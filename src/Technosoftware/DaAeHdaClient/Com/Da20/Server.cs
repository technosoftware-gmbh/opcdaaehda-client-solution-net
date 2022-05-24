#region Copyright (c) 2011-2022 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2022 Technosoftware GmbH. All rights reserved
// Web: https://www.technosoftware.com 
// 
// The source code in this file is covered under a dual-license scenario:
//   - Owner of a purchased license: SCLA 1.0
//   - GPL V3: everybody else
//
// SCLA license terms accompanied with this source code.
// See SCLA 1.0://technosoftware.com/license/Source_Code_License_Agreement.pdf
//
// GNU General Public License as published by the Free Software Foundation;
// version 3 of the License are accompanied with this source code.
// See https://technosoftware.com/license/GPLv3License.txt
//
// This source code is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
// or FITNESS FOR A PARTICULAR PURPOSE.
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2022 Technosoftware GmbH. All rights reserved

#region Using Directives
using System;
using System.Collections;
using System.Runtime.InteropServices;

using Technosoftware.DaAeHdaClient.Da;
using Technosoftware.DaAeHdaClient.Com.Da;
using Technosoftware.DaAeHdaClient.Utilities;

using OpcRcw.Da;
using OpcRcw.Comn;

#endregion

namespace Technosoftware.DaAeHdaClient.Com.Da20
{
    /// <summary>
    /// An in-process wrapper for a remote OPC Data Access 2.0X server.
    /// </summary>
    internal class Server : Technosoftware.DaAeHdaClient.Com.Da.Server
    {

        #region Constructors
        /// <summary>
        /// The default constructor for the object.
        /// </summary>
        internal Server() { }

        /// <summary>
        /// Initializes the object with the specified COM server.
        /// </summary>
        internal Server(OpcUrl url, object unknown) : base(url, unknown) { }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// This must be called explicitly by clients to ensure the COM server is released.
        /// </summary>
        public void Dispose()
        {
            lock (this)
            {
                if (subscription_ != null)
                {
                    string methodName = "IOPCServer.RemoveGroup";
                    try
                    {
                        IOPCServer server = BeginComCall<IOPCServer>(methodName, true);
                        server.RemoveGroup(groupHandle_, 0);
                    }
                    catch (Exception e)
                    {
                        ComCallError(methodName, e);
                    }
                    finally
                    {
                        EndComCall(methodName);
                    }

                    Utilities.Interop.ReleaseServer(subscription_);
                    subscription_ = null;
                    groupHandle_ = 0;

                    base.Dispose();
                }
            }
        }
        #endregion
        
        //======================================================================
        // Connection Management

        /// <summary>
        /// Connects to the server with the specified URL and credentials.
        /// </summary>
        public override void Initialize(OpcUrl url, OpcConnectData connectData)
        {
            lock (this)
            {
                // connect to server.
                base.Initialize(url, connectData);

                separators_ = null;
                string methodName = "IOPCCommon.GetLocaleID";

                // create a global subscription required for various item level operations.
                int localeID = 0;
                try
                {
                    // get the default locale for the server.
                    IOPCCommon server = BeginComCall<IOPCCommon>(methodName, true);
                    server.GetLocaleID(out localeID);
                }
                catch (Exception e)
                {
                    Uninitialize();
                    ComCallError(methodName, e);
                    throw Utilities.Interop.CreateException(methodName, e);
                }
                finally
                {
                    EndComCall(methodName);
                }

                // create a global subscription required for various item level operations.
                methodName = "IOPCServer.AddGroup";
                try
                {                  
                    // add the subscription.
                    int revisedUpdateRate = 0;
                    Guid iid = typeof(IOPCItemMgt).GUID;

                    IOPCServer server = BeginComCall<IOPCServer>(methodName, true);
                    ((IOPCServer)server).AddGroup(
                        "",
                        1,
                        500,
                        0,
                        IntPtr.Zero,
                        IntPtr.Zero,
                        localeID,
                        out groupHandle_,
                        out revisedUpdateRate,
                        ref iid,
                        out subscription_);

                    if (DCOMCallWatchdog.IsCancelled)
                    {
                        throw new Exception($"{methodName} call was cancelled due to response timeout");
                    }
                }
                catch (Exception e)
                {
                    Uninitialize();
                    ComCallError(methodName, e);
                    throw Utilities.Interop.CreateException(methodName, e);
                }
                finally
                {
                    EndComCall(methodName);                  
                }
            }
        }

        //======================================================================
        // Private Members

        /// <summary>
        /// A global subscription used for various item level operations. 
        /// </summary>
        private object subscription_ = null;

        /// <summary>
        /// The server handle for the global subscription.
        /// </summary>
        private int groupHandle_ = 0;

        /// <summary>
        /// True if BROWSE_TO is supported; otherwise false.
        /// </summary>
        private bool browseToSupported_ = true;

        /// <summary>
        /// A list of seperators used in the browse paths.
        /// </summary>
        private char[] separators_ = null;
        private object separatorsLock_ = new object();

        //======================================================================
        // Read

        /// <summary>
        /// Reads the values for the specified items.
        /// </summary>
        public override TsCDaItemValueResult[] Read(TsCDaItem[] items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            // check if nothing to do.
            if (items.Length == 0)
            {
                return new TsCDaItemValueResult[0];
            }

            lock (this)
            {
                if (server_ == null) throw new NotConnectedException();

                // create temporary items.
                OpcItemResult[] temporaryItems = AddItems(items);
                TsCDaItemValueResult[] results = new TsCDaItemValueResult[items.Length];

                try
                {
                    // construct return values.
                    ArrayList cacheItems = new ArrayList(items.Length);
                    ArrayList cacheResults = new ArrayList(items.Length);
                    ArrayList deviceItems = new ArrayList(items.Length);
                    ArrayList deviceResults = new ArrayList(items.Length);

                    for (int ii = 0; ii < items.Length; ii++)
                    {
                        results[ii] = new TsCDaItemValueResult(temporaryItems[ii]);

                        if (temporaryItems[ii].Result.Failed())
                        {
                            results[ii].Result = temporaryItems[ii].Result;
                            results[ii].DiagnosticInfo = temporaryItems[ii].DiagnosticInfo;
                            continue;
                        }

                        if (items[ii].MaxAgeSpecified && (items[ii].MaxAge < 0 || items[ii].MaxAge == Int32.MaxValue))
                        {
                            cacheItems.Add(items[ii]);
                            cacheResults.Add(results[ii]);
                        }
                        else
                        {
                            deviceItems.Add(items[ii]);
                            deviceResults.Add(results[ii]);
                        }
                    }

                    // read values from the cache.
                    if (cacheResults.Count > 0)
                    {
                        string methodName = "IOPCItemMgt.SetActiveState";
                        // items must be active for cache reads.
                        try
                        {                           
                            // create list of server handles.
                            int[] serverHandles = new int[cacheResults.Count];

                            for (int ii = 0; ii < cacheResults.Count; ii++)
                            {
                                serverHandles[ii] = (int)((TsCDaItemValueResult)cacheResults[ii]).ServerHandle;
                            }

                            IntPtr pErrors = IntPtr.Zero;

                            IOPCItemMgt subscription = BeginComCall<IOPCItemMgt>(subscription_, methodName, true);
                            subscription.SetActiveState(
                                cacheResults.Count,
                                serverHandles,
                                1,
                                out pErrors);

                            // free error array.
                            Marshal.FreeCoTaskMem(pErrors);

                            if (DCOMCallWatchdog.IsCancelled)
                            {
                                throw new Exception($"{methodName} call was cancelled due to response timeout");
                            }
                        }
                        catch (Exception e)
                        {
                            ComCallError(methodName, e);
                            throw Utilities.Interop.CreateException(methodName, e);
                        }
                        finally
                        {
                            EndComCall(methodName);
                        }

                        // read the values.
                        ReadValues(
                            (TsCDaItem[])cacheItems.ToArray(typeof(TsCDaItem)),
                            (TsCDaItemValueResult[])cacheResults.ToArray(typeof(TsCDaItemValueResult)),
                            true);
                    }

                    // read values from the device.
                    if (deviceResults.Count > 0)
                    {
                        ReadValues(
                            (TsCDaItem[])deviceItems.ToArray(typeof(TsCDaItem)),
                            (TsCDaItemValueResult[])deviceResults.ToArray(typeof(TsCDaItemValueResult)),
                            false);
                    }
                }

                // remove temporary items after read.
                finally
                {
                    RemoveItems(temporaryItems);
                }

                // return results.
                return results;
            }
        }

        //======================================================================
        // Write

        /// <summary>
        /// Write the values for the specified items.
        /// </summary>
        public override OpcItemResult[] Write(TsCDaItemValue[] items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            // check if nothing to do.
            if (items.Length == 0)
            {
                return new OpcItemResult[0];
            }

            lock (this)
            {
                if (server_ == null) throw new NotConnectedException();

                // create item objects to add temporary items.
                TsCDaItem[] groupItems = new TsCDaItem[items.Length];

                for (int ii = 0; ii < items.Length; ii++)
                {
                    groupItems[ii] = new TsCDaItem(items[ii]);
                }

                // create temporary items.
                OpcItemResult[] results = AddItems(groupItems);

                try
                {
                    // construct list of valid items to write.
                    ArrayList writeItems = new ArrayList(items.Length);
                    ArrayList writeValues = new ArrayList(items.Length);

                    for (int ii = 0; ii < items.Length; ii++)
                    {
                        if (results[ii].Result.Failed())
                        {
                            continue;
                        }

                        if (items[ii].QualitySpecified || items[ii].TimestampSpecified)
                        {
                            results[ii].Result = OpcResult.Da.E_NO_WRITEQT;
                            results[ii].DiagnosticInfo = null;
                            continue;
                        }

                        writeItems.Add(results[ii]);
                        writeValues.Add(items[ii]);
                    }

                    // read values from the cache.
                    if (writeItems.Count > 0)
                    {
                        // initialize input parameters.
                        int[] serverHandles = new int[writeItems.Count];
                        object[] values = new object[writeItems.Count];

                        for (int ii = 0; ii < serverHandles.Length; ii++)
                        {
                            serverHandles[ii] = (int)((OpcItemResult)writeItems[ii]).ServerHandle;
                            values[ii] = Utilities.Interop.GetVARIANT(((TsCDaItemValue)writeValues[ii]).Value);
                        }

                        IntPtr pErrors = IntPtr.Zero;

                        // write item values.
                        string methodName = "IOPCSyncIO.Write";
                        try
                        {                   
                            IOPCSyncIO subscription = BeginComCall<IOPCSyncIO>(subscription_, methodName, true);
                            subscription.Write(
                                writeItems.Count,
                                serverHandles,
                                values,
                                out pErrors);

                            if (DCOMCallWatchdog.IsCancelled)
                            {
                                throw new Exception($"{methodName} call was cancelled due to response timeout");
                            }
                        }
                        catch (Exception e)
                        {
                            ComCallError(methodName, e);
                            throw Utilities.Interop.CreateException(methodName, e);
                        }
                        finally
                        {
                            EndComCall(methodName);
                        }

                        // unmarshal results.
                        int[] errors = Utilities.Interop.GetInt32s(ref pErrors, writeItems.Count, true);

                        for (int ii = 0; ii < writeItems.Count; ii++)
                        {
                            OpcItemResult result = (OpcItemResult)writeItems[ii];

                            result.Result = Utilities.Interop.GetResultId(errors[ii]);
                            result.DiagnosticInfo = null;

                            // convert COM code to unified DA code.
                            if (errors[ii] == Result.E_BADRIGHTS) { results[ii].Result = new OpcResult(OpcResult.Da.E_READONLY, Result.E_BADRIGHTS); }
                        }
                    }
                }

                // remove temporary items
                finally
                {
                    RemoveItems(results);
                }

                // return results.
                return results;
            }
        }

        //======================================================================
        // Browse

        /// <summary>
        /// Fetches child elements of the specified branch which match the filter criteria.
        /// </summary>
        public override TsCDaBrowseElement[] Browse(
            OpcItem itemId,
            TsCDaBrowseFilters filters,
            out TsCDaBrowsePosition position)
        {
            if (filters == null) throw new ArgumentNullException(nameof(filters));

            position = null;

            lock (this)
            {
                if (server_ == null) throw new NotConnectedException();

                BrowsePosition pos = null;

                ArrayList elements = new ArrayList();

                // search for child branches.
                if (filters.BrowseFilter != TsCDaBrowseFilter.Item)
                {
                    TsCDaBrowseElement[] branches = GetElements(elements.Count, itemId, filters, true, ref pos);

                    if (branches != null)
                    {
                        elements.AddRange(branches);
                    }

                    position = pos;

                    // return current set if browse halted.
                    if (position != null)
                    {
                        return (TsCDaBrowseElement[])elements.ToArray(typeof(TsCDaBrowseElement));
                    }
                }

                // search for child items.
                if (filters.BrowseFilter != TsCDaBrowseFilter.Branch)
                {
                    TsCDaBrowseElement[] items = GetElements(elements.Count, itemId, filters, false, ref pos);

                    if (items != null)
                    {
                        elements.AddRange(items);
                    }

                    position = pos;
                }

                // return the elements.
                return (TsCDaBrowseElement[])elements.ToArray(typeof(TsCDaBrowseElement));
            }
        }

        //======================================================================
        // BrowseNext

        /// <summary>
        /// Continues a browse operation with previously specified search criteria.
        /// </summary>
		public override TsCDaBrowseElement[] BrowseNext(ref TsCDaBrowsePosition position)
        {
            lock (this)
            {
                if (server_ == null) throw new NotConnectedException();

                // check for valid browse position object.
                if (position == null && position.GetType() != typeof(BrowsePosition))
                {
                    throw new OpcResultException(new OpcResult((int)OpcResult.E_FAIL.Code, OpcResult.FuncCallType.SysFuncCall, null), "The browse operation cannot continue");
                }

                BrowsePosition pos = (BrowsePosition)position;

                OpcItem itemID = pos.ItemID;
                TsCDaBrowseFilters filters = pos.Filters;

                ArrayList elements = new ArrayList();

                // search for child branches.
                if (pos.IsBranch)
                {
                    TsCDaBrowseElement[] branches = GetElements(elements.Count, itemID, filters, true, ref pos);

                    if (branches != null)
                    {
                        elements.AddRange(branches);
                    }

                    position = pos;

                    // return current set if browse halted.
                    if (position != null)
                    {
                        return (TsCDaBrowseElement[])elements.ToArray(typeof(TsCDaBrowseElement));
                    }
                }

                // search for child items.
                if (filters.BrowseFilter != TsCDaBrowseFilter.Branch)
                {
                    TsCDaBrowseElement[] items = GetElements(elements.Count, itemID, filters, false, ref pos);

                    if (items != null)
                    {
                        elements.AddRange(items);
                    }

                    position = pos;
                }

                // return the elements.
                return (TsCDaBrowseElement[])elements.ToArray(typeof(TsCDaBrowseElement));
            }
        }

        //======================================================================
        // GetProperties

        /// <summary>
        /// Returns the specified properties for a set of items.
        /// </summary>
        public override TsCDaItemPropertyCollection[] GetProperties(
            OpcItem[] itemIds,
            TsDaPropertyID[] propertyIDs,
            bool returnValues)
        {
            if (itemIds == null) throw new ArgumentNullException(nameof(itemIds));

            // check for trival case.
            if (itemIds.Length == 0)
            {
                return new TsCDaItemPropertyCollection[0];
            }

            lock (this)
            {
                if (server_ == null) throw new NotConnectedException();

                // initialize list of property lists.
                TsCDaItemPropertyCollection[] propertyLists = new TsCDaItemPropertyCollection[itemIds.Length];

                for (int ii = 0; ii < itemIds.Length; ii++)
                {
                    propertyLists[ii] = new TsCDaItemPropertyCollection();

                    propertyLists[ii].ItemName = itemIds[ii].ItemName;
                    propertyLists[ii].ItemPath = itemIds[ii].ItemPath;

                    // fetch properties for item.
                    try
                    {
                        TsCDaItemProperty[] properties = GetProperties(itemIds[ii].ItemName, propertyIDs, returnValues);

                        if (properties != null)
                        {
                            propertyLists[ii].AddRange(properties);
                        }

                        propertyLists[ii].Result = OpcResult.S_OK;
                    }
                    catch (OpcResultException e)
                    {
                        propertyLists[ii].Result = e.Result;
                    }
                    catch (Exception e)
                    {
                        propertyLists[ii].Result = new OpcResult(Marshal.GetHRForException(e));
                    }
                }

                // return property lists.
                return propertyLists;
            }
        }

        //======================================================================
        // Private Methods

        /// <summary>
        /// Adds a set of temporary items used for a read/write operation.
        /// </summary>
        private OpcItemResult[] AddItems(TsCDaItem[] items)
        {
            // add items to subscription.
            int count = items.Length;

            OPCITEMDEF[] definitions = Technosoftware.DaAeHdaClient.Com.Da.Interop.GetOPCITEMDEFs(items);

            // ensure all items are created as inactive.
            for (int ii = 0; ii < definitions.Length; ii++)
            {
                definitions[ii].bActive = 0;
            }

            // initialize output parameters.
            IntPtr pResults = IntPtr.Zero;
            IntPtr pErrors = IntPtr.Zero;

            // get the default current for the server.
            int localeID = 0;
            ((IOPCCommon)server_).GetLocaleID(out localeID);

            GCHandle hLocale = GCHandle.Alloc(localeID, GCHandleType.Pinned);
                     
            string methodName = "IOPCGroupStateMgt.SetState";
            try
            {
                int updateRate = 0;

                // ensure the current locale is correct.
                IOPCGroupStateMgt subscription = BeginComCall<IOPCGroupStateMgt>(subscription_, methodName, true);
                ((IOPCGroupStateMgt)subscription).SetState(
                    IntPtr.Zero,
                    out updateRate,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    hLocale.AddrOfPinnedObject(),
                    IntPtr.Zero);

                if (DCOMCallWatchdog.IsCancelled)
                {
                    throw new Exception($"{methodName} call was cancelled due to response timeout");
                }
            }
            catch (Exception e)
            {
                ComCallError(methodName, e);
                throw Utilities.Interop.CreateException(methodName, e);
            }
            finally
            {
                if (hLocale.IsAllocated) hLocale.Free();
                EndComCall(methodName);                
            }
         
            // add items to subscription.
            methodName = "IOPCItemMgt.AddItems";
            try
            {
                IOPCItemMgt subscription = BeginComCall<IOPCItemMgt>(subscription_, methodName, true);
                subscription.AddItems(
                    count,
                    definitions,
                    out pResults,
                    out pErrors);

                if (DCOMCallWatchdog.IsCancelled)
                {
                    throw new Exception($"{methodName} call was cancelled due to response timeout");
                }
            }
            catch (Exception e)
            {
                ComCallError(methodName, e);
                throw Utilities.Interop.CreateException(methodName, e);
            }
            finally
            {
                EndComCall(methodName);
                if (hLocale.IsAllocated) hLocale.Free();
            }
          
            // unmarshal output parameters.
            int[] serverHandles = Technosoftware.DaAeHdaClient.Com.Da.Interop.GetItemResults(ref pResults, count, true);
            int[] errors = Utilities.Interop.GetInt32s(ref pErrors, count, true);

            // create results list.
            OpcItemResult[] results = new OpcItemResult[count];

            for (int ii = 0; ii < count; ii++)
            {
                results[ii] = new OpcItemResult(items[ii]);

                results[ii].ServerHandle = null;
                results[ii].Result = Utilities.Interop.GetResultId(errors[ii]);
                results[ii].DiagnosticInfo = null;

                if (results[ii].Result.Succeeded())
                {
                    results[ii].ServerHandle = serverHandles[ii];
                }
            }

            // return results.
            return results;
        }

        /// <summary>
        /// Removes a set of temporary items used for a read/write operation.
        /// </summary>
        private void RemoveItems(OpcItemResult[] items)
        {
            try
            {
                // contruct array of valid server handles.
                ArrayList handles = new ArrayList(items.Length);

                foreach (OpcItemResult item in items)
                {
                    if (item.Result.Succeeded() && item.ServerHandle.GetType() == typeof(int))
                    {
                        handles.Add((int)item.ServerHandle);
                    }
                }

                // check if nothing to do.
                if (handles.Count == 0)
                {
                    return;
                }

                // remove items from server.
                IntPtr pErrors = IntPtr.Zero;

                string methodName = "IOPCItemMgt.RemoveItems";
                try
                {              
                    IOPCItemMgt subscription = BeginComCall<IOPCItemMgt>(subscription_, methodName, true);
                    ((IOPCItemMgt)subscription).RemoveItems(
                        handles.Count,
                        (int[])handles.ToArray(typeof(int)),
                        out pErrors);

                    if (DCOMCallWatchdog.IsCancelled)
                    {
                        throw new Exception($"{methodName} call was cancelled due to response timeout");
                    }

                }
                catch (Exception e)
                {
                    ComCallError(methodName, e);
                    throw Utilities.Interop.CreateException(methodName, e);
                }
                finally
                {
                    EndComCall(methodName);
                    // free returned error array.
                    Utilities.Interop.GetInt32s(ref pErrors, handles.Count, true);
                }

            }
            catch
            {
                // ignore errors.
            }
        }

        /// <summary>
        /// Reads a set of values.
        /// </summary>
        private void ReadValues(TsCDaItem[] items, TsCDaItemValueResult[] results, bool cache)
        {
            if (items.Length == 0 || results.Length == 0) return;

            // marshal input parameters.
            int[] serverHandles = new int[results.Length];

            for (int ii = 0; ii < results.Length; ii++)
            {
                serverHandles[ii] = Convert.ToInt32(results[ii].ServerHandle);
            }

            // initialize output parameters.
            IntPtr pValues = IntPtr.Zero;
            IntPtr pErrors = IntPtr.Zero;

            string methodName = "IOPCSyncIO.Read";
            try
            {         
                IOPCSyncIO subscription = BeginComCall<IOPCSyncIO>(subscription_, methodName, true);
                subscription.Read(
                    (cache) ? OPCDATASOURCE.OPC_DS_CACHE : OPCDATASOURCE.OPC_DS_DEVICE,
                    results.Length,
                    serverHandles,
                    out pValues,
                    out pErrors);

                if (DCOMCallWatchdog.IsCancelled)
                {
                    throw new Exception($"{methodName} call was cancelled due to response timeout");
                }
            }
            catch (Exception e)
            {
                ComCallError(methodName, e);
                throw Utilities.Interop.CreateException(methodName, e);
            }
            finally
            {
                EndComCall(methodName);
                // free returned error array.
            }

            // unmarshal output parameters.
            TsCDaItemValue[] values = Technosoftware.DaAeHdaClient.Com.Da.Interop.GetItemValues(ref pValues, results.Length, true);
            int[] errors = Utilities.Interop.GetInt32s(ref pErrors, results.Length, true);

            // pre-fetch the current locale to use for data conversions.
            string locale = GetLocale();

            // construct results list.
            for (int ii = 0; ii < results.Length; ii++)
            {
                results[ii].Result = Utilities.Interop.GetResultId(errors[ii]);
                results[ii].DiagnosticInfo = null;

                if (results[ii].Result.Succeeded())
                {
                    results[ii].Value = values[ii].Value;
                    results[ii].Quality = values[ii].Quality;
                    results[ii].QualitySpecified = values[ii].QualitySpecified;
                    results[ii].Timestamp = values[ii].Timestamp;
                    results[ii].TimestampSpecified = values[ii].TimestampSpecified;
                }

                // convert COM code to unified DA code.
                if (errors[ii] == Result.E_BADRIGHTS) { results[ii].Result = new OpcResult(OpcResult.Da.E_WRITEONLY, Result.E_BADRIGHTS); }

                // convert the data type since the server does not support the feature.
                if (results[ii].Value != null && items[ii].ReqType != null)
                {
                    try
                    {
                        results[ii].Value = ChangeType(results[ii].Value, items[ii].ReqType, "en-US");
                    }
                    catch (Exception e)
                    {
                        results[ii].Value = null;
                        results[ii].Quality = TsCDaQuality.Bad;
                        results[ii].QualitySpecified = true;
                        results[ii].Timestamp = DateTime.MinValue;
                        results[ii].TimestampSpecified = false;

                        if (e.GetType() == typeof(OverflowException))
                        {
                            results[ii].Result = Utilities.Interop.GetResultId(Result.E_RANGE);
                        }
                        else
                        {
                            results[ii].Result = Utilities.Interop.GetResultId(Result.E_BADTYPE);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns the set of available properties for the item.
        /// </summary>
        private TsCDaItemProperty[] GetAvailableProperties(string itemID)
        {
            // validate argument.
            if (itemID == null || itemID.Length == 0)
            {
                throw new OpcResultException(OpcResult.Da.E_INVALID_ITEM_NAME);
            }

            // query for available properties.
            int count = 0;

            IntPtr pPropertyIDs = IntPtr.Zero;
            IntPtr pDescriptions = IntPtr.Zero;
            IntPtr pDataTypes = IntPtr.Zero;

            string methodName = "IOPCItemProperties.QueryAvailableProperties";
            try
            {          
                IOPCItemProperties server = BeginComCall<IOPCItemProperties>(methodName, true);
                server.QueryAvailableProperties(
                    itemID,
                    out count,
                    out pPropertyIDs,
                    out pDescriptions,
                    out pDataTypes);

                if (DCOMCallWatchdog.IsCancelled)
                {
                    throw new Exception($"{methodName} call was cancelled due to response timeout");
                }

            }
            catch (Exception e)
            {
                ComCallError(methodName, e);
                throw new OpcResultException(OpcResult.Da.E_UNKNOWN_ITEM_NAME);
            }
            finally
            {
                EndComCall(methodName);
                // free returned error array.                
            }

            // unmarshal results.
            int[] propertyIDs = Utilities.Interop.GetInt32s(ref pPropertyIDs, count, true);
            short[] datatypes = Utilities.Interop.GetInt16s(ref pDataTypes, count, true);
            string[] descriptions = Utilities.Interop.GetUnicodeStrings(ref pDescriptions, count, true);

            // check for error condition.
            if (count == 0)
            {
                return null;
            }

            // initialize property objects.
            TsCDaItemProperty[] properties = new TsCDaItemProperty[count];

            for (int ii = 0; ii < count; ii++)
            {
                properties[ii] = new TsCDaItemProperty();

                properties[ii].ID = Technosoftware.DaAeHdaClient.Com.Da.Interop.GetPropertyID(propertyIDs[ii]);
                properties[ii].Description = descriptions[ii];
                properties[ii].DataType = Utilities.Interop.GetType((VarEnum)datatypes[ii]);
                properties[ii].ItemName = null;
                properties[ii].ItemPath = null;
                properties[ii].Result = OpcResult.S_OK;
                properties[ii].Value = null;
            }

            // return property list.
            return properties;
        }

        /// <summary>
        /// Fetches the property item id for the specified set of properties.
        /// </summary>
        private void GetItemIDs(string itemID, TsCDaItemProperty[] properties)
        {
            try
            {
                // create input arguments;
                int[] propertyIDs = new int[properties.Length];

                for (int ii = 0; ii < properties.Length; ii++)
                {
                    propertyIDs[ii] = properties[ii].ID.Code;
                }

                // lookup item ids.
                IntPtr pItemIDs = IntPtr.Zero;
                IntPtr pErrors = IntPtr.Zero;
                             
                ((IOPCItemProperties)server_).LookupItemIDs(
                    itemID,
                    properties.Length,
                    propertyIDs,
                    out pItemIDs,
                    out pErrors);              

                // unmarshal results.
                string[] itemIDs = Utilities.Interop.GetUnicodeStrings(ref pItemIDs, properties.Length, true);
                int[] errors = Utilities.Interop.GetInt32s(ref pErrors, properties.Length, true);

                // update property objects.
                for (int ii = 0; ii < properties.Length; ii++)
                {
                    properties[ii].ItemName = null;
                    properties[ii].ItemPath = null;

                    if (errors[ii] >= 0)
                    {
                        properties[ii].ItemName = itemIDs[ii];
                    }
                }
            }
            catch (Exception e)
            {
                // set item ids to null for all properties.
                foreach (TsCDaItemProperty property in properties)
                {
                    property.ItemName = null;
                    property.ItemPath = null;
                }
            }
        }

        /// <summary>
        /// Fetches the property values for the specified set of properties.
        /// </summary>
        private void GetValues(string itemID, TsCDaItemProperty[] properties)
        {
            try
            {
                // create input arguments;
                int[] propertyIDs = new int[properties.Length];

                for (int ii = 0; ii < properties.Length; ii++)
                {
                    propertyIDs[ii] = properties[ii].ID.Code;
                }

                // lookup item ids.
                IntPtr pValues = IntPtr.Zero;
                IntPtr pErrors = IntPtr.Zero;

                ((IOPCItemProperties)server_).GetItemProperties(
                    itemID,
                    properties.Length,
                    propertyIDs,
                    out pValues,
                    out pErrors);

                // unmarshal results.
                object[] values = Interop.GetVARIANTs(ref pValues, properties.Length, true);
                int[] errors = Utilities.Interop.GetInt32s(ref pErrors, properties.Length, true);

                // update property objects.
                for (int ii = 0; ii < properties.Length; ii++)
                {
                    properties[ii].Value = null;

                    // ignore value for invalid properties.
                    if (!properties[ii].Result.Succeeded())
                    {
                        continue;
                    }

                    properties[ii].Result = Utilities.Interop.GetResultId(errors[ii]);

                    // substitute property reult code.
                    if (errors[ii] == Result.E_BADRIGHTS)
                    {
                        properties[ii].Result = new OpcResult(OpcResult.Da.E_WRITEONLY, Result.E_BADRIGHTS);
                    }

                    if (properties[ii].Result.Succeeded())
                    {
                        properties[ii].Value = Technosoftware.DaAeHdaClient.Com.Da.Interop.UnmarshalPropertyValue(properties[ii].ID, values[ii]);
                    }
                }
            }
            catch (Exception e)
            {
                // set general error code as the result for each property.
                OpcResult result = new OpcResult(Marshal.GetHRForException(e));

                foreach (TsCDaItemProperty property in properties)
                {
                    property.Value = null;
                    property.Result = result;
                }
            }
        }

        /// <summary>
        /// Gets the specified properties for the specified item.
        /// </summary>
        private TsCDaItemProperty[] GetProperties(string itemID, TsDaPropertyID[] propertyIDs, bool returnValues)
        {
            TsCDaItemProperty[] properties = null;

            // return all available properties.
            if (propertyIDs == null)
            {
                properties = GetAvailableProperties(itemID);
            }

            // return on the selected properties.
            else
            {
                // get available properties.
                TsCDaItemProperty[] availableProperties = GetAvailableProperties(itemID);

                // initialize result list.
                properties = new TsCDaItemProperty[propertyIDs.Length];

                for (int ii = 0; ii < propertyIDs.Length; ii++)
                {
                    // search available property list for specified property.
                    foreach (TsCDaItemProperty property in availableProperties)
                    {
                        if (property.ID == propertyIDs[ii])
                        {
                            properties[ii] = (TsCDaItemProperty)property.Clone();
                            properties[ii].ID = propertyIDs[ii];
                            break;
                        }
                    }

                    // property not valid for the item.
                    if (properties[ii] == null)
                    {
                        properties[ii] = new TsCDaItemProperty();

                        properties[ii].ID = propertyIDs[ii];
                        properties[ii].Result = OpcResult.Da.E_INVALID_PID;
                    }
                }
            }

            // fill in missing fields in property objects.
            if (properties != null)
            {
                GetItemIDs(itemID, properties);

                if (returnValues)
                {
                    GetValues(itemID, properties);
                }
            }

            // return property list.
            return properties;
        }


        /// <summary>
        /// Returns an enumerator for the children of the specified branch.
        /// </summary>
        private EnumString GetEnumerator(string itemID, TsCDaBrowseFilters filters, bool branches, bool flat)
        {
            var browser = (IOPCBrowseServerAddressSpace)server_;

            if (!flat)
            {
                if (itemID == null)
                {
                    if (browseToSupported_)
                    {
                        // move to the root of the hierarchial address spaces.
                        try
                        {
                            string id = String.Empty;
                            browser.ChangeBrowsePosition(OPCBROWSEDIRECTION.OPC_BROWSE_TO, id);
                        }
                        catch (Exception e)
                        {
                            string message = String.Format("ChangeBrowsePosition to root with BROWSE_TO={0} failed with error {1}. BROWSE_TO not supported.", String.Empty, e.Message);
                            browseToSupported_ = false;
                        }
                    }
                    if (!browseToSupported_)
                    {
                        // browse to root.
                        while (true)
                        {
                            try
                            {
                                browser.ChangeBrowsePosition(OPCBROWSEDIRECTION.OPC_BROWSE_UP, String.Empty);
                            }
                            catch (Exception)
                            {
                                break;                                                               
                            }
                        }
                    }
                }
                else
                {
                    // move to the specified branch for hierarchial address spaces.
                    string id = (itemID != null) ? itemID : "";
                    if (browseToSupported_)
                    {
                        try
                        {
                            browser.ChangeBrowsePosition(OPCBROWSEDIRECTION.OPC_BROWSE_TO, id);
                        }
                        catch (Exception)
                        {
                            browseToSupported_ = false;
                        }
                    }
                    if (!browseToSupported_)
                    {
                        // try to browse down instead.
                        try
                        {
                            browser.ChangeBrowsePosition(OPCBROWSEDIRECTION.OPC_BROWSE_DOWN, id);
                        }
                        catch (Exception)
                        {

                            // browse to root.
                            while (true)
                            {
                                try
                                {
                                    browser.ChangeBrowsePosition(OPCBROWSEDIRECTION.OPC_BROWSE_UP, String.Empty);
                                }
                                catch (Exception)
                                {
                                    break;
                                }
                            }

                            // parse the browse path.
                            string[] paths = null;

                            lock (separatorsLock_)
                            {
                                if (separators_ != null)
                                {
                                    paths = id.Split(separators_);
                                }
                                else
                                {
                                    paths = id.Split(separators_);
                                }
                            }

                            // browse to correct location.
                            for (int ii = 0; ii < paths.Length; ii++)
                            {
                                if (paths[ii] == null || paths[ii].Length == 0)
                                {
                                    continue;
                                }

                                try
                                {
                                    browser.ChangeBrowsePosition(OPCBROWSEDIRECTION.OPC_BROWSE_DOWN, paths[ii]);
                                }
                                catch (Exception)
                                {
                                    throw new OpcResultException(OpcResult.Da.E_UNKNOWN_ITEM_NAME);
                                }
                            }
                        }
                    }
                }
            }

            try
            {
                // create the enumerator.
                IEnumString enumerator = null;

                OPCBROWSETYPE browseType = (branches) ? OPCBROWSETYPE.OPC_BRANCH : OPCBROWSETYPE.OPC_LEAF;

                if (flat)
                {
                    browseType = OPCBROWSETYPE.OPC_FLAT;
                }

                browser.BrowseOPCItemIDs(
                    browseType,
                    (filters.ElementNameFilter != null) ? filters.ElementNameFilter : "",
                    (short)VarEnum.VT_EMPTY,
                    0,
                    out enumerator);

                // return the enumerator.
                return new EnumString(enumerator);
            }
            catch (Exception)
            {
                throw new OpcResultException(OpcResult.Da.E_UNKNOWN_ITEM_NAME);
            }
        }


        /// <summary>
        /// Detects the separators used in the item id.
        /// </summary>
        private void DetectAndSaveSeparators(string browseName, string itemID)
        {
            if (!itemID.EndsWith(browseName))
            {
                return;
            }

            if (string.Compare(itemID, browseName, true) == 0)
            {
                return;
            }

            char separator = itemID[itemID.Length - browseName.Length - 1];

            lock (separatorsLock_)
            {
                int index = -1;

                if (separators_ != null)
                {
                    for (int ii = 0; ii < separators_.Length; ii++)
                    {
                        if (separators_[ii] == separator)
                        {
                            index = ii;
                            break;
                        }
                    }

                    if (index == -1)
                    {
                        char[] separators = new char[separators_.Length + 1];
                        Array.Copy(separators_, separators, separators_.Length);
                        separators_ = separators;
                    }
                }

                if (index == -1)
                {
                    if (separators_ == null)
                    {
                        separators_ = new char[1];
                    }

                    separators_[separators_.Length - 1] = separator;
                }
            }
        }

        /// <summary>
        /// Reads a single value from the enumerator and returns a browse element.
        /// </summary>
        private TsCDaBrowseElement GetElement(
        OpcItem itemID,
                string name,
                TsCDaBrowseFilters filters,
                bool isBranch)
        {
            if (name == null)
            {
                return null;
            }

            TsCDaBrowseElement element = new TsCDaBrowseElement();

            element.Name = name;
            element.HasChildren = isBranch;
            element.ItemPath = null;

            // get item id.
            try
            {
                string itemName = null;
                ((IOPCBrowseServerAddressSpace)server_).GetItemID(element.Name, out itemName);
                element.ItemName = itemName;

                // detect separator.
                if (element.ItemName != null)
                {
                    DetectAndSaveSeparators(element.Name, element.ItemName);
                }
            }

            // this is an error that should not occur.
            catch
            {
                element.ItemName = name;
            }

            // check if element is an actual item or just a branch.
            try
            {
                OPCITEMDEF definition = new OPCITEMDEF();

                definition.szItemID = element.ItemName;
                definition.szAccessPath = null;
                definition.hClient = 0;
                definition.bActive = 0;
                definition.vtRequestedDataType = (short)VarEnum.VT_EMPTY;
                definition.dwBlobSize = 0;
                definition.pBlob = IntPtr.Zero;

                IntPtr pResults = IntPtr.Zero;
                IntPtr pErrors = IntPtr.Zero;

                // validate item.
                ((IOPCItemMgt)subscription_).ValidateItems(
                    1,
                    new OPCITEMDEF[] { definition },
                    0,
                    out pResults,
                    out pErrors);

                // free results.
                Technosoftware.DaAeHdaClient.Com.Da.Interop.GetItemResults(ref pResults, 1, true);

                int[] errors = Utilities.Interop.GetInt32s(ref pErrors, 1, true);

                // can only be an item if validation succeeded.
                element.IsItem = (errors[0] >= 0);
            }

            // this is an error that should not occur - must be a branch.
            catch
            {
                element.IsItem = false;
                // Because ABB Real-TPI server always return ItemName == null we use Name instead to fix browsing problem
                element.ItemName = element.Name;
            }


            // fetch item properties.
            try
            {
                if (filters.ReturnAllProperties)
                {
                    element.Properties = GetProperties(element.ItemName, null, filters.ReturnPropertyValues);
                }
                else if (filters.PropertyIDs != null)
                {
                    element.Properties = GetProperties(element.ItemName, filters.PropertyIDs, filters.ReturnPropertyValues);
                }
            }

            // return no properties if an error fetching properties occurred.
            catch
            {
                element.Properties = null;
            }

            // return new element.
            return element;
        }

        /// <summary>
        /// Returns a list of child elements that meet the filter criteria.
        /// </summary>
        private TsCDaBrowseElement[] GetElements(
            int elementsFound,
            OpcItem itemID,
            TsCDaBrowseFilters filters,
            bool branches,
            ref BrowsePosition position)
        {
            // get the enumerator.
            EnumString enumerator = null;

            if (position == null)
            {
                IOPCBrowseServerAddressSpace browser = (IOPCBrowseServerAddressSpace)server_;

                // check the server address space type.
                OPCNAMESPACETYPE namespaceType = OPCNAMESPACETYPE.OPC_NS_HIERARCHIAL;

                try
                {
                    browser.QueryOrganization(out namespaceType);
                }
                catch (Exception e)
                {
                    throw Utilities.Interop.CreateException("IOPCBrowseServerAddressSpace.QueryOrganization", e);
                }

                // return an empty list if requesting branches for a flat address space.
                if (namespaceType == OPCNAMESPACETYPE.OPC_NS_FLAT)
                {
                    if (branches)
                    {
                        return new TsCDaBrowseElement[0];
                    }

                    // check that root is browsed for flat address spaces.
                    if (itemID != null && itemID.ItemName != null && itemID.ItemName.Length > 0)
                    {
                        throw new OpcResultException(OpcResult.Da.E_UNKNOWN_ITEM_NAME);
                    }
                }

                // get the enumerator.
                enumerator = GetEnumerator(
                         (itemID != null) ? itemID.ItemName : null,
                         filters,
                         branches,
                         namespaceType == OPCNAMESPACETYPE.OPC_NS_FLAT);
            }
            else
            {
                enumerator = position.Enumerator;
            }

            ArrayList elements = new ArrayList();

            // read elements one at a time.
            TsCDaBrowseElement element = null;

            int start = 0;
            string[] names = null;

            // get cached name list.
            if (position != null)
            {
                start = position.Index;
                names = position.Names;
                position = null;
            }

            do
            {
                if (names != null)
                {
                    for (int ii = start; ii < names.Length; ii++)
                    {
                        // check if max returned elements is exceeded.
                        if (filters.MaxElementsReturned != 0 && filters.MaxElementsReturned == elements.Count + elementsFound)
                        {
                            position = new BrowsePosition(itemID, filters, enumerator, branches);
                            position.Names = names;
                            position.Index = ii;
                            break;
                        }

                        // get next element.
                        element = GetElement(itemID, names[ii], filters, branches);

                        if (element == null)
                        {
                            break;
                        }

                        // add element.
                        elements.Add(element);
                    }
                }

                // check if browse halted.
                if (position != null)
                {
                    break;
                }

                // fetch next element name.
                names = enumerator.Next(10);
                start = 0;
            }
            while (names != null && names.Length > 0);

            // free enumerator.
            if (position == null)
            {
                enumerator.Dispose();
            }

            // return list of elements.
            return (TsCDaBrowseElement[])elements.ToArray(typeof(TsCDaBrowseElement));
        }

        //======================================================================
        // Private Methods

        /// <summary>
        /// Creates a new instance of a subscription.
        /// </summary>
        protected override Technosoftware.DaAeHdaClient.Com.Da.Subscription CreateSubscription(
            object group,
            TsCDaSubscriptionState state,
            int filters)
        {
            return new Subscription(group, state, filters);
        }
    }

    /// <summary>
    /// Implements an object that handles multi-step browse operations for DA2.05 servers.
    /// </summary>
    [Serializable]
    internal class BrowsePosition : TsCDaBrowsePosition
    {
        /// <summary>
        /// The enumerator for a browse operation.
        /// </summary>
        internal EnumString Enumerator = null;

        /// <summary>
        /// Whether the current enumerator returns branches or leaves.
        /// </summary>
        internal bool IsBranch = true;

        /// <summary>
        /// The pre-fetched set of names.
        /// </summary>
        internal string[] Names = null;

        /// <summary>
        /// The current index in the pre-fetched names.
        /// </summary>
        internal int Index = 0;

        /// <summary>
        /// Initializes a browse position 
        /// </summary>
        internal BrowsePosition(
            OpcItem itemID,
            TsCDaBrowseFilters filters,
            EnumString enumerator,
            bool isBranch)
            :
            base(itemID, filters)
        {
            Enumerator = enumerator;
            IsBranch = isBranch;
        }

        /// <summary>
        /// Releases unmanaged resources held by the object.
        /// </summary>
        public override void Dispose()
        {
            if (Enumerator != null)
            {
                Enumerator.Dispose();
                Enumerator = null;
            }
        }

        /// <summary>
        /// Creates a deep copy of the object.
        /// </summary>
        public override object Clone()
        {
            BrowsePosition clone = (BrowsePosition)MemberwiseClone();
            clone.Enumerator = Enumerator.Clone();
            return clone;
        }
    }
}

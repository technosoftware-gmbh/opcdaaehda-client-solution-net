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

using Technosoftware.DaAeHdaClient.Ae;
using OpcRcw.Ae;
using OpcRcw.Comn;
#endregion

#pragma warning disable 0618

namespace Technosoftware.DaAeHdaClient.Com.Ae
{
    /// <summary>
    /// A .NET wrapper for a COM server that implements the AE server interfaces.
    /// </summary>
    [Serializable]
    internal class Server : Technosoftware.DaAeHdaClient.Com.Server, ITsCAeServer
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with the specified OpcUrl and COM server.
        /// </summary>
        internal Server(OpcUrl url, object server)  : base(url, server)
        {
            m_supportsAE11 = true;

            // check if the V1.1 interfaces are supported.
            try
            {
                IOPCEventServer2 server2 = (IOPCEventServer2)server;
            }
            catch
            {
                m_supportsAE11 = false;
            }
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">If true managed and unmanaged resources can be disposed. If false only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                lock (this)
                {
                    if (disposing)
                    {
                        // Release managed resources.

                        // release the server.
                        if (server_ != null)
                        {
                            // release all subscriptions.
                            foreach (Subscription subscription in m_subscriptions.Values)
                            {
                                // dispose of the subscription object (disconnects all subscriptions connections).
                                subscription.Dispose();
                            }

                            // clear subscription table.
                            m_subscriptions.Clear();
                        }
                    }

                    // Release unmanaged resources.
                    // Set large fields to null.

                    // release the browser.
                    if (m_browser != null)
                    {
                        Technosoftware.DaAeHdaClient.Com.Interop.ReleaseServer(m_browser);
                        m_browser = null;
                    }

                    // release the server.
                    if (server_ != null)
                    {
                        Technosoftware.DaAeHdaClient.Com.Interop.ReleaseServer(server_);
                        server_ = null;
                    }
                }

                // Call Dispose on your base class.
                m_disposed = true;
            }

            base.Dispose(disposing);
        }

        private bool m_disposed = false;
        #endregion

        #region Technosoftware.DaAeHdaClient.IOpcServer Members
        //======================================================================
        // Get Status

        /// <summary>
        /// Returns the current server status.
        /// </summary>
        /// <returns>The current server status.</returns>
        public OpcServerStatus GetServerStatus()
        {
            lock (this)
            {
                if (server_ == null) throw new NotConnectedException();
                string methodName = "IOPCServer.GetStatus";

                // initialize arguments.
                IntPtr pStatus = IntPtr.Zero;

                // invoke COM method.
                try
                {
                    IOPCEventServer server = BeginComCall<IOPCEventServer>(methodName, true);
                    ((IOPCEventServer)server_).GetStatus(out pStatus);
                }
                catch (Exception e)
                {
                    ComCallError(methodName, e);
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("Server.GetStatus", e);
                }
                finally
                {
                    EndComCall(methodName);
                }

                // return results.
                return Interop.GetServerStatus(ref pStatus, true);
            }
        }

        //======================================================================
        // Event Subscription

        /// <summary>
        /// Creates a new event subscription.
        /// </summary>
        /// <param name="state">The initial state for the subscription.</param>
        /// <returns>The new subscription object.</returns>
        public ITsCAeSubscription CreateSubscription(TsCAeSubscriptionState state)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();
                if (state == null)    throw new ArgumentNullException(nameof(state));

                // initialize arguments.
                object unknown    = null;
                Guid   riid       = typeof(IOPCEventSubscriptionMgt).GUID;
                int    bufferTime = 0;
                int    maxSize    = 0;

                // invoke COM method.
                try
                {
                    ((IOPCEventServer)server_).CreateEventSubscription(
                        (state.Active)?1:0,
                        state.BufferTime,
                        state.MaxSize,
                        ++m_handles,
                        ref riid,
                        out unknown,
                        out bufferTime,
                        out maxSize);                       
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.CreateEventSubscription", e);
                }       

                // save actual values.
                state.BufferTime = bufferTime;
                state.MaxSize    = maxSize;

                Subscription subscription = new Subscription(state, unknown);

                // set keep alive.
                subscription.ModifyState((int)TsCAeStateMask.KeepAlive, state);
                
                // save subscription.
                m_subscriptions.Add(m_handles, subscription);

                // return results.
                return subscription;
            }
        }

        //======================================================================
        // QueryAvailableFilters

        /// <summary>
        /// Returns the event filters supported by the server.
        /// </summary>
        /// <returns>A bit mask of all event filters supported by the server.</returns>
        public int QueryAvailableFilters()
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // initialize arguments.
                int filters = 0;

                // invoke COM method.
                try
                {
                    ((IOPCEventServer)server_).QueryAvailableFilters(out filters);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.QueryAvailableFilters", e);
                }       
                
                // return results.
                return filters;
            }
        }

        //======================================================================
        // QueryEventCategories

        /// <summary>       
        /// Returns the event categories supported by the server for the specified event types.
        /// </summary>
        /// <param name="eventType">A bit mask for the event types of interest.</param>
        /// <returns>A collection of event categories.</returns>
        public TsCAeCategory[] QueryEventCategories(int eventType)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // initialize arguments.
                int count = 0;

                IntPtr ppdwEventCategories    = IntPtr.Zero;
                IntPtr ppszEventCategoryDescs = IntPtr.Zero;

                // invoke COM method.
                try
                {
                    ((IOPCEventServer)server_).QueryEventCategories(
                        eventType, 
                        out count,
                        out ppdwEventCategories, 
                        out ppszEventCategoryDescs);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.QueryEventCategories", e);
                }       
                
                // check for empty list.
                if (count == 0)
                {
                    return new TsCAeCategory[0];
                }

                // unmarshal arguments.
                int[]    ids   = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref ppdwEventCategories, count, true);
                string[] names = Technosoftware.DaAeHdaClient.Com.Interop.GetUnicodeStrings(ref ppszEventCategoryDescs, count, true);

                // build results.
                TsCAeCategory[] categories = new TsCAeCategory[count];

                for (int ii = 0; ii < count; ii++)
                {
                    categories[ii] = new TsCAeCategory();

                    categories[ii].ID   = ids[ii];
                    categories[ii].Name = names[ii];
                }

                // return results.
                return categories;
            }
        }

        //======================================================================
        // QueryConditionNames

        /// <summary>
        /// Returns the condition names supported by the server for the specified event categories.
        /// </summary>
        /// <param name="eventCategory">A bit mask for the event categories of interest.</param>
        /// <returns>A list of condition names.</returns>
        public string[] QueryConditionNames(int eventCategory)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // initialize arguments.
                int count = 0;
                IntPtr ppszConditionNames = IntPtr.Zero;

                // invoke COM method.
                try
                {
                    ((IOPCEventServer)server_).QueryConditionNames(
                        eventCategory, 
                        out count,
                        out ppszConditionNames);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.QueryConditionNames", e);
                }       
                
                // check for empty list.
                if (count == 0)
                {
                    return new string[0];
                }

                // unmarshal arguments.
                string[] names = Technosoftware.DaAeHdaClient.Com.Interop.GetUnicodeStrings(ref ppszConditionNames, count, true);

                // return results.
                return names;
            }
        }

        //======================================================================
        // QuerySubConditionNames

        /// <summary>
        /// Returns the sub-condition names supported by the server for the specified event condition.
        /// </summary>
        /// <param name="conditionName">The name of the condition.</param>
        /// <returns>A list of sub-condition names.</returns>
        public string[] QuerySubConditionNames(string conditionName)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // initialize arguments.
                int count = 0;
                IntPtr ppszSubConditionNames = IntPtr.Zero;

                // invoke COM method.
                try
                {
                    ((IOPCEventServer)server_).QuerySubConditionNames(
                        conditionName, 
                        out count,
                        out ppszSubConditionNames);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.QuerySubConditionNames", e);
                }       

                // check for empty list.
                if (count == 0)
                {
                    return new string[0];
                }
                
                // unmarshal arguments.
                string[] names = Technosoftware.DaAeHdaClient.Com.Interop.GetUnicodeStrings(ref ppszSubConditionNames, count, true);

                // return results.
                return names;
            }
        }

        //======================================================================
        // QuerySourceConditions

        /// <summary>
        /// Returns the condition names supported by the server for the specified event source.
        /// </summary>
        /// <param name="sourceName">The name of the event source.</param>
        /// <returns>A list of condition names.</returns>
        public string[] QueryConditionNames(string sourceName)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // initialize arguments.
                int count = 0;
                IntPtr ppszConditionNames = IntPtr.Zero;

                // invoke COM method.
                try
                {
                    ((IOPCEventServer)server_).QuerySourceConditions(
                        sourceName, 
                        out count,
                        out ppszConditionNames);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.QuerySourceConditions", e);
                }       
                    
                // check for empty list.
                if (count == 0)
                {
                    return new string[0];
                }

                // unmarshal arguments.
                string[] names = Technosoftware.DaAeHdaClient.Com.Interop.GetUnicodeStrings(ref ppszConditionNames, count, true);

                // return results.
                return names;
            }
        }

        //======================================================================
        // QueryEventAttributes

        /// <summary>       
        /// Returns the event attributes supported by the server for the specified event categories.
        /// </summary>
        /// <param name="eventCategory">A bit mask for the event categories of interest.</param>
        /// <returns>A collection of event attributes.</returns>
        public TsCAeAttribute[] QueryEventAttributes(int eventCategory)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // initialize arguments.
                int count = 0;
                IntPtr ppdwAttrIDs = IntPtr.Zero;
                IntPtr ppszAttrDescs = IntPtr.Zero;
                IntPtr ppvtAttrTypes = IntPtr.Zero;

                // invoke COM method.
                try
                {
                    ((IOPCEventServer)server_).QueryEventAttributes(
                        eventCategory, 
                        out count,
                        out ppdwAttrIDs,
                        out ppszAttrDescs,
                        out ppvtAttrTypes);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.QueryEventAttributes", e);
                }       
                
                // check for empty list.
                if (count == 0)
                {
                    return new TsCAeAttribute[0];
                }

                // unmarshal arguments.
                int[]    ids   = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref ppdwAttrIDs, count, true);
                string[] names = Technosoftware.DaAeHdaClient.Com.Interop.GetUnicodeStrings(ref ppszAttrDescs, count, true);
                short[]  types = Technosoftware.DaAeHdaClient.Com.Interop.GetInt16s(ref ppvtAttrTypes, count, true);

                // build results.
                TsCAeAttribute[] attributes = new TsCAeAttribute[count];

                for (int ii = 0; ii < count; ii++)
                {
                    attributes[ii] = new TsCAeAttribute();

                    attributes[ii].ID       = ids[ii];
                    attributes[ii].Name     = names[ii];
                    attributes[ii].DataType = Technosoftware.DaAeHdaClient.Com.Interop.GetType((VarEnum)types[ii]);
                }

                // return results.
                return attributes;
            }
        }

        //======================================================================
        // TranslateToItemIDs

        /// <summary>
        /// Returns the DA item ids for a set of attribute ids belonging to events which meet the specified filter criteria.
        /// </summary>
        /// <param name="sourceName">The event source of interest.</param>
        /// <param name="eventCategory">The id of the event category for the events of interest.</param>
        /// <param name="conditionName">The name of a condition within the event category.</param>
        /// <param name="subConditionName">The name of a sub-condition within a multi-state condition.</param>
        /// <param name="attributeIDs">The ids of the attributes to return item ids for.</param>
        /// <returns>A list of item urls for each specified attribute.</returns>
        public TsCAeItemUrl[] TranslateToItemIDs(
            string sourceName,
            int    eventCategory,
            string conditionName,
            string subConditionName,
            int[]  attributeIDs)
        {
                lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // initialize arguments.
                IntPtr ppszAttrItemIDs = IntPtr.Zero;
                IntPtr ppszNodeNames = IntPtr.Zero;
                IntPtr ppCLSIDs = IntPtr.Zero;
                    
                int count = (attributeIDs != null)?attributeIDs.Length:0;

                // call server.
                try
                {
                    ((IOPCEventServer)server_).TranslateToItemIDs(
                        (sourceName != null)?sourceName:"",
                        eventCategory,
                        (conditionName != null)?conditionName:"",
                        (subConditionName != null)?subConditionName:"",
                        count,
                        (count > 0)?attributeIDs:new int[0],
                        out ppszAttrItemIDs,
                        out ppszNodeNames,
                        out ppCLSIDs);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.TranslateToItemIDs", e);
                }       
            
                // unmarshal results.
                string[] itemIDs   = Technosoftware.DaAeHdaClient.Com.Interop.GetUnicodeStrings(ref ppszAttrItemIDs, count, true);
                string[] nodeNames = Technosoftware.DaAeHdaClient.Com.Interop.GetUnicodeStrings(ref ppszNodeNames, count, true);
                Guid[]   clsids    = Technosoftware.DaAeHdaClient.Com.Interop.GetGUIDs(ref ppCLSIDs, count, true);
                    
                TsCAeItemUrl[] itemUrls = new TsCAeItemUrl[count];
            
                // fill in item urls.
                for (int ii = 0; ii < count; ii++)
                {
                    itemUrls[ii] = new TsCAeItemUrl();

                    itemUrls[ii].ItemName = itemIDs[ii];
                    itemUrls[ii].ItemPath = null;
                    itemUrls[ii].Url.Scheme   = OpcUrlScheme.DA;
                    itemUrls[ii].Url.HostName = nodeNames[ii];
                    itemUrls[ii].Url.Path     = String.Format("{{{0}}}", clsids[ii]);
                }

                // return results.
                return itemUrls;
            }
        }

        //======================================================================
        // GetConditionState

        /// <summary>
        /// Returns the current state information for the condition instance corresponding to the source and condition name.
        /// </summary>
        /// <param name="sourceName">The source name</param>
        /// <param name="conditionName">A condition name for the source.</param>
        /// <param name="attributeIDs">The list of attributes to return with the condition state.</param>
        /// <returns>The current state of the connection.</returns>
		public TsCAeCondition GetConditionState(
            string sourceName,
            string conditionName,
            int[]  attributeIDs)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // initialize arguments.
                IntPtr ppConditionState = IntPtr.Zero;

                // call server.
                try
                {
                    ((IOPCEventServer)server_).GetConditionState(
                        (sourceName != null)?sourceName:"",
                        (conditionName != null)?conditionName:"",
                        (attributeIDs != null)?attributeIDs.Length:0,
                        (attributeIDs != null)?attributeIDs:new int[0],
                        out ppConditionState);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.GetConditionState", e);
                }       
            
                // unmarshal results.
				TsCAeCondition[] conditions = Interop.GetConditions(ref ppConditionState, 1, true);
            
                // fill in attribute ids.
                for (int ii = 0; ii < conditions[0].Attributes.Count; ii++)
                {
                    conditions[0].Attributes[ii].ID = attributeIDs[ii];
                }

                // return results.
                return conditions[0];
            }
        }

        //======================================================================
        // EnableConditionByArea

        /// <summary>
        /// Places the specified process areas into the enabled state.
        /// </summary>
        /// <param name="areas">A list of fully qualified area names.</param>
        /// <returns>The results of the operation for each area.</returns>
        public OpcResult[] EnableConditionByArea(string[] areas)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // check for trivial case.
                if (areas == null || areas.Length == 0)
                {
                    return new OpcResult[0];
                }

                // initialize arguments.
                IntPtr ppErrors = IntPtr.Zero;

                int[] errors = null;

                if (m_supportsAE11)
                {
                    try
                    {
                        ((IOPCEventServer2)server_).EnableConditionByArea2(
                            areas.Length, 
                            areas,
                            out ppErrors);
                    }
                    catch (Exception e)
                    {
                        throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer2.EnableConditionByArea2", e);
                    }       
                
                    // unmarshal arguments.
                    errors = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref ppErrors, areas.Length, true);
                }
                else
                {
                    try
                    {
                        ((IOPCEventServer)server_).EnableConditionByArea(
                            areas.Length, 
                            areas);
                    }
                    catch (Exception e)
                    {
                        throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.EnableConditionByArea", e);
                    }   
    
                    // create dummy error array (0 == S_OK).
                    errors = new int[areas.Length];
                }
                
                // build results.
                OpcResult[] results = new OpcResult[errors.Length];

                for (int ii = 0; ii < errors.Length; ii++)
                {
                    results[ii] = Interop.GetResultID(errors[ii]);
                }

                // return results.
                return results;
            }
        }
        
        //======================================================================
        // DisableConditionByArea

        /// <summary>
        /// Places the specified process areas into the disabled state.
        /// </summary>
        /// <param name="areas">A list of fully qualified area names.</param>
        /// <returns>The results of the operation for each area.</returns>
        public OpcResult[] DisableConditionByArea(string[] areas)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // check for trivial case.
                if (areas == null || areas.Length == 0)
                {
                    return new OpcResult[0];
                }

                // initialize arguments.
                IntPtr ppErrors = IntPtr.Zero;

                int[] errors = null;

                if (m_supportsAE11)
                {
                    try
                    {
                        ((IOPCEventServer2)server_).DisableConditionByArea2(
                            areas.Length, 
                            areas,
                            out ppErrors);
                    }
                    catch (Exception e)
                    {
                        throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer2.DisableConditionByArea2", e);
                    }       
                
                    // unmarshal arguments.
                    errors = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref ppErrors, areas.Length, true);
                }
                else
                {
                    try
                    {
                        ((IOPCEventServer)server_).DisableConditionByArea(
                            areas.Length, 
                            areas);
                    }
                    catch (Exception e)
                    {
                        throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.DisableConditionByArea", e);
                    }   
    
                    // create dummy error array (0 == S_OK).
                    errors = new int[areas.Length];
                }
                
                // build results.
                OpcResult[] results = new OpcResult[errors.Length];

                for (int ii = 0; ii < errors.Length; ii++)
                {
                    results[ii] = Interop.GetResultID(errors[ii]);
                }

                // return results.
                return results;
            }
        }

        //======================================================================
        // EnableConditionBySource

        /// <summary>
        /// Places the specified process areas into the enabled state.
        /// </summary>
        /// <param name="sources">A list of fully qualified source names.</param>
        /// <returns>The results of the operation for each area.</returns>
        public OpcResult[] EnableConditionBySource(string[] sources)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // check for trivial case.
                if (sources == null || sources.Length == 0)
                {
                    return new OpcResult[0];
                }

                // initialize arguments.
                IntPtr ppErrors = IntPtr.Zero;

                int[] errors = null;

                if (m_supportsAE11)
                {
                    try
                    {
                        ((IOPCEventServer2)server_).EnableConditionBySource2(
                            sources.Length, 
                            sources,
                            out ppErrors);
                    }
                    catch (Exception e)
                    {
                        throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer2.EnableConditionBySource2", e);
                    }       
                
                    // unmarshal arguments.
                    errors = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref ppErrors, sources.Length, true);
                }
                else
                {
                    try
                    {
                        ((IOPCEventServer)server_).EnableConditionBySource(
                            sources.Length, 
                            sources);
                    }
                    catch (Exception e)
                    {
                        throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.EnableConditionBySource", e);
                    }   
    
                    // create dummy error array (0 == S_OK).
                    errors = new int[sources.Length];
                }
                
                // build results.
                OpcResult[] results = new OpcResult[errors.Length];

                for (int ii = 0; ii < errors.Length; ii++)
                {
                    results[ii] = Interop.GetResultID(errors[ii]);
                }

                // return results.
                return results;
            }
        }

        //======================================================================
        // DisableConditionBySource

        /// <summary>
        /// Places the specified process areas into the disabled state.
        /// </summary>
        /// <param name="sources">A list of fully qualified source names.</param>
        /// <returns>The results of the operation for each area.</returns>
        public OpcResult[] DisableConditionBySource(string[] sources)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // check for trivial case.
                if (sources == null || sources.Length == 0)
                {
                    return new OpcResult[0];
                }

                // initialize arguments.
                IntPtr ppErrors = IntPtr.Zero;

                int[] errors = null;

                if (m_supportsAE11)
                {
                    try
                    {
                        ((IOPCEventServer2)server_).DisableConditionBySource2(
                            sources.Length, 
                            sources,
                            out ppErrors);
                    }
                    catch (Exception e)
                    {
                        throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer2.DisableConditionBySource2", e);
                    }       
                
                    // unmarshal arguments.
                    errors = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref ppErrors, sources.Length, true);
                }
                else
                {
                    try
                    {
                        ((IOPCEventServer)server_).DisableConditionBySource(
                            sources.Length, 
                            sources);
                    }
                    catch (Exception e)
                    {
                        throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.DisableConditionBySource", e);
                    }   
    
                    // create dummy error array (0 == S_OK).
                    errors = new int[sources.Length];
                }
                
                // build results.
                OpcResult[] results = new OpcResult[errors.Length];

                for (int ii = 0; ii < errors.Length; ii++)
                {
                    results[ii] = Interop.GetResultID(errors[ii]);
                }

                // return results.
                return results;
            }
        }

        //======================================================================
        // GetEnableStateByArea

        /// <summary>
        /// Returns the enabled state for the specified process areas. 
        /// </summary>
        /// <param name="areas">A list of fully qualified area names.</param>
        public TsCAeEnabledStateResult[] GetEnableStateByArea(string[] areas)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // check for trivial case.
                if (areas == null || areas.Length == 0)
                {
                    return new TsCAeEnabledStateResult[0];
                }

                // return error code if AE 1.1 not supported.
                if (!m_supportsAE11)
                {
                    TsCAeEnabledStateResult[] failures = new TsCAeEnabledStateResult[areas.Length];

                    for (int ii = 0; ii < failures.Length; ii++)
                    {
                        failures[ii] = new TsCAeEnabledStateResult();

                        failures[ii].Enabled            = false;
                        failures[ii].EffectivelyEnabled = false;
                        failures[ii].Result           = OpcResult.E_FAIL;
                    }

                    return failures;
                }

                // initialize arguments.
                IntPtr pbEnabled            = IntPtr.Zero;
                IntPtr pbEffectivelyEnabled = IntPtr.Zero;
                IntPtr ppErrors             = IntPtr.Zero;

                try
                {
                    ((IOPCEventServer2)server_).GetEnableStateByArea(
                        areas.Length, 
                        areas,
                        out pbEnabled,
                        out pbEffectivelyEnabled,
                        out ppErrors);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer2.GetEnableStateByArea", e);
                }       
                
                // unmarshal arguments.
                int[] enabled             = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref pbEnabled, areas.Length, true);
                int[] effectivelyEnabled  = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref pbEffectivelyEnabled, areas.Length, true);
                int[] errors              = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref ppErrors, areas.Length, true);

                
                // build results.
                TsCAeEnabledStateResult[] results = new TsCAeEnabledStateResult[errors.Length];

                for (int ii = 0; ii < errors.Length; ii++)
                {
                    results[ii] = new TsCAeEnabledStateResult();

                    results[ii].Enabled            = enabled[ii] != 0;
                    results[ii].EffectivelyEnabled = effectivelyEnabled[ii] != 0;
                    results[ii].Result           = Interop.GetResultID(errors[ii]);
                }

                // return results
                return results;
            }
        }

        //======================================================================
        // GetEnableStateBySource

        /// <summary>
        /// Returns the enabled state for the specified event sources. 
        /// </summary>
        /// <param name="sources">A list of fully qualified source names.</param>
        public TsCAeEnabledStateResult[] GetEnableStateBySource(string[] sources)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // check for trivial case.
                if (sources == null || sources.Length == 0)
                {
                    return new TsCAeEnabledStateResult[0];
                }

                // return error code if AE 1.1 not supported.
                if (!m_supportsAE11)
                {
                    TsCAeEnabledStateResult[] failures = new TsCAeEnabledStateResult[sources.Length];

                    for (int ii = 0; ii < failures.Length; ii++)
                    {
                        failures[ii] = new TsCAeEnabledStateResult();

                        failures[ii].Enabled            = false;
                        failures[ii].EffectivelyEnabled = false;
                        failures[ii].Result           = OpcResult.E_FAIL;
                    }

                    return failures;
                }

                // initialize arguments.
                IntPtr pbEnabled            = IntPtr.Zero;
                IntPtr pbEffectivelyEnabled = IntPtr.Zero;
                IntPtr ppErrors             = IntPtr.Zero;

                try
                {
                    ((IOPCEventServer2)server_).GetEnableStateBySource(
                        sources.Length, 
                        sources,
                        out pbEnabled,
                        out pbEffectivelyEnabled,
                        out ppErrors);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer2.GetEnableStateBySource", e);
                }       
                    
                // unmarshal arguments.
                int[] enabled             = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref pbEnabled, sources.Length, true);
                int[] effectivelyEnabled  = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref pbEffectivelyEnabled, sources.Length, true);
                int[] errors              = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref ppErrors, sources.Length, true);

                    
                // build results.
                TsCAeEnabledStateResult[] results = new TsCAeEnabledStateResult[errors.Length];

                for (int ii = 0; ii < errors.Length; ii++)
                {
                    results[ii] = new TsCAeEnabledStateResult();

                    results[ii].Enabled            = enabled[ii] != 0;
                    results[ii].EffectivelyEnabled = effectivelyEnabled[ii] != 0;
                    results[ii].Result           = Interop.GetResultID(errors[ii]);
                }

                // return results
                return results;
            }
        }

        //======================================================================
        // AcknowledgeCondition

        /// <summary>
        /// Used to acknowledge one or more conditions in the event server.
        /// </summary>
        /// <param name="acknowledgerID">The identifier for who is acknowledging the condition.</param>
        /// <param name="comment">A comment associated with the acknowledgment.</param>
        /// <param name="conditions">The conditions being acknowledged.</param>
        /// <returns>A list of result id indictaing whether each condition was successfully acknowledged.</returns>
        public OpcResult[] AcknowledgeCondition(
            string                 acknowledgerID,
            string                 comment,
            TsCAeEventAcknowledgement[] conditions)
        {               
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // check for trivial case.
                if (conditions == null || conditions.Length == 0)
                {
                    return new OpcResult[0];
                }

                // initialize arguments.
                int count = conditions.Length;

                string[]             pszSource        = new string[count];
                string[]             pszConditionName = new string[count];
                OpcRcw.Ae.FILETIME[] pftActiveTime = new OpcRcw.Ae.FILETIME[count];
                int[]                pdwCookie        = new int[count];

                for (int ii = 0; ii < count; ii ++)
                {
                    pszSource[ii]        = conditions[ii].SourceName;
                    pszConditionName[ii] = conditions[ii].ConditionName;
                    pftActiveTime[ii]    = Interop.Convert(Com.Interop.GetFILETIME(conditions[ii].ActiveTime));
                    pdwCookie[ii]        = conditions[ii].Cookie;
                }

                IntPtr ppErrors = IntPtr.Zero;

                // call server.
                try
                {
                    ((IOPCEventServer)server_).AckCondition(
                        conditions.Length,
                        acknowledgerID,
                        comment,
                        pszSource,
                        pszConditionName,
                        pftActiveTime,
                        pdwCookie,
                        out ppErrors);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.AckCondition", e);
                }       
                
                // unmarshal results.
                int[] errors = Technosoftware.DaAeHdaClient.Com.Interop.GetInt32s(ref ppErrors, count, true);
                
                // build results.
                OpcResult[] results = new OpcResult[count];

                for (int ii = 0; ii < count; ii++)
                {
                    results[ii] = Interop.GetResultID(errors[ii]);
                }

                // return results.
                return results;
            }
        }

        //======================================================================
        // Browse

        /// <summary>
        /// Browses for all children of the specified area that meet the filter criteria.
        /// </summary>
        /// <param name="areaID">The full-qualified id for the area.</param>
        /// <param name="browseType">The type of children to return.</param>
        /// <param name="browseFilter">The expression used to filter the names of children returned.</param>
        /// <returns>The set of elements that meet the filter criteria.</returns>
        public TsCAeBrowseElement[] Browse(
            string     areaID,
            TsCAeBrowseType browseType, 
            string     browseFilter)
        {
            lock (this)
            {
                // intialize arguments.
                IOpcBrowsePosition position = null;

                // browse for all elements at the current position.
                TsCAeBrowseElement[] elements = Browse(areaID, browseType, browseFilter, 0, out position);

                // free position object.
                if (position != null)
                {
                    position.Dispose();
                }

                // return results.
                return elements;
            }
        }

        /// <summary>
        /// Browses for all children of the specified area that meet the filter criteria.
        /// </summary>
        /// <param name="areaID">The full-qualified id for the area.</param>
        /// <param name="browseType">The type of children to return.</param>
        /// <param name="browseFilter">The expression used to filter the names of children returned.</param>
        /// <param name="maxElements">The maximum number of elements to return.</param>
        /// <param name="position">The object used to continue the browse if the number nodes exceeds the maximum specified.</param>
        /// <returns>The set of elements that meet the filter criteria.</returns>
        public TsCAeBrowseElement[] Browse(
            string              areaID,
            TsCAeBrowseType          browseType, 
            string              browseFilter, 
            int                 maxElements,
            out IOpcBrowsePosition position)
        {
            position = null;

            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();

                // initialize browser.
                InitializeBrowser();

                // move to desired area.
                ChangeBrowsePosition(areaID);

                // create enumerator.
                System.Runtime.InteropServices.ComTypes.IEnumString enumerator = (System.Runtime.InteropServices.ComTypes.IEnumString)CreateEnumerator(browseType, browseFilter);

                // fetch elements.
                ArrayList elements = new ArrayList();

                int result = FetchElements(browseType, maxElements, enumerator, elements);
                
                // dispose of enumerator if all done.
                if (result != 0)
                {
                    Technosoftware.DaAeHdaClient.Com.Interop.ReleaseServer(enumerator);
                }

                // create continuation point.
                else
                {
                    position = new BrowsePosition(areaID, browseType, browseFilter, enumerator);
                }

                // return results.
                return (TsCAeBrowseElement[])elements.ToArray(typeof(TsCAeBrowseElement));
            }
        }
        
        //======================================================================
        // BrowseNext

        /// <summary>
        /// Continues browsing the server's address space at the specified position.
        /// </summary>
        /// <param name="maxElements">The maximum number of elements to return.</param>
        /// <param name="position">The position object used to continue a browse operation.</param>
        /// <returns>The set of elements that meet the filter criteria.</returns>
        public TsCAeBrowseElement[] BrowseNext(int maxElements, ref IOpcBrowsePosition position)
        {
            lock (this)
            {
                // verify state and arguments.
                if (server_ == null) throw new NotConnectedException();
                if (position == null) throw new ArgumentNullException(nameof(position));

                // initialize browser.
                InitializeBrowser();

                // move to desired area.
                ChangeBrowsePosition(((BrowsePosition)position).AreaID);

                // fetch enumerator from position object.
                System.Runtime.InteropServices.ComTypes.IEnumString enumerator = ((BrowsePosition)position).Enumerator;
            
                // fetch elements.
                ArrayList elements = new ArrayList();

                int result = FetchElements(((BrowsePosition)position).BrowseType, maxElements, enumerator, elements);
                
                // dispose of position object if all done.
                if (result != 0)
                {
                    position.Dispose();
                    position = null;
                }

                // return results.
                return (TsCAeBrowseElement[])elements.ToArray(typeof(TsCAeBrowseElement));
            }
        }   
        #endregion

        #region Private Methods
        /// <summary>
        /// Creates an area browser object for use by all browse requests.
        /// </summary>
        private void InitializeBrowser()
        {
            // do nothing if browser already exists.
            if (m_browser != null)
            {
                return;
            }

            // initialize arguments.
            object unknown = null;
            Guid riid = typeof(IOPCEventAreaBrowser).GUID;

            // invoke COM method.
            try
            {
                ((IOPCEventServer)server_).CreateAreaBrowser(
                    ref riid,
                    out unknown);
            }
            catch (Exception e)
            {
                throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventServer.CreateAreaBrowser", e);
            }       

            // verify object.
            if (unknown == null)
            {
            throw new OpcResultException(new OpcResult( (int)OpcResult.E_FAIL.Code, OpcResult.FuncCallType.SysFuncCall, null ),"The response from the server was invalid or incomplete");
            }

            // save object.
            m_browser = unknown;
        }
        
        /// <summary>
        /// Moves the browse position prior to executing a browse operation.
        /// </summary>
        private void ChangeBrowsePosition(string areaID)
        {
            string targetID = (areaID != null)?areaID:"";

            // invoke COM method.
            try
            {
                ((IOPCEventAreaBrowser)m_browser).ChangeBrowsePosition(
                    OPCAEBROWSEDIRECTION.OPCAE_BROWSE_TO,
                    targetID);
            }
            catch (Exception e)
            {
                throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventAreaBrowser.ChangeBrowsePosition", e);
            }       
        }
        
        /// <summary>
        /// Creates an enumerator for the names at the current position.
        /// </summary>
        private object CreateEnumerator(TsCAeBrowseType browseType, string browseFilter)
        {
            // initialize arguments.
            OPCAEBROWSETYPE dwBrowseFilterType = Interop.GetBrowseType(browseType);
            IEnumString enumerator = null;

            // invoke COM method.
            try
            {
                ((IOPCEventAreaBrowser)m_browser).BrowseOPCAreas(
                    dwBrowseFilterType,
                    (browseFilter != null)?browseFilter:"",
                    out enumerator);
            }
            catch (Exception e)
            {
                throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventAreaBrowser.BrowseOPCAreas", e);
            }       

            // verify object.
            if (enumerator == null)
            {
            throw new OpcResultException(new OpcResult( (int)OpcResult.E_FAIL.Code, OpcResult.FuncCallType.SysFuncCall, null ),"The response from the server was invalid or incomplete");
            }

            // return result.
		return (System.Runtime.InteropServices.ComTypes.IEnumString)enumerator;
        }

        /// <summary>
        /// Returns the qualified name for the node at the current position.
        /// </summary>
        private string GetQualifiedName(string name, TsCAeBrowseType browseType)
        {
            // initialize arguments.
            string nodeID = null;

            // fetch area qualified name.
            if (browseType == TsCAeBrowseType.Area)
            {
                try
                {
                    ((IOPCEventAreaBrowser)m_browser).GetQualifiedAreaName(name, out nodeID);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventAreaBrowser.GetQualifiedAreaName", e);
                }
            }
                
            // fetch source qualified name.
            else
            {
                try
                {
                    ((IOPCEventAreaBrowser)m_browser).GetQualifiedSourceName(name, out nodeID);
                }
                catch (Exception e)
                {
                    throw Technosoftware.DaAeHdaClient.Com.Interop.CreateException("IOPCEventAreaBrowser.GetQualifiedSourceName", e);
                }
            }

            // return results.
            return nodeID;
        }

        /// <summary>
        /// Fetches up to max elements and returns an flag indicating whether there are any elements left.
        /// </summary>
		private int FetchElements(TsCAeBrowseType browseType, int maxElements, System.Runtime.InteropServices.ComTypes.IEnumString enumerator, ArrayList elements)
        {
            string[] buffer = new string[1];

            // re-calculate buffer length.
            int bufferLength = (maxElements > 0 && maxElements-elements.Count < buffer.Length)?maxElements-elements.Count:buffer.Length;

            // fetch first batch of names.
            IntPtr pFetched = Marshal.AllocCoTaskMem(sizeof(int));
            
            try
            {
                int result = enumerator.Next(bufferLength, buffer, pFetched);

            while (result == 0)
            {
                    int fetched = Marshal.ReadInt32(pFetched);

                // create elements.
				for (int ii = 0; ii < fetched; ii++)
                {
                    TsCAeBrowseElement element = new TsCAeBrowseElement();

                    element.Name          = buffer[ii];
                    element.QualifiedName = GetQualifiedName(buffer[ii], browseType);
                    element.NodeType      = browseType;
                
                    elements.Add(element);
                }

                // check for halt.
                if (maxElements > 0 && elements.Count >= maxElements)
                {
                    break;
                }

                // re-calculate buffer length.
                bufferLength = (maxElements > 0 && maxElements-elements.Count < buffer.Length)?maxElements-elements.Count:buffer.Length;
                    
                // fetch next block.
                    result = enumerator.Next(bufferLength, buffer, pFetched);
            }

            // return final result.
            return result;
        }
            finally
            {
                if (pFetched != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(pFetched);
                }
            }
		}
        #endregion

        #region Private Members
        private bool m_supportsAE11 = true;
        private object m_browser = null;
        private int m_handles = 1;
        private Hashtable m_subscriptions = new Hashtable();
        #endregion
    }
    
    #region BrowsePosition Class
    /// <summary>
    /// Stores the state of a browse operation.
    /// </summary>
    [Serializable]
    internal class BrowsePosition : TsCAeBrowsePosition
    {
        #region Constructors
        /// <summary>
        /// Saves the parameters for an incomplete browse information.
        /// </summary>
        public BrowsePosition(
            string          areaID,
            TsCAeBrowseType      browseType, 
            string          browseFilter,
			System.Runtime.InteropServices.ComTypes.IEnumString enumerator)
        :
            base (areaID, browseType, browseFilter)
        {
            m_enumerator   = enumerator;
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">If true managed and unmanaged resources can be disposed. If false only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    // Release managed resources.
                }

                // Release unmanaged resources.
                // Set large fields to null.

			    if (m_enumerator != null)
			    {				
				    Technosoftware.DaAeHdaClient.Com.Interop.ReleaseServer(m_enumerator);
				    m_enumerator = null;
			    }

                // Call Dispose on your base class.
                m_disposed = true;
            }

            base.Dispose(disposing);
        }

        private bool m_disposed = false;
        #endregion

        #region Public Interface
        /// <summary>
        /// Returns the enumerator stored in the object.
        /// </summary>
		public System.Runtime.InteropServices.ComTypes.IEnumString Enumerator => m_enumerator;

        #endregion

        #region Private Members
		System.Runtime.InteropServices.ComTypes.IEnumString m_enumerator = null;
        #endregion
    }
    #endregion
}

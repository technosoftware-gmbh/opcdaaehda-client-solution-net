#region Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
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
#endregion Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved

#region Using Directives
using System;
using System.Runtime.InteropServices;
#endregion

namespace OpcRcw.Comn
{   
    /// <exclude />
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]    
    public struct CONNECTDATA 
    {
        [MarshalAs(UnmanagedType.IUnknown)]
        object pUnk;
        [MarshalAs(UnmanagedType.I4)]
        int dwCookie;
    }

    /// <exclude />
    [ComImport]
    [GuidAttribute("B196B287-BAB4-101A-B69C-00AA00341D07")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface IEnumConnections
    {
        /// <summary>
        /// Retrieves a specified number of items in the enumeration sequence.
        /// </summary>
        /// <param name="cConnections"></param>
        /// <param name="rgcd"></param>
        /// <param name="pcFetched"></param>
        void RemoteNext(
            [MarshalAs(UnmanagedType.I4)]
            int cConnections,
            [Out]
            IntPtr rgcd,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pcFetched);

        /// <summary>
        /// Skips a specified number of items in the enumeration sequence.
        /// </summary>
        /// <param name="cConnections"></param>
        void Skip(
            [MarshalAs(UnmanagedType.I4)]
            int cConnections);

        /// <summary>
        /// Retrieves a specified number of items in the enumeration sequence.
        /// </summary>
        void Reset();

        /// <summary>
        /// Creates a new enumerator that contains the same enumeration state as the current one.
        /// </summary>
        /// <param name="ppEnum"></param>
        void Clone(
            [Out]
            out IEnumConnections ppEnum);
    }

    /// <exclude />
    [ComImport]
    [GuidAttribute("B196B286-BAB4-101A-B69C-00AA00341D07")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface IConnectionPoint
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPoint.GetConnectionInterface(out Guid)'
        void GetConnectionInterface(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPoint.GetConnectionInterface(out Guid)'
            [Out]
            out Guid pIID);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPoint.GetConnectionPointContainer(out IConnectionPointContainer)'
        void GetConnectionPointContainer(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPoint.GetConnectionPointContainer(out IConnectionPointContainer)'
            [Out]
            out IConnectionPointContainer ppCPC);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPoint.Advise(object, out int)'
        void Advise(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPoint.Advise(object, out int)'
            [MarshalAs(UnmanagedType.IUnknown)]
            object pUnkSink,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCookie);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPoint.Unadvise(int)'
        void Unadvise(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPoint.Unadvise(int)'
            [MarshalAs(UnmanagedType.I4)]
            int dwCookie);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPoint.EnumConnections(out IEnumConnections)'
        void EnumConnections(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPoint.EnumConnections(out IEnumConnections)'
            [Out]
            out IEnumConnections ppEnum);
    }

    /// <exclude />
    [ComImport]
    [GuidAttribute("B196B285-BAB4-101A-B69C-00AA00341D07")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface IEnumConnectionPoints 
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumConnectionPoints.RemoteNext(int, IntPtr, out int)'
        void RemoteNext(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumConnectionPoints.RemoteNext(int, IntPtr, out int)'
            [MarshalAs(UnmanagedType.I4)]
            int cConnections,
            [Out]
            IntPtr ppCP,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pcFetched);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumConnectionPoints.Skip(int)'
        void Skip(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumConnectionPoints.Skip(int)'
            [MarshalAs(UnmanagedType.I4)]
            int cConnections);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumConnectionPoints.Reset()'
        void Reset();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumConnectionPoints.Reset()'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumConnectionPoints.Clone(out IEnumConnectionPoints)'
        void Clone(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumConnectionPoints.Clone(out IEnumConnectionPoints)'
            [Out]
            out IEnumConnectionPoints ppEnum);
    }

    /// <exclude />
    [ComImport]
    [GuidAttribute("B196B284-BAB4-101A-B69C-00AA00341D07")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface IConnectionPointContainer
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPointContainer.EnumConnectionPoints(out IEnumConnectionPoints)'
        void EnumConnectionPoints(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPointContainer.EnumConnectionPoints(out IEnumConnectionPoints)'
            [Out]
            out IEnumConnectionPoints ppEnum);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPointContainer.FindConnectionPoint(ref Guid, out IConnectionPoint)'
        void FindConnectionPoint(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IConnectionPointContainer.FindConnectionPoint(ref Guid, out IConnectionPoint)'
            ref Guid riid,
            [Out]
            out IConnectionPoint ppCP);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("F31DFDE1-07B6-11d2-B2D8-0060083BA1FB")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface IOPCShutdown
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IOPCShutdown.ShutdownRequest(string)'
        void ShutdownRequest(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IOPCShutdown.ShutdownRequest(string)'
			[MarshalAs(UnmanagedType.LPWStr)]
			string szReason);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("F31DFDE2-07B6-11d2-B2D8-0060083BA1FB")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
	public interface IOPCCommon 
	{
		/// <summary>
		/// Set the default LocaleID for this server/client session. This localeid will be used by the GetErrorString method on this interface. It should also be used as the ‘default’ localeid by any other server functions that are affected by localid. Other OPC interfaces may provide additional LocaleID capability by allowing this LocalID to be overridden either via a parameter to a method or via a property on a child object.
		/// </summary>
		/// <param name="dwLcid">The default LocaleID for this server/client session</param>
		void SetLocaleID(
			[MarshalAs(UnmanagedType.I4)]
			int dwLcid);

		/// <summary>
		/// Return the default LocaleID for this server/client session. 
		/// </summary>
		/// <param name="pdwLcid">Where to return the default LocaleID for this server/client session</param>
		void GetLocaleID(
			[Out][MarshalAs(UnmanagedType.I4)]
			out int pdwLcid);

		/// <summary>
		/// Return the available LocaleIDs for this server/client session. 
		/// </summary>
		/// <param name="pdwCount">Where to return the LocaleID count</param>
		/// <param name="pdwLcid">Where to return the LocaleID list.</param>
		void QueryAvailableLocaleIDs( 
			[Out][MarshalAs(UnmanagedType.I4)]
			out int pdwCount,	
			[Out]
			out IntPtr pdwLcid);

		/// <summary>
		/// Returns the error string for a server specific error code.
		/// </summary>
		/// <param name="dwError">A server specific error code that the client application had returned from an interface function from the server, and for which the client application is requesting the server’s textual representation. </param>
		/// <param name="ppString">Pointer to pointer where server supplied result will be saved</param>
		void GetErrorString( 
			[MarshalAs(UnmanagedType.I4)]
			int dwError,
			[Out][MarshalAs(UnmanagedType.LPWStr)]
			out String ppString);

		/// <summary>
		/// Allows the client to optionally register a client name with the server. This is included primarily for debugging purposes. The recommended behavior is that the client set his Node name and EXE name here. 
		/// </summary>
		/// <param name="szName">An arbitrary string containing information about the client task.</param>
		void SetClientName(
			[MarshalAs(UnmanagedType.LPWStr)] 
			String szName);
	}

    /// <exclude />
	[ComImport]
	[GuidAttribute("13486D50-4821-11D2-A494-3CB306C10000")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
	public interface IOPCServerList 
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IOPCServerList.EnumClassesOfCategories(int, Guid[], int, Guid[], out object)'
        void EnumClassesOfCategories(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IOPCServerList.EnumClassesOfCategories(int, Guid[], int, Guid[], out object)'
		    [MarshalAs(UnmanagedType.I4)]
            int cImplemented,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)]
            Guid[] rgcatidImpl,
		    [MarshalAs(UnmanagedType.I4)]
            int cRequired,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=2)]
            Guid[] rgcatidReq,
		    [Out][MarshalAs(UnmanagedType.IUnknown)]
            out object ppenumClsid);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IOPCServerList.GetClassDetails(ref Guid, out string, out string)'
        void GetClassDetails(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IOPCServerList.GetClassDetails(ref Guid, out string, out string)'
            ref Guid clsid, 
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string ppszProgID,
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string ppszUserType);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IOPCServerList.CLSIDFromProgID(string, out Guid)'
        void CLSIDFromProgID(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IOPCServerList.CLSIDFromProgID(string, out Guid)'
		    [MarshalAs(UnmanagedType.LPWStr)]
            string szProgId,
            [Out]
            out Guid clsid);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("55C382C8-21C7-4e88-96C1-BECFB1E3F483")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface IOPCEnumGUID 
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IOPCEnumGUID.Next(int, IntPtr, out int)'
        void Next(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IOPCEnumGUID.Next(int, IntPtr, out int)'
		    [MarshalAs(UnmanagedType.I4)]
            int celt,
            [Out]
            IntPtr rgelt,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pceltFetched);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IOPCEnumGUID.Skip(int)'
        void Skip(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IOPCEnumGUID.Skip(int)'
		    [MarshalAs(UnmanagedType.I4)]
            int celt);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IOPCEnumGUID.Reset()'
        void Reset();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IOPCEnumGUID.Reset()'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IOPCEnumGUID.Clone(out IOPCEnumGUID)'
        void Clone(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IOPCEnumGUID.Clone(out IOPCEnumGUID)'
            [Out]
            out IOPCEnumGUID ppenum);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("0002E000-0000-0000-C000-000000000046")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface IEnumGUID 
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumGUID.Next(int, IntPtr, out int)'
        void Next(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumGUID.Next(int, IntPtr, out int)'
		    [MarshalAs(UnmanagedType.I4)]
            int celt,
            [Out]
            IntPtr rgelt,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pceltFetched);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumGUID.Skip(int)'
        void Skip(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumGUID.Skip(int)'
		    [MarshalAs(UnmanagedType.I4)]
            int celt);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumGUID.Reset()'
        void Reset();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumGUID.Reset()'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumGUID.Clone(out IEnumGUID)'
        void Clone(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumGUID.Clone(out IEnumGUID)'
            [Out]
            out IEnumGUID ppenum);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("00000100-0000-0000-C000-000000000046")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface IEnumUnknown 
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumUnknown.RemoteNext(int, IntPtr, out int)'
        void RemoteNext(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumUnknown.RemoteNext(int, IntPtr, out int)'
		    [MarshalAs(UnmanagedType.I4)]
            int celt,
            [Out]
            IntPtr rgelt,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pceltFetched);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumUnknown.Skip(int)'
        void Skip(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumUnknown.Skip(int)'
		    [MarshalAs(UnmanagedType.I4)]
            int celt);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumUnknown.Reset()'
        void Reset();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumUnknown.Reset()'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumUnknown.Clone(out IEnumUnknown)'
        void Clone(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumUnknown.Clone(out IEnumUnknown)'
            [Out]
            out IEnumUnknown ppenum);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("00000101-0000-0000-C000-000000000046")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface IEnumString 
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumString.RemoteNext(int, IntPtr, out int)'
        void RemoteNext(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumString.RemoteNext(int, IntPtr, out int)'
		    [MarshalAs(UnmanagedType.I4)]
            int celt,
            IntPtr rgelt,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pceltFetched);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumString.Skip(int)'
        void Skip(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumString.Skip(int)'
		    [MarshalAs(UnmanagedType.I4)]
            int celt);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumString.Reset()'
        void Reset();
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumString.Reset()'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IEnumString.Clone(out IEnumString)'
        void Clone(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IEnumString.Clone(out IEnumString)'
            [Out]
            out IEnumString ppenum);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("9DD0B56C-AD9E-43ee-8305-487F3188BF7A")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    public interface IOPCServerList2
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IOPCServerList2.EnumClassesOfCategories(int, Guid[], int, Guid[], out IOPCEnumGUID)'
        void EnumClassesOfCategories(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IOPCServerList2.EnumClassesOfCategories(int, Guid[], int, Guid[], out IOPCEnumGUID)'
            [MarshalAs(UnmanagedType.I4)]
            int cImplemented,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)]
            Guid[] rgcatidImpl,
            [MarshalAs(UnmanagedType.I4)]
            int cRequired,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)]
            Guid[] rgcatidReq,
            [Out]
            out IOPCEnumGUID ppenumClsid);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IOPCServerList2.GetClassDetails(ref Guid, out string, out string, out string)'
        void GetClassDetails(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IOPCServerList2.GetClassDetails(ref Guid, out string, out string, out string)'
            ref Guid clsid, 
		    [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string ppszProgID,
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string ppszUserType,
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string ppszVerIndProgID);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IOPCServerList2.CLSIDFromProgID(string, out Guid)'
        void CLSIDFromProgID(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'IOPCServerList2.CLSIDFromProgID(string, out Guid)'
		    [MarshalAs(UnmanagedType.LPWStr)]
            string szProgId,
            [Out]
            out Guid clsid);
    }
}

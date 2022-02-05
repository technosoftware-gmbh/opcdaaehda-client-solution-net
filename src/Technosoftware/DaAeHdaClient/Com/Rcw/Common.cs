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
using System.Runtime.InteropServices;
#endregion

namespace OpcRcw.Comn
{   
    /// <exclude />
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]    
    internal struct CONNECTDATA 
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
    internal interface IEnumConnections
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
    internal interface IConnectionPoint
    {
        void GetConnectionInterface(
            [Out]
            out Guid pIID);

        void GetConnectionPointContainer(
            [Out]
            out IConnectionPointContainer ppCPC);

        void Advise(
            [MarshalAs(UnmanagedType.IUnknown)]
            object pUnkSink,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCookie);

        void Unadvise(
            [MarshalAs(UnmanagedType.I4)]
            int dwCookie);

        void EnumConnections(
            [Out]
            out IEnumConnections ppEnum);
    }

    /// <exclude />
    [ComImport]
    [GuidAttribute("B196B285-BAB4-101A-B69C-00AA00341D07")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IEnumConnectionPoints 
    {
        void RemoteNext(
            [MarshalAs(UnmanagedType.I4)]
            int cConnections,
            [Out]
            IntPtr ppCP,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pcFetched);

        void Skip(
            [MarshalAs(UnmanagedType.I4)]
            int cConnections);

        void Reset();

        void Clone(
            [Out]
            out IEnumConnectionPoints ppEnum);
    }

    /// <exclude />
    [ComImport]
    [GuidAttribute("B196B284-BAB4-101A-B69C-00AA00341D07")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IConnectionPointContainer
    {
        void EnumConnectionPoints(
            [Out]
            out IEnumConnectionPoints ppEnum);

        void FindConnectionPoint(
            ref Guid riid,
            [Out]
            out IConnectionPoint ppCP);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("F31DFDE1-07B6-11d2-B2D8-0060083BA1FB")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IOPCShutdown
    {
        void ShutdownRequest(
			[MarshalAs(UnmanagedType.LPWStr)]
			string szReason);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("F31DFDE2-07B6-11d2-B2D8-0060083BA1FB")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IOPCCommon 
	{
		void SetLocaleID(
			[MarshalAs(UnmanagedType.I4)]
			int dwLcid);

		void GetLocaleID(
			[Out][MarshalAs(UnmanagedType.I4)]
			out int pdwLcid);

		void QueryAvailableLocaleIDs( 
			[Out][MarshalAs(UnmanagedType.I4)]
			out int pdwCount,	
			[Out]
			out IntPtr pdwLcid);

		void GetErrorString( 
			[MarshalAs(UnmanagedType.I4)]
			int dwError,
			[Out][MarshalAs(UnmanagedType.LPWStr)]
			out String ppString);

		void SetClientName(
			[MarshalAs(UnmanagedType.LPWStr)] 
			String szName);
	}

    /// <exclude />
	[ComImport]
	[GuidAttribute("13486D50-4821-11D2-A494-3CB306C10000")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
	internal interface IOPCServerList 
    {
        void EnumClassesOfCategories(
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

        void GetClassDetails(
            ref Guid clsid, 
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string ppszProgID,
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string ppszUserType);

        void CLSIDFromProgID(
		    [MarshalAs(UnmanagedType.LPWStr)]
            string szProgId,
            [Out]
            out Guid clsid);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("55C382C8-21C7-4e88-96C1-BECFB1E3F483")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCEnumGUID 
    {
        void Next(
		    [MarshalAs(UnmanagedType.I4)]
            int celt,
            [Out]
            IntPtr rgelt,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pceltFetched);

        void Skip(
		    [MarshalAs(UnmanagedType.I4)]
            int celt);

        void Reset();

        void Clone(
            [Out]
            out IOPCEnumGUID ppenum);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("0002E000-0000-0000-C000-000000000046")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IEnumGUID 
    {
        void Next(
		    [MarshalAs(UnmanagedType.I4)]
            int celt,
            [Out]
            IntPtr rgelt,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pceltFetched);

        void Skip(
		    [MarshalAs(UnmanagedType.I4)]
            int celt);

        void Reset();

        void Clone(
            [Out]
            out IEnumGUID ppenum);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("00000100-0000-0000-C000-000000000046")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IEnumUnknown 
    {
        void RemoteNext(
		    [MarshalAs(UnmanagedType.I4)]
            int celt,
            [Out]
            IntPtr rgelt,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pceltFetched);

        void Skip(
		    [MarshalAs(UnmanagedType.I4)]
            int celt);

        void Reset();

        void Clone(
            [Out]
            out IEnumUnknown ppenum);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("00000101-0000-0000-C000-000000000046")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IEnumString 
    {
        void RemoteNext(
		    [MarshalAs(UnmanagedType.I4)]
            int celt,
            IntPtr rgelt,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pceltFetched);

        void Skip(
		    [MarshalAs(UnmanagedType.I4)]
            int celt);

        void Reset();

        void Clone(
            [Out]
            out IEnumString ppenum);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("9DD0B56C-AD9E-43ee-8305-487F3188BF7A")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCServerList2
    {
        void EnumClassesOfCategories(
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

        void GetClassDetails(
            ref Guid clsid, 
		    [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string ppszProgID,
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string ppszUserType,
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string ppszVerIndProgID);

        void CLSIDFromProgID(
		    [MarshalAs(UnmanagedType.LPWStr)]
            string szProgId,
            [Out]
            out Guid clsid);
    }
}

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

#pragma warning disable 1591, CS0618  

namespace OpcRcw.Hda
{

    /// <exclude />
	[ComImport]
	[GuidAttribute("7DE5B060-E089-11d2-A5E6-000086339399")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface CATID_OPCHDAServer10 {}

    /// <exclude />
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct OPCHDA_FILETIME
    {
        internal int dwLowDateTime;
        internal int dwHighDateTime;
    }

    /// <exclude />
    internal enum OPCHDA_SERVERSTATUS 
    { 
        OPCHDA_UP = 1,
	    OPCHDA_DOWN,
	    OPCHDA_INDETERMINATE 
    }

    /// <exclude />
    internal enum OPCHDA_BROWSEDIRECTION 
    {
	    OPCHDA_BROWSE_UP = 1,
	    OPCHDA_BROWSE_DOWN,
	    OPCHDA_BROWSE_DIRECT
    }

    /// <exclude />
    internal enum OPCHDA_BROWSETYPE 
    {
	    OPCHDA_BRANCH = 1,
	    OPCHDA_LEAF,
	    OPCHDA_FLAT,
	    OPCHDA_ITEMS
    }

    /// <exclude />
    internal enum OPCHDA_ANNOTATIONCAPABILITIES 
    {  
	    OPCHDA_READANNOTATIONCAP   = 0x01,
	    OPCHDA_INSERTANNOTATIONCAP = 0x02 
    }

    /// <exclude />
    internal enum OPCHDA_UPDATECAPABILITIES 
    {
	    OPCHDA_INSERTCAP        = 0x01,
	    OPCHDA_REPLACECAP       = 0x02,
	    OPCHDA_INSERTREPLACECAP = 0x04,
	    OPCHDA_DELETERAWCAP     = 0x08,
	    OPCHDA_DELETEATTIMECAP  = 0x10
    }

    /// <exclude />
    internal enum OPCHDA_OPERATORCODES 
    {
	    OPCHDA_EQUAL = 1,
	    OPCHDA_LESS,
	    OPCHDA_LESSEQUAL,
	    OPCHDA_GREATER,
	    OPCHDA_GREATEREQUAL,
	    OPCHDA_NOTEQUAL
    }

    /// <exclude />
    internal enum OPCHDA_EDITTYPE 
    {
	    OPCHDA_INSERT = 1,
	    OPCHDA_REPLACE,
	    OPCHDA_INSERTREPLACE,
	    OPCHDA_DELETE
    }

    /// <exclude />
    internal enum OPCHDA_AGGREGATE 
    {
	    OPCHDA_NOAGGREGATE = 0,
	    OPCHDA_INTERPOLATIVE,
	    OPCHDA_TOTAL,
	    OPCHDA_AVERAGE,
	    OPCHDA_TIMEAVERAGE,
	    OPCHDA_COUNT,
	    OPCHDA_STDEV,
	    OPCHDA_MINIMUMACTUALTIME,
	    OPCHDA_MINIMUM,
	    OPCHDA_MAXIMUMACTUALTIME,
	    OPCHDA_MAXIMUM,
	    OPCHDA_START,
	    OPCHDA_END,
	    OPCHDA_DELTA,
	    OPCHDA_REGSLOPE,
	    OPCHDA_REGCONST,
	    OPCHDA_REGDEV,
	    OPCHDA_VARIANCE,
	    OPCHDA_RANGE,
	    OPCHDA_DURATIONGOOD,
	    OPCHDA_DURATIONBAD,
	    OPCHDA_PERCENTGOOD,
	    OPCHDA_PERCENTBAD,
	    OPCHDA_WORSTQUALITY,
	    OPCHDA_ANNOTATIONS
    }

    /// <exclude />
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    internal struct OPCHDA_ANNOTATION 
    {					  
        [MarshalAs(UnmanagedType.I4)]
        internal int hClient;
        [MarshalAs(UnmanagedType.I4)]
        internal int dwNumValues;
        internal IntPtr ftTimeStamps;
        internal IntPtr szAnnotation;
        internal IntPtr ftAnnotationTime;
        internal IntPtr szUser;
    }

    /// <exclude />
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    internal struct OPCHDA_MODIFIEDITEM 
    {
        [MarshalAs(UnmanagedType.I4)]
        internal int hClient;
        [MarshalAs(UnmanagedType.I4)]
        internal int dwCount;
        internal IntPtr pftTimeStamps;
        internal IntPtr pdwQualities;
        internal IntPtr pvDataValues;
        internal IntPtr pftModificationTime;
        internal IntPtr pEditType;
        internal IntPtr szUser;
    }

    /// <exclude />
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    internal struct OPCHDA_ATTRIBUTE
    {
        [MarshalAs(UnmanagedType.I4)]
        internal int hClient;
        [MarshalAs(UnmanagedType.I4)]
        internal int dwNumValues;
        [MarshalAs(UnmanagedType.I4)]
        internal int dwAttributeID;
        internal IntPtr ftTimeStamps;
        internal IntPtr vAttributeValues;
    };

    /// <exclude />
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    internal struct OPCHDA_TIME 
    {
        [MarshalAs(UnmanagedType.I4)]
        internal int bString;
        [MarshalAs(UnmanagedType.LPWStr)]
	    internal string szTime;
	    internal OPCHDA_FILETIME ftTime;
    }

    /// <exclude />
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    internal struct OPCHDA_ITEM
    {
        [MarshalAs(UnmanagedType.I4)]
        internal int hClient;
        [MarshalAs(UnmanagedType.I4)]
        internal int haAggregate;
        [MarshalAs(UnmanagedType.I4)]
        internal int dwCount;
        internal IntPtr pftTimeStamps;
        internal IntPtr pdwQualities;
        internal IntPtr pvDataValues;
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("1F1217B1-DEE0-11d2-A5E5-000086339399")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCHDA_Browser
    {
        void GetEnum(
            OPCHDA_BROWSETYPE dwBrowseType,
            [Out] 
            out Comn.IEnumString ppIEnumString);   

	    void ChangeBrowsePosition(
            OPCHDA_BROWSEDIRECTION dwBrowseDirection,
            [MarshalAs(UnmanagedType.LPWStr)]
		    string szString);

        void GetItemID(
            [MarshalAs(UnmanagedType.LPWStr)]
            string szNode,
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string pszItemID);

        void GetBranchPosition(
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string pszBranchPos);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("1F1217B0-DEE0-11d2-A5E5-000086339399")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCHDA_Server
    {
        void GetItemAttributes( 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCount,
            [Out]
            out IntPtr ppdwAttrID,
            [Out]
            out IntPtr ppszAttrName,
            [Out]
            out IntPtr ppszAttrDesc,
            [Out]
            out IntPtr ppvtAttrDataType);

        void GetAggregates(
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCount,
            [Out]
            out IntPtr ppdwAggrID,
            [Out]
            out IntPtr ppszAggrName,
            [Out]
            out IntPtr ppszAggrDesc);

        void GetHistorianStatus(
            [Out]
            out OPCHDA_SERVERSTATUS pwStatus,
            [Out]
            out IntPtr pftCurrentTime,
            [Out]
            out IntPtr pftStartTime,
            [Out][MarshalAs(UnmanagedType.I2)]
            out short pwMajorVersion,
            [Out][MarshalAs(UnmanagedType.I2)]
            out short wMinorVersion,
            [Out][MarshalAs(UnmanagedType.I2)]
            out short pwBuildNumber,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwMaxReturnValues,
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string  ppszStatusString,
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string ppszVendorInfo);

        void GetItemHandles(
            [MarshalAs(UnmanagedType.I4)]
            int dwCount,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszItemID,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)]  
            int[] phClient,
            [Out]
            out IntPtr pphServer,
            [Out]
            out IntPtr ppErrors);

	    void ReleaseItemHandles(
            [MarshalAs(UnmanagedType.I4)]
            int dwCount,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)]  
	        int[] phServer,
            [Out]
            out IntPtr ppErrors);

        void ValidateItemIDs(
            [MarshalAs(UnmanagedType.I4)]
            int dwCount,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszItemID,
            [Out]
            out IntPtr ppErrors);

        void CreateBrowse(
            [MarshalAs(UnmanagedType.I4)]
            int dwCount,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)]  
            int[] pdwAttrID,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0)]  
            OPCHDA_OPERATORCODES[] pOperator,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.Struct, SizeParamIndex=0)]  
            object[]  vFilter,
            out IOPCHDA_Browser pphBrowser,
            [Out]
            out IntPtr ppErrors);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("1F1217B2-DEE0-11d2-A5E5-000086339399")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCHDA_SyncRead
    {
        void ReadRaw(
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumValues,
            [MarshalAs(UnmanagedType.I4)]
            int bBounds,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=4)]  
            int[] phServer,
            [Out]
            out IntPtr ppItemValues,
            [Out]
            out IntPtr ppErrors);

        void ReadProcessed(
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            OPCHDA_FILETIME ftResampleInterval,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=3)]  
            int[] phServer, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=3)]  
            int[] haAggregate,
            [Out]
            out IntPtr ppItemValues,
            [Out]
            out IntPtr ppErrors);

        void ReadAtTime(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumTimeStamps,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)]  
            OPCHDA_FILETIME[] ftTimeStamps,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)]  
            int[] phServer,
            [Out]
            out IntPtr ppItemValues,
            [Out]
            out IntPtr ppErrors);

        void ReadModified(
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumValues,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=3)] 
            int[] phServer,
            [Out]
            out IntPtr ppItemValues,
            [Out]
            out IntPtr ppErrors);

        void ReadAttribute(
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            [MarshalAs(UnmanagedType.I4)]
            int hServer, 
            [MarshalAs(UnmanagedType.I4)]
            int dwNumAttributes,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=3)] 
            int[] pdwAttributeIDs,
            [Out]
            out IntPtr ppAttributeValues,
            [Out]
            out IntPtr ppErrors);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("1F1217B3-DEE0-11d2-A5E5-000086339399")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCHDA_SyncUpdate
    {
	    void QueryCapabilities(
            [Out]
		    out OPCHDA_UPDATECAPABILITIES pCapabilities);

        void Insert(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)] 
            int[] phServer, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)] 
            OPCHDA_FILETIME[] ftTimeStamps,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.Struct, SizeParamIndex=0)] 
            object[] vDataValues,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)] 
            int[] pdwQualities,
            [Out]
            out IntPtr ppErrors);

        void Replace(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)] 
            int[] phServer, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)] 
            OPCHDA_FILETIME[] ftTimeStamps,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.Struct, SizeParamIndex=0)] 
            object[] vDataValues,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)] 
            int[] pdwQualities,
            [Out]
            out IntPtr ppErrors);

        void InsertReplace(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)] 
            int[] phServer, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)] 
            OPCHDA_FILETIME[] ftTimeStamps,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.Struct, SizeParamIndex=0)] 
            object[] vDataValues,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)] 
            int[] pdwQualities,
            [Out]
            out IntPtr ppErrors);

        void DeleteRaw(
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] phServer,
            [Out]
            out IntPtr ppErrors);

        void DeleteAtTime(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)] 
            int[] phServer, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)] 
            OPCHDA_FILETIME[] ftTimeStamps,
            [Out]
            out IntPtr ppErrors);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("1F1217B4-DEE0-11d2-A5E5-000086339399")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCHDA_SyncAnnotations
    {
	    void QueryCapabilities(
            [Out]
		    out OPCHDA_ANNOTATIONCAPABILITIES pCapabilities);

        void Read(
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] phServer,
            [Out]
            out IntPtr ppAnnotationValues,
            [Out]
            out IntPtr ppErrors);

	    void Insert(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)] 
            int[] phServer,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)] 
            OPCHDA_FILETIME[] ftTimeStamps,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)] 
		    OPCHDA_ANNOTATION[] pAnnotationValues,
            [Out]
            out IntPtr ppErrors);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("1F1217B5-DEE0-11d2-A5E5-000086339399")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCHDA_AsyncRead
    {
        void ReadRaw(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumValues,
            [MarshalAs(UnmanagedType.I4)]
            int bBounds,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=5)] 
            int[] phServer,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

        void AdviseRaw(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            ref OPCHDA_TIME htStartTime,
            OPCHDA_FILETIME     ftUpdateInterval,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=3)] 
            int[] phServer,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

        void ReadProcessed(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            OPCHDA_FILETIME ftResampleInterval,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=4)] 
            int[] phServer,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=4)] 
            int[] haAggregate,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

        void AdviseProcessed(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            ref OPCHDA_TIME htStartTime,
            OPCHDA_FILETIME ftResampleInterval,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] phServer,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] haAggregate,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumIntervals,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

        void ReadAtTime(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumTimeStamps,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=1)] 
            OPCHDA_FILETIME[]  ftTimeStamps,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=3)] 
            int[] phServer,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

        void ReadModified(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumValues,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=4)] 
            int[] phServer,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

        void ReadAttribute(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            [MarshalAs(UnmanagedType.I4)]
            int hServer, 
            [MarshalAs(UnmanagedType.I4)]
            int dwNumAttributes,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=4)] 
            int[] dwAttributeIDs,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

	    void Cancel(
             [MarshalAs(UnmanagedType.I4)]
		     int dwCancelID);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("1F1217B6-DEE0-11d2-A5E5-000086339399")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCHDA_AsyncUpdate
    {
	    void QueryCapabilities(
		    out OPCHDA_UPDATECAPABILITIES pCapabilities
	    );

        void Insert(
            [MarshalAs(UnmanagedType.I4)]
            int  dwTransactionID,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=1)] 
            int[] phServer,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=1)] 
            OPCHDA_FILETIME[]  ftTimeStamps,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.Struct, SizeParamIndex=1)] 
            object[] vDataValues,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=1)] 
            int[] pdwQualities,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

	    void Replace(
            [MarshalAs(UnmanagedType.I4)]
            int  dwTransactionID,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=1)] 
            int[] phServer,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=1)] 
            OPCHDA_FILETIME[]  ftTimeStamps,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.Struct, SizeParamIndex=1)] 
            object[] vDataValues,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=1)] 
            int[] pdwQualities,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

	    void InsertReplace(
            [MarshalAs(UnmanagedType.I4)]
            int  dwTransactionID,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=1)] 
            int[] phServer,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=1)] 
            OPCHDA_FILETIME[]  ftTimeStamps,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.Struct, SizeParamIndex=1)] 
            object[] vDataValues,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=1)] 
            int[] pdwQualities,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

        void DeleteRaw(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=3)] 
            int[] phServer,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

        void DeleteAtTime(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=1)] 
            int[] phServer,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=1)] 
            OPCHDA_FILETIME[] ftTimeStamps,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

	    void Cancel(
            [MarshalAs(UnmanagedType.I4)]
		    int dwCancelID);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("1F1217B7-DEE0-11d2-A5E5-000086339399")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCHDA_AsyncAnnotations
    {
	    void QueryCapabilities(
		    out OPCHDA_ANNOTATIONCAPABILITIES pCapabilities);

        void Read(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=3)] 
            int[] phServer,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

        void Insert(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=1)] 
            int[] phServer,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=1)] 
            OPCHDA_FILETIME[] ftTimeStamps,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=1)] 
            OPCHDA_ANNOTATION[] pAnnotationValues,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

	    void Cancel(
             [MarshalAs(UnmanagedType.I4)]
		     int dwCancelID);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("1F1217B8-DEE0-11d2-A5E5-000086339399")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCHDA_Playback
    {
        void ReadRawWithUpdate(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumValues,
            OPCHDA_FILETIME ftUpdateDuration,
            OPCHDA_FILETIME ftUpdateInterval,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=6)] 
            int[] phServer,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

        void ReadProcessedWithUpdate(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID,
            ref OPCHDA_TIME htStartTime,
            ref OPCHDA_TIME htEndTime,
            OPCHDA_FILETIME ftResampleInterval,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumIntervals,
            OPCHDA_FILETIME ftUpdateInterval,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=6)] 
            int[] phServer,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=6)] 
            int[] haAggregate,
            [Out]
            out int pdwCancelID,
            [Out]
            out IntPtr ppErrors);

	    void Cancel(
            [MarshalAs(UnmanagedType.I4)]
		    int dwCancelID);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("1F1217B9-DEE0-11d2-A5E5-000086339399")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCHDA_DataCallback
    {
        void OnDataChange(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID, 
            [MarshalAs(UnmanagedType.I4)]
            int hrStatus,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=2)] 
            OPCHDA_ITEM[] pItemValues,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] phrErrors);

        void OnReadComplete(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID, 
            [MarshalAs(UnmanagedType.I4)]
            int hrStatus,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=2)] 
            OPCHDA_ITEM[] pItemValues,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] phrErrors);

        void OnReadModifiedComplete(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID, 
            [MarshalAs(UnmanagedType.I4)]
            int hrStatus,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=2)] 
            OPCHDA_MODIFIEDITEM[] pItemValues,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] phrErrors);

        void OnReadAttributeComplete(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID, 
            [MarshalAs(UnmanagedType.I4)]
            int hrStatus,
            [MarshalAs(UnmanagedType.I4)]
            int hClient, 
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=3)] 
            OPCHDA_ATTRIBUTE[] pAttributeValues,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=3)] 
            int[] phrErrors);

        void OnReadAnnotations(
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID, 
            [MarshalAs(UnmanagedType.I4)]
            int hrStatus,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=2)] 
            OPCHDA_ANNOTATION[] pAnnotationValues,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] phrErrors);

        void OnInsertAnnotations (
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID, 
            [MarshalAs(UnmanagedType.I4)]
            int hrStatus,
            [MarshalAs(UnmanagedType.I4)]
            int dwCount, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] phClients, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] phrErrors);

        void OnPlayback (
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID, 
            [MarshalAs(UnmanagedType.I4)]
            int hrStatus,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumItems, 
            IntPtr ppItemValues, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] phrErrors);

        void OnUpdateComplete (
            [MarshalAs(UnmanagedType.I4)]
            int dwTransactionID, 
            [MarshalAs(UnmanagedType.I4)]
            int hrStatus,
            [MarshalAs(UnmanagedType.I4)]
            int dwCount, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] phClients, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)] 
            int[] phrErrors);

        void OnCancelComplete(
            [MarshalAs(UnmanagedType.I4)]
            int dwCancelID);
    }

    /// <exclude />
	internal static class Constants
	{
		// category description.
		internal const string OPC_CATEGORY_DESCRIPTION_HDA10 = "OPC History Data Access Servers Version 1.0";

		// attribute ids.
		internal const int OPCHDA_DATA_TYPE		   = 0x01;
		internal const int OPCHDA_DESCRIPTION		   = 0x02;
		internal const int OPCHDA_ENG_UNITS		   = 0x03;
		internal const int OPCHDA_STEPPED		       = 0x04;
		internal const int OPCHDA_ARCHIVING	       = 0x05;
		internal const int OPCHDA_DERIVE_EQUATION    = 0x06;
		internal const int OPCHDA_NODE_NAME		   = 0x07;
		internal const int OPCHDA_PROCESS_NAME	   = 0x08;
		internal const int OPCHDA_SOURCE_NAME	       = 0x09;
		internal const int OPCHDA_SOURCE_TYPE	       = 0x0a;
		internal const int OPCHDA_NORMAL_MAXIMUM     = 0x0b;
		internal const int OPCHDA_NORMAL_MINIMUM	   = 0x0c;
		internal const int OPCHDA_ITEMID			   = 0x0d;
		internal const int OPCHDA_MAX_TIME_INT	   = 0x0e;
		internal const int OPCHDA_MIN_TIME_INT	   = 0x0f;
		internal const int OPCHDA_EXCEPTION_DEV	   = 0x10;
		internal const int OPCHDA_EXCEPTION_DEV_TYPE = 0x11;
		internal const int OPCHDA_HIGH_ENTRY_LIMIT   = 0x12;
		internal const int OPCHDA_LOW_ENTRY_LIMIT	   = 0x13;

		// attribute names.
		internal const string OPCHDA_ATTRNAME_DATA_TYPE		   = "Data Type";
		internal const string OPCHDA_ATTRNAME_DESCRIPTION        = "Description";
		internal const string OPCHDA_ATTRNAME_ENG_UNITS		   = "Eng Units";
		internal const string OPCHDA_ATTRNAME_STEPPED		       = "Stepped";
		internal const string OPCHDA_ATTRNAME_ARCHIVING	       = "Archiving";
		internal const string OPCHDA_ATTRNAME_DERIVE_EQUATION    = "Derive Equation";
		internal const string OPCHDA_ATTRNAME_NODE_NAME		   = "Node Name";
		internal const string OPCHDA_ATTRNAME_PROCESS_NAME	   = "Process Name";
		internal const string OPCHDA_ATTRNAME_SOURCE_NAME	       = "Source Name";
		internal const string OPCHDA_ATTRNAME_SOURCE_TYPE	       = "Source Type";
		internal const string OPCHDA_ATTRNAME_NORMAL_MAXIMUM     = "Normal Maximum";
		internal const string OPCHDA_ATTRNAME_NORMAL_MINIMUM	   = "Normal Minimum";
		internal const string OPCHDA_ATTRNAME_ITEMID			   = "ItemID";
		internal const string OPCHDA_ATTRNAME_MAX_TIME_INT	   = "Max Time Interval";
		internal const string OPCHDA_ATTRNAME_MIN_TIME_INT	   = "Min Time Interval";
		internal const string OPCHDA_ATTRNAME_EXCEPTION_DEV	   = "Exception Deviation";
		internal const string OPCHDA_ATTRNAME_EXCEPTION_DEV_TYPE = "Exception Dev Type";
		internal const string OPCHDA_ATTRNAME_HIGH_ENTRY_LIMIT   = "High Entry Limit";
		internal const string OPCHDA_ATTRNAME_LOW_ENTRY_LIMIT	   = "Low Entry Limit";

		// aggregate names.
		internal const string OPCHDA_AGGRNAME_INTERPOLATIVE	  = "Interpolative";
		internal const string OPCHDA_AGGRNAME_TOTAL	          = "Total";
		internal const string OPCHDA_AGGRNAME_AVERAGE	          = "Average";
		internal const string OPCHDA_AGGRNAME_TIMEAVERAGE	      = "Time Average";
		internal const string OPCHDA_AGGRNAME_COUNT	          = "Count";
		internal const string OPCHDA_AGGRNAME_STDEV	          = "Standard Deviation";
		internal const string OPCHDA_AGGRNAME_MINIMUMACTUALTIME = "Minimum Actual Time";
		internal const string OPCHDA_AGGRNAME_MINIMUM	          = "Minimum";
		internal const string OPCHDA_AGGRNAME_MAXIMUMACTUALTIME = "Maximum Actual Time";
		internal const string OPCHDA_AGGRNAME_MAXIMUM	          = "Maximum";
		internal const string OPCHDA_AGGRNAME_START	          = "Start";
		internal const string OPCHDA_AGGRNAME_END               = "End";
		internal const string OPCHDA_AGGRNAME_DELTA	          = "Delta";
		internal const string OPCHDA_AGGRNAME_REGSLOPE	      = "Regression Line Slope";
		internal const string OPCHDA_AGGRNAME_REGCONST	      = "Regression Line Constant";
		internal const string OPCHDA_AGGRNAME_REGDEV            = "Regression Line Error";
		internal const string OPCHDA_AGGRNAME_VARIANCE	      = "Variance";
		internal const string OPCHDA_AGGRNAME_RANGE	          = "Range";
		internal const string OPCHDA_AGGRNAME_DURATIONGOOD	  = "Duration Good";
		internal const string OPCHDA_AGGRNAME_DURATIONBAD	      = "Duration Bad";
		internal const string OPCHDA_AGGRNAME_PERCENTGOOD	      = "Percent Good";
		internal const string OPCHDA_AGGRNAME_PERCENTBAD	      = "Percent Bad";
		internal const string OPCHDA_AGGRNAME_WORSTQUALITY	  = "Worst Quality";
		internal const string OPCHDA_AGGRNAME_ANNOTATIONS	      = "Annotations";

		// OPCHDA_QUALITY -- these are the high-order 16 bits, OPC DA Quality occupies low-order 16 bits.
		internal const int OPCHDA_EXTRADATA		  = 0x00010000;
		internal const int OPCHDA_INTERPOLATED	  = 0x00020000;
		internal const int OPCHDA_RAW			      = 0x00040000;
		internal const int OPCHDA_CALCULATED	      = 0x00080000;
		internal const int OPCHDA_NOBOUND		      = 0x00100000;
		internal const int OPCHDA_NODATA			  = 0x00200000;
		internal const int OPCHDA_DATALOST		  = 0x00400000;
		internal const int OPCHDA_CONVERSION		  = 0x00800000;
		internal const int OPCHDA_PARTIAL           = 0x01000000;
	}
}

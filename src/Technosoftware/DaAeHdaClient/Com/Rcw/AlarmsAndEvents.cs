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

#pragma warning disable 1591

namespace OpcRcw.Ae
{
    /// <exclude />
	[ComImport]
	[GuidAttribute("58E13251-AC87-11d1-84D5-00608CB8A7E9")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface CATID_OPCAEServer10 {}

    /// <exclude />
    internal enum OPCAEBROWSEDIRECTION  
    { 
	    OPCAE_BROWSE_UP = 1,
	    OPCAE_BROWSE_DOWN, 
	    OPCAE_BROWSE_TO
    }

    /// <exclude />
    internal enum OPCAEBROWSETYPE
    { 
	    OPC_AREA = 1,
	    OPC_SOURCE
    }
    
    /// <exclude />
    internal enum OPCEVENTSERVERSTATE
    { 
        OPCAE_STATUS_RUNNING = 1,
        OPCAE_STATUS_FAILED,
        OPCAE_STATUS_NOCONFIG,
        OPCAE_STATUS_SUSPENDED,
        OPCAE_STATUS_TEST,
        OPCAE_STATUS_COMM_FAULT
    }

    /// <exclude />
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct FILETIME
    {
	    internal int dwLowDateTime;
		internal int dwHighDateTime;
    }

    /// <exclude />
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    internal struct ONEVENTSTRUCT
    {
        [MarshalAs(UnmanagedType.I2)]
        internal short wChangeMask;
        [MarshalAs(UnmanagedType.I2)]
        internal short wNewState;
        [MarshalAs(UnmanagedType.LPWStr)]
        internal string szSource;
        internal FILETIME ftTime;
        [MarshalAs(UnmanagedType.LPWStr)]
        internal string szMessage;
        [MarshalAs(UnmanagedType.I4)]
        internal int dwEventType;
        [MarshalAs(UnmanagedType.I4)]
        internal int dwEventCategory;
        [MarshalAs(UnmanagedType.I4)]
        internal int dwSeverity; 
        [MarshalAs(UnmanagedType.LPWStr)]
        internal string szConditionName;
        [MarshalAs(UnmanagedType.LPWStr)]
        internal string szSubconditionName;
        [MarshalAs(UnmanagedType.I2)]
        internal short wQuality;
        [MarshalAs(UnmanagedType.I2)]
        internal short wReserved;		
        [MarshalAs(UnmanagedType.I4)]
        internal int bAckRequired;
        internal FILETIME ftActiveTime;
        [MarshalAs(UnmanagedType.I4)]
        internal int dwCookie;
        [MarshalAs(UnmanagedType.I4)]
        internal int dwNumEventAttrs;
        internal IntPtr pEventAttributes;
        [MarshalAs(UnmanagedType.LPWStr)]
        internal string szActorID;
    }

    /// <exclude />
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    internal struct OPCEVENTSERVERSTATUS
    {
        internal FILETIME ftStartTime;
        internal FILETIME ftCurrentTime;
        internal FILETIME ftLastUpdateTime;
        internal OPCEVENTSERVERSTATE dwServerState;
        [MarshalAs(UnmanagedType.I2)]
        internal short wMajorVersion;
        [MarshalAs(UnmanagedType.I2)]
        internal short wMinorVersion;
        [MarshalAs(UnmanagedType.I2)]
        internal short wBuildNumber;
        [MarshalAs(UnmanagedType.I2)]
        internal short wReserved;	
        [MarshalAs(UnmanagedType.LPWStr)]	
        internal string szVendorInfo;
    }

    /// <exclude />
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    internal struct OPCCONDITIONSTATE
    {
        [MarshalAs(UnmanagedType.I2)]
        internal short wState;
        [MarshalAs(UnmanagedType.I2)]
        internal short wReserved1;	
        [MarshalAs(UnmanagedType.LPWStr)]		
        internal string szActiveSubCondition;
        [MarshalAs(UnmanagedType.LPWStr)]	
        internal string szASCDefinition;
        [MarshalAs(UnmanagedType.I4)]
        internal int dwASCSeverity;
        [MarshalAs(UnmanagedType.LPWStr)]	
        internal string szASCDescription;
        [MarshalAs(UnmanagedType.I2)]
        internal short wQuality;
        [MarshalAs(UnmanagedType.I2)]
        internal short wReserved2;		
        internal FILETIME ftLastAckTime;
        internal FILETIME ftSubCondLastActive;
        internal FILETIME ftCondLastActive;
        internal FILETIME ftCondLastInactive;
        [MarshalAs(UnmanagedType.LPWStr)]
        internal string szAcknowledgerID;
        [MarshalAs(UnmanagedType.LPWStr)]
        internal string szComment;
        [MarshalAs(UnmanagedType.I4)]
        internal int dwNumSCs;
        internal IntPtr pszSCNames;
        internal IntPtr pszSCDefinitions;
        internal IntPtr pdwSCSeverities;
        internal IntPtr pszSCDescriptions;
        internal int	 dwNumEventAttrs;
        internal IntPtr pEventAttributes;
        internal IntPtr pErrors;
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("65168851-5783-11D1-84A0-00608CB8A7E9")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCEventServer
    {
        void GetStatus(
            out IntPtr ppEventServerStatus);

        void CreateEventSubscription(
            [MarshalAs(UnmanagedType.I4)]
            int bActive,
            [MarshalAs(UnmanagedType.I4)]
            int dwBufferTime, 
            [MarshalAs(UnmanagedType.I4)]
            int dwMaxSize,
            [MarshalAs(UnmanagedType.I4)]
            int hClientSubscription,
            ref Guid riid,
		    [Out][MarshalAs(UnmanagedType.IUnknown, IidParameterIndex=4)] 
            out object ppUnk,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwRevisedBufferTime,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwRevisedMaxSize);
        
        void QueryAvailableFilters(
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwFilterMask);

        void QueryEventCategories(
            [MarshalAs(UnmanagedType.I4)]
            int dwEventType,	
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCount, 
            [Out]
            out IntPtr ppdwEventCategories,
            [Out]
            out IntPtr ppszEventCategoryDescs);
        
        [PreserveSig]
        int QueryConditionNames(
            [MarshalAs(UnmanagedType.I4)]
            int dwEventCategory, 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCount, 
            [Out]
            out IntPtr ppszConditionNames);

        void QuerySubConditionNames(
            [MarshalAs(UnmanagedType.LPWStr)]
            string szConditionName, 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCount, 
            [Out]
            out IntPtr ppszSubConditionNames);

        void QuerySourceConditions(
            [MarshalAs(UnmanagedType.LPWStr)]
            string szSource, 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCount, 
            [Out]
            out IntPtr ppszConditionNames);

	    void QueryEventAttributes(
            [MarshalAs(UnmanagedType.I4)]
            int dwEventCategory, 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCount, 
            [Out]
            out IntPtr ppdwAttrIDs,
            [Out]
            out IntPtr ppszAttrDescs,
            [Out]
            out IntPtr ppvtAttrTypes);

        void TranslateToItemIDs(
            [MarshalAs(UnmanagedType.LPWStr)]
            string szSource,
            [MarshalAs(UnmanagedType.I4)]
            int dwEventCategory,
            [MarshalAs(UnmanagedType.LPWStr)]
            string szConditionName,
            [MarshalAs(UnmanagedType.LPWStr)]
            string szSubconditionName,
            [MarshalAs(UnmanagedType.I4)]
            int dwCount, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=4)]  
            int[] pdwAssocAttrIDs, 
		    out IntPtr ppszAttrItemIDs,
		    out IntPtr ppszNodeNames,
		    out IntPtr ppCLSIDs);

        void GetConditionState(
            [MarshalAs(UnmanagedType.LPWStr)]
            string szSource,
            [MarshalAs(UnmanagedType.LPWStr)]
            string szConditionName,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumEventAttrs,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)]  
            int[] pdwAttributeIDs,
            [Out]
            out IntPtr ppConditionState);

        void EnableConditionByArea(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumAreas, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszAreas);

        void EnableConditionBySource(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumSources, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszSources);

        void DisableConditionByArea(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumAreas, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszAreas);

        void DisableConditionBySource(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumSources, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszSources);

        void AckCondition(
            [MarshalAs(UnmanagedType.I4)]
            int dwCount,
            [MarshalAs(UnmanagedType.LPWStr)]
            string szAcknowledgerID,
            [MarshalAs(UnmanagedType.LPWStr)]
            string szComment,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszSource,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] szConditionName,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)]  
            FILETIME[] pftActiveTime,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)]  
            int[] pdwCookie,
            [Out]
            out IntPtr ppErrors);

        void CreateAreaBrowser(
            ref Guid riid,
            [Out][MarshalAs(UnmanagedType.IUnknown, IidParameterIndex=0)] 
            out object ppUnk);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("65168855-5783-11D1-84A0-00608CB8A7E9")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCEventSubscriptionMgt
    {
        void SetFilter(	
            [MarshalAs(UnmanagedType.I4)]
            int dwEventType, 
            [MarshalAs(UnmanagedType.I4)]
            int dwNumCategories,		
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=1)]  
            int[] pdwEventCategories, 
            [MarshalAs(UnmanagedType.I4)]
            int dwLowSeverity,
            [MarshalAs(UnmanagedType.I4)]
            int dwHighSeverity,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumAreas,	
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=5)]  	
            string[] pszAreaList,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumSources,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=7)]  
            string[] pszSourceList);

        void GetFilter(	
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwEventType, 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwNumCategories,
            [Out]
            out IntPtr ppdwEventCategories, 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwLowSeverity,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwHighSeverity,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwNumAreas,	
            [Out]	
            out IntPtr ppszAreaList,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwNumSources,
            [Out]
            out IntPtr ppszSourceList);

        void SelectReturnedAttributes(	
            [MarshalAs(UnmanagedType.I4)]
            int dwEventCategory,	
            [MarshalAs(UnmanagedType.I4)]	
            int dwCount,		
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=1)]  
            int[] dwAttributeIDs);

        void GetReturnedAttributes(	
            [MarshalAs(UnmanagedType.I4)]
            int dwEventCategory,	
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int pdwCount,		
            [Out]
            out IntPtr ppdwAttributeIDs);

        void Refresh(
            [MarshalAs(UnmanagedType.I4)]
            int dwConnection);

        void CancelRefresh(
            [MarshalAs(UnmanagedType.I4)]
            int dwConnection);

        void GetState(
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int pbActive, 
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int pdwBufferTime,  
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int pdwMaxSize,
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int phClientSubscription);

        void SetState( 
            IntPtr pbActive, 
            IntPtr pdwBufferTime,
            IntPtr pdwMaxSize,
            [MarshalAs(UnmanagedType.I4)]
            int hClientSubscription,
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int pdwRevisedBufferTime,
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int pdwRevisedMaxSize);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("65168857-5783-11D1-84A0-00608CB8A7E9")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCEventAreaBrowser
    {
        void ChangeBrowsePosition(
            OPCAEBROWSEDIRECTION dwBrowseDirection,  
            [MarshalAs(UnmanagedType.LPWStr)]
            string szString);

        void BrowseOPCAreas(
            OPCAEBROWSETYPE dwBrowseFilterType,
            [MarshalAs(UnmanagedType.LPWStr)]
            string szFilterCriteria,  
            [Out] 
            out Comn.IEnumString ppIEnumString); 

        void GetQualifiedAreaName( 
            [MarshalAs(UnmanagedType.LPWStr)]
            string szAreaName,
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string pszQualifiedAreaName);

	    void GetQualifiedSourceName( 
            [MarshalAs(UnmanagedType.LPWStr)]
            string szSourceName,
            [Out][MarshalAs(UnmanagedType.LPWStr)]
            out string pszQualifiedSourceName);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("6516885F-5783-11D1-84A0-00608CB8A7E9")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCEventSink
    {
        void OnEvent(
            [MarshalAs(UnmanagedType.I4)]
            int hClientSubscription,
            [MarshalAs(UnmanagedType.I4)]
            int bRefresh,
            [MarshalAs(UnmanagedType.I4)]
            int bLastRefresh,
            [MarshalAs(UnmanagedType.I4)]
            int dwCount,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=3)]  
            ONEVENTSTRUCT[] pEvents);
    }

    /// <exclude />
	[ComImport]
	[GuidAttribute("71BBE88E-9564-4bcd-BCFC-71C558D94F2D")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCEventServer2 // : IOPCEventServer
    { 
        void GetStatus(
            out IntPtr ppEventServerStatus);

        void CreateEventSubscription(
            [MarshalAs(UnmanagedType.I4)]
            int bActive,
            [MarshalAs(UnmanagedType.I4)]
            int dwBufferTime, 
            [MarshalAs(UnmanagedType.I4)]
            int dwMaxSize,
            [MarshalAs(UnmanagedType.I4)]
            int hClientSubscription,
            ref Guid riid,
		    [Out][MarshalAs(UnmanagedType.IUnknown, IidParameterIndex=4)] 
            out object ppUnk,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwRevisedBufferTime,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwRevisedMaxSize);
        
        void QueryAvailableFilters(
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwFilterMask);

        void QueryEventCategories(
            [MarshalAs(UnmanagedType.I4)]
            int dwEventType,	
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCount, 
            [Out]
            out IntPtr ppdwEventCategories,
            [Out]
            out IntPtr ppszEventCategoryDescs);

        [PreserveSig]
        int QueryConditionNames(
            [MarshalAs(UnmanagedType.I4)]
            int dwEventCategory, 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCount, 
            [Out]
            out IntPtr ppszConditionNames);

        void QuerySubConditionNames(
            [MarshalAs(UnmanagedType.LPWStr)]
            string szConditionName, 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCount, 
            [Out]
            out IntPtr ppszSubConditionNames);

        void QuerySourceConditions(
            [MarshalAs(UnmanagedType.LPWStr)]
            string szSource, 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCount, 
            [Out]
            out IntPtr ppszConditionNames);

	    void QueryEventAttributes(
            [MarshalAs(UnmanagedType.I4)]
            int dwEventCategory, 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwCount, 
            [Out]
            out IntPtr ppdwAttrIDs,
            [Out]
            out IntPtr ppszAttrDescs,
            [Out]
            out IntPtr ppvtAttrTypes);

        void TranslateToItemIDs(
            [MarshalAs(UnmanagedType.LPWStr)]
            string szSource,
            [MarshalAs(UnmanagedType.I4)]
            int dwEventCategory,
            [MarshalAs(UnmanagedType.LPWStr)]
            string szConditionName,
            [MarshalAs(UnmanagedType.LPWStr)]
            string szSubconditionName,
            [MarshalAs(UnmanagedType.I4)]
            int dwCount, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=4)]  
            int[] pdwAssocAttrIDs, 
		    out IntPtr ppszAttrItemIDs,
		    out IntPtr ppszNodeNames,
		    out IntPtr ppCLSIDs);

        void GetConditionState(
            [MarshalAs(UnmanagedType.LPWStr)]
            string szSource,
            [MarshalAs(UnmanagedType.LPWStr)]
            string szConditionName,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumEventAttrs,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=2)]  
            int[] pdwAttributeIDs,
            [Out]
            out IntPtr ppConditionState);

        void EnableConditionByArea(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumAreas, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszAreas);

        void EnableConditionBySource(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumSources, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszSources);

        void DisableConditionByArea(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumAreas, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszAreas);

        void DisableConditionBySource(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumSources, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszSources);

        void AckCondition(
            [MarshalAs(UnmanagedType.I4)]
            int dwCount,
            [MarshalAs(UnmanagedType.LPWStr)]
            string szAcknowledgerID,
            [MarshalAs(UnmanagedType.LPWStr)]
            string szComment,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszSource,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] szConditionName,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPStruct, SizeParamIndex=0)]  
            FILETIME[] pftActiveTime,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=0)]  
            int[] pdwCookie,
            [Out]
            out IntPtr ppErrors);

        void CreateAreaBrowser(
            ref Guid riid,
            [Out][MarshalAs(UnmanagedType.IUnknown, IidParameterIndex=0)] 
            out object ppUnk);

        void EnableConditionByArea2(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumAreas, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszAreas,
            [Out]
            out IntPtr ppErrors);

	    void EnableConditionBySource2(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumSources, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
		    string[] pszSources,
            [Out]
		    out IntPtr ppErrors);

	    void DisableConditionByArea2(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumAreas, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
		    string[] pszAreas,
            [Out]
		    out IntPtr ppErrors);

	    void DisableConditionBySource2(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumSources, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
		    string[] pszSources,
            [Out]
		    out IntPtr ppErrors);

        void GetEnableStateByArea(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumAreas, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
            string[] pszAreas,
            [Out]
            out IntPtr pbEnabled,
            [Out]
            out IntPtr pbEffectivelyEnabled,
            [Out]
            out IntPtr ppErrors);

	    void GetEnableStateBySource(
            [MarshalAs(UnmanagedType.I4)]
            int dwNumSources, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=0)]  
		    string[] pszSources,
		    out IntPtr pbEnabled,
		    out IntPtr pbEffectivelyEnabled,
		    out IntPtr ppErrors);
    };

    /// <exclude />
	[ComImport]
	[GuidAttribute("94C955DC-3684-4ccb-AFAB-F898CE19AAC3")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCEventSubscriptionMgt2 // : IOPCEventSubscriptionMgt
    {      
        void SetFilter(	
            [MarshalAs(UnmanagedType.I4)]
            int dwEventType, 
            [MarshalAs(UnmanagedType.I4)]
            int dwNumCategories,		
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=1)]  
            int[] pdwEventCategories, 
            [MarshalAs(UnmanagedType.I4)]
            int dwLowSeverity,
            [MarshalAs(UnmanagedType.I4)]
            int dwHighSeverity,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumAreas,	
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=5)]  	
            string[] pszAreaList,
            [MarshalAs(UnmanagedType.I4)]
            int dwNumSources,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPWStr, SizeParamIndex=7)]  
            string[] pszSourceList);

        void GetFilter(	
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwEventType, 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwNumCategories,
            [Out]
            out IntPtr ppdwEventCategories, 
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwLowSeverity,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwHighSeverity,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwNumAreas,	
            [Out]	
            out IntPtr ppszAreaList,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwNumSources,
            [Out]
            out IntPtr ppszSourceList);

        void SelectReturnedAttributes(	
            [MarshalAs(UnmanagedType.I4)]
            int dwEventCategory,	
            [MarshalAs(UnmanagedType.I4)]	
            int dwCount,		
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I4, SizeParamIndex=1)]  
            int[] dwAttributeIDs);

        void GetReturnedAttributes(	
            [MarshalAs(UnmanagedType.I4)]
            int dwEventCategory,	
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int pdwCount,		
            [Out]
            out IntPtr ppdwAttributeIDs);

        void Refresh(
            [MarshalAs(UnmanagedType.I4)]
            int dwConnection);

        void CancelRefresh(
            [MarshalAs(UnmanagedType.I4)]
            int dwConnection);

        void GetState(
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int pbActive, 
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int pdwBufferTime,  
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int pdwMaxSize,
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int phClientSubscription);

        void SetState( 
            IntPtr pbActive, 
            IntPtr pdwBufferTime,
            IntPtr pdwMaxSize,
            [MarshalAs(UnmanagedType.I4)]
            int hClientSubscription,
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int pdwRevisedBufferTime,
            [Out][MarshalAs(UnmanagedType.I4)]	
            out int pdwRevisedMaxSize);

        void SetKeepAlive( 
            [MarshalAs(UnmanagedType.I4)]
            int dwKeepAliveTime,
            [Out][MarshalAs(UnmanagedType.I4)]
            out int pdwRevisedKeepAliveTime);

        void GetKeepAlive( 
            [Out][MarshalAs(UnmanagedType.I4)]
	        out int pdwKeepAliveTime);
    }

    /// <exclude />
	internal static class Constants
	{
		// category description string.
		internal const string OPC_CATEGORY_DESCRIPTION_AE10 = "OPC Alarm & Event Server Version 1.0";

		// state bit masks.
		internal const int CONDITION_ENABLED	 = 0x0001;
		internal const int CONDITION_ACTIVE	 = 0x0002;
		internal const int CONDITION_ACKED     = 0x0004;

		// bit masks for change mask.
		internal const int CHANGE_ACTIVE_STATE = 0x0001;
		internal const int CHANGE_ACK_STATE	 = 0x0002;
		internal const int CHANGE_ENABLE_STATE = 0x0004;
		internal const int CHANGE_QUALITY		 = 0x0008;
		internal const int CHANGE_SEVERITY	 = 0x0010;
		internal const int CHANGE_SUBCONDITION = 0x0020;
		internal const int CHANGE_MESSAGE		 = 0x0040;
		internal const int CHANGE_ATTRIBUTE    = 0x0080;

		// event type.
		internal const int SIMPLE_EVENT	 	 = 0x0001;
		internal const int TRACKING_EVENT		 = 0x0002;
		internal const int CONDITION_EVENT	 = 0x0004;
		internal const int ALL_EVENTS	         = 0x0007;

		// bit masks for QueryAvailableFilters().
		internal const int FILTER_BY_EVENT	 = 0x0001;
		internal const int FILTER_BY_CATEGORY	 = 0x0002;
		internal const int FILTER_BY_SEVERITY  = 0x0004;
		internal const int FILTER_BY_AREA		 = 0x0008;
		internal const int FILTER_BY_SOURCE    = 0x0010;
	}
}

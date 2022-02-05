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

using System.Runtime.InteropServices;
#endregion

#pragma warning disable 1591

namespace OpcRcw.Security
{       
    /// <exclude />
	[ComImport]
	[GuidAttribute("7AA83A01-6C77-11d3-84F9-00008630A38B")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCSecurityNT
    {
	    void IsAvailableNT(
		    [Out][MarshalAs(UnmanagedType.I4)]
		    out int pbAvailable);

	    void QueryMinImpersonationLevel(
		    [Out][MarshalAs(UnmanagedType.I4)]
		    out int pdwMinImpLevel);

	    void ChangeUser();
    };

    /// <exclude />
	[ComImport]
	[GuidAttribute("7AA83A02-6C77-11d3-84F9-00008630A38B")]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)] 
    internal interface IOPCSecurityPrivate
    {
        void IsAvailablePriv(
		    [Out][MarshalAs(UnmanagedType.I4)]
		    out int pbAvailable);

        void Logon(
			[MarshalAs(UnmanagedType.LPWStr)]
		    string szUserID, 
			[MarshalAs(UnmanagedType.LPWStr)]
		    string szPassword);

        void Logoff();
    };
}

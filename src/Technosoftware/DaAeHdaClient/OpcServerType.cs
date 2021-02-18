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
#endregion

namespace Technosoftware.DaAeHdaClient
{
    /// <summary>
    /// This class defines standard server types. A server may 
    /// support one or more server types.
    /// </summary>
    [System.CLSCompliant(false)]
    public class OpcServerType
    {
        ///////////////////////////////////////////////////////////////////////
        #region Standard Server Type Ids

        /// <summary>
        /// The server is a server discovery server.
        /// </summary>
        public const uint XI_DiscoveryServer = 0x0001;

        /// <summary>
        /// The server is a native Xi data server.
        /// </summary>
        public const uint XI_DataServer = 0x0002;

        /// <summary>
        /// The server is a native Xi event server.
        /// </summary>
        public const uint XI_EventServer = 0x0004;

        /// <summary>
        /// The server is a native Xi data journal server.
        /// </summary>
        public const uint XI_DataJournalServer = 0x0008;

        /// <summary>
        /// The server is a native Xi event journal server.
        /// </summary>
        public const uint XI_EventJournalServer = 0x0010;

        /// <summary>
        /// The server wraps an OPC DA 2.05 server.
        /// </summary>
        public const uint DA205_Wrapper = 0x0020;

        /// <summary>
        /// The server wraps an OPC Alarms and Events 1.1 server.
        /// </summary>
        public const uint AE11_Wrapper = 0x0040;

        /// <summary>
        /// The server wraps an OPC HDA 1.2 server.
        /// </summary>
        public const uint HDA12_Wrapper = 0x0080;

        /// <summary>
        /// The server wraps an OPC DA 3.0 server.
        /// </summary>
        public const uint DA30_Wrapper = 0x0100;

        /// <summary>
        /// The server wraps an OPC XMLDA server.
        /// </summary>
        public const uint XMLDA_Wrapper = 0x0200;

        /// <summary>
        /// The server wraps an OPC UA Data Access server.
        /// </summary>
        public const uint UA_DA_Wrapper = 0x0400;

        /// <summary>
        /// The server wraps an OPC UA Alarms and Conditions server.
        /// </summary>
        public const uint UA_AC_Wrapper = 0x0800;

        /// <summary>
        /// The server wraps an OPC UA Historical Data Access server.
        /// </summary>
        public const uint UA_HDA_Wrapper = 0x1000;

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region Public Methods
        
        /// <summary>
        /// Checks if the server supports Data Access functionality
        /// </summary>
        /// <param name="serverType">The type of the server</param>
        /// <returns>Returns true if server supports Data Access functionality; otherwise false</returns>
        public static bool IsDaSupported(uint serverType)
        {
            if ( ((serverType & OpcServerType.DA205_Wrapper) > 0) ||
                 ((serverType & OpcServerType.DA30_Wrapper) > 0) ||
                 ((serverType & OpcServerType.XI_DataServer) > 0) ||
                 ((serverType & OpcServerType.UA_DA_Wrapper) > 0) )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the server supports Alarms and Events functionality
        /// </summary>
        /// <param name="serverType">The type of the server</param>
        /// <returns>Returns true if server supports Alarms andEvents functionality; otherwise false</returns>
        public static bool IsAeSupported(uint serverType)
        {
            if (((serverType & OpcServerType.AE11_Wrapper) > 0) ||
                 ((serverType & OpcServerType.XI_EventServer) > 0) ||
                 ((serverType & OpcServerType.UA_AC_Wrapper) > 0))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the server supports Historical Data functionality
        /// </summary>
        /// <param name="serverType">The type of the server</param>
        /// <returns>Returns true if server supports Historical Data functionality; otherwise false</returns>
        public static bool IsHdaSupported(uint serverType)
        {
            if (((serverType & OpcServerType.HDA12_Wrapper) > 0) ||
                 ((serverType & OpcServerType.UA_HDA_Wrapper) > 0) ||
                 ((serverType & OpcServerType.XI_DataJournalServer) > 0) ||
                 ((serverType & OpcServerType.XI_EventJournalServer) > 0))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}

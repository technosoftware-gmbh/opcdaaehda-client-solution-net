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

using Technosoftware.DaAeHdaClient.Utilities;
#endregion

namespace Technosoftware.DaAeHdaClient
{
    /// <summary>
    /// Manages the license to enable the different product versions.
    /// </summary>
    public class ApplicationInstance
    {
        #region Nested Enums
        /// <summary>
        /// The possible authentication levels.
        /// </summary>
        [Flags]
        public enum AuthenticationLevel : uint
        {
            /// <summary>
            /// Tells DCOM to choose the authentication level using its normal security blanket negotiation algorithm.
            /// </summary>
            Default = 0,

            /// <summary>
            /// Performs no authentication.
            /// </summary>
            None = 1,

            /// <summary>
            /// Authenticates the credentials of the client only when the client establishes a relationship with the server. Datagram transports always use Packet instead.
            /// </summary>
            Connect = 2,

            /// <summary>
            /// Authenticates only at the beginning of each remote procedure call when the server receives the request. Datagram transports use Packet instead.
            /// </summary>
            Call = 3,

            /// <summary>
            /// Authenticates that all data received is from the expected client.
            /// </summary>
            Packet = 4,

            /// <summary>
            /// Authenticates and verifies that none of the data transferred between client and server has been modified.
            /// </summary>
            Integrity = 5,

            /// <summary>
            /// Authenticates all previous levels and encrypts the argument value of each remote procedure call.
            /// </summary>
            Privacy = 6,
        }
        #endregion

        #region Properties
        /// <summary>
        /// This flag suppresses the conversion to local time done during marshalling.
        /// </summary>
        public static bool TimeAsUtc
        {
            get => Com.Interop.PreserveUtc;
            set => Com.Interop.PreserveUtc = value;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes COM security. This should be called directly at the beginning of an application and can only be called once.
        /// </summary>
        /// <param name="authenticationLevel">The default authentication level for the process. Both servers and clients use this parameter when they call CoInitializeSecurity. With the Windows Update KB5004442 a higher authentication level of Integrity must be used.</param>
        public static void InitializeSecurity(AuthenticationLevel authenticationLevel)
        {
            if (!InitializeSecurityCalled)
            {
                Com.Interop.InitializeSecurity((uint)authenticationLevel);
                InitializeSecurityCalled = true;
            }
        }

        /// <summary>
        /// Gets the log file directory and ensures it is writable.
        /// </summary>
        public static string GetLogFileDirectory()
        {
            return ConfigUtils.GetLogFileDirectory();
        }

        /// <summary>
        /// Enable the trace.
        /// </summary>
        /// <param name="path">The path to use.</param>
        /// <param name="filename">The filename.</param>
        public static void EnableTrace(string path, string filename)
        {
            ConfigUtils.EnableTrace(path, filename);
        }
        #endregion

        #region Internal Fields
        internal static bool InitializeSecurityCalled;
        #endregion
    }
}

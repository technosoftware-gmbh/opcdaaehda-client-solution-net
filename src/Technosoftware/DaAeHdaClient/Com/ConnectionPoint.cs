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
using OpcRcw.Comn;
#endregion

namespace Technosoftware.DaAeHdaClient.Com
{
    /// <summary>
    /// Adds and removes a connection point to a server.
    /// </summary>
    internal class ConnectionPoint : IDisposable
    {
        /// <summary>
        /// The COM server that supports connection points.
        /// </summary>
		private IConnectionPoint m_server;

        /// <summary>
        /// The id assigned to the connection by the COM server.
        /// </summary>
		private int m_cookie;
        
        /// <summary>
        /// The number of times Advise() has been called without a matching Unadvise(). 
        /// </summary>
		private int m_refs;
        
        /// <summary>
        /// Initializes the object by finding the specified connection point.
        /// </summary>
        public ConnectionPoint(object server, Guid iid)
        {
            ((IConnectionPointContainer)server).FindConnectionPoint(ref iid, out m_server);
        }

        /// <summary>
        /// Releases the COM server.
        /// </summary>
        public void Dispose()
        {
            if (m_server != null)
            {
                while (Unadvise() > 0);             
                Technosoftware.DaAeHdaClient.Utilities.Interop.ReleaseServer(m_server);
                m_server = null;
            }
        }

        /// <summary> 
        /// The cookie returned in the advise call. 
        /// </summary> 
        public int Cookie 
        { 
            get { return m_cookie; } 
        }
		
        //=====================================================================
        // IConnectionPoint

        /// <summary>
        /// Establishes a connection, if necessary and increments the reference count.
        /// </summary>
        public int Advise(object callback)
        {
            if (m_refs++ == 0) m_server.Advise(callback, out m_cookie);
            return m_refs;
        }

        /// <summary>
        /// Decrements the reference count and closes the connection if no more references.
        /// </summary>
        public int Unadvise()
        {
            if (--m_refs == 0) m_server.Unadvise(m_cookie);
            return m_refs;
        }
    }
}

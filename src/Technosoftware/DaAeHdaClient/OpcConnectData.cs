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
using System.Net;
using System.Runtime.Serialization;
#endregion

namespace Technosoftware.DaAeHdaClient
{
    /// <summary>
    /// Contains protocol dependent connection and authenication information.
    /// </summary>
    [Serializable]
    public class OpcConnectData : ISerializable, ICredentials
    {
        ///////////////////////////////////////////////////////////////////////
        #region Fields

        private WebProxy _proxy;

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region Public Methods

        /// <summary>
        /// The credentials to submit to the proxy server for authentication.
        /// </summary>
		public OpcUserIdentity UserIdentity { get; set; }

        /// <summary>
        /// The license key used to connect to the server.
        /// </summary>
        public string LicenseKey { get; set; }

        /// <summary>
		/// Returns a UserIdentity object that is associated with the specified URI, and authentication type.
        /// </summary>
        public NetworkCredential GetCredential(Uri uri, string authenticationType)
        {
            if (UserIdentity != null)
            {
                return new NetworkCredential(UserIdentity.Username, UserIdentity.Password, UserIdentity.Domain);
            }

            return null;
        }

        /// <summary>
        /// Returns the web proxy object to use when connecting to the server.
        /// </summary>
        public IWebProxy GetProxy()
        {
            if (_proxy != null)
            {
                return _proxy;
            }
            else
            {
                return WebRequest.DefaultWebProxy ;
            }
        }

        /// <summary>
        /// Sets the web proxy object.
        /// </summary>
        public void SetProxy(WebProxy proxy)
        {
            _proxy = proxy;
        }

        /// <summary>
        /// Initializes an instance with the specified credentials.
        /// </summary>
		public OpcConnectData(OpcUserIdentity userIdentity)
        {
			UserIdentity = userIdentity;
            _proxy = null;
        }

        /// <summary>
        /// Initializes an instance with the specified credentials and web proxy.
        /// </summary>
		public OpcConnectData(OpcUserIdentity userIdentity, WebProxy proxy)
        {
            UserIdentity = userIdentity;
            _proxy = proxy;
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region ISerializable Members
        /// <summary>
        /// A set of names for fields used in serialization.
        /// </summary>
        private class Names
        {
            internal const string USER_NAME = "UN";
            internal const string PASSWORD = "PW";
            internal const string DOMAIN = "DO";
            internal const string PROXY_URI = "PU";
            internal const string LICENSE_KEY = "LK";
        }

        /// <summary>
        /// Contructs teh object by de-serializing from the stream.
        /// </summary>
        protected OpcConnectData(SerializationInfo info, StreamingContext context)
        {
            string username = info.GetString(Names.USER_NAME);
            string password = info.GetString(Names.PASSWORD);
            string domain = info.GetString(Names.DOMAIN);
            string proxyUri = info.GetString(Names.PROXY_URI);
            string licenseKey = info.GetString(Names.LICENSE_KEY);

            if (domain != null)
            {
				UserIdentity = new OpcUserIdentity("","");
            }
            else
            {
				UserIdentity = new OpcUserIdentity(username, password);
            }

            if (proxyUri != null)
            {
                _proxy = new WebProxy(proxyUri);
            }
            else
            {
                _proxy = null;
            }
        }

        /// <summary>
        /// Serializes a server into a stream.
        /// </summary>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (UserIdentity != null)
            {
                info.AddValue(Names.USER_NAME, UserIdentity.Username);
                info.AddValue(Names.PASSWORD,  UserIdentity.Password);
                info.AddValue(Names.DOMAIN,    UserIdentity.Domain);
            }
            else
            {
                info.AddValue(Names.USER_NAME, null);
                info.AddValue(Names.PASSWORD, null);
                info.AddValue(Names.DOMAIN, null);
            }

            if (_proxy != null)
            {
                info.AddValue(Names.PROXY_URI, _proxy.Address);
            }
            else
            {
                info.AddValue(Names.PROXY_URI, null);
            }
        }
        #endregion
    }
}

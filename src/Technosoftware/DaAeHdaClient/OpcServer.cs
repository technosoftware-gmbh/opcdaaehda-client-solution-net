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
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

using Microsoft.Win32;
#endregion

namespace Technosoftware.DaAeHdaClient
{
	/// <summary>A base class for an in-process object used to access OPC servers.</summary>
	[Serializable]
	public class OpcServer : IOpcServer, ISerializable, ICloneable
	{
		#region Fields

		/// <summary>
		/// The remote server object.
		/// </summary>
		internal IOpcServer server_;

		/// <summary>
		/// The OpcUrl that describes the network location of the server.
		/// </summary>
		private OpcUrl _url;

		/// <summary>
		/// The factory used to instantiate the remote server.
		/// </summary>
        [CLSCompliant(false)]
        protected IOpcFactory _factory;

		/// <summary>
		/// The last set of credentials used to connect successfully to the server.
		/// </summary>
		private OpcConnectData _connectData;

		/// <summary>
		/// A short name for the server.
		/// </summary>
		private string _serverName;

		/// <summary>
		/// A short name for the server assigned by the client
		/// </summary>
		private string _clientName;

		/// <summary>
		/// The default locale used by the server.
		/// </summary>
		private string _locale;

		/// <summary>
		/// The set of locales supported by the remote server.
		/// </summary>
		private string[] _supportedLocales;

		/// <summary>
		/// The resource manager used to access localized resources.
		/// </summary>
        [CLSCompliant(false)]
        protected ResourceManager _resourceManager;

		#endregion

		#region Constructors, Destructor, Initialization

        /// <summary>
        /// Initializes the object.
        /// </summary>
        public OpcServer()
        {
            _factory = null;
            server_ = null;
            _url = null;
            _serverName = null;
            _supportedLocales = null;
            _resourceManager = new ResourceManager("Technosoftware.DaAeHdaClient.Resources.Strings", Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Initializes the object with a factory and a default OpcUrl.
        /// </summary>
        /// <param name="factory">The OpcFactory used to connect to remote servers.</param>
        /// <param name="url">The network address of a remote server.</param>
		public OpcServer(OpcFactory factory, OpcUrl url)
        {
            if (factory == null) throw new ArgumentNullException("factory");

            _factory = (IOpcFactory)factory.Clone();
            server_ = null;
            _url = null;
            _serverName = null;
            _supportedLocales = null;
            _resourceManager = new ResourceManager("Technosoftware.DaAeHdaClient.Resources.Strings", Assembly.GetExecutingAssembly());

            if (url != null) SetUrl(url);
        }		
        
        /// <summary>
		/// This must be called explicitly by clients to ensure the remote server is released.
		/// </summary>
		public virtual void Dispose()
		{
			if (_factory != null)
			{
				_factory.Dispose();
				_factory = null;
			}

			if (server_ != null)
			{
				try { Disconnect(); }
				catch (Exception e)
				{
                }

				server_ = null;
			}
		}
		#endregion

		#region Properties

		/// <summary>
		/// Information about an OPC Server
		/// </summary>
		public OpcServerDescription ServerDescription { get; set; }

		/// <summary>
		/// List of supported OPC specifications
		/// </summary>
		public IList<OpcSpecification> SupportedSpecifications { get; set; }

        /// <summary>
        /// Can be used to force OPC DA 2.0 even if OPC DA 3.0 serverfeatures are available
        /// </summary>
        public bool ForceDa20Usage { get; set; }
		#endregion

		#region Public Methods
		/// <summary>
		/// Finds the best matching locale given a set of supported locales.
		/// </summary>
		public static string FindBestLocale(string requestedLocale, string[] supportedLocales)
		{
			try
			{
				// check for direct match with requested locale.
				foreach (string supportedLocale in supportedLocales)
				{
					if (supportedLocale == requestedLocale)
					{
						return requestedLocale;
					}
				}

				// try to find match for parent culture.
				CultureInfo requestedCulture = new CultureInfo(requestedLocale);

				foreach (string supportedLocale in supportedLocales)
				{
					try
					{
						CultureInfo supportedCulture = new CultureInfo(supportedLocale);

						if (requestedCulture.Parent.Name == supportedCulture.Name)
						{
							return supportedCulture.Name;
						}
					}
					catch
					{
						continue;
					}
				}

				// return default locale.     
				return (supportedLocales != null && supportedLocales.Length > 0) ? supportedLocales[0] : "";
			}
			catch
			{
				// return default locale on any error.    
				return (supportedLocales != null && supportedLocales.Length > 0) ? supportedLocales[0] : "";
			}
		}
		#endregion

		#region Private Methods

		/// <summary>
		/// Updates the OpcUrl for the server.
		/// </summary>
		private void SetUrl(OpcUrl url)
		{
			if (url == null) throw new ArgumentNullException("url");

			//  cannot change the OpcUrl if the remote server is already instantiated.
			if (server_ != null) throw new OpcResultException(new OpcResult((int)OpcResult.E_FAIL.Code, OpcResult.FuncCallType.SysFuncCall, null), "The server is already connected.");

			//  copy the url.
			_url = (OpcUrl)url.Clone();

			//  construct a name for the server.
			string name = "";

			//  use the host name as a base.
			if (_url.HostName != null)
			{
				name = _url.HostName.ToLower();

				// suppress localhoat and loopback as explicit hostnames.
				if (name == "localhost" || name == "127.0.0.1")
				{
					name = "";
				}
			}

			//  append the port.
			if (_url.Port != 0)
			{
				name += String.Format(".{0}", _url.Port);
			}

			//  add a separator.
			if (name != "") { name += "."; }

			//  use the prog id as the name.
			if (_url.Scheme != OpcUrlScheme.HTTP)
			{
				string progID = _url.Path;

				int index = progID.LastIndexOf('/');

				if (index != -1)
				{
					progID = progID.Substring(0, index);
				}

				name += progID;
			}

				// use full path without the extension as the name.
			else
			{
				string path = _url.Path;

				// strip the file extension.
				int index = path.LastIndexOf('.');

				if (index != -1)
				{
					path = path.Substring(0, index);
				}

				// replace slashes with dashes.
				while (path.IndexOf('/') != -1)
				{
					path = path.Replace('/', '-');
				}

				name += path;
			}

            //  save the generated name in case the server name is not already set
            if (String.IsNullOrEmpty(_serverName))
            {
                _serverName = name;
            }
		}
		#endregion

		#region Protected Methods
		/// <summary>
		/// Returns a localized string with the specified name.
		/// </summary>
		protected string GetString(string name)
		{
			//  create a culture object.
			CultureInfo culture = null;

			try { culture = new CultureInfo(Locale); }
			catch { culture = new CultureInfo(""); }

			//  lookup resource string.
			try { return _resourceManager.GetString(name, culture); }
			catch { return null; }
		}
		#endregion

		#region ISerializable Members
		/// <summary>
		/// A   set of names for fields used in serialization.
		/// </summary>
		private class Names
		{
			internal const string NAME = "Name";
			internal const string URL = "Url";
			internal const string FACTORY = "Factory";
		}

		/// <summary>
		/// Contructs a server by de-serializing its OpcUrl from the stream.
		/// </summary>
		internal OpcServer(SerializationInfo info, StreamingContext context)
		{
			_serverName = info.GetString(Names.NAME);
			_url = (OpcUrl)info.GetValue(Names.URL, typeof(OpcUrl));
			_factory = (IOpcFactory)info.GetValue(Names.FACTORY, typeof(IOpcFactory));
		}

		/// <summary>
		/// Serializes a server into a stream.
		/// </summary>
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(Names.NAME, _serverName);
			info.AddValue(Names.URL, _url);
			info.AddValue(Names.FACTORY, _factory);
		}
		#endregion

        #region ICloneable Members
		/// <summary>
		/// Returns an unconnected copy of the server with the same OpcUrl. 
		/// </summary>
		public virtual object Clone()
		{
			//  do a memberwise clone.
			OpcServer clone = (OpcServer)MemberwiseClone();

			//  place clone in disconnected state.
			clone.server_ = null;
			clone._supportedLocales = null;
			clone._locale = null;
			clone._resourceManager = new ResourceManager("Technosoftware.DaAeHdaClient.Resources.Strings", Assembly.GetExecutingAssembly());

			//  return clone.
			return clone;
		}
		#endregion

		#region IOpcServer Members
        /// <summary>
		/// A short descriptive name for the server.
		/// </summary>
		public virtual string ServerName
		{
			get { return _serverName; }
			set
			{
				_serverName = value;
			}
		}

		/// <summary>
		/// A short descriptive name for the server assigned by the client.
		/// </summary>
		public virtual string ClientName
		{
			get { return _clientName; }
			set
			{
                _clientName = value;
                if (server_ != null)
                {
                    server_.SetClientName(value);
                }
			}
		}
		/// <summary>
		/// The OpcUrl that describes the network location of the server.
		/// </summary>
		public virtual OpcUrl Url
		{
			get { return (_url != null) ? (OpcUrl)_url.Clone() : null; }
			set { SetUrl(value); }
		}

		/// <summary>
		/// The default of locale used by the remote server.
		/// </summary>
		public virtual string Locale {get{ return _locale; }}

		/// <summary>
		/// The set of locales supported by the remote server.
		/// </summary>
		public virtual string[] SupportedLocales { get { return (_supportedLocales != null) ? (string[])_supportedLocales.Clone() : null; } }


		/// <summary>
		/// Whether the remote server is currently connected.
		/// </summary>
		public virtual bool IsConnected { get { return (server_ != null); } }

		/// <summary>
		/// Allows the client to optionally register a client name with the server. This is included primarily for debugging purposes. The recommended behavior is that the client set his Node name and EXE name here.
		/// </summary>
		public virtual void SetClientName(string clientName)
		{
			ClientName = clientName;
		}

		/// <summary>
		/// Establishes a physical connection to the remote server.
		/// </summary>
		public virtual void Connect()
		{
            Connect(_url, null);
		}

        /// <summary>Establishes a physical connection to the remote server.</summary>
        /// <exception cref="OpcResultException" caption="OpcResultException Class">If an OPC specific error occur this exception is raised. The Result field includes then the OPC specific code.</exception>
        /// <param name="url">Name of the server. The usual form is http:://xxx/yyy, e.g. http://localhost//TsOpcXSampleServer/Service.asmx.</param>
        public virtual void Connect(string url)
        {
            OpcConnectData connectData = null;
            _factory = null;
            OpcUrl opcurl = new OpcUrl(url);
            Connect(opcurl, connectData);
        }

		/// <summary>
		/// Establishes a physical connection to the remote server.
		/// </summary>
		/// <param name="connectData">Any protocol configuration or user authenication information.</param>
		public virtual void Connect(OpcConnectData connectData)
		{
            Connect(_url, connectData);
		}

		/// <summary>
		/// Establishes a physical connection to the remote server identified by a OpcUrl.
		/// </summary>
		/// <param name="url">The network address of the remote server.</param>
		/// <param name="connectData">Any protocol configuration or user authenication information.</param>
		public virtual void Connect(OpcUrl url, OpcConnectData connectData)
		{
            if (url == null) throw new ArgumentNullException("url");
			if (server_ != null) throw new OpcResultException(new OpcResult((int)OpcResult.E_FAIL.Code, OpcResult.FuncCallType.SysFuncCall, null), "The server is already connected.");

			//  save url.
			SetUrl(url);

			try
			{
                _factory.ForceDa20Usage = ForceDa20Usage;

				// instantiate the server object.
				server_ = _factory.CreateInstance(url, connectData);

				// save the connect data.
				_connectData = connectData;

				try
				{
					// cache the supported locales.
					GetSupportedLocales();

				// update the default locale.
				SetLocale(_locale);

					SupportedSpecifications = new List<OpcSpecification>();
					if (server_ is Com.Da20.Server)
					{
						SupportedSpecifications.Add(OpcSpecification.OPC_DA_20);
					}
					else if (server_ is Com.Da.Server)
					{
						SupportedSpecifications.Add(OpcSpecification.OPC_DA_30);
						SupportedSpecifications.Add(OpcSpecification.OPC_DA_20);
					}
					else if (server_ is Com.Ae.Server)
					if (server_ is Com.Ae.Server)
                    {
                        SupportedSpecifications.Add(OpcSpecification.OPC_AE_10);
					}
                    else if (server_ is Com.Hda.Server)
                    if (server_ is Com.Hda.Server)
                    {
                        SupportedSpecifications.Add(OpcSpecification.OPC_HDA_10);
					}
                }
                catch (Exception e)
				{
                }

			}
			catch (Exception e)
			{
                if (server_ != null)
				{
					try { Disconnect(); }
					catch (Exception e1)
					{
                    }
				}

                throw e;
			}
		}

		/// <summary>
		/// Disconnects from the server and releases all network resources.
		/// </summary>
		public virtual void Disconnect()
		{
			if (server_ == null) throw new OpcResultException(new OpcResult((int)OpcResult.E_FAIL.Code, OpcResult.FuncCallType.SysFuncCall, null), "The server is not currently connected.");

			//  dispose of the remote server object.
			server_.Dispose();
			server_ = null;
		}

		/// <summary>
		/// Creates a new instance of a server object with the same factory and url.
		/// </summary>
		/// <remarks>This method does not copy the value of any properties.</remarks>
		/// <returns>An unconnected duplicate instance of the server object.</returns>
		public virtual Technosoftware.DaAeHdaClient.OpcServer Duplicate()
		{
			OpcServer instance = (Technosoftware.DaAeHdaClient.OpcServer)Activator.CreateInstance(GetType(), new object[] { _factory, _url });

			//  preserve the credentials.
			instance._connectData = _connectData;

			//  preserve the locale.
			instance._locale = _locale;

			return instance;
		}

		/// <summary>
		/// An event to receive server shutdown notifications.
		/// </summary>
        public virtual event OpcServerShutdownEventHandler ServerShutdownEvent
		{
			add { server_.ServerShutdownEvent += value; }
			remove { server_.ServerShutdownEvent -= value; }
		}

		/// <summary>
		/// The locale used in any error messages or results returned to the client.
		/// </summary>
		/// <returns>The locale name in the format "[languagecode]-[country/regioncode]".</returns>
		public virtual string GetLocale()
		{
			if (server_ == null) throw new NotConnectedException();

			// cache the current locale.
			_locale = server_.GetLocale();

			// return the cached value.
			return _locale;
		}

		/// <summary>
		/// Sets the locale used in any error messages or results returned to the client.
		/// </summary>
		/// <param name="locale">The locale name in the format "[languagecode]-[country/regioncode]".</param>
		/// <returns>A locale that the server supports and is the best match for the requested locale.</returns>
		public virtual string SetLocale(string locale)
		{
			if (server_ == null) throw new NotConnectedException();

			try
			{
				// set the requested locale on the server.
				_locale = server_.SetLocale(locale);
			}
			catch
			{
				// find a best match and check if the server supports it.
				string revisedLocale = OpcServer.FindBestLocale(locale, _supportedLocales);

				if (revisedLocale != locale)
				{
					server_.SetLocale(revisedLocale);
				}

				// cache the revised locale.
				_locale = revisedLocale;
			}
			
			// return actual local used.
			return _locale;
		}	

		/// <summary>
		/// Returns the locales supported by the server
		/// </summary>
		/// <remarks>The first element in the array must be the default locale for the server.</remarks>
		/// <returns>An array of locales with the format "[languagecode]-[country/regioncode]".</returns>
		public virtual string[] GetSupportedLocales()
		{
			if (server_ == null) throw new OpcResultException(new OpcResult((int)OpcResult.E_FAIL.Code, OpcResult.FuncCallType.SysFuncCall, null), "The server is not currently connected.");

			//  cache supported locales.
			_supportedLocales = server_.GetSupportedLocales();

			//  return copy of cached locales. 
			return SupportedLocales;
		}

		/// <summary>
		/// Returns the localized text for the specified result code.
		/// </summary>
		/// <param name="locale">The locale name in the format "[languagecode]-[country/regioncode]".</param>
		/// <param name="resultId">The result code identifier.</param>
		/// <returns>A message localized for the best match for the requested locale.</returns>
		public virtual string GetErrorText(string locale, OpcResult resultId)
		{
			if (server_ == null) throw new OpcResultException(OpcResult.E_FAIL, "The server is not currently connected.");

			return server_.GetErrorText(locale ?? _locale, resultId);
		}
		#endregion
    }

    //=============================================================================
    // Exceptions

    /// <summary>
    /// Raised if an operation cannot be executed because the server is not connected.
    /// </summary>
    [Serializable]
    public class AlreadyConnectedException : ApplicationException
    {
        private const string Default = "The remote server is already connected.";
        /// <remarks/>
        public AlreadyConnectedException() : base(Default) { }
        /// <remarks/>
        public AlreadyConnectedException(string message) : base(Default + "\r\n" + message) { }
        /// <remarks/>
        public AlreadyConnectedException(Exception e) : base(Default, e) { }
        /// <remarks/>
        public AlreadyConnectedException(string message, Exception innerException) : base(Default + "\r\n" + message, innerException) { }
        /// <remarks/>
        protected AlreadyConnectedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Raised if an operation cannot be executed because the server is not connected.
    /// </summary>
    [Serializable]
    public class NotConnectedException : ApplicationException
    {
        private const string Default = "The remote server is not currently connected.";
        /// <remarks/>
        public NotConnectedException() : base(Default) { }
        /// <remarks/>
        public NotConnectedException(string message) : base(Default + "\r\n" + message) { }
        /// <remarks/>
        public NotConnectedException(Exception e) : base(Default, e) { }
        /// <remarks/>
        public NotConnectedException(string message, Exception innerException) : base(Default + "\r\n" + message, innerException) { }
        /// <remarks/>
        protected NotConnectedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Raised if an operation cannot be executed because the server is not reachable.
    /// </summary>
    [Serializable]
    public class ConnectFailedException : OpcResultException
    {
        private const string Default = "Could not connect to server.";
        /// <remarks/>
        public ConnectFailedException() : base(OpcResult.E_ACCESS_DENIED, Default) { }
        /// <remarks/>
        public ConnectFailedException(string message) : base(OpcResult.E_NETWORK_ERROR, Default + "\r\n" + message) { }
        /// <remarks/>
        public ConnectFailedException(Exception e) : base(OpcResult.E_NETWORK_ERROR, Default, e) { }
        /// <remarks/>
        public ConnectFailedException(string message, Exception innerException) : base(OpcResult.E_NETWORK_ERROR, Default + "\r\n" + message, innerException) { }
        /// <remarks/>
        protected ConnectFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Raised if an operation cannot be executed because the server refuses access.
    /// </summary>
    [Serializable]
    public class AccessDeniedException : OpcResultException
    {
        private const string Default = "The server refused the connection.";
        /// <remarks/>
        public AccessDeniedException() : base(OpcResult.E_ACCESS_DENIED, Default) { }
        /// <remarks/>
        public AccessDeniedException(string message) : base(OpcResult.E_ACCESS_DENIED, Default + "\r\n" + message) { }
        /// <remarks/>
        public AccessDeniedException(Exception e) : base(OpcResult.E_ACCESS_DENIED, Default, e) { }
        /// <remarks/>
        public AccessDeniedException(string message, Exception innerException) : base(OpcResult.E_NETWORK_ERROR, Default + "\r\n" + message, innerException) { }
        /// <remarks/>
        protected AccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Raised an remote operation by the server timed out
    /// </summary>
    public class ServerTimeoutException : OpcResultException
    {
        private const string Default = "The server did not respond within the specified timeout period.";
        /// <remarks/>
        public ServerTimeoutException() : base(OpcResult.E_TIMEDOUT, Default) { }
        /// <remarks/>
        public ServerTimeoutException(string message) : base(OpcResult.E_TIMEDOUT, Default + "\r\n" + message) { }
        /// <remarks/>
        public ServerTimeoutException(Exception e) : base(OpcResult.E_TIMEDOUT, Default, e) { }
        /// <remarks/>
        public ServerTimeoutException(string message, Exception innerException) : base(OpcResult.E_TIMEDOUT, Default + "\r\n" + message, innerException) { }
        /// <remarks/>
        protected ServerTimeoutException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Raised an remote operation by the server returned unusable or invalid results.
    /// </summary>
    [Serializable]
    public class InvalidResponseException : ApplicationException
    {
        private const string Default = "The response from the server was invalid or incomplete.";
        /// <remarks/>
        public InvalidResponseException() : base(Default) { }
        /// <remarks/>
        public InvalidResponseException(string message) : base(Default + "\r\n" + message) { }
        /// <remarks/>
        public InvalidResponseException(Exception e) : base(Default, e) { }
        /// <remarks/>
        public InvalidResponseException(string message, Exception innerException) : base(Default + "\r\n" + message, innerException) { }
        /// <remarks/>
        protected InvalidResponseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Raised if the browse position is not valid.
    /// </summary>
    [Serializable]
    public class BrowseCannotContinueException : ApplicationException
    {
        private const string Default = "The browse operation cannot continue.";
        /// <remarks/>
        public BrowseCannotContinueException() : base(Default) { }
        /// <remarks/>
        public BrowseCannotContinueException(string message) : base(Default + "\r\n" + message) { }
        /// <remarks/>
        public BrowseCannotContinueException(string message, Exception innerException) : base(Default + "\r\n" + message, innerException) { }
        /// <remarks/>
        protected BrowseCannotContinueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Raised if the browse position is not valid.
    /// </summary>
    [Serializable]
    public class BadInternalErrorException : ApplicationException
    {
        private const string Default = "License required! You can't use this feature.";
        /// <remarks/>
        public BadInternalErrorException() : base(Default) { }
        /// <remarks/>
        public BadInternalErrorException(string message) : base(message) { }
        /// <remarks/>
        public BadInternalErrorException(string message, Exception innerException) : base(message, innerException) { }
        /// <remarks/>
        protected BadInternalErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

}

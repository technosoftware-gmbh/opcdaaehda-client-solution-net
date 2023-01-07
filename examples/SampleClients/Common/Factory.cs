#region Copyright (c) 2011-2023 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2023 Technosoftware GmbH. All rights reserved
// Web: https://technosoftware.com  
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
// 
// The Software is based on the OPC .NET API Sample Code.
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2023 Technosoftware GmbH. All rights reserved

#region Using Directives

using System;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Ae;
using Technosoftware.DaAeHdaClient.Da;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// Defines utility functions used to instantiate servers.
    /// </summary>
    public class Factory
	{		
		/// <summary>
		/// Creates a server object for the specified URL.
		/// </summary>
		public static OpcServer GetServerForURL(OpcUrl url)
		{
			if (url == null) throw new ArgumentNullException("url");

			OpcServer server = null;

			// create an unconnected server object for XML based servers.
			if (url.Scheme == OpcUrlScheme.HTTP)
			{
                new NotSupportedException("XML not supported with .NET 4.6 and later.");
			}

			// create an unconnected server object for COM based servers.
			else
			{
				// DA
				if (url.Scheme == OpcUrlScheme.DA)  
				{ 
					server = new TsCDaServer(new Technosoftware.DaAeHdaClient.Com.Factory(), url); 
				}

				// AE
				else if (url.Scheme == OpcUrlScheme.AE)  
				{ 
					server = new TsCAeServer(new Technosoftware.DaAeHdaClient.Com.Factory(), url); 
				}

				// HDA
				else if (url.Scheme == OpcUrlScheme.HDA) 
				{ 
					server = new TsCHdaServer(new Technosoftware.DaAeHdaClient.Com.Factory(), url); 
				}

				// Other specifications not supported yet.
				else
				{
					throw new NotSupportedException(url.Scheme);
				}
			}

			return server;
		}
	}
}

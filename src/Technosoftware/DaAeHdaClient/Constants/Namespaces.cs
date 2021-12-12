#region Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
// Web: https://technosoftware.com  
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved

#region Using Directives
using System;
#endregion

namespace Technosoftware.DaAeHdaClient
{
	/// <summary>
	/// Defines well-known namespaces.
	/// </summary>
    public static partial class Namespaces
	{
		/// <summary>
		/// The XML Schema namespace.
		/// </summary>
        public const string XmlSchema = "http://www.w3.org/2001/XMLSchema";

		/// <summary>
		/// The XML Schema Instance namespace.
		/// </summary>
        public const string XmlSchemaInstance = "http://www.w3.org/2001/XMLSchema-instance";

		/// <summary>
		/// The WS Secuirity Extensions Namespace.
		/// </summary>
        public const string WSSecurityExtensions = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        
		/// <summary>
		/// The WS Secuirity Utilities Namespace.
		/// </summary>
        public const string WSSecurityUtilities = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
        
		/// <summary>
		/// The base URI for SDK related schemas.
		/// </summary>
        public const string OpcUaSdk = " http://technosoftware.com/DAAEHDA/Solution/";

		/// <summary>
		/// The URI for the UA SDK Configuration Schema.
		/// </summary>
        public const string OpcUaConfig = OpcUaSdk + "ApplicationConfiguration.xsd";
       
    }
}

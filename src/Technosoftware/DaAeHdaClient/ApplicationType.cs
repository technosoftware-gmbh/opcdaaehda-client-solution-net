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
using System.Runtime.Serialization;
#endregion

namespace Technosoftware.DaAeHdaClient
{
    #region ApplicationType Enumeration
    /// <summary>
    /// 
    /// </summary>
    /// <exclude />
    public enum ApplicationType
    {
        /// <remarks />
        [EnumMember(Value = "Server_0")]
        Server = 0,

        /// <remarks />
        [EnumMember(Value = "Client_1")]
        Client = 1,

        /// <remarks />
        [EnumMember(Value = "ClientAndServer_2")]
        ClientAndServer = 2,

        /// <remarks />
        [EnumMember(Value = "DiscoveryServer_3")]
        DiscoveryServer = 3,
    }
    #endregion
}
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
using System.Threading.Tasks;
using System.Xml;
#endregion

namespace Technosoftware.DaAeHdaClient
{
    /// <summary>
    /// The client or server application configuration.
    /// </summary>
    public interface IApplicationConfiguration :
        IApplicationConfigurationClient,
        IApplicationConfigurationTraceConfiguration
    {
    }

    /// <summary>
    /// The interfaces to implement if a client is selected.
    /// </summary>
    public interface IApplicationConfigurationClientSelected :
        IApplicationConfigurationClientOptions 
    {
    }

    /// <summary>
    /// The options to set if a client is selected.
    /// </summary>
    public interface IApplicationConfigurationClientOptions
    {
        /// <inheritdoc cref="ClientConfiguration.TimeAsUtc"/>
        IApplicationConfigurationClientOptions SeTimeAsUtc(bool timeAsUtc = false);
    }

    /// <summary>
    /// Add the client configuration (optional).
    /// </summary>
    public interface IApplicationConfigurationClient
    {
        /// <summary>
        /// Configure instance to be used for DA/AE/HDA client.
        /// </summary>
        IApplicationConfigurationClientSelected AsClient();
    }

    /// <summary>
    /// Add the trace configuration.
    /// </summary>
    public interface IApplicationConfigurationTraceConfiguration :
        IApplicationConfigurationCreate
    {
        /// <inheritdoc cref="TraceConfiguration.OutputFilePath"/>
        IApplicationConfigurationTraceConfiguration SetOutputFilePath(string outputFilePath);

        /// <inheritdoc cref="TraceConfiguration.DeleteOnLoad"/>
        IApplicationConfigurationTraceConfiguration SetDeleteOnLoad(bool deleteOnLoad);

        /// <inheritdoc cref="TraceConfiguration.TraceMasks"/>
        IApplicationConfigurationTraceConfiguration SetTraceMasks(int TraceMasks);
    }

    /// <summary>
    /// Create and validate the application configuration.
    /// </summary>
    public interface IApplicationConfigurationCreate
    {
        /// <summary>
        /// Creates and updates the application configuration.
        /// </summary>
        Task<ApplicationConfiguration> CreateAsync();
    }
}


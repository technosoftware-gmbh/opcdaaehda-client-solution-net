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
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml;

#endregion

namespace Technosoftware.DaAeHdaClient
{
    /// <summary>
    /// Manages a configuration for an OPC UA application.
    /// </summary>
    public class ApplicationConfigurationManager :
        IApplicationConfigurationManager
    {
        #region ctor
        /// <summary>
        /// Create the application configuration manager.
        /// </summary>
        public ApplicationConfigurationManager(ApplicationInstance applicationInstance)
        {
            ApplicationInstance = applicationInstance;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The application instance used to build the configuration.
        /// </summary>
        public ApplicationInstance ApplicationInstance { get; private set; }
        /// <summary>
        /// The application configuration.
        /// </summary>
        public ApplicationConfiguration ApplicationConfiguration => ApplicationInstance.ApplicationConfiguration;
        #endregion

        #region Public Methods
        /// <inheritdoc/>
        public IApplicationConfigurationClientSelected AsClient()
        {
            switch (ApplicationInstance.ApplicationType)
            {
                case ApplicationType.Client:
                    break;
                default:
                    throw new ArgumentException("Invalid application type for client.");
            }

            typeSelected_ = true;

            ApplicationConfiguration.ClientConfiguration = new ClientConfiguration();

            return this;
        }

        /// <inheritdoc/>
        public async Task<ApplicationConfiguration> CreateAsync()
        {
            // sanity checks
            if (ApplicationInstance.ApplicationType == ApplicationType.Client)
            {
                if (ApplicationConfiguration.ClientConfiguration == null) throw new ArgumentException("ApplicationType Client is not configured.");
            }

            ApplicationConfiguration.TraceConfiguration?.ApplySettings();

            await ApplicationConfiguration.Validate(ApplicationInstance.ApplicationType).ConfigureAwait(false);

            return ApplicationConfiguration;
        }

        /// <inheritdoc/>
        public IApplicationConfigurationClientOptions SeTimeAsUtc(bool timeAsUtc = false)
        {
            ApplicationConfiguration.ClientConfiguration.TimeAsUtc = timeAsUtc;
            return this;
        }

        /// <inheritdoc/>
        public IApplicationConfigurationTraceConfiguration SetOutputFilePath(string outputFilePath)
        {
            ApplicationConfiguration.TraceConfiguration.OutputFilePath = outputFilePath;
            return this;
        }

        /// <inheritdoc/>
        public IApplicationConfigurationTraceConfiguration SetDeleteOnLoad(bool deleteOnLoad)
        {
            ApplicationConfiguration.TraceConfiguration.DeleteOnLoad = deleteOnLoad;
            return this;
        }

        /// <inheritdoc/>
        public IApplicationConfigurationTraceConfiguration SetTraceMasks(int traceMasks)
        {
            ApplicationConfiguration.TraceConfiguration.TraceMasks = traceMasks;
            return this;
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Fields
        private bool typeSelected_;
        #endregion
    }
}

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
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
#endregion

namespace Technosoftware.DaAeHdaClient
{
    /// <summary>
	/// Loads the configuration section for an application.
	/// </summary>
	public class ApplicationConfigurationSection
    {
        #region IConfigurationSectionHandler Members	
        /// <summary>
        /// Creates the configuration object from the configuration section.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        /// <param name="configContext">The configuration context object.</param>
        /// <param name="section">The section as XML node.</param>
        /// <returns>The created section handler object.</returns>
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            XmlNode element = section.FirstChild;

            while (element != null && typeof(XmlElement) != element.GetType())
            {
                element = element.NextSibling;
            }

            using (XmlReader reader = XmlReader.Create(new StringReader(element.OuterXml), Utils.DefaultXmlReaderSettings()))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(ConfigurationLocation));
                ConfigurationLocation configuration = serializer.ReadObject(reader) as ConfigurationLocation;
                return configuration;
            }
        }
        #endregion
    }

    /// <summary>
    /// Represents the location of a configuration file.
    /// </summary>
    public class ConfigurationLocation
    {
        #region Persistent Properties
        /// <summary>
        /// Gets or sets the relative or absolute path to the configuration file.
        /// </summary>
        /// <value>The file path.</value>
        [DataMember(IsRequired = true, Order = 0)]
        public string FilePath
        {
            get { return m_filePath; }
            set { m_filePath = value; }
        }
        #endregion

        #region Private Fields
        private string m_filePath;
        #endregion
    }

    /// <summary>
    /// Stores the configurable configuration information for a UA application.
    /// </summary>
    public partial class ApplicationConfiguration
    {
        #region Public Methods
        /// <summary>
        /// Gets the file that was used to load the configuration.
        /// </summary>
        /// <value>The source file path.</value>
        public string SourceFilePath => m_sourceFilePath;

        /// <summary>
        /// Loads and validates the application configuration from a configuration section.
        /// </summary>
        /// <param name="sectionName">Name of configuration section for the current application's default configuration containing <see cref="ConfigurationLocation"/>.</param>
        /// <param name="applicationType">Type of the application.</param>
        /// <returns>Application configuration</returns>
        public static Task<ApplicationConfiguration> Load(string sectionName, ApplicationType applicationType)
        {
            return Load(sectionName, applicationType, typeof(ApplicationConfiguration));
        }

        /// <summary>
        /// Loads and validates the application configuration from a configuration section.
        /// </summary>
        /// <param name="sectionName">Name of configuration section for the current application's default configuration containing <see cref="ConfigurationLocation"/>.</param>
        /// <param name="applicationType">A description for the ApplicationType DataType.</param>
        /// <param name="systemType">A user type of the configuration instance.</param>
        /// <returns>Application configuration</returns>
        public static Task<ApplicationConfiguration> Load(string sectionName, ApplicationType applicationType, Type systemType)
        {
            string filePath = GetFilePathFromAppConfig(sectionName);

            FileInfo file = new FileInfo(filePath);

            if (!file.Exists)
            {
                var message = new StringBuilder();
                message.AppendFormat("Configuration file does not exist: {0}", filePath);
                message.AppendLine();
                message.AppendFormat("Current directory is: {0}", Directory.GetCurrentDirectory());
                throw ServiceResultException.Create(
                    StatusCodes.BadConfigurationError, message.ToString());
            }

            return Load(file, applicationType, systemType);
        }

        /// <summary>
        /// Loads but does not validate the application configuration from a configuration section.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="systemType">Type of the system.</param>
        /// <returns>Application configuration</returns>
        /// <remarks>Use this method to ensure the configuration is not changed during loading.</remarks>
        public static ApplicationConfiguration LoadWithNoValidation(FileInfo file, Type systemType)
        {
            using (var stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    DataContractSerializer serializer = new DataContractSerializer(systemType);

                    ApplicationConfiguration configuration = serializer.ReadObject(stream) as ApplicationConfiguration;

                    if (configuration != null)
                    {
                        configuration.m_sourceFilePath = file.FullName;
                    }

                    return configuration;
                }
                catch (Exception e)
                {
                    var message = new StringBuilder();
                    message.AppendFormat("Configuration file could not be loaded: {0}", file.FullName);
                    message.AppendLine();
                    message.AppendFormat("Error is: {0}", e.Message);
                    throw ServiceResultException.Create(
                        StatusCodes.BadConfigurationError, e, message.ToString());
                }
            }
        }

        /// <summary>
        /// Loads and validates the application configuration from a configuration section.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="applicationType">Type of the application.</param>
        /// <param name="systemType">Type of the system.</param>
        /// <returns>Application configuration</returns>
        public static Task<ApplicationConfiguration> Load(FileInfo file, ApplicationType applicationType, Type systemType)
        {
            return ApplicationConfiguration.Load(file, applicationType, systemType, true);
        }

        /// <summary>
        /// Loads and validates the application configuration from a configuration section.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="applicationType">Type of the application.</param>
        /// <param name="systemType">Type of the system.</param>
        /// <param name="applyTraceSettings">if set to <c>true</c> apply trace settings after validation.</param>
        /// <returns>Application configuration</returns>
        public static async Task<ApplicationConfiguration> Load(
            FileInfo file,
            ApplicationType applicationType,
            Type systemType,
            bool applyTraceSettings)
        {
            ApplicationConfiguration configuration = null;

            try
            {
                using (FileStream stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    configuration = await Load(stream, applicationType, systemType, applyTraceSettings);
                }
            }
            catch (Exception e)
            {
                var message = new StringBuilder();
                message.AppendFormat("Configuration file could not be loaded: {0}", file.FullName);
                message.AppendLine();
                message.Append(e.Message);
                throw ServiceResultException.Create(
                    StatusCodes.BadConfigurationError, e, message.ToString());
            }

            if (configuration != null)
            {
                configuration.m_sourceFilePath = file.FullName;
            }

            return configuration;
        }

        /// <summary>
        /// Loads and validates the application configuration from a configuration section.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="applicationType">Type of the application.</param>
        /// <param name="systemType">Type of the system.</param>
        /// <param name="applyTraceSettings">if set to <c>true</c> apply trace settings after validation.</param>
        /// <returns>Application configuration</returns>
        public static async Task<ApplicationConfiguration> Load(
            Stream stream,
            ApplicationType applicationType,
            Type systemType,
            bool applyTraceSettings)
        {
            ApplicationConfiguration configuration = null;
            systemType = systemType ?? typeof(ApplicationConfiguration);

            try
            {
                DataContractSerializer serializer = new DataContractSerializer(systemType);
                configuration = (ApplicationConfiguration)serializer.ReadObject(stream);
            }
            catch (Exception e)
            {
                var message = new StringBuilder();
                message.AppendFormat("Configuration could not be loaded.");
                message.AppendLine();
                message.AppendFormat("Error is: {0}", e.Message);
                throw ServiceResultException.Create(
                    StatusCodes.BadConfigurationError, e, message.ToString());
            }

            if (configuration != null)
            {
                // should not be here but need to preserve old behavior.
                if (applyTraceSettings && configuration.TraceConfiguration != null)
                {
                    configuration.TraceConfiguration.ApplySettings();
                }

                await configuration.Validate(applicationType).ConfigureAwait(false);
            }

            return configuration;
        }

        /// <summary>
        /// Reads the file path from the application configuration file.
        /// </summary>
	    /// <param name="sectionName">Name of configuration section for the current application's default configuration containing <see cref="ConfigurationLocation"/>.
	    /// </param>
        /// <returns>File path from the application configuration file.</returns>
        public static string GetFilePathFromAppConfig(string sectionName)
        {
            // convert to absolute file path (expands environment strings).
            string absolutePath = Utils.GetAbsoluteFilePath(sectionName + ".Config.xml", true, false, false);
            return (absolutePath != null) ? absolutePath : sectionName + ".Config.xml";
        }

        /// <summary>
        /// Saves the configuration file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <remarks>Calls GetType() on the current instance and passes that to the DataContractSerializer.</remarks>
        public void SaveToFile(string filePath)
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                CloseOutput = true
            };

            using (Stream ostrm = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite))
            using (XmlWriter writer = XmlDictionaryWriter.Create(ostrm, settings))
            {
                DataContractSerializer serializer = new DataContractSerializer(GetType());
                serializer.WriteObject(writer, this);
            }
        }

        /// <summary>
        /// Ensures that the application configuration is valid.
        /// </summary>
        /// <param name="applicationType">Type of the application.</param>
        public virtual async Task Validate(ApplicationType applicationType)
        {
            if (applicationType == ApplicationType.Client)
            {
                if (ClientConfiguration == null)
                {
                    throw ServiceResultException.Create(StatusCodes.BadConfigurationError, "ClientConfiguration must be specified.");
                }

                ClientConfiguration.Validate();
            }
        }
        #endregion
    }

    #region TraceConfiguration Class
    /// <summary>
    /// Specifies parameters used for tracing.
    /// </summary>
    public partial class TraceConfiguration
    {
        #region Public Methods
        /// <summary>
        /// Applies the trace settings to the current process.
        /// </summary>
        public void ApplySettings()
        {
            Utils.SetTraceLog(m_outputFilePath, m_deleteOnLoad);
            Utils.SetTraceMask(m_traceMasks);

            if (m_traceMasks == 0)
            {
                Utils.SetTraceOutput(Utils.TraceOutput.Off);
            }
            else
            {
                Utils.SetTraceOutput(Utils.TraceOutput.DebugAndFile);
            }
        }
        #endregion
    }
    #endregion

    #region ClientConfiguration Class
    /// <summary>
    /// The configuration for a client application.
    /// </summary>
    public partial class ClientConfiguration
    {
        #region Public Methods
        /// <summary>
        /// Validates the configuration.
        /// </summary>
        public void Validate()
        {
        }
        #endregion
    }
    #endregion
}

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
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
#endregion

namespace Technosoftware.DaAeHdaClient
{

    #region ApplicationConfiguration
    /// <summary>
    /// Stores the configurable configuration information for a UA application.
    /// </summary>
    [DataContract(Namespace = Namespaces.OpcUaConfig)]
    public partial class ApplicationConfiguration
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public ApplicationConfiguration()
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_sourceFilePath = null;
            m_disableHiResClock = false;
            m_properties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes the object during deserialization.
        /// </summary>
        /// <param name="context">The context.</param>
        [OnDeserializing()]
        public void Initialize(StreamingContext context) => Initialize();
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets an object used to synchronize access to the properties dictionary.
        /// </summary>
        /// <value>
        /// The object used to synchronize access to the properties dictionary.
        /// </value>
        public object PropertiesLock => m_properties;

        /// <summary>
        /// Gets a dictionary used to save state associated with the application.
        /// </summary>
        /// <value>
        /// The dictionary used to save state associated with the application.
        /// </value>
        public IDictionary<string, object> Properties => m_properties;
        #endregion

        #region Persistent Properties
        /// <summary>
        /// The type of application.
        /// </summary>
        /// <value>The type of the application.</value>
        [DataMember(IsRequired = true, Order = 3)]
        public ApplicationType ApplicationType
        {
            get { return m_applicationType; }
            set { m_applicationType = value; }
        }

        /// <summary>
        /// Additional configuration for client applications.
        /// </summary>
        /// <value>The client configuration.</value>
        [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 8)]
        public ClientConfiguration ClientConfiguration
        {
            get { return m_clientConfiguration; }
            set { m_clientConfiguration = value; }
        }

        /// <summary>
        /// Configuration of the trace and information about log file
        /// </summary>
        /// <value>The trace configuration.</value>
        [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 11)]
        public TraceConfiguration TraceConfiguration
        {
            get { return m_traceConfiguration; }
            set { m_traceConfiguration = value; }
        }

        /// <summary>
        /// Disabling / enabling high resolution clock 
        /// </summary>
        /// <value><c>true</c> if high resolution clock is disabled; otherwise, <c>false</c>.</value>
        [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 12)]
        public bool DisableHiResClock
        {
            get { return m_disableHiResClock; }
            set { m_disableHiResClock = value; }
        }
        #endregion

        #region Private Fields

        private ApplicationType m_applicationType;

        private ClientConfiguration m_clientConfiguration;
        private TraceConfiguration m_traceConfiguration;
        private bool m_disableHiResClock;
        private string m_sourceFilePath;
        private Dictionary<string, object> m_properties;
        #endregion
    }
    #endregion

    #region ClientConfiguration Class
    /// <summary>
    /// The configuration for a client application.
    /// </summary>
    [DataContract(Namespace = Namespaces.OpcUaConfig)]
    public partial class ClientConfiguration
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public ClientConfiguration()
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_timeAsUtc = false;
        }

        /// <summary>
        /// Initializes the object during deserialization.
        /// </summary>
        /// <param name="context">The context.</param>
        [OnDeserializing()]
        public void Initialize(StreamingContext context) => Initialize();
        #endregion

        #region Persistent Properties
        /// <summary>
        /// The default session timeout (in milliseconds).
        /// </summary>
        /// <value>The default session timeout.</value>
        [DataMember(IsRequired = false, Order = 0)]
        public bool TimeAsUtc
        {
            get { return m_timeAsUtc; }
            set { m_timeAsUtc = value; }
        }
        #endregion

        #region Private Members
        private bool m_timeAsUtc;
        #endregion
    }
    #endregion

    #region TraceConfiguration Class
    /// <summary>
    /// Specifies parameters used for tracing.
    /// </summary>
    [DataContract(Namespace = Namespaces.OpcUaConfig)]
    public partial class TraceConfiguration
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public TraceConfiguration()
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_outputFilePath = null;
            m_deleteOnLoad = false;
        }

        /// <summary>
        /// Initializes the object during deserialization.
        /// </summary>
        /// <param name="context">The context.</param>
        [OnDeserializing()]
        public void Initialize(StreamingContext context) => Initialize();
        #endregion

        #region Persistent Properties
        /// <summary>
        /// The output file used to log the trace information.
        /// </summary>
        /// <value>The output file path.</value>
        [DataMember(IsRequired = false, Order = 0)]
        public string OutputFilePath
        {
            get { return m_outputFilePath; }
            set { m_outputFilePath = value; }
        }

        /// <summary>
        /// Whether the existing log file should be deleted when the application configuration is loaded.
        /// </summary>
        /// <value><c>true</c> if existing log file should be deleted when the application configuration is loaded; otherwise, <c>false</c>.</value>
        [DataMember(IsRequired = false, Order = 1)]
        public bool DeleteOnLoad
        {
            get { return m_deleteOnLoad; }
            set { m_deleteOnLoad = value; }
        }

        /// <summary>
        /// The masks used to select what is written to the output  
        /// Masks supported by the trace feature:
        /// - Do not output any messages -None = 0x0;
        /// - Output error messages - Error = 0x1;
        /// - Output informational messages - Information = 0x2;
        /// - Output stack traces - StackTrace = 0x4;
        /// - Output basic messages for service calls - Service = 0x8;
        /// - Output detailed messages for service calls - ServiceDetail = 0x10;
        /// - Output basic messages for each operation - Operation = 0x20;
        /// - Output detailed messages for each operation - OperationDetail = 0x40;
        /// - Output messages related to application initialization or shutdown - StartStop = 0x80;
        /// - Output messages related to a call to an external system - ExternalSystem = 0x100;
        /// - Output messages related to security. - Security = 0x200;
        /// </summary>
        /// <value>The trace masks.</value>
        [DataMember(IsRequired = false, Order = 2)]
        public int TraceMasks
        {
            get { return m_traceMasks; }
            set { m_traceMasks = value; }
        }
        #endregion

        #region Private Fields
        private string m_outputFilePath;
        private bool m_deleteOnLoad;
        private int m_traceMasks;
        #endregion
    }
    #endregion
}
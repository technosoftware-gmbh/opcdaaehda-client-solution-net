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
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
#endregion

namespace Technosoftware.DaAeHdaClient
{
    /// <summary>
    /// A class that combines the status code and diagnostic info structures.
    /// </summary>
    [DataContract(Namespace = Namespaces.OpcUaSdk)]
    public class ServiceResult
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        private ServiceResult()
        {
            Code = StatusCodes.Good;
        }

        /// <summary>
        /// Constructs a object by specifying each property.
        /// </summary>
        public ServiceResult(
            StatusCode code,
            string additionalInfo,
            ServiceResult innerResult)
        {
            StatusCode = code;
            AdditionalInfo = additionalInfo;
            InnerResult = innerResult;
        }

        /// <summary>
        /// Constructs a object by specifying each property.
        /// </summary>
        public ServiceResult(
            StatusCode code,
            ServiceResult innerResult)
        :
            this(code, null, innerResult)
        {
        }

        /// <summary>
        /// Constructs a object by specifying each property.
        /// </summary>
        /// <remarks>
        /// The innerException is used to construct the innerResult.
        /// </remarks>
        public ServiceResult(StatusCode code, Exception innerException)
        :
            this(code, null, innerException)
        {
        }

        /// <summary>
        /// Constructs a object by specifying each property.
        /// </summary>
        public ServiceResult(
            StatusCode code,
            string additionalInfo)
        :
            this(code, additionalInfo, (ServiceResult)null)
        {
        }

        /// <summary>
        /// Constructs a object from a StatusCode.
        /// </summary>
        public ServiceResult(StatusCode status)
        {
            m_code = status.Code;
        }

        /// <summary>
        /// Constructs a object from a StatusCode.
        /// </summary>
        public ServiceResult(uint code)
        {
            m_code = code;
        }

        /// <summary>
        /// Constructs a object by specifying each property.
        /// </summary>
        /// <remarks>
        /// The innerException is used to construct the inner result.
        /// </remarks>
        public ServiceResult(
            StatusCode code,
            string additionalInfo,
            Exception innerException)
        {
            ServiceResult innerResult = new ServiceResult(innerException);

            // check if no new information provided.
            if (code.Code == innerResult.Code)
            {
                m_code = innerResult.Code;
                m_additionalInfo = innerResult.AdditionalInfo;
                m_innerResult = innerResult.InnerResult;
            }

            // make the exception the inner result.
            else
            {
                m_code = code.Code;
                m_additionalInfo = additionalInfo;
                m_innerResult = innerResult;
            }
        }

        /// <summary>
        /// Constructs a object from an exception.
        /// </summary>
        /// <remarks>
        /// The code, symbolicId, namespaceUri and localizedText parameters are ignored for ServiceResultExceptions.
        /// </remarks>
        public ServiceResult(
            Exception e,
            uint defaultCode)
        {
            ServiceResultException sre = e as ServiceResultException;

            if (sre != null)
            {
                m_code = sre.StatusCode;
                m_innerResult = sre.Result.InnerResult;
            }
            else
            {
                m_code = defaultCode;
            }

            m_additionalInfo = BuildExceptionTrace(e);
        }

        /// <summary>
        /// Constructs a object from an exception.
        /// </summary>
        public ServiceResult(Exception exception)
        :
            this(exception, StatusCodes.Bad)
        {
        }
        #endregion

        #region Static Interface
        /// <summary>
        /// A result representing a good status.
        /// </summary>
        public static ServiceResult Good => s_Good;

        private static readonly ServiceResult s_Good = new ServiceResult();

        /// <summary>
        /// Creates a new instance of a ServiceResult
        /// </summary>
        public static ServiceResult Create(uint code, string format, params object[] args)
        {
            if (format == null)
            {
                return new ServiceResult(code);
            }

            if (args == null || args.Length == 0)
            {
                return new ServiceResult(code, format);
            }

            return new ServiceResult(code, Utils.Format(format, args));
        }

        /// <summary>
        /// Creates a new instance of a ServiceResult
        /// </summary>
        public static ServiceResult Create(Exception e, uint defaultCode, string format, params object[] args)
        {
            // replace the default code with the one from the exception.
            ServiceResultException sre = e as ServiceResultException;

            if (sre != null)
            {
                defaultCode = sre.StatusCode;
            }

            if (format == null)
            {
                return new ServiceResult(e, defaultCode);
            }

            if (args == null || args.Length == 0)
            {
                return new ServiceResult(defaultCode, format, e);
            }

            return new ServiceResult(defaultCode, Utils.Format(format, args), e);
        }

        /// <summary>
        /// Returns true if the status code is good.
        /// </summary>
        public static bool IsGood(ServiceResult status)
        {
            if (status != null)
            {
                return StatusCode.IsGood(status.m_code);
            }

            return true;
        }

        /// <summary>
        /// Returns true if the status is bad or uncertain.
        /// </summary>
        public static bool IsNotGood(ServiceResult status)
        {
            if (status != null)
            {
                return StatusCode.IsNotGood(status.m_code);
            }

            return true;
        }

        /// <summary>
        /// Returns true if the status code is uncertain.
        /// </summary>
        public static bool IsUncertain(ServiceResult status)
        {
            if (status != null)
            {
                return StatusCode.IsUncertain(status.m_code);
            }

            return false;
        }

        /// <summary>
        /// Returns true if the status is good or uncertain.
        /// </summary>
        public static bool IsNotUncertain(ServiceResult status)
        {
            if (status != null)
            {
                return StatusCode.IsNotUncertain(status.m_code);
            }

            return true;
        }

        /// <summary>
        /// Returns true if the status code is bad.
        /// </summary>
        public static bool IsBad(ServiceResult status)
        {
            if (status != null)
            {
                return StatusCode.IsBad(status.m_code);
            }

            return false;
        }

        /// <summary>
        /// Returns true if the status is good or uncertain.
        /// </summary>
        public static bool IsNotBad(ServiceResult status)
        {
            if (status != null)
            {
                return StatusCode.IsNotBad(status.m_code);
            }

            return true;
        }

        /// <summary>
        /// Converts a 32-bit code a ServiceResult object.
        /// </summary>
        public static implicit operator ServiceResult(uint code)
        {
            return new ServiceResult(code);
        }

        /// <summary>
        /// Converts a StatusCode a ServiceResult object.
        /// </summary>
        public static implicit operator ServiceResult(StatusCode code)
        {
            return new ServiceResult(code);
        }

        /// <summary>
        /// Converts a StatusCode object to a 32-bit code.
        /// </summary>
        public static explicit operator uint(ServiceResult status)
        {
            if (status == null)
            {
                return StatusCodes.Good;
            }

            return status.Code;
        }

        /// <summary>
        /// Looks up the symbolic name for a status code.
        /// </summary>
        public static string LookupSymbolicId(uint code)
        {
            return StatusCodes.GetBrowseName(code & 0xFFFF0000);
        }

        /// <summary>
        /// Returns a string containing all nested exceptions.
        /// </summary>
        public static string BuildExceptionTrace(Exception exception)
        {
            StringBuilder buffer = new StringBuilder();

            while (exception != null)
            {
                if (buffer.Length > 0)
                {
                    buffer.AppendLine();
                    buffer.AppendLine();
                }

                buffer.AppendFormat(CultureInfo.InvariantCulture, ">>> {0}", exception.Message);

                if (!String.IsNullOrEmpty(exception.StackTrace))
                {
                    string[] trace = exception.StackTrace.Split(Environment.NewLine.ToCharArray());
                    for (int ii = 0; ii < trace.Length; ii++)
                    {
                        if (trace[ii] != null && trace[ii].Length > 0)
                        {
                            buffer.AppendLine();
                            buffer.AppendFormat(CultureInfo.InvariantCulture, "--- {0}", trace[ii]);
                        }
                    }
                }

                exception = exception.InnerException;
            }

            return buffer.ToString();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The status code associated with the result.
        /// </summary>
        public uint Code
        {
            get { return m_code; }
            private set { m_code = value; }
        }

        /// <summary>
        /// The status code associated with the result.
        /// </summary>
        [DataMember(Order = 1)]
        public StatusCode StatusCode
        {
            get { return m_code; }
            private set { m_code = value.Code; }
        }

        /// <summary>
        /// Additional diagnostic/debugging information associated with the operation.
        /// </summary>
        [DataMember(Order = 2)]
        public string AdditionalInfo
        {
            get { return m_additionalInfo; }
            private set { m_additionalInfo = value; }
        }

        /// <summary>
        /// Nested error information.
        /// </summary>
        [DataMember(Order = 3)]
        public ServiceResult InnerResult
        {
            get { return m_innerResult; }
            private set { m_innerResult = value; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Converts the value to a human readable string.
        /// </summary>
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.Append(LookupSymbolicId(m_code));

            if ((0x0000FFFF & Code) != 0)
            {
                buffer.AppendFormat(" [{0:X4}]", (0x0000FFFF & Code));
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Returns a formatted string with the contents of exception.
        /// </summary>
        public string ToLongString()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.Append("Id: ");
            buffer.Append(StatusCodes.GetBrowseName(m_code));

            if (AdditionalInfo != null && AdditionalInfo.Length > 0)
            {
                buffer.AppendLine();
                buffer.Append(AdditionalInfo);
            }

            ServiceResult innerResult = m_innerResult;

            if (innerResult != null)
            {
                buffer.AppendLine();
                buffer.Append("===");
                buffer.AppendLine();
                buffer.Append(innerResult.ToLongString());
            }

            return buffer.ToString();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Looks up a string in a string table.
        /// </summary>
        private static string LookupString(IList<string> stringTable, int index)
        {
            if (index < 0 || stringTable == null || index >= stringTable.Count)
            {
                return null;
            }

            return stringTable[index];
        }

        /// <summary>
        /// Extract a default message from an exception.
        /// </summary>
        /// <param name="exception"></param>
        private static string GetDefaultMessage(Exception exception)
        {
            if (exception != null && exception.Message != null)
            {
                if (exception.Message.StartsWith("[") || exception is ServiceResultException)
                {
                    return exception.Message;
                }

                return String.Format(CultureInfo.InvariantCulture, "[{0}] {1}", exception.GetType().Name, exception.Message);
            }

            return String.Empty;
        }
        #endregion

        #region Private Fields
        private uint m_code;
        private string m_additionalInfo;
        private ServiceResult m_innerResult;
        #endregion
    }
}

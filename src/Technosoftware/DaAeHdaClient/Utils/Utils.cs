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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Runtime.Serialization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Net;
using System.Collections.ObjectModel;
using System;
#endregion

namespace Technosoftware.DaAeHdaClient
{
    /// <summary>
    /// Defines various static utility functions.
    /// </summary>
    public static class Utils
    {
        #region Public Constants
        /// <summary>
        /// The URI scheme for the HTTP protocol. 
        /// </summary>
        public const string UriSchemeHttp = "http";

        /// <summary>
        /// The URI scheme for the HTTPS protocol. 
        /// </summary>
        public const string UriSchemeHttps = "https";

        /// <summary>
        /// The URI scheme for the UA TCP protocol. 
        /// </summary>
        public const string UriSchemeOpcTcp = "opc.tcp";

        /// <summary>
        /// The URI scheme for the UA TCP protocol over Secure WebSockets. 
        /// </summary>
        public const string UriSchemeOpcWss = "opc.wss";

        /// <summary>
        /// The URI scheme for the UDP protocol. 
        /// </summary>
        public const string UriSchemeOpcUdp = "opc.udp";

        /// <summary>
        /// The URI scheme for the MQTT protocol. 
        /// </summary>
        public const string UriSchemeMqtt = "mqtt";

        /// <summary>
        /// The URI scheme for the MQTTS protocol. 
        /// </summary>
        public const string UriSchemeMqtts = "mqtts";

        /// <summary>
        /// The URI schemes which are supported in the core server. 
        /// </summary>
        public static readonly string[] DefaultUriSchemes = new string[]
        {
            Utils.UriSchemeOpcTcp,
            Utils.UriSchemeHttps
        };

        /// <summary>
        /// The default port for the UA TCP protocol.
        /// </summary>
        public const int UaTcpDefaultPort = 4840;

        /// <summary>
        /// The default port for the UA TCP protocol over WebSockets.
        /// </summary>
        public const int UaWebSocketsDefaultPort = 4843;

        /// <summary>
        /// The default port for the MQTT protocol.
        /// </summary>
        public const int MqttDefaultPort = 1883;

        /// <summary>
        /// The urls of the discovery servers on a node.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2105:ArrayFieldsShouldNotBeReadOnly")]
        public static readonly string[] DiscoveryUrls = new string[]
        {
            "opc.tcp://{0}:4840",
            "https://{0}:4843",
            "http://{0}:52601/UADiscovery",
            "http://{0}/UADiscovery/Default.svc"
        };

        /// <summary>
        /// The default LocalFolder.
        /// </summary>
        public static string DefaultLocalFolder = Directory.GetCurrentDirectory();
        #endregion

        #region Trace Support
#if DEBUG
        private static int s_traceOutput = (int)TraceOutput.DebugAndFile;
        private static int s_traceMasks = (int)TraceMasks.All;
#else
        private static int s_traceOutput = (int)TraceOutput.FileOnly;
        private static int s_traceMasks = (int)TraceMasks.None;
#endif

        private static string s_traceFileName = string.Empty;
        private static long s_BaseLineTicks = DateTime.UtcNow.Ticks;
        private static object s_traceFileLock = new object();

        /// <summary>
        /// The possible trace output mechanisms.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public enum TraceOutput
        {
            /// <summary>
            /// No tracing
            /// </summary>
            Off = 0,

            /// <summary>
            /// Only write to file (if specified). Default for Release mode.
            /// </summary>
            FileOnly = 1,

            /// <summary>
            /// Write to debug trace listeners and a file (if specified). Default for Debug mode.
            /// </summary>
            DebugAndFile = 2
        }

        /// <summary>
        /// The masks used to filter trace messages.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public static class TraceMasks
        {
            /// <summary>
            /// Do not output any messages.
            /// </summary>
            public const int None = 0x0;

            /// <summary>
            /// Output error messages.
            /// </summary>
            public const int Error = 0x1;

            /// <summary>
            /// Output informational messages.
            /// </summary>
            public const int Information = 0x2;

            /// <summary>
            /// Output stack traces.
            /// </summary>
            public const int StackTrace = 0x4;

            /// <summary>
            /// Output basic messages for service calls.
            /// </summary>
            public const int Service = 0x8;

            /// <summary>
            /// Output detailed messages for service calls.
            /// </summary>
            public const int ServiceDetail = 0x10;

            /// <summary>
            /// Output basic messages for each operation.
            /// </summary>
            public const int Operation = 0x20;

            /// <summary>
            /// Output detailed messages for each operation.
            /// </summary>
            public const int OperationDetail = 0x40;

            /// <summary>
            /// Output messages related to application initialization or shutdown
            /// </summary>
            public const int StartStop = 0x80;

            /// <summary>
            /// Output messages related to a call to an external system.
            /// </summary>
            public const int ExternalSystem = 0x100;

            /// <summary>
            /// Output messages related to security
            /// </summary>
            public const int Security = 0x200;

            /// <summary>
            /// Output all messages.
            /// </summary>
            public const int All = 0x7FFFFFFF;
        }

        /// <summary>
        /// Sets the output for tracing (thead safe).
        /// </summary>
        public static void SetTraceOutput(TraceOutput output)
        {
            lock (s_traceFileLock)
            {
                s_traceOutput = (int)output;
            }
        }

        /// <summary>
        /// Gets the current trace mask settings.
        /// </summary>
        public static int TraceMask
        {
            get { return s_traceMasks; }
        }

        /// <summary>
        /// Sets the mask for tracing (thead safe).
        /// </summary>
        public static void SetTraceMask(int masks)
        {
            s_traceMasks = (int)masks;
        }

        /// <summary>
        /// Returns Tracing class instance for event attaching.
        /// </summary>
        public static Tracing Tracing
        {
            get { return Tracing.Instance; }
        }

        /// <summary>
        /// Writes a trace statement.
        /// </summary>
        private static void TraceWriteLine(string message, params object[] args)
        {
            // null strings not supported.
            if (String.IsNullOrEmpty(message))
            {
                return;
            }

            // format the message if format arguments provided.
            string output = message;

            if (args != null && args.Length > 0)
            {
                try
                {
                    output = String.Format(CultureInfo.InvariantCulture, message, args);
                }
                catch (Exception)
                {
                    output = message;
                }
            }

            // write to the log file.
            lock (s_traceFileLock)
            {
                // write to debug trace listeners.
                if (s_traceOutput == (int)TraceOutput.DebugAndFile)
                {
                    System.Diagnostics.Debug.WriteLine(output);
                }

                string traceFileName = s_traceFileName;

                if (s_traceOutput != (int)TraceOutput.Off && !String.IsNullOrEmpty(traceFileName))
                {
                    try
                    {
                        FileInfo file = new FileInfo(traceFileName);

                        // limit the file size
                        bool truncated = false;

                        if (file.Exists && file.Length > 10000000)
                        {
                            file.Delete();
                            truncated = true;
                        }

                        using (StreamWriter writer = new StreamWriter(File.Open(file.FullName, FileMode.Append, FileAccess.Write, FileShare.Read)))
                        {
                            if (truncated)
                            {
                                writer.WriteLine("WARNING - LOG FILE TRUNCATED.");
                            }

                            writer.WriteLine(output);
                            writer.Flush();
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Could not write to trace file. Error={0}", e.Message);
                        Debug.WriteLine("FilePath={1}", traceFileName);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the path to the log file to use for tracing.
        /// </summary>
        public static void SetTraceLog(string filePath, bool deleteExisting)
        {
            // turn tracing on.
            lock (s_traceFileLock)
            {
                // check if tracing is being turned off.
                if (String.IsNullOrEmpty(filePath))
                {
                    s_traceFileName = null;
                    return;
                }

                s_traceFileName = GetAbsoluteFilePath(filePath, true, false, true, true);

                if (s_traceOutput == (int)TraceOutput.Off)
                {
                    s_traceOutput = (int)TraceOutput.FileOnly;
                }

                try
                {
                    FileInfo file = new FileInfo(s_traceFileName);

                    if (deleteExisting && file.Exists)
                    {
                        file.Delete();
                    }

                    // write initial log message.
                    TraceWriteLine(string.Empty);
                    TraceWriteLine(
                        "{1} Logging started at {0}",
                        DateTime.Now,
                        new String('*', 25));
                }
                catch (Exception e)
                {
                    TraceWriteLine(e.Message, null);
                }
            }
        }

        /// <summary>
        /// Writes an informational message to the trace log.
        /// </summary>
        public static void Trace(string format, params object[] args)
        {
            Trace((int)TraceMasks.Information, format, false, args);
        }

        /// <summary>
        /// Writes an informational message to the trace log.
        /// </summary>
        [Conditional("DEBUG")]
        public static void TraceDebug(string format, params object[] args)
        {
            Trace((int)TraceMasks.OperationDetail, format, false, args);
        }

        /// <summary>
        /// Writes an exception/error message to the trace log.
        /// </summary>
        public static void Trace(Exception e, string format, params object[] args)
        {
            Trace(e, format, false, args);
        }

        /// <summary>
        /// Writes an exception/error message to the trace log.
        /// </summary>
        public static void Trace(Exception e, string format, bool handled, params object[] args)
        {
            StringBuilder message = new StringBuilder();

            // format message.            
            if (args != null && args.Length > 0)
            {
                try
                {
                    message.AppendFormat(CultureInfo.InvariantCulture, format, args);
                    message.AppendLine();
                }
                catch (Exception)
                {
                    message.AppendLine(format);
                }
            }
            else
            {
                message.AppendLine(format);
            }

            // append exception information.
            if (e != null)
            {
                ServiceResultException sre = e as ServiceResultException;

                if (sre != null)
                {
                    message.AppendFormat(CultureInfo.InvariantCulture, " {0} '{1}'", StatusCodes.GetBrowseName(sre.StatusCode), sre.Message);
                }
                else
                {
                    message.AppendFormat(CultureInfo.InvariantCulture, " {0} '{1}'", e.GetType().Name, e.Message);
                }
                message.AppendLine();

                // append stack trace.
                if ((s_traceMasks & (int)TraceMasks.StackTrace) != 0)
                {
                    message.AppendLine();
                    message.AppendLine();
                    var separator = new String('=', 40);
                    message.AppendLine(separator);
                    message.AppendLine(new ServiceResult(e).ToLongString());
                    message.AppendLine(separator);
                }
            }

            // trace message.
            Trace(e, (int)TraceMasks.Error, message.ToString(), handled, null);
        }

        /// <summary>
        /// Writes a message to the trace log.
        /// </summary>
        public static void Trace(int traceMask, string format, params object[] args)
        {
            Trace(traceMask, format, false, args);
        }

        /// <summary>
        /// Writes a message to the trace log.
        /// </summary>
        public static void Trace(int traceMask, string format, bool handled, params object[] args)
        {
            Trace(null, traceMask, format, handled, args);
        }

        /// <summary>
        /// Writes a message to the trace log.
        /// </summary>
        public static void Trace(Exception e, int traceMask, string format, bool handled, params object[] args)
        {
            if (!handled)
            {
                Tracing.Instance.RaiseTraceEvent(new TraceEventArgs(traceMask, format, string.Empty, e, args));
            }

            // do nothing if mask not enabled.
            if ((s_traceMasks & traceMask) == 0)
            {
                return;
            }

            StringBuilder message = new StringBuilder();

            // append process and timestamp.
            message.AppendFormat("{0:d} {0:HH:mm:ss.fff} ", DateTime.UtcNow.ToLocalTime());

            // format message.
            if (args != null && args.Length > 0)
            {
                try
                {
                    message.AppendFormat(CultureInfo.InvariantCulture, format, args);
                }
                catch (Exception)
                {
                    message.Append(format);
                }
            }
            else
            {
                message.Append(format);
            }

            TraceWriteLine(message.ToString(), null);
        }
        #endregion

        #region File Access
        /// <summary>
        /// Replaces a prefix enclosed in '%' with a special folder or environment variable path (e.g. %ProgramFiles%\MyCompany).
        /// </summary>
        public static bool IsPathRooted(string path)
        {
            // allow for local file locations
            return Path.IsPathRooted(path) || path[0] == '.';
        }

        /// <summary>
        /// Maps a special folder to environment variable with folder path.
        /// </summary>
        private static string ReplaceSpecialFolderWithEnvVar(string input)
        {
            switch (input)
            {
                case "CommonApplicationData": return "ProgramData";
            }

            return input;
        }

        /// <summary>
        /// Replaces a prefix enclosed in '%' with a special folder or environment variable path (e.g. %ProgramFiles%\MyCompany).
        /// </summary>
        public static string ReplaceSpecialFolderNames(string input)
        {

            // nothing to do for nulls.
            if (String.IsNullOrEmpty(input))
            {
                return null;
            }

            // check for absolute path.
            if (Utils.IsPathRooted(input))
            {
                return input;
            }

            // check for special folder prefix.
            if (input[0] != '%')
            {
                return input;
            }

            // extract special folder name.
            string folder = null;
            string path = null;

            int index = input.IndexOf('%', 1);

            if (index == -1)
            {
                folder = input.Substring(1);
                path = String.Empty;
            }
            else
            {
                folder = input.Substring(1, index - 1);
                path = input.Substring(index + 1);
            }

            StringBuilder buffer = new StringBuilder();
#if !NETSTANDARD1_4 && !NETSTANDARD1_3
            // check for special folder.
            Environment.SpecialFolder specialFolder;
            if (!Enum.TryParse<Environment.SpecialFolder>(folder, out specialFolder))
            {
#endif
                folder = ReplaceSpecialFolderWithEnvVar(folder);
                string value = Environment.GetEnvironmentVariable(folder);
                if (value != null)
                {
                    buffer.Append(value);
                }
                else
                {
                    if (folder == "LocalFolder")
                    {
                        buffer.Append(DefaultLocalFolder);
                    }
                }
#if !NETSTANDARD1_4 && !NETSTANDARD1_3
            }
            else
            {
                buffer.Append(Environment.GetFolderPath(specialFolder));
            }
#endif
            // construct new path.
            buffer.Append(path);
            return buffer.ToString();
        }

        /// <summary>
        /// Finds the file by search the common file folders and then bin directories in the source tree
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The path to the file. Null if not found.</returns>
        public static string FindInstalledFile(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                return null;
            }

            string path = null;

            // check source tree.
            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (directory != null)
            {
                StringBuilder buffer = new StringBuilder();
                buffer.Append(directory.FullName);
                buffer.Append(Path.DirectorySeparatorChar).Append("Bin").Append(Path.DirectorySeparatorChar);
                buffer.Append(fileName);

                path = Utils.GetAbsoluteFilePath(buffer.ToString(), false, false, false);

                if (path != null)
                {
                    break;
                }

                directory = directory.Parent;
            }

            // return what was found.
            return path;
        }

        /// <summary>
        /// Checks if the file path is a relative path and returns an absolute path relative to the EXE location.
        /// </summary>
        public static string GetAbsoluteFilePath(string filePath)
        {
            return GetAbsoluteFilePath(filePath, false, true, false);
        }

        /// <summary>
        /// Checks if the file path is a relative path and returns an absolute path relative to the EXE location.
        /// </summary>
        public static string GetAbsoluteFilePath(string filePath, bool checkCurrentDirectory, bool throwOnError, bool createAlways, bool writable = false)
        {
            filePath = Utils.ReplaceSpecialFolderNames(filePath);

            if (!String.IsNullOrEmpty(filePath))
            {
                FileInfo file = new FileInfo(filePath);

                // check for absolute path.
                bool isAbsolute = Utils.IsPathRooted(filePath);

                if (isAbsolute)
                {
                    if (file.Exists)
                    {
                        return filePath;
                    }

                    if (createAlways)
                    {
                        return CreateFile(file, filePath, throwOnError);
                    }
                }

                if (!isAbsolute)
                {
                    // look current directory.
                    if (checkCurrentDirectory)
                    {
                        // first check in local folder
                        FileInfo localFile = null;
                        if (!writable)
                        {
                            localFile = new FileInfo(Utils.Format("{0}{1}{2}", Directory.GetCurrentDirectory(), Path.DirectorySeparatorChar, filePath));
#if NETFRAMEWORK
                            if (!localFile.Exists)
                            {
                                var localFile2 = new FileInfo(Utils.Format("{0}{1}{2}",
                                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                    Path.DirectorySeparatorChar, filePath));
                                if (localFile2.Exists)
                                {
                                    localFile = localFile2;
                                }
                            }
#endif
                        }
                        else
                        {
                            localFile = new FileInfo(Utils.Format("{0}{1}{2}", Path.GetTempPath(), Path.DirectorySeparatorChar, filePath));
                        }

                        if (localFile.Exists)
                        {
                            return localFile.FullName;
                        }

                        if (file.Exists && !writable)
                        {
                            return file.FullName;
                        }

                        if (createAlways && writable)
                        {
                            return CreateFile(localFile, localFile.FullName, throwOnError);
                        }
                    }
                }
            }

            // file does not exist.
            if (throwOnError)
            {
                var message = new StringBuilder();
                message.AppendLine("File does not exist: {0}");
                message.AppendLine("Current directory is: {1}");
                throw ServiceResultException.Create(
                    StatusCodes.BadConfigurationError,
                    message.ToString(),
                    filePath,
                    Directory.GetCurrentDirectory());
            }

            return null;
        }

        /// <summary>
        /// Creates an empty file.
        /// </summary>
        private static string CreateFile(FileInfo file, string filePath, bool throwOnError)
        {
            try
            {
                // create the directory as required.
                if (!file.Directory.Exists)
                {
                    Directory.CreateDirectory(file.DirectoryName);
                }

                // open and close the file.
                using (Stream ostrm = file.Open(FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    return filePath;
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Could not create file: {0}", filePath);

                if (throwOnError)
                {
                    throw;
                }

                return filePath;
            }
        }

        /// <summary>
        /// Checks if the file path is a relative path and returns an absolute path relative to the EXE location.
        /// </summary>
        public static string GetAbsoluteDirectoryPath(string dirPath, bool checkCurrentDirectory, bool throwOnError)
        {
            return GetAbsoluteDirectoryPath(dirPath, checkCurrentDirectory, throwOnError, false);
        }

        /// <summary>
        /// Checks if the file path is a relative path and returns an absolute path relative to the EXE location.
        /// </summary>
        public static string GetAbsoluteDirectoryPath(string dirPath, bool checkCurrentDirectory, bool throwOnError, bool createAlways)
        {
            string originalPath = dirPath;
            dirPath = Utils.ReplaceSpecialFolderNames(dirPath);

            if (!String.IsNullOrEmpty(dirPath))
            {
                DirectoryInfo directory = new DirectoryInfo(dirPath);

                // check for absolute path.
                bool isAbsolute = Utils.IsPathRooted(dirPath);

                if (isAbsolute)
                {
                    if (directory.Exists)
                    {
                        return dirPath;
                    }

                    if (createAlways && !directory.Exists)
                    {
                        directory = Directory.CreateDirectory(dirPath);
                        return directory.FullName;
                    }
                }

                if (!isAbsolute)
                {
                    // look current directory.
                    if (checkCurrentDirectory)
                    {
                        if (!directory.Exists)
                        {
                            directory = new DirectoryInfo(Utils.Format("{0}{1}{2}", Directory.GetCurrentDirectory(), Path.DirectorySeparatorChar, dirPath));
#if NETFRAMEWORK
                            if (!directory.Exists)
                            {
                                var directory2 = new DirectoryInfo(Utils.Format("{0}{1}{2}",
                                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                    Path.DirectorySeparatorChar, dirPath));
                                if (directory2.Exists)
                                {
                                    directory = directory2;
                                }
                            }
#endif
                        }
                    }

                    // return full path.      
                    if (directory.Exists)
                    {
                        return directory.FullName;
                    }

                    // create the directory.
                    if (createAlways)
                    {
                        directory = Directory.CreateDirectory(directory.FullName);
                        return directory.FullName;
                    }
                }
            }

            // file does not exist.
            if (throwOnError)
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadConfigurationError,
                    "Directory does not exist: {0}\r\nCurrent directory is: {1}",
                    originalPath,
                    Directory.GetCurrentDirectory());
            }

            return null;
        }

        /// <summary>
        /// Truncates a file path so it can be displayed in a limited width view.
        /// </summary>
        public static string GetFilePathDisplayName(string filePath, int maxLength)
        {
            // check if nothing to do.
            if (filePath == null || maxLength <= 0 || filePath.Length < maxLength)
            {
                return filePath;
            }

            // keep first path segment.
            int start = filePath.IndexOf(Path.DirectorySeparatorChar);

            if (start == -1)
            {
                return Utils.Format("{0}...", filePath.Substring(0, maxLength));
            }

            // keep file name.
            int end = filePath.LastIndexOf(Path.DirectorySeparatorChar);

            while (end > start && filePath.Length - end < maxLength)
            {
                end = filePath.LastIndexOf(Path.DirectorySeparatorChar, end - 1);

                if (filePath.Length - end > maxLength)
                {
                    end = filePath.IndexOf(Path.DirectorySeparatorChar, end + 1);
                    break;
                }
            }

            // format the result.
            return Utils.Format("{0}...{1}", filePath.Substring(0, start + 1), filePath.Substring(end));
        }
        #endregion

        #region String, Object and Data Convienence Functions
        /// <summary>
        /// Supresses any exceptions while disposing the object.
        /// </summary>
        /// <remarks>
        /// Writes errors to trace output in DEBUG builds.
        /// </remarks>
        public static void SilentDispose(object objectToDispose)
        {
            IDisposable disposable = objectToDispose as IDisposable;
            SilentDispose(disposable);
        }

        /// <summary>
        /// Supresses any exceptions while disposing the object.
        /// </summary>
        /// <remarks>
        /// Writes errors to trace output in DEBUG builds.
        /// </remarks>
        public static void SilentDispose(IDisposable disposable)
        {
            try
            {
                disposable?.Dispose();
            }
#if DEBUG
            catch (Exception e)
            {
                Utils.Trace(e, "Error disposing object: {0}", disposable.GetType().Name);
            }
#else
            catch (Exception) {;}
#endif
        }

        /// <summary>
        /// The earliest time that can be represented on with UA date/time values.
        /// </summary>
        public static DateTime TimeBase
        {
            get { return s_TimeBase; }
        }

        private static readonly DateTime s_TimeBase = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Normalize a DateTime to Opc Ua UniversalTime.
        /// </summary>
        public static DateTime ToOpcUaUniversalTime(DateTime value)
        {
            if (value <= DateTime.MinValue)
            {
                return DateTime.MinValue;
            }
            if (value >= DateTime.MaxValue)
            {
                return DateTime.MaxValue;
            }
            if (value.Kind != DateTimeKind.Utc)
            {
                return value.ToUniversalTime();
            }
            return value;
        }

        /// <summary>
        /// Returns an absolute deadline for a timeout.
        /// </summary>
        public static DateTime GetDeadline(TimeSpan timeSpan)
        {
            DateTime now = DateTime.UtcNow;

            if (DateTime.MaxValue.Ticks - now.Ticks < timeSpan.Ticks)
            {
                return DateTime.MaxValue;
            }

            return now + timeSpan;
        }

        /// <summary>
        /// Returns a timeout as integer number of milliseconds
        /// </summary>
        public static int GetTimeout(TimeSpan timeSpan)
        {
            if (timeSpan.TotalMilliseconds > Int32.MaxValue)
            {
                return -1;
            }

            if (timeSpan.TotalMilliseconds < 0)
            {
                return 0;
            }

            return (int)timeSpan.TotalMilliseconds;
        }

        /// <inheritdoc cref="Dns.GetHostAddressesAsync(string)"/>
        public static Task<IPAddress[]> GetHostAddressesAsync(string hostNameOrAddress)
        {
            return Dns.GetHostAddressesAsync(hostNameOrAddress);
        }

        /// <inheritdoc cref="Dns.GetHostAddresses(string)"/>
        public static IPAddress[] GetHostAddresses(string hostNameOrAddress)
        {
            return Dns.GetHostAddresses(hostNameOrAddress);
        }

        /// <inheritdoc cref="Dns.GetHostName"/>
        /// <remarks>If the platform returns a FQDN, only the host name is returned.</remarks>
        public static string GetHostName()
        {
            return Dns.GetHostName().Split('.')[0].ToLowerInvariant();
        }

        /// <summary>
        /// Get the FQDN of the local computer.
        /// </summary>
        public static string GetFullQualifiedDomainName()
        {
            string domainName = null;
            try
            {
                domainName = Dns.GetHostEntry("localhost").HostName;
            }
            catch
            {
            }
            if (String.IsNullOrEmpty(domainName))
            {
                return Dns.GetHostName();
            }
            return domainName;
        }

        /// <summary>
        /// Normalize ipv4/ipv6 address for comparisons.
        /// </summary>
        public static string NormalizedIPAddress(string ipAddress)
        {
            try
            {
                IPAddress normalizedAddress = IPAddress.Parse(ipAddress);
                return normalizedAddress.ToString();
            }
            catch
            {
                return ipAddress;
            }
        }


        /// <summary>
        /// Replaces the localhost domain with the current host name.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "RCS1197:Optimize StringBuilder.Append/AppendLine call.")]
        public static string ReplaceLocalhost(string uri, string hostname = null)
        {
            // ignore nulls.
            if (String.IsNullOrEmpty(uri))
            {
                return uri;
            }

            // IPv6 address needs a surrounding [] 
            if (!String.IsNullOrEmpty(hostname) && hostname.Contains(':'))
            {
                hostname = "[" + hostname + "]";
            }

            // check if the string localhost is specified.
            var localhost = "localhost";
            int index = uri.IndexOf(localhost, StringComparison.OrdinalIgnoreCase);

            if (index == -1)
            {
                return uri;
            }

            // construct new uri.
            var buffer = new StringBuilder();
#if NET5_0_OR_GREATER || NETSTANDARD2_1
            buffer.Append(uri.AsSpan(0, index))
                .Append(hostname ?? GetHostName())
                .Append(uri.AsSpan(index + localhost.Length));
#else
            buffer.Append(uri.Substring(0, index))
                .Append(hostname ?? GetHostName())
                .Append(uri.Substring(index + localhost.Length));
#endif
            return buffer.ToString();
        }

        /// <summary>
        /// Replaces the cert subject name DC=localhost with the current host name.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "RCS1197:Optimize StringBuilder.Append/AppendLine call.")]
        public static string ReplaceDCLocalhost(string subjectName, string hostname = null)
        {
            // ignore nulls.
            if (String.IsNullOrEmpty(subjectName))
            {
                return subjectName;
            }

            // IPv6 address needs a surrounding [] 
            if (!String.IsNullOrEmpty(hostname) && hostname.Contains(':'))
            {
                hostname = "[" + hostname + "]";
            }

            // check if the string DC=localhost is specified.
            var dclocalhost = "DC=localhost";
            int index = subjectName.IndexOf(dclocalhost, StringComparison.OrdinalIgnoreCase);

            if (index == -1)
            {
                return subjectName;
            }

            // construct new uri.
            var buffer = new StringBuilder();
#if NET5_0_OR_GREATER || NETSTANDARD2_1
            buffer.Append(subjectName.AsSpan(0, index + 3))
                .Append(hostname == null ? GetHostName() : hostname)
                .Append(subjectName.AsSpan(index + dclocalhost.Length));
#else
            buffer.Append(subjectName.Substring(0, index + 3))
                .Append(hostname == null ? GetHostName() : hostname)
                .Append(subjectName.Substring(index + dclocalhost.Length));
#endif
            return buffer.ToString();
        }

        /// <summary>
        /// Parses a URI string. Returns null if it is invalid.
        /// </summary>
        public static Uri ParseUri(string uri)
        {
            try
            {
                if (String.IsNullOrEmpty(uri))
                {
                    return null;
                }

                return new Uri(uri);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Parses the URLs, returns true of they have the same domain.
        /// </summary>
        /// <param name="url1">The first URL to compare.</param>
        /// <param name="url2">The second URL to compare.</param>
        /// <returns>True if they have the same domain.</returns>
        public static bool AreDomainsEqual(Uri url1, Uri url2)
        {
            if (url1 == null || url2 == null)
            {
                return false;
            }

            try
            {
                string domain1 = url1.DnsSafeHost;
                string domain2 = url2.DnsSafeHost;

                // replace localhost with the computer name.
                if (domain1 == "localhost")
                {
                    domain1 = GetHostName();
                }

                if (domain2 == "localhost")
                {
                    domain2 = GetHostName();
                }

                if (AreDomainsEqual(domain1, domain2))
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the domains are equal.
        /// </summary>
        /// <param name="domain1">The first domain to compare.</param>
        /// <param name="domain2">The second domain to compare.</param>
        /// <returns>True if they are equal.</returns>
        public static bool AreDomainsEqual(string domain1, string domain2)
        {
            if (String.IsNullOrEmpty(domain1) || String.IsNullOrEmpty(domain2))
            {
                return false;
            }

            if (String.Equals(domain1, domain2, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Substitutes the local machine name if "localhost" is specified in the instance uri.
        /// </summary>
        public static string UpdateInstanceUri(string instanceUri)
        {
            // check for null.
            if (String.IsNullOrEmpty(instanceUri))
            {
                UriBuilder builder = new UriBuilder();

                builder.Scheme = Utils.UriSchemeHttps;
                builder.Host = GetHostName();
                builder.Port = -1;
                builder.Path = Guid.NewGuid().ToString();

                return builder.Uri.ToString();
            }

            // prefix non-urls with the hostname.
            if (!instanceUri.StartsWith(Utils.UriSchemeHttps, StringComparison.Ordinal))
            {
                UriBuilder builder = new UriBuilder();

                builder.Scheme = Utils.UriSchemeHttps;
                builder.Host = GetHostName();
                builder.Port = -1;
                builder.Path = Uri.EscapeDataString(instanceUri);

                return builder.Uri.ToString();
            }

            // replace localhost with the current hostname.
            Uri parsedUri = Utils.ParseUri(instanceUri);

            if (parsedUri != null && parsedUri.DnsSafeHost == "localhost")
            {
                UriBuilder builder = new UriBuilder(parsedUri);
                builder.Host = GetHostName();
                return builder.Uri.ToString();
            }

            // return the original instance uri.
            return instanceUri;
        }

        /// <summary>
        /// Increments a identifier (wraps around if max exceeded).
        /// </summary>
        public static uint IncrementIdentifier(ref long identifier)
        {
            System.Threading.Interlocked.CompareExchange(ref identifier, 0, UInt32.MaxValue);
            return (uint)System.Threading.Interlocked.Increment(ref identifier);
        }

        /// <summary>
        /// Increments a identifier (wraps around if max exceeded).
        /// </summary>
        public static int IncrementIdentifier(ref int identifier)
        {
            System.Threading.Interlocked.CompareExchange(ref identifier, 0, Int32.MaxValue);
            return System.Threading.Interlocked.Increment(ref identifier);
        }

        /// <summary>
        /// Safely converts an UInt32 identifier to a Int32 identifier.
        /// </summary>
        public static int ToInt32(uint identifier)
        {
            if (identifier <= (uint)Int32.MaxValue)
            {
                return (int)identifier;
            }

            return -(int)((long)UInt32.MaxValue - (long)identifier + 1);
        }

        /// <summary>
        /// Safely converts an Int32 identifier to a UInt32 identifier.
        /// </summary>
        public static uint ToUInt32(int identifier)
        {
            if (identifier >= 0)
            {
                return (uint)identifier;
            }

            return (uint)((long)UInt32.MaxValue + 1 + (long)identifier);
        }

        /// <summary>
        /// Converts a multidimension array to a flat array. 
        /// </summary>
        /// <remarks>
        /// The higher rank dimensions are written first.
        /// e.g. a array with dimensions [2,2,2] is written in this order: 
        /// [0,0,0], [0,0,1], [0,1,0], [0,1,1], [1,0,0], [1,0,1], [1,1,0], [1,1,1]
        /// </remarks>
        public static Array FlattenArray(Array array)
        {
            Array flatArray = Array.CreateInstance(array.GetType().GetElementType(), array.Length);

            int[] indexes = new int[array.Rank];
            int[] dimensions = new int[array.Rank];

            for (int jj = array.Rank - 1; jj >= 0; jj--)
            {
                dimensions[jj] = array.GetLength(array.Rank - jj - 1);
            }

            for (int ii = 0; ii < array.Length; ii++)
            {
                indexes[array.Rank - 1] = ii % dimensions[0];

                for (int jj = 1; jj < array.Rank; jj++)
                {
                    int multiplier = 1;

                    for (int kk = 0; kk < jj; kk++)
                    {
                        multiplier *= dimensions[kk];
                    }

                    indexes[array.Rank - jj - 1] = (ii / multiplier) % dimensions[jj];
                }

                flatArray.SetValue(array.GetValue(indexes), ii);
            }

            return flatArray;
        }

        /// <summary>
        /// Converts a buffer to a hexadecimal string.
        /// </summary>
        public static string ToHexString(byte[] buffer, bool invertEndian = false)
        {
            if (buffer == null || buffer.Length == 0)
            {
                return String.Empty;
            }

            StringBuilder builder = new StringBuilder(buffer.Length * 2);

            if (invertEndian)
            {
                for (int ii = buffer.Length - 1; ii >= 0; ii--)
                {
                    builder.AppendFormat("{0:X2}", buffer[ii]);
                }
            }
            else
            {
                for (int ii = 0; ii < buffer.Length; ii++)
                {
                    builder.AppendFormat("{0:X2}", buffer[ii]);
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Converts a hexadecimal string to an array of bytes.
        /// </summary>
        public static byte[] FromHexString(string buffer)
        {
            if (buffer == null)
            {
                return null;
            }

            if (buffer.Length == 0)
            {
                return Array.Empty<byte>();
            }

            string text = buffer.ToUpperInvariant();
            const string digits = "0123456789ABCDEF";

            byte[] bytes = new byte[(buffer.Length / 2) + (buffer.Length % 2)];

            int ii = 0;

            while (ii < bytes.Length * 2)
            {
                int index = digits.IndexOf(buffer[ii]);

                if (index == -1)
                {
                    break;
                }

                byte b = (byte)index;
                b <<= 4;

                if (ii < buffer.Length - 1)
                {
                    index = digits.IndexOf(buffer[ii + 1]);

                    if (index == -1)
                    {
                        break;
                    }

                    b += (byte)index;
                }

                bytes[ii / 2] = b;
                ii += 2;
            }

            return bytes;
        }

        /// <summary>
        /// Formats an object using the invariant locale.
        /// </summary>
        public static string ToString(object source)
        {
            if (source != null)
            {
                return String.Format(CultureInfo.InvariantCulture, "{0}", source);
            }

            return String.Empty;
        }

        /// <summary>
        /// Formats a message using the invariant locale.
        /// </summary>
        public static string Format(string text, params object[] args)
        {
            return String.Format(CultureInfo.InvariantCulture, text, args);
        }
        #endregion

        #region Reflection Helper Functions
        /// <summary>
        /// Returns the public static field names for a class.
        /// </summary>
        public static string[] GetFieldNames(Type systemType)
        {
            FieldInfo[] fields = systemType.GetFields(BindingFlags.Public | BindingFlags.Static);

            int ii = 0;

            string[] names = new string[fields.Length];

            foreach (FieldInfo field in fields)
            {
                names[ii++] = field.Name;
            }

            return names;
        }

        /// <summary>
        /// Returns the data member name for a property.
        /// </summary>
        public static string GetDataMemberName(PropertyInfo property)
        {
            object[] attributes = property.GetCustomAttributes(typeof(DataMemberAttribute), true).ToArray();

            if (attributes != null)
            {
                for (int ii = 0; ii < attributes.Length; ii++)
                {
                    DataMemberAttribute contract = attributes[ii] as DataMemberAttribute;

                    if (contract != null)
                    {
                        if (String.IsNullOrEmpty(contract.Name))
                        {
                            return property.Name;
                        }

                        return contract.Name;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns the numeric constant associated with a name.
        /// </summary>
        public static uint GetIdentifier(string name, Type constants)
        {
            FieldInfo[] fields = constants.GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {
                if (field.Name == name)
                {
                    return (uint)field.GetValue(constants);
                }
            }

            return 0;
        }

        /// <summary>
        /// Returns the linker timestamp for an assembly. 
        /// </summary>
        public static DateTime GetAssemblyTimestamp()
        {
            try
            {
#if !NETSTANDARD1_4 && !NETSTANDARD1_3
                return File.GetLastWriteTimeUtc(typeof(Utils).GetTypeInfo().Assembly.Location);
#endif
            }
            catch
            { }
            return new DateTime(1970, 1, 1, 0, 0, 0);
        }

        /// <summary>
        /// Returns the major/minor version number for an assembly formatted as a string.
        /// </summary>
        public static string GetAssemblySoftwareVersion()
        {
            return typeof(Utils).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }

        /// <summary>
        /// Returns the build/revision number for an assembly formatted as a string.
        /// </summary>
        public static string GetAssemblyBuildNumber()
        {
            return typeof(Utils).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
        }

        #endregion

        #region Security Helper Functions
        /// <summary>
        /// Returns a XmlReaderSetting with safe defaults.
        /// DtdProcessing Prohibited, XmlResolver disabled and
        /// ConformanceLevel Document. 
        /// </summary>
        internal static XmlReaderSettings DefaultXmlReaderSettings()
        {
            return new XmlReaderSettings() {
                DtdProcessing = DtdProcessing.Prohibit,
                XmlResolver = null,
                ConformanceLevel = ConformanceLevel.Document
            };
        }

        /// <summary>
        /// Safe version for assignment of InnerXml.
        /// </summary>
        /// <param name="doc">The XmlDocument.</param>
        /// <param name="xml">The Xml document string.</param>
        internal static void LoadInnerXml(this XmlDocument doc, string xml)
        {
            using (var sreader = new StringReader(xml))
            using (var reader = XmlReader.Create(sreader, DefaultXmlReaderSettings()))
            {
                doc.XmlResolver = null;
                doc.Load(reader);
            }
        }

        /// <summary>
        /// Appends a list of byte arrays.
        /// </summary>
        public static byte[] Append(params byte[][] arrays)
        {
            if (arrays == null)
            {
                return Array.Empty<byte>();
            }

            int length = 0;

            for (int ii = 0; ii < arrays.Length; ii++)
            {
                if (arrays[ii] != null)
                {
                    length += arrays[ii].Length;
                }
            }

            byte[] output = new byte[length];

            int pos = 0;

            for (int ii = 0; ii < arrays.Length; ii++)
            {
                if (arrays[ii] != null)
                {
                    Array.Copy(arrays[ii], 0, output, pos, arrays[ii].Length);
                    pos += arrays[ii].Length;
                }
            }

            return output;
        }

        /// <summary>
        /// Compare Nonce for equality.
        /// </summary>
        public static bool CompareNonce(byte[] a, byte[] b)
        {
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;

            byte result = 0;
            for (int i = 0; i < a.Length; i++)
                result |= (byte)(a[i] ^ b[i]);

            return result == 0;
        }

        /// <summary>
        /// Generates a Pseudo random sequence of bits using the P_SHA1 alhorithm.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Security", "CA5350:Do Not Use Weak Cryptographic Algorithms",
            Justification = "SHA1 is needed for deprecated security profiles.")]
        public static byte[] PSHA1(byte[] secret, string label, byte[] data, int offset, int length)
        {
            if (secret == null) throw new ArgumentNullException(nameof(secret));
            // create the hmac.
            HMACSHA1 hmac = new HMACSHA1(secret);
            return PSHA(hmac, label, data, offset, length);
        }

        /// <summary>
        /// Generates a Pseudo random sequence of bits using the P_SHA256 alhorithm.
        /// </summary>
        public static byte[] PSHA256(byte[] secret, string label, byte[] data, int offset, int length)
        {
            if (secret == null) throw new ArgumentNullException(nameof(secret));
            // create the hmac.
            HMACSHA256 hmac = new HMACSHA256(secret);
            return PSHA(hmac, label, data, offset, length);
        }

        /// <summary>
        /// Generates a Pseudo random sequence of bits using the HMAC algorithm.
        /// </summary>
        private static byte[] PSHA(HMAC hmac, string label, byte[] data, int offset, int length)
        {
            if (hmac == null) throw new ArgumentNullException(nameof(hmac));
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));

            byte[] seed = null;

            // convert label to UTF-8 byte sequence.
            if (!String.IsNullOrEmpty(label))
            {
                seed = new UTF8Encoding().GetBytes(label);
            }

            // append data to label.
            if (data != null && data.Length > 0)
            {
                if (seed != null)
                {
                    byte[] seed2 = new byte[seed.Length + data.Length];
                    seed.CopyTo(seed2, 0);
                    data.CopyTo(seed2, seed.Length);
                    seed = seed2;
                }
                else
                {
                    seed = data;
                }
            }

            // check for a valid seed.
            if (seed == null)
            {
                throw new ServiceResultException(StatusCodes.BadUnexpectedError, "The HMAC algorithm requires a non-null seed.");
            }

            byte[] keySeed = hmac.ComputeHash(seed);
            byte[] prfSeed = new byte[hmac.HashSize / 8 + seed.Length];
            Array.Copy(keySeed, prfSeed, keySeed.Length);
            Array.Copy(seed, 0, prfSeed, keySeed.Length, seed.Length);

            // create buffer with requested size.
            byte[] output = new byte[length];

            int position = 0;

            do
            {
                byte[] hash = hmac.ComputeHash(prfSeed);

                if (offset < hash.Length)
                {
                    for (int ii = offset; position < length && ii < hash.Length; ii++)
                    {
                        output[position++] = hash[ii];
                    }
                }

                if (offset > hash.Length)
                {
                    offset -= hash.Length;
                }
                else
                {
                    offset = 0;
                }

                keySeed = hmac.ComputeHash(keySeed);
                Array.Copy(keySeed, prfSeed, keySeed.Length);
            }
            while (position < length);

            // return random data.
            return output;
        }

        /// <summary>
        /// Checks if the target is in the list. Comparisons ignore case.
        /// </summary>
        public static bool FindStringIgnoreCase(IList<string> strings, string target)
        {
            if (strings == null || strings.Count == 0)
            {
                return false;
            }

            for (int ii = 0; ii < strings.Count; ii++)
            {
                if (String.Equals(strings[ii], target, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Lazy helper to allow runtime check for Mono.
        /// </summary>
        private static readonly Lazy<bool> IsRunningOnMonoValue = new Lazy<bool>(() => {
            return Type.GetType("Mono.Runtime") != null;
        });

        /// <summary>
        /// Determine if assembly uses mono runtime.
        /// </summary>
        /// <returns>true if running on Mono runtime</returns>
        public static bool IsRunningOnMono()
        {
            return IsRunningOnMonoValue.Value;
        }
        #endregion
    }

    /// <summary>
    /// Used as underlying tracing object for event processing.
    /// </summary>
    public class Tracing
    {
        #region Private Members
        private static object m_syncRoot = new Object();
        private static Tracing s_instance;
        #endregion Private Members

        #region Singleton Instance
        /// <summary>
        /// Private constructor.
        /// </summary>
        private Tracing()
        { }

        /// <summary>
        /// Public Singleton Instance getter.
        /// </summary>
        public static Tracing Instance
        {
            get
            {
                if (s_instance == null)
                {
                    lock (m_syncRoot)
                    {
                        if (s_instance == null)
                        {
                            s_instance = new Tracing();
                        }
                    }
                }
                return s_instance;
            }
        }
        #endregion Singleton Instance

        #region Public Events
        /// <summary>
        /// Occurs when a trace call is made.
        /// </summary>
        public event EventHandler<TraceEventArgs> TraceEventHandler;
        #endregion Public Events

        #region Internal Members
        internal void RaiseTraceEvent(TraceEventArgs eventArgs)
        {
            if (TraceEventHandler != null)
            {
                try
                {
                    TraceEventHandler(this, eventArgs);
                }
                catch (Exception ex)
                {
                    Utils.Trace(ex, "Exception invoking Trace Event Handler", true, null);
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// The event arguments provided when a trace event is raised.
    /// </summary>
    public class TraceEventArgs : EventArgs
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the TraceEventArgs class.
        /// </summary>
        /// <param name="traceMask">The trace mask.</param>
        /// <param name="format">The format.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        internal TraceEventArgs(int traceMask, string format, string message, Exception exception, object[] args)
        {
            TraceMask = traceMask;
            Format = format;
            Message = message;
            Exception = exception;
            Arguments = args;
        }
        #endregion Constructors

        #region Public Properties
        /// <summary>
        /// Gets the trace mask.
        /// </summary>
        public int TraceMask { get; private set; }

        /// <summary>
        /// Gets the format.
        /// </summary>
        public string Format { get; private set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        public object[] Arguments { get; private set; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        public Exception Exception { get; private set; }
        #endregion Public Properties
    }
}

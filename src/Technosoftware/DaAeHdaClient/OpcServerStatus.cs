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
#endregion

namespace Technosoftware.DaAeHdaClient
{
	/// <summary>
	/// Contains properties that describe the current status of an OPC server.
	/// </summary>
	[Serializable]
	public class OpcServerStatus : ICloneable
	{
		///////////////////////////////////////////////////////////////////////
		#region Fields

        private OpcServerState _serverState = OpcServerState.Unknown;
		private DateTime _startTime = DateTime.MinValue;
		private DateTime _currentTime = DateTime.MinValue;
		private DateTime _lastUpdateTime = DateTime.MinValue;
		private Int32 _bandWidth = -1;
		private Int16 _majorVersion = 0;
		private Int16 _minorVersion = 0;
		private Int16 _buildNumber = 0;

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Properties
		
		/// <summary>
		/// The vendor name and product name for the server.
		/// </summary>
		public string VendorInfo { get; set; }

		/// <summary>
		/// A string that contains the server software version number.
		/// </summary>
		public string ProductVersion { get; set; }

        /// <summary>
        /// The server for which the status is being reported.
        /// The ServerType enumeration is used to identify 
        /// the server. If the enumeration indicates multiple 
        /// server types, then this is the status of the entire 
        /// server. For example, if the server wraps an 
        /// OPC DA and OPC AE server, then if this ServerType 
        /// indicates both, the status is for the entire server, and 
        /// not for an individual wrapped server.
        /// </summary>
         public uint ServerType { get; set; }

		/// <summary>
		/// The current state of the server.
		/// </summary>
		public OpcServerState ServerState
		{
			get { return _serverState; }
			set { _serverState = value; }
		}

		/// <summary>
		/// A string that describes the current server state.
		/// </summary>
		public string StatusInfo { get; set; }

		/// <summary>
		/// The time when the server started.
		/// The <see cref="LicenseHandler.TimeAsUtc">LicenseHandler.TimeAsUtc</see> property defines
		/// the time format (UTC or local   time).
		/// </summary>
		public DateTime StartTime
		{
			get { return _startTime; }
			set { _startTime = value; }
		}

		/// <summary>
		/// Th current time at the server.
		/// The <see cref="LicenseHandler.TimeAsUtc">LicenseHandler.TimeAsUtc</see> property defines
		/// the time format (UTC or local   time).
		/// </summary>
		public DateTime CurrentTime
		{
			get { return _currentTime; }
			set { _currentTime = value; }
		}

		/// <summary>
		/// The maximum number of values that can be returned by the server on a per item basis. 
		/// </summary>
		public int MaxReturnValues { get; set; }

		/// <summary>
		/// The last time the server sent an data update to the client.
		/// The <see cref="LicenseHandler.TimeAsUtc">LicenseHandler.TimeAsUtc</see> property defines
		/// the time format (UTC or local   time).
		/// </summary>
		public DateTime LastUpdateTime
		{
			get { return _lastUpdateTime; }
			set { _lastUpdateTime = value; }
		}

		/// <summary>
		/// Total   number of groups being managed by the server.
		/// </summary>
		public Int32 GroupCount { get; set; }

		/// <summary>
		/// The behavior of of this value   is server specific.
		/// </summary>
		public Int32 BandWidth
		{
			get { return _bandWidth; }
			set { _bandWidth = value; }
		}

		/// <summary>
		/// The major   version of the used server issue.
		/// </summary>
		public Int16 MajorVersion
		{
			get { return _majorVersion; }
			set { _majorVersion = value; }
		}

		/// <summary>
		/// The minor   version of the used server issue.
		/// </summary>
		public Int16 MinorVersion
		{
			get { return _minorVersion; }
			set { _minorVersion = value; }
		}

		/// <summary>
		/// The build   number of the used server issue.
		/// </summary>
		public Int16 BuildNumber
		{
			get { return _buildNumber; }
			set { _buildNumber = value; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region ICloneable Members

		/// <summary>
		/// Creates a deepcopy of the object.
		/// </summary>
		public virtual object Clone()
		{
			return MemberwiseClone();
		}

		#endregion
	}
}

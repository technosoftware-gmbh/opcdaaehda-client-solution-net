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

namespace Technosoftware.DaAeHdaClient.Hda
{
	/// <summary>
	/// A value of an item at in instant of time that has be deleted or replaced.
	/// </summary>
	[Serializable]
	public class TsCHdaModifiedValue : TsCHdaItemValue
	{
		///////////////////////////////////////////////////////////////////////
		#region Fields

		private DateTime _modificationTime = DateTime.MinValue;
		private TsCHdaEditType _editType = TsCHdaEditType.Insert;

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Properties

		/// <summary>
		/// The time when the value was deleted or replaced.
		/// The <see cref="LicenseHandler.TimeAsUTC">OpcBase.TimeAsUTC</see> property defines
		/// the time format (UTC or local time).
		/// </summary>
		public DateTime ModificationTime
		{
			get { return _modificationTime; }
			set { _modificationTime = value; }
		}

		/// <summary>
		/// Whether the value was deleted or replaced.
		/// </summary>
		public TsCHdaEditType EditType
		{
			get { return _editType; }
			set { _editType = value; }
		}

		/// <summary>
		/// The user who modified the item value.
		/// </summary>
		public string User { get; set; }

		#endregion
	}
}

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
    /// A value of an item at in instant of time.
    /// </summary>
    [Serializable]
    public class TsCHdaItemValue : ICloneable
    {
        ///////////////////////////////////////////////////////////////////////
        #region Fields

        private DateTime _timestamp = DateTime.MinValue;
        private Da.TsCDaQuality _quality = Da.TsCDaQuality.Bad;
        private Hda.TsCHdaQuality _historianQuality = Hda.TsCHdaQuality.NoData;

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region Properties

        /// <summary>
        /// The value of the item.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// The timestamp associated with the value.
        /// The <see cref="LicenseHandler.TimeAsUTC">OpcBase.TimeAsUTC</see> property defines
        /// the time format (UTC or local time).
        /// </summary>
        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

        /// <summary>
		/// The quality associated with the value when it was acquired from the data source.
		/// </summary>
		public Da.TsCDaQuality Quality
		{
			get { return _quality; }
			set { _quality = value; }
		}

        /// <summary>
        /// The quality associated with the value when it was retrieved from the hiatorian database.
        /// </summary>
        public Hda.TsCHdaQuality HistorianQuality
        {
            get { return _historianQuality; }
            set { _historianQuality = value; }
        }

        /// <summary>
        /// VARTYPE of the item
        /// </summary>
        public System.Runtime.InteropServices.VarEnum VarType
        {
            get { return Technosoftware.DaAeHdaClient.Utilities.Interop.GetType(Value.GetType()); }
            set { }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region ICloneable Members

        /// <summary>
        /// Creates a deep copy of the object.
        /// </summary>
        public object Clone()
        {
            TsCHdaItemValue value = (TsCHdaItemValue)MemberwiseClone();
            value.Value = Technosoftware.DaAeHdaClient.OpcConvert.Clone(Value);
            return value;
        }

        #endregion
    }
}

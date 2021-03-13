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

namespace Technosoftware.DaAeHdaClient.Ae
{
    /// <summary>
    /// Stores the state of a browse operation.
    /// </summary>
    [Serializable]
	public class TsCAeBrowsePosition : IOpcBrowsePosition
	{
		///////////////////////////////////////////////////////////////////////
		#region Fields

  		private bool _disposed;
		private string _areaID;
		private TsCAeBrowseType _browseType = TsCAeBrowseType.Area;
		private string _browseFilter;

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Constructors, Destructor, Initialization

		/// <summary>
		/// Saves the parameters for an incomplete browse information.
		/// </summary>
		public TsCAeBrowsePosition(
			string areaID,
			TsCAeBrowseType browseType,
			string browseFilter)
		{
			_areaID = areaID;
			_browseType = browseType;
			_browseFilter = browseFilter;
		}

        /// <summary>
        /// The finalizer implementation.
        /// </summary>
        ~TsCAeBrowsePosition()
		{
			Dispose(false);
		}

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
		{
			Dispose(true);
			// Take yourself off the Finalization queue
			// to prevent finalization code for this object
			// from executing a second time.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Dispose(bool disposing) executes in two distinct scenarios.
		/// If disposing equals true, the method has been called directly
		/// or indirectly by a user's code. Managed and unmanaged resources
		/// can be disposed.
		/// If disposing equals false, the method has been called by the
		/// runtime from inside the finalizer and you should not reference
		/// other objects. Only unmanaged resources can be disposed.
		/// </summary>
		/// <param name="disposing">If true managed and unmanaged resources can be disposed. If false only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if(!_disposed)
			{
				// If disposing equals true, dispose all managed
				// and unmanaged resources.
				if(disposing)
				{
				}
				// Release unmanaged resources. If disposing is false,
				// only the following code is executed.
			}
			_disposed = true;
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Properties

		/// <summary>
		/// The fully qualified id for the area being browsed.
		/// </summary>
		public string AreaID
		{
			get { return _areaID; }
		}

		/// <summary>
		/// The type of child element being returned with the browse.
		/// </summary>
		public TsCAeBrowseType BrowseType
		{
			get { return _browseType; }
		}

		/// <summary>
		/// The filter applied to the name of the elements being returned.
		/// </summary>
		public string BrowseFilter
		{
			get { return _browseFilter; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region ICloneable Members

		/// <summary>
		/// Creates a shallow copy of the object.
		/// </summary>
		public virtual object Clone()
		{
			return (TsCAeBrowsePosition)MemberwiseClone();
		}

		#endregion
	}
}

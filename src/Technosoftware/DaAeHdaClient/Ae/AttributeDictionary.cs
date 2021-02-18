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
using Technosoftware.DaAeHdaClient;
#endregion

namespace Technosoftware.DaAeHdaClient.Ae
{
	/// <summary>
	/// Contains multiple lists of the attributes indexed by category.
	/// </summary>
	[Serializable]
	public class TsCAeAttributeDictionary : OpcWriteableDictionary
	{
		///////////////////////////////////////////////////////////////////////
		#region Constructors, Destructor, Initialization

		/// <summary>
		/// Constructs an empty dictionary.
		/// </summary>
		public TsCAeAttributeDictionary() : base(null, typeof(int), typeof(TsCAeAttributeCollection)) { }

		/// <summary>
		/// Constructs an dictionary from a set of category ids.
		/// </summary>
		public TsCAeAttributeDictionary(int[] categoryIDs)
			: base(null, typeof(int), typeof(TsCAeAttributeCollection))
		{
			for (int ii = 0; ii < categoryIDs.Length; ii++)
			{
				Add(categoryIDs[ii], null);
			}
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Public Methods

		/// <summary>
		/// Gets or sets the atrtibute collection for the specified category. 
		/// </summary>
		public TsCAeAttributeCollection this[int categoryID]
		{
			get { return (TsCAeAttributeCollection)base[categoryID]; }

			set
			{
				if (value != null)
				{
					base[categoryID] = value;
				}
				else
				{
					base[categoryID] = new TsCAeAttributeCollection();
				}
			}
		}

		/// <summary>
		/// Adds an element with the provided key and value to the IDictionary.
		/// </summary>
		public virtual void Add(int key, int[] value)
		{
			if (value != null)
			{
				base.Add(key, new TsCAeAttributeCollection(value));
			}
			else
			{
				base.Add(key, new TsCAeAttributeCollection());
			}
		}

		#endregion
	}
}

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
using System.Collections;
#endregion

namespace Technosoftware.DaAeHdaClient.Hda
{
	/// <summary>
	/// A collection of attribute filters used when browsing the server address space.
	/// </summary>
	[Serializable]
	public class TsCHdaBrowseFilterCollection : Technosoftware.DaAeHdaClient.OpcItem, ICollection
	{
		///////////////////////////////////////////////////////////////////////
		#region Fields

		private TsCHdaBrowseFilter[] _filters = new TsCHdaBrowseFilter[0];

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Constructors, Destructor, Initialization

		/// <summary>
		/// Creates an empty collection.
		/// </summary>
		public TsCHdaBrowseFilterCollection()
		{
			// do nothing.
		}

		/// <summary>
		/// Initializes the object with any BrowseFilter contained in the collection.
		/// </summary>
		/// <param name="collection">A collection containing browse filters.</param>
		public TsCHdaBrowseFilterCollection(ICollection collection)
		{
			Init(collection);
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Properties

		/// <summary>
		/// Returns the browse filter at the specified index.
		/// </summary>
		public TsCHdaBrowseFilter this[int index]
		{
			get { return _filters[index]; }
			set { _filters[index] = value; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Public Methods

		/// <summary>
		/// Returns the browse filter for the specified attribute id.
		/// </summary>
		public TsCHdaBrowseFilter Find(int id)
		{
			foreach (TsCHdaBrowseFilter filter in _filters)
			{
				if (filter.AttributeID == id)
				{
					return filter;
				}
			}

			return null;
		}

		/// <summary>
		/// Initializes the object with any attribute values contained in the collection.
		/// </summary>
		/// <param name="collection">A collection containing attribute values.</param>
		public void Init(ICollection collection)
		{
			Clear();

			if (collection != null)
			{
				ArrayList values = new ArrayList(collection.Count);

				foreach (object value in collection)
				{
					if (value.GetType() == typeof(TsCHdaBrowseFilter))
					{
						values.Add(Technosoftware.DaAeHdaClient.OpcConvert.Clone(value));
					}
				}

				_filters = (TsCHdaBrowseFilter[])values.ToArray(typeof(TsCHdaBrowseFilter));
			}
		}

		/// <summary>
		/// Removes all attribute values in the collection.
		/// </summary>
		public void Clear()
		{
			_filters = new TsCHdaBrowseFilter[0];
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region ICloneable Members

		/// <summary>
		/// Creates a deep copy of the object.
		/// </summary>
		public override object Clone()
		{
			return new TsCHdaBrowseFilterCollection(this);
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region ICollection Members

		/// <summary>
		/// Indicates whether access to the ICollection is synchronized (thread-safe).
		/// </summary>
		public bool IsSynchronized
		{
			get { return false; }
		}

		/// <summary>
		/// Gets the number of objects in the collection.
		/// </summary>
		public int Count
		{
			get { return (_filters != null) ? _filters.Length : 0; }
		}

		/// <summary>
		/// Copies the objects in to an Array, starting at a the specified index.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination for the objects.</param>
		/// <param name="index">The zero-based index in the Array at which copying begins.</param>
		public void CopyTo(Array array, int index)
		{
			if (_filters != null)
			{
				_filters.CopyTo(array, index);
			}
		}

		/// <summary>
		/// Copies the objects to an Array, starting at a the specified index.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination for the objects.</param>
		/// <param name="index">The zero-based index in the Array at which copying begins.</param>
		public void CopyTo(TsCHdaBrowseFilter[] array, int index)
		{
			CopyTo((Array)array, index);
		}

		/// <summary>
		/// Indicates whether access to the ICollection is synchronized (thread-safe).
		/// </summary>
		public object SyncRoot
		{
			get { return this; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region IEnumerable Members

		/// <summary>
		/// Returns an enumerator that can iterate through a collection.
		/// </summary>
		/// <returns>An IEnumerator that can be used to iterate through the collection.</returns>
		public IEnumerator GetEnumerator()
		{
			return _filters.GetEnumerator();
		}

		#endregion
	}
}

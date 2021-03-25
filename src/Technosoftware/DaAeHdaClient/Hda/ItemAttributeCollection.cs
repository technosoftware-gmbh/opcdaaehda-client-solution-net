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
using Technosoftware.DaAeHdaClient;
#endregion

namespace Technosoftware.DaAeHdaClient.Hda
{
	/// <summary>
	/// A collection of item attribute values passed to write or returned from a read operation.
	/// </summary>
	[Serializable]
	public class TsCHdaItemAttributeCollection : OpcItem, IOpcResult, ITsCHdaActualTime, ICollection, IList
	{
		///////////////////////////////////////////////////////////////////////
		#region Fields

		private DateTime _startTime = DateTime.MinValue;
		private DateTime _endTime = DateTime.MinValue;
		private ArrayList _attributes = new ArrayList();
		private OpcResult _result = OpcResult.S_OK;

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Constructors, Destructor, Initialization

		/// <summary>
		/// Initializes object with the default values.
		/// </summary>
		public TsCHdaItemAttributeCollection() { }

		/// <summary>
		/// Initializes object with the specified ItemIdentifier object.
		/// </summary>
		public TsCHdaItemAttributeCollection(OpcItem item) : base(item) { }

		/// <summary>
		/// Initializes object with the specified ItemAttributeCollection object.
		/// </summary>
		public TsCHdaItemAttributeCollection(TsCHdaItemAttributeCollection item)
			: base(item)
		{
			_attributes = new ArrayList(item._attributes.Count);

			foreach (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection value in item._attributes)
			{
				if (value != null)
				{
					_attributes.Add(value.Clone());
				}
			}
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Properties

		/// <summary>
		/// Accessor for elements in the collection.
		/// </summary>
		public Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection this[int index]
		{
			get { return (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection)_attributes[index]; }
			set { _attributes[index] = value; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region IOpcResult Members

		/// <summary>
		/// The error id for the result of an operation on an item.
		/// </summary>
		public OpcResult Result
		{
			get { return _result; }
			set { _result = value; }
		}

		/// <summary>
		/// Vendor specific diagnostic information (not the localized error text).
		/// </summary>
		public string DiagnosticInfo { get; set; }

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region IActualTime Members

		/// <summary>
		/// The actual start time used by a server while processing a request.
		/// The <see cref="LicenseHandler.TimeAsUtc">LicenseHandler.TimeAsUtc</see> property defines
		/// the time format (UTC or local time).
		/// </summary>
		public DateTime StartTime
		{
			get { return _startTime; }
			set { _startTime = value; }
		}

		/// <summary>
		/// The actual end time used by a server while processing a request.
		/// The <see cref="LicenseHandler.TimeAsUtc">LicenseHandler.TimeAsUtc</see> property defines
		/// the time format (UTC or local time).
		/// </summary>
		public DateTime EndTime
		{
			get { return _endTime; }
			set { _endTime = value; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region ICloneable Members

		/// <summary>
		/// Creates a deep copy of the object.
		/// </summary>
		public override object Clone()
		{
			TsCHdaItemAttributeCollection collection = (TsCHdaItemAttributeCollection)base.Clone();

			collection._attributes = new ArrayList(_attributes.Count);

			foreach (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection value in _attributes)
			{
				collection._attributes.Add(value.Clone());
			}

			return collection;
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
			get { return (_attributes != null) ? _attributes.Count : 0; }
		}

		/// <summary>
		/// Copies the objects to an Array, starting at a the specified index.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination for the objects.</param>
		/// <param name="index">The zero-based index in the Array at which copying begins.</param>
		public void CopyTo(Array array, int index)
		{
			if (_attributes != null)
			{
				_attributes.CopyTo(array, index);
			}
		}

		/// <summary>
		/// Copies the objects to an Array, starting at a the specified index.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination for the objects.</param>
		/// <param name="index">The zero-based index in the Array at which copying begins.</param>
		public void CopyTo(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection[] array, int index)
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
			return _attributes.GetEnumerator();
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region IList Members

		/// <summary>
		/// Gets a value indicating whether the IList is read-only.
		/// </summary>
		public bool IsReadOnly
		{
			get { return false; }
		}

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		object IList.this[int index]
		{
			get { return _attributes[index]; }

			set
			{
				if (!typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection).IsInstanceOfType(value))
				{
					throw new ArgumentException("May only add AttributeValueCollection objects into the collection.");
				}

				_attributes[index] = value;
			}
		}

		/// <summary>
		/// Removes the IList item at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		public void RemoveAt(int index)
		{
			_attributes.RemoveAt(index);
		}

		/// <summary>
		/// Inserts an item to the IList at the specified position.
		/// </summary>
		/// <param name="index">The zero-based index at which value should be inserted.</param>
		/// <param name="value">The Object to insert into the IList. </param>
		public void Insert(int index, object value)
		{
			if (!typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection).IsInstanceOfType(value))
			{
				throw new ArgumentException("May only add AttributeValueCollection objects into the collection.");
			}

			_attributes.Insert(index, value);
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the IList.
		/// </summary>
		/// <param name="value">The Object to remove from the IList.</param>
		public void Remove(object value)
		{
			_attributes.Remove(value);
		}

		/// <summary>
		/// Determines whether the IList contains a specific value.
		/// </summary>
		/// <param name="value">The Object to locate in the IList.</param>
		/// <returns>true if the Object is found in the IList; otherwise, false.</returns>
		public bool Contains(object value)
		{
			return _attributes.Contains(value);
		}

		/// <summary>
		/// Removes all items from the IList.
		/// </summary>
		public void Clear()
		{
			_attributes.Clear();
		}

		/// <summary>
		/// Determines the index of a specific item in the IList.
		/// </summary>
		/// <param name="value">The Object to locate in the IList.</param>
		/// <returns>The index of value if found in the list; otherwise, -1.</returns>
		public int IndexOf(object value)
		{
			return _attributes.IndexOf(value);
		}

		/// <summary>
		/// Adds an item to the IList.
		/// </summary>
		/// <param name="value">The Object to add to the IList. </param>
		/// <returns>The position into which the new element was inserted.</returns>
		public int Add(object value)
		{
			if (!typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection).IsInstanceOfType(value))
			{
				throw new ArgumentException("May only add AttributeValueCollection objects into the collection.");
			}

			return _attributes.Add(value);
		}

		/// <summary>
		/// Indicates whether the IList has a fixed size.
		/// </summary>
		public bool IsFixedSize
		{
			get { return false; }
		}

		/// <summary>
		/// Inserts an item to the IList at the specified position.
		/// </summary>
		/// <param name="index">The zero-based index at which value should be inserted.</param>
		/// <param name="value">The Object to insert into the IList. </param>
		public void Insert(int index, Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection value)
		{
			Insert(index, (object)value);
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the IList.
		/// </summary>
		/// <param name="value">The Object to remove from the IList.</param>
		public void Remove(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection value)
		{
			Remove((object)value);
		}

		/// <summary>
		/// Determines whether the IList contains a specific value.
		/// </summary>
		/// <param name="value">The Object to locate in the IList.</param>
		/// <returns>true if the Object is found in the IList; otherwise, false.</returns>
		public bool Contains(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection value)
		{
			return Contains((object)value);
		}

		/// <summary>
		/// Determines the index of a specific item in the IList.
		/// </summary>
		/// <param name="value">The Object to locate in the IList.</param>
		/// <returns>The index of value if found in the list; otherwise, -1.</returns>
		public int IndexOf(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection value)
		{
			return IndexOf((object)value);
		}

		/// <summary>
		/// Adds an item to the IList.
		/// </summary>
		/// <param name="value">The Object to add to the IList. </param>
		/// <returns>The position into which the new element was inserted.</returns>
		public int Add(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection value)
		{
			return Add((object)value);
		}

		#endregion
	}
}

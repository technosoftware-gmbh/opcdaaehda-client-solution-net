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
	/// The set of values for an item attribute over a period of time.
	/// </summary>
	[Serializable]
	public class TsCHdaAttributeValueCollection : IOpcResult, ICollection, ICloneable, IList
	{
		///////////////////////////////////////////////////////////////////////
		#region Fields

		private OpcResult _result = OpcResult.S_OK;
		private ArrayList _attributeValues = new ArrayList();

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Constructors, Destructor, Initialization

		/// <summary>
		/// Initializes object with the default values.
		/// </summary>
		public TsCHdaAttributeValueCollection() { }

		/// <summary>
		/// Initializes object with the specified ItemIdentifier object.
		/// </summary>
		public TsCHdaAttributeValueCollection(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute attribute)
		{
			AttributeID = attribute.ID;
		}

		/// <summary>
		/// Initializes object with the specified AttributeValueCollection object.
		/// </summary>
		public TsCHdaAttributeValueCollection(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection collection)
		{
			_attributeValues = new ArrayList(collection._attributeValues.Count);

			foreach (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue value in collection._attributeValues)
			{
				_attributeValues.Add(value.Clone());
			}
		}

		#endregion
		
		///////////////////////////////////////////////////////////////////////
		#region Properties

		/// <summary>
		/// A unique identifier for the attribute.
		/// </summary>
		public int AttributeID { get; set; }

		/// <summary>
		/// Accessor for elements in the collection.
		/// </summary>
		public Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue this[int index]
		{
			get { return (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue)_attributeValues[index]; }
			set { _attributeValues[index] = value; }
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
		#region ICloneable Members

		/// <summary>
		/// Creates a deep copy of the object.
		/// </summary>
		public virtual object Clone()
		{
			Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection collection = (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection)MemberwiseClone();

			collection._attributeValues = new ArrayList(_attributeValues.Count);

			foreach (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue value in _attributeValues)
			{
				collection._attributeValues.Add(value.Clone());
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
			get { return (_attributeValues != null) ? _attributeValues.Count : 0; }
		}

		/// <summary>
		/// Copies the objects to an Array, starting at a the specified index.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination for the objects.</param>
		/// <param name="index">The zero-based index in the Array at which copying begins.</param>
		public void CopyTo(Array array, int index)
		{
			if (_attributeValues != null)
			{
				_attributeValues.CopyTo(array, index);
			}
		}

		/// <summary>
		/// Copies the objects to an Array, starting at a the specified index.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination for the objects.</param>
		/// <param name="index">The zero-based index in the Array at which copying begins.</param>
		public void CopyTo(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue[] array, int index)
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
			return _attributeValues.GetEnumerator();
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
			get { return _attributeValues[index]; }

			set
			{
				if (!typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue).IsInstanceOfType(value))
				{
					throw new ArgumentException("May only add AttributeValue objects into the collection.");
				}

				_attributeValues[index] = value;
			}
		}

		/// <summary>
		/// Removes the IList item at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		public void RemoveAt(int index)
		{
			_attributeValues.RemoveAt(index);
		}

		/// <summary>
		/// Inserts an item to the IList at the specified position.
		/// </summary>
		/// <param name="index">The zero-based index at which value should be inserted.</param>
		/// <param name="value">The Object to insert into the IList. </param>
		public void Insert(int index, object value)
		{
			if (!typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue).IsInstanceOfType(value))
			{
				throw new ArgumentException("May only add AttributeValue objects into the collection.");
			}

			_attributeValues.Insert(index, value);
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the IList.
		/// </summary>
		/// <param name="value">The Object to remove from the IList.</param>
		public void Remove(object value)
		{
			_attributeValues.Remove(value);
		}

		/// <summary>
		/// Determines whether the IList contains a specific value.
		/// </summary>
		/// <param name="value">The Object to locate in the IList.</param>
		/// <returns>true if the Object is found in the IList; otherwise, false.</returns>
		public bool Contains(object value)
		{
			return _attributeValues.Contains(value);
		}

		/// <summary>
		/// Removes all items from the IList.
		/// </summary>
		public void Clear()
		{
			_attributeValues.Clear();
		}

		/// <summary>
		/// Determines the index of a specific item in the IList.
		/// </summary>
		/// <param name="value">The Object to locate in the IList.</param>
		/// <returns>The index of value if found in the list; otherwise, -1.</returns>
		public int IndexOf(object value)
		{
			return _attributeValues.IndexOf(value);
		}

		/// <summary>
		/// Adds an item to the IList.
		/// </summary>
		/// <param name="value">The Object to add to the IList. </param>
		/// <returns>The position into which the new element was inserted.</returns>
		public int Add(object value)
		{
			if (!typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue).IsInstanceOfType(value))
			{
				throw new ArgumentException("May only add AttributeValue objects into the collection.");
			}

			return _attributeValues.Add(value);
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
		public void Insert(int index, Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue value)
		{
			Insert(index, (object)value);
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the IList.
		/// </summary>
		/// <param name="value">The Object to remove from the IList.</param>
		public void Remove(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue value)
		{
			Remove((object)value);
		}

		/// <summary>
		/// Determines whether the IList contains a specific value.
		/// </summary>
		/// <param name="value">The Object to locate in the IList.</param>
		/// <returns>true if the Object is found in the IList; otherwise, false.</returns>
		public bool Contains(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue value)
		{
			return Contains((object)value);
		}

		/// <summary>
		/// Determines the index of a specific item in the IList.
		/// </summary>
		/// <param name="value">The Object to locate in the IList.</param>
		/// <returns>The index of value if found in the list; otherwise, -1.</returns>
		public int IndexOf(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue value)
		{
			return IndexOf((object)value);
		}

		/// <summary>
		/// Adds an item to the IList.
		/// </summary>
		/// <param name="value">The Object to add to the IList. </param>
		/// <returns>The position into which the new element was inserted.</returns>
		public int Add(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue value)
		{
			return Add((object)value);
		}

		#endregion
	}
}

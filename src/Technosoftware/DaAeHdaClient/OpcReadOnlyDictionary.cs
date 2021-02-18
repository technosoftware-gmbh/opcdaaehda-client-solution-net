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
using System.Runtime.Serialization;
#endregion

namespace Technosoftware.DaAeHdaClient
{
    /// <summary>
    /// A read only dictionary class which can be used to expose arrays as properties of classes.
    /// </summary>
    [Serializable]
    public class OpcReadOnlyDictionary : IDictionary, ISerializable
    {
        #region Protected Interface
        /// <summary>
        ///Creates a collection that wraps the specified array instance.
        /// </summary>
        protected OpcReadOnlyDictionary(Hashtable dictionary)
        {
            Dictionary = dictionary;
        }

        /// <summary>
        /// The array instance exposed by the collection.
        /// </summary>
        protected virtual Hashtable Dictionary
        {
            get { return m_dictionary; }

            set
            {
                m_dictionary = value;

                if (m_dictionary == null)
                {
                    m_dictionary = new Hashtable();
                }
            }
        }
        #endregion

        #region ISerializable Members
        /// <summary>
        /// A set of names for fields used in serialization.
        /// </summary>
        private class Names
        {
            internal const string COUNT = "CT";
            internal const string KEY = "KY";
            internal const string VALUE = "VA";
        }

        /// <summary>
        /// Contructs a server by de-serializing its OpcUrl from the stream.
        /// </summary>
        protected OpcReadOnlyDictionary(SerializationInfo info, StreamingContext context)
        {
            int count = (int)info.GetValue(Names.COUNT, typeof(int));

            m_dictionary = new Hashtable();

            for (int ii = 0; ii < count; ii++)
            {
                object key = info.GetValue(Names.KEY + ii.ToString(), typeof(object));
                object value = info.GetValue(Names.VALUE + ii.ToString(), typeof(object));

                if (key != null)
                {
                    m_dictionary[key] = value;
                }
            }
        }

        /// <summary>
        /// Serializes a server into a stream.
        /// </summary>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(Names.COUNT, m_dictionary.Count);

            int ii = 0;

            IDictionaryEnumerator enumerator = m_dictionary.GetEnumerator();

            while (enumerator.MoveNext())
            {
                info.AddValue(Names.KEY + ii.ToString(), enumerator.Key);
                info.AddValue(Names.VALUE + ii.ToString(), enumerator.Value);

                ii++;
            }
        }
        #endregion

        #region IDictionary Members
        /// <summary>
        /// Gets a value indicating whether the IDictionary is read-only.
        /// </summary>
        public virtual bool IsReadOnly
        {
            get { return true; }
        }

        /// <summary>
        /// Returns an IDictionaryEnumerator for the IDictionary.
        /// </summary>
        public virtual IDictionaryEnumerator GetEnumerator()
        {
            return m_dictionary.GetEnumerator();
        }

        /// <summary>
        /// Gets or sets the element with the specified key. 
        /// </summary>
        public virtual object this[object key]
        {
            get
            {
                return m_dictionary[key];
            }

            set
            {
                throw new InvalidOperationException(READ_ONLY_DICTIONARY);
            }
        }

        /// <summary>
        /// Removes the element with the specified key from the IDictionary.
        /// </summary>
        public virtual void Remove(object key)
        {
            throw new InvalidOperationException(READ_ONLY_DICTIONARY);
        }

        /// <summary>
        /// Determines whether the IDictionary contains an element with the specified key.
        /// </summary>
        public virtual bool Contains(object key)
        {
            return m_dictionary.Contains(key);
        }

        /// <summary>
        /// Removes all elements from the IDictionary.
        /// </summary>
        public virtual void Clear()
        {
            throw new InvalidOperationException(READ_ONLY_DICTIONARY);
        }

        /// <summary>
        /// Gets an ICollection containing the values in the IDictionary.
        /// </summary>
        public virtual ICollection Values
        {
            get { return m_dictionary.Values; }
        }

        /// <summary>
        /// Adds an element with the provided key and value to the IDictionary.
        /// </summary>
        public void Add(object key, object value)
        {
            throw new InvalidOperationException(READ_ONLY_DICTIONARY);
        }

        /// <summary>
        /// Gets an ICollection containing the keys of the IDictionary.
        /// </summary>
        public virtual ICollection Keys
        {
            get { return m_dictionary.Keys; }
        }

        /// <summary>
        /// Gets a value indicating whether the IDictionary has a fixed size.
        /// </summary>
        public virtual bool IsFixedSize
        {
            get { return false; }
        }
        #endregion

        #region ICollection Members
        /// <summary>
        /// Indicates whether access to the ICollection is synchronized (thread-safe).
        /// </summary>
        public virtual bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the number of objects in the collection.
        /// </summary>
        public virtual int Count
        {
            get { return m_dictionary.Count; }
        }

        /// <summary>
        /// Copies the objects to an Array, starting at a the specified index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination for the objects.</param>
        /// <param name="index">The zero-based index in the Array at which copying begins.</param>
        public virtual void CopyTo(Array array, int index)
        {
            if (m_dictionary != null)
            {
                m_dictionary.CopyTo(array, index);
            }
        }

        /// <summary>
        /// Indicates whether access to the ICollection is synchronized (thread-safe).
        /// </summary>
        public virtual object SyncRoot
        {
            get { return this; }
        }
        #endregion

        #region IEnumerable Members
        /// <summary>
        /// Returns an enumerator that can iterate through a collection.
        /// </summary>
        /// <returns>An IEnumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        #region ICloneable Members
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public virtual object Clone()
        {
            OpcReadOnlyDictionary clone = (OpcReadOnlyDictionary)this.MemberwiseClone();

            // clone contents of hashtable.
            Hashtable dictionary = new Hashtable();

            IDictionaryEnumerator enumerator = m_dictionary.GetEnumerator();

            while (enumerator.MoveNext())
            {
                dictionary.Add(Technosoftware.DaAeHdaClient.OpcConvert.Clone(enumerator.Key), Technosoftware.DaAeHdaClient.OpcConvert.Clone(enumerator.Value));
            }

            clone.m_dictionary = dictionary;

            // return clone.
            return clone;
        }
        #endregion

        #region Private Members
        private Hashtable m_dictionary = new Hashtable();
        private const string READ_ONLY_DICTIONARY = "Cannot change the contents of a read-only dictionary";
        #endregion
    }
}

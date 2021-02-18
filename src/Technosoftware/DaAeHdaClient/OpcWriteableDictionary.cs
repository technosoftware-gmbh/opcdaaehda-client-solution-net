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
    public class OpcWriteableDictionary : IDictionary, ISerializable
    {
        #region Fields
        private Hashtable _dictionary = new Hashtable();
        private System.Type _keyType;
        private System.Type _valueType;
        #endregion

        #region Protected Interface
        /// <summary>
        /// Creates a collection that wraps the specified array instance.
        /// </summary>
        protected OpcWriteableDictionary(IDictionary dictionary, System.Type keyType, System.Type valueType)
        {
            // set default key/value types.
            _keyType = keyType ?? typeof(object);
            _valueType = valueType ?? typeof(object);

            // copy dictionary.
            Dictionary = dictionary;
        }

        /// <summary>
        /// The dictionary instance exposed by the collection.
        /// </summary>
        protected virtual IDictionary Dictionary
        {
            get { return _dictionary;  }
            
            set 
            { 
                // copy dictionary.
                if (value != null)
                {           
                    // verify that current keys of the dictionary are the correct type.
                    if (_keyType != null)
                    {
                        foreach (object element in value.Keys)
                        {
                            ValidateKey(element, _keyType);
                        }
                    }

                    // verify that current values of the dictionary are the correct type.
                    if (_valueType != null)
                    {
                        foreach (object element in value.Values)
                        {
                            ValidateValue(element, _valueType);
                        }
                    }

                    _dictionary = new Hashtable(value);
                }
                else
                {
                    _dictionary = new Hashtable();
                }
            }
        }

        /// <summary>
        /// The type of objects allowed as keys in the dictionary.
        /// </summary>
        protected System.Type KeyType
        {
            get { return _keyType; }
            
            set 
            {
                // verify that current keys of the dictionary are the correct type.
                foreach (object element in _dictionary.Keys)
                {
                    ValidateKey(element, value);
                }

                _keyType = value; 
            }
        }

        /// <summary>
        /// The type of objects allowed as values in the dictionary.
        /// </summary>
        protected System.Type ValueType
        {
            get { return _valueType; }
            
            set 
            {
                // verify that current values of the dictionary are the correct type.
                foreach (object element in _dictionary.Values)
                {
                    ValidateValue(element, value);
                }

                _valueType = value; 
            }
        }
                
        /// <summary>
        /// Throws an exception if the key is not valid for the dictionary.
        /// </summary>
        protected virtual void ValidateKey(object element, System.Type type)
        {
            if (element == null)
            {
                throw new ArgumentException(String.Format(INVALID_VALUE, element, "key"));
            }

            if (!type.IsInstanceOfType(element))
            {
                throw new ArgumentException(String.Format(INVALID_TYPE, element.GetType(), "key"));
            }
        }
                
        /// <summary>
        /// Throws an exception if the value is not valid for the dictionary.
        /// </summary>
        protected virtual void ValidateValue(object element, System.Type type)
        {
            if (element != null)
            {
                if (!type.IsInstanceOfType(element))
                {
                    throw new ArgumentException(String.Format(INVALID_TYPE, element.GetType(), "value"));
                }
            }
        }

        /// <remarks/>
        protected const string INVALID_VALUE = "The {1} '{0}' cannot be added to the dictionary.";
        /// <remarks/>
        protected const string INVALID_TYPE  = "A {1} with type '{0}' cannot be added to the dictionary.";
        #endregion

        #region ISerializable Members
        /// <summary>
        /// A set of names for fields used in serialization.
        /// </summary>
        private class Names
        {  
            internal const string COUNT       = "CT";
            internal const string KEY         = "KY";
            internal const string VALUE       = "VA";
            internal const string KEY_TYPE    = "KT";
            internal const string VALUE_VALUE = "VT";                                                    
        }

        /// <summary>
        /// Contructs a server by de-serializing its OpcUrl from the stream.
        /// </summary>
        protected OpcWriteableDictionary(SerializationInfo info, StreamingContext context)
        {   
            _keyType   = (System.Type)info.GetValue(Names.KEY_TYPE, typeof(System.Type));
            _valueType = (System.Type)info.GetValue(Names.VALUE_VALUE, typeof(System.Type));

            int count = (int)info.GetValue(Names.COUNT, typeof(int));

            _dictionary = new Hashtable();

            for (int ii = 0; ii < count; ii++)
            {
                object key   = info.GetValue(Names.KEY + ii.ToString(), typeof(object));
                object value = info.GetValue(Names.VALUE + ii.ToString(), typeof(object));

                if (key != null)
                {
                    _dictionary[key] = value;
                }
            }
        }

        /// <summary>
        /// Serializes a server into a stream.
        /// </summary>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {           
            info.AddValue(Names.KEY_TYPE, _keyType);
            info.AddValue(Names.VALUE_VALUE, _valueType);
            info.AddValue(Names.COUNT, _dictionary.Count);

            int ii = 0;

            IDictionaryEnumerator enumerator = _dictionary.GetEnumerator();

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
            get { return false; }
        }

        /// <summary>
        /// Returns an IDictionaryEnumerator for the IDictionary.
        /// </summary>
        public virtual IDictionaryEnumerator GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }       

        /// <summary>
        /// Gets or sets the element with the specified key. 
        /// </summary>
        public virtual object this[object key]
        {
            get
            {
                return _dictionary[key];
            }

            set
            {
                ValidateKey(key, _keyType);
                ValidateValue(value, _valueType);
                _dictionary[key] = value;
            }
        }

        /// <summary>
        /// Removes the element with the specified key from the IDictionary.
        /// </summary>
        public virtual void Remove(object key)
        {
            _dictionary.Remove(key);
        }

        /// <summary>
        /// Determines whether the IDictionary contains an element with the specified key.
        /// </summary>
        public virtual bool Contains(object key)
        {
            return _dictionary.Contains(key);
        }

        /// <summary>
        /// Removes all elements from the IDictionary.
        /// </summary>
        public virtual void Clear()
        {
            _dictionary.Clear();
        }

        /// <summary>
        /// Gets an ICollection containing the values in the IDictionary.
        /// </summary>
        public virtual ICollection Values
        {
            get { return _dictionary.Values; }
        }

        /// <summary>
        /// Adds an element with the provided key and value to the IDictionary.
        /// </summary>
        public virtual void Add(object key, object value)
        {
            ValidateKey(key, _keyType);
            ValidateValue(value, _valueType);
            _dictionary.Add(key, value);
        }

        /// <summary>
        /// Gets an ICollection containing the keys of the IDictionary.
        /// </summary>
        public virtual ICollection Keys
        {
            get { return _dictionary.Keys; }
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
            get { return _dictionary.Count; }
        }

        /// <summary>
        /// Copies the objects to an Array, starting at a the specified index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination for the objects.</param>
        /// <param name="index">The zero-based index in the Array at which copying begins.</param>
        public virtual void CopyTo(Array array, int index)
        {
            if (_dictionary != null)
            {
                _dictionary.CopyTo(array, index);
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
            return GetEnumerator();
        }
        #endregion
        
        #region ICloneable Members
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public virtual object Clone()
        {
            OpcWriteableDictionary clone = (OpcWriteableDictionary)MemberwiseClone();
    
            // clone contents of hashtable.
            Hashtable dictionary = new Hashtable();

            IDictionaryEnumerator enumerator = _dictionary.GetEnumerator();

            while (enumerator.MoveNext())
            {
                dictionary.Add(Technosoftware.DaAeHdaClient.OpcConvert.Clone(enumerator.Key), Technosoftware.DaAeHdaClient.OpcConvert.Clone(enumerator.Value));
            }

            clone._dictionary = dictionary;

            // return clone.
            return clone;
        }
        #endregion

    }
}

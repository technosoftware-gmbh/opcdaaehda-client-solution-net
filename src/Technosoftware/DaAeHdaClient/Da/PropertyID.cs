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
using System.Xml;
using System.Runtime.Serialization;
#endregion

namespace Technosoftware.DaAeHdaClient.Da
{
	/// <summary>
	/// Contains a unique identifier for a property.
	/// </summary>
	[Serializable]
	public struct TsDaPropertyID : ISerializable
	{
		///////////////////////////////////////////////////////////////////////
		#region Names Class

		/// <summary>
		/// A set of names for fields used in serialization.
		/// </summary>
		private class Names
		{
			internal const string NAME = "NA";
			internal const string NAMESPACE = "NS";
			internal const string CODE = "CO";
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Fields

		private int _code;
		private XmlQualifiedName _name;
		
		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Constructors, Destructor, Initialization

		/// <summary>
		/// Initializes a property identified by a qualified name.
		/// </summary>
		public TsDaPropertyID(XmlQualifiedName name) { _name = name; _code = 0; }

		/// <summary>
		/// Initializes a property identified by an integer.
		/// </summary>
		public TsDaPropertyID(int code) { _name = null; _code = code; }

		/// <summary>
		/// Initializes a property identified by a property description.
		/// </summary>
		public TsDaPropertyID(string name, int code, string ns) { _name = new XmlQualifiedName(name, ns); _code = code; }

		///<remarks>
		/// During deserialization, SerializationInfo is passed to the class using the constructor provided for this purpose. Any visibility 
		/// constraints placed on the constructor are ignored when the object is deserialized; so you can mark the class as public, 
		/// protected, internal, or private. However, it is best practice to make the constructor protected unless the class is sealed, in which case 
		/// the constructor should be marked private. The constructor should also perform thorough input validation. To avoid misuse by malicious code, 
		/// the constructor should enforce the same security checks and permissions required to obtain an instance of the class using any other 
		/// constructor. 
		/// </remarks>
		/// <summary>
		/// Contructs a server by de-serializing its OpcUrl from the stream.
		/// </summary>
		private TsDaPropertyID(SerializationInfo info, StreamingContext context)
		{
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			string name = "";
			string ns = "";
			enumerator.Reset();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Name.Equals(Names.NAME))
				{
					name = (string)enumerator.Current.Value;
					continue;
				}
				if (enumerator.Current.Name.Equals(Names.NAMESPACE))
				{
					ns = (string)enumerator.Current.Value;
					continue;
				}
			}
			_name = new XmlQualifiedName(name, ns);
			_code = (int)info.GetValue(Names.CODE, typeof(int));
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Properties

		/// <summary>
		/// Used for properties identified by a qualified name.
		/// </summary>
		public XmlQualifiedName Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Used for properties identified by a integer.
		/// </summary>
		public int Code
		{
			get { return _code; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Public Methods

		/// <summary>
		/// Returns true if the objects are equal.
		/// </summary>
		public static bool operator ==(TsDaPropertyID a, TsDaPropertyID b)
		{
			return a.Equals(b);
		}

		/// <summary>
		/// Returns true if the objects are not equal.
		/// </summary>
		public static bool operator !=(TsDaPropertyID a, TsDaPropertyID b)
		{
			return !a.Equals(b);
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Serialization Functions

		/// <summary>
		/// Serializes a server into a stream.
		/// </summary>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (_name != null)
			{
				info.AddValue(Names.NAME, _name.Name);
				info.AddValue(Names.NAMESPACE, _name.Namespace);
			}
			info.AddValue(Names.CODE, _code);
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Object Member Overrides
		
		/// <summary>
		/// Returns true if the target object is equal to the object.
		/// </summary>
		public override bool Equals(object target)
		{
			if (target != null && target.GetType() == typeof(TsDaPropertyID))
			{
				TsDaPropertyID propertyID = (TsDaPropertyID)target;

				// compare by integer if both specify valid integers.
				if (propertyID.Code != 0 && Code != 0)
				{
					return (propertyID.Code == Code);
				}

				// compare by name if both specify valid names.
				if (propertyID.Name != null && Name != null)
				{
					return (propertyID.Name == Name);
				}
			}

			return false;
		}

		/// <summary>
		/// Returns a useful hash code for the object.
		/// </summary>
		public override int GetHashCode()
		{
			if (Code != 0) return Code.GetHashCode();
			if (Name != null) return Name.GetHashCode();
			return base.GetHashCode();
		}

		/// <summary>
		/// Converts the property id to a string.
		/// </summary>
		public override string ToString()
		{
			if (Name != null && Code != 0) return String.Format("{0} ({1})", Name.Name, Code);
			if (Name != null) return Name.Name;
			if (Code != 0) return String.Format("{0}", Code);
			return "";
		}

		#endregion
	}
}

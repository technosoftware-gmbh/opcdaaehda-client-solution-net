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
using System.Runtime.Serialization;
using Technosoftware.DaAeHdaClient;
#endregion

namespace Technosoftware.DaAeHdaClient.Ae
{
	/// <summary>
	/// Describes the event filters for a subscription.
	/// </summary>
	[Serializable]
	public class TsCAeSubscriptionFilters : ICloneable, ISerializable
	{
		///////////////////////////////////////////////////////////////////////
		#region CategoryCollection Class

		/// <summary>
		/// Contains a writeable collection category ids.
		/// </summary>
		[Serializable]
		public class CategoryCollection : OpcWriteableCollection
		{
			///////////////////////////////////////////////////////////////////
			#region Constructors, Destructor, Initialization

			/// <summary>
			/// Creates an empty collection.
			/// </summary>
			internal CategoryCollection() : base(null, typeof(int)) { }

			#region ISerializable Members

			/// <summary>
			/// Contructs an object by deserializing it from a stream.
			/// </summary>
			protected CategoryCollection(SerializationInfo info, StreamingContext context) : base(info, context) { }

			#endregion

			#endregion

			///////////////////////////////////////////////////////////////////
			#region Public Methods

			/// <summary>
			/// An indexer for the collection.
			/// </summary>
			public new int this[int index]
			{
				get { return (int)Array[index]; }
			}

			/// <summary>
			/// Returns a copy of the collection as an array.
			/// </summary>
			public new int[] ToArray()
			{
				return (int[])Array.ToArray(typeof(int));
			}

			#endregion
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region StringCollection Class

		/// <summary>
		/// Contains a writeable collection of strings.
		/// </summary>
		[Serializable]
		public class StringCollection : OpcWriteableCollection
		{
			///////////////////////////////////////////////////////////////////
			#region Constructors, Destructor, Initialization

			/// <summary>
			/// Creates an empty collection.
			/// </summary>
			internal StringCollection() : base(null, typeof(string)) { }

			#endregion

			///////////////////////////////////////////////////////////////////
			#region Public Methods
			
			/// <summary>
			/// An indexer for the collection.
			/// </summary>
			public new string this[int index]
			{
				get { return (string)Array[index]; }
			}

			/// <summary>
			/// Returns a copy of the collection as an array.
			/// </summary>
			public new string[] ToArray()
			{
				return (string[])Array.ToArray(typeof(string));
			}

			#endregion

			#region ISerializable Members

			/// <summary>
			/// Contructs an object by deserializing it from a stream.
			/// </summary>
			protected StringCollection(SerializationInfo info, StreamingContext context) : base(info, context) { }

			#endregion

		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Names Class
		
		/// <summary>
		/// A set of names for fields used in serialization.
		/// </summary>
		private class Names
		{
			internal const string EVENT_TYPES = "ET";
			internal const string CATEGORIES = "CT";
			internal const string HIGH_SEVERITY = "HS";
			internal const string LOW_SEVERITY = "LS";
			internal const string AREAS = "AR";
			internal const string SOURCES = "SR";
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Fields

		private int _eventTypes = (int)TsCAeEventType.All;
		private CategoryCollection _categories = new CategoryCollection();
		private int _highSeverity = 1000;
		private int _lowSeverity = 1;
		private StringCollection _areas = new StringCollection();
		private StringCollection _sources = new StringCollection();

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Constructors, Destructor, Initialization

		/// <summary>
		/// Initializes object with default values.
		/// </summary>
		public TsCAeSubscriptionFilters() { }

		/// <summary>
		/// Contructs a server by de-serializing its OpcUrl from the stream.
		/// </summary>
		protected TsCAeSubscriptionFilters(SerializationInfo info, StreamingContext context)
		{
			_eventTypes = (int)info.GetValue(Names.EVENT_TYPES, typeof(int));
			_categories = (CategoryCollection)info.GetValue(Names.CATEGORIES, typeof(CategoryCollection));
			_highSeverity = (int)info.GetValue(Names.HIGH_SEVERITY, typeof(int));
			_lowSeverity = (int)info.GetValue(Names.LOW_SEVERITY, typeof(int));
			_areas = (StringCollection)info.GetValue(Names.AREAS, typeof(StringCollection));
			_sources = (StringCollection)info.GetValue(Names.SOURCES, typeof(StringCollection));
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Properties

		/// <summary>
		/// A mask indicating which event types should be sent to the client.
		/// </summary>
		public int EventTypes
		{
			get { return _eventTypes; }
			set { _eventTypes = value; }
		}

		/// <summary>
		/// The highest severity for the events that should be sent to the client.
		/// </summary>
		public int HighSeverity
		{
			get { return _highSeverity; }
			set { _highSeverity = value; }
		}

		/// <summary>
		/// The lowest severity for the events that should be sent to the client.
		/// </summary>
		public int LowSeverity
		{
			get { return _lowSeverity; }
			set { _lowSeverity = value; }
		}

		/// <summary>
		/// The category ids for the events that should be sent to the client.
		/// </summary>
		public CategoryCollection Categories
		{
			get { return _categories; }
		}

		/// <summary>
		/// A list of full-qualified ids for process areas of interest - only events or conditions in these areas will be reported.
		/// </summary>
		public StringCollection Areas
		{
			get { return _areas; }
		}

		/// <summary>
		/// A list of full-qualified ids for sources of interest - only events or conditions from these soucres will be reported.
		/// </summary>
		public StringCollection Sources
		{
			get { return _sources; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region ISerializable Members

		/// <summary>
		/// Serializes a server into a stream.
		/// </summary>
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(Names.EVENT_TYPES, _eventTypes);
			info.AddValue(Names.CATEGORIES, _categories);
			info.AddValue(Names.HIGH_SEVERITY, _highSeverity);
			info.AddValue(Names.LOW_SEVERITY, _lowSeverity);
			info.AddValue(Names.AREAS, _areas);
			info.AddValue(Names.SOURCES, _sources);
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region ICloneable Members

		/// <summary>
		/// Creates a deep copy of the object.
		/// </summary>
		public virtual object Clone()
		{
			TsCAeSubscriptionFilters filters = (TsCAeSubscriptionFilters)MemberwiseClone();

			filters._categories = (CategoryCollection)_categories.Clone();
			filters._areas = (StringCollection)_areas.Clone();
			filters._sources = (StringCollection)_sources.Clone();

			return filters;
		}

		#endregion
	}
}

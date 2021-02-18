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

namespace Technosoftware.DaAeHdaClient.Ae
{
	/// <summary>
	/// An in-process object which provides access to AE subscription objects.
	/// </summary>
	[Serializable]
	public class TsCAeSubscription : ITsCAeSubscription, ISerializable, ICloneable
	{
		///////////////////////////////////////////////////////////////////////
		#region CategoryCollection Class

		/// <summary>
		/// Contains a read-only collection category ids.
		/// </summary>
		public class CategoryCollection : OpcReadOnlyCollection
		{
			///////////////////////////////////////////////////////////////////
			#region Constructors, Destructor, Initialization

			/// <summary>
			/// Creates an empty collection.
			/// </summary>
			internal CategoryCollection() : base(new int[0]) { }

			/// <summary>
			/// Creates a collection containing the list of category ids.
			/// </summary>
			internal CategoryCollection(int[] categoryIDs) : base(categoryIDs) { }

			#endregion

			///////////////////////////////////////////////////////////////////
			#region Public Methods

			/// <summary>
			/// An indexer for the collection.
			/// </summary>
			public new int this[int index]
			{
				get { return (int)Array.GetValue(index); }
			}

			/// <summary>
			/// Returns a copy of the collection as an array.
			/// </summary>
			public new int[] ToArray()
			{
				return (int[])Technosoftware.DaAeHdaClient.OpcConvert.Clone(Array);
			}

			#endregion
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region StringCollection Class

		/// <summary>
		/// Contains a read-only collection of strings.
		/// </summary>
		public class StringCollection : OpcReadOnlyCollection
		{
			///////////////////////////////////////////////////////////////////
			#region Constructors, Destructor, Initialization

			/// <summary>
			/// Creates an empty collection.
			/// </summary>
			internal StringCollection() : base(new string[0]) { }

			/// <summary>
			/// Creates a collection containing the specified strings.
			/// </summary>
			internal StringCollection(string[] strings) : base(strings) { }

			#endregion
			
			///////////////////////////////////////////////////////////////////
			#region Public Methods

			/// <summary>
			/// An indexer for the collection.
			/// </summary>
			public new string this[int index]
			{
				get { return (string)Array.GetValue(index); }
			}

			/// <summary>
			/// Returns a copy of the collection as an array.
			/// </summary>
			public new string[] ToArray()
			{
				return (string[])Technosoftware.DaAeHdaClient.OpcConvert.Clone(Array);
			}

			#endregion
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region AttributeDictionary Class

		/// <summary>
		/// Contains a read-only dictionary of attribute lists indexed by category id.
		/// </summary>
		[Serializable]
		public class AttributeDictionary : OpcReadOnlyDictionary
		{
			///////////////////////////////////////////////////////////////////
			#region Constructors, Destructor, Initialization
			
			/// <summary>
			/// Creates an empty collection.
			/// </summary>
			internal AttributeDictionary() : base(null) { }

			/// <summary>
			/// Constructs an dictionary from a set of category ids.
			/// </summary>
			internal AttributeDictionary(Hashtable dictionary) : base(dictionary) { }

			#endregion

			///////////////////////////////////////////////////////////////////
			#region Public Methods

			/// <summary>
			/// Gets or sets the atrtibute collection for the specified category. 
			/// </summary>
			public AttributeCollection this[int categoryID]
			{
				get { return (AttributeCollection)base[categoryID]; }
			}

			/// <summary>
			/// Adds or replaces the set of attributes associated with the category.
			/// </summary>
			internal void Update(int categoryID, int[] attributeIDs)
			{
				Dictionary[categoryID] = new AttributeCollection(attributeIDs);
			}

			#endregion

			///////////////////////////////////////////////////////////////////
			#region ISerializable Members
			/// <summary>
			/// Contructs an object by deserializing it from a stream.
			/// </summary>
			protected AttributeDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
			#endregion
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region AttributeCollection Class

		/// <summary>
		/// Contains a read-only collection attribute ids.
		/// </summary>
		[Serializable]
		public class AttributeCollection : OpcReadOnlyCollection
		{
			///////////////////////////////////////////////////////////////////
			#region Constructors, Destructor, Initialization

			/// <summary>
			/// Creates an empty collection.
			/// </summary>
			internal AttributeCollection() : base(new int[0]) { }

			/// <summary>
			/// Creates a collection containing the specified attribute ids.
			/// </summary>
			internal AttributeCollection(int[] attributeIDs) : base(attributeIDs) { }

			#endregion

			///////////////////////////////////////////////////////////////////
			#region Public Methods
			
			/// <summary>
			/// An indexer for the collection.
			/// </summary>
			public new int this[int index]
			{
				get { return (int)Array.GetValue(index); }
			}

			/// <summary>
			/// Returns a copy of the collection as an array.
			/// </summary>
			public new int[] ToArray()
			{
				return (int[])Technosoftware.DaAeHdaClient.OpcConvert.Clone(Array);
			}

			#endregion

			///////////////////////////////////////////////////////////////////
			#region ISerializable Members

			/// <summary>
			/// Contructs an object by deserializing it from a stream.
			/// </summary>
			protected AttributeCollection(SerializationInfo info, StreamingContext context) : base(info, context) { }

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
			internal const string STATE = "ST";
			internal const string FILTERS = "FT";
			internal const string ATTRIBUTES = "AT";
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Fields

		private bool _disposed;
		private TsCAeServer _server;
		private ITsCAeSubscription _subscription;

		// state
		private TsCAeSubscriptionState _state = new TsCAeSubscriptionState();
		private string _name;

		// filters
		private TsCAeSubscriptionFilters _filters = new TsCAeSubscriptionFilters();
		private CategoryCollection _categories = new CategoryCollection();
		private StringCollection _areas = new StringCollection();
		private StringCollection _sources = new StringCollection();

		// returned attributes
		private AttributeDictionary _attributes = new AttributeDictionary();

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Constructors, Destructor, Initialization

		/// <summary>
		/// Initializes object with default values.
		/// </summary>
		public TsCAeSubscription(TsCAeServer server, ITsCAeSubscription subscription, TsCAeSubscriptionState state)
		{
			if (server == null) throw new ArgumentNullException("server");
			if (subscription == null) throw new ArgumentNullException("subscription");

			_server = server;
			_subscription = subscription;
			_state = (Ae.TsCAeSubscriptionState)state.Clone();
			_name = state.Name;
		}

        /// <summary>
        /// The finializer implementation.
        /// </summary>
        ~TsCAeSubscription()
		{
			Dispose(false);
		}

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
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if(!_disposed)
			{
				// If disposing equals true, dispose all managed
				// and unmanaged resources.
				if(disposing)
				{
					if (_subscription != null)
					{
						_server.SubscriptionDisposed(this);
						_subscription.Dispose();
					}
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
		/// The server that the subscription object belongs to.
		/// </summary>
		public TsCAeServer Server
		{
			get { return _server; }
		}

		/// <summary>
		/// A descriptive name for the subscription.
		/// </summary>
		public string Name
		{
			get { return _state.Name; }
		}

		/// <summary>
		/// A unique identifier for the subscription assigned by the client.
		/// </summary>
		public object ClientHandle
		{
			get { return _state.ClientHandle; }
		}

		/// <summary>
		/// Whether the subscription is monitoring for events to send to the client.
		/// </summary>
		public bool Active
		{
			get { return _state.Active; }
		}

		/// <summary>
		/// The maximum rate at which the server send event notifications.
		/// The <see cref="LicenseHandler.TimeAsUTC">OpcBase.TimeAsUTC</see> property defines
		/// the time format (UTC or local   time).
		/// </summary>
		public int BufferTime
		{
			get { return _state.BufferTime; }
		}

		/// <summary>
		/// The requested maximum number of events that will be sent in a single callback.
		/// </summary>
		public int MaxSize
		{
			get { return _state.MaxSize; }
		}

		/// <summary>
		/// The maximum period between updates sent to the client.
		/// </summary>
		public int KeepAlive
		{
			get { return _state.KeepAlive; }
		}

		/// <summary>
		/// A mask indicating which event types should be sent to the client.
		/// </summary>
		public int EventTypes
		{
			get { return _filters.EventTypes; }
		}

		/// <summary>
		/// The highest severity for the events that should be sent to the client.
		/// </summary>
		public int HighSeverity
		{
			get { return _filters.HighSeverity; }
		}

		/// <summary>
		/// The lowest severity for the events that should be sent to the client.
		/// </summary>
		public int LowSeverity
		{
			get { return _filters.LowSeverity; }
		}

		/// <summary>
		/// The event category ids monitored by this subscription.
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

		/// <summary>
		/// The list of attributes returned for each event category.
		/// </summary>
		public AttributeDictionary Attributes
		{
			get { return _attributes; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Public Methods

		/// <summary>
		/// Returns a writeable copy of the current attributes.
		/// </summary>
		public Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary GetAttributes()
		{
			Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary attributes = new Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary();

			IDictionaryEnumerator enumerator = _attributes.GetEnumerator();

			while (enumerator.MoveNext())
			{
				int categoryID = (int)enumerator.Key;
				AttributeCollection attributeIDs = (AttributeCollection)enumerator.Value;

				attributes.Add(categoryID, attributeIDs.ToArray());
			}

			return attributes;
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region ISerializable Members

		/// <summary>
		/// Contructs a server by de-serializing its OpcUrl from the stream.
		/// </summary>
		protected TsCAeSubscription(SerializationInfo info, StreamingContext context)
		{
			_state = (Ae.TsCAeSubscriptionState)info.GetValue(Names.STATE, typeof(Ae.TsCAeSubscriptionState));
			_filters = (Ae.TsCAeSubscriptionFilters)info.GetValue(Names.FILTERS, typeof(Ae.TsCAeSubscriptionFilters));
			_attributes = (AttributeDictionary)info.GetValue(Names.ATTRIBUTES, typeof(AttributeDictionary));

			_name = _state.Name;

			_categories = new CategoryCollection(_filters.Categories.ToArray());
			_areas = new StringCollection(_filters.Areas.ToArray());
			_sources = new StringCollection(_filters.Sources.ToArray());
		}

		/// <summary>
		/// Serializes a server into a stream.
		/// </summary>
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(Names.STATE, _state);
			info.AddValue(Names.FILTERS, _filters);
			info.AddValue(Names.ATTRIBUTES, _attributes);
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region ICloneable Members

		/// <summary>
		/// Returns an unconnected copy of the subscription with the same items.
		/// </summary>
		public virtual object Clone()
		{
			// do a memberwise clone.
			Ae.TsCAeSubscription clone = (Ae.TsCAeSubscription)MemberwiseClone();

			/*
			// place clone in disconnected state.
			clone.server       = null;
			clone.subscription = null;
			clone.state        = (SubscriptionState)state.Clone();

			// clear server handles.
			clone.state.ServerHandle = null;

			// always make cloned subscriptions inactive.
			clone.state.Active = false;

			// clone items.
			if (clone.items != null)
			{
				ArrayList items = new ArrayList();

				foreach (Item item in clone.items)
				{
					items.Add(item.Clone());
				}

				clone.items = (Item[])items.ToArray(typeof(Item));
			}
			*/

			// return clone.
			return clone;
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region ISubscription Members
        /// <summary>
        /// An event to receive data change updates.
        /// </summary>
        public event TsCAeDataChangedEventHandler DataChangedEvent
        {
            add { _subscription.DataChangedEvent += value; }
            remove { _subscription.DataChangedEvent -= value; }
        }

		/// <summary>
		/// Returns the current state of the subscription.
		/// </summary>
		/// <returns>The current state of the subscription.</returns>
		public TsCAeSubscriptionState GetState()
		{
            if (_subscription == null) throw new NotConnectedException();

			_state = _subscription.GetState();
			_state.Name = _name;

			return (TsCAeSubscriptionState)_state.Clone();
		}

		/// <summary>
		/// Changes the state of a subscription.
		/// </summary>
		/// <param name="masks">A bit mask that indicates which elements of the subscription state are changing.</param>
		/// <param name="state">The new subscription state.</param>
		/// <returns>The actual subscription state after applying the changes.</returns>
		public Ae.TsCAeSubscriptionState ModifyState(int masks, Ae.TsCAeSubscriptionState state)
		{
            if (_subscription == null) throw new NotConnectedException();

            _state = _subscription.ModifyState(masks, state);

			if ((masks & (int)TsCAeStateMask.Name) != 0)
			{
				_state.Name = _name = state.Name;
			}
			else
			{
				_state.Name = _name;
			}

			return (Ae.TsCAeSubscriptionState)_state.Clone();
		}

		/// <summary>
		/// Returns the current filters for the subscription.
		/// </summary>
		/// <returns>The current filters for the subscription.</returns>
		public TsCAeSubscriptionFilters GetFilters()
		{
            if (_subscription == null) throw new NotConnectedException();

            _filters = _subscription.GetFilters();
			_categories = new CategoryCollection(_filters.Categories.ToArray());
			_areas = new StringCollection(_filters.Areas.ToArray());
			_sources = new StringCollection(_filters.Sources.ToArray());

			return (TsCAeSubscriptionFilters)_filters.Clone();
		}

		/// <summary>
		/// Sets the current filters for the subscription.
		/// </summary>
		/// <param name="filters">The new filters to use for the subscription.</param>
		public void SetFilters(Ae.TsCAeSubscriptionFilters filters)
		{
            if (_subscription == null) throw new NotConnectedException();

            _subscription.SetFilters(filters);

			GetFilters();
		}

		/// <summary>
		/// Returns the set of attributes to return with event notifications.
		/// </summary>
		/// <returns>The set of attributes to returned with event notifications.</returns>
		public int[] GetReturnedAttributes(int eventCategory)
		{
            if (_subscription == null) throw new NotConnectedException();

            int[] attributeIDs = _subscription.GetReturnedAttributes(eventCategory);

			_attributes.Update(eventCategory, (int[])Technosoftware.DaAeHdaClient.OpcConvert.Clone(attributeIDs));

			return attributeIDs;
		}

		/// <summary>
		/// Selects the set of attributes to return with event notifications.
		/// </summary>
		/// <param name="eventCategory">The specific event category for which the attributes apply.</param>
		/// <param name="attributeIDs">The list of attribute ids to return.</param>
		public void SelectReturnedAttributes(int eventCategory, int[] attributeIDs)
		{
            if (_subscription == null) throw new NotConnectedException();

            _subscription.SelectReturnedAttributes(eventCategory, attributeIDs);

			_attributes.Update(eventCategory, (int[])Technosoftware.DaAeHdaClient.OpcConvert.Clone(attributeIDs));
		}

		/// <summary>
		/// Force a refresh for all active conditions and inactive, unacknowledged conditions whose event notifications match the filter of the event subscription.
		/// </summary>
		public void Refresh()
		{
            if (_subscription == null) throw new NotConnectedException();

            _subscription.Refresh();
		}

		/// <summary>
		/// Cancels an outstanding refresh request.
		/// </summary>
		public void CancelRefresh()
		{
            if (_subscription == null) throw new NotConnectedException();

            _subscription.CancelRefresh();
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Private Methods

		/// <summary>
		/// The current state.
		/// </summary>
		internal TsCAeSubscriptionState State
		{
			get { return _state; }
		}

		/// <summary>
		/// The current filters.
		/// </summary>
		internal TsCAeSubscriptionFilters Filters
		{
			get { return _filters; }
		}

		#endregion
	}
}

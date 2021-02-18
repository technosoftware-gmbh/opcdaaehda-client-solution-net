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
using System.Collections.Generic;
#endregion

namespace Technosoftware.DaAeHdaClient.Da
{

	/// <summary>
	/// 	<para>This class is the main interface to access an OPC Data Access or OPC XML-DA
	///     server.</para>
	/// </summary>
	/// <remarks>
	/// 	<para>The Connect method defines to which type of server the client connects to,
	///     e.g.</para>
	/// 	<blockquote dir="ltr" style="MARGIN-RIGHT: 0px">
	/// 		<para>
	/// 			<c>MyDaServer.Connect( "OpcClassic.DaSample" );</c>
	/// 		</para>
	/// 	</blockquote>
	/// 	<para>connects to a local Data Access Server whereas</para>
	/// 	<blockquote dir="ltr" style="MARGIN-RIGHT: 0px">
	/// 		<para>
	/// 			<code inline="true">
	/// MyXdaServer.Connect( "http://localhost/OpcXmlSampleServer/Service.asmx" );
	///             </code>
	/// 		</para>
	/// 	</blockquote>
	/// 	<para>connects to an OPC XML-DA Server.</para>
	/// </remarks>
	/// <requirements>OPC XML-DA Server or OPC Data Access Server V2.x / V3.x</requirements>
	[Serializable]
	public class TsCDaServer : Technosoftware.DaAeHdaClient.OpcServer, Technosoftware.DaAeHdaClient.Da.ITsDaServer, Technosoftware.DaAeHdaClient.IOpcServer
	{
		///////////////////////////////////////////////////////////////////////
		#region Names Class

		/// <summary>A set of names for fields used in serialization.</summary>
		private class Names
		{
			internal const string FILTERS = "Filters";
			internal const string SUBSCRIPTIONS = "Subscription";
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Fields
		
		/// <summary>
		/// A list of subscriptions for the server.
		/// </summary>
		private TsCDaSubscriptionCollection _subscriptions = new TsCDaSubscriptionCollection();

		/// <summary>
		/// The local copy of the result filters.
		/// </summary>
        int _filters = (int)TsCDaResultFilter.All | (int)TsCDaResultFilter.ClientHandle;

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Constructors, Destructor, Initialization

        /// <summary>
        /// Initializes the object.
        /// </summary>
        public TsCDaServer()
            
        {                      
            //base._factory = new Com.Factory();
        }

		/// <summary>
		/// Initializes the object with a factory and a default OpcUrl.
		/// </summary>
		/// <param name="factory">The OpcFactory used to connect to remote servers.</param>
		/// <param name="url">The network address of a remote server.</param>
		public TsCDaServer(OpcFactory factory, OpcUrl url)
			:
			base(factory, url)
		{
		}


		/// <summary>
		/// Contructs a server by de-serializing its OpcUrl from the stream.
		/// </summary>
		protected TsCDaServer(SerializationInfo info, StreamingContext context)
			:
			base(info, context)
		{
			_filters = (int)info.GetValue(Names.FILTERS, typeof(int));

			TsCDaSubscription[] subscriptions = (TsCDaSubscription[])info.GetValue(Names.SUBSCRIPTIONS, typeof(TsCDaSubscription[]));

			if (subscriptions != null)
			{
				Array.ForEach(subscriptions, subscription => _subscriptions.Add(subscription));
			}
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Properties

		/// <summary>
		/// Returns an array of all subscriptions for the server.
		/// </summary>
		public TsCDaSubscriptionCollection Subscriptions
		{
			get { return _subscriptions; }
		}

		/// <summary>
		/// The current result filters applied by the server.
		/// </summary>
		public int Filters 
		{ 
			get { return _filters; } 
		}
		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Class properties serialization helpers

		/// <summary>Serializes a server into a stream.</summary>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue(Names.FILTERS, _filters);

			TsCDaSubscription[] subscriptions = null;

			if (_subscriptions.Count > 0)
			{
				subscriptions = new TsCDaSubscription[_subscriptions.Count];

				for (int ii = 0; ii < subscriptions.Length; ii++)
				{
					subscriptions[ii] = _subscriptions[ii];
				}
			}

			info.AddValue(Names.SUBSCRIPTIONS, subscriptions);
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Public Methods

		/// <summary>Returns an unconnected copy of the server with the same OpcUrl.</summary>
		public override object Clone()
		{
			// clone the base object.
			TsCDaServer clone = (TsCDaServer)base.Clone();

			// clone subscriptions.
			if (clone._subscriptions != null)
			{
				TsCDaSubscriptionCollection subscriptions = new TsCDaSubscriptionCollection();

				foreach (TsCDaSubscription subscription in clone._subscriptions)
				{
					subscriptions.Add(subscription.Clone());
				}

				clone._subscriptions = subscriptions;
			}

			// return clone.
			return clone;
		}

		/// <summary>Connects to the server with the specified OpcUrl and credentials.</summary>
		/// <exception caption="OpcResultException Class" cref="OpcResultException">If an OPC specific error occur this exception is raised. The Result field includes then the OPC specific code.</exception>
        /// <param name="url">The network address of the remote server.</param>
        /// <param name="connectData">Any protocol configuration or user authenication information.</param>
        public override void Connect(OpcUrl url, OpcConnectData connectData)
		{
            if (_factory == null)
            {
                if (_factory == null)
                {
                    _factory = new Com.Factory();
                }
            }
            // connect to server.
			base.Connect(url, connectData);

			// all done if no subscriptions.
			if (_subscriptions == null)
			{
				return;
			}

			// create subscriptions (should only happen if server has been deserialized).
			TsCDaSubscriptionCollection subscriptions = new TsCDaSubscriptionCollection();

			foreach (TsCDaSubscription template in _subscriptions)
			{
				// create subscription for template.
				try { subscriptions.Add(EstablishSubscription(template)); }
				catch { }
			}

			// save new set of subscriptions.
			_subscriptions = subscriptions;
		}

		/// <summary>Disconnects from the server and releases all network resources.</summary>
		public override void Disconnect()
		{
            if (_server == null) throw new NotConnectedException();

            // dispose of all subscriptions first.
            if (_subscriptions != null)
			{
				foreach (TsCDaSubscription subscription in _subscriptions)
				{
					subscription.Dispose();
				}

				_subscriptions = null;
			}

			// disconnect from server.
			base.Disconnect();
		}

		/// <summary>Returns the filters applied by the server to any item results returned to the client.</summary>
		/// <returns>A bit mask indicating which fields should be returned in any item results.</returns>
		public int GetResultFilters()
		{
            if (_server == null) throw new NotConnectedException();

            // update local cache.
            _filters = ((ITsDaServer)_server).GetResultFilters();

			// return filters.
			return _filters;
		}

		/// <summary>Sets the filters applied by the server to any item results returned to the client.</summary>
		/// <param name="filters">A bit mask indicating which fields should be returned in any item results.</param>
		public void SetResultFilters(int filters)
		{
            if (_server == null) throw new NotConnectedException();

            // set filters on server.
            ((ITsDaServer)_server).SetResultFilters(filters);

			// cache updated filters.
			_filters = filters;
		}

        /// <summary>Returns the current server status.</summary>
        /// <returns>The current server status.</returns>
        public OpcServerStatus GetServerStatus()
        {
            if (_server == null) throw new NotConnectedException();

            OpcServerStatus status = ((ITsDaServer)_server).GetServerStatus();

            if (status != null)
            {
                if (status.StatusInfo == null)
                {
                    status.StatusInfo = GetString(String.Format("serverState.{0}", status.ServerState));
                }
            }
            else
            {
                throw new NotConnectedException();
            }

            return status;
        }

		/// <summary>Reads the current values for a set of items.</summary>
		/// <returns>The results of the read operation for each item.</returns>
		/// <requirements>OPC XML-DA Server or OPC Data Access Server V3.x</requirements>
		/// <param name="items">The set of items to read.</param>
		public TsCDaItemValueResult[] Read(TsCDaItem[] items)
		{
            if (_server == null) throw new NotConnectedException();

            return ((ITsDaServer)_server).Read(items);
		}

		/// <summary>Writes the value, quality and timestamp for a set of items.</summary>
		/// <returns>The results of the write operation for each item.</returns>
		/// <requirements>OPC XML-DA Server or OPC Data Access Server V3.x</requirements>
		/// <param name="items">The set of item values to write.</param>
		public OpcItemResult[] Write(TsCDaItemValue[] items)
		{
            if (_server == null) throw new NotConnectedException();

            return ((ITsDaServer)_server).Write(items);
		}

		/// <summary>
		/// Creates a new subscription.
		/// </summary>
		/// <returns>The new subscription object.</returns>
		/// <requirements>OPC XML-DA Server or OPC Data Access Server V2.x / V3.x</requirements>
		/// <param name="state">The initial state of the subscription.</param>
		public virtual ITsCDaSubscription CreateSubscription(TsCDaSubscriptionState state)
		{
			if (state == null) throw new ArgumentNullException("state");
            if (_server == null) throw new NotConnectedException();

            // create subscription on server.
            ITsCDaSubscription subscription = ((ITsDaServer)_server).CreateSubscription(state);

			// set filters.
			subscription.SetResultFilters(_filters);

			// append new subscription to existing list.
			TsCDaSubscriptionCollection subscriptions = new TsCDaSubscriptionCollection();

			if (_subscriptions != null)
			{
				foreach (TsCDaSubscription value in _subscriptions)
				{
					subscriptions.Add(value);
				}
			}

			subscriptions.Add(CreateSubscription(subscription));

			// save new subscription list.
			_subscriptions = subscriptions;

			// return new subscription.
			return _subscriptions[_subscriptions.Count - 1];
		}

		/// <summary>
		/// Creates a new instance of the appropriate subcription object.
		/// </summary>
		/// <param name="subscription">The remote subscription object.</param>
		protected virtual TsCDaSubscription CreateSubscription(ITsCDaSubscription subscription)
		{
			return new TsCDaSubscription(this, subscription);
		}

		/// <summary>Cancels a subscription and releases all resources allocated for it.</summary>
		/// <requirements>OPC XML-DA Server or OPC Data Access Server V2.x / V3.x</requirements>
		/// <param name="subscription">The subscription to cancel.</param>
		public virtual void CancelSubscription(ITsCDaSubscription subscription)
		{
			if (subscription == null) throw new ArgumentNullException("subscription");
            if (_server == null) throw new NotConnectedException();

            // validate argument.
            if (!typeof(TsCDaSubscription).IsInstanceOfType(subscription))
			{
				throw new ArgumentException("Incorrect object type.", "subscription");
			}

			if (!Equals(((TsCDaSubscription)subscription).Server))
			{
				throw new ArgumentException("Server subscription.", "subscription");
			}

			// search for subscription in list of subscriptions.
			TsCDaSubscriptionCollection subscriptions = new TsCDaSubscriptionCollection();

			foreach (TsCDaSubscription current in _subscriptions)
			{
				if (!subscription.Equals(current))
				{
					subscriptions.Add(current);
					continue;
				}
			}

			// check if subscription was not found.
			if (subscriptions.Count == _subscriptions.Count)
			{
				throw new ArgumentException("Subscription not found.", "subscription");
			}

			// remove subscription from list of subscriptions.
			_subscriptions = subscriptions;

			// cancel subscription on server.
			((ITsDaServer)_server).CancelSubscription(((TsCDaSubscription)subscription)._subscription);
		}

        /// <summary>Fetches all the childrens of the root branch that meet the filter criteria.</summary>
        /// <returns>The set of elements found.</returns>
        /// <requirements>OPC XML-DA Server or OPC Data Access Server V2.x / V3.x</requirements>
        /// <param name="filters">The filters to use to limit the set of child elements returned.</param>
        private TsCDaBrowseElement[] Browse(
            TsCDaBrowseFilters filters)
        {
            if (_server == null) throw new NotConnectedException();
            Da.TsCDaBrowsePosition position;
            List<TsCDaBrowseElement> elementsList = new List<TsCDaBrowseElement>();

            TsCDaBrowseElement[] elements = ((ITsDaServer)_server).Browse(null, filters, out position);

            if (elements != null)
            {
                Browse(elements, filters, ref elementsList);
            }

            return elementsList.ToArray();
        }

        private void Browse(TsCDaBrowseElement[] elements, TsCDaBrowseFilters filters, ref List<TsCDaBrowseElement> elementsList)
        {
            Da.TsCDaBrowsePosition position;

            foreach (TsCDaBrowseElement element in elements)
            {
                if (element.HasChildren)
                {
                    OpcItem itemID = new OpcItem(element.ItemPath, element.ItemName); ;

                    TsCDaBrowseElement[] childElements = ((ITsDaServer)_server).Browse(itemID, filters, out position);
                    if (childElements != null)
                    {
                        Browse(childElements, filters, ref elementsList);
                    }

                }
                else
                {
                    elementsList.Add(element);
                }
            } 
        }

		/// <summary>Fetches the children of a branch that meet the filter criteria.</summary>
		/// <returns>The set of elements found.</returns>
		/// <requirements>OPC XML-DA Server or OPC Data Access Server V2.x / V3.x</requirements>
		/// <param name="itemID">The identifier of branch which is the target of the search.</param>
		/// <param name="filters">The filters to use to limit the set of child elements returned.</param>
		/// <param name="position">An object used to continue a browse that could not be completed.</param>
		public TsCDaBrowseElement[] Browse(
			OpcItem itemID,
			TsCDaBrowseFilters filters,
			out Da.TsCDaBrowsePosition position)
		{
            if (_server == null) throw new NotConnectedException();
			return ((ITsDaServer)_server).Browse(itemID, filters, out position);
		}

		/// <summary>Continues a browse operation with previously specified search criteria.</summary>
		/// <returns>The set of elements found.</returns>
		/// <requirements>OPC XML-DA Server or OPC Data Access Server V2.x / V3.x</requirements>
		/// <param name="position">An object containing the browse operation state information.</param>
		public TsCDaBrowseElement[] BrowseNext(ref Da.TsCDaBrowsePosition position)
		{
            if (_server == null) throw new NotConnectedException();
			return ((ITsDaServer)_server).BrowseNext(ref position);
		}

		/// <summary>Returns the item properties for a set of items.</summary>
		/// <param name="itemIds">A list of item identifiers.</param>
		/// <param name="propertyIDs">A list of properties to fetch for each item.</param>
		/// <param name="returnValues">Whether the property values should be returned with the properties.</param>
		/// <returns>A list of properties for each item.</returns>
		public TsCDaItemPropertyCollection[] GetProperties(
			OpcItem[] itemIds,
			TsDaPropertyID[] propertyIDs,
			bool returnValues)
		{
            if (_server == null) throw new NotConnectedException();
			return ((ITsDaServer)_server).GetProperties(itemIds, propertyIDs, returnValues);
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Private Methods

		/// <summary>
		/// Establishes a subscription based on the template provided.
		/// </summary>
		private TsCDaSubscription EstablishSubscription(TsCDaSubscription template)
		{
			// create subscription.
			TsCDaSubscription subscription = new TsCDaSubscription(this, ((ITsDaServer)_server).CreateSubscription(template.State));

			// set filters.
			subscription.SetResultFilters(template.Filters);

			// add items.
			try
			{
				subscription.AddItems(template.Items);
			}
			catch
			{
				subscription.Dispose();
				subscription = null;
			}

			// return new subscription.
			return subscription;
		}

		#endregion

    }
}

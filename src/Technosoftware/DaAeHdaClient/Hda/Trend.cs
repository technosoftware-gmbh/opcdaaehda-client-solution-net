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
#endregion

namespace Technosoftware.DaAeHdaClient.Hda
{
	/// <summary>
	/// Manages a set of items and a set of read, update, subscribe or playback request parameters. 
	/// </summary>
	[Serializable]
	public class TsCHdaTrend : ISerializable, ICloneable
	{
		///////////////////////////////////////////////////////////////////////
		#region Class Names

		/// <summary>
		/// A set of names for fields used in serialization.
		/// </summary>
		private class Names
		{
			internal const string NAME = "Name";
			internal const string AGGREGATE_ID = "AggregateID";
			internal const string START_TIME = "StartTime";
			internal const string END_TIME = "EndTime";
			internal const string MAX_VALUES = "MaxValues";
			internal const string INCLUDE_BOUNDS = "IncludeBounds";
			internal const string RESAMPLE_INTERVAL = "ResampleInterval";
			internal const string UPDATE_INTERVAL = "UpdateInterval";
			internal const string PLAYBACK_INTERVAL = "PlaybackInterval";
			internal const string PLAYBACK_DURATION = "PlaybackDuration";
			internal const string TIMESTAMPS = "Timestamps";
			internal const string ITEMS = "Items";
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Fields

		private static int _count;

		private Technosoftware.DaAeHdaClient.Hda.TsCHdaServer _server;
		private int _aggregate = TsCHdaAggregateID.NoAggregate;
		private decimal _resampleInterval = 0;
		private TsCHdaItemTimeCollection _timeStamps = new TsCHdaItemTimeCollection();
		private TsCHdaItemCollection _items = new TsCHdaItemCollection();
		private decimal _updateInterval = 0;
		private decimal _playbackInterval = 0;
		private decimal _playbackDuration = 0;

		private IOpcRequest _subscription;
		private IOpcRequest _playback;

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Constructors, Destructor, Initialization

		/// <summary>
		/// Initializes the object with the specified server.
		/// </summary>
		public TsCHdaTrend(TsCHdaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			// save a reference to a server.
			_server = server;

			// create a default name.
			do
			{
				Name = String.Format("Trend{0,2:00}", ++_count);
			}
			while (_server.Trends[Name] != null);
		}

		/// <summary>
		/// Contructs a server by de-serializing its OpcUrl from the stream.
		/// </summary>
		protected TsCHdaTrend(SerializationInfo info, StreamingContext context)
		{
			// deserialize basic parameters.
			Name = (string)info.GetValue(Names.NAME, typeof(string));
			_aggregate = (int)info.GetValue(Names.AGGREGATE_ID, typeof(int));
			StartTime = (TsCHdaTime)info.GetValue(Names.START_TIME, typeof(TsCHdaTime));
			EndTime = (TsCHdaTime)info.GetValue(Names.END_TIME, typeof(TsCHdaTime));
			MaxValues = (int)info.GetValue(Names.MAX_VALUES, typeof(int));
			IncludeBounds = (bool)info.GetValue(Names.INCLUDE_BOUNDS, typeof(bool));
			_resampleInterval = (decimal)info.GetValue(Names.RESAMPLE_INTERVAL, typeof(decimal));
			_updateInterval = (decimal)info.GetValue(Names.UPDATE_INTERVAL, typeof(decimal));
			_playbackInterval = (decimal)info.GetValue(Names.PLAYBACK_INTERVAL, typeof(decimal));
			_playbackDuration = (decimal)info.GetValue(Names.PLAYBACK_DURATION, typeof(decimal));

			// deserialize timestamps.
			DateTime[] timestamps = (DateTime[])info.GetValue(Names.TIMESTAMPS, typeof(DateTime[]));

			if (timestamps != null)
			{
				Array.ForEach(timestamps, timestamp => _timeStamps.Add(timestamp));
			}

			// deserialize items.
			TsCHdaItem[] items = (TsCHdaItem[])info.GetValue(Names.ITEMS, typeof(TsCHdaItem[]));

			if (items != null)
			{
				Array.ForEach(items, item => _items.Add(item));
			}
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Properties

		/// <summary>
		/// The server containing the data in the trend.
		/// </summary>
		public TsCHdaServer Server
		{
			get { return _server; }
		}

		/// <summary>
		/// A name for the trend used to display to the user.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The default aggregate to use for the trend.
		/// </summary>
		public int Aggregate
		{
			get { return _aggregate; }
			set { _aggregate = value; }
		}

		/// <summary>
		/// The start time for the trend.
		/// The <see cref="LicenseHandler.TimeAsUTC">OpcBase.TimeAsUTC</see> property defines
		/// the time format (UTC or local time).
		/// </summary>
		public TsCHdaTime StartTime { get; set; }

		/// <summary>
		/// The end time for the trend.
		/// The <see cref="LicenseHandler.TimeAsUTC">OpcBase.TimeAsUTC</see> property defines
		/// the time format (UTC or local time).
		/// </summary>
		public TsCHdaTime EndTime { get; set; }

		/// <summary>
		/// The maximum number of data points per item in the trend.
		/// </summary>
		public int MaxValues { get; set; }

		/// <summary>
		/// Whether the trend includes the bounding values.
		/// </summary>
		public bool IncludeBounds { get; set; }

		/// <summary>
		/// The resampling interval (in seconds) to use for processed reads.
		/// </summary>
		public decimal ResampleInterval
		{
			get { return _resampleInterval; }
			set { _resampleInterval = value; }
		}

		/// <summary>
		/// The discrete set of timestamps for the trend.
		/// </summary>
		public TsCHdaItemTimeCollection Timestamps
		{
			get { return _timeStamps; }

			set
			{
				if (value == null) throw new ArgumentNullException("value");
				_timeStamps = value;
			}
		}

		/// <summary>
		/// The interval between updates from the server when subscribing to new data.
		/// </summary>
		/// <remarks>This specifies a number of seconds for raw data or the number of resample intervals for processed data.</remarks>
		public decimal UpdateInterval
		{
			get { return _updateInterval; }
			set { _updateInterval = value; }
		}

		/// <summary>
		/// Whether the server is currently sending updates for the trend.
		/// </summary>
		public bool SubscriptionActive
		{
			get { return _subscription != null; }
		}

		/// <summary>
		/// The interval between updates from the server when playing back existing data. 
		/// </summary>
		/// <remarks>This specifies a number of seconds for raw data and for processed data.</remarks>
		public decimal PlaybackInterval
		{
			get { return _playbackInterval; }
			set { _playbackInterval = value; }
		}

		/// <summary>
		/// The amount of data that should be returned with each update when playing back existing data.
		/// </summary>
		/// <remarks>This specifies a number of seconds for raw data or the number of resample intervals for processed data.</remarks>
		public decimal PlaybackDuration
		{
			get { return _playbackDuration; }
			set { _playbackDuration = value; }
		}

		/// <summary>
		/// Whether the server is currently playing data back for the trend.
		/// </summary>
		public bool PlaybackActive
		{
			get { return _playback != null; }
		}

		/// <summary>
		/// The items
		/// </summary>
		public TsCHdaItemCollection Items
		{
			get { return _items; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Public Methods

		/// <summary>
		/// Returns the items in a trend as an array.
		/// </summary>
		public TsCHdaItem[] GetItems()
		{
			TsCHdaItem[] items = new TsCHdaItem[_items.Count];

			for (int ii = 0; ii < _items.Count; ii++)
			{
				items[ii] = _items[ii];
			}

			return items;
		}

		/// <summary>
		/// Creates a handle for an item and adds it to the trend.
		/// </summary>
		public TsCHdaItem AddItem(OpcItem itemID)
		{
			if (itemID == null) throw new ArgumentNullException("itemID");

			// assign client handle.
			if (itemID.ClientHandle == null)
			{
				itemID.ClientHandle = Guid.NewGuid().ToString();
			}

			// create server handle.
			OpcItemResult[] results = _server.CreateItems(new OpcItem[] { itemID });

			// check for valid results.
			if (results == null || results.Length != 1)
			{
				throw new OpcResultException(new OpcResult((int)OpcResult.E_FAIL.Code, OpcResult.FuncCallType.SysFuncCall, null), "The browse operation cannot continue");
			}

			// check result code.
			if (results[0].Result.Failed())
			{
				throw new OpcResultException(results[0].Result, "Could not add item to trend.");
			}

			// add new item.
			TsCHdaItem item = new TsCHdaItem(results[0]);
			_items.Add(item);

			// return new item.
			return item;
		}

		/// <summary>
		/// Removes an item from the trend.
		/// </summary>
		public void RemoveItem(TsCHdaItem item)
		{
			if (item == null) throw new ArgumentNullException("item");

			for (int ii = 0; ii < _items.Count; ii++)
			{
				if (item.Equals(_items[ii]))
				{
					_server.ReleaseItems(new OpcItem[] { item });
					_items.RemoveAt(ii);
					return;
				}
			}

			throw new ArgumentOutOfRangeException("item", item.Key, "Item not found in collection.");
		}

		/// <summary>
		/// Removes all items from the trend.
		/// </summary>
		public void ClearItems()
		{
			_server.ReleaseItems(GetItems());
			_items.Clear();
		}

		#region Read

		/// <summary>
		/// Reads the values for a for all items in the trend.
		/// </summary>
		public TsCHdaItemValueCollection[] Read()
		{
			return Read(GetItems());
		}

		/// <summary>
		/// Reads the values for a for a set of items. 
		/// </summary>
		public TsCHdaItemValueCollection[] Read(TsCHdaItem[] items)
		{
			// read raw data.
			if (Aggregate == TsCHdaAggregateID.NoAggregate)
			{
				return ReadRaw(items);
			}

				// read processed data.
			else
			{
				return ReadProcessed(items);
			}
		}


		/// <summary>
		/// Starts an asynchronous read request for all items in the trend. 
		/// </summary>
		public OpcItemResult[] Read(
			object requestHandle,
			TsCHdaReadValuesCompleteEventHandler callback,
			out IOpcRequest request)
		{
			return Read(GetItems(), requestHandle, callback, out request);
		}


		/// <summary>
		/// Starts an asynchronous read request for a set of items. 
		/// </summary>
		public OpcItemResult[] Read(
			TsCHdaItem[] items,
			object requestHandle,
			TsCHdaReadValuesCompleteEventHandler callback,
			out IOpcRequest request)
		{
			// read raw data.
			if (Aggregate == TsCHdaAggregateID.NoAggregate)
			{
				return ReadRaw(items, requestHandle, callback, out request);
			}

				// read processed data.
			else
			{
				return ReadProcessed(items, requestHandle, callback, out request);
			}
		}

		#endregion

		#region ReadRaw

		/// <summary>
		/// Reads the raw values for a for all items in the trend.
		/// </summary>
		public TsCHdaItemValueCollection[] ReadRaw()
		{
			return ReadRaw(GetItems());
		}

		/// <summary>
		/// Reads the raw values for a for a set of items. 
		/// </summary>
		public TsCHdaItemValueCollection[] ReadRaw(TsCHdaItem[] items)
		{
			TsCHdaItemValueCollection[] results = _server.ReadRaw(
				StartTime,
				EndTime,
				MaxValues,
				IncludeBounds,
				items);

			return results;
		}


		/// <summary>
		/// Starts an asynchronous read raw request for all items in the trend. 
		/// </summary>
		public OpcItemResult[] ReadRaw(
			object requestHandle,
			TsCHdaReadValuesCompleteEventHandler callback,
			out IOpcRequest request)
		{
			return Read(GetItems(), requestHandle, callback, out request);
		}

		/// <summary>
		/// Starts an asynchronous read raw request for a set of items. 
		/// </summary>
		public OpcItemResult[] ReadRaw(
			OpcItem[] items,
			object requestHandle,
			TsCHdaReadValuesCompleteEventHandler callback,
			out IOpcRequest request)
		{
			OpcItemResult[] results = _server.ReadRaw(
				StartTime,
				EndTime,
				MaxValues,
				IncludeBounds,
				items,
				requestHandle,
				callback,
				out request);

			return results;
		}

		#endregion

		#region ReadProcessed

		/// <summary>
		/// Reads the processed values for a for all items in the trend.
		/// </summary>
		public TsCHdaItemValueCollection[] ReadProcessed()
		{
			return ReadProcessed(GetItems());
		}

		/// <summary>
		/// Reads the processed values for a for a set of items. 
		/// </summary>
		public TsCHdaItemValueCollection[] ReadProcessed(TsCHdaItem[] items)
		{
			TsCHdaItem[] localItems = ApplyDefaultAggregate(items);

			TsCHdaItemValueCollection[] results = _server.ReadProcessed(
				StartTime,
				EndTime,
				ResampleInterval,
				localItems);

			return results;
		}


		/// <summary>
		/// Starts an asynchronous read processed request for all items in the trend. 
		/// </summary>
		public OpcItemResult[] ReadProcessed(
			object requestHandle,
			TsCHdaReadValuesCompleteEventHandler callback,
			out IOpcRequest request)
		{
			return ReadProcessed(GetItems(), requestHandle, callback, out request);
		}

		/// <summary>
		/// Starts an asynchronous read processed request for a set of items. 
		/// </summary>
		public OpcItemResult[] ReadProcessed(
			TsCHdaItem[] items,
			object requestHandle,
			TsCHdaReadValuesCompleteEventHandler callback,
			out IOpcRequest request)
		{
			TsCHdaItem[] localItems = ApplyDefaultAggregate(items);

			OpcItemResult[] results = _server.ReadProcessed(
				StartTime,
				EndTime,
				ResampleInterval,
				localItems,
				requestHandle,
				callback,
				out request);

			return results;
		}

		#endregion

		#region Subscribe
        /// <summary>
		/// Establishes a subscription for the trend.
		/// </summary>
		public OpcItemResult[] Subscribe(
			object subscriptionHandle,
			TsCHdaDataUpdateEventHandler callback)
		{
			OpcItemResult[] results = null;

			// subscribe to raw data.
			if (Aggregate == TsCHdaAggregateID.NoAggregate)
			{
				results = _server.AdviseRaw(
					StartTime,
					UpdateInterval,
					GetItems(),
					subscriptionHandle,
					callback,
					out _subscription);
			}

				// subscribe processed data.
			else
			{
				TsCHdaItem[] localItems = ApplyDefaultAggregate(GetItems());

				results = _server.AdviseProcessed(
					StartTime,
					ResampleInterval,
					(int)UpdateInterval,
					localItems,
					subscriptionHandle,
					callback,
					out _subscription);
			}

			return results;
		}

		/// <summary>
		/// Cancels an existing subscription.
		/// </summary>
		public void SubscribeCancel()
		{
			if (_subscription != null)
			{
				_server.CancelRequest(_subscription);
				_subscription = null;
			}
		}

		#endregion

		#region Playback
        /// <summary>
		/// Begins playback of data for a trend.
		/// </summary>
		public OpcItemResult[] Playback(
			object playbackHandle,
			TsCHdaDataUpdateEventHandler callback)
		{
			OpcItemResult[] results = null;

			// playback raw data.
			if (Aggregate == TsCHdaAggregateID.NoAggregate)
			{
				results = _server.PlaybackRaw(
					StartTime,
					EndTime,
					MaxValues,
					PlaybackInterval,
					PlaybackDuration,
					GetItems(),
					playbackHandle,
					callback,
					out _playback);
			}

				// playback processed data.
			else
			{
				TsCHdaItem[] localItems = ApplyDefaultAggregate(GetItems());

				results = _server.PlaybackProcessed(
					StartTime,
					EndTime,
					ResampleInterval,
					(int)PlaybackDuration,
					PlaybackInterval,
					localItems,
					playbackHandle,
					callback,
					out _playback);
			}

			return results;
		}

		/// <summary>
		/// Cancels an existing playback operation.
		/// </summary>
		public void PlaybackCancel()
		{
			if (_playback != null)
			{
				_server.CancelRequest(_playback);
				_playback = null;
			}
		}

		#endregion

		#region ReadModified

		/// <summary>
		/// Reads the modified values for all items in the trend.
		/// </summary>
		public TsCHdaModifiedValueCollection[] ReadModified()
		{
			return ReadModified(GetItems());
		}

		/// <summary>
		/// Reads the modified values for a for a set of items. 
		/// </summary>
		public TsCHdaModifiedValueCollection[] ReadModified(TsCHdaItem[] items)
		{
			TsCHdaModifiedValueCollection[] results = _server.ReadModified(
				StartTime,
				EndTime,
				MaxValues,
				items);

			return results;
		}

		/// <summary>
		/// Starts an asynchronous read modified request for all items in the trend.
		/// </summary>
		public OpcItemResult[] ReadModified(
			object requestHandle,
			TsCHdaReadValuesCompleteEventHandler callback,
			out IOpcRequest request)
		{
			return ReadModified(GetItems(), requestHandle, callback, out request);
		}

		/// <summary>
		/// Starts an asynchronous read modified request for a set of items. 
		/// </summary>
		public OpcItemResult[] ReadModified(
			TsCHdaItem[] items,
			object requestHandle,
			TsCHdaReadValuesCompleteEventHandler callback,
			out IOpcRequest request)
		{
			OpcItemResult[] results = _server.ReadModified(
				StartTime,
				EndTime,
				MaxValues,
				items,
				requestHandle,
				callback,
				out request);

			return results;
		}

		#endregion

		#region ReadAtTime

		/// <summary>
		/// Reads the values at specific times for a for all items in the trend.
		/// </summary>
		public TsCHdaItemValueCollection[] ReadAtTime()
		{
			return ReadAtTime(GetItems());
		}

		/// <summary>
		/// Reads the values at specific times for a for a set of items. 
		/// </summary>
		public TsCHdaItemValueCollection[] ReadAtTime(TsCHdaItem[] items)
		{
			DateTime[] timestamps = new DateTime[Timestamps.Count];

			for (int ii = 0; ii < Timestamps.Count; ii++)
			{
				timestamps[ii] = Timestamps[ii];
			}

			return _server.ReadAtTime(timestamps, items);
		}


		/// <summary>
		/// Starts an asynchronous read values at specific times request for all items in the trend. 
		/// </summary>
		public OpcItemResult[] ReadAtTime(
			object requestHandle,
			TsCHdaReadValuesCompleteEventHandler callback,
			out IOpcRequest request)
		{
			return ReadAtTime(GetItems(), requestHandle, callback, out request);
		}


		/// <summary>
		/// Starts an asynchronous read values at specific times request for a set of items.
		/// </summary>
		public OpcItemResult[] ReadAtTime(
			TsCHdaItem[] items,
			object requestHandle,
			TsCHdaReadValuesCompleteEventHandler callback,
			out IOpcRequest request)
		{
			DateTime[] timestamps = new DateTime[Timestamps.Count];

			for (int ii = 0; ii < Timestamps.Count; ii++)
			{
				timestamps[ii] = Timestamps[ii];
			}

			return _server.ReadAtTime(timestamps, items, requestHandle, callback, out request);
		}

		#endregion

		#region ReadAttributes

		/// <summary>
		/// Reads the attributes at specific times for a for an item. 
		/// </summary>
		public TsCHdaItemAttributeCollection ReadAttributes(OpcItem item, int[] attributeIDs)
		{
			return _server.ReadAttributes(StartTime, EndTime, item, attributeIDs);
		}

		/// <summary>
		/// Starts an asynchronous read attributes at specific times request for an item. 
		/// </summary>
		public TsCHdaResultCollection ReadAttributes(
			OpcItem item,
			int[] attributeIDs,
			object requestHandle,
			TsCHdaReadAttributesCompleteEventHandler callback,
			out IOpcRequest request)
		{
			TsCHdaResultCollection results = _server.ReadAttributes(
				StartTime,
				EndTime,
				item,
				attributeIDs,
				requestHandle,
				callback,
				out request);

			return results;
		}

		#endregion

		#region ReadAnnotations

		/// <summary>
		/// Reads the annotations for a for all items in the trend.
		/// </summary>
		public TsCHdaAnnotationValueCollection[] ReadAnnotations()
		{
			return ReadAnnotations(GetItems());
		}

		/// <summary>
		/// Reads the annotations for a for a set of items. 
		/// </summary>
		public TsCHdaAnnotationValueCollection[] ReadAnnotations(TsCHdaItem[] items)
		{
			TsCHdaAnnotationValueCollection[] results = _server.ReadAnnotations(
				StartTime,
				EndTime,
				items);

			return results;
		}

		/// <summary>
		/// Starts an asynchronous read annotations request for all items in the trend.
		/// </summary>
		public OpcItemResult[] ReadAnnotations(
			object requestHandle,
			TsCHdaReadAnnotationsCompleteEventHandler callback,
			out IOpcRequest request)
		{
			return ReadAnnotations(GetItems(), requestHandle, callback, out request);
		}

		/// <summary>
		/// Starts an asynchronous read annotations request for a set of items. 
		/// </summary>
		public OpcItemResult[] ReadAnnotations(
			TsCHdaItem[] items,
			object requestHandle,
			TsCHdaReadAnnotationsCompleteEventHandler callback,
			out IOpcRequest request)
		{
			OpcItemResult[] results = _server.ReadAnnotations(
				StartTime,
				EndTime,
				items,
				requestHandle,
				callback,
				out request);

			return results;
		}

		#endregion

		#region Delete

		/// <summary>
		/// Deletes the raw values for a for all items in the trend.
		/// </summary>
		public OpcItemResult[] Delete()
		{
			return Delete(GetItems());
		}

		/// <summary>
		/// Deletes the raw values for a for a set of items. 
		/// </summary>
		public OpcItemResult[] Delete(TsCHdaItem[] items)
		{
			OpcItemResult[] results = _server.Delete(
				StartTime,
				EndTime,
				items);

			return results;
		}

		/// <summary>
		/// Starts an asynchronous delete raw request for all items in the trend. 
		/// </summary>
		public OpcItemResult[] Delete(
			object requestHandle,
			TsCHdaUpdateCompleteEventHandler callback,
			out IOpcRequest request)
		{
			return Delete(GetItems(), requestHandle, callback, out request);
		}

		/// <summary>
		/// Starts an asynchronous delete raw request for a set of items. 
		/// </summary>
		public OpcItemResult[] Delete(
			OpcItem[] items,
			object requestHandle,
			TsCHdaUpdateCompleteEventHandler callback,
			out IOpcRequest request)
		{
			OpcItemResult[] results = _server.Delete(
				StartTime,
				EndTime,
				items,
				requestHandle,
				callback,
				out request);

			return results;
		}

		#endregion

		#region DeleteAtTime

		/// <summary>
		/// Deletes the values at specific times for a for all items in the trend.
		/// </summary>
		public TsCHdaResultCollection[] DeleteAtTime()
		{
			return DeleteAtTime(GetItems());
		}

		/// <summary>
		/// Deletes the values at specific times for a for a set of items. 
		/// </summary>
		public TsCHdaResultCollection[] DeleteAtTime(TsCHdaItem[] items)
		{
			TsCHdaItemTimeCollection[] times = new TsCHdaItemTimeCollection[items.Length];

			for (int ii = 0; ii < items.Length; ii++)
			{
				times[ii] = (TsCHdaItemTimeCollection)Timestamps.Clone();

				times[ii].ItemName = items[ii].ItemName;
				times[ii].ItemPath = items[ii].ItemPath;
				times[ii].ClientHandle = items[ii].ClientHandle;
				times[ii].ServerHandle = items[ii].ServerHandle;
			}

			return _server.DeleteAtTime(times);
		}

		/// <summary>
		/// Starts an asynchronous delete values at specific times request for all items in the trend. 
		/// </summary>
		public OpcItemResult[] DeleteAtTime(
			object requestHandle,
			TsCHdaUpdateCompleteEventHandler callback,
			out IOpcRequest request)
		{
			return DeleteAtTime(GetItems(), requestHandle, callback, out request);
		}

		/// <summary>
		/// Starts an asynchronous delete values at specific times request for a set of items.
		/// </summary>
		public OpcItemResult[] DeleteAtTime(
			TsCHdaItem[] items,
			object requestHandle,
			TsCHdaUpdateCompleteEventHandler callback,
			out IOpcRequest request)
		{
			TsCHdaItemTimeCollection[] times = new TsCHdaItemTimeCollection[items.Length];

			for (int ii = 0; ii < items.Length; ii++)
			{
				times[ii] = (TsCHdaItemTimeCollection)Timestamps.Clone();

				times[ii].ItemName = items[ii].ItemName;
				times[ii].ItemPath = items[ii].ItemPath;
				times[ii].ClientHandle = items[ii].ClientHandle;
				times[ii].ServerHandle = items[ii].ServerHandle;
			}

			return _server.DeleteAtTime(times, requestHandle, callback, out request);
		}

		#endregion

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region ISerializable Members

		/// <summary>
		/// Serializes a server into a stream.
		/// </summary>
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// serialize basic parameters.
			info.AddValue(Names.NAME, Name);
			info.AddValue(Names.AGGREGATE_ID, _aggregate);
			info.AddValue(Names.START_TIME, StartTime);
			info.AddValue(Names.END_TIME, EndTime);
			info.AddValue(Names.MAX_VALUES, MaxValues);
			info.AddValue(Names.INCLUDE_BOUNDS, IncludeBounds);
			info.AddValue(Names.RESAMPLE_INTERVAL, _resampleInterval);
			info.AddValue(Names.UPDATE_INTERVAL, _updateInterval);
			info.AddValue(Names.PLAYBACK_INTERVAL, _playbackInterval);
			info.AddValue(Names.PLAYBACK_DURATION, _playbackDuration);

			// serialize timestamps.
			DateTime[] timestamps = null;

			if (_timeStamps.Count > 0)
			{
				timestamps = new DateTime[_timeStamps.Count];

				for (int ii = 0; ii < timestamps.Length; ii++)
				{
					timestamps[ii] = _timeStamps[ii];
				}
			}

			info.AddValue(Names.TIMESTAMPS, timestamps);

			// serialize items.
			TsCHdaItem[] items = null;

			if (_items.Count > 0)
			{
				items = new TsCHdaItem[_items.Count];

				for (int ii = 0; ii < items.Length; ii++)
				{
					items[ii] = _items[ii];
				}
			}

			info.AddValue(Names.ITEMS, items);
		}

		/// <summary>
		/// Used to set the server after the object is deserialized.
		/// </summary>
		internal void SetServer(TsCHdaServer server)
		{
			_server = server;
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region ICloneable Members

		/// <summary>
		/// Creates a deep copy of the object.
		/// </summary>
		public virtual object Clone()
		{
			// clone simple properies.
			TsCHdaTrend clone = (TsCHdaTrend)MemberwiseClone();

			// clone items.
			clone._items = new TsCHdaItemCollection();

			foreach (TsCHdaItem item in _items)
			{
				clone._items.Add(item.Clone());
			}

			// clone timestamps.
			clone._timeStamps = new TsCHdaItemTimeCollection();

			foreach (DateTime timestamp in _timeStamps)
			{
				clone._timeStamps.Add(timestamp);
			}

			// clear dynamic state information.
			clone._subscription = null;
			clone._playback = null;

			return clone;
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Private Methods

		/// <summary>
		/// Creates a copy of the items that have a valid aggregate set.
		/// </summary>
		private TsCHdaItem[] ApplyDefaultAggregate(TsCHdaItem[] items)
		{
			// use interpolative aggregate if none specified for the trend.
			int defaultID = Aggregate;

			if (defaultID == TsCHdaAggregateID.NoAggregate)
			{
				defaultID = TsCHdaAggregateID.Interpolative;
			}

			// apply default aggregate to items that have no aggregate specified.
			TsCHdaItem[] localItems = new TsCHdaItem[items.Length];

			for (int ii = 0; ii < items.Length; ii++)
			{
				localItems[ii] = new TsCHdaItem(items[ii]);

				if (localItems[ii].Aggregate == TsCHdaAggregateID.NoAggregate)
				{
					localItems[ii].Aggregate = defaultID;
				}
			}

			// return updated items.
			return localItems;
		}

		#endregion
	}

}

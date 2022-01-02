#region Copyright (c) 2011-2022 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2022 Technosoftware GmbH. All rights reserved
// Web: http://www.technosoftware.com 
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2022 Technosoftware GmbH. All rights reserved

#region Using Directives
using System;
#endregion

namespace Technosoftware.DaAeHdaClient.Ae
{
	/// <summary>
	/// Describes the state of a subscription.
	/// </summary>
	[Serializable]
	public class TsCAeSubscriptionState : ICloneable
	{
		#region Fields
        private bool active_ = true;
        #endregion

		#region Constructors, Destructor, Initialization
        #endregion

		#region Properties
        /// <summary>
		/// A descriptive name for the subscription.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// A unique identifier for the subscription assigned by the client.
		/// </summary>
		public object ClientHandle { get; set; }

		/// <summary>
		/// Whether the subscription is monitoring for events to send to the client.
		/// </summary>
		public bool Active
		{
			get => active_;
            set => active_ = value;
        }

		/// <summary>
		/// The maximum rate at which the server send event notifications.
		/// </summary>
		public int BufferTime { get; set; }

		/// <summary>
		/// The requested maximum number of events that will be sent in a single callback.
		/// </summary>
		public int MaxSize { get; set; }

		/// <summary>
		/// The maximum period between updates sent to the client.
		/// </summary>
		public int KeepAlive { get; set; }
        #endregion

		#region ICloneable Members
        /// <summary>
		/// Creates a shallow copy of the object.
		/// </summary>
		public virtual object Clone()
		{
			return MemberwiseClone();
		}
        #endregion
	}
}

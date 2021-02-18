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
#endregion

namespace Technosoftware.DaAeHdaClient.Da
{
	/// <summary>
	/// Describes the state of a subscription.
	/// </summary>
	[Serializable]
	public class TsCDaRequest : IOpcRequest
	{
		///////////////////////////////////////////////////////////////////////
		#region Fields

		private ITsCDaSubscription _subscription;
		private object _handle;

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Constructors, Destructor, Initialization

		/// <summary>
		/// Initializes the object with a subscription and a unique id.
		/// </summary>
		public TsCDaRequest(ITsCDaSubscription subscription, object handle)
		{
			_subscription = subscription;
			_handle = handle;
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Properties

		/// <summary>
		/// The subscription processing the request.
		/// </summary>
		public ITsCDaSubscription Subscription
		{
			get { return _subscription; }
		}

		/// <summary>
		/// An unique identifier, assigned by the client, for the request.
		/// </summary>
		public object Handle
		{
			get { return _handle; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////////
		#region Public Methods

		/// <summary>
		/// Cancels the request, if possible.
		/// </summary>
		public void Cancel(TsCDaCancelCompleteEventHandler callback) { _subscription.Cancel(this, callback); }

		#endregion
	}
}

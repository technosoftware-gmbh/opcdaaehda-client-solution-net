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
using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Da;
#endregion

namespace Technosoftware.DaAeHdaClient.Ae
{
    /// <summary>
    /// A notification sent by the server when an event change occurs.
    /// </summary>
    [Serializable]
    public class TsCAeEventNotification : ICloneable
    {
        ///////////////////////////////////////////////////////////////////////
        #region Fields

        private DateTime _time = DateTime.MinValue;
        private TsCAeEventType _eventType = TsCAeEventType.Condition;
        private int _severity = 1;
        private AttributeCollection _attributes = new AttributeCollection();
        private TsCDaQuality _quality = TsCDaQuality.Bad;

        private DateTime _activeTime = DateTime.MinValue;

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region AttributeCollection Class

        /// <summary>
        /// Contains a read-only collection of AttributeValues.
        /// </summary>
        [Serializable]
        public class AttributeCollection : OpcReadOnlyCollection
        {
            /// <summary>
            /// Creates an empty collection.
            /// </summary>
            internal AttributeCollection() : base(new object[0]) { }

            /// <summary>
            /// Creates a collection from an array of objects.
            /// </summary>
            internal AttributeCollection(object[] attributes) : base(attributes) { }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region Properties

        /// <summary>
        /// The handle of the subscription that requested the notification
        /// </summary>
        public object ClientHandle { get; set; }

        /// <summary>
        /// The identifier for the source that generated the event.
        /// </summary>
        public string SourceID { get; set; }

        /// <summary>
        /// The time of the event occurrence.
        /// The <see cref="LicenseHandler.TimeAsUTC">OpcBase.TimeAsUTC</see> property defines
        /// the time format (UTC or local time).
        /// </summary>
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        /// <summary>
        /// Event notification message describing the event.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The type of event that generated the notification.
        /// </summary>
        public TsCAeEventType EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        /// <summary>
        /// The vendor defined category id for the event.
        /// </summary>
        public int EventCategory { get; set; }

        /// <summary>
        /// The severity of the event (1..1000).
        /// </summary>
        public int Severity
        {
            get { return _severity; }
            set { _severity = value; }
        }

        /// <summary>
        /// The name of the condition related to this event notification.
        /// </summary>
        public string ConditionName { get; set; }

        /// <summary>
        /// The name of the current sub-condition, for multi-state conditions.
        /// For a single-state condition, this contains the condition name.
        /// </summary>
        public string SubConditionName { get; set; }

        /// <summary>
        /// The values of the attributes selected for the event subscription. 
        /// </summary>
        public AttributeCollection Attributes
        {
            get { return _attributes; }
        }

        /// <summary>
        /// Indicates which properties of the condition have changed, to have caused the server to send the event notification.
        /// </summary>
        public int ChangeMask { get; set; }

        /// <summary>
        /// Indicates which properties of the condition have changed, to have caused the server to send the event notification.
        /// </summary>
        public string ChangeMaskAsText
        {
            get
            {
                string str = null;

                if ((ChangeMask & (int)0x0001) == 0x0001) str = "Active State, ";
                if ((ChangeMask & (int)0x0002) == 0x0002) str += "Ack State, ";
                if ((ChangeMask & (int)0x0004) == 0x0004) str += "Enable State, ";
                if ((ChangeMask & (int)0x0008) == 0x0005) str += "Quality, ";
                if ((ChangeMask & (int)0x0010) == 0x0010) str += "Serverity, ";
                if ((ChangeMask & (int)0x0020) == 0x0020) str += "Subconditionn, ";
                if ((ChangeMask & (int)0x0040) == 0x0040) str += "Message, ";
                if ((ChangeMask & (int)0x0080) == 0x0080) str += "Attribute";

                return str;
            }
        }

        /// <summary>
        /// A bit mask specifying the new state of the condition.
        /// </summary>
        public int NewState { get; set; }

        /// <summary>
        /// A bit mask specifying the new state of the condition.
        /// </summary>
        public string NewStateAsText
        {
            get
            {
                string str = null;

                if ((NewState & (int)0x0001) == 0x0001)
                {
                    str = "Active, ";
                }
                else
                {
                    str = "Inactive, ";
                }
                if ((NewState & (int)0x0002) == 0x0002)
                {
                    str += "Acked, ";
                }
                else
                {
                    str += "Unacked, ";
                }
                if ((NewState & (int)0x0004) == 0x0004)
                {
                    str += "Enabled";
                }
                else
                {
                    str += "Disabled";
                }

                return str;
            }
        }

        /// <summary>
		/// The quality associated with the condition state.
		/// </summary>
		public TsCDaQuality Quality
		{
			get { return _quality; }
			set { _quality = value; }
		}

        /// <summary>
        /// Whether the related condition requires acknowledgment of this event.
        /// </summary>
        public bool AckRequired { get; set; }

        /// <summary>
        /// The time that the condition became active (for single-state conditions), or the
        /// time of the transition into the current sub-condition (for multi-state conditions). 
        /// The <see cref="LicenseHandler.TimeAsUTC">OpcBase.TimeAsUTC</see> property defines
        /// the time format (UTC or local time).
        /// </summary>
        public DateTime ActiveTime
        {
            get { return _activeTime; }
            set { _activeTime = value; }
        }

        /// <summary>
        /// A server defined cookie associated with the event notification.
        /// </summary>
        public int Cookie { get; set; }

        /// <summary>
        /// For tracking events, this is the actor id for the event notification. 
        /// For condition-related events, this is the acknowledger id passed by the client.
        /// </summary>
        public string ActorID { get; set; }

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region Public Methods


        /// <summary>
        /// Sets the list of attribute values.
        /// </summary>
        public void SetAttributes(object[] attributes)
        {
            if (attributes == null)
            {
                _attributes = new AttributeCollection();
            }
            else
            {
                _attributes = new AttributeCollection(attributes);
            }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region ICloneable Members

        /// <summary>
        /// Creates a deep copy of the object.
        /// </summary>
        public virtual object Clone()
        {
            TsCAeEventNotification clone = (TsCAeEventNotification)MemberwiseClone();

            clone._attributes = (AttributeCollection)_attributes.Clone();

            return clone;
        }

        #endregion

    }
}

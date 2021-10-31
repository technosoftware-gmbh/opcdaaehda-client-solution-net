#region Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
// Web: http://www.technosoftware.com 
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved

using System.Collections;
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A control used to edit the state of a subscription.
    /// </summary>
    public class NotificationCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView attributesLv_;
		private System.Windows.Forms.GroupBox attributesGb_;
		private System.Windows.Forms.Panel generalGb_;
		private System.Windows.Forms.TextBox newStateTb_;
		private System.Windows.Forms.Label newStateLb_;
		private System.Windows.Forms.Label subConditionNameLb_;
		private System.Windows.Forms.TextBox subConditionNameTb_;
		private System.Windows.Forms.Label conditionNameLb_;
		private System.Windows.Forms.TextBox conditionNameTb_;
		private System.Windows.Forms.Label eventCategoryLb_;
		private System.Windows.Forms.TextBox eventCategoryTb_;
		private System.Windows.Forms.Label eventTypeLb_;
		private System.Windows.Forms.TextBox eventTypeTb_;
		private System.Windows.Forms.TextBox timeTb_;
		private System.Windows.Forms.Label timeLb_;
		private System.Windows.Forms.TextBox actorTb_;
		private System.Windows.Forms.TextBox messageTb_;
		private System.Windows.Forms.TextBox ackRequiredTb_;
		private System.Windows.Forms.Label actorLb_;
		private System.Windows.Forms.Label sourceLb_;
		private System.Windows.Forms.Label ackRequiredLb_;
		private System.Windows.Forms.Label messageLb_;
		private System.Windows.Forms.TextBox sourceTb_;
		private System.Windows.Forms.TextBox activeTimeTb_;
		private System.Windows.Forms.Label activeTimeLb_;
		private System.Windows.Forms.TextBox qualityTb_;
		private System.Windows.Forms.Label qualityLb_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public NotificationCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			AddHeader(attributesLv_, "Name");
			AddHeader(attributesLv_, "Value");
			AdjustColumns(attributesLv_);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components_ != null)
				{
					components_.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			attributesGb_ = new System.Windows.Forms.GroupBox();
			attributesLv_ = new System.Windows.Forms.ListView();
			generalGb_ = new System.Windows.Forms.Panel();
			activeTimeTb_ = new System.Windows.Forms.TextBox();
			activeTimeLb_ = new System.Windows.Forms.Label();
			qualityTb_ = new System.Windows.Forms.TextBox();
			qualityLb_ = new System.Windows.Forms.Label();
			newStateTb_ = new System.Windows.Forms.TextBox();
			newStateLb_ = new System.Windows.Forms.Label();
			subConditionNameLb_ = new System.Windows.Forms.Label();
			subConditionNameTb_ = new System.Windows.Forms.TextBox();
			conditionNameLb_ = new System.Windows.Forms.Label();
			conditionNameTb_ = new System.Windows.Forms.TextBox();
			eventCategoryLb_ = new System.Windows.Forms.Label();
			eventCategoryTb_ = new System.Windows.Forms.TextBox();
			eventTypeLb_ = new System.Windows.Forms.Label();
			eventTypeTb_ = new System.Windows.Forms.TextBox();
			timeTb_ = new System.Windows.Forms.TextBox();
			timeLb_ = new System.Windows.Forms.Label();
			actorTb_ = new System.Windows.Forms.TextBox();
			messageTb_ = new System.Windows.Forms.TextBox();
			ackRequiredTb_ = new System.Windows.Forms.TextBox();
			actorLb_ = new System.Windows.Forms.Label();
			sourceLb_ = new System.Windows.Forms.Label();
			ackRequiredLb_ = new System.Windows.Forms.Label();
			messageLb_ = new System.Windows.Forms.Label();
			sourceTb_ = new System.Windows.Forms.TextBox();
			attributesGb_.SuspendLayout();
			generalGb_.SuspendLayout();
			SuspendLayout();
			// 
			// AttributesGB
			// 
			attributesGb_.Controls.Add(attributesLv_);
			attributesGb_.Dock = System.Windows.Forms.DockStyle.Fill;
			attributesGb_.Location = new System.Drawing.Point(0, 284);
			attributesGb_.Name = "attributesGb_";
			attributesGb_.Size = new System.Drawing.Size(544, 184);
			attributesGb_.TabIndex = 0;
			attributesGb_.TabStop = false;
			attributesGb_.Text = "Attributes";
			// 
			// AttributesLV
			// 
			attributesLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			attributesLv_.FullRowSelect = true;
			attributesLv_.Location = new System.Drawing.Point(3, 16);
			attributesLv_.MultiSelect = false;
			attributesLv_.Name = "attributesLv_";
			attributesLv_.Size = new System.Drawing.Size(538, 165);
			attributesLv_.TabIndex = 0;
			attributesLv_.View = System.Windows.Forms.View.Details;
			// 
			// GeneralGB
			// 
			generalGb_.Controls.Add(activeTimeTb_);
			generalGb_.Controls.Add(activeTimeLb_);
			generalGb_.Controls.Add(qualityTb_);
			generalGb_.Controls.Add(qualityLb_);
			generalGb_.Controls.Add(newStateTb_);
			generalGb_.Controls.Add(newStateLb_);
			generalGb_.Controls.Add(subConditionNameLb_);
			generalGb_.Controls.Add(subConditionNameTb_);
			generalGb_.Controls.Add(conditionNameLb_);
			generalGb_.Controls.Add(conditionNameTb_);
			generalGb_.Controls.Add(eventCategoryLb_);
			generalGb_.Controls.Add(eventCategoryTb_);
			generalGb_.Controls.Add(eventTypeLb_);
			generalGb_.Controls.Add(eventTypeTb_);
			generalGb_.Controls.Add(timeTb_);
			generalGb_.Controls.Add(timeLb_);
			generalGb_.Controls.Add(actorTb_);
			generalGb_.Controls.Add(messageTb_);
			generalGb_.Controls.Add(ackRequiredTb_);
			generalGb_.Controls.Add(actorLb_);
			generalGb_.Controls.Add(sourceLb_);
			generalGb_.Controls.Add(ackRequiredLb_);
			generalGb_.Controls.Add(messageLb_);
			generalGb_.Controls.Add(sourceTb_);
			generalGb_.Dock = System.Windows.Forms.DockStyle.Top;
			generalGb_.Location = new System.Drawing.Point(0, 0);
			generalGb_.Name = "generalGb_";
			generalGb_.Size = new System.Drawing.Size(544, 284);
			generalGb_.TabIndex = 13;
			generalGb_.Text = "General";
			// 
			// ActiveTimeTB
			// 
			activeTimeTb_.Location = new System.Drawing.Point(132, 240);
			activeTimeTb_.Name = "activeTimeTb_";
			activeTimeTb_.ReadOnly = true;
			activeTimeTb_.Size = new System.Drawing.Size(132, 20);
			activeTimeTb_.TabIndex = 21;
			activeTimeTb_.Text = "";
			// 
			// ActiveTimeLB
			// 
			activeTimeLb_.Location = new System.Drawing.Point(0, 240);
			activeTimeLb_.Name = "activeTimeLb_";
			activeTimeLb_.Size = new System.Drawing.Size(128, 23);
			activeTimeLb_.TabIndex = 20;
			activeTimeLb_.Text = "Active Time";
			activeTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualityTB
			// 
			qualityTb_.Location = new System.Drawing.Point(132, 216);
			qualityTb_.Name = "qualityTb_";
			qualityTb_.ReadOnly = true;
			qualityTb_.Size = new System.Drawing.Size(132, 20);
			qualityTb_.TabIndex = 19;
			qualityTb_.Text = "";
			// 
			// QualityLB
			// 
			qualityLb_.Location = new System.Drawing.Point(0, 216);
			qualityLb_.Name = "qualityLb_";
			qualityLb_.Size = new System.Drawing.Size(128, 23);
			qualityLb_.TabIndex = 18;
			qualityLb_.Text = "Quality";
			qualityLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NewStateTB
			// 
			newStateTb_.Location = new System.Drawing.Point(132, 168);
			newStateTb_.Name = "newStateTb_";
			newStateTb_.ReadOnly = true;
			newStateTb_.Size = new System.Drawing.Size(212, 20);
			newStateTb_.TabIndex = 15;
			newStateTb_.Text = "";
			// 
			// NewStateLB
			// 
			newStateLb_.Location = new System.Drawing.Point(0, 168);
			newStateLb_.Name = "newStateLb_";
			newStateLb_.Size = new System.Drawing.Size(128, 23);
			newStateLb_.TabIndex = 14;
			newStateLb_.Text = "New State";
			newStateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubConditionNameLB
			// 
			subConditionNameLb_.Location = new System.Drawing.Point(0, 144);
			subConditionNameLb_.Name = "subConditionNameLb_";
			subConditionNameLb_.Size = new System.Drawing.Size(128, 23);
			subConditionNameLb_.TabIndex = 12;
			subConditionNameLb_.Text = "Subcondition Name";
			subConditionNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubConditionNameTB
			// 
			subConditionNameTb_.Location = new System.Drawing.Point(132, 144);
			subConditionNameTb_.Name = "subConditionNameTb_";
			subConditionNameTb_.ReadOnly = true;
			subConditionNameTb_.Size = new System.Drawing.Size(212, 20);
			subConditionNameTb_.TabIndex = 13;
			subConditionNameTb_.Text = "";
			// 
			// ConditionNameLB
			// 
			conditionNameLb_.Location = new System.Drawing.Point(0, 120);
			conditionNameLb_.Name = "conditionNameLb_";
			conditionNameLb_.Size = new System.Drawing.Size(128, 23);
			conditionNameLb_.TabIndex = 10;
			conditionNameLb_.Text = "Condition Name";
			conditionNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionNameTB
			// 
			conditionNameTb_.Location = new System.Drawing.Point(132, 120);
			conditionNameTb_.Name = "conditionNameTb_";
			conditionNameTb_.ReadOnly = true;
			conditionNameTb_.Size = new System.Drawing.Size(212, 20);
			conditionNameTb_.TabIndex = 11;
			conditionNameTb_.Text = "";
			// 
			// EventCategoryLB
			// 
			eventCategoryLb_.Location = new System.Drawing.Point(0, 96);
			eventCategoryLb_.Name = "eventCategoryLb_";
			eventCategoryLb_.Size = new System.Drawing.Size(128, 23);
			eventCategoryLb_.TabIndex = 8;
			eventCategoryLb_.Text = "Event Category";
			eventCategoryLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EventCategoryTB
			// 
			eventCategoryTb_.Location = new System.Drawing.Point(132, 96);
			eventCategoryTb_.Name = "eventCategoryTb_";
			eventCategoryTb_.ReadOnly = true;
			eventCategoryTb_.Size = new System.Drawing.Size(212, 20);
			eventCategoryTb_.TabIndex = 9;
			eventCategoryTb_.Text = "";
			// 
			// EventTypeLB
			// 
			eventTypeLb_.Location = new System.Drawing.Point(0, 72);
			eventTypeLb_.Name = "eventTypeLb_";
			eventTypeLb_.Size = new System.Drawing.Size(128, 23);
			eventTypeLb_.TabIndex = 6;
			eventTypeLb_.Text = "Event Type";
			eventTypeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EventTypeTB
			// 
			eventTypeTb_.Location = new System.Drawing.Point(132, 72);
			eventTypeTb_.Name = "eventTypeTb_";
			eventTypeTb_.ReadOnly = true;
			eventTypeTb_.Size = new System.Drawing.Size(212, 20);
			eventTypeTb_.TabIndex = 7;
			eventTypeTb_.Text = "";
			// 
			// TimeTB
			// 
			timeTb_.Location = new System.Drawing.Point(132, 24);
			timeTb_.Name = "timeTb_";
			timeTb_.ReadOnly = true;
			timeTb_.Size = new System.Drawing.Size(132, 20);
			timeTb_.TabIndex = 3;
			timeTb_.Text = "";
			// 
			// TimeLB
			// 
			timeLb_.Location = new System.Drawing.Point(0, 24);
			timeLb_.Name = "timeLb_";
			timeLb_.Size = new System.Drawing.Size(128, 23);
			timeLb_.TabIndex = 2;
			timeLb_.Text = "Time";
			timeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ActorTB
			// 
			actorTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			actorTb_.Location = new System.Drawing.Point(132, 264);
			actorTb_.Name = "actorTb_";
			actorTb_.ReadOnly = true;
			actorTb_.Size = new System.Drawing.Size(404, 20);
			actorTb_.TabIndex = 23;
			actorTb_.Text = "";
			// 
			// MessageTB
			// 
			messageTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			messageTb_.Location = new System.Drawing.Point(132, 48);
			messageTb_.Name = "messageTb_";
			messageTb_.ReadOnly = true;
			messageTb_.Size = new System.Drawing.Size(404, 20);
			messageTb_.TabIndex = 5;
			messageTb_.Text = "";
			// 
			// AckRequiredTB
			// 
			ackRequiredTb_.Location = new System.Drawing.Point(132, 192);
			ackRequiredTb_.Name = "ackRequiredTb_";
			ackRequiredTb_.ReadOnly = true;
			ackRequiredTb_.Size = new System.Drawing.Size(132, 20);
			ackRequiredTb_.TabIndex = 17;
			ackRequiredTb_.Text = "";
			// 
			// ActorLB
			// 
			actorLb_.Location = new System.Drawing.Point(0, 264);
			actorLb_.Name = "actorLb_";
			actorLb_.Size = new System.Drawing.Size(128, 23);
			actorLb_.TabIndex = 22;
			actorLb_.Text = "Actor ID";
			actorLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SourceLB
			// 
			sourceLb_.Location = new System.Drawing.Point(0, 0);
			sourceLb_.Name = "sourceLb_";
			sourceLb_.Size = new System.Drawing.Size(128, 23);
			sourceLb_.TabIndex = 0;
			sourceLb_.Text = "Source";
			sourceLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AckRequiredLB
			// 
			ackRequiredLb_.Location = new System.Drawing.Point(0, 192);
			ackRequiredLb_.Name = "ackRequiredLb_";
			ackRequiredLb_.Size = new System.Drawing.Size(128, 23);
			ackRequiredLb_.TabIndex = 16;
			ackRequiredLb_.Text = "Ack Requried";
			ackRequiredLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MessageLB
			// 
			messageLb_.Location = new System.Drawing.Point(0, 48);
			messageLb_.Name = "messageLb_";
			messageLb_.Size = new System.Drawing.Size(128, 23);
			messageLb_.TabIndex = 4;
			messageLb_.Text = "Message";
			messageLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SourceTB
			// 
			sourceTb_.Location = new System.Drawing.Point(132, 0);
			sourceTb_.Name = "sourceTb_";
			sourceTb_.ReadOnly = true;
			sourceTb_.Size = new System.Drawing.Size(212, 20);
			sourceTb_.TabIndex = 1;
			sourceTb_.Text = "";
			// 
			// NotificationCtrl
			// 
			Controls.Add(attributesGb_);
			Controls.Add(generalGb_);
			Name = "NotificationCtrl";
			Size = new System.Drawing.Size(544, 468);
			attributesGb_.ResumeLayout(false);
			generalGb_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the notification in the control.
		/// </summary>
		public void ShowNotification(TsCAeSubscription subscription, TsCAeEventNotification notification)
		{
			// check for null value.
			if (notification == null)
			{
				sourceTb_.Text           = "";
				timeTb_.Text             = "";
				messageTb_.Text          = "";
				eventTypeTb_.Text        = "";
				eventCategoryTb_.Text    = "";
				conditionNameTb_.Text    = "";
				subConditionNameTb_.Text = "";
				newStateTb_.Text         = "";
				ackRequiredTb_.Text      = "";
				qualityTb_.Text          = "";
				activeTimeTb_.Text       = "";
				actorTb_.Text            = "";
				
				attributesLv_.Items.Clear();
				return;
			}

			// find category.
			Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category = null;

			try
			{
				Technosoftware.DaAeHdaClient.Ae.TsCAeCategory[] categories = subscription.Server.QueryEventCategories((int)notification.EventType);

				for (int ii = 0; ii < categories.Length; ii++)
				{
					if (categories[ii].ID == notification.EventCategory)
					{
						category = categories[ii];
						break;
					}
				}
			}
			catch
			{
				category = null;
			}
			
			// find attributes.
			ArrayList attributes = new ArrayList();

			try
			{
				// get attribute descriptions.
				Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute[] descriptions = subscription.Server.QueryEventAttributes(notification.EventCategory);

				// get selected attributes.
				int[] attributeIDs = null;
				
				if (subscription.Attributes.Contains(notification.EventCategory))
				{
					attributeIDs = subscription.Attributes[notification.EventCategory].ToArray();
				}

				// find decriptions for selected attributes.
				if (attributeIDs != null)
				{
					for (int ii = 0; ii < attributeIDs.Length; ii++)
					{
						for (int jj = 0; jj < descriptions.Length; jj++)
						{
							if (descriptions[jj].ID == attributeIDs[ii])
							{
								attributes.Add(descriptions[jj]);
								break;
							}
						}
					}
				}
			}
			catch
			{
				// ignore errors.
			}			

			sourceTb_.Text           = notification.SourceID;
			timeTb_.Text             = Technosoftware.DaAeHdaClient.OpcConvert.ToString(notification.Time);
			messageTb_.Text          = notification.Message;
			eventTypeTb_.Text        = Technosoftware.DaAeHdaClient.OpcConvert.ToString(notification.EventType);
			eventCategoryTb_.Text    = (category != null)?category.Name:"";
			conditionNameTb_.Text    = notification.ConditionName;
			subConditionNameTb_.Text = notification.SubConditionName;
			newStateTb_.Text         = "";
			ackRequiredTb_.Text      = Technosoftware.DaAeHdaClient.OpcConvert.ToString(notification.AckRequired);
			qualityTb_.Text          = Technosoftware.DaAeHdaClient.OpcConvert.ToString(notification.Quality);
			activeTimeTb_.Text       = Technosoftware.DaAeHdaClient.OpcConvert.ToString(notification.ActiveTime);
			actorTb_.Text            = notification.ActorID;

			// convert state to a string.
			if ((notification.NewState & (int)TsCAeConditionState.Active) != 0)
			{
				newStateTb_.Text += TsCAeConditionState.Active.ToString();
			}

			if ((notification.NewState & (int)TsCAeConditionState.Enabled) != 0)
			{
				if (newStateTb_.Text != "") newStateTb_.Text += " AND ";
				newStateTb_.Text += TsCAeConditionState.Enabled.ToString();
			}

			if ((notification.NewState & (int)TsCAeConditionState.Acknowledged) != 0)
			{
				if (newStateTb_.Text != "") newStateTb_.Text += " AND ";
				newStateTb_.Text += TsCAeConditionState.Acknowledged.ToString();
			}

			// fill attributes list.
			attributesLv_.Items.Clear();

			for (int ii = 0; ii < notification.Attributes.Count; ii++)
			{
				Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute attribute = (ii < attributes.Count)?(Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute)attributes[ii]:null;

				ListViewItem item = new ListViewItem((attribute != null)?attribute.Name:"Unknown");

				item.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(notification.Attributes[ii]));

				attributesLv_.Items.Add(item);
			}

			AdjustColumns(attributesLv_);
		}

		/// <summary>
		/// Populates the list box with the categories.
		/// </summary>
		private void AddHeader(ListView listview, string name)
		{
            ColumnHeader header = new ColumnHeader
            {
                Text = name
            };
            listview.Columns.Add(header);
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns(ListView listview)
		{
			// adjust column widths.
			for (int ii = 0; ii < listview.Columns.Count; ii++)
			{
				listview.Columns[ii].Width = -2;
			}
		}
		#endregion
	}
}

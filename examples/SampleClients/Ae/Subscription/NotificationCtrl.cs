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
			this.attributesGb_ = new System.Windows.Forms.GroupBox();
			this.attributesLv_ = new System.Windows.Forms.ListView();
			this.generalGb_ = new System.Windows.Forms.Panel();
			this.activeTimeTb_ = new System.Windows.Forms.TextBox();
			this.activeTimeLb_ = new System.Windows.Forms.Label();
			this.qualityTb_ = new System.Windows.Forms.TextBox();
			this.qualityLb_ = new System.Windows.Forms.Label();
			this.newStateTb_ = new System.Windows.Forms.TextBox();
			this.newStateLb_ = new System.Windows.Forms.Label();
			this.subConditionNameLb_ = new System.Windows.Forms.Label();
			this.subConditionNameTb_ = new System.Windows.Forms.TextBox();
			this.conditionNameLb_ = new System.Windows.Forms.Label();
			this.conditionNameTb_ = new System.Windows.Forms.TextBox();
			this.eventCategoryLb_ = new System.Windows.Forms.Label();
			this.eventCategoryTb_ = new System.Windows.Forms.TextBox();
			this.eventTypeLb_ = new System.Windows.Forms.Label();
			this.eventTypeTb_ = new System.Windows.Forms.TextBox();
			this.timeTb_ = new System.Windows.Forms.TextBox();
			this.timeLb_ = new System.Windows.Forms.Label();
			this.actorTb_ = new System.Windows.Forms.TextBox();
			this.messageTb_ = new System.Windows.Forms.TextBox();
			this.ackRequiredTb_ = new System.Windows.Forms.TextBox();
			this.actorLb_ = new System.Windows.Forms.Label();
			this.sourceLb_ = new System.Windows.Forms.Label();
			this.ackRequiredLb_ = new System.Windows.Forms.Label();
			this.messageLb_ = new System.Windows.Forms.Label();
			this.sourceTb_ = new System.Windows.Forms.TextBox();
			this.attributesGb_.SuspendLayout();
			this.generalGb_.SuspendLayout();
			this.SuspendLayout();
			// 
			// AttributesGB
			// 
			this.attributesGb_.Controls.Add(this.attributesLv_);
			this.attributesGb_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.attributesGb_.Location = new System.Drawing.Point(0, 284);
			this.attributesGb_.Name = "attributesGb_";
			this.attributesGb_.Size = new System.Drawing.Size(544, 184);
			this.attributesGb_.TabIndex = 0;
			this.attributesGb_.TabStop = false;
			this.attributesGb_.Text = "Attributes";
			// 
			// AttributesLV
			// 
			this.attributesLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.attributesLv_.FullRowSelect = true;
			this.attributesLv_.Location = new System.Drawing.Point(3, 16);
			this.attributesLv_.MultiSelect = false;
			this.attributesLv_.Name = "attributesLv_";
			this.attributesLv_.Size = new System.Drawing.Size(538, 165);
			this.attributesLv_.TabIndex = 0;
			this.attributesLv_.View = System.Windows.Forms.View.Details;
			// 
			// GeneralGB
			// 
			this.generalGb_.Controls.Add(this.activeTimeTb_);
			this.generalGb_.Controls.Add(this.activeTimeLb_);
			this.generalGb_.Controls.Add(this.qualityTb_);
			this.generalGb_.Controls.Add(this.qualityLb_);
			this.generalGb_.Controls.Add(this.newStateTb_);
			this.generalGb_.Controls.Add(this.newStateLb_);
			this.generalGb_.Controls.Add(this.subConditionNameLb_);
			this.generalGb_.Controls.Add(this.subConditionNameTb_);
			this.generalGb_.Controls.Add(this.conditionNameLb_);
			this.generalGb_.Controls.Add(this.conditionNameTb_);
			this.generalGb_.Controls.Add(this.eventCategoryLb_);
			this.generalGb_.Controls.Add(this.eventCategoryTb_);
			this.generalGb_.Controls.Add(this.eventTypeLb_);
			this.generalGb_.Controls.Add(this.eventTypeTb_);
			this.generalGb_.Controls.Add(this.timeTb_);
			this.generalGb_.Controls.Add(this.timeLb_);
			this.generalGb_.Controls.Add(this.actorTb_);
			this.generalGb_.Controls.Add(this.messageTb_);
			this.generalGb_.Controls.Add(this.ackRequiredTb_);
			this.generalGb_.Controls.Add(this.actorLb_);
			this.generalGb_.Controls.Add(this.sourceLb_);
			this.generalGb_.Controls.Add(this.ackRequiredLb_);
			this.generalGb_.Controls.Add(this.messageLb_);
			this.generalGb_.Controls.Add(this.sourceTb_);
			this.generalGb_.Dock = System.Windows.Forms.DockStyle.Top;
			this.generalGb_.Location = new System.Drawing.Point(0, 0);
			this.generalGb_.Name = "generalGb_";
			this.generalGb_.Size = new System.Drawing.Size(544, 284);
			this.generalGb_.TabIndex = 13;
			this.generalGb_.Text = "General";
			// 
			// ActiveTimeTB
			// 
			this.activeTimeTb_.Location = new System.Drawing.Point(132, 240);
			this.activeTimeTb_.Name = "activeTimeTb_";
			this.activeTimeTb_.ReadOnly = true;
			this.activeTimeTb_.Size = new System.Drawing.Size(132, 20);
			this.activeTimeTb_.TabIndex = 21;
			this.activeTimeTb_.Text = "";
			// 
			// ActiveTimeLB
			// 
			this.activeTimeLb_.Location = new System.Drawing.Point(0, 240);
			this.activeTimeLb_.Name = "activeTimeLb_";
			this.activeTimeLb_.Size = new System.Drawing.Size(128, 23);
			this.activeTimeLb_.TabIndex = 20;
			this.activeTimeLb_.Text = "Active Time";
			this.activeTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualityTB
			// 
			this.qualityTb_.Location = new System.Drawing.Point(132, 216);
			this.qualityTb_.Name = "qualityTb_";
			this.qualityTb_.ReadOnly = true;
			this.qualityTb_.Size = new System.Drawing.Size(132, 20);
			this.qualityTb_.TabIndex = 19;
			this.qualityTb_.Text = "";
			// 
			// QualityLB
			// 
			this.qualityLb_.Location = new System.Drawing.Point(0, 216);
			this.qualityLb_.Name = "qualityLb_";
			this.qualityLb_.Size = new System.Drawing.Size(128, 23);
			this.qualityLb_.TabIndex = 18;
			this.qualityLb_.Text = "Quality";
			this.qualityLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NewStateTB
			// 
			this.newStateTb_.Location = new System.Drawing.Point(132, 168);
			this.newStateTb_.Name = "newStateTb_";
			this.newStateTb_.ReadOnly = true;
			this.newStateTb_.Size = new System.Drawing.Size(212, 20);
			this.newStateTb_.TabIndex = 15;
			this.newStateTb_.Text = "";
			// 
			// NewStateLB
			// 
			this.newStateLb_.Location = new System.Drawing.Point(0, 168);
			this.newStateLb_.Name = "newStateLb_";
			this.newStateLb_.Size = new System.Drawing.Size(128, 23);
			this.newStateLb_.TabIndex = 14;
			this.newStateLb_.Text = "New State";
			this.newStateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubConditionNameLB
			// 
			this.subConditionNameLb_.Location = new System.Drawing.Point(0, 144);
			this.subConditionNameLb_.Name = "subConditionNameLb_";
			this.subConditionNameLb_.Size = new System.Drawing.Size(128, 23);
			this.subConditionNameLb_.TabIndex = 12;
			this.subConditionNameLb_.Text = "Subcondition Name";
			this.subConditionNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubConditionNameTB
			// 
			this.subConditionNameTb_.Location = new System.Drawing.Point(132, 144);
			this.subConditionNameTb_.Name = "subConditionNameTb_";
			this.subConditionNameTb_.ReadOnly = true;
			this.subConditionNameTb_.Size = new System.Drawing.Size(212, 20);
			this.subConditionNameTb_.TabIndex = 13;
			this.subConditionNameTb_.Text = "";
			// 
			// ConditionNameLB
			// 
			this.conditionNameLb_.Location = new System.Drawing.Point(0, 120);
			this.conditionNameLb_.Name = "conditionNameLb_";
			this.conditionNameLb_.Size = new System.Drawing.Size(128, 23);
			this.conditionNameLb_.TabIndex = 10;
			this.conditionNameLb_.Text = "Condition Name";
			this.conditionNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionNameTB
			// 
			this.conditionNameTb_.Location = new System.Drawing.Point(132, 120);
			this.conditionNameTb_.Name = "conditionNameTb_";
			this.conditionNameTb_.ReadOnly = true;
			this.conditionNameTb_.Size = new System.Drawing.Size(212, 20);
			this.conditionNameTb_.TabIndex = 11;
			this.conditionNameTb_.Text = "";
			// 
			// EventCategoryLB
			// 
			this.eventCategoryLb_.Location = new System.Drawing.Point(0, 96);
			this.eventCategoryLb_.Name = "eventCategoryLb_";
			this.eventCategoryLb_.Size = new System.Drawing.Size(128, 23);
			this.eventCategoryLb_.TabIndex = 8;
			this.eventCategoryLb_.Text = "Event Category";
			this.eventCategoryLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EventCategoryTB
			// 
			this.eventCategoryTb_.Location = new System.Drawing.Point(132, 96);
			this.eventCategoryTb_.Name = "eventCategoryTb_";
			this.eventCategoryTb_.ReadOnly = true;
			this.eventCategoryTb_.Size = new System.Drawing.Size(212, 20);
			this.eventCategoryTb_.TabIndex = 9;
			this.eventCategoryTb_.Text = "";
			// 
			// EventTypeLB
			// 
			this.eventTypeLb_.Location = new System.Drawing.Point(0, 72);
			this.eventTypeLb_.Name = "eventTypeLb_";
			this.eventTypeLb_.Size = new System.Drawing.Size(128, 23);
			this.eventTypeLb_.TabIndex = 6;
			this.eventTypeLb_.Text = "Event Type";
			this.eventTypeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EventTypeTB
			// 
			this.eventTypeTb_.Location = new System.Drawing.Point(132, 72);
			this.eventTypeTb_.Name = "eventTypeTb_";
			this.eventTypeTb_.ReadOnly = true;
			this.eventTypeTb_.Size = new System.Drawing.Size(212, 20);
			this.eventTypeTb_.TabIndex = 7;
			this.eventTypeTb_.Text = "";
			// 
			// TimeTB
			// 
			this.timeTb_.Location = new System.Drawing.Point(132, 24);
			this.timeTb_.Name = "timeTb_";
			this.timeTb_.ReadOnly = true;
			this.timeTb_.Size = new System.Drawing.Size(132, 20);
			this.timeTb_.TabIndex = 3;
			this.timeTb_.Text = "";
			// 
			// TimeLB
			// 
			this.timeLb_.Location = new System.Drawing.Point(0, 24);
			this.timeLb_.Name = "timeLb_";
			this.timeLb_.Size = new System.Drawing.Size(128, 23);
			this.timeLb_.TabIndex = 2;
			this.timeLb_.Text = "Time";
			this.timeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ActorTB
			// 
			this.actorTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.actorTb_.Location = new System.Drawing.Point(132, 264);
			this.actorTb_.Name = "actorTb_";
			this.actorTb_.ReadOnly = true;
			this.actorTb_.Size = new System.Drawing.Size(404, 20);
			this.actorTb_.TabIndex = 23;
			this.actorTb_.Text = "";
			// 
			// MessageTB
			// 
			this.messageTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.messageTb_.Location = new System.Drawing.Point(132, 48);
			this.messageTb_.Name = "messageTb_";
			this.messageTb_.ReadOnly = true;
			this.messageTb_.Size = new System.Drawing.Size(404, 20);
			this.messageTb_.TabIndex = 5;
			this.messageTb_.Text = "";
			// 
			// AckRequiredTB
			// 
			this.ackRequiredTb_.Location = new System.Drawing.Point(132, 192);
			this.ackRequiredTb_.Name = "ackRequiredTb_";
			this.ackRequiredTb_.ReadOnly = true;
			this.ackRequiredTb_.Size = new System.Drawing.Size(132, 20);
			this.ackRequiredTb_.TabIndex = 17;
			this.ackRequiredTb_.Text = "";
			// 
			// ActorLB
			// 
			this.actorLb_.Location = new System.Drawing.Point(0, 264);
			this.actorLb_.Name = "actorLb_";
			this.actorLb_.Size = new System.Drawing.Size(128, 23);
			this.actorLb_.TabIndex = 22;
			this.actorLb_.Text = "Actor ID";
			this.actorLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SourceLB
			// 
			this.sourceLb_.Location = new System.Drawing.Point(0, 0);
			this.sourceLb_.Name = "sourceLb_";
			this.sourceLb_.Size = new System.Drawing.Size(128, 23);
			this.sourceLb_.TabIndex = 0;
			this.sourceLb_.Text = "Source";
			this.sourceLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AckRequiredLB
			// 
			this.ackRequiredLb_.Location = new System.Drawing.Point(0, 192);
			this.ackRequiredLb_.Name = "ackRequiredLb_";
			this.ackRequiredLb_.Size = new System.Drawing.Size(128, 23);
			this.ackRequiredLb_.TabIndex = 16;
			this.ackRequiredLb_.Text = "Ack Requried";
			this.ackRequiredLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MessageLB
			// 
			this.messageLb_.Location = new System.Drawing.Point(0, 48);
			this.messageLb_.Name = "messageLb_";
			this.messageLb_.Size = new System.Drawing.Size(128, 23);
			this.messageLb_.TabIndex = 4;
			this.messageLb_.Text = "Message";
			this.messageLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SourceTB
			// 
			this.sourceTb_.Location = new System.Drawing.Point(132, 0);
			this.sourceTb_.Name = "sourceTb_";
			this.sourceTb_.ReadOnly = true;
			this.sourceTb_.Size = new System.Drawing.Size(212, 20);
			this.sourceTb_.TabIndex = 1;
			this.sourceTb_.Text = "";
			// 
			// NotificationCtrl
			// 
			this.Controls.Add(this.attributesGb_);
			this.Controls.Add(this.generalGb_);
			this.Name = "NotificationCtrl";
			this.Size = new System.Drawing.Size(544, 468);
			this.attributesGb_.ResumeLayout(false);
			this.generalGb_.ResumeLayout(false);
			this.ResumeLayout(false);

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
			ColumnHeader header = new ColumnHeader();
			header.Text = name;
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

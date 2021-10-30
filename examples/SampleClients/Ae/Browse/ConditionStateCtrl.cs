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

using System.Drawing;
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A control used to edit the state of a subscription.
    /// </summary>
    public class ConditionStateCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TextBox stateTb_;
		private System.Windows.Forms.GroupBox generalGb_;
		private System.Windows.Forms.Label stateLb_;
		private System.Windows.Forms.Label qualityLb_;
		private System.Windows.Forms.Label commentsLb_;
		private System.Windows.Forms.TextBox qualityTb_;
		private System.Windows.Forms.TextBox commentsTb_;
		private System.Windows.Forms.Label lastAcknowledgedLb_;
		private System.Windows.Forms.Label conditionLastActiveLb_;
		private System.Windows.Forms.Label conditionLastInactiveLb_;
		private System.Windows.Forms.GroupBox subConditionsGb_;
		private System.Windows.Forms.Label subConditionLastActiveLb_;
		private System.Windows.Forms.TextBox lastAcknowledgedTb_;
		private System.Windows.Forms.TextBox subConditionLastActiveTb_;
		private System.Windows.Forms.TextBox conditionLastInactiveTb_;
		private System.Windows.Forms.TextBox conditionLastActiveTb_;
		private System.Windows.Forms.ListView subConditionsLv_;
		private System.Windows.Forms.ListView attributesLv_;
		private System.Windows.Forms.GroupBox timestampsGb_;
		private System.Windows.Forms.GroupBox attributesGb_;
		private System.Windows.Forms.TextBox activeSubConditionTb_;
		private System.Windows.Forms.Label activeSubConditionLb_;
		private System.Windows.Forms.TextBox acknowledgerTb_;
		private System.Windows.Forms.Label acknowledgerLb_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ConditionStateCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			AddHeader(subConditionsLv_, "Name");
			AddHeader(subConditionsLv_, "Severity");
			AddHeader(subConditionsLv_, "Definition");
			AddHeader(subConditionsLv_, "Description");
			AdjustColumns(subConditionsLv_);

			AddHeader(attributesLv_, "Name");
			AddHeader(attributesLv_, "Value");
			AddHeader(attributesLv_, "Result");
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
			this.stateTb_ = new System.Windows.Forms.TextBox();
			this.timestampsGb_ = new System.Windows.Forms.GroupBox();
			this.lastAcknowledgedTb_ = new System.Windows.Forms.TextBox();
			this.subConditionLastActiveTb_ = new System.Windows.Forms.TextBox();
			this.conditionLastInactiveTb_ = new System.Windows.Forms.TextBox();
			this.conditionLastActiveTb_ = new System.Windows.Forms.TextBox();
			this.subConditionLastActiveLb_ = new System.Windows.Forms.Label();
			this.lastAcknowledgedLb_ = new System.Windows.Forms.Label();
			this.conditionLastActiveLb_ = new System.Windows.Forms.Label();
			this.conditionLastInactiveLb_ = new System.Windows.Forms.Label();
			this.attributesGb_ = new System.Windows.Forms.GroupBox();
			this.attributesLv_ = new System.Windows.Forms.ListView();
			this.subConditionsGb_ = new System.Windows.Forms.GroupBox();
			this.subConditionsLv_ = new System.Windows.Forms.ListView();
			this.generalGb_ = new System.Windows.Forms.GroupBox();
			this.activeSubConditionTb_ = new System.Windows.Forms.TextBox();
			this.activeSubConditionLb_ = new System.Windows.Forms.Label();
			this.acknowledgerTb_ = new System.Windows.Forms.TextBox();
			this.commentsTb_ = new System.Windows.Forms.TextBox();
			this.qualityTb_ = new System.Windows.Forms.TextBox();
			this.acknowledgerLb_ = new System.Windows.Forms.Label();
			this.stateLb_ = new System.Windows.Forms.Label();
			this.qualityLb_ = new System.Windows.Forms.Label();
			this.commentsLb_ = new System.Windows.Forms.Label();
			this.timestampsGb_.SuspendLayout();
			this.attributesGb_.SuspendLayout();
			this.subConditionsGb_.SuspendLayout();
			this.generalGb_.SuspendLayout();
			this.SuspendLayout();
			// 
			// StateTB
			// 
			this.stateTb_.Location = new System.Drawing.Point(136, 16);
			this.stateTb_.Name = "stateTb_";
			this.stateTb_.ReadOnly = true;
			this.stateTb_.Size = new System.Drawing.Size(212, 20);
			this.stateTb_.TabIndex = 8;
			this.stateTb_.Text = "";
			// 
			// TimestampsGB
			// 
			this.timestampsGb_.Controls.Add(this.lastAcknowledgedTb_);
			this.timestampsGb_.Controls.Add(this.subConditionLastActiveTb_);
			this.timestampsGb_.Controls.Add(this.conditionLastInactiveTb_);
			this.timestampsGb_.Controls.Add(this.conditionLastActiveTb_);
			this.timestampsGb_.Controls.Add(this.subConditionLastActiveLb_);
			this.timestampsGb_.Controls.Add(this.lastAcknowledgedLb_);
			this.timestampsGb_.Controls.Add(this.conditionLastActiveLb_);
			this.timestampsGb_.Controls.Add(this.conditionLastInactiveLb_);
			this.timestampsGb_.Dock = System.Windows.Forms.DockStyle.Top;
			this.timestampsGb_.Location = new System.Drawing.Point(0, 136);
			this.timestampsGb_.Name = "timestampsGb_";
			this.timestampsGb_.Size = new System.Drawing.Size(544, 68);
			this.timestampsGb_.TabIndex = 10;
			this.timestampsGb_.TabStop = false;
			this.timestampsGb_.Text = "Timestamps";
			// 
			// LastAcknowledgedTB
			// 
			this.lastAcknowledgedTb_.Location = new System.Drawing.Point(408, 40);
			this.lastAcknowledgedTb_.Name = "lastAcknowledgedTb_";
			this.lastAcknowledgedTb_.ReadOnly = true;
			this.lastAcknowledgedTb_.Size = new System.Drawing.Size(132, 20);
			this.lastAcknowledgedTb_.TabIndex = 18;
			this.lastAcknowledgedTb_.Text = "";
			// 
			// SubConditionLastActiveTB
			// 
			this.subConditionLastActiveTb_.Location = new System.Drawing.Point(408, 16);
			this.subConditionLastActiveTb_.Name = "subConditionLastActiveTb_";
			this.subConditionLastActiveTb_.ReadOnly = true;
			this.subConditionLastActiveTb_.Size = new System.Drawing.Size(132, 20);
			this.subConditionLastActiveTb_.TabIndex = 17;
			this.subConditionLastActiveTb_.Text = "";
			// 
			// ConditionLastInactiveTB
			// 
			this.conditionLastInactiveTb_.Location = new System.Drawing.Point(136, 40);
			this.conditionLastInactiveTb_.Name = "conditionLastInactiveTb_";
			this.conditionLastInactiveTb_.ReadOnly = true;
			this.conditionLastInactiveTb_.Size = new System.Drawing.Size(132, 20);
			this.conditionLastInactiveTb_.TabIndex = 16;
			this.conditionLastInactiveTb_.Text = "";
			// 
			// ConditionLastActiveTB
			// 
			this.conditionLastActiveTb_.Location = new System.Drawing.Point(136, 16);
			this.conditionLastActiveTb_.Name = "conditionLastActiveTb_";
			this.conditionLastActiveTb_.ReadOnly = true;
			this.conditionLastActiveTb_.Size = new System.Drawing.Size(132, 20);
			this.conditionLastActiveTb_.TabIndex = 15;
			this.conditionLastActiveTb_.Text = "";
			// 
			// SubConditionLastActiveLB
			// 
			this.subConditionLastActiveLb_.Location = new System.Drawing.Point(276, 16);
			this.subConditionLastActiveLb_.Name = "subConditionLastActiveLb_";
			this.subConditionLastActiveLb_.Size = new System.Drawing.Size(128, 23);
			this.subConditionLastActiveLb_.TabIndex = 11;
			this.subConditionLastActiveLb_.Text = "Subcondition Last Active";
			this.subConditionLastActiveLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LastAcknowledgedLB
			// 
			this.lastAcknowledgedLb_.Location = new System.Drawing.Point(276, 40);
			this.lastAcknowledgedLb_.Name = "lastAcknowledgedLb_";
			this.lastAcknowledgedLb_.Size = new System.Drawing.Size(128, 23);
			this.lastAcknowledgedLb_.TabIndex = 1;
			this.lastAcknowledgedLb_.Text = "Last Acknowledged";
			this.lastAcknowledgedLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionLastActiveLB
			// 
			this.conditionLastActiveLb_.Location = new System.Drawing.Point(4, 16);
			this.conditionLastActiveLb_.Name = "conditionLastActiveLb_";
			this.conditionLastActiveLb_.Size = new System.Drawing.Size(128, 23);
			this.conditionLastActiveLb_.TabIndex = 4;
			this.conditionLastActiveLb_.Text = "Condition Last Active";
			this.conditionLastActiveLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionLastInactiveLB
			// 
			this.conditionLastInactiveLb_.Location = new System.Drawing.Point(4, 40);
			this.conditionLastInactiveLb_.Name = "conditionLastInactiveLb_";
			this.conditionLastInactiveLb_.Size = new System.Drawing.Size(128, 23);
			this.conditionLastInactiveLb_.TabIndex = 10;
			this.conditionLastInactiveLb_.Text = "Condition Last Inactive";
			this.conditionLastInactiveLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AttributesGB
			// 
			this.attributesGb_.Controls.Add(this.attributesLv_);
			this.attributesGb_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.attributesGb_.Location = new System.Drawing.Point(0, 328);
			this.attributesGb_.Name = "attributesGb_";
			this.attributesGb_.Size = new System.Drawing.Size(544, 140);
			this.attributesGb_.TabIndex = 11;
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
			this.attributesLv_.Size = new System.Drawing.Size(538, 121);
			this.attributesLv_.TabIndex = 1;
			this.attributesLv_.View = System.Windows.Forms.View.Details;
			// 
			// SubConditionsGB
			// 
			this.subConditionsGb_.Controls.Add(this.subConditionsLv_);
			this.subConditionsGb_.Dock = System.Windows.Forms.DockStyle.Top;
			this.subConditionsGb_.Location = new System.Drawing.Point(0, 204);
			this.subConditionsGb_.Name = "subConditionsGb_";
			this.subConditionsGb_.Size = new System.Drawing.Size(544, 124);
			this.subConditionsGb_.TabIndex = 12;
			this.subConditionsGb_.TabStop = false;
			this.subConditionsGb_.Text = "Subconditions";
			// 
			// SubConditionsLV
			// 
			this.subConditionsLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.subConditionsLv_.FullRowSelect = true;
			this.subConditionsLv_.Location = new System.Drawing.Point(3, 16);
			this.subConditionsLv_.MultiSelect = false;
			this.subConditionsLv_.Name = "subConditionsLv_";
			this.subConditionsLv_.Size = new System.Drawing.Size(538, 105);
			this.subConditionsLv_.TabIndex = 0;
			this.subConditionsLv_.View = System.Windows.Forms.View.Details;
			// 
			// GeneralGB
			// 
			this.generalGb_.Controls.Add(this.activeSubConditionTb_);
			this.generalGb_.Controls.Add(this.activeSubConditionLb_);
			this.generalGb_.Controls.Add(this.acknowledgerTb_);
			this.generalGb_.Controls.Add(this.commentsTb_);
			this.generalGb_.Controls.Add(this.qualityTb_);
			this.generalGb_.Controls.Add(this.acknowledgerLb_);
			this.generalGb_.Controls.Add(this.stateLb_);
			this.generalGb_.Controls.Add(this.qualityLb_);
			this.generalGb_.Controls.Add(this.commentsLb_);
			this.generalGb_.Controls.Add(this.stateTb_);
			this.generalGb_.Dock = System.Windows.Forms.DockStyle.Top;
			this.generalGb_.Location = new System.Drawing.Point(0, 0);
			this.generalGb_.Name = "generalGb_";
			this.generalGb_.Size = new System.Drawing.Size(544, 136);
			this.generalGb_.TabIndex = 13;
			this.generalGb_.TabStop = false;
			this.generalGb_.Text = "General";
			// 
			// ActiveSubConditionTB
			// 
			this.activeSubConditionTb_.Location = new System.Drawing.Point(136, 40);
			this.activeSubConditionTb_.Name = "activeSubConditionTb_";
			this.activeSubConditionTb_.ReadOnly = true;
			this.activeSubConditionTb_.Size = new System.Drawing.Size(212, 20);
			this.activeSubConditionTb_.TabIndex = 16;
			this.activeSubConditionTb_.Text = "";
			// 
			// ActiveSubConditionLB
			// 
			this.activeSubConditionLb_.Location = new System.Drawing.Point(4, 40);
			this.activeSubConditionLb_.Name = "activeSubConditionLb_";
			this.activeSubConditionLb_.Size = new System.Drawing.Size(128, 23);
			this.activeSubConditionLb_.TabIndex = 15;
			this.activeSubConditionLb_.Text = "Active Subcondition";
			this.activeSubConditionLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AcknowledgerTB
			// 
			this.acknowledgerTb_.Location = new System.Drawing.Point(136, 112);
			this.acknowledgerTb_.Name = "acknowledgerTb_";
			this.acknowledgerTb_.ReadOnly = true;
			this.acknowledgerTb_.Size = new System.Drawing.Size(360, 20);
			this.acknowledgerTb_.TabIndex = 14;
			this.acknowledgerTb_.Text = "";
			// 
			// CommentsTB
			// 
			this.commentsTb_.Location = new System.Drawing.Point(136, 88);
			this.commentsTb_.Name = "commentsTb_";
			this.commentsTb_.ReadOnly = true;
			this.commentsTb_.Size = new System.Drawing.Size(360, 20);
			this.commentsTb_.TabIndex = 13;
			this.commentsTb_.Text = "";
			// 
			// QualityTB
			// 
			this.qualityTb_.Location = new System.Drawing.Point(136, 64);
			this.qualityTb_.Name = "qualityTb_";
			this.qualityTb_.ReadOnly = true;
			this.qualityTb_.Size = new System.Drawing.Size(116, 20);
			this.qualityTb_.TabIndex = 12;
			this.qualityTb_.Text = "";
			// 
			// AcknowledgerLB
			// 
			this.acknowledgerLb_.Location = new System.Drawing.Point(4, 112);
			this.acknowledgerLb_.Name = "acknowledgerLb_";
			this.acknowledgerLb_.Size = new System.Drawing.Size(128, 23);
			this.acknowledgerLb_.TabIndex = 11;
			this.acknowledgerLb_.Text = "Acknowledger";
			this.acknowledgerLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StateLB
			// 
			this.stateLb_.Location = new System.Drawing.Point(4, 16);
			this.stateLb_.Name = "stateLb_";
			this.stateLb_.Size = new System.Drawing.Size(128, 23);
			this.stateLb_.TabIndex = 1;
			this.stateLb_.Text = "State";
			this.stateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualityLB
			// 
			this.qualityLb_.Location = new System.Drawing.Point(4, 64);
			this.qualityLb_.Name = "qualityLb_";
			this.qualityLb_.Size = new System.Drawing.Size(128, 23);
			this.qualityLb_.TabIndex = 4;
			this.qualityLb_.Text = "Quality";
			this.qualityLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CommentsLB
			// 
			this.commentsLb_.Location = new System.Drawing.Point(4, 88);
			this.commentsLb_.Name = "commentsLb_";
			this.commentsLb_.Size = new System.Drawing.Size(128, 23);
			this.commentsLb_.TabIndex = 10;
			this.commentsLb_.Text = "Comments";
			this.commentsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionStateCtrl
			// 
			this.Controls.Add(this.attributesGb_);
			this.Controls.Add(this.subConditionsGb_);
			this.Controls.Add(this.timestampsGb_);
			this.Controls.Add(this.generalGb_);
			this.Name = "ConditionStateCtrl";
			this.Size = new System.Drawing.Size(544, 468);
			this.timestampsGb_.ResumeLayout(false);
			this.attributesGb_.ResumeLayout(false);
			this.subConditionsGb_.ResumeLayout(false);
			this.generalGb_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the condition in the control.
		/// </summary>
		public void ShowCondition(Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute[] attributes, TsCAeCondition condition)
		{
			// check for null value.
			if (condition == null)
			{
				qualityTb_.Text                = "";
				commentsTb_.Text               = "";
				acknowledgerTb_.Text           = "";
				activeSubConditionTb_.Text     = "";
				conditionLastActiveTb_.Text    = "";
				conditionLastInactiveTb_.Text  = "";
				subConditionLastActiveTb_.Text = "";
				lastAcknowledgedTb_.Text       = "";
				
				subConditionsLv_.Items.Clear();
				attributesLv_.Items.Clear();
				return;
			}
			
			// convert state to a string.
			stateTb_.Text = "";

			if ((condition.State & (int)TsCAeConditionState.Active) != 0)
			{
				stateTb_.Text += TsCAeConditionState.Active.ToString();
			}

			if ((condition.State & (int)TsCAeConditionState.Enabled) != 0)
			{
				if (stateTb_.Text != "") stateTb_.Text += " AND ";
				stateTb_.Text += TsCAeConditionState.Enabled.ToString();
			}

			if ((condition.State & (int)TsCAeConditionState.Acknowledged) != 0)
			{
				if (stateTb_.Text != "") stateTb_.Text += " AND ";
				stateTb_.Text += TsCAeConditionState.Acknowledged.ToString();
			}

			qualityTb_.Text                = Technosoftware.DaAeHdaClient.OpcConvert.ToString(condition.Quality);
			commentsTb_.Text               = condition.Comment;
			acknowledgerTb_.Text           = condition.AcknowledgerID;
			activeSubConditionTb_.Text     = condition.ActiveSubCondition.Name;
			conditionLastActiveTb_.Text    = Technosoftware.DaAeHdaClient.OpcConvert.ToString(condition.CondLastActive);
			conditionLastInactiveTb_.Text  = Technosoftware.DaAeHdaClient.OpcConvert.ToString(condition.CondLastInactive);
			subConditionLastActiveTb_.Text = Technosoftware.DaAeHdaClient.OpcConvert.ToString(condition.SubCondLastActive);
			lastAcknowledgedTb_.Text       = Technosoftware.DaAeHdaClient.OpcConvert.ToString(condition.LastAckTime);

			// fill sub-conditions list.
			subConditionsLv_.Items.Clear();

			foreach (TsCAeSubCondition subcondition in condition.SubConditions)
			{
				ListViewItem item = new ListViewItem(subcondition.Name);

				if (subcondition.Name == condition.ActiveSubCondition.Name)
				{
					item.SubItems.Add(condition.ActiveSubCondition.Severity.ToString());
					item.SubItems.Add(condition.ActiveSubCondition.Definition);
					item.SubItems.Add(condition.ActiveSubCondition.Description);
					
					item.ForeColor = Color.Red;
				}
				else
				{
					item.SubItems.Add(subcondition.Severity.ToString());
					item.SubItems.Add(subcondition.Definition);
					item.SubItems.Add(subcondition.Description);
				}

				subConditionsLv_.Items.Add(item);
			}

			AdjustColumns(subConditionsLv_);

			// fill attributes list.
			attributesLv_.Items.Clear();

			for (int ii = 0; ii < condition.Attributes.Count; ii++)
			{
				ListViewItem item = new ListViewItem(attributes[ii].Name);

				item.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(condition.Attributes[ii].Value));
				item.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(condition.Attributes[ii].Result));

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

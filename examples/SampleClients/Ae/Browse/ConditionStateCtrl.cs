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
			stateTb_ = new System.Windows.Forms.TextBox();
			timestampsGb_ = new System.Windows.Forms.GroupBox();
			lastAcknowledgedTb_ = new System.Windows.Forms.TextBox();
			subConditionLastActiveTb_ = new System.Windows.Forms.TextBox();
			conditionLastInactiveTb_ = new System.Windows.Forms.TextBox();
			conditionLastActiveTb_ = new System.Windows.Forms.TextBox();
			subConditionLastActiveLb_ = new System.Windows.Forms.Label();
			lastAcknowledgedLb_ = new System.Windows.Forms.Label();
			conditionLastActiveLb_ = new System.Windows.Forms.Label();
			conditionLastInactiveLb_ = new System.Windows.Forms.Label();
			attributesGb_ = new System.Windows.Forms.GroupBox();
			attributesLv_ = new System.Windows.Forms.ListView();
			subConditionsGb_ = new System.Windows.Forms.GroupBox();
			subConditionsLv_ = new System.Windows.Forms.ListView();
			generalGb_ = new System.Windows.Forms.GroupBox();
			activeSubConditionTb_ = new System.Windows.Forms.TextBox();
			activeSubConditionLb_ = new System.Windows.Forms.Label();
			acknowledgerTb_ = new System.Windows.Forms.TextBox();
			commentsTb_ = new System.Windows.Forms.TextBox();
			qualityTb_ = new System.Windows.Forms.TextBox();
			acknowledgerLb_ = new System.Windows.Forms.Label();
			stateLb_ = new System.Windows.Forms.Label();
			qualityLb_ = new System.Windows.Forms.Label();
			commentsLb_ = new System.Windows.Forms.Label();
			timestampsGb_.SuspendLayout();
			attributesGb_.SuspendLayout();
			subConditionsGb_.SuspendLayout();
			generalGb_.SuspendLayout();
			SuspendLayout();
			// 
			// StateTB
			// 
			stateTb_.Location = new System.Drawing.Point(136, 16);
			stateTb_.Name = "stateTb_";
			stateTb_.ReadOnly = true;
			stateTb_.Size = new System.Drawing.Size(212, 20);
			stateTb_.TabIndex = 8;
			stateTb_.Text = "";
			// 
			// TimestampsGB
			// 
			timestampsGb_.Controls.Add(lastAcknowledgedTb_);
			timestampsGb_.Controls.Add(subConditionLastActiveTb_);
			timestampsGb_.Controls.Add(conditionLastInactiveTb_);
			timestampsGb_.Controls.Add(conditionLastActiveTb_);
			timestampsGb_.Controls.Add(subConditionLastActiveLb_);
			timestampsGb_.Controls.Add(lastAcknowledgedLb_);
			timestampsGb_.Controls.Add(conditionLastActiveLb_);
			timestampsGb_.Controls.Add(conditionLastInactiveLb_);
			timestampsGb_.Dock = System.Windows.Forms.DockStyle.Top;
			timestampsGb_.Location = new System.Drawing.Point(0, 136);
			timestampsGb_.Name = "timestampsGb_";
			timestampsGb_.Size = new System.Drawing.Size(544, 68);
			timestampsGb_.TabIndex = 10;
			timestampsGb_.TabStop = false;
			timestampsGb_.Text = "Timestamps";
			// 
			// LastAcknowledgedTB
			// 
			lastAcknowledgedTb_.Location = new System.Drawing.Point(408, 40);
			lastAcknowledgedTb_.Name = "lastAcknowledgedTb_";
			lastAcknowledgedTb_.ReadOnly = true;
			lastAcknowledgedTb_.Size = new System.Drawing.Size(132, 20);
			lastAcknowledgedTb_.TabIndex = 18;
			lastAcknowledgedTb_.Text = "";
			// 
			// SubConditionLastActiveTB
			// 
			subConditionLastActiveTb_.Location = new System.Drawing.Point(408, 16);
			subConditionLastActiveTb_.Name = "subConditionLastActiveTb_";
			subConditionLastActiveTb_.ReadOnly = true;
			subConditionLastActiveTb_.Size = new System.Drawing.Size(132, 20);
			subConditionLastActiveTb_.TabIndex = 17;
			subConditionLastActiveTb_.Text = "";
			// 
			// ConditionLastInactiveTB
			// 
			conditionLastInactiveTb_.Location = new System.Drawing.Point(136, 40);
			conditionLastInactiveTb_.Name = "conditionLastInactiveTb_";
			conditionLastInactiveTb_.ReadOnly = true;
			conditionLastInactiveTb_.Size = new System.Drawing.Size(132, 20);
			conditionLastInactiveTb_.TabIndex = 16;
			conditionLastInactiveTb_.Text = "";
			// 
			// ConditionLastActiveTB
			// 
			conditionLastActiveTb_.Location = new System.Drawing.Point(136, 16);
			conditionLastActiveTb_.Name = "conditionLastActiveTb_";
			conditionLastActiveTb_.ReadOnly = true;
			conditionLastActiveTb_.Size = new System.Drawing.Size(132, 20);
			conditionLastActiveTb_.TabIndex = 15;
			conditionLastActiveTb_.Text = "";
			// 
			// SubConditionLastActiveLB
			// 
			subConditionLastActiveLb_.Location = new System.Drawing.Point(276, 16);
			subConditionLastActiveLb_.Name = "subConditionLastActiveLb_";
			subConditionLastActiveLb_.Size = new System.Drawing.Size(128, 23);
			subConditionLastActiveLb_.TabIndex = 11;
			subConditionLastActiveLb_.Text = "Subcondition Last Active";
			subConditionLastActiveLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LastAcknowledgedLB
			// 
			lastAcknowledgedLb_.Location = new System.Drawing.Point(276, 40);
			lastAcknowledgedLb_.Name = "lastAcknowledgedLb_";
			lastAcknowledgedLb_.Size = new System.Drawing.Size(128, 23);
			lastAcknowledgedLb_.TabIndex = 1;
			lastAcknowledgedLb_.Text = "Last Acknowledged";
			lastAcknowledgedLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionLastActiveLB
			// 
			conditionLastActiveLb_.Location = new System.Drawing.Point(4, 16);
			conditionLastActiveLb_.Name = "conditionLastActiveLb_";
			conditionLastActiveLb_.Size = new System.Drawing.Size(128, 23);
			conditionLastActiveLb_.TabIndex = 4;
			conditionLastActiveLb_.Text = "Condition Last Active";
			conditionLastActiveLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionLastInactiveLB
			// 
			conditionLastInactiveLb_.Location = new System.Drawing.Point(4, 40);
			conditionLastInactiveLb_.Name = "conditionLastInactiveLb_";
			conditionLastInactiveLb_.Size = new System.Drawing.Size(128, 23);
			conditionLastInactiveLb_.TabIndex = 10;
			conditionLastInactiveLb_.Text = "Condition Last Inactive";
			conditionLastInactiveLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AttributesGB
			// 
			attributesGb_.Controls.Add(attributesLv_);
			attributesGb_.Dock = System.Windows.Forms.DockStyle.Fill;
			attributesGb_.Location = new System.Drawing.Point(0, 328);
			attributesGb_.Name = "attributesGb_";
			attributesGb_.Size = new System.Drawing.Size(544, 140);
			attributesGb_.TabIndex = 11;
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
			attributesLv_.Size = new System.Drawing.Size(538, 121);
			attributesLv_.TabIndex = 1;
			attributesLv_.View = System.Windows.Forms.View.Details;
			// 
			// SubConditionsGB
			// 
			subConditionsGb_.Controls.Add(subConditionsLv_);
			subConditionsGb_.Dock = System.Windows.Forms.DockStyle.Top;
			subConditionsGb_.Location = new System.Drawing.Point(0, 204);
			subConditionsGb_.Name = "subConditionsGb_";
			subConditionsGb_.Size = new System.Drawing.Size(544, 124);
			subConditionsGb_.TabIndex = 12;
			subConditionsGb_.TabStop = false;
			subConditionsGb_.Text = "Subconditions";
			// 
			// SubConditionsLV
			// 
			subConditionsLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			subConditionsLv_.FullRowSelect = true;
			subConditionsLv_.Location = new System.Drawing.Point(3, 16);
			subConditionsLv_.MultiSelect = false;
			subConditionsLv_.Name = "subConditionsLv_";
			subConditionsLv_.Size = new System.Drawing.Size(538, 105);
			subConditionsLv_.TabIndex = 0;
			subConditionsLv_.View = System.Windows.Forms.View.Details;
			// 
			// GeneralGB
			// 
			generalGb_.Controls.Add(activeSubConditionTb_);
			generalGb_.Controls.Add(activeSubConditionLb_);
			generalGb_.Controls.Add(acknowledgerTb_);
			generalGb_.Controls.Add(commentsTb_);
			generalGb_.Controls.Add(qualityTb_);
			generalGb_.Controls.Add(acknowledgerLb_);
			generalGb_.Controls.Add(stateLb_);
			generalGb_.Controls.Add(qualityLb_);
			generalGb_.Controls.Add(commentsLb_);
			generalGb_.Controls.Add(stateTb_);
			generalGb_.Dock = System.Windows.Forms.DockStyle.Top;
			generalGb_.Location = new System.Drawing.Point(0, 0);
			generalGb_.Name = "generalGb_";
			generalGb_.Size = new System.Drawing.Size(544, 136);
			generalGb_.TabIndex = 13;
			generalGb_.TabStop = false;
			generalGb_.Text = "General";
			// 
			// ActiveSubConditionTB
			// 
			activeSubConditionTb_.Location = new System.Drawing.Point(136, 40);
			activeSubConditionTb_.Name = "activeSubConditionTb_";
			activeSubConditionTb_.ReadOnly = true;
			activeSubConditionTb_.Size = new System.Drawing.Size(212, 20);
			activeSubConditionTb_.TabIndex = 16;
			activeSubConditionTb_.Text = "";
			// 
			// ActiveSubConditionLB
			// 
			activeSubConditionLb_.Location = new System.Drawing.Point(4, 40);
			activeSubConditionLb_.Name = "activeSubConditionLb_";
			activeSubConditionLb_.Size = new System.Drawing.Size(128, 23);
			activeSubConditionLb_.TabIndex = 15;
			activeSubConditionLb_.Text = "Active Subcondition";
			activeSubConditionLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AcknowledgerTB
			// 
			acknowledgerTb_.Location = new System.Drawing.Point(136, 112);
			acknowledgerTb_.Name = "acknowledgerTb_";
			acknowledgerTb_.ReadOnly = true;
			acknowledgerTb_.Size = new System.Drawing.Size(360, 20);
			acknowledgerTb_.TabIndex = 14;
			acknowledgerTb_.Text = "";
			// 
			// CommentsTB
			// 
			commentsTb_.Location = new System.Drawing.Point(136, 88);
			commentsTb_.Name = "commentsTb_";
			commentsTb_.ReadOnly = true;
			commentsTb_.Size = new System.Drawing.Size(360, 20);
			commentsTb_.TabIndex = 13;
			commentsTb_.Text = "";
			// 
			// QualityTB
			// 
			qualityTb_.Location = new System.Drawing.Point(136, 64);
			qualityTb_.Name = "qualityTb_";
			qualityTb_.ReadOnly = true;
			qualityTb_.Size = new System.Drawing.Size(116, 20);
			qualityTb_.TabIndex = 12;
			qualityTb_.Text = "";
			// 
			// AcknowledgerLB
			// 
			acknowledgerLb_.Location = new System.Drawing.Point(4, 112);
			acknowledgerLb_.Name = "acknowledgerLb_";
			acknowledgerLb_.Size = new System.Drawing.Size(128, 23);
			acknowledgerLb_.TabIndex = 11;
			acknowledgerLb_.Text = "Acknowledger";
			acknowledgerLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StateLB
			// 
			stateLb_.Location = new System.Drawing.Point(4, 16);
			stateLb_.Name = "stateLb_";
			stateLb_.Size = new System.Drawing.Size(128, 23);
			stateLb_.TabIndex = 1;
			stateLb_.Text = "State";
			stateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualityLB
			// 
			qualityLb_.Location = new System.Drawing.Point(4, 64);
			qualityLb_.Name = "qualityLb_";
			qualityLb_.Size = new System.Drawing.Size(128, 23);
			qualityLb_.TabIndex = 4;
			qualityLb_.Text = "Quality";
			qualityLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CommentsLB
			// 
			commentsLb_.Location = new System.Drawing.Point(4, 88);
			commentsLb_.Name = "commentsLb_";
			commentsLb_.Size = new System.Drawing.Size(128, 23);
			commentsLb_.TabIndex = 10;
			commentsLb_.Text = "Comments";
			commentsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionStateCtrl
			// 
			Controls.Add(attributesGb_);
			Controls.Add(subConditionsGb_);
			Controls.Add(timestampsGb_);
			Controls.Add(generalGb_);
			Name = "ConditionStateCtrl";
			Size = new System.Drawing.Size(544, 468);
			timestampsGb_.ResumeLayout(false);
			attributesGb_.ResumeLayout(false);
			subConditionsGb_.ResumeLayout(false);
			generalGb_.ResumeLayout(false);
			ResumeLayout(false);

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

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

using SampleClients.Common;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A control used to edit the filters of a subscription.
    /// </summary>
    public class SubscriptionFiltersEditCtrl : System.Windows.Forms.UserControl, IEditObjectCtrl
	{
		private System.Windows.Forms.NumericUpDown lowSeverityCtrl_;
		private System.Windows.Forms.NumericUpDown highSeverityCtrl_;
		private System.Windows.Forms.Label lowSeverityLb_;
		private System.Windows.Forms.Label highSeverityLb_;
		private System.Windows.Forms.Label simpleEventsLb_;
		private System.Windows.Forms.CheckBox simpleEventChk_;
		private System.Windows.Forms.CheckBox trackingEventsChk_;
		private System.Windows.Forms.Label trackingEventsLb_;
		private System.Windows.Forms.CheckBox conditionEventsChk_;
		private System.Windows.Forms.Label conditionEventsLb_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public SubscriptionFiltersEditCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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
			this.lowSeverityCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.highSeverityCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.lowSeverityLb_ = new System.Windows.Forms.Label();
			this.highSeverityLb_ = new System.Windows.Forms.Label();
			this.simpleEventsLb_ = new System.Windows.Forms.Label();
			this.simpleEventChk_ = new System.Windows.Forms.CheckBox();
			this.trackingEventsChk_ = new System.Windows.Forms.CheckBox();
			this.trackingEventsLb_ = new System.Windows.Forms.Label();
			this.conditionEventsChk_ = new System.Windows.Forms.CheckBox();
			this.conditionEventsLb_ = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.lowSeverityCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.highSeverityCtrl_)).BeginInit();
			this.SuspendLayout();
			// 
			// LowSeverityCTRL
			// 
			this.lowSeverityCtrl_.Location = new System.Drawing.Point(104, 97);
			this.lowSeverityCtrl_.Maximum = new System.Decimal(new int[] {
																			1000,
																			0,
																			0,
																			0});
			this.lowSeverityCtrl_.Minimum = new System.Decimal(new int[] {
																			1,
																			0,
																			0,
																			0});
			this.lowSeverityCtrl_.Name = "lowSeverityCtrl_";
			this.lowSeverityCtrl_.Size = new System.Drawing.Size(72, 20);
			this.lowSeverityCtrl_.TabIndex = 23;
			this.lowSeverityCtrl_.Value = new System.Decimal(new int[] {
																		  1,
																		  0,
																		  0,
																		  0});
			// 
			// HighSeverityCTRL
			// 
			this.highSeverityCtrl_.Location = new System.Drawing.Point(104, 73);
			this.highSeverityCtrl_.Maximum = new System.Decimal(new int[] {
																			 1000,
																			 0,
																			 0,
																			 0});
			this.highSeverityCtrl_.Minimum = new System.Decimal(new int[] {
																			 1,
																			 0,
																			 0,
																			 0});
			this.highSeverityCtrl_.Name = "highSeverityCtrl_";
			this.highSeverityCtrl_.Size = new System.Drawing.Size(72, 20);
			this.highSeverityCtrl_.TabIndex = 22;
			this.highSeverityCtrl_.Value = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			// 
			// LowSeverityLB
			// 
			this.lowSeverityLb_.Location = new System.Drawing.Point(0, 96);
			this.lowSeverityLb_.Name = "lowSeverityLb_";
			this.lowSeverityLb_.TabIndex = 18;
			this.lowSeverityLb_.Text = "Low Severity";
			this.lowSeverityLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// HighSeverityLB
			// 
			this.highSeverityLb_.Location = new System.Drawing.Point(0, 72);
			this.highSeverityLb_.Name = "highSeverityLb_";
			this.highSeverityLb_.TabIndex = 17;
			this.highSeverityLb_.Text = "High Severity";
			this.highSeverityLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SimpleEventsLB
			// 
			this.simpleEventsLb_.Location = new System.Drawing.Point(0, 0);
			this.simpleEventsLb_.Name = "simpleEventsLb_";
			this.simpleEventsLb_.TabIndex = 24;
			this.simpleEventsLb_.Text = "Simple Events";
			this.simpleEventsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SimpleEventCHK
			// 
			this.simpleEventChk_.Location = new System.Drawing.Point(104, -1);
			this.simpleEventChk_.Name = "simpleEventChk_";
			this.simpleEventChk_.Size = new System.Drawing.Size(16, 24);
			this.simpleEventChk_.TabIndex = 25;
			// 
			// TrackingEventsCHK
			// 
			this.trackingEventsChk_.Location = new System.Drawing.Point(104, 23);
			this.trackingEventsChk_.Name = "trackingEventsChk_";
			this.trackingEventsChk_.Size = new System.Drawing.Size(16, 24);
			this.trackingEventsChk_.TabIndex = 27;
			// 
			// TrackingEventsLB
			// 
			this.trackingEventsLb_.Location = new System.Drawing.Point(0, 24);
			this.trackingEventsLb_.Name = "trackingEventsLb_";
			this.trackingEventsLb_.TabIndex = 26;
			this.trackingEventsLb_.Text = "Tracking Events";
			this.trackingEventsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionEventsCHK
			// 
			this.conditionEventsChk_.Location = new System.Drawing.Point(104, 47);
			this.conditionEventsChk_.Name = "conditionEventsChk_";
			this.conditionEventsChk_.Size = new System.Drawing.Size(16, 24);
			this.conditionEventsChk_.TabIndex = 29;
			// 
			// ConditionEventsLB
			// 
			this.conditionEventsLb_.Location = new System.Drawing.Point(0, 48);
			this.conditionEventsLb_.Name = "conditionEventsLb_";
			this.conditionEventsLb_.TabIndex = 28;
			this.conditionEventsLb_.Text = "Condition Events";
			this.conditionEventsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubscriptionFiltersEditCtrl
			// 
			this.Controls.Add(this.conditionEventsChk_);
			this.Controls.Add(this.conditionEventsLb_);
			this.Controls.Add(this.trackingEventsChk_);
			this.Controls.Add(this.trackingEventsLb_);
			this.Controls.Add(this.simpleEventChk_);
			this.Controls.Add(this.simpleEventsLb_);
			this.Controls.Add(this.lowSeverityCtrl_);
			this.Controls.Add(this.highSeverityCtrl_);
			this.Controls.Add(this.lowSeverityLb_);
			this.Controls.Add(this.highSeverityLb_);
			this.Name = "SubscriptionFiltersEditCtrl";
			this.Size = new System.Drawing.Size(176, 120);
			((System.ComponentModel.ISupportInitialize)(this.lowSeverityCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.highSeverityCtrl_)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region IEditObjectCtrl Members
		/// <summary>
		/// Set all fields to default values.
		/// </summary>
		public void SetDefaults()
		{
			simpleEventChk_.Checked     = true;
			trackingEventsChk_.Checked  = true;
			conditionEventsChk_.Checked = true;
			highSeverityCtrl_.Value     = 1000;
			lowSeverityCtrl_.Value      = 1;
		}

		/// <summary>
		/// Copy values from control into object - throw exceptions on error.
		/// </summary>
		public object Get()
		{
			TsCAeSubscriptionFilters filters = new TsCAeSubscriptionFilters();

			filters.EventTypes = 0;

			if (simpleEventChk_.Checked)     filters.EventTypes |= (int)TsCAeEventType.Simple;
			if (trackingEventsChk_.Checked)  filters.EventTypes |= (int)TsCAeEventType.Tracking;
			if (conditionEventsChk_.Checked) filters.EventTypes |= (int)TsCAeEventType.Condition;

			filters.HighSeverity = (int)highSeverityCtrl_.Value;
			filters.LowSeverity  = (int)lowSeverityCtrl_.Value;

			return filters;
		}
		
		/// <summary>
		/// Copy object values into controls.
		/// </summary>
		public void Set(object value)
		{
			// check for null value.
			if (value == null) { SetDefaults(); return; }

			TsCAeSubscriptionFilters filters = (TsCAeSubscriptionFilters)value;
			
			simpleEventChk_.Checked     = (filters.EventTypes & (int)TsCAeEventType.Simple) != 0;
			trackingEventsChk_.Checked  = (filters.EventTypes & (int)TsCAeEventType.Tracking) != 0;
			conditionEventsChk_.Checked = (filters.EventTypes & (int)TsCAeEventType.Condition) != 0;
			highSeverityCtrl_.Value     = filters.HighSeverity;
			lowSeverityCtrl_.Value      = filters.LowSeverity;
		}

		/// <summary>
		/// Creates a new object.
		/// </summary>
		public object Create()
		{
			TsCAeSubscriptionFilters filters = new TsCAeSubscriptionFilters();
			filters.EventTypes = (int)TsCAeEventType.All;
			return filters;
		}
		#endregion
	}
}

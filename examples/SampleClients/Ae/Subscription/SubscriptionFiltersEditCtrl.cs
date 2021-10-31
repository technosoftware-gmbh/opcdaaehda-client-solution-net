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
			lowSeverityCtrl_ = new System.Windows.Forms.NumericUpDown();
			highSeverityCtrl_ = new System.Windows.Forms.NumericUpDown();
			lowSeverityLb_ = new System.Windows.Forms.Label();
			highSeverityLb_ = new System.Windows.Forms.Label();
			simpleEventsLb_ = new System.Windows.Forms.Label();
			simpleEventChk_ = new System.Windows.Forms.CheckBox();
			trackingEventsChk_ = new System.Windows.Forms.CheckBox();
			trackingEventsLb_ = new System.Windows.Forms.Label();
			conditionEventsChk_ = new System.Windows.Forms.CheckBox();
			conditionEventsLb_ = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(lowSeverityCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(highSeverityCtrl_)).BeginInit();
			SuspendLayout();
			// 
			// LowSeverityCTRL
			// 
			lowSeverityCtrl_.Location = new System.Drawing.Point(104, 97);
			lowSeverityCtrl_.Maximum = new System.Decimal(new int[] {
																			1000,
																			0,
																			0,
																			0});
			lowSeverityCtrl_.Minimum = new System.Decimal(new int[] {
																			1,
																			0,
																			0,
																			0});
			lowSeverityCtrl_.Name = "lowSeverityCtrl_";
			lowSeverityCtrl_.Size = new System.Drawing.Size(72, 20);
			lowSeverityCtrl_.TabIndex = 23;
			lowSeverityCtrl_.Value = new System.Decimal(new int[] {
																		  1,
																		  0,
																		  0,
																		  0});
			// 
			// HighSeverityCTRL
			// 
			highSeverityCtrl_.Location = new System.Drawing.Point(104, 73);
			highSeverityCtrl_.Maximum = new System.Decimal(new int[] {
																			 1000,
																			 0,
																			 0,
																			 0});
			highSeverityCtrl_.Minimum = new System.Decimal(new int[] {
																			 1,
																			 0,
																			 0,
																			 0});
			highSeverityCtrl_.Name = "highSeverityCtrl_";
			highSeverityCtrl_.Size = new System.Drawing.Size(72, 20);
			highSeverityCtrl_.TabIndex = 22;
			highSeverityCtrl_.Value = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			// 
			// LowSeverityLB
			// 
			lowSeverityLb_.Location = new System.Drawing.Point(0, 96);
			lowSeverityLb_.Name = "lowSeverityLb_";
			lowSeverityLb_.TabIndex = 18;
			lowSeverityLb_.Text = "Low Severity";
			lowSeverityLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// HighSeverityLB
			// 
			highSeverityLb_.Location = new System.Drawing.Point(0, 72);
			highSeverityLb_.Name = "highSeverityLb_";
			highSeverityLb_.TabIndex = 17;
			highSeverityLb_.Text = "High Severity";
			highSeverityLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SimpleEventsLB
			// 
			simpleEventsLb_.Location = new System.Drawing.Point(0, 0);
			simpleEventsLb_.Name = "simpleEventsLb_";
			simpleEventsLb_.TabIndex = 24;
			simpleEventsLb_.Text = "Simple Events";
			simpleEventsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SimpleEventCHK
			// 
			simpleEventChk_.Location = new System.Drawing.Point(104, -1);
			simpleEventChk_.Name = "simpleEventChk_";
			simpleEventChk_.Size = new System.Drawing.Size(16, 24);
			simpleEventChk_.TabIndex = 25;
			// 
			// TrackingEventsCHK
			// 
			trackingEventsChk_.Location = new System.Drawing.Point(104, 23);
			trackingEventsChk_.Name = "trackingEventsChk_";
			trackingEventsChk_.Size = new System.Drawing.Size(16, 24);
			trackingEventsChk_.TabIndex = 27;
			// 
			// TrackingEventsLB
			// 
			trackingEventsLb_.Location = new System.Drawing.Point(0, 24);
			trackingEventsLb_.Name = "trackingEventsLb_";
			trackingEventsLb_.TabIndex = 26;
			trackingEventsLb_.Text = "Tracking Events";
			trackingEventsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionEventsCHK
			// 
			conditionEventsChk_.Location = new System.Drawing.Point(104, 47);
			conditionEventsChk_.Name = "conditionEventsChk_";
			conditionEventsChk_.Size = new System.Drawing.Size(16, 24);
			conditionEventsChk_.TabIndex = 29;
			// 
			// ConditionEventsLB
			// 
			conditionEventsLb_.Location = new System.Drawing.Point(0, 48);
			conditionEventsLb_.Name = "conditionEventsLb_";
			conditionEventsLb_.TabIndex = 28;
			conditionEventsLb_.Text = "Condition Events";
			conditionEventsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubscriptionFiltersEditCtrl
			// 
			Controls.Add(conditionEventsChk_);
			Controls.Add(conditionEventsLb_);
			Controls.Add(trackingEventsChk_);
			Controls.Add(trackingEventsLb_);
			Controls.Add(simpleEventChk_);
			Controls.Add(simpleEventsLb_);
			Controls.Add(lowSeverityCtrl_);
			Controls.Add(highSeverityCtrl_);
			Controls.Add(lowSeverityLb_);
			Controls.Add(highSeverityLb_);
			Name = "SubscriptionFiltersEditCtrl";
			Size = new System.Drawing.Size(176, 120);
			((System.ComponentModel.ISupportInitialize)(lowSeverityCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(highSeverityCtrl_)).EndInit();
			ResumeLayout(false);

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
            TsCAeSubscriptionFilters filters = new TsCAeSubscriptionFilters
            {
                EventTypes = 0
            };

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
            TsCAeSubscriptionFilters filters = new TsCAeSubscriptionFilters
            {
                EventTypes = (int)TsCAeEventType.All
            };
            return filters;
		}
		#endregion
	}
}

#region Copyright (c) 2011-2023 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2023 Technosoftware GmbH. All rights reserved
// Web: https://technosoftware.com  
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
// 
// The Software is based on the OPC .NET API Sample Code.
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2023 Technosoftware GmbH. All rights reserved

#region Using Directives

using System;

using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Common
{
	/// <summary>
	/// Summary description for TimeCtrl.
	/// </summary>
	public class TimeCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.DateTimePicker absoluteTimeCtrl_;
		private System.Windows.Forms.TextBox offsetTb_;
		private System.Windows.Forms.ComboBox timeTypeCb_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public TimeCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			timeTypeCb_.Items.Clear();
			timeTypeCb_.Items.Add(Absolute);

			foreach (TsCHdaRelativeTime time in Enum.GetValues(typeof(TsCHdaRelativeTime)))
			{
				timeTypeCb_.Items.Add(time);
			}

			timeTypeCb_.SelectedItem = Absolute;
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
			absoluteTimeCtrl_ = new System.Windows.Forms.DateTimePicker();
			timeTypeCb_ = new System.Windows.Forms.ComboBox();
			offsetTb_ = new System.Windows.Forms.TextBox();
			SuspendLayout();
			// 
			// AbsoluteTimeCTRL
			// 
			absoluteTimeCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			absoluteTimeCtrl_.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			absoluteTimeCtrl_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			absoluteTimeCtrl_.Location = new System.Drawing.Point(76, 0);
			absoluteTimeCtrl_.Name = "absoluteTimeCtrl_";
			absoluteTimeCtrl_.Size = new System.Drawing.Size(132, 20);
			absoluteTimeCtrl_.TabIndex = 0;
			// 
			// TimeTypeCB
			// 
			timeTypeCb_.Location = new System.Drawing.Point(0, 0);
			timeTypeCb_.Name = "timeTypeCb_";
			timeTypeCb_.Size = new System.Drawing.Size(72, 21);
			timeTypeCb_.TabIndex = 1;
			timeTypeCb_.Text = "Absolute";
			timeTypeCb_.SelectedIndexChanged += new System.EventHandler(TimeTypeCB_SelectedIndexChanged);
			// 
			// OffsetTB
			// 
			offsetTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			offsetTb_.Location = new System.Drawing.Point(76, 0);
			offsetTb_.Name = "offsetTb_";
			offsetTb_.Size = new System.Drawing.Size(132, 20);
			offsetTb_.TabIndex = 2;
			offsetTb_.Text = "+50MO-6D+1S";
			// 
			// TimeCtrl
			// 
			Controls.Add(timeTypeCb_);
			Controls.Add(absoluteTimeCtrl_);
			Controls.Add(offsetTb_);
			Name = "TimeCtrl";
			Size = new System.Drawing.Size(208, 24);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// A constant used to select absolute time instead of a relative time.
		/// </summary>
		private const string Absolute = "Absolute";

		/// <summary>
		/// Creates a Time object from the current contents of the controls.
		/// </summary>
		public TsCHdaTime Get()
		{
			TsCHdaTime time = new TsCHdaTime();

			if (timeTypeCb_.SelectedItem == (object)Absolute)
			{
				if (absoluteTimeCtrl_.Value > absoluteTimeCtrl_.MinDate)
				{
					time.AbsoluteTime = absoluteTimeCtrl_.Value;
				}
				else
				{
					time.AbsoluteTime = DateTime.MinValue;
				}
			}
			else
			{
				time.BaseTime = (TsCHdaRelativeTime)timeTypeCb_.SelectedItem;
				time.Offsets.Parse(offsetTb_.Text);
			}

			return time;
		}

		/// <summary>
		/// Initializes the control with the time object.
		/// </summary>
		public void Set(TsCHdaTime value)
		{
			if (value == null)
			{
				timeTypeCb_.SelectedIndex = 1;
				absoluteTimeCtrl_.Value   = absoluteTimeCtrl_.MinDate;
				timeTypeCb_.SelectedItem  = TsCHdaRelativeTime.Now;
				offsetTb_.Text            = "";
			}

			else if (value.IsRelative)
			{
				timeTypeCb_.SelectedIndex = 1;
				absoluteTimeCtrl_.Value   = absoluteTimeCtrl_.MinDate;
				timeTypeCb_.SelectedItem  = value.BaseTime;
				offsetTb_.Text            = value.Offsets.ToString();			
			}

			else
			{
				timeTypeCb_.SelectedIndex = 0;
				absoluteTimeCtrl_.Value   = (value.AbsoluteTime < absoluteTimeCtrl_.MinDate)?absoluteTimeCtrl_.MinDate:value.AbsoluteTime;
				timeTypeCb_.SelectedItem  = Absolute;
				offsetTb_.Text            = "";
			}
		}

		/// <summary>
		/// Updates the visibility of the controls based on the selected time type. 
		/// </summary>
		private void TimeTypeCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{		
			absoluteTimeCtrl_.Visible = (timeTypeCb_.SelectedItem == (object)Absolute);
			offsetTb_.Visible = !absoluteTimeCtrl_.Visible;
			
			if (absoluteTimeCtrl_.Visible)
			{
				if (absoluteTimeCtrl_.Value == absoluteTimeCtrl_.MinDate)
				{
					absoluteTimeCtrl_.Value = DateTime.Now;
				}
			}
		}
	}
}

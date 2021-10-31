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
    /// A control used to edit the state of a subscription.
    /// </summary>
    public class SubscriptionStateEditCtrl : System.Windows.Forms.UserControl, IEditObjectCtrl
	{
		private System.Windows.Forms.Label activeLb_;
		private System.Windows.Forms.CheckBox activeCb_;
		private System.Windows.Forms.Label bufferTimeLb_;
		private System.Windows.Forms.NumericUpDown bufferTimeCtrl_;
		private System.Windows.Forms.Label nameLb_;
		private System.Windows.Forms.Label keepAliveLb_;
		private System.Windows.Forms.Label maxSizeLb_;
		private System.Windows.Forms.TextBox nameTb_;
		private System.Windows.Forms.NumericUpDown keepAliveCtrl_;
		private System.Windows.Forms.NumericUpDown maxSizeCtrl_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public SubscriptionStateEditCtrl()
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
			nameLb_ = new System.Windows.Forms.Label();
			activeLb_ = new System.Windows.Forms.Label();
			bufferTimeLb_ = new System.Windows.Forms.Label();
			keepAliveLb_ = new System.Windows.Forms.Label();
			maxSizeLb_ = new System.Windows.Forms.Label();
			nameTb_ = new System.Windows.Forms.TextBox();
			activeCb_ = new System.Windows.Forms.CheckBox();
			bufferTimeCtrl_ = new System.Windows.Forms.NumericUpDown();
			keepAliveCtrl_ = new System.Windows.Forms.NumericUpDown();
			maxSizeCtrl_ = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(bufferTimeCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(keepAliveCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(maxSizeCtrl_)).BeginInit();
			SuspendLayout();
			// 
			// NameLB
			// 
			nameLb_.Location = new System.Drawing.Point(0, 0);
			nameLb_.Name = "nameLb_";
			nameLb_.TabIndex = 0;
			nameLb_.Text = "Name";
			nameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ActiveLB
			// 
			activeLb_.Location = new System.Drawing.Point(0, 24);
			activeLb_.Name = "activeLb_";
			activeLb_.TabIndex = 1;
			activeLb_.Text = "Active";
			activeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BufferTimeLB
			// 
			bufferTimeLb_.Location = new System.Drawing.Point(0, 48);
			bufferTimeLb_.Name = "bufferTimeLb_";
			bufferTimeLb_.TabIndex = 4;
			bufferTimeLb_.Text = "Buffer Time";
			bufferTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// KeepAliveLB
			// 
			keepAliveLb_.Location = new System.Drawing.Point(0, 72);
			keepAliveLb_.Name = "keepAliveLb_";
			keepAliveLb_.TabIndex = 5;
			keepAliveLb_.Text = "Keep Alive Time";
			keepAliveLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxSizeLB
			// 
			maxSizeLb_.Location = new System.Drawing.Point(0, 96);
			maxSizeLb_.Name = "maxSizeLb_";
			maxSizeLb_.TabIndex = 6;
			maxSizeLb_.Text = "Max Size";
			maxSizeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameTB
			// 
			nameTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			nameTb_.Location = new System.Drawing.Point(104, 0);
			nameTb_.Name = "nameTb_";
			nameTb_.Size = new System.Drawing.Size(124, 20);
			nameTb_.TabIndex = 8;
			nameTb_.Text = "";
			// 
			// ActiveCB
			// 
			activeCb_.Location = new System.Drawing.Point(104, 24);
			activeCb_.Name = "activeCb_";
			activeCb_.Size = new System.Drawing.Size(16, 24);
			activeCb_.TabIndex = 9;
			// 
			// BufferTimeCTRL
			// 
			bufferTimeCtrl_.Increment = new System.Decimal(new int[] {
																			 100,
																			 0,
																			 0,
																			 0});
			bufferTimeCtrl_.Location = new System.Drawing.Point(104, 48);
			bufferTimeCtrl_.Maximum = new System.Decimal(new int[] {
																		   1000000000,
																		   0,
																		   0,
																		   0});
			bufferTimeCtrl_.Name = "bufferTimeCtrl_";
			bufferTimeCtrl_.Size = new System.Drawing.Size(72, 20);
			bufferTimeCtrl_.TabIndex = 11;
			// 
			// KeepAliveCTRL
			// 
			keepAliveCtrl_.Increment = new System.Decimal(new int[] {
																			100,
																			0,
																			0,
																			0});
			keepAliveCtrl_.Location = new System.Drawing.Point(104, 72);
			keepAliveCtrl_.Maximum = new System.Decimal(new int[] {
																		  1000000000,
																		  0,
																		  0,
																		  0});
			keepAliveCtrl_.Name = "keepAliveCtrl_";
			keepAliveCtrl_.Size = new System.Drawing.Size(72, 20);
			keepAliveCtrl_.TabIndex = 12;
			// 
			// MaxSizeCTRL
			// 
			maxSizeCtrl_.Increment = new System.Decimal(new int[] {
																		  100,
																		  0,
																		  0,
																		  0});
			maxSizeCtrl_.Location = new System.Drawing.Point(104, 96);
			maxSizeCtrl_.Maximum = new System.Decimal(new int[] {
																		100000,
																		0,
																		0,
																		0});
			maxSizeCtrl_.Name = "maxSizeCtrl_";
			maxSizeCtrl_.Size = new System.Drawing.Size(72, 20);
			maxSizeCtrl_.TabIndex = 14;
			// 
			// SubscriptionStateEditCtrl
			// 
			Controls.Add(maxSizeCtrl_);
			Controls.Add(keepAliveCtrl_);
			Controls.Add(bufferTimeCtrl_);
			Controls.Add(activeCb_);
			Controls.Add(nameTb_);
			Controls.Add(keepAliveLb_);
			Controls.Add(activeLb_);
			Controls.Add(nameLb_);
			Controls.Add(bufferTimeLb_);
			Controls.Add(maxSizeLb_);
			Name = "SubscriptionStateEditCtrl";
			Size = new System.Drawing.Size(232, 120);
			((System.ComponentModel.ISupportInitialize)(bufferTimeCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(keepAliveCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(maxSizeCtrl_)).EndInit();
			ResumeLayout(false);

		}
		#endregion

		#region IEditObjectCtrl Members
		/// <summary>
		/// Set all fields to default values.
		/// </summary>
		public void SetDefaults()
		{
			nameTb_.Text          = null;
			activeCb_.Checked     = true;
			bufferTimeCtrl_.Value = 1000;
			keepAliveCtrl_.Value  = 0;
			maxSizeCtrl_.Value    = 0;
		}

		/// <summary>
		/// Copy values from control into object - throw exceptions on error.
		/// </summary>
		public object Get()
		{
            TsCAeSubscriptionState state = new TsCAeSubscriptionState
            {
                Name = nameTb_.Text,
                Active = activeCb_.Checked,
                BufferTime = (int)bufferTimeCtrl_.Value,
                KeepAlive = (int)keepAliveCtrl_.Value,
                MaxSize = (int)maxSizeCtrl_.Value
            };

            return state;
		}
		
		/// <summary>
		/// Copy object values into controls.
		/// </summary>
		public void Set(object value)
		{
			// check for null value.
			if (value == null) { SetDefaults(); return; }

			TsCAeSubscriptionState state = (TsCAeSubscriptionState)value;
			
			nameTb_.Text          = state.Name;
			activeCb_.Checked     = state.Active;
			bufferTimeCtrl_.Value = (decimal)state.BufferTime;
			keepAliveCtrl_.Value  = (decimal)state.KeepAlive;
			maxSizeCtrl_.Value    = (decimal)state.MaxSize;
		}

		/// <summary>
		/// Creates a new object.
		/// </summary>
		public object Create()
		{
            TsCAeSubscriptionState state = new TsCAeSubscriptionState
            {
                BufferTime = 1000
            };
            return state;
		}
		#endregion
	}
}

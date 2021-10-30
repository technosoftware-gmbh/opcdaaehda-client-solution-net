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
			this.nameLb_ = new System.Windows.Forms.Label();
			this.activeLb_ = new System.Windows.Forms.Label();
			this.bufferTimeLb_ = new System.Windows.Forms.Label();
			this.keepAliveLb_ = new System.Windows.Forms.Label();
			this.maxSizeLb_ = new System.Windows.Forms.Label();
			this.nameTb_ = new System.Windows.Forms.TextBox();
			this.activeCb_ = new System.Windows.Forms.CheckBox();
			this.bufferTimeCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.keepAliveCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.maxSizeCtrl_ = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.bufferTimeCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.keepAliveCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maxSizeCtrl_)).BeginInit();
			this.SuspendLayout();
			// 
			// NameLB
			// 
			this.nameLb_.Location = new System.Drawing.Point(0, 0);
			this.nameLb_.Name = "nameLb_";
			this.nameLb_.TabIndex = 0;
			this.nameLb_.Text = "Name";
			this.nameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ActiveLB
			// 
			this.activeLb_.Location = new System.Drawing.Point(0, 24);
			this.activeLb_.Name = "activeLb_";
			this.activeLb_.TabIndex = 1;
			this.activeLb_.Text = "Active";
			this.activeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BufferTimeLB
			// 
			this.bufferTimeLb_.Location = new System.Drawing.Point(0, 48);
			this.bufferTimeLb_.Name = "bufferTimeLb_";
			this.bufferTimeLb_.TabIndex = 4;
			this.bufferTimeLb_.Text = "Buffer Time";
			this.bufferTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// KeepAliveLB
			// 
			this.keepAliveLb_.Location = new System.Drawing.Point(0, 72);
			this.keepAliveLb_.Name = "keepAliveLb_";
			this.keepAliveLb_.TabIndex = 5;
			this.keepAliveLb_.Text = "Keep Alive Time";
			this.keepAliveLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxSizeLB
			// 
			this.maxSizeLb_.Location = new System.Drawing.Point(0, 96);
			this.maxSizeLb_.Name = "maxSizeLb_";
			this.maxSizeLb_.TabIndex = 6;
			this.maxSizeLb_.Text = "Max Size";
			this.maxSizeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameTB
			// 
			this.nameTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nameTb_.Location = new System.Drawing.Point(104, 0);
			this.nameTb_.Name = "nameTb_";
			this.nameTb_.Size = new System.Drawing.Size(124, 20);
			this.nameTb_.TabIndex = 8;
			this.nameTb_.Text = "";
			// 
			// ActiveCB
			// 
			this.activeCb_.Location = new System.Drawing.Point(104, 24);
			this.activeCb_.Name = "activeCb_";
			this.activeCb_.Size = new System.Drawing.Size(16, 24);
			this.activeCb_.TabIndex = 9;
			// 
			// BufferTimeCTRL
			// 
			this.bufferTimeCtrl_.Increment = new System.Decimal(new int[] {
																			 100,
																			 0,
																			 0,
																			 0});
			this.bufferTimeCtrl_.Location = new System.Drawing.Point(104, 48);
			this.bufferTimeCtrl_.Maximum = new System.Decimal(new int[] {
																		   1000000000,
																		   0,
																		   0,
																		   0});
			this.bufferTimeCtrl_.Name = "bufferTimeCtrl_";
			this.bufferTimeCtrl_.Size = new System.Drawing.Size(72, 20);
			this.bufferTimeCtrl_.TabIndex = 11;
			// 
			// KeepAliveCTRL
			// 
			this.keepAliveCtrl_.Increment = new System.Decimal(new int[] {
																			100,
																			0,
																			0,
																			0});
			this.keepAliveCtrl_.Location = new System.Drawing.Point(104, 72);
			this.keepAliveCtrl_.Maximum = new System.Decimal(new int[] {
																		  1000000000,
																		  0,
																		  0,
																		  0});
			this.keepAliveCtrl_.Name = "keepAliveCtrl_";
			this.keepAliveCtrl_.Size = new System.Drawing.Size(72, 20);
			this.keepAliveCtrl_.TabIndex = 12;
			// 
			// MaxSizeCTRL
			// 
			this.maxSizeCtrl_.Increment = new System.Decimal(new int[] {
																		  100,
																		  0,
																		  0,
																		  0});
			this.maxSizeCtrl_.Location = new System.Drawing.Point(104, 96);
			this.maxSizeCtrl_.Maximum = new System.Decimal(new int[] {
																		100000,
																		0,
																		0,
																		0});
			this.maxSizeCtrl_.Name = "maxSizeCtrl_";
			this.maxSizeCtrl_.Size = new System.Drawing.Size(72, 20);
			this.maxSizeCtrl_.TabIndex = 14;
			// 
			// SubscriptionStateEditCtrl
			// 
			this.Controls.Add(this.maxSizeCtrl_);
			this.Controls.Add(this.keepAliveCtrl_);
			this.Controls.Add(this.bufferTimeCtrl_);
			this.Controls.Add(this.activeCb_);
			this.Controls.Add(this.nameTb_);
			this.Controls.Add(this.keepAliveLb_);
			this.Controls.Add(this.activeLb_);
			this.Controls.Add(this.nameLb_);
			this.Controls.Add(this.bufferTimeLb_);
			this.Controls.Add(this.maxSizeLb_);
			this.Name = "SubscriptionStateEditCtrl";
			this.Size = new System.Drawing.Size(232, 120);
			((System.ComponentModel.ISupportInitialize)(this.bufferTimeCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.keepAliveCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maxSizeCtrl_)).EndInit();
			this.ResumeLayout(false);

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
			TsCAeSubscriptionState state = new TsCAeSubscriptionState();

			state.Name         = nameTb_.Text;
			state.Active       = activeCb_.Checked;
			state.BufferTime   = (int)bufferTimeCtrl_.Value;
			state.KeepAlive    = (int)keepAliveCtrl_.Value;
			state.MaxSize      = (int)maxSizeCtrl_.Value;

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
			TsCAeSubscriptionState state = new TsCAeSubscriptionState();
			state.BufferTime = 1000;
			return state;
		}
		#endregion
	}
}

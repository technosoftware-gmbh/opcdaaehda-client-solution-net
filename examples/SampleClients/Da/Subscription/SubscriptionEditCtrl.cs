#region Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
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
#endregion Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved

#region Using Directives

using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da.Subscription
{
    /// <summary>
    /// A control used to edit the state of a subscription.
    /// </summary>
    public class SubscriptionEditCtrl : System.Windows.Forms.UserControl, IEditObjectCtrl
	{
		private System.Windows.Forms.Label nameLb_;
		private System.Windows.Forms.Label activeLb_;
		private System.Windows.Forms.Label updateRateLb_;
		private System.Windows.Forms.Label keepAliveRateLb_;
		private System.Windows.Forms.Label deadbandLb_;
		private System.Windows.Forms.TextBox nameTb_;
		private System.Windows.Forms.CheckBox activeCb_;
		private System.Windows.Forms.NumericUpDown updateRateCtrl_;
		private System.Windows.Forms.NumericUpDown keepAliveRateCtrl_;
		private System.Windows.Forms.NumericUpDown deadbandCtrl_;
		private System.Windows.Forms.CheckBox keepAliveSpecifiedCb_;
		private System.Windows.Forms.CheckBox deadbandSpecifiedCb_;
		private System.Windows.Forms.Label localeLb_;
		private LocaleCtrl localeCtrl_;
		private System.Windows.Forms.CheckBox localeSpecifiedCb_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public SubscriptionEditCtrl()
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
			this.updateRateLb_ = new System.Windows.Forms.Label();
			this.keepAliveRateLb_ = new System.Windows.Forms.Label();
			this.deadbandLb_ = new System.Windows.Forms.Label();
			this.nameTb_ = new System.Windows.Forms.TextBox();
			this.activeCb_ = new System.Windows.Forms.CheckBox();
			this.updateRateCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.keepAliveRateCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.deadbandCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.keepAliveSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.deadbandSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.localeLb_ = new System.Windows.Forms.Label();
			this.localeCtrl_ = new LocaleCtrl();
			this.localeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.updateRateCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.keepAliveRateCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deadbandCtrl_)).BeginInit();
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
			// UpdateRateLB
			// 
			this.updateRateLb_.Location = new System.Drawing.Point(0, 48);
			this.updateRateLb_.Name = "updateRateLb_";
			this.updateRateLb_.TabIndex = 4;
			this.updateRateLb_.Text = "Update Rate";
			this.updateRateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// KeepAliveRateLB
			// 
			this.keepAliveRateLb_.Location = new System.Drawing.Point(0, 72);
			this.keepAliveRateLb_.Name = "keepAliveRateLb_";
			this.keepAliveRateLb_.TabIndex = 5;
			this.keepAliveRateLb_.Text = "Keep Alive Rate";
			this.keepAliveRateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DeadbandLB
			// 
			this.deadbandLb_.Location = new System.Drawing.Point(0, 96);
			this.deadbandLb_.Name = "deadbandLb_";
			this.deadbandLb_.TabIndex = 6;
			this.deadbandLb_.Text = "Deadband";
			this.deadbandLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameTB
			// 
			this.nameTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nameTb_.Location = new System.Drawing.Point(104, 0);
			this.nameTb_.Name = "nameTb_";
			this.nameTb_.Size = new System.Drawing.Size(128, 20);
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
			// UpdateRateCTRL
			// 
			this.updateRateCtrl_.Increment = new System.Decimal(new int[] {
																			 100,
																			 0,
																			 0,
																			 0});
			this.updateRateCtrl_.Location = new System.Drawing.Point(104, 48);
			this.updateRateCtrl_.Maximum = new System.Decimal(new int[] {
																		   1000000000,
																		   0,
																		   0,
																		   0});
			this.updateRateCtrl_.Name = "updateRateCtrl_";
			this.updateRateCtrl_.Size = new System.Drawing.Size(72, 20);
			this.updateRateCtrl_.TabIndex = 11;
			// 
			// KeepAliveRateCTRL
			// 
			this.keepAliveRateCtrl_.Increment = new System.Decimal(new int[] {
																				100,
																				0,
																				0,
																				0});
			this.keepAliveRateCtrl_.Location = new System.Drawing.Point(104, 72);
			this.keepAliveRateCtrl_.Maximum = new System.Decimal(new int[] {
																			  1000000000,
																			  0,
																			  0,
																			  0});
			this.keepAliveRateCtrl_.Name = "keepAliveRateCtrl_";
			this.keepAliveRateCtrl_.Size = new System.Drawing.Size(72, 20);
			this.keepAliveRateCtrl_.TabIndex = 12;
			// 
			// DeadbandCTRL
			// 
			this.deadbandCtrl_.DecimalPlaces = 1;
			this.deadbandCtrl_.Location = new System.Drawing.Point(104, 96);
			this.deadbandCtrl_.Name = "deadbandCtrl_";
			this.deadbandCtrl_.Size = new System.Drawing.Size(72, 20);
			this.deadbandCtrl_.TabIndex = 14;
			// 
			// KeepAliveSpecifiedCB
			// 
			this.keepAliveSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.keepAliveSpecifiedCb_.Checked = true;
			this.keepAliveSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.keepAliveSpecifiedCb_.Location = new System.Drawing.Point(216, 72);
			this.keepAliveSpecifiedCb_.Name = "keepAliveSpecifiedCb_";
			this.keepAliveSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.keepAliveSpecifiedCb_.TabIndex = 20;
			this.keepAliveSpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// DeadbandSpecifiedCB
			// 
			this.deadbandSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.deadbandSpecifiedCb_.Checked = true;
			this.deadbandSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.deadbandSpecifiedCb_.Location = new System.Drawing.Point(216, 96);
			this.deadbandSpecifiedCb_.Name = "deadbandSpecifiedCb_";
			this.deadbandSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.deadbandSpecifiedCb_.TabIndex = 21;
			this.deadbandSpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// LocaleLB
			// 
			this.localeLb_.Location = new System.Drawing.Point(0, 120);
			this.localeLb_.Name = "localeLb_";
			this.localeLb_.TabIndex = 22;
			this.localeLb_.Text = "Locale";
			this.localeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LocaleCTRL
			// 
			this.localeCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.localeCtrl_.Enabled = false;
			this.localeCtrl_.Locale = "";
			this.localeCtrl_.Location = new System.Drawing.Point(104, 120);
			this.localeCtrl_.Name = "localeCtrl_";
			this.localeCtrl_.Size = new System.Drawing.Size(104, 24);
			this.localeCtrl_.TabIndex = 23;
			// 
			// LocaleSpecifiedCB
			// 
			this.localeSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.localeSpecifiedCb_.Checked = true;
			this.localeSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.localeSpecifiedCb_.Location = new System.Drawing.Point(216, 120);
			this.localeSpecifiedCb_.Name = "localeSpecifiedCb_";
			this.localeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.localeSpecifiedCb_.TabIndex = 24;
			this.localeSpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// SubscriptionEditCtrl
			// 
			this.Controls.Add(this.localeSpecifiedCb_);
			this.Controls.Add(this.localeCtrl_);
			this.Controls.Add(this.localeLb_);
			this.Controls.Add(this.deadbandSpecifiedCb_);
			this.Controls.Add(this.keepAliveSpecifiedCb_);
			this.Controls.Add(this.deadbandCtrl_);
			this.Controls.Add(this.keepAliveRateCtrl_);
			this.Controls.Add(this.updateRateCtrl_);
			this.Controls.Add(this.activeCb_);
			this.Controls.Add(this.nameTb_);
			this.Controls.Add(this.keepAliveRateLb_);
			this.Controls.Add(this.activeLb_);
			this.Controls.Add(this.nameLb_);
			this.Controls.Add(this.updateRateLb_);
			this.Controls.Add(this.deadbandLb_);
			this.Name = "SubscriptionEditCtrl";
			this.Size = new System.Drawing.Size(232, 144);
			((System.ComponentModel.ISupportInitialize)(this.updateRateCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.keepAliveRateCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deadbandCtrl_)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// A handle assigned by the client to a subscription.
		/// </summary>
		private object mClientHandle_ = null;

		/// <summary>
		/// A handle assigned by the server to a subscription.
		/// </summary>
		private object mServerHandle_ = null;

		/// <summary>
		/// The server object which contains the subscriptions being edited.
		/// </summary>
		public TsCDaServer Server {set{ mServer_ = value; }}
		/// <remarks/>
		private TsCDaServer mServer_ = null;

		/// <summary>
		/// Set all fields to default values.
		/// </summary>
		public void SetDefaults()
		{
			nameTb_.Text                  = null;
			activeCb_.Checked             = true;
			updateRateCtrl_.Value         = 1000;
			keepAliveRateCtrl_.Value      = 0;
			keepAliveSpecifiedCb_.Checked = false;
			deadbandCtrl_.Value           = 0;
			deadbandSpecifiedCb_.Checked  = false;
			localeCtrl_.Locale            = "";
			localeSpecifiedCb_.Checked    = false;

			if (mServer_ != null)
			{
				localeCtrl_.Locale = mServer_.Locale;
				localeSpecifiedCb_.Checked = mServer_.Locale != null;
				localeCtrl_.SetSupportedLocales(mServer_.SupportedLocales);
			}
		}

		/// <summary>
		/// Copy values from control into object - throw exceptions on error.
		/// </summary>
		public object Get()
		{
			TsCDaSubscriptionState state = new TsCDaSubscriptionState();

			state.ClientHandle        = mClientHandle_;
			state.ServerHandle        = mServerHandle_;
			state.Name                = nameTb_.Text;
			state.Active              = activeCb_.Checked;
			state.UpdateRate          = (int)updateRateCtrl_.Value;
			state.KeepAlive           = (int)keepAliveRateCtrl_.Value;
			state.Deadband            = (float)deadbandCtrl_.Value;
			state.Locale              = (localeSpecifiedCb_.Checked)?localeCtrl_.Locale:null;

			return state;
		}
		
		/// <summary>
		/// Copy object values into controls.
		/// </summary>
		public void Set(object value)
		{
			// check for null value.
			if (value == null) { SetDefaults(); return; }

			TsCDaSubscriptionState state = (TsCDaSubscriptionState)value;

			// save subscription handles.
			mClientHandle_ = state.ClientHandle;
			mServerHandle_ = state.ClientHandle;
			
			nameTb_.Text                     = state.Name;
			activeCb_.Checked                = state.Active;
			updateRateCtrl_.Value            = (decimal)state.UpdateRate;
			keepAliveRateCtrl_.Value         = (decimal)state.KeepAlive;
			keepAliveSpecifiedCb_.Checked    = state.KeepAlive != 0;
			deadbandCtrl_.Value              = (decimal)state.Deadband;
			deadbandSpecifiedCb_.Checked     = state.Deadband != 0;
			localeCtrl_.Locale               = state.Locale;
			localeSpecifiedCb_.Checked       = state.Locale != null;

			if (mServer_ != null)
			{
				localeCtrl_.SetSupportedLocales(mServer_.SupportedLocales);
			}
		}

		/// <summary>
		/// Creates a new object.
		/// </summary>
		public object Create()
		{
			TsCDaSubscriptionState state = new TsCDaSubscriptionState();
			state.UpdateRate = 1000;
			return state;
		}

		/// <summary>
		/// Toggles the enabled state of controls based on the specified check boxes.
		/// </summary>
		private void Specified_CheckedChanged(object sender, System.EventArgs e)
		{			
			keepAliveRateCtrl_.Enabled = keepAliveSpecifiedCb_.Checked;
			deadbandCtrl_.Enabled      = deadbandSpecifiedCb_.Checked;
			localeCtrl_.Enabled        = localeSpecifiedCb_.Checked;
		}
	}
}

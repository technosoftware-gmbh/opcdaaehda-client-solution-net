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
			nameLb_ = new System.Windows.Forms.Label();
			activeLb_ = new System.Windows.Forms.Label();
			updateRateLb_ = new System.Windows.Forms.Label();
			keepAliveRateLb_ = new System.Windows.Forms.Label();
			deadbandLb_ = new System.Windows.Forms.Label();
			nameTb_ = new System.Windows.Forms.TextBox();
			activeCb_ = new System.Windows.Forms.CheckBox();
			updateRateCtrl_ = new System.Windows.Forms.NumericUpDown();
			keepAliveRateCtrl_ = new System.Windows.Forms.NumericUpDown();
			deadbandCtrl_ = new System.Windows.Forms.NumericUpDown();
			keepAliveSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			deadbandSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			localeLb_ = new System.Windows.Forms.Label();
			localeCtrl_ = new LocaleCtrl();
			localeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(updateRateCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(keepAliveRateCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(deadbandCtrl_)).BeginInit();
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
			// UpdateRateLB
			// 
			updateRateLb_.Location = new System.Drawing.Point(0, 48);
			updateRateLb_.Name = "updateRateLb_";
			updateRateLb_.TabIndex = 4;
			updateRateLb_.Text = "Update Rate";
			updateRateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// KeepAliveRateLB
			// 
			keepAliveRateLb_.Location = new System.Drawing.Point(0, 72);
			keepAliveRateLb_.Name = "keepAliveRateLb_";
			keepAliveRateLb_.TabIndex = 5;
			keepAliveRateLb_.Text = "Keep Alive Rate";
			keepAliveRateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DeadbandLB
			// 
			deadbandLb_.Location = new System.Drawing.Point(0, 96);
			deadbandLb_.Name = "deadbandLb_";
			deadbandLb_.TabIndex = 6;
			deadbandLb_.Text = "Deadband";
			deadbandLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameTB
			// 
			nameTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			nameTb_.Location = new System.Drawing.Point(104, 0);
			nameTb_.Name = "nameTb_";
			nameTb_.Size = new System.Drawing.Size(128, 20);
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
			// UpdateRateCTRL
			// 
			updateRateCtrl_.Increment = new System.Decimal(new int[] {
																			 100,
																			 0,
																			 0,
																			 0});
			updateRateCtrl_.Location = new System.Drawing.Point(104, 48);
			updateRateCtrl_.Maximum = new System.Decimal(new int[] {
																		   1000000000,
																		   0,
																		   0,
																		   0});
			updateRateCtrl_.Name = "updateRateCtrl_";
			updateRateCtrl_.Size = new System.Drawing.Size(72, 20);
			updateRateCtrl_.TabIndex = 11;
			// 
			// KeepAliveRateCTRL
			// 
			keepAliveRateCtrl_.Increment = new System.Decimal(new int[] {
																				100,
																				0,
																				0,
																				0});
			keepAliveRateCtrl_.Location = new System.Drawing.Point(104, 72);
			keepAliveRateCtrl_.Maximum = new System.Decimal(new int[] {
																			  1000000000,
																			  0,
																			  0,
																			  0});
			keepAliveRateCtrl_.Name = "keepAliveRateCtrl_";
			keepAliveRateCtrl_.Size = new System.Drawing.Size(72, 20);
			keepAliveRateCtrl_.TabIndex = 12;
			// 
			// DeadbandCTRL
			// 
			deadbandCtrl_.DecimalPlaces = 1;
			deadbandCtrl_.Location = new System.Drawing.Point(104, 96);
			deadbandCtrl_.Name = "deadbandCtrl_";
			deadbandCtrl_.Size = new System.Drawing.Size(72, 20);
			deadbandCtrl_.TabIndex = 14;
			// 
			// KeepAliveSpecifiedCB
			// 
			keepAliveSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			keepAliveSpecifiedCb_.Checked = true;
			keepAliveSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			keepAliveSpecifiedCb_.Location = new System.Drawing.Point(216, 72);
			keepAliveSpecifiedCb_.Name = "keepAliveSpecifiedCb_";
			keepAliveSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			keepAliveSpecifiedCb_.TabIndex = 20;
			keepAliveSpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// DeadbandSpecifiedCB
			// 
			deadbandSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			deadbandSpecifiedCb_.Checked = true;
			deadbandSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			deadbandSpecifiedCb_.Location = new System.Drawing.Point(216, 96);
			deadbandSpecifiedCb_.Name = "deadbandSpecifiedCb_";
			deadbandSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			deadbandSpecifiedCb_.TabIndex = 21;
			deadbandSpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// LocaleLB
			// 
			localeLb_.Location = new System.Drawing.Point(0, 120);
			localeLb_.Name = "localeLb_";
			localeLb_.TabIndex = 22;
			localeLb_.Text = "Locale";
			localeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LocaleCTRL
			// 
			localeCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			localeCtrl_.Enabled = false;
			localeCtrl_.Locale = "";
			localeCtrl_.Location = new System.Drawing.Point(104, 120);
			localeCtrl_.Name = "localeCtrl_";
			localeCtrl_.Size = new System.Drawing.Size(104, 24);
			localeCtrl_.TabIndex = 23;
			// 
			// LocaleSpecifiedCB
			// 
			localeSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			localeSpecifiedCb_.Checked = true;
			localeSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			localeSpecifiedCb_.Location = new System.Drawing.Point(216, 120);
			localeSpecifiedCb_.Name = "localeSpecifiedCb_";
			localeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			localeSpecifiedCb_.TabIndex = 24;
			localeSpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// SubscriptionEditCtrl
			// 
			Controls.Add(localeSpecifiedCb_);
			Controls.Add(localeCtrl_);
			Controls.Add(localeLb_);
			Controls.Add(deadbandSpecifiedCb_);
			Controls.Add(keepAliveSpecifiedCb_);
			Controls.Add(deadbandCtrl_);
			Controls.Add(keepAliveRateCtrl_);
			Controls.Add(updateRateCtrl_);
			Controls.Add(activeCb_);
			Controls.Add(nameTb_);
			Controls.Add(keepAliveRateLb_);
			Controls.Add(activeLb_);
			Controls.Add(nameLb_);
			Controls.Add(updateRateLb_);
			Controls.Add(deadbandLb_);
			Name = "SubscriptionEditCtrl";
			Size = new System.Drawing.Size(232, 144);
			((System.ComponentModel.ISupportInitialize)(updateRateCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(keepAliveRateCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(deadbandCtrl_)).EndInit();
			ResumeLayout(false);

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

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

using System;
using System.Windows.Forms;

using SampleClients.Common;
using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da
{
    /// <summary>
    /// // A dialog used to edit the default options for a server or subscription.
    /// </summary>
    public class OptionsEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Panel topPn_;
		private System.Windows.Forms.Label itemTimeLb_;
		private System.Windows.Forms.Label itemNameLb_;
		private System.Windows.Forms.Label itemPathLb_;
		private System.Windows.Forms.Label errorTextLb_;
		private System.Windows.Forms.CheckBox errorTextCb_;
		private System.Windows.Forms.Label diagnosticInfoLb_;
		private System.Windows.Forms.CheckBox diagnosticInfoCb_;
		private System.Windows.Forms.CheckBox itemNameCb_;
		private System.Windows.Forms.CheckBox itemPathCb_;
		private System.Windows.Forms.CheckBox itemTimeCb_;
		private System.Windows.Forms.CheckBox clientHandleCb_;
		private System.Windows.Forms.Label clientHandleLb_;
		private LocaleCtrl localeCtrl_;
		private System.Windows.Forms.Label localeLb_;
		private System.Windows.Forms.CheckBox localeSpecifiedCb_;
		private System.ComponentModel.IContainer components = null;

		public OptionsEditDlg()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();
        }
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.okBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.itemTimeLb_ = new System.Windows.Forms.Label();
			this.itemNameLb_ = new System.Windows.Forms.Label();
			this.itemTimeCb_ = new System.Windows.Forms.CheckBox();
			this.itemPathLb_ = new System.Windows.Forms.Label();
			this.topPn_ = new System.Windows.Forms.Panel();
			this.localeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.localeCtrl_ = new LocaleCtrl();
			this.localeLb_ = new System.Windows.Forms.Label();
			this.clientHandleCb_ = new System.Windows.Forms.CheckBox();
			this.itemPathCb_ = new System.Windows.Forms.CheckBox();
			this.itemNameCb_ = new System.Windows.Forms.CheckBox();
			this.diagnosticInfoCb_ = new System.Windows.Forms.CheckBox();
			this.errorTextCb_ = new System.Windows.Forms.CheckBox();
			this.clientHandleLb_ = new System.Windows.Forms.Label();
			this.diagnosticInfoLb_ = new System.Windows.Forms.Label();
			this.errorTextLb_ = new System.Windows.Forms.Label();
			this.buttonsPn_.SuspendLayout();
			this.topPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
			this.okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn_.Location = new System.Drawing.Point(5, 8);
			this.okBtn_.Name = "okBtn_";
			this.okBtn_.TabIndex = 1;
			this.okBtn_.Text = "OK";
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(176, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 170);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(256, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// ItemTimeLB
			// 
			this.itemTimeLb_.Location = new System.Drawing.Point(4, 100);
			this.itemTimeLb_.Name = "itemTimeLb_";
			this.itemTimeLb_.Size = new System.Drawing.Size(128, 23);
			this.itemTimeLb_.TabIndex = 8;
			this.itemTimeLb_.Text = "Return Timestamp";
			this.itemTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameLB
			// 
			this.itemNameLb_.Location = new System.Drawing.Point(4, 28);
			this.itemNameLb_.Name = "itemNameLb_";
			this.itemNameLb_.Size = new System.Drawing.Size(128, 23);
			this.itemNameLb_.TabIndex = 0;
			this.itemNameLb_.Text = "Return Item Name";
			this.itemNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemTimeCB
			// 
			this.itemTimeCb_.Checked = true;
			this.itemTimeCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.itemTimeCb_.Location = new System.Drawing.Point(132, 100);
			this.itemTimeCb_.Name = "itemTimeCb_";
			this.itemTimeCb_.Size = new System.Drawing.Size(96, 24);
			this.itemTimeCb_.TabIndex = 9;
			// 
			// ItemPathLB
			// 
			this.itemPathLb_.Location = new System.Drawing.Point(4, 52);
			this.itemPathLb_.Name = "itemPathLb_";
			this.itemPathLb_.Size = new System.Drawing.Size(128, 23);
			this.itemPathLb_.TabIndex = 2;
			this.itemPathLb_.Text = "Return Item Path";
			this.itemPathLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
			this.topPn_.Controls.Add(this.localeSpecifiedCb_);
			this.topPn_.Controls.Add(this.localeCtrl_);
			this.topPn_.Controls.Add(this.localeLb_);
			this.topPn_.Controls.Add(this.clientHandleCb_);
			this.topPn_.Controls.Add(this.itemPathCb_);
			this.topPn_.Controls.Add(this.itemNameCb_);
			this.topPn_.Controls.Add(this.diagnosticInfoCb_);
			this.topPn_.Controls.Add(this.errorTextCb_);
			this.topPn_.Controls.Add(this.itemTimeCb_);
			this.topPn_.Controls.Add(this.clientHandleLb_);
			this.topPn_.Controls.Add(this.diagnosticInfoLb_);
			this.topPn_.Controls.Add(this.errorTextLb_);
			this.topPn_.Controls.Add(this.itemTimeLb_);
			this.topPn_.Controls.Add(this.itemPathLb_);
			this.topPn_.Controls.Add(this.itemNameLb_);
			this.topPn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.topPn_.DockPadding.Left = 4;
			this.topPn_.DockPadding.Right = 4;
			this.topPn_.Location = new System.Drawing.Point(0, 0);
			this.topPn_.Name = "topPn_";
			this.topPn_.Size = new System.Drawing.Size(256, 460);
			this.topPn_.TabIndex = 1;
			// 
			// LocaleSpecifiedCB
			// 
			this.localeSpecifiedCb_.Location = new System.Drawing.Point(236, 4);
			this.localeSpecifiedCb_.Name = "localeSpecifiedCb_";
			this.localeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.localeSpecifiedCb_.TabIndex = 16;
			this.localeSpecifiedCb_.CheckedChanged += new System.EventHandler(this.LocaleSpecifiedCB_CheckedChanged);
			// 
			// LocaleCTRL
			// 
			this.localeCtrl_.Enabled = false;
			this.localeCtrl_.Locale = "";
			this.localeCtrl_.Location = new System.Drawing.Point(132, 4);
			this.localeCtrl_.Name = "localeCtrl_";
			this.localeCtrl_.Size = new System.Drawing.Size(96, 24);
			this.localeCtrl_.TabIndex = 15;
			// 
			// LocaleLB
			// 
			this.localeLb_.Location = new System.Drawing.Point(4, 4);
			this.localeLb_.Name = "localeLb_";
			this.localeLb_.Size = new System.Drawing.Size(128, 23);
			this.localeLb_.TabIndex = 14;
			this.localeLb_.Text = "Locale";
			this.localeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ClientHandleCB
			// 
			this.clientHandleCb_.Checked = true;
			this.clientHandleCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.clientHandleCb_.Location = new System.Drawing.Point(132, 76);
			this.clientHandleCb_.Name = "clientHandleCb_";
			this.clientHandleCb_.Size = new System.Drawing.Size(96, 24);
			this.clientHandleCb_.TabIndex = 5;
			// 
			// ItemPathCB
			// 
			this.itemPathCb_.Checked = true;
			this.itemPathCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.itemPathCb_.Location = new System.Drawing.Point(132, 52);
			this.itemPathCb_.Name = "itemPathCb_";
			this.itemPathCb_.Size = new System.Drawing.Size(96, 24);
			this.itemPathCb_.TabIndex = 3;
			// 
			// ItemNameCB
			// 
			this.itemNameCb_.Checked = true;
			this.itemNameCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.itemNameCb_.Location = new System.Drawing.Point(132, 28);
			this.itemNameCb_.Name = "itemNameCb_";
			this.itemNameCb_.Size = new System.Drawing.Size(96, 24);
			this.itemNameCb_.TabIndex = 1;
			// 
			// DiagnosticInfoCB
			// 
			this.diagnosticInfoCb_.Checked = true;
			this.diagnosticInfoCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.diagnosticInfoCb_.Location = new System.Drawing.Point(132, 148);
			this.diagnosticInfoCb_.Name = "diagnosticInfoCb_";
			this.diagnosticInfoCb_.Size = new System.Drawing.Size(96, 24);
			this.diagnosticInfoCb_.TabIndex = 13;
			// 
			// ErrorTextCB
			// 
			this.errorTextCb_.Checked = true;
			this.errorTextCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.errorTextCb_.Location = new System.Drawing.Point(132, 124);
			this.errorTextCb_.Name = "errorTextCb_";
			this.errorTextCb_.Size = new System.Drawing.Size(96, 24);
			this.errorTextCb_.TabIndex = 11;
			// 
			// ClientHandleLB
			// 
			this.clientHandleLb_.Location = new System.Drawing.Point(4, 76);
			this.clientHandleLb_.Name = "clientHandleLb_";
			this.clientHandleLb_.Size = new System.Drawing.Size(128, 23);
			this.clientHandleLb_.TabIndex = 4;
			this.clientHandleLb_.Text = "Return Client Handle";
			this.clientHandleLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DiagnosticInfoLB
			// 
			this.diagnosticInfoLb_.Location = new System.Drawing.Point(4, 148);
			this.diagnosticInfoLb_.Name = "diagnosticInfoLb_";
			this.diagnosticInfoLb_.Size = new System.Drawing.Size(128, 23);
			this.diagnosticInfoLb_.TabIndex = 12;
			this.diagnosticInfoLb_.Text = "Return Diagnostic Info";
			this.diagnosticInfoLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ErrorTextLB
			// 
			this.errorTextLb_.Location = new System.Drawing.Point(4, 124);
			this.errorTextLb_.Name = "errorTextLb_";
			this.errorTextLb_.Size = new System.Drawing.Size(128, 23);
			this.errorTextLb_.TabIndex = 10;
			this.errorTextLb_.Text = "Return Error Text";
			this.errorTextLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// OptionsEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 206);
			this.Controls.Add(this.buttonsPn_);
			this.Controls.Add(this.topPn_);
			this.Name = "OptionsEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Options";
			this.buttonsPn_.ResumeLayout(false);
			this.topPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts user to edit request option parameters in a modal dialog.
		/// </summary>
		public void ShowDialog(TsCDaServer server)
		{
			ShowDialog(server, null);
		}

		/// <summary>
		/// Toggles the state of the locale selection control.
		/// </summary>
		private void LocaleSpecifiedCB_CheckedChanged(object sender, System.EventArgs e)
		{
			localeCtrl_.Enabled = localeSpecifiedCb_.Checked;	
		}

		/// <summary>
		/// Prompts user to edit request option parameters in a modal dialog.
		/// </summary>
		public void ShowDialog(TsCDaSubscription subscription)
		{
			ShowDialog(subscription.Server, subscription);
		}
		
		/// <summary>
		/// Prompts user to edit request option parameters in a modal dialog.
		/// </summary>
		private void ShowDialog(TsCDaServer server, TsCDaSubscription subscription)
		{
			if (server == null) throw new ArgumentNullException("server");

			// get supported locales.
			localeCtrl_.SetSupportedLocales(server.SupportedLocales);

			// set locale.
			string locale = (subscription == null)?server.Locale:subscription.Locale;

			localeCtrl_.Locale = locale;
			localeSpecifiedCb_.Checked = locale != null;

			// get filters.
			int filters = (subscription == null)?server.Filters:subscription.Filters;

			itemNameCb_.Checked       = ((filters & (int)TsCDaResultFilter.ItemName)       != 0);
			itemPathCb_.Checked       = ((filters & (int)TsCDaResultFilter.ItemPath)       != 0);
			clientHandleCb_.Checked   = ((filters & (int)TsCDaResultFilter.ClientHandle)   != 0);
			itemTimeCb_.Checked       = ((filters & (int)TsCDaResultFilter.ItemTime)       != 0);
			errorTextCb_.Checked      = ((filters & (int)TsCDaResultFilter.ErrorText)      != 0);
			diagnosticInfoCb_.Checked = ((filters & (int)TsCDaResultFilter.DiagnosticInfo) != 0);

			// show dialog.
			while (ShowDialog() == DialogResult.OK)
			{
				// update locale.
				try
				{
					locale = null;

					if (localeSpecifiedCb_.Checked)
					{
						locale = localeCtrl_.Locale;
					}

					if (subscription == null)
					{
						server.SetLocale(locale);
					}
					else
					{
						TsCDaSubscriptionState state = new TsCDaSubscriptionState();
						state.Locale = locale;
						subscription.ModifyState((int)TsCDaStateMask.Locale, state);
					}
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message);
					continue;
				}

				// update filters.
				filters = 0;

				filters |= (itemNameCb_.Checked)?(int)TsCDaResultFilter.ItemName:0;
				filters |= (itemPathCb_.Checked)?(int)TsCDaResultFilter.ItemPath:0;
				filters |= (clientHandleCb_.Checked)?(int)TsCDaResultFilter.ClientHandle:0;
				filters |= (itemTimeCb_.Checked)?(int)TsCDaResultFilter.ItemTime:0;
				filters |= (errorTextCb_.Checked)?(int)TsCDaResultFilter.ErrorText:0;
				filters |= (diagnosticInfoCb_.Checked)?(int)TsCDaResultFilter.DiagnosticInfo:0;

				try
				{
					if (subscription == null)
					{
						server.SetResultFilters(filters);
					}
					else
					{
						subscription.SetResultFilters(filters);
					}
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message);
					continue;
				}

				// break out of loop if no error.
				break;
			}
		}
	}
}

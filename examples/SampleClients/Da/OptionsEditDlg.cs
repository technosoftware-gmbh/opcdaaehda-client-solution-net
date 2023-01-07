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
			okBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			buttonsPn_ = new System.Windows.Forms.Panel();
			itemTimeLb_ = new System.Windows.Forms.Label();
			itemNameLb_ = new System.Windows.Forms.Label();
			itemTimeCb_ = new System.Windows.Forms.CheckBox();
			itemPathLb_ = new System.Windows.Forms.Label();
			topPn_ = new System.Windows.Forms.Panel();
			localeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			localeCtrl_ = new LocaleCtrl();
			localeLb_ = new System.Windows.Forms.Label();
			clientHandleCb_ = new System.Windows.Forms.CheckBox();
			itemPathCb_ = new System.Windows.Forms.CheckBox();
			itemNameCb_ = new System.Windows.Forms.CheckBox();
			diagnosticInfoCb_ = new System.Windows.Forms.CheckBox();
			errorTextCb_ = new System.Windows.Forms.CheckBox();
			clientHandleLb_ = new System.Windows.Forms.Label();
			diagnosticInfoLb_ = new System.Windows.Forms.Label();
			errorTextLb_ = new System.Windows.Forms.Label();
			buttonsPn_.SuspendLayout();
			topPn_.SuspendLayout();
			SuspendLayout();
			// 
			// OkBTN
			// 
			okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			okBtn_.Location = new System.Drawing.Point(5, 8);
			okBtn_.Name = "okBtn_";
			okBtn_.TabIndex = 1;
			okBtn_.Text = "OK";
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(176, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 170);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(256, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// ItemTimeLB
			// 
			itemTimeLb_.Location = new System.Drawing.Point(4, 100);
			itemTimeLb_.Name = "itemTimeLb_";
			itemTimeLb_.Size = new System.Drawing.Size(128, 23);
			itemTimeLb_.TabIndex = 8;
			itemTimeLb_.Text = "Return Timestamp";
			itemTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameLB
			// 
			itemNameLb_.Location = new System.Drawing.Point(4, 28);
			itemNameLb_.Name = "itemNameLb_";
			itemNameLb_.Size = new System.Drawing.Size(128, 23);
			itemNameLb_.TabIndex = 0;
			itemNameLb_.Text = "Return Item Name";
			itemNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemTimeCB
			// 
			itemTimeCb_.Checked = true;
			itemTimeCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			itemTimeCb_.Location = new System.Drawing.Point(132, 100);
			itemTimeCb_.Name = "itemTimeCb_";
			itemTimeCb_.Size = new System.Drawing.Size(96, 24);
			itemTimeCb_.TabIndex = 9;
			// 
			// ItemPathLB
			// 
			itemPathLb_.Location = new System.Drawing.Point(4, 52);
			itemPathLb_.Name = "itemPathLb_";
			itemPathLb_.Size = new System.Drawing.Size(128, 23);
			itemPathLb_.TabIndex = 2;
			itemPathLb_.Text = "Return Item Path";
			itemPathLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
			topPn_.Controls.Add(localeSpecifiedCb_);
			topPn_.Controls.Add(localeCtrl_);
			topPn_.Controls.Add(localeLb_);
			topPn_.Controls.Add(clientHandleCb_);
			topPn_.Controls.Add(itemPathCb_);
			topPn_.Controls.Add(itemNameCb_);
			topPn_.Controls.Add(diagnosticInfoCb_);
			topPn_.Controls.Add(errorTextCb_);
			topPn_.Controls.Add(itemTimeCb_);
			topPn_.Controls.Add(clientHandleLb_);
			topPn_.Controls.Add(diagnosticInfoLb_);
			topPn_.Controls.Add(errorTextLb_);
			topPn_.Controls.Add(itemTimeLb_);
			topPn_.Controls.Add(itemPathLb_);
			topPn_.Controls.Add(itemNameLb_);
			topPn_.Dock = System.Windows.Forms.DockStyle.Top;
			topPn_.DockPadding.Left = 4;
			topPn_.DockPadding.Right = 4;
			topPn_.Location = new System.Drawing.Point(0, 0);
			topPn_.Name = "topPn_";
			topPn_.Size = new System.Drawing.Size(256, 460);
			topPn_.TabIndex = 1;
			// 
			// LocaleSpecifiedCB
			// 
			localeSpecifiedCb_.Location = new System.Drawing.Point(236, 4);
			localeSpecifiedCb_.Name = "localeSpecifiedCb_";
			localeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			localeSpecifiedCb_.TabIndex = 16;
			localeSpecifiedCb_.CheckedChanged += new System.EventHandler(LocaleSpecifiedCB_CheckedChanged);
			// 
			// LocaleCTRL
			// 
			localeCtrl_.Enabled = false;
			localeCtrl_.Locale = "";
			localeCtrl_.Location = new System.Drawing.Point(132, 4);
			localeCtrl_.Name = "localeCtrl_";
			localeCtrl_.Size = new System.Drawing.Size(96, 24);
			localeCtrl_.TabIndex = 15;
			// 
			// LocaleLB
			// 
			localeLb_.Location = new System.Drawing.Point(4, 4);
			localeLb_.Name = "localeLb_";
			localeLb_.Size = new System.Drawing.Size(128, 23);
			localeLb_.TabIndex = 14;
			localeLb_.Text = "Locale";
			localeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ClientHandleCB
			// 
			clientHandleCb_.Checked = true;
			clientHandleCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			clientHandleCb_.Location = new System.Drawing.Point(132, 76);
			clientHandleCb_.Name = "clientHandleCb_";
			clientHandleCb_.Size = new System.Drawing.Size(96, 24);
			clientHandleCb_.TabIndex = 5;
			// 
			// ItemPathCB
			// 
			itemPathCb_.Checked = true;
			itemPathCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			itemPathCb_.Location = new System.Drawing.Point(132, 52);
			itemPathCb_.Name = "itemPathCb_";
			itemPathCb_.Size = new System.Drawing.Size(96, 24);
			itemPathCb_.TabIndex = 3;
			// 
			// ItemNameCB
			// 
			itemNameCb_.Checked = true;
			itemNameCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			itemNameCb_.Location = new System.Drawing.Point(132, 28);
			itemNameCb_.Name = "itemNameCb_";
			itemNameCb_.Size = new System.Drawing.Size(96, 24);
			itemNameCb_.TabIndex = 1;
			// 
			// DiagnosticInfoCB
			// 
			diagnosticInfoCb_.Checked = true;
			diagnosticInfoCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			diagnosticInfoCb_.Location = new System.Drawing.Point(132, 148);
			diagnosticInfoCb_.Name = "diagnosticInfoCb_";
			diagnosticInfoCb_.Size = new System.Drawing.Size(96, 24);
			diagnosticInfoCb_.TabIndex = 13;
			// 
			// ErrorTextCB
			// 
			errorTextCb_.Checked = true;
			errorTextCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			errorTextCb_.Location = new System.Drawing.Point(132, 124);
			errorTextCb_.Name = "errorTextCb_";
			errorTextCb_.Size = new System.Drawing.Size(96, 24);
			errorTextCb_.TabIndex = 11;
			// 
			// ClientHandleLB
			// 
			clientHandleLb_.Location = new System.Drawing.Point(4, 76);
			clientHandleLb_.Name = "clientHandleLb_";
			clientHandleLb_.Size = new System.Drawing.Size(128, 23);
			clientHandleLb_.TabIndex = 4;
			clientHandleLb_.Text = "Return Client Handle";
			clientHandleLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DiagnosticInfoLB
			// 
			diagnosticInfoLb_.Location = new System.Drawing.Point(4, 148);
			diagnosticInfoLb_.Name = "diagnosticInfoLb_";
			diagnosticInfoLb_.Size = new System.Drawing.Size(128, 23);
			diagnosticInfoLb_.TabIndex = 12;
			diagnosticInfoLb_.Text = "Return Diagnostic Info";
			diagnosticInfoLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ErrorTextLB
			// 
			errorTextLb_.Location = new System.Drawing.Point(4, 124);
			errorTextLb_.Name = "errorTextLb_";
			errorTextLb_.Size = new System.Drawing.Size(128, 23);
			errorTextLb_.TabIndex = 10;
			errorTextLb_.Text = "Return Error Text";
			errorTextLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// OptionsEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(256, 206);
			Controls.Add(buttonsPn_);
			Controls.Add(topPn_);
			Name = "OptionsEditDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Edit Options";
			buttonsPn_.ResumeLayout(false);
			topPn_.ResumeLayout(false);
			ResumeLayout(false);

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

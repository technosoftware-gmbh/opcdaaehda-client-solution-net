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
using System;
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A dialog that displays the current status of an OPC server.
    /// </summary>
    public class SetEnabledStateDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Label enabledLb_;
		private System.Windows.Forms.CheckBox enabledChk_;
		private System.Windows.Forms.CheckBox recursiveChk_;
		private System.Windows.Forms.Label recursiveLb_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public SetEnabledStateDlg()
		{
			//
			// Required for Windows Form Designer support
			//
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
				if(components_ != null)
				{
					components_.Dispose();
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
			this.enabledLb_ = new System.Windows.Forms.Label();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.okBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.enabledChk_ = new System.Windows.Forms.CheckBox();
			this.recursiveChk_ = new System.Windows.Forms.CheckBox();
			this.recursiveLb_ = new System.Windows.Forms.Label();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// EnabledLB
			// 
			this.enabledLb_.Location = new System.Drawing.Point(4, 4);
			this.enabledLb_.Name = "enabledLb_";
			this.enabledLb_.Size = new System.Drawing.Size(68, 20);
			this.enabledLb_.TabIndex = 1;
			this.enabledLb_.Text = "Enabled";
			this.enabledLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 50);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(216, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// OkBTN
			// 
			this.okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn_.Location = new System.Drawing.Point(4, 8);
			this.okBtn_.Name = "okBtn_";
			this.okBtn_.TabIndex = 1;
			this.okBtn_.Text = "OK";
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(136, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// EnabledCHK
			// 
			this.enabledChk_.Location = new System.Drawing.Point(80, 2);
			this.enabledChk_.Name = "enabledChk_";
			this.enabledChk_.Size = new System.Drawing.Size(24, 24);
			this.enabledChk_.TabIndex = 2;
			// 
			// RecursiveCHK
			// 
			this.recursiveChk_.Location = new System.Drawing.Point(80, 26);
			this.recursiveChk_.Name = "recursiveChk_";
			this.recursiveChk_.Size = new System.Drawing.Size(24, 24);
			this.recursiveChk_.TabIndex = 4;
			// 
			// RecursiveLB
			// 
			this.recursiveLb_.Location = new System.Drawing.Point(4, 28);
			this.recursiveLb_.Name = "recursiveLb_";
			this.recursiveLb_.Size = new System.Drawing.Size(68, 20);
			this.recursiveLb_.TabIndex = 3;
			this.recursiveLb_.Text = "Recursive";
			this.recursiveLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SetEnabledStateDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(216, 86);
			this.Controls.Add(this.recursiveChk_);
			this.Controls.Add(this.recursiveLb_);
			this.Controls.Add(this.enabledChk_);
			this.Controls.Add(this.buttonsPn_);
			this.Controls.Add(this.enabledLb_);
			this.MaximizeBox = false;
			this.Name = "SetEnabledStateDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Enabled State";
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private TsCAeServer mServer_ = null;
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to select the enabled state.
		/// </summary>
		public bool ShowDialog(
			TsCAeServer server, 
			Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element, 
			out bool      enabled, 
			ref bool      recursive)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;

			// get current enabled state.
			enabledChk_.Checked = enabled = GetEnabledState(element);

			if (element != null)
			{
				recursiveChk_.Checked = recursive;	
				recursiveChk_.Enabled = true;
			}
			else
			{
				recursiveChk_.Checked = true;	
				recursiveChk_.Enabled = false;
			}

			// show dialog.
			if (ShowDialog() == DialogResult.OK)
			{
				enabled   = enabledChk_.Checked;
				recursive = recursiveChk_.Checked;
				return true;
			}

			return false;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Fetches the enabled state for an area or source.
		/// </summary>
		private bool GetEnabledState(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element)
		{
			try
			{
				// check for root.
				if (element == null)
				{
					return true;
				}

				// construct arguments.
				string[] names = new string[] { element.QualifiedName };
				
				TsCAeEnabledStateResult[] results = null;
				
				// get current enabled state.
				if (element.NodeType == Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area)
				{
					results = mServer_.GetEnableStateByArea(names);
				}
				else
				{
					results = mServer_.GetEnableStateBySource(names);
				}
				
				// check return code and result.
				if (results != null && results.Length == 1)
				{
					if (results[0].Result.Failed())
					{
						return false;
					}

					return results[0].Enabled;
				}

				// should never happen.
				return false;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "GetEnabledState");
				return false;
			}	
		}
		#endregion
	}
}

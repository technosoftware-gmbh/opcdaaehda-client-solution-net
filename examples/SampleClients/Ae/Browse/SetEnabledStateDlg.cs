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
			enabledLb_ = new System.Windows.Forms.Label();
			buttonsPn_ = new System.Windows.Forms.Panel();
			okBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			enabledChk_ = new System.Windows.Forms.CheckBox();
			recursiveChk_ = new System.Windows.Forms.CheckBox();
			recursiveLb_ = new System.Windows.Forms.Label();
			buttonsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// EnabledLB
			// 
			enabledLb_.Location = new System.Drawing.Point(4, 4);
			enabledLb_.Name = "enabledLb_";
			enabledLb_.Size = new System.Drawing.Size(68, 20);
			enabledLb_.TabIndex = 1;
			enabledLb_.Text = "Enabled";
			enabledLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 50);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(216, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// OkBTN
			// 
			okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			okBtn_.Location = new System.Drawing.Point(4, 8);
			okBtn_.Name = "okBtn_";
			okBtn_.TabIndex = 1;
			okBtn_.Text = "OK";
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(136, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// EnabledCHK
			// 
			enabledChk_.Location = new System.Drawing.Point(80, 2);
			enabledChk_.Name = "enabledChk_";
			enabledChk_.Size = new System.Drawing.Size(24, 24);
			enabledChk_.TabIndex = 2;
			// 
			// RecursiveCHK
			// 
			recursiveChk_.Location = new System.Drawing.Point(80, 26);
			recursiveChk_.Name = "recursiveChk_";
			recursiveChk_.Size = new System.Drawing.Size(24, 24);
			recursiveChk_.TabIndex = 4;
			// 
			// RecursiveLB
			// 
			recursiveLb_.Location = new System.Drawing.Point(4, 28);
			recursiveLb_.Name = "recursiveLb_";
			recursiveLb_.Size = new System.Drawing.Size(68, 20);
			recursiveLb_.TabIndex = 3;
			recursiveLb_.Text = "Recursive";
			recursiveLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SetEnabledStateDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = cancelBtn_;
			ClientSize = new System.Drawing.Size(216, 86);
			Controls.Add(recursiveChk_);
			Controls.Add(recursiveLb_);
			Controls.Add(enabledChk_);
			Controls.Add(buttonsPn_);
			Controls.Add(enabledLb_);
			MaximizeBox = false;
			Name = "SetEnabledStateDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Set Enabled State";
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

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

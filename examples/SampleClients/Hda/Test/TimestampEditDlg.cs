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

#endregion

namespace SampleClients.Hda.Test
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class TimestampEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel mainPn_;
		private System.Windows.Forms.Label timestampLb_;
		private System.Windows.Forms.DateTimePicker timestampCtrl_;
		private System.Windows.Forms.CheckBox timestampSpecifiedCb_;
		private System.ComponentModel.IContainer components = null;

		public TimestampEditDlg()
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
			cancelBtn_ = new System.Windows.Forms.Button();
			buttonsPn_ = new System.Windows.Forms.Panel();
			okBtn_ = new System.Windows.Forms.Button();
			mainPn_ = new System.Windows.Forms.Panel();
			timestampCtrl_ = new System.Windows.Forms.DateTimePicker();
			timestampLb_ = new System.Windows.Forms.Label();
			timestampSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			buttonsPn_.SuspendLayout();
			mainPn_.SuspendLayout();
			SuspendLayout();
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(168, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 26);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(248, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// OkBTN
			// 
			okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			okBtn_.Location = new System.Drawing.Point(4, 8);
			okBtn_.Name = "okBtn_";
			okBtn_.TabIndex = 0;
			okBtn_.Text = "OK";
			// 
			// MainPN
			// 
			mainPn_.Controls.Add(timestampSpecifiedCb_);
			mainPn_.Controls.Add(timestampCtrl_);
			mainPn_.Controls.Add(timestampLb_);
			mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			mainPn_.DockPadding.Left = 4;
			mainPn_.DockPadding.Right = 4;
			mainPn_.DockPadding.Top = 4;
			mainPn_.Location = new System.Drawing.Point(0, 0);
			mainPn_.Name = "mainPn_";
			mainPn_.Size = new System.Drawing.Size(248, 26);
			mainPn_.TabIndex = 33;
			// 
			// TimestampCTRL
			// 
			timestampCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			timestampCtrl_.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			timestampCtrl_.Enabled = false;
			timestampCtrl_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			timestampCtrl_.Location = new System.Drawing.Point(72, 4);
			timestampCtrl_.Name = "timestampCtrl_";
			timestampCtrl_.Size = new System.Drawing.Size(152, 20);
			timestampCtrl_.TabIndex = 40;
			// 
			// TimestampLB
			// 
			timestampLb_.Location = new System.Drawing.Point(4, 4);
			timestampLb_.Name = "timestampLb_";
			timestampLb_.Size = new System.Drawing.Size(68, 23);
			timestampLb_.TabIndex = 39;
			timestampLb_.Text = "Timestamp";
			timestampLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TimestampSpecifiedCB
			// 
			timestampSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			timestampSpecifiedCb_.Location = new System.Drawing.Point(228, 3);
			timestampSpecifiedCb_.Name = "timestampSpecifiedCb_";
			timestampSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			timestampSpecifiedCb_.TabIndex = 41;
			timestampSpecifiedCb_.CheckedChanged += new System.EventHandler(TimestampSpecifiedCB_CheckedChanged);
			// 
			// TimestampEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(248, 62);
			Controls.Add(mainPn_);
			Controls.Add(buttonsPn_);
			Name = "TimestampEditDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Edit Timestamp";
			buttonsPn_.ResumeLayout(false);
			mainPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the user to edit a timestamp.
		/// </summary>
		public bool ShowDialog(ref DateTime timestamp)
		{
			timestampSpecifiedCb_.Checked = (timestampCtrl_.MinDate < timestamp);

			// initialize controls.
			if (timestampSpecifiedCb_.Checked)
			{
				timestampCtrl_.Value = timestamp;
			}

			// display dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return false;
			}

			// update object.
			if (timestampSpecifiedCb_.Checked)
			{
				timestamp = timestampCtrl_.Value;
			}
			else
			{
				timestamp = DateTime.MinValue;
			}

			return true;
		}

		/// <summary>
		/// Toggles the enabled state of the value control.
		/// </summary>
		private void TimestampSpecifiedCB_CheckedChanged(object sender, System.EventArgs e)
		{
			 timestampCtrl_.Enabled = timestampSpecifiedCb_.Checked;
		}
	}
}

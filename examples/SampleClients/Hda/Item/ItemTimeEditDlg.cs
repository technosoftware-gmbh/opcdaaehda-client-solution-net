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

#endregion

namespace SampleClients.Hda.Item
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class ItemTimeEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel mainPn_;
		private System.Windows.Forms.Label timestampLb_;
		private System.Windows.Forms.DateTimePicker timestampCtrl_;
		private System.ComponentModel.IContainer components = null;

		public ItemTimeEditDlg()
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
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.okBtn_ = new System.Windows.Forms.Button();
			this.mainPn_ = new System.Windows.Forms.Panel();
			this.timestampCtrl_ = new System.Windows.Forms.DateTimePicker();
			this.timestampLb_ = new System.Windows.Forms.Label();
			this.buttonsPn_.SuspendLayout();
			this.mainPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(128, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 26);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(208, 36);
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
			// MainPN
			// 
			this.mainPn_.Controls.Add(this.timestampCtrl_);
			this.mainPn_.Controls.Add(this.timestampLb_);
			this.mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPn_.DockPadding.Left = 4;
			this.mainPn_.DockPadding.Right = 4;
			this.mainPn_.DockPadding.Top = 4;
			this.mainPn_.Location = new System.Drawing.Point(0, 0);
			this.mainPn_.Name = "mainPn_";
			this.mainPn_.Size = new System.Drawing.Size(208, 26);
			this.mainPn_.TabIndex = 1;
			// 
			// TimestampCTRL
			// 
			this.timestampCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.timestampCtrl_.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.timestampCtrl_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.timestampCtrl_.Location = new System.Drawing.Point(76, 4);
			this.timestampCtrl_.Name = "timestampCtrl_";
			this.timestampCtrl_.Size = new System.Drawing.Size(128, 20);
			this.timestampCtrl_.TabIndex = 4;
			// 
			// TimestampLB
			// 
			this.timestampLb_.Location = new System.Drawing.Point(4, 4);
			this.timestampLb_.Name = "timestampLb_";
			this.timestampLb_.Size = new System.Drawing.Size(68, 23);
			this.timestampLb_.TabIndex = 3;
			this.timestampLb_.Text = "Timestamp";
			this.timestampLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemTimeEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(208, 62);
			this.Controls.Add(this.mainPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "ItemTimeEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Item Time";
			this.buttonsPn_.ResumeLayout(false);
			this.mainPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to edit an item value.
		/// </summary>
		public DateTime ShowDialog(DateTime time)
		{
			// initialize controls.
			if (timestampCtrl_.MinDate > time)
			{
				timestampCtrl_.Value = timestampCtrl_.MinDate;
			}
			else
			{
				timestampCtrl_.Value = time;
			}

			// display dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return DateTime.MinValue;
			}

			// update object.
			time = new DateTime();

			if (timestampCtrl_.Value == timestampCtrl_.MinDate)
			{
				time = DateTime.MinValue;
			}
			else
			{
				time = timestampCtrl_.Value;
			}

			// return new value.
			return time;
		}
		#endregion
	}
}

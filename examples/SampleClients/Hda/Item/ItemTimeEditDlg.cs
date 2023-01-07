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
			buttonsPn_.SuspendLayout();
			mainPn_.SuspendLayout();
			SuspendLayout();
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(128, 8);
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
			buttonsPn_.Size = new System.Drawing.Size(208, 36);
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
			// MainPN
			// 
			mainPn_.Controls.Add(timestampCtrl_);
			mainPn_.Controls.Add(timestampLb_);
			mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			mainPn_.DockPadding.Left = 4;
			mainPn_.DockPadding.Right = 4;
			mainPn_.DockPadding.Top = 4;
			mainPn_.Location = new System.Drawing.Point(0, 0);
			mainPn_.Name = "mainPn_";
			mainPn_.Size = new System.Drawing.Size(208, 26);
			mainPn_.TabIndex = 1;
			// 
			// TimestampCTRL
			// 
			timestampCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			timestampCtrl_.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			timestampCtrl_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			timestampCtrl_.Location = new System.Drawing.Point(76, 4);
			timestampCtrl_.Name = "timestampCtrl_";
			timestampCtrl_.Size = new System.Drawing.Size(128, 20);
			timestampCtrl_.TabIndex = 4;
			// 
			// TimestampLB
			// 
			timestampLb_.Location = new System.Drawing.Point(4, 4);
			timestampLb_.Name = "timestampLb_";
			timestampLb_.Size = new System.Drawing.Size(68, 23);
			timestampLb_.TabIndex = 3;
			timestampLb_.Text = "Timestamp";
			timestampLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemTimeEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(208, 62);
			Controls.Add(mainPn_);
			Controls.Add(buttonsPn_);
			Name = "ItemTimeEditDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Edit Item Time";
			buttonsPn_.ResumeLayout(false);
			mainPn_.ResumeLayout(false);
			ResumeLayout(false);

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

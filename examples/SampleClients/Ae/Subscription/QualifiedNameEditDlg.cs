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
using System.Windows.Forms;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A dialog that displays the current status of an OPC server.
    /// </summary>
    public class QualifiedNameEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Label qualifiedNameLb_;
		private System.Windows.Forms.TextBox qualifiedNameTb_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public QualifiedNameEditDlg()
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
			qualifiedNameLb_ = new System.Windows.Forms.Label();
			qualifiedNameTb_ = new System.Windows.Forms.TextBox();
			buttonsPn_ = new System.Windows.Forms.Panel();
			okBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			buttonsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// QualifiedNameLB
			// 
			qualifiedNameLb_.Location = new System.Drawing.Point(4, 4);
			qualifiedNameLb_.Name = "qualifiedNameLb_";
			qualifiedNameLb_.Size = new System.Drawing.Size(100, 20);
			qualifiedNameLb_.TabIndex = 1;
			qualifiedNameLb_.Text = "Qualified Name";
			qualifiedNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualifiedNameTB
			// 
			qualifiedNameTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			qualifiedNameTb_.Location = new System.Drawing.Point(88, 4);
			qualifiedNameTb_.Name = "qualifiedNameTb_";
			qualifiedNameTb_.Size = new System.Drawing.Size(232, 20);
			qualifiedNameTb_.TabIndex = 2;
			qualifiedNameTb_.Text = "";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 26);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(328, 36);
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
			cancelBtn_.Location = new System.Drawing.Point(248, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// QualifiedNameEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = cancelBtn_;
			ClientSize = new System.Drawing.Size(328, 62);
			Controls.Add(qualifiedNameTb_);
			Controls.Add(buttonsPn_);
			Controls.Add(qualifiedNameLb_);
			MaximizeBox = false;
			MinimumSize = new System.Drawing.Size(312, 0);
			Name = "QualifiedNameEditDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Edit Qualified Name";
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		#region Private Members
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to change the browse filter settings.
		/// </summary>
		public string ShowDialog(string filter)
		{
			qualifiedNameTb_.Text = filter;

			if (ShowDialog() == DialogResult.OK)
			{
				return qualifiedNameTb_.Text;
			}

			return null;
		}
		#endregion
	}
}

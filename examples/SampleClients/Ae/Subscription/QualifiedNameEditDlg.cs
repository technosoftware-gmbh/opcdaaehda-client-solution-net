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
			this.qualifiedNameLb_ = new System.Windows.Forms.Label();
			this.qualifiedNameTb_ = new System.Windows.Forms.TextBox();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.okBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// QualifiedNameLB
			// 
			this.qualifiedNameLb_.Location = new System.Drawing.Point(4, 4);
			this.qualifiedNameLb_.Name = "qualifiedNameLb_";
			this.qualifiedNameLb_.Size = new System.Drawing.Size(100, 20);
			this.qualifiedNameLb_.TabIndex = 1;
			this.qualifiedNameLb_.Text = "Qualified Name";
			this.qualifiedNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualifiedNameTB
			// 
			this.qualifiedNameTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.qualifiedNameTb_.Location = new System.Drawing.Point(88, 4);
			this.qualifiedNameTb_.Name = "qualifiedNameTb_";
			this.qualifiedNameTb_.Size = new System.Drawing.Size(232, 20);
			this.qualifiedNameTb_.TabIndex = 2;
			this.qualifiedNameTb_.Text = "";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 26);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(328, 36);
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
			this.cancelBtn_.Location = new System.Drawing.Point(248, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// QualifiedNameEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(328, 62);
			this.Controls.Add(this.qualifiedNameTb_);
			this.Controls.Add(this.buttonsPn_);
			this.Controls.Add(this.qualifiedNameLb_);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(312, 0);
			this.Name = "QualifiedNameEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Qualified Name";
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

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

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

using System.Windows.Forms;

using Technosoftware.DaAeHdaClient;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// A dialog used specify the username/password required to access a OPC server.
    /// </summary>
    public class NetworkCredentialsDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Panel TopPN;
		private System.Windows.Forms.TextBox DomainTB;
		private System.Windows.Forms.Label DomainLB;
		private System.Windows.Forms.Label UserNameLB;
		private System.Windows.Forms.Label PasswordLB;
		private System.Windows.Forms.TextBox UserNameTB;
		private System.Windows.Forms.TextBox PasswordTB;
		private System.ComponentModel.IContainer components = null;

		public NetworkCredentialsDlg()
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
			this.OkBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.DomainTB = new System.Windows.Forms.TextBox();
			this.DomainLB = new System.Windows.Forms.Label();
			this.UserNameLB = new System.Windows.Forms.Label();
			this.PasswordLB = new System.Windows.Forms.Label();
			this.TopPN = new System.Windows.Forms.Panel();
			this.PasswordTB = new System.Windows.Forms.TextBox();
			this.UserNameTB = new System.Windows.Forms.TextBox();
			this.ButtonsPN.SuspendLayout();
			this.TopPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
			this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkBTN.Location = new System.Drawing.Point(47, 8);
			this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
			this.OkBTN.TabIndex = 0;
			this.OkBTN.Text = "OK";
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(128, 8);
			this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
			this.CancelBTN.TabIndex = 1;
			this.CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 74);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(208, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// DomainTB
			// 
			this.DomainTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.DomainTB.Location = new System.Drawing.Point(68, 52);
			this.DomainTB.Name = "DomainTB";
			this.DomainTB.Size = new System.Drawing.Size(136, 20);
			this.DomainTB.TabIndex = 5;
			// 
			// DomainLB
			// 
			this.DomainLB.Location = new System.Drawing.Point(4, 52);
			this.DomainLB.Name = "DomainLB";
			this.DomainLB.Size = new System.Drawing.Size(64, 23);
			this.DomainLB.TabIndex = 4;
			this.DomainLB.Text = "Domain";
			this.DomainLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UserNameLB
			// 
			this.UserNameLB.Location = new System.Drawing.Point(4, 4);
			this.UserNameLB.Name = "UserNameLB";
			this.UserNameLB.Size = new System.Drawing.Size(64, 23);
			this.UserNameLB.TabIndex = 0;
			this.UserNameLB.Text = "User Name";
			this.UserNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PasswordLB
			// 
			this.PasswordLB.Location = new System.Drawing.Point(4, 28);
			this.PasswordLB.Name = "PasswordLB";
			this.PasswordLB.Size = new System.Drawing.Size(64, 23);
			this.PasswordLB.TabIndex = 2;
			this.PasswordLB.Text = "Password";
			this.PasswordLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
			this.TopPN.Controls.Add(this.PasswordTB);
			this.TopPN.Controls.Add(this.UserNameTB);
			this.TopPN.Controls.Add(this.DomainTB);
			this.TopPN.Controls.Add(this.UserNameLB);
			this.TopPN.Controls.Add(this.PasswordLB);
			this.TopPN.Controls.Add(this.DomainLB);
			this.TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TopPN.Location = new System.Drawing.Point(0, 0);
			this.TopPN.Name = "TopPN";
            this.TopPN.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			this.TopPN.Size = new System.Drawing.Size(208, 110);
			this.TopPN.TabIndex = 1;
			// 
			// PasswordTB
			// 
			this.PasswordTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.PasswordTB.Location = new System.Drawing.Point(68, 28);
			this.PasswordTB.Name = "PasswordTB";
			this.PasswordTB.PasswordChar = '*';
			this.PasswordTB.Size = new System.Drawing.Size(136, 20);
			this.PasswordTB.TabIndex = 3;
			// 
			// UserNameTB
			// 
			this.UserNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.UserNameTB.Location = new System.Drawing.Point(68, 4);
			this.UserNameTB.Name = "UserNameTB";
			this.UserNameTB.Size = new System.Drawing.Size(136, 20);
			this.UserNameTB.TabIndex = 1;
			// 
			// NetworkCredentialsDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(208, 110);
			this.Controls.Add(this.ButtonsPN);
			this.Controls.Add(this.TopPN);
			this.Name = "NetworkCredentialsDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Login";
			this.ButtonsPN.ResumeLayout(false);
			this.TopPN.ResumeLayout(false);
            this.TopPN.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Displays the network credentials in a model dialog.
		/// </summary>
		public OpcUserIdentity ShowDialog(OpcUserIdentity userIdentity)
		{
			if (userIdentity != null)
			{
				UserNameTB.Text = userIdentity.Username;
				PasswordTB.Text = userIdentity.Password;
				DomainTB.Text   = userIdentity.Domain;
			}

			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			if (DomainTB.Text == null || DomainTB.Text == "")
			{
				return new OpcUserIdentity(UserNameTB.Text, PasswordTB.Text);
			}

			return new OpcUserIdentity(UserNameTB.Text, PasswordTB.Text);
		}
	}
}

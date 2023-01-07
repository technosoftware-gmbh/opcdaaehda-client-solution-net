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
			OkBTN = new System.Windows.Forms.Button();
			CancelBTN = new System.Windows.Forms.Button();
			ButtonsPN = new System.Windows.Forms.Panel();
			DomainTB = new System.Windows.Forms.TextBox();
			DomainLB = new System.Windows.Forms.Label();
			UserNameLB = new System.Windows.Forms.Label();
			PasswordLB = new System.Windows.Forms.Label();
			TopPN = new System.Windows.Forms.Panel();
			PasswordTB = new System.Windows.Forms.TextBox();
			UserNameTB = new System.Windows.Forms.TextBox();
			ButtonsPN.SuspendLayout();
			TopPN.SuspendLayout();
			SuspendLayout();
			// 
			// OkBTN
			// 
			OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            OkBTN.Location = new System.Drawing.Point(47, 8);
			OkBTN.Name = "OkBTN";
            OkBTN.Size = new System.Drawing.Size(75, 23);
			OkBTN.TabIndex = 0;
			OkBTN.Text = "OK";
			// 
			// CancelBTN
			// 
			CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			CancelBTN.Location = new System.Drawing.Point(128, 8);
			CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new System.Drawing.Size(75, 23);
			CancelBTN.TabIndex = 1;
			CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			ButtonsPN.Controls.Add(CancelBTN);
			ButtonsPN.Controls.Add(OkBTN);
			ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			ButtonsPN.Location = new System.Drawing.Point(0, 74);
			ButtonsPN.Name = "ButtonsPN";
			ButtonsPN.Size = new System.Drawing.Size(208, 36);
			ButtonsPN.TabIndex = 0;
			// 
			// DomainTB
			// 
			DomainTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			DomainTB.Location = new System.Drawing.Point(68, 52);
			DomainTB.Name = "DomainTB";
			DomainTB.Size = new System.Drawing.Size(136, 20);
			DomainTB.TabIndex = 5;
			// 
			// DomainLB
			// 
			DomainLB.Location = new System.Drawing.Point(4, 52);
			DomainLB.Name = "DomainLB";
			DomainLB.Size = new System.Drawing.Size(64, 23);
			DomainLB.TabIndex = 4;
			DomainLB.Text = "Domain";
			DomainLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UserNameLB
			// 
			UserNameLB.Location = new System.Drawing.Point(4, 4);
			UserNameLB.Name = "UserNameLB";
			UserNameLB.Size = new System.Drawing.Size(64, 23);
			UserNameLB.TabIndex = 0;
			UserNameLB.Text = "User Name";
			UserNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PasswordLB
			// 
			PasswordLB.Location = new System.Drawing.Point(4, 28);
			PasswordLB.Name = "PasswordLB";
			PasswordLB.Size = new System.Drawing.Size(64, 23);
			PasswordLB.TabIndex = 2;
			PasswordLB.Text = "Password";
			PasswordLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
			TopPN.Controls.Add(PasswordTB);
			TopPN.Controls.Add(UserNameTB);
			TopPN.Controls.Add(DomainTB);
			TopPN.Controls.Add(UserNameLB);
			TopPN.Controls.Add(PasswordLB);
			TopPN.Controls.Add(DomainLB);
			TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
			TopPN.Location = new System.Drawing.Point(0, 0);
			TopPN.Name = "TopPN";
            TopPN.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			TopPN.Size = new System.Drawing.Size(208, 110);
			TopPN.TabIndex = 1;
			// 
			// PasswordTB
			// 
			PasswordTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			PasswordTB.Location = new System.Drawing.Point(68, 28);
			PasswordTB.Name = "PasswordTB";
			PasswordTB.PasswordChar = '*';
			PasswordTB.Size = new System.Drawing.Size(136, 20);
			PasswordTB.TabIndex = 3;
			// 
			// UserNameTB
			// 
			UserNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			UserNameTB.Location = new System.Drawing.Point(68, 4);
			UserNameTB.Name = "UserNameTB";
			UserNameTB.Size = new System.Drawing.Size(136, 20);
			UserNameTB.TabIndex = 1;
			// 
			// NetworkCredentialsDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = CancelBTN;
			ClientSize = new System.Drawing.Size(208, 110);
			Controls.Add(ButtonsPN);
			Controls.Add(TopPN);
			Name = "NetworkCredentialsDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Set Login";
			ButtonsPN.ResumeLayout(false);
			TopPN.ResumeLayout(false);
            TopPN.PerformLayout();
			ResumeLayout(false);

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

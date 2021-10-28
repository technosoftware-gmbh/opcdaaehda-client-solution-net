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
using System.Net;
using System.Windows.Forms;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// A dialog used specify the username/password required to access a OPC server.
    /// </summary>
    public class ProxyServerDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Panel TopPN;
		private System.Windows.Forms.Label UserNameLB;
		private System.Windows.Forms.TextBox AddressTB;
		private System.ComponentModel.IContainer components = null;

		public ProxyServerDlg()
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
			this.UserNameLB = new System.Windows.Forms.Label();
			this.TopPN = new System.Windows.Forms.Panel();
			this.AddressTB = new System.Windows.Forms.TextBox();
			this.ButtonsPN.SuspendLayout();
			this.TopPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
			this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkBTN.Location = new System.Drawing.Point(111, 8);
			this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(192, 8);
			this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 26);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(272, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// UserNameLB
			// 
			this.UserNameLB.Location = new System.Drawing.Point(4, 4);
			this.UserNameLB.Name = "UserNameLB";
			this.UserNameLB.Size = new System.Drawing.Size(28, 23);
			this.UserNameLB.TabIndex = 0;
			this.UserNameLB.Text = "URL";
			this.UserNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
			this.TopPN.Controls.Add(this.AddressTB);
			this.TopPN.Controls.Add(this.UserNameLB);
			this.TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TopPN.Location = new System.Drawing.Point(0, 0);
			this.TopPN.Name = "TopPN";
            this.TopPN.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			this.TopPN.Size = new System.Drawing.Size(272, 62);
			this.TopPN.TabIndex = 1;
			// 
			// AddressTB
			// 
			this.AddressTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.AddressTB.Location = new System.Drawing.Point(36, 5);
			this.AddressTB.Name = "AddressTB";
			this.AddressTB.Size = new System.Drawing.Size(232, 20);
			this.AddressTB.TabIndex = 1;
			// 
			// ProxyServerDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(272, 62);
			this.Controls.Add(this.ButtonsPN);
			this.Controls.Add(this.TopPN);
			this.Name = "ProxyServerDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Proxy Server";
			this.ButtonsPN.ResumeLayout(false);
			this.TopPN.ResumeLayout(false);
            this.TopPN.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Displays the network credentials in a model dialog.
		/// </summary>
		public WebProxy ShowDialog(WebProxy proxy)
		{
			if (proxy != null)
			{
				AddressTB.Text = proxy.Address.ToString();
			}

			if (ShowDialog() != DialogResult.OK)
			{
				return proxy;
			}

			if (AddressTB.Text != "")
			{
				if (!AddressTB.Text.StartsWith("http://"))
				{
					AddressTB.Text = "http://" + AddressTB.Text;
				}

				return new WebProxy(new Uri(AddressTB.Text));
			}

			return null;
		}
	}
}

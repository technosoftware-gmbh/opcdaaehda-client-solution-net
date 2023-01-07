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
			UserNameLB = new System.Windows.Forms.Label();
			TopPN = new System.Windows.Forms.Panel();
			AddressTB = new System.Windows.Forms.TextBox();
			ButtonsPN.SuspendLayout();
			TopPN.SuspendLayout();
			SuspendLayout();
			// 
			// OkBTN
			// 
			OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            OkBTN.Location = new System.Drawing.Point(111, 8);
			OkBTN.Name = "OkBTN";
            OkBTN.Size = new System.Drawing.Size(75, 23);
			OkBTN.TabIndex = 1;
			OkBTN.Text = "OK";
			// 
			// CancelBTN
			// 
			CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			CancelBTN.Location = new System.Drawing.Point(192, 8);
			CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new System.Drawing.Size(75, 23);
			CancelBTN.TabIndex = 0;
			CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			ButtonsPN.Controls.Add(CancelBTN);
			ButtonsPN.Controls.Add(OkBTN);
			ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			ButtonsPN.Location = new System.Drawing.Point(0, 26);
			ButtonsPN.Name = "ButtonsPN";
			ButtonsPN.Size = new System.Drawing.Size(272, 36);
			ButtonsPN.TabIndex = 0;
			// 
			// UserNameLB
			// 
			UserNameLB.Location = new System.Drawing.Point(4, 4);
			UserNameLB.Name = "UserNameLB";
			UserNameLB.Size = new System.Drawing.Size(28, 23);
			UserNameLB.TabIndex = 0;
			UserNameLB.Text = "URL";
			UserNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
			TopPN.Controls.Add(AddressTB);
			TopPN.Controls.Add(UserNameLB);
			TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
			TopPN.Location = new System.Drawing.Point(0, 0);
			TopPN.Name = "TopPN";
            TopPN.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			TopPN.Size = new System.Drawing.Size(272, 62);
			TopPN.TabIndex = 1;
			// 
			// AddressTB
			// 
			AddressTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			AddressTB.Location = new System.Drawing.Point(36, 5);
			AddressTB.Name = "AddressTB";
			AddressTB.Size = new System.Drawing.Size(232, 20);
			AddressTB.TabIndex = 1;
			// 
			// ProxyServerDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = CancelBTN;
			ClientSize = new System.Drawing.Size(272, 62);
			Controls.Add(ButtonsPN);
			Controls.Add(TopPN);
			Name = "ProxyServerDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Set Proxy Server";
			ButtonsPN.ResumeLayout(false);
			TopPN.ResumeLayout(false);
            TopPN.PerformLayout();
			ResumeLayout(false);

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

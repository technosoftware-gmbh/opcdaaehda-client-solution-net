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

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// A dialog used to browse the address space of an OPC DA server.
    /// </summary>
    public class BrowseItemsDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel MainPN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private BrowseTreeCtrl BrowseCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BrowseItemsDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			BrowseCTRL.ItemPicked += new ItemPicked_EventHandler(BrowseCTRL_ItemPicked);
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
			this.MainPN = new System.Windows.Forms.Panel();
			this.BrowseCTRL = new BrowseTreeCtrl();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.OkBTN = new System.Windows.Forms.Button();
			this.MainPN.SuspendLayout();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainPN
			// 
			this.MainPN.Controls.Add(this.BrowseCTRL);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.Location = new System.Drawing.Point(0, 0);
			this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(4, 4, 0, 0);
			this.MainPN.Size = new System.Drawing.Size(792, 300);
			this.MainPN.TabIndex = 6;
			// 
			// BrowseCTRL
			// 
			this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseCTRL.Location = new System.Drawing.Point(4, 4);
			this.BrowseCTRL.Name = "BrowseCTRL";
			this.BrowseCTRL.Size = new System.Drawing.Size(788, 296);
			this.BrowseCTRL.TabIndex = 0;
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 300);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(792, 36);
			this.ButtonsPN.TabIndex = 7;
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(712, 8);
			this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// OkBTN
			// 
			this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkBTN.Location = new System.Drawing.Point(631, 8);
			this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			// 
			// BrowseItemsDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 336);
			this.Controls.Add(this.MainPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "BrowseItemsDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Browse Items";
			this.MainPN.ResumeLayout(false);
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The server used to process read request.
		/// </summary>
		private TsCDaServer m_server = null;

		private OpcItem m_itemID = null;

		/// <summary>
		/// Displays the address space for the specified server.
		/// </summary>
		public OpcItem ShowDialog(TsCDaServer server)
		{
			try
			{
				if (server == null) throw new ArgumentNullException("server");

				m_server = server;
				m_itemID = null;

				TsCDaBrowseFilters filters = new TsCDaBrowseFilters();

				filters.ReturnAllProperties  = false;
				filters.ReturnPropertyValues = false;

				BrowseCTRL.ShowSingleServer(m_server, filters);

				if (ShowDialog() != DialogResult.OK)
				{
					return null;
				}

				return m_itemID;
			}
			finally
			{
				// ensure server connection in the browse control are closed.
				BrowseCTRL.Clear();
			}
		}

		/// <summary>
		/// Displays the address space for the specified server.
		/// </summary>
		public void Initialize(TsCDaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;

			TsCDaBrowseFilters filters = new TsCDaBrowseFilters();

			filters.ReturnAllProperties  = true;
			filters.ReturnPropertyValues = true;

			BrowseCTRL.ShowSingleServer(m_server, filters);

			ShowDialog();

			// ensure server connection in the browse control are closed.
			BrowseCTRL.Clear();
		}
		
		/// <summary>
		/// Called when the close button is clicked.
		/// </summary>
		private void DoneBTN_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Called when an item is explicitly picked.
		/// </summary>
		private void BrowseCTRL_ItemPicked(OpcItem itemID)
		{
			m_itemID = itemID;
			DialogResult = DialogResult.OK;
		}
	}
}

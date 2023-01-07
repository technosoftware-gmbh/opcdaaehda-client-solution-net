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
			MainPN = new System.Windows.Forms.Panel();
			BrowseCTRL = new BrowseTreeCtrl();
			ButtonsPN = new System.Windows.Forms.Panel();
			CancelBTN = new System.Windows.Forms.Button();
			OkBTN = new System.Windows.Forms.Button();
			MainPN.SuspendLayout();
			ButtonsPN.SuspendLayout();
			SuspendLayout();
			// 
			// MainPN
			// 
			MainPN.Controls.Add(BrowseCTRL);
			MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			MainPN.Location = new System.Drawing.Point(0, 0);
			MainPN.Name = "MainPN";
            MainPN.Padding = new System.Windows.Forms.Padding(4, 4, 0, 0);
			MainPN.Size = new System.Drawing.Size(792, 300);
			MainPN.TabIndex = 6;
			// 
			// BrowseCTRL
			// 
			BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			BrowseCTRL.Location = new System.Drawing.Point(4, 4);
			BrowseCTRL.Name = "BrowseCTRL";
			BrowseCTRL.Size = new System.Drawing.Size(788, 296);
			BrowseCTRL.TabIndex = 0;
			// 
			// ButtonsPN
			// 
			ButtonsPN.Controls.Add(CancelBTN);
			ButtonsPN.Controls.Add(OkBTN);
			ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			ButtonsPN.Location = new System.Drawing.Point(0, 300);
			ButtonsPN.Name = "ButtonsPN";
			ButtonsPN.Size = new System.Drawing.Size(792, 36);
			ButtonsPN.TabIndex = 7;
			// 
			// CancelBTN
			// 
			CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			CancelBTN.Location = new System.Drawing.Point(712, 8);
			CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new System.Drawing.Size(75, 23);
			CancelBTN.TabIndex = 0;
			CancelBTN.Text = "Cancel";
			// 
			// OkBTN
			// 
			OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            OkBTN.Location = new System.Drawing.Point(631, 8);
			OkBTN.Name = "OkBTN";
            OkBTN.Size = new System.Drawing.Size(75, 23);
			OkBTN.TabIndex = 1;
			OkBTN.Text = "OK";
			// 
			// BrowseItemsDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(792, 336);
			Controls.Add(MainPN);
			Controls.Add(ButtonsPN);
			Name = "BrowseItemsDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Browse Items";
			MainPN.ResumeLayout(false);
			ButtonsPN.ResumeLayout(false);
			ResumeLayout(false);

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

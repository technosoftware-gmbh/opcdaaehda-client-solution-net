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
    /// A control used browse and select a single OPC server. 
    /// </summary>
    public class SelectServerDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel TopPN;
		private System.Windows.Forms.Label SpecificationLB;
		private System.Windows.Forms.ComboBox SpecificationCB;
		private BrowseTreeCtrl ServersCTRL;
		private System.Windows.Forms.Panel MainPN;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SelectServerDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            

			SpecificationCB.Items.Add(OpcSpecification.OPC_AE_10);		
			SpecificationCB.Items.Add(OpcSpecification.OPC_DA_10);
			SpecificationCB.Items.Add(OpcSpecification.OPC_DA_20);	
			SpecificationCB.Items.Add(OpcSpecification.OPC_DA_30);	
			SpecificationCB.Items.Add(OpcSpecification.OPC_HDA_10);
	
			SpecificationCB.SelectedItem = null;

			ServersCTRL.ServerPicked += new ServerPicked_EventHandler(OnServerPicked);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectServerDlg));
            ButtonsPN = new System.Windows.Forms.Panel();
            CancelBTN = new System.Windows.Forms.Button();
            OkBTN = new System.Windows.Forms.Button();
            SpecificationLB = new System.Windows.Forms.Label();
            TopPN = new System.Windows.Forms.Panel();
            SpecificationCB = new System.Windows.Forms.ComboBox();
            ServersCTRL = new BrowseTreeCtrl();
            MainPN = new System.Windows.Forms.Panel();
            ButtonsPN.SuspendLayout();
            TopPN.SuspendLayout();
            MainPN.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonsPN
            // 
            ButtonsPN.Controls.Add(CancelBTN);
            ButtonsPN.Controls.Add(OkBTN);
            ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            ButtonsPN.Location = new System.Drawing.Point(0, 202);
            ButtonsPN.Name = "ButtonsPN";
            ButtonsPN.Size = new System.Drawing.Size(296, 36);
            ButtonsPN.TabIndex = 1;
            // 
            // CancelBTN
            // 
            CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            CancelBTN.Location = new System.Drawing.Point(216, 8);
            CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new System.Drawing.Size(75, 23);
            CancelBTN.TabIndex = 0;
            CancelBTN.Text = "Cancel";
            // 
            // OkBTN
            // 
            OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            OkBTN.Location = new System.Drawing.Point(135, 6);
            OkBTN.Name = "OkBTN";
            OkBTN.Size = new System.Drawing.Size(75, 23);
            OkBTN.TabIndex = 1;
            OkBTN.Text = "OK";
            // 
            // SpecificationLB
            // 
            SpecificationLB.Dock = System.Windows.Forms.DockStyle.Left;
            SpecificationLB.Location = new System.Drawing.Point(4, 4);
            SpecificationLB.Name = "SpecificationLB";
            SpecificationLB.Size = new System.Drawing.Size(76, 20);
            SpecificationLB.TabIndex = 2;
            SpecificationLB.Text = "Specification";
            SpecificationLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TopPN
            // 
            TopPN.Controls.Add(SpecificationCB);
            TopPN.Controls.Add(SpecificationLB);
            TopPN.Dock = System.Windows.Forms.DockStyle.Top;
            TopPN.Location = new System.Drawing.Point(0, 0);
            TopPN.Name = "TopPN";
            TopPN.Padding = new System.Windows.Forms.Padding(4);
            TopPN.Size = new System.Drawing.Size(296, 28);
            TopPN.TabIndex = 5;
            // 
            // SpecificationCB
            // 
            SpecificationCB.Dock = System.Windows.Forms.DockStyle.Fill;
            SpecificationCB.Location = new System.Drawing.Point(80, 4);
            SpecificationCB.Name = "SpecificationCB";
            SpecificationCB.Size = new System.Drawing.Size(212, 21);
            SpecificationCB.TabIndex = 3;
            SpecificationCB.SelectedIndexChanged += new System.EventHandler(SpecificationCB_SelectedIndexChanged);
            // 
            // ServersCTRL
            // 
            ServersCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            ServersCTRL.Location = new System.Drawing.Point(4, 0);
            ServersCTRL.Name = "ServersCTRL";
            ServersCTRL.Size = new System.Drawing.Size(288, 174);
            ServersCTRL.TabIndex = 0;
            // 
            // MainPN
            // 
            MainPN.Controls.Add(ServersCTRL);
            MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            MainPN.Location = new System.Drawing.Point(0, 28);
            MainPN.Name = "MainPN";
            MainPN.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            MainPN.Size = new System.Drawing.Size(296, 174);
            MainPN.TabIndex = 6;
            // 
            // SelectServerDlg
            // 
            AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            CancelButton = CancelBTN;
            ClientSize = new System.Drawing.Size(296, 238);
            Controls.Add(MainPN);
            Controls.Add(TopPN);
            Controls.Add(ButtonsPN);
            Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            Name = "SelectServerDlg";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Select Server";
            ButtonsPN.ResumeLayout(false);
            TopPN.ResumeLayout(false);
            TopPN.PerformLayout();
            MainPN.ResumeLayout(false);
            ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the use to select a server with the specified specification.
		/// </summary>
		public OpcServer ShowDialog(OpcSpecification specification)
		{
			SpecificationCB.SelectedItem = specification;

			if (ShowDialog() != DialogResult.OK)
			{
				ServersCTRL.Clear();
				return null;
			}

			OpcServer server = ServersCTRL.SelectedServer;
			ServersCTRL.Clear();
			return server;
		}

        /// <summary>
		/// Called when a Session is picked in the browse control.
		/// </summary>
		private void OnServerPicked(OpcServer server)
		{
			if (server != null)	DialogResult = DialogResult.OK;
		}

		/// <summary>
		/// Updates the specification of servers displayed in the browse control.
		/// </summary>
		private void SpecificationCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ServersCTRL.ShowAllServers((OpcSpecification)SpecificationCB.SelectedItem, null);
		}
	}
}

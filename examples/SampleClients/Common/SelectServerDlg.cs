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
            Icon = ClientUtils.GetAppIcon();

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
            this.ButtonsPN = new System.Windows.Forms.Panel();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.OkBTN = new System.Windows.Forms.Button();
            this.SpecificationLB = new System.Windows.Forms.Label();
            this.TopPN = new System.Windows.Forms.Panel();
            this.SpecificationCB = new System.Windows.Forms.ComboBox();
            this.ServersCTRL = new BrowseTreeCtrl();
            this.MainPN = new System.Windows.Forms.Panel();
            this.ButtonsPN.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Controls.Add(this.OkBTN);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 202);
            this.ButtonsPN.Name = "ButtonsPN";
            this.ButtonsPN.Size = new System.Drawing.Size(296, 36);
            this.ButtonsPN.TabIndex = 1;
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(216, 8);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 0;
            this.CancelBTN.Text = "Cancel";
            // 
            // OkBTN
            // 
            this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkBTN.Location = new System.Drawing.Point(135, 6);
            this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
            this.OkBTN.TabIndex = 1;
            this.OkBTN.Text = "OK";
            // 
            // SpecificationLB
            // 
            this.SpecificationLB.Dock = System.Windows.Forms.DockStyle.Left;
            this.SpecificationLB.Location = new System.Drawing.Point(4, 4);
            this.SpecificationLB.Name = "SpecificationLB";
            this.SpecificationLB.Size = new System.Drawing.Size(76, 20);
            this.SpecificationLB.TabIndex = 2;
            this.SpecificationLB.Text = "Specification";
            this.SpecificationLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TopPN
            // 
            this.TopPN.Controls.Add(this.SpecificationCB);
            this.TopPN.Controls.Add(this.SpecificationLB);
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPN.Location = new System.Drawing.Point(0, 0);
            this.TopPN.Name = "TopPN";
            this.TopPN.Padding = new System.Windows.Forms.Padding(4);
            this.TopPN.Size = new System.Drawing.Size(296, 28);
            this.TopPN.TabIndex = 5;
            // 
            // SpecificationCB
            // 
            this.SpecificationCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpecificationCB.Location = new System.Drawing.Point(80, 4);
            this.SpecificationCB.Name = "SpecificationCB";
            this.SpecificationCB.Size = new System.Drawing.Size(212, 21);
            this.SpecificationCB.TabIndex = 3;
            this.SpecificationCB.SelectedIndexChanged += new System.EventHandler(this.SpecificationCB_SelectedIndexChanged);
            // 
            // ServersCTRL
            // 
            this.ServersCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServersCTRL.Location = new System.Drawing.Point(4, 0);
            this.ServersCTRL.Name = "ServersCTRL";
            this.ServersCTRL.Size = new System.Drawing.Size(288, 174);
            this.ServersCTRL.TabIndex = 0;
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.ServersCTRL);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 28);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MainPN.Size = new System.Drawing.Size(296, 174);
            this.MainPN.TabIndex = 6;
            // 
            // SelectServerDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.CancelBTN;
            this.ClientSize = new System.Drawing.Size(296, 238);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.TopPN);
            this.Controls.Add(this.ButtonsPN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectServerDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Server";
            this.ButtonsPN.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.TopPN.PerformLayout();
            this.MainPN.ResumeLayout(false);
            this.ResumeLayout(false);

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

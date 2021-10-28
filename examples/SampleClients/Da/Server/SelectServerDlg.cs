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

using SampleClients.Da.Browse;

using Technosoftware.DaAeHdaClient;
using SampleClients.Common;
using Technosoftware.DaAeHdaClient.Da;

using BrowseTreeCtrl = SampleClients.Da.Browse.BrowseTreeCtrl;

#endregion

namespace SampleClients.Da.Server
{
    /// <summary>
    /// A control used browse and select a single OPC server. 
    /// </summary>
    public class SelectServerDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private BrowseTreeCtrl serversCtrl_;
		private System.Windows.Forms.Panel topPn_;
		private System.Windows.Forms.Label specificationLb_;
		private System.Windows.Forms.ComboBox specificationCb_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public SelectServerDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			specificationCb_.Items.Add(OpcSpecification.OPC_DA_20);
			specificationCb_.Items.Add(OpcSpecification.OPC_DA_30);	
			specificationCb_.SelectedItem = null;

			serversCtrl_.ServerPicked += new ServerPickedEventHandler(OnServerPicked);
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
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.okBtn_ = new System.Windows.Forms.Button();
			this.specificationLb_ = new System.Windows.Forms.Label();
			this.serversCtrl_ = new BrowseTreeCtrl();
			this.topPn_ = new System.Windows.Forms.Panel();
			this.specificationCb_ = new System.Windows.Forms.ComboBox();
			this.buttonsPn_.SuspendLayout();
			this.topPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
            this.buttonsPn_.Controls.Add(this.cancelBtn_);
            this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 202);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(280, 36);
			this.buttonsPn_.TabIndex = 1;
			// 
			// CancelBTN
			// 
            this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(200, 8);
			this.cancelBtn_.Name = "cancelBtn_";
            this.cancelBtn_.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// OkBTN
			// 
            this.okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn_.Location = new System.Drawing.Point(119, 8);
			this.okBtn_.Name = "okBtn_";
            this.okBtn_.Size = new System.Drawing.Size(75, 23);
			this.okBtn_.TabIndex = 1;
			this.okBtn_.Text = "OK";
			// 
			// SpecificationLB
			// 
			this.specificationLb_.Location = new System.Drawing.Point(4, 4);
			this.specificationLb_.Name = "specificationLb_";
            this.specificationLb_.Size = new System.Drawing.Size(73, 23);
			this.specificationLb_.TabIndex = 2;
			this.specificationLb_.Text = "Specification";
			this.specificationLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ServersCTRL
			// 
			this.serversCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.serversCtrl_.Location = new System.Drawing.Point(0, 32);
			this.serversCtrl_.Name = "serversCtrl_";
            this.serversCtrl_.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.serversCtrl_.Size = new System.Drawing.Size(280, 170);
			this.serversCtrl_.TabIndex = 4;
			// 
			// TopPN
			// 
            this.topPn_.Controls.Add(this.specificationCb_);
            this.topPn_.Controls.Add(this.specificationLb_);
			this.topPn_.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPn_.Location = new System.Drawing.Point(0, 0);
			this.topPn_.Name = "topPn_";
			this.topPn_.Size = new System.Drawing.Size(280, 32);
			this.topPn_.TabIndex = 5;
			// 
			// SpecificationCB
			// 
            this.specificationCb_.Location = new System.Drawing.Point(73, 4);
			this.specificationCb_.Name = "specificationCb_";
            this.specificationCb_.Size = new System.Drawing.Size(203, 21);
			this.specificationCb_.TabIndex = 3;
			this.specificationCb_.SelectedIndexChanged += new System.EventHandler(this.SpecificationCB_SelectedIndexChanged);
			// 
			// SelectServerDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(280, 238);
            this.Controls.Add(this.serversCtrl_);
            this.Controls.Add(this.topPn_);
            this.Controls.Add(this.buttonsPn_);
			this.Name = "SelectServerDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Server";
			this.buttonsPn_.ResumeLayout(false);
			this.topPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the use to select a server with the specified specification.
		/// </summary>
		public TsCDaServer ShowDialog(OpcSpecification specification)
		{
			specificationCb_.SelectedItem = specification;

			if (ShowDialog() != DialogResult.OK)
			{
				serversCtrl_.Clear();
				return null;
			}

			TsCDaServer server = serversCtrl_.SelectedServer;
			serversCtrl_.Clear();
			return server;
		}

		/// <summary>
		/// Called when a server is picked in the browse control.
		/// </summary>
		private void OnServerPicked(TsCDaServer server)
		{
			if (server != null)	DialogResult = DialogResult.OK;
		}

		/// <summary>
		/// Updates the specification of servers displayed in the browse control.
		/// </summary>
		private void SpecificationCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			serversCtrl_.ShowAllServers((OpcSpecification)specificationCb_.SelectedItem, null);
		}
	}
}

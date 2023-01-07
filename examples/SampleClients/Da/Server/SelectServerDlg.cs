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
            buttonsPn_ = new System.Windows.Forms.Panel();
            cancelBtn_ = new System.Windows.Forms.Button();
            okBtn_ = new System.Windows.Forms.Button();
            specificationLb_ = new System.Windows.Forms.Label();
            serversCtrl_ = new SampleClients.Da.Browse.BrowseTreeCtrl();
            topPn_ = new System.Windows.Forms.Panel();
            specificationCb_ = new System.Windows.Forms.ComboBox();
            buttonsPn_.SuspendLayout();
            topPn_.SuspendLayout();
            SuspendLayout();
            // 
            // buttonsPn_
            // 
            buttonsPn_.Controls.Add(cancelBtn_);
            buttonsPn_.Controls.Add(okBtn_);
            buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
            buttonsPn_.Location = new System.Drawing.Point(0, 194);
            buttonsPn_.Name = "buttonsPn_";
            buttonsPn_.Size = new System.Drawing.Size(336, 44);
            buttonsPn_.TabIndex = 1;
            // 
            // cancelBtn_
            // 
            cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelBtn_.Location = new System.Drawing.Point(240, 10);
            cancelBtn_.Name = "cancelBtn_";
            cancelBtn_.Size = new System.Drawing.Size(90, 28);
            cancelBtn_.TabIndex = 0;
            cancelBtn_.Text = "Cancel";
            // 
            // okBtn_
            // 
            okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
            okBtn_.Location = new System.Drawing.Point(144, 10);
            okBtn_.Name = "okBtn_";
            okBtn_.Size = new System.Drawing.Size(90, 28);
            okBtn_.TabIndex = 1;
            okBtn_.Text = "OK";
            // 
            // specificationLb_
            // 
            specificationLb_.Location = new System.Drawing.Point(5, 5);
            specificationLb_.Name = "specificationLb_";
            specificationLb_.Size = new System.Drawing.Size(87, 28);
            specificationLb_.TabIndex = 2;
            specificationLb_.Text = "Specification";
            specificationLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serversCtrl_
            // 
            serversCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            serversCtrl_.Location = new System.Drawing.Point(0, 39);
            serversCtrl_.Name = "serversCtrl_";
            serversCtrl_.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            serversCtrl_.Size = new System.Drawing.Size(336, 155);
            serversCtrl_.TabIndex = 4;
            // 
            // topPn_
            // 
            topPn_.Controls.Add(specificationCb_);
            topPn_.Controls.Add(specificationLb_);
            topPn_.Dock = System.Windows.Forms.DockStyle.Top;
            topPn_.Location = new System.Drawing.Point(0, 0);
            topPn_.Name = "topPn_";
            topPn_.Size = new System.Drawing.Size(336, 39);
            topPn_.TabIndex = 5;
            // 
            // specificationCb_
            // 
            specificationCb_.Location = new System.Drawing.Point(88, 5);
            specificationCb_.Name = "specificationCb_";
            specificationCb_.Size = new System.Drawing.Size(243, 23);
            specificationCb_.TabIndex = 3;
            specificationCb_.SelectedIndexChanged += new System.EventHandler(SpecificationCB_SelectedIndexChanged);
            // 
            // SelectServerDlg
            // 
            AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            CancelButton = cancelBtn_;
            ClientSize = new System.Drawing.Size(336, 238);
            Controls.Add(serversCtrl_);
            Controls.Add(topPn_);
            Controls.Add(buttonsPn_);
            Name = "SelectServerDlg";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Select Server";
            buttonsPn_.ResumeLayout(false);
            topPn_.ResumeLayout(false);
            ResumeLayout(false);

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

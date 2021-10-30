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

using SampleClients.Common;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Server
{
	/// <summary>
	/// A dialog that displays the current status of an OPC server.
	/// </summary>
	public class ServerStatusDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox startTimeTb_;
		private System.Windows.Forms.Label startTimeLb_;
		private System.Windows.Forms.Label serverStateLb_;
		private System.Windows.Forms.TextBox serverStateTb_;
		private System.Windows.Forms.Label vendorInfoLb_;
		private System.Windows.Forms.Label currentTimeLb_;
		private System.Windows.Forms.TextBox vendorInfoTb_;
		private System.Windows.Forms.TextBox currentTimeTb_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button updateBtn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Label productVersionLb_;
		private System.Windows.Forms.TextBox productVersionTb_;
		private System.Windows.Forms.TextBox statusInfoTb_;
		private System.Windows.Forms.Label statusInfoLb_;
		private System.Windows.Forms.Label maxReturnValuesLb_;
		private System.Windows.Forms.TextBox maxReturnValuesTb_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ServerStatusDlg()
		{
			//
			// Required for Windows Form Designer support
			//
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
			this.startTimeTb_ = new System.Windows.Forms.TextBox();
			this.startTimeLb_ = new System.Windows.Forms.Label();
			this.productVersionLb_ = new System.Windows.Forms.Label();
			this.productVersionTb_ = new System.Windows.Forms.TextBox();
			this.serverStateLb_ = new System.Windows.Forms.Label();
			this.serverStateTb_ = new System.Windows.Forms.TextBox();
			this.vendorInfoLb_ = new System.Windows.Forms.Label();
			this.currentTimeLb_ = new System.Windows.Forms.Label();
			this.vendorInfoTb_ = new System.Windows.Forms.TextBox();
			this.currentTimeTb_ = new System.Windows.Forms.TextBox();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.updateBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.statusInfoTb_ = new System.Windows.Forms.TextBox();
			this.statusInfoLb_ = new System.Windows.Forms.Label();
			this.maxReturnValuesLb_ = new System.Windows.Forms.Label();
			this.maxReturnValuesTb_ = new System.Windows.Forms.TextBox();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// StartTimeTB
			// 
			this.startTimeTb_.Location = new System.Drawing.Point(104, 84);
			this.startTimeTb_.Name = "startTimeTb_";
			this.startTimeTb_.ReadOnly = true;
			this.startTimeTb_.Size = new System.Drawing.Size(128, 20);
			this.startTimeTb_.TabIndex = 12;
			this.startTimeTb_.Text = "";
			// 
			// StartTimeLB
			// 
			this.startTimeLb_.Location = new System.Drawing.Point(4, 84);
			this.startTimeLb_.Name = "startTimeLb_";
			this.startTimeLb_.Size = new System.Drawing.Size(96, 20);
			this.startTimeLb_.TabIndex = 11;
			this.startTimeLb_.Text = "Start Time";
			this.startTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ProductVersionLB
			// 
			this.productVersionLb_.Location = new System.Drawing.Point(4, 24);
			this.productVersionLb_.Name = "productVersionLb_";
			this.productVersionLb_.Size = new System.Drawing.Size(96, 20);
			this.productVersionLb_.TabIndex = 3;
			this.productVersionLb_.Text = "Product Version";
			this.productVersionLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ProductVersionTB
			// 
			this.productVersionTb_.Location = new System.Drawing.Point(104, 24);
			this.productVersionTb_.Name = "productVersionTb_";
			this.productVersionTb_.ReadOnly = true;
			this.productVersionTb_.Size = new System.Drawing.Size(128, 20);
			this.productVersionTb_.TabIndex = 4;
			this.productVersionTb_.Text = "";
			// 
			// ServerStateLB
			// 
			this.serverStateLb_.Location = new System.Drawing.Point(4, 44);
			this.serverStateLb_.Name = "serverStateLb_";
			this.serverStateLb_.Size = new System.Drawing.Size(96, 20);
			this.serverStateLb_.TabIndex = 5;
			this.serverStateLb_.Text = "Server State";
			this.serverStateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ServerStateTB
			// 
			this.serverStateTb_.Location = new System.Drawing.Point(104, 44);
			this.serverStateTb_.Name = "serverStateTb_";
			this.serverStateTb_.ReadOnly = true;
			this.serverStateTb_.Size = new System.Drawing.Size(128, 20);
			this.serverStateTb_.TabIndex = 6;
			this.serverStateTb_.Text = "";
			// 
			// VendorInfoLB
			// 
			this.vendorInfoLb_.Location = new System.Drawing.Point(4, 4);
			this.vendorInfoLb_.Name = "vendorInfoLb_";
			this.vendorInfoLb_.Size = new System.Drawing.Size(96, 20);
			this.vendorInfoLb_.TabIndex = 1;
			this.vendorInfoLb_.Text = "Vendor Info";
			this.vendorInfoLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CurrentTimeLB
			// 
			this.currentTimeLb_.Location = new System.Drawing.Point(4, 104);
			this.currentTimeLb_.Name = "currentTimeLb_";
			this.currentTimeLb_.Size = new System.Drawing.Size(96, 20);
			this.currentTimeLb_.TabIndex = 13;
			this.currentTimeLb_.Text = "Current Time";
			this.currentTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VendorInfoTB
			// 
			this.vendorInfoTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.vendorInfoTb_.Location = new System.Drawing.Point(104, 4);
			this.vendorInfoTb_.Name = "vendorInfoTb_";
			this.vendorInfoTb_.ReadOnly = true;
			this.vendorInfoTb_.Size = new System.Drawing.Size(248, 20);
			this.vendorInfoTb_.TabIndex = 2;
			this.vendorInfoTb_.Text = "";
			// 
			// CurrentTimeTB
			// 
			this.currentTimeTb_.Location = new System.Drawing.Point(104, 104);
			this.currentTimeTb_.Name = "currentTimeTb_";
			this.currentTimeTb_.ReadOnly = true;
			this.currentTimeTb_.Size = new System.Drawing.Size(128, 20);
			this.currentTimeTb_.TabIndex = 14;
			this.currentTimeTb_.Text = "";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.updateBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 146);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(360, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// UpdateBTN
			// 
			this.updateBtn_.Location = new System.Drawing.Point(4, 8);
			this.updateBtn_.Name = "updateBtn_";
			this.updateBtn_.TabIndex = 1;
			this.updateBtn_.Text = "Update";
			this.updateBtn_.Click += new System.EventHandler(this.UpdateBTN_Click);
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(280, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Close";
			// 
			// StatusInfoTB
			// 
			this.statusInfoTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.statusInfoTb_.Location = new System.Drawing.Point(104, 64);
			this.statusInfoTb_.Name = "statusInfoTb_";
			this.statusInfoTb_.ReadOnly = true;
			this.statusInfoTb_.Size = new System.Drawing.Size(248, 20);
			this.statusInfoTb_.TabIndex = 17;
			this.statusInfoTb_.Text = "";
			// 
			// StatusInfoLB
			// 
			this.statusInfoLb_.Location = new System.Drawing.Point(4, 64);
			this.statusInfoLb_.Name = "statusInfoLb_";
			this.statusInfoLb_.Size = new System.Drawing.Size(96, 20);
			this.statusInfoLb_.TabIndex = 18;
			this.statusInfoLb_.Text = "Status Info";
			this.statusInfoLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxReturnValuesLB
			// 
			this.maxReturnValuesLb_.Location = new System.Drawing.Point(4, 124);
			this.maxReturnValuesLb_.Name = "maxReturnValuesLb_";
			this.maxReturnValuesLb_.Size = new System.Drawing.Size(100, 20);
			this.maxReturnValuesLb_.TabIndex = 19;
			this.maxReturnValuesLb_.Text = "Max Return Values";
			this.maxReturnValuesLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxReturnValuesTB
			// 
			this.maxReturnValuesTb_.Location = new System.Drawing.Point(104, 124);
			this.maxReturnValuesTb_.Name = "maxReturnValuesTb_";
			this.maxReturnValuesTb_.ReadOnly = true;
			this.maxReturnValuesTb_.Size = new System.Drawing.Size(128, 20);
			this.maxReturnValuesTb_.TabIndex = 20;
			this.maxReturnValuesTb_.Text = "";
			// 
			// ServerStatusDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(360, 182);
			this.Controls.Add(this.maxReturnValuesTb_);
			this.Controls.Add(this.maxReturnValuesLb_);
			this.Controls.Add(this.statusInfoLb_);
			this.Controls.Add(this.statusInfoTb_);
			this.Controls.Add(this.buttonsPn_);
			this.Controls.Add(this.startTimeTb_);
			this.Controls.Add(this.startTimeLb_);
			this.Controls.Add(this.productVersionLb_);
			this.Controls.Add(this.productVersionTb_);
			this.Controls.Add(this.serverStateLb_);
			this.Controls.Add(this.serverStateTb_);
			this.Controls.Add(this.vendorInfoLb_);
			this.Controls.Add(this.currentTimeLb_);
			this.Controls.Add(this.vendorInfoTb_);
			this.Controls.Add(this.currentTimeTb_);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(600, 216);
			this.MinimumSize = new System.Drawing.Size(350, 216);
			this.Name = "ServerStatusDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Server Status";
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The server used to fetch status information.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// Displays the current server status in a modal dialog.
		/// </summary>
		public void ShowDialog(TsCHdaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;

			GetStatus();
			
			ShowDialog();
		}

		/// <summary>
		/// Get the status of the server.
		/// </summary>
		private void GetStatus()
		{
			try
			{
				OpcServerStatus status = mServer_.GetServerStatus();

				vendorInfoTb_.Text      = status.VendorInfo;
				productVersionTb_.Text  = status.ProductVersion;
				serverStateTb_.Text     = Technosoftware.DaAeHdaClient.OpcConvert.ToString(status.ServerState);
				statusInfoTb_.Text      = status.StatusInfo;
				startTimeTb_.Text       = Technosoftware.DaAeHdaClient.OpcConvert.ToString(status.StartTime);
				currentTimeTb_.Text     = Technosoftware.DaAeHdaClient.OpcConvert.ToString(status.CurrentTime);
				maxReturnValuesTb_.Text = Technosoftware.DaAeHdaClient.OpcConvert.ToString(status.MaxReturnValues);
			}
			catch (Exception e)
			{
				vendorInfoTb_.Text      = null;
				productVersionTb_.Text  = null;
				serverStateTb_.Text     = null;
				statusInfoTb_.Text      = e.Message;
				startTimeTb_.Text       = null;
				currentTimeTb_.Text     = null;
				maxReturnValuesTb_.Text = null;
			}
		}

		/// <summary>
		/// Updates the status when the update button is clicked.
		/// </summary>
		private void UpdateBTN_Click(object sender, System.EventArgs e)
		{
			GetStatus();
		}
	}
}

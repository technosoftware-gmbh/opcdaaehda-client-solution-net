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
			startTimeTb_ = new System.Windows.Forms.TextBox();
			startTimeLb_ = new System.Windows.Forms.Label();
			productVersionLb_ = new System.Windows.Forms.Label();
			productVersionTb_ = new System.Windows.Forms.TextBox();
			serverStateLb_ = new System.Windows.Forms.Label();
			serverStateTb_ = new System.Windows.Forms.TextBox();
			vendorInfoLb_ = new System.Windows.Forms.Label();
			currentTimeLb_ = new System.Windows.Forms.Label();
			vendorInfoTb_ = new System.Windows.Forms.TextBox();
			currentTimeTb_ = new System.Windows.Forms.TextBox();
			buttonsPn_ = new System.Windows.Forms.Panel();
			updateBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			statusInfoTb_ = new System.Windows.Forms.TextBox();
			statusInfoLb_ = new System.Windows.Forms.Label();
			maxReturnValuesLb_ = new System.Windows.Forms.Label();
			maxReturnValuesTb_ = new System.Windows.Forms.TextBox();
			buttonsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// StartTimeTB
			// 
			startTimeTb_.Location = new System.Drawing.Point(104, 84);
			startTimeTb_.Name = "startTimeTb_";
			startTimeTb_.ReadOnly = true;
			startTimeTb_.Size = new System.Drawing.Size(128, 20);
			startTimeTb_.TabIndex = 12;
			startTimeTb_.Text = "";
			// 
			// StartTimeLB
			// 
			startTimeLb_.Location = new System.Drawing.Point(4, 84);
			startTimeLb_.Name = "startTimeLb_";
			startTimeLb_.Size = new System.Drawing.Size(96, 20);
			startTimeLb_.TabIndex = 11;
			startTimeLb_.Text = "Start Time";
			startTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ProductVersionLB
			// 
			productVersionLb_.Location = new System.Drawing.Point(4, 24);
			productVersionLb_.Name = "productVersionLb_";
			productVersionLb_.Size = new System.Drawing.Size(96, 20);
			productVersionLb_.TabIndex = 3;
			productVersionLb_.Text = "Product Version";
			productVersionLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ProductVersionTB
			// 
			productVersionTb_.Location = new System.Drawing.Point(104, 24);
			productVersionTb_.Name = "productVersionTb_";
			productVersionTb_.ReadOnly = true;
			productVersionTb_.Size = new System.Drawing.Size(128, 20);
			productVersionTb_.TabIndex = 4;
			productVersionTb_.Text = "";
			// 
			// ServerStateLB
			// 
			serverStateLb_.Location = new System.Drawing.Point(4, 44);
			serverStateLb_.Name = "serverStateLb_";
			serverStateLb_.Size = new System.Drawing.Size(96, 20);
			serverStateLb_.TabIndex = 5;
			serverStateLb_.Text = "Server State";
			serverStateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ServerStateTB
			// 
			serverStateTb_.Location = new System.Drawing.Point(104, 44);
			serverStateTb_.Name = "serverStateTb_";
			serverStateTb_.ReadOnly = true;
			serverStateTb_.Size = new System.Drawing.Size(128, 20);
			serverStateTb_.TabIndex = 6;
			serverStateTb_.Text = "";
			// 
			// VendorInfoLB
			// 
			vendorInfoLb_.Location = new System.Drawing.Point(4, 4);
			vendorInfoLb_.Name = "vendorInfoLb_";
			vendorInfoLb_.Size = new System.Drawing.Size(96, 20);
			vendorInfoLb_.TabIndex = 1;
			vendorInfoLb_.Text = "Vendor Info";
			vendorInfoLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CurrentTimeLB
			// 
			currentTimeLb_.Location = new System.Drawing.Point(4, 104);
			currentTimeLb_.Name = "currentTimeLb_";
			currentTimeLb_.Size = new System.Drawing.Size(96, 20);
			currentTimeLb_.TabIndex = 13;
			currentTimeLb_.Text = "Current Time";
			currentTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VendorInfoTB
			// 
			vendorInfoTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			vendorInfoTb_.Location = new System.Drawing.Point(104, 4);
			vendorInfoTb_.Name = "vendorInfoTb_";
			vendorInfoTb_.ReadOnly = true;
			vendorInfoTb_.Size = new System.Drawing.Size(248, 20);
			vendorInfoTb_.TabIndex = 2;
			vendorInfoTb_.Text = "";
			// 
			// CurrentTimeTB
			// 
			currentTimeTb_.Location = new System.Drawing.Point(104, 104);
			currentTimeTb_.Name = "currentTimeTb_";
			currentTimeTb_.ReadOnly = true;
			currentTimeTb_.Size = new System.Drawing.Size(128, 20);
			currentTimeTb_.TabIndex = 14;
			currentTimeTb_.Text = "";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(updateBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 146);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(360, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// UpdateBTN
			// 
			updateBtn_.Location = new System.Drawing.Point(4, 8);
			updateBtn_.Name = "updateBtn_";
			updateBtn_.TabIndex = 1;
			updateBtn_.Text = "Update";
			updateBtn_.Click += new System.EventHandler(UpdateBTN_Click);
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(280, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Close";
			// 
			// StatusInfoTB
			// 
			statusInfoTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			statusInfoTb_.Location = new System.Drawing.Point(104, 64);
			statusInfoTb_.Name = "statusInfoTb_";
			statusInfoTb_.ReadOnly = true;
			statusInfoTb_.Size = new System.Drawing.Size(248, 20);
			statusInfoTb_.TabIndex = 17;
			statusInfoTb_.Text = "";
			// 
			// StatusInfoLB
			// 
			statusInfoLb_.Location = new System.Drawing.Point(4, 64);
			statusInfoLb_.Name = "statusInfoLb_";
			statusInfoLb_.Size = new System.Drawing.Size(96, 20);
			statusInfoLb_.TabIndex = 18;
			statusInfoLb_.Text = "Status Info";
			statusInfoLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxReturnValuesLB
			// 
			maxReturnValuesLb_.Location = new System.Drawing.Point(4, 124);
			maxReturnValuesLb_.Name = "maxReturnValuesLb_";
			maxReturnValuesLb_.Size = new System.Drawing.Size(100, 20);
			maxReturnValuesLb_.TabIndex = 19;
			maxReturnValuesLb_.Text = "Max Return Values";
			maxReturnValuesLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxReturnValuesTB
			// 
			maxReturnValuesTb_.Location = new System.Drawing.Point(104, 124);
			maxReturnValuesTb_.Name = "maxReturnValuesTb_";
			maxReturnValuesTb_.ReadOnly = true;
			maxReturnValuesTb_.Size = new System.Drawing.Size(128, 20);
			maxReturnValuesTb_.TabIndex = 20;
			maxReturnValuesTb_.Text = "";
			// 
			// ServerStatusDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = cancelBtn_;
			ClientSize = new System.Drawing.Size(360, 182);
			Controls.Add(maxReturnValuesTb_);
			Controls.Add(maxReturnValuesLb_);
			Controls.Add(statusInfoLb_);
			Controls.Add(statusInfoTb_);
			Controls.Add(buttonsPn_);
			Controls.Add(startTimeTb_);
			Controls.Add(startTimeLb_);
			Controls.Add(productVersionLb_);
			Controls.Add(productVersionTb_);
			Controls.Add(serverStateLb_);
			Controls.Add(serverStateTb_);
			Controls.Add(vendorInfoLb_);
			Controls.Add(currentTimeLb_);
			Controls.Add(vendorInfoTb_);
			Controls.Add(currentTimeTb_);
			MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(600, 216);
			MinimumSize = new System.Drawing.Size(350, 216);
			Name = "ServerStatusDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Server Status";
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

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

#region Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
// Web: http://www.technosoftware.com 
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved

using SampleClients.Common;
using System;
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A dialog that displays the current status of an OPC server.
    /// </summary>
    public class BrowseDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private Technosoftware.AeSampleClient.BrowseCtrl browseCtrl_;
		private System.Windows.Forms.Panel leftPn_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public BrowseDlg()
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
            this.buttonsPn_ = new System.Windows.Forms.Panel();
            this.cancelBtn_ = new System.Windows.Forms.Button();
			this.browseCtrl_ = new BrowseCtrl();
            this.leftPn_ = new System.Windows.Forms.Panel();
            this.buttonsPn_.SuspendLayout();
            this.leftPn_.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPN
            // 
            this.buttonsPn_.Controls.Add(this.cancelBtn_);
            this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 290);
            this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(512, 36);
            this.buttonsPn_.TabIndex = 0;
            // 
            // CancelBTN
            // 
            this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.cancelBtn_.Location = new System.Drawing.Point(219, 8);
            this.cancelBtn_.Name = "cancelBtn_";
            this.cancelBtn_.TabIndex = 0;
            this.cancelBtn_.Text = "Close";
            this.cancelBtn_.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // BrowseCTRL
            // 
            this.browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browseCtrl_.Location = new System.Drawing.Point(4, 4);
            this.browseCtrl_.Name = "browseCtrl_";
			this.browseCtrl_.Size = new System.Drawing.Size(504, 286);
            this.browseCtrl_.TabIndex = 0;
            // 
            // LeftPN
            // 
            this.leftPn_.Controls.Add(this.browseCtrl_);
            this.leftPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPn_.DockPadding.Left = 4;
			this.leftPn_.DockPadding.Right = 4;
			this.leftPn_.DockPadding.Top = 4;
            this.leftPn_.Location = new System.Drawing.Point(0, 0);
            this.leftPn_.Name = "leftPn_";
			this.leftPn_.Size = new System.Drawing.Size(512, 290);
            this.leftPn_.TabIndex = 2;
            // 
            // BrowseDlg
            // 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelBtn_;
            this.ClientSize = new System.Drawing.Size(512, 326);
            this.Controls.Add(this.leftPn_);
            this.Controls.Add(this.buttonsPn_);
            this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(0, 180);
            this.Name = "BrowseDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Browse Address Space";
            this.buttonsPn_.ResumeLayout(false);
            this.leftPn_.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the event conditions supported by the server.
		/// </summary>
		public void ShowDialog(TsCAeServer server, bool modal)
		{
			if (server == null) throw new ArgumentNullException("server");

			browseCtrl_.ShowAreas(server);

			if (modal)
			{
				ShowDialog();
			}
			else
			{
				Show();
			}
		}
		#endregion

		#region Private Methods
		#endregion

		#region Event Handlers
		/// <summary>
		/// Closes the window.
		/// </summary>
		private void CancelBTN_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
		#endregion
	}
}

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
			browseCtrl_ = new BrowseCtrl();
            leftPn_ = new System.Windows.Forms.Panel();
            buttonsPn_.SuspendLayout();
            leftPn_.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonsPN
            // 
            buttonsPn_.Controls.Add(cancelBtn_);
            buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 290);
            buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(512, 36);
            buttonsPn_.TabIndex = 0;
            // 
            // CancelBTN
            // 
            cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			cancelBtn_.Location = new System.Drawing.Point(219, 8);
            cancelBtn_.Name = "cancelBtn_";
            cancelBtn_.TabIndex = 0;
            cancelBtn_.Text = "Close";
            cancelBtn_.Click += new System.EventHandler(CancelBTN_Click);
            // 
            // BrowseCTRL
            // 
            browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            browseCtrl_.Location = new System.Drawing.Point(4, 4);
            browseCtrl_.Name = "browseCtrl_";
			browseCtrl_.Size = new System.Drawing.Size(504, 286);
            browseCtrl_.TabIndex = 0;
            // 
            // LeftPN
            // 
            leftPn_.Controls.Add(browseCtrl_);
            leftPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			leftPn_.DockPadding.Left = 4;
			leftPn_.DockPadding.Right = 4;
			leftPn_.DockPadding.Top = 4;
            leftPn_.Location = new System.Drawing.Point(0, 0);
            leftPn_.Name = "leftPn_";
			leftPn_.Size = new System.Drawing.Size(512, 290);
            leftPn_.TabIndex = 2;
            // 
            // BrowseDlg
            // 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            CancelButton = cancelBtn_;
            ClientSize = new System.Drawing.Size(512, 326);
            Controls.Add(leftPn_);
            Controls.Add(buttonsPn_);
            MaximizeBox = false;
			MinimumSize = new System.Drawing.Size(0, 180);
            Name = "BrowseDlg";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Browse Address Space";
            buttonsPn_.ResumeLayout(false);
            leftPn_.ResumeLayout(false);
            ResumeLayout(false);

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

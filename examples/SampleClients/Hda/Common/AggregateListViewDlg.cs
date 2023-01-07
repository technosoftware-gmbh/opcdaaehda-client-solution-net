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

using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Common
{
	/// <summary>
	/// A dialog used to browse the address space of an OPC DA server.
	/// </summary>
	public class AggregateListViewDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button doneBtn_;
		private System.Windows.Forms.Panel rightPn_;
		private AggregateListViewCtrl aggregatesCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public AggregateListViewDlg()
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
			rightPn_ = new System.Windows.Forms.Panel();
			buttonsPn_ = new System.Windows.Forms.Panel();
			doneBtn_ = new System.Windows.Forms.Button();
			aggregatesCtrl_ = new AggregateListViewCtrl();
			rightPn_.SuspendLayout();
			buttonsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// RightPN
			// 
			rightPn_.Controls.Add(aggregatesCtrl_);
			rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			rightPn_.DockPadding.Right = 4;
			rightPn_.DockPadding.Top = 4;
			rightPn_.Location = new System.Drawing.Point(0, 0);
			rightPn_.Name = "rightPn_";
			rightPn_.Size = new System.Drawing.Size(792, 300);
			rightPn_.TabIndex = 8;
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(doneBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 300);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(792, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// DoneBTN
			// 
			doneBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			doneBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			doneBtn_.Location = new System.Drawing.Point(359, 8);
			doneBtn_.Name = "doneBtn_";
			doneBtn_.TabIndex = 0;
			doneBtn_.Text = "Done";
			doneBtn_.Click += new System.EventHandler(DoneBTN_Click);
			// 
			// AggregatesCTRL
			// 
			aggregatesCtrl_.AllowDrop = true;
			aggregatesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			aggregatesCtrl_.Location = new System.Drawing.Point(0, 4);
			aggregatesCtrl_.Name = "aggregatesCtrl_";
			aggregatesCtrl_.Size = new System.Drawing.Size(788, 296);
			aggregatesCtrl_.TabIndex = 0;
			// 
			// AggregateListViewDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(792, 336);
			Controls.Add(rightPn_);
			Controls.Add(buttonsPn_);
			Name = "AggregateListViewDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "View Aggregates";
			rightPn_.ResumeLayout(false);
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The server used for viewing attributes.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// Displays the address space for the specified server.
		/// </summary>
		public void ShowDialog(TsCHdaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;

			aggregatesCtrl_.Initialize(server);

			ShowDialog();
		}
		
		/// <summary>
		/// Called when the close button is clicked.
		/// </summary>
		private void DoneBTN_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}

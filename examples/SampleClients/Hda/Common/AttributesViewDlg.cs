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
using System.Windows.Forms;

using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Common
{
	/// <summary>
	/// A dialog used to browse the address space of an OPC DA server.
	/// </summary>
	public class AttributesViewDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button doneBtn_;
		private System.Windows.Forms.Panel rightPn_;
		private AttributesViewCtrl attributesCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public AttributesViewDlg()
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
			this.rightPn_ = new System.Windows.Forms.Panel();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.doneBtn_ = new System.Windows.Forms.Button();
			this.attributesCtrl_ = new AttributesViewCtrl();
			this.rightPn_.SuspendLayout();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// RightPN
			// 
			this.rightPn_.Controls.Add(this.attributesCtrl_);
			this.rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPn_.DockPadding.Right = 4;
			this.rightPn_.DockPadding.Top = 4;
			this.rightPn_.Location = new System.Drawing.Point(0, 0);
			this.rightPn_.Name = "rightPn_";
			this.rightPn_.Size = new System.Drawing.Size(792, 300);
			this.rightPn_.TabIndex = 8;
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.doneBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 300);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(792, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// DoneBTN
			// 
			this.doneBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.doneBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.doneBtn_.Location = new System.Drawing.Point(359, 8);
			this.doneBtn_.Name = "doneBtn_";
			this.doneBtn_.TabIndex = 0;
			this.doneBtn_.Text = "Done";
			this.doneBtn_.Click += new System.EventHandler(this.DoneBTN_Click);
			// 
			// AttributesCTRL
			// 
			this.attributesCtrl_.AllowDrop = true;
			this.attributesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.attributesCtrl_.Location = new System.Drawing.Point(0, 4);
			this.attributesCtrl_.Name = "attributesCtrl_";
			this.attributesCtrl_.Size = new System.Drawing.Size(788, 296);
			this.attributesCtrl_.TabIndex = 0;
			// 
			// AttributesViewDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 336);
			this.Controls.Add(this.rightPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "AttributesViewDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "View Attributes";
			this.rightPn_.ResumeLayout(false);
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Displays the attributes supported by a server.
		/// </summary>
		public void ShowDialog(TsCHdaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			attributesCtrl_.Initialize(server);

			ShowDialog();
		}

		/// <summary>
		/// Displays the values in an attribute collection.
		/// </summary>
		public void ShowDialog(TsCHdaServer server, Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection values)
		{
			if (server == null) throw new ArgumentNullException("server");

			attributesCtrl_.Initialize(server, values);

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

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
using System.Collections;
using System.Windows.Forms;

using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Common
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class AttributesSelectDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Panel mainPn_;
		private AttributesSelectCtrl attributesCtrl_;
		private System.ComponentModel.IContainer components = null;

		public AttributesSelectDlg()
		{
			// Required for Windows Form Designer support
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
			this.okBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.mainPn_ = new System.Windows.Forms.Panel();
			this.attributesCtrl_ = new AttributesSelectCtrl();
			this.buttonsPn_.SuspendLayout();
			this.mainPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
			this.okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn_.Location = new System.Drawing.Point(4, 8);
			this.okBtn_.Name = "okBtn_";
			this.okBtn_.TabIndex = 1;
			this.okBtn_.Text = "OK";
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(184, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 378);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(264, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// MainPN
			// 
			this.mainPn_.Controls.Add(this.attributesCtrl_);
			this.mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPn_.DockPadding.Left = 4;
			this.mainPn_.DockPadding.Right = 4;
			this.mainPn_.DockPadding.Top = 4;
			this.mainPn_.Location = new System.Drawing.Point(0, 0);
			this.mainPn_.Name = "mainPn_";
			this.mainPn_.Size = new System.Drawing.Size(264, 378);
			this.mainPn_.TabIndex = 32;
			// 
			// AttributesCTRL
			// 
			this.attributesCtrl_.AllowDrop = true;
			this.attributesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.attributesCtrl_.Location = new System.Drawing.Point(4, 4);
			this.attributesCtrl_.Name = "attributesCtrl_";
			this.attributesCtrl_.ReadOnly = false;
			this.attributesCtrl_.Size = new System.Drawing.Size(256, 374);
			this.attributesCtrl_.TabIndex = 0;
			this.attributesCtrl_.AttributePicked += new AttributesSelectCtrl.AttributePickedEventHandler(this.AttributesCTRL_AttributePicked);
			// 
			// AttributesSelectDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 414);
			this.Controls.Add(this.mainPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "AttributesSelectDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Attributes";
			this.buttonsPn_.ResumeLayout(false);
			this.mainPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the user to edit the properties of a server.
		/// </summary>
		public Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute[] ShowDialog(TsCHdaServer server, ArrayList excludeList)
		{
			if (server == null) throw new ArgumentNullException("server");
			
			// initialize the controls.
			attributesCtrl_.Initialize(server, excludeList);

			// show the dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// return selected items.
			return attributesCtrl_.GetAttributes(true);
		}

		/// <summary>
		/// Called when an item is double clicked in the list.
		/// </summary>
		private void AttributesCTRL_AttributePicked(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute[] attributes)
		{
			DialogResult = DialogResult.OK;
		}
	}
}

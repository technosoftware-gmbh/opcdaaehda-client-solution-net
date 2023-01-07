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
			okBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			buttonsPn_ = new System.Windows.Forms.Panel();
			mainPn_ = new System.Windows.Forms.Panel();
			attributesCtrl_ = new AttributesSelectCtrl();
			buttonsPn_.SuspendLayout();
			mainPn_.SuspendLayout();
			SuspendLayout();
			// 
			// OkBTN
			// 
			okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			okBtn_.Location = new System.Drawing.Point(4, 8);
			okBtn_.Name = "okBtn_";
			okBtn_.TabIndex = 1;
			okBtn_.Text = "OK";
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(184, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 378);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(264, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// MainPN
			// 
			mainPn_.Controls.Add(attributesCtrl_);
			mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			mainPn_.DockPadding.Left = 4;
			mainPn_.DockPadding.Right = 4;
			mainPn_.DockPadding.Top = 4;
			mainPn_.Location = new System.Drawing.Point(0, 0);
			mainPn_.Name = "mainPn_";
			mainPn_.Size = new System.Drawing.Size(264, 378);
			mainPn_.TabIndex = 32;
			// 
			// AttributesCTRL
			// 
			attributesCtrl_.AllowDrop = true;
			attributesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			attributesCtrl_.Location = new System.Drawing.Point(4, 4);
			attributesCtrl_.Name = "attributesCtrl_";
			attributesCtrl_.ReadOnly = false;
			attributesCtrl_.Size = new System.Drawing.Size(256, 374);
			attributesCtrl_.TabIndex = 0;
			attributesCtrl_.AttributePicked += new AttributesSelectCtrl.AttributePickedEventHandler(AttributesCTRL_AttributePicked);
			// 
			// AttributesSelectDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(264, 414);
			Controls.Add(mainPn_);
			Controls.Add(buttonsPn_);
			Name = "AttributesSelectDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Select Attributes";
			buttonsPn_.ResumeLayout(false);
			mainPn_.ResumeLayout(false);
			ResumeLayout(false);

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

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

namespace SampleClients.Hda.Item
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class ItemValuesDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Panel mainPn_;
		private ItemValuesCtrl trendCtrl_;
		private System.ComponentModel.IContainer components = null;

		public ItemValuesDlg()
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
			trendCtrl_ = new ItemValuesCtrl();
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
			cancelBtn_.Location = new System.Drawing.Point(608, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 434);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(688, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// MainPN
			// 
			mainPn_.Controls.Add(trendCtrl_);
			mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			mainPn_.Location = new System.Drawing.Point(0, 0);
			mainPn_.Name = "mainPn_";
			mainPn_.Size = new System.Drawing.Size(688, 434);
			mainPn_.TabIndex = 32;
			// 
			// TrendCTRL
			// 
			trendCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			trendCtrl_.DockPadding.All = 4;
			trendCtrl_.Location = new System.Drawing.Point(0, 0);
			trendCtrl_.Name = "trendCtrl_";
			trendCtrl_.Size = new System.Drawing.Size(688, 434);
			trendCtrl_.TabIndex = 0;
			// 
			// ItemValuesDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(688, 470);
			Controls.Add(mainPn_);
			Controls.Add(buttonsPn_);
			Name = "ItemValuesDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "View Trend";
			buttonsPn_.ResumeLayout(false);
			mainPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to view the values of a trend.
		/// </summary>
		public bool ShowDialog(TsCHdaServer server, TsCHdaItemValueCollection values, bool readOnly)
		{			
			if (server == null) throw new ArgumentNullException("server");
			if (values == null) throw new ArgumentNullException("values");

			// initialize controls.
			trendCtrl_.Initialize(server, values);
			trendCtrl_.ReadOnly = readOnly;
			
			// show the dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return false;
			}

			// update collection if not read only.
			if (!readOnly)
			{
				values.Clear();
				
				foreach (TsCHdaItemValue value in trendCtrl_.GetValues())
				{
					values.Add(value);
				}
			}

			return true;
		}
		#endregion
	}
}

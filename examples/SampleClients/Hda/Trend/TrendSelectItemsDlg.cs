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

namespace SampleClients.Hda.Trend
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class TrendSelectItemsDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Panel mainPn_;
		private TrendItemsCtrl itemsCtrl_;
		private System.ComponentModel.IContainer components = null;

		public TrendSelectItemsDlg()
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
			this.itemsCtrl_ = new TrendItemsCtrl();
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
			this.cancelBtn_.Location = new System.Drawing.Point(248, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 242);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(328, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// MainPN
			// 
			this.mainPn_.Controls.Add(this.itemsCtrl_);
			this.mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPn_.DockPadding.Left = 4;
			this.mainPn_.DockPadding.Right = 4;
			this.mainPn_.DockPadding.Top = 4;
			this.mainPn_.Location = new System.Drawing.Point(0, 0);
			this.mainPn_.Name = "mainPn_";
			this.mainPn_.Size = new System.Drawing.Size(328, 242);
			this.mainPn_.TabIndex = 32;
			// 
			// ItemsCTRL
			// 
			this.itemsCtrl_.AllowDrop = true;
			this.itemsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsCtrl_.Location = new System.Drawing.Point(4, 4);
			this.itemsCtrl_.Name = "itemsCtrl_";
			this.itemsCtrl_.Size = new System.Drawing.Size(320, 238);
			this.itemsCtrl_.TabIndex = 0;
			this.itemsCtrl_.ItemPicked += new TrendItemsCtrl.ItemPickedEventHandler(this.ItemsCTRL_ItemPicked);
			// 
			// TrendSelectItemsDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 278);
			this.Controls.Add(this.mainPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "TrendSelectItemsDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Items";
			this.buttonsPn_.ResumeLayout(false);
			this.mainPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the user to edit the properties of a trend.
		/// </summary>
		public TsCHdaItem[] ShowDialog(TsCHdaTrend trend, ArrayList excludeList)
		{
			if (trend == null) throw new ArgumentNullException("trend");
			
			// initialize the controls.
			itemsCtrl_.Initialize(trend, false, excludeList);

			// show the dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// return selected items.
			return itemsCtrl_.GetItems(true);
		}

		/// <summary>
		/// Called when an item is double clicked in the list.
		/// </summary>
		private void ItemsCTRL_ItemPicked(TsCHdaItem[] items)
		{
			DialogResult = DialogResult.OK;
		}
	}
}

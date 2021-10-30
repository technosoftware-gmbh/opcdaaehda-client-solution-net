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

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Item
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class ItemEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Panel mainPn_;
		private System.Windows.Forms.Label aggregateLb_;
		private System.Windows.Forms.ComboBox aggregateCb_;
		private System.Windows.Forms.Label itemNameLb_;
		private System.Windows.Forms.TextBox itemNameTb_;
		private System.Windows.Forms.TextBox itemPathTb_;
		private System.Windows.Forms.Label itemPathLb_;
		private System.Windows.Forms.CheckBox aggregateSpecifiedCb_;
		private System.ComponentModel.IContainer components = null;

		public ItemEditDlg()
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
			this.itemNameLb_ = new System.Windows.Forms.Label();
			this.mainPn_ = new System.Windows.Forms.Panel();
			this.itemPathTb_ = new System.Windows.Forms.TextBox();
			this.itemPathLb_ = new System.Windows.Forms.Label();
			this.aggregateCb_ = new System.Windows.Forms.ComboBox();
			this.aggregateLb_ = new System.Windows.Forms.Label();
			this.itemNameTb_ = new System.Windows.Forms.TextBox();
			this.aggregateSpecifiedCb_ = new System.Windows.Forms.CheckBox();
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
			this.cancelBtn_.Location = new System.Drawing.Point(192, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 74);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(272, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// ItemNameLB
			// 
			this.itemNameLb_.Location = new System.Drawing.Point(4, 4);
			this.itemNameLb_.Name = "itemNameLb_";
			this.itemNameLb_.Size = new System.Drawing.Size(60, 23);
			this.itemNameLb_.TabIndex = 0;
			this.itemNameLb_.Text = "Item Name";
			this.itemNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MainPN
			// 
			this.mainPn_.Controls.Add(this.aggregateSpecifiedCb_);
			this.mainPn_.Controls.Add(this.itemPathTb_);
			this.mainPn_.Controls.Add(this.itemPathLb_);
			this.mainPn_.Controls.Add(this.aggregateCb_);
			this.mainPn_.Controls.Add(this.aggregateLb_);
			this.mainPn_.Controls.Add(this.itemNameTb_);
			this.mainPn_.Controls.Add(this.itemNameLb_);
			this.mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPn_.DockPadding.Right = 4;
			this.mainPn_.DockPadding.Top = 4;
			this.mainPn_.Location = new System.Drawing.Point(0, 0);
			this.mainPn_.Name = "mainPn_";
			this.mainPn_.Size = new System.Drawing.Size(272, 74);
			this.mainPn_.TabIndex = 1;
			// 
			// ItemPathTB
			// 
			this.itemPathTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.itemPathTb_.Location = new System.Drawing.Point(64, 28);
			this.itemPathTb_.Name = "itemPathTb_";
			this.itemPathTb_.Size = new System.Drawing.Size(204, 20);
			this.itemPathTb_.TabIndex = 3;
			this.itemPathTb_.Text = "";
			// 
			// ItemPathLB
			// 
			this.itemPathLb_.Location = new System.Drawing.Point(4, 28);
			this.itemPathLb_.Name = "itemPathLb_";
			this.itemPathLb_.Size = new System.Drawing.Size(60, 23);
			this.itemPathLb_.TabIndex = 2;
			this.itemPathLb_.Text = "Item Path";
			this.itemPathLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AggregateCB
			// 
			this.aggregateCb_.Enabled = false;
			this.aggregateCb_.Location = new System.Drawing.Point(64, 52);
			this.aggregateCb_.Name = "aggregateCb_";
			this.aggregateCb_.Size = new System.Drawing.Size(121, 21);
			this.aggregateCb_.TabIndex = 5;
			// 
			// AggregateLB
			// 
			this.aggregateLb_.Location = new System.Drawing.Point(4, 52);
			this.aggregateLb_.Name = "aggregateLb_";
			this.aggregateLb_.Size = new System.Drawing.Size(60, 23);
			this.aggregateLb_.TabIndex = 4;
			this.aggregateLb_.Text = "Aggregate";
			this.aggregateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameTB
			// 
			this.itemNameTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.itemNameTb_.Location = new System.Drawing.Point(64, 4);
			this.itemNameTb_.Name = "itemNameTb_";
			this.itemNameTb_.Size = new System.Drawing.Size(204, 20);
			this.itemNameTb_.TabIndex = 1;
			this.itemNameTb_.Text = "";
			// 
			// AggregateSpecifiedCB
			// 
			this.aggregateSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.aggregateSpecifiedCb_.Location = new System.Drawing.Point(192, 50);
			this.aggregateSpecifiedCb_.Name = "aggregateSpecifiedCb_";
			this.aggregateSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.aggregateSpecifiedCb_.TabIndex = 6;
			this.aggregateSpecifiedCb_.CheckedChanged += new System.EventHandler(this.AggregateSpecifiedCB_CheckedChanged);
			// 
			// ItemEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 110);
			this.Controls.Add(this.mainPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "ItemEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Item";
			this.buttonsPn_.ResumeLayout(false);
			this.mainPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the use to edit the properties of an item object.
		/// </summary>
		public bool ShowDialog(TsCHdaServer server, TsCHdaItem item)
		{
			if (server == null) throw new ArgumentNullException("server");
			if (item == null)   throw new ArgumentNullException("item");

			// cannot edit item id in this context.
			itemNameTb_.ReadOnly          = true;
			itemPathTb_.ReadOnly          = true;
			aggregateCb_.Enabled          = true;
			aggregateSpecifiedCb_.Enabled = true;
			aggregateLb_.Enabled          = true;

			// fill in the item id.
			itemNameTb_.Text = item.ItemName;
			itemPathTb_.Text = item.ItemPath;

			// populate aggregate drop down list.
			aggregateCb_.Items.Clear();

			foreach (TsCHdaAggregate aggregate in server.Aggregates)
			{
				aggregateCb_.Items.Add(aggregate);

				if (aggregate.Id == item.Aggregate)
				{
					aggregateCb_.SelectedItem = aggregate;
				}
			}

			aggregateSpecifiedCb_.Checked = (item.Aggregate != TsCHdaAggregateID.NoAggregate);
			
			// show the dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return false;
			}

			// update the item.
			item.Aggregate = TsCHdaAggregateID.NoAggregate;

			if (aggregateSpecifiedCb_.Checked && aggregateCb_.SelectedItem != null)
			{
				item.Aggregate = ((TsCHdaAggregate)aggregateCb_.SelectedItem).Id;
			}

			return true;
		}

		/// <summary>
		/// Prompts the use to edit the properties of an item identifier object.
		/// </summary>
		public bool ShowDialog(OpcItem item)
		{
			if (item == null)   throw new ArgumentNullException("item");

			// cannot edit item id in this context.
			itemNameTb_.ReadOnly          = false;
			itemPathTb_.ReadOnly          = false;
			aggregateCb_.Enabled          = false;
			aggregateSpecifiedCb_.Enabled = false;
			aggregateLb_.Enabled          = false;

			// fill in the item id.
			itemNameTb_.Text = item.ItemName;
			itemPathTb_.Text = item.ItemPath;
		
			// show the dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return false;
			}

			// update the item.
			item.ItemName = itemNameTb_.Text;
			item.ItemPath = itemPathTb_.Text;

			return true;
		}
		#endregion

		/// <summary>
		/// Toggles the enabled state of the aggregate selector.
		/// </summary>
		private void AggregateSpecifiedCB_CheckedChanged(object sender, System.EventArgs e)
		{
			aggregateCb_.Enabled = aggregateSpecifiedCb_.Checked;
		}
	}
}

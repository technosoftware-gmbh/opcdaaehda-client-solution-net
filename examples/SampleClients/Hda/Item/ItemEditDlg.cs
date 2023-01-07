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
			itemNameLb_ = new System.Windows.Forms.Label();
			mainPn_ = new System.Windows.Forms.Panel();
			itemPathTb_ = new System.Windows.Forms.TextBox();
			itemPathLb_ = new System.Windows.Forms.Label();
			aggregateCb_ = new System.Windows.Forms.ComboBox();
			aggregateLb_ = new System.Windows.Forms.Label();
			itemNameTb_ = new System.Windows.Forms.TextBox();
			aggregateSpecifiedCb_ = new System.Windows.Forms.CheckBox();
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
			cancelBtn_.Location = new System.Drawing.Point(192, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 74);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(272, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// ItemNameLB
			// 
			itemNameLb_.Location = new System.Drawing.Point(4, 4);
			itemNameLb_.Name = "itemNameLb_";
			itemNameLb_.Size = new System.Drawing.Size(60, 23);
			itemNameLb_.TabIndex = 0;
			itemNameLb_.Text = "Item Name";
			itemNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MainPN
			// 
			mainPn_.Controls.Add(aggregateSpecifiedCb_);
			mainPn_.Controls.Add(itemPathTb_);
			mainPn_.Controls.Add(itemPathLb_);
			mainPn_.Controls.Add(aggregateCb_);
			mainPn_.Controls.Add(aggregateLb_);
			mainPn_.Controls.Add(itemNameTb_);
			mainPn_.Controls.Add(itemNameLb_);
			mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			mainPn_.DockPadding.Right = 4;
			mainPn_.DockPadding.Top = 4;
			mainPn_.Location = new System.Drawing.Point(0, 0);
			mainPn_.Name = "mainPn_";
			mainPn_.Size = new System.Drawing.Size(272, 74);
			mainPn_.TabIndex = 1;
			// 
			// ItemPathTB
			// 
			itemPathTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			itemPathTb_.Location = new System.Drawing.Point(64, 28);
			itemPathTb_.Name = "itemPathTb_";
			itemPathTb_.Size = new System.Drawing.Size(204, 20);
			itemPathTb_.TabIndex = 3;
			itemPathTb_.Text = "";
			// 
			// ItemPathLB
			// 
			itemPathLb_.Location = new System.Drawing.Point(4, 28);
			itemPathLb_.Name = "itemPathLb_";
			itemPathLb_.Size = new System.Drawing.Size(60, 23);
			itemPathLb_.TabIndex = 2;
			itemPathLb_.Text = "Item Path";
			itemPathLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AggregateCB
			// 
			aggregateCb_.Enabled = false;
			aggregateCb_.Location = new System.Drawing.Point(64, 52);
			aggregateCb_.Name = "aggregateCb_";
			aggregateCb_.Size = new System.Drawing.Size(121, 21);
			aggregateCb_.TabIndex = 5;
			// 
			// AggregateLB
			// 
			aggregateLb_.Location = new System.Drawing.Point(4, 52);
			aggregateLb_.Name = "aggregateLb_";
			aggregateLb_.Size = new System.Drawing.Size(60, 23);
			aggregateLb_.TabIndex = 4;
			aggregateLb_.Text = "Aggregate";
			aggregateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameTB
			// 
			itemNameTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			itemNameTb_.Location = new System.Drawing.Point(64, 4);
			itemNameTb_.Name = "itemNameTb_";
			itemNameTb_.Size = new System.Drawing.Size(204, 20);
			itemNameTb_.TabIndex = 1;
			itemNameTb_.Text = "";
			// 
			// AggregateSpecifiedCB
			// 
			aggregateSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			aggregateSpecifiedCb_.Location = new System.Drawing.Point(192, 50);
			aggregateSpecifiedCb_.Name = "aggregateSpecifiedCb_";
			aggregateSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			aggregateSpecifiedCb_.TabIndex = 6;
			aggregateSpecifiedCb_.CheckedChanged += new System.EventHandler(AggregateSpecifiedCB_CheckedChanged);
			// 
			// ItemEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(272, 110);
			Controls.Add(mainPn_);
			Controls.Add(buttonsPn_);
			Name = "ItemEditDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Edit Item";
			buttonsPn_.ResumeLayout(false);
			mainPn_.ResumeLayout(false);
			ResumeLayout(false);

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

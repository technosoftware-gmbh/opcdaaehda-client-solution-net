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
using SampleClients.Hda.Common;

using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Server
{	
	/// <summary>
	/// Called when the browse filters have changed.
	/// </summary>
	public delegate void BrowseFiltersChangedCallback(int maxElements, TsCHdaBrowseFilter[] filters);

	/// <summary>
	/// A dialog used to specify element and property filters used when browsing.
	/// </summary>
	public class BrowseFiltersDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Panel topPn_;
		private System.Windows.Forms.Panel mainPn_;
		private System.Windows.Forms.ListView browseFiltersLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem removeMi_;
		private System.Windows.Forms.Button applyBtn_;
		private System.Windows.Forms.ToolStripMenuItem addMi_;
		private System.Windows.Forms.Label itemNameLb_;
		private System.Windows.Forms.TextBox itemNameTb_;
		private System.Windows.Forms.Label dataTypeLb_;
		private SampleClients.Common.DataTypeCtrl dataTypeCtrl_;
		private System.Windows.Forms.Label maxElementsLb_;
		private System.Windows.Forms.NumericUpDown maxElementsCtrl_;
		private System.ComponentModel.IContainer components = null;

		public BrowseFiltersDlg()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			browseFiltersLv_.SmallImageList = Resources.Instance.ImageList;

			browseFiltersLv_.Columns.Add("Attribute", -2, HorizontalAlignment.Left);
			browseFiltersLv_.Columns.Add("Operator", -2, HorizontalAlignment.Left);
			browseFiltersLv_.Columns.Add("Value", -2, HorizontalAlignment.Left);
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
			this.applyBtn_ = new System.Windows.Forms.Button();
			this.itemNameLb_ = new System.Windows.Forms.Label();
			this.topPn_ = new System.Windows.Forms.Panel();
			this.maxElementsCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.maxElementsLb_ = new System.Windows.Forms.Label();
			this.dataTypeCtrl_ = new SampleClients.Common.DataTypeCtrl();
			this.dataTypeLb_ = new System.Windows.Forms.Label();
			this.itemNameTb_ = new System.Windows.Forms.TextBox();
			this.mainPn_ = new System.Windows.Forms.Panel();
			this.browseFiltersLv_ = new System.Windows.Forms.ListView();
			this.popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			this.addMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.removeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonsPn_.SuspendLayout();
			this.topPn_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxElementsCtrl_)).BeginInit();
			this.mainPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
			this.okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.okBtn_.Location = new System.Drawing.Point(4, 8);
			this.okBtn_.Name = "okBtn_";
			this.okBtn_.TabIndex = 1;
			this.okBtn_.Text = "OK";
			this.okBtn_.Click += new System.EventHandler(this.OkBTN_Click);
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(248, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			this.cancelBtn_.Click += new System.EventHandler(this.CancelBTN_Click);
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.applyBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(4, 218);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(328, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// ApplyBTN
			// 
			this.applyBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.applyBtn_.Location = new System.Drawing.Point(127, 7);
			this.applyBtn_.Name = "applyBtn_";
			this.applyBtn_.TabIndex = 2;
			this.applyBtn_.Text = "Apply";
			this.applyBtn_.Click += new System.EventHandler(this.ApplyBTN_Click);
			// 
			// ItemNameLB
			// 
			this.itemNameLb_.Location = new System.Drawing.Point(8, 0);
			this.itemNameLb_.Name = "itemNameLb_";
			this.itemNameLb_.Size = new System.Drawing.Size(80, 23);
			this.itemNameLb_.TabIndex = 0;
			this.itemNameLb_.Text = "Item Name";
			this.itemNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
			this.topPn_.Controls.Add(this.maxElementsCtrl_);
			this.topPn_.Controls.Add(this.maxElementsLb_);
			this.topPn_.Controls.Add(this.dataTypeCtrl_);
			this.topPn_.Controls.Add(this.dataTypeLb_);
			this.topPn_.Controls.Add(this.itemNameTb_);
			this.topPn_.Controls.Add(this.itemNameLb_);
			this.topPn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.topPn_.Location = new System.Drawing.Point(4, 4);
			this.topPn_.Name = "topPn_";
			this.topPn_.Size = new System.Drawing.Size(328, 72);
			this.topPn_.TabIndex = 32;
			// 
			// MaxElementsCTRL
			// 
			this.maxElementsCtrl_.Location = new System.Drawing.Point(88, 49);
			this.maxElementsCtrl_.Maximum = new System.Decimal(new int[] {
																			2147483647,
																			0,
																			0,
																			0});
			this.maxElementsCtrl_.Name = "maxElementsCtrl_";
			this.maxElementsCtrl_.TabIndex = 14;
			// 
			// MaxElementsLB
			// 
			this.maxElementsLb_.Location = new System.Drawing.Point(8, 48);
			this.maxElementsLb_.Name = "maxElementsLb_";
			this.maxElementsLb_.Size = new System.Drawing.Size(80, 23);
			this.maxElementsLb_.TabIndex = 13;
			this.maxElementsLb_.Text = "Max Items";
			this.maxElementsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DataTypeCTRL
			// 
			this.dataTypeCtrl_.Location = new System.Drawing.Point(88, 24);
			this.dataTypeCtrl_.Name = "dataTypeCtrl_";
			this.dataTypeCtrl_.SelectedType = null;
			this.dataTypeCtrl_.Size = new System.Drawing.Size(120, 24);
			this.dataTypeCtrl_.TabIndex = 12;
			// 
			// DataTypeLB
			// 
			this.dataTypeLb_.Location = new System.Drawing.Point(8, 24);
			this.dataTypeLb_.Name = "dataTypeLb_";
			this.dataTypeLb_.Size = new System.Drawing.Size(80, 23);
			this.dataTypeLb_.TabIndex = 11;
			this.dataTypeLb_.Text = "Data Type";
			this.dataTypeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameTB
			// 
			this.itemNameTb_.Location = new System.Drawing.Point(88, 0);
			this.itemNameTb_.Name = "itemNameTb_";
			this.itemNameTb_.Size = new System.Drawing.Size(236, 20);
			this.itemNameTb_.TabIndex = 10;
			this.itemNameTb_.Text = "";
			// 
			// MainPN
			// 
			this.mainPn_.Controls.Add(this.browseFiltersLv_);
			this.mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPn_.DockPadding.Bottom = 4;
			this.mainPn_.DockPadding.Top = 4;
			this.mainPn_.Location = new System.Drawing.Point(4, 76);
			this.mainPn_.Name = "mainPn_";
			this.mainPn_.Size = new System.Drawing.Size(328, 142);
			this.mainPn_.TabIndex = 33;
			// 
			// BrowseFiltersLV
			// 
			this.browseFiltersLv_.ContextMenuStrip = this.popupMenu_;
			this.browseFiltersLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browseFiltersLv_.FullRowSelect = true;
			this.browseFiltersLv_.Location = new System.Drawing.Point(0, 4);
			this.browseFiltersLv_.MultiSelect = false;
			this.browseFiltersLv_.Name = "browseFiltersLv_";
			this.browseFiltersLv_.Size = new System.Drawing.Size(328, 134);
			this.browseFiltersLv_.TabIndex = 0;
			this.browseFiltersLv_.View = System.Windows.Forms.View.Details;
			// 
			// PopupMenu
			// 
			this.popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  this.addMi_,
																					  this.removeMi_});
			// 
			// AddMI
			// 
			this.addMi_.ImageIndex = 0;
			this.addMi_.Text = "&Add";
			this.addMi_.Click += new System.EventHandler(this.AddMI_Click);
			// 
			// RemoveMI
			// 
			this.removeMi_.ImageIndex = 1;
			this.removeMi_.Text = "&Remove";
			this.removeMi_.Click += new System.EventHandler(this.RemoveMI_Click);
			// 
			// BrowseFiltersDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 254);
			this.Controls.Add(this.mainPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Controls.Add(this.topPn_);
			this.DockPadding.Left = 4;
			this.DockPadding.Right = 4;
			this.DockPadding.Top = 4;
			this.Name = "BrowseFiltersDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Browse Filters";
			this.buttonsPn_.ResumeLayout(false);
			this.topPn_.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.maxElementsCtrl_)).EndInit();
			this.mainPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Called when the OK or Apply button is clicked.
		/// </summary>
		private BrowseFiltersChangedCallback mCallback_ = null;

		/// <summary>
		/// The server who address space is being browsed.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// Displays the browse filters in a non-model dialog.
		/// </summary>
		public void Show(
			Form                         owner,
			TsCHdaServer               server,
			ITsCHdaBrowser             browser,
			int                          maxItems,
			BrowseFiltersChangedCallback callback)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_   = server;
			mCallback_ = callback;

			// set default filter values.
			itemNameTb_.Text = "";
			dataTypeCtrl_.SelectedType = null;
			maxElementsCtrl_.Value = maxItems;
			browseFiltersLv_.Items.Clear();

			// fetch existing filters from browse object.
			if (browser != null)
			{
				foreach (TsCHdaBrowseFilter filter in browser.Filters)
				{
					switch (filter.AttributeID)
					{
						case Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeID.ITEMID:
						{
							itemNameTb_.Text = (string)filter.FilterValue;
							break;
						}

						case Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeID.DATA_TYPE:
						{
							dataTypeCtrl_.SelectedType = (System.Type)filter.FilterValue;
							break;
						}

						default:
						{
							AddFilter(filter);
							break;
						}
					}
				}

				AdjustColumns();
			}

			StartPosition = FormStartPosition.Manual;
				
			int x = owner.Left + (owner.Width - Width)/2;
			int y = owner.Top  + (owner.Height - Height)/2;
 
			SetDesktopLocation(x, y);

			// show the dialog.
			Show();

			BringToFront();
		}

		/// <summary>
		/// Adds a browse filter to the list view.
		/// </summary>
		private void AddFilter(TsCHdaBrowseFilter filter)
		{
			ListViewItem item = new ListViewItem("", Resources.IMAGE_EXPLODING_BOX);

			item.SubItems.Add("");
			item.SubItems.Add("");

			item.SubItems[0].Text = mServer_.Attributes.Find(filter.AttributeID).Name;
			item.SubItems[1].Text = filter.Operator.ToString();
			item.SubItems[2].Text = Technosoftware.DaAeHdaClient.OpcConvert.ToString(filter.FilterValue);

			browseFiltersLv_.Items.Add(item);
				
			item.Tag = filter;
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			foreach (ColumnHeader column in browseFiltersLv_.Columns)
			{
				column.Width = -2;
			}
		}

		/// <summary>
		/// Invokes the callback an passes the new browse filters.
		/// </summary>
		private void ApplyChanges()
		{
			ArrayList filters = new ArrayList();

			// add item id filter.
			if (itemNameTb_.Text != "")
			{
				TsCHdaBrowseFilter filter = new TsCHdaBrowseFilter();

				filter.AttributeID = Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeID.ITEMID;
				filter.Operator    = TsCHdaOperator.Equal;
				filter.FilterValue = itemNameTb_.Text;

				filters.Add(filter);
			}

			// add data type filter.
			if (dataTypeCtrl_.SelectedType != null && dataTypeCtrl_.SelectedType != typeof(object))
			{
				TsCHdaBrowseFilter filter = new TsCHdaBrowseFilter();

				filter.AttributeID = Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeID.DATA_TYPE;
				filter.Operator    = TsCHdaOperator.Equal;
				filter.FilterValue = dataTypeCtrl_.SelectedType;

				filters.Add(filter);
			}

			// add other attribute filters.
			foreach (ListViewItem item in browseFiltersLv_.Items)
			{
				filters.Add(item.Tag);
			}

			// send notification.
			if (mCallback_ != null)
			{
				mCallback_((int)maxElementsCtrl_.Value, (TsCHdaBrowseFilter[])filters.ToArray(typeof(TsCHdaBrowseFilter)));
			}
		}

		/// <summary>
		/// Sends the updated filters notification and closes the form. 
		/// </summary>
		private void OkBTN_Click(object sender, System.EventArgs e)
		{
			ApplyChanges();
			Close();
		}

		/// <summary>
		/// Sends the updated filters notification. 
		/// </summary>
		private void ApplyBTN_Click(object sender, System.EventArgs e)
		{
			ApplyChanges();
		}
		/// <summary>
		/// Closes the form. 
		/// </summary>
		private void CancelBTN_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Adds a new browse filter to the list view.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			// exclude attributes that are already in use.
			ArrayList excludeIDs = new ArrayList();

			excludeIDs.Add(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeID.ITEMID);
			excludeIDs.Add(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeID.DATA_TYPE);

			foreach (ListViewItem item in browseFiltersLv_.Items)
			{				
				excludeIDs.Add(((TsCHdaBrowseFilter)item.Tag).AttributeID);
			}

			// edit filter values.
			TsCHdaBrowseFilter filter = new AttributeFilterEditDlg().ShowDialog(mServer_, excludeIDs);

			if (filter == null)
			{
				return;
			}

			// add new filter to list.
			AddFilter(filter);

			// adjust columns.
			AdjustColumns();
		}

		private void RemoveMI_Click(object sender, System.EventArgs e)
		{
			// do nothing if nothing currently selected.
			if (browseFiltersLv_.SelectedItems.Count == 0)
			{
				return;
			}

			// removing selected filter should cause the controls to be updated.
			browseFiltersLv_.SelectedItems[0].Remove();
		}
	}
}

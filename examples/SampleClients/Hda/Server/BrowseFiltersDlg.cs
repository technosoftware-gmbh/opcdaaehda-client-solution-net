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
			okBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			buttonsPn_ = new System.Windows.Forms.Panel();
			applyBtn_ = new System.Windows.Forms.Button();
			itemNameLb_ = new System.Windows.Forms.Label();
			topPn_ = new System.Windows.Forms.Panel();
			maxElementsCtrl_ = new System.Windows.Forms.NumericUpDown();
			maxElementsLb_ = new System.Windows.Forms.Label();
			dataTypeCtrl_ = new SampleClients.Common.DataTypeCtrl();
			dataTypeLb_ = new System.Windows.Forms.Label();
			itemNameTb_ = new System.Windows.Forms.TextBox();
			mainPn_ = new System.Windows.Forms.Panel();
			browseFiltersLv_ = new System.Windows.Forms.ListView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			addMi_ = new System.Windows.Forms.ToolStripMenuItem();
			removeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			buttonsPn_.SuspendLayout();
			topPn_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(maxElementsCtrl_)).BeginInit();
			mainPn_.SuspendLayout();
			SuspendLayout();
			// 
			// OkBTN
			// 
			okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			okBtn_.Location = new System.Drawing.Point(4, 8);
			okBtn_.Name = "okBtn_";
			okBtn_.TabIndex = 1;
			okBtn_.Text = "OK";
			okBtn_.Click += new System.EventHandler(OkBTN_Click);
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(248, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			cancelBtn_.Click += new System.EventHandler(CancelBTN_Click);
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(applyBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(4, 218);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(328, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// ApplyBTN
			// 
			applyBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			applyBtn_.Location = new System.Drawing.Point(127, 7);
			applyBtn_.Name = "applyBtn_";
			applyBtn_.TabIndex = 2;
			applyBtn_.Text = "Apply";
			applyBtn_.Click += new System.EventHandler(ApplyBTN_Click);
			// 
			// ItemNameLB
			// 
			itemNameLb_.Location = new System.Drawing.Point(8, 0);
			itemNameLb_.Name = "itemNameLb_";
			itemNameLb_.Size = new System.Drawing.Size(80, 23);
			itemNameLb_.TabIndex = 0;
			itemNameLb_.Text = "Item Name";
			itemNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
			topPn_.Controls.Add(maxElementsCtrl_);
			topPn_.Controls.Add(maxElementsLb_);
			topPn_.Controls.Add(dataTypeCtrl_);
			topPn_.Controls.Add(dataTypeLb_);
			topPn_.Controls.Add(itemNameTb_);
			topPn_.Controls.Add(itemNameLb_);
			topPn_.Dock = System.Windows.Forms.DockStyle.Top;
			topPn_.Location = new System.Drawing.Point(4, 4);
			topPn_.Name = "topPn_";
			topPn_.Size = new System.Drawing.Size(328, 72);
			topPn_.TabIndex = 32;
			// 
			// MaxElementsCTRL
			// 
			maxElementsCtrl_.Location = new System.Drawing.Point(88, 49);
			maxElementsCtrl_.Maximum = new System.Decimal(new int[] {
																			2147483647,
																			0,
																			0,
																			0});
			maxElementsCtrl_.Name = "maxElementsCtrl_";
			maxElementsCtrl_.TabIndex = 14;
			// 
			// MaxElementsLB
			// 
			maxElementsLb_.Location = new System.Drawing.Point(8, 48);
			maxElementsLb_.Name = "maxElementsLb_";
			maxElementsLb_.Size = new System.Drawing.Size(80, 23);
			maxElementsLb_.TabIndex = 13;
			maxElementsLb_.Text = "Max Items";
			maxElementsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DataTypeCTRL
			// 
			dataTypeCtrl_.Location = new System.Drawing.Point(88, 24);
			dataTypeCtrl_.Name = "dataTypeCtrl_";
			dataTypeCtrl_.SelectedType = null;
			dataTypeCtrl_.Size = new System.Drawing.Size(120, 24);
			dataTypeCtrl_.TabIndex = 12;
			// 
			// DataTypeLB
			// 
			dataTypeLb_.Location = new System.Drawing.Point(8, 24);
			dataTypeLb_.Name = "dataTypeLb_";
			dataTypeLb_.Size = new System.Drawing.Size(80, 23);
			dataTypeLb_.TabIndex = 11;
			dataTypeLb_.Text = "Data Type";
			dataTypeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameTB
			// 
			itemNameTb_.Location = new System.Drawing.Point(88, 0);
			itemNameTb_.Name = "itemNameTb_";
			itemNameTb_.Size = new System.Drawing.Size(236, 20);
			itemNameTb_.TabIndex = 10;
			itemNameTb_.Text = "";
			// 
			// MainPN
			// 
			mainPn_.Controls.Add(browseFiltersLv_);
			mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			mainPn_.DockPadding.Bottom = 4;
			mainPn_.DockPadding.Top = 4;
			mainPn_.Location = new System.Drawing.Point(4, 76);
			mainPn_.Name = "mainPn_";
			mainPn_.Size = new System.Drawing.Size(328, 142);
			mainPn_.TabIndex = 33;
			// 
			// BrowseFiltersLV
			// 
			browseFiltersLv_.ContextMenuStrip = popupMenu_;
			browseFiltersLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			browseFiltersLv_.FullRowSelect = true;
			browseFiltersLv_.Location = new System.Drawing.Point(0, 4);
			browseFiltersLv_.MultiSelect = false;
			browseFiltersLv_.Name = "browseFiltersLv_";
			browseFiltersLv_.Size = new System.Drawing.Size(328, 134);
			browseFiltersLv_.TabIndex = 0;
			browseFiltersLv_.View = System.Windows.Forms.View.Details;
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  addMi_,
																					  removeMi_});
			// 
			// AddMI
			// 
			addMi_.ImageIndex = 0;
			addMi_.Text = "&Add";
			addMi_.Click += new System.EventHandler(AddMI_Click);
			// 
			// RemoveMI
			// 
			removeMi_.ImageIndex = 1;
			removeMi_.Text = "&Remove";
			removeMi_.Click += new System.EventHandler(RemoveMI_Click);
			// 
			// BrowseFiltersDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(336, 254);
			Controls.Add(mainPn_);
			Controls.Add(buttonsPn_);
			Controls.Add(topPn_);
			DockPadding.Left = 4;
			DockPadding.Right = 4;
			DockPadding.Top = 4;
			Name = "BrowseFiltersDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Browse Filters";
			buttonsPn_.ResumeLayout(false);
			topPn_.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(maxElementsCtrl_)).EndInit();
			mainPn_.ResumeLayout(false);
			ResumeLayout(false);

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

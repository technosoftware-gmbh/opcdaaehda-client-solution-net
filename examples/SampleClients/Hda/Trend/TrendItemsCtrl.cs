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
using SampleClients.Hda.Edit;
using SampleClients.Hda.Item;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Trend
{
	/// <summary>
	/// A control used to display a list of item properties.
	/// </summary>
	public class TrendItemsCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView itemsLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem copyDataMi_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		private System.Windows.Forms.ToolStripMenuItem addMi_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.ToolStripMenuItem removeMi_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public TrendItemsCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			itemsLv_.SmallImageList = Resources.Instance.ImageList;
			SetColumns(columnNames_);
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			itemsLv_ = new System.Windows.Forms.ListView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			addMi_ = new System.Windows.Forms.ToolStripMenuItem();
			editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			removeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			copyDataMi_ = new System.Windows.Forms.ToolStripMenuItem();
			SuspendLayout();
			// 
			// ItemsLV
			// 
			itemsLv_.ContextMenuStrip = popupMenu_;
			itemsLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			itemsLv_.FullRowSelect = true;
			itemsLv_.Location = new System.Drawing.Point(0, 0);
			itemsLv_.MultiSelect = false;
			itemsLv_.Name = "itemsLv_";
			itemsLv_.Size = new System.Drawing.Size(432, 272);
			itemsLv_.TabIndex = 0;
			itemsLv_.View = System.Windows.Forms.View.Details;
			itemsLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(ItemsLV_MouseDown);
			itemsLv_.DoubleClick += new System.EventHandler(ItemsLV_DoubleClick);
			itemsLv_.SelectedIndexChanged += new System.EventHandler(ItemsLV_SelectedIndexChanged);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  addMi_,
																					  editMi_,
																					  removeMi_,
																					  separator01_,
																					  copyDataMi_});
			// 
			// AddMI
			// 
			addMi_.ImageIndex = 0;
			addMi_.Text = "Add...";
			addMi_.Click += new System.EventHandler(AddMI_Click);
			// 
			// EditMI
			// 
			editMi_.ImageIndex = 1;
			editMi_.Text = "Edit...";
			editMi_.Click += new System.EventHandler(EditMI_Click);
			// 
			// RemoveMI
			// 
			removeMi_.ImageIndex = 2;
			removeMi_.Text = "Remove...";
			removeMi_.Click += new System.EventHandler(RemoveMI_Click);
			// 
			// Separator01
			// 
			separator01_.ImageIndex = 3;
			separator01_.Text = "-";
			// 
			// CopyDataMI
			// 
			copyDataMi_.ImageIndex = 4;
			copyDataMi_.Text = "Copy Data...";
			copyDataMi_.Click += new System.EventHandler(CopyDataMI_Click);
			// 
			// TrendItemsCtrl
			// 
			AllowDrop = true;
			Controls.Add(itemsLv_);
			Name = "TrendItemsCtrl";
			Size = new System.Drawing.Size(432, 272);
			ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// A delegate to receive item picked events.
		/// </summary>
		public delegate void ItemPickedEventHandler(TsCHdaItem[] items);

		/// <summary>
		/// Fired when one or more items are explicitly picked within the tree control.
		/// </summary>
		public event ItemPickedEventHandler ItemPicked;

		/// <summary>
		/// A delegate to receive item selected events.
		/// </summary>
		public delegate void ItemSelectedEventHandler(TsCHdaItem item);

		/// <summary>
		/// Fired when an item node is selected in the tree.
		/// </summary>
		public event ItemSelectedEventHandler ItemSelected;

		/// <summary>
		/// Initializes the control with the set of items in a trend.
		/// </summary>
		public void Initialize(TsCHdaTrend trend, bool update, ArrayList excludeList)
		{
			if (trend == null) throw new ArgumentNullException("trend");

			mTrend_ = trend;

			itemsLv_.Items.Clear();
			
			// add trend items.
			foreach (TsCHdaItem item in trend.Items)
			{
				// ignore items in the exclude list.
				if (excludeList != null)
				{
					if (excludeList.Contains(item))
					{
						continue;
					}
				}

				// create empty item value collections for each item.
				if (update)
				{
					AddListItem(new TsCHdaItemValueCollection(item));
				}
				else
				{
					AddListItem(item);
				}
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}	

		/// <summary>
		/// Returns the set of items stored in the list control.
		/// </summary>
		public TsCHdaItem[] GetItems(bool selected)
		{
			// fetch objects from list view.
			ArrayList items = new ArrayList(itemsLv_.Items.Count);

			if (selected)
			{				
				foreach (ListViewItem listItem in itemsLv_.SelectedItems)
				{
					if (typeof(TsCHdaItem).IsInstanceOfType(listItem.Tag))
					{
						items.Add(listItem.Tag);
					}
				}
			}
			else
			{
				foreach (ListViewItem listItem in itemsLv_.Items)
				{
					if (typeof(TsCHdaItem).IsInstanceOfType(listItem.Tag))
					{
						items.Add(listItem.Tag);
					}
				}
			}		

			// convert to an array.
			return (TsCHdaItem[])items.ToArray(typeof(TsCHdaItem));
		}

		/// <summary>
		/// Returns the set of values stored in the list control.
		/// </summary>
		public TsCHdaItemValueCollection[] GetValues(bool selected)
		{
			// fetch objects from list view.
			ArrayList items = new ArrayList(itemsLv_.Items.Count);

			if (selected)
			{				
				foreach (ListViewItem listItem in itemsLv_.SelectedItems)
				{
					if (typeof(TsCHdaItemValueCollection).IsInstanceOfType(listItem.Tag))
					{
						items.Add(listItem.Tag);
					}
				}
			}
			else
			{
				foreach (ListViewItem listItem in itemsLv_.Items)
				{
					if (typeof(TsCHdaItemValueCollection).IsInstanceOfType(listItem.Tag))
					{
						items.Add(listItem.Tag);
					}
				}
			}		

			// convert to an array.
			return (TsCHdaItemValueCollection[])items.ToArray(typeof(TsCHdaItemValueCollection));
		}
		#endregion
        
		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int Itemid     = 0;
		private const int Aggregate  = 1;
		private const int NumValues = 2;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Item ID",
			"Aggregate",
			"Num Values"
		};
		
		/// <summary>
		/// The trend containing the items being displayed.
		/// </summary>
		private TsCHdaTrend mTrend_ = null;

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			itemsLv_.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				itemsLv_.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < itemsLv_.Columns.Count; ii++)
			{
				// always show the item id and value column.
				if (ii == Itemid)
				{
					itemsLv_.Columns[ii].Width = -2;
					continue;
				}

				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in itemsLv_.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						itemsLv_.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) itemsLv_.Columns[ii].Width = 0;
			}
		}
		
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(object item, int fieldId)
		{
			// item identifier.
			if (typeof(OpcItem).IsInstanceOfType(item))
			{
				if (fieldId == Itemid)
				{
					return ((OpcItem)item).ItemName; 
				}
			}

			// item.
			if (typeof(TsCHdaItem).IsInstanceOfType(item))
			{
				if (fieldId == Aggregate)
				{
					int aggregateId = ((TsCHdaItem)item).Aggregate;

					if (aggregateId != TsCHdaAggregateID.NoAggregate)
					{
						return mTrend_.Server.Aggregates.Find(aggregateId);
					}
				}
			}

			// item value collection.
			if (typeof(TsCHdaItemValueCollection).IsInstanceOfType(item))
			{
				if (fieldId == NumValues)
				{
					return ((TsCHdaItemValueCollection)item).Count; 
				}
			}

			// invalid field or type.
			return null;
		}	

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(OpcItem item)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_YELLOW_SCROLL);

			// add empty columns.
			while (listItem.SubItems.Count < columnNames_.Length) listItem.SubItems.Add("");
			
			// update columns.
			UpdateListItem(listItem, item);
		
			// add to list view.
			itemsLv_.Items.Add(listItem);
		}

		/// <summary>
		/// Updates the columns of an item in the list view.
		/// </summary>
		private void UpdateListItem(ListViewItem listItem, object item)
		{
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, ii));
			}

			// save object as list view item tag.
			listItem.Tag = item;
		}
		#endregion

		/// <summary>
		/// Adds an item that was previously removed from the list.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				bool update = false;

				// create a list of trend items that are already in the view.
				ArrayList excludeList = new ArrayList();

				foreach (ListViewItem listItem in itemsLv_.Items)
				{
					if (typeof(OpcItem).IsInstanceOfType(listItem.Tag))
					{
						TsCHdaItem item = mTrend_.Items[(OpcItem)listItem.Tag];

						if (item != null)
						{
							excludeList.Add(item);
						}

						update = typeof(TsCHdaItemValueCollection).IsInstanceOfType(listItem.Tag);
					}
				}

				// prompt user to select items.
				TsCHdaItem[] items = new TrendSelectItemsDlg().ShowDialog(mTrend_, excludeList);

				if (items == null)
				{
					return;
				}

				// add new items to the list view.
				foreach (TsCHdaItem item in items)
				{
					if (update)
					{
						AddListItem(new TsCHdaItemValueCollection(item));
					}
					else
					{
						AddListItem(item);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Edits an item from the list.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (itemsLv_.SelectedItems.Count != 1)
				{
					return;
				}

				object item = itemsLv_.SelectedItems[0].Tag;

				// edit an item.
				if (typeof(TsCHdaItem).IsInstanceOfType(item))
				{
					if (new ItemEditDlg().ShowDialog(mTrend_.Server, (TsCHdaItem)item))
					{
						UpdateListItem(itemsLv_.SelectedItems[0], item);
					}
				}

				// edit an item value collection.
				else if (typeof(TsCHdaItemValueCollection).IsInstanceOfType(item))
				{
					if (new ItemValuesDlg().ShowDialog(mTrend_.Server, (TsCHdaItemValueCollection)item, false))
					{
						UpdateListItem(itemsLv_.SelectedItems[0], item);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Removes an item from the list.
		/// </summary>
		private void RemoveMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// build list of items to remove.
				ArrayList items = new ArrayList(itemsLv_.SelectedItems.Count);

				foreach (ListViewItem item in itemsLv_.SelectedItems)
				{
					items.Add(item);
				}

				// remove selected items.
				foreach (ListViewItem item in items)
				{
					item.Remove();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Initializes an item value collection by reading data from another item.
		/// </summary>
		private void CopyDataMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (itemsLv_.SelectedItems.Count != 1)
				{
					return;
				}

				// must be an item value collection.
				object item = itemsLv_.SelectedItems[0].Tag;

				if (!typeof(TsCHdaItemValueCollection).IsInstanceOfType(item))
				{
					return;
				}

				// prompt user to select a collection to copy.
				TsCHdaItemValueCollection values = new ReadValuesDlg().ShowDialog(mTrend_.Server, RequestType.ReadRaw, true);

				if (values != null)
				{
					// replace item identifier information.
					TsCHdaItemValueCollection existing = (TsCHdaItemValueCollection)item;

					values.ItemName     = existing.ItemName;
					values.ItemPath     = existing.ItemPath;
					values.ServerHandle = existing.ServerHandle;
					values.ClientHandle = existing.ClientHandle;

					// update list item.
					UpdateListItem(itemsLv_.SelectedItems[0], values);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Enables/disables items in the popup menu before it is displayed.
		/// </summary>
		private void ItemsLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			addMi_.Enabled      = itemsLv_.Items.Count < mTrend_.Items.Count;
			editMi_.Enabled     = false;
			removeMi_.Enabled   = false;
			copyDataMi_.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = itemsLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (itemsLv_.SelectedItems.Count == 1)
			{
				editMi_.Enabled     = true;
				removeMi_.Enabled   = true;
				copyDataMi_.Enabled = typeof(TsCHdaItemValueCollection).IsInstanceOfType(clickedItem.Tag);
			}
		}

		private void ItemsLV_DoubleClick(object sender, System.EventArgs e)
		{
			if (ItemPicked != null)
			{
				ItemPicked(null);
			}
		}

		private void ItemsLV_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ItemSelected != null)
			{
				ItemSelected(null);
			}
		}
	}
}

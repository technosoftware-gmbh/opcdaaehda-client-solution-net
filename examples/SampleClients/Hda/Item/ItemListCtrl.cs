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

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Item
{
	/// <summary>
	/// A control used to display a list of item properties.
	/// </summary>
	public class ItemListCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView itemsLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.ToolStripMenuItem removeMi_;
		private System.Windows.Forms.ToolStripMenuItem addMi_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ItemListCtrl()
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
			this.itemsLv_ = new System.Windows.Forms.ListView();
			this.popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			this.addMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.removeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.SuspendLayout();
			// 
			// ItemsLV
			// 
			this.itemsLv_.ContextMenuStrip = this.popupMenu_;
			this.itemsLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsLv_.FullRowSelect = true;
			this.itemsLv_.Location = new System.Drawing.Point(0, 0);
			this.itemsLv_.MultiSelect = false;
			this.itemsLv_.Name = "itemsLv_";
			this.itemsLv_.Size = new System.Drawing.Size(432, 272);
			this.itemsLv_.TabIndex = 0;
			this.itemsLv_.View = System.Windows.Forms.View.Details;
			this.itemsLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ItemsLV_MouseDown);
			this.itemsLv_.DoubleClick += new System.EventHandler(this.EditMI_Click);
			// 
			// PopupMenu
			// 
			this.popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  this.addMi_,
																					  this.editMi_,
																					  this.removeMi_});
			// 
			// AddMI
			// 
			this.addMi_.ImageIndex = 0;
			this.addMi_.Text = "Add..";
			this.addMi_.Click += new System.EventHandler(this.AddMI_Click);
			// 
			// EditMI
			// 
			this.editMi_.ImageIndex = 1;
			this.editMi_.Text = "Edit...";
			this.editMi_.Click += new System.EventHandler(this.EditMI_Click);
			// 
			// RemoveMI
			// 
			this.removeMi_.ImageIndex = 2;
			this.removeMi_.Text = "Remove";
			this.removeMi_.Click += new System.EventHandler(this.RemoveMI_Click);
			// 
			// ItemListCtrl
			// 
			this.AllowDrop = true;
			this.Controls.Add(this.itemsLv_);
			this.Name = "ItemListCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Initializes the control with a set of item identifiers.
		/// </summary>
		public void Initialize(TsCHdaServer server, OpcItem[] items)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;

			itemsLv_.Items.Clear();

			// check if there is nothing to do.
			if (items == null) return;

			foreach (OpcItem item in items)
			{
				AddListItem(item);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}

		/// <summary>
		/// Adds the set of item identifiers to the control.
		/// </summary>
		public void AddItems(OpcItem[] items)
		{
			if (items != null)
			{
				foreach (OpcItem item in items)
				{
					AddListItem(new OpcItem(item));
				}

				// adjust the list view columns to fit the data.
				AdjustColumns();
			}
		}

		/// <summary>
		/// Returns the set of items stored in the list control.
		/// </summary>
		public OpcItem[] GetItemIDs(bool selected)
		{
			// fetch objects from list view.
			ArrayList items = new ArrayList(itemsLv_.Items.Count);

			if (selected)
			{				
				foreach (ListViewItem listItem in itemsLv_.SelectedItems)
				{
					if (typeof(OpcItem).IsInstanceOfType(listItem.Tag))
					{
						items.Add(listItem.Tag);
					}
				}
			}
			else
			{
				foreach (ListViewItem listItem in itemsLv_.Items)
				{
					if (typeof(OpcItem).IsInstanceOfType(listItem.Tag))
					{
						items.Add(listItem.Tag);
					}
				}
			}		

			// convert to an array.
			return (OpcItem[])items.ToArray(typeof(OpcItem));
		}
		#endregion

		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int Itemid = 0;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Item ID"
		};
		
		/// <summary>
		/// The server containing the items being viewed in the list. 
		/// </summary>
		private TsCHdaServer mServer_ = null;

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
			if (typeof(OpcItem).IsInstanceOfType(item))
			{
				if (fieldId == Itemid)
				{
					return ((OpcItem)item).ItemName; 
				}
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(object item)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_YELLOW_SCROLL);

			// add empty columns.
			while (listItem.SubItems.Count < columnNames_.Length) listItem.SubItems.Add("");
			
			// update the columns.
			UpdateListItem(listItem, item);
		
			// add to list view.
			itemsLv_.Items.Add(listItem);
		}

		/// <summary>
		/// Updates an item in the list view.
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
		/// Adds an item to the list.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// prompt user to create a new item.
				OpcItem item = new OpcItem();

				if (!new ItemEditDlg().ShowDialog(item))
				{
					return;
				}

				// only add item if a vali item id was specified.
				if (item.ItemName != null && item.ItemName != "")
				{						
					// add to list view.
					AddListItem(item);
					
					// adjust columns.
					AdjustColumns();
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

				// check for correct type.
				object item = itemsLv_.SelectedItems[0].Tag;

				if (!typeof(OpcItem).IsInstanceOfType(item))
				{
					return;
				}

				// prompt user to edit the selected item.
				if (!new ItemEditDlg().ShowDialog((OpcItem)item))
				{
					return;
				}

				// update list view.
				UpdateListItem(itemsLv_.SelectedItems[0], item);
					
				// adjust columns.
				AdjustColumns();
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
		/// Enables/disables items in the popup menu before it is displayed.
		/// </summary>
		private void ItemsLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			addMi_.Enabled    = true;
			editMi_.Enabled   = false;
			removeMi_.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = itemsLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (itemsLv_.SelectedItems.Count == 1)
			{
				editMi_.Enabled   = true;
				removeMi_.Enabled = true;
			}
		}
	}
}

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
	/// A control used to display a list of item properties.
	/// </summary>
	public class AttributesSelectCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView attributesLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem addMi_;
		private System.Windows.Forms.ToolStripMenuItem viewMi_;
		private System.Windows.Forms.ToolStripMenuItem removeMi_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public AttributesSelectCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			attributesLv_.SmallImageList = Resources.Instance.ImageList;
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
			attributesLv_ = new System.Windows.Forms.ListView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			viewMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			addMi_ = new System.Windows.Forms.ToolStripMenuItem();
			removeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			SuspendLayout();
			// 
			// AttributesLV
			// 
			attributesLv_.CheckBoxes = true;
			attributesLv_.ContextMenuStrip = popupMenu_;
			attributesLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			attributesLv_.FullRowSelect = true;
			attributesLv_.Location = new System.Drawing.Point(0, 0);
			attributesLv_.Name = "attributesLv_";
			attributesLv_.Size = new System.Drawing.Size(432, 272);
			attributesLv_.TabIndex = 0;
			attributesLv_.View = System.Windows.Forms.View.Details;
			attributesLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(AttributesLV_MouseDown);
			attributesLv_.DoubleClick += new System.EventHandler(AttributesLV_DoubleClick);
			attributesLv_.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(AttributesLV_ColumnClick);
			attributesLv_.SelectedIndexChanged += new System.EventHandler(AttributesLV_SelectedIndexChanged);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  viewMi_,
																					  separator01_,
																					  addMi_,
																					  removeMi_});
			// 
			// ViewMI
			// 
			viewMi_.ImageIndex = 0;
			viewMi_.Text = "View...";
			viewMi_.Click += new System.EventHandler(ViewMI_Click);
			// 
			// Separator01
			// 
			separator01_.ImageIndex = 1;
			separator01_.Text = "-";
			// 
			// AddMI
			// 
			addMi_.ImageIndex = 2;
			addMi_.Text = "Add...";
			addMi_.Click += new System.EventHandler(AddMI_Click);
			// 
			// RemoveMI
			// 
			removeMi_.ImageIndex = 3;
			removeMi_.Text = "Remove...";
			removeMi_.Click += new System.EventHandler(RemoveMI_Click);
			// 
			// AttributesSelectCtrl
			// 
			AllowDrop = true;
			Controls.Add(attributesLv_);
			Name = "AttributesSelectCtrl";
			Size = new System.Drawing.Size(432, 272);
			ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Whether the attribute list can be changed. 
		/// </summary>
		public bool ReadOnly
		{
			get { return mReadOnly_;  }
			set { mReadOnly_ = value; }
		}

		/// <summary>
		/// A delegate to receive picked picked events.
		/// </summary>
		public delegate void AttributePickedEventHandler(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute[] attributes);

		/// <summary>
		/// Fired when one or more items are explicitly picked within the tree control.
		/// </summary>
		public event AttributePickedEventHandler AttributePicked;

		/// <summary>
		/// A delegate to receive item selected events.
		/// </summary>
		public delegate void AttributeSelectedEventHandler(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute attribute);

		/// <summary>
		/// Fired when an item node is selected in the tree.
		/// </summary>
		public event AttributeSelectedEventHandler AttributeSelected;

		/// <summary>
		/// Initializes the control with the set of items in a trend.
		/// </summary>
		public void Initialize(TsCHdaServer server, ArrayList excludeList)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;

			attributesLv_.Items.Clear();
			
			// add server attributes.
			foreach (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute attribute in server.Attributes)
			{
				// ignore attributes in the exclude list.
				if (excludeList != null)
				{
					if (excludeList.Contains(attribute.ID))
					{
						continue;
					}
				}

				AddListItem(attribute);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}	

		/// <summary>
		/// Returns the set of attributes stored in the list control.
		/// </summary>
		public Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute[] GetAttributes(bool selected)
		{
			// fetch objects from list view.
			ArrayList attributes = new ArrayList(attributesLv_.Items.Count);

			if (selected)
			{				
				foreach (ListViewItem listItem in attributesLv_.CheckedItems)
				{
					if (typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute).IsInstanceOfType(listItem.Tag))
					{
						attributes.Add(listItem.Tag);
					}
				}
			}
			else
			{
				foreach (ListViewItem listItem in attributesLv_.Items)
				{
					if (typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute).IsInstanceOfType(listItem.Tag))
					{
						attributes.Add(listItem.Tag);
					}
				}
			}		

			// convert to an array.
			return (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute[])attributes.ToArray(typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute));
		}

		/// <summary>
		/// Returns the ids of attributes stored in the list control.
		/// </summary>
		public int[] GetAttributeIDs(bool selected)
		{
			// convert attribute list to a list of ids.
			Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute[] attributes = GetAttributes(selected);

			if (attributes != null)
			{
				int[] ids = new int[attributes.Length];

				for (int ii = 0; ii < attributes.Length; ii++)
				{
					ids[ii] = attributes[ii].ID;
				}

				return ids;
			}

			// convert to an array.
			return null;
		}
		#endregion
        
		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int Attribute = 0;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Attribute"
		};
		
		/// <summary>
		/// The server containing the attributes being displayed.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// Whether the attribute list can be changed. 
		/// </summary>
		private bool mReadOnly_ = false;

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			attributesLv_.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				attributesLv_.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < attributesLv_.Columns.Count; ii++)
			{
				// always show the item id and value column.
				if (ii == Attribute)
				{
					attributesLv_.Columns[ii].Width = -2;
					continue;
				}

				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in attributesLv_.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						attributesLv_.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) attributesLv_.Columns[ii].Width = 0;
			}
		}
		
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(object item, int fieldId)
		{
			// attribute.
			if (typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute).IsInstanceOfType(item))
			{
				if (fieldId == Attribute)
				{
					return ((Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute)item).Name; 
				}
			}

			// invalid field or type.
			return null;
		}	

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(object item)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_EXPLODING_BOX);

			// add empty columns.
			while (listItem.SubItems.Count < columnNames_.Length) listItem.SubItems.Add("");
			
			// update columns.
			UpdateListItem(listItem, item);
		
			// add to list view.
			attributesLv_.Items.Add(listItem);

			// new items checked by default.
			listItem.Checked = true;
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
		/// Edits an item from the list.
		/// </summary>
		private void ViewMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (attributesLv_.SelectedItems.Count != 1)
				{
					return;
				}

				Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute attribute = (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute)attributesLv_.SelectedItems[0].Tag;

				// view an attribute.
				MessageBox.Show(attribute.Description, attribute.Name);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Adds an item that was previously removed from the list.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (ReadOnly)
				{
					return;
				}

				// create a list of trend items that are already in the view.
				ArrayList excludeList = new ArrayList();

				foreach (ListViewItem listItem in attributesLv_.Items)
				{
					if (typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute).IsInstanceOfType(listItem.Tag))
					{
                        excludeList.Add(((Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute)listItem.Tag).ID);
					}
				}

				// prompt user to select attributes.
				Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute[] attributes = new AttributesSelectDlg().ShowDialog(mServer_, excludeList);

				if (attributes == null)
				{
					return;
				}

				// add new attributes to the list view.
				foreach (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute attribute in attributes)
				{
					AddListItem(attribute);
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
				if (ReadOnly)
				{
					return;
				}

				// build list of items to remove.
				ArrayList attributes = new ArrayList(attributesLv_.SelectedItems.Count);

				foreach (ListViewItem item in attributesLv_.SelectedItems)
				{
					attributes.Add(item);
				}

				// remove selected items.
				foreach (ListViewItem item in attributes)
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
		private void AttributesLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			addMi_.Enabled      = !ReadOnly && attributesLv_.Items.Count < mServer_.Attributes.Count;
			viewMi_.Enabled     = false;
			removeMi_.Enabled   = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = attributesLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (attributesLv_.SelectedItems.Count == 1)
			{
				viewMi_.Enabled = true;
			}

			if (attributesLv_.SelectedItems.Count > 0)
			{
				removeMi_.Enabled = !ReadOnly;
			}
		}

		/// <summary>
		/// Fires an attribute picked event.
		/// </summary>
		private void AttributesLV_DoubleClick(object sender, System.EventArgs e)
		{
			if (AttributePicked != null)
			{
				AttributePicked(GetAttributes(true));
			}
			else
			{
				ViewMI_Click(sender, e);
			}
		}

		/// <summary>
		/// Fires an attribute selected event.
		/// </summary>
		private void AttributesLV_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (AttributeSelected != null)
			{
				if (attributesLv_.SelectedItems.Count > 0)
				{
					AttributeSelected((Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute)attributesLv_.SelectedItems[0].Tag);
				}
				else
				{
					AttributeSelected(null);
				}
			}
		}

		/// <summary>
		/// Toggles the state of the check boxes.
		/// </summary>
		private void AttributesLV_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			foreach (ListViewItem listItem in  attributesLv_.Items)
			{
				listItem.Checked = !listItem.Checked;
			}
		}
	}
}

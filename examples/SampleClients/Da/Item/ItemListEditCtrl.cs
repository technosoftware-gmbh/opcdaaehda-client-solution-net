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

using System.Collections;
using System.Windows.Forms;

using SampleClients.Common;
using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da.Item
{
    /// <summary>
    /// A control used to display and edit a list of Item objects.
    /// </summary>
    public class ItemListEditCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView itemListLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.ToolStripMenuItem newMi_;
		private System.Windows.Forms.ToolStripMenuItem deleteMi_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ItemListEditCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			itemListLv_.SmallImageList = Resources.Instance.ImageList;

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
			itemListLv_ = new System.Windows.Forms.ListView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			newMi_ = new System.Windows.Forms.ToolStripMenuItem();
			deleteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			SuspendLayout();
			// 
			// ItemListLV
			// 
			itemListLv_.ContextMenuStrip = popupMenu_;
			itemListLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			itemListLv_.FullRowSelect = true;
			itemListLv_.Name = "itemListLv_";
			itemListLv_.Size = new System.Drawing.Size(432, 272);
			itemListLv_.TabIndex = 0;
			itemListLv_.View = System.Windows.Forms.View.Details;
			itemListLv_.DoubleClick += new System.EventHandler(EditMI_Click);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  editMi_,
																					  newMi_,
																					  deleteMi_});
			// 
			// EditMI
			// 
			editMi_.ImageIndex = 0;
			editMi_.Text = "&Edit...";
			editMi_.Click += new System.EventHandler(EditMI_Click);
			// 
			// NewMI
			// 
			newMi_.ImageIndex = 1;
			newMi_.Text = "&New...";
			newMi_.Click += new System.EventHandler(NewMI_Click);
			// 
			// DeleteMI
			// 
			deleteMi_.ImageIndex = 2;
			deleteMi_.Text = "&Delete";
			deleteMi_.Click += new System.EventHandler(RemoveMI_Click);
			// 
			// ItemListEditCtrl
			// 
			Controls.AddRange(new System.Windows.Forms.Control[] {
																		  itemListLv_});
			Name = "ItemListEditCtrl";
			Size = new System.Drawing.Size(432, 272);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ItemId          = 0;
		private const int ItemPath        = 1;
		private const int RequestedType   = 2;
		private const int MaximumAge      = 3;
		private const int Active           = 4;
		private const int Deadband         = 5;
		private const int SamplingRate    = 6;
		private const int EnableBuffering = 7;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Item ID",
			"Item Path",
			"Req Type",
			"Max Age",
			"Active",
			"Deadband",
			"Sampling",
			"Buffering"
		};

		/// <summary>
		/// Whether the control is displaying a 'read' item or a 'subscribe' items.
		/// </summary>
		public bool IsReadItem = false;

		/// <summary>
		/// An item that specifies default values for all items.
		/// </summary>
		private TsCDaItem mTemplate_ = null;

		/// <summary>
		/// Initializes the control with the specified template item.
		/// </summary>
		public void Initialize(TsCDaItem template)
		{
			// clear existing items.
			itemListLv_.Items.Clear();

			// create template item.
			mTemplate_ = (template != null)?(TsCDaItem)template.Clone():new TsCDaItem();
			mTemplate_.ItemName = "<default>";

			// add template to list.
			AddItem(mTemplate_);

			// adjust columns.
			AdjustColumns();
		}

		/// <summary>
		/// Initializes the control with the specified set of items.
		/// </summary>
		public void Initialize(TsCDaItem template, TsCDaItem[] items)
		{
			Initialize(template);

			// add items.
			if (items != null)
			{
				foreach (TsCDaItem item in items)
				{
					// clear subscription related fields.
					if (IsReadItem)
					{
						item.ActiveSpecified          = false;
						item.DeadbandSpecified        = false;
						item.SamplingRateSpecified    = false;
						item.EnableBufferingSpecified = false;
					}

					AddItem(item);
				}
			}

			// adjust columns.
			AdjustColumns();
		}	
	
		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			itemListLv_.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				itemListLv_.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < itemListLv_.Columns.Count; ii++)
			{
				// always show the item id column.
				if (ii == ItemId)
				{
					itemListLv_.Columns[ii].Width = -2;
					continue;
				}

				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in itemListLv_.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						itemListLv_.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) itemListLv_.Columns[ii].Width = 0;
			}
		}

		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCDaItem item, int fieldId)
		{
			object fieldValue = null;

			switch (fieldId)
			{
				// Item Path
				case ItemPath:
				{
					fieldValue = item.ItemPath;
					break;
				}

				// Req Type
				case RequestedType:
				{
					fieldValue = item.ReqType;
					if (fieldValue == null)	fieldValue = mTemplate_.ReqType;
					break;
				}

				// Max Age
				case MaximumAge:
				{
					fieldValue = (item.MaxAgeSpecified)?item.MaxAge:fieldValue;
					if (fieldValue == null)	fieldValue = (mTemplate_.MaxAgeSpecified)?mTemplate_.MaxAge:fieldValue;
					break;
				}

				// Active
				case Active:
				{
					fieldValue = (item.ActiveSpecified)?item.Active:fieldValue;
					if (fieldValue == null)	fieldValue = (mTemplate_.ActiveSpecified)?mTemplate_.Active:fieldValue;
					break;
				}

				// Deadband
				case Deadband:
				{
					fieldValue = (item.DeadbandSpecified)?item.Deadband:fieldValue;
					if (fieldValue == null)	fieldValue = (mTemplate_.DeadbandSpecified)?mTemplate_.Deadband:fieldValue;
					break;
				}

				// Sampling Rate
				case SamplingRate:
				{
					fieldValue = (item.SamplingRateSpecified)?item.SamplingRate:fieldValue;
					if (fieldValue == null)	fieldValue = (mTemplate_.SamplingRateSpecified)?mTemplate_.SamplingRate:fieldValue;
					break;
				}

				// Enable Buffering
				case EnableBuffering:
				{
					fieldValue = (item.EnableBufferingSpecified)?item.EnableBuffering:fieldValue;
					if (fieldValue == null)	fieldValue = (mTemplate_.EnableBufferingSpecified)?mTemplate_.EnableBuffering:fieldValue;
					break;
				}
			}

			return fieldValue;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		public void AddItem(TsCDaItem item)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem(item.ItemName, Resources.IMAGE_YELLOW_SCROLL);

			// add appropriate sub-items.
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, ItemPath)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, RequestedType)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, MaximumAge)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, Active)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, Deadband)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, SamplingRate)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, EnableBuffering)));

			// save item object as list view item tag.
			listItem.Tag = item;

			// insert/add item to list view.
			if (item == mTemplate_) itemListLv_.Items.Insert(0, listItem);
			else itemListLv_.Items.Add(listItem);		    

			// adjust columns.
			AdjustColumns();
		}

		/// <summary>
		/// Returns the set of items in the control.
		/// </summary>
		public TsCDaItem[] GetItems()
		{
			ArrayList items = new ArrayList();

			foreach (ListViewItem listItem in itemListLv_.Items)
			{
				// skip template.
				if (listItem.Tag == mTemplate_)
				{
					continue;
				}

				object field = null;

				// create copy of item.
				TsCDaItem item = (TsCDaItem)((TsCDaItem)listItem.Tag).Clone();

				// Req Type
				field	                      = GetFieldValue(item, RequestedType);
				item.ReqType                  = (System.Type)field;

				// Max Age
				field                         = GetFieldValue(item, MaximumAge);
				item.MaxAge                   = (field != null)?(int)field:0;
				item.MaxAgeSpecified          = field != null;

				// Active
				field                         = GetFieldValue(item, Active);
				item.Active                   = (field != null)?(bool)field:false;
				item.ActiveSpecified          = field != null;

				// Deadband
				field                         = GetFieldValue(item, Deadband);
				item.Deadband                 = (field != null)?(float)field:0;
				item.DeadbandSpecified        = field != null;

				// Sampling Rate
				field                         = GetFieldValue(item, SamplingRate);
				item.SamplingRate             = (field != null)?(int)field:0;
				item.SamplingRateSpecified    = field != null;

				// Enable Buffering
				field                         = GetFieldValue(item, EnableBuffering);
				item.EnableBuffering          = (field != null)?(bool)field:false;
				item.EnableBufferingSpecified = field != null;

				// add item to list.
				items.Add(item);
			}	

			// convert to array of item objects.
			return (TsCDaItem[])items.ToArray(typeof(TsCDaItem));
		}	

		/// <summary>
		/// Removes the selected items from the list.
		/// </summary>
		private void RemoveMI_Click(object sender, System.EventArgs e)
		{
			// copy the selected items collection.
			ArrayList items = new ArrayList(itemListLv_.SelectedItems.Count);

			items.AddRange(itemListLv_.SelectedItems);

			// remove the selected items.
			foreach (ListViewItem item in items)
			{
				if (item.Tag != mTemplate_)	item.Remove();
			}	
		}

		/// <summary>
		/// Edits the item template.
		/// </summary>
		private void EditTemplate(TsCDaItem template)
		{			
			// prompt user to edit the template.
			TsCDaItem[] templates = new ItemListEditDlg().ShowDialog(new TsCDaItem[] { template }, IsReadItem, false);

			if (templates == null || templates.Length != 1) 
			{
				return;
			}

			// get existing items without applying defaults.
			ArrayList items = new ArrayList();

			foreach (ListViewItem item in itemListLv_.Items)
			{
				if (item.Tag != null && item.Tag.GetType() == typeof(TsCDaItem))
				{
					if (item.Tag != mTemplate_)	items.Add(item.Tag);
				}
			}

			// re-initialize the list with the new template.
			Initialize(templates[0]);

			// add items back.
			foreach (TsCDaItem item in items) AddItem(item);
		}

		/// <summary>
		/// Edits a group of items.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{			
			// check if the template if being editied.
			if (itemListLv_.SelectedItems.Count == 1)
			{
				if (itemListLv_.SelectedItems[0].Tag == mTemplate_)
				{
					EditTemplate(mTemplate_);
					return;
				}
			}
			
			// build list of items to edit (exclude template).
			ArrayList itemList = new ArrayList(itemListLv_.SelectedItems.Count);

			foreach (ListViewItem item in itemListLv_.SelectedItems)
			{
				if (item.Tag != null && item.Tag.GetType() == typeof(TsCDaItem))
				{
					if (item.Tag != mTemplate_)	itemList.Add(item.Tag);
				}
			}

			// prompt user to edit list of items.
			TsCDaItem[] items = new ItemListEditDlg().ShowDialog((TsCDaItem[])itemList.ToArray(typeof(TsCDaItem)), IsReadItem, false);

			if (items == null) 
			{
				return;
			}
			
			// remove changed items.
			RemoveMI_Click(sender, e);

			// add changed items.
			foreach (TsCDaItem item in items) AddItem(item);
		}

		/// <summary>
		/// Creates a new item.
		/// </summary>
		private void NewMI_Click(object sender, System.EventArgs e)
		{
			TsCDaItem template = null;

			// copy the current selection.
			if (itemListLv_.SelectedItems.Count > 0)
			{
				template = (TsCDaItem)((TsCDaItem)itemListLv_.SelectedItems[0].Tag).Clone();
			}
			
			// prompt user to edit new item.
			TsCDaItem[] items = new ItemListEditDlg().ShowDialog(new TsCDaItem[] { template }, IsReadItem, true);

			if (items == null) 
			{
				return;
			}

			// add new items.
			foreach (TsCDaItem item in items) AddItem(item);		
		}
	}
}

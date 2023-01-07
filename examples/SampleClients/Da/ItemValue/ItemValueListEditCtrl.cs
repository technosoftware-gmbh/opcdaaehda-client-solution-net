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
using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da.ItemValue
{
    /// <summary>
    /// A control used to display and edit a list of ItemValue objects.
    /// </summary>
    public class ItemValueListEditCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView itemListLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.ToolStripMenuItem initMi_;
		private System.Windows.Forms.ToolStripMenuItem deleteMi_;
		private System.Windows.Forms.ToolStripMenuItem newMi_;
		private System.Windows.Forms.ToolStripMenuItem valuesOnlyMi_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ItemValueListEditCtrl()
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
			initMi_ = new System.Windows.Forms.ToolStripMenuItem();
			deleteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			valuesOnlyMi_ = new System.Windows.Forms.ToolStripMenuItem();
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
																					  initMi_,
																					  deleteMi_,
																					  separator01_,
																					  valuesOnlyMi_});
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
			// InitMI
			// 
			initMi_.ImageIndex = 2;
			initMi_.Text = "&Initialize with Properties";
			initMi_.Click += new System.EventHandler(InitMI_Click);
			// 
			// DeleteMI
			// 
			deleteMi_.ImageIndex = 3;
			deleteMi_.Text = "&Delete";
			deleteMi_.Click += new System.EventHandler(RemoveMI_Click);
			// 
			// Separator01
			// 
			separator01_.ImageIndex = 4;
			separator01_.Text = "-";
			// 
			// ValuesOnlyMI
			// 
			valuesOnlyMi_.Checked = true;
			valuesOnlyMi_.ImageIndex = 5;
			valuesOnlyMi_.Text = "&Values Only";
			valuesOnlyMi_.Click += new System.EventHandler(ValuesOnlyMI_Click);
			// 
			// ItemValueListEditCtrl
			// 
			Controls.AddRange(new System.Windows.Forms.Control[] {
																		  itemListLv_});
			Name = "ItemValueListEditCtrl";
			Size = new System.Drawing.Size(432, 272);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ItemId          = 0;
		private const int ItemPath        = 1;
		private const int Value            = 2;
		private const int ValueType       = 3;
		private const int QualityBits     = 4;
		private const int LimitBits       = 5;
		private const int VendorBits      = 6;
		private const int Timestamp        = 7;
		private const int Quality          = 100;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Item ID",
			"Item Path",
			"Value",
			"Data Type",
			"Quality Bits",
			"Limit Bits",
			"Vendor Bits",
			"Timestamp"
		};

		/// <summary>
		/// The server where the items are resident on.
		/// </summary>
		private TsCDaServer mServer_ = null;

		/// <summary>
		/// An item that specifies default values for all items.
		/// </summary>
		private TsCDaItemValue mTemplate_ = null;

		/// <summary>
		/// Initializes the control with the specified set of items.
		/// </summary>
		public void Initialize(TsCDaServer server, TsCDaItemValue template)
		{
			// clear existing items.
			itemListLv_.Items.Clear();

			// save reference to server object.
			mServer_ = server;

			// disable init from properties if no server provided.
			initMi_.Enabled = mServer_ != null;

			// create template item.
			mTemplate_ = (template != null)?(TsCDaItemValue)template.Clone():new TsCDaItemValue();
			mTemplate_.ItemName = "<default>";

			// clear values only flag if quality or timestamp specified.
			if (mTemplate_.QualitySpecified || mTemplate_.TimestampSpecified)
			{
				valuesOnlyMi_.Checked = false;
			}

			// add template to list.
			AddItem(mTemplate_);

			// adjust columns.
			AdjustColumns();
		}
	
		/// <summary>
		/// Initializes the control with the specified set of items.
		/// </summary>
		public void Initialize(TsCDaServer server, TsCDaItemValue template, TsCDaItem[] items)
		{
			Initialize(server, template);

			// add items.
			if (items != null)
			{
				foreach (TsCDaItem item in items) AddItemWithDefaults(new TsCDaItemValue(item));
			}

			// adjust columns.
			AdjustColumns();
		}	
	
		/// <summary>
		/// Initializes an item value object with the item properties.
		/// </summary>
		private void GetDefaultValues(TsCDaItemValue[] items, bool valuesOnly)
		{
			try
			{
				// get item value properties.
				TsCDaItemPropertyCollection[] propertyLists = mServer_.GetProperties(
					items,
					new TsDaPropertyID[] { TsDaProperty.DATATYPE, TsDaProperty.QUALITY, TsDaProperty.TIMESTAMP, TsDaProperty.VALUE },
					true);

				// update item values.
				for (int ii = 0; ii < items.Length; ii++)
				{
					// ignore errors for failures for individual items.
					if (propertyLists[ii].Result.Failed())
					{
						continue;
					}

					// set a default value based on the data type.
					object defaultValue = propertyLists[ii][3].Value;

					if (defaultValue == null)
					{
						System.Type type = (System.Type)propertyLists[ii][0].Value;
						System.Type baseType = (type.IsArray)?type.GetElementType():type;

						if (baseType == typeof(string))   defaultValue = "";
						if (baseType == typeof(DateTime)) defaultValue = DateTime.Now;
						if (baseType == typeof(object))   defaultValue = "";

						defaultValue = Technosoftware.DaAeHdaClient.OpcConvert.ChangeType(defaultValue, baseType);

						// convert to a three element array.
						if (type.IsArray)
						{
							defaultValue = new object[] {defaultValue, defaultValue, defaultValue};
							defaultValue = Technosoftware.DaAeHdaClient.OpcConvert.ChangeType(defaultValue, type);
						}
					}

					// update the object.
					items[ii].Value     =  defaultValue;
					items[ii].Quality   =  (TsCDaQuality)propertyLists[ii][1].Value;
					items[ii].Timestamp =  (DateTime)propertyLists[ii][2].Value;

					// set the quality/timestamp exists flags.
					items[ii].QualitySpecified   = !valuesOnly;
					items[ii].TimestampSpecified = !valuesOnly;
				}
			}
			catch
			{
				// ignore errors.
			}
		}

		/// <summary>
		/// Updates the specified list item.
		/// </summary>
		private void UpdateItem(ListViewItem listItem, TsCDaItemValue item)
		{
			listItem.SubItems[Value].Text        = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, Value));
			listItem.SubItems[ValueType].Text   = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, ValueType));
			listItem.SubItems[QualityBits].Text = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, QualityBits));
			listItem.SubItems[LimitBits].Text   = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, LimitBits));
			listItem.SubItems[VendorBits].Text  = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, VendorBits));
			listItem.SubItems[Timestamp].Text    = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, Timestamp));
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
				if (ii == ItemId || ii == Value)
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
        /// Performs a deep copy of an object if possible.
        /// </summary>
        public object Clone(object source)
        {
            if (source == null) return null;
            if (source.GetType().IsValueType) return source;

            if (source.GetType().IsArray || source.GetType() == typeof(Array))
            {
                Array array = (Array)((Array)source).Clone();

                for (int ii = 0; ii < array.Length; ii++)
                {
                    array.SetValue(Clone(array.GetValue(ii)), ii);
                }

                return array;
            }

            try { return ((ICloneable)source).Clone(); }
            catch { throw new NotSupportedException("Object cannot be cloned."); }
        }
        
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCDaItemValue item, int fieldId)
		{
			object fieldValue = null;

			switch (fieldId)
			{
				case ItemPath:
				{
					fieldValue = item.ItemPath;
					break;
				}

				case Value:
				{
					fieldValue = item.Value;
					if (fieldValue == null)	fieldValue = Technosoftware.DaAeHdaClient.OpcConvert.Clone(mTemplate_.Value);
					break;
				}

				case ValueType:
				{
					fieldValue = (item.Value != null)?item.Value.GetType():null;
					if (fieldValue == null)	fieldValue = (mTemplate_.Value != null)?mTemplate_.Value.GetType():null;
					break;
				}		
				
				case QualityBits:
				{
					fieldValue = (item.QualitySpecified)?item.Quality.QualityBits:fieldValue;
					if (fieldValue == null)	fieldValue = (mTemplate_.QualitySpecified)?mTemplate_.Quality.QualityBits:fieldValue;
					break;
				}

				case LimitBits:
				{
					fieldValue = (item.QualitySpecified)?item.Quality.LimitBits:fieldValue;
					if (fieldValue == null)	fieldValue = (mTemplate_.QualitySpecified)?mTemplate_.Quality.LimitBits:fieldValue;
					break;
				}

				case VendorBits:
				{
					fieldValue = (item.QualitySpecified)?item.Quality.VendorBits:fieldValue;
					if (fieldValue == null)	fieldValue = (mTemplate_.QualitySpecified)?mTemplate_.Quality.VendorBits:fieldValue;
					break;
				}

				case Timestamp:
				{
					fieldValue = (item.TimestampSpecified)?item.Timestamp:fieldValue;
					if (fieldValue == null)	fieldValue = (mTemplate_.TimestampSpecified)?mTemplate_.Timestamp:fieldValue;
					break;
				}

				case Quality:
				{
					fieldValue = (item.QualitySpecified)?item.Quality:fieldValue;
					if (fieldValue == null)	fieldValue = (mTemplate_.QualitySpecified)?mTemplate_.Quality:fieldValue;
					break;
				}
			}

			return fieldValue;
		}

		/// <summary>
		/// Adds a items to the list view.
		/// </summary>
		public void AddItemWithDefaults(TsCDaItemValue item)
		{
			GetDefaultValues(new TsCDaItemValue[] { item }, valuesOnlyMi_.Checked);
			AddItem(item);
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddItem(TsCDaItemValue item)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem(item.ItemName, Resources.IMAGE_YELLOW_SCROLL);

			// add sub-items.
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, ItemPath)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, Value)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, ValueType)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, QualityBits)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, LimitBits)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, VendorBits)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, Timestamp)));

			// save item object as list view item tag.
			listItem.Tag = item;

			// insert/add item to list view.
			if (item == mTemplate_) itemListLv_.Items.Insert(0, listItem);
			else itemListLv_.Items.Add(listItem);		    

			// adjust column widths.
			AdjustColumns();
		}

		/// <summary>
		/// Returns the set of items in the control.
		/// </summary>
		public TsCDaItemValue[] GetItems()
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
				TsCDaItemValue item = (TsCDaItemValue)((TsCDaItemValue)listItem.Tag).Clone();

				// Value
				field	                = GetFieldValue(item, Value);
				item.Value              = field;

				// Quality
				field	                = GetFieldValue(item, Quality);
				item.Quality            = (field != null)?(TsCDaQuality)field:TsCDaQuality.Bad;
				item.QualitySpecified   = field != null;

				// Timestamp
				field	                = GetFieldValue(item, Timestamp);
				item.Timestamp          = (field != null)?(DateTime)field:DateTime.MinValue;
				item.TimestampSpecified = field != null;

				// add item to list.
				items.Add(item);
			}	

			// convert to array of item objects.
			return (TsCDaItemValue[])items.ToArray(typeof(TsCDaItemValue));
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
		private void EditTemplate(TsCDaItemValue template)
		{			
			// prompt user to edit the template.
			TsCDaItemValue[] templates = new ItemValueListEditDlg().ShowDialog(new TsCDaItemValue[] { template }, false);

			if (templates == null || templates.Length != 1) 
			{
				return;
			}

			// get existing items without applying defaults.
			ArrayList items = new ArrayList();

			foreach (ListViewItem item in itemListLv_.Items)
			{
				if (item.Tag != null && item.Tag.GetType() == typeof(TsCDaItemValue))
				{
					if (item.Tag != mTemplate_)	items.Add(item.Tag);
				}
			}

			// re-initialize the list with the new template.
			Initialize(mServer_, templates[0]);

			// add items back.
			foreach (TsCDaItemValue item in items) AddItem(item);
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
				if (item.Tag != null && item.Tag.GetType() == typeof(TsCDaItemValue))
				{
					if (item.Tag != mTemplate_)	itemList.Add(item.Tag);
				}
			}

			// prompt user to edit list of items.
			TsCDaItemValue[] items = new ItemValueListEditDlg().ShowDialog((TsCDaItemValue[])itemList.ToArray(typeof(TsCDaItemValue)), false);

			if (items == null) 
			{
				return;
			}
			
			// remove changed items.
			RemoveMI_Click(sender, e);

			// add changed items.
			foreach (TsCDaItemValue item in items) 
			{
				// clear values only flag if quality or timestamp specified.
				if (item.QualitySpecified || item.TimestampSpecified)
				{
					valuesOnlyMi_.Checked = false;
				}

				AddItem(item);
			}

			// adjust columns to fit data.
			AdjustColumns();
		}

		/// <summary>
		/// Creates a new item.
		/// </summary>
		private void NewMI_Click(object sender, System.EventArgs e)
		{
			TsCDaItemValue template = null;

			// copy the current selection.
			if (itemListLv_.SelectedItems.Count > 0)
			{
				template = (TsCDaItemValue)((TsCDaItemValue)itemListLv_.SelectedItems[0].Tag).Clone();
			}
			
			// prompt user to edit new item.
			TsCDaItemValue[] items = new ItemValueListEditDlg().ShowDialog(new TsCDaItemValue[] { template }, true);

			if (items == null) 
			{
				return;
			}

			// add new items.
			foreach (TsCDaItemValue item in items) AddItem(item);		

			// adjust columns to fit data.
			AdjustColumns();
		}

		/// <summary>
		/// Reads the item properties from the server and uses them to initialize the items.
		/// </summary>
		private void InitMI_Click(object sender, System.EventArgs e)
		{
			// build list of items to query properties for (exclude template).
			ArrayList items = new ArrayList(itemListLv_.SelectedItems.Count);

			foreach (ListViewItem listItem in itemListLv_.SelectedItems)
			{
				if (listItem.Tag != null && listItem.Tag.GetType() == typeof(TsCDaItemValue))
				{
					if (listItem.Tag != mTemplate_)	
					{
						items.Add(listItem.Tag);
					}
				}
			}

			// fetch default values from item properties.
			GetDefaultValues((TsCDaItemValue[])items.ToArray(typeof(TsCDaItemValue)), valuesOnlyMi_.Checked);
			
			// update list view.
			foreach (ListViewItem listItem in itemListLv_.SelectedItems) 
			{
				UpdateItem(listItem, (TsCDaItemValue)listItem.Tag);
			}
			
			// adjust columns widths.
			AdjustColumns();
		}

		/// <summary>
		/// Toggles the flag indicating whether to write only values.
		/// </summary>
		private void ValuesOnlyMI_Click(object sender, System.EventArgs e)
		{
			valuesOnlyMi_.Checked = !valuesOnlyMi_.Checked;

			// clear quality and timestamp.
			if (valuesOnlyMi_.Checked)
			{
				foreach (ListViewItem listItem in itemListLv_.Items)
				{
					// get item.
					TsCDaItemValue item = (TsCDaItemValue)listItem.Tag;

					// disable quality/timestamp fields.
					item.QualitySpecified   = false;
					item.TimestampSpecified = false;
			
					// clear columns in the list view.
					listItem.SubItems[QualityBits].Text = "";
					listItem.SubItems[LimitBits].Text   = "";
					listItem.SubItems[VendorBits].Text  = "";
					listItem.SubItems[Timestamp].Text    = "";
				}			

				AdjustColumns();
			}
		}
	}
}

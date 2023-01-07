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

using System.Windows.Forms;

using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Cpx;
using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da.Browse
{
    /// <summary>
    /// A control used to display a list of item properties.
    /// </summary>
    public class PropertyListViewCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView propertiesLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem removeMi_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.ToolStripMenuItem copyMi_;
		private System.Windows.Forms.ToolStripMenuItem viewMi_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public PropertyListViewCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			propertiesLv_.SmallImageList = Resources.Instance.ImageList;
			
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
			propertiesLv_ = new System.Windows.Forms.ListView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			viewMi_ = new System.Windows.Forms.ToolStripMenuItem();
			copyMi_ = new System.Windows.Forms.ToolStripMenuItem();
			editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			removeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			SuspendLayout();
			// 
			// PropertiesLV
			// 
			propertiesLv_.ContextMenuStrip = popupMenu_;
			propertiesLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			propertiesLv_.FullRowSelect = true;
			propertiesLv_.MultiSelect = false;
			propertiesLv_.Name = "propertiesLv_";
			propertiesLv_.Size = new System.Drawing.Size(432, 272);
			propertiesLv_.TabIndex = 0;
			propertiesLv_.View = System.Windows.Forms.View.Details;
			propertiesLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(PropertiesLV_MouseDown);
			propertiesLv_.DoubleClick += new System.EventHandler(ViewMI_Click);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  viewMi_});
			// 
			// ViewMI
			// 
			viewMi_.ImageIndex = 0;
			viewMi_.Text = "&View...";
			viewMi_.Click += new System.EventHandler(ViewMI_Click);
			// 
			// CopyMI
			// 
			copyMi_.ImageIndex = -1;
			copyMi_.Text = "";
			// 
			// EditMI
			// 
			editMi_.ImageIndex = -1;
			editMi_.Text = "";
			// 
			// RemoveMI
			// 
			removeMi_.ImageIndex = -1;
			removeMi_.Text = "";
			// 
			// PropertyListViewCtrl
			// 
			AllowDrop = true;
			Controls.AddRange(new System.Windows.Forms.Control[] {
																		  propertiesLv_});
			Name = "PropertyListViewCtrl";
			Size = new System.Drawing.Size(432, 272);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int Id           = 0;
		private const int Description  = 1;
		private const int Value        = 2;
		private const int DataType    = 3;
		private const int ItemPath    = 4;
		private const int ItemName    = 5;
		private const int Error        = 6;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"ID",
			"Description",
			"Value",
			"Data Type",
			"Item Path",
			"Item Name",
			"Result"
		};
		
		/// <summary>
		/// The browse element containin the properties being displayed.
		/// </summary>
		private TsCDaBrowseElement mElement_ = null;

		/// <summary>
		/// Initializes the control with a set of identified results.
		/// </summary>
		public void Initialize(TsCDaBrowseElement element)
		{
			propertiesLv_.Items.Clear();

			// check if there is nothing to do.
			if (element == null || element.Properties == null) return;

			mElement_ = element;

			foreach (TsCDaItemProperty property in element.Properties)
			{
				AddProperty(property);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}	

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			propertiesLv_.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				propertiesLv_.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < propertiesLv_.Columns.Count; ii++)
			{
				// always show the property id and value column.
				if (ii == Id || ii == Value)
				{
					propertiesLv_.Columns[ii].Width = -2;
					continue;
				}

				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in propertiesLv_.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						propertiesLv_.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) propertiesLv_.Columns[ii].Width = 0;
			}

			/*
			// get total width
			int width = 0;

			foreach (ColumnHeader column in  PropertiesLV.Columns) width += column.Width;

			// expand parent form to display all columns.
			if (width > PropertiesLV.Width)
			{
				width = ParentForm.Width + (width - PropertiesLV.Width) + 4; 
				ParentForm.Width = (width > 1024)?1024:width;
			}
			*/
		}
	
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCDaItemProperty property, int fieldId)
		{
			switch (fieldId)
			{
				case Id:          { return property.ID.ToString(); }
				case Description: { return property.Description; }
				case Value:       { return property.Value; }
				case DataType:   { return (property.Value != null)?property.Value.GetType():null; }
				case ItemPath:   { return property.ItemPath; }
				case ItemName:   { return property.ItemName; }
				case Error:       { return property.Result; }
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddProperty(TsCDaItemProperty property)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem((string)GetFieldValue(property, Id), Resources.IMAGE_EXPLODING_BOX);

			// add appropriate sub-items.
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(property, Description)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(property, Value)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(property, DataType)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(property, ItemPath)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(property, ItemName)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(property, Error)));

			// save item object as list view item tag.
			listItem.Tag = property;
		
			// add to list view.
			propertiesLv_.Items.Add(listItem);
		}
		
		/// <summary>
		/// Shows a detailed view for array values.
		/// </summary>
		private void ViewMI_Click(object sender, System.EventArgs e)
		{
			if (propertiesLv_.SelectedItems.Count > 0)
			{
				object tag = propertiesLv_.SelectedItems[0].Tag;

				if (tag != null && tag.GetType() == typeof(TsCDaItemProperty))
				{
					TsCDaItemProperty property = (TsCDaItemProperty)tag;

					if (property.Value != null)
					{
						if (property.ID == TsDaProperty.VALUE)
						{
							TsCCpxComplexItem complexItem = TsCCpxComplexTypeCache.GetComplexItem(mElement_);

							if (complexItem != null)
							{
								new EditComplexValueDlg().ShowDialog(complexItem, property.Value, true, true);
							}
						}
						else if (property.Value.GetType().IsArray)
						{
							new EditArrayDlg().ShowDialog(property.Value, true);
						}
					}
				}
			}
		}

		/// <summary>
		/// Enables/disables items in the popup menu before it is displayed.
		/// </summary>
		private void PropertiesLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// disable everything.
			viewMi_.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = propertiesLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked node.
			clickedItem.Selected = true;

			if (propertiesLv_.SelectedItems.Count == 1)
			{
				viewMi_.Enabled = true;
			}
		}
	}
}

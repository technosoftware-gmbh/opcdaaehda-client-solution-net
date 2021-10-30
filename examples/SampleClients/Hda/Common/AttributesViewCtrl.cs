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

namespace SampleClients.Hda.Common
{
	/// <summary>
	/// A control used to display a list of item properties.
	/// </summary>
	public class AttributesViewCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView attributesLv_;
		private System.Windows.Forms.ToolStripMenuItem removeMi_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.ToolStripMenuItem copyMi_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem viewMi_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public AttributesViewCtrl()
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
			this.attributesLv_ = new System.Windows.Forms.ListView();
			this.copyMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.removeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			this.viewMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.SuspendLayout();
			// 
			// AttributesLV
			// 
			this.attributesLv_.ContextMenuStrip = this.popupMenu_;
			this.attributesLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.attributesLv_.FullRowSelect = true;
			this.attributesLv_.Location = new System.Drawing.Point(0, 0);
			this.attributesLv_.MultiSelect = false;
			this.attributesLv_.Name = "attributesLv_";
			this.attributesLv_.Size = new System.Drawing.Size(432, 272);
			this.attributesLv_.TabIndex = 0;
			this.attributesLv_.View = System.Windows.Forms.View.Details;
			this.attributesLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AttributesLV_MouseDown);
			this.attributesLv_.DoubleClick += new System.EventHandler(this.ViewMI_Click);
			// 
			// CopyMI
			// 
			this.copyMi_.ImageIndex = -1;
			this.copyMi_.Text = "";
			// 
			// EditMI
			// 
			this.editMi_.ImageIndex = -1;
			this.editMi_.Text = "";
			// 
			// RemoveMI
			// 
			this.removeMi_.ImageIndex = -1;
			this.removeMi_.Text = "";
			// 
			// PopupMenu
			// 
			this.popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  this.viewMi_});
			// 
			// ViewMI
			// 
			this.viewMi_.ImageIndex = 0;
			this.viewMi_.Text = "View...";
			this.viewMi_.Click += new System.EventHandler(this.ViewMI_Click);
			// 
			// AttributesViewCtrl
			// 
			this.AllowDrop = true;
			this.Controls.Add(this.attributesLv_);
			((Control)this).Name = "AttributesViewCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the attributes supported by the server.
		/// </summary>
		public void Initialize(TsCHdaServer server)
		{
			mServer_ = server;

			attributesLv_.Items.Clear();

			if (server != null)
			{
				foreach (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute attribute in server.Attributes)
				{
					AddListItem(attribute);
				}
			
				AdjustColumns();
			}
		}	

		/// <summary>
		/// Displays the results of a read attributes request.
		/// </summary>
		public void Initialize(TsCHdaServer server, TsCHdaItemAttributeCollection results)
		{
			mServer_ = server;

			attributesLv_.Items.Clear();

			if (results != null)
			{
				foreach (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection result in results)
				{
					AddListItem(result);
				}
				
				AdjustColumns();
			}
		}	

		/// <summary>
		/// Displays the values of an attribute.
		/// </summary>
		public void Initialize(TsCHdaServer server, Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection values)
		{
			mServer_ = server;

			attributesLv_.Items.Clear();

			if (values != null)
			{
				foreach (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue value in values)
				{
					AddListItem(value);
				}

				AdjustColumns();
			}
		}	

		/// <summary>
		/// Displays the values of an attribute.
		/// </summary>
		public void Initialize(TsCHdaServer server, int attributeIDs, TsCHdaResultCollection results)
		{
			mServer_ = server;

			attributesLv_.Items.Clear();

			if (results != null)
			{
				foreach (TsCHdaResult result in results)
				{
					AddListItem(result);
				}

				AdjustColumns();
			}
		}	

		/// <summary>
		/// Returns the set of checked attributes.
		/// </summary>
		public Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute[] GetAttributes()
		{
			ArrayList attributes = new ArrayList();

			foreach (ListViewItem listItem in attributesLv_.CheckedItems)
			{
				if (typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute).IsInstanceOfType(listItem.Tag))
				{
					attributes.Add(listItem.Tag);
				}
			}

			return (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute[])attributes.ToArray(typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute));
		}
		#endregion

		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int Name         = 0;
		private const int DataType    = 1;
		private const int Description  = 2;
		private const int NumValues   = 3;
		private const int Timestamp    = 4;
		private const int Value        = 5;
		private const int Result       = 6;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Name",
			"Data Type",
			"Description",
			"Count",
			"Timestamp",
			"Value",
			"Result"
		};
		
		/// <summary>
		/// The server containing the attributes to be displayed.
		/// </summary>
		private TsCHdaServer mServer_ = null;

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
		private object GetFieldValue(object attribute, int fieldId)
		{
			// display result code.
			if (typeof(IOpcResult).IsInstanceOfType(attribute))
			{
				switch (fieldId)
				{								
					case Result: { return ((Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection)attribute).Result; }
				}
			}

			// displaying attribute descriptions. 
			if (typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute).IsInstanceOfType(attribute))
			{
				if (attributesLv_.CheckBoxes)
				{
					switch (fieldId)
					{
						case Name: { return ((Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute)attribute).Name; }
					}
				}
				else
				{
					switch (fieldId)
					{
						case Name:        { return ((Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute)attribute).Name;        }
						case DataType:   { return ((Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute)attribute).DataType;    }
						case Description: { return ((Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute)attribute).Description; }
					}
				}
			}

			// displaying attribute results. 
			if (typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection).IsInstanceOfType(attribute))
			{
				Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection collection = (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection)attribute;

				switch (fieldId)
				{					
					case Name:        
					{ 
						Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute description =	mServer_.Attributes.Find(collection.AttributeID);

						if (description != null)
						{
							return description.Name; 
						}

						return null;
					}

					case NumValues:
					{
						if (collection.Count > 1)
						{
							return collection.Count;
						}

						return null;
					}
                        
					case Value:      
					{ 
						if (collection.Count == 1)
						{
							return collection[0].Value;
						}

						return null;
					}
				}
			}

			// displaying attribute values. 
			if (typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue).IsInstanceOfType(attribute))
			{
				switch (fieldId)
				{					
					case Timestamp: { return ((Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue)attribute).Timestamp; }
					case Value:     { return ((Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValue)attribute).Value;     }
				}
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(object attribute)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_EXPLODING_BOX);

			// add empty columns.
			while (listItem.SubItems.Count < columnNames_.Length) listItem.SubItems.Add("");
			
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(attribute, ii));
			}

			// save object as list view item tag.
			listItem.Tag = attribute;
		
			// add to list view.
			attributesLv_.Items.Add(listItem);
		}
		#endregion

		/// <summary>
		/// Updates the state of the popup menu items based on the current selection.
		/// </summary>
		private void AttributesLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			viewMi_.Enabled = false;

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
		}

		/// <summary>
		/// Displays a dialog with more detailed view of the current selection.
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

				ListViewItem selection = attributesLv_.SelectedItems[0];

				// show values if an attribute collection.
				if (typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection).IsInstanceOfType(selection.Tag))
				{
					new AttributesViewDlg().ShowDialog(mServer_, (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttributeValueCollection)selection.Tag);
				}

				// show description of attribute.
				else if(typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute).IsInstanceOfType(selection.Tag))
				{
					Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute attribute = (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute)selection.Tag;
					MessageBox.Show(attribute.Description, attribute.Name, MessageBoxButtons.OK);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}

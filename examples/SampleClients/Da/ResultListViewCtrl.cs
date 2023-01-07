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

using Technosoftware.DaAeHdaClient;
using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Cpx;
using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da
{
    /// <summary>
    /// A control used to display a set of results.
    /// </summary>
    public class ResultListViewCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView itemListLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem removeMi_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.ToolStripMenuItem copyMi_;
		private System.Windows.Forms.ToolStripMenuItem showErrorTextMi_;
		private System.Windows.Forms.ToolStripMenuItem viewMi_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ResultListViewCtrl()
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
			viewMi_ = new System.Windows.Forms.ToolStripMenuItem();
			showErrorTextMi_ = new System.Windows.Forms.ToolStripMenuItem();
			copyMi_ = new System.Windows.Forms.ToolStripMenuItem();
			editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			removeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			SuspendLayout();
			// 
			// ItemListLV
			// 
			itemListLv_.ContextMenuStrip = popupMenu_;
			itemListLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			itemListLv_.FullRowSelect = true;
			itemListLv_.Location = new System.Drawing.Point(0, 0);
			itemListLv_.MultiSelect = false;
			itemListLv_.Name = "itemListLv_";
			itemListLv_.Size = new System.Drawing.Size(432, 272);
			itemListLv_.TabIndex = 0;
			itemListLv_.View = System.Windows.Forms.View.Details;
			itemListLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(ItemListLV_MouseDown);
			itemListLv_.DoubleClick += new System.EventHandler(ViewMI_Click);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  viewMi_,
																					  showErrorTextMi_});
			// 
			// ViewMI
			// 
			viewMi_.ImageIndex = 0;
			viewMi_.Text = "&View...";
			viewMi_.Click += new System.EventHandler(ViewMI_Click);
			// 
			// ShowErrorTextMI
			// 
			showErrorTextMi_.ImageIndex = 1;
			showErrorTextMi_.Text = "&Show Error Text";
			showErrorTextMi_.Click += new System.EventHandler(ShowErrorTextMI_Click);
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
			// ResultListViewCtrl
			// 
			AllowDrop = true;
			Controls.Add(itemListLv_);
			Name = "ResultListViewCtrl";
			Size = new System.Drawing.Size(432, 272);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ItemName        = 0;
		private const int ItemPath        = 1;
		private const int Value            = 2;
		private const int DataType        = 3;
		private const int QualityBits     = 4;
		private const int LimitBits       = 5;
		private const int VendorBits      = 6;
		private const int Timestamp        = 7;
		private const int Deadband         = 8;
		private const int SamplingRate    = 9;
		private const int EnableBuffering = 10;
		private const int Error            = 11;
		private const int ClientHandle    = 12;
		private const int ServerHandle    = 13;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Item Name",
			"Item Path",
			"Value",
			"Data Type",
			"Quality Bits",
			"Limit Bits",
			"Vendor Bits",
			"Timestamp",
			"Deadband",
			"Sampling Rate",
			"Buffering",
			"Result",
			"Client Handle",
			"Server Handle"
		};

		/// <summary>
		/// The server used to fetch localized texts for error messages.
		/// </summary>
		public TsCDaServer MServer = null;

		/// <summary>
		/// The locale to use when fetching localized texts for the error mesasges.
		/// </summary>
		public string MLocale = null;

		/// <summary>
		/// The set of values displayed in the the control.
		/// </summary>
		public Hashtable MValues = new Hashtable();

		/// <summary>
		/// A table of localize error texts indexed by result id.
		/// </summary>
		public Hashtable MErrors = new Hashtable();

		/// <summary>
		/// Initializes the control with a set of identified results.
		/// </summary>
		public void Initialize(TsCDaServer server, string locale, OpcItemResult[] results)
		{
			MServer = server;
			MLocale = locale;

			MErrors.Clear();

			itemListLv_.Items.Clear();

			// check if there is nothing to do.
			if (results == null || results.Length == 0) return;

			foreach (OpcItemResult result in results)
			{
				AddResult(result);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}

		/// <summary>
		/// Initializes the control with a set of item results.
		/// </summary>
		public void Initialize(TsCDaServer server, string locale, TsCDaItemResult[] results)
		{
			MServer = server;
			MLocale = locale;

			MErrors.Clear();

			itemListLv_.Items.Clear();

			// check if there is nothing to do.
			if (results == null || results.Length == 0) return;

			foreach (TsCDaItemResult result in results)
			{
				AddResult(result);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}

		/// <summary>
		/// Initializes the control with a set of item value results.
		/// </summary>
		public void Initialize(TsCDaServer server, string locale, TsCDaItemValueResult[] results)
		{
			MServer = server;
			MLocale = locale;

			MErrors.Clear();

			itemListLv_.Items.Clear();

			// check if there is nothing to do.
			if (results == null || results.Length == 0) return;

			foreach (TsCDaItemValueResult result in results)
			{
				AddResult(result);
			}
			
			// adjust the list view columns to fit the data.
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
				// always show the item id  and value column.
				if (ii == ItemName)
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

			/*
			// get total width
			int width = 0;

			foreach (ColumnHeader column in  ItemListLV.Columns) width += column.Width;

			// expand parent form to display all columns.
			if (width > ItemListLV.Width)
			{
				width = ParentForm.Width + (width - ItemListLV.Width) + 4; 
				ParentForm.Width = (width > 1024)?1024:width;
			}
			*/
		}

		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(object item, int fieldId)
		{
			if (item.GetType() == typeof(OpcItemResult)) return GetFieldValue((OpcItemResult)item, fieldId);
			if (item.GetType() == typeof(TsCDaItemResult))       return GetFieldValue((TsCDaItemResult)item, fieldId);
			if (item.GetType() == typeof(TsCDaItemValueResult))  return GetFieldValue((TsCDaItemValueResult)item, fieldId);

			return null;
		}
	
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(OpcItemResult item, int fieldId)
		{
			switch (fieldId)
			{
				case ItemName:     { return item.ItemName; }
				case ItemPath:     { return item.ItemPath; }
				// case CLIENT_HANDLE: { return Technosoftware.DaAeHdaClient.Utilities.Convert.ToString(item.ClientHandle); }
				// case SERVER_HANDLE: { return Technosoftware.DaAeHdaClient.Utilities.Convert.ToString(item.ServerHandle); }
				case Error:         { return GetErrorText(item.Result); }
			}

			return null;
		}

		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCDaItemResult item, int fieldId)
		{
			object fieldValue = null;

			switch (fieldId)
			{
				case ItemName:        { return item.ItemName; }
				case ItemPath:        { return item.ItemPath; }
				// case CLIENT_HANDLE:    { return Technosoftware.DaAeHdaClient.Utilities.Convert.ToString(item.ClientHandle); }
				// case SERVER_HANDLE:    { return Technosoftware.DaAeHdaClient.Utilities.Convert.ToString(item.ServerHandle); }
				case Deadband:         { return (item.DeadbandSpecified)?item.Deadband:fieldValue; }
				case SamplingRate:	   { return (item.SamplingRateSpecified)?item.SamplingRate:fieldValue; }
				case EnableBuffering: { return (item.EnableBufferingSpecified)?item.EnableBuffering:fieldValue; }
				case Error:            { return GetErrorText(item.Result); }
			}

			return null;
		}


		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCDaItemValueResult item, int fieldId)
		{
			object fieldValue = null;

			switch (fieldId)
			{

				case ItemName:     { return item.ItemName; }
				case ItemPath:     { return item.ItemPath; }
				// case CLIENT_HANDLE: { return Technosoftware.DaAeHdaClient.Utilities.Convert.ToString(item.ClientHandle); }
				// case SERVER_HANDLE: { return Technosoftware.DaAeHdaClient.Utilities.Convert.ToString(item.ServerHandle); }
				case Value:         { return Technosoftware.DaAeHdaClient.OpcConvert.ToString(item.Value); }
				case DataType:	    { return (item.Value != null)?item.Value.GetType():fieldValue; }
				case QualityBits:  { return (item.QualitySpecified && item.Quality.QualityBits != TsDaQualityBits.Good)?item.Quality.QualityBits:fieldValue; }
				case LimitBits:    { return (item.QualitySpecified && item.Quality.LimitBits != TsDaLimitBits.None)?item.Quality.LimitBits:fieldValue; }
				case VendorBits:   { return (item.QualitySpecified && item.Quality.VendorBits != 0)?item.Quality.VendorBits:fieldValue; }
				case Timestamp:     { return (item.TimestampSpecified)?item.Timestamp:fieldValue; }
				case Error:         { return GetErrorText(item.Result); }
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddResult(object item)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem((string)GetFieldValue(item, ItemName), Resources.IMAGE_YELLOW_SCROLL);

			// add appropriate sub-items.
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, ItemPath)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, Value)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, DataType)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, QualityBits)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, LimitBits)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, VendorBits)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, Timestamp)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, Deadband)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, SamplingRate)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, EnableBuffering)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, Error)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, ClientHandle)));
			listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, ServerHandle)));

			// save item object as list view item tag.
			listItem.Tag = item;
		
			// add to list view.
			itemListLv_.Items.Add(listItem);
		}

		/// <summary>
		/// Lookups the error text for the specified error id.
		/// </summary>
		private string GetErrorText(OpcResult resultId)
		{
			if (showErrorTextMi_.Checked)
			{
				// display nothing for ok results.
				if (resultId == OpcResult.S_OK) return "";
	
				// check if text has already been fetched.
				string errorText = (string)MErrors[resultId];

				// fetch the error text from the server.
				if (errorText == null)
				{
					try 
					{
						errorText = MServer.GetErrorText(MLocale, resultId);
						MErrors[resultId] = errorText;
					}
					catch
					{
						errorText = null;
					}
				}

				// return the result;
				return (errorText != null)?errorText:"";
			}

			// return the result id as a string.
			return resultId.ToString();
		}

		/// <summary>
		/// Shows a detailed view for array values.
		/// </summary>
		private void ViewMI_Click(object sender, System.EventArgs e)
		{
			if (itemListLv_.SelectedItems.Count > 0)
			{
				object tag = itemListLv_.SelectedItems[0].Tag;

				if (tag != null && tag.GetType() == typeof(TsCDaItemValueResult))
				{
					TsCDaItemValueResult item = (TsCDaItemValueResult)tag;

					if (item.Value != null)
					{
						TsCCpxComplexItem complexItem = TsCCpxComplexTypeCache.GetComplexItem(item);

						if (complexItem != null)
						{
							new EditComplexValueDlg().ShowDialog(complexItem, item.Value, true, true);
						}

						else if (item.Value.GetType().IsArray)
						{
							new EditArrayDlg().ShowDialog(item.Value, true);
						}
					}
				}
			}
		}

		/// <summary>
		/// Enables/disables items in the popup menu before it is displayed.
		/// </summary>
		private void ItemListLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// disable everything.
			viewMi_.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = itemListLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked node.
			clickedItem.Selected = true;

			if (itemListLv_.SelectedItems.Count == 1)
			{
				viewMi_.Enabled = (clickedItem.Tag != null && clickedItem.Tag.GetType() == typeof(TsCDaItemValueResult));
			}
		}

		/// <summary>
		/// Toggles the state of the show error text flag.
		/// </summary>
		private void ShowErrorTextMI_Click(object sender, System.EventArgs e)
		{
			// toggle state.
			showErrorTextMi_.Checked = !showErrorTextMi_.Checked;

			// update list items.
			foreach (ListViewItem listItem in itemListLv_.Items)
			{
				if (listItem.Tag == null) { continue; }

				string errorText = null;

				if (listItem.Tag.GetType() == typeof(OpcItemResult))
				{
					errorText = GetErrorText(((OpcItemResult)listItem.Tag).Result);
				}

				else if (listItem.Tag.GetType() == typeof(TsCDaItemResult))
				{
					errorText = GetErrorText(((TsCDaItemResult)listItem.Tag).Result);
				}

				else if (listItem.Tag.GetType() == typeof(TsCDaItemValueResult))
				{
					errorText = GetErrorText(((TsCDaItemValueResult)listItem.Tag).Result);
				}

			    listItem.SubItems[listItem.SubItems.Count-3].Text = errorText;
			}

			// adjust column widths.
			AdjustColumns();
		}
	}
}

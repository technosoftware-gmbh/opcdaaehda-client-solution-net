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

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Item
{
	/// <summary>
	/// A control used to display a list of item properties.
	/// </summary>
	public class ResultListCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView itemsLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem viewMi_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ResultListCtrl()
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
			viewMi_ = new System.Windows.Forms.ToolStripMenuItem();
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
			itemsLv_.DoubleClick += new System.EventHandler(ViewMI_Click);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  viewMi_});
			// 
			// ViewMI
			// 
			viewMi_.ImageIndex = 0;
			viewMi_.Text = "View...";
			viewMi_.Click += new System.EventHandler(ViewMI_Click);
			// 
			// ResultListCtrl
			// 
			AllowDrop = true;
			Controls.Add(itemsLv_);
			Name = "ResultListCtrl";
			Size = new System.Drawing.Size(432, 272);
			ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Initializes the control with a set of results.
		/// </summary>
		public void Initialize(TsCHdaServer server, IOpcResult[] results)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;

			itemsLv_.Items.Clear();

			// check if there is nothing to do.
			if (results == null) return;

			foreach (IOpcResult result in results)
			{
				AddListItem(result);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}
		
		/// <summary>
		/// Initializes the control with a set of item value collections.
		/// </summary>
		public void Initialize(TsCHdaServer server, IList[] values, TsCHdaResultCollection[] results)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;
			
			itemsLv_.Items.Clear();

			// check if there is nothing to do.
			if (values == null || results == null) return;

			// collapse the array of collections into indiviual items in the list.
			for (int ii = 0; ii < results.Length; ii++)
			{
				for (int jj = 0; jj < results[ii].Count; jj++)
				{
					DateTime timestamp = DateTime.MinValue;

					if (ii < values.Length && jj < values[ii].Count)
					{
						if (typeof(TsCHdaItemValue).IsInstanceOfType(values[ii][jj]))
						{
							timestamp = ((TsCHdaItemValue)values[ii][jj]).Timestamp;
						}
						else if (typeof(TsCHdaAnnotationValue).IsInstanceOfType(values[ii][jj]))
						{
							timestamp = ((TsCHdaAnnotationValue)values[ii][jj]).Timestamp;
						}
					}

					AddListItem(new ItemTimeResult(results[ii], timestamp, results[ii][jj]));
				}
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}	

		/// <summary>
		/// Initializes the control with a set of attribute ids.
		/// </summary>
		public void Initialize(TsCHdaServer server, int[] attributeIDs, TsCHdaResultCollection results)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;
			
			itemsLv_.Items.Clear();

			// check if there is nothing to do.
			if (attributeIDs == null || results == null) return;

			// collapse the array of collections into indiviual items in the list.
			for (int ii = 0; ii < attributeIDs.Length; ii++)
			{
				if (ii < results.Count)
				{
					AddListItem(new AttributeResult(results, attributeIDs[ii], results[ii]));
				}
			}

			// adjust the list view columns to fit the data.
			AdjustColumns();
		}

		/// <summary>
		/// Initializes the control with a set of item value collections.
		/// </summary>
		public void Initialize(
			TsCHdaServer             server,
            TsCHdaItemTimeCollection times,
			TsCHdaResultCollection[] results)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;
			
			itemsLv_.Items.Clear();

			// check if there is nothing to do.
			if (results == null)
			{
				return;
			}

			// collapse the array of collections into indiviual items in the list.
			if (results.Length > 0)
			{
				for (int ii = 0; ii < results.Length; ii++)
				{
					for (int jj = 0; jj < results[ii].Count; jj++)
					{
						if (times == null)
						{
							AddListItem(new ItemTimeResult(results[ii], DateTime.MinValue, results[ii][jj]));
						}
						else if (jj < times.Count)
						{
							AddListItem(new ItemTimeResult(results[ii], times[jj], results[ii][jj]));
						}
					}
				}
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}	
		#endregion

		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int Itemid     = 0;
		private const int Timestamp  = 1;
		private const int Aggregate  = 2;
		private const int Attribute  = 3;
		private const int NumValues = 4;
		private const int Result     = 5;
 
		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Item ID",
			"Timestamp",
			"Aggregate",
			"Attribute",
			"Num Values",
			"Result"
		};

		/// <summary>
		/// An class used to associate item value results with the original item value/timestamp.
		/// </summary>
		private class ItemTimeResult : OpcItem, IOpcResult
		{
			public ItemTimeResult(OpcItem item, DateTime timestamp, IOpcResult result) : base(item)
			{
				Timestamp      = timestamp;
				Result       = result.Result;
				DiagnosticInfo = result.DiagnosticInfo;
			}

			/// <summary>
			/// The timestamp associated with the value.
			/// </summary>
			public DateTime Timestamp
			{
				get { return mTimestamp_;  } 
				set { mTimestamp_ = value; }
			}

			#region IResult Members
			/// <summary>
			/// The error id for the result of an operation on an item.
			/// </summary>
			public OpcResult Result 
			{
				get { return mResultId_;  }
				set { mResultId_ = value; }
			}	

			/// <summary>
			/// Vendor specific diagnostic information (not the localized error text).
			/// </summary>
			public string DiagnosticInfo
			{
				get { return mDiagnosticInfo_;  }
				set { mDiagnosticInfo_ = value; }
			}
			#endregion

			#region Private Members
			private DateTime mTimestamp_ = DateTime.MinValue;
			private OpcResult mResultId_ = OpcResult.S_OK;
			private string mDiagnosticInfo_ = null;
			#endregion
		}

		/// <summary>
		/// An class used to associate an attribute and a result code.
		/// </summary>
		private class AttributeResult : OpcItem, IOpcResult
		{
			public AttributeResult(OpcItem item, int attributeId, IOpcResult result) : base(item)
			{
				AttributeId    = attributeId;
				Result       = result.Result;
				DiagnosticInfo = result.DiagnosticInfo;
			}

			/// <summary>
			/// The timestamp associated with the value.
			/// </summary>
			public int AttributeId
			{
				get { return mAttributeId_;  } 
				set { mAttributeId_ = value; }
			}

			#region IResult Members
			/// <summary>
			/// The error id for the result of an operation on an item.
			/// </summary>
			public OpcResult Result 
			{
				get { return mResultId_;  }
				set { mResultId_ = value; }
			}	

			/// <summary>
			/// Vendor specific diagnostic information (not the localized error text).
			/// </summary>
			public string DiagnosticInfo
			{
				get { return mDiagnosticInfo_;  }
				set { mDiagnosticInfo_ = value; }
			}
			#endregion

			#region Private Members
			private int mAttributeId_ = -1;
			private OpcResult mResultId_ = OpcResult.S_OK;
			private string mDiagnosticInfo_ = null;
			#endregion
		}
		
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

			// attribute.
			if (typeof(AttributeResult).IsInstanceOfType(item))
			{
				if (fieldId == Attribute)
				{
					return mServer_.Attributes.Find(((AttributeResult)item).AttributeId);
				}
			}

			// item.
			if (typeof(TsCHdaItem).IsInstanceOfType(item))
			{
				if (fieldId == Aggregate)
				{
					return mServer_.Aggregates.Find(((TsCHdaItem)item).Aggregate);
				}
			}
				
			// item value collection.
			if (typeof(TsCHdaItem).IsInstanceOfType(item))
			{
				if (fieldId == NumValues)
				{
					return ((ICollection)item).Count; 
				}
			}

			// item time result.
			if (typeof(ItemTimeResult).IsInstanceOfType(item))
			{
				if (fieldId == Timestamp)
				{
					return ((ItemTimeResult)item).Timestamp; 
				}
			}

			// result.
			if (typeof(IOpcResult).IsInstanceOfType(item))
			{
				if (fieldId == Result)
				{
					return ((IOpcResult)item).Result; 
				}
			}

			// invalid field id or type.
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
			
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, ii));
			}

			// save object as list view item tag.
			listItem.Tag = item;
		
			// add to list view.
			itemsLv_.Items.Add(listItem);
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
				if (itemsLv_.SelectedItems.Count != 1)
				{
					return;
				}	

				object item = itemsLv_.SelectedItems[0].Tag;

				if (typeof(TsCHdaItemValueCollection).IsInstanceOfType(item))
				{
					new ItemValuesDlg().ShowDialog(mServer_, (TsCHdaItemValueCollection)item, true); 
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
			viewMi_.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = itemsLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (itemsLv_.SelectedItems.Count > 0)
			{
				viewMi_.Enabled = true;
			}
		}
	}
}

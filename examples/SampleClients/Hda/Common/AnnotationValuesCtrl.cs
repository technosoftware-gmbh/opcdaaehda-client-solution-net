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
using SampleClients.Hda.Test;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Common
{
    /// <summary>
    /// Summary description for ReadParametersCtrl.
    /// </summary>
    public class AnnotationValuesCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView valuesLv_;
		private System.Windows.Forms.Panel mainPn_;
		private SampleClients.ScPl.Windows.PlotSurface2D plotCtrl_;
		private System.Windows.Forms.Panel plotPn_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem addMi_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.ToolStripMenuItem removeMi_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		private System.Windows.Forms.ToolStripMenuItem graphMi_;
		private System.Windows.Forms.ToolStripMenuItem dataMi_;
		private System.Windows.Forms.ToolStripMenuItem copyMi_;
		private System.Windows.Forms.ToolStripMenuItem separator02_;
		private System.Windows.Forms.ToolStripMenuItem importValuesMi_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public AnnotationValuesCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			valuesLv_.SmallImageList = Resources.Instance.ImageList;
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
			valuesLv_ = new System.Windows.Forms.ListView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			graphMi_ = new System.Windows.Forms.ToolStripMenuItem();
			dataMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			addMi_ = new System.Windows.Forms.ToolStripMenuItem();
			copyMi_ = new System.Windows.Forms.ToolStripMenuItem();
			editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			removeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator02_ = new System.Windows.Forms.ToolStripMenuItem();
			importValuesMi_ = new System.Windows.Forms.ToolStripMenuItem();
			mainPn_ = new System.Windows.Forms.Panel();
			plotPn_ = new System.Windows.Forms.Panel();
			plotCtrl_ = new ScPl.Windows.PlotSurface2D();
			mainPn_.SuspendLayout();
			plotPn_.SuspendLayout();
			SuspendLayout();
			// 
			// ValuesLV
			// 
			valuesLv_.ContextMenuStrip = popupMenu_;
			valuesLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			valuesLv_.FullRowSelect = true;
			valuesLv_.Location = new System.Drawing.Point(0, 0);
			valuesLv_.Name = "valuesLv_";
			valuesLv_.Size = new System.Drawing.Size(544, 360);
			valuesLv_.TabIndex = 1;
			valuesLv_.View = System.Windows.Forms.View.Details;
			valuesLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(ValuesLV_MouseDown);
			valuesLv_.DoubleClick += new System.EventHandler(EditMI_Click);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  graphMi_,
																					  dataMi_,
																					  separator01_,
																					  addMi_,
																					  copyMi_,
																					  editMi_,
																					  removeMi_,
																					  separator02_,
																					  importValuesMi_});
			// 
			// GraphMI
			// 
			graphMi_.ImageIndex = 0;
			//this.GraphMI.RadioCheck = true;
			graphMi_.Text = "Graph";
			// 
			// DataMI
			// 
			dataMi_.Checked = true;
			dataMi_.ImageIndex = 1;
			//this.DataMI.RadioCheck = true;
			dataMi_.Text = "Data";
			// 
			// Separator01
			// 
			separator01_.ImageIndex = 2;
			separator01_.Text = "-";
			// 
			// AddMI
			// 
			addMi_.ImageIndex = 3;
			addMi_.Text = "Add...";
			addMi_.Click += new System.EventHandler(AddMI_Click);
			// 
			// CopyMI
			// 
			copyMi_.ImageIndex = 4;
			copyMi_.Text = "Copy...";
			copyMi_.Click += new System.EventHandler(CopyMI_Click);
			// 
			// EditMI
			// 
			editMi_.ImageIndex = 5;
			editMi_.Text = "Edit...";
			editMi_.Click += new System.EventHandler(EditMI_Click);
			// 
			// RemoveMI
			// 
			removeMi_.ImageIndex = 6;
			removeMi_.Text = "Remove";
			removeMi_.Click += new System.EventHandler(RemoveMI_Click);
			// 
			// Separator02
			// 
			separator02_.ImageIndex = 7;
			separator02_.Text = "-";
			// 
			// ImportValuesMI
			// 
			importValuesMi_.ImageIndex = 8;
			importValuesMi_.Text = "Import Values...";
			importValuesMi_.Click += new System.EventHandler(ImportValuesMI_Click);
			// 
			// MainPN
			// 
			mainPn_.Controls.Add(valuesLv_);
			mainPn_.Controls.Add(plotPn_);
			mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			mainPn_.Location = new System.Drawing.Point(0, 0);
			mainPn_.Name = "mainPn_";
			mainPn_.Size = new System.Drawing.Size(544, 360);
			mainPn_.TabIndex = 2;
			// 
			// PlotPN
			// 
			plotPn_.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			plotPn_.Controls.Add(plotCtrl_);
			plotPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			plotPn_.Location = new System.Drawing.Point(0, 0);
			plotPn_.Name = "plotPn_";
			plotPn_.Size = new System.Drawing.Size(544, 360);
			plotPn_.TabIndex = 3;
			// 
			// PlotCTRL
			// 
			plotCtrl_.AllowSelection = false;
			plotCtrl_.BackColor = System.Drawing.SystemColors.ControlLightLight;
			plotCtrl_.ContextMenuStrip = popupMenu_;
			plotCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			plotCtrl_.HorizontalEdgeLegendPlacement = ScPl.Legend.Placement.Inside;
			plotCtrl_.LegendBorderStyle = ScPl.Legend.BorderType.Shadow;
			plotCtrl_.LegendXOffset = 10F;
			plotCtrl_.LegendYOffset = 1F;
			plotCtrl_.Location = new System.Drawing.Point(0, 0);
			plotCtrl_.Name = "plotCtrl_";
			plotCtrl_.Padding = 10;
			plotCtrl_.PlotBackColor = System.Drawing.Color.White;
			plotCtrl_.ShowLegend = false;
			plotCtrl_.Size = new System.Drawing.Size(540, 356);
			plotCtrl_.TabIndex = 2;
			plotCtrl_.Title = "";
			plotCtrl_.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			plotCtrl_.VerticalEdgeLegendPlacement = ScPl.Legend.Placement.Outside;
			plotCtrl_.XAxis1 = null;
			plotCtrl_.XAxis2 = null;
			plotCtrl_.YAxis1 = null;
			plotCtrl_.YAxis2 = null;
			// 
			// AnnotationValuesCtrl
			// 
			Controls.Add(mainPn_);
			Name = "AnnotationValuesCtrl";
			Size = new System.Drawing.Size(544, 360);
			mainPn_.ResumeLayout(false);
			plotPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Whether the item values can be changed. 
		/// </summary>
		public bool ReadOnly
		{
			get { return mReadOnly_;  }
			set { mReadOnly_ = value; }
		}

		/// <summary>
		/// Initializes the control with a set of items.
		/// </summary>
		public void Initialize(TsCHdaServer server, TsCHdaAnnotationValueCollection values)
		{
			mServer_ = server;
			mItem_   = values;

			valuesLv_.Items.Clear();

			if (values != null)
			{
				// add item values to list.
				foreach (TsCHdaAnnotationValue value in values)
				{
					AddListItem(value, -1);
				}

				// adjust the list view columns to fit the data.
				AdjustColumns();
			}
		}	

		/// <summary>
		/// Returns the set of item values stored in the list control.
		/// </summary>
		public TsCHdaAnnotationValueCollection GetValues()
		{
			TsCHdaAnnotationValueCollection values = new TsCHdaAnnotationValueCollection();

			foreach (ListViewItem listItem in valuesLv_.Items)
			{
				if (typeof(TsCHdaAnnotationValue).IsInstanceOfType(listItem.Tag))
				{
					values.Add(listItem.Tag);
				}
			}

			return values;
		}
		#endregion

		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int Timestamp     = 0;
		private const int Value         = 1;
		private const int CreationTime = 2;
		private const int User          = 3;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Timestamp",
			"Annotation",
			"Created",
			"User"
		};
		
		/// <summary>
		/// The historian database server.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// The current item id.
		/// </summary>
		private OpcItem mItem_ = null;

		/// <summary>
		/// Whether the item values can be changed. 
		/// </summary>
		private bool mReadOnly_ = false;

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			valuesLv_.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				valuesLv_.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < valuesLv_.Columns.Count; ii++)
			{
				// always show the timestamp column.
				if (ii == Timestamp)
				{
					valuesLv_.Columns[ii].Width = -2;
					continue;
				}

				// the value column has a default width of 200.
				if (ii == Value)
				{
					if (valuesLv_.Columns[ii].Width < 200)
					{
						valuesLv_.Columns[ii].Width = 200;
					}

					continue;
				}

				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in valuesLv_.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						valuesLv_.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) valuesLv_.Columns[ii].Width = 0;
			}
		}
		
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCHdaAnnotationValue value, int fieldId)
		{
			if (value != null)
			{
				switch (fieldId)
				{
					case Timestamp:     { return value.Timestamp;    }
					case Value:         { return value.Annotation;   }
					case CreationTime: { return value.CreationTime; }
					case User:          { return value.User;         }
				}
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(TsCHdaAnnotationValue value, int index)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_YELLOW_SCROLL);

			// add empty columns.
			while (listItem.SubItems.Count < columnNames_.Length) listItem.SubItems.Add("");
			
			// update columns.
			UpdateListItem(listItem, value);
	
			// add to list view.
			if (index < 0)
			{
				valuesLv_.Items.Add(listItem);
			}
			else
			{
				valuesLv_.Items.Insert(index, listItem);
			}
		}

		/// <summary>
		/// Updates an item in the list view.
		/// </summary>
		private void UpdateListItem(ListViewItem listItem, TsCHdaAnnotationValue value)
		{
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(value, ii));
			}

			// save object as list view item tag.
			listItem.Tag = value;
		}
		#endregion
		
		/// <summary>
		/// Adds a new item value.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check control state.
				if (ReadOnly)
				{
					return;
				}

				// create new item value.
				TsCHdaAnnotationValue value = new TsCHdaAnnotationValue();

				value.Annotation   = null;
				value.Timestamp    = RunTestDlg.Basetime;
				value.CreationTime = DateTime.MinValue;
				value.User         = null;

				// prompt user to edit item value.
				value = new AnnotationValueEditDlg().ShowDialog(value);

				if (value == null)
				{
					return;
				}

				// get the current selection.
				int index = -1;

				if (valuesLv_.SelectedIndices.Count > 0)
				{
					index = valuesLv_.SelectedIndices[valuesLv_.SelectedIndices.Count-1];
				}

				// update display.
				AddListItem(value, index);

				// adjust columns
				AdjustColumns();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Adds a new item value by copying an existing one.
		/// </summary>
		private void CopyMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ReadOnly || valuesLv_.SelectedItems.Count != 1)
				{
					return;
				}

				TsCHdaAnnotationValue value = (TsCHdaAnnotationValue)valuesLv_.SelectedItems[0].Tag;

				// create new item value.
				TsCHdaAnnotationValue copy = new AnnotationValueEditDlg().ShowDialog((TsCHdaAnnotationValue)value.Clone());

				// prompt user to edit item value.
				if (copy == null)
				{
					return;
				}
				
				// update display.
				AddListItem(copy, valuesLv_.SelectedIndices[0]);

				// adjust columns
				AdjustColumns();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Edits the parameters of s item value.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ReadOnly || valuesLv_.SelectedItems.Count != 1)
				{
					return;
				}

				// create new item value.
				TsCHdaAnnotationValue value = new AnnotationValueEditDlg().ShowDialog((TsCHdaAnnotationValue)valuesLv_.SelectedItems[0].Tag);

				// prompt user to edit item value.
				if (value == null)
				{
					return;
				}
				
				// update display.
				UpdateListItem(valuesLv_.SelectedItems[0], value);
				
				// adjust columns
				AdjustColumns();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Deletes am existing item value.
		/// </summary>
		private void RemoveMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ReadOnly || valuesLv_.SelectedItems.Count == 0)
				{
					return;
				}
				
				// update display.
				ArrayList items = new ArrayList();

				foreach (ListViewItem listItem in valuesLv_.SelectedItems)
				{
					items.Add(listItem);
				}

				foreach (ListViewItem listItem in items)
				{
					listItem.Remove();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Imports item values from another item.
		/// </summary>
		private void ImportValuesMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ReadOnly)
				{
					return;
				}

				// prompt user to select values from another item.
				TsCHdaAnnotationValueCollection values = new ReadAnnotationsDlg().ShowDialog(mServer_, true);

				if (values == null)
				{
					return;
				}

				// get the current selection.
				int index = 0;

				if (valuesLv_.SelectedIndices.Count > 0)
				{
					index = valuesLv_.SelectedIndices[valuesLv_.SelectedIndices.Count-1];
				}

				// add new values to list.
				foreach (TsCHdaAnnotationValue value in values)
				{
					AddListItem(value, index++);
				}				  

				// adjust columns
				AdjustColumns();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Updates the state of the menu buttons when the mouse is pressed.
		/// </summary>
		private void ValuesLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			addMi_.Enabled          = !ReadOnly;
			copyMi_.Enabled         = false;
			editMi_.Enabled         = false;
			removeMi_.Enabled       = false;
			importValuesMi_.Enabled = !ReadOnly;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = valuesLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (valuesLv_.SelectedItems.Count == 1)
			{			
				copyMi_.Enabled   = !ReadOnly;
				editMi_.Enabled   = !ReadOnly;
			}

			if (valuesLv_.SelectedItems.Count > 0)
			{			
				removeMi_.Enabled = !ReadOnly;
			}		
		}
	}
}

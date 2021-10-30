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
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SampleClients.Common;
using SampleClients.Hda.Edit;
using SampleClients.Hda.Trend;
using SampleClients.Hda.Test;

using scpl;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Da;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Item
{
    /// <summary>
    /// Summary description for ReadParametersCtrl.
    /// </summary>
    public class ItemValuesCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView valuesLv_;
		private System.Windows.Forms.Panel mainPn_;
		private scpl.Windows.PlotSurface2D plotCtrl_;
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

		public ItemValuesCtrl()
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
			this.valuesLv_ = new System.Windows.Forms.ListView();
			this.popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			this.graphMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.dataMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			this.addMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.copyMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.removeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.separator02_ = new System.Windows.Forms.ToolStripMenuItem();
			this.importValuesMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.mainPn_ = new System.Windows.Forms.Panel();
			this.plotPn_ = new System.Windows.Forms.Panel();
			this.plotCtrl_ = new scpl.Windows.PlotSurface2D();
			this.mainPn_.SuspendLayout();
			this.plotPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// ValuesLV
			// 
			this.valuesLv_.ContextMenuStrip = this.popupMenu_;
			this.valuesLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.valuesLv_.FullRowSelect = true;
			this.valuesLv_.Location = new System.Drawing.Point(0, 0);
			this.valuesLv_.Name = "valuesLv_";
			this.valuesLv_.Size = new System.Drawing.Size(544, 360);
			this.valuesLv_.TabIndex = 1;
			this.valuesLv_.View = System.Windows.Forms.View.Details;
			this.valuesLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ValuesLV_MouseDown);
			this.valuesLv_.DoubleClick += new System.EventHandler(this.EditMI_Click);
			// 
			// PopupMenu
			// 
			this.popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  this.graphMi_,
																					  this.dataMi_,
																					  this.separator01_,
																					  this.addMi_,
																					  this.copyMi_,
																					  this.editMi_,
																					  this.removeMi_,
																					  this.separator02_,
																					  this.importValuesMi_});
			// 
			// GraphMI
			// 
			this.graphMi_.ImageIndex = 0;
			//this.GraphMI.RadioCheck = true;
			this.graphMi_.Text = "Graph";
			this.graphMi_.Click += new System.EventHandler(this.GraphMI_Click);
			// 
			// DataMI
			// 
			this.dataMi_.Checked = true;
			this.dataMi_.ImageIndex = 1;
			//this.DataMI.RadioCheck = true;
			this.dataMi_.Text = "Data";
			this.dataMi_.Click += new System.EventHandler(this.DataMI_Click);
			// 
			// Separator01
			// 
			this.separator01_.ImageIndex = 2;
			this.separator01_.Text = "-";
			// 
			// AddMI
			// 
			this.addMi_.ImageIndex = 3;
			this.addMi_.Text = "Add...";
			this.addMi_.Click += new System.EventHandler(this.AddMI_Click);
			// 
			// CopyMI
			// 
			this.copyMi_.ImageIndex = 4;
			this.copyMi_.Text = "Copy...";
			this.copyMi_.Click += new System.EventHandler(this.CopyMI_Click);
			// 
			// EditMI
			// 
			this.editMi_.ImageIndex = 5;
			this.editMi_.Text = "Edit...";
			this.editMi_.Click += new System.EventHandler(this.EditMI_Click);
			// 
			// RemoveMI
			// 
			this.removeMi_.ImageIndex = 6;
			this.removeMi_.Text = "Remove";
			this.removeMi_.Click += new System.EventHandler(this.RemoveMI_Click);
			// 
			// Separator02
			// 
			this.separator02_.ImageIndex = 7;
			this.separator02_.Text = "-";
			// 
			// ImportValuesMI
			// 
			this.importValuesMi_.ImageIndex = 8;
			this.importValuesMi_.Text = "Import Values...";
			this.importValuesMi_.Click += new System.EventHandler(this.ImportValuesMI_Click);
			// 
			// MainPN
			// 
			this.mainPn_.Controls.Add(this.valuesLv_);
			this.mainPn_.Controls.Add(this.plotPn_);
			this.mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPn_.Location = new System.Drawing.Point(0, 0);
			this.mainPn_.Name = "mainPn_";
			this.mainPn_.Size = new System.Drawing.Size(544, 360);
			this.mainPn_.TabIndex = 2;
			// 
			// PlotPN
			// 
			this.plotPn_.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.plotPn_.Controls.Add(this.plotCtrl_);
			this.plotPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.plotPn_.Location = new System.Drawing.Point(0, 0);
			this.plotPn_.Name = "plotPn_";
			this.plotPn_.Size = new System.Drawing.Size(544, 360);
			this.plotPn_.TabIndex = 3;
			// 
			// PlotCTRL
			// 
			this.plotCtrl_.AllowSelection = false;
			this.plotCtrl_.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.plotCtrl_.ContextMenuStrip = this.popupMenu_;
			this.plotCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.plotCtrl_.HorizontalEdgeLegendPlacement = scpl.Legend.Placement.Inside;
			this.plotCtrl_.LegendBorderStyle = scpl.Legend.BorderType.Shadow;
			this.plotCtrl_.LegendXOffset = 10F;
			this.plotCtrl_.LegendYOffset = 1F;
			this.plotCtrl_.Location = new System.Drawing.Point(0, 0);
			this.plotCtrl_.Name = "plotCtrl_";
			this.plotCtrl_.Padding = 10;
			this.plotCtrl_.PlotBackColor = System.Drawing.Color.White;
			this.plotCtrl_.ShowLegend = false;
			this.plotCtrl_.Size = new System.Drawing.Size(540, 356);
			this.plotCtrl_.TabIndex = 2;
			this.plotCtrl_.Title = "";
			this.plotCtrl_.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.plotCtrl_.VerticalEdgeLegendPlacement = scpl.Legend.Placement.Outside;
			this.plotCtrl_.XAxis1 = null;
			this.plotCtrl_.XAxis2 = null;
			this.plotCtrl_.YAxis1 = null;
			this.plotCtrl_.YAxis2 = null;
			// 
			// ItemValuesCtrl
			// 
			this.Controls.Add(this.mainPn_);
			this.Name = "ItemValuesCtrl";
			this.Size = new System.Drawing.Size(544, 360);
			this.mainPn_.ResumeLayout(false);
			this.plotPn_.ResumeLayout(false);
			this.ResumeLayout(false);

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
		/// Whether the controls displays the results in a graph.
		/// </summary>
		public bool DisplayGraph
		{
			get 
			{
				return graphMi_.Checked;  
			}
			
			set 
			{
				graphMi_.Checked = value;  
				SetState(value);
			}
		}

		/// <summary>
		/// Initializes the control with a set of items.
		/// </summary>
		public void Initialize(TsCHdaServer server, TsCHdaItemValueCollection values)
		{
			mServer_ = server;
			mItem_   = values;

			valuesLv_.Items.Clear();
			plotCtrl_.Clear();

			if (values != null)
			{
				// add item values to list.
				foreach (TsCHdaItemValue value in values)
				{
					AddListItem(value, -1);
				}

				// adjust the list view columns to fit the data.
				AdjustColumns();
			}

			// update control state.
			SetState(graphMi_.Checked);
		}	

		/// <summary>
		/// Returns the set of item values stored in the list control.
		/// </summary>
		public TsCHdaItemValueCollection GetValues()
		{
			TsCHdaItemValueCollection values = new TsCHdaItemValueCollection();

			foreach (ListViewItem listItem in valuesLv_.Items)
			{
				if (typeof(TsCHdaItemValue).IsInstanceOfType(listItem.Tag))
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
		private const int Timestamp         = 0;
		private const int Value             = 1;
		private const int Quality           = 2;
		private const int HistorianQuality = 3;
		private const int ModificationTime = 4;
		private const int EditType         = 5;
		private const int User              = 6;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Timestamp",
			"Value",
			"Quality",
			"Historian Quality",
			"Modified",
			"Edit Type",
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
		/// Updates the enabled/visibility state of al contols.
		/// </summary>
		private void SetState(bool graph)
		{
			graphMi_.Checked  = graph;
			dataMi_.Checked   = !graph;
			valuesLv_.Visible = !graph;
			plotPn_.Visible   = graph;
			addMi_.Enabled    = !graph;
			editMi_.Enabled   = !graph;
			removeMi_.Enabled = !graph;

			if (graphMi_.Checked)
			{
				DrawGraph();
			}
		}

		/// <summary>
		/// Determines what time units should be used for the value collection.
		/// </summary>
		private double CalculateUnits(TsCHdaItemValueCollection values)
		{
			TimeSpan range = (values.EndTime - values.StartTime);

			if (values.Count > 0)
			{
				// calculate the total span.
				range = (values[values.Count-1].Timestamp-values[0].Timestamp);

				// up to 100 hours before switching to days.
				if (Math.Abs(range.TotalDays) > 4)
				{
					return TimeSpan.TicksPerDay;
				}

				// up to 1000 minutes before switching to hours.
				if (Math.Abs(range.TotalHours) > 16)
				{
					return TimeSpan.TicksPerHour;
				}

				// up to 1000 seconds before switching to minutes.
				if (Math.Abs(range.TotalMinutes) > 16)
				{
					return TimeSpan.TicksPerMinute;
				}
			}

			// default is seconds.
			return TimeSpan.TicksPerSecond;
		}

		/// <summary>
		/// Creates a set of points from an item value collection.
		/// </summary>
		private ArrayAdapter CreateAdapter(
			TsCHdaItemValueCollection values, 
			int                 qualityMask,
			DateTime            startTime,
			double              units)
		{
			// select only those values with the specified quality.
			ArrayList points = new ArrayList();

			foreach (TsCHdaItemValue value in values)
			{
				int qualityBits = (int)value.Quality.QualityBits & 0xC0;

				if (qualityBits == qualityMask)
				{
					points.Add(value);
				}
			}

			// no values meet quality criteria. 
			if (points.Count == 0)
			{
				return null;
			}

			// create array.
			double[] xs = new double[points.Count];
			double[] ys = new double[points.Count];

			for (int ii = 0; ii < points.Count; ii++)
			{
				TsCHdaItemValue value = (TsCHdaItemValue)points[ii];

				// calculate the difference between the start time and the current timestamp.
				long delta = ((TimeSpan)(value.Timestamp - startTime)).Ticks;

				xs[ii] = ((double)delta)/units;
				ys[ii] = System.Convert.ToDouble(value.Value);
			}

			// return points.
			return new ArrayAdapter(xs, ys);
		}

		/// <summary>
		/// Create the time axis label for a plot.
		/// </summary>
		private string CreateLabel(DateTime startTime, double units)
		{
			StringBuilder buffer = new StringBuilder();

			if (units == (double)TimeSpan.TicksPerDay)
			{
				buffer.Append("Days");
			}
			else if (units == (double)TimeSpan.TicksPerHour)
			{
				buffer.Append("Hours");
			}
			else if (units == (double)TimeSpan.TicksPerMinute)
			{
				buffer.Append("Minutes");
			}
			else if (units == (double)TimeSpan.TicksPerSecond)
			{
				buffer.Append("Seconds");
			}
			else
			{
				buffer.Append("Time");
			}

			buffer.Append(" (From ");
			buffer.Append(startTime.ToString("yyyy-MM-dd HH:mm:ss"));
			buffer.Append(")");

			return buffer.ToString();
		}

		/// <summary>
		/// Draws a graph for the current set of values.
		/// </summary>
		private void DrawGraph()
		{
			// clear existing plot.
			plotCtrl_.Clear();

			// update title.
			if (mItem_ != null && mItem_.ItemName != null && mItem_.ItemName != "")
			{
				plotCtrl_.Title = mItem_.ItemName;
			}

			// get current set of values.
			TsCHdaItemValueCollection values = GetValues();

			if (values == null || (values.Count == 0 && (values.StartTime == DateTime.MinValue || values.EndTime == DateTime.MinValue)))
			{
				plotCtrl_.Add(new PointPlot(new ArrayAdapter(new double[] { 0, 100 }, new double[] { 0, 100 })));
				plotCtrl_.XAxis1.Label = "No Data Available";
				plotCtrl_.Refresh();

				return;
			}

			// determine the best set of units.
			double units = CalculateUnits(values);

			// the first timestamp is the reference point for the plot.
			DateTime startTime = (values.Count > 0)?values[0].Timestamp:values.StartTime;

			// display empty set by plotting the time axis.
			if (values.Count == 0)
			{
				// create array.
				double[] xs = new double[2];
				double[] ys = new double[2];
				
				xs[0] = 0;
				ys[0] = 0;

				xs[1] = ((double)(((TimeSpan)(values.EndTime - startTime)).Ticks))/units;
				ys[1] = 100;

				plotCtrl_.Add(new PointPlot(new ArrayAdapter(xs, ys)));
				plotCtrl_.XAxis1.Label = CreateLabel(startTime, units);
				plotCtrl_.Refresh();

				return;
			}
			
			// create seperate plots for each quality of data.
			int[] qualityMasks = new int[] { 0xC0, 0x40, 0x00 };
			
			// create different icons for each type of data.
			Marker[] markers = new Marker[] 
			{
				new Marker(MarkerType.Circle, 4, new Pen(Color.Black)),
				new Marker(MarkerType.Square, 4, new Pen(Color.Blue)),
				new Marker(MarkerType.Cross1, 4, new Pen(Color.Red))
			};

			// add plots to control.
			for (int ii = 0; ii < qualityMasks.Length; ii++)
			{
				ArrayAdapter adpater = CreateAdapter(values, qualityMasks[ii], startTime, units);

				if (adpater != null)
				{
					if (adpater.Count < 40)
					{
						plotCtrl_.Add(new PointPlot(adpater, markers[ii]));
					}
					else
					{
						plotCtrl_.Add(new LinePlot(adpater));
					}
				}
			}
			
			// update the label.
			plotCtrl_.XAxis1.Label = CreateLabel(startTime, units);

			// display the data. 
			plotCtrl_.Refresh();	
		}

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

				// the value column has a default width of 100.
				if (ii == Value)
				{
					if (valuesLv_.Columns[ii].Width < 100)
					{
						valuesLv_.Columns[ii].Width = 100;
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
		private object GetFieldValue(TsCHdaItemValue value, int fieldId)
		{
			if (value != null)
			{
				switch (fieldId)
				{
					case Timestamp:         { return value.Timestamp;        }
					case Value:             { return value.Value;            }
					case Quality:           { return value.Quality;          }
					case HistorianQuality: { return value.HistorianQuality; }
				}

				if (typeof(TsCHdaModifiedValue).IsInstanceOfType(value))
				{
					switch (fieldId)
					{
						case ModificationTime: { return ((TsCHdaModifiedValue)value).ModificationTime; }
						case EditType:         { return ((TsCHdaModifiedValue)value).EditType;         }
						case User:              { return ((TsCHdaModifiedValue)value).User;             }
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(TsCHdaItemValue value, int index)
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
		private void UpdateListItem(ListViewItem listItem, TsCHdaItemValue value)
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
		/// Activates or deactivates the graph view mode.
		/// </summary>
		private void GraphMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// toggle check box.
				graphMi_.Checked = !graphMi_.Checked;
				
				// update state.
				SetState(graphMi_.Checked);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Activates or deactivates the raw data view mode.
		/// </summary>
		private void DataMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// toggle check box.
				dataMi_.Checked = !dataMi_.Checked;
				
				// update state.
				SetState(!dataMi_.Checked);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}


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
				TsCHdaItemValue value = new TsCHdaItemValue();

				value.Value            = new Double();
				value.Timestamp        = RunTestDlg.Basetime;
				value.Quality          = TsCDaQuality.Good;
				value.HistorianQuality = TsCHdaQuality.Raw;

				// prompt user to edit item value.
				value = new ItemValueEditDlg().ShowDialog(value);

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

				TsCHdaItemValue value = (TsCHdaItemValue)valuesLv_.SelectedItems[0].Tag;

				// create new item value.
				TsCHdaItemValue copy = new ItemValueEditDlg().ShowDialog((TsCHdaItemValue)value.Clone());

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
				TsCHdaItemValue value = new ItemValueEditDlg().ShowDialog((TsCHdaItemValue)valuesLv_.SelectedItems[0].Tag);

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
				TsCHdaItemValueCollection values = new ReadValuesDlg().ShowDialog(mServer_, RequestType.ReadRaw, true);

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
				foreach (TsCHdaItemValue value in values)
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

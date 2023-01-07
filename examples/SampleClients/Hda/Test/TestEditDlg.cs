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
using System.Drawing;
using System.Windows.Forms;

using SampleClients.Common;
using SampleClients.Hda.Item;
using SampleClients.Hda.Trend;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Da;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Test
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class TestEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Panel mainPn_;
		private System.Windows.Forms.ListView valuesLv_;
		private System.Windows.Forms.Panel topPn_;
		private System.Windows.Forms.Label resultIdlb_;
		private System.Windows.Forms.TextBox resultIdtb_;
		private System.Windows.Forms.Button okBtn_;
		private TrendEditCtrl trendCtrl_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem addMi_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.ToolStripMenuItem copyMi_;
		private System.Windows.Forms.ToolStripMenuItem deleteMi_;
		private System.Windows.Forms.ToolStripMenuItem clearMi_;
		private System.Windows.Forms.ToolStripMenuItem acceptActualMi_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		private System.ComponentModel.IContainer components = null;

		public TestEditDlg()
		{
			// Required for Windows Form Designer support
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
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			cancelBtn_ = new System.Windows.Forms.Button();
			buttonsPn_ = new System.Windows.Forms.Panel();
			okBtn_ = new System.Windows.Forms.Button();
			mainPn_ = new System.Windows.Forms.Panel();
			valuesLv_ = new System.Windows.Forms.ListView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			addMi_ = new System.Windows.Forms.ToolStripMenuItem();
			copyMi_ = new System.Windows.Forms.ToolStripMenuItem();
			editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			deleteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			clearMi_ = new System.Windows.Forms.ToolStripMenuItem();
			topPn_ = new System.Windows.Forms.Panel();
			trendCtrl_ = new TrendEditCtrl();
			resultIdlb_ = new System.Windows.Forms.Label();
			resultIdtb_ = new System.Windows.Forms.TextBox();
			acceptActualMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			buttonsPn_.SuspendLayout();
			mainPn_.SuspendLayout();
			topPn_.SuspendLayout();
			SuspendLayout();
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(304, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 378);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(384, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// OkBTN
			// 
			okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			okBtn_.Location = new System.Drawing.Point(4, 8);
			okBtn_.Name = "okBtn_";
			okBtn_.TabIndex = 0;
			okBtn_.Text = "OK";
			// 
			// MainPN
			// 
			mainPn_.Controls.Add(valuesLv_);
			mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			mainPn_.DockPadding.Left = 4;
			mainPn_.DockPadding.Right = 4;
			mainPn_.DockPadding.Top = 4;
			mainPn_.Location = new System.Drawing.Point(0, 192);
			mainPn_.Name = "mainPn_";
			mainPn_.Size = new System.Drawing.Size(384, 186);
			mainPn_.TabIndex = 32;
			// 
			// ValuesLV
			// 
			valuesLv_.ContextMenuStrip = popupMenu_;
			valuesLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			valuesLv_.FullRowSelect = true;
			valuesLv_.Location = new System.Drawing.Point(4, 4);
			valuesLv_.MultiSelect = false;
			valuesLv_.Name = "valuesLv_";
			valuesLv_.Size = new System.Drawing.Size(376, 182);
			valuesLv_.TabIndex = 0;
			valuesLv_.View = System.Windows.Forms.View.Details;
			valuesLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(ValuesLV_MouseDown);
			valuesLv_.DoubleClick += new System.EventHandler(EditMI_Click);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  addMi_,
																					  copyMi_,
																					  editMi_,
																					  deleteMi_,
																					  separator01_,
																					  clearMi_,
																					  acceptActualMi_});
			// 
			// AddMI
			// 
			addMi_.ImageIndex = 0;
			addMi_.Text = "Add...";
			addMi_.Click += new System.EventHandler(AddMI_Click);
			// 
			// CopyMI
			// 
			copyMi_.ImageIndex = 1;
			copyMi_.Text = "Copy....";
			copyMi_.Click += new System.EventHandler(CopyMI_Click);
			// 
			// EditMI
			// 
			editMi_.ImageIndex = 2;
			editMi_.Text = "Edit..";
			editMi_.Click += new System.EventHandler(EditMI_Click);
			// 
			// DeleteMI
			// 
			deleteMi_.ImageIndex = 3;
			deleteMi_.Text = "Delete";
			deleteMi_.Click += new System.EventHandler(DeleteMI_Click);
			// 
			// ClearMI
			// 
			clearMi_.ImageIndex = 5;
			clearMi_.Text = "Clear";
			clearMi_.Click += new System.EventHandler(ClearMI_Click);
			// 
			// TopPN
			// 
			topPn_.Controls.Add(trendCtrl_);
			topPn_.Controls.Add(resultIdlb_);
			topPn_.Controls.Add(resultIdtb_);
			topPn_.Dock = System.Windows.Forms.DockStyle.Top;
			topPn_.DockPadding.Left = 4;
			topPn_.DockPadding.Right = 4;
			topPn_.DockPadding.Top = 4;
			topPn_.Location = new System.Drawing.Point(0, 0);
			topPn_.Name = "topPn_";
			topPn_.Size = new System.Drawing.Size(384, 192);
			topPn_.TabIndex = 33;
			// 
			// TrendCTRL
			// 
			trendCtrl_.Dock = System.Windows.Forms.DockStyle.Top;
			trendCtrl_.Location = new System.Drawing.Point(4, 4);
			trendCtrl_.Name = "trendCtrl_";
			trendCtrl_.Size = new System.Drawing.Size(376, 168);
			trendCtrl_.TabIndex = 1;
			// 
			// ResultIDLB
			// 
			resultIdlb_.Location = new System.Drawing.Point(4, 172);
			resultIdlb_.Name = "resultIdlb_";
			resultIdlb_.Size = new System.Drawing.Size(96, 23);
			resultIdlb_.TabIndex = 0;
			resultIdlb_.Text = "Result ID";
			resultIdlb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ResultIDTB
			// 
			resultIdtb_.Location = new System.Drawing.Point(100, 172);
			resultIdtb_.Name = "resultIdtb_";
			resultIdtb_.Size = new System.Drawing.Size(204, 20);
			resultIdtb_.TabIndex = 0;
			resultIdtb_.Text = "";
			// 
			// AcceptActualMI
			// 
			acceptActualMi_.ImageIndex = 6;
			acceptActualMi_.Text = "Accept Actual Values...";
			acceptActualMi_.Click += new System.EventHandler(AcceptActualMI_Click);
			// 
			// Separator01
			// 
			separator01_.ImageIndex = 4;
			separator01_.Text = "-";
			// 
			// TestEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(384, 414);
			Controls.Add(mainPn_);
			Controls.Add(topPn_);
			Controls.Add(buttonsPn_);
			Name = "TestEditDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Edit Test Case";
			buttonsPn_.ResumeLayout(false);
			mainPn_.ResumeLayout(false);
			topPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion
		
		#region Public Interface
		/// <summary>
		/// Runs all tests with the specified name and displays the results.
		/// </summary>
		public bool ShowDialog(TsCHdaServer server, TestData test)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;

			trendCtrl_.Initialize(test.Trend, RequestType.None);

			valuesLv_.Tag = test;

			if (test.Expected != null)
			{
				// add expected result.
				resultIdtb_.Text = test.Expected.Result.Name.Name;

				// add expected values to list view.
				UpdateValues();
			}

			if (ShowDialog() != DialogResult.OK)
			{
				return false;
			}
			
			// update trend and expected values.
			trendCtrl_.Update(test.Trend);
			
			if (test.Expected != null)
			{
				// only update result if it does not have invalid characters.
				if (resultIdtb_.Text.IndexOfAny("() ".ToCharArray()) == -1) 
				{
					test.Expected.Result = new OpcResult(resultIdtb_.Text, "");
				}

				test.Expected.Clear();

				foreach (ListViewItem listItem in valuesLv_.Items)
				{
					if (typeof(TsCHdaItemValue).IsInstanceOfType(listItem.Tag))
					{
						test.Expected.Add(listItem.Tag);
					}
				}
			}

			return true;
		}
		#endregion
		
		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int Timestamp           = 0;
		private const int Value               = 1;
		private const int Quality             = 2;
		private const int HistorianQuality   = 3;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Timestamp",
			"Value",
			"Quality",
			"Historian Quality"
		};
		
		/// <summary>
		/// The server executing the test cases.
		/// </summary>
		private TsCHdaServer mServer_ = null;

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

				// set column width to zero if no test it in.
				if (empty) valuesLv_.Columns[ii].Width = 0;
			}
		}
	
		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddItem(TsCHdaItemValue item, bool highlight)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_YELLOW_SCROLL);

			// add empty columns.
			while (listItem.SubItems.Count < columnNames_.Length) listItem.SubItems.Add("");
			
			// update columns.
			UpdateItem(listItem, item);

			if (highlight)
			{
				listItem.ForeColor = Color.Red;
			}
		
			// add to list view.
			valuesLv_.Items.Add(listItem);
		}

		/// <summary>
		/// Updates the columns of an item in the list view.
		/// </summary>
		private void UpdateItem(ListViewItem listItem, TsCHdaItemValue item)
		{
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(item, ii));
			}

			// save object as list view item tag.
			listItem.Tag = item;
		}

		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCHdaItemValue item, int fieldId)
		{
			if (item == null)
			{
				return null;
			}

			switch (fieldId)
			{
				case Timestamp:   
				{ 
					if (item.Timestamp != DateTime.MinValue)
					{
						return item.Timestamp.ToString("HH:mm:ss"); 
					}

					return null;
				}

				case Value:              { return item.Value;            }
				case Quality:            { return item.Quality;          }
				case HistorianQuality:  { return item.HistorianQuality; }
			}

			return null;
		}

		/// <summary>
		/// Adds the expected and actual values to the list view.
		/// </summary>
		private void UpdateValues()
		{			
			// get test object.
			TestData test = (TestData)valuesLv_.Tag;

			// clear existing values.
			valuesLv_.Items.Clear();

			// add expected values.
			foreach (TsCHdaItemValue value in test.Expected)
			{
				AddItem(value, false);
			}

			if (test.Actual != null)
			{
				// append actual result to result.
				resultIdtb_.Text += " (" + test.Actual.Result.Name.Name + ")";

				for (int ii = 0; ii < test.Actual.Count; ii++)
				{
					// append actual values to columns of expected item.
					if (ii < valuesLv_.Items.Count)
					{		
						ListViewItem listItem = valuesLv_.Items[ii];

						for (int jj = 0; jj < listItem.SubItems.Count; jj++)
						{
							string expected = listItem.SubItems[jj].Text;
							string actual   = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(test.Actual[ii], jj));

							if (expected != actual)
							{
								listItem.SubItems[jj].Text = expected + " (" + actual + ")";
								listItem.ForeColor = Color.Green;
							}
						}
					}

						// add a new item with a different colour.
					else
					{
						AddItem(test.Actual[ii], true);
					}
				}

				// change color of expected items that are not in the set of actual items.
				for (int ii = test.Actual.Count; ii < test.Expected.Count; ii++)
				{
					valuesLv_.Items[ii].ForeColor = Color.Blue;
				}
			}

			// adjust columns.
			AdjustColumns();
		}
		#endregion

		/// <summary>
		/// Adds a new test case.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// create new item value.
				TsCHdaItemValue value = new TsCHdaItemValue();

				value.Value            = new Double();
				value.Timestamp        = RunTestDlg.Basetime;
				value.Quality          = TsCDaQuality.Good;
				value.HistorianQuality = Technosoftware.DaAeHdaClient.Hda.TsCHdaQuality.Raw;

				// prompt user to edit test case.
				value = new ItemValueEditDlg().ShowDialog(value);

				if (value == null)
				{
					return;
				}
				
				// update display.
				AddItem(value, false);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Adds a new test case by copying an existing one.
		/// </summary>
		private void CopyMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (valuesLv_.SelectedItems.Count != 1)
				{
					return;
				}

				TsCHdaItemValue value = (TsCHdaItemValue)valuesLv_.SelectedItems[0].Tag;

				// create new item value.
				TsCHdaItemValue copy = new ItemValueEditDlg().ShowDialog((TsCHdaItemValue)value.Clone());

				// prompt user to edit test case.
				if (copy == null)
				{
					return;
				}
				
				// update display.
				AddItem(copy, false);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Edits the parameters of s test case.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (valuesLv_.SelectedItems.Count != 1)
				{
					return;
				}

				// create new item value.
				TsCHdaItemValue value = new ItemValueEditDlg().ShowDialog((TsCHdaItemValue)valuesLv_.SelectedItems[0].Tag);

				// prompt user to edit test case.
				if (value == null)
				{
					return;
				}
				
				// update display.
				UpdateItem(valuesLv_.SelectedItems[0], value);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Deletes am existing test case.
		/// </summary>
		private void DeleteMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (valuesLv_.SelectedItems.Count != 1)
				{
					return;
				}
				
				// update display.
				valuesLv_.SelectedItems[0].Remove();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void ValuesLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			addMi_.Enabled    = true;
			copyMi_.Enabled   = false;
			editMi_.Enabled   = false;
			deleteMi_.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = valuesLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (valuesLv_.SelectedItems.Count == 1)
			{			
				copyMi_.Enabled   = true;
				editMi_.Enabled   = true;
				deleteMi_.Enabled = true;
			}
		}

		/// <summary>
		/// Remove all values from the list.
		/// </summary>
		private void ClearMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				valuesLv_.Items.Clear();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Accepts the actual values as the expected values.
		/// </summary>
		private void AcceptActualMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// get test object.
				TestData test = (TestData)valuesLv_.Tag;

				// set actual values as expected and update list view.
				if (test.Actual != null)
				{
					test.Expected = test.Actual;
					UpdateValues();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}	
		}
	}

	/// <summary>
	/// Contains data related to a test run.
	/// </summary>
	public class TestData
	{
		public DataSet.TestCase TestCase;
		public TsCHdaTrend Trend;
		public TsCHdaItemValueCollection Actual;
		public TsCHdaItemValueCollection Expected;
		public bool Passed;
	}
}

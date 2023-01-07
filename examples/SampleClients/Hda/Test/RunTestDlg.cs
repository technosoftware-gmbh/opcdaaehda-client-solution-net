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
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using SampleClients.Common;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Da;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Test
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class RunTestDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Panel mainPn_;
		private System.Windows.Forms.ListView resultsLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem copyMi_;
		private System.Windows.Forms.ToolStripMenuItem removeMi_;
		private System.Windows.Forms.ToolStripMenuItem addMi_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.Button runBtn_;
		private System.ComponentModel.IContainer components = null;

		public RunTestDlg()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
            
			
			resultsLv_.SmallImageList = Resources.Instance.ImageList;
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
			runBtn_ = new System.Windows.Forms.Button();
			mainPn_ = new System.Windows.Forms.Panel();
			resultsLv_ = new System.Windows.Forms.ListView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			addMi_ = new System.Windows.Forms.ToolStripMenuItem();
			copyMi_ = new System.Windows.Forms.ToolStripMenuItem();
			editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			removeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			buttonsPn_.SuspendLayout();
			mainPn_.SuspendLayout();
			SuspendLayout();
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(480, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Close";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(runBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 346);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(560, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// RunBTN
			// 
			runBtn_.Location = new System.Drawing.Point(4, 8);
			runBtn_.Name = "runBtn_";
			runBtn_.TabIndex = 1;
			runBtn_.Text = "Run";
			runBtn_.Click += new System.EventHandler(RunBTN_Click);
			// 
			// MainPN
			// 
			mainPn_.Controls.Add(resultsLv_);
			mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			mainPn_.DockPadding.Left = 4;
			mainPn_.DockPadding.Right = 4;
			mainPn_.DockPadding.Top = 4;
			mainPn_.Location = new System.Drawing.Point(0, 0);
			mainPn_.Name = "mainPn_";
			mainPn_.Size = new System.Drawing.Size(560, 346);
			mainPn_.TabIndex = 32;
			// 
			// ResultsLV
			// 
			resultsLv_.ContextMenuStrip = popupMenu_;
			resultsLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			resultsLv_.FullRowSelect = true;
			resultsLv_.Location = new System.Drawing.Point(4, 4);
			resultsLv_.MultiSelect = false;
			resultsLv_.Name = "resultsLv_";
			resultsLv_.Size = new System.Drawing.Size(552, 342);
			resultsLv_.TabIndex = 0;
			resultsLv_.View = System.Windows.Forms.View.Details;
			resultsLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(ResultsLV_MouseDown);
			resultsLv_.DoubleClick += new System.EventHandler(EditMI_Click);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  addMi_,
																					  copyMi_,
																					  editMi_,
																					  removeMi_});
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
			copyMi_.Text = "Copy...";
			copyMi_.Click += new System.EventHandler(CopyMI_Click);
			// 
			// EditMI
			// 
			editMi_.ImageIndex = 2;
			editMi_.Text = "Edit..";
			editMi_.Click += new System.EventHandler(EditMI_Click);
			// 
			// RemoveMI
			// 
			removeMi_.ImageIndex = 3;
			removeMi_.Text = "Delete";
			removeMi_.Click += new System.EventHandler(RemoveMI_Click);
			// 
			// RunTestDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(560, 382);
			Controls.Add(mainPn_);
			Controls.Add(buttonsPn_);
			Name = "RunTestDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Run Test Cases";
			buttonsPn_.ResumeLayout(false);
			mainPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The base time for all test parameters/results.
		/// </summary>
		internal static readonly DateTime Basetime = new DateTime(2005, 1, 1);

		/// <summary>
		/// The server executing the test cases.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// The dataset describing the test cases.
		/// </summary>
		private DataSet mDataset_ = null;

		/// <summary>
		/// The file containing the test case descriptions.
		/// </summary>
		private string mFilePath_ = null;
	
		/// <summary>
		/// The item id to use for the tests.
		/// </summary>
		private string mItemId_ = null;

		/// <summary>
		/// Runs all tests with the specified name and displays the results.
		/// </summary>
		public void ShowDialog(TsCHdaServer server, string fileName, string itemId)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;	
			mItemId_ = itemId;
			
			// construct full file path.
			mFilePath_ = Application.StartupPath + "\\" + fileName;

			// run the test
			try
			{
				Run();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}

			// display dilaog.
			ShowDialog();

			// dispose of dataset.
			if (mDataset_ != null) 
			{
				mDataset_.Dispose();
				mDataset_ = null;
			}
		}

		/// <summary>
		/// Runs all test cases and displays the results.
		/// </summary>
		private void Run()
		{
			TsCHdaItem[] items = null;

			try
			{
				// clear existing results.
				resultsLv_.Items.Clear();

				// free the existing dataset.
				if (mDataset_ != null) 
				{
					mDataset_.Dispose();
					mDataset_ = null;
				}

				// load the dataset.
				TestData[] tests = LoadDataSet();

				if (tests == null)
				{
					return;
				}

				// create the item.
				OpcItemResult[] results = mServer_.CreateItems(new OpcItem[] { new OpcItem(mItemId_) });

				if (results == null || results.Length != 1)
				{
					//throw new InvalidResponseException();
				}

				// return items.
				items = new TsCHdaItem[] { new TsCHdaItem(results[0]) };

				// execute test cases.
				foreach (TestData test in tests)
				{
					ExecuteTest(test, items);
				}

				// adjust columns.
				AdjustColumns();

				// scroll to the first failed result.
				for (int ii = 0; ii < resultsLv_.Items.Count; ii++)
				{
					if (resultsLv_.Items[ii].ForeColor == Color.Red)
					{						
						resultsLv_.EnsureVisible(ii);
						break;
					}
				}
			}
			finally
			{				
				if (items != null)
				{
					try   { mServer_.ReleaseItems(items); }
					catch {}
				}
			}
		}

		/// <summary>
		/// Loads the dataset containing the test descriptions.
		/// </summary>
		private TestData[] LoadDataSet()
		{
			try
			{
				// create the dataset.
				mDataset_ = new DataSet();

				// load the test case descriptions.
				mDataset_.ReadXml(mFilePath_);

				// select only the desired test cases. 
				mDataset_.TestCases.DefaultView.Sort = "Name";

				// execute the test cases.
				ArrayList tests = new ArrayList(mDataset_.TestCases.DefaultView.Count);

				foreach (DataRowView row in mDataset_.TestCases.DefaultView)
				{
					DataSet.TestCase testcase = (DataSet.TestCase)row.Row;

					// create trend.
					TsCHdaTrend trend = new TsCHdaTrend(mServer_);

					trend.Name             = testcase.Name;
					trend.Aggregate      = testcase.AggregateId;
					trend.MaxValues        = testcase.MaxValues;
					trend.IncludeBounds    = testcase.IncludeBounds;
					trend.ResampleInterval = testcase.ResampleInterval;

					if (testcase.StartTime != Decimal.MinValue)
					{
						trend.StartTime = new TsCHdaTime(Basetime.AddSeconds((double)testcase.StartTime));
					}

					if (testcase.EndTime != Decimal.MinValue)
					{
						trend.EndTime = new TsCHdaTime(Basetime.AddSeconds((double)testcase.EndTime));
					}

					TestData test = new TestData();

					test.TestCase = testcase;
					test.Trend    = trend;
					test.Expected = GetExpectedResults(testcase);

					// add to list.
					tests.Add(test);
				}

				// return set of trends.
				return (TestData[])tests.ToArray(typeof(TestData));
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			return null;
		}

		/// <summary>
		/// Creates the item to use for the tests.
		/// </summary>
		private void ExecuteTest(TestData test, TsCHdaItem[] items)
		{
			try
			{
				// read values from server.
				TsCHdaItemValueCollection[] actualResults = test.Trend.Read(items);

				if (actualResults == null || actualResults.Length != 1)
				{
					//throw new InvalidResponseException();
				}

				// check results.
				test.Actual = actualResults[0];
				test.Passed = CheckResults(test.Expected, test.Actual);
			}
			catch (Exception e)
			{
				test.Actual = new TsCHdaItemValueCollection();
				test.Actual.Result = OpcResult.E_FAIL;
				test.Actual.DiagnosticInfo = e.Message;
			}

			// add test data to list view.
			AddItem(test);
		}

		/// <summary>
		/// Reads the expected results for a test case from the dataset.
		/// </summary>
		private TsCHdaItemValueCollection GetExpectedResults(DataSet.TestCase testcase)
		{
			// create item value collection.
			TsCHdaItemValueCollection values = new TsCHdaItemValueCollection();

			try
			{
				// set expected result.
				values.Result = new OpcResult(testcase.ResultId, "");

				// get the item values.
				DataRow[] rows = testcase.GetChildRows(mDataset_.TestCases.ChildRelations[0]);

				// read the expected values.
				if (rows != null)
				{
					foreach (DataSet.TsCHdaItemValue row in rows)
					{
						// create item value.
						TsCHdaItemValue value = new TsCHdaItemValue();

						if (!typeof(DBNull).IsInstanceOfType(row["Value"]))
						{
							value.Value = row.Value;
						}

						value.Timestamp        = Basetime.AddSeconds((double)row.Timestamp);
						value.Quality          = new TsCDaQuality((short)(row.Quality & 0x000FFFF));
						value.HistorianQuality = (Technosoftware.DaAeHdaClient.Hda.TsCHdaQuality)Enum.ToObject(typeof(Technosoftware.DaAeHdaClient.Hda.TsCHdaQuality), (int)(row.Quality & 0xFFFF0000));

						// add to list.
						values.Add(value);
					}
				}
			}
			catch (Exception)
			{
				// ignore exceptions - return at whatever was read correctly.
			}

			// return set of values.
			return values;
		}

		/// <summary>
		/// Compares the expected results to the actual results.
		/// </summary>
		private bool CheckResults(TsCHdaItemValueCollection expected, TsCHdaItemValueCollection actual)
		{
			// check result codes.
			if (expected.Result.Name.Name != actual.Result.Name.Name)
			{
				return false;
			}

			// check that number of results are equal.
			if (expected.Count != actual.Count)
			{
				return false;
			}

			for (int ii = 0; ii < expected.Count; ii++)
			{
				// compare timestamps.
				if (expected[ii].Timestamp != actual[ii].Timestamp)
				{
					return false;
				}

				// compare quality.
				if (expected[ii].Quality != actual[ii].Quality)
				{
					return false;
				}

				// compare histrorian quality.
				if (expected[ii].HistorianQuality != actual[ii].HistorianQuality)
				{
					return false;
				}

				// check for null (empty or bad values).
				if (expected[ii].Value == null || actual[ii].Value == null)
				{
					if (expected[ii].Value != actual[ii].Value)
					{
						return false;
					}
				}

				// comapare value - allowing for some round off errors.
				else
				{
					decimal expectedValue = System.Convert.ToDecimal(expected[ii].Value);
					decimal actualValue   = System.Convert.ToDecimal(actual[ii].Value);

					if (Math.Abs(expectedValue - actualValue) > 0.001M)
					{
						return false;
					}
				}
			}

			// test passed - actual results match expected.
			return true;
		}

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int Testcase            = 0;
		private const int Aggregate           = 1;
		private const int StartTime          = 2;
		private const int EndTime            = 3;
		private const int MaxValues          = 4;
		private const int IncludeBounds      = 5;
		private const int ResamplingInterval = 6;
		private const int Result              = 7;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Test Case",
			"Aggregate",
			"Start",
			"End",
			"Max",
			"Bounds",
			"Sampling",
			"Result"
		};
		
		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			resultsLv_.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				resultsLv_.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < resultsLv_.Columns.Count; ii++)
			{
				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in resultsLv_.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						resultsLv_.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) resultsLv_.Columns[ii].Width = 0;
			}
		}
	
		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddItem(TestData test)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_YELLOW_SCROLL);

			// add empty columns.
			while (listItem.SubItems.Count < columnNames_.Length) listItem.SubItems.Add("");
			
			// update columns.
			UpdateItem(listItem, test);

			// add to list view.
			resultsLv_.Items.Add(listItem);
		}

		/// <summary>
		/// Updates the columns of an item in the list view.
		/// </summary>
		private void UpdateItem(ListViewItem listItem, TestData test)
		{
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = Technosoftware.DaAeHdaClient.OpcConvert.ToString(GetFieldValue(test, ii));
			}

			// flag tests that failed.
			listItem.ForeColor = (test.Passed)?Color.Empty:Color.Red;
			
			// save object as list view item tag.
			listItem.Tag = test;
		}

		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TestData test, int fieldId)
		{
			if (test == null)
			{
				return null;
			}

			switch (fieldId)
			{
				case Testcase: { return test.Trend.Name; }
				
				case Aggregate:           
				{ 
					if (test.Trend.Aggregate != TsCHdaAggregateID.NoAggregate)
					{
						foreach (TsCHdaAggregate aggregate in mServer_.Aggregates)
						{
							if (aggregate.Id == test.Trend.Aggregate)
							{
								return aggregate;
							}
						}
					}

					return null;
				}

				case StartTime:   
				{ 
					if (test.Trend.StartTime != null)
					{
						return test.Trend.StartTime.AbsoluteTime.ToString("HH:mm:ss"); 
					}

					return null;
				}

				case EndTime: 
				{ 
					if (test.Trend.EndTime != null)
					{
						return test.Trend.EndTime.AbsoluteTime.ToString("HH:mm:ss"); 
					}

					return null;
				}

				case MaxValues:   
				{
					if (test.Trend.Aggregate == TsCHdaAggregateID.NoAggregate)
					{
						return test.Trend.MaxValues;
					}

					return null;
				}

				case IncludeBounds:  
				{
					if (test.Trend.Aggregate == TsCHdaAggregateID.NoAggregate)
					{
						return test.Trend.IncludeBounds;
					}

					return null;
				}

				case ResamplingInterval:
				{
					if (test.Trend.Aggregate != TsCHdaAggregateID.NoAggregate)
					{
						return test.Trend.ResampleInterval;
					}

					return null;
				}

				case Result: 
				{
					// check if passed.
					if (test.Passed)
					{
						return String.Format("Passed ({0}, {1} Values)", test.Expected.Result.Name.Name, test.Expected.Count);
					}

					if (test.Actual != null)
					{
						// exception thrown.
						if (test.Actual.DiagnosticInfo != null)
						{
							return test.Actual.DiagnosticInfo;
						}

						// result code wrong.
						if (test.Actual.Result.Name.Name != test.Expected.Result.Name.Name)
						{
							return "Unexpected result: " + test.Actual.Result;
						}
						
						// incorrect values.
						return "Incorrect set of item values.";
					}

					// test not executed.
					return null;
				}
			}

			return null;
		}

		/// <summary>
		/// Updates the a testcase in the dataset.
		/// </summary>
		private void UpdateTestCase(TestData test)
		{
			// update the test case.
			test.TestCase.Name             = test.Trend.Name;
			test.TestCase.AggregateId      = test.Trend.Aggregate;
			test.TestCase.StartTime        = Decimal.MinValue;
			test.TestCase.EndTime          = Decimal.MinValue;
			test.TestCase.MaxValues        = test.Trend.MaxValues;
			test.TestCase.IncludeBounds    = test.Trend.IncludeBounds;
			test.TestCase.ResampleInterval = test.Trend.ResampleInterval;
			test.TestCase.ResultId         = test.Expected.Result.Name.Name;

			if (test.Trend.StartTime != null)
			{
				test.TestCase.StartTime = (decimal)((TimeSpan)(test.Trend.StartTime.AbsoluteTime - Basetime)).TotalSeconds;
			}		

			if (test.Trend.EndTime != null)
			{
				test.TestCase.EndTime = (decimal)((TimeSpan)(test.Trend.EndTime.AbsoluteTime - Basetime)).TotalSeconds;
			}

			// get child rows.
			DataRow[] rows = test.TestCase.GetChildRows(mDataset_.TestCases.ChildRelations[0]);

			// update existing records or add new records as required.
			for (int ii = 0; ii < test.Expected.Count; ii++)
			{
				DataSet.TsCHdaItemValue value = null;

				if (rows != null && ii < rows.Length)
				{
					value = (DataSet.TsCHdaItemValue)rows[ii];
				}
				else
				{
					value = mDataset_.ItemValues.NewItemValue();
					value.TestCase = test.TestCase;					
					mDataset_.ItemValues.AddItemValue(value);
				}

				if (test.Expected[ii].Value != null)
				{
					value.Value = System.Convert.ToDouble(test.Expected[ii].Value);
				}
				else
				{
					value["Value"] = DBNull.Value;
				}

				value.Timestamp  = (decimal)((TimeSpan)(test.Expected[ii].Timestamp - Basetime)).TotalSeconds;
				value.Quality    = (int)test.Expected[ii].Quality.GetCode();
				value.Quality   |= (int)test.Expected[ii].HistorianQuality;
			}

			// delete unnecessary records.
			if (rows != null)
			{
				for (int ii = test.Expected.Count; ii < rows.Length; ii++)
				{
					rows[ii].Delete();
				}
			}
		}

		/// <summary>
		/// Adds a new test case.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// create new test case.
				TestData test = new TestData();

				test.Trend                  = new TsCHdaTrend(mServer_);
				test.Trend.Name             = "Test01";
				test.Trend.Aggregate = TsCHdaAggregateID.NoAggregate;
				test.Trend.StartTime        = new TsCHdaTime(Basetime);
				test.Trend.EndTime          = new TsCHdaTime(Basetime);
				test.Trend.MaxValues        = 0;
				test.Trend.IncludeBounds    = false;
				test.Trend.ResampleInterval = 0;

				test.Expected = new TsCHdaItemValueCollection();

				// prompt user to edit test case.
				if (!new TestEditDlg().ShowDialog(mServer_, test))
				{
					return;
				}
				
				// create test case.
				test.TestCase = mDataset_.TestCases.NewTestCase();
				mDataset_.TestCases.AddTestCase(test.TestCase);

				// update test case.
				UpdateTestCase(test);

				// accept changes and save the dataset.
				mDataset_.AcceptChanges();
				mDataset_.WriteXml(mFilePath_);

				// update display.
				AddItem(test);
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
				if (resultsLv_.SelectedItems.Count != 1)
				{
					return;
				}

				TestData test = (TestData)resultsLv_.SelectedItems[0].Tag;

				// create new test case.
				TestData copy = new TestData();

				copy.Trend    = (TsCHdaTrend)test.Trend.Clone();
				copy.Expected = (TsCHdaItemValueCollection)test.Expected.Clone();

				// prompt user to edit test case.
				if (!new TestEditDlg().ShowDialog(mServer_, copy))
				{
					return;
				}

				// create test case.
				copy.TestCase = mDataset_.TestCases.NewTestCase();
				mDataset_.TestCases.AddTestCase(copy.TestCase);

				// update test case.
				UpdateTestCase(copy);

				// accept changes and save the dataset.
				mDataset_.AcceptChanges();
				mDataset_.WriteXml(mFilePath_);

				// update display.
				AddItem(copy);
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
				if (resultsLv_.SelectedItems.Count != 1)
				{
					return;
				}

				TestData test = (TestData)resultsLv_.SelectedItems[0].Tag;

				if (!new TestEditDlg().ShowDialog(mServer_, test))
				{
					return;
				}

				// update test case.
				UpdateTestCase(test);

				// accept changes and save the dataset.
				mDataset_.AcceptChanges();
				mDataset_.WriteXml(mFilePath_);

				// update display.
				UpdateItem(resultsLv_.SelectedItems[0], test);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Deletes am existing test case.
		/// </summary>
		private void RemoveMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (resultsLv_.SelectedItems.Count != 1)
				{
					return;
				}

				TestData test = (TestData)resultsLv_.SelectedItems[0].Tag;

				// confirm delete.
				DialogResult result = MessageBox.Show("Permenently delete the test case?", test.Trend.Name, MessageBoxButtons.YesNo);

				if (result != DialogResult.Yes)
				{
					return;
				}

				// fetch the current index in the dataset.
				int index = mDataset_.TestCases.DefaultView.Find(test.Trend.Name);

				if (index == -1)
				{
					return;
				}

				DataSet.TestCase testcase = (DataSet.TestCase)mDataset_.TestCases.DefaultView[index].Row;

				// delete the test case.
				testcase.Delete();

				// accept changes and save the dataset.
				mDataset_.AcceptChanges();
				mDataset_.WriteXml(mFilePath_);

				// update display.
				resultsLv_.SelectedItems[0].Remove();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Updates state of the popup menu before display.
		/// </summary>
		private void ResultsLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			addMi_.Enabled    = true;
			copyMi_.Enabled   = false;
			editMi_.Enabled   = false;
			removeMi_.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = resultsLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (resultsLv_.SelectedItems.Count == 1)
			{			
				copyMi_.Enabled   = true;
				editMi_.Enabled   = true;
				removeMi_.Enabled = true;
			}
		}

		/// <summary>
		/// Re-runs the tests.
		/// </summary>
		private void RunBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				Run();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}

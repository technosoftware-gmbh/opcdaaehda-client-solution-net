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
using System.Windows.Forms;

using SampleClients.Common;
using SampleClients.Hda.Item;
using SampleClients.Hda.Trend;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;

using BrowseTreeCtrl = SampleClients.Hda.Server.BrowseTreeCtrl;

#endregion

namespace SampleClients.Hda.Edit
{
	/// <summary>
	/// Summary description for ItemAddDlg.
	/// </summary>
	public class ReplaceValuesDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Splitter splitterV_;
		private System.Windows.Forms.Panel rightPn_;
		private System.Windows.Forms.Panel leftPn_;
		private BrowseTreeCtrl browseCtrl_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button backBtn_;
		private System.Windows.Forms.Button nextBtn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button doneBtn_;
		private TrendEditCtrl trendCtrl_;
		private ItemValuesCtrl valuesCtrl_;
		private ResultListCtrl resultsCtrl_;
		private ResultListCtrl asyncResultsCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ReplaceValuesDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			splitterV_ = new System.Windows.Forms.Splitter();
			rightPn_ = new System.Windows.Forms.Panel();
			valuesCtrl_ = new ItemValuesCtrl();
			browseCtrl_ = new BrowseTreeCtrl();
			resultsCtrl_ = new ResultListCtrl();
			leftPn_ = new System.Windows.Forms.Panel();
			trendCtrl_ = new TrendEditCtrl();
			buttonsPn_ = new System.Windows.Forms.Panel();
			backBtn_ = new System.Windows.Forms.Button();
			nextBtn_ = new System.Windows.Forms.Button();
			doneBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			asyncResultsCtrl_ = new ResultListCtrl();
			rightPn_.SuspendLayout();
			leftPn_.SuspendLayout();
			buttonsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// SplitterV
			// 
			splitterV_.Location = new System.Drawing.Point(360, 0);
			splitterV_.Name = "splitterV_";
			splitterV_.Size = new System.Drawing.Size(3, 386);
			splitterV_.TabIndex = 12;
			splitterV_.TabStop = false;
			// 
			// RightPN
			// 
			rightPn_.Controls.Add(asyncResultsCtrl_);
			rightPn_.Controls.Add(valuesCtrl_);
			rightPn_.Controls.Add(browseCtrl_);
			rightPn_.Controls.Add(resultsCtrl_);
			rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			rightPn_.DockPadding.Right = 4;
			rightPn_.DockPadding.Top = 4;
			rightPn_.Location = new System.Drawing.Point(363, 0);
			rightPn_.Name = "rightPn_";
			rightPn_.Size = new System.Drawing.Size(509, 386);
			rightPn_.TabIndex = 13;
			// 
			// ValuesCTRL
			// 
			valuesCtrl_.DisplayGraph = false;
			valuesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			valuesCtrl_.Location = new System.Drawing.Point(0, 4);
			valuesCtrl_.Name = "valuesCtrl_";
			valuesCtrl_.ReadOnly = false;
			valuesCtrl_.Size = new System.Drawing.Size(505, 382);
			valuesCtrl_.TabIndex = 3;
			// 
			// BrowseCTRL
			// 
			browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			browseCtrl_.Location = new System.Drawing.Point(0, 4);
			browseCtrl_.Name = "browseCtrl_";
			browseCtrl_.Size = new System.Drawing.Size(505, 382);
			browseCtrl_.TabIndex = 1;
			browseCtrl_.ItemSelected += new BrowseTreeCtrl.ItemSelectedEventHandler(BrowseCTRL_ItemSelected);
			browseCtrl_.ItemPicked += new BrowseTreeCtrl.ItemPickedEventHandler(BrowseCTRL_ItemPicked);
			// 
			// ResultsCTRL
			// 
			resultsCtrl_.AllowDrop = true;
			resultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			resultsCtrl_.Location = new System.Drawing.Point(0, 4);
			resultsCtrl_.Name = "resultsCtrl_";
			resultsCtrl_.Size = new System.Drawing.Size(505, 382);
			resultsCtrl_.TabIndex = 0;
			// 
			// LeftPN
			// 
			leftPn_.Controls.Add(trendCtrl_);
			leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			leftPn_.DockPadding.Left = 4;
			leftPn_.DockPadding.Top = 4;
			leftPn_.Location = new System.Drawing.Point(0, 0);
			leftPn_.Name = "leftPn_";
			leftPn_.Size = new System.Drawing.Size(360, 386);
			leftPn_.TabIndex = 14;
			// 
			// TrendCTRL
			// 
			trendCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			trendCtrl_.Location = new System.Drawing.Point(4, 4);
			trendCtrl_.Name = "trendCtrl_";
			trendCtrl_.RequestType = RequestType.ReadRaw;
			trendCtrl_.Size = new System.Drawing.Size(356, 382);
			trendCtrl_.TabIndex = 2;
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(backBtn_);
			buttonsPn_.Controls.Add(nextBtn_);
			buttonsPn_.Controls.Add(doneBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 386);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(872, 36);
			buttonsPn_.TabIndex = 15;
			// 
			// BackBTN
			// 
			backBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			backBtn_.Location = new System.Drawing.Point(632, 8);
			backBtn_.Name = "backBtn_";
			backBtn_.TabIndex = 3;
			backBtn_.Text = "< Back";
			backBtn_.Click += new System.EventHandler(BackBTN_Click);
			// 
			// NextBTN
			// 
			nextBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			nextBtn_.Location = new System.Drawing.Point(712, 8);
			nextBtn_.Name = "nextBtn_";
			nextBtn_.TabIndex = 2;
			nextBtn_.Text = "Next >";
			nextBtn_.Click += new System.EventHandler(NextBTN_Click);
			// 
			// DoneBTN
			// 
			doneBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			doneBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			doneBtn_.Location = new System.Drawing.Point(792, 8);
			doneBtn_.Name = "doneBtn_";
			doneBtn_.TabIndex = 0;
			doneBtn_.Text = "Done";
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(792, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 5;
			cancelBtn_.Text = "Cancel";
			// 
			// AsyncResultsCTRL
			// 
			asyncResultsCtrl_.AllowDrop = true;
			asyncResultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			asyncResultsCtrl_.Location = new System.Drawing.Point(0, 4);
			asyncResultsCtrl_.Name = "asyncResultsCtrl_";
			asyncResultsCtrl_.Size = new System.Drawing.Size(505, 382);
			asyncResultsCtrl_.TabIndex = 4;
			// 
			// ReplaceValuesDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(872, 422);
			Controls.Add(rightPn_);
			Controls.Add(splitterV_);
			Controls.Add(leftPn_);
			Controls.Add(buttonsPn_);
			Name = "ReplaceValuesDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Replace Item Values";
			rightPn_.ResumeLayout(false);
			leftPn_.ResumeLayout(false);
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion
		
		#region Public Interface
		/// <summary>
		/// Prompts the user to specified values to replace.
		/// </summary>
		public bool ShowDialog(TsCHdaServer server, bool synchronous)
		{
			return ShowDialog(server, null, synchronous);
		}

		/// <summary>
		/// Prompts the user to specified values to replace.
		/// </summary>
		public bool ShowDialog(TsCHdaServer server, OpcItem item, bool synchronous)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_      = server;
			mSynchronous_ = synchronous;
			mItem_        = item;
			mValues_      = null;
			mResults_     = null;

			// create new trend.
			mTrend_ = new TsCHdaTrend(mServer_);

			// set reasonable defaults.
			mTrend_.StartTime = new TsCHdaTime("YEAR");
			mTrend_.EndTime   = new TsCHdaTime("YEAR+1H");

			browseCtrl_.Browse(mServer_, null);
			trendCtrl_.Initialize(mTrend_, RequestType.ReadRaw);
			valuesCtrl_.Initialize(mServer_, null);
			asyncResultsCtrl_.Initialize(mServer_, null);
			resultsCtrl_.Initialize(mServer_, null);

			// update dialog state.
			SetState();

			// show dialog.
			bool result = (ShowDialog() == DialogResult.OK);

			// release item handles.
			mTrend_.ClearItems();

			// return item values.
			return result;
		}
		#endregion

		#region Private Members
		/// <summary>
		/// The historian database server.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// The trend used to read the data.
		/// </summary>
		private TsCHdaTrend mTrend_ = null;

		/// <summary>
		/// The requst object for an asynchronous update.
		/// </summary>
		private IOpcRequest mRequest_ = null;

		/// <summary>
		/// Whether an asynchronous request was sent (and possibly failed).
		/// </summary>
		private bool mAsyncSent_ = false;
		
		/// <summary>
		/// Whether to use synchronous or asynchronous updates.
		/// </summary>
		private bool mSynchronous_ = true;

		/// <summary>
		/// The item to read.
		/// </summary>
		private OpcItem mItem_ = null;

		/// <summary>
		/// The set of new items which will be added to the trend.
		/// </summary>
		private TsCHdaItemValueCollection[] mValues_ = null;

		/// <summary>
		/// The set of results from the insert operation.
		/// </summary>
		private TsCHdaResultCollection[] mResults_ = null;

		/// <summary>
		/// Create server handles for new items.
		/// </summary>
		private void DoRead()
		{
			// fetch the new trend parameters.
			trendCtrl_.Update(mTrend_);

			// create item (if necessary).
			TsCHdaItem item = mTrend_.Items[mItem_];

			if (item == null)
			{
				item = mTrend_.AddItem(mItem_);
			}

			// read data.
			TsCHdaItemValueCollection[] results = mTrend_.Read(new TsCHdaItem[] { item });

			if (results == null || results.Length != 1)
			{
				////throw new InvalidResponseException();
			}

			// save results.
			mValues_ = results;
					
			// display results.
			valuesCtrl_.Initialize(mServer_, mValues_[0]);
		}

		/// <summary>
		/// Updates the values of the item.
		/// </summary>
		private void DoReplace()
		{
			// get the values to insert/replace.
			mValues_ = new TsCHdaItemValueCollection[] { valuesCtrl_.GetValues() };

			// check if there is nothing to do.
			if (mValues_[0] == null || mValues_[0].Count == 0)
			{
				return;
			}
			
			// create item (if necessary).
			TsCHdaItem item = mTrend_.Items[mItem_];

			if (item == null)
			{
				item = mTrend_.AddItem(mItem_);
			}

			// add the item identifier information to the collection.
			mValues_[0].ItemName     = item.ItemName;
			mValues_[0].ItemPath     = item.ItemPath;
			mValues_[0].ServerHandle = item.ServerHandle;
			mValues_[0].ClientHandle = item.ClientHandle;

			if (mSynchronous_)
			{
				// replace data.
				TsCHdaResultCollection[] results =  mServer_.Replace(mValues_);

				if (results == null || results.Length != 1)
				{
					////throw new InvalidResponseException();
				}

				// display results.
				resultsCtrl_.Initialize(mServer_, mValues_, results);

				// save results.
				mResults_ = results;
			}
			else
			{
				// check if already waiting for results.
				if (mAsyncSent_)
				{
					return;
				}

				// begin replace data.
				OpcItemResult[] results =  mServer_.Replace(
					mValues_,
					null,
                    new TsCHdaUpdateCompleteEventHandler(OnUpdateComplete),
					out mRequest_);
	
				if (results == null || results.Length != 1)
				{
					//throw new InvalidResponseException();
				}

				// display initial results.
				asyncResultsCtrl_.Initialize(mServer_, results);
				mAsyncSent_ = true;
			}
		}

		/// <summary>
		/// Called when a update request completes.
		/// </summary>
		public void OnUpdateComplete(IOpcRequest request, TsCHdaResultCollection[] results)
		{
			// check if dialog has closed.
			if (IsDisposed)
			{
				return;
			}

			// check if invoke is required.
			if (InvokeRequired)
			{
                BeginInvoke(new TsCHdaUpdateCompleteEventHandler(OnUpdateComplete), new object[] { request, results });
				return;
			}
						
			try
			{
				// display results.
				resultsCtrl_.Initialize(mServer_, mValues_, results);
				mResults_ = results;
				nextBtn_.Enabled = true;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Called when a cancel request completes.
		/// </summary>
		public void OnCancelComplete(IOpcRequest request)
		{
			// check if invoke is required.
			if (InvokeRequired)
			{
				BeginInvoke(new TsCHdaCancelCompleteEventHandler(OnCancelComplete), new object[] { request });
				return;
			}
			
			// check if dialog has closed.
			if (IsDisposed)
			{
				return;
			}

			MessageBox.Show("Asynchronous update successfully cancelled.");
		}

		/// <summary>
		/// Remove server handles for new items.
		/// </summary>
		private void UndoRead()
		{
			mValues_ = null;
			mItem_   = null;

			valuesCtrl_.Initialize(mServer_, null);
		}
		
		/// <summary>
		/// Discards results used for the replace operation.
		/// </summary>
		private void UndoReplace()
		{
			if (mResults_ != null)
			{
				mResults_   = null;
				mAsyncSent_ = false;

				if (mRequest_ != null)
				{
					mServer_.CancelRequest(mRequest_, new TsCHdaCancelCompleteEventHandler(OnCancelComplete));
					mRequest_ = null;
				}
			}

			// display results.
			resultsCtrl_.Initialize(mServer_, mValues_, mResults_);
		}

		/// <summary>
		/// Toggle control visibility based on the dialog state.
		/// </summary>
		private void SetState()
		{
			// replace operation complete.
			if (mResults_ != null)
			{
				nextBtn_.Enabled          = false;
				backBtn_.Enabled          = true;
				doneBtn_.Visible          = true;
				cancelBtn_.Visible        = false;
				browseCtrl_.Visible       = false;
				valuesCtrl_.Visible       = false;
				resultsCtrl_.Visible      = true;
				asyncResultsCtrl_.Visible = false;
			}
				
			// async request started.
			else if (mAsyncSent_)
			{
				nextBtn_.Enabled          = mResults_ != null;
				backBtn_.Enabled          = true;
				doneBtn_.Visible          = false;
				cancelBtn_.Visible        = true;
				browseCtrl_.Visible       = false;
				valuesCtrl_.Visible       = false;
				resultsCtrl_.Visible      = false;
				asyncResultsCtrl_.Visible = true;
			}

			// editing values to use in an replace operation.
			else if (mItem_ != null)
			{
				nextBtn_.Enabled          = true;
				backBtn_.Enabled          = true;
				doneBtn_.Visible          = false;
				cancelBtn_.Visible        = true;
				browseCtrl_.Visible       = false;
				valuesCtrl_.Visible       = true;
				resultsCtrl_.Visible      = false;
				asyncResultsCtrl_.Visible = false;
			}

			// selecting an item to use for the read/replace operation.
			else
			{
				nextBtn_.Enabled          = false;
				backBtn_.Enabled          = false;
				doneBtn_.Visible          = false;
				cancelBtn_.Visible        = true;
				browseCtrl_.Visible       = true;
				valuesCtrl_.Visible       = false;
				resultsCtrl_.Visible      = false;
				asyncResultsCtrl_.Visible = false;
				
				browseCtrl_.ClearSelection();
			}
		}
		#endregion

		/// <summary>
		/// Adds the current set of items to server.
		/// </summary>
		private void NextBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				// replace values.
				if (mValues_ != null)
				{
					DoReplace();
				}
				
				// read initial values.
				else
				{
					DoRead();
				}

				// update dialog state.
				SetState();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Removes the items and goes back to the select items view.
		/// </summary>
		private void BackBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				// discards any intermediate results.
				if (mAsyncSent_ || mResults_ != null)
				{
					UndoReplace();
				}
				else
				{
					UndoRead();
				}

				// update dialog state.
				SetState();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Toggles the state of the next button based on the current selection.
		/// </summary>
		private void BrowseCTRL_ItemSelected(OpcItem item)
		{
			mItem_ = item;
			nextBtn_.Enabled = item != null;
		}

		/// <summary>
		/// Activates the next button when an item is picked.
		/// </summary>
		private void BrowseCTRL_ItemPicked(OpcItem[] items)
		{
			if (items != null && items.Length == 1)
			{
				mItem_ = items[0];
				nextBtn_.Enabled = true;
				NextBTN_Click(browseCtrl_, null);
			}	
		}
	}
}

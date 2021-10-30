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
	public class DeleteValuesDlg : System.Windows.Forms.Form
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
		private ResultListCtrl resultsCtrl_;
		private ResultViewCtrl itemsCtrl_;
		private TrendItemsCtrl trendItemsCtrl_;
		private ResultListCtrl asyncResultsCtrl_;
		private TrendEditCtrl trendCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public DeleteValuesDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();
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
			this.splitterV_ = new System.Windows.Forms.Splitter();
			this.rightPn_ = new System.Windows.Forms.Panel();
			this.asyncResultsCtrl_ = new ResultListCtrl();
			this.resultsCtrl_ = new ResultListCtrl();
			this.trendItemsCtrl_ = new TrendItemsCtrl();
			this.browseCtrl_ = new BrowseTreeCtrl();
			this.leftPn_ = new System.Windows.Forms.Panel();
			this.itemsCtrl_ = new ResultViewCtrl();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.backBtn_ = new System.Windows.Forms.Button();
			this.nextBtn_ = new System.Windows.Forms.Button();
			this.doneBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.trendCtrl_ = new TrendEditCtrl();
			this.rightPn_.SuspendLayout();
			this.leftPn_.SuspendLayout();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// SplitterV
			// 
			this.splitterV_.Location = new System.Drawing.Point(328, 0);
			this.splitterV_.Name = "splitterV_";
			this.splitterV_.Size = new System.Drawing.Size(3, 386);
			this.splitterV_.TabIndex = 12;
			this.splitterV_.TabStop = false;
			// 
			// RightPN
			// 
			this.rightPn_.Controls.Add(this.asyncResultsCtrl_);
			this.rightPn_.Controls.Add(this.resultsCtrl_);
			this.rightPn_.Controls.Add(this.trendItemsCtrl_);
			this.rightPn_.Controls.Add(this.browseCtrl_);
			this.rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPn_.DockPadding.Right = 4;
			this.rightPn_.DockPadding.Top = 4;
			this.rightPn_.Location = new System.Drawing.Point(331, 0);
			this.rightPn_.Name = "rightPn_";
			this.rightPn_.Size = new System.Drawing.Size(605, 386);
			this.rightPn_.TabIndex = 13;
			// 
			// AsyncResultsCTRL
			// 
			this.asyncResultsCtrl_.AllowDrop = true;
			this.asyncResultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.asyncResultsCtrl_.Location = new System.Drawing.Point(0, 4);
			this.asyncResultsCtrl_.Name = "asyncResultsCtrl_";
			this.asyncResultsCtrl_.Size = new System.Drawing.Size(601, 382);
			this.asyncResultsCtrl_.TabIndex = 4;
			// 
			// ResultsCTRL
			// 
			this.resultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultsCtrl_.Location = new System.Drawing.Point(0, 4);
			this.resultsCtrl_.Name = "resultsCtrl_";
			this.resultsCtrl_.Size = new System.Drawing.Size(601, 382);
			this.resultsCtrl_.TabIndex = 2;
			// 
			// TrendItemsCTRL
			// 
			this.trendItemsCtrl_.AllowDrop = true;
			this.trendItemsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trendItemsCtrl_.Location = new System.Drawing.Point(0, 4);
			this.trendItemsCtrl_.Name = "trendItemsCtrl_";
			this.trendItemsCtrl_.Size = new System.Drawing.Size(601, 382);
			this.trendItemsCtrl_.TabIndex = 3;
			// 
			// BrowseCTRL
			// 
			this.browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browseCtrl_.Location = new System.Drawing.Point(0, 4);
			this.browseCtrl_.Name = "browseCtrl_";
			this.browseCtrl_.Size = new System.Drawing.Size(601, 382);
			this.browseCtrl_.TabIndex = 1;
			this.browseCtrl_.ItemSelected += new BrowseTreeCtrl.ItemSelectedEventHandler(this.BrowseCTRL_ItemSelected);
			this.browseCtrl_.ItemPicked += new BrowseTreeCtrl.ItemPickedEventHandler(this.BrowseCTRL_ItemPicked);
			// 
			// LeftPN
			// 
			this.leftPn_.Controls.Add(this.trendCtrl_);
			this.leftPn_.Controls.Add(this.itemsCtrl_);
			this.leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftPn_.DockPadding.Left = 4;
			this.leftPn_.DockPadding.Top = 4;
			this.leftPn_.Location = new System.Drawing.Point(0, 0);
			this.leftPn_.Name = "leftPn_";
			this.leftPn_.Size = new System.Drawing.Size(328, 386);
			this.leftPn_.TabIndex = 14;
			// 
			// ItemsCTRL
			// 
			this.itemsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsCtrl_.Location = new System.Drawing.Point(4, 4);
			this.itemsCtrl_.Name = "itemsCtrl_";
			this.itemsCtrl_.Size = new System.Drawing.Size(324, 382);
			this.itemsCtrl_.TabIndex = 4;
			this.itemsCtrl_.ResultSelected += new ResultViewCtrl.ResultSelectedEventHandler(this.ItemsCTRL_ResultSelected);
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.backBtn_);
			this.buttonsPn_.Controls.Add(this.nextBtn_);
			this.buttonsPn_.Controls.Add(this.doneBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 386);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(936, 36);
			this.buttonsPn_.TabIndex = 15;
			// 
			// BackBTN
			// 
			this.backBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.backBtn_.Location = new System.Drawing.Point(696, 8);
			this.backBtn_.Name = "backBtn_";
			this.backBtn_.TabIndex = 3;
			this.backBtn_.Text = "< Back";
			this.backBtn_.Click += new System.EventHandler(this.BackBTN_Click);
			// 
			// NextBTN
			// 
			this.nextBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nextBtn_.Location = new System.Drawing.Point(776, 8);
			this.nextBtn_.Name = "nextBtn_";
			this.nextBtn_.TabIndex = 2;
			this.nextBtn_.Text = "Next >";
			this.nextBtn_.Click += new System.EventHandler(this.NextBTN_Click);
			// 
			// DoneBTN
			// 
			this.doneBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.doneBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.doneBtn_.Location = new System.Drawing.Point(856, 8);
			this.doneBtn_.Name = "doneBtn_";
			this.doneBtn_.TabIndex = 0;
			this.doneBtn_.Text = "Done";
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(856, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 5;
			this.cancelBtn_.Text = "Cancel";
			// 
			// TrendCTRL
			// 
			this.trendCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trendCtrl_.Location = new System.Drawing.Point(4, 4);
			this.trendCtrl_.Name = "trendCtrl_";
			this.trendCtrl_.Size = new System.Drawing.Size(324, 382);
			this.trendCtrl_.TabIndex = 5;
			// 
			// DeleteValuesDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(936, 422);
			this.Controls.Add(this.rightPn_);
			this.Controls.Add(this.splitterV_);
			this.Controls.Add(this.leftPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "DeleteValuesDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Delete Values";
			this.rightPn_.ResumeLayout(false);
			this.leftPn_.ResumeLayout(false);
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region Public Interface	
		/// <summary>
		/// Prompts the user to select an item and specify trend properties.
		/// </summary>
		public TsCHdaResultCollection[] ShowDialog(TsCHdaServer server, RequestType type, bool synchronous)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_      = server;
			mType_        = type;
			mSynchronous_ = synchronous;
			mSingleItem_  = true;
			mResults_     = null;

			// create new trend.
			mTrend_ = new TsCHdaTrend(mServer_);

			// set reasonable defaults.
			mTrend_.StartTime = new TsCHdaTime("YEAR");
			mTrend_.EndTime   = new TsCHdaTime("YEAR+1H");

			browseCtrl_.Browse(mServer_, null);
			trendItemsCtrl_.Initialize(mTrend_, false, null);
			trendCtrl_.Initialize(mTrend_, type);
			itemsCtrl_.Initialize(null);
			resultsCtrl_.Initialize(mServer_, null);
			asyncResultsCtrl_.Initialize(mServer_, null);

			// update dialog state.
			SetState();

			// show dialog.
			bool result = (ShowDialog() == DialogResult.OK);

			// release item handles.
			mTrend_.ClearItems();

			// return item values.
			return mResults_;
		}

		/// <summary>
		/// Prompts the user to select trend items and specify trend properties.
		/// </summary>
		public TsCHdaResultCollection[] ShowDialog(TsCHdaTrend trend, RequestType type, bool synchronous)
		{
			if (trend == null) throw new ArgumentNullException("trend");

			mServer_      = trend.Server;
			mTrend_       = trend;
			mType_        = type;
			mSynchronous_ = synchronous;
			mSingleItem_  = false;
			mResults_     = null;

			browseCtrl_.Browse(mServer_, null);
			trendItemsCtrl_.Initialize(trend, false, null);
			trendCtrl_.Initialize(mTrend_, type);
			itemsCtrl_.Initialize(null);
			resultsCtrl_.Initialize(mServer_, null);

			// update dialog state.
			SetState();

			// show dialog.
			bool result = (ShowDialog() == DialogResult.OK);

			// return item values.
			return mResults_;
		}
		#endregion

		#region Private Members
		/// <summary>
		/// The historian database server.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// The trend used to delete the data.
		/// </summary>
		private TsCHdaTrend mTrend_ = null;

		/// <summary>
		/// The item to delete.
		/// </summary>
		private OpcItem mItem_ = null;
		
		/// <summary>
		/// The requst object for an asynchronous delete.
		/// </summary>
		private IOpcRequest mRequest_ = null;

		/// <summary>
		/// Whether an asynchronous request was sent (and possibly failed).
		/// </summary>
		private bool mAsyncSent_ = false;

		/// <summary>
		/// The set of items used in the request.
		/// </summary>
		private OpcItem[] mItems_ = null;

		/// <summary>
		/// The set of new items which will be added to the trend.
		/// </summary>
		private TsCHdaResultCollection[] mResults_ = null;

		/// <summary>
		/// Type of delete operation.
		/// </summary>
		private RequestType mType_ = RequestType.DeleteRaw;

		/// <summary>
		/// Whether to use synchronous or asynchronous reads.
		/// </summary>
		private bool mSynchronous_ = true;

		/// <summary>
		/// Whether only a single item is being delete.
		/// </summary>
		private bool mSingleItem_ = false;

		/// <summary>
		/// Synchronously eads the values from the server.
		/// </summary>
		private TsCHdaResultCollection[] SyncDelete(TsCHdaItem[] items)
		{
			// get request parameters from controls.
			trendCtrl_.Update(mTrend_);

			switch (mType_)
			{
				// synchronous delete raw.
				case RequestType.DeleteRaw:
				{
					OpcItemResult[] results = mTrend_.Delete(items);

					if (results != null)
					{
						TsCHdaResultCollection[] collections = new TsCHdaResultCollection[results.Length];

						for (int ii = 0; ii < results.Length; ii++)
						{
							collections[ii] = new TsCHdaResultCollection(results[ii]);
							collections[ii].Add(new TsCHdaResult(results[ii]));
						}

						return collections;
					}

					return null;
				}					

				// synchronous delete at time.
				case RequestType.DeleteAtTime:
				{
					return mTrend_.DeleteAtTime(items);
				}
			}

			return null;
		}

		/// <summary>
		/// Asynchronously eads the values from the server.
		/// </summary>
		private OpcItemResult[] AsyncDelete(TsCHdaItem[] items)
		{
			// get parameters from controls.
			trendCtrl_.Update(mTrend_);

			OpcItemResult[] results = null;

			switch (mType_)
			{
				// begin asynchronous delete raw.
				case RequestType.DeleteRaw:
				{
					results = mTrend_.Delete(
						items,
						null,
                        new TsCHdaUpdateCompleteEventHandler(OnDeleteComplete),
						out mRequest_);

					
					mItems_ = items;
					break;
				}					

				// begin asynchronous delete at time.
				case RequestType.DeleteAtTime:
				{	
					results = mTrend_.DeleteAtTime(
						items,
						null,
                        new TsCHdaUpdateCompleteEventHandler(OnDeleteComplete),
						out mRequest_);

					mItems_ = items;
					break;
				}			
			}

			return results;
		}

		/// <summary>
		/// Creates a server handle for the selected item and reads the data.
		/// </summary>
		private void DoItemDelete()
		{
			// create item (if necessary).
			TsCHdaItem item = mTrend_.Items[mItem_];

			if (item == null)
			{
				item = mTrend_.AddItem(mItem_);
			}

			if (mSynchronous_)
			{
				// delete data.
				TsCHdaResultCollection[] results = SyncDelete(new TsCHdaItem[] { item });
	
				if (results == null || results.Length != 1)
				{
					////throw new InvalidResponseException();
				}

				// display results.
				itemsCtrl_.Initialize(results);

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

				// begin delete data.
				OpcItemResult[] results = AsyncDelete(new TsCHdaItem[] { item });
	
				if (results == null || results.Length != 1)
				{
					////throw new InvalidResponseException();
				}

				// display initial results.
				asyncResultsCtrl_.Initialize(mServer_, results);
				mAsyncSent_ = true;
			}		
		}

		/// <summary>
		/// Creates reads the data for the selected items.
		/// </summary>
		private void DoTrendDelete()
		{
			TsCHdaItem[] items = trendItemsCtrl_.GetItems(false);

			if (items == null)
			{
				return;
			}

			if (mSynchronous_)
			{
				// delete data.
				TsCHdaResultCollection[] results = SyncDelete(items);
	
				if (results == null || results.Length != items.Length)
				{
					////throw new InvalidResponseException();
				}

				// display results.
				itemsCtrl_.Initialize(results);

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

				// begin delete data.
				OpcItemResult[] results = AsyncDelete(items);
	
				if (results == null || results.Length != items.Length)
				{
					////throw new InvalidResponseException();
				}

				// display initial results.
				asyncResultsCtrl_.Initialize(mServer_, results);			
				mAsyncSent_ = true;
			}		
		}

		/// <summary>
		/// Remove server handles for new items.
		/// </summary>
		private void UndoDelete()
		{
			mResults_   = null;
			mAsyncSent_ = false;
			mItems_     = null;

			if (mRequest_ != null)
			{
				mServer_.CancelRequest(mRequest_, new TsCHdaCancelCompleteEventHandler(OnCancelComplete));
				mRequest_ = null;
			}
		}

		/// <summary>
		/// Called when a delete request completes.
		/// </summary>
		public void OnDeleteComplete(IOpcRequest request, TsCHdaResultCollection[] results)
		{
			// check if dialog has closed.
			if (IsDisposed)
			{
				return;
			}

			// check if invoke is required.
			if (InvokeRequired)
			{
                BeginInvoke(new TsCHdaUpdateCompleteEventHandler(OnDeleteComplete), new object[] { request, results });
				return;
			}
						
			try
			{				
				// enable next button since first batch of results have arrived.
				itemsCtrl_.Initialize(results);
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

			MessageBox.Show("Asynchronous delete successfully cancelled.");
		}

		/// <summary>
		/// Toggle control visibility based on the dialog state.
		/// </summary>
		private void SetState()
		{
			if (mResults_ != null)
			{
				nextBtn_.Enabled          = false;
				backBtn_.Enabled          = true;
				doneBtn_.Visible          = true;
				cancelBtn_.Visible        = false;
				trendCtrl_.Visible        = false;
				browseCtrl_.Visible       = false;
				trendItemsCtrl_.Visible   = false;
				itemsCtrl_.Visible        = true;
				resultsCtrl_.Visible      = true;
				asyncResultsCtrl_.Visible = false;
			}
			else if (mAsyncSent_)
			{
				nextBtn_.Enabled          = mResults_ != null;
				backBtn_.Enabled          = true;
				doneBtn_.Visible          = false;
				cancelBtn_.Visible        = true;
				trendCtrl_.Visible        = true;
				browseCtrl_.Visible       = false;
				trendItemsCtrl_.Visible   = false;
				itemsCtrl_.Visible        = false;
				resultsCtrl_.Visible      = false;
				asyncResultsCtrl_.Visible = true;
			}
			else
			{
				nextBtn_.Enabled          = !mSingleItem_ || mType_ == RequestType.DeleteRaw;
				backBtn_.Enabled          = false;
				doneBtn_.Visible          = false;
				cancelBtn_.Visible        = true;
				trendCtrl_.Visible        = true;
				browseCtrl_.Visible       = mSingleItem_;
				trendItemsCtrl_.Visible   = !mSingleItem_;
				itemsCtrl_.Visible        = false;
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
				// do single item delete.
				if (mSingleItem_)
				{
					if (mItem_ == null)
					{
						return;
					}

					// delete values.
					DoItemDelete();
				}

				// do multiple item delete.
				else
				{
					// delete values.
					DoTrendDelete();
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
				// releases handles for items.
				UndoDelete();

				// display results.
				itemsCtrl_.Initialize(null);
				resultsCtrl_.Initialize(mServer_, null);

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

		/// <summary>
		/// Display the current selection in the result control.
		/// </summary>
		private void ItemsCTRL_ResultSelected(OpcItem result)
		{
			if (typeof(TsCHdaResultCollection).IsInstanceOfType(result))
			{
				if (mType_ == RequestType.DeleteAtTime)
				{
					resultsCtrl_.Initialize(mServer_, mTrend_.Timestamps, new TsCHdaResultCollection[] { (TsCHdaResultCollection)result });
				}
				else
				{
					resultsCtrl_.Initialize(mServer_, (TsCHdaItemTimeCollection)null, new TsCHdaResultCollection[] { (TsCHdaResultCollection)result });
				}
			}
		}
	}
}

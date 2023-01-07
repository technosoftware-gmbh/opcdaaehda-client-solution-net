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
using SampleClients.Hda.Common;
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
	public class ReadAttributesDlg : System.Windows.Forms.Form
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
		private AttributesViewCtrl resultsCtrl_;
		private AttributesSelectCtrl attributesCtrl_;
		private ResultListCtrl asyncResultsCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ReadAttributesDlg()
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
			browseCtrl_ = new BrowseTreeCtrl();
			attributesCtrl_ = new AttributesSelectCtrl();
			resultsCtrl_ = new AttributesViewCtrl();
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
			splitterV_.Location = new System.Drawing.Point(328, 0);
			splitterV_.Name = "splitterV_";
			splitterV_.Size = new System.Drawing.Size(3, 386);
			splitterV_.TabIndex = 12;
			splitterV_.TabStop = false;
			// 
			// RightPN
			// 
			rightPn_.Controls.Add(asyncResultsCtrl_);
			rightPn_.Controls.Add(browseCtrl_);
			rightPn_.Controls.Add(attributesCtrl_);
			rightPn_.Controls.Add(resultsCtrl_);
			rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			rightPn_.DockPadding.Right = 4;
			rightPn_.DockPadding.Top = 4;
			rightPn_.Location = new System.Drawing.Point(331, 0);
			rightPn_.Name = "rightPn_";
			rightPn_.Size = new System.Drawing.Size(605, 386);
			rightPn_.TabIndex = 13;
			// 
			// BrowseCTRL
			// 
			browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			browseCtrl_.Location = new System.Drawing.Point(0, 4);
			browseCtrl_.Name = "browseCtrl_";
			browseCtrl_.Size = new System.Drawing.Size(601, 382);
			browseCtrl_.TabIndex = 1;
			browseCtrl_.ItemSelected += new BrowseTreeCtrl.ItemSelectedEventHandler(BrowseCTRL_ItemSelected);
			browseCtrl_.ItemPicked += new BrowseTreeCtrl.ItemPickedEventHandler(BrowseCTRL_ItemPicked);
			// 
			// AttributesCTRL
			// 
			attributesCtrl_.AllowDrop = true;
			attributesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			attributesCtrl_.Location = new System.Drawing.Point(0, 4);
			attributesCtrl_.Name = "attributesCtrl_";
			attributesCtrl_.ReadOnly = false;
			attributesCtrl_.Size = new System.Drawing.Size(601, 382);
			attributesCtrl_.TabIndex = 5;
			// 
			// ResultsCTRL
			// 
			resultsCtrl_.AllowDrop = true;
			resultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			resultsCtrl_.Location = new System.Drawing.Point(0, 4);
			resultsCtrl_.Name = "resultsCtrl_";
			resultsCtrl_.Size = new System.Drawing.Size(601, 382);
			resultsCtrl_.TabIndex = 4;
			// 
			// LeftPN
			// 
			leftPn_.Controls.Add(trendCtrl_);
			leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			leftPn_.DockPadding.Left = 4;
			leftPn_.DockPadding.Top = 4;
			leftPn_.Location = new System.Drawing.Point(0, 0);
			leftPn_.Name = "leftPn_";
			leftPn_.Size = new System.Drawing.Size(328, 386);
			leftPn_.TabIndex = 14;
			// 
			// TrendCTRL
			// 
			trendCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			trendCtrl_.Location = new System.Drawing.Point(4, 4);
			trendCtrl_.Name = "trendCtrl_";
			trendCtrl_.RequestType = RequestType.ReadRaw;
			trendCtrl_.Size = new System.Drawing.Size(324, 382);
			trendCtrl_.TabIndex = 3;
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
			buttonsPn_.Size = new System.Drawing.Size(936, 36);
			buttonsPn_.TabIndex = 15;
			// 
			// BackBTN
			// 
			backBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			backBtn_.Location = new System.Drawing.Point(696, 8);
			backBtn_.Name = "backBtn_";
			backBtn_.TabIndex = 3;
			backBtn_.Text = "< Back";
			backBtn_.Click += new System.EventHandler(BackBTN_Click);
			// 
			// NextBTN
			// 
			nextBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			nextBtn_.Location = new System.Drawing.Point(776, 8);
			nextBtn_.Name = "nextBtn_";
			nextBtn_.TabIndex = 2;
			nextBtn_.Text = "Next >";
			nextBtn_.Click += new System.EventHandler(NextBTN_Click);
			// 
			// DoneBTN
			// 
			doneBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			doneBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			doneBtn_.Location = new System.Drawing.Point(856, 8);
			doneBtn_.Name = "doneBtn_";
			doneBtn_.TabIndex = 0;
			doneBtn_.Text = "Done";
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(856, 8);
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
			asyncResultsCtrl_.Size = new System.Drawing.Size(601, 382);
			asyncResultsCtrl_.TabIndex = 6;
			// 
			// ReadAttributesDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(936, 422);
			Controls.Add(rightPn_);
			Controls.Add(splitterV_);
			Controls.Add(leftPn_);
			Controls.Add(buttonsPn_);
			Name = "ReadAttributesDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Read Attributes";
			rightPn_.ResumeLayout(false);
			leftPn_.ResumeLayout(false);
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion
		
		#region Public Interface
		/// <summary>
		/// Prompts the user to select an item and specify trend properties.
		/// </summary>
		public TsCHdaItemAttributeCollection ShowDialog(TsCHdaServer server, bool synchronous)
		{
			return ShowDialog(server, null, new TsCHdaTime("NOW"), null, synchronous);
		}

		/// <summary>
		/// Prompts the user to select attributes to read for an item.
		/// </summary>
		public TsCHdaItemAttributeCollection ShowDialog(
			TsCHdaServer server, 
			OpcItem      item,
			TsCHdaTime           startTime,
			TsCHdaTime           endTime,
			bool           synchronous)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_      = server;
			mItem_        = item;
			mFixedItem_   = item != null;
			mSynchronous_ = synchronous;
			mResults_     = null;

			// create new trend.
			mTrend_ = new TsCHdaTrend(mServer_);

			// set reasonable defaults.
			mTrend_.StartTime = startTime;
			mTrend_.EndTime   = endTime;

			browseCtrl_.Browse(mServer_, null);
			trendCtrl_.Initialize(mTrend_, RequestType.ReadAttributes);
			attributesCtrl_.Initialize(mServer_, null);
			resultsCtrl_.Initialize(mServer_, mResults_);
			asyncResultsCtrl_.Initialize(mServer_, null);

			// update dialog state.
			SetState();

			// show dialog.
			bool result = (ShowDialog() == DialogResult.OK);

			// release item handles.
			mTrend_.ClearItems();

			// return item values.
			return (result)?mResults_:null;
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
		/// Whether to use synchronous or asynchronous reads.
		/// </summary>
		private bool mSynchronous_ = true;

		/// <summary>
		/// The item to read.
		/// </summary>
		private OpcItem mItem_ = null;

		/// <summary>
		/// The set of attribute ids which should be read.
		/// </summary>
		private int[] mAttributeIDs_ = null;

		/// <summary>
		/// The requst object for an asynchronous read.
		/// </summary>
		private IOpcRequest mRequest_ = null;

		/// <summary>
		/// Whether an asynchronous request was sent (and possibly failed).
		/// </summary>
		private bool mAsyncSent_ = false;

		/// <summary>
		/// The set of new items which will be added to the trend.
		/// </summary>
		private TsCHdaItemAttributeCollection mResults_ = null;

		/// <summary>
		/// Whether only a single item is being read.
		/// </summary>
		private bool mFixedItem_ = false;

		/// <summary>
		/// Creates a server handle for the selected item and reads the data.
		/// </summary>
		private void DoItemRead()
		{
			// get the attribute ids.
			if (mAttributeIDs_ == null)
			{
				mAttributeIDs_ = attributesCtrl_.GetAttributeIDs(true);
				return;
			}

			// create item (if necessary).
			TsCHdaItem item = mTrend_.Items[mItem_];

			if (item == null)
			{
				item = mTrend_.AddItem(mItem_);
			}

			// get the paramaters.
			trendCtrl_.Update(mTrend_);
			
			// get the attributes.
			mAttributeIDs_ = attributesCtrl_.GetAttributeIDs(true);

			if (mSynchronous_)
			{
				// read data.
				TsCHdaItemAttributeCollection results = mTrend_.ReadAttributes(item, mAttributeIDs_);

				if (results == null || results.Count != mAttributeIDs_.Length)
				{
					////throw new InvalidResponseException();
				}

				// display results.
				resultsCtrl_.Initialize(mServer_, results);

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

				// begin read data.
				TsCHdaResultCollection results = mTrend_.ReadAttributes(
					item,
					mAttributeIDs_,
					null,
					new TsCHdaReadAttributesCompleteEventHandler(OnReadComplete),
					out mRequest_);

				if (results == null || results.Count != mAttributeIDs_.Length)
				{
					////throw new InvalidResponseException();
				}

				// display initial results.
				asyncResultsCtrl_.Initialize(mServer_, mAttributeIDs_, results);
				mAsyncSent_ = true;
			}	
		}

		/// <summary>
		/// Remove server handles for new items.
		/// </summary>
		private void UndoRead()
		{
			mResults_   = null;
			mAsyncSent_ = false;

			if (mRequest_ != null)
			{
				mServer_.CancelRequest(mRequest_, new TsCHdaCancelCompleteEventHandler(OnCancelComplete));
				mRequest_ = null;
			}

			if (!mFixedItem_)
			{
				mAttributeIDs_ = null;
				mItem_ = null;
			}
		}

		/// <summary>
		/// Called when a read request completes.
		/// </summary>
		public void OnReadComplete(IOpcRequest request, TsCHdaItemAttributeCollection results)
		{
			// check if dialog has closed.
			if (IsDisposed)
			{
				return;
			}

			// check if invoke is required.
			if (InvokeRequired)
			{
				BeginInvoke(new TsCHdaReadAttributesCompleteEventHandler(OnReadComplete), new object[] { request, results });
				return;
			}
			
			try
			{				
				// enable next button since first batch of results have arrived.
				resultsCtrl_.Initialize(mServer_, results);
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

			MessageBox.Show("Asynchronous read successfully cancelled.");
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
				trendCtrl_.Visible        = true;
				browseCtrl_.Visible       = false;
				attributesCtrl_.Visible   = false;
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
				attributesCtrl_.Visible   = false;
				resultsCtrl_.Visible      = false;
				asyncResultsCtrl_.Visible = true;
			}
			else
			{
				nextBtn_.Enabled          = mItem_ != null;
				backBtn_.Enabled          = mItem_ != null && !mFixedItem_;
				doneBtn_.Visible          = false;
				cancelBtn_.Visible        = true;
				trendCtrl_.Visible        = true;
				browseCtrl_.Visible       = mItem_ == null;
				attributesCtrl_.Visible   = mItem_ != null;
				resultsCtrl_.Visible      = mItem_ != null;
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
				if (mItem_ == null)
				{
					return;
				}

				// read values.
				DoItemRead();

				// display results.
				resultsCtrl_.Initialize(mServer_, mResults_);

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
				UndoRead();

				// display results.
				resultsCtrl_.Initialize(mServer_, mResults_);

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

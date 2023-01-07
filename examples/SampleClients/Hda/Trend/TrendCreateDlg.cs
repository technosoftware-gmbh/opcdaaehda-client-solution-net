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

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;

using BrowseTreeCtrl = SampleClients.Hda.Server.BrowseTreeCtrl;

#endregion

namespace SampleClients.Hda.Trend
{
	/// <summary>
	/// Summary description for ItemAddDlg.
	/// </summary>
	public class TrendCreateDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Splitter splitterV_;
		private System.Windows.Forms.Panel rightPn_;
		private ItemListCtrl itemsCtrl_;
		private System.Windows.Forms.Panel leftPn_;
		private BrowseTreeCtrl browseCtrl_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button backBtn_;
		private System.Windows.Forms.Button nextBtn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button doneBtn_;
		private ResultListCtrl resultsCtrl_;
		private TrendEditCtrl trendCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public TrendCreateDlg()
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
			resultsCtrl_ = new ResultListCtrl();
			itemsCtrl_ = new ItemListCtrl();
			leftPn_ = new System.Windows.Forms.Panel();
			trendCtrl_ = new TrendEditCtrl();
			browseCtrl_ = new BrowseTreeCtrl();
			buttonsPn_ = new System.Windows.Forms.Panel();
			backBtn_ = new System.Windows.Forms.Button();
			nextBtn_ = new System.Windows.Forms.Button();
			doneBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
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
			rightPn_.Controls.Add(resultsCtrl_);
			rightPn_.Controls.Add(itemsCtrl_);
			rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			rightPn_.DockPadding.Right = 4;
			rightPn_.DockPadding.Top = 4;
			rightPn_.Location = new System.Drawing.Point(363, 0);
			rightPn_.Name = "rightPn_";
			rightPn_.Size = new System.Drawing.Size(509, 386);
			rightPn_.TabIndex = 13;
			// 
			// ResultsCTRL
			// 
			resultsCtrl_.AllowDrop = true;
			resultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			resultsCtrl_.Location = new System.Drawing.Point(0, 4);
			resultsCtrl_.Name = "resultsCtrl_";
			resultsCtrl_.Size = new System.Drawing.Size(505, 382);
			resultsCtrl_.TabIndex = 1;
			// 
			// ItemsCTRL
			// 
			itemsCtrl_.AllowDrop = true;
			itemsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			itemsCtrl_.Location = new System.Drawing.Point(0, 4);
			itemsCtrl_.Name = "itemsCtrl_";
			itemsCtrl_.Size = new System.Drawing.Size(505, 382);
			itemsCtrl_.TabIndex = 0;
			// 
			// LeftPN
			// 
			leftPn_.Controls.Add(browseCtrl_);
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
			trendCtrl_.Size = new System.Drawing.Size(356, 382);
			trendCtrl_.TabIndex = 2;
			// 
			// BrowseCTRL
			// 
			browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			browseCtrl_.Location = new System.Drawing.Point(4, 4);
			browseCtrl_.Name = "browseCtrl_";
			browseCtrl_.Size = new System.Drawing.Size(356, 382);
			browseCtrl_.TabIndex = 1;
			browseCtrl_.ItemPicked += new BrowseTreeCtrl.ItemPickedEventHandler(BrowseCTRL_ItemPicked);
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
			// TrendCreateDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(872, 422);
			Controls.Add(rightPn_);
			Controls.Add(splitterV_);
			Controls.Add(leftPn_);
			Controls.Add(buttonsPn_);
			Name = "TrendCreateDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Create Trend";
			rightPn_.ResumeLayout(false);
			leftPn_.ResumeLayout(false);
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion
		
		/// <summary>
		/// The historian database server.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// The set of new items which will be added to the trend.
		/// </summary>
		private OpcItemResult[] mResults_ = null;

		/// <summary>
		/// Prompts the user to select items and specify trend properties.
		/// </summary>
		public TsCHdaTrend ShowDialog(TsCHdaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_  = server;
			mResults_ = null;

			// create new trend.
			TsCHdaTrend trend = new TsCHdaTrend(mServer_);

			// set reasonable defaults.
			trend.StartTime = new TsCHdaTime("YEAR");
			trend.EndTime   = new TsCHdaTime("YEAR+1H");

			browseCtrl_.Browse(mServer_, null);
			trendCtrl_.Initialize(trend, RequestType.None);
			itemsCtrl_.Initialize(mServer_, (OpcItem[])null);
			resultsCtrl_.Initialize(mServer_, mResults_);

			// update dialog state.
			SetState(false);

			// show dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// create or update the trend.
			trendCtrl_.Update(trend);

			// add new items.
			if (mResults_ != null)
			{
				foreach (OpcItemResult item in mResults_)
				{
					if (item.Result.Succeeded())
					{
						trend.Items.Add(new TsCHdaItem(item));
					}
				}
			}

			// return new trend.
			return trend;
		}

		/// <summary>
		/// Prompts the user to select items and specify trend properties.
		/// </summary>
		public OpcItem[] ShowDialog(TsCHdaTrend trend)
		{
			if (trend == null) throw new ArgumentNullException("trend");

			mServer_  = trend.Server;
			mResults_ = null;

			browseCtrl_.Browse(mServer_, null);
			trendCtrl_.Initialize(trend, RequestType.None);
			itemsCtrl_.Initialize(mServer_, (OpcItem[])null);
			resultsCtrl_.Initialize(mServer_, mResults_);

			// update dialog state.
			SetState(false);

			// show dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// create or update the trend.
			trendCtrl_.Update(trend);

			// add new items.
			if (mResults_ != null)
			{
				foreach (OpcItemResult item in mResults_)
				{
					if (item.Result.Succeeded())
					{
						trend.Items.Add(new TsCHdaItem(item));
					}
				}
			}

			// return new items
			return mResults_;
		}

		#region Private Methods
		/// <summary>
		/// Create server handles for new items.
		/// </summary>
		private void DoAddItems()
		{
			// get set of items from control.
			OpcItem[] items = itemsCtrl_.GetItemIDs(false);

			if (items == null)
			{
				return;
			}

			// assign unique client handles.
			foreach (OpcItem item in items)
			{
				item.ClientHandle = Guid.NewGuid().ToString();
			}

			// create item handles on server.
			mResults_ = mServer_.CreateItems(items);
		}

		/// <summary>
		/// Remove server handles for new items.
		/// </summary>
		private void UndoAddItems()
		{
			if (mResults_ != null)
			{
				mServer_.ReleaseItems(mResults_);
			}

			mResults_ = null;
		}

		/// <summary>
		/// Toggle control visibility based on the dialog state.
		/// </summary>
		private void SetState(bool done)
		{
			nextBtn_.Enabled     = !done;
			backBtn_.Enabled     = done;
			doneBtn_.Visible     = done;
			cancelBtn_.Visible   = !done;
			browseCtrl_.Visible  = !done;
			trendCtrl_.Visible   = done;
			itemsCtrl_.Visible   = !done;
			resultsCtrl_.Visible = done;
		}
		#endregion

		/// <summary>
		/// Adds the current set of items to server.
		/// </summary>
		private void NextBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				// create handles for items.
				DoAddItems();

				// display results.
				resultsCtrl_.Initialize(mServer_, mResults_);

				// update dialog state.
				SetState(true);
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
				UndoAddItems();

				// display results.
				resultsCtrl_.Initialize(mServer_, mResults_);

				// update dialog state.
				SetState(false);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Called when an item is picked in the browse control.
		/// </summary>
		private void BrowseCTRL_ItemPicked(OpcItem[] items)
		{
			try
			{	
				itemsCtrl_.AddItems(items);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}

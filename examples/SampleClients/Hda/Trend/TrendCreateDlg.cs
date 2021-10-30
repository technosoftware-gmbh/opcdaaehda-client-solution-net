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
			this.resultsCtrl_ = new ResultListCtrl();
			this.itemsCtrl_ = new ItemListCtrl();
			this.leftPn_ = new System.Windows.Forms.Panel();
			this.trendCtrl_ = new TrendEditCtrl();
			this.browseCtrl_ = new BrowseTreeCtrl();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.backBtn_ = new System.Windows.Forms.Button();
			this.nextBtn_ = new System.Windows.Forms.Button();
			this.doneBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.rightPn_.SuspendLayout();
			this.leftPn_.SuspendLayout();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// SplitterV
			// 
			this.splitterV_.Location = new System.Drawing.Point(360, 0);
			this.splitterV_.Name = "splitterV_";
			this.splitterV_.Size = new System.Drawing.Size(3, 386);
			this.splitterV_.TabIndex = 12;
			this.splitterV_.TabStop = false;
			// 
			// RightPN
			// 
			this.rightPn_.Controls.Add(this.resultsCtrl_);
			this.rightPn_.Controls.Add(this.itemsCtrl_);
			this.rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPn_.DockPadding.Right = 4;
			this.rightPn_.DockPadding.Top = 4;
			this.rightPn_.Location = new System.Drawing.Point(363, 0);
			this.rightPn_.Name = "rightPn_";
			this.rightPn_.Size = new System.Drawing.Size(509, 386);
			this.rightPn_.TabIndex = 13;
			// 
			// ResultsCTRL
			// 
			this.resultsCtrl_.AllowDrop = true;
			this.resultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultsCtrl_.Location = new System.Drawing.Point(0, 4);
			this.resultsCtrl_.Name = "resultsCtrl_";
			this.resultsCtrl_.Size = new System.Drawing.Size(505, 382);
			this.resultsCtrl_.TabIndex = 1;
			// 
			// ItemsCTRL
			// 
			this.itemsCtrl_.AllowDrop = true;
			this.itemsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsCtrl_.Location = new System.Drawing.Point(0, 4);
			this.itemsCtrl_.Name = "itemsCtrl_";
			this.itemsCtrl_.Size = new System.Drawing.Size(505, 382);
			this.itemsCtrl_.TabIndex = 0;
			// 
			// LeftPN
			// 
			this.leftPn_.Controls.Add(this.browseCtrl_);
			this.leftPn_.Controls.Add(this.trendCtrl_);
			this.leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftPn_.DockPadding.Left = 4;
			this.leftPn_.DockPadding.Top = 4;
			this.leftPn_.Location = new System.Drawing.Point(0, 0);
			this.leftPn_.Name = "leftPn_";
			this.leftPn_.Size = new System.Drawing.Size(360, 386);
			this.leftPn_.TabIndex = 14;
			// 
			// TrendCTRL
			// 
			this.trendCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trendCtrl_.Location = new System.Drawing.Point(4, 4);
			this.trendCtrl_.Name = "trendCtrl_";
			this.trendCtrl_.Size = new System.Drawing.Size(356, 382);
			this.trendCtrl_.TabIndex = 2;
			// 
			// BrowseCTRL
			// 
			this.browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browseCtrl_.Location = new System.Drawing.Point(4, 4);
			this.browseCtrl_.Name = "browseCtrl_";
			this.browseCtrl_.Size = new System.Drawing.Size(356, 382);
			this.browseCtrl_.TabIndex = 1;
			this.browseCtrl_.ItemPicked += new BrowseTreeCtrl.ItemPickedEventHandler(this.BrowseCTRL_ItemPicked);
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
			this.buttonsPn_.Size = new System.Drawing.Size(872, 36);
			this.buttonsPn_.TabIndex = 15;
			// 
			// BackBTN
			// 
			this.backBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.backBtn_.Location = new System.Drawing.Point(632, 8);
			this.backBtn_.Name = "backBtn_";
			this.backBtn_.TabIndex = 3;
			this.backBtn_.Text = "< Back";
			this.backBtn_.Click += new System.EventHandler(this.BackBTN_Click);
			// 
			// NextBTN
			// 
			this.nextBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nextBtn_.Location = new System.Drawing.Point(712, 8);
			this.nextBtn_.Name = "nextBtn_";
			this.nextBtn_.TabIndex = 2;
			this.nextBtn_.Text = "Next >";
			this.nextBtn_.Click += new System.EventHandler(this.NextBTN_Click);
			// 
			// DoneBTN
			// 
			this.doneBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.doneBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.doneBtn_.Location = new System.Drawing.Point(792, 8);
			this.doneBtn_.Name = "doneBtn_";
			this.doneBtn_.TabIndex = 0;
			this.doneBtn_.Text = "Done";
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(792, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 5;
			this.cancelBtn_.Text = "Cancel";
			// 
			// TrendCreateDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(872, 422);
			this.Controls.Add(this.rightPn_);
			this.Controls.Add(this.splitterV_);
			this.Controls.Add(this.leftPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "TrendCreateDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create Trend";
			this.rightPn_.ResumeLayout(false);
			this.leftPn_.ResumeLayout(false);
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

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

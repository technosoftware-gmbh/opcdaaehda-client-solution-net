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

using SampleClients.Da.Browse;
using SampleClients.Da.Item;
using SampleClients.Da.Subscription;

using Technosoftware.DaAeHdaClient;
using SampleClients.Common;
using Technosoftware.DaAeHdaClient.Da;

using BrowseTreeCtrl = SampleClients.Da.Browse.BrowseTreeCtrl;

#endregion

namespace SampleClients.Da
{
    /// <summary>
    /// A dialog used select items for a read request and then display the results.
    /// </summary>
    public class ReadItemsDlg : System.Windows.Forms.Form
	{
		private BrowseTreeCtrl browseCtrl_;
		private ItemListEditCtrl itemsCtrl_;
		private ResultListViewCtrl resultsCtrl_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button backBtn_;
		private System.Windows.Forms.Button nextBtn_;
		private System.Windows.Forms.Button doneBtn_;
		private System.Windows.Forms.Panel leftPn_;
		private System.Windows.Forms.Panel rightPn_;
		private SubscriptionsTreeCtrl subscriptionCtrl_;
		private System.Windows.Forms.Splitter splitterV_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button optionsBtn_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ReadItemsDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			itemsCtrl_.IsReadItem = true;

			browseCtrl_.ItemPicked += new ItemPickedEventHandler(OnItemPicked);
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
			this.browseCtrl_ = new BrowseTreeCtrl();
			this.itemsCtrl_ = new ItemListEditCtrl();
			this.leftPn_ = new System.Windows.Forms.Panel();
			this.subscriptionCtrl_ = new SubscriptionsTreeCtrl();
			this.rightPn_ = new System.Windows.Forms.Panel();
			this.resultsCtrl_ = new ResultListViewCtrl();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.optionsBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.backBtn_ = new System.Windows.Forms.Button();
			this.nextBtn_ = new System.Windows.Forms.Button();
			this.doneBtn_ = new System.Windows.Forms.Button();
			this.splitterV_ = new System.Windows.Forms.Splitter();
			this.leftPn_.SuspendLayout();
			this.rightPn_.SuspendLayout();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// BrowseCTRL
			// 
			this.browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browseCtrl_.Location = new System.Drawing.Point(4, 4);
			this.browseCtrl_.Name = "browseCtrl_";
			this.browseCtrl_.Size = new System.Drawing.Size(246, 296);
			this.browseCtrl_.TabIndex = 1;
			// 
			// ItemsCTRL
			// 
			this.itemsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsCtrl_.Location = new System.Drawing.Point(0, 4);
			this.itemsCtrl_.Name = "itemsCtrl_";
			this.itemsCtrl_.Size = new System.Drawing.Size(534, 296);
			this.itemsCtrl_.TabIndex = 2;
			// 
			// LeftPN
			// 
			this.leftPn_.Controls.Add(this.subscriptionCtrl_);
			this.leftPn_.Controls.Add(this.browseCtrl_);
			this.leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftPn_.DockPadding.Left = 4;
			this.leftPn_.DockPadding.Top = 4;
			this.leftPn_.Location = new System.Drawing.Point(0, 0);
			this.leftPn_.Name = "leftPn_";
			this.leftPn_.Size = new System.Drawing.Size(250, 300);
			this.leftPn_.TabIndex = 6;
			// 
			// SubscriptionCTRL
			// 
			this.subscriptionCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.subscriptionCtrl_.Location = new System.Drawing.Point(4, 4);
			this.subscriptionCtrl_.Name = "subscriptionCtrl_";
			this.subscriptionCtrl_.Size = new System.Drawing.Size(246, 296);
			this.subscriptionCtrl_.TabIndex = 7;
			// 
			// RightPN
			// 
			this.rightPn_.Controls.Add(this.resultsCtrl_);
			this.rightPn_.Controls.Add(this.itemsCtrl_);
			this.rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPn_.DockPadding.Right = 4;
			this.rightPn_.DockPadding.Top = 4;
			this.rightPn_.Location = new System.Drawing.Point(254, 0);
			this.rightPn_.Name = "rightPn_";
			this.rightPn_.Size = new System.Drawing.Size(538, 300);
			this.rightPn_.TabIndex = 8;
			// 
			// ResultsCTRL
			// 
			this.resultsCtrl_.AllowDrop = true;
			this.resultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultsCtrl_.Location = new System.Drawing.Point(0, 4);
			this.resultsCtrl_.Name = "resultsCtrl_";
			this.resultsCtrl_.Size = new System.Drawing.Size(534, 296);
			this.resultsCtrl_.TabIndex = 0;
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.optionsBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Controls.Add(this.backBtn_);
			this.buttonsPn_.Controls.Add(this.nextBtn_);
			this.buttonsPn_.Controls.Add(this.doneBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 300);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(792, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// OptionsBTN
			// 
			this.optionsBtn_.Location = new System.Drawing.Point(5, 8);
			this.optionsBtn_.Name = "optionsBtn_";
			this.optionsBtn_.TabIndex = 6;
			this.optionsBtn_.Text = "Options...";
			this.optionsBtn_.Click += new System.EventHandler(this.OptionsBTN_Click);
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(712, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 5;
			this.cancelBtn_.Text = "Cancel";
			this.cancelBtn_.Click += new System.EventHandler(this.DoneBTN_Click);
			// 
			// BackBTN
			// 
			this.backBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.backBtn_.Location = new System.Drawing.Point(552, 8);
			this.backBtn_.Name = "backBtn_";
			this.backBtn_.TabIndex = 3;
			this.backBtn_.Text = "< Back";
			this.backBtn_.Click += new System.EventHandler(this.BackBTN_Click);
			// 
			// NextBTN
			// 
			this.nextBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nextBtn_.Location = new System.Drawing.Point(632, 8);
			this.nextBtn_.Name = "nextBtn_";
			this.nextBtn_.TabIndex = 2;
			this.nextBtn_.Text = "Next >";
			this.nextBtn_.Click += new System.EventHandler(this.NextBTN_Click);
			// 
			// DoneBTN
			// 
			this.doneBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.doneBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.doneBtn_.Location = new System.Drawing.Point(712, 8);
			this.doneBtn_.Name = "doneBtn_";
			this.doneBtn_.TabIndex = 0;
			this.doneBtn_.Text = "Done";
			this.doneBtn_.Click += new System.EventHandler(this.DoneBTN_Click);
			// 
			// SplitterV
			// 
			this.splitterV_.Location = new System.Drawing.Point(250, 0);
			this.splitterV_.Name = "splitterV_";
			this.splitterV_.Size = new System.Drawing.Size(4, 300);
			this.splitterV_.TabIndex = 9;
			this.splitterV_.TabStop = false;
			// 
			// ReadItemsDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 336);
			this.Controls.Add(this.rightPn_);
			this.Controls.Add(this.splitterV_);
			this.Controls.Add(this.leftPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "ReadItemsDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Read Items";
			this.leftPn_.ResumeLayout(false);
			this.rightPn_.ResumeLayout(false);
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The server used to process read request.
		/// </summary>
		private TsCDaServer mServer_ = null;

		/// <summary>
		/// The subscription used to process read request.
		/// </summary>
		private TsCDaSubscription mSubscription_ = null;
		
		/// <summary>
		/// Whether to use asynchronous read operations. 
		/// </summary>
		private bool mSynchronous_ = true;

		/// <summary>
		/// The set of values returned from the server.
		/// </summary>
		private TsCDaItemValueResult[] mValues_ = null;
		
		/// <summary>
		/// Prompts the use to select items for the read request.
		/// </summary>
		public TsCDaItemValueResult[] ShowDialog(TsCDaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_       = server;
			mSubscription_ = null;

			backBtn_.Enabled          = false;
			nextBtn_.Enabled          = true;
			cancelBtn_.Visible        = true;
			doneBtn_.Visible          = false;
			browseCtrl_.Visible       = true;
			subscriptionCtrl_.Visible = false;
			itemsCtrl_.Visible        = true;
			resultsCtrl_.Visible      = false;

			browseCtrl_.ShowSingleServer(mServer_, null);
			itemsCtrl_.Initialize((TsCDaItem)null);

			ShowDialog();

			// ensure server connection in the browse control are closed.
			browseCtrl_.Clear();

			return mValues_;
		}

		/// <summary>
		/// Prompts the use to select items for the read request.
		/// </summary>
		public TsCDaItemValueResult[] ShowDialog(TsCDaSubscription subscription, bool synchronous)
		{
			if (subscription == null) throw new ArgumentNullException("subscription");

			mServer_       = subscription.Server;
			mSubscription_ = subscription;
			mSynchronous_  = synchronous;

			backBtn_.Enabled          = false;
			nextBtn_.Enabled          = true;
			cancelBtn_.Visible        = true;
			doneBtn_.Visible          = false;
			optionsBtn_.Visible       = true;
			browseCtrl_.Visible       = false;
			subscriptionCtrl_.Visible = true;
			itemsCtrl_.Visible        = true;
			resultsCtrl_.Visible      = false;

			subscriptionCtrl_.Initialize(mSubscription_);
			itemsCtrl_.Initialize(null, mSubscription_.Items);

			ShowDialog();

			return mValues_;
		}

		/// <summary>
		/// Executes a  read request for the current set if items.
		/// </summary>
		public void DoRead()
		{
			try
			{	
				// read from server.
				TsCDaItem[] items = itemsCtrl_.GetItems();

				TsCDaItemValueResult[] results  = null;

				if (mSubscription_ != null)
				{
					if (mSynchronous_)
					{
						results = mSubscription_.Read(items);
					}
					else
					{
						results = new AsyncRequestDlg().ShowDialog(mSubscription_, items);

						if (results == null)
						{
							return;
						}
					}
				}
				else
				{
					// add dummy client handles to test that they get returned properly.
					foreach(TsCDaItem item in items) { item.ClientHandle = item.ItemName; }

					results = mServer_.Read(items);
				}

				// save results.
				mValues_ = results;

				backBtn_.Enabled     = true;
				nextBtn_.Enabled     = false;
				cancelBtn_.Visible   = false;
				doneBtn_.Visible     = true;
				optionsBtn_.Visible  = false;
				itemsCtrl_.Visible   = false;
				resultsCtrl_.Visible = true;

				// display results.
				resultsCtrl_.Initialize(mServer_, (mSubscription_ != null)?mSubscription_.Locale:mServer_.Locale, results);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Discards any results from a read request.
		/// </summary>
		public void UndoRead()
		{
			// clear the previously read results.
			mValues_ = null;
			
			backBtn_.Enabled     = false;
			nextBtn_.Enabled     = true;
			cancelBtn_.Visible   = true;
			doneBtn_.Visible     = false;
			optionsBtn_.Visible  = true;
			itemsCtrl_.Visible   = true;
			resultsCtrl_.Visible = false;
		}
		
		/// <summary>
		/// Called when a server is picked in the browse control.
		/// </summary>
		private void OnItemPicked(OpcItem itemId)
		{
			itemsCtrl_.AddItem(new TsCDaItem(itemId));
		}

		/// <summary>
		/// Called when the back button is clicked.
		/// </summary>
		private void BackBTN_Click(object sender, System.EventArgs e)
		{
			UndoRead();
		}

		/// <summary>
		/// Called when the next button is clicked.
		/// </summary>
		private void NextBTN_Click(object sender, System.EventArgs e)
		{
			DoRead();
		}

		/// <summary>
		/// Called when the close button is clicked.
		/// </summary>
		private void DoneBTN_Click(object sender, System.EventArgs e)
		{
			if (sender == cancelBtn_)
			{
				mValues_ = null;
			}

			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Updates the result filters used for the request.
		/// </summary>
		private void OptionsBTN_Click(object sender, System.EventArgs e)
		{
			if (mSubscription_ != null)
			{
				new OptionsEditDlg().ShowDialog(mSubscription_);
			}
			else
			{
				new OptionsEditDlg().ShowDialog(mServer_);
			}
		}
	}
}

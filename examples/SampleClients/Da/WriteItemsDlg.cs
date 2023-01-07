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

using SampleClients.Da.Browse;
using SampleClients.Da.ItemValue;
using SampleClients.Da.Subscription;

using Technosoftware.DaAeHdaClient;
using SampleClients.Common;
using Technosoftware.DaAeHdaClient.Da;

using BrowseTreeCtrl = SampleClients.Da.Browse.BrowseTreeCtrl;

#endregion

namespace SampleClients.Da
{
    /// <summary>
    /// A dialog used select items for a write request and then display the results.
    /// </summary>
    public class WriteItemsDlg : System.Windows.Forms.Form
	{
		private BrowseTreeCtrl browseCtrl_;
		private ResultListViewCtrl resultsCtrl_;
		private ItemValueListEditCtrl itemsCtrl_;
		private System.Windows.Forms.Panel leftPn_;
		private System.Windows.Forms.Panel rightPn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button backBtn_;
		private System.Windows.Forms.Button nextBtn_;
		private System.Windows.Forms.Button doneBtn_;
		private System.Windows.Forms.Splitter splitterV_;
		private SubscriptionsTreeCtrl subscriptionCtrl_;
		private System.Windows.Forms.Button optionsBtn_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public WriteItemsDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            

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
			browseCtrl_ = new BrowseTreeCtrl();
			leftPn_ = new System.Windows.Forms.Panel();
			subscriptionCtrl_ = new SubscriptionsTreeCtrl();
			itemsCtrl_ = new ItemValueListEditCtrl();
			rightPn_ = new System.Windows.Forms.Panel();
			resultsCtrl_ = new ResultListViewCtrl();
			buttonsPn_ = new System.Windows.Forms.Panel();
			optionsBtn_ = new System.Windows.Forms.Button();
			backBtn_ = new System.Windows.Forms.Button();
			nextBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			doneBtn_ = new System.Windows.Forms.Button();
			splitterV_ = new System.Windows.Forms.Splitter();
			leftPn_.SuspendLayout();
			rightPn_.SuspendLayout();
			buttonsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// BrowseCTRL
			// 
			browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			browseCtrl_.Location = new System.Drawing.Point(4, 4);
			browseCtrl_.Name = "browseCtrl_";
			browseCtrl_.Size = new System.Drawing.Size(246, 296);
			browseCtrl_.TabIndex = 1;
			// 
			// LeftPN
			// 
			leftPn_.Controls.Add(subscriptionCtrl_);
			leftPn_.Controls.Add(browseCtrl_);
			leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			leftPn_.DockPadding.Left = 4;
			leftPn_.DockPadding.Top = 4;
			leftPn_.Location = new System.Drawing.Point(0, 0);
			leftPn_.Name = "leftPn_";
			leftPn_.Size = new System.Drawing.Size(250, 300);
			leftPn_.TabIndex = 6;
			// 
			// SubscriptionCTRL
			// 
			subscriptionCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			subscriptionCtrl_.Location = new System.Drawing.Point(4, 4);
			subscriptionCtrl_.Name = "subscriptionCtrl_";
			subscriptionCtrl_.Size = new System.Drawing.Size(246, 296);
			subscriptionCtrl_.TabIndex = 2;
			// 
			// ItemsCTRL
			// 
			itemsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			itemsCtrl_.Location = new System.Drawing.Point(0, 4);
			itemsCtrl_.Name = "itemsCtrl_";
			itemsCtrl_.Size = new System.Drawing.Size(534, 296);
			itemsCtrl_.TabIndex = 7;
			// 
			// RightPN
			// 
			rightPn_.Controls.Add(itemsCtrl_);
			rightPn_.Controls.Add(resultsCtrl_);
			rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			rightPn_.DockPadding.Right = 4;
			rightPn_.DockPadding.Top = 4;
			rightPn_.Location = new System.Drawing.Point(254, 0);
			rightPn_.Name = "rightPn_";
			rightPn_.Size = new System.Drawing.Size(538, 300);
			rightPn_.TabIndex = 8;
			// 
			// ResultsCTRL
			// 
			resultsCtrl_.AllowDrop = true;
			resultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			resultsCtrl_.Location = new System.Drawing.Point(0, 4);
			resultsCtrl_.Name = "resultsCtrl_";
			resultsCtrl_.Size = new System.Drawing.Size(534, 296);
			resultsCtrl_.TabIndex = 0;
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(optionsBtn_);
			buttonsPn_.Controls.Add(backBtn_);
			buttonsPn_.Controls.Add(nextBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Controls.Add(doneBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 300);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(792, 36);
			buttonsPn_.TabIndex = 9;
			// 
			// OptionsBTN
			// 
			optionsBtn_.Location = new System.Drawing.Point(5, 8);
			optionsBtn_.Name = "optionsBtn_";
			optionsBtn_.TabIndex = 7;
			optionsBtn_.Text = "Options...";
			optionsBtn_.Click += new System.EventHandler(OptionsBTN_Click);
			// 
			// BackBTN
			// 
			backBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			backBtn_.Location = new System.Drawing.Point(552, 8);
			backBtn_.Name = "backBtn_";
			backBtn_.TabIndex = 3;
			backBtn_.Text = "< Back";
			backBtn_.Click += new System.EventHandler(BackBTN_Click);
			// 
			// NextBTN
			// 
			nextBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			nextBtn_.Location = new System.Drawing.Point(632, 8);
			nextBtn_.Name = "nextBtn_";
			nextBtn_.TabIndex = 2;
			nextBtn_.Text = "Next >";
			nextBtn_.Click += new System.EventHandler(NextBTN_Click);
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(712, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 5;
			cancelBtn_.Text = "Cancel";
			cancelBtn_.Click += new System.EventHandler(DoneBTN_Click);
			// 
			// DoneBTN
			// 
			doneBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			doneBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			doneBtn_.Location = new System.Drawing.Point(712, 8);
			doneBtn_.Name = "doneBtn_";
			doneBtn_.TabIndex = 0;
			doneBtn_.Text = "Done";
			// 
			// SplitterV
			// 
			splitterV_.Location = new System.Drawing.Point(250, 0);
			splitterV_.Name = "splitterV_";
			splitterV_.Size = new System.Drawing.Size(4, 300);
			splitterV_.TabIndex = 10;
			splitterV_.TabStop = false;
			// 
			// WriteItemsDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(792, 336);
			Controls.Add(rightPn_);
			Controls.Add(splitterV_);
			Controls.Add(leftPn_);
			Controls.Add(buttonsPn_);
			Name = "WriteItemsDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Write Items";
			leftPn_.ResumeLayout(false);
			rightPn_.ResumeLayout(false);
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The server used to process write request.
		/// </summary>
		private TsCDaServer mServer_ = null;

		/// <summary>
		/// The subscription used to process write request.
		/// </summary>
		private TsCDaSubscription mSubscription_ = null;

		/// <summary>
		/// Whether to use asynchronous write operations. 
		/// </summary>
		private bool mSynchronous_ = true;

		/// <summary>
		/// The set of values written to the server.
		/// </summary>
		private TsCDaItemValueResult[] mValues_ = null;

		/// <summary>
		/// Prompts the use to select items for the write request.
		/// </summary>
		public TsCDaItemValueResult[] ShowDialog(TsCDaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_       = server;
			mSubscription_ = null;
			mSynchronous_  = true;

			backBtn_.Enabled          = false;
			nextBtn_.Enabled          = true;
			cancelBtn_.Visible        = true;
			doneBtn_.Visible          = false;
			browseCtrl_.Visible       = true;
			subscriptionCtrl_.Visible = false;
			itemsCtrl_.Visible        = true;
			resultsCtrl_.Visible      = false;

			browseCtrl_.ShowSingleServer(mServer_, null);
			itemsCtrl_.Initialize(mServer_, null);

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
			itemsCtrl_.Initialize(mServer_, null, mSubscription_.Items);

			ShowDialog();

			return mValues_;
		}

		/// <summary>
		/// Executes a write request for the current set if items.
		/// </summary>
		public void DoWrite()
		{
			try
			{
				// get the selected items 
				TsCDaItemValue[] items = itemsCtrl_.GetItems();

				// write to server.
				OpcItemResult[] results  = null;

				if (mSubscription_ != null)
				{
					if (mSynchronous_)
					{
						results = mSubscription_.Write(items);
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
					foreach(TsCDaItemValue item in items) { item.ClientHandle = item.ItemName; }

					results = mServer_.Write(items);
				}

				// create a list of item value results.
				ArrayList values = new ArrayList();

				for (int ii = 0; ii < items.Length; ii++)
				{
					TsCDaItemValueResult value = new TsCDaItemValueResult(items[ii]);

					value.ItemName       = results[ii].ItemName;
					value.ItemPath       = results[ii].ItemPath;
					value.ClientHandle   = results[ii].ClientHandle;
					value.ServerHandle   = results[ii].ServerHandle;
					value.Result       = results[ii].Result;
					value.DiagnosticInfo = results[ii].DiagnosticInfo;

					values.Add(value);
				}

				// save results.
				mValues_ = (TsCDaItemValueResult[])values.ToArray(typeof(TsCDaItemValueResult));

				backBtn_.Enabled     = true;
				nextBtn_.Enabled     = false;
				cancelBtn_.Visible   = false;
				doneBtn_.Visible     = true;
				optionsBtn_.Visible  = false;
				itemsCtrl_.Visible   = false;
				resultsCtrl_.Visible = true;

				// display results.
				resultsCtrl_.Initialize(mServer_, (mSubscription_ != null)?mSubscription_.Locale:mServer_.Locale, mValues_);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Discards any results from a write request.
		/// </summary>
		public void UndoWrite()
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
			itemsCtrl_.AddItemWithDefaults(new TsCDaItemValue(itemId));
		}

		/// <summary>
		/// Called when the back button is clicked.
		/// </summary>
		private void BackBTN_Click(object sender, System.EventArgs e)
		{
			UndoWrite();
		}

		/// <summary>
		/// Called when the next button is clicked.
		/// </summary>
		private void NextBTN_Click(object sender, System.EventArgs e)
		{
			DoWrite();
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

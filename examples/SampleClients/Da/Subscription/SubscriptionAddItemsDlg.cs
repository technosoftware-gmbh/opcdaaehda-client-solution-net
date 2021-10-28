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

using Technosoftware.DaAeHdaClient;
using SampleClients.Common;
using Technosoftware.DaAeHdaClient.Da;

using BrowseTreeCtrl = SampleClients.Da.Browse.BrowseTreeCtrl;

#endregion

namespace SampleClients.Da.Subscription
{
    /// <summary>
    /// A dialog used to add new items to an existing subscription.
    /// </summary>
    public class SubscriptionAddItemsDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button backBtn_;
		private System.Windows.Forms.Button nextBtn_;
		private System.Windows.Forms.Button doneBtn_;
		private System.Windows.Forms.Panel leftPn_;
		private BrowseTreeCtrl browseCtrl_;
		private System.Windows.Forms.Panel rightPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Splitter splitterV_;
		private ResultListViewCtrl resultsCtrl_;
		private ItemListEditCtrl itemsCtrl_;
		private System.Windows.Forms.Button optionsBtn_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public SubscriptionAddItemsDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

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
			this.rightPn_ = new System.Windows.Forms.Panel();
			this.resultsCtrl_ = new ResultListViewCtrl();
			this.itemsCtrl_ = new ItemListEditCtrl();
			this.leftPn_ = new System.Windows.Forms.Panel();
			this.browseCtrl_ = new BrowseTreeCtrl();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.optionsBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.backBtn_ = new System.Windows.Forms.Button();
			this.nextBtn_ = new System.Windows.Forms.Button();
			this.doneBtn_ = new System.Windows.Forms.Button();
			this.splitterV_ = new System.Windows.Forms.Splitter();
			this.rightPn_.SuspendLayout();
			this.leftPn_.SuspendLayout();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// RightPN
			// 
			this.rightPn_.Controls.Add(this.resultsCtrl_);
			this.rightPn_.Controls.Add(this.itemsCtrl_);
			this.rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPn_.DockPadding.Right = 4;
			this.rightPn_.DockPadding.Top = 4;
			this.rightPn_.Location = new System.Drawing.Point(253, 0);
			this.rightPn_.Name = "rightPn_";
			this.rightPn_.Size = new System.Drawing.Size(539, 272);
			this.rightPn_.TabIndex = 6;
			// 
			// ResultsCTRL
			// 
			this.resultsCtrl_.AllowDrop = true;
			this.resultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultsCtrl_.Location = new System.Drawing.Point(0, 4);
			this.resultsCtrl_.Name = "resultsCtrl_";
			this.resultsCtrl_.Size = new System.Drawing.Size(535, 268);
			this.resultsCtrl_.TabIndex = 1;
			// 
			// ItemsCTRL
			// 
			this.itemsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsCtrl_.Location = new System.Drawing.Point(0, 4);
			this.itemsCtrl_.Name = "itemsCtrl_";
			this.itemsCtrl_.Size = new System.Drawing.Size(535, 268);
			this.itemsCtrl_.TabIndex = 0;
			// 
			// LeftPN
			// 
			this.leftPn_.Controls.Add(this.browseCtrl_);
			this.leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftPn_.DockPadding.Left = 4;
			this.leftPn_.DockPadding.Top = 4;
			this.leftPn_.Location = new System.Drawing.Point(0, 0);
			this.leftPn_.Name = "leftPn_";
			this.leftPn_.Size = new System.Drawing.Size(250, 272);
			this.leftPn_.TabIndex = 11;
			// 
			// BrowseCTRL
			// 
			this.browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browseCtrl_.Location = new System.Drawing.Point(4, 4);
			this.browseCtrl_.Name = "browseCtrl_";
			this.browseCtrl_.Size = new System.Drawing.Size(246, 268);
			this.browseCtrl_.TabIndex = 0;
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.optionsBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Controls.Add(this.backBtn_);
			this.buttonsPn_.Controls.Add(this.nextBtn_);
			this.buttonsPn_.Controls.Add(this.doneBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 272);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(792, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// OptionsBTN
			// 
			this.optionsBtn_.Location = new System.Drawing.Point(5, 8);
			this.optionsBtn_.Name = "optionsBtn_";
			this.optionsBtn_.TabIndex = 7;
			this.optionsBtn_.Text = "Options...";
			this.optionsBtn_.Click += new System.EventHandler(this.OptionsBTN_Click);
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(712, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 4;
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
			this.splitterV_.Size = new System.Drawing.Size(3, 272);
			this.splitterV_.TabIndex = 12;
			this.splitterV_.TabStop = false;
			// 
			// SubscriptionAddItemsDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 308);
			this.Controls.Add(this.rightPn_);
			this.Controls.Add(this.splitterV_);
			this.Controls.Add(this.leftPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "SubscriptionAddItemsDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Subscription Items";
			this.rightPn_.ResumeLayout(false);
			this.leftPn_.ResumeLayout(false);
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The server which processes the subscription.
		/// </summary>
		private TsCDaServer mServer_ = null;

		/// <summary>
		/// The subscription being created.
		/// </summary>
		private TsCDaSubscription mSubscription_ = null;

		/// <summary>
		/// The items being added.
		/// </summary>
		private TsCDaItemResult[] mItems_ = null;

		/// <summary>
		/// Prompts a user to add items to a subscitpion with a modal dialog. 
		/// </summary>
		public TsCDaItemResult[] ShowDialog(TsCDaSubscription subscription)
		{
			if (subscription == null) throw new ArgumentNullException("subscription");

			mServer_       = subscription.Server;
			mSubscription_ = subscription;
			mItems_        = null;

			backBtn_.Enabled          = false;
			nextBtn_.Enabled          = true;
			cancelBtn_.Visible        = true;
			doneBtn_.Visible          = false;
			optionsBtn_.Visible       = true;
			browseCtrl_.Visible       = true;
			itemsCtrl_.Visible        = true;
			resultsCtrl_.Visible      = false;

			browseCtrl_.ShowSingleServer(mServer_, null);
			itemsCtrl_.Initialize(null);

			ShowDialog();

			// ensure server connection in the browse control are closed.
			browseCtrl_.Clear();

			return mItems_;
		}
		
		/// <summary>
		/// Adds a set of items to a subscription.
		/// </summary>
		private void DoAddItems()
		{
			try
			{
				// assign globally unique client handle.
				TsCDaItem[] items = itemsCtrl_.GetItems();

				foreach (TsCDaItem item in items)
				{
					item.ClientHandle = Guid.NewGuid().ToString();
				}

				// add items to subscription.
				mItems_ = mSubscription_.AddItems(items);

				// move to add items panel.
				backBtn_.Enabled          = true;
				nextBtn_.Enabled          = false;
				cancelBtn_.Visible        = false;
				doneBtn_.Visible          = true;
				optionsBtn_.Visible       = false;
				browseCtrl_.Visible       = true;
				itemsCtrl_.Visible        = false;
				resultsCtrl_.Visible      = true;

				// update controls with actual values.
				resultsCtrl_.Initialize(mServer_, null, mItems_);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Removes a previously added items from a subscription.
		/// </summary>
		private void UndoAddItems()
		{
			try
			{
				if (mItems_ != null)
				{
					mSubscription_.RemoveItems(mItems_);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			finally
			{
				mItems_ = null;
			}

			// move to add items panel.
			backBtn_.Enabled          = true;
			nextBtn_.Enabled          = true;
			cancelBtn_.Visible        = true;
			doneBtn_.Visible          = false;
			optionsBtn_.Visible       = true;
			browseCtrl_.Visible       = true;
			itemsCtrl_.Visible        = true;
			resultsCtrl_.Visible      = false;
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
			UndoAddItems();
		}

		/// <summary>
		/// Called when the next button is clicked.
		/// </summary>
		private void NextBTN_Click(object sender, System.EventArgs e)
		{
			DoAddItems();
		}

		/// <summary>
		/// Called when the close button is clicked.
		/// </summary>
		private void DoneBTN_Click(object sender, System.EventArgs e)
		{
			if (sender == cancelBtn_)
			{
				if (mItems_ != null)
				{
					try   { mSubscription_.RemoveItems(mItems_); }
					catch {}

					mItems_ = null;
				}
			}

			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Updates the result filters used for the request.
		/// </summary>
		private void OptionsBTN_Click(object sender, System.EventArgs e)
		{
			new OptionsEditDlg().ShowDialog(mSubscription_);
		}
	}
}

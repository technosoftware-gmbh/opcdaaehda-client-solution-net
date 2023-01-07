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
    /// A dialog used to create a new subscription.
    /// </summary>
    public class SubscriptionCreateDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button backBtn_;
		private System.Windows.Forms.Button nextBtn_;
		private System.Windows.Forms.Button doneBtn_;
		private System.Windows.Forms.Panel leftPn_;
		private BrowseTreeCtrl browseCtrl_;
		private SubscriptionEditCtrl subscriptionCtrl_;
		private System.Windows.Forms.Panel rightPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Splitter splitterV_;
		private System.Windows.Forms.Button optionsBtn_;
		private ResultListViewCtrl resultsCtrl_;
		private ItemListEditCtrl itemsCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public SubscriptionCreateDlg()
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
			rightPn_ = new System.Windows.Forms.Panel();
			itemsCtrl_ = new ItemListEditCtrl();
			resultsCtrl_ = new ResultListViewCtrl();
			leftPn_ = new System.Windows.Forms.Panel();
			subscriptionCtrl_ = new SubscriptionEditCtrl();
			browseCtrl_ = new BrowseTreeCtrl();
			buttonsPn_ = new System.Windows.Forms.Panel();
			optionsBtn_ = new System.Windows.Forms.Button();
			backBtn_ = new System.Windows.Forms.Button();
			nextBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			doneBtn_ = new System.Windows.Forms.Button();
			splitterV_ = new System.Windows.Forms.Splitter();
			rightPn_.SuspendLayout();
			leftPn_.SuspendLayout();
			buttonsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// RightPN
			// 
			rightPn_.Controls.Add(itemsCtrl_);
			rightPn_.Controls.Add(resultsCtrl_);
			rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			rightPn_.DockPadding.Right = 4;
			rightPn_.DockPadding.Top = 4;
			rightPn_.Location = new System.Drawing.Point(253, 0);
			rightPn_.Name = "rightPn_";
			rightPn_.Size = new System.Drawing.Size(539, 272);
			rightPn_.TabIndex = 6;
			// 
			// ItemsCTRL
			// 
			itemsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			itemsCtrl_.Location = new System.Drawing.Point(0, 4);
			itemsCtrl_.Name = "itemsCtrl_";
			itemsCtrl_.Size = new System.Drawing.Size(535, 268);
			itemsCtrl_.TabIndex = 1;
			// 
			// ResultsCTRL
			// 
			resultsCtrl_.AllowDrop = true;
			resultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			resultsCtrl_.Location = new System.Drawing.Point(0, 4);
			resultsCtrl_.Name = "resultsCtrl_";
			resultsCtrl_.Size = new System.Drawing.Size(535, 268);
			resultsCtrl_.TabIndex = 0;
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
			leftPn_.Size = new System.Drawing.Size(250, 272);
			leftPn_.TabIndex = 11;
			// 
			// SubscriptionCTRL
			// 
			subscriptionCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			subscriptionCtrl_.Location = new System.Drawing.Point(4, 4);
			subscriptionCtrl_.Name = "subscriptionCtrl_";
			subscriptionCtrl_.Size = new System.Drawing.Size(246, 268);
			subscriptionCtrl_.TabIndex = 1;
			// 
			// BrowseCTRL
			// 
			browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			browseCtrl_.Location = new System.Drawing.Point(4, 4);
			browseCtrl_.Name = "browseCtrl_";
			browseCtrl_.Size = new System.Drawing.Size(246, 268);
			browseCtrl_.TabIndex = 0;
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(optionsBtn_);
			buttonsPn_.Controls.Add(backBtn_);
			buttonsPn_.Controls.Add(nextBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Controls.Add(doneBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 272);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(792, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// OptionsBTN
			// 
			optionsBtn_.Location = new System.Drawing.Point(5, 8);
			optionsBtn_.Name = "optionsBtn_";
			optionsBtn_.TabIndex = 8;
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
			cancelBtn_.TabIndex = 4;
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
			doneBtn_.Click += new System.EventHandler(DoneBTN_Click);
			// 
			// SplitterV
			// 
			splitterV_.Location = new System.Drawing.Point(250, 0);
			splitterV_.Name = "splitterV_";
			splitterV_.Size = new System.Drawing.Size(3, 272);
			splitterV_.TabIndex = 12;
			splitterV_.TabStop = false;
			// 
			// SubscriptionCreateDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(792, 308);
			Controls.Add(rightPn_);
			Controls.Add(splitterV_);
			Controls.Add(leftPn_);
			Controls.Add(buttonsPn_);
			Name = "SubscriptionCreateDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Create Subscription";
			rightPn_.ResumeLayout(false);
			leftPn_.ResumeLayout(false);
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

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
		/// Prompts a user to create a new subscription with a modal dialog. 
		/// </summary>
		public TsCDaSubscription ShowDialog(TsCDaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_       = server;
			mSubscription_ = null;
			mItems_        = null;

			backBtn_.Enabled          = false;
			nextBtn_.Enabled          = true;
			cancelBtn_.Visible        = true;
			doneBtn_.Visible          = false;
			optionsBtn_.Visible       = false;
			subscriptionCtrl_.Visible = true;
			browseCtrl_.Visible       = false;
			itemsCtrl_.Visible        = true;
			resultsCtrl_.Visible      = false;

			subscriptionCtrl_.Server = mServer_;
			subscriptionCtrl_.Set(null);
			browseCtrl_.ShowSingleServer(mServer_, null);
			itemsCtrl_.Initialize((TsCDaItem)null);

			ShowDialog();

			// ensure server connection in the browse control are closed.
			browseCtrl_.Clear();

			return mSubscription_;
		}

		/// <summary>
		/// Creates a subscription with the specified parameters.
		/// </summary>
		private void DoCreate()
		{
			try
			{
				// assign a globally unique handle to the subscription.
				TsCDaSubscriptionState state = (TsCDaSubscriptionState)subscriptionCtrl_.Get();

				state.ClientHandle = Guid.NewGuid().ToString();

				// create the subscription.
				mSubscription_ = (TsCDaSubscription)mServer_.CreateSubscription(state);

				// move to add items panel.
				backBtn_.Enabled          = true;
				nextBtn_.Enabled          = true;
				cancelBtn_.Visible        = false;
				doneBtn_.Visible          = true;
				optionsBtn_.Visible       = true;
				subscriptionCtrl_.Visible = false;
				browseCtrl_.Visible       = true;
				itemsCtrl_.Visible        = true;
				resultsCtrl_.Visible      = false;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Removes a previously created subscription.
		/// </summary>
		private void UndoCreate()
		{
			try
			{
				mServer_.CancelSubscription(mSubscription_);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			finally
			{
				if (mSubscription_ != null) mSubscription_.Dispose();
				mSubscription_ = null;
			}

			// move to edit subscription panel.
			backBtn_.Enabled          = false;
			nextBtn_.Enabled          = true;
			cancelBtn_.Visible        = true;
			doneBtn_.Visible          = false;
			optionsBtn_.Visible       = false;
			subscriptionCtrl_.Visible = true;
			browseCtrl_.Visible       = false;
			itemsCtrl_.Visible        = true;
			resultsCtrl_.Visible      = false;
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
				subscriptionCtrl_.Visible = true;
				browseCtrl_.Visible       = false;
				itemsCtrl_.Visible        = false;
				resultsCtrl_.Visible      = true;

				// update controls with actual values.
				subscriptionCtrl_.Set(mSubscription_.State);
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
				mSubscription_.RemoveItems(mItems_);
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
			cancelBtn_.Visible        = false;
			doneBtn_.Visible          = true;
			optionsBtn_.Visible       = true;
			subscriptionCtrl_.Visible = false;
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
			if (mItems_ != null)        { UndoAddItems(); return; }
			if (mSubscription_ != null) { UndoCreate();   return; }
		}

		/// <summary>
		/// Called when the next button is clicked.
		/// </summary>
		private void NextBTN_Click(object sender, System.EventArgs e)
		{
			if (mSubscription_ == null) { DoCreate();   return; }
			if (mItems_ == null)        { DoAddItems(); return; }
		}

		/// <summary>
		/// Called when the close button is clicked.
		/// </summary>
		private void DoneBTN_Click(object sender, System.EventArgs e)
		{
			if (sender == cancelBtn_)
			{
				try   { mServer_.CancelSubscription(mSubscription_); }
				catch {}
				mSubscription_ = null;
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

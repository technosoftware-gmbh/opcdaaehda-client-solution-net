#region Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
// Web: http://www.technosoftware.com 
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved

using SampleClients.Common;
using System;
using System.Collections;
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A dialog used to create a new subscription.
    /// </summary>
    public class SubscriptionEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button backBtn_;
		private System.Windows.Forms.Button nextBtn_;
		private System.Windows.Forms.Button doneBtn_;
		private System.Windows.Forms.Panel leftPn_;
		private System.Windows.Forms.Panel rightPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Splitter splitterV_;
		private Technosoftware.AeSampleClient.AttributesCtrl attributesCtrl_;
		private Technosoftware.AeSampleClient.SubscriptionStateEditCtrl stateCtrl_;
		private Technosoftware.AeSampleClient.SubscriptionFiltersEditCtrl filtersCtrl_;
		private System.Windows.Forms.GroupBox stateGb_;
		private System.Windows.Forms.GroupBox filtersGb_;
		private Technosoftware.AeSampleClient.CategoriesCtrl categoriesCtrl_;
		private Technosoftware.AeSampleClient.BrowseCtrl browseCtrl_;
		private System.Windows.Forms.Panel stateFiltersPn_;
		private Technosoftware.AeSampleClient.AreaSourceListCtrl areaSourcesListCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public SubscriptionEditDlg()
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
			rightPn_ = new System.Windows.Forms.Panel();
			areaSourcesListCtrl_ = new Technosoftware.AeSampleClient.AreaSourceListCtrl();
			attributesCtrl_ = new Technosoftware.AeSampleClient.AttributesCtrl();
			stateFiltersPn_ = new System.Windows.Forms.Panel();
			categoriesCtrl_ = new Technosoftware.AeSampleClient.CategoriesCtrl();
			filtersGb_ = new System.Windows.Forms.GroupBox();
			filtersCtrl_ = new Technosoftware.AeSampleClient.SubscriptionFiltersEditCtrl();
			stateGb_ = new System.Windows.Forms.GroupBox();
			stateCtrl_ = new Technosoftware.AeSampleClient.SubscriptionStateEditCtrl();
			leftPn_ = new System.Windows.Forms.Panel();
			browseCtrl_ = new Technosoftware.AeSampleClient.BrowseCtrl();
			buttonsPn_ = new System.Windows.Forms.Panel();
			backBtn_ = new System.Windows.Forms.Button();
			nextBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			doneBtn_ = new System.Windows.Forms.Button();
			splitterV_ = new System.Windows.Forms.Splitter();
			rightPn_.SuspendLayout();
			stateFiltersPn_.SuspendLayout();
			filtersGb_.SuspendLayout();
			stateGb_.SuspendLayout();
			leftPn_.SuspendLayout();
			buttonsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// RightPN
			// 
			rightPn_.Controls.Add(areaSourcesListCtrl_);
			rightPn_.Controls.Add(attributesCtrl_);
			rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			rightPn_.DockPadding.Right = 4;
			rightPn_.DockPadding.Top = 4;
			rightPn_.Location = new System.Drawing.Point(283, 0);
			rightPn_.Name = "rightPn_";
			rightPn_.Size = new System.Drawing.Size(509, 490);
			rightPn_.TabIndex = 6;
			// 
			// AreaSourcesListCTRL
			// 
			areaSourcesListCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			areaSourcesListCtrl_.Location = new System.Drawing.Point(0, 4);
			areaSourcesListCtrl_.Name = "areaSourcesListCtrl_";
			areaSourcesListCtrl_.Size = new System.Drawing.Size(505, 486);
			areaSourcesListCtrl_.TabIndex = 1;
			// 
			// AttributesCTRL
			// 
			attributesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			attributesCtrl_.Location = new System.Drawing.Point(0, 4);
			attributesCtrl_.Name = "attributesCtrl_";
			attributesCtrl_.Size = new System.Drawing.Size(505, 486);
			attributesCtrl_.TabIndex = 0;
			// 
			// StateFiltersPN
			// 
			stateFiltersPn_.Controls.Add(categoriesCtrl_);
			stateFiltersPn_.Controls.Add(filtersGb_);
			stateFiltersPn_.Controls.Add(stateGb_);
			stateFiltersPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			stateFiltersPn_.Location = new System.Drawing.Point(4, 4);
			stateFiltersPn_.Name = "stateFiltersPn_";
			stateFiltersPn_.Size = new System.Drawing.Size(272, 486);
			stateFiltersPn_.TabIndex = 1;
			// 
			// CategoriesCTRL
			// 
			categoriesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			categoriesCtrl_.Location = new System.Drawing.Point(0, 284);
			categoriesCtrl_.Name = "categoriesCtrl_";
			categoriesCtrl_.Size = new System.Drawing.Size(272, 202);
			categoriesCtrl_.TabIndex = 1;
			categoriesCtrl_.CategoryChecked += new Technosoftware.AeSampleClient.CategoriesCtrl.CategoryCheckedEventHandler(CategoriesCTRL_CategorySelected);
			// 
			// FiltersGB
			// 
			filtersGb_.Controls.Add(filtersCtrl_);
			filtersGb_.Dock = System.Windows.Forms.DockStyle.Top;
			filtersGb_.Location = new System.Drawing.Point(0, 140);
			filtersGb_.Name = "filtersGb_";
			filtersGb_.Size = new System.Drawing.Size(272, 144);
			filtersGb_.TabIndex = 0;
			filtersGb_.TabStop = false;
			filtersGb_.Text = "Filtering Parameters";
			// 
			// FiltersCTRL
			// 
			filtersCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			filtersCtrl_.Location = new System.Drawing.Point(3, 16);
			filtersCtrl_.Name = "filtersCtrl_";
			filtersCtrl_.Size = new System.Drawing.Size(266, 125);
			filtersCtrl_.TabIndex = 1;
			// 
			// StateGB
			// 
			stateGb_.Controls.Add(stateCtrl_);
			stateGb_.Dock = System.Windows.Forms.DockStyle.Top;
			stateGb_.Location = new System.Drawing.Point(0, 0);
			stateGb_.Name = "stateGb_";
			stateGb_.Size = new System.Drawing.Size(272, 140);
			stateGb_.TabIndex = 0;
			stateGb_.TabStop = false;
			stateGb_.Text = "State Parameters";
			// 
			// StateCTRL
			// 
			stateCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			stateCtrl_.Location = new System.Drawing.Point(3, 16);
			stateCtrl_.Name = "stateCtrl_";
			stateCtrl_.Size = new System.Drawing.Size(266, 121);
			stateCtrl_.TabIndex = 0;
			// 
			// LeftPN
			// 
			leftPn_.Controls.Add(stateFiltersPn_);
			leftPn_.Controls.Add(browseCtrl_);
			leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			leftPn_.DockPadding.Left = 4;
			leftPn_.DockPadding.Right = 4;
			leftPn_.DockPadding.Top = 4;
			leftPn_.Location = new System.Drawing.Point(0, 0);
			leftPn_.Name = "leftPn_";
			leftPn_.Size = new System.Drawing.Size(280, 490);
			leftPn_.TabIndex = 11;
			// 
			// BrowseCTRL
			// 
			browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			browseCtrl_.Location = new System.Drawing.Point(4, 4);
			browseCtrl_.Name = "browseCtrl_";
			browseCtrl_.Size = new System.Drawing.Size(272, 486);
			browseCtrl_.TabIndex = 1;
			browseCtrl_.NodeSelected += new Technosoftware.AeSampleClient.BrowseCtrl.NodeSelectedEventHandler(BrowseCTRL_NodeSelected);
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(backBtn_);
			buttonsPn_.Controls.Add(doneBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Controls.Add(nextBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 490);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(792, 36);
			buttonsPn_.TabIndex = 0;
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
			// 
			// DoneBTN
			// 
			doneBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			doneBtn_.Location = new System.Drawing.Point(632, 8);
			doneBtn_.Name = "doneBtn_";
			doneBtn_.TabIndex = 0;
			doneBtn_.Text = "Done";
			doneBtn_.Click += new System.EventHandler(DoneBTN_Click);
			// 
			// SplitterV
			// 
			splitterV_.Location = new System.Drawing.Point(280, 0);
			splitterV_.Name = "splitterV_";
			splitterV_.Size = new System.Drawing.Size(3, 490);
			splitterV_.TabIndex = 12;
			splitterV_.TabStop = false;
			// 
			// SubscriptionEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(792, 526);
			Controls.Add(rightPn_);
			Controls.Add(splitterV_);
			Controls.Add(leftPn_);
			Controls.Add(buttonsPn_);
			Name = "SubscriptionEditDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Create Subscription";
			rightPn_.ResumeLayout(false);
			stateFiltersPn_.ResumeLayout(false);
			filtersGb_.ResumeLayout(false);
			stateGb_.ResumeLayout(false);
			leftPn_.ResumeLayout(false);
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private TsCAeServer mServer_ = null;
		private TsCAeSubscription mSubscription_ = null;		
		private TsCAeSubscriptionState mState_ = new TsCAeSubscriptionState();
		private TsCAeSubscriptionFilters mFilters_ = new TsCAeSubscriptionFilters();
		private Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary mAttributes_ = new Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary();
		private string[] mAreas_ = null;
		private string[] mSources_ = null;
		private int mStage_ = 0;

		private static int mCount_ = 0;
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts a user to create a new subscription with a modal dialog. 
		/// </summary>
		public TsCAeSubscription ShowDialog(TsCAeServer server, TsCAeSubscription subscription)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_       = server;
			mSubscription_ = subscription;

			// go to the initial stage.
			mStage_ = 0;
			ChangeStage(0);

			// initialize controls.
			stateCtrl_.SetDefaults();
			filtersCtrl_.SetDefaults();
			categoriesCtrl_.ShowCategories(mServer_);
			attributesCtrl_.ShowAttributes(mServer_);
			browseCtrl_.ShowAreas(mServer_);

			if (mSubscription_ != null)
			{
				mState_      = mSubscription_.GetState();
				mFilters_    = mSubscription_.GetFilters();
				mAttributes_ = mSubscription_.GetAttributes();
				mAreas_      = mSubscription_.Areas.ToArray();
				mSources_    = mSubscription_.Sources.ToArray();
			}
			else
			{
				mState_.Name = String.Format("Subscription{0,3:000}", ++mCount_);
			}

			// set current values.
			stateCtrl_.Set(mState_);
			filtersCtrl_.Set(mFilters_);
			categoriesCtrl_.SetSelectedCategories(mFilters_.Categories.ToArray());
			attributesCtrl_.SetSelectedAttributes(mAttributes_);
			areaSourcesListCtrl_.AddAreas(mAreas_);
			areaSourcesListCtrl_.AddSources(mSources_);

			// show dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// return updated/created subscription.
			return mSubscription_;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Toggles the states of the buttons and controls based on the stage.
		/// </summary>
		private void ChangeStage(int stage)
		{
			switch (stage)
			{
				case 0:
				{
					backBtn_.Enabled   = false;
					nextBtn_.Enabled   = true;
					nextBtn_.Visible   = true;
					cancelBtn_.Visible = true;
					doneBtn_.Visible   = false;

					stateFiltersPn_.Visible      = true;
					attributesCtrl_.Visible      = true;
					browseCtrl_.Visible          = false;
					areaSourcesListCtrl_.Visible = false;
					break;
				}

				case 1:
				{
					backBtn_.Enabled   = true;
					nextBtn_.Enabled   = false;
					nextBtn_.Visible   = false;
					cancelBtn_.Visible = true;
					doneBtn_.Visible   = true;

					stateFiltersPn_.Visible      = false;
					attributesCtrl_.Visible      = false;
					browseCtrl_.Visible          = true;
					areaSourcesListCtrl_.Visible = true;
					break;
				}
			}
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Called when the back button is clicked.
		/// </summary>
		private void BackBTN_Click(object sender, System.EventArgs e)
		{
			ChangeStage(--mStage_);

			if (mStage_ == 0)
			{
				stateCtrl_.Set(mState_);
				filtersCtrl_.Set(mFilters_);
				categoriesCtrl_.SetSelectedCategories(mFilters_.Categories.ToArray());
				attributesCtrl_.SetSelectedAttributes(mAttributes_);
			}
		}

		/// <summary>
		/// Called when the next button is clicked.
		/// </summary>
		private void NextBTN_Click(object sender, System.EventArgs e)
		{
			if (mStage_ == 0)
			{
				mState_   = (TsCAeSubscriptionState)stateCtrl_.Get();
				mFilters_ = (TsCAeSubscriptionFilters)filtersCtrl_.Get();

				mFilters_.Categories.Clear();
				mFilters_.Categories.AddRange(categoriesCtrl_.GetSelectedCategories());
	
				mAttributes_ = attributesCtrl_.GetSelectedAttributes();
			}

			ChangeStage(++mStage_);
		}

		/// <summary>
		/// Called when the close button is clicked.
		/// </summary>
		private void DoneBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				mAreas_   = areaSourcesListCtrl_.GetAreas();
				mSources_ = areaSourcesListCtrl_.GetSources();

				// don't activate until all the filters are applied.
				bool active = mState_.Active;
				bool update = mSubscription_ != null;

				// create new subscription.
				if (mSubscription_ == null)
				{
					mState_.Active       = false;
					mState_.ClientHandle = Guid.NewGuid().ToString();
					mSubscription_ = (TsCAeSubscription)mServer_.CreateSubscription(mState_);
				}

				// update existing subscription.
				else
				{
					mSubscription_.ModifyState(((int)TsCAeStateMask.All & ~(int)TsCAeStateMask.Active), mState_); 
				}

				// select filters.
				mFilters_.Areas.Clear();
				mFilters_.Areas.AddRange(mAreas_);
				mFilters_.Sources.Clear();
				mFilters_.Sources.AddRange(mSources_);

				mSubscription_.SetFilters(mFilters_);

				// select attributes.
				IDictionaryEnumerator enumerator = mAttributes_.GetEnumerator();

				while (enumerator.MoveNext())
				{
					int categoryId = (int)enumerator.Key;
					Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeCollection attributeIDs = (Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeCollection)enumerator.Value;

					mSubscription_.SelectReturnedAttributes(categoryId, attributeIDs.ToArray());
				}

				// activate the subscription.
				if (active || update)
				{
					mState_.Active = active;
					mSubscription_.ModifyState((int)TsCAeStateMask.Active, mState_); 
				}

				// close the dialog.
                DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception exception)
			{				
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Updates the attribute control after a category is selected.
		/// </summary>
		private void CategoriesCTRL_CategorySelected(int categoryId, bool picked)
		{
			attributesCtrl_.SelectCategory(categoryId, picked);
		}

		/// <summary>
		/// Sends notifications when a node is selected.
		/// </summary>
		private void BrowseCTRL_NodeSelected(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element, bool picked)
		{
			if (picked)
			{
				if (element.NodeType == Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area)
				{
					areaSourcesListCtrl_.AddAreas(new string[] { element.QualifiedName });
				}
				else
				{
					areaSourcesListCtrl_.AddSources(new string[] { element.QualifiedName });
				}
			}
		}
		#endregion
	}
}

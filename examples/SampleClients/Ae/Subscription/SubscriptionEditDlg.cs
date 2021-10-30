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
			this.rightPn_ = new System.Windows.Forms.Panel();
			this.areaSourcesListCtrl_ = new Technosoftware.AeSampleClient.AreaSourceListCtrl();
			this.attributesCtrl_ = new Technosoftware.AeSampleClient.AttributesCtrl();
			this.stateFiltersPn_ = new System.Windows.Forms.Panel();
			this.categoriesCtrl_ = new Technosoftware.AeSampleClient.CategoriesCtrl();
			this.filtersGb_ = new System.Windows.Forms.GroupBox();
			this.filtersCtrl_ = new Technosoftware.AeSampleClient.SubscriptionFiltersEditCtrl();
			this.stateGb_ = new System.Windows.Forms.GroupBox();
			this.stateCtrl_ = new Technosoftware.AeSampleClient.SubscriptionStateEditCtrl();
			this.leftPn_ = new System.Windows.Forms.Panel();
			this.browseCtrl_ = new Technosoftware.AeSampleClient.BrowseCtrl();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.backBtn_ = new System.Windows.Forms.Button();
			this.nextBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.doneBtn_ = new System.Windows.Forms.Button();
			this.splitterV_ = new System.Windows.Forms.Splitter();
			this.rightPn_.SuspendLayout();
			this.stateFiltersPn_.SuspendLayout();
			this.filtersGb_.SuspendLayout();
			this.stateGb_.SuspendLayout();
			this.leftPn_.SuspendLayout();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// RightPN
			// 
			this.rightPn_.Controls.Add(this.areaSourcesListCtrl_);
			this.rightPn_.Controls.Add(this.attributesCtrl_);
			this.rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPn_.DockPadding.Right = 4;
			this.rightPn_.DockPadding.Top = 4;
			this.rightPn_.Location = new System.Drawing.Point(283, 0);
			this.rightPn_.Name = "rightPn_";
			this.rightPn_.Size = new System.Drawing.Size(509, 490);
			this.rightPn_.TabIndex = 6;
			// 
			// AreaSourcesListCTRL
			// 
			this.areaSourcesListCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.areaSourcesListCtrl_.Location = new System.Drawing.Point(0, 4);
			this.areaSourcesListCtrl_.Name = "areaSourcesListCtrl_";
			this.areaSourcesListCtrl_.Size = new System.Drawing.Size(505, 486);
			this.areaSourcesListCtrl_.TabIndex = 1;
			// 
			// AttributesCTRL
			// 
			this.attributesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.attributesCtrl_.Location = new System.Drawing.Point(0, 4);
			this.attributesCtrl_.Name = "attributesCtrl_";
			this.attributesCtrl_.Size = new System.Drawing.Size(505, 486);
			this.attributesCtrl_.TabIndex = 0;
			// 
			// StateFiltersPN
			// 
			this.stateFiltersPn_.Controls.Add(this.categoriesCtrl_);
			this.stateFiltersPn_.Controls.Add(this.filtersGb_);
			this.stateFiltersPn_.Controls.Add(this.stateGb_);
			this.stateFiltersPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.stateFiltersPn_.Location = new System.Drawing.Point(4, 4);
			this.stateFiltersPn_.Name = "stateFiltersPn_";
			this.stateFiltersPn_.Size = new System.Drawing.Size(272, 486);
			this.stateFiltersPn_.TabIndex = 1;
			// 
			// CategoriesCTRL
			// 
			this.categoriesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.categoriesCtrl_.Location = new System.Drawing.Point(0, 284);
			this.categoriesCtrl_.Name = "categoriesCtrl_";
			this.categoriesCtrl_.Size = new System.Drawing.Size(272, 202);
			this.categoriesCtrl_.TabIndex = 1;
			this.categoriesCtrl_.CategoryChecked += new Technosoftware.AeSampleClient.CategoriesCtrl.CategoryCheckedEventHandler(this.CategoriesCTRL_CategorySelected);
			// 
			// FiltersGB
			// 
			this.filtersGb_.Controls.Add(this.filtersCtrl_);
			this.filtersGb_.Dock = System.Windows.Forms.DockStyle.Top;
			this.filtersGb_.Location = new System.Drawing.Point(0, 140);
			this.filtersGb_.Name = "filtersGb_";
			this.filtersGb_.Size = new System.Drawing.Size(272, 144);
			this.filtersGb_.TabIndex = 0;
			this.filtersGb_.TabStop = false;
			this.filtersGb_.Text = "Filtering Parameters";
			// 
			// FiltersCTRL
			// 
			this.filtersCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.filtersCtrl_.Location = new System.Drawing.Point(3, 16);
			this.filtersCtrl_.Name = "filtersCtrl_";
			this.filtersCtrl_.Size = new System.Drawing.Size(266, 125);
			this.filtersCtrl_.TabIndex = 1;
			// 
			// StateGB
			// 
			this.stateGb_.Controls.Add(this.stateCtrl_);
			this.stateGb_.Dock = System.Windows.Forms.DockStyle.Top;
			this.stateGb_.Location = new System.Drawing.Point(0, 0);
			this.stateGb_.Name = "stateGb_";
			this.stateGb_.Size = new System.Drawing.Size(272, 140);
			this.stateGb_.TabIndex = 0;
			this.stateGb_.TabStop = false;
			this.stateGb_.Text = "State Parameters";
			// 
			// StateCTRL
			// 
			this.stateCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.stateCtrl_.Location = new System.Drawing.Point(3, 16);
			this.stateCtrl_.Name = "stateCtrl_";
			this.stateCtrl_.Size = new System.Drawing.Size(266, 121);
			this.stateCtrl_.TabIndex = 0;
			// 
			// LeftPN
			// 
			this.leftPn_.Controls.Add(this.stateFiltersPn_);
			this.leftPn_.Controls.Add(this.browseCtrl_);
			this.leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftPn_.DockPadding.Left = 4;
			this.leftPn_.DockPadding.Right = 4;
			this.leftPn_.DockPadding.Top = 4;
			this.leftPn_.Location = new System.Drawing.Point(0, 0);
			this.leftPn_.Name = "leftPn_";
			this.leftPn_.Size = new System.Drawing.Size(280, 490);
			this.leftPn_.TabIndex = 11;
			// 
			// BrowseCTRL
			// 
			this.browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browseCtrl_.Location = new System.Drawing.Point(4, 4);
			this.browseCtrl_.Name = "browseCtrl_";
			this.browseCtrl_.Size = new System.Drawing.Size(272, 486);
			this.browseCtrl_.TabIndex = 1;
			this.browseCtrl_.NodeSelected += new Technosoftware.AeSampleClient.BrowseCtrl.NodeSelectedEventHandler(this.BrowseCTRL_NodeSelected);
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.backBtn_);
			this.buttonsPn_.Controls.Add(this.doneBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Controls.Add(this.nextBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 490);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(792, 36);
			this.buttonsPn_.TabIndex = 0;
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
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(712, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 4;
			this.cancelBtn_.Text = "Cancel";
			// 
			// DoneBTN
			// 
			this.doneBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.doneBtn_.Location = new System.Drawing.Point(632, 8);
			this.doneBtn_.Name = "doneBtn_";
			this.doneBtn_.TabIndex = 0;
			this.doneBtn_.Text = "Done";
			this.doneBtn_.Click += new System.EventHandler(this.DoneBTN_Click);
			// 
			// SplitterV
			// 
			this.splitterV_.Location = new System.Drawing.Point(280, 0);
			this.splitterV_.Name = "splitterV_";
			this.splitterV_.Size = new System.Drawing.Size(3, 490);
			this.splitterV_.TabIndex = 12;
			this.splitterV_.TabStop = false;
			// 
			// SubscriptionEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 526);
			this.Controls.Add(this.rightPn_);
			this.Controls.Add(this.splitterV_);
			this.Controls.Add(this.leftPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "SubscriptionEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create Subscription";
			this.rightPn_.ResumeLayout(false);
			this.stateFiltersPn_.ResumeLayout(false);
			this.filtersGb_.ResumeLayout(false);
			this.stateGb_.ResumeLayout(false);
			this.leftPn_.ResumeLayout(false);
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

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

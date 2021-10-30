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
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A dialog that displays the current status of an OPC server.
    /// </summary>
    public class ItemIDsViewDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.ListView itemUrlsLv_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ItemIDsViewDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			// add columns.
			AddHeader("Attribute");
			AddHeader("ItemID");
			AddHeader("URL");
			
			// adjust column widths.
			AdjustColumns();
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
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.itemUrlsLv_ = new System.Windows.Forms.ListView();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 258);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(592, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(259, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Close";
			// 
			// ItemUrlsLV
			// 
			this.itemUrlsLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemUrlsLv_.Location = new System.Drawing.Point(0, 0);
			this.itemUrlsLv_.Name = "itemUrlsLv_";
			this.itemUrlsLv_.Size = new System.Drawing.Size(592, 258);
			this.itemUrlsLv_.TabIndex = 1;
			this.itemUrlsLv_.View = System.Windows.Forms.View.Details;
			// 
			// ItemIDsViewDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(592, 294);
			this.Controls.Add(this.itemUrlsLv_);
			this.Controls.Add(this.buttonsPn_);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(600, 400);
			this.MinimumSize = new System.Drawing.Size(300, 180);
			this.Name = "ItemIDsViewDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Translate Item IDs";
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private TsCAeServer mServer_ = null;
		private string mSource_ = null;
		private int mCategoryId_ = 0;
		private string mCondition_ = null;
		private Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute[] mAttributes_ = null;
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the event categories supported by the server.
		/// </summary>
		public void ShowDialog(
			TsCAeServer server,
			string        source, 
			string        condition,
			string        subcondition)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_    = server;
			mSource_    = source;
			mCondition_ = condition;
			
			// find attributes for condition.
			FindAttributes();

			// clear list view.
			itemUrlsLv_.Items.Clear();	

			try
			{
				// build attribute list.
				int[] attributeIDs = new int[mAttributes_.Length];

				for (int ii = 0; ii < mAttributes_.Length; ii++)
				{
					attributeIDs[ii] = mAttributes_[ii].ID;
				}

				// translate item ids
				TsCAeItemUrl[] itemUrls = mServer_.TranslateToItemIDs(
					mSource_, 
					mCategoryId_, 
					mCondition_, 
					subcondition,
					attributeIDs);

				// add to list.
				for (int ii = 0; ii < itemUrls.Length; ii++)
				{
					ListViewItem item = new ListViewItem(mAttributes_[ii].Name);

					item.SubItems.Add(itemUrls[ii].ItemName);
					item.SubItems.Add(itemUrls[ii].Url.ToString());
					item.Tag = itemUrls[ii];

					itemUrlsLv_.Items.Add(item);					
				}

				// adjust column widths.
				AdjustColumns();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}

			// show dialog.
			ShowDialog();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Populates the list box with the categories.
		/// </summary>
		private void AddHeader(string name)
		{
			ColumnHeader header = new ColumnHeader();
			header.Text = name;
			itemUrlsLv_.Columns.Add(header);
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < itemUrlsLv_.Columns.Count; ii++)
			{
				itemUrlsLv_.Columns[ii].Width = -2;
			}
		}

		/// <summary>
		/// Find attributes for condition by searching all categories.
		/// </summary>
		private void FindAttributes()
		{
			try
			{
				Technosoftware.DaAeHdaClient.Ae.TsCAeCategory[] categories = mServer_.QueryEventCategories((int)TsCAeEventType.Condition);

				for (int ii = 0; ii < categories.Length; ii++)
				{
					// fetch conditions for category.
					string[] conditions = mServer_.QueryConditionNames(categories[ii].ID);

					// check if this is the category containing the current condition.
					bool found = false;

					for (int jj = 0; jj < conditions.Length; jj++)
					{
						if (conditions[jj] == mCondition_)
						{
							mCategoryId_ = categories[ii].ID;
							found = true;
							break;
						}
					}

					// fetch the attributes when found.
					if (found)
					{
						mAttributes_ = mServer_.QueryEventAttributes(categories[ii].ID);
						break;
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return;
			}
		}
		#endregion
	}
}

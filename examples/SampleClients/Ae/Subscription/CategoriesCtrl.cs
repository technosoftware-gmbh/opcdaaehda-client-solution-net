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

using System;
using System.Collections;
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A control used to edit the state of a subscription.
    /// </summary>
    public class CategoriesCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView categoriesLv_;
		private System.Windows.Forms.GroupBox categoriesGb_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public CategoriesCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			AddHeader(categoriesLv_, "Name");
			AddHeader(categoriesLv_, "Event Type");
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.categoriesLv_ = new System.Windows.Forms.ListView();
			this.categoriesGb_ = new System.Windows.Forms.GroupBox();
			this.categoriesGb_.SuspendLayout();
			this.SuspendLayout();
			// 
			// CategoriesLV
			// 
			this.categoriesLv_.CheckBoxes = true;
			this.categoriesLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.categoriesLv_.FullRowSelect = true;
			this.categoriesLv_.Location = new System.Drawing.Point(3, 16);
			this.categoriesLv_.Name = "categoriesLv_";
			this.categoriesLv_.Size = new System.Drawing.Size(370, 181);
			this.categoriesLv_.TabIndex = 16;
			this.categoriesLv_.View = System.Windows.Forms.View.Details;
			this.categoriesLv_.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CategoriesLV_ItemCheck);
			// 
			// CategoriesGB
			// 
			this.categoriesGb_.Controls.Add(this.categoriesLv_);
			this.categoriesGb_.Dock = System.Windows.Forms.DockStyle.Top;
			this.categoriesGb_.Location = new System.Drawing.Point(0, 0);
			this.categoriesGb_.Name = "categoriesGb_";
			this.categoriesGb_.Size = new System.Drawing.Size(376, 200);
			this.categoriesGb_.TabIndex = 17;
			this.categoriesGb_.TabStop = false;
			this.categoriesGb_.Text = "Categories";
			// 
			// CategoriesCtrl
			// 
			this.Controls.Add(this.categoriesGb_);
			this.Name = "CategoriesCtrl";
			this.Size = new System.Drawing.Size(376, 200);
			this.categoriesGb_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private TsCAeServer mServer_ = null;
		private event CategoryCheckedEventHandler MCategoryChecked = null;
		#endregion

		#region Public Interface
		/// <summary>
		/// Raised when a category is checked.
		/// </summary>
		public event CategoryCheckedEventHandler CategoryChecked
		{
			add    { MCategoryChecked += value; }
			remove { MCategoryChecked += value; }
		}

		/// <summary>
		/// A delegate to receive notifications when categories are selected.
		/// </summary>
		public delegate void CategoryCheckedEventHandler(int categoryId, bool picked);

		/// <summary>
		/// Shows the available categories in the control.
		/// </summary>
		public void ShowCategories(TsCAeServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;
 
			ShowAvailableCategories();
		}

		/// <summary>
		/// Returns the currently selected categories.
		/// </summary>
		public int[] GetSelectedCategories()
		{
			ArrayList categories = new ArrayList();

			foreach (ListViewItem item in categoriesLv_.Items)
			{
				if (item.Checked)
				{
					categories.Add(((Technosoftware.DaAeHdaClient.Ae.TsCAeCategory)item.Tag).ID);
				}				
			}

			return (int[])categories.ToArray(typeof(int));
		}

		/// <summary>
		/// Sets the currently selected categories.
		/// </summary>
		public void SetSelectedCategories(int[] categoryIDs)
		{
			foreach (ListViewItem item in categoriesLv_.Items)
			{
				item.Checked = false;

				Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category = (Technosoftware.DaAeHdaClient.Ae.TsCAeCategory)item.Tag;

				for (int ii = 0; ii < categoryIDs.Length; ii++)
				{
					if (categoryIDs[ii] == category.ID)
					{
						item.Checked = true;
						break;
					}
				}		
			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Displays all available categories in the list view.
		/// </summary>
		private void ShowAvailableCategories()
		{
			categoriesLv_.Items.Clear();

			ShowAvailableCategories(TsCAeEventType.Simple);
			ShowAvailableCategories(TsCAeEventType.Tracking);
			ShowAvailableCategories(TsCAeEventType.Condition);

			categoriesLv_.Sorting = SortOrder.Ascending;
			categoriesLv_.Sort();

			AdjustColumns(categoriesLv_);
		}

		/// <summary>
		/// Displays the categories for the specified event type.
		/// </summary>
		private void ShowAvailableCategories(TsCAeEventType eventType)
		{
			try
			{
				Technosoftware.DaAeHdaClient.Ae.TsCAeCategory[] categories = mServer_.QueryEventCategories((int)eventType);

				foreach (Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category in categories)
				{
					ListViewItem item = new ListViewItem(category.Name);
					
					item.SubItems.Add(eventType.ToString());
					item.Tag = category;

					categoriesLv_.Items.Add(item);
				}
			}
			catch
			{
				// ignore errors.
			}
		}

		/// <summary>
		/// Populates the list box with the categories.
		/// </summary>
		private void AddHeader(ListView listview, string name)
		{
			ColumnHeader header = new ColumnHeader();
			header.Text = name;
			listview.Columns.Add(header);
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns(ListView listview)
		{
			// adjust column widths.
			for (int ii = 0; ii < listview.Columns.Count; ii++)
			{
				listview.Columns[ii].Width = -2;
			}
		}
		#endregion
		
		#region Event Handlers
		/// <summary>
		/// Raises a category selected event.
		/// </summary>
		private void CategoriesLV_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if (MCategoryChecked != null)
			{
				try
				{
					ListViewItem item = categoriesLv_.Items[e.Index];

					if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeCategory).IsInstanceOfType(item.Tag))
					{
						MCategoryChecked(((Technosoftware.DaAeHdaClient.Ae.TsCAeCategory)item.Tag).ID, (e.NewValue == CheckState.Checked));
					}
				}
				catch
				{
					// do nothing.
				}
			}		
		}
		#endregion
	}
}

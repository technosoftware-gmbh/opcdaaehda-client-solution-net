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
    public class CategoriesViewDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.ListView categoriesLv_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public CategoriesViewDlg()
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
			buttonsPn_ = new System.Windows.Forms.Panel();
			cancelBtn_ = new System.Windows.Forms.Button();
			categoriesLv_ = new System.Windows.Forms.ListView();
			buttonsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 202);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(292, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(109, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Close";
			// 
			// CategoriesLV
			// 
			categoriesLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			categoriesLv_.Location = new System.Drawing.Point(0, 0);
			categoriesLv_.Name = "categoriesLv_";
			categoriesLv_.Size = new System.Drawing.Size(292, 202);
			categoriesLv_.TabIndex = 1;
			categoriesLv_.View = System.Windows.Forms.View.Details;
			// 
			// CategoriesViewDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = cancelBtn_;
			ClientSize = new System.Drawing.Size(292, 238);
			Controls.Add(categoriesLv_);
			Controls.Add(buttonsPn_);
			MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(600, 400);
			MinimumSize = new System.Drawing.Size(300, 180);
			Name = "CategoriesViewDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Available Event Categories";
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		#region Private Members
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the event categories supported by the server.
		/// </summary>
		public void ShowDialog(TsCAeServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			// clear list view.
			categoriesLv_.Clear();	

			// add columns.
			AddHeader("ID");
			AddHeader("Name");
			AddHeader("Event Type");

			// fetch and populate categories.
			try
			{
				FetchCategories(server, TsCAeEventType.Simple);
				FetchCategories(server, TsCAeEventType.Tracking);
				FetchCategories(server, TsCAeEventType.Condition);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, Text);
			}

			// adjust column widths.
			AdjustColumns();

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
            ColumnHeader header = new ColumnHeader
            {
                Text = name
            };
            categoriesLv_.Columns.Add(header);
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < categoriesLv_.Columns.Count; ii++)
			{
				categoriesLv_.Columns[ii].Width = -2;
			}
		}

		/// <summary>
		/// Populates the list box with the categories.
		/// </summary>
		private void FetchCategories(TsCAeServer server, TsCAeEventType eventType)
		{
			Technosoftware.DaAeHdaClient.Ae.TsCAeCategory[] categories = server.QueryEventCategories((int)eventType);
            
			foreach (Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category in categories)
			{
				ListViewItem item = new ListViewItem(category.ID.ToString());

				item.SubItems.Add(category.Name);
				item.SubItems.Add(eventType.ToString());

				item.Tag = category;

				categoriesLv_.Items.Add(item);
			}
		}
		#endregion
	}
}

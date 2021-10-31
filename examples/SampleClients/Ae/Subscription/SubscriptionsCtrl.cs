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
    /// A control used to select a valid value for any bit mask expressed as an enumeration.
    /// </summary>
    public class SubscriptionsCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView subscriptionsLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		private System.Windows.Forms.ToolStripMenuItem addSubscriptionMi_;
		private System.Windows.Forms.ToolStripMenuItem deleteMi_;
		private System.Windows.Forms.ToolStripMenuItem activeMi_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.ToolStripMenuItem separator02_;
		private System.Windows.Forms.ToolStripMenuItem refreshMi_;
		private System.ComponentModel.IContainer components = null;

		public SubscriptionsCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			AddHeader(subscriptionsLv_, "Subscription");
			AddHeader(subscriptionsLv_, "Active");

			subscriptionsLv_.SmallImageList = Resources.Instance.ImageList;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
		
			base.Dispose(disposing);
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			subscriptionsLv_ = new System.Windows.Forms.ListView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			addSubscriptionMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			activeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			deleteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator02_ = new System.Windows.Forms.ToolStripMenuItem();
			refreshMi_ = new System.Windows.Forms.ToolStripMenuItem();
			SuspendLayout();
			// 
			// SubscriptionsLV
			// 
			subscriptionsLv_.ContextMenuStrip = popupMenu_;
			subscriptionsLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			subscriptionsLv_.FullRowSelect = true;
			subscriptionsLv_.Location = new System.Drawing.Point(0, 0);
			subscriptionsLv_.MultiSelect = false;
			subscriptionsLv_.Name = "subscriptionsLv_";
			subscriptionsLv_.Size = new System.Drawing.Size(400, 304);
			subscriptionsLv_.TabIndex = 0;
			subscriptionsLv_.View = System.Windows.Forms.View.Details;
			subscriptionsLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(SubscriptionsLV_MouseDown);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  addSubscriptionMi_,
																					  separator01_,
																					  editMi_,
																					  activeMi_,
																					  deleteMi_,
																					  separator02_,
																					  refreshMi_});
			// 
			// AddSubscriptionMI
			// 
			addSubscriptionMi_.ImageIndex = 0;
			addSubscriptionMi_.Text = "Add Subscription...";
			addSubscriptionMi_.Click += new System.EventHandler(AddSubscriptionMI_Click);
			// 
			// Separator01
			// 
			separator01_.ImageIndex = 1;
			separator01_.Text = "-";
			// 
			// EditMI
			// 
			editMi_.ImageIndex = 2;
			editMi_.Text = "Edit...";
			editMi_.Click += new System.EventHandler(EditMI_Click);
			// 
			// ActiveMI
			// 
			activeMi_.ImageIndex = 3;
			activeMi_.Text = "Active";
			activeMi_.Click += new System.EventHandler(ActiveMI_Click);
			// 
			// DeleteMI
			// 
			deleteMi_.ImageIndex = 4;
			deleteMi_.Text = "Delete";
			deleteMi_.Click += new System.EventHandler(DeleteMI_Click);
			// 
			// Separator02
			// 
			separator02_.ImageIndex = 5;
			separator02_.Text = "-";
			// 
			// RefreshMI
			// 
			refreshMi_.ImageIndex = 6;
			refreshMi_.Text = "Refresh";
			refreshMi_.Click += new System.EventHandler(RefreshMI_Click);
			// 
			// SubscriptionsCtrl
			// 
			Controls.Add(subscriptionsLv_);
			Name = "SubscriptionsCtrl";
			Size = new System.Drawing.Size(400, 304);
			ResumeLayout(false);

		}
		#endregion
	
		#region Private Members
		private TsCAeServer mServer_ = null;
		private event SubscriptionActionEventHandler MSubscriptionAction = null;
		#endregion
		
		#region Public Interface
		/// <summary>
		/// Raised when a area or source node in the tree is selected.
		/// </summary>
		public event SubscriptionActionEventHandler SubscriptionAction
		{
			add    { MSubscriptionAction += value; }
			remove { MSubscriptionAction += value; }
		}

		/// <summary>
		/// A delegate to receive notifications when categories are selected.
		/// </summary>
		public delegate void SubscriptionActionEventHandler(TsCAeSubscription subscription, bool deleted);

		/// <summary>
		/// Displays current subscriptions for the server.
		/// </summary>
		public void ShowSubscriptions(TsCAeServer server)
		{
			mServer_ = server;

			subscriptionsLv_.Items.Clear();

			// nothing more to do if no server provided.
			if (mServer_ == null)
			{
				return;
			}

			// add subscriptions.
			foreach (TsCAeSubscription subscription in mServer_.Subscriptions)
			{
				Add(subscription);
				
				// send notifications.
				if (subscription.Active)
				{
					if (MSubscriptionAction != null)
					{
						MSubscriptionAction(subscription, false);
					}
				}
			}

			// adjust columns.
			AdjustColumns(subscriptionsLv_);
		}

		/// <summary>
		/// Prompts the user to create a new subscription.
		/// </summary>
		public void AddSubscription()
		{
			try
			{
				// show properties dialog.
				TsCAeSubscription subscription = new SubscriptionEditDlg().ShowDialog(mServer_, null);

				if (subscription == null)
				{
					return;
				}

				// add to list.
				Add(subscription);

				// adjust columns.
				AdjustColumns(subscriptionsLv_);

				// send notifications.
				if (subscription.Active)
				{
					if (MSubscriptionAction != null)
					{
						MSubscriptionAction(subscription, false);
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Adds a subscription to the list.
		/// </summary>
		private void Add(TsCAeSubscription subscription)
		{			
			ListViewItem item = new ListViewItem(subscription.Name, Resources.IMAGE_ENVELOPE);

			item.SubItems.Add((subscription.Active)?"Yes":"No");
			item.Tag = subscription;

			subscriptionsLv_.Items.Add(item);
		}		
		
		/// <summary>
		/// Updates a subscription in the list.
		/// </summary>
		private void Update(ListViewItem item)
		{			
			TsCAeSubscription subscription = (TsCAeSubscription)item.Tag;

			item.Text             = subscription.Name;
			item.SubItems[1].Text = (subscription.Active)?"Yes":"No";
		}		

		/// <summary>
		/// Populates the list box with the categories.
		/// </summary>
		private void AddHeader(ListView listview, string name)
		{
            ColumnHeader header = new ColumnHeader
            {
                Text = name
            };
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
		/// Updates the state of context menus based on the current selection.
		/// </summary>
		private void SubscriptionsLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set defaults.
			addSubscriptionMi_.Enabled = true;
			editMi_.Enabled            = false;
			activeMi_.Enabled          = false;
			deleteMi_.Enabled          = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = subscriptionsLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked node.
			clickedItem.Selected = true;

			// check for subscription.
			if (typeof(TsCAeSubscription).IsInstanceOfType(clickedItem.Tag))
			{
				editMi_.Enabled   = true;
				activeMi_.Enabled = true;
				deleteMi_.Enabled = true;

				activeMi_.Checked = ((TsCAeSubscription)clickedItem.Tag).Active;
				return;
			}
		}	

		/// <summary>
		/// Prompts the user to create a new subscription.
		/// </summary>
		private void AddSubscriptionMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				AddSubscription();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}		
		}

		/// <summary>
		/// Edits the state of a subscription.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				ListViewItem item = subscriptionsLv_.SelectedItems[0];
				TsCAeSubscription subscription = (TsCAeSubscription)item.Tag;

				// show properties dialog.
				bool active = subscription.Active;

				new SubscriptionEditDlg().ShowDialog(mServer_, subscription);

				if (subscription == null)
				{
					return;
				}

				// update list.
				Update(item);

				// send notifications.
				if (active != subscription.Active)
				{
					if (MSubscriptionAction != null)
					{
						MSubscriptionAction(subscription, !subscription.Active);
					}
				}

				// adjust columns.
				AdjustColumns(subscriptionsLv_);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}				
		}

		/// <summary>
		/// Toggles the active/inactive state for a subscription.
		/// </summary>
		private void ActiveMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				ListViewItem item = subscriptionsLv_.SelectedItems[0];
				TsCAeSubscription subscription = (TsCAeSubscription)item.Tag;

                TsCAeSubscriptionState state = new TsCAeSubscriptionState
                {
                    Active = !activeMi_.Checked
                };

                subscription.ModifyState((int)TsCAeStateMask.Active, state);
				
				// toggle checkbox.
				activeMi_.Checked = !activeMi_.Checked;
	
				// update list.
				Update(item);

				// receive notifications.
				if (MSubscriptionAction != null)
				{
					MSubscriptionAction(subscription, !subscription.Active);
				}

				// adjust columns.
				AdjustColumns(subscriptionsLv_);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}				
		}

		/// <summary>
		/// Deletes a subscription.
		/// </summary>
		private void DeleteMI_Click(object sender, System.EventArgs e)
		{
			try
			{	
				ListViewItem item = subscriptionsLv_.SelectedItems[0];
				TsCAeSubscription subscription = (TsCAeSubscription)item.Tag;

				// send notifications.
				if (MSubscriptionAction != null)
				{
					MSubscriptionAction(subscription, true);
				}

				// remove from list.
				item.Remove();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}			
		}

		/// <summary>
		/// Refreshes the current subscription.
		/// </summary>
		private void RefreshMI_Click(object sender, System.EventArgs e)
		{
			try
			{	
				ListViewItem item = subscriptionsLv_.SelectedItems[0];
				TsCAeSubscription subscription = (TsCAeSubscription)item.Tag;		

				subscription.Refresh();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}		
		}
		#endregion

	}
}
  
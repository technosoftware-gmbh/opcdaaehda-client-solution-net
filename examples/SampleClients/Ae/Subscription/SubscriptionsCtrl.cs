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
			this.subscriptionsLv_ = new System.Windows.Forms.ListView();
			this.popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			this.addSubscriptionMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			this.editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.activeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.separator02_ = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.SuspendLayout();
			// 
			// SubscriptionsLV
			// 
			this.subscriptionsLv_.ContextMenuStrip = this.popupMenu_;
			this.subscriptionsLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.subscriptionsLv_.FullRowSelect = true;
			this.subscriptionsLv_.Location = new System.Drawing.Point(0, 0);
			this.subscriptionsLv_.MultiSelect = false;
			this.subscriptionsLv_.Name = "subscriptionsLv_";
			this.subscriptionsLv_.Size = new System.Drawing.Size(400, 304);
			this.subscriptionsLv_.TabIndex = 0;
			this.subscriptionsLv_.View = System.Windows.Forms.View.Details;
			this.subscriptionsLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SubscriptionsLV_MouseDown);
			// 
			// PopupMenu
			// 
			this.popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  this.addSubscriptionMi_,
																					  this.separator01_,
																					  this.editMi_,
																					  this.activeMi_,
																					  this.deleteMi_,
																					  this.separator02_,
																					  this.refreshMi_});
			// 
			// AddSubscriptionMI
			// 
			this.addSubscriptionMi_.ImageIndex = 0;
			this.addSubscriptionMi_.Text = "Add Subscription...";
			this.addSubscriptionMi_.Click += new System.EventHandler(this.AddSubscriptionMI_Click);
			// 
			// Separator01
			// 
			this.separator01_.ImageIndex = 1;
			this.separator01_.Text = "-";
			// 
			// EditMI
			// 
			this.editMi_.ImageIndex = 2;
			this.editMi_.Text = "Edit...";
			this.editMi_.Click += new System.EventHandler(this.EditMI_Click);
			// 
			// ActiveMI
			// 
			this.activeMi_.ImageIndex = 3;
			this.activeMi_.Text = "Active";
			this.activeMi_.Click += new System.EventHandler(this.ActiveMI_Click);
			// 
			// DeleteMI
			// 
			this.deleteMi_.ImageIndex = 4;
			this.deleteMi_.Text = "Delete";
			this.deleteMi_.Click += new System.EventHandler(this.DeleteMI_Click);
			// 
			// Separator02
			// 
			this.separator02_.ImageIndex = 5;
			this.separator02_.Text = "-";
			// 
			// RefreshMI
			// 
			this.refreshMi_.ImageIndex = 6;
			this.refreshMi_.Text = "Refresh";
			this.refreshMi_.Click += new System.EventHandler(this.RefreshMI_Click);
			// 
			// SubscriptionsCtrl
			// 
			this.Controls.Add(this.subscriptionsLv_);
			this.Name = "SubscriptionsCtrl";
			this.Size = new System.Drawing.Size(400, 304);
			this.ResumeLayout(false);

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

				TsCAeSubscriptionState state = new TsCAeSubscriptionState();
				state.Active = !activeMi_.Checked;

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
  
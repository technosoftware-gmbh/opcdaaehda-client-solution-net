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
using System.Drawing;
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A control used to edit the state of a subscription.
    /// </summary>
    public class EventListCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView notificationsLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem clearAllMi_;
		private System.Windows.Forms.ToolStripMenuItem deleteMi_;
		private System.Windows.Forms.ToolStripMenuItem acknowledgeMi_;
		private System.Windows.Forms.ToolStripMenuItem viewMi_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public EventListCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			notificationsLv_.SmallImageList = Resources.Instance.ImageList;

			AddHeader(notificationsLv_, "Event Time");
			AddHeader(notificationsLv_, "Severity");
			AddHeader(notificationsLv_, "Source");
			AddHeader(notificationsLv_, "Ack Req");
			AddHeader(notificationsLv_, "Condition");
			AddHeader(notificationsLv_, "Message");

			AdjustColumns(notificationsLv_);
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
			notificationsLv_ = new System.Windows.Forms.ListView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			viewMi_ = new System.Windows.Forms.ToolStripMenuItem();
			acknowledgeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			deleteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			clearAllMi_ = new System.Windows.Forms.ToolStripMenuItem();
			SuspendLayout();
			// 
			// NotificationsLV
			// 
			notificationsLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			notificationsLv_.FullRowSelect = true;
			notificationsLv_.Location = new System.Drawing.Point(0, 0);
			notificationsLv_.Name = "notificationsLv_";
			notificationsLv_.Size = new System.Drawing.Size(376, 200);
			notificationsLv_.TabIndex = 16;
			notificationsLv_.View = System.Windows.Forms.View.Details;
			notificationsLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(NotificationsLV_MouseDown);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  viewMi_,
																					  acknowledgeMi_,
																					  deleteMi_,
																					  separator01_,
																					  clearAllMi_});
			// 
			// ViewMI
			// 
			viewMi_.ImageIndex = 0;
			viewMi_.Text = "View...";
			viewMi_.Click += new System.EventHandler(ViewMI_Click);
			// 
			// AcknowledgeMI
			// 
			acknowledgeMi_.ImageIndex = 1;
			acknowledgeMi_.Text = "Acknowledge...";
			acknowledgeMi_.Click += new System.EventHandler(AcknowledgeMI_Click);
			// 
			// DeleteMI
			// 
			deleteMi_.ImageIndex = 2;
			deleteMi_.Text = "Delete";
			deleteMi_.Click += new System.EventHandler(DeleteMI_Click);
			// 
			// Separator01
			// 
			separator01_.ImageIndex = 3;
			separator01_.Text = "-";
			// 
			// ClearAllMI
			// 
			clearAllMi_.ImageIndex = 4;
			clearAllMi_.Text = "Clear All";
			clearAllMi_.Click += new System.EventHandler(ClearAllMI_Click);
			// 
			// EventListCtrl
			// 
			ContextMenuStrip = popupMenu_;
			Controls.Add(notificationsLv_);
			Name = "EventListCtrl";
			Size = new System.Drawing.Size(376, 200);
			ResumeLayout(false);

		}
		#endregion

		#region Private Members
		TsCAeServer mServer_ = null;
		Hashtable mSubscriptions_ = new Hashtable();
		#endregion

		private class State
		{
			public TsCAeSubscription      Subscription;
			public TsCAeDataChangedEventHandler EventHandler;
		}

		#region Public Interface
		/// <summary>
		/// Adds a subscription to the control.
		/// </summary>
		public void AddSubscription(TsCAeSubscription subscription)
		{
			if (subscription == null) throw new ArgumentNullException();
			if (mSubscriptions_.Contains(subscription.ClientHandle)) throw new ArgumentException("Subscription exists");

			// update current server.
			if (mServer_ != subscription.Server)
			{
				mServer_ = subscription.Server;
			}

            State state = new State
            {
                Subscription = subscription,
                EventHandler = new TsCAeDataChangedEventHandler(Subscription_EventChanged)
            };

            subscription.DataChangedEvent += new TsCAeDataChangedEventHandler(Subscription_EventChanged);

			mSubscriptions_.Add(subscription.ClientHandle, state);
		}

		/// <summary>
		/// Removes a subscription from the control.
		/// </summary>
		public void RemoveSubscription(TsCAeSubscription subscription)
		{
			State state = (State)mSubscriptions_[subscription.ClientHandle];

			if (state != null)
			{
				// unregister call backs.
                subscription.DataChangedEvent -= state.EventHandler;

				// remove subscription.
				mSubscriptions_.Remove(subscription.ClientHandle);

				// compile list of item to delete.
				ArrayList itemsToDelete = new ArrayList();

				foreach (ListViewItem item in notificationsLv_.Items)
				{
					TsCAeEventNotification notification = (TsCAeEventNotification)item.Tag;

					if (notification.ClientHandle.Equals(subscription.ClientHandle))
					{
						itemsToDelete.Add(item);
					}
				}

				// delete items.
				foreach (ListViewItem item in itemsToDelete)
				{
					item.Remove();
				}
			}
		}

		/// <summary>
		/// Removes all subscriptions from the control.
		/// </summary>
		public void RemoveSubscriptions()
		{
			// close callback connection.
			foreach (State state in mSubscriptions_.Values)
			{
                try { state.Subscription.DataChangedEvent -= state.EventHandler; }
				catch {}
			}

			// clear subscriptions.
			mSubscriptions_.Clear();

			// clear events.
			 notificationsLv_.Items.Clear();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Adds the area or source to the list.
		/// </summary>
		public void Add(TsCAeEventNotification notification, bool refresh)
		{
			ListViewItem item = new ListViewItem(notification.Time.ToString("HH:mm:ss.fff"));
			
			item.SubItems.Add(notification.Severity.ToString());
			item.SubItems.Add(notification.SourceID);
			item.SubItems.Add((notification.AckRequired)?"Y":"");
			item.SubItems.Add(notification.ConditionName + "." + notification.SubConditionName);
			item.SubItems.Add(notification.Message);

			item.ImageIndex = (notification.EventType != TsCAeEventType.Condition)?Resources.IMAGE_YELLOW_SCROLL:Resources.IMAGE_GREEN_SCROLL;
			item.Tag        = notification;
			item.ForeColor  = (refresh)?Color.IndianRed:Color.Empty;

			notificationsLv_.Items.Insert(0, item);
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
		/// Enables items in popup menu based on current selection.
		/// </summary>
		private void NotificationsLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// disable everything.
			viewMi_.Enabled        = false;
			acknowledgeMi_.Enabled = false;
			deleteMi_.Enabled      = false;
			clearAllMi_.Enabled    = true;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = notificationsLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked node.
			clickedItem.Selected = true;

			// check for single selection.
			if (notificationsLv_.SelectedItems.Count == 1)
			{
				viewMi_.Enabled = true;
			}

			// check for multiple selection.
			if (notificationsLv_.SelectedItems.Count > 0)
			{
				acknowledgeMi_.Enabled = true;
				deleteMi_.Enabled      = true;

				// make sure all selected events require acknowledgement.
				foreach (ListViewItem item in notificationsLv_.SelectedItems)
				{
					TsCAeEventNotification notification = (TsCAeEventNotification)item.Tag;

					if (!notification.AckRequired)
					{
						acknowledgeMi_.Enabled = false;
						break;
					}
				}
			}
		}

		/// <summary>
		/// Invokes the default action for the current selection.
		/// </summary>
		private void NotificationsLV_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if (notificationsLv_.SelectedItems.Count != 1)
				{
					return;
				}

				if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(notificationsLv_.SelectedItems[0].Tag))
				{
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void Subscription_EventChanged(TsCAeEventNotification[] notifications, bool refresh, bool lastRefresh)
		{
			// synchronize the HMI thread.
			if (InvokeRequired)
			{
                BeginInvoke(new TsCAeDataChangedEventHandler(Subscription_EventChanged), new object[] { notifications, refresh, lastRefresh });
                return;
			}

			// gray out old entries.
			foreach (ListViewItem item in notificationsLv_.Items)
			{
				item.ForeColor = Color.Gray;
			}

			// add new entries.
			for (int ii = 0; ii < notifications.Length; ii++)
			{
				Add(notifications[ii], refresh);
			}

			AdjustColumns(notificationsLv_);
		}
		#endregion

		/// <summary>
		/// Displays a detailed view of an event notification.
		/// </summary>
		private void ViewMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (notificationsLv_.SelectedItems.Count != 1)
				{
					return;
				}

				TsCAeEventNotification notification = (TsCAeEventNotification)notificationsLv_.SelectedItems[0].Tag;
				State state = (State)mSubscriptions_[notification.ClientHandle];

				new NotificationDlg().ShowDialog(state.Subscription, notification);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Sends acknowledgement for an event notification.
		/// </summary>
		private void AcknowledgeMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// get current selection.
				TsCAeEventNotification[] notifications = new TsCAeEventNotification[notificationsLv_.SelectedItems.Count];

				for (int ii = 0; ii < notifications.Length; ii++)
				{
					notifications[ii] = (TsCAeEventNotification)notificationsLv_.SelectedItems[ii].Tag;
				}

				// show dialog.
				bool result = new AcknowledgerEditDlg().ShowDialog(mServer_, notifications);

				// delete events if successful.
				if (result)
				{
					DeleteMI_Click(sender, e);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}		
		}

		/// <summary>
		/// Deletes the selected events from the list view.
		/// </summary>
		private void DeleteMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// build list if items to remove.
				ArrayList items = new ArrayList();

				foreach (ListViewItem item in notificationsLv_.SelectedItems)
				{
					items.Add(item);
				}

				// actually remove items from list.
				foreach (ListViewItem item in items)
				{
					item.Remove();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}		
		}

		/// <summary>
		/// Deletes all events from the list view.
		/// </summary>
		private void ClearAllMI_Click(object sender, System.EventArgs e)
		{	
			try
			{
				notificationsLv_.Items.Clear();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}	
		}
	}
}

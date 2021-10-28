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
using System.Collections;
using System.Windows.Forms;

using SampleClients.Da.Item;
using SampleClients.Da.Server;

using Technosoftware.DaAeHdaClient;
using SampleClients.Common;
using Technosoftware.DaAeHdaClient.Da;

using BrowseItemsDlg = SampleClients.Da.Browse.BrowseItemsDlg;

#endregion

namespace SampleClients.Da.Subscription
{
    /// <summary>
    /// Delegate to receive subscription created/deleted events.
    /// </summary>
    public delegate void SubscriptionModifiedCallback(TsCDaSubscription subscription, bool deleted);
	
	/// <summary>
	/// A tree control used to navigate and manipulate a set of subscriptions for a DA server.
	/// </summary>
	public class SubscriptionsTreeCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView subscriptionTv_;
		private System.Windows.Forms.ContextMenuStrip serverPopupMenu_;
		private System.Windows.Forms.ContextMenuStrip subscriptionPopupMenu_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionDeleteMi_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionAddItemsMi_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionEditItemsMi_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionEditMi_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionReadMi_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionWriteMi_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionRefreshMi_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionActiveMi_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionEnabledMi_;
		private System.Windows.Forms.ToolStripMenuItem separatorS1_;
		private System.Windows.Forms.ToolStripMenuItem separatorS2_;
		private System.Windows.Forms.ToolStripMenuItem serverViewStatusMi_;
		private System.Windows.Forms.ToolStripMenuItem serverReadItemsMi_;
		private System.Windows.Forms.ToolStripMenuItem serverWriteItemsMi_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionCreateMi_;
		private System.Windows.Forms.ContextMenuStrip itemPopupMenu_;
		private System.Windows.Forms.ToolStripMenuItem itemEditMi_;
		private System.Windows.Forms.ToolStripMenuItem itemRemoveMi_;
		private System.Windows.Forms.ToolStripMenuItem serverDisconnectMi_;
		private System.Windows.Forms.ToolStripMenuItem serverBrowseItemsMi_;
		private System.Windows.Forms.ToolStripMenuItem separator02_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		private System.Windows.Forms.ToolStripMenuItem separatorI1_;
		private System.Windows.Forms.ToolStripMenuItem itemActiveMi_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionAsyncReadMi_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionAsyncWriteMi_;
		private System.Windows.Forms.ToolStripMenuItem separatorS3_;
		private System.Windows.Forms.ToolStripMenuItem editOptionsMi_;
		private System.Windows.Forms.ToolStripMenuItem subscriptionEditOptionsMi_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public SubscriptionsTreeCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			subscriptionTv_.ImageList = Resources.Instance.ImageList;
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
			this.subscriptionTv_ = new System.Windows.Forms.TreeView();
			this.serverPopupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			this.serverViewStatusMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.editOptionsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.serverDisconnectMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			this.serverBrowseItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionCreateMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.separator02_ = new System.Windows.Forms.ToolStripMenuItem();
			this.serverReadItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.serverWriteItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionPopupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			this.subscriptionEditMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionDeleteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionAddItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionEditItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.separatorS1_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionActiveMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionEnabledMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.separatorS2_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionReadMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionWriteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.separatorS3_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionAsyncReadMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionAsyncWriteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionRefreshMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.itemPopupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			this.itemEditMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.itemRemoveMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.separatorI1_ = new System.Windows.Forms.ToolStripMenuItem();
			this.itemActiveMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.subscriptionEditOptionsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			this.SuspendLayout();
			// 
			// SubscriptionTV
			// 
			this.subscriptionTv_.ContextMenuStrip = this.serverPopupMenu_;
			this.subscriptionTv_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.subscriptionTv_.ImageIndex = -1;
			this.subscriptionTv_.Location = new System.Drawing.Point(0, 0);
			this.subscriptionTv_.Name = "subscriptionTv_";
			this.subscriptionTv_.SelectedImageIndex = -1;
			this.subscriptionTv_.Size = new System.Drawing.Size(360, 400);
			this.subscriptionTv_.TabIndex = 0;
			this.subscriptionTv_.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SubscriptionTV_MouseDown);
			// 
			// Server_PopupMenu
			// 
			this.serverPopupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																							 this.serverViewStatusMi_,
																							 this.editOptionsMi_,
																							 this.serverDisconnectMi_,
																							 this.separator01_,
																							 this.serverBrowseItemsMi_,
																							 this.subscriptionCreateMi_,
																							 this.separator02_,
																							 this.serverReadItemsMi_,
																							 this.serverWriteItemsMi_});
			// 
			// ServerViewStatusMI
			// 
			this.serverViewStatusMi_.ImageIndex = 0;
			this.serverViewStatusMi_.Text = "&View Status...";
			this.serverViewStatusMi_.Click += new System.EventHandler(this.ServerViewStatusMI_Click);
			// 
			// EditOptionsMI
			// 
			this.editOptionsMi_.ImageIndex = 1;
			this.editOptionsMi_.Text = "Edit &Options...";
			this.editOptionsMi_.Click += new System.EventHandler(this.EditOptionsMI_Click);
			// 
			// ServerDisconnectMI
			// 
			this.serverDisconnectMi_.ImageIndex = 2;
			this.serverDisconnectMi_.Text = "&Disconnect";
			this.serverDisconnectMi_.Click += new System.EventHandler(this.ServerDisconnectMI_Click);
			// 
			// Separator01
			// 
			this.separator01_.ImageIndex = 3;
			this.separator01_.Text = "-";
			// 
			// ServerBrowseItemsMI
			// 
			this.serverBrowseItemsMi_.ImageIndex = 4;
			this.serverBrowseItemsMi_.Text = "&Browse Items...";
			this.serverBrowseItemsMi_.Click += new System.EventHandler(this.ServerBrowseItemsMI_Click);
			// 
			// SubscriptionCreateMI
			// 
			this.subscriptionCreateMi_.ImageIndex = 5;
			this.subscriptionCreateMi_.Text = "&Create Subscription...";
			this.subscriptionCreateMi_.Click += new System.EventHandler(this.CreateSubscriptionMI_Click);
			// 
			// Separator02
			// 
			this.separator02_.ImageIndex = 6;
			this.separator02_.Text = "-";
			// 
			// ServerReadItemsMI
			// 
			this.serverReadItemsMi_.ImageIndex = 7;
			this.serverReadItemsMi_.Text = "&Read...";
			this.serverReadItemsMi_.Click += new System.EventHandler(this.ServerReadItemsMI_Click);
			// 
			// ServerWriteItemsMI
			// 
			this.serverWriteItemsMi_.ImageIndex = 8;
			this.serverWriteItemsMi_.Text = "&Write...";
			this.serverWriteItemsMi_.Click += new System.EventHandler(this.ServerWriteItemsMI_Click);
			// 
			// Subscription_PopupMenu
			// 
			this.subscriptionPopupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																								   this.subscriptionEditMi_,
																								   this.subscriptionEditOptionsMi_,
																								   this.subscriptionDeleteMi_,
																								   this.subscriptionAddItemsMi_,
																								   this.subscriptionEditItemsMi_,
																								   this.separatorS1_,
																								   this.subscriptionActiveMi_,
																								   this.subscriptionEnabledMi_,
																								   this.separatorS2_,
																								   this.subscriptionReadMi_,
																								   this.subscriptionWriteMi_,
																								   this.separatorS3_,
																								   this.subscriptionAsyncReadMi_,
																								   this.subscriptionAsyncWriteMi_,
																								   this.subscriptionRefreshMi_});
			// 
			// SubscriptionEditMI
			// 
			this.subscriptionEditMi_.ImageIndex = 0;
			this.subscriptionEditMi_.Text = "&Edit State...";
			this.subscriptionEditMi_.Click += new System.EventHandler(this.SubscriptionEditMI_Click);
			// 
			// SubscriptionDeleteMI
			// 
			this.subscriptionDeleteMi_.ImageIndex = 2;
			this.subscriptionDeleteMi_.Text = "&Delete";
			this.subscriptionDeleteMi_.Click += new System.EventHandler(this.SubscriptionDeleteMI_Click);
			// 
			// SubscriptionAddItemsMI
			// 
			this.subscriptionAddItemsMi_.ImageIndex = 3;
			this.subscriptionAddItemsMi_.Text = "&Add Items..";
			this.subscriptionAddItemsMi_.Click += new System.EventHandler(this.SubscriptionAddItemsMI_Click);
			// 
			// SubscriptionEditItemsMI
			// 
			this.subscriptionEditItemsMi_.ImageIndex = 4;
			this.subscriptionEditItemsMi_.Text = "E&dit Items...";
			this.subscriptionEditItemsMi_.Click += new System.EventHandler(this.SubscriptionEditItemsMI_Click);
			// 
			// SeparatorS1
			// 
			this.separatorS1_.ImageIndex = 5;
			this.separatorS1_.Text = "-";
			// 
			// SubscriptionActiveMI
			// 
			this.subscriptionActiveMi_.ImageIndex = 6;
			this.subscriptionActiveMi_.Text = "Acti&ve";
			this.subscriptionActiveMi_.Click += new System.EventHandler(this.SubscriptionActiveMI_Click);
			// 
			// SubscriptionEnabledMI
			// 
			this.subscriptionEnabledMi_.ImageIndex = 7;
			this.subscriptionEnabledMi_.Text = "E&nabled";
			this.subscriptionEnabledMi_.Click += new System.EventHandler(this.SubscriptionEnabledMI_Click);
			// 
			// SeparatorS2
			// 
			this.separatorS2_.ImageIndex = 8;
			this.separatorS2_.Text = "-";
			// 
			// SubscriptionReadMI
			// 
			this.subscriptionReadMi_.ImageIndex = 9;
			this.subscriptionReadMi_.Text = "&Read...";
			this.subscriptionReadMi_.Click += new System.EventHandler(this.SubscriptionReadMI_Click);
			// 
			// SubscriptionWriteMI
			// 
			this.subscriptionWriteMi_.ImageIndex = 10;
			this.subscriptionWriteMi_.Text = "&Write...";
			this.subscriptionWriteMi_.Click += new System.EventHandler(this.SubscriptionWriteMI_Click);
			// 
			// SeparatorS3
			// 
			this.separatorS3_.ImageIndex = 11;
			this.separatorS3_.Text = "-";
			// 
			// SubscriptionAsyncReadMI
			// 
			this.subscriptionAsyncReadMi_.ImageIndex = 12;
			this.subscriptionAsyncReadMi_.Text = "Async Read...";
			this.subscriptionAsyncReadMi_.Click += new System.EventHandler(this.SubscriptionAsyncReadMI_Click);
			// 
			// SubscriptionAsyncWriteMI
			// 
			this.subscriptionAsyncWriteMi_.ImageIndex = 13;
			this.subscriptionAsyncWriteMi_.Text = "Async Write...";
			this.subscriptionAsyncWriteMi_.Click += new System.EventHandler(this.SubscriptionAsyncWriteMI_Click);
			// 
			// SubscriptionRefreshMI
			// 
			this.subscriptionRefreshMi_.ImageIndex = 14;
			this.subscriptionRefreshMi_.Text = "Refre&sh";
			this.subscriptionRefreshMi_.Click += new System.EventHandler(this.SubscriptionRefreshMI_Click);
			// 
			// Item_PopupMenu
			// 
			this.itemPopupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																						   this.itemEditMi_,
																						   this.itemRemoveMi_,
																						   this.separatorI1_,
																						   this.itemActiveMi_});
			// 
			// ItemEditMI
			// 
			this.itemEditMi_.ImageIndex = 0;
			this.itemEditMi_.Text = "&Edit...";
			this.itemEditMi_.Click += new System.EventHandler(this.ItemEditMI_Click);
			// 
			// ItemRemoveMI
			// 
			this.itemRemoveMi_.ImageIndex = 1;
			this.itemRemoveMi_.Text = "&Delete";
			this.itemRemoveMi_.Click += new System.EventHandler(this.ItemRemoveMI_Click);
			// 
			// SeparatorI1
			// 
			this.separatorI1_.ImageIndex = 2;
			this.separatorI1_.Text = "-";
			// 
			// ItemActiveMI
			// 
			this.itemActiveMi_.ImageIndex = 3;
			this.itemActiveMi_.Text = "&Active";
			this.itemActiveMi_.Click += new System.EventHandler(this.ItemActiveMI_Click);
			// 
			// SubscriptionEditOptionsMI
			// 
			this.subscriptionEditOptionsMi_.ImageIndex = 1;
			this.subscriptionEditOptionsMi_.Text = "Edit &Options...";
			this.subscriptionEditOptionsMi_.Click += new System.EventHandler(this.SubscriptionEditOptionsMI_Click);
			// 
			// SubscriptionsTreeCtrl
			// 
			this.Controls.Add(this.subscriptionTv_);
			this.Name = "SubscriptionsTreeCtrl";
			this.Size = new System.Drawing.Size(360, 400);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The underlying tree view. 
		/// </summary>
		public TreeView View {get{return subscriptionTv_;}}

		/// <summary>
		/// Raised when a subscrition is created/deleted.
		/// </summary>
		public event SubscriptionModifiedCallback SubscriptionModified = null;

		/// <summary>
		/// Initializes the control with the specified server.
		/// </summary>
		public void Initialize(TsCDaServer server)
		{
			// clear the tree view.
			subscriptionTv_.Nodes.Clear();

			// check if nothing to do.
			if (server == null) return;

			// connect to server if not already.
			if (!server.IsConnected)
			{
				server.Connect((OpcConnectData)null);
			}

			// add the root node.
            TreeNode node = new TreeNode(server.ServerName);
			node.ImageIndex = node.SelectedImageIndex = Resources.IMAGE_LOCAL_SERVER;
			node.Tag = server;

			subscriptionTv_.Nodes.Add(node);

			// add any existing subscriptions.
			foreach (TsCDaSubscription subscription in server.Subscriptions)
			{
				AddSubscription(node, subscription);

				if (SubscriptionModified != null)
				{
					SubscriptionModified(subscription, false);
				}
			}

			// expand root node.
			node.Expand();
		}

		/// <summary>
		/// Initializes the control with the specified server.
		/// </summary>
		public void Initialize(TsCDaSubscription subscription)
		{
			if (subscription == null) throw new ArgumentNullException("subscription");

			AddSubscription(null, subscription);
		}

		/// <summary>
		/// Disconnects from the server.
		/// </summary>
		public void Disconnect()
		{
			foreach (TreeNode node in subscriptionTv_.Nodes)
			{
				Disconnect(node, (TsCDaServer)node.Tag);
			}
		}

		/// <summary>
		/// Displays the server status in a model dialog.
		/// </summary>
		private void ViewStatus(TsCDaServer server)
		{
			new ServerStatusDlg().ShowDialog(server);	
		}

		/// <summary>
		/// Disconnects from the server and clears all objects.
		/// </summary>
		private void Disconnect(TreeNode node, TsCDaServer server)
		{
			// remove all subscriptions.
			foreach (TreeNode child in node.Nodes)
			{
				if (IsSubscriptionNode(child))
				{
					if (SubscriptionModified != null)
					{
						SubscriptionModified((TsCDaSubscription)child.Tag, true);
					}

					TsCDaSubscription subscription = (TsCDaSubscription)child.Tag;
					server.CancelSubscription(subscription);
					subscription.Dispose();				
				}
			}

			// disconnect server.
			server.Disconnect();

			// remove tree from view.
			node.Remove();
		}
		
		/// <summary>
		/// Displays the address space of the server in a modal dialog.
		/// </summary>
		private void BrowseItems(TsCDaServer server)
		{
			new BrowseItemsDlg().Initialize(server);
		}

		/// <summary>
		/// Prompts the user to select a set of items and reads them from the server.
		/// </summary>
		private void ReadItems(TsCDaServer server)
		{
			new ReadItemsDlg().ShowDialog(server);	
		}

		/// <summary>
		/// Prompts the user to specify a set of item values and writes them to the server.
		/// </summary>
		private void WriteItems(TsCDaServer server)
		{
			new WriteItemsDlg().ShowDialog(server);	
		}

		/// <summary>
		/// Prompts the user to create a new subscription.
		/// </summary>
		private void CreateSubscription(TreeNode node, TsCDaServer server)
		{
			TsCDaSubscription subscription = new SubscriptionCreateDlg().ShowDialog(server);

			if (subscription == null)
			{
				return;
			}

			AddSubscription(node, subscription);
			node.Expand();

			if (SubscriptionModified != null)
			{
				SubscriptionModified(subscription, false);
			}
		}

		/// <summary>
		/// Deletes the specified subscription.
		/// </summary>
		private void DeleteSubscription(TreeNode node, TsCDaSubscription subscription)
		{
			if (SubscriptionModified != null)
			{
				SubscriptionModified(subscription, true);
			}

			try
			{
				TsCDaServer server = subscription.Server;
				server.CancelSubscription(subscription);
				subscription.Dispose();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			node.Remove();
		}		
		
		/// <summary>
		/// Edit the specified subscription.
		/// </summary>
		private void EditSubscription(TreeNode node, TsCDaSubscription subscription)
		{
			try
			{
				TsCDaSubscriptionState state = new SubscriptionListEditDlg().ShowDialog(subscription.Server, subscription.State);

				if (state == null)
				{
					return;
				}

				subscription.ModifyState((int)TsCDaStateMask.All, state);

				node.Text = subscription.Name;

				if (SubscriptionModified != null)
				{
					SubscriptionModified(subscription, !state.Active);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Toggles the active state of a subscription.
		/// </summary>
		private void SetActive(TsCDaSubscription subscription, bool active)
		{
			try
			{
				TsCDaSubscriptionState state = new TsCDaSubscriptionState();
				state.Active = active;
				subscription.ModifyState((int)TsCDaStateMask.Active, state);

				if (SubscriptionModified != null)
				{
					SubscriptionModified(subscription, !state.Active);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Toggles the enabled state of a subscription.
		/// </summary>
		private void SetEnabled(TsCDaSubscription subscription, bool enabled)
		{
			try
			{
				subscription.SetEnabled(enabled);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Prompts the user to select a set of items and reads them from the server.
		/// </summary>
		private void ReadItems(TsCDaSubscription subscription, bool synchronous)
		{
			new ReadItemsDlg().ShowDialog(subscription, synchronous);	
		}

		/// <summary>
		/// Prompts the user to specify a set of item values and writes them to the server.
		/// </summary>
		private void WriteItems(TsCDaSubscription subscription, bool synchronous)
		{
			new WriteItemsDlg().ShowDialog(subscription, synchronous);	
		}

		/// <summary>
		/// Refreshes the items of a subscription.
		/// </summary>
		private void Refresh(TsCDaSubscription subscription)
		{
			try
			{
				subscription.Refresh();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Adds items to the specified subscription.
		/// </summary>
		private void AddItems(TreeNode node, TsCDaSubscription subscription)
		{
			TsCDaItemResult[] items = new SubscriptionAddItemsDlg().ShowDialog(subscription);

			// update tree with new items.
			if (items != null)
			{
				foreach (TsCDaItemResult item in items) 
				{
					if (item.Result.Succeeded())
					{
						AddItem(node, item);
					}
				}

				node.Expand();
			}
		}

		/// <summary>
		/// Edits items in the specified subscription.
		/// </summary>
		private void EditItems(TreeNode node, TsCDaSubscription subscription)
		{
			try
			{
				// save item ids to detect item id changes.
				OpcItem[] itemIDs = new OpcItem[subscription.Items.Length];

				for (int ii = 0; ii < itemIDs.Length; ii++)
				{
					itemIDs[ii] = new OpcItem(subscription.Items[ii]);
				}

				// edit the items.
				TsCDaItem[] items = new ItemListEditDlg().ShowDialog(subscription.Items, false, false);

				if (items == null)
				{
					return;
				}

				// separate the items in lists depending on whether item id changed.
				ArrayList insertItems = new ArrayList();
				ArrayList updateItems = new ArrayList();
				ArrayList deleteItems = new ArrayList();

				for (int ii = 0; ii < itemIDs.Length; ii++)
				{
					if (items[ii].Key != itemIDs[ii].Key)
					{
						insertItems.Add(items[ii]);
						deleteItems.Add(itemIDs[ii]);
					}
					else
					{
						updateItems.Add(items[ii]);
					}
				}

				// update existing items.
				if (updateItems.Count > 0)
				{
					subscription.ModifyItems((int)TsCDaStateMask.All, (TsCDaItem[])updateItems.ToArray(typeof(TsCDaItem)));
				}

				// insert new items.
				if (insertItems.Count > 0)
				{
					subscription.AddItems((TsCDaItem[])insertItems.ToArray(typeof(TsCDaItem)));
				}

				// delete old items.
				if (deleteItems.Count > 0)
				{
					subscription.RemoveItems((OpcItem[])deleteItems.ToArray(typeof(OpcItem)));
				}

				// update tree.
				node.Nodes.Clear();
				
				foreach (TsCDaItem item in subscription.Items)
				{ 
					AddItem(node, item); 
				}
				
				node.Expand();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Edits items in the specified subscription.
		/// </summary>
		private void EditItem(TreeNode node, TsCDaSubscription subscription, TsCDaItem item)
		{
			try
			{
				// save existing item id.
				OpcItem itemId = new OpcItem(item);

				TsCDaItem[] items = new ItemListEditDlg().ShowDialog(new TsCDaItem[] { item }, false, false);

				if (items == null)
				{
					return;
				}

				// modify an existing item.
				if (itemId.Key == items[0].Key)
				{
					subscription.ModifyItems((int)TsCDaStateMask.All, items);
				}

				// add/remove item because the item id changed.
				else
				{
					items = subscription.AddItems(items);
					subscription.RemoveItems(new OpcItem[] {itemId});
				}

				node.Text = items[0].ItemName;
				node.Tag  = items[0];

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Remove an item in the specified subscription.
		/// </summary>
		private void RemoveItem(TreeNode node, TsCDaSubscription subscription, TsCDaItem item)
		{
			try
			{
				subscription.RemoveItems(new OpcItem[] { item });
				node.Remove();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
	
		/// <summary>
		/// Toggles the active state of a subscription.
		/// </summary>
		private void SetActive(TreeNode node, TsCDaSubscription subscription, TsCDaItem item, bool active)
		{
			try
			{			
				item.Active = active;
				item.ActiveSpecified = true;

				TsCDaItem[] items = subscription.ModifyItems((int)TsCDaStateMask.Active, new TsCDaItem[] { item });

				if (items != null)
				{
					node.Tag = items[0];
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Checks if the current node is a server node.
		/// </summary>
		private bool IsServerNode(TreeNode node)
		{
			if (node == null || node.Tag == null) return false;
		
			return typeof(TsCDaServer).IsInstanceOfType(node.Tag);
		}

		/// <summary>
		/// Checks if the current node is a subscription node.
		/// </summary>
		private bool IsSubscriptionNode(TreeNode node)
		{
			if (node == null || node.Tag == null) return false;
			return (node.Tag.GetType().GetInterface(typeof(ITsCDaSubscription).FullName) != null);
		}

		/// <summary>
		/// Checks if the current node is an item node.
		/// </summary>
		private bool IsItemNode(TreeNode node)
		{
			if (node == null || node.Tag == null) return false;
			return (node.Tag.GetType() == typeof(TsCDaItem) || node.Tag.GetType() == typeof(TsCDaItemResult));
		}

		/// <summary>
		/// Adds a subscription into the tree.
		/// </summary>
		private void AddSubscription(TreeNode parent, TsCDaSubscription subscription)
		{
			TreeNode child = new TreeNode(subscription.Name);
			child.ImageIndex = child.SelectedImageIndex = Resources.IMAGE_ENVELOPE;
			child.Tag = subscription;

			foreach (TsCDaItem item in subscription.Items)
			{
				AddItem(child, item);
			}

			if (parent != null)	
			{ 
				parent.Nodes.Add(child); 
			}
			else                
			{ 
				subscriptionTv_.Nodes.Add(child); 
				child.Expand(); 
			}
		}
		
		/// <summary>
		/// Adds an item into the tree.
		/// </summary>
		private void AddItem(TreeNode parent, TsCDaItem item)
		{
			TreeNode child = new TreeNode(item.ItemName);
			child.ImageIndex = child.SelectedImageIndex = Resources.IMAGE_YELLOW_SCROLL;
			child.Tag = item;

			parent.Nodes.Add(child);
		}
		
		/// <summary>
		/// Removes a subscription an releases all resources.
		/// </summary>
		private void RemoveSubscriptionMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				if (node.Parent != null)
				{
					try
					{
						TsCDaServer server = (TsCDaServer)node.Parent.Tag;
						server.CancelSubscription((TsCDaSubscription)node.Tag);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}

					node.Remove();
				}
			}
		}

		/// <summary>
		/// Updates the state of context menu. 
		/// </summary>
		private void SubscriptionTV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// selects the item that was right clicked on.
			TreeNode clickedNode = subscriptionTv_.GetNodeAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedNode == null) return;

			// force selection to clicked node.
			subscriptionTv_.SelectedNode = clickedNode;

			// disable everything.
			serverViewStatusMi_.Enabled      = false;
			serverBrowseItemsMi_.Enabled     = false;
			serverReadItemsMi_.Enabled       = false;
			serverWriteItemsMi_.Enabled      = false;
			serverDisconnectMi_.Enabled      = false;
			subscriptionCreateMi_.Enabled    = false;
			subscriptionDeleteMi_.Enabled    = false;
			subscriptionAddItemsMi_.Enabled  = false;
			subscriptionEditItemsMi_.Enabled = false;
			subscriptionEditMi_.Enabled      = false;
			subscriptionReadMi_.Enabled      = false;
			subscriptionWriteMi_.Enabled     = false;
			subscriptionRefreshMi_.Enabled   = false;
			subscriptionActiveMi_.Enabled    = false;
			subscriptionEnabledMi_.Enabled   = false;
			itemEditMi_.Enabled              = false;
			itemRemoveMi_.Enabled            = false;

			if (IsServerNode(clickedNode))
			{
				subscriptionTv_.ContextMenuStrip = serverPopupMenu_;

				serverViewStatusMi_.Enabled   = true;
				serverBrowseItemsMi_.Enabled  = true;
				serverReadItemsMi_.Enabled    = true;
				serverWriteItemsMi_.Enabled   = true;
				serverDisconnectMi_.Enabled   = true;
				subscriptionCreateMi_.Enabled = true;

				return;
			}

			if (IsSubscriptionNode(clickedNode))
			{
				subscriptionTv_.ContextMenuStrip = subscriptionPopupMenu_;

				subscriptionEditMi_.Enabled      = true;
				subscriptionDeleteMi_.Enabled    = clickedNode.Parent != null;
				subscriptionAddItemsMi_.Enabled  = true;
				subscriptionEditItemsMi_.Enabled = clickedNode.Parent != null;
				subscriptionReadMi_.Enabled      = clickedNode.Parent != null;
				subscriptionWriteMi_.Enabled     = clickedNode.Parent != null;
				subscriptionRefreshMi_.Enabled   = clickedNode.Parent != null;
				subscriptionActiveMi_.Enabled    = clickedNode.Parent != null;
				subscriptionEnabledMi_.Enabled   = clickedNode.Parent != null;

				subscriptionActiveMi_.Checked    = ((TsCDaSubscription)clickedNode.Tag).Active;
				subscriptionEnabledMi_.Checked   = ((TsCDaSubscription)clickedNode.Tag).Enabled;
				return;
			}

			if (IsItemNode(clickedNode))
			{
				subscriptionTv_.ContextMenuStrip = itemPopupMenu_;

				TsCDaItem item = (TsCDaItem)clickedNode.Tag;

				itemEditMi_.Enabled   = true;
				itemRemoveMi_.Enabled = true;
				itemActiveMi_.Checked = item.Active;
				return;
			}
		}

		/// <summary>
		/// Displays the server status in a modal dialog.
		/// </summary>
		private void ServerViewStatusMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsServerNode(node))
			{
				ViewStatus((TsCDaServer)node.Tag);
			}
		}

		/// <summary>
		/// Disconnects and removes a server from the control.
		/// </summary>
		private void ServerDisconnectMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsServerNode(node))
			{
				Disconnect(node, (TsCDaServer)node.Tag);
			}
		}

		/// <summary>
		/// Displays the address space of the server in a modal dialog.
		/// </summary>
		private void ServerBrowseItemsMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsServerNode(node))
			{
				BrowseItems((TsCDaServer)node.Tag);
			}
		}

		/// <summary>
		/// Creates a new subscription and adds it to the tree.
		/// </summary>
		private void CreateSubscriptionMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsServerNode(node))
			{
				CreateSubscription(node, (TsCDaServer)node.Tag);
			}
		}

		/// <summary>
		/// Reads a set of items for a server.
		/// </summary>
		private void ServerReadItemsMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsServerNode(node))
			{
				ReadItems((TsCDaServer)node.Tag);
			}
		}

		/// <summary>
		/// Writes a set of items to the server.
		/// </summary>
		private void ServerWriteItemsMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsServerNode(node))
			{
				WriteItems((TsCDaServer)node.Tag);
			}
		}

		/// <summary>
		/// Edits the state of a subscription.
		/// </summary>
		private void SubscriptionEditMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				EditSubscription(node, (TsCDaSubscription)node.Tag);
			}
		}

		/// <summary>
		/// Removes a subscription.
		/// </summary>
		private void SubscriptionDeleteMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				DeleteSubscription(node, (TsCDaSubscription)node.Tag);
			}
		}

		/// <summary>
		/// Adds items to a subscription.
		/// </summary>
		private void SubscriptionAddItemsMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				AddItems(node, (TsCDaSubscription)node.Tag);
			}
		}

		/// <summary>
		/// Edits items in a subscription.
		/// </summary>
		private void SubscriptionEditItemsMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				EditItems(node, (TsCDaSubscription)node.Tag);
			}
		}

		/// <summary>
		/// Toggles the active state of a subscription.
		/// </summary>
		private void SubscriptionActiveMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				subscriptionActiveMi_.Checked = !subscriptionActiveMi_.Checked;
				SetActive((TsCDaSubscription)node.Tag, subscriptionActiveMi_.Checked);
			}
		}

		/// <summary>
		/// Toggles the enabled state of a subscription.
		/// </summary>
		private void SubscriptionEnabledMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				subscriptionEnabledMi_.Checked = !subscriptionEnabledMi_.Checked;
				SetEnabled((TsCDaSubscription)node.Tag, subscriptionEnabledMi_.Checked);
			}
		}

		/// <summary>
		/// Reads a set of items belonging to a subscription.
		/// </summary>
		private void SubscriptionReadMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				ReadItems((TsCDaSubscription)node.Tag, true);
			}
		}

		/// <summary>
		/// Writes a set of items belonging to a subscription.
		/// </summary>
		private void SubscriptionWriteMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				WriteItems((TsCDaSubscription)node.Tag, true);
			}
		}

		/// <summary>
		/// Reads a set of items belonging to a subscription.
		/// </summary>
		private void SubscriptionAsyncReadMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				ReadItems((TsCDaSubscription)node.Tag, false);
			}
		}

		/// <summary>
		/// Writes a set of items belonging to a subscription.
		/// </summary>
		private void SubscriptionAsyncWriteMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				WriteItems((TsCDaSubscription)node.Tag, false);
			}
		}

		/// <summary>
		/// Refreshes the items of a subscription.
		/// </summary>
		private void SubscriptionRefreshMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				Refresh((TsCDaSubscription)node.Tag);
			}
		}

		/// <summary>
		/// Edits a single item.
		/// </summary>
		private void ItemEditMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsItemNode(node))
			{
				EditItem(node, (TsCDaSubscription)node.Parent.Tag, (TsCDaItem)node.Tag);
			}
		}

		/// <summary>
		/// Removes a single item.
		/// </summary>
		private void ItemRemoveMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsItemNode(node))
			{
				RemoveItem(node, (TsCDaSubscription)node.Parent.Tag, (TsCDaItem)node.Tag);
			}
		}

		/// <summary>
		/// Toggles the active state of a single item.
		/// </summary>
		private void ItemActiveMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsItemNode(node))
			{
				itemActiveMi_.Checked = !itemActiveMi_.Checked;
				SetActive(node, (TsCDaSubscription)node.Parent.Tag, (TsCDaItem)node.Tag, itemActiveMi_.Checked);
			}
		}

		/// <summary>
		/// Called when the Server | Edit Options menu item is clicked.
		/// </summary>
		private void EditOptionsMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsServerNode(node))
			{
				new OptionsEditDlg().ShowDialog((TsCDaServer)node.Tag);
			}
		}

		/// <summary>
		/// Called when the Subscription | Edit Options menu item is clicked.
		/// </summary>
		private void SubscriptionEditOptionsMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = subscriptionTv_.SelectedNode;

			if (IsSubscriptionNode(node))
			{
				new OptionsEditDlg().ShowDialog((TsCDaSubscription)node.Tag);
			}
		} 
	}
}

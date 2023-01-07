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
			subscriptionTv_ = new System.Windows.Forms.TreeView();
			serverPopupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			serverViewStatusMi_ = new System.Windows.Forms.ToolStripMenuItem();
			editOptionsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			serverDisconnectMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			serverBrowseItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionCreateMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator02_ = new System.Windows.Forms.ToolStripMenuItem();
			serverReadItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			serverWriteItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionPopupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			subscriptionEditMi_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionDeleteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionAddItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionEditItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separatorS1_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionActiveMi_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionEnabledMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separatorS2_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionReadMi_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionWriteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separatorS3_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionAsyncReadMi_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionAsyncWriteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionRefreshMi_ = new System.Windows.Forms.ToolStripMenuItem();
			itemPopupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			itemEditMi_ = new System.Windows.Forms.ToolStripMenuItem();
			itemRemoveMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separatorI1_ = new System.Windows.Forms.ToolStripMenuItem();
			itemActiveMi_ = new System.Windows.Forms.ToolStripMenuItem();
			subscriptionEditOptionsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			SuspendLayout();
			// 
			// SubscriptionTV
			// 
			subscriptionTv_.ContextMenuStrip = serverPopupMenu_;
			subscriptionTv_.Dock = System.Windows.Forms.DockStyle.Fill;
			subscriptionTv_.ImageIndex = -1;
			subscriptionTv_.Location = new System.Drawing.Point(0, 0);
			subscriptionTv_.Name = "subscriptionTv_";
			subscriptionTv_.SelectedImageIndex = -1;
			subscriptionTv_.Size = new System.Drawing.Size(360, 400);
			subscriptionTv_.TabIndex = 0;
			subscriptionTv_.MouseDown += new System.Windows.Forms.MouseEventHandler(SubscriptionTV_MouseDown);
			// 
			// Server_PopupMenu
			// 
			serverPopupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																							 serverViewStatusMi_,
																							 editOptionsMi_,
																							 serverDisconnectMi_,
																							 separator01_,
																							 serverBrowseItemsMi_,
																							 subscriptionCreateMi_,
																							 separator02_,
																							 serverReadItemsMi_,
																							 serverWriteItemsMi_});
			// 
			// ServerViewStatusMI
			// 
			serverViewStatusMi_.ImageIndex = 0;
			serverViewStatusMi_.Text = "&View Status...";
			serverViewStatusMi_.Click += new System.EventHandler(ServerViewStatusMI_Click);
			// 
			// EditOptionsMI
			// 
			editOptionsMi_.ImageIndex = 1;
			editOptionsMi_.Text = "Edit &Options...";
			editOptionsMi_.Click += new System.EventHandler(EditOptionsMI_Click);
			// 
			// ServerDisconnectMI
			// 
			serverDisconnectMi_.ImageIndex = 2;
			serverDisconnectMi_.Text = "&Disconnect";
			serverDisconnectMi_.Click += new System.EventHandler(ServerDisconnectMI_Click);
			// 
			// Separator01
			// 
			separator01_.ImageIndex = 3;
			separator01_.Text = "-";
			// 
			// ServerBrowseItemsMI
			// 
			serverBrowseItemsMi_.ImageIndex = 4;
			serverBrowseItemsMi_.Text = "&Browse Items...";
			serverBrowseItemsMi_.Click += new System.EventHandler(ServerBrowseItemsMI_Click);
			// 
			// SubscriptionCreateMI
			// 
			subscriptionCreateMi_.ImageIndex = 5;
			subscriptionCreateMi_.Text = "&Create Subscription...";
			subscriptionCreateMi_.Click += new System.EventHandler(CreateSubscriptionMI_Click);
			// 
			// Separator02
			// 
			separator02_.ImageIndex = 6;
			separator02_.Text = "-";
			// 
			// ServerReadItemsMI
			// 
			serverReadItemsMi_.ImageIndex = 7;
			serverReadItemsMi_.Text = "&Read...";
			serverReadItemsMi_.Click += new System.EventHandler(ServerReadItemsMI_Click);
			// 
			// ServerWriteItemsMI
			// 
			serverWriteItemsMi_.ImageIndex = 8;
			serverWriteItemsMi_.Text = "&Write...";
			serverWriteItemsMi_.Click += new System.EventHandler(ServerWriteItemsMI_Click);
			// 
			// Subscription_PopupMenu
			// 
			subscriptionPopupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																								   subscriptionEditMi_,
																								   subscriptionEditOptionsMi_,
																								   subscriptionDeleteMi_,
																								   subscriptionAddItemsMi_,
																								   subscriptionEditItemsMi_,
																								   separatorS1_,
																								   subscriptionActiveMi_,
																								   subscriptionEnabledMi_,
																								   separatorS2_,
																								   subscriptionReadMi_,
																								   subscriptionWriteMi_,
																								   separatorS3_,
																								   subscriptionAsyncReadMi_,
																								   subscriptionAsyncWriteMi_,
																								   subscriptionRefreshMi_});
			// 
			// SubscriptionEditMI
			// 
			subscriptionEditMi_.ImageIndex = 0;
			subscriptionEditMi_.Text = "&Edit State...";
			subscriptionEditMi_.Click += new System.EventHandler(SubscriptionEditMI_Click);
			// 
			// SubscriptionDeleteMI
			// 
			subscriptionDeleteMi_.ImageIndex = 2;
			subscriptionDeleteMi_.Text = "&Delete";
			subscriptionDeleteMi_.Click += new System.EventHandler(SubscriptionDeleteMI_Click);
			// 
			// SubscriptionAddItemsMI
			// 
			subscriptionAddItemsMi_.ImageIndex = 3;
			subscriptionAddItemsMi_.Text = "&Add Items..";
			subscriptionAddItemsMi_.Click += new System.EventHandler(SubscriptionAddItemsMI_Click);
			// 
			// SubscriptionEditItemsMI
			// 
			subscriptionEditItemsMi_.ImageIndex = 4;
			subscriptionEditItemsMi_.Text = "E&dit Items...";
			subscriptionEditItemsMi_.Click += new System.EventHandler(SubscriptionEditItemsMI_Click);
			// 
			// SeparatorS1
			// 
			separatorS1_.ImageIndex = 5;
			separatorS1_.Text = "-";
			// 
			// SubscriptionActiveMI
			// 
			subscriptionActiveMi_.ImageIndex = 6;
			subscriptionActiveMi_.Text = "Acti&ve";
			subscriptionActiveMi_.Click += new System.EventHandler(SubscriptionActiveMI_Click);
			// 
			// SubscriptionEnabledMI
			// 
			subscriptionEnabledMi_.ImageIndex = 7;
			subscriptionEnabledMi_.Text = "E&nabled";
			subscriptionEnabledMi_.Click += new System.EventHandler(SubscriptionEnabledMI_Click);
			// 
			// SeparatorS2
			// 
			separatorS2_.ImageIndex = 8;
			separatorS2_.Text = "-";
			// 
			// SubscriptionReadMI
			// 
			subscriptionReadMi_.ImageIndex = 9;
			subscriptionReadMi_.Text = "&Read...";
			subscriptionReadMi_.Click += new System.EventHandler(SubscriptionReadMI_Click);
			// 
			// SubscriptionWriteMI
			// 
			subscriptionWriteMi_.ImageIndex = 10;
			subscriptionWriteMi_.Text = "&Write...";
			subscriptionWriteMi_.Click += new System.EventHandler(SubscriptionWriteMI_Click);
			// 
			// SeparatorS3
			// 
			separatorS3_.ImageIndex = 11;
			separatorS3_.Text = "-";
			// 
			// SubscriptionAsyncReadMI
			// 
			subscriptionAsyncReadMi_.ImageIndex = 12;
			subscriptionAsyncReadMi_.Text = "Async Read...";
			subscriptionAsyncReadMi_.Click += new System.EventHandler(SubscriptionAsyncReadMI_Click);
			// 
			// SubscriptionAsyncWriteMI
			// 
			subscriptionAsyncWriteMi_.ImageIndex = 13;
			subscriptionAsyncWriteMi_.Text = "Async Write...";
			subscriptionAsyncWriteMi_.Click += new System.EventHandler(SubscriptionAsyncWriteMI_Click);
			// 
			// SubscriptionRefreshMI
			// 
			subscriptionRefreshMi_.ImageIndex = 14;
			subscriptionRefreshMi_.Text = "Refre&sh";
			subscriptionRefreshMi_.Click += new System.EventHandler(SubscriptionRefreshMI_Click);
			// 
			// Item_PopupMenu
			// 
			itemPopupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																						   itemEditMi_,
																						   itemRemoveMi_,
																						   separatorI1_,
																						   itemActiveMi_});
			// 
			// ItemEditMI
			// 
			itemEditMi_.ImageIndex = 0;
			itemEditMi_.Text = "&Edit...";
			itemEditMi_.Click += new System.EventHandler(ItemEditMI_Click);
			// 
			// ItemRemoveMI
			// 
			itemRemoveMi_.ImageIndex = 1;
			itemRemoveMi_.Text = "&Delete";
			itemRemoveMi_.Click += new System.EventHandler(ItemRemoveMI_Click);
			// 
			// SeparatorI1
			// 
			separatorI1_.ImageIndex = 2;
			separatorI1_.Text = "-";
			// 
			// ItemActiveMI
			// 
			itemActiveMi_.ImageIndex = 3;
			itemActiveMi_.Text = "&Active";
			itemActiveMi_.Click += new System.EventHandler(ItemActiveMI_Click);
			// 
			// SubscriptionEditOptionsMI
			// 
			subscriptionEditOptionsMi_.ImageIndex = 1;
			subscriptionEditOptionsMi_.Text = "Edit &Options...";
			subscriptionEditOptionsMi_.Click += new System.EventHandler(SubscriptionEditOptionsMI_Click);
			// 
			// SubscriptionsTreeCtrl
			// 
			Controls.Add(subscriptionTv_);
			Name = "SubscriptionsTreeCtrl";
			Size = new System.Drawing.Size(360, 400);
			ResumeLayout(false);

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

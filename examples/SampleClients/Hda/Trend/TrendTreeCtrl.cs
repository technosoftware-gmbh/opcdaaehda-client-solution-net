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
using System.Windows.Forms;

using SampleClients.Common;
using SampleClients.Hda.Edit;
using SampleClients.Hda.Item;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Trend
{
	/// <summary>
	/// A tree control used to manager a set of trends acquired from an HDA server.
	/// </summary>
	public class TrendTreeCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView trendTv_;
		private System.Windows.Forms.ToolStripMenuItem addTrendMi_;
		private System.Windows.Forms.ToolStripMenuItem removeTrendMi_;
		private System.Windows.Forms.ToolStripMenuItem editTrendMi_;
		private System.Windows.Forms.ToolStripMenuItem editItemMi_;
		private System.Windows.Forms.ToolStripMenuItem removeItemMi_;
		private System.Windows.Forms.ToolStripMenuItem readAtTimeMi_;
		private System.Windows.Forms.ToolStripMenuItem readModifiedMi_;
		private System.Windows.Forms.ToolStripMenuItem readAttributesMi_;
		private System.Windows.Forms.ToolStripMenuItem readAnnotationsMi_;
		private System.Windows.Forms.ToolStripMenuItem addItemsMi_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		private System.Windows.Forms.ToolStripMenuItem insertMi_;
		private System.Windows.Forms.ToolStripMenuItem insertReplaceMi_;
		private System.Windows.Forms.ToolStripMenuItem replaceMi_;
		private System.Windows.Forms.ToolStripMenuItem deleteAtTimeMi_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem deleteRawMi_;
		private System.Windows.Forms.ToolStripMenuItem readRawMi_;
		private System.Windows.Forms.ToolStripMenuItem readProcessedMi_;
		private System.Windows.Forms.ToolStripMenuItem playbackRawMi_;
		private System.Windows.Forms.ToolStripMenuItem subscribeProcessedMi_;
		private System.Windows.Forms.ToolStripMenuItem playbackProcessedMi_;
		private System.Windows.Forms.ToolStripMenuItem separator02_;
		private System.Windows.Forms.ToolStripMenuItem separator03_;
		private System.Windows.Forms.ToolStripMenuItem separator04_;
		private System.Windows.Forms.ToolStripMenuItem subscribeRawMi_;
		private System.Windows.Forms.ToolStripMenuItem separator05_;
		private System.Windows.Forms.ToolStripMenuItem subscribeCancelMi_;
		private System.Windows.Forms.ToolStripMenuItem playbackCancelMi_;
		private System.Windows.Forms.ToolStripMenuItem useAsyncMi_;
		private System.Windows.Forms.ToolStripMenuItem separator06_;
		private System.Windows.Forms.ToolStripMenuItem insertAnnotationsMi_;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public TrendTreeCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			trendTv_.ImageList = Resources.Instance.ImageList;
			Clear();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				// release all server objects.
				Clear();

				if (components_ != null)
				{
					components_.Dispose();
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
			trendTv_ = new System.Windows.Forms.TreeView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			addTrendMi_ = new System.Windows.Forms.ToolStripMenuItem();
			editTrendMi_ = new System.Windows.Forms.ToolStripMenuItem();
			removeTrendMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			addItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			editItemMi_ = new System.Windows.Forms.ToolStripMenuItem();
			removeItemMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator02_ = new System.Windows.Forms.ToolStripMenuItem();
			useAsyncMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator03_ = new System.Windows.Forms.ToolStripMenuItem();
			readRawMi_ = new System.Windows.Forms.ToolStripMenuItem();
			readProcessedMi_ = new System.Windows.Forms.ToolStripMenuItem();
			readModifiedMi_ = new System.Windows.Forms.ToolStripMenuItem();
			readAtTimeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			readAttributesMi_ = new System.Windows.Forms.ToolStripMenuItem();
			readAnnotationsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator04_ = new System.Windows.Forms.ToolStripMenuItem();
			insertMi_ = new System.Windows.Forms.ToolStripMenuItem();
			insertReplaceMi_ = new System.Windows.Forms.ToolStripMenuItem();
			replaceMi_ = new System.Windows.Forms.ToolStripMenuItem();
			deleteRawMi_ = new System.Windows.Forms.ToolStripMenuItem();
			deleteAtTimeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			insertAnnotationsMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator05_ = new System.Windows.Forms.ToolStripMenuItem();
			subscribeRawMi_ = new System.Windows.Forms.ToolStripMenuItem();
			subscribeProcessedMi_ = new System.Windows.Forms.ToolStripMenuItem();
			subscribeCancelMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator06_ = new System.Windows.Forms.ToolStripMenuItem();
			playbackRawMi_ = new System.Windows.Forms.ToolStripMenuItem();
			playbackProcessedMi_ = new System.Windows.Forms.ToolStripMenuItem();
			playbackCancelMi_ = new System.Windows.Forms.ToolStripMenuItem();
			SuspendLayout();
			// 
			// TrendTV
			// 
			trendTv_.ContextMenuStrip = popupMenu_;
			trendTv_.Dock = System.Windows.Forms.DockStyle.Fill;
			trendTv_.ImageIndex = -1;
			trendTv_.Location = new System.Drawing.Point(0, 0);
			trendTv_.Name = "trendTv_";
			trendTv_.SelectedImageIndex = -1;
			trendTv_.Size = new System.Drawing.Size(400, 400);
			trendTv_.TabIndex = 0;
			trendTv_.MouseDown += new System.Windows.Forms.MouseEventHandler(TrendTV_MouseDown);
			trendTv_.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(TrendTV_AfterSelect);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  addTrendMi_,
																					  editTrendMi_,
																					  removeTrendMi_,
																					  separator01_,
																					  addItemsMi_,
																					  editItemMi_,
																					  removeItemMi_,
																					  separator02_,
																					  useAsyncMi_,
																					  separator03_,
																					  readRawMi_,
																					  readProcessedMi_,
																					  readModifiedMi_,
																					  readAtTimeMi_,
																					  readAttributesMi_,
																					  readAnnotationsMi_,
																					  separator04_,
																					  insertMi_,
																					  insertReplaceMi_,
																					  replaceMi_,
																					  deleteRawMi_,
																					  deleteAtTimeMi_,
																					  insertAnnotationsMi_,
																					  separator05_,
																					  subscribeRawMi_,
																					  subscribeProcessedMi_,
																					  subscribeCancelMi_,
																					  separator06_,
																					  playbackRawMi_,
																					  playbackProcessedMi_,
																					  playbackCancelMi_});
			// 
			// AddTrendMI
			// 
			addTrendMi_.ImageIndex = 0;
			addTrendMi_.Text = "&Add Trend...";
			addTrendMi_.Click += new System.EventHandler(AddTrendMI_Click);
			// 
			// EditTrendMI
			// 
			editTrendMi_.ImageIndex = 1;
			editTrendMi_.Text = "&Edit Trend...";
			editTrendMi_.Click += new System.EventHandler(EditTrendMI_Click);
			// 
			// RemoveTrendMI
			// 
			removeTrendMi_.ImageIndex = 2;
			removeTrendMi_.Text = "&Remove Trend";
			removeTrendMi_.Click += new System.EventHandler(RemoveTrendMI_Click);
			// 
			// Separator01
			// 
			separator01_.ImageIndex = 3;
			separator01_.Text = "-";
			// 
			// AddItemsMI
			// 
			addItemsMi_.ImageIndex = 4;
			addItemsMi_.Text = "&Add Items...";
			addItemsMi_.Click += new System.EventHandler(AddItemsMI_Click);
			// 
			// EditItemMI
			// 
			editItemMi_.ImageIndex = 5;
			editItemMi_.Text = "&Edit Item...";
			editItemMi_.Click += new System.EventHandler(EditItemMI_Click);
			// 
			// RemoveItemMI
			// 
			removeItemMi_.ImageIndex = 6;
			removeItemMi_.Text = "&Remove Item";
			removeItemMi_.Click += new System.EventHandler(RemoveItemMI_Click);
			// 
			// Separator02
			// 
			separator02_.ImageIndex = 7;
			separator02_.Text = "-";
			// 
			// UseAsyncMI
			// 
			useAsyncMi_.ImageIndex = 8;
			useAsyncMi_.Text = "Asynchronous";
			useAsyncMi_.Click += new System.EventHandler(UseAsyncMI_Click);
			// 
			// Separator03
			// 
			separator03_.ImageIndex = 9;
			separator03_.Text = "-";
			// 
			// ReadRawMI
			// 
			readRawMi_.ImageIndex = 10;
			readRawMi_.Text = "&Read Raw...";
			readRawMi_.Click += new System.EventHandler(ReadRawMI_Click);
			// 
			// ReadProcessedMI
			// 
			readProcessedMi_.ImageIndex = 11;
			readProcessedMi_.Text = "Read Processed...";
			readProcessedMi_.Click += new System.EventHandler(ReadProcessedMI_Click);
			// 
			// ReadModifiedMI
			// 
			readModifiedMi_.ImageIndex = 12;
			readModifiedMi_.Text = "Read &Modified...";
			readModifiedMi_.Click += new System.EventHandler(ReadModifiedMI_Click);
			// 
			// ReadAtTimeMI
			// 
			readAtTimeMi_.ImageIndex = 13;
			readAtTimeMi_.Text = "Read At &Time...";
			readAtTimeMi_.Click += new System.EventHandler(ReadAtTimeMI_Click);
			// 
			// ReadAttributesMI
			// 
			readAttributesMi_.ImageIndex = 14;
			readAttributesMi_.Text = "Read &Attributes...";
			readAttributesMi_.Click += new System.EventHandler(ReadAttributesMI_Click);
			// 
			// ReadAnnotationsMI
			// 
			readAnnotationsMi_.ImageIndex = 15;
			readAnnotationsMi_.Text = "Read A&nnotations...";
			readAnnotationsMi_.Click += new System.EventHandler(ReadAnnotationsMI_Click);
			// 
			// Separator04
			// 
			separator04_.ImageIndex = 16;
			separator04_.Text = "-";
			// 
			// InsertMI
			// 
			insertMi_.ImageIndex = 17;
			insertMi_.Text = "&Insert...";
			insertMi_.Click += new System.EventHandler(InsertMI_Click);
			// 
			// InsertReplaceMI
			// 
			insertReplaceMi_.ImageIndex = 18;
			insertReplaceMi_.Text = "I&nsert/Replace...";
			insertReplaceMi_.Click += new System.EventHandler(InsertReplaceMI_Click);
			// 
			// ReplaceMI
			// 
			replaceMi_.ImageIndex = 19;
			replaceMi_.Text = "&Replace...";
			replaceMi_.Click += new System.EventHandler(ReplaceMI_Click);
			// 
			// DeleteRawMI
			// 
			deleteRawMi_.ImageIndex = 20;
			deleteRawMi_.Text = "&Delete...";
			deleteRawMi_.Click += new System.EventHandler(DeleteRawMI_Click);
			// 
			// DeleteAtTimeMI
			// 
			deleteAtTimeMi_.ImageIndex = 21;
			deleteAtTimeMi_.Text = "Delete At &Time...";
			deleteAtTimeMi_.Click += new System.EventHandler(DeleteAtTimeMI_Click);
			// 
			// InsertAnnotationsMI
			// 
			insertAnnotationsMi_.ImageIndex = 22;
			insertAnnotationsMi_.Text = "Insert Annotations...";
			insertAnnotationsMi_.Click += new System.EventHandler(InsertAnnotationsMI_Click);
			// 
			// Separator05
			// 
			separator05_.ImageIndex = 23;
			separator05_.Text = "-";
			// 
			// SubscribeRawMI
			// 
			subscribeRawMi_.ImageIndex = 24;
			subscribeRawMi_.Text = "Subscribe Raw...";
			subscribeRawMi_.Click += new System.EventHandler(SubscribeRawMI_Click);
			// 
			// SubscribeProcessedMI
			// 
			subscribeProcessedMi_.ImageIndex = 25;
			subscribeProcessedMi_.Text = "Subscribe Processed...";
			subscribeProcessedMi_.Click += new System.EventHandler(SubscribeProcessedMI_Click);
			// 
			// SubscribeCancelMI
			// 
			subscribeCancelMi_.ImageIndex = 26;
			subscribeCancelMi_.Text = "Cancel Subscription";
			subscribeCancelMi_.Click += new System.EventHandler(SubscribeCancelMI_Click);
			// 
			// Separator06
			// 
			separator06_.ImageIndex = 27;
			separator06_.Text = "-";
			// 
			// PlaybackRawMI
			// 
			playbackRawMi_.ImageIndex = 28;
			playbackRawMi_.Text = "Playback Raw...";
			playbackRawMi_.Click += new System.EventHandler(PlaybackRawMI_Click);
			// 
			// PlaybackProcessedMI
			// 
			playbackProcessedMi_.ImageIndex = 29;
			playbackProcessedMi_.Text = "Playback Processed...";
			playbackProcessedMi_.Click += new System.EventHandler(PlaybackProcessedMI_Click);
			// 
			// PlaybackCancelMI
			// 
			playbackCancelMi_.ImageIndex = 30;
			playbackCancelMi_.Text = "Cancel Playback";
			playbackCancelMi_.Click += new System.EventHandler(PlaybackCancelMI_Click);
			// 
			// TrendTreeCtrl
			// 
			Controls.Add(trendTv_);
			Name = "TrendTreeCtrl";
			Size = new System.Drawing.Size(400, 400);
			ResumeLayout(false);

		}
		#endregion
				
		#region Public Interface
		/// <summary>
		/// Called when new data is read for a trend.
		/// </summary>
		public delegate void TrendChangedEventHandler(TsCHdaTrend trend, TsCHdaItemValueCollection[] values, bool replace);

		/// <summary>
		/// Fired when new data is read for a trend.
		/// </summary>
		public event TrendChangedEventHandler TrendChanged;

		/// <summary>
		/// Called when a trend or item is selected in the tree.
		/// </summary>
		public delegate void TrendSelectedEventHandler(TsCHdaTrend trend, TsCHdaItem item);

		/// <summary>
		/// Fired when a trend or item is selected in the tree.
		/// </summary>
		public event TrendSelectedEventHandler TrendSelected;

		/// <summary>
		/// Initializes the control with the specified HDA server.
		/// </summary>
		public void Initialize(TsCHdaServer server)
		{
			mServer_ = server;

			Clear();

			// nothing more to do server is null.
			if (server == null)
			{
				return;
			}
						
			// create the root node.
            TreeNode root = new TreeNode(server.ServerName);
			root.ImageIndex         = Resources.IMAGE_LOCAL_SERVER;
			root.SelectedImageIndex = Resources.IMAGE_LOCAL_SERVER;
			root.Tag                = server;

			// add the current set of items.
			foreach (TsCHdaTrend trend in server.Trends)
			{
				AddTrend(root, trend, false);
			}

			// add new node to tree view.
			trendTv_.Nodes.Add(root);	
			root.Expand();
		}

		/// <summary>
		/// Removes all nodes and releases all resources.
		/// </summary>
		public void Clear()
		{		
			// recursively searches the tree and free objects.
			foreach (TreeNode child in trendTv_.Nodes)
			{
				Clear(child);
			}

			// clear the tree.
			trendTv_.Nodes.Clear();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// The server which is the source for the trend data.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// Adds a trend to the tree view.
		/// </summary>
		private void AddTrend(TreeNode parent, TsCHdaTrend trend, bool expand)
		{
			TreeNode node = new TreeNode(trend.Name);

			node.ImageIndex         = Resources.IMAGE_LIST_BOX;
			node.SelectedImageIndex = Resources.IMAGE_LIST_BOX;
			node.Tag                = trend;

			foreach (TsCHdaItem item in trend.Items)
			{
				AddItem(node, item);
			}

			parent.Nodes.Add(node);

			// ensure items are visible.
			if (expand)
			{
				node.Expand();
			}
		}

		/// <summary>
		/// Adds an item to the tree view.
		/// </summary>
		private void AddItem(TreeNode parent, TsCHdaItem item)
		{
			TreeNode node = new TreeNode();

			node.ImageIndex         = Resources.IMAGE_YELLOW_SCROLL;
			node.SelectedImageIndex = Resources.IMAGE_YELLOW_SCROLL;

			UpdateItem(node, item);

			parent.Nodes.Add(node);
		}

		/// <summary>
		/// Sets the text of the trend node.
		/// </summary>
		private void UpdateTrend(TreeNode node, TsCHdaTrend trend, TsCHdaItemValueCollection[] values)
		{
			node.Text = trend.Name;
			node.Tag  = trend;

			// update cache entries for all trend items.
			if (TrendChanged != null)
			{
				TrendChanged(trend, values, true);
			}
		}

		/// <summary>
		/// Sets the text of the item node.
		/// </summary>
		private void UpdateItem(TreeNode node, TsCHdaItem item)
		{
			TsCHdaAggregate aggregate = mServer_.Aggregates.Find(item.Aggregate);

			if (aggregate != null)
			{
				node.Text = String.Format("{0} ({1})", item.ItemName, aggregate.Name);
			}
			else
			{
				node.Text = item.ItemName;
			}

			node.Tag = item;
		}

		/// <summary>
		/// Recursively searches the tree and free objects.
		/// </summary>
		private void Clear(TreeNode parent)
		{		
			// search children.
			foreach (TreeNode child in parent.Nodes)
			{
				Clear(child);
			}
		}

		/// <summary>
		/// Checks is the node is a server node.
		/// </summary>
		private bool IsServerNode(TreeNode node)
		{
			if (node != null)
			{
				if (typeof(TsCHdaServer).IsInstanceOfType(node.Tag))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Checks is the node is a trend node.
		/// </summary>
		private bool IsTrendNode(TreeNode node)
		{
			if (node != null)
			{
				if (typeof(TsCHdaTrend).IsInstanceOfType(node.Tag))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Checks is the node is an item node.
		/// </summary>
		private bool IsItemNode(TreeNode node)
		{
			if (node != null)
			{
				if (typeof(TsCHdaItem).IsInstanceOfType(node.Tag))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Handles an operation on a server node.
		/// </summary>
		private void HandleRequest(TsCHdaServer server, RequestType type)
		{
			switch (type)
			{
				case RequestType.ReadRaw:
				case RequestType.ReadProcessed:
				case RequestType.ReadModified:
				case RequestType.ReadAtTime:
				{
					new ReadValuesDlg().ShowDialog(server, type, !useAsyncMi_.Checked);
					break;
				}

				case RequestType.ReadAttributes:
				{
					new ReadAttributesDlg().ShowDialog(mServer_, !useAsyncMi_.Checked);
					break;
				}

				case RequestType.ReadAnnotations:
				{
					new ReadAnnotationsDlg().ShowDialog(mServer_, !useAsyncMi_.Checked);
					break;
				}

				case RequestType.InsertAnnotations:
				{
					new InsertAnnotationsDlg().ShowDialog(mServer_, !useAsyncMi_.Checked);
					break;
				}

				case RequestType.Insert:
				{
					new InsertValuesDlg().ShowDialog(mServer_, false, !useAsyncMi_.Checked);
					break;
				}

				case RequestType.InsertReplace:
				{
					new InsertValuesDlg().ShowDialog(mServer_, true, !useAsyncMi_.Checked);
					break;
				}

				case RequestType.Replace:
				{
					new ReplaceValuesDlg().ShowDialog(mServer_, !useAsyncMi_.Checked);
					break;
				}

				case RequestType.DeleteRaw:
				case RequestType.DeleteAtTime:
				{
					new DeleteValuesDlg().ShowDialog(mServer_, type, !useAsyncMi_.Checked);
					break;
				}
			}
		}

		/// <summary>
		/// Handles an operation on n trend node.
		/// </summary>
		private void HandleRequest(TsCHdaTrend trend, RequestType type)
		{
			// used only if the request reads a new data set from the server.
			TsCHdaItemValueCollection[] results = null;
			
			// dispatch request.
			switch (type)
			{
				case RequestType.ReadRaw:
				case RequestType.ReadProcessed:
				case RequestType.ReadModified:
				case RequestType.ReadAtTime:
				{
					results = new ReadValuesDlg().ShowDialog(trend, type, !useAsyncMi_.Checked);
					break;
				}

				case RequestType.AdviseRaw:
				case RequestType.AdviseProcessed:
				{
					// prompt user to specified subscription parameters.
					if (!new SubscriptionEditDlg().ShowDialog(trend, type))
					{
						return;
					}

					// create a subscription.
					trend.Subscribe(trend, new TsCHdaDataUpdateEventHandler(OnDataChanged));

					// clear cached results.
					if (TrendChanged != null)
					{
						TrendChanged(trend, null, true);
					}
                    
					// all done.
					break;
				}

				case RequestType.PlaybackRaw:
				case RequestType.PlaybackProcessed:
				{
					// prompt user to specified subscription parameters.
					if (!new SubscriptionEditDlg().ShowDialog(trend, type))
					{
						return;
					}

					// create a subscription.
					trend.Playback(trend, new TsCHdaDataUpdateEventHandler(OnDataChanged));

					// clear cached results.
					if (TrendChanged != null)
					{
						TrendChanged(trend, null, true);
					}
                    
					// all done.
					break;
				}

				case RequestType.ReadAnnotations:
				{
					new ReadAnnotationsDlg().ShowDialog(trend, !useAsyncMi_.Checked);
					break;
				}

				case RequestType.DeleteRaw:
				case RequestType.DeleteAtTime:
				{
					if (new DeleteValuesDlg().ShowDialog(trend, type, !useAsyncMi_.Checked) != null)
					{
						results = trend.ReadRaw();
					}

					break;
				}
			}

			// send notification that the trend data set changed.
			if (results != null)
			{
				if (TrendChanged != null)
				{
					TrendChanged(trend, results, true);
				}
			}
		}

		/// <summary>
		/// Handles an operation on an item node.
		/// </summary>
		private void HandleRequest(TsCHdaTrend trend, TsCHdaItem item, RequestType type)
		{
			// used only if the request reads a new data set from the server.
			TsCHdaItemValueCollection[] results = null;
			
			// dispatch request.
			switch (type)
			{
				case RequestType.ReadRaw:
				{
					results = trend.ReadRaw(new TsCHdaItem[] { item });
					break;
				}

				case RequestType.ReadProcessed:
				{
					results = trend.ReadProcessed(new TsCHdaItem[] { item });
					break;
				}

				case RequestType.ReadModified:
				{
					results = trend.ReadModified(new TsCHdaItem[] { item });
					break;
				}

				case RequestType.ReadAtTime:
				{
					results = trend.ReadAtTime(new TsCHdaItem[] { item });
					break;
				}

				case RequestType.ReadAttributes:
				{
					new ReadAttributesDlg().ShowDialog(
						mServer_,
						item,
						trend.StartTime,
						trend.EndTime,
						!useAsyncMi_.Checked);

					break;
				}

				case RequestType.ReadAnnotations:
				{
					trend.ReadAnnotations(new TsCHdaItem[] { item });
					break;
				}

				case RequestType.InsertAnnotations:
				{
					new InsertAnnotationsDlg().ShowDialog(mServer_, item, !useAsyncMi_.Checked);
					break;
				}

				case RequestType.Insert:
				{
					new InsertValuesDlg().ShowDialog(mServer_, item, false, !useAsyncMi_.Checked);
					break;
				}

				case RequestType.InsertReplace:
				{
					new InsertValuesDlg().ShowDialog(mServer_, item, true, !useAsyncMi_.Checked);
					break;
				}

				case RequestType.Replace:
				{
					new ReplaceValuesDlg().ShowDialog(mServer_, item, !useAsyncMi_.Checked);
					break;
				}
			}

			// send notification that the trend data set changed.
			if (results != null)
			{
				if (TrendChanged != null)
				{
					TrendChanged(trend, results, true);
				}
			}
		}

		/// <summary>
		/// Called when new data arrives from the server.
		/// </summary>
		public void OnDataChanged(IOpcRequest request, TsCHdaItemValueCollection[] results)
		{	
			// check if control has closed.
			if (IsDisposed)
			{
				return;
			}
			
			// check if invoke is required.
			if (InvokeRequired)
			{
				BeginInvoke(new TsCHdaDataUpdateEventHandler(OnDataChanged), new object[] { request, results });
				return;
			}
			
			try
			{
				// send notification that the trend data set changed.
				if (results != null)
				{
					// check if a playback request has completed.
					TsCHdaTrend trend = (TsCHdaTrend)request.Handle;

					if (trend != null)
					{
						if (trend.PlaybackActive)
						{
							// check if any data came back for any item.
							bool done = true;

							foreach (TsCHdaItemValueCollection result in results)
							{
								if (result.Count > 0)
								{
									done = false;
									break;
								}
							}

							// cancel the playback request and return.
							if (done)
							{
								trend.PlaybackCancel();
								return;
							}
						}
					}

					// send notification.
					if (TrendChanged != null)
					{
						TrendChanged(trend, results, false);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion

		/// <summary>
		/// Updates the state of context menus based on the current selection.
		/// </summary>
		private void TrendTV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// selects the item that was right clicked on.
			TreeNode clickedNode = trendTv_.GetNodeAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedNode == null) return;

			// force selection to clicked node.
			trendTv_.SelectedNode = clickedNode;

			// disable everything.
			addTrendMi_.Enabled           = false;
			editTrendMi_.Enabled          = false;
			removeTrendMi_.Enabled        = false;
			addItemsMi_.Enabled           = false;
			editItemMi_.Enabled           = false;
			removeItemMi_.Enabled         = false;
			readRawMi_.Enabled            = false;
			readProcessedMi_.Enabled      = false;
			readAtTimeMi_.Enabled         = false;
			readModifiedMi_.Enabled       = false;
			readAttributesMi_.Enabled     = false;
			readAnnotationsMi_.Enabled    = false;
			insertAnnotationsMi_.Enabled  = false;
			insertMi_.Enabled             = false;
			insertReplaceMi_.Enabled      = false;
			replaceMi_.Enabled            = false;
			deleteRawMi_.Enabled          = false;
			deleteAtTimeMi_.Enabled       = false;
			subscribeRawMi_.Enabled       = false;
			subscribeProcessedMi_.Enabled = false;
			subscribeCancelMi_.Enabled    = false;
			playbackRawMi_.Enabled        = false;
			playbackProcessedMi_.Enabled  = false;
			playbackCancelMi_.Enabled     = false;


			// setup menu for server nodes.
			if (typeof(TsCHdaServer).IsInstanceOfType(clickedNode.Tag))
			{
				addTrendMi_.Enabled           = true;
				readRawMi_.Enabled            = true;
				readProcessedMi_.Enabled      = true;
				readAtTimeMi_.Enabled         = true;
				readModifiedMi_.Enabled       = true;
				readAttributesMi_.Enabled     = true;
				readAnnotationsMi_.Enabled    = true;		
				insertAnnotationsMi_.Enabled  = true;	
				insertMi_.Enabled             = true;
				insertReplaceMi_.Enabled      = true;
				replaceMi_.Enabled            = true;
				deleteRawMi_.Enabled          = true;
				deleteAtTimeMi_.Enabled       = true;
                return;
			}

			// setup menu for trend nodes.
			if (typeof(TsCHdaTrend).IsInstanceOfType(clickedNode.Tag))
			{
				TsCHdaTrend trend = (TsCHdaTrend)clickedNode.Tag;

				editTrendMi_.Enabled          = true;
				removeTrendMi_.Enabled        = true;
				addItemsMi_.Enabled           = true;
				readRawMi_.Enabled            = true;
				readProcessedMi_.Enabled      = true;
				readAtTimeMi_.Enabled         = true;
				readModifiedMi_.Enabled       = true;
				readAttributesMi_.Enabled     = true;
				readAnnotationsMi_.Enabled    = true;		
				insertAnnotationsMi_.Enabled  = false;
				insertMi_.Enabled             = false;
				insertReplaceMi_.Enabled      = false;
				replaceMi_.Enabled            = false;
				deleteRawMi_.Enabled          = true;
				deleteAtTimeMi_.Enabled       = true;
				subscribeRawMi_.Enabled       = !trend.SubscriptionActive && !trend.PlaybackActive;
				subscribeProcessedMi_.Enabled = !trend.SubscriptionActive && !trend.PlaybackActive;
				subscribeCancelMi_.Enabled    = trend.SubscriptionActive;
				playbackRawMi_.Enabled        = !trend.SubscriptionActive && !trend.PlaybackActive;
				playbackProcessedMi_.Enabled  = !trend.SubscriptionActive && !trend.PlaybackActive;
				playbackCancelMi_.Enabled     = trend.PlaybackActive;
				return;
			}

			// setup menu for item nodes.
			if (typeof(TsCHdaItem).IsInstanceOfType(clickedNode.Tag))
			{
				editItemMi_.Enabled           = true;
				removeItemMi_.Enabled         = true;
				readRawMi_.Enabled            = true;
				readProcessedMi_.Enabled      = true;
				readAtTimeMi_.Enabled         = true;
				readModifiedMi_.Enabled       = true;
				readAttributesMi_.Enabled     = true;
				readAnnotationsMi_.Enabled    = true;
				insertAnnotationsMi_.Enabled  = true;
				insertMi_.Enabled             = true;
				insertReplaceMi_.Enabled      = true;
				replaceMi_.Enabled            = true;
				deleteRawMi_.Enabled          = false;
				deleteAtTimeMi_.Enabled       = false;
				return;
			}			
		}	

		/// <summary>
		/// Fires events indicating trends or items have been selected.  
		/// </summary>
		private void TrendTV_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				// check for regisitered sinks.
				if (TrendSelected == null)
				{
					return;
				}

				// check type of selection.
				if (trendTv_.SelectedNode != null)
				{
					object selection = trendTv_.SelectedNode.Tag;

					if (typeof(TsCHdaTrend).IsInstanceOfType(selection))
					{
						TrendSelected((TsCHdaTrend)selection, null);
						return;
					}

					if (typeof(TsCHdaItem).IsInstanceOfType(selection))
					{
						TrendSelected((TsCHdaTrend)trendTv_.SelectedNode.Parent.Tag, (TsCHdaItem)selection);
						return;
					}
				}
					
				// nothing of interest selected.
				TrendSelected(null, null);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		#region Trend Event Handlers
		/// <summary>
		/// Adds a new trend to the control.
		/// </summary>
		private void AddTrendMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// verify selection.
				TreeNode node = trendTv_.SelectedNode;

				if (node == null || !typeof(TsCHdaServer).IsInstanceOfType(node.Tag))
				{
					return;
				}	

				// create trend.
				TsCHdaTrend trend = new TrendCreateDlg().ShowDialog(mServer_);

				if (trend == null)
				{
					return;
				}

				// add trend to server.
				mServer_.Trends.Add(trend);

				// add trend to tree.
				AddTrend(node, trend, true);

				// ensure new node is visible.
				node.Expand();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}		

		/// <summary>
		/// Edits the parameters of a trend.
		/// </summary>
		private void EditTrendMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// verify selection.
				TreeNode node = trendTv_.SelectedNode;

				if (node == null || !typeof(TsCHdaTrend).IsInstanceOfType(node.Tag))
				{
					return;
				}

				// edit trend.
				TsCHdaTrend trend = (TsCHdaTrend)node.Tag;
				
				if (!new TrendEditDlg().ShowDialog(trend))
				{
					return;
				}

				// update display.
				UpdateTrend(node, trend, null);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Removes a trend from the control.
		/// </summary>
		private void RemoveTrendMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// verify selection.
				TreeNode node = trendTv_.SelectedNode;

				if (node == null || !typeof(TsCHdaTrend).IsInstanceOfType(node.Tag))
				{
					return;
				}

				TsCHdaTrend trend = (TsCHdaTrend)node.Tag;

				// release item server handles.
				OpcItem[] itemIDs = new OpcItem[trend.Items.Count];

				for (int ii = 0; ii < itemIDs.Length; ii++)
				{
					itemIDs[ii] = new OpcItem(trend.Items[ii]);
				}

				mServer_.ReleaseItems(itemIDs);

				// remove trend.
				mServer_.Trends.Remove(trend);

				// remove node.
				node.Remove();

				// send notification.
				if (TrendChanged != null)
				{
					TrendChanged(trend, null, true);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		
		/// <summary>
		/// Adds new items to the control.
		/// </summary>
		private void AddItemsMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// verify selection.
				TreeNode node = trendTv_.SelectedNode;

				if (node == null || !typeof(TsCHdaTrend).IsInstanceOfType(node.Tag))
				{
					return;
				}	

				// create trend.
				TsCHdaTrend trend = (TsCHdaTrend)node.Tag;

				OpcItem[] items = new TrendCreateDlg().ShowDialog(trend);

				if (items == null)
				{
					return;
				}

				// add items to control.
				node.Nodes.Clear();

				foreach (TsCHdaItem item in trend.Items)
				{
					AddItem(node, item);
				}

				// ensure new node is visible.
				node.Expand();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}		

		/// <summary>
		/// Edits a item in a trend.
		/// </summary>
		private void EditItemMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// verify selection.
				TreeNode node = trendTv_.SelectedNode;

				if (node == null || !typeof(TsCHdaItem).IsInstanceOfType(node.Tag))
				{
					return;
				}

				// prompt user to edit the item.
				TsCHdaItem item = (TsCHdaItem)node.Tag;

				if (new ItemEditDlg().ShowDialog(mServer_, item))
				{
					UpdateItem(node, item);
				}

				TsCHdaTrend trend = (TsCHdaTrend)node.Parent.Tag;

				// update the cache with the new values.
				if (TrendChanged != null)
				{
					TrendChanged(trend, trend.Read(), true);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Removes an item from a trend.
		/// </summary>
		private void RemoveItemMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				// verify selection.
				TreeNode node = trendTv_.SelectedNode;

				if (node == null || !typeof(TsCHdaItem).IsInstanceOfType(node.Tag))
				{
					return;
				}

				if (node.Parent == null || !typeof(TsCHdaTrend).IsInstanceOfType(node.Parent.Tag))
				{
					return;
				}

				// remove item from trend.
				TsCHdaTrend trend = (TsCHdaTrend)node.Parent.Tag;

				trend.RemoveItem((TsCHdaItem)node.Tag);

				// remove node.
				node.Remove();

				// send notification to clear cache.
				if (TrendChanged != null)
				{
					TrendChanged(trend, null, true);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Toggles between synchronous and asynchronous communications.
		/// </summary>
		private void UseAsyncMI_Click(object sender, System.EventArgs e)
		{
			useAsyncMi_.Checked = !useAsyncMi_.Checked;
		}
		#endregion

		#region Read Event Handlers
		/// <summary>
		/// Reads raw values for a trend.
		/// </summary>
		private void ReadRawMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.ReadRaw);
					return;
				}

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.ReadRaw);
					return;
				}

				if (IsItemNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.ReadRaw);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		
		/// <summary>
		/// Reads processed values for a trend.
		/// </summary>
		private void ReadProcessedMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.ReadProcessed);
					return;
				}

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.ReadProcessed);
					return;
				}

				if (IsItemNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.ReadProcessed);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Reads the modified values for a trend within the specified interval.
		/// </summary>
		private void ReadModifiedMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.ReadModified);
					return;
				}

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.ReadModified);
					return;
				}

				if (IsItemNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.ReadModified);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Reads the values for a trend at the specified times.
		/// </summary>
		private void ReadAtTimeMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.ReadAtTime);
					return;
				}

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.ReadAtTime);
					return;
				}

				if (IsItemNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.ReadAtTime);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		
		/// <summary>
		/// Reads the attributes for an item within the specified interval.
		/// </summary>
		private void ReadAttributesMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.ReadAttributes);
					return;
				}

				if (IsItemNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.ReadAttributes);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Reads the annotations for a trend within the specified interval.
		/// </summary>
		private void ReadAnnotationsMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.ReadAnnotations);
					return;
				}

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.ReadAnnotations);
					return;
				}

				if (IsItemNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.ReadAnnotations);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion

		#region Update Event Handlers
		/// <summary>
		/// Prompts the user to insert new values for an item.
		/// </summary>
		private void InsertMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.Insert);
					return;
				}

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.Insert);
					return;
				}

				if (IsItemNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.Insert);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Prompts the user to insert or replace values for an item.
		/// </summary>
		private void InsertReplaceMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.InsertReplace);
					return;
				}

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.InsertReplace);
					return;
				}

				if (IsItemNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.InsertReplace);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Prompts the user to replace existing values for an item.
		/// </summary>
		private void ReplaceMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.Replace);
					return;
				}

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.Replace);
					return;
				}

				if (IsItemNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.Replace);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Prompts the user to delete existing values for an item.
		/// </summary>
		private void DeleteAtTimeMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.DeleteAtTime);
					return;
				}

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.DeleteAtTime);
					return;
				}

				if (IsItemNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.DeleteAtTime);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Prompts the user to delete existing values for an item.
		/// </summary>
		private void DeleteRawMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.DeleteRaw);
					return;
				}

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.DeleteRaw);
					return;
				}

				if (IsItemNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.DeleteRaw);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Prompts the user to insert annotations for an item.
		/// </summary>
		private void InsertAnnotationsMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.InsertAnnotations);
					return;
				}

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.InsertAnnotations);
					return;
				}

				if (IsItemNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.InsertAnnotations);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion

		#region Subscribe Event Handlers
		/// <summary>
		/// Creates or modifies a subscription for raw values.
		/// </summary>
		private void SubscribeRawMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.AdviseRaw);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Creates or modifies a subscription for processed values.
		/// </summary>
		private void SubscribeProcessedMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.AdviseProcessed);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Cancels an existing subscription.
		/// </summary>
		private void SubscribeCancelMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					((TsCHdaTrend)node.Tag).SubscribeCancel();
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion

		#region Playback Event Handlers
		/// <summary>
		/// Creates or modifies a playback request for raw values.
		/// </summary>
		private void PlaybackRawMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.PlaybackRaw);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Creates or modifies a playback request for processed values.
		/// </summary>
		private void PlaybackProcessedMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.PlaybackProcessed);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Cancels an existing playback request.
		/// </summary>
		private void PlaybackCancelMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = trendTv_.SelectedNode;

				if (IsTrendNode(trendTv_.SelectedNode))
				{
					((TsCHdaTrend)node.Tag).PlaybackCancel();
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion
	}
}

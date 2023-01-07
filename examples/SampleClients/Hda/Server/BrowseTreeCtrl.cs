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

using SampleClients.Common;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Server
{

	/// <summary>
	/// A tree control use to navigate the address space of an HDA server.
	/// </summary>
	public class BrowseTreeCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView browseTv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem refreshMi_;
		private System.Windows.Forms.ToolStripMenuItem editFiltersMi_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		private System.Windows.Forms.ToolStripMenuItem pickMi_;
		private System.Windows.Forms.ToolStripMenuItem pickChildrenMi_;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public BrowseTreeCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			browseTv_.ImageList = Resources.Instance.ImageList;
			Clear();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				// ensure the filters dialog is disposed properly.
				if (mFiltersDialog_ != null && !mFiltersDialog_.IsDisposed)
				{
					mFiltersDialog_.Close();
					mFiltersDialog_ = null;
				}

				// ensure browser object is disposed.
				if (mBrowser_ != null)
				{
					mBrowser_.Dispose();
					mBrowser_ = null;
				}

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
			browseTv_ = new System.Windows.Forms.TreeView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			pickMi_ = new System.Windows.Forms.ToolStripMenuItem();
			pickChildrenMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			editFiltersMi_ = new System.Windows.Forms.ToolStripMenuItem();
			refreshMi_ = new System.Windows.Forms.ToolStripMenuItem();
			SuspendLayout();
			// 
			// BrowseTV
			// 
			browseTv_.ContextMenuStrip = popupMenu_;
			browseTv_.Dock = System.Windows.Forms.DockStyle.Fill;
			browseTv_.ImageIndex = -1;
			browseTv_.Location = new System.Drawing.Point(0, 0);
			browseTv_.Name = "browseTv_";
			browseTv_.SelectedImageIndex = -1;
			browseTv_.Size = new System.Drawing.Size(400, 400);
			browseTv_.TabIndex = 0;
			browseTv_.MouseDown += new System.Windows.Forms.MouseEventHandler(BrowseTV_MouseDown);
			browseTv_.DoubleClick += new System.EventHandler(BrowseTV_DoubleClick);
			browseTv_.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(BrowseTV_AfterSelect);
			browseTv_.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(BrowseTV_BeforeExpand);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  pickMi_,
																					  pickChildrenMi_,
																					  separator01_,
																					  editFiltersMi_,
																					  refreshMi_});
			// 
			// PickMI
			// 
			pickMi_.ImageIndex = 0;
			pickMi_.Text = "&Select";
			pickMi_.Click += new System.EventHandler(PickMI_Click);
			// 
			// PickChildrenMI
			// 
			pickChildrenMi_.ImageIndex = 1;
			pickChildrenMi_.Text = "Select Chil&dren";
			pickChildrenMi_.Click += new System.EventHandler(PickChildrenMI_Click);
			// 
			// Separator01
			// 
			separator01_.ImageIndex = 2;
			separator01_.Text = "-";
			// 
			// EditFiltersMI
			// 
			editFiltersMi_.ImageIndex = 3;
			editFiltersMi_.Text = "Set &Filters...";
			editFiltersMi_.Click += new System.EventHandler(EditFiltersMI_Click);
			// 
			// RefreshMI
			// 
			refreshMi_.ImageIndex = 4;
			refreshMi_.Text = "&Refresh";
			// 
			// BrowseTreeCtrl
			// 
			Controls.Add(browseTv_);
			Name = "BrowseTreeCtrl";
			Size = new System.Drawing.Size(400, 400);
			ResumeLayout(false);

		}
		#endregion
				
		#region Public Interface
		/// <summary>
		/// A delegate to receive item picked events.
		/// </summary>
		public delegate void ItemPickedEventHandler(OpcItem[] items);

		/// <summary>
		/// Fired when one or more items are explicitly picked within the tree control.
		/// </summary>
		public event ItemPickedEventHandler ItemPicked;

		/// <summary>
		/// A delegate to receive item selected events.
		/// </summary>
		public delegate void ItemSelectedEventHandler(OpcItem item);

		/// <summary>
		/// Fired when an item node is selected in the tree.
		/// </summary>
		public event ItemSelectedEventHandler ItemSelected;

		/// <summary>
		/// Browses the address space for a single server.
		/// </summary>
		public void Browse(TsCHdaServer server, TsCHdaBrowseFilter[] filters)
		{
			if (server == null) throw new ArgumentNullException("server");

			Clear();
			
			// create the initial browser.
			try
			{
				OpcResult[] results = null;
				mBrowser_ = server.CreateBrowser(filters, out results);
				mServer_  = server;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return;
			}

			// create the root node.
            TreeNode root = new TreeNode(server.ServerName);
			root.ImageIndex         = Resources.IMAGE_LOCAL_SERVER;
			root.SelectedImageIndex = Resources.IMAGE_LOCAL_SERVER;
			root.Tag                = server;

			// browse for top level nodes.
			Browse(root, null);	

			// add new node to tree view.
			browseTv_.Nodes.Add(root);	
			root.Expand();
		}

		/// <summary>
		/// Removes all nodes and releases all resources.
		/// </summary>
		public void Clear()
		{		
			// recursively searches the tree and free objects.
			foreach (TreeNode child in browseTv_.Nodes)
			{
				Clear(child);
			}

			// clear the tree.
			browseTv_.Nodes.Clear();
		}
		
		/// <summary>
		/// Clears the current selection in the tree control
		/// </summary>
		public void ClearSelection()
		{		
			browseTv_.SelectedNode = null;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// The server which is being browsed.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// The object used to browse the server address space.
		/// </summary>
		private ITsCHdaBrowser mBrowser_ = null;

		/// <summary>
		/// The maximum number of elements to return in a single browse operation.
		/// </summary>
		private int mMaxElements_ = 0;
		
		/// <summary>
		/// The non-model dialog used to change the browse filters.
		/// </summary>
		private BrowseFiltersDlg mFiltersDialog_ = new BrowseFiltersDlg();

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
		/// Browses for child nodes and populates the tree.
		/// </summary>
		private void Browse(TreeNode parent, TsCHdaBrowseElement branch)
		{
			// clear existing children.
			parent.Nodes.Clear();

			// browse for the children of the node.
			TsCHdaBrowseElement[] children = null;
			
			IOpcBrowsePosition position = null;

			do
			{
				// fetch next batch of elements from the server.
				try
				{
					if (position == null)
					{
						children = mBrowser_.Browse(branch, mMaxElements_, out position);
					}
					else
					{
						children = mBrowser_.BrowseNext(mMaxElements_, ref position);
					}
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message);
					break;
				}

				// nothing more to do.
				if (children == null)
				{
					break;
				}

				// create a tree node for each child.
				foreach (TsCHdaBrowseElement child in children)
				{
					// create new node.
					TreeNode node = new TreeNode(child.Name);

					// set node icon.
					if (child.IsItem)
					{						
						node.ImageIndex         = Resources.IMAGE_GREEN_SCROLL;
						node.SelectedImageIndex = Resources.IMAGE_GREEN_SCROLL;
					}
					else
					{
						node.ImageIndex         = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
						node.SelectedImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
					}
				
					// save element.
					node.Tag = child;

					// add dummy child node for branches.
					if (child.HasChildren)
					{
						node.Nodes.Add(new TreeNode());
					}

					// add top level node to root node.
					parent.Nodes.Add(node);
				}

				// prompt use to continue browse operation.
				if (position != null)
				{
					if (MessageBox.Show("More items exist. Continue browsing?", "Browse Items", MessageBoxButtons.YesNo) == DialogResult.No)
					{
						break;
					}
				}
			}
			while (position != null);		

			// release browse position object if browse halted.
			if (position != null)
			{
				position.Dispose();
				position = null;
			}
		}
		#endregion

		/// <summary>
		/// Called before a node is about to expand.
		/// </summary>
		private void BrowseTV_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;

			if (node == null || node.Tag == null)
			{
				return;
			}

			if (node.Tag.GetType() == typeof(TsCHdaBrowseElement))
			{
				TsCHdaBrowseElement element = (TsCHdaBrowseElement)node.Tag;

				// fetch children if they have not already been fetched.
				if (element.HasChildren && node.Nodes.Count == 1 && node.Nodes[0].Tag == null)
				{
					Browse(node, element);	
				}
			}		
		}

		/// <summary>
		/// Updates the state of context menus based on the current selection.
		/// </summary>
		private void BrowseTV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// selects the item that was right clicked on.
			TreeNode clickedNode = browseTv_.GetNodeAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedNode == null) return;

			// force selection to clicked node.
			browseTv_.SelectedNode = clickedNode;

			// disable everything.
			pickMi_.Enabled            = false;
			pickChildrenMi_.Enabled    = false;
			editFiltersMi_.Enabled     = false;
			refreshMi_.Enabled         = false;

			// setup menu for browse element nodes.
			if (typeof(TsCHdaBrowseElement).IsInstanceOfType(clickedNode.Tag))
			{
				TsCHdaBrowseElement element = (TsCHdaBrowseElement)clickedNode.Tag;

				pickMi_.Enabled            = element.IsItem;
				pickChildrenMi_.Enabled    = element.HasChildren;
				editFiltersMi_.Enabled     = element.HasChildren;
				refreshMi_.Enabled         = element.HasChildren;

				return;
			}
			
			// setup menu for server nodes.
			if (typeof(TsCHdaServer).IsInstanceOfType(clickedNode.Tag))
			{
				pickMi_.Enabled            = false;
				pickChildrenMi_.Enabled    = true;
				editFiltersMi_.Enabled     = true;
				refreshMi_.Enabled         = true;

				return;
			}
		}	
		
		/// <summary>
		/// Called when the browse filters have changed.
		/// </summary>
		private void OnBrowseFiltersChanged(int maxElements, TsCHdaBrowseFilter[] filters)
		{
			try
			{
				// release existing browser.
				if (mBrowser_ != null)
				{
					mBrowser_.Dispose();
					mBrowser_ = null;
				}

				// create a new browser.
				OpcResult[] results = null;
				mBrowser_ = mServer_.CreateBrowser(filters, out results);

				// save maximum elements to return in a single call.
				mMaxElements_ = maxElements;

				// update chidren of selected node.
				TreeNode node = browseTv_.SelectedNode;

				if (node != null)
				{
					TsCHdaBrowseElement branch = null;

					if (node.Tag != null && node.Tag.GetType() == typeof(TsCHdaBrowseElement))
					{
						branch = (TsCHdaBrowseElement)node.Tag;
					}

					Browse(node, branch);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
			
		/// <summary>
		/// Causes an item selected event to be sent for the current node.
		/// </summary>
		private void PickMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check if current selection is valid.
				TreeNode node = browseTv_.SelectedNode;

				if (node == null || node.Tag == null || node.Tag.GetType() != typeof(TsCHdaBrowseElement))
				{
					return;
				}

				// raise event if selected element is an item.
				TsCHdaBrowseElement element = (TsCHdaBrowseElement)node.Tag;

				if (element.IsItem)
				{
					if (ItemPicked != null)
					{
						ItemPicked(new OpcItem[] { element });
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Causes an item selected event to be sent for each child of of the current node.
		/// </summary>
		private void PickChildrenMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check if current selection is valid.
				TreeNode node = browseTv_.SelectedNode;

				if (node == null || node.Nodes.Count == 0)
				{
					return;
				}

				// build list of items contained in the selected branch.
				ArrayList items = new ArrayList();

				foreach (TreeNode child in node.Nodes)
				{
					if (typeof(TsCHdaBrowseElement).IsInstanceOfType(child.Tag))
					{
						TsCHdaBrowseElement element = (TsCHdaBrowseElement)child.Tag;

						if (element.IsItem)
						{
							items.Add(element);
						}
					}
				}

				// raise event at least one child item was found.
				if (items.Count > 0)
				{
					if (ItemPicked != null)
					{
						ItemPicked((OpcItem[])items.ToArray(typeof(OpcItem)));
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Displays the edit browse filters dialog.
		/// </summary>
		private void EditFiltersMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// create new dialog if required.
				if (mFiltersDialog_ == null || mFiltersDialog_.IsDisposed)
				{
					mFiltersDialog_ = new BrowseFiltersDlg();
				}

				// show the dialog.
				mFiltersDialog_.Show(
					FindForm(), 
					mServer_, 
					mBrowser_, 
					mMaxElements_,
					new BrowseFiltersChangedCallback(OnBrowseFiltersChanged));
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
        
		/// <summary>
		/// Updates the contents of the current selection.
		/// </summary>
		private void RefreshMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// TBD
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Sends an item picked event.
		/// </summary>
		private void BrowseTV_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				// check if current selection is valid.
				TreeNode node = browseTv_.SelectedNode;

				if (node == null || !typeof(TsCHdaBrowseElement).IsInstanceOfType(node.Tag))
				{
					return;
				}

				// check if selection is an item.
				TsCHdaBrowseElement element = (TsCHdaBrowseElement)node.Tag;

				if (element.IsItem)
				{
					if (ItemPicked != null)
					{
						ItemPicked(new OpcItem[] { element });
					}				
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Sends an item selected event.
		/// </summary>
		private void BrowseTV_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				// ignore event if no listeners.
				if (ItemSelected == null)
				{
					return;
				}	

				// check if the current selection is an item.
				TsCHdaBrowseElement element = null;

				TreeNode node = browseTv_.SelectedNode;

				if (node != null && typeof(TsCHdaBrowseElement).IsInstanceOfType(node.Tag))
				{
					if (((TsCHdaBrowseElement)node.Tag).IsItem)
					{
						element = (TsCHdaBrowseElement)node.Tag;
					}
				}

				// fire the event.
				ItemSelected(element);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}

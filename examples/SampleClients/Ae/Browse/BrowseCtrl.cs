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
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A control used to select a valid value for any bit mask expressed as an enumeration.
    /// </summary>
    public class BrowseCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView browseTv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem applyFiltersMi_;
		private System.Windows.Forms.ToolStripMenuItem selectNodeMi_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		private System.Windows.Forms.ToolStripMenuItem separator02_;
		private System.Windows.Forms.ToolStripMenuItem separator03_;
		private System.Windows.Forms.ToolStripMenuItem getEnabledStateMi_;
		private System.Windows.Forms.ToolStripMenuItem getConditionStateMi_;
		private System.Windows.Forms.ToolStripMenuItem getDaItemIDsMi_;
		private System.Windows.Forms.ToolStripMenuItem setEnabledStateMi_;
		private System.ComponentModel.IContainer components_ = null;

		public BrowseCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			browseTv_.ImageList = Resources.Instance.ImageList;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if(components_ != null)
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
			applyFiltersMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			selectNodeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator02_ = new System.Windows.Forms.ToolStripMenuItem();
			setEnabledStateMi_ = new System.Windows.Forms.ToolStripMenuItem();
			getEnabledStateMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator03_ = new System.Windows.Forms.ToolStripMenuItem();
			getConditionStateMi_ = new System.Windows.Forms.ToolStripMenuItem();
			getDaItemIDsMi_ = new System.Windows.Forms.ToolStripMenuItem();
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
			browseTv_.Size = new System.Drawing.Size(400, 304);
			browseTv_.TabIndex = 0;
			browseTv_.MouseDown += new System.Windows.Forms.MouseEventHandler(BrowseTV_MouseDown);
			browseTv_.DoubleClick += new System.EventHandler(BrowseTV_DoubleClick);
			browseTv_.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(BrowseTV_AfterSelect);
			browseTv_.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(BrowseTV_BeforeExpand);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  applyFiltersMi_,
																					  separator01_,
																					  selectNodeMi_,
																					  separator02_,
																					  getEnabledStateMi_,
																					  setEnabledStateMi_,
																					  separator03_,
																					  getConditionStateMi_,
																					  getDaItemIDsMi_});
			// 
			// ApplyFiltersMI
			// 
			applyFiltersMi_.Text = "Apply Filters...";
			applyFiltersMi_.Click += new System.EventHandler(ApplyFiltersMI_Click);
			// 
			// Separator01
			// 
			separator01_.Text = "-";
			// 
			// SelectNodeMI
			// 
			selectNodeMi_.Text = "Select";
			selectNodeMi_.Click += new System.EventHandler(SelectNodeMI_Click);
			// 
			// Separator02
			// 
			separator02_.Text = "-";
			// 
			// SetEnabledStateMI
			// 
			setEnabledStateMi_.Text = "Set Enabled State...";
			setEnabledStateMi_.Click += new System.EventHandler(SetEnabledStateMI_Click);
			// 
			// GetEnabledStateMI
			// 
			getEnabledStateMi_.Text = "Get Enabled State...";
			getEnabledStateMi_.Click += new System.EventHandler(GetEnabledStateMI_Click);
			// 
			// Separator03
			// 
			separator03_.Text = "-";
			// 
			// GetConditionStateMI
			// 
			getConditionStateMi_.Text = "Get Condition State...";
			getConditionStateMi_.Click += new System.EventHandler(GetConditionStateMI_Click);
			// 
			// GetDAItemIDsMI
			// 
			getDaItemIDsMi_.Text = "Get DA ItemIDs...";
			getDaItemIDsMi_.Click += new System.EventHandler(GetDAItemIDsMI_Click);
			// 
			// BrowseCtrl
			// 
			Controls.Add(browseTv_);
			Name = "BrowseCtrl";
			Size = new System.Drawing.Size(400, 304);
			ResumeLayout(false);

		}
		#endregion
	
		#region Private Members
		private TsCAeServer mServer_ = null;
		private string mBrowseFilter_ = null;
		private int mMaxElements_ = 0;
		private bool mRecursive_ = false;
		private event NodeSelectedEventHandler MNodeSelected = null;

		private const string EventsText = "Events";
		private const string AreasText  = "Areas";
		#endregion
		
		#region Public Interface
		/// <summary>
		/// Raised when a area or source node in the tree is selected.
		/// </summary>
		public event NodeSelectedEventHandler NodeSelected
		{
			add    { MNodeSelected += value; }
			remove { MNodeSelected += value; }
		}

		/// <summary>
		/// A delegate to receive notifications when categories are selected.
		/// </summary>
		public delegate void NodeSelectedEventHandler(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element, bool picked);

		/// <summary>
		/// Displays the area hierarchy for the server.
		/// </summary>
		public void ShowAreas(TsCAeServer server)
		{
			mServer_ = server;

			browseTv_.Nodes.Clear();

			// nothing more to do if no server provided.
			if (mServer_ == null)
			{
				return;
			}

            // create root node.
            TreeNode root = new TreeNode(mServer_.ServerName)
            {
                ImageIndex = Resources.IMAGE_LOCAL_SERVER,
                SelectedImageIndex = Resources.IMAGE_LOCAL_SERVER,
                Tag = mServer_
            };

            browseTv_.Nodes.Add(root);	

			// browse top level areas.
			BrowseArea(root.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area, null);

			// browse top level sources.
			BrowseArea(root.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Source, null);

			// expand root node.
			root.Expand();
		}

		/// <summary>
		/// Displays the area and event hierarchies for the server.
		/// </summary>
		/// <param name="server"></param>
		public void ShowEventsAndAreas(TsCAeServer server)
		{
			mServer_ = server;

			browseTv_.Nodes.Clear();

			// nothing more to do if no server provided.
			if (mServer_ == null)
			{
				return;
			}

            // create root node.
            TreeNode root = new TreeNode(mServer_.ServerName)
            {
                ImageIndex = Resources.IMAGE_LOCAL_SERVER,
                SelectedImageIndex = Resources.IMAGE_LOCAL_SERVER,
                Tag = mServer_
            };

            browseTv_.Nodes.Add(root);

            // create events node.
            TreeNode events = new TreeNode(EventsText)
            {
                ImageIndex = Resources.IMAGE_OPEN_YELLOW_FOLDER,
                SelectedImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER,
                Tag = EventsText
            };

            // browse event categories
            BrowseEvents(events.Nodes, TsCAeEventType.Simple);
			BrowseEvents(events.Nodes, TsCAeEventType.Tracking);
			BrowseEvents(events.Nodes, TsCAeEventType.Condition);

			root.Nodes.Add(events);

            // create areas node.
            TreeNode areas = new TreeNode(AreasText)
            {
                ImageIndex = Resources.IMAGE_OPEN_YELLOW_FOLDER,
                SelectedImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER,
                Tag = AreasText
            };

            root.Nodes.Add(areas);

			// browse top level areas.
			BrowseArea(areas.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area, null);

			// browse top level sources.
			BrowseArea(areas.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Source, null);

			// expand root node.
			root.Expand();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Recursively finds all browse elements in the tree starting with the specified node.
		/// </summary>
		private void FindBrowseElements(TreeNode node, ArrayList elements)
		{	
			if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(node.Tag))
			{
				elements.Add(node.Tag);
			}

			if (node != null)
			{
				// check if a dummy node is present.
				if (node.Nodes.Count == 1 && node.Nodes[0].Text.Length == 0)
				{
					FetchChildren(node);
				}	

				// find children.
				foreach (TreeNode child in node.Nodes)
				{
					FindBrowseElements(child, elements);
				}
			}
		}

		/// <summary>
		/// Fetches the children for the specified node.
		/// </summary>
		private void FetchChildren(TreeNode node)
		{
			// check for element.
			if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(node.Tag))
			{
				// get the element.
				Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element = (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)node.Tag;

				node.Nodes.Clear();

				// browse area.
				if (element.NodeType == Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area)
				{
					BrowseArea(node.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area,   element);
					BrowseArea(node.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Source, element);
				}

				// browse source
				else
				{
					BrowseSource(node.Nodes, element);
				}
			}

			// check for category.
			else if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeCategory).IsInstanceOfType(node.Tag))
			{
				node.Nodes.Clear();
				BrowseCategory(node.Nodes, (Technosoftware.DaAeHdaClient.Ae.TsCAeCategory)node.Tag);
			}

			// check for conditions.
			else if (typeof(Condition).IsInstanceOfType(node.Tag))
			{
				node.Nodes.Clear();
				BrowseCondition(node.Nodes, (Condition)node.Tag);
			}
		}

		/// <summary>
		/// A wrapper for a condition name.
		/// </summary>
		private struct Condition
		{
			public string Name;
			public Condition(string name) {	Name = name; }
		}

		/// <summary>
		/// Populates the tree with the event categories supported by the server.
		/// </summary>
		private void BrowseEvents(TreeNodeCollection nodes, TsCAeEventType eventType)
		{
			// fetch categories.
			Technosoftware.DaAeHdaClient.Ae.TsCAeCategory[] categories = mServer_.QueryEventCategories((int)eventType);

			if (categories.Length == 0)
			{
				return;
			}

            // create event type node.
            TreeNode root = new TreeNode(eventType.ToString())
            {
                ImageIndex = Resources.IMAGE_OPEN_YELLOW_FOLDER,
                SelectedImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER,
                Tag = eventType
            };

            nodes.Add(root);

			// add categories to tree.
			foreach (Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category in categories)
			{
                // create node.
                TreeNode node = new TreeNode(category.Name)
                {
                    ImageIndex = Resources.IMAGE_ENVELOPE,
                    SelectedImageIndex = Resources.IMAGE_ENVELOPE,
                    Tag = category
                };

                // add dummy child to ensure '+' sign is visible.
                if (eventType == TsCAeEventType.Condition)
				{
					node.Nodes.Add(new TreeNode());
				}

				// add to tree.
				root.Nodes.Add(node);
			}
		}

		/// <summary>
		/// Populates the tree with the elements within the specified area.
		/// </summary>
		private void BrowseArea(TreeNodeCollection nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType browseType, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement area)
		{
			IOpcBrowsePosition position = null;

			try
			{
				// fetch first batch of elements.
                Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement[] elements = mServer_.Browse(
                    area?.QualifiedName,
                    browseType,
                    mBrowseFilter_,
                    mMaxElements_,
                    out position);


				do
				{
					// add elements to tree.
					for (int ii = 0; ii < elements.Length; ii++)
					{
                        // create node.
                        TreeNode node = new TreeNode(elements[ii].Name)
                        {
                            ImageIndex = (browseType == Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area) ? Resources.IMAGE_CLOSED_BLUE_FOLDER : Resources.IMAGE_GREEN_SCROLL,
                            SelectedImageIndex = (browseType == Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area) ? Resources.IMAGE_OPEN_BLUE_FOLDER : Resources.IMAGE_GREEN_SCROLL,
                            Tag = elements[ii]
                        };

                        // add dummy child to ensure '+' sign is visible.
                        node.Nodes.Add(new TreeNode());

						// add to tree.
						nodes.Add(node);
					}

					// check if browse is complete.
					if (position == null)
					{
						break;
					}

					// prompt to continue browse.
					DialogResult result = MessageBox.Show(
						"More elements meeting search criteria exist. Continue browse?", 
						"Browse " + browseType + "s", 
						MessageBoxButtons.YesNo);
				
					if (result == DialogResult.No)
					{
						break;
					}
					
					// continue browse.
					elements = mServer_.BrowseNext(mMaxElements_, ref position);
				}
				while (true);
			}
			finally
			{
				// dipose position object on exit.
				if (position != null)
				{
					position.Dispose();
					position = null;
				}
			}
		}
		
		/// <summary>
		/// Populates the tree with the conditions for the source.
		/// </summary>
		private void BrowseSource(TreeNodeCollection nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement source)
		{
			// fetch conditions.
			string[] conditions = mServer_.QueryConditionNames(source.QualifiedName);

			// add conditions to tree.
			for (int ii = 0; ii < conditions.Length; ii++)
			{
                // create node.
                TreeNode node = new TreeNode(conditions[ii])
                {
                    ImageIndex = Resources.IMAGE_EXPLODING_BOX,
                    SelectedImageIndex = Resources.IMAGE_EXPLODING_BOX,
                    Tag = new Condition(conditions[ii])
                };

                // add dummy child to ensure '+' sign is visible.
                node.Nodes.Add(new TreeNode());

				// add to tree.
				nodes.Add(node);
			}
		}

		/// <summary>
		/// Populates the tree with the sub-conditions for the condition.
		/// </summary>
		private void BrowseCondition(TreeNodeCollection nodes, Condition condition)
		{
			// fetch subconditions.
			string[] subconditions = mServer_.QuerySubConditionNames(condition.Name);

			// add conditions to tree.
			for (int ii = 0; ii < subconditions.Length; ii++)
			{
                // create node.
                TreeNode node = new TreeNode(subconditions[ii])
                {
                    ImageIndex = Resources.IMAGE_LIST_BOX,
                    SelectedImageIndex = Resources.IMAGE_LIST_BOX,
                    Tag = subconditions[ii]
                };

                // add to tree.
                nodes.Add(node);
			}
		}

		/// <summary>
		/// Populates the tree with the conditions for the category.
		/// </summary>
		private void BrowseCategory(TreeNodeCollection nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category)
		{
			// fetch conditions.
			string[] conditions = mServer_.QueryConditionNames(category.ID);

			// add conditions to tree.
			for (int ii = 0; ii < conditions.Length; ii++)
			{
                // create node.
                TreeNode node = new TreeNode(conditions[ii])
                {
                    ImageIndex = Resources.IMAGE_EXPLODING_BOX,
                    SelectedImageIndex = Resources.IMAGE_EXPLODING_BOX,
                    Tag = new Condition(conditions[ii])
                };

                // add dummy child to ensure '+' sign is visible.
                node.Nodes.Add(new TreeNode());

				// add to tree.
				nodes.Add(node);
			}
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Fetches the child nodes before expanding a node.
		/// </summary>
		private void BrowseTV_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			try
			{
				// check if a dummy node is present.
				if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text.Length == 0)
				{
					FetchChildren(e.Node);
				}				
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Refreshes the current node with the current filter settings.
		/// </summary>
		private void ApplyFiltersMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				TreeNode node = browseTv_.SelectedNode;

				if (!typeof(TsCAeServer).IsInstanceOfType(node.Tag) && !typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(node.Tag))
				{
					return;
				}

				// diplay dialog.
				bool result = new BrowseFiltersDlg().ShowDialog(
					ref mBrowseFilter_, 
					ref mMaxElements_, 
					new EventHandler(FiltersChanged));

				// update display.
				if (result)
				{
					node.Nodes.Clear();

					if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(node.Tag))
					{
						BrowseArea(node.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area,   (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)node.Tag);
						BrowseArea(node.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Source, (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)node.Tag);
					}
					else
					{
						BrowseArea(node.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area,   null);
						BrowseArea(node.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Source, null);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		
		/// <summary>
		/// Called when the apply button in the browse filters dialog is clicked.
		/// </summary>
		private void FiltersChanged(object sender, System.EventArgs e)
		{
			TreeNode node = browseTv_.SelectedNode;

			if (node != null)
			{
				mBrowseFilter_ = ((BrowseFiltersDlg)sender).Filter;
				mMaxElements_  = ((BrowseFiltersDlg)sender).MaxElements;

				node.Nodes.Clear();

				if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(node.Tag))
				{
					BrowseArea(node.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area,   (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)node.Tag);
					BrowseArea(node.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Source, (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)node.Tag);
				}
				else
				{
					BrowseArea(node.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area,   null);
					BrowseArea(node.Nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Source, null);
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
			applyFiltersMi_.Enabled      = false;
			selectNodeMi_.Enabled        = MNodeSelected != null;
			getEnabledStateMi_.Enabled   = false;
			setEnabledStateMi_.Enabled   = false;
			getConditionStateMi_.Enabled = false;
			getDaItemIDsMi_.Enabled      = false;

			// check for server node.
			if (typeof(TsCAeServer).IsInstanceOfType(clickedNode.Tag))
			{
				applyFiltersMi_.Enabled    = true;
				getEnabledStateMi_.Enabled = true;
				setEnabledStateMi_.Enabled = true;
				return;
			}

			// check for area or source node.
			if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(clickedNode.Tag))
			{
				if (((Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)clickedNode.Tag).NodeType == Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area)
				{
					applyFiltersMi_.Enabled  = true;
				}
				
				getEnabledStateMi_.Enabled = true;
				setEnabledStateMi_.Enabled = true;
				return;
			}

			// check for condition node.
			if (typeof(Condition).IsInstanceOfType(clickedNode.Tag))
			{
				getConditionStateMi_.Enabled = true;
				getDaItemIDsMi_.Enabled      = true;
			}

			// check for sub-condition node.
			if (typeof(string).IsInstanceOfType(clickedNode.Tag))
			{
				if (typeof(Condition).IsInstanceOfType(clickedNode.Parent.Tag))
				{
					getDaItemIDsMi_.Enabled = true;
				}
			}
		}	

		/// <summary>
		/// Sends notifications after a node is selected.
		/// </summary>
		private void BrowseTV_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{		
			try
			{
				if (MNodeSelected == null || browseTv_.SelectedNode == null)
				{
					return;
				}

				if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(browseTv_.SelectedNode.Tag))
				{
					MNodeSelected((Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)browseTv_.SelectedNode.Tag, false);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}	
		}

		/// <summary>
		/// Sends notifications after a node is picked.
		/// </summary>
		private void BrowseTV_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if (MNodeSelected == null || browseTv_.SelectedNode == null)
				{
					return;
				}

				if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(browseTv_.SelectedNode.Tag))
				{
					MNodeSelected((Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)browseTv_.SelectedNode.Tag, true);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}	
		}

		/// <summary>
		/// Sends notifications after a node is picked.
		/// </summary>
		private void SelectNodeMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MNodeSelected == null || browseTv_.SelectedNode == null)
				{
					return;
				}

				if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(browseTv_.SelectedNode.Tag))
				{
					MNodeSelected((Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)browseTv_.SelectedNode.Tag, true);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}			
		}

		/// <summary>
		/// Enables condition based notifications for the area or source.
		/// </summary>
		private void SetEnabledStateMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				// find current selection.
				Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement selection = null;

				if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(browseTv_.SelectedNode.Tag))
				{
					selection = (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)browseTv_.SelectedNode.Tag;
				}
				else if (!typeof(TsCAeServer).IsInstanceOfType(browseTv_.SelectedNode.Tag))
				{
					return;
				}

				// prompt user.
				bool enabled = false;

				bool result = new SetEnabledStateDlg().ShowDialog(
					mServer_,
					selection,
					out enabled, 
					ref mRecursive_);

				if (!result)
				{
					return;
				}

				// apply changes.	
				ArrayList elements = new ArrayList();

				if (mRecursive_)
				{
					FindBrowseElements(browseTv_.SelectedNode, elements);
				}
				else
				{
					elements.Add(selection);
				}

				// seperate into areas and sources.
				ArrayList areas   = new ArrayList();
				ArrayList sources = new ArrayList();

				foreach (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element in elements)
				{
					if (element.NodeType == Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area)
					{
						areas.Add(element.QualifiedName);
					}
					else
					{
						sources.Add(element.QualifiedName);
					}
				}

				// call server.
				if (enabled)
				{
					mServer_.EnableConditionByArea((string[])areas.ToArray(typeof(string)));
					mServer_.EnableConditionBySource((string[])sources.ToArray(typeof(string)));
				}
				else
				{
					mServer_.DisableConditionByArea((string[])areas.ToArray(typeof(string)));
					mServer_.DisableConditionBySource((string[])sources.ToArray(typeof(string)));
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}	
		}

		/// <summary>
		/// Gets the enabled state for all elements in the hierarchy.
		/// </summary>
		private void GetEnabledStateMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				ArrayList elements = new ArrayList();

				FindBrowseElements(browseTv_.SelectedNode, elements);

				new GetEnabledStateDlg().ShowDialog(mServer_, (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement[])elements.ToArray(typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)));
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}	
		}

		/// <summary>
		/// Gets the current state for the selected condition.
		/// </summary>
		private void GetConditionStateMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				if (typeof(Condition).IsInstanceOfType(browseTv_.SelectedNode.Tag))
				{
					Condition condition = (Condition)browseTv_.SelectedNode.Tag;
					Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement source = (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)browseTv_.SelectedNode.Parent.Tag;

					new ConditionStateDlg().ShowDialog(mServer_, source.QualifiedName, condition.Name);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void GetDAItemIDsMI_Click(object sender, System.EventArgs e)
		{	
			try
			{
				if (typeof(Condition).IsInstanceOfType(browseTv_.SelectedNode.Tag))
				{
					Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement source    = (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)browseTv_.SelectedNode.Parent.Tag;
					Condition     condition = (Condition)browseTv_.SelectedNode.Tag;

					new ItemIDsViewDlg().ShowDialog(mServer_, source.QualifiedName, condition.Name, null);
				}

				if (typeof(string).IsInstanceOfType(browseTv_.SelectedNode.Tag))
				{
					Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement source       = (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)browseTv_.SelectedNode.Parent.Parent.Tag;
					Condition     condition    = (Condition)browseTv_.SelectedNode.Parent.Tag;
					string        subcondition = (string)browseTv_.SelectedNode.Tag;

					new ItemIDsViewDlg().ShowDialog(mServer_, source.QualifiedName, condition.Name, subcondition);
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
  
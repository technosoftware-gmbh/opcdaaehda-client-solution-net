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
    public class AttributesCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView attributesTv_;
		private System.Windows.Forms.GroupBox attributesGb_;
		private System.ComponentModel.IContainer components = null;

		public AttributesCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			attributesTv_.ImageList = Resources.Instance.ImageList;
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
			attributesTv_ = new System.Windows.Forms.TreeView();
			attributesGb_ = new System.Windows.Forms.GroupBox();
			attributesGb_.SuspendLayout();
			SuspendLayout();
			// 
			// AttributesTV
			// 
			attributesTv_.CheckBoxes = true;
			attributesTv_.Dock = System.Windows.Forms.DockStyle.Fill;
			attributesTv_.ImageIndex = -1;
			attributesTv_.Location = new System.Drawing.Point(3, 16);
			attributesTv_.Name = "attributesTv_";
			attributesTv_.SelectedImageIndex = -1;
			attributesTv_.Size = new System.Drawing.Size(394, 285);
			attributesTv_.TabIndex = 0;
			attributesTv_.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(AttributesTV_AfterCheck);
			attributesTv_.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(AttributesTV_BeforeExpand);
			// 
			// AttributesGB
			// 
			attributesGb_.Controls.Add(attributesTv_);
			attributesGb_.Dock = System.Windows.Forms.DockStyle.Fill;
			attributesGb_.Location = new System.Drawing.Point(0, 0);
			attributesGb_.Name = "attributesGb_";
			attributesGb_.Size = new System.Drawing.Size(400, 304);
			attributesGb_.TabIndex = 1;
			attributesGb_.TabStop = false;
			attributesGb_.Text = "Attributes";
			// 
			// AttributesCtrl
			// 
			Controls.Add(attributesGb_);
			Name = "AttributesCtrl";
			Size = new System.Drawing.Size(400, 304);
			attributesGb_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion
	
		#region Private Members
		private TsCAeServer mServer_ = null;
		#endregion
		
		#region Public Interface
		/// <summary>
		/// Displays the available attributes in a heirarchy. 
		/// </summary>
		public void ShowAttributes(TsCAeServer server)
		{
			mServer_ = server;

			attributesTv_.Nodes.Clear();

			// nothing more to do if no server provided.
			if (mServer_ == null)
			{
				return;
			}

			// display all event categories
			ShowEventCategories(attributesTv_.Nodes, TsCAeEventType.Simple);
			ShowEventCategories(attributesTv_.Nodes, TsCAeEventType.Tracking);
			ShowEventCategories(attributesTv_.Nodes, TsCAeEventType.Condition);
		}

		/// <summary>
		/// Returns currently selected attributes
		/// </summary>
		public Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary GetSelectedAttributes()
		{
			Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary attributes = new Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary();

			foreach (TreeNode child in attributesTv_.Nodes)
			{
				GetSelectedCategories(child, attributes);
			}

			return attributes;
		}

		/// <summary>
		/// Sets the currently selected attributes.
		/// </summary>
		public void SetSelectedAttributes(Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary attributes)
		{
			foreach (TreeNode child in attributesTv_.Nodes)
			{
				SetSelectedCategories(child, attributes);
			}
		}

		/// <summary>
		/// Checks or unchecks all attributes for the specified category id.
		/// </summary>
		public void SelectCategory(int categoryId, bool picked)
		{
			foreach (TreeNode child in attributesTv_.Nodes)
			{
				SelectCategory(child, categoryId, picked);
			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Checks or unchecks all attributes for the specified category id.
		/// </summary>
		public void SelectCategory(TreeNode parent, int categoryId, bool picked)
		{
			foreach (TreeNode child in parent.Nodes)
			{
				if (!typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeCategory).IsInstanceOfType(child.Tag))
				{
					continue;
				}

				// find the matching category id.
				Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category = (Technosoftware.DaAeHdaClient.Ae.TsCAeCategory)child.Tag;

				if (categoryId == category.ID)
				{
					// ensure node is visible if state changes.
					if (child.Checked != picked)
					{				
						// fetch attributes if a dummy mode exists.
						if (child.Nodes.Count == 1 && child.Nodes[0].Text.Length == 0)
						{
							child.Nodes.Clear();
							ShowEventAttributes(child.Nodes, category);
						}

						child.EnsureVisible();
					}

					if (picked)
					{
						child.Checked = true;
					}
					else
					{
						child.Checked = false;
					}
				}			
			}
		}

		/// <summary>
		/// Adds categories with selected attributes to dictionary.
		/// </summary>
		private void GetSelectedCategories(TreeNode parent, Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary attributes)
		{
			foreach (TreeNode child in parent.Nodes)
			{
				if (!typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeCategory).IsInstanceOfType(child.Tag))
				{
					continue;
				}

				GetSelectedAttributes(child, (Technosoftware.DaAeHdaClient.Ae.TsCAeCategory)child.Tag, attributes);
			}
        }

		/// <summary>
		/// Adds selected attributes to the dictionary.
		/// </summary>
		private void GetSelectedAttributes(TreeNode parent, Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category, Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary attributes)
		{
			foreach (TreeNode child in parent.Nodes)
			{
				if (!typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute).IsInstanceOfType(child.Tag))
				{
					continue;
				}

				if (child.Checked)
				{
					Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeCollection collection = attributes[category.ID];

					if (collection == null)
					{
						attributes.Add(category.ID, null);
						collection = attributes[category.ID];
					}
				
					collection.Add(((Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute)child.Tag).ID);
				}
			}
		}

		/// <summary>
		/// Updates categories with selected attributes to dictionary.
		/// </summary>
		private void SetSelectedCategories(TreeNode parent, Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary attributes)
		{
			foreach (TreeNode child in parent.Nodes)
			{
				if (!typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeCategory).IsInstanceOfType(child.Tag))
				{
					continue;
				}

				// check if category exists.
				Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category = (Technosoftware.DaAeHdaClient.Ae.TsCAeCategory)child.Tag;

				if (!attributes.Contains(category.ID))
				{
					child.Checked = false;
					continue;
				}

				// check if attributes need to be fetched.
				if (child.Nodes.Count == 1 && child.Nodes[0].Text.Length == 0)
				{
					child.Nodes.Clear();
					ShowEventAttributes(child.Nodes, category);
				}

				// update individual attributes.
				SetSelectedAttributes(child, category, attributes);
			}
		}

		/// <summary>
		/// Updates the selected attributes to the dictionary.
		/// </summary>
		private void SetSelectedAttributes(TreeNode parent, Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category, Technosoftware.DaAeHdaClient.Ae.TsCAeAttributeDictionary attributes)
		{
			foreach (TreeNode child in parent.Nodes)
			{
				if (!typeof(TsCAeAttribute).IsInstanceOfType(child.Tag))
				{
					continue;
				}
				
				Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute attribute = (Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute)child.Tag;

				if (attributes[category.ID].Contains(attribute.ID))
				{
					child.Checked = true;
				}
				else
				{
					child.Checked = false;
				}
			}
		}

		/// <summary>
		/// Populates the tree with the event categories supported by the server.
		/// </summary>
		private void ShowEventCategories(TreeNodeCollection nodes, TsCAeEventType eventType)
		{
			Technosoftware.DaAeHdaClient.Ae.TsCAeCategory[] categories = null;

			// fetch categories.
			try
			{
				categories = mServer_.QueryEventCategories((int)eventType);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return;
			}

			// check for trivial case.
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
                node.Nodes.Add(new TreeNode());

				// add to tree.
				root.Nodes.Add(node);
			}
		}

		/// <summary>
		/// Populates the tree with the event attributes supported by the category.
		/// </summary>
		private void ShowEventAttributes(TreeNodeCollection nodes, Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category)
		{
			Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute[] attributes = null;

			// fetch attributes.
			try
			{
				attributes = mServer_.QueryEventAttributes(category.ID);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return;
			}

			// add attributes to tree.
			foreach (Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute attribute in attributes)
			{
                // create node.
                TreeNode node = new TreeNode(attribute.Name)
                {
                    ImageIndex = Resources.IMAGE_EXPLODING_BOX,
                    SelectedImageIndex = Resources.IMAGE_EXPLODING_BOX,
                    Tag = attribute
                };

                // add to tree.
                nodes.Add(node);
			}
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Fetches the child nodes before expanding a node.
		/// </summary>
		private void AttributesTV_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			try
			{
				// check if a dummy node is present.
				if (e.Node.Nodes.Count != 1 || e.Node.Nodes[0].Text.Length != 0)
				{
					return;
				}

				// check for category.
				if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeCategory).IsInstanceOfType(e.Node.Tag))
				{
					e.Node.Nodes.Clear();
					ShowEventAttributes(e.Node.Nodes, (Technosoftware.DaAeHdaClient.Ae.TsCAeCategory)e.Node.Tag);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Changes the check state of all children to match the parent that was checked.
		/// </summary>
		private void AttributesTV_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				// check for event type.
				if (typeof(TsCAeEventType).IsInstanceOfType(e.Node.Tag))
				{
					// check all attributes.
					foreach (TreeNode child in e.Node.Nodes)
					{
						child.Checked = e.Node.Checked;
					}

					// ensure changes are visible.
					e.Node.ExpandAll();
				}
			
					// check for category.
				else if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeCategory).IsInstanceOfType(e.Node.Tag))
				{					
					// fetch the attributes if necessary.
					if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text.Length != 0)
					{
						e.Node.Nodes.Clear();
						ShowEventAttributes(e.Node.Nodes, (Technosoftware.DaAeHdaClient.Ae.TsCAeCategory)e.Node.Tag);
					}

					// check if any attributes are already checked.
					bool checkall = true;

					foreach (TreeNode child in e.Node.Nodes)
					{
						if (child.Checked)
						{
							checkall = false;
						}
					}

					// check all attributes.
					if (checkall || !e.Node.Checked)
					{
						foreach (TreeNode child in e.Node.Nodes)
						{
							child.Checked = e.Node.Checked;
						}
					}

					// ensure changes are visible.
					e.Node.ExpandAll();
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
  
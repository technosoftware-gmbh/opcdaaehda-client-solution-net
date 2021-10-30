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
    public class ConditionsViewDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.TreeView conditionsTv_;
		private System.Windows.Forms.Panel leftPn_;
		private System.Windows.Forms.Splitter splitter01_;
		private System.Windows.Forms.Panel rightPn_;
		private Technosoftware.AeSampleClient.ConditionStateCtrl conditionCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ConditionsViewDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			conditionsTv_.ImageList = Resources.Instance.ImageList;
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
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.conditionsTv_ = new System.Windows.Forms.TreeView();
			this.leftPn_ = new System.Windows.Forms.Panel();
			this.splitter01_ = new System.Windows.Forms.Splitter();
			this.rightPn_ = new System.Windows.Forms.Panel();
			this.conditionCtrl_ = new Technosoftware.AeSampleClient.ConditionStateCtrl();
			this.buttonsPn_.SuspendLayout();
			this.leftPn_.SuspendLayout();
			this.rightPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 458);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(712, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(319, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Close";
			// 
			// ConditionsTV
			// 
			this.conditionsTv_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.conditionsTv_.ImageIndex = -1;
			this.conditionsTv_.Location = new System.Drawing.Point(4, 4);
			this.conditionsTv_.Name = "conditionsTv_";
			this.conditionsTv_.SelectedImageIndex = -1;
			this.conditionsTv_.ShowRootLines = false;
			this.conditionsTv_.Size = new System.Drawing.Size(192, 454);
			this.conditionsTv_.TabIndex = 1;
			this.conditionsTv_.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ConditionsTV_AfterSelect);
			// 
			// LeftPN
			// 
			this.leftPn_.Controls.Add(this.conditionsTv_);
			this.leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftPn_.DockPadding.Left = 4;
			this.leftPn_.DockPadding.Right = 4;
			this.leftPn_.DockPadding.Top = 4;
			this.leftPn_.Location = new System.Drawing.Point(0, 0);
			this.leftPn_.Name = "leftPn_";
			this.leftPn_.Size = new System.Drawing.Size(200, 458);
			this.leftPn_.TabIndex = 2;
			// 
			// Splitter01
			// 
			this.splitter01_.Location = new System.Drawing.Point(200, 0);
			this.splitter01_.Name = "splitter01_";
			this.splitter01_.Size = new System.Drawing.Size(3, 458);
			this.splitter01_.TabIndex = 3;
			this.splitter01_.TabStop = false;
			// 
			// RightPN
			// 
			this.rightPn_.Controls.Add(this.conditionCtrl_);
			this.rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPn_.DockPadding.Right = 4;
			this.rightPn_.DockPadding.Top = 4;
			this.rightPn_.Location = new System.Drawing.Point(203, 0);
			this.rightPn_.Name = "rightPn_";
			this.rightPn_.Size = new System.Drawing.Size(509, 458);
			this.rightPn_.TabIndex = 4;
			// 
			// ConditionCTRL
			// 
			this.conditionCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.conditionCtrl_.Location = new System.Drawing.Point(0, 4);
			this.conditionCtrl_.Name = "conditionCtrl_";
			this.conditionCtrl_.Size = new System.Drawing.Size(505, 454);
			this.conditionCtrl_.TabIndex = 0;
			// 
			// ConditionsViewDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(712, 494);
			this.Controls.Add(this.rightPn_);
			this.Controls.Add(this.splitter01_);
			this.Controls.Add(this.leftPn_);
			this.Controls.Add(this.buttonsPn_);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(0, 180);
			this.Name = "ConditionsViewDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Event Conditions";
			this.buttonsPn_.ResumeLayout(false);
			this.leftPn_.ResumeLayout(false);
			this.rightPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the event conditions supported by the server.
		/// </summary>
		public void ShowDialog(TsCAeServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			// clear tree view.
			conditionsTv_.Nodes.Clear();	

			// fetch and populate conditions and sub-conditions.
			try
			{
				TreeNode root = new TreeNode("Categories");

				root.ImageIndex         = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
				root.SelectedImageIndex = Resources.IMAGE_OPEN_YELLOW_FOLDER;

				conditionsTv_.Nodes.Add(root);
				root.Expand();

				// add categories.
				Technosoftware.DaAeHdaClient.Ae.TsCAeCategory[] categories = server.QueryEventCategories((int)TsCAeEventType.Condition);
			
				foreach (Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category in categories)
				{
					TreeNode node = new TreeNode(category.Name);

					node.ImageIndex         = Resources.IMAGE_LIST_BOX;
					node.SelectedImageIndex = Resources.IMAGE_LIST_BOX;
					node.Tag                = category;

					// add conditions.
					TreeNode folder = new TreeNode("Conditions");

					folder.ImageIndex         = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
					folder.SelectedImageIndex = Resources.IMAGE_OPEN_YELLOW_FOLDER;

					node.Nodes.Add(folder);

					FetchConditions(folder, server, category.ID);

					// add attributes.
					folder = new TreeNode("Attributes");

					folder.ImageIndex         = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
					folder.SelectedImageIndex = Resources.IMAGE_OPEN_YELLOW_FOLDER;

					node.Nodes.Add(folder);

					FetchAttributes(folder, server, category.ID);

					// add category to tree.
					root.Nodes.Add(node);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}

			// show dialog.
			ShowDialog();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Populates the tree view with the conditions.
		/// </summary>
		private void FetchConditions(TreeNode parent, TsCAeServer server, int categoryId)
		{
			string[] conditions = server.QueryConditionNames(categoryId);
            
			for (int ii = 0; ii < conditions.Length; ii++)
			{
				TreeNode node = new TreeNode(conditions[ii]);
				
				node.ImageIndex         = Resources.IMAGE_YELLOW_SCROLL;
				node.SelectedImageIndex = Resources.IMAGE_YELLOW_SCROLL;
				node.Tag                = conditions[ii];

				// add sub-conditions.
				FetchSubConditions(node, server, conditions[ii]);

				parent.Nodes.Add(node);
			}
		}

		/// <summary>
		/// Populates the tree view with the attributes.
		/// </summary>
		private void FetchAttributes(TreeNode parent, TsCAeServer server, int categoryId)
		{
			Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute[] attributes = server.QueryEventAttributes(categoryId);
            
			foreach (Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute attribute in attributes)
			{
				string label = String.Format(
					"[{0}] {1} ({2})", 
					attribute.ID, 
					attribute.Name, 
					Technosoftware.DaAeHdaClient.OpcConvert.ToString(attribute.DataType));

				TreeNode node = new TreeNode(label);
				
				node.ImageIndex         = Resources.IMAGE_EXPLODING_BOX;
				node.SelectedImageIndex = Resources.IMAGE_EXPLODING_BOX;
				node.Tag                = attribute;

				parent.Nodes.Add(node);
			}
		}

		/// <summary>
		/// Populates the tree view with the sub-conditions.
		/// </summary>
		private void FetchSubConditions(TreeNode parent, TsCAeServer server, string conditionName)
		{
			string[] subconditions = server.QuerySubConditionNames(conditionName);
            
			for (int ii = 0; ii < subconditions.Length; ii++)
			{
				TreeNode node = new TreeNode(subconditions[ii]);

				node.ImageIndex         = Resources.IMAGE_YELLOW_SCROLL;
				node.SelectedImageIndex = Resources.IMAGE_YELLOW_SCROLL;
				node.Tag                = subconditions[ii];

				parent.Nodes.Add(node);
			}
		}
		#endregion

		#region Event Handlers
		private void ConditionsTV_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion
	}
}

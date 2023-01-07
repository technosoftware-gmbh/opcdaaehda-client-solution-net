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
			buttonsPn_ = new System.Windows.Forms.Panel();
			cancelBtn_ = new System.Windows.Forms.Button();
			conditionsTv_ = new System.Windows.Forms.TreeView();
			leftPn_ = new System.Windows.Forms.Panel();
			splitter01_ = new System.Windows.Forms.Splitter();
			rightPn_ = new System.Windows.Forms.Panel();
			conditionCtrl_ = new Technosoftware.AeSampleClient.ConditionStateCtrl();
			buttonsPn_.SuspendLayout();
			leftPn_.SuspendLayout();
			rightPn_.SuspendLayout();
			SuspendLayout();
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 458);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(712, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(319, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Close";
			// 
			// ConditionsTV
			// 
			conditionsTv_.Dock = System.Windows.Forms.DockStyle.Fill;
			conditionsTv_.ImageIndex = -1;
			conditionsTv_.Location = new System.Drawing.Point(4, 4);
			conditionsTv_.Name = "conditionsTv_";
			conditionsTv_.SelectedImageIndex = -1;
			conditionsTv_.ShowRootLines = false;
			conditionsTv_.Size = new System.Drawing.Size(192, 454);
			conditionsTv_.TabIndex = 1;
			conditionsTv_.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(ConditionsTV_AfterSelect);
			// 
			// LeftPN
			// 
			leftPn_.Controls.Add(conditionsTv_);
			leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			leftPn_.DockPadding.Left = 4;
			leftPn_.DockPadding.Right = 4;
			leftPn_.DockPadding.Top = 4;
			leftPn_.Location = new System.Drawing.Point(0, 0);
			leftPn_.Name = "leftPn_";
			leftPn_.Size = new System.Drawing.Size(200, 458);
			leftPn_.TabIndex = 2;
			// 
			// Splitter01
			// 
			splitter01_.Location = new System.Drawing.Point(200, 0);
			splitter01_.Name = "splitter01_";
			splitter01_.Size = new System.Drawing.Size(3, 458);
			splitter01_.TabIndex = 3;
			splitter01_.TabStop = false;
			// 
			// RightPN
			// 
			rightPn_.Controls.Add(conditionCtrl_);
			rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			rightPn_.DockPadding.Right = 4;
			rightPn_.DockPadding.Top = 4;
			rightPn_.Location = new System.Drawing.Point(203, 0);
			rightPn_.Name = "rightPn_";
			rightPn_.Size = new System.Drawing.Size(509, 458);
			rightPn_.TabIndex = 4;
			// 
			// ConditionCTRL
			// 
			conditionCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			conditionCtrl_.Location = new System.Drawing.Point(0, 4);
			conditionCtrl_.Name = "conditionCtrl_";
			conditionCtrl_.Size = new System.Drawing.Size(505, 454);
			conditionCtrl_.TabIndex = 0;
			// 
			// ConditionsViewDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = cancelBtn_;
			ClientSize = new System.Drawing.Size(712, 494);
			Controls.Add(rightPn_);
			Controls.Add(splitter01_);
			Controls.Add(leftPn_);
			Controls.Add(buttonsPn_);
			MaximizeBox = false;
			MinimumSize = new System.Drawing.Size(0, 180);
			Name = "ConditionsViewDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Event Conditions";
			buttonsPn_.ResumeLayout(false);
			leftPn_.ResumeLayout(false);
			rightPn_.ResumeLayout(false);
			ResumeLayout(false);

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
                TreeNode root = new TreeNode("Categories")
                {
                    ImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER,
                    SelectedImageIndex = Resources.IMAGE_OPEN_YELLOW_FOLDER
                };

                conditionsTv_.Nodes.Add(root);
				root.Expand();

				// add categories.
				Technosoftware.DaAeHdaClient.Ae.TsCAeCategory[] categories = server.QueryEventCategories((int)TsCAeEventType.Condition);
			
				foreach (Technosoftware.DaAeHdaClient.Ae.TsCAeCategory category in categories)
				{
                    TreeNode node = new TreeNode(category.Name)
                    {
                        ImageIndex = Resources.IMAGE_LIST_BOX,
                        SelectedImageIndex = Resources.IMAGE_LIST_BOX,
                        Tag = category
                    };

                    // add conditions.
                    TreeNode folder = new TreeNode("Conditions")
                    {
                        ImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER,
                        SelectedImageIndex = Resources.IMAGE_OPEN_YELLOW_FOLDER
                    };

                    node.Nodes.Add(folder);

					FetchConditions(folder, server, category.ID);

                    // add attributes.
                    folder = new TreeNode("Attributes")
                    {
                        ImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER,
                        SelectedImageIndex = Resources.IMAGE_OPEN_YELLOW_FOLDER
                    };

                    node.Nodes.Add(folder);

					FetchAttributes(folder, server, category.ID);

					// add category to tree.
					root.Nodes.Add(node);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, Text);
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
                TreeNode node = new TreeNode(conditions[ii])
                {
                    ImageIndex = Resources.IMAGE_YELLOW_SCROLL,
                    SelectedImageIndex = Resources.IMAGE_YELLOW_SCROLL,
                    Tag = conditions[ii]
                };

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

                TreeNode node = new TreeNode(label)
                {
                    ImageIndex = Resources.IMAGE_EXPLODING_BOX,
                    SelectedImageIndex = Resources.IMAGE_EXPLODING_BOX,
                    Tag = attribute
                };

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
                TreeNode node = new TreeNode(subconditions[ii])
                {
                    ImageIndex = Resources.IMAGE_YELLOW_SCROLL,
                    SelectedImageIndex = Resources.IMAGE_YELLOW_SCROLL,
                    Tag = subconditions[ii]
                };

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

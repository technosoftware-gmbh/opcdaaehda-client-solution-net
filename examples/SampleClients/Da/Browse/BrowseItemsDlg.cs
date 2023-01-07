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

using Technosoftware.DaAeHdaClient;
using SampleClients.Common;
using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da.Browse
{
    /// <summary>
    /// A dialog used to browse the address space of an OPC DA server.
    /// </summary>
    public class BrowseItemsDlg : System.Windows.Forms.Form
	{
		private BrowseTreeCtrl browseCtrl_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button doneBtn_;
		private System.Windows.Forms.Panel leftPn_;
		private System.Windows.Forms.Panel rightPn_;
		private System.Windows.Forms.Splitter splitterV_;
		private PropertyListViewCtrl propertiesCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public BrowseItemsDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            

			browseCtrl_.ElementSelected += new ElementSelectedEventHandler(OnElementSelected);
			browseCtrl_.ItemPicked += new ItemPickedEventHandler(BrowseCTRL_ItemPicked);
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
			browseCtrl_ = new BrowseTreeCtrl();
			leftPn_ = new System.Windows.Forms.Panel();
			rightPn_ = new System.Windows.Forms.Panel();
			propertiesCtrl_ = new PropertyListViewCtrl();
			buttonsPn_ = new System.Windows.Forms.Panel();
			doneBtn_ = new System.Windows.Forms.Button();
			splitterV_ = new System.Windows.Forms.Splitter();
			leftPn_.SuspendLayout();
			rightPn_.SuspendLayout();
			buttonsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// BrowseCTRL
			// 
			browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			browseCtrl_.Location = new System.Drawing.Point(4, 4);
			browseCtrl_.Name = "browseCtrl_";
			browseCtrl_.Size = new System.Drawing.Size(220, 296);
			browseCtrl_.TabIndex = 1;
			// 
			// LeftPN
			// 
			leftPn_.Controls.Add(browseCtrl_);
			leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			leftPn_.DockPadding.Left = 4;
			leftPn_.DockPadding.Top = 4;
			leftPn_.Location = new System.Drawing.Point(0, 0);
			leftPn_.Name = "leftPn_";
			leftPn_.Size = new System.Drawing.Size(224, 300);
			leftPn_.TabIndex = 6;
			// 
			// RightPN
			// 
			rightPn_.Controls.Add(propertiesCtrl_);
			rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			rightPn_.DockPadding.Right = 4;
			rightPn_.DockPadding.Top = 4;
			rightPn_.Location = new System.Drawing.Point(228, 0);
			rightPn_.Name = "rightPn_";
			rightPn_.Size = new System.Drawing.Size(564, 300);
			rightPn_.TabIndex = 8;
			// 
			// PropertiesCTRL
			// 
			propertiesCtrl_.AllowDrop = true;
			propertiesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			propertiesCtrl_.Location = new System.Drawing.Point(0, 4);
			propertiesCtrl_.Name = "propertiesCtrl_";
			propertiesCtrl_.Size = new System.Drawing.Size(560, 296);
			propertiesCtrl_.TabIndex = 0;
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(doneBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 300);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(792, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// DoneBTN
			// 
			doneBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			doneBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			doneBtn_.Location = new System.Drawing.Point(359, 8);
			doneBtn_.Name = "doneBtn_";
			doneBtn_.TabIndex = 0;
			doneBtn_.Text = "Done";
			doneBtn_.Click += new System.EventHandler(DoneBTN_Click);
			// 
			// SplitterV
			// 
			splitterV_.Location = new System.Drawing.Point(224, 0);
			splitterV_.Name = "splitterV_";
			splitterV_.Size = new System.Drawing.Size(4, 300);
			splitterV_.TabIndex = 9;
			splitterV_.TabStop = false;
			// 
			// BrowseItemsDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(792, 336);
			Controls.Add(rightPn_);
			Controls.Add(splitterV_);
			Controls.Add(leftPn_);
			Controls.Add(buttonsPn_);
			Name = "BrowseItemsDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Browse Address Space";
			leftPn_.ResumeLayout(false);
			rightPn_.ResumeLayout(false);
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The server used to process read request.
		/// </summary>
		private TsCDaServer mServer_ = null;

		private OpcItem mItemId_ = null;

		/// <summary>
		/// Displays the address space for the specified server.
		/// </summary>
		public OpcItem ShowDialog(TsCDaServer server)
		{
			try
			{
				if (server == null) throw new ArgumentNullException("server");

				mServer_ = server;
				mItemId_ = null;

				TsCDaBrowseFilters filters = new TsCDaBrowseFilters();

				filters.ReturnAllProperties  = false;
				filters.ReturnPropertyValues = false;

				browseCtrl_.ShowSingleServer(mServer_, filters);
				propertiesCtrl_.Initialize(null);

				if (ShowDialog() != DialogResult.OK)
				{
					return null;
				}

				return mItemId_;
			}
			finally
			{
				// ensure server connection in the browse control are closed.
				browseCtrl_.Clear();
			}
		}

		/// <summary>
		/// Displays the address space for the specified server.
		/// </summary>
		public void Initialize(Technosoftware.DaAeHdaClient.Da.TsCDaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;

			TsCDaBrowseFilters filters = new TsCDaBrowseFilters();

			filters.ReturnAllProperties  = true;
			filters.ReturnPropertyValues = true;

			browseCtrl_.ShowSingleServer(mServer_, filters);
			propertiesCtrl_.Initialize(null);

			ShowDialog();

			// ensure server connection in the browse control are closed.
			browseCtrl_.Clear();
		}
		
		/// <summary>
		/// Called when a server is picked in the browse control.
		/// </summary>
		private void OnElementSelected(TsCDaBrowseElement element)
		{
			propertiesCtrl_.Initialize(element);
		}
		
		/// <summary>
		/// Called when the close button is clicked.
		/// </summary>
		private void DoneBTN_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Called when an item is explicitly picked.
		/// </summary>
		private void BrowseCTRL_ItemPicked(OpcItem itemId)
		{
			mItemId_ = itemId;
			DialogResult = DialogResult.OK;
		}
	}
}

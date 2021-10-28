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
            Icon = ClientUtils.GetAppIcon();

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
			this.browseCtrl_ = new BrowseTreeCtrl();
			this.leftPn_ = new System.Windows.Forms.Panel();
			this.rightPn_ = new System.Windows.Forms.Panel();
			this.propertiesCtrl_ = new PropertyListViewCtrl();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.doneBtn_ = new System.Windows.Forms.Button();
			this.splitterV_ = new System.Windows.Forms.Splitter();
			this.leftPn_.SuspendLayout();
			this.rightPn_.SuspendLayout();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// BrowseCTRL
			// 
			this.browseCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browseCtrl_.Location = new System.Drawing.Point(4, 4);
			this.browseCtrl_.Name = "browseCtrl_";
			this.browseCtrl_.Size = new System.Drawing.Size(220, 296);
			this.browseCtrl_.TabIndex = 1;
			// 
			// LeftPN
			// 
			this.leftPn_.Controls.Add(this.browseCtrl_);
			this.leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftPn_.DockPadding.Left = 4;
			this.leftPn_.DockPadding.Top = 4;
			this.leftPn_.Location = new System.Drawing.Point(0, 0);
			this.leftPn_.Name = "leftPn_";
			this.leftPn_.Size = new System.Drawing.Size(224, 300);
			this.leftPn_.TabIndex = 6;
			// 
			// RightPN
			// 
			this.rightPn_.Controls.Add(this.propertiesCtrl_);
			this.rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPn_.DockPadding.Right = 4;
			this.rightPn_.DockPadding.Top = 4;
			this.rightPn_.Location = new System.Drawing.Point(228, 0);
			this.rightPn_.Name = "rightPn_";
			this.rightPn_.Size = new System.Drawing.Size(564, 300);
			this.rightPn_.TabIndex = 8;
			// 
			// PropertiesCTRL
			// 
			this.propertiesCtrl_.AllowDrop = true;
			this.propertiesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertiesCtrl_.Location = new System.Drawing.Point(0, 4);
			this.propertiesCtrl_.Name = "propertiesCtrl_";
			this.propertiesCtrl_.Size = new System.Drawing.Size(560, 296);
			this.propertiesCtrl_.TabIndex = 0;
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.doneBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 300);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(792, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// DoneBTN
			// 
			this.doneBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.doneBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.doneBtn_.Location = new System.Drawing.Point(359, 8);
			this.doneBtn_.Name = "doneBtn_";
			this.doneBtn_.TabIndex = 0;
			this.doneBtn_.Text = "Done";
			this.doneBtn_.Click += new System.EventHandler(this.DoneBTN_Click);
			// 
			// SplitterV
			// 
			this.splitterV_.Location = new System.Drawing.Point(224, 0);
			this.splitterV_.Name = "splitterV_";
			this.splitterV_.Size = new System.Drawing.Size(4, 300);
			this.splitterV_.TabIndex = 9;
			this.splitterV_.TabStop = false;
			// 
			// BrowseItemsDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 336);
			this.Controls.Add(this.rightPn_);
			this.Controls.Add(this.splitterV_);
			this.Controls.Add(this.leftPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "BrowseItemsDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Browse Address Space";
			this.leftPn_.ResumeLayout(false);
			this.rightPn_.ResumeLayout(false);
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

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

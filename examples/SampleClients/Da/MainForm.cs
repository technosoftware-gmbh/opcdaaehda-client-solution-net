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
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

using SampleClients.Da.Server;
using SampleClients.Da.Subscription;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Da;
using Technosoftware.DaAeHdaClient.Cpx;
using SampleClients.Common;
#endregion

namespace SampleClients.Da
{
    /// <summary>
    /// The main application window for the OPC DA Sample Application.
    /// </summary>
    public class MainForm : Form
	{
		private MenuStrip mainMenu_;
		private ToolStripMenuItem fileMi_;
		private ToolStrip toolBar_;
		private Panel bottomPn_;
		private RichTextBox outputCtrl_;
		private Splitter splitterH_;
		private Splitter splitterV_;
		private Panel leftPn_;
		private Panel rightPn_;
		private SelectServerCtrl selectServerCtrl_;
		private SubscriptionsTreeCtrl subscriptionCtrl_;
		private ServerStatusCtrl statusCtrl_;
		private UpdatesListViewCtrl updatesCtrl_;
		private ToolStripMenuItem exitMi_;
		private ToolStripMenuItem serverMi_;
		private ToolStripMenuItem connectMi_;
		private ToolStripMenuItem disconnecMi_;
		private ToolStripMenuItem viewStatusMi_;
		private ToolStripMenuItem browseMi_;
		private ToolStripMenuItem readMi_;
		private ToolStripMenuItem writeMi_;
		private ToolStripMenuItem separatorS1_;
		private ToolStripMenuItem separatorS2_;
		private ToolStripMenuItem helpMi_;
		private ToolStripMenuItem aboutMi_;
		private ImageList toolBarImageList_;
		private ToolStripButton connectBtn_;
		private ToolStripButton disconnectBtn_;
		private ToolStripButton viewStatusBtn_;
		private ToolStripButton browseBtn_;
		private ToolStripButton readBtn_;
		private ToolStripButton writeBtn_;
		private ToolStripButton aboutBtn_;
		private ToolStripMenuItem outputMi_;
		private ToolStripMenuItem outputClearMi_;
		private ToolStripMenuItem optionsMi_;
		private ToolStripMenuItem clearHistoryMi_;
		private ToolStripMenuItem menuItem1_;
		private System.ComponentModel.IContainer components;
        private ToolStripMenuItem forceDa20UsageMenuItem_;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Timer updateTimerControl_;
		
		[STAThread]
		static void Main() 
		{
            try
			{
                //ApplicationInstance.InitializeSecurity(ApplicationInstance.AuthenticationLevel.Integrity);
                ApplicationInstance.EnableTrace(ApplicationInstance.GetLogFileDirectory(), "SampleClients.Da.log");

                Application.Run(new MainForm());
			}
			catch (Exception e)
			{
                MessageBox.Show("An unexpected exception occurred. Application exiting.\r\n\r\n" + e.Message, "OPC DA Sample Client");
			}
		}

        private MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
 
            
            
			// connect the updates control to the subscriptions control.
			subscriptionCtrl_.SubscriptionModified += new SubscriptionModifiedCallback(updatesCtrl_.OnSubscriptionModified);

			// register for trace/debug output from the updates control.
			updatesCtrl_.UpdateEvent += new UpdateEventEventHandler(OnUpdateEvent);	
			
#if (DEBUG)

			// initialize the set of known servers.
			OpcUrl[] knownUrls = new OpcUrl[] 
			{
				new OpcUrl("opcda://localhost/SampleCompany.DaSample"),
			};

#else
			// initialize the set of known servers.
			OpcUrl[] knownUrls = new OpcUrl[] 
			{
				new OpcUrl("opcda://localhost/SampleCompany.DaSample"),
			};
#endif

            selectServerCtrl_.Initialize(knownUrls, 0, OpcSpecification.OPC_DA_20);
			
			// register for server connected callbacks.
			selectServerCtrl_.ConnectServer += OnConnect; 
            UpdateTitle();
            updateTimerControl_.Enabled = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu_ = new System.Windows.Forms.MenuStrip();
            this.fileMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.serverMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.connectMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnecMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorS1_ = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStatusMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.browseMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorS2_ = new System.Windows.Forms.ToolStripMenuItem();
            this.readMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.writeMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem1_ = new System.Windows.Forms.ToolStripMenuItem();
            this.outputMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.outputClearMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.forceDa20UsageMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBar_ = new System.Windows.Forms.ToolStrip();
            this.toolBarImageList_ = new System.Windows.Forms.ImageList(this.components);
            this.connectBtn_ = new System.Windows.Forms.ToolStripButton();
            this.disconnectBtn_ = new System.Windows.Forms.ToolStripButton();
            this.viewStatusBtn_ = new System.Windows.Forms.ToolStripButton();
            this.browseBtn_ = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.readBtn_ = new System.Windows.Forms.ToolStripButton();
            this.writeBtn_ = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutBtn_ = new System.Windows.Forms.ToolStripButton();
            this.bottomPn_ = new System.Windows.Forms.Panel();
            this.outputCtrl_ = new System.Windows.Forms.RichTextBox();
            this.splitterH_ = new System.Windows.Forms.Splitter();
            this.splitterV_ = new System.Windows.Forms.Splitter();
            this.leftPn_ = new System.Windows.Forms.Panel();
            this.subscriptionCtrl_ = new SampleClients.Da.Subscription.SubscriptionsTreeCtrl();
            this.rightPn_ = new System.Windows.Forms.Panel();
            this.updatesCtrl_ = new SampleClients.Da.UpdatesListViewCtrl();
            this.updateTimerControl_ = new System.Windows.Forms.Timer(this.components);
            this.statusCtrl_ = new SampleClients.Da.Server.ServerStatusCtrl();
            this.selectServerCtrl_ = new SampleClients.Common.SelectServerCtrl();
            this.mainMenu_.SuspendLayout();
            this.toolBar_.SuspendLayout();
            this.bottomPn_.SuspendLayout();
            this.leftPn_.SuspendLayout();
            this.rightPn_.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu_
            // 
            this.mainMenu_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMi_,
            this.serverMi_,
            this.outputMi_,
            this.optionsMi_,
            this.helpMi_});
            this.mainMenu_.Location = new System.Drawing.Point(0, 0);
            this.mainMenu_.Name = "mainMenu_";
            this.mainMenu_.Size = new System.Drawing.Size(200, 24);
            this.mainMenu_.TabIndex = 0;
            // 
            // fileMi_
            // 
            this.fileMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMi_});
            this.fileMi_.Name = "fileMi_";
            this.fileMi_.Size = new System.Drawing.Size(37, 20);
            this.fileMi_.Text = "&File";
            // 
            // exitMi_
            // 
            this.exitMi_.Name = "exitMi_";
            this.exitMi_.Size = new System.Drawing.Size(93, 22);
            this.exitMi_.Text = "&Exit";
            this.exitMi_.Click += new System.EventHandler(this.ExitMI_Click);
            // 
            // serverMi_
            // 
            this.serverMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectMi_,
            this.disconnecMi_,
            this.separatorS1_,
            this.viewStatusMi_,
            this.browseMi_,
            this.separatorS2_,
            this.readMi_,
            this.writeMi_,
            this.menuItem1_});
            this.serverMi_.Name = "serverMi_";
            this.serverMi_.Size = new System.Drawing.Size(51, 20);
            this.serverMi_.Text = "&Server";
            // 
            // connectMi_
            // 
            this.connectMi_.Name = "connectMi_";
            this.connectMi_.Size = new System.Drawing.Size(134, 22);
            this.connectMi_.Text = "&Connect";
            this.connectMi_.Click += new System.EventHandler(this.ConnectMI_Click);
            // 
            // disconnecMi_
            // 
            this.disconnecMi_.Name = "disconnecMi_";
            this.disconnecMi_.Size = new System.Drawing.Size(134, 22);
            this.disconnecMi_.Text = "&Disconnect";
            this.disconnecMi_.Click += new System.EventHandler(this.DisconnectMI_Click);
            // 
            // separatorS1_
            // 
            this.separatorS1_.Name = "separatorS1_";
            this.separatorS1_.Size = new System.Drawing.Size(134, 22);
            this.separatorS1_.Text = "-";
            // 
            // viewStatusMi_
            // 
            this.viewStatusMi_.Name = "viewStatusMi_";
            this.viewStatusMi_.Size = new System.Drawing.Size(134, 22);
            this.viewStatusMi_.Text = "&View Status";
            this.viewStatusMi_.Click += new System.EventHandler(this.ViewStatusMI_Click);
            // 
            // browseMi_
            // 
            this.browseMi_.Name = "browseMi_";
            this.browseMi_.Size = new System.Drawing.Size(134, 22);
            this.browseMi_.Text = "&Browse...";
            this.browseMi_.Click += new System.EventHandler(this.BrowseMI_Click);
            // 
            // separatorS2_
            // 
            this.separatorS2_.Name = "separatorS2_";
            this.separatorS2_.Size = new System.Drawing.Size(134, 22);
            this.separatorS2_.Text = "-";
            // 
            // readMi_
            // 
            this.readMi_.Name = "readMi_";
            this.readMi_.Size = new System.Drawing.Size(134, 22);
            this.readMi_.Text = "&Read...";
            this.readMi_.Click += new System.EventHandler(this.ReadMI_Click);
            // 
            // writeMi_
            // 
            this.writeMi_.Name = "writeMi_";
            this.writeMi_.Size = new System.Drawing.Size(134, 22);
            this.writeMi_.Text = "&Write...";
            this.writeMi_.Click += new System.EventHandler(this.WriteMI_Click);
            // 
            // menuItem1_
            // 
            this.menuItem1_.Name = "menuItem1_";
            this.menuItem1_.Size = new System.Drawing.Size(134, 22);
            this.menuItem1_.Text = "-";
            // 
            // outputMi_
            // 
            this.outputMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputClearMi_});
            this.outputMi_.Name = "outputMi_";
            this.outputMi_.Size = new System.Drawing.Size(57, 20);
            this.outputMi_.Text = "&Output";
            // 
            // outputClearMi_
            // 
            this.outputClearMi_.Name = "outputClearMi_";
            this.outputClearMi_.Size = new System.Drawing.Size(101, 22);
            this.outputClearMi_.Text = "&Clear";
            this.outputClearMi_.Click += new System.EventHandler(this.OutputClearMI_Click);
            // 
            // optionsMi_
            // 
            this.optionsMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearHistoryMi_,
            this.forceDa20UsageMenuItem_});
            this.optionsMi_.Name = "optionsMi_";
            this.optionsMi_.Size = new System.Drawing.Size(61, 20);
            this.optionsMi_.Text = "O&ptions";
            // 
            // clearHistoryMi_
            // 
            this.clearHistoryMi_.Name = "clearHistoryMi_";
            this.clearHistoryMi_.Size = new System.Drawing.Size(175, 22);
            this.clearHistoryMi_.Text = "&Clear History";
            this.clearHistoryMi_.Click += new System.EventHandler(this.ClearHistoryMI_Click);
            // 
            // forceDa20UsageMenuItem_
            // 
            this.forceDa20UsageMenuItem_.Name = "forceDa20UsageMenuItem_";
            this.forceDa20UsageMenuItem_.Size = new System.Drawing.Size(175, 22);
            this.forceDa20UsageMenuItem_.Text = "&Force DA 2.0 Usage";
            this.forceDa20UsageMenuItem_.Click += new System.EventHandler(this.OnForceDa20Usage);
            // 
            // helpMi_
            // 
            this.helpMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMi_});
            this.helpMi_.Name = "helpMi_";
            this.helpMi_.Size = new System.Drawing.Size(44, 20);
            this.helpMi_.Text = "&Help";
            // 
            // aboutMi_
            // 
            this.aboutMi_.Name = "aboutMi_";
            this.aboutMi_.Size = new System.Drawing.Size(116, 22);
            this.aboutMi_.Text = "&About...";
            // 
            // toolBar_
            // 
            this.toolBar_.ImageList = this.toolBarImageList_;
            this.toolBar_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectBtn_,
            this.disconnectBtn_,
            this.viewStatusBtn_,
            this.browseBtn_,
            this.toolStripSeparator1,
            this.readBtn_,
            this.writeBtn_,
            this.toolStripSeparator2,
            this.aboutBtn_});
            this.toolBar_.Location = new System.Drawing.Point(3, 0);
            this.toolBar_.Name = "toolBar_";
            this.toolBar_.Size = new System.Drawing.Size(1010, 25);
            this.toolBar_.TabIndex = 0;
            // 
            // toolBarImageList_
            // 
            this.toolBarImageList_.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolBarImageList_.ImageStream")));
            this.toolBarImageList_.TransparentColor = System.Drawing.Color.Teal;
            this.toolBarImageList_.Images.SetKeyName(0, "");
            this.toolBarImageList_.Images.SetKeyName(1, "");
            this.toolBarImageList_.Images.SetKeyName(2, "");
            this.toolBarImageList_.Images.SetKeyName(3, "");
            this.toolBarImageList_.Images.SetKeyName(4, "");
            this.toolBarImageList_.Images.SetKeyName(5, "");
            this.toolBarImageList_.Images.SetKeyName(6, "");
            this.toolBarImageList_.Images.SetKeyName(7, "");
            this.toolBarImageList_.Images.SetKeyName(8, "");
            this.toolBarImageList_.Images.SetKeyName(9, "");
            this.toolBarImageList_.Images.SetKeyName(10, "");
            this.toolBarImageList_.Images.SetKeyName(11, "");
            this.toolBarImageList_.Images.SetKeyName(12, "");
            this.toolBarImageList_.Images.SetKeyName(13, "");
            // 
            // connectBtn_
            // 
            this.connectBtn_.ImageIndex = 0;
            this.connectBtn_.Name = "connectBtn_";
            this.connectBtn_.Size = new System.Drawing.Size(23, 22);
            this.connectBtn_.ToolTipText = "Connect to Server";
            this.connectBtn_.Click += new System.EventHandler(this.ConnectMI_Click);
            // 
            // disconnectBtn_
            // 
            this.disconnectBtn_.ImageIndex = 1;
            this.disconnectBtn_.Name = "disconnectBtn_";
            this.disconnectBtn_.Size = new System.Drawing.Size(23, 22);
            this.disconnectBtn_.ToolTipText = "Disconnect from Server";
            this.disconnectBtn_.Click += new System.EventHandler(this.DisconnectMI_Click);
            // 
            // viewStatusBtn_
            // 
            this.viewStatusBtn_.ImageIndex = 4;
            this.viewStatusBtn_.Name = "viewStatusBtn_";
            this.viewStatusBtn_.Size = new System.Drawing.Size(23, 22);
            this.viewStatusBtn_.ToolTipText = "View Server Status";
            this.viewStatusBtn_.Click += new System.EventHandler(this.ViewStatusMI_Click);
            // 
            // browseBtn_
            // 
            this.browseBtn_.ImageIndex = 6;
            this.browseBtn_.Name = "browseBtn_";
            this.browseBtn_.Size = new System.Drawing.Size(23, 22);
            this.browseBtn_.ToolTipText = "Browse Address Space";
            this.browseBtn_.Click += new System.EventHandler(this.BrowseMI_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // readBtn_
            // 
            this.readBtn_.ImageIndex = 7;
            this.readBtn_.Name = "readBtn_";
            this.readBtn_.Size = new System.Drawing.Size(23, 22);
            this.readBtn_.ToolTipText = "Read Items";
            this.readBtn_.Click += new System.EventHandler(this.ReadMI_Click);
            // 
            // writeBtn_
            // 
            this.writeBtn_.ImageIndex = 8;
            this.writeBtn_.Name = "writeBtn_";
            this.writeBtn_.Size = new System.Drawing.Size(23, 22);
            this.writeBtn_.ToolTipText = "Write Items";
            this.writeBtn_.Click += new System.EventHandler(this.WriteMI_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // aboutBtn_
            // 
            this.aboutBtn_.ImageIndex = 13;
            this.aboutBtn_.Name = "aboutBtn_";
            this.aboutBtn_.Size = new System.Drawing.Size(23, 22);
            this.aboutBtn_.ToolTipText = "About";
            // 
            // bottomPn_
            // 
            this.bottomPn_.Controls.Add(this.outputCtrl_);
            this.bottomPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPn_.Location = new System.Drawing.Point(3, 486);
            this.bottomPn_.Name = "bottomPn_";
            this.bottomPn_.Size = new System.Drawing.Size(1010, 100);
            this.bottomPn_.TabIndex = 3;
            // 
            // outputCtrl_
            // 
            this.outputCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputCtrl_.Location = new System.Drawing.Point(0, 0);
            this.outputCtrl_.Name = "outputCtrl_";
            this.outputCtrl_.Size = new System.Drawing.Size(1010, 100);
            this.outputCtrl_.TabIndex = 0;
            this.outputCtrl_.Text = "";
            // 
            // splitterH_
            // 
            this.splitterH_.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterH_.Location = new System.Drawing.Point(3, 483);
            this.splitterH_.Name = "splitterH_";
            this.splitterH_.Size = new System.Drawing.Size(1010, 3);
            this.splitterH_.TabIndex = 4;
            this.splitterH_.TabStop = false;
            // 
            // splitterV_
            // 
            this.splitterV_.Location = new System.Drawing.Point(267, 47);
            this.splitterV_.Name = "splitterV_";
            this.splitterV_.Size = new System.Drawing.Size(3, 436);
            this.splitterV_.TabIndex = 5;
            this.splitterV_.TabStop = false;
            // 
            // leftPn_
            // 
            this.leftPn_.Controls.Add(this.subscriptionCtrl_);
            this.leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPn_.Location = new System.Drawing.Point(3, 47);
            this.leftPn_.Name = "leftPn_";
            this.leftPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.leftPn_.Size = new System.Drawing.Size(264, 436);
            this.leftPn_.TabIndex = 6;
            // 
            // subscriptionCtrl_
            // 
            this.subscriptionCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subscriptionCtrl_.Location = new System.Drawing.Point(0, 3);
            this.subscriptionCtrl_.Name = "subscriptionCtrl_";
            this.subscriptionCtrl_.Size = new System.Drawing.Size(264, 433);
            this.subscriptionCtrl_.TabIndex = 0;
            // 
            // rightPn_
            // 
            this.rightPn_.Controls.Add(this.updatesCtrl_);
            this.rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPn_.Location = new System.Drawing.Point(270, 47);
            this.rightPn_.Name = "rightPn_";
            this.rightPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.rightPn_.Size = new System.Drawing.Size(743, 436);
            this.rightPn_.TabIndex = 7;
            // 
            // updatesCtrl_
            // 
            this.updatesCtrl_.AllowDrop = true;
            this.updatesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updatesCtrl_.Location = new System.Drawing.Point(0, 3);
            this.updatesCtrl_.Name = "updatesCtrl_";
            this.updatesCtrl_.Size = new System.Drawing.Size(743, 433);
            this.updatesCtrl_.TabIndex = 0;
            // 
            // updateTimerControl_
            // 
            this.updateTimerControl_.Interval = 10000;
            this.updateTimerControl_.Tick += new System.EventHandler(this.UpdateTimerCtrlTick);
            // 
            // statusCtrl_
            // 
            this.statusCtrl_.Location = new System.Drawing.Point(3, 586);
            this.statusCtrl_.Name = "statusCtrl_";
            this.statusCtrl_.Size = new System.Drawing.Size(1010, 22);
            this.statusCtrl_.TabIndex = 8;
            // 
            // selectServerCtrl_
            // 
            this.selectServerCtrl_.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectServerCtrl_.Label = "Server";
            this.selectServerCtrl_.Location = new System.Drawing.Point(3, 25);
            this.selectServerCtrl_.Name = "selectServerCtrl_";
            this.selectServerCtrl_.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selectServerCtrl_.Size = new System.Drawing.Size(1010, 22);
            this.selectServerCtrl_.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 608);
            this.Controls.Add(this.rightPn_);
            this.Controls.Add(this.splitterV_);
            this.Controls.Add(this.leftPn_);
            this.Controls.Add(this.splitterH_);
            this.Controls.Add(this.bottomPn_);
            this.Controls.Add(this.statusCtrl_);
            this.Controls.Add(this.selectServerCtrl_);
            this.Controls.Add(this.toolBar_);
            this.MainMenuStrip = this.mainMenu_;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Text = "OPC DA Sample Client";
            this.mainMenu_.ResumeLayout(false);
            this.mainMenu_.PerformLayout();
            this.toolBar_.ResumeLayout(false);
            this.toolBar_.PerformLayout();
            this.bottomPn_.ResumeLayout(false);
            this.leftPn_.ResumeLayout(false);
            this.rightPn_.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

		/// <summary>
		/// A class that stores the user's application settings.
		/// </summary>
		[Serializable]
		public class UserAppData
		{
			public OpcUrl[]  KnownUrls;
			public int    SelectedUrl = -1;
			public string ProxyServer;
		}

		/// <summary>
		/// A class that DX configuration.
		/// </summary>
		[Serializable]
		public class DxConfiguration
		{
			public TsCDaServer  Target;
		}

		/// <summary>
		/// The application configuration file path.
		/// </summary>
		private string ConfigFilePath => Application.StartupPath + "\\SampleClients.Da.config";

        /// <summary>
		/// The default web proxy for the application - uses IE settings if null.
		/// </summary>
		private WebProxy mProxy_;

		/// <summary>
		/// The currently active server object.
		/// </summary>
		private TsCDaServer server_;

	    private bool forceDa20Usage_;

		/// <summary>
		/// The path of the current configuration file.
		/// </summary>
		private string mConfigFile_;

		/// <summary>
		/// The DX target server. 
		/// </summary>
#pragma warning disable CS0649 // Field 'MainForm.mTarget_' is never assigned to, and will always have its default value null
		private TsCDaServer mTarget_;
#pragma warning restore CS0649 // Field 'MainForm.mTarget_' is never assigned to, and will always have its default value null


		/// <summary>
		/// Called by the update control when something happens.
		/// </summary>
		private void OnUpdateEvent(object subscriptionHandle, object args)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new UpdateEventEventHandler(OnUpdateEvent), new object[] { subscriptionHandle, args });
				return;
			}

			if (args is string s)
            {
                if (server_?.Subscriptions != null)
                {
                    foreach (TsCDaSubscription subscription in server_.Subscriptions)
                    {
                        if (subscription.ClientHandle.Equals(subscriptionHandle))
                        {
                            outputCtrl_.Text += $"{subscription.Name}\t{s}\r\n";
                            return;
                        }
                    }
                }
            }
		}

		/// <summary>
		/// Called to connect to a server.
		/// </summary>
		public void OnConnect(OpcServer server)
		{
			// disconnect from the current server.
			OnDisconnect();

			// create a default file name for the server.
            mConfigFile_ = server.ServerName + ".config";

			// use the specified server object directly.
			TsCCpxComplexTypeCache.Server = server_ = (TsCDaServer)server;

			// connect with an empty configuration.
			OnConnect();	
		}
		
		/// <summary>
		/// Called to connect to a server.
		/// </summary>
		public void OnConnect()
		{
            if (server_ == null)
            {
                return;
            }

            Cursor = Cursors.WaitCursor;

            try
			{
				OpcUserIdentity credentials = null;

				do
				{
					try
					{
					    server_.ForceDa20Usage = forceDa20Usage_;
						server_.Connect(new OpcConnectData(credentials, mProxy_));
                        break;
					}
                    catch (Exception e)
					{
						MessageBox.Show(e.Message);
					}

					credentials = new NetworkCredentialsDlg().ShowDialog(credentials);
				}
				while (credentials != null);
	
				// select all filters by default.
				server_.SetResultFilters((int)TsCDaResultFilter.All);

				// initialize controls.
				statusCtrl_.Start(server_);
				updatesCtrl_.Initialize(server_);
				subscriptionCtrl_.Initialize(server_);
				selectServerCtrl_.OnConnect(server_);

				// register for shutdown events.
				server_.ServerShutdownEvent += Server_ServerShutdown;

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				TsCCpxComplexTypeCache.Server = server_ = null;
			}

			Cursor = Cursors.Default;
		}

		/// <summary>
		/// Called to disconnect from a server.
		/// </summary>
		public void OnDisconnect()
		{
			// disconnect server.
			if (server_ != null)
			{
				try	  { server_.Disconnect(); }
				catch {}

				server_.Dispose();
				TsCCpxComplexTypeCache.Server = server_ = null;
			}

			// initialize controls.
			subscriptionCtrl_.Initialize(server_);
			updatesCtrl_.Initialize(server_);
			statusCtrl_.Start(server_);
			outputCtrl_.Text = "";
		}

		/// <summary>
		/// Called when a tool bar button is clicked.
		/// </summary>
		//private void ToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		//{
		//	if (e.Button == ConnectBTN)    { OnConnect();                   return; }	
		//	if (e.Button == DisconnectBTN) { OnDisconnect();                return; }	
		//	if (e.Button == ViewStatusBTN) { ViewStatusMI_Click(sender, e); return; }	
		//	if (e.Button == BrowseBTN)     { BrowseMI_Click(sender, e);     return; }	
		//	if (e.Button == ReadBTN)       { ReadMI_Click(sender, e);       return; }	
		//	if (e.Button == WriteBTN)      { WriteMI_Click(sender, e);      return; }	
		//	if (e.Button == AboutBTN)      { OnAbout();                     return; }	
		//}

		/// <summary>
		/// Called when the File | Exit menu item is clicked.
		/// </summary>
		private void ExitMI_Click(object sender, EventArgs e)
		{
			OnDisconnect();
			Close();
		}

		/// <summary>
		/// Called when the Server | Connect menu item is clicked.
		/// </summary>
		private void ConnectMI_Click(object sender, EventArgs e)
		{
            if (server_ ==null)
            {
                server_ = new Da.Server.SelectServerDlg().ShowDialog(OpcSpecification.OPC_DA_30);
            }
            OnConnect();
		}

		/// <summary>
		/// Called when the Server | Disconnect menu item is clicked.
		/// </summary>
		private void DisconnectMI_Click(object sender, EventArgs e)
		{
			OnDisconnect();
		}

		/// <summary>
		/// Called when the Server | Browse menu item is clicked.
		/// </summary>
		private void ViewStatusMI_Click(object sender, EventArgs e)
		{
			if (server_ != null)
            {
                new ServerStatusDlg().ShowDialog(server_);
            }
        }

		/// <summary>
		/// Called when the Server | Browse menu item is clicked.
		/// </summary>
		private void BrowseMI_Click(object sender, EventArgs e)
		{
			if (server_ != null) new BrowseItemsDlg().Initialize(server_);
		}

		/// <summary>
		/// Called when the Server | Read menu item is clicked.
		/// </summary>
		private void ReadMI_Click(object sender, EventArgs e)
		{
			if (server_ != null) new ReadItemsDlg().ShowDialog(server_);	
		}

		/// <summary>
		/// Called when the Server | Write menu item is clicked.
		/// </summary>
		private void WriteMI_Click(object sender, EventArgs e)
		{
			if (server_ != null) new WriteItemsDlg().ShowDialog(server_);	
		}

		/// <summary>
		/// Called when the Output | Clear menu item is clicked.
		/// </summary>
		private void OutputClearMI_Click(object sender, EventArgs e)
		{
			outputCtrl_.Text = "";
		}

        /// <summary>
		/// Clears the URL history in the drop down menu.
		/// </summary>
		private void ClearHistoryMI_Click(object sender, EventArgs e)
		{
			selectServerCtrl_.Initialize(null, 0, OpcSpecification.OPC_DA_30);
		}

		/// <summary>
		/// Called when the server sends a shutdown event.
		/// </summary>
		private void Server_ServerShutdown(string reason)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new OpcServerShutdownEventHandler(Server_ServerShutdown), new object[] { reason });
				return;
			}

			MessageBox.Show(reason, "Server Shutdown");
			OnDisconnect();
		}

        #region Event Handlers

        private void OnForceDa20Usage(object sender, EventArgs e)
        {
            forceDa20UsageMenuItem_.Checked = !forceDa20Usage_;
            forceDa20Usage_ = !forceDa20Usage_;
        }

        private void UpdateTitle()
        {
            Text = $"{"OPC DA Sample Client"}";
        }

		private void UpdateTimerCtrlTick(object sender, EventArgs e)
		{
			UpdateTitle();
		}
        
        #endregion
	}
}

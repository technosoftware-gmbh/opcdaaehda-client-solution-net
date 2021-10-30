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
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Permissions;
using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Ae;
using Technosoftware.DaAeHdaClient.Utilities;
using SampleClients.Common;
using Technosoftware.AeSampleClient;

#endregion

namespace SampleClients.Ae
{
    /// <summary>
    /// The main application window for the OPC AE Sample Application.
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
        private ServerStatusCtrl statusCtrl_;
        private ToolStripMenuItem exitMi_;
        private ToolStripMenuItem serverMi_;
        private ToolStripMenuItem connectMi_;
        private ToolStripMenuItem disconnecMi_;
        private ToolStripMenuItem viewStatusMi_;
        private ToolStripMenuItem separatorS1_;
        private ToolStripMenuItem separatorS2_;
        private ToolStripMenuItem helpMi_;
        private ToolStripMenuItem aboutMi_;
        private ImageList toolBarImageList_;
        private ToolStripButton connectBtn_;
        private ToolStripButton disconnectBtn_;
        private ToolStripButton viewStatusBtn_;
        private ToolStripButton browseBtn_;
        private ToolStripButton aboutBtn_;
        private ToolStripMenuItem outputMi_;
        private ToolStripMenuItem outputClearMi_;
        private ToolStripMenuItem optionsMi_;
        private ToolStripMenuItem clearHistoryMi_;
        private ToolStripMenuItem viewFiltersMi_;
        private ToolStripMenuItem viewCategoriesMi_;
        private SubscriptionsCtrl subscriptionsCtrl_;
        private ToolStripMenuItem menuItem1_;
        private ToolStripMenuItem createSubscriptionMi_;
        private EventListCtrl eventListCtrl_;
        private ToolStripMenuItem browseAreasMi_;
        private Timer updateTimerControl_;
        private ToolStripSeparator separatorT2_;
        private System.ComponentModel.IContainer components;

        [STAThread]
        static void Main()
        {
            try
            {
                ConfigUtils.EnableTrace(ConfigUtils.GetLogFileDirectory(), "SampleClients.Ae.log.txt");

                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                MessageBox.Show("An unexpected exception occurred. Application exiting.\r\n\r\n" + e.Message, "OPC AE Sample Client");
            }
        }

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
 
            Icon = ClientUtils.GetAppIcon();

            ////Icon = ClientUtils.GetAppIcon();

#if (DEBUG)

            // initialize the set of known servers.
            var knownUrLs = new OpcUrl[]
            {
                new OpcUrl("opcae://localhost/Technosoftware.AeSample")
            };

#else
			// initialize the set of known servers.
			OpcUrl[] knownURLs = new OpcUrl[] 
			{
				new OpcUrl("opcae://localhost/Technosoftware.AeSample")
			};
#endif

            selectServerCtrl_.Initialize(knownUrLs, 0, OpcSpecification.OPC_AE_10);
            LoadSettings();

            // register for server connected callbacks.
            selectServerCtrl_.ConnectServer += new ConnectServer_EventHandler(OnConnect);
            UpdateTitle();
            updateTimerControl_.Enabled = true;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
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
            this.browseAreasMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorS2_ = new System.Windows.Forms.ToolStripMenuItem();
            this.viewFiltersMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCategoriesMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem1_ = new System.Windows.Forms.ToolStripMenuItem();
            this.createSubscriptionMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.outputMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.outputClearMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBar_ = new System.Windows.Forms.ToolStrip();
            this.connectBtn_ = new System.Windows.Forms.ToolStripButton();
            this.disconnectBtn_ = new System.Windows.Forms.ToolStripButton();
            this.viewStatusBtn_ = new System.Windows.Forms.ToolStripButton();
            this.browseBtn_ = new System.Windows.Forms.ToolStripButton();
            this.aboutBtn_ = new System.Windows.Forms.ToolStripButton();
            this.toolBarImageList_ = new System.Windows.Forms.ImageList(this.components);
            this.bottomPn_ = new System.Windows.Forms.Panel();
            this.outputCtrl_ = new System.Windows.Forms.RichTextBox();
            this.splitterH_ = new System.Windows.Forms.Splitter();
            this.splitterV_ = new System.Windows.Forms.Splitter();
            this.leftPn_ = new System.Windows.Forms.Panel();
            this.subscriptionsCtrl_ = new Technosoftware.AeSampleClient.SubscriptionsCtrl();
            this.rightPn_ = new System.Windows.Forms.Panel();
            this.eventListCtrl_ = new Technosoftware.AeSampleClient.EventListCtrl();
            this.selectServerCtrl_ = new SampleClients.Common.SelectServerCtrl();
            this.statusCtrl_ = new Technosoftware.AeSampleClient.ServerStatusCtrl();
            this.updateTimerControl_ = new System.Windows.Forms.Timer(this.components);
            this.separatorT2_ = new System.Windows.Forms.ToolStripSeparator();
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
            this.browseAreasMi_,
            this.separatorS2_,
            this.viewFiltersMi_,
            this.viewCategoriesMi_,
            this.menuItem1_,
            this.createSubscriptionMi_});
            this.serverMi_.Name = "serverMi_";
            this.serverMi_.Size = new System.Drawing.Size(51, 20);
            this.serverMi_.Text = "&Server";
            // 
            // connectMi_
            // 
            this.connectMi_.Name = "connectMi_";
            this.connectMi_.Size = new System.Drawing.Size(186, 22);
            this.connectMi_.Text = "&Connect";
            this.connectMi_.Click += new System.EventHandler(this.ConnectMI_Click);
            // 
            // disconnecMi_
            // 
            this.disconnecMi_.Name = "disconnecMi_";
            this.disconnecMi_.Size = new System.Drawing.Size(186, 22);
            this.disconnecMi_.Text = "&Disconnect";
            this.disconnecMi_.Click += new System.EventHandler(this.DisconnectMI_Click);
            // 
            // separatorS1_
            // 
            this.separatorS1_.Name = "separatorS1_";
            this.separatorS1_.Size = new System.Drawing.Size(186, 22);
            this.separatorS1_.Text = "-";
            // 
            // viewStatusMi_
            // 
            this.viewStatusMi_.Name = "viewStatusMi_";
            this.viewStatusMi_.Size = new System.Drawing.Size(186, 22);
            this.viewStatusMi_.Text = "&View Status...";
            this.viewStatusMi_.Click += new System.EventHandler(this.ViewStatusMI_Click);
            // 
            // browseAreasMi_
            // 
            this.browseAreasMi_.Name = "browseAreasMi_";
            this.browseAreasMi_.Size = new System.Drawing.Size(186, 22);
            this.browseAreasMi_.Text = "&Browse Areas...";
            this.browseAreasMi_.Click += new System.EventHandler(this.BrowseMI_Click);
            // 
            // separatorS2_
            // 
            this.separatorS2_.Name = "separatorS2_";
            this.separatorS2_.Size = new System.Drawing.Size(186, 22);
            this.separatorS2_.Text = "-";
            // 
            // viewFiltersMi_
            // 
            this.viewFiltersMi_.Name = "viewFiltersMi_";
            this.viewFiltersMi_.Size = new System.Drawing.Size(186, 22);
            this.viewFiltersMi_.Text = "View Filters...";
            this.viewFiltersMi_.Click += new System.EventHandler(this.ViewFiltersMI_Click);
            // 
            // viewCategoriesMi_
            // 
            this.viewCategoriesMi_.Name = "viewCategoriesMi_";
            this.viewCategoriesMi_.Size = new System.Drawing.Size(186, 22);
            this.viewCategoriesMi_.Text = "View Categories...";
            this.viewCategoriesMi_.Click += new System.EventHandler(this.ViewCategoriesMI_Click);
            // 
            // menuItem1_
            // 
            this.menuItem1_.Name = "menuItem1_";
            this.menuItem1_.Size = new System.Drawing.Size(186, 22);
            this.menuItem1_.Text = "-";
            // 
            // createSubscriptionMi_
            // 
            this.createSubscriptionMi_.Name = "createSubscriptionMi_";
            this.createSubscriptionMi_.Size = new System.Drawing.Size(186, 22);
            this.createSubscriptionMi_.Text = "Create Subscription...";
            this.createSubscriptionMi_.Click += new System.EventHandler(this.CreateSubscriptionMI_Click);
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
            this.clearHistoryMi_});
            this.optionsMi_.Name = "optionsMi_";
            this.optionsMi_.Size = new System.Drawing.Size(61, 20);
            this.optionsMi_.Text = "O&ptions";
            // 
            // clearHistoryMi_
            // 
            this.clearHistoryMi_.Name = "clearHistoryMi_";
            this.clearHistoryMi_.Size = new System.Drawing.Size(142, 22);
            this.clearHistoryMi_.Text = "&Clear History";
            this.clearHistoryMi_.Click += new System.EventHandler(this.ClearHistoryMI_Click);
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
            this.aboutMi_.Click += new System.EventHandler(this.AboutMI_Click);
            // 
            // toolBar_
            // 
            this.toolBar_.ImageList = this.toolBarImageList_;
            this.toolBar_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectBtn_,
            this.disconnectBtn_,
            this.viewStatusBtn_,
            this.browseBtn_,
            this.separatorT2_,
            this.aboutBtn_});
            this.toolBar_.Location = new System.Drawing.Point(3, 0);
            this.toolBar_.Name = "toolBar_";
            this.toolBar_.Size = new System.Drawing.Size(1010, 25);
            this.toolBar_.TabIndex = 0;
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
            // aboutBtn_
            // 
            this.aboutBtn_.ImageIndex = 13;
            this.aboutBtn_.Name = "aboutBtn_";
            this.aboutBtn_.Size = new System.Drawing.Size(23, 22);
            this.aboutBtn_.ToolTipText = "About";
            this.aboutBtn_.Click += new System.EventHandler(this.AboutMI_Click);
            // 
            // toolBarImageList_
            // 
            this.toolBarImageList_.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
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
            // bottomPn_
            // 
            this.bottomPn_.Controls.Add(this.outputCtrl_);
            this.bottomPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPn_.Location = new System.Drawing.Point(3, 526);
            this.bottomPn_.Name = "bottomPn_";
            this.bottomPn_.Size = new System.Drawing.Size(1010, 123);
            this.bottomPn_.TabIndex = 3;
            // 
            // outputCtrl_
            // 
            this.outputCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputCtrl_.Location = new System.Drawing.Point(0, 0);
            this.outputCtrl_.Name = "outputCtrl_";
            this.outputCtrl_.Size = new System.Drawing.Size(1010, 123);
            this.outputCtrl_.TabIndex = 0;
            this.outputCtrl_.Text = "";
            // 
            // splitterH_
            // 
            this.splitterH_.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterH_.Location = new System.Drawing.Point(3, 522);
            this.splitterH_.Name = "splitterH_";
            this.splitterH_.Size = new System.Drawing.Size(1010, 4);
            this.splitterH_.TabIndex = 4;
            this.splitterH_.TabStop = false;
            // 
            // splitterV_
            // 
            this.splitterV_.Location = new System.Drawing.Point(319, 52);
            this.splitterV_.Name = "splitterV_";
            this.splitterV_.Size = new System.Drawing.Size(4, 470);
            this.splitterV_.TabIndex = 5;
            this.splitterV_.TabStop = false;
            // 
            // leftPn_
            // 
            this.leftPn_.Controls.Add(this.subscriptionsCtrl_);
            this.leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPn_.Location = new System.Drawing.Point(3, 52);
            this.leftPn_.Name = "leftPn_";
            this.leftPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.leftPn_.Size = new System.Drawing.Size(316, 470);
            this.leftPn_.TabIndex = 6;
            // 
            // subscriptionsCtrl_
            // 
            this.subscriptionsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subscriptionsCtrl_.Location = new System.Drawing.Point(0, 3);
            this.subscriptionsCtrl_.Name = "subscriptionsCtrl_";
            this.subscriptionsCtrl_.Size = new System.Drawing.Size(316, 467);
            this.subscriptionsCtrl_.TabIndex = 0;
            this.subscriptionsCtrl_.SubscriptionAction += new Technosoftware.AeSampleClient.SubscriptionsCtrl.SubscriptionActionEventHandler(this.SubscriptionsCTRL_SubscriptionAction);
            // 
            // rightPn_
            // 
            this.rightPn_.Controls.Add(this.eventListCtrl_);
            this.rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPn_.Location = new System.Drawing.Point(323, 52);
            this.rightPn_.Name = "rightPn_";
            this.rightPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.rightPn_.Size = new System.Drawing.Size(690, 470);
            this.rightPn_.TabIndex = 7;
            // 
            // eventListCtrl_
            // 
            this.eventListCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventListCtrl_.Location = new System.Drawing.Point(0, 3);
            this.eventListCtrl_.Name = "eventListCtrl_";
            this.eventListCtrl_.Size = new System.Drawing.Size(690, 467);
            this.eventListCtrl_.TabIndex = 0;
            // 
            // selectServerCtrl_
            // 
            this.selectServerCtrl_.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectServerCtrl_.Label = "Server";
            this.selectServerCtrl_.Location = new System.Drawing.Point(3, 25);
            this.selectServerCtrl_.Name = "selectServerCtrl_";
            this.selectServerCtrl_.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selectServerCtrl_.Size = new System.Drawing.Size(1010, 27);
            this.selectServerCtrl_.TabIndex = 0;
            // 
            // statusCtrl_
            // 
            this.statusCtrl_.Location = new System.Drawing.Point(3, 649);
            this.statusCtrl_.Name = "statusCtrl_";
            this.statusCtrl_.Size = new System.Drawing.Size(1010, 22);
            this.statusCtrl_.TabIndex = 8;
            // 
            // updateTimerControl_
            // 
            this.updateTimerControl_.Interval = 10000;
            this.updateTimerControl_.Tick += new System.EventHandler(this.UpdateTimerCtrlTick);
            // 
            // separatorT2_
            // 
            this.separatorT2_.Name = "separatorT2_";
            this.separatorT2_.Size = new System.Drawing.Size(6, 25);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.ClientSize = new System.Drawing.Size(1016, 671);
            this.Controls.Add(this.rightPn_);
            this.Controls.Add(this.splitterV_);
            this.Controls.Add(this.leftPn_);
            this.Controls.Add(this.splitterH_);
            this.Controls.Add(this.bottomPn_);
            this.Controls.Add(this.selectServerCtrl_);
            this.Controls.Add(this.statusCtrl_);
            this.Controls.Add(this.toolBar_);
            this.MainMenuStrip = this.mainMenu_;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Text = "OPC AE Sample Client";
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
            public OpcUrl[] KnownUrls = null;
            public int SelectedUrl = -1;
            public string ProxyServer = null;
        }

        /// <summary>
        /// The application configuration file path.
        /// </summary>
        private string ConfigFilePath
        {
            get { return Application.StartupPath + "\\Technosoftware.AeSampleClient.config"; }
        }

        /// <summary>
        /// The default web proxy for the application - uses IE settings if null.
        /// </summary>
        private WebProxy mProxy_ = null;

        /// <summary>
        /// The currently active server object.
        /// </summary>
        private TsCAeServer mServer_ = null;

        /// <summary>
        /// The path of the current configuration file.
        /// </summary>
        private string mConfigFile_ = null;

        /// <summary>
        /// Called to connect to a server.
        /// </summary>
        public void OnConnect(OpcServer server)
        {
            // disconnect from the current server.
            OnDisconnect();

            // create a default file name for the server.
            mConfigFile_ = server.ServerName + ".config";

            // load server object from config file if it exists. 
            if (File.Exists(mConfigFile_))
            {
                if (OnLoad(false, server.Url)) return;
            }

            // use the specified server object directly.
            mServer_ = (TsCAeServer)server;

            // connect with an empty configuration.
            OnConnect();
        }

        /// <summary>
        /// Called to connect to a server.
        /// </summary>
        public void OnConnect()
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                OpcUserIdentity credentials = null;

                do
                {
                    try
                    {
                        mServer_.Connect(new OpcConnectData(credentials, mProxy_));
                        break;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    credentials = new NetworkCredentialsDlg().ShowDialog(credentials);
                }
                while (credentials != null);

                // initialize controls.
                selectServerCtrl_.OnConnect(mServer_);
                statusCtrl_.Start(mServer_);
                subscriptionsCtrl_.ShowSubscriptions(mServer_);

                // register for shutdown events.
                mServer_.ServerShutdownEvent += new OpcServerShutdownEventHandler(Server_ServerShutdown);

                // save settings.
                SaveSettings();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "On Connect");
                mServer_ = null;
            }

            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Called to disconnect from a server.
        /// </summary>
        public void OnDisconnect()
        {
            try
            {
                // close notification callbacks.
                eventListCtrl_.RemoveSubscriptions();

                // disconnect server.
                if (mServer_ != null)
                {
                    try { mServer_.Disconnect(); }
                    catch { }

                    mServer_.Dispose();
                    mServer_ = null;
                }

                // uninitialize controls.
                statusCtrl_.Start(null);
                subscriptionsCtrl_.ShowSubscriptions(null);
                outputCtrl_.Text = "";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Disconnect Server Failed");
            }
        }

        /// <summary>
        /// Displays the about dialog for the application.
        /// </summary>
        private void OnAbout()
        {
        }

        /// <summary>
        /// Saves the configuration for the current server.
        /// </summary>
        private void OnSave()
        {
            Stream stream = null;

            try
            {
                Cursor = Cursors.WaitCursor;

                // ensure a valid server object exists.
                if (mServer_ == null) throw new OpcResultException(OpcResult.E_FAIL, "The server is not currently connected.");

                // create the configuartion file.
                stream = new FileStream(mConfigFile_, FileMode.Create, FileAccess.Write, FileShare.None);

                // serialize the server object.
                new BinaryFormatter().Serialize(stream, mServer_);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                // close the stream.
                if (stream != null) stream.Close();

                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Loads the configuration for the current server.
        /// </summary>
        private bool OnLoad(bool prompt, OpcUrl url)
        {
            Stream stream = null;

            try
            {
                Cursor = Cursors.WaitCursor;

                // prompt user to select a configuration file.
                if (prompt)
                {
                    var dialog = new OpenFileDialog();

                    dialog.CheckFileExists = true;
                    dialog.CheckPathExists = true;
                    dialog.DefaultExt = ".config";
                    dialog.Filter = "Config Files (*.config)|*.config|All Files (*.*)|*.*";
                    dialog.Multiselect = false;
                    dialog.ValidateNames = true;
                    dialog.Title = "Open Server Configuration File";
                    dialog.FileName = mConfigFile_;

                    if (dialog.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }

                    // save the new config file name.
                    mConfigFile_ = dialog.FileName;
                }

                // disconnect from current server.
                OnDisconnect();

                // open configuration file.
                stream = new FileStream(mConfigFile_, FileMode.Open, FileAccess.Read, FileShare.Read);

                // deserialize the server object.
                mServer_ = (TsCAeServer)new BinaryFormatter().Deserialize(stream);

                // overrided default url.
                if (url != null)
                {
                    mServer_.Url = url;
                }

                // connect to new server.
                OnConnect();

                // load succeeded.
                return true;
            }
            catch (Exception e)
            {
                if (prompt) MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                // close the stream.
                if (stream != null) stream.Close();

                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Saves the user's application settings.
        /// </summary>
        private void SaveSettings()
        {
            Stream stream = null;

            try
            {
                Cursor = Cursors.WaitCursor;

                // create the configuartion file.
                stream = new FileStream(ConfigFilePath, FileMode.Create, FileAccess.Write, FileShare.None);

                // populate the user settings object.
                var settings = new UserAppData();

                settings.KnownUrls = selectServerCtrl_.GetKnownURLs(out settings.SelectedUrl);

                if (mProxy_ != null)
                {
                    settings.ProxyServer = mProxy_.Address.ToString();
                }

                // serialize the user settings object.
                new BinaryFormatter().Serialize(stream, settings);
            }
            catch
            {
                // ignore errors.
            }
            finally
            {
                // close the stream.
                if (stream != null) stream.Close();
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Loads the user's application settings.
        /// </summary>
        private void LoadSettings()
        {
            Stream stream = null;

            try
            {
                Cursor = Cursors.WaitCursor;

                // open configuration file.
                stream = new FileStream(ConfigFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);

                // deserialize the server object.
                var settings = (UserAppData)new BinaryFormatter().Deserialize(stream);

                // overrided the current settings.
                if (settings != null)
                {
                    // known urls.
                    selectServerCtrl_.Initialize(settings.KnownUrls, settings.SelectedUrl, OpcSpecification.OPC_AE_10);

                    // proxy server.
                    if (settings.ProxyServer != null)
                    {
                        mProxy_ = new WebProxy(settings.ProxyServer);
                    }
                }
            }
            catch
            {
                // ignore errors.
            }
            finally
            {
                // close the stream.
                if (stream != null) stream.Close();
                Cursor = Cursors.Default;
            }
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
        //	if (e.Button == AboutBTN)      { OnAbout();                     return; }	
        //}

        /// <summary>
        /// Called when the File | Load menu item is clicked.
        /// </summary>
        private void LoadMI_Click(object sender, EventArgs e)
        {
            OnLoad(true, null);
        }

        /// <summary>
        /// Called when the File | Save menu item is clicked.
        /// </summary>
        private void SaveMI_Click(object sender, EventArgs e)
        {
            OnSave();
        }

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
            if (mServer_ != null) new ServerStatusDlg().ShowDialog(mServer_);
        }

        /// <summary>
        /// Called when the Server | Browse menu item is clicked.
        /// </summary>
        private void BrowseMI_Click(object sender, EventArgs e)
        {
            try
            {
                new BrowseDlg().ShowDialog(mServer_, false);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Called when the Help | About menu item is clicked.
        /// </summary>
        private void AboutMI_Click(object sender, EventArgs e)
        {
            OnAbout();
        }

        /// <summary>
        /// Called when the Output | Clear menu item is clicked.
        /// </summary>
        private void OutputClearMI_Click(object sender, EventArgs e)
        {
            outputCtrl_.Text = "";
        }

        /// <summary>
        /// Handles changes to the proxy server settings.
        /// </summary>
        private void ProxyServerMI_Click(object sender, EventArgs e)
        {
            var proxy = new ProxyServerDlg().ShowDialog(mProxy_);

            if (proxy != mProxy_)
            {
                mProxy_ = proxy;
                SaveSettings();
            }
        }

        /// <summary>
        /// Clears the URL history in the drop down menu.
        /// </summary>
        private void ClearHistoryMI_Click(object sender, EventArgs e)
        {
            selectServerCtrl_.Initialize(null, 0, OpcSpecification.OPC_AE_10);
            SaveSettings();
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

        /// <summary>
        /// Displays the filters supported by the server.
        /// </summary>
        private void ViewFiltersMI_Click(object sender, EventArgs e)
        {
            try
            {
                new FiltersViewDlg().ShowDialog(mServer_);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Displays the categories supported by the server.
        /// </summary>
        private void ViewCategoriesMI_Click(object sender, EventArgs e)
        {
            try
            {
                new CategoriesViewDlg().ShowDialog(mServer_);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Displays the conditions supported by the server.
        /// </summary>
        private void ViewConditionsMI_Click(object sender, EventArgs e)
        {
            try
            {
                new ConditionsViewDlg().ShowDialog(mServer_);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Creates a new event subscription.
        /// </summary>
        private void CreateSubscriptionMI_Click(object sender, EventArgs e)
        {
            try
            {
                subscriptionsCtrl_.AddSubscription();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Adds or removes a subscription from the event notifications control.
        /// </summary>
        private void SubscriptionsCTRL_SubscriptionAction(TsCAeSubscription subscription, bool deleted)
        {
            try
            {
                if (deleted)
                {
                    eventListCtrl_.RemoveSubscription(subscription);
                }
                else
                {
                    eventListCtrl_.AddSubscription(subscription);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        #region Event Handlers

        private void UpdateTitle()
        {
            Text = $"{"OPC AE Sample Client"}";
        }

        private void UpdateTimerCtrlTick(object sender, EventArgs e)
        {
            UpdateTitle();
        }

        #endregion

    }
}

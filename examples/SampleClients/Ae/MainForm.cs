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
using System.Security;
using System.Security.Permissions;
using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Ae;
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
        private System.ComponentModel.IContainer components_;

        [STAThread]
        static void Main()
        {
            try
            {
                //ApplicationInstance.InitializeSecurity(ApplicationInstance.AuthenticationLevel.Integrity);
                ApplicationInstance.EnableTrace(ApplicationInstance.GetLogFileDirectory(), "SampleClients.Ae.log");

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
 
            

            ////

#if (DEBUG)

            // initialize the set of known servers.
            var knownUrls = new OpcUrl[]
            {
                new OpcUrl("opcae://localhost/SampleCompany.AeSample")
            };

#else
			// initialize the set of known servers.
			OpcUrl[] knownUrls = new OpcUrl[] 
			{
				new OpcUrl("opcae://localhost/SampleCompany.AeSample")
			};
#endif

            selectServerCtrl_.Initialize(knownUrls, 0, OpcSpecification.OPC_AE_10);

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
                if (components_ != null)
                {
                    components_.Dispose();
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
            components_ = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainMenu_ = new System.Windows.Forms.MenuStrip();
            fileMi_ = new System.Windows.Forms.ToolStripMenuItem();
            exitMi_ = new System.Windows.Forms.ToolStripMenuItem();
            serverMi_ = new System.Windows.Forms.ToolStripMenuItem();
            connectMi_ = new System.Windows.Forms.ToolStripMenuItem();
            disconnecMi_ = new System.Windows.Forms.ToolStripMenuItem();
            separatorS1_ = new System.Windows.Forms.ToolStripMenuItem();
            viewStatusMi_ = new System.Windows.Forms.ToolStripMenuItem();
            browseAreasMi_ = new System.Windows.Forms.ToolStripMenuItem();
            separatorS2_ = new System.Windows.Forms.ToolStripMenuItem();
            viewFiltersMi_ = new System.Windows.Forms.ToolStripMenuItem();
            viewCategoriesMi_ = new System.Windows.Forms.ToolStripMenuItem();
            menuItem1_ = new System.Windows.Forms.ToolStripMenuItem();
            createSubscriptionMi_ = new System.Windows.Forms.ToolStripMenuItem();
            outputMi_ = new System.Windows.Forms.ToolStripMenuItem();
            outputClearMi_ = new System.Windows.Forms.ToolStripMenuItem();
            optionsMi_ = new System.Windows.Forms.ToolStripMenuItem();
            clearHistoryMi_ = new System.Windows.Forms.ToolStripMenuItem();
            helpMi_ = new System.Windows.Forms.ToolStripMenuItem();
            aboutMi_ = new System.Windows.Forms.ToolStripMenuItem();
            toolBar_ = new System.Windows.Forms.ToolStrip();
            connectBtn_ = new System.Windows.Forms.ToolStripButton();
            disconnectBtn_ = new System.Windows.Forms.ToolStripButton();
            viewStatusBtn_ = new System.Windows.Forms.ToolStripButton();
            browseBtn_ = new System.Windows.Forms.ToolStripButton();
            aboutBtn_ = new System.Windows.Forms.ToolStripButton();
            toolBarImageList_ = new System.Windows.Forms.ImageList(components_);
            bottomPn_ = new System.Windows.Forms.Panel();
            outputCtrl_ = new System.Windows.Forms.RichTextBox();
            splitterH_ = new System.Windows.Forms.Splitter();
            splitterV_ = new System.Windows.Forms.Splitter();
            leftPn_ = new System.Windows.Forms.Panel();
            subscriptionsCtrl_ = new Technosoftware.AeSampleClient.SubscriptionsCtrl();
            rightPn_ = new System.Windows.Forms.Panel();
            eventListCtrl_ = new Technosoftware.AeSampleClient.EventListCtrl();
            selectServerCtrl_ = new SampleClients.Common.SelectServerCtrl();
            statusCtrl_ = new Technosoftware.AeSampleClient.ServerStatusCtrl();
            updateTimerControl_ = new System.Windows.Forms.Timer(components_);
            separatorT2_ = new System.Windows.Forms.ToolStripSeparator();
            mainMenu_.SuspendLayout();
            toolBar_.SuspendLayout();
            bottomPn_.SuspendLayout();
            leftPn_.SuspendLayout();
            rightPn_.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenu_
            // 
            mainMenu_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileMi_,
            serverMi_,
            outputMi_,
            optionsMi_,
            helpMi_});
            mainMenu_.Location = new System.Drawing.Point(0, 0);
            mainMenu_.Name = "mainMenu_";
            mainMenu_.Size = new System.Drawing.Size(200, 24);
            mainMenu_.TabIndex = 0;
            // 
            // fileMi_
            // 
            fileMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            exitMi_});
            fileMi_.Name = "fileMi_";
            fileMi_.Size = new System.Drawing.Size(37, 20);
            fileMi_.Text = "&File";
            // 
            // exitMi_
            // 
            exitMi_.Name = "exitMi_";
            exitMi_.Size = new System.Drawing.Size(93, 22);
            exitMi_.Text = "&Exit";
            exitMi_.Click += new System.EventHandler(ExitMI_Click);
            // 
            // serverMi_
            // 
            serverMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            connectMi_,
            disconnecMi_,
            separatorS1_,
            viewStatusMi_,
            browseAreasMi_,
            separatorS2_,
            viewFiltersMi_,
            viewCategoriesMi_,
            menuItem1_,
            createSubscriptionMi_});
            serverMi_.Name = "serverMi_";
            serverMi_.Size = new System.Drawing.Size(51, 20);
            serverMi_.Text = "&Server";
            // 
            // connectMi_
            // 
            connectMi_.Name = "connectMi_";
            connectMi_.Size = new System.Drawing.Size(186, 22);
            connectMi_.Text = "&Connect";
            connectMi_.Click += new System.EventHandler(ConnectMI_Click);
            // 
            // disconnecMi_
            // 
            disconnecMi_.Name = "disconnecMi_";
            disconnecMi_.Size = new System.Drawing.Size(186, 22);
            disconnecMi_.Text = "&Disconnect";
            disconnecMi_.Click += new System.EventHandler(DisconnectMI_Click);
            // 
            // separatorS1_
            // 
            separatorS1_.Name = "separatorS1_";
            separatorS1_.Size = new System.Drawing.Size(186, 22);
            separatorS1_.Text = "-";
            // 
            // viewStatusMi_
            // 
            viewStatusMi_.Name = "viewStatusMi_";
            viewStatusMi_.Size = new System.Drawing.Size(186, 22);
            viewStatusMi_.Text = "&View Status...";
            viewStatusMi_.Click += new System.EventHandler(ViewStatusMI_Click);
            // 
            // browseAreasMi_
            // 
            browseAreasMi_.Name = "browseAreasMi_";
            browseAreasMi_.Size = new System.Drawing.Size(186, 22);
            browseAreasMi_.Text = "&Browse Areas...";
            browseAreasMi_.Click += new System.EventHandler(BrowseMI_Click);
            // 
            // separatorS2_
            // 
            separatorS2_.Name = "separatorS2_";
            separatorS2_.Size = new System.Drawing.Size(186, 22);
            separatorS2_.Text = "-";
            // 
            // viewFiltersMi_
            // 
            viewFiltersMi_.Name = "viewFiltersMi_";
            viewFiltersMi_.Size = new System.Drawing.Size(186, 22);
            viewFiltersMi_.Text = "View Filters...";
            viewFiltersMi_.Click += new System.EventHandler(ViewFiltersMI_Click);
            // 
            // viewCategoriesMi_
            // 
            viewCategoriesMi_.Name = "viewCategoriesMi_";
            viewCategoriesMi_.Size = new System.Drawing.Size(186, 22);
            viewCategoriesMi_.Text = "View Categories...";
            viewCategoriesMi_.Click += new System.EventHandler(ViewCategoriesMI_Click);
            // 
            // menuItem1_
            // 
            menuItem1_.Name = "menuItem1_";
            menuItem1_.Size = new System.Drawing.Size(186, 22);
            menuItem1_.Text = "-";
            // 
            // createSubscriptionMi_
            // 
            createSubscriptionMi_.Name = "createSubscriptionMi_";
            createSubscriptionMi_.Size = new System.Drawing.Size(186, 22);
            createSubscriptionMi_.Text = "Create Subscription...";
            createSubscriptionMi_.Click += new System.EventHandler(CreateSubscriptionMI_Click);
            // 
            // outputMi_
            // 
            outputMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            outputClearMi_});
            outputMi_.Name = "outputMi_";
            outputMi_.Size = new System.Drawing.Size(57, 20);
            outputMi_.Text = "&Output";
            // 
            // outputClearMi_
            // 
            outputClearMi_.Name = "outputClearMi_";
            outputClearMi_.Size = new System.Drawing.Size(101, 22);
            outputClearMi_.Text = "&Clear";
            outputClearMi_.Click += new System.EventHandler(OutputClearMI_Click);
            // 
            // optionsMi_
            // 
            optionsMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            clearHistoryMi_});
            optionsMi_.Name = "optionsMi_";
            optionsMi_.Size = new System.Drawing.Size(61, 20);
            optionsMi_.Text = "O&ptions";
            // 
            // clearHistoryMi_
            // 
            clearHistoryMi_.Name = "clearHistoryMi_";
            clearHistoryMi_.Size = new System.Drawing.Size(142, 22);
            clearHistoryMi_.Text = "&Clear History";
            clearHistoryMi_.Click += new System.EventHandler(ClearHistoryMI_Click);
            // 
            // helpMi_
            // 
            helpMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            aboutMi_});
            helpMi_.Name = "helpMi_";
            helpMi_.Size = new System.Drawing.Size(44, 20);
            helpMi_.Text = "&Help";
            // 
            // aboutMi_
            // 
            aboutMi_.Name = "aboutMi_";
            aboutMi_.Size = new System.Drawing.Size(116, 22);
            aboutMi_.Text = "&About...";
            // 
            // toolBar_
            // 
            toolBar_.ImageList = toolBarImageList_;
            toolBar_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            connectBtn_,
            disconnectBtn_,
            viewStatusBtn_,
            browseBtn_,
            separatorT2_,
            aboutBtn_});
            toolBar_.Location = new System.Drawing.Point(3, 0);
            toolBar_.Name = "toolBar_";
            toolBar_.Size = new System.Drawing.Size(1010, 25);
            toolBar_.TabIndex = 0;
            // 
            // connectBtn_
            // 
            connectBtn_.ImageIndex = 0;
            connectBtn_.Name = "connectBtn_";
            connectBtn_.Size = new System.Drawing.Size(23, 22);
            connectBtn_.ToolTipText = "Connect to Server";
            connectBtn_.Click += new System.EventHandler(ConnectMI_Click);
            // 
            // disconnectBtn_
            // 
            disconnectBtn_.ImageIndex = 1;
            disconnectBtn_.Name = "disconnectBtn_";
            disconnectBtn_.Size = new System.Drawing.Size(23, 22);
            disconnectBtn_.ToolTipText = "Disconnect from Server";
            disconnectBtn_.Click += new System.EventHandler(DisconnectMI_Click);
            // 
            // viewStatusBtn_
            // 
            viewStatusBtn_.ImageIndex = 4;
            viewStatusBtn_.Name = "viewStatusBtn_";
            viewStatusBtn_.Size = new System.Drawing.Size(23, 22);
            viewStatusBtn_.ToolTipText = "View Server Status";
            viewStatusBtn_.Click += new System.EventHandler(ViewStatusMI_Click);
            // 
            // browseBtn_
            // 
            browseBtn_.ImageIndex = 6;
            browseBtn_.Name = "browseBtn_";
            browseBtn_.Size = new System.Drawing.Size(23, 22);
            browseBtn_.ToolTipText = "Browse Address Space";
            browseBtn_.Click += new System.EventHandler(BrowseMI_Click);
            // 
            // aboutBtn_
            // 
            aboutBtn_.ImageIndex = 13;
            aboutBtn_.Name = "aboutBtn_";
            aboutBtn_.Size = new System.Drawing.Size(23, 22);
            aboutBtn_.ToolTipText = "About";
            // 
            // toolBarImageList_
            // 
            toolBarImageList_.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            toolBarImageList_.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolBarImageList_.ImageStream")));
            toolBarImageList_.TransparentColor = System.Drawing.Color.Teal;
            toolBarImageList_.Images.SetKeyName(0, "");
            toolBarImageList_.Images.SetKeyName(1, "");
            toolBarImageList_.Images.SetKeyName(2, "");
            toolBarImageList_.Images.SetKeyName(3, "");
            toolBarImageList_.Images.SetKeyName(4, "");
            toolBarImageList_.Images.SetKeyName(5, "");
            toolBarImageList_.Images.SetKeyName(6, "");
            toolBarImageList_.Images.SetKeyName(7, "");
            toolBarImageList_.Images.SetKeyName(8, "");
            toolBarImageList_.Images.SetKeyName(9, "");
            toolBarImageList_.Images.SetKeyName(10, "");
            toolBarImageList_.Images.SetKeyName(11, "");
            toolBarImageList_.Images.SetKeyName(12, "");
            toolBarImageList_.Images.SetKeyName(13, "");
            // 
            // bottomPn_
            // 
            bottomPn_.Controls.Add(outputCtrl_);
            bottomPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
            bottomPn_.Location = new System.Drawing.Point(3, 526);
            bottomPn_.Name = "bottomPn_";
            bottomPn_.Size = new System.Drawing.Size(1010, 123);
            bottomPn_.TabIndex = 3;
            // 
            // outputCtrl_
            // 
            outputCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            outputCtrl_.Location = new System.Drawing.Point(0, 0);
            outputCtrl_.Name = "outputCtrl_";
            outputCtrl_.Size = new System.Drawing.Size(1010, 123);
            outputCtrl_.TabIndex = 0;
            outputCtrl_.Text = "";
            // 
            // splitterH_
            // 
            splitterH_.Dock = System.Windows.Forms.DockStyle.Bottom;
            splitterH_.Location = new System.Drawing.Point(3, 522);
            splitterH_.Name = "splitterH_";
            splitterH_.Size = new System.Drawing.Size(1010, 4);
            splitterH_.TabIndex = 4;
            splitterH_.TabStop = false;
            // 
            // splitterV_
            // 
            splitterV_.Location = new System.Drawing.Point(319, 52);
            splitterV_.Name = "splitterV_";
            splitterV_.Size = new System.Drawing.Size(4, 470);
            splitterV_.TabIndex = 5;
            splitterV_.TabStop = false;
            // 
            // leftPn_
            // 
            leftPn_.Controls.Add(subscriptionsCtrl_);
            leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
            leftPn_.Location = new System.Drawing.Point(3, 52);
            leftPn_.Name = "leftPn_";
            leftPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            leftPn_.Size = new System.Drawing.Size(316, 470);
            leftPn_.TabIndex = 6;
            // 
            // subscriptionsCtrl_
            // 
            subscriptionsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            subscriptionsCtrl_.Location = new System.Drawing.Point(0, 3);
            subscriptionsCtrl_.Name = "subscriptionsCtrl_";
            subscriptionsCtrl_.Size = new System.Drawing.Size(316, 467);
            subscriptionsCtrl_.TabIndex = 0;
            subscriptionsCtrl_.SubscriptionAction += new Technosoftware.AeSampleClient.SubscriptionsCtrl.SubscriptionActionEventHandler(SubscriptionsCTRL_SubscriptionAction);
            // 
            // rightPn_
            // 
            rightPn_.Controls.Add(eventListCtrl_);
            rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
            rightPn_.Location = new System.Drawing.Point(323, 52);
            rightPn_.Name = "rightPn_";
            rightPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            rightPn_.Size = new System.Drawing.Size(690, 470);
            rightPn_.TabIndex = 7;
            // 
            // eventListCtrl_
            // 
            eventListCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            eventListCtrl_.Location = new System.Drawing.Point(0, 3);
            eventListCtrl_.Name = "eventListCtrl_";
            eventListCtrl_.Size = new System.Drawing.Size(690, 467);
            eventListCtrl_.TabIndex = 0;
            // 
            // selectServerCtrl_
            // 
            selectServerCtrl_.Dock = System.Windows.Forms.DockStyle.Top;
            selectServerCtrl_.Label = "Server";
            selectServerCtrl_.Location = new System.Drawing.Point(3, 25);
            selectServerCtrl_.Name = "selectServerCtrl_";
            selectServerCtrl_.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            selectServerCtrl_.Size = new System.Drawing.Size(1010, 27);
            selectServerCtrl_.TabIndex = 0;
            // 
            // statusCtrl_
            // 
            statusCtrl_.Location = new System.Drawing.Point(3, 649);
            statusCtrl_.Name = "statusCtrl_";
            statusCtrl_.Size = new System.Drawing.Size(1010, 22);
            statusCtrl_.TabIndex = 8;
            // 
            // updateTimerControl_
            // 
            updateTimerControl_.Interval = 10000;
            updateTimerControl_.Tick += new System.EventHandler(UpdateTimerCtrlTick);
            // 
            // separatorT2_
            // 
            separatorT2_.Name = "separatorT2_";
            separatorT2_.Size = new System.Drawing.Size(6, 25);
            // 
            // MainForm
            // 
            AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            ClientSize = new System.Drawing.Size(1016, 671);
            Controls.Add(rightPn_);
            Controls.Add(splitterV_);
            Controls.Add(leftPn_);
            Controls.Add(splitterH_);
            Controls.Add(bottomPn_);
            Controls.Add(selectServerCtrl_);
            Controls.Add(statusCtrl_);
            Controls.Add(toolBar_);
            MainMenuStrip = mainMenu_;
            Name = "MainForm";
            Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            Text = "OPC AE Sample Client";
            mainMenu_.ResumeLayout(false);
            mainMenu_.PerformLayout();
            toolBar_.ResumeLayout(false);
            toolBar_.PerformLayout();
            bottomPn_.ResumeLayout(false);
            leftPn_.ResumeLayout(false);
            rightPn_.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

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
            get { return Application.StartupPath + "\\SampleClients.Ae.config"; }
        }

        /// <summary>
        /// The default web proxy for the application - uses IE settings if null.
        /// </summary>
        private WebProxy mProxy_ = null;

        /// <summary>
        /// The currently active server object.
        /// </summary>
        private TsCAeServer server_ = null;

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

            // use the specified server object directly.
            server_ = (TsCAeServer)server;

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

                // initialize controls.
                selectServerCtrl_.OnConnect(server_);
                statusCtrl_.Start(server_);
                subscriptionsCtrl_.ShowSubscriptions(server_);

                // register for shutdown events.
                server_.ServerShutdownEvent += new OpcServerShutdownEventHandler(Server_ServerShutdown);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "On Connect");
                server_ = null;
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
                if (server_ != null)
                {
                    try { server_.Disconnect(); }
                    catch { }

                    server_.Dispose();
                    server_ = null;
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
            if (server_ == null)
            {
                server_ = (TsCAeServer) new SelectServerDlg().ShowDialog(OpcSpecification.OPC_AE_10);
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
            if (server_ != null) new ServerStatusDlg().ShowDialog(server_);
        }

        /// <summary>
        /// Called when the Server | Browse menu item is clicked.
        /// </summary>
        private void BrowseMI_Click(object sender, EventArgs e)
        {
            try
            {
                new BrowseDlg().ShowDialog(server_, false);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
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
            }
        }

        /// <summary>
        /// Clears the URL history in the drop down menu.
        /// </summary>
        private void ClearHistoryMI_Click(object sender, EventArgs e)
        {
            selectServerCtrl_.Initialize(null, 0, OpcSpecification.OPC_AE_10);
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
                new FiltersViewDlg().ShowDialog(server_);
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
                new CategoriesViewDlg().ShowDialog(server_);
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
                new ConditionsViewDlg().ShowDialog(server_);
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

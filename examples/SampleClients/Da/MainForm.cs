#region Copyright (c) 2011-2022 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2022 Technosoftware GmbH. All rights reserved
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
#endregion Copyright (c) 2011-2022 Technosoftware GmbH. All rights reserved

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
                ApplicationInstance.InitializeSecurity(ApplicationInstance.AuthenticationLevel.Integrity);
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
 
            Icon = ClientUtils.GetAppIcon();
            
			// connect the updates control to the subscriptions control.
			subscriptionCtrl_.SubscriptionModified += new SubscriptionModifiedCallback(updatesCtrl_.OnSubscriptionModified);

			// register for trace/debug output from the updates control.
			updatesCtrl_.UpdateEvent += new UpdateEventEventHandler(OnUpdateEvent);	
			
#if (DEBUG)

			// initialize the set of known servers.
			OpcUrl[] knownUrLs = new OpcUrl[] 
			{
				new OpcUrl("opcda://localhost/Technosoftware.DaSample"),
			};

#else
			// initialize the set of known servers.
			OpcUrl[] knownURLs = new OpcUrl[] 
			{
				new OpcUrl("opcda://localhost/Technosoftware.DaSample"),
			};
#endif

            selectServerCtrl_.Initialize(knownUrLs, 0, OpcSpecification.OPC_DA_20);
			
			LoadSettings();
			
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainMenu_ = new System.Windows.Forms.MenuStrip();
            fileMi_ = new System.Windows.Forms.ToolStripMenuItem();
            exitMi_ = new System.Windows.Forms.ToolStripMenuItem();
            serverMi_ = new System.Windows.Forms.ToolStripMenuItem();
            connectMi_ = new System.Windows.Forms.ToolStripMenuItem();
            disconnecMi_ = new System.Windows.Forms.ToolStripMenuItem();
            separatorS1_ = new System.Windows.Forms.ToolStripMenuItem();
            viewStatusMi_ = new System.Windows.Forms.ToolStripMenuItem();
            browseMi_ = new System.Windows.Forms.ToolStripMenuItem();
            separatorS2_ = new System.Windows.Forms.ToolStripMenuItem();
            readMi_ = new System.Windows.Forms.ToolStripMenuItem();
            writeMi_ = new System.Windows.Forms.ToolStripMenuItem();
            menuItem1_ = new System.Windows.Forms.ToolStripMenuItem();
            outputMi_ = new System.Windows.Forms.ToolStripMenuItem();
            outputClearMi_ = new System.Windows.Forms.ToolStripMenuItem();
            optionsMi_ = new System.Windows.Forms.ToolStripMenuItem();
            clearHistoryMi_ = new System.Windows.Forms.ToolStripMenuItem();
            forceDa20UsageMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            helpMi_ = new System.Windows.Forms.ToolStripMenuItem();
            aboutMi_ = new System.Windows.Forms.ToolStripMenuItem();
            toolBar_ = new System.Windows.Forms.ToolStrip();
            toolBarImageList_ = new System.Windows.Forms.ImageList(components);
            connectBtn_ = new System.Windows.Forms.ToolStripButton();
            disconnectBtn_ = new System.Windows.Forms.ToolStripButton();
            viewStatusBtn_ = new System.Windows.Forms.ToolStripButton();
            browseBtn_ = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            readBtn_ = new System.Windows.Forms.ToolStripButton();
            writeBtn_ = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            aboutBtn_ = new System.Windows.Forms.ToolStripButton();
            bottomPn_ = new System.Windows.Forms.Panel();
            outputCtrl_ = new System.Windows.Forms.RichTextBox();
            splitterH_ = new System.Windows.Forms.Splitter();
            splitterV_ = new System.Windows.Forms.Splitter();
            leftPn_ = new System.Windows.Forms.Panel();
            subscriptionCtrl_ = new SampleClients.Da.Subscription.SubscriptionsTreeCtrl();
            rightPn_ = new System.Windows.Forms.Panel();
            updatesCtrl_ = new SampleClients.Da.UpdatesListViewCtrl();
            updateTimerControl_ = new System.Windows.Forms.Timer(components);
            statusCtrl_ = new SampleClients.Da.Server.ServerStatusCtrl();
            selectServerCtrl_ = new SampleClients.Common.SelectServerCtrl();
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
            browseMi_,
            separatorS2_,
            readMi_,
            writeMi_,
            menuItem1_});
            serverMi_.Name = "serverMi_";
            serverMi_.Size = new System.Drawing.Size(51, 20);
            serverMi_.Text = "&Server";
            // 
            // connectMi_
            // 
            connectMi_.Name = "connectMi_";
            connectMi_.Size = new System.Drawing.Size(134, 22);
            connectMi_.Text = "&Connect";
            connectMi_.Click += new System.EventHandler(ConnectMI_Click);
            // 
            // disconnecMi_
            // 
            disconnecMi_.Name = "disconnecMi_";
            disconnecMi_.Size = new System.Drawing.Size(134, 22);
            disconnecMi_.Text = "&Disconnect";
            disconnecMi_.Click += new System.EventHandler(DisconnectMI_Click);
            // 
            // separatorS1_
            // 
            separatorS1_.Name = "separatorS1_";
            separatorS1_.Size = new System.Drawing.Size(134, 22);
            separatorS1_.Text = "-";
            // 
            // viewStatusMi_
            // 
            viewStatusMi_.Name = "viewStatusMi_";
            viewStatusMi_.Size = new System.Drawing.Size(134, 22);
            viewStatusMi_.Text = "&View Status";
            viewStatusMi_.Click += new System.EventHandler(ViewStatusMI_Click);
            // 
            // browseMi_
            // 
            browseMi_.Name = "browseMi_";
            browseMi_.Size = new System.Drawing.Size(134, 22);
            browseMi_.Text = "&Browse...";
            browseMi_.Click += new System.EventHandler(BrowseMI_Click);
            // 
            // separatorS2_
            // 
            separatorS2_.Name = "separatorS2_";
            separatorS2_.Size = new System.Drawing.Size(134, 22);
            separatorS2_.Text = "-";
            // 
            // readMi_
            // 
            readMi_.Name = "readMi_";
            readMi_.Size = new System.Drawing.Size(134, 22);
            readMi_.Text = "&Read...";
            readMi_.Click += new System.EventHandler(ReadMI_Click);
            // 
            // writeMi_
            // 
            writeMi_.Name = "writeMi_";
            writeMi_.Size = new System.Drawing.Size(134, 22);
            writeMi_.Text = "&Write...";
            writeMi_.Click += new System.EventHandler(WriteMI_Click);
            // 
            // menuItem1_
            // 
            menuItem1_.Name = "menuItem1_";
            menuItem1_.Size = new System.Drawing.Size(134, 22);
            menuItem1_.Text = "-";
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
            clearHistoryMi_,
            forceDa20UsageMenuItem_});
            optionsMi_.Name = "optionsMi_";
            optionsMi_.Size = new System.Drawing.Size(61, 20);
            optionsMi_.Text = "O&ptions";
            // 
            // clearHistoryMi_
            // 
            clearHistoryMi_.Name = "clearHistoryMi_";
            clearHistoryMi_.Size = new System.Drawing.Size(175, 22);
            clearHistoryMi_.Text = "&Clear History";
            clearHistoryMi_.Click += new System.EventHandler(ClearHistoryMI_Click);
            // 
            // forceDa20UsageMenuItem_
            // 
            forceDa20UsageMenuItem_.Name = "forceDa20UsageMenuItem_";
            forceDa20UsageMenuItem_.Size = new System.Drawing.Size(175, 22);
            forceDa20UsageMenuItem_.Text = "&Force DA 2.0 Usage";
            forceDa20UsageMenuItem_.Click += new System.EventHandler(OnForceDa20Usage);
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
            aboutMi_.Click += new System.EventHandler(AboutMI_Click);
            // 
            // toolBar_
            // 
            toolBar_.ImageList = toolBarImageList_;
            toolBar_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            connectBtn_,
            disconnectBtn_,
            viewStatusBtn_,
            browseBtn_,
            toolStripSeparator1,
            readBtn_,
            writeBtn_,
            toolStripSeparator2,
            aboutBtn_});
            toolBar_.Location = new System.Drawing.Point(3, 0);
            toolBar_.Name = "toolBar_";
            toolBar_.Size = new System.Drawing.Size(1010, 25);
            toolBar_.TabIndex = 0;
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // readBtn_
            // 
            readBtn_.ImageIndex = 7;
            readBtn_.Name = "readBtn_";
            readBtn_.Size = new System.Drawing.Size(23, 22);
            readBtn_.ToolTipText = "Read Items";
            readBtn_.Click += new System.EventHandler(ReadMI_Click);
            // 
            // writeBtn_
            // 
            writeBtn_.ImageIndex = 8;
            writeBtn_.Name = "writeBtn_";
            writeBtn_.Size = new System.Drawing.Size(23, 22);
            writeBtn_.ToolTipText = "Write Items";
            writeBtn_.Click += new System.EventHandler(WriteMI_Click);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // aboutBtn_
            // 
            aboutBtn_.ImageIndex = 13;
            aboutBtn_.Name = "aboutBtn_";
            aboutBtn_.Size = new System.Drawing.Size(23, 22);
            aboutBtn_.ToolTipText = "About";
            aboutBtn_.Click += new System.EventHandler(AboutMI_Click);
            // 
            // bottomPn_
            // 
            bottomPn_.Controls.Add(outputCtrl_);
            bottomPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
            bottomPn_.Location = new System.Drawing.Point(3, 463);
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
            splitterH_.Location = new System.Drawing.Point(3, 459);
            splitterH_.Name = "splitterH_";
            splitterH_.Size = new System.Drawing.Size(1010, 4);
            splitterH_.TabIndex = 4;
            splitterH_.TabStop = false;
            // 
            // splitterV_
            // 
            splitterV_.Location = new System.Drawing.Point(319, 52);
            splitterV_.Name = "splitterV_";
            splitterV_.Size = new System.Drawing.Size(4, 407);
            splitterV_.TabIndex = 5;
            splitterV_.TabStop = false;
            // 
            // leftPn_
            // 
            leftPn_.Controls.Add(subscriptionCtrl_);
            leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
            leftPn_.Location = new System.Drawing.Point(3, 52);
            leftPn_.Name = "leftPn_";
            leftPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            leftPn_.Size = new System.Drawing.Size(316, 407);
            leftPn_.TabIndex = 6;
            // 
            // subscriptionCtrl_
            // 
            subscriptionCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            subscriptionCtrl_.Location = new System.Drawing.Point(0, 3);
            subscriptionCtrl_.Name = "subscriptionCtrl_";
            subscriptionCtrl_.Size = new System.Drawing.Size(316, 404);
            subscriptionCtrl_.TabIndex = 0;
            // 
            // rightPn_
            // 
            rightPn_.Controls.Add(updatesCtrl_);
            rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
            rightPn_.Location = new System.Drawing.Point(323, 52);
            rightPn_.Name = "rightPn_";
            rightPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            rightPn_.Size = new System.Drawing.Size(690, 407);
            rightPn_.TabIndex = 7;
            // 
            // updatesCtrl_
            // 
            updatesCtrl_.AllowDrop = true;
            updatesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            updatesCtrl_.Location = new System.Drawing.Point(0, 3);
            updatesCtrl_.Name = "updatesCtrl_";
            updatesCtrl_.Size = new System.Drawing.Size(690, 404);
            updatesCtrl_.TabIndex = 0;
            // 
            // updateTimerControl_
            // 
            updateTimerControl_.Interval = 10000;
            updateTimerControl_.Tick += new System.EventHandler(UpdateTimerCtrlTick);
            // 
            // statusCtrl_
            // 
            statusCtrl_.Location = new System.Drawing.Point(3, 586);
            statusCtrl_.Name = "statusCtrl_";
            statusCtrl_.Size = new System.Drawing.Size(1010, 22);
            statusCtrl_.TabIndex = 8;
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
            // MainForm
            // 
            AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            ClientSize = new System.Drawing.Size(1016, 608);
            Controls.Add(rightPn_);
            Controls.Add(splitterV_);
            Controls.Add(leftPn_);
            Controls.Add(splitterH_);
            Controls.Add(bottomPn_);
            Controls.Add(statusCtrl_);
            Controls.Add(selectServerCtrl_);
            Controls.Add(toolBar_);
            MainMenuStrip = mainMenu_;
            Name = "MainForm";
            Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            Text = "OPC DA Sample Client";
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

			// load server object from config file if it exists. 
			if (File.Exists(mConfigFile_))
			{
				if (OnLoad(false, server.Url)) return;
			}

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

				// save settings.
				SaveSettings();
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
				if (server_ == null) throw new OpcResultException(OpcResult.E_FAIL, "The server is not currently connected.");

				// create the configuartion file.
				stream = new FileStream(mConfigFile_, FileMode.Create, FileAccess.Write, FileShare.None);

				// serialize the server object.
				new BinaryFormatter().Serialize(stream, server_);
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
					OpenFileDialog dialog = new OpenFileDialog();

					dialog.CheckFileExists = true;
					dialog.CheckPathExists = true;
					dialog.DefaultExt      = ".config";
					dialog.Filter          = "Config Files (*.config)|*.config|All Files (*.*)|*.*";
					dialog.Multiselect     = false;
					dialog.ValidateNames   = true;
					dialog.Title           = "Open Server Configuration File";
					dialog.FileName        = mConfigFile_;

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
				TsCCpxComplexTypeCache.Server = server_ = (TsCDaServer)new BinaryFormatter().Deserialize(stream);

				// overrided default url.
				if (url != null)
				{
					server_.Url = url;
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
		/// Saves the current DXConfiguration
		/// </summary>
		private void SaveDxConfiguration()
		{
			Stream stream = null;

			try
			{
				Cursor = Cursors.WaitCursor;

                string configFile = server_.ServerName + ".dxconfig";

				// create the configuartion file.
				stream = new FileStream(configFile, FileMode.Create, FileAccess.Write, FileShare.None);

				// populate the user settings object.
				DxConfiguration configuration = new DxConfiguration();

				configuration.Target        = mTarget_;

				// serialize the user settings object.
				new BinaryFormatter().Serialize(stream, configuration);
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
				UserAppData settings = new UserAppData();

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
				UserAppData settings = (UserAppData)new BinaryFormatter().Deserialize(stream);

				// overrided the current settings.
				if (settings != null)
				{					
					// known urls.
					selectServerCtrl_.Initialize(settings.KnownUrls, settings.SelectedUrl, OpcSpecification.OPC_DA_30);

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
		//	if (e.Button == ReadBTN)       { ReadMI_Click(sender, e);       return; }	
		//	if (e.Button == WriteBTN)      { WriteMI_Click(sender, e);      return; }	
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
		/// Clears the URL history in the drop down menu.
		/// </summary>
		private void ClearHistoryMI_Click(object sender, EventArgs e)
		{
			selectServerCtrl_.Initialize(null, 0, OpcSpecification.OPC_DA_30);
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

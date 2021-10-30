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
using System.Threading;

using SampleClients.Da.Server;
using SampleClients.Da.Subscription;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Da;
using Technosoftware.DaAeHdaClient.Cpx;
using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Utilities;
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
		private SelectServerCtrl selectTargetCtrl_;
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
		private ToolStripButton separatorT2_;
		private ToolStripButton readBtn_;
		private ToolStripButton writeBtn_;
		private ToolStripButton separatorT3_;
		private ToolStripButton aboutBtn_;
		private ToolStripMenuItem outputMi_;
		private ToolStripMenuItem outputClearMi_;
		private ToolStripMenuItem optionsMi_;
		private ToolStripMenuItem clearHistoryMi_;
		private ToolStripMenuItem menuItem1_;
		private System.ComponentModel.IContainer components;
        private ToolStripMenuItem forceDa20UsageMenuItem_;
        private System.Windows.Forms.Timer updateTimerControl_;
		
		[STAThread]
		static void Main() 
		{
            try
			{
                ConfigUtils.EnableTrace(ConfigUtils.GetLogFileDirectory(), "SampleClients.Da.log.txt");

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
			selectTargetCtrl_.Initialize(knownUrLs, 0, OpcSpecification.OPC_DA_30);
			
			LoadSettings();
			
			// register for server connected callbacks.
			selectServerCtrl_.ConnectServer += OnConnect; 
			selectTargetCtrl_.ConnectServer += OnConnectTarget; 
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
            this.connectBtn_ = new System.Windows.Forms.ToolStripButton();
            this.disconnectBtn_ = new System.Windows.Forms.ToolStripButton();
            this.viewStatusBtn_ = new System.Windows.Forms.ToolStripButton();
            this.browseBtn_ = new System.Windows.Forms.ToolStripButton();
            this.separatorT2_ = new System.Windows.Forms.ToolStripButton();
            this.readBtn_ = new System.Windows.Forms.ToolStripButton();
            this.writeBtn_ = new System.Windows.Forms.ToolStripButton();
            this.separatorT3_ = new System.Windows.Forms.ToolStripButton();
            this.aboutBtn_ = new System.Windows.Forms.ToolStripButton();
            this.toolBarImageList_ = new System.Windows.Forms.ImageList(this.components);
            this.bottomPn_ = new System.Windows.Forms.Panel();
            this.outputCtrl_ = new System.Windows.Forms.RichTextBox();
            this.splitterH_ = new System.Windows.Forms.Splitter();
            this.splitterV_ = new System.Windows.Forms.Splitter();
            this.leftPn_ = new System.Windows.Forms.Panel();
            this.subscriptionCtrl_ = new SubscriptionsTreeCtrl();
            this.rightPn_ = new System.Windows.Forms.Panel();
            this.updatesCtrl_ = new UpdatesListViewCtrl();
            this.updateTimerControl_ = new System.Windows.Forms.Timer();
            this.statusCtrl_ = new ServerStatusCtrl();
            this.selectTargetCtrl_ = new SelectServerCtrl();
            this.selectServerCtrl_ = new SelectServerCtrl(); 
            this.bottomPn_.SuspendLayout();
            this.leftPn_.SuspendLayout();
            this.rightPn_.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.mainMenu_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMi_,
            this.serverMi_,
            this.outputMi_,
            this.optionsMi_,
            this.helpMi_});
            // 
            // FileMI
            // 
            this.fileMi_.ImageIndex = 0;
            this.fileMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.exitMi_});
            this.fileMi_.Text = "&File";
            // 
            // ExitMI
            // 
            this.exitMi_.ImageIndex = 0;
            this.exitMi_.Text = "&Exit";
            this.exitMi_.Click += new System.EventHandler(this.ExitMI_Click);
            // 
            // ServerMI
            // 
            this.serverMi_.ImageIndex = 1;
            this.serverMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.connectMi_,
            this.disconnecMi_,
            this.separatorS1_,
            this.viewStatusMi_,
            this.browseMi_,
            this.separatorS2_,
            this.readMi_,
            this.writeMi_,
            this.menuItem1_});
            this.serverMi_.Text = "&Server";
            // 
            // ConnectMI
            // 
            this.connectMi_.ImageIndex = 0;
            this.connectMi_.Text = "&Connect";
            this.connectMi_.Click += new System.EventHandler(this.ConnectMI_Click);
            // 
            // DisconnecMI
            // 
            this.disconnecMi_.ImageIndex = 1;
            this.disconnecMi_.Text = "&Disconnect";
            this.disconnecMi_.Click += new System.EventHandler(this.DisconnectMI_Click);
            // 
            // SeparatorS1
            // 
            this.separatorS1_.ImageIndex = 2;
            this.separatorS1_.Text = "-";
            // 
            // ViewStatusMI
            // 
            this.viewStatusMi_.ImageIndex = 3;
            this.viewStatusMi_.Text = "&View Status";
            this.viewStatusMi_.Click += new System.EventHandler(this.ViewStatusMI_Click);
            // 
            // BrowseMI
            // 
            this.browseMi_.ImageIndex = 4;
            this.browseMi_.Text = "&Browse...";
            this.browseMi_.Click += new System.EventHandler(this.BrowseMI_Click);
            // 
            // SeparatorS2
            // 
            this.separatorS2_.ImageIndex = 5;
            this.separatorS2_.Text = "-";
            // 
            // ReadMI
            // 
            this.readMi_.ImageIndex = 6;
            this.readMi_.Text = "&Read...";
            this.readMi_.Click += new System.EventHandler(this.ReadMI_Click);
            // 
            // WriteMI
            // 
            this.writeMi_.ImageIndex = 7;
            this.writeMi_.Text = "&Write...";
            this.writeMi_.Click += new System.EventHandler(this.WriteMI_Click);
            // 
            // menuItem1
            // 
            this.menuItem1_.ImageIndex = 8;
            this.menuItem1_.Text = "-";
            // 
            // OutputMI
            // 
            this.outputMi_.ImageIndex = 2;
            this.outputMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.outputClearMi_});
            this.outputMi_.Text = "&Output";
            // 
            // OutputClearMI
            // 
            this.outputClearMi_.ImageIndex = 0;
            this.outputClearMi_.Text = "&Clear";
            this.outputClearMi_.Click += new System.EventHandler(this.OutputClearMI_Click);
            // 
            // OptionsMI
            // 
            this.optionsMi_.ImageIndex = 3;
            this.optionsMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.clearHistoryMi_,
            this.forceDa20UsageMenuItem_});
            this.optionsMi_.Text = "O&ptions";
            // 
            // ClearHistoryMI
            // 
            this.clearHistoryMi_.ImageIndex = 0;
            this.clearHistoryMi_.Text = "&Clear History";
            this.clearHistoryMi_.Click += new System.EventHandler(this.ClearHistoryMI_Click);
            // 
            // ForceDa20UsageMenuItem
            // 
            this.forceDa20UsageMenuItem_.ImageIndex = 1;
            this.forceDa20UsageMenuItem_.Text = "&Force DA 2.0 Usage";
            this.forceDa20UsageMenuItem_.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // HelpMI
            // 
            this.helpMi_.ImageIndex = 4;
            this.helpMi_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.aboutMi_});
            this.helpMi_.Text = "&Help";
            // 
            // AboutMI
            // 
            this.aboutMi_.ImageIndex = 0;
            this.aboutMi_.Text = "&About...";
            this.aboutMi_.Click += new System.EventHandler(this.AboutMI_Click);
            // 
            // ToolBar
            // 
            //this.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar_.Items.AddRange(new System.Windows.Forms.ToolStripButton[] {
            this.connectBtn_,
            this.disconnectBtn_,
            this.viewStatusBtn_,
            this.browseBtn_,
            this.separatorT2_,
            this.readBtn_,
            this.writeBtn_,
            this.separatorT3_,
            this.aboutBtn_});
            //this.ToolBar.ButtonSize = new System.Drawing.Size(16, 16);
            //this.ToolBar.DropDownArrows = true;
            this.toolBar_.ImageList = this.toolBarImageList_;
            this.toolBar_.Location = new System.Drawing.Point(3, 0);
            this.toolBar_.Name = "ToolBar";
            //this.ToolBar.ShowToolTips = true;
            this.toolBar_.Size = new System.Drawing.Size(1010, 30);
            this.toolBar_.TabIndex = 0;
            //this.ToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBar_ButtonClick);
            // 
            // ConnectBTN
            // 
            this.connectBtn_.ImageIndex = 0;
            this.connectBtn_.Name = "connectBtn_";
            this.connectBtn_.ToolTipText = "Connect to Server";
            // 
            // DisconnectBTN
            // 
            this.disconnectBtn_.ImageIndex = 1;
            this.disconnectBtn_.Name = "disconnectBtn_";
            this.disconnectBtn_.ToolTipText = "Disconnect from Server";
            // 
            // ViewStatusBTN
            // 
            this.viewStatusBtn_.ImageIndex = 4;
            this.viewStatusBtn_.Name = "viewStatusBtn_";
            this.viewStatusBtn_.ToolTipText = "View Server Status";
            // 
            // BrowseBTN
            // 
            this.browseBtn_.ImageIndex = 6;
            this.browseBtn_.Name = "browseBtn_";
            this.browseBtn_.ToolTipText = "Browse Address Space";
            // 
            // SeparatorT2
            // 
            this.separatorT2_.Name = "separatorT2_";
            //this.SeparatorT2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // ReadBTN
            // 
            this.readBtn_.ImageIndex = 7;
            this.readBtn_.Name = "readBtn_";
            this.readBtn_.ToolTipText = "Read Items";
            // 
            // WriteBTN
            // 
            this.writeBtn_.ImageIndex = 8;
            this.writeBtn_.Name = "writeBtn_";
            this.writeBtn_.ToolTipText = "Write Items";
            // 
            // SeparatorT3
            // 
            this.separatorT3_.Name = "separatorT3_";
            //this.SeparatorT3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // AboutBTN
            // 
            this.aboutBtn_.ImageIndex = 13;
            this.aboutBtn_.Name = "aboutBtn_";
            this.aboutBtn_.ToolTipText = "About";
            // 
            // ToolBarImageList
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
            // BottomPN
            // 
            this.bottomPn_.Controls.Add(this.outputCtrl_);
            this.bottomPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPn_.Location = new System.Drawing.Point(3, 492);
            this.bottomPn_.Name = "BottomPN";
            this.bottomPn_.Size = new System.Drawing.Size(1010, 100);
            this.bottomPn_.TabIndex = 3;
            // 
            // OutputCTRL
            // 
            this.outputCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputCtrl_.Location = new System.Drawing.Point(0, 0);
            this.outputCtrl_.Name = "OutputCTRL";
            this.outputCtrl_.Size = new System.Drawing.Size(1010, 100);
            this.outputCtrl_.TabIndex = 0;
            this.outputCtrl_.Text = "";
            // 
            // SplitterH
            // 
            this.splitterH_.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterH_.Location = new System.Drawing.Point(3, 489);
            this.splitterH_.Name = "SplitterH";
            this.splitterH_.Size = new System.Drawing.Size(1010, 3);
            this.splitterH_.TabIndex = 4;
            this.splitterH_.TabStop = false;
            // 
            // SplitterV
            // 
            this.splitterV_.Location = new System.Drawing.Point(267, 74);
            this.splitterV_.Name = "SplitterV";
            this.splitterV_.Size = new System.Drawing.Size(3, 415);
            this.splitterV_.TabIndex = 5;
            this.splitterV_.TabStop = false;
            // 
            // LeftPN
            // 
            this.leftPn_.Controls.Add(this.subscriptionCtrl_);
            this.leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPn_.Location = new System.Drawing.Point(3, 74);
            this.leftPn_.Name = "LeftPN";
            this.leftPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.leftPn_.Size = new System.Drawing.Size(264, 415);
            this.leftPn_.TabIndex = 6;
            // 
            // SubscriptionCTRL
            // 
            this.subscriptionCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subscriptionCtrl_.Location = new System.Drawing.Point(0, 3);
            this.subscriptionCtrl_.Name = "SubscriptionCTRL";
            this.subscriptionCtrl_.Size = new System.Drawing.Size(264, 412);
            this.subscriptionCtrl_.TabIndex = 0;
            // 
            // RightPN
            // 
            this.rightPn_.Controls.Add(this.updatesCtrl_);
            this.rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPn_.Location = new System.Drawing.Point(270, 74);
            this.rightPn_.Name = "RightPN";
            this.rightPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.rightPn_.Size = new System.Drawing.Size(743, 415);
            this.rightPn_.TabIndex = 7;
            // 
            // UpdatesCTRL
            // 
            this.updatesCtrl_.AllowDrop = true;
            this.updatesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updatesCtrl_.Location = new System.Drawing.Point(0, 3);
            this.updatesCtrl_.Name = "updatesCtrl_";
            this.updatesCtrl_.Size = new System.Drawing.Size(743, 412);
            this.updatesCtrl_.TabIndex = 0;
            // 
            // updateTimerControl_
            // 
            this.updateTimerControl_.Interval = 10000;
            this.updateTimerControl_.Tick += new System.EventHandler(this.UpdateTimerCtrlTick);
            // 
            // StatusCTRL
            // 
            this.statusCtrl_.Location = new System.Drawing.Point(3, 592);
            this.statusCtrl_.Name = "StatusCTRL";
            this.statusCtrl_.Size = new System.Drawing.Size(1010, 16);
            this.statusCtrl_.TabIndex = 8;
            // 
            // SelectTargetCTRL
            // 
            this.selectTargetCtrl_.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectTargetCtrl_.Label = "Target";
            this.selectTargetCtrl_.Location = new System.Drawing.Point(3, 52);
            this.selectTargetCtrl_.Name = "SelectTargetCTRL";
            this.selectTargetCtrl_.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selectTargetCtrl_.Size = new System.Drawing.Size(1010, 22);
            this.selectTargetCtrl_.TabIndex = 0;
            this.selectTargetCtrl_.Visible = false;
            // 
            // SelectServerCTRL
            // 
            this.selectServerCtrl_.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectServerCtrl_.Label = "Server";
            this.selectServerCtrl_.Location = new System.Drawing.Point(3, 30);
            this.selectServerCtrl_.Name = "SelectServerCTRL";
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
            this.Controls.Add(this.selectTargetCtrl_);
            this.Controls.Add(this.selectServerCtrl_);
            this.Controls.Add(this.toolBar_);
            this.MainMenuStrip = this.mainMenu_;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Text = $"OPC DA Sample Client";
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
		private TsCDaServer mTarget_;


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
		/// Called to connect to a target.
		/// </summary>
		public void OnConnectTarget(OpcServer server)
		{
			if (mTarget_ != null)
			{
				mTarget_.Disconnect();
				mTarget_.Dispose();
				mTarget_ = null;
			}

			// use the specified server object directly.
			mTarget_ = (TsCDaServer)server;

			Cursor = Cursors.WaitCursor;
			
			try
			{
				OpcUserIdentity credentials = null;

				do
				{
					try
					{
						mTarget_.Connect(new OpcConnectData(credentials, mProxy_));
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
				mTarget_.SetResultFilters((int)TsCDaResultFilter.All);

				// initialize controls.
				selectTargetCtrl_.OnConnect(mTarget_);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				mTarget_ = null;
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

				// load DX configuration.
				LoadDxConfiguration();

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
		/// Loads the configuration for the current server.
		/// </summary>
		private bool LoadDxConfiguration()
		{
			Stream stream = null;

			try
			{				
				Cursor = Cursors.WaitCursor;

                string configFile = server_.ServerName + ".dxconfig";

				// open configuration file.
				stream = new FileStream(configFile, FileMode.Open, FileAccess.Read, FileShare.Read);
				
				// deserialize the server object.
				DxConfiguration configuration = (DxConfiguration)new BinaryFormatter().Deserialize(stream);

				// overrided the current settings.
				if (configuration != null)
				{					
					configuration.Target.Connect();

					mTarget_      = configuration.Target;

					selectTargetCtrl_.Initialize(new OpcUrl[] { mTarget_.Url }, 0, OpcSpecification.OPC_DA_30);
				}

				// load succeeded.
				return true;
			}
			catch (Exception)
			{
				// ignore errors.
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

		private void TestMI_Click(object sender, EventArgs e)
		{ 
			try
			{
				TsCDaServer server = (TsCDaServer)server_;

				TsCDaItem[] items = new TsCDaItem[100];

				for (int ii = 0; ii < items.Length; ii++)
				{
					items[ii] = new TsCDaItem
                    {
                        ItemName = "Static/ArrayTypes/Object[]",
                        ItemPath = "DA30",
                        ClientHandle = ii
                    };
                }

				TsCDaSubscriptionState state = new TsCDaSubscriptionState
                {
                    Active = true,
                    UpdateRate = 1000
                };

                ITsCDaSubscription subscription = server.CreateSubscription(state);
				Thread.Sleep(100);

				TsCDaItemResult[] results = subscription.AddItems(items);
				Thread.Sleep(100);
				
				subscription.RemoveItems(results);
				Thread.Sleep(100);
					
				server.CancelSubscription(subscription);
				Thread.Sleep(100);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

        #region Event Handlers

        private void UpdateTitle()
        {
            Text = $"{"OPC DA Sample Client"}";
        }

		private void UpdateTimerCtrlTick(object sender, EventArgs e)
		{
			UpdateTitle();
		}
        
        #endregion

        private void menuItem2_Click(object sender, EventArgs e)
        {
            forceDa20UsageMenuItem_.Checked = !forceDa20Usage_;
            forceDa20Usage_ = !forceDa20Usage_;
        }

	}
}

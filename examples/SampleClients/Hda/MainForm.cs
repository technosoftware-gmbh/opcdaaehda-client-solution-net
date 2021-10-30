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
using System.Collections;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

using SampleClients.Common;
using SampleClients.Hda.Common;
using SampleClients.Hda.Item;
using SampleClients.Hda.Server;
using SampleClients.Hda.Trend;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;
using Technosoftware.DaAeHdaClient.Utilities;

using BrowseItemsDlg = SampleClients.Hda.Server.BrowseItemsDlg;

#endregion

namespace SampleClients.Hda
{
    /// <summary>
    /// The main application window for the OPC HDA Sample Application.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MenuStrip mainMenu_;
		private System.Windows.Forms.ToolStripMenuItem fileMi_;
		private System.Windows.Forms.ToolStrip toolBar_;
		private System.Windows.Forms.Panel bottomPn_;
		private System.Windows.Forms.RichTextBox outputCtrl_;
		private System.Windows.Forms.Splitter splitterH_;
		private System.Windows.Forms.Splitter splitterV_;
		private System.Windows.Forms.Panel leftPn_;
		private System.Windows.Forms.Panel rightPn_;
		private SelectServerCtrl selectServerCtrl_;
		private ServerStatusCtrl statusCtrl_;
		private System.Windows.Forms.ToolStripMenuItem exitMi_;
		private System.Windows.Forms.ToolStripMenuItem serverMi_;
		private System.Windows.Forms.ToolStripMenuItem connectMi_;
		private System.Windows.Forms.ToolStripMenuItem disconnecMi_;
		private System.Windows.Forms.ToolStripMenuItem viewStatusMi_;
		private System.Windows.Forms.ToolStripMenuItem separatorS1_;
		private System.Windows.Forms.ToolStripMenuItem helpMi_;
		private System.Windows.Forms.ToolStripMenuItem aboutMi_;
		private System.Windows.Forms.ImageList toolBarImageList_;
		private System.Windows.Forms.ToolStripButton connectBtn_;
		private System.Windows.Forms.ToolStripButton disconnectBtn_;
		private System.Windows.Forms.ToolStripButton viewStatusBtn_;
		private System.Windows.Forms.ToolStripButton browseBtn_;
		private System.Windows.Forms.ToolStripButton aboutBtn_;
		private System.Windows.Forms.ToolStripMenuItem outputMi_;
		private System.Windows.Forms.ToolStripMenuItem outputClearMi_;
		private System.Windows.Forms.ToolStripMenuItem optionsMi_;
		private System.Windows.Forms.ToolStripMenuItem clearHistoryMi_;
		private System.Windows.Forms.ToolStripMenuItem viewAttributesMi_;
		private System.Windows.Forms.ToolStripMenuItem viewAggregatesMi_;
		private System.Windows.Forms.ToolStripMenuItem browseItemsMi_;
		private TrendTreeCtrl trendsCtrl_;
		private ItemValuesCtrl valuesCtrl_;
        private Timer updateTimerControl_;
		private System.ComponentModel.IContainer components;
		
		[STAThread]
		static void Main() 
		{
			try
			{
                ConfigUtils.EnableTrace(ConfigUtils.GetLogFileDirectory(), "SampleClients.Hda.log.txt");

                Application.Run(new MainForm());
			}
			catch (Exception e)
			{
                MessageBox.Show("An unexpected exception occurred. Application exiting.\r\n\r\n" + e.Message, "OPC HDA Sample Client");
			}
		}

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

                        Icon = ClientUtils.GetAppIcon();

			//Technosoftware.DaAeHdaClient.Utilities.Interop.PreserveUTC = true;
 	
#if (DEBUG)

			// initialize the set of known servers.
			OpcUrl[] knownUrLs = new OpcUrl[] 
			{
				new OpcUrl("opchda://localhost/OPCSample.OpcHdaServer")
			};

#else
			// initialize the set of known servers.
			OpcUrl[] knownURLs = new OpcUrl[] 
			{
				new OpcUrl("opchda://localhost/OPCSample.OpcHdaServer")
			};
#endif
            // set the UTC flag.
			// OpcCom.Interop.PreserveUTC = true;
			
			selectServerCtrl_.Initialize(knownUrLs, 0, OpcSpecification.OPC_HDA_10);
			LoadSettings();
			
			// register for server connected callbacks.
			selectServerCtrl_.ConnectServer += new ConnectServer_EventHandler(OnConnect); 
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
            this.viewAttributesMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAggregatesMi_ = new System.Windows.Forms.ToolStripMenuItem();
            this.browseItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
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
            this.trendsCtrl_ = new SampleClients.Hda.Trend.TrendTreeCtrl();
            this.rightPn_ = new System.Windows.Forms.Panel();
            this.valuesCtrl_ = new SampleClients.Hda.Item.ItemValuesCtrl();
            this.selectServerCtrl_ = new SampleClients.Common.SelectServerCtrl();
            this.statusCtrl_ = new SampleClients.Hda.Server.ServerStatusCtrl();
            this.updateTimerControl_ = new System.Windows.Forms.Timer(this.components);
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
            this.viewAttributesMi_,
            this.viewAggregatesMi_,
            this.browseItemsMi_});
            this.serverMi_.Name = "serverMi_";
            this.serverMi_.Size = new System.Drawing.Size(51, 20);
            this.serverMi_.Text = "&Server";
            // 
            // connectMi_
            // 
            this.connectMi_.Name = "connectMi_";
            this.connectMi_.Size = new System.Drawing.Size(171, 22);
            this.connectMi_.Text = "&Connect";
            this.connectMi_.Click += new System.EventHandler(this.ConnectMI_Click);
            // 
            // disconnecMi_
            // 
            this.disconnecMi_.Name = "disconnecMi_";
            this.disconnecMi_.Size = new System.Drawing.Size(171, 22);
            this.disconnecMi_.Text = "&Disconnect";
            this.disconnecMi_.Click += new System.EventHandler(this.DisconnectMI_Click);
            // 
            // separatorS1_
            // 
            this.separatorS1_.Name = "separatorS1_";
            this.separatorS1_.Size = new System.Drawing.Size(171, 22);
            this.separatorS1_.Text = "-";
            // 
            // viewStatusMi_
            // 
            this.viewStatusMi_.Name = "viewStatusMi_";
            this.viewStatusMi_.Size = new System.Drawing.Size(171, 22);
            this.viewStatusMi_.Text = "&View Status...";
            this.viewStatusMi_.Click += new System.EventHandler(this.ViewStatusMI_Click);
            // 
            // viewAttributesMi_
            // 
            this.viewAttributesMi_.Name = "viewAttributesMi_";
            this.viewAttributesMi_.Size = new System.Drawing.Size(171, 22);
            this.viewAttributesMi_.Text = "View &Attributes...";
            this.viewAttributesMi_.Click += new System.EventHandler(this.ViewAttributesMI_Click);
            // 
            // viewAggregatesMi_
            // 
            this.viewAggregatesMi_.Name = "viewAggregatesMi_";
            this.viewAggregatesMi_.Size = new System.Drawing.Size(171, 22);
            this.viewAggregatesMi_.Text = "View A&ggregates...";
            this.viewAggregatesMi_.Click += new System.EventHandler(this.ViewAggregatesMI_Click);
            // 
            // browseItemsMi_
            // 
            this.browseItemsMi_.Name = "browseItemsMi_";
            this.browseItemsMi_.Size = new System.Drawing.Size(171, 22);
            this.browseItemsMi_.Text = "&Browse Items...";
            this.browseItemsMi_.Click += new System.EventHandler(this.BrowseMI_Click);
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
            this.aboutBtn_});
            this.toolBar_.Location = new System.Drawing.Point(0, 0);
            this.toolBar_.Name = "toolBar_";
            this.toolBar_.Size = new System.Drawing.Size(1016, 25);
            this.toolBar_.TabIndex = 0;
            // 
            // connectBtn_
            // 
            this.connectBtn_.ImageIndex = 0;
            this.connectBtn_.Name = "connectBtn_";
            this.connectBtn_.Size = new System.Drawing.Size(23, 22);
            this.connectBtn_.ToolTipText = "Connect to Server";
            // 
            // disconnectBtn_
            // 
            this.disconnectBtn_.ImageIndex = 1;
            this.disconnectBtn_.Name = "disconnectBtn_";
            this.disconnectBtn_.Size = new System.Drawing.Size(23, 22);
            this.disconnectBtn_.ToolTipText = "Disconnect from Server";
            // 
            // viewStatusBtn_
            // 
            this.viewStatusBtn_.ImageIndex = 4;
            this.viewStatusBtn_.Name = "viewStatusBtn_";
            this.viewStatusBtn_.Size = new System.Drawing.Size(23, 22);
            this.viewStatusBtn_.ToolTipText = "View Server Status";
            // 
            // browseBtn_
            // 
            this.browseBtn_.ImageIndex = 6;
            this.browseBtn_.Name = "browseBtn_";
            this.browseBtn_.Size = new System.Drawing.Size(23, 22);
            this.browseBtn_.ToolTipText = "Browse Address Space";
            // 
            // aboutBtn_
            // 
            this.aboutBtn_.ImageIndex = 13;
            this.aboutBtn_.Name = "aboutBtn_";
            this.aboutBtn_.Size = new System.Drawing.Size(23, 22);
            this.aboutBtn_.ToolTipText = "About";
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
            this.bottomPn_.Location = new System.Drawing.Point(0, 568);
            this.bottomPn_.Name = "bottomPn_";
            this.bottomPn_.Size = new System.Drawing.Size(1016, 123);
            this.bottomPn_.TabIndex = 3;
            // 
            // outputCtrl_
            // 
            this.outputCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputCtrl_.Location = new System.Drawing.Point(0, 0);
            this.outputCtrl_.Name = "outputCtrl_";
            this.outputCtrl_.Size = new System.Drawing.Size(1016, 123);
            this.outputCtrl_.TabIndex = 0;
            this.outputCtrl_.Text = "";
            // 
            // splitterH_
            // 
            this.splitterH_.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterH_.Location = new System.Drawing.Point(0, 565);
            this.splitterH_.Name = "splitterH_";
            this.splitterH_.Size = new System.Drawing.Size(1016, 3);
            this.splitterH_.TabIndex = 4;
            this.splitterH_.TabStop = false;
            // 
            // splitterV_
            // 
            this.splitterV_.Location = new System.Drawing.Point(317, 52);
            this.splitterV_.Name = "splitterV_";
            this.splitterV_.Size = new System.Drawing.Size(3, 513);
            this.splitterV_.TabIndex = 5;
            this.splitterV_.TabStop = false;
            // 
            // leftPn_
            // 
            this.leftPn_.Controls.Add(this.trendsCtrl_);
            this.leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPn_.Location = new System.Drawing.Point(0, 52);
            this.leftPn_.Name = "leftPn_";
            this.leftPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.leftPn_.Size = new System.Drawing.Size(317, 513);
            this.leftPn_.TabIndex = 6;
            // 
            // trendsCtrl_
            // 
            this.trendsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trendsCtrl_.Location = new System.Drawing.Point(0, 3);
            this.trendsCtrl_.Name = "trendsCtrl_";
            this.trendsCtrl_.Size = new System.Drawing.Size(317, 510);
            this.trendsCtrl_.TabIndex = 0;
            this.trendsCtrl_.TrendChanged += new SampleClients.Hda.Trend.TrendTreeCtrl.TrendChangedEventHandler(this.TrendsCTRL_TrendChanged);
            this.trendsCtrl_.TrendSelected += new SampleClients.Hda.Trend.TrendTreeCtrl.TrendSelectedEventHandler(this.TrendsCTRL_TrendSelected);
            // 
            // rightPn_
            // 
            this.rightPn_.Controls.Add(this.valuesCtrl_);
            this.rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPn_.Location = new System.Drawing.Point(320, 52);
            this.rightPn_.Name = "rightPn_";
            this.rightPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.rightPn_.Size = new System.Drawing.Size(696, 513);
            this.rightPn_.TabIndex = 7;
            // 
            // valuesCtrl_
            // 
            this.valuesCtrl_.DisplayGraph = true;
            this.valuesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valuesCtrl_.Location = new System.Drawing.Point(0, 3);
            this.valuesCtrl_.Name = "valuesCtrl_";
            this.valuesCtrl_.ReadOnly = false;
            this.valuesCtrl_.Size = new System.Drawing.Size(696, 510);
            this.valuesCtrl_.TabIndex = 0;
            // 
            // selectServerCtrl_
            // 
            this.selectServerCtrl_.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectServerCtrl_.Label = "Server";
            this.selectServerCtrl_.Location = new System.Drawing.Point(0, 25);
            this.selectServerCtrl_.Name = "selectServerCtrl_";
            this.selectServerCtrl_.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selectServerCtrl_.Size = new System.Drawing.Size(1016, 27);
            this.selectServerCtrl_.TabIndex = 0;
            // 
            // statusCtrl_
            // 
            this.statusCtrl_.Location = new System.Drawing.Point(0, 691);
            this.statusCtrl_.Name = "statusCtrl_";
            this.statusCtrl_.Size = new System.Drawing.Size(1016, 22);
            this.statusCtrl_.TabIndex = 8;
            // 
            // updateTimerControl_
            // 
            this.updateTimerControl_.Interval = 10000;
            this.updateTimerControl_.Tick += new System.EventHandler(this.UpdateTimerCtrlTick);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.ClientSize = new System.Drawing.Size(1016, 713);
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
            this.Text = "OPC HDA Sample Client";
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
			public OpcUrl[]  KnownUrls   = null;
			public int    SelectedUrl = -1;
			public string ProxyServer = null;
		}

		/// <summary>
		/// The application configuration file path.
		/// </summary>
		private string ConfigFilePath
		{
			get { return Application.StartupPath + "\\SampleClients.Hda.config"; }
		}

		/// <summary>
		/// The default web proxy for the application - uses IE settings if null.
		/// </summary>
		private WebProxy mProxy_ = null;

		/// <summary>
		/// The currently active server object.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// The path of the current configuration file.
		/// </summary>
		private string mConfigFile_ = null;

		/// <summary>
		/// A table of item results indexed by client handle.
		/// </summary>
		private Hashtable mCache_ = new Hashtable();

		/// <summary>
		/// The client handle of the currently selected item.
		/// </summary>
		private object mSelectedItem_ = null;

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
			mServer_ = (TsCHdaServer)server;

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
				statusCtrl_.Start(mServer_);
				selectServerCtrl_.OnConnect(mServer_);
				trendsCtrl_.Initialize(mServer_);

				// register for shutdown events.
				mServer_.ServerShutdownEvent += new OpcServerShutdownEventHandler(Server_ServerShutdown);

				// save settings.
				SaveSettings();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				mServer_ = null;
			}

			Cursor = Cursors.Default;
		}

		/// <summary>
		/// Called to disconnect from a server.
		/// </summary>
		public void OnDisconnect()
		{
			// disconnect server.
			if (mServer_ != null)
			{
				try	  { mServer_.Disconnect(); }
				catch {}

				mServer_.Dispose();
				mServer_ = null;
			}

			// clear cache.
			mCache_ = new Hashtable();

			// initialize controls.
			statusCtrl_.Start(null);
			trendsCtrl_.Initialize(null);
			valuesCtrl_.Initialize(null, null);
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
		private bool OnLoad(bool prompt, Technosoftware.DaAeHdaClient.OpcUrl url)
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
				mServer_ = (TsCHdaServer)new BinaryFormatter().Deserialize(stream);

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
					selectServerCtrl_.Initialize(settings.KnownUrls, settings.SelectedUrl, OpcSpecification.OPC_HDA_10);

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
		private void LoadMI_Click(object sender, System.EventArgs e)
		{
			OnLoad(true, null); 
		}

		/// <summary>
		/// Called when the File | Save menu item is clicked.
		/// </summary>
		private void SaveMI_Click(object sender, System.EventArgs e)
		{
			OnSave();
		}

		/// <summary>
		/// Called when the File | Exit menu item is clicked.
		/// </summary>
		private void ExitMI_Click(object sender, System.EventArgs e)
		{
			OnDisconnect();
			Close();
		}

		/// <summary>
		/// Called when the Server | Connect menu item is clicked.
		/// </summary>
		private void ConnectMI_Click(object sender, System.EventArgs e)
		{
			OnConnect();
		}

		/// <summary>
		/// Called when the Server | Disconnect menu item is clicked.
		/// </summary>
		private void DisconnectMI_Click(object sender, System.EventArgs e)
		{
			OnDisconnect();
		}

		/// <summary>
		/// Called when the Server | Browse menu item is clicked.
		/// </summary>
		private void ViewStatusMI_Click(object sender, System.EventArgs e)
		{
			if (mServer_ != null) new ServerStatusDlg().ShowDialog(mServer_);
		}

		/// <summary>
		/// Called when the Server | Browse menu item is clicked.
		/// </summary>
		private void BrowseMI_Click(object sender, System.EventArgs e)
		{
			if (mServer_ != null) new BrowseItemsDlg().ShowDialog(mServer_);
		}

		/// <summary>
		/// Called when the Help | About menu item is clicked.
		/// </summary>
		private void AboutMI_Click(object sender, System.EventArgs e)
		{
			OnAbout();
		}

		/// <summary>
		/// Called when the Output | Clear menu item is clicked.
		/// </summary>
		private void OutputClearMI_Click(object sender, System.EventArgs e)
		{
			outputCtrl_.Text = "";
		}

		/// <summary>
		/// Handles changes to the proxy server settings.
		/// </summary>
		private void ProxyServerMI_Click(object sender, System.EventArgs e)
		{
			WebProxy proxy = new ProxyServerDlg().ShowDialog(mProxy_);

			if (proxy != mProxy_)
			{
				mProxy_ = proxy;
				SaveSettings();
			}
		}

		/// <summary>
		/// Clears the URL history in the drop down menu.
		/// </summary>
		private void ClearHistoryMI_Click(object sender, System.EventArgs e)
		{
			selectServerCtrl_.Initialize(null, 0, OpcSpecification.OPC_HDA_10);
			SaveSettings();
		}

		/// <summary>
		/// Displays the set of item attributes for the current server.
		/// </summary>
		private void ViewAttributesMI_Click(object sender, System.EventArgs e)
		{		
			if (mServer_ != null) new AttributesViewDlg().ShowDialog(mServer_);	
		}

		/// <summary>
		/// Displays the set of aggregates for the current server.
		/// </summary>
		private void ViewAggregatesMI_Click(object sender, System.EventArgs e)
		{
			if (mServer_ != null) new AggregateListViewDlg().ShowDialog(mServer_);	
		}

		/// <summary>
		/// Displays data for the current selection in the right pane.
		/// </summary>
		private void TrendsCTRL_TrendSelected(TsCHdaTrend trend, TsCHdaItem item)
		{
			if (trend != null && trend.Items.Count > 0)
			{
				if (item == null)
				{
					item = trend.Items[0];
				}

				if (item.ClientHandle != null)
				{
					valuesCtrl_.Initialize(mServer_, (TsCHdaItemValueCollection)mCache_[item.ClientHandle]);
					mSelectedItem_ = item.ClientHandle;
					return;
				}
			}

			valuesCtrl_.Initialize(mServer_, null);
			mSelectedItem_ = null;
		}

		/// <summary>
		/// Updates the cached values for the items.
		/// </summary>
		private void TrendsCTRL_TrendChanged(TsCHdaTrend trend, TsCHdaItemValueCollection[] values, bool replace)
		{
			// add new values to cache.
			if (values != null && values.Length > 0)
			{
				foreach (TsCHdaItemValueCollection value in values)
				{
					// ignore results without a client handle.
					if (value.ClientHandle == null)
					{
						continue;
					}
					
					// check if results for the item already exist.
					TsCHdaItemValueCollection existingValues = (TsCHdaItemValueCollection)mCache_[value.ClientHandle];

					if (!replace && existingValues != null)
					{
						existingValues.AddRange(value);
					}

					// replace existing or insert new results for the item.
					else
					{
						mCache_[value.ClientHandle] = value;
					}
				}
				
				// update values display if nothing is selected.
				if (mSelectedItem_ == null)
				{
					mSelectedItem_ = values[0].ClientHandle;
					valuesCtrl_.Initialize(mServer_, (TsCHdaItemValueCollection)mCache_[mSelectedItem_]);
				}

				// onluy update values display if current selection changed.
				else
				{
					foreach (OpcItem item in values)
					{
						if (mSelectedItem_.Equals(item.ClientHandle))
						{							
							valuesCtrl_.Initialize(mServer_, (TsCHdaItemValueCollection)mCache_[mSelectedItem_]);
						}
					}
				}
			}

			// clear items from the cache.
			else if (replace)
			{
				foreach (TsCHdaItem item in trend.Items)
				{
					if (item.ClientHandle != null)
					{
						if (item.ClientHandle.Equals(mSelectedItem_))
						{
							valuesCtrl_.Initialize(mServer_, null);
							mSelectedItem_ = null;
						}

						mCache_.Remove(item.ClientHandle);
					}
				}
			}
		}

		/// <summary>
		/// Called when the server sends a shutdown event.
		/// </summary>
		private void Server_ServerShutdown(string reason)
		{
			if (this.InvokeRequired)
			{
				BeginInvoke(new OpcServerShutdownEventHandler(Server_ServerShutdown), new object[] { reason });
				return;
			}

			MessageBox.Show(reason, "Server Shutdown");
			OnDisconnect();
		}

        #region Event Handlers

        private void UpdateTitle()
        {
            Text = String.Format("{0}", "OPC HDA Client SDK .NET Standard Sample Application");
        }

        private void UpdateTimerCtrlTick(object sender, EventArgs e)
        {
            UpdateTitle();
        }

        #endregion
	}
}

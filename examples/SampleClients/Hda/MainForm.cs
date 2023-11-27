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
		private System.ComponentModel.IContainer components_;

        [STAThread]
        static void Main() 
		{
			try
			{
                //ApplicationInstance.InitializeSecurity(ApplicationInstance.AuthenticationLevel.Integrity);
                ApplicationInstance.EnableTrace(ApplicationInstance.GetLogFileDirectory(), "SampleClients.HDa.log");
 
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

                        

			//Technosoftware.DaAeHdaClient.Utilities.Interop.PreserveUTC = true;
 	
#if (DEBUG)

			// initialize the set of known servers.
			var knownUrls = new OpcUrl[] 
			{
				new OpcUrl("opchda://localhost/OPCSample.OpcHdaServer")
			};

#else
			// initialize the set of known servers.
			OpcUrl[] knownUrls = new OpcUrl[] 
			{
				new OpcUrl("opchda://localhost/OPCSample.OpcHdaServer")
			};
#endif
            // set the UTC flag.
            // OpcCom.Interop.PreserveUTC = true;

            selectServerCtrl_.Initialize(knownUrls, 0, OpcSpecification.OPC_HDA_10);
			
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
            viewAttributesMi_ = new System.Windows.Forms.ToolStripMenuItem();
            viewAggregatesMi_ = new System.Windows.Forms.ToolStripMenuItem();
            browseItemsMi_ = new System.Windows.Forms.ToolStripMenuItem();
            outputMi_ = new System.Windows.Forms.ToolStripMenuItem();
            outputClearMi_ = new System.Windows.Forms.ToolStripMenuItem();
            optionsMi_ = new System.Windows.Forms.ToolStripMenuItem();
            clearHistoryMi_ = new System.Windows.Forms.ToolStripMenuItem();
            helpMi_ = new System.Windows.Forms.ToolStripMenuItem();
            aboutMi_ = new System.Windows.Forms.ToolStripMenuItem();
            toolBar_ = new System.Windows.Forms.ToolStrip();
            toolBarImageList_ = new System.Windows.Forms.ImageList(components_);
            connectBtn_ = new System.Windows.Forms.ToolStripButton();
            disconnectBtn_ = new System.Windows.Forms.ToolStripButton();
            viewStatusBtn_ = new System.Windows.Forms.ToolStripButton();
            browseBtn_ = new System.Windows.Forms.ToolStripButton();
            aboutBtn_ = new System.Windows.Forms.ToolStripButton();
            bottomPn_ = new System.Windows.Forms.Panel();
            outputCtrl_ = new System.Windows.Forms.RichTextBox();
            splitterH_ = new System.Windows.Forms.Splitter();
            splitterV_ = new System.Windows.Forms.Splitter();
            leftPn_ = new System.Windows.Forms.Panel();
            trendsCtrl_ = new SampleClients.Hda.Trend.TrendTreeCtrl();
            rightPn_ = new System.Windows.Forms.Panel();
            valuesCtrl_ = new SampleClients.Hda.Item.ItemValuesCtrl();
            selectServerCtrl_ = new SampleClients.Common.SelectServerCtrl();
            statusCtrl_ = new SampleClients.Hda.Server.ServerStatusCtrl();
            updateTimerControl_ = new System.Windows.Forms.Timer(components_);
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
            viewAttributesMi_,
            viewAggregatesMi_,
            browseItemsMi_});
            serverMi_.Name = "serverMi_";
            serverMi_.Size = new System.Drawing.Size(51, 20);
            serverMi_.Text = "&Server";
            // 
            // connectMi_
            // 
            connectMi_.Name = "connectMi_";
            connectMi_.Size = new System.Drawing.Size(171, 22);
            connectMi_.Text = "&Connect";
            connectMi_.Click += new System.EventHandler(ConnectMI_Click);
            // 
            // disconnecMi_
            // 
            disconnecMi_.Name = "disconnecMi_";
            disconnecMi_.Size = new System.Drawing.Size(171, 22);
            disconnecMi_.Text = "&Disconnect";
            disconnecMi_.Click += new System.EventHandler(DisconnectMI_Click);
            // 
            // separatorS1_
            // 
            separatorS1_.Name = "separatorS1_";
            separatorS1_.Size = new System.Drawing.Size(171, 22);
            separatorS1_.Text = "-";
            // 
            // viewStatusMi_
            // 
            viewStatusMi_.Name = "viewStatusMi_";
            viewStatusMi_.Size = new System.Drawing.Size(171, 22);
            viewStatusMi_.Text = "&View Status...";
            viewStatusMi_.Click += new System.EventHandler(ViewStatusMI_Click);
            // 
            // viewAttributesMi_
            // 
            viewAttributesMi_.Name = "viewAttributesMi_";
            viewAttributesMi_.Size = new System.Drawing.Size(171, 22);
            viewAttributesMi_.Text = "View &Attributes...";
            viewAttributesMi_.Click += new System.EventHandler(ViewAttributesMI_Click);
            // 
            // viewAggregatesMi_
            // 
            viewAggregatesMi_.Name = "viewAggregatesMi_";
            viewAggregatesMi_.Size = new System.Drawing.Size(171, 22);
            viewAggregatesMi_.Text = "View A&ggregates...";
            viewAggregatesMi_.Click += new System.EventHandler(ViewAggregatesMI_Click);
            // 
            // browseItemsMi_
            // 
            browseItemsMi_.Name = "browseItemsMi_";
            browseItemsMi_.Size = new System.Drawing.Size(171, 22);
            browseItemsMi_.Text = "&Browse Items...";
            browseItemsMi_.Click += new System.EventHandler(BrowseMI_Click);
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
            aboutBtn_});
            toolBar_.Location = new System.Drawing.Point(0, 0);
            toolBar_.Name = "toolBar_";
            toolBar_.Size = new System.Drawing.Size(1016, 25);
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
            // aboutBtn_
            // 
            aboutBtn_.ImageIndex = 13;
            aboutBtn_.Name = "aboutBtn_";
            aboutBtn_.Size = new System.Drawing.Size(23, 22);
            aboutBtn_.ToolTipText = "About";
            // 
            // bottomPn_
            // 
            bottomPn_.Controls.Add(outputCtrl_);
            bottomPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
            bottomPn_.Location = new System.Drawing.Point(0, 568);
            bottomPn_.Name = "bottomPn_";
            bottomPn_.Size = new System.Drawing.Size(1016, 123);
            bottomPn_.TabIndex = 3;
            // 
            // outputCtrl_
            // 
            outputCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            outputCtrl_.Location = new System.Drawing.Point(0, 0);
            outputCtrl_.Name = "outputCtrl_";
            outputCtrl_.Size = new System.Drawing.Size(1016, 123);
            outputCtrl_.TabIndex = 0;
            outputCtrl_.Text = "";
            // 
            // splitterH_
            // 
            splitterH_.Dock = System.Windows.Forms.DockStyle.Bottom;
            splitterH_.Location = new System.Drawing.Point(0, 565);
            splitterH_.Name = "splitterH_";
            splitterH_.Size = new System.Drawing.Size(1016, 3);
            splitterH_.TabIndex = 4;
            splitterH_.TabStop = false;
            // 
            // splitterV_
            // 
            splitterV_.Location = new System.Drawing.Point(317, 52);
            splitterV_.Name = "splitterV_";
            splitterV_.Size = new System.Drawing.Size(3, 513);
            splitterV_.TabIndex = 5;
            splitterV_.TabStop = false;
            // 
            // leftPn_
            // 
            leftPn_.Controls.Add(trendsCtrl_);
            leftPn_.Dock = System.Windows.Forms.DockStyle.Left;
            leftPn_.Location = new System.Drawing.Point(0, 52);
            leftPn_.Name = "leftPn_";
            leftPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            leftPn_.Size = new System.Drawing.Size(317, 513);
            leftPn_.TabIndex = 6;
            // 
            // trendsCtrl_
            // 
            trendsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            trendsCtrl_.Location = new System.Drawing.Point(0, 3);
            trendsCtrl_.Name = "trendsCtrl_";
            trendsCtrl_.Size = new System.Drawing.Size(317, 510);
            trendsCtrl_.TabIndex = 0;
            trendsCtrl_.TrendChanged += new SampleClients.Hda.Trend.TrendTreeCtrl.TrendChangedEventHandler(TrendsCTRL_TrendChanged);
            trendsCtrl_.TrendSelected += new SampleClients.Hda.Trend.TrendTreeCtrl.TrendSelectedEventHandler(TrendsCTRL_TrendSelected);
            // 
            // rightPn_
            // 
            rightPn_.Controls.Add(valuesCtrl_);
            rightPn_.Dock = System.Windows.Forms.DockStyle.Fill;
            rightPn_.Location = new System.Drawing.Point(320, 52);
            rightPn_.Name = "rightPn_";
            rightPn_.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            rightPn_.Size = new System.Drawing.Size(696, 513);
            rightPn_.TabIndex = 7;
            // 
            // valuesCtrl_
            // 
            valuesCtrl_.DisplayGraph = true;
            valuesCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
            valuesCtrl_.Location = new System.Drawing.Point(0, 3);
            valuesCtrl_.Name = "valuesCtrl_";
            valuesCtrl_.ReadOnly = false;
            valuesCtrl_.Size = new System.Drawing.Size(696, 510);
            valuesCtrl_.TabIndex = 0;
            // 
            // selectServerCtrl_
            // 
            selectServerCtrl_.Dock = System.Windows.Forms.DockStyle.Top;
            selectServerCtrl_.Label = "Server";
            selectServerCtrl_.Location = new System.Drawing.Point(0, 25);
            selectServerCtrl_.Name = "selectServerCtrl_";
            selectServerCtrl_.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            selectServerCtrl_.Size = new System.Drawing.Size(1016, 27);
            selectServerCtrl_.TabIndex = 0;
            // 
            // statusCtrl_
            // 
            statusCtrl_.Location = new System.Drawing.Point(0, 691);
            statusCtrl_.Name = "statusCtrl_";
            statusCtrl_.Size = new System.Drawing.Size(1016, 22);
            statusCtrl_.TabIndex = 8;
            // 
            // updateTimerControl_
            // 
            updateTimerControl_.Interval = 10000;
            updateTimerControl_.Tick += new System.EventHandler(UpdateTimerCtrlTick);
            // 
            // MainForm
            // 
            AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            ClientSize = new System.Drawing.Size(1016, 713);
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
            Text = "OPC HDA Sample Client";
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
		private WebProxy proxy_ = null;

		/// <summary>
		/// The currently active server object.
		/// </summary>
		private TsCHdaServer server_ = null;

		/// <summary>
		/// The path of the current configuration file.
		/// </summary>
		private string configFile_ = null;

		/// <summary>
		/// A table of item results indexed by client handle.
		/// </summary>
		private Hashtable cache_ = new Hashtable();

		/// <summary>
		/// The client handle of the currently selected item.
		/// </summary>
		private object selectedItem_ = null;

		/// <summary>
		/// Called to connect to a server.
		/// </summary>
		public void OnConnect(OpcServer server)
		{
			// disconnect from the current server.
			OnDisconnect();

			// create a default file name for the server.
            configFile_ = $"{server.ServerName}.config";

			// use the specified server object directly.
			server_ = (TsCHdaServer)server;

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
						server_.Connect(new OpcConnectData(credentials, proxy_));
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
				statusCtrl_.Start(server_);
				selectServerCtrl_.OnConnect(server_);
				trendsCtrl_.Initialize(server_);

				// register for shutdown events.
				server_.ServerShutdownEvent += new OpcServerShutdownEventHandler(Server_ServerShutdown);

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				server_ = null;
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
				server_ = null;
			}

			// clear cache.
			cache_ = new Hashtable();

			// initialize controls.
			statusCtrl_.Start(null);
			trendsCtrl_.Initialize(null);
			valuesCtrl_.Initialize(null, null);
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
		//	if (e.Button == AboutBTN)      { OnAbout();                     return; }	
		//}

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
            if (server_ == null)
            {
                server_ = (TsCHdaServer)new SelectServerDlg().ShowDialog(OpcSpecification.OPC_HDA_10);
            }
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
			if (server_ != null) new ServerStatusDlg().ShowDialog(server_);
		}

		/// <summary>
		/// Called when the Server | Browse menu item is clicked.
		/// </summary>
		private void BrowseMI_Click(object sender, System.EventArgs e)
		{
			if (server_ != null) new BrowseItemsDlg().ShowDialog(server_);
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
			var proxy = new ProxyServerDlg().ShowDialog(proxy_);

			if (proxy != proxy_)
			{
				proxy_ = proxy;
			}
		}

		/// <summary>
		/// Clears the URL history in the drop down menu.
		/// </summary>
		private void ClearHistoryMI_Click(object sender, System.EventArgs e)
		{
			selectServerCtrl_.Initialize(null, 0, OpcSpecification.OPC_HDA_10);
		}

		/// <summary>
		/// Displays the set of item attributes for the current server.
		/// </summary>
		private void ViewAttributesMI_Click(object sender, System.EventArgs e)
		{		
			if (server_ != null) new AttributesViewDlg().ShowDialog(server_);	
		}

		/// <summary>
		/// Displays the set of aggregates for the current server.
		/// </summary>
		private void ViewAggregatesMI_Click(object sender, System.EventArgs e)
		{
			if (server_ != null) new AggregateListViewDlg().ShowDialog(server_);	
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
					valuesCtrl_.Initialize(server_, (TsCHdaItemValueCollection)cache_[item.ClientHandle]);
					selectedItem_ = item.ClientHandle;
					return;
				}
			}

			valuesCtrl_.Initialize(server_, null);
			selectedItem_ = null;
		}

		/// <summary>
		/// Updates the cached values for the items.
		/// </summary>
		private void TrendsCTRL_TrendChanged(TsCHdaTrend trend, TsCHdaItemValueCollection[] values, bool replace)
		{
			// add new values to cache.
			if (values != null && values.Length > 0)
			{
				foreach (var value in values)
				{
					// ignore results without a client handle.
					if (value.ClientHandle == null)
					{
						continue;
					}
					
					// check if results for the item already exist.
					var existingValues = (TsCHdaItemValueCollection)cache_[value.ClientHandle];

					if (!replace && existingValues != null)
					{
						existingValues.AddRange(value);
					}

					// replace existing or insert new results for the item.
					else
					{
						cache_[value.ClientHandle] = value;
					}
				}
				
				// update values display if nothing is selected.
				if (selectedItem_ == null)
				{
					selectedItem_ = values[0].ClientHandle;
					valuesCtrl_.Initialize(server_, (TsCHdaItemValueCollection)cache_[selectedItem_]);
				}

				// onluy update values display if current selection changed.
				else
				{
					foreach (OpcItem item in values)
					{
						if (selectedItem_.Equals(item.ClientHandle))
						{							
							valuesCtrl_.Initialize(server_, (TsCHdaItemValueCollection)cache_[selectedItem_]);
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
						if (item.ClientHandle.Equals(selectedItem_))
						{
							valuesCtrl_.Initialize(server_, null);
							selectedItem_ = null;
						}

						cache_.Remove(item.ClientHandle);
					}
				}
			}
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

        private void UpdateTitle()
        {
            Text = $"{"OPC HDA Sample Client"}";
        }

        private void UpdateTimerCtrlTick(object sender, EventArgs e)
        {
            UpdateTitle();
        }

        #endregion
	}
}

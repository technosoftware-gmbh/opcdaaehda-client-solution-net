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

using Technosoftware.DaAeHdaClient;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// Use to receive notifications when a the connect server button is clicked.
    /// </summary>
    public delegate void ConnectServer_EventHandler(OpcServer server);

	/// <summary>
	/// A control used browse and select a single OPC server. 
	/// </summary>
	public class SelectServerCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Button ConnectBTN;
		private System.Windows.Forms.Label ServerUrlLB;
		private System.Windows.Forms.ComboBox ServerUrlCB;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SelectServerCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            ConnectBTN = new System.Windows.Forms.Button();
            ServerUrlLB = new System.Windows.Forms.Label();
            ServerUrlCB = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // ConnectBTN
            // 
            ConnectBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            ConnectBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ConnectBTN.Location = new System.Drawing.Point(712, 0);
            ConnectBTN.Name = "ConnectBTN";
            ConnectBTN.Size = new System.Drawing.Size(75, 21);
            ConnectBTN.TabIndex = 0;
            ConnectBTN.Text = "Connect";
            ConnectBTN.Click += new System.EventHandler(ConnectBTN_Click);
            // 
            // ServerUrlLB
            // 
            ServerUrlLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left)));
            ServerUrlLB.Location = new System.Drawing.Point(0, 0);
            ServerUrlLB.Name = "ServerUrlLB";
            ServerUrlLB.Size = new System.Drawing.Size(40, 21);
            ServerUrlLB.TabIndex = 1;
            ServerUrlLB.Text = "Server";
            ServerUrlLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServerUrlCB
            // 
            ServerUrlCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            ServerUrlCB.Location = new System.Drawing.Point(48, 0);
            ServerUrlCB.Name = "ServerUrlCB";
            ServerUrlCB.Size = new System.Drawing.Size(656, 21);
            ServerUrlCB.TabIndex = 2;
            ServerUrlCB.SelectedIndexChanged += new System.EventHandler(ServerUrlCB_SelectedIndexChanged);
            // 
            // SelectServerCtrl
            // 
            Controls.Add(ServerUrlCB);
            Controls.Add(ServerUrlLB);
            Controls.Add(ConnectBTN);
            Name = "SelectServerCtrl";
            Size = new System.Drawing.Size(788, 22);
            ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// Called when a server is connected.
		/// </summary>
		public event ConnectServer_EventHandler ConnectServer;

		/// <summary>
		/// The label displayed in the control.
		/// </summary>
		public string Label
		{
			get { return ServerUrlLB.Text;  }
			set { ServerUrlLB.Text = value; }
		}

		/// <summary>
		/// The specification to use when browsing for servers.
		/// </summary>
		private OpcSpecification m_specification = OpcSpecification.OPC_DA_20;

		/// <summary>
		/// Initializes the control with a set of known urls.
		/// </summary>
		public void Initialize(OpcUrl[] knownUrls, int selectedIndex, OpcSpecification specification)
		{
			// store the default specification.
			m_specification = specification;

			// clear the existing items.
			ServerUrlCB.Items.Clear();

			// add a 'special' item that shows the browse servers dialog.
			ServerUrlCB.Items.Add("<Browse...>");
			
			// add known urls.
			if (knownUrls != null && knownUrls.Length > 0) 
			{
				ServerUrlCB.Items.AddRange(knownUrls);
			}

			// update the selection.
			if (selectedIndex < ServerUrlCB.Items.Count-1)
			{
				ServerUrlCB.SelectedIndex = (selectedIndex != -1)?selectedIndex+1:1;
			}
		}

		/// <summary>
		/// Returns the set of known urls.
		/// </summary>
		public OpcUrl[] GetKnownURLs(out int selectedUrl)
		{
			selectedUrl = -1;

			ArrayList knownUrls = new ArrayList();

			foreach (object url in ServerUrlCB.Items)
			{
				if (url.GetType() == typeof(OpcUrl))
				{
					if (url.Equals(ServerUrlCB.SelectedItem))
					{
						selectedUrl = knownUrls.Count;
					}

					knownUrls.Add(url);
				}
			}

			return (OpcUrl[])knownUrls.ToArray(typeof(OpcUrl));
		}

		/// <summary>
		/// Adds/selects the server in the combo box and connects to the server.
		/// </summary>
		public void Connect()
		{
			OpcUrl url = null;

			// get the url from the select or from the text.
			object selection = ServerUrlCB.SelectedItem;
			
			if (selection != null && selection.GetType() == typeof(OpcUrl))
			{
				url = (OpcUrl)selection;
			}
			else
			{
				url = new OpcUrl(ServerUrlCB.Text);
			}

			// create an unconnected server object.
			OpcServer server = Factory.GetServerForURL(url);

			// invoke the connect server callback.
			if (server != null)
			{
				if (ConnectServer != null) { ConnectServer(server); }
			}
		}

		/// <summary>
		/// Adds/selects the specified server in the combo box.
		/// </summary>
		public void OnConnect(OpcServer server)
		{
			// check if the server url already exists.
			int index = ServerUrlCB.FindStringExact(server.Url.ToString());

			// add url if it does not exist.
			if (index == -1)
			{
				index = 1;
				ServerUrlCB.Items.Insert(index, server.Url);
			}

			// select the new url.
			ServerUrlCB.SelectedIndex = index;
		}

		/// <summary>
		/// Displays the select server dialog if the "Browse..." item was selected.
		/// </summary>
		private void ServerUrlCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			object selection = ServerUrlCB.SelectedItem;

			if (selection != null && selection.GetType() == typeof(string))
			{
				OpcServer server = new SelectServerDlg().ShowDialog(m_specification);
					
				// invoke the connect server callback.
				if (server != null)
				{
					if (ConnectServer != null) 
					{ 
						try   { ConnectServer(server); }
						catch { ServerUrlCB.SelectedItem = null; }
					}
				}
			}
		}

		/// <summary>
		/// Connects to the server and raises an event if successful.
		/// </summary>
		private void ConnectBTN_Click(object sender, System.EventArgs e)
		{
			try  
			{ 
				Connect(); 
			}
			catch (Exception)
			{ 
				ServerUrlCB.SelectedItem = null; 
			}
		}
	}
}

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

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Server
{
	/// <summary>
	/// A control that periodically gets the server status and shows the results.
	/// </summary>
	public class ServerStatusCtrl : System.Windows.Forms.StatusStrip
	{
		private System.Windows.Forms.Timer updateTimer_;
		private System.Windows.Forms.ToolStripStatusLabel infoPn_;
		private System.Windows.Forms.ToolStripStatusLabel statePn_;
		private System.Windows.Forms.ToolStripStatusLabel timePn_;

		private System.ComponentModel.IContainer components = null;

		public ServerStatusCtrl()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			updateTimer_ = new System.Windows.Forms.Timer(components);
			infoPn_ = new System.Windows.Forms.ToolStripStatusLabel();
			statePn_ = new System.Windows.Forms.ToolStripStatusLabel();
			timePn_ = new System.Windows.Forms.ToolStripStatusLabel();
			// 
			// UpdateTimer
			// 
			updateTimer_.Interval = 30000;
			updateTimer_.Tick += new System.EventHandler(UpdateTimer_Tick);
			// 
			// InfoPN
			// 
			//this.InfoPN.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			//this.InfoPN.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			infoPn_.Width = 10;
			// 
			// StatePN
			// 
			//this.StatePN.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			statePn_.Width = 10;
			// 
			// TimePN
			// 
			//this.TimePN.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			timePn_.Width = 10;
			// 
			// ServerStatusCtrl
			// 
			Items.AddRange(new System.Windows.Forms.ToolStripStatusLabel[] {
																			   infoPn_,
																			   statePn_,
																			   timePn_});

		}
		#endregion

		/// <summary>
		/// The server being polled for its current status.
		/// </summary>
		private TsCHdaServer mServer_ = null;

		/// <summary>
		/// Begins polling the status of the server.
		/// </summary>
		public void Start(TsCHdaServer server)
		{
			mServer_ = server;

			if (mServer_ == null)
			{
				updateTimer_.Enabled = false;
				//ShowPanels = false;
				Text = "Server not connected.";
			}
			else
			{
				updateTimer_.Enabled = true;
				UpdateTimer_Tick(this, null);
			}
		}

		/// <summary>
		/// Stoppes polling the server for its status.
		/// </summary>
		public void Stop()
		{
			Start(null);
		}

		/// <summary>
		/// Called when the update timer expires - begins a get status request.
		/// </summary>
		private void UpdateTimer_Tick(object sender, System.EventArgs e)
		{
			try
			{
				OpcGetStatusDelegate callback = new OpcGetStatusDelegate(mServer_.GetServerStatus);
				callback.BeginInvoke(new AsyncCallback(OnGetStatus), callback);
			}
			catch (Exception exception)
			{
				//ShowPanels = false;
				Text = exception.Message;
			}
		}

		/// <summary>
		/// Completes an asynchronous get status request and updates the control.
		/// </summary>
		private void OnGetStatus(IAsyncResult result)
		{
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnGetStatus), result);
                return;
            }

			try
			{
				OpcGetStatusDelegate callback = (OpcGetStatusDelegate)result.AsyncState;

				OpcServerStatus status = callback.EndInvoke(result);

				//ShowPanels   = true;
				infoPn_.Text  = status.VendorInfo;
				statePn_.Text = (status.StatusInfo == null)?status.ServerState.ToString():status.StatusInfo;
				timePn_.Text  = status.CurrentTime.ToString();
			}
			catch (Exception e)
			{
				//ShowPanels = false;
				Text = e.Message;
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////
	#region Delegate Declarations

	/// <summary>
	/// The asynchronous delegate for GetStatus.
	/// </summary>
	public delegate OpcServerStatus OpcGetStatusDelegate();

	#endregion

}


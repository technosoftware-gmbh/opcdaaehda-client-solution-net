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

namespace SampleClients.Da
{
    /// <summary>
    /// A dialog used to send an asynchronous read or write request.
    /// </summary>
    public class AsyncRequestDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Panel topPn_;
		private ResultListViewCtrl resultsCtrl_;
		private System.Windows.Forms.Button goBtn_;
		private System.Windows.Forms.Button stopBtn_;
		private System.ComponentModel.IContainer components = null;

		public AsyncRequestDlg()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();
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
			this.okBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.goBtn_ = new System.Windows.Forms.Button();
			this.stopBtn_ = new System.Windows.Forms.Button();
			this.topPn_ = new System.Windows.Forms.Panel();
			this.resultsCtrl_ = new ResultListViewCtrl();
			this.buttonsPn_.SuspendLayout();
			this.topPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
			this.okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn_.Location = new System.Drawing.Point(5, 8);
			this.okBtn_.Name = "okBtn_";
			this.okBtn_.TabIndex = 1;
			this.okBtn_.Text = "OK";
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(392, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Controls.Add(this.goBtn_);
			this.buttonsPn_.Controls.Add(this.stopBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 202);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(472, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// GoBTN
			// 
			this.goBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.goBtn_.Location = new System.Drawing.Point(200, 8);
			this.goBtn_.Name = "goBtn_";
			this.goBtn_.TabIndex = 2;
			this.goBtn_.Text = "Go";
			this.goBtn_.Click += new System.EventHandler(this.GoBTN_Click);
			// 
			// StopBTN
			// 
			this.stopBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.stopBtn_.Location = new System.Drawing.Point(200, 8);
			this.stopBtn_.Name = "stopBtn_";
			this.stopBtn_.TabIndex = 3;
			this.stopBtn_.Text = "Stop";
			this.stopBtn_.Click += new System.EventHandler(this.StopBTN_Click);
			// 
			// TopPN
			// 
			this.topPn_.Controls.Add(this.resultsCtrl_);
			this.topPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.topPn_.DockPadding.Bottom = 4;
			this.topPn_.DockPadding.Left = 4;
			this.topPn_.DockPadding.Right = 4;
			this.topPn_.DockPadding.Top = 4;
			this.topPn_.Location = new System.Drawing.Point(0, 0);
			this.topPn_.Name = "topPn_";
			this.topPn_.Size = new System.Drawing.Size(472, 202);
			this.topPn_.TabIndex = 1;
			// 
			// ResultsCTRL
			// 
			this.resultsCtrl_.AllowDrop = true;
			this.resultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultsCtrl_.Location = new System.Drawing.Point(4, 4);
			this.resultsCtrl_.Name = "resultsCtrl_";
			this.resultsCtrl_.Size = new System.Drawing.Size(464, 194);
			this.resultsCtrl_.TabIndex = 0;
			// 
			// AsyncRequestDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 238);
			this.Controls.Add(this.topPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "AsyncRequestDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Asynchronous Request";
			this.buttonsPn_.ResumeLayout(false);
			this.topPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The subscription used to process the request.
		/// </summary>
		private TsCDaSubscription mSubscription_ = null;
	
		/// <summary>
		/// The items used for a read operation.
		/// </summary>
		private TsCDaItem[] mItems_ = null;

		/// <summary>
		/// The values used for a write operation.
		/// </summary>
		private TsCDaItemValue[] mValues_ = null;

		/// <summary>
		/// The results of the operation.
		/// </summary>
		private OpcItem[] mResults_ = null;

		/// <summary>
		/// The current request being executed.
		/// </summary>
		IOpcRequest mRequest_ = null;

		/// <summary>
		/// The current request id being executed.
		/// </summary>
		int mHandle_ = 0;

		/// <summary>
		/// Executes an asynchronous read and displays the results.
		/// </summary>
		public TsCDaItemValueResult[] ShowDialog(TsCDaSubscription subscription, TsCDaItem[] items)
		{
			if (subscription == null) throw new ArgumentNullException("subscription");

			mSubscription_ = subscription;
			mItems_        = items;
			mValues_       = null;
			mResults_      = null;

			BeginRequest();

			// show dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// return results.
			return (TsCDaItemValueResult[])mResults_;
		}

		/// <summary>
		/// Executes an asynchronous read and displays the results.
		/// </summary>
		public OpcItemResult[] ShowDialog(TsCDaSubscription subscription, TsCDaItemValue[] values)
		{
			if (subscription == null) throw new ArgumentNullException("subscription");

			mSubscription_ = subscription;
			mItems_        = null;
			mValues_       = values;
			mResults_      = null;

			BeginRequest();

			// show dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// return results.
			return (OpcItemResult[])mResults_;
		}

		/// <summary>
		/// Begins the asynchronous request.
		/// </summary>
		private void BeginRequest()
		{
			try
			{				
				mRequest_ = null;

				// begin the asynchronous read request.
				if (mItems_ != null)
				{
					mSubscription_.Read(mItems_, ++mHandle_, new TsCDaReadCompleteEventHandler(OnReadComplete), out mRequest_);
				}				

				// begin the asynchronous write request.
				else if (mValues_ != null)
				{
                    mSubscription_.Write(mValues_, ++mHandle_, new TsCDaWriteCompleteEventHandler(OnWriteComplete), out mRequest_);
				}

				// update controls if request successful.
				if (mRequest_ != null)
				{
					okBtn_.Enabled     = false;
					cancelBtn_.Enabled = false;
					goBtn_.Visible     = false;
					stopBtn_.Visible   = true;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Cancels the asynchronous request.
		/// </summary>
		private void CancelRequest()
		{
			try
			{
				if (mRequest_ != null)
				{
					mSubscription_.Cancel(mRequest_, new TsCDaCancelCompleteEventHandler(OnCancelComplete));
				}				
			}
			catch (Exception e)
			{
				mRequest_ = null;

				okBtn_.Enabled     = true;
				cancelBtn_.Enabled = true;
				goBtn_.Visible     = true;
				stopBtn_.Visible   = false;

				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Called when an asynchronous read request completes.
		/// </summary>
		private void OnReadComplete(object clientHandle, TsCDaItemValueResult[] results)
		{
			try
			{
				if (InvokeRequired)
				{
					BeginInvoke(new TsCDaReadCompleteEventHandler(OnReadComplete), new object[] { clientHandle, results });
					return;
				}

				if (!mHandle_.Equals(clientHandle))
				{
					return;
				}
			
				resultsCtrl_.Initialize(mSubscription_.Server, null, results);

				mRequest_ = null;
				mResults_ = results;

				okBtn_.Enabled     = true;
				cancelBtn_.Enabled = true;
				goBtn_.Visible     = true;
				stopBtn_.Visible   = false;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Called when an asynchronous write request completes.
		/// </summary>
		private void OnWriteComplete(object clientHandle, OpcItemResult[] results)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new TsCDaWriteCompleteEventHandler(OnWriteComplete), new object[] { clientHandle, results });
				return;
			}

			if (!mHandle_.Equals(clientHandle))
			{
				return;
			}

			resultsCtrl_.Initialize(mSubscription_.Server, null, results);

			mRequest_ = null;
			mResults_ = results;

			okBtn_.Enabled     = true;
			cancelBtn_.Enabled = true;
			goBtn_.Visible     = true;
			stopBtn_.Visible   = false;
		}
		
		/// <summary>
		/// Displays a dialog indicating the request was cancelled successfully.
		/// </summary>
		private void OnCancelComplete(object clientHandle)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new TsCDaCancelCompleteEventHandler(OnCancelComplete), new object[] { clientHandle });
				return;
			}

			if (!mHandle_.Equals(clientHandle))
			{
				return;
			}
			
			MessageBox.Show("Request cancelled successfully.");
			
			okBtn_.Enabled     = true;
			cancelBtn_.Enabled = true;
			goBtn_.Visible     = true;
			stopBtn_.Visible   = false;
		}

		/// <summary>
		/// Called to stop an active asynchronous request.
		/// </summary>
		private void StopBTN_Click(object sender, System.EventArgs e)
		{
			CancelRequest();
		}

		/// <summary>
		/// Called to start a new asynchronous request.
		/// </summary>
		private void GoBTN_Click(object sender, System.EventArgs e)
		{
			BeginRequest();
		}
	}
}

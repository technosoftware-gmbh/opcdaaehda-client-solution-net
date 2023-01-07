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
			okBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			buttonsPn_ = new System.Windows.Forms.Panel();
			goBtn_ = new System.Windows.Forms.Button();
			stopBtn_ = new System.Windows.Forms.Button();
			topPn_ = new System.Windows.Forms.Panel();
			resultsCtrl_ = new ResultListViewCtrl();
			buttonsPn_.SuspendLayout();
			topPn_.SuspendLayout();
			SuspendLayout();
			// 
			// OkBTN
			// 
			okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			okBtn_.Location = new System.Drawing.Point(5, 8);
			okBtn_.Name = "okBtn_";
			okBtn_.TabIndex = 1;
			okBtn_.Text = "OK";
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(392, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Controls.Add(goBtn_);
			buttonsPn_.Controls.Add(stopBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 202);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(472, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// GoBTN
			// 
			goBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			goBtn_.Location = new System.Drawing.Point(200, 8);
			goBtn_.Name = "goBtn_";
			goBtn_.TabIndex = 2;
			goBtn_.Text = "Go";
			goBtn_.Click += new System.EventHandler(GoBTN_Click);
			// 
			// StopBTN
			// 
			stopBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			stopBtn_.Location = new System.Drawing.Point(200, 8);
			stopBtn_.Name = "stopBtn_";
			stopBtn_.TabIndex = 3;
			stopBtn_.Text = "Stop";
			stopBtn_.Click += new System.EventHandler(StopBTN_Click);
			// 
			// TopPN
			// 
			topPn_.Controls.Add(resultsCtrl_);
			topPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			topPn_.DockPadding.Bottom = 4;
			topPn_.DockPadding.Left = 4;
			topPn_.DockPadding.Right = 4;
			topPn_.DockPadding.Top = 4;
			topPn_.Location = new System.Drawing.Point(0, 0);
			topPn_.Name = "topPn_";
			topPn_.Size = new System.Drawing.Size(472, 202);
			topPn_.TabIndex = 1;
			// 
			// ResultsCTRL
			// 
			resultsCtrl_.AllowDrop = true;
			resultsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			resultsCtrl_.Location = new System.Drawing.Point(4, 4);
			resultsCtrl_.Name = "resultsCtrl_";
			resultsCtrl_.Size = new System.Drawing.Size(464, 194);
			resultsCtrl_.TabIndex = 0;
			// 
			// AsyncRequestDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(472, 238);
			Controls.Add(topPn_);
			Controls.Add(buttonsPn_);
			Name = "AsyncRequestDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Asynchronous Request";
			buttonsPn_.ResumeLayout(false);
			topPn_.ResumeLayout(false);
			ResumeLayout(false);

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

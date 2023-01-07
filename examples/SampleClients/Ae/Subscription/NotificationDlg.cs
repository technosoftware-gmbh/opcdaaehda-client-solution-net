#region Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
// Web: http://www.technosoftware.com 
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved

using SampleClients.Common;
using System;
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A dialog that displays the current status of an OPC server.
    /// </summary>
    public class NotificationDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Panel leftPn_;
		private Technosoftware.AeSampleClient.NotificationCtrl notificationCtrl_;
		private System.Windows.Forms.Button acknowledgeBtn_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public NotificationDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
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
			buttonsPn_ = new System.Windows.Forms.Panel();
			acknowledgeBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			leftPn_ = new System.Windows.Forms.Panel();
			notificationCtrl_ = new Technosoftware.AeSampleClient.NotificationCtrl();
			buttonsPn_.SuspendLayout();
			leftPn_.SuspendLayout();
			SuspendLayout();
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(acknowledgeBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 474);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(552, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// AcknowledgeBTN
			// 
			acknowledgeBtn_.Location = new System.Drawing.Point(4, 8);
			acknowledgeBtn_.Name = "acknowledgeBtn_";
			acknowledgeBtn_.Size = new System.Drawing.Size(92, 23);
			acknowledgeBtn_.TabIndex = 0;
			acknowledgeBtn_.Text = "Acknowledge";
			acknowledgeBtn_.Click += new System.EventHandler(AcknowledgeBTN_Click);
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(472, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 1;
			cancelBtn_.Text = "Close";
			cancelBtn_.Click += new System.EventHandler(CancelBTN_Click);
			// 
			// LeftPN
			// 
			leftPn_.Controls.Add(notificationCtrl_);
			leftPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			leftPn_.DockPadding.Left = 4;
			leftPn_.DockPadding.Right = 4;
			leftPn_.DockPadding.Top = 4;
			leftPn_.Location = new System.Drawing.Point(0, 0);
			leftPn_.Name = "leftPn_";
			leftPn_.Size = new System.Drawing.Size(552, 474);
			leftPn_.TabIndex = 1;
			// 
			// NotificationCTRL
			// 
			notificationCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			notificationCtrl_.Location = new System.Drawing.Point(4, 4);
			notificationCtrl_.Name = "notificationCtrl_";
			notificationCtrl_.Size = new System.Drawing.Size(544, 470);
			notificationCtrl_.TabIndex = 0;
			// 
			// NotificationDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = cancelBtn_;
			ClientSize = new System.Drawing.Size(552, 510);
			Controls.Add(leftPn_);
			Controls.Add(buttonsPn_);
			MaximizeBox = false;
			MinimumSize = new System.Drawing.Size(0, 180);
			Name = "NotificationDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "View Condition State";
			buttonsPn_.ResumeLayout(false);
			leftPn_.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private TsCAeSubscription mSubscription_ = null;
		private TsCAeEventNotification mNotification_ = null;
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the event notifications.
		/// </summary>
		public void ShowDialog(TsCAeSubscription subscription, TsCAeEventNotification notification)
		{
			if (subscription == null) throw new ArgumentNullException("subscription");

			mSubscription_ = subscription;
			mNotification_ = notification;

			acknowledgeBtn_.Enabled = notification.AckRequired;

			notificationCtrl_.ShowNotification(subscription, notification);

			ShowDialog();
		}
		#endregion

		#region Private Methods
		#endregion

		#region Event Handlers
		/// <summary>
		/// Closes the window.
		/// </summary>
		private void CancelBTN_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Acknowledges an event.
		/// </summary>
		private void AcknowledgeBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				bool result = new AcknowledgerEditDlg().ShowDialog(mSubscription_.Server, new TsCAeEventNotification[] { mNotification_ });

				if (result)
				{
					acknowledgeBtn_.Enabled = false;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}		
		}
		#endregion


	}
}

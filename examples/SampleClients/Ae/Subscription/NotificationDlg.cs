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
            Icon = ClientUtils.GetAppIcon();
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
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.acknowledgeBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.leftPn_ = new System.Windows.Forms.Panel();
			this.notificationCtrl_ = new Technosoftware.AeSampleClient.NotificationCtrl();
			this.buttonsPn_.SuspendLayout();
			this.leftPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.acknowledgeBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 474);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(552, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// AcknowledgeBTN
			// 
			this.acknowledgeBtn_.Location = new System.Drawing.Point(4, 8);
			this.acknowledgeBtn_.Name = "acknowledgeBtn_";
			this.acknowledgeBtn_.Size = new System.Drawing.Size(92, 23);
			this.acknowledgeBtn_.TabIndex = 0;
			this.acknowledgeBtn_.Text = "Acknowledge";
			this.acknowledgeBtn_.Click += new System.EventHandler(this.AcknowledgeBTN_Click);
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(472, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 1;
			this.cancelBtn_.Text = "Close";
			this.cancelBtn_.Click += new System.EventHandler(this.CancelBTN_Click);
			// 
			// LeftPN
			// 
			this.leftPn_.Controls.Add(this.notificationCtrl_);
			this.leftPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPn_.DockPadding.Left = 4;
			this.leftPn_.DockPadding.Right = 4;
			this.leftPn_.DockPadding.Top = 4;
			this.leftPn_.Location = new System.Drawing.Point(0, 0);
			this.leftPn_.Name = "leftPn_";
			this.leftPn_.Size = new System.Drawing.Size(552, 474);
			this.leftPn_.TabIndex = 1;
			// 
			// NotificationCTRL
			// 
			this.notificationCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.notificationCtrl_.Location = new System.Drawing.Point(4, 4);
			this.notificationCtrl_.Name = "notificationCtrl_";
			this.notificationCtrl_.Size = new System.Drawing.Size(544, 470);
			this.notificationCtrl_.TabIndex = 0;
			// 
			// NotificationDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(552, 510);
			this.Controls.Add(this.leftPn_);
			this.Controls.Add(this.buttonsPn_);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(0, 180);
			this.Name = "NotificationDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "View Condition State";
			this.buttonsPn_.ResumeLayout(false);
			this.leftPn_.ResumeLayout(false);
			this.ResumeLayout(false);

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

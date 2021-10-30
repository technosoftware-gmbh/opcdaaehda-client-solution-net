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
using System.Text;
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A dialog that displays the current status of an OPC server.
    /// </summary>
    public class AcknowledgerEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Label acknowledgerLb_;
		private System.Windows.Forms.TextBox acknowledgerTb_;
		private System.Windows.Forms.Label commentLb_;
		private System.Windows.Forms.TextBox commentTb_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public AcknowledgerEditDlg()
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
			this.acknowledgerLb_ = new System.Windows.Forms.Label();
			this.acknowledgerTb_ = new System.Windows.Forms.TextBox();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.okBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.commentLb_ = new System.Windows.Forms.Label();
			this.commentTb_ = new System.Windows.Forms.TextBox();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// AcknowledgerLB
			// 
			this.acknowledgerLb_.Location = new System.Drawing.Point(4, 4);
			this.acknowledgerLb_.Name = "acknowledgerLb_";
			this.acknowledgerLb_.Size = new System.Drawing.Size(100, 20);
			this.acknowledgerLb_.TabIndex = 1;
			this.acknowledgerLb_.Text = "Acknowledger ID";
			this.acknowledgerLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AcknowledgerTB
			// 
			this.acknowledgerTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.acknowledgerTb_.Location = new System.Drawing.Point(96, 4);
			this.acknowledgerTb_.Name = "acknowledgerTb_";
			this.acknowledgerTb_.Size = new System.Drawing.Size(296, 20);
			this.acknowledgerTb_.TabIndex = 2;
			this.acknowledgerTb_.Text = "";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 50);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(400, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// OkBTN
			// 
			this.okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn_.Location = new System.Drawing.Point(4, 8);
			this.okBtn_.Name = "okBtn_";
			this.okBtn_.TabIndex = 1;
			this.okBtn_.Text = "OK";
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(320, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// CommentLB
			// 
			this.commentLb_.Location = new System.Drawing.Point(4, 28);
			this.commentLb_.Name = "commentLb_";
			this.commentLb_.Size = new System.Drawing.Size(84, 20);
			this.commentLb_.TabIndex = 3;
			this.commentLb_.Text = "Comment";
			this.commentLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CommentTB
			// 
			this.commentTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.commentTb_.Location = new System.Drawing.Point(96, 28);
			this.commentTb_.Name = "commentTb_";
			this.commentTb_.Size = new System.Drawing.Size(296, 20);
			this.commentTb_.TabIndex = 4;
			this.commentTb_.Text = "";
			// 
			// AcknowledgerEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(400, 86);
			this.Controls.Add(this.commentTb_);
			this.Controls.Add(this.commentLb_);
			this.Controls.Add(this.acknowledgerTb_);
			this.Controls.Add(this.buttonsPn_);
			this.Controls.Add(this.acknowledgerLb_);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(312, 0);
			this.Name = "AcknowledgerEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Acknowledge Event";
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to provide a comment before acknowledging a group of events.
		/// </summary>
		public bool ShowDialog(TsCAeServer server, TsCAeEventNotification[] notifications)
		{
			// prompt user to provide a comment.
			acknowledgerTb_.Text = Environment.UserName;
			commentTb_.Text      = "Acknowledged.";

			if (ShowDialog() != DialogResult.OK)
			{
				return false;
			}

			try
			{
				// create acknowledgements.
				TsCAeEventAcknowledgement[] acknowledgements = new TsCAeEventAcknowledgement[notifications.Length];

				for (int ii = 0; ii < notifications.Length; ii++)
				{					
					acknowledgements[ii] = new TsCAeEventAcknowledgement(notifications[ii]);
				}

				// acknowledge events.
				OpcResult[] results = server.AcknowledgeCondition(
					acknowledgerTb_.Text,
					commentTb_.Text,
					acknowledgements);

				// check for errors.
				StringBuilder errors = new StringBuilder();

				for (int ii = 0; ii < results.Length; ii++)
				{				
					if (results[ii].Failed())
					{			
						if (errors.Length > 0)
						{
							errors.Append(Environment.NewLine);
						}

						errors.Append(acknowledgements[ii].SourceName);
						errors.Append("/");
						errors.Append(acknowledgements[ii].ConditionName);
						errors.Append(" Failed: ");
						errors.Append(results[ii].ToString());
						errors.Append(".");
					}
				}

				// show errors.
				if (errors.Length > 0)
				{
					MessageBox.Show(errors.ToString(), "Acknowledgement Failed");
				}
				
				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			return false;
		}
		#endregion

	}
}

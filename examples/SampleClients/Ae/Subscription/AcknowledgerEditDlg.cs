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
			acknowledgerLb_ = new System.Windows.Forms.Label();
			acknowledgerTb_ = new System.Windows.Forms.TextBox();
			buttonsPn_ = new System.Windows.Forms.Panel();
			okBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			commentLb_ = new System.Windows.Forms.Label();
			commentTb_ = new System.Windows.Forms.TextBox();
			buttonsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// AcknowledgerLB
			// 
			acknowledgerLb_.Location = new System.Drawing.Point(4, 4);
			acknowledgerLb_.Name = "acknowledgerLb_";
			acknowledgerLb_.Size = new System.Drawing.Size(100, 20);
			acknowledgerLb_.TabIndex = 1;
			acknowledgerLb_.Text = "Acknowledger ID";
			acknowledgerLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AcknowledgerTB
			// 
			acknowledgerTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			acknowledgerTb_.Location = new System.Drawing.Point(96, 4);
			acknowledgerTb_.Name = "acknowledgerTb_";
			acknowledgerTb_.Size = new System.Drawing.Size(296, 20);
			acknowledgerTb_.TabIndex = 2;
			acknowledgerTb_.Text = "";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 50);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(400, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// OkBTN
			// 
			okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			okBtn_.Location = new System.Drawing.Point(4, 8);
			okBtn_.Name = "okBtn_";
			okBtn_.TabIndex = 1;
			okBtn_.Text = "OK";
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(320, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// CommentLB
			// 
			commentLb_.Location = new System.Drawing.Point(4, 28);
			commentLb_.Name = "commentLb_";
			commentLb_.Size = new System.Drawing.Size(84, 20);
			commentLb_.TabIndex = 3;
			commentLb_.Text = "Comment";
			commentLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CommentTB
			// 
			commentTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			commentTb_.Location = new System.Drawing.Point(96, 28);
			commentTb_.Name = "commentTb_";
			commentTb_.Size = new System.Drawing.Size(296, 20);
			commentTb_.TabIndex = 4;
			commentTb_.Text = "";
			// 
			// AcknowledgerEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = cancelBtn_;
			ClientSize = new System.Drawing.Size(400, 86);
			Controls.Add(commentTb_);
			Controls.Add(commentLb_);
			Controls.Add(acknowledgerTb_);
			Controls.Add(buttonsPn_);
			Controls.Add(acknowledgerLb_);
			MaximizeBox = false;
			MinimumSize = new System.Drawing.Size(312, 0);
			Name = "AcknowledgerEditDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Acknowledge Event";
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

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

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
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A dialog that displays the current status of an OPC server.
    /// </summary>
    public class EventTypesSelectDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private Technosoftware.DaAeHdaClient.SampleClient.BitMaskCtrl filtersCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public EventTypesSelectDlg()
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
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.filtersCtrl_ = new Technosoftware.DaAeHdaClient.SampleClient.BitMaskCtrl();
			this.buttonsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 110);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(242, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(84, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Close";
			// 
			// FiltersCTRL
			// 
			this.filtersCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.filtersCtrl_.Location = new System.Drawing.Point(0, 0);
			this.filtersCtrl_.Name = "filtersCtrl_";
			this.filtersCtrl_.ReadOnly = false;
			this.filtersCtrl_.Size = new System.Drawing.Size(242, 110);
			this.filtersCtrl_.TabIndex = 1;
			this.filtersCtrl_.Type = null;
			this.filtersCtrl_.Value = 0;
			// 
			// EventTypesSelectDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(242, 146);
			this.Controls.Add(this.filtersCtrl_);
			this.Controls.Add(this.buttonsPn_);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(600, 216);
			this.MinimumSize = new System.Drawing.Size(250, 180);
			this.Name = "EventTypesSelectDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Event Types";
			this.buttonsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to select one or more event types.
		/// </summary>
		public new int ShowDialog()
		{
			filtersCtrl_.Type  = typeof(TsCAeEventType);
			filtersCtrl_.Value = (int)TsCAeEventType.All;

			if (base.ShowDialog() == DialogResult.OK)
			{
				return filtersCtrl_.Value;
			}

			return 0;
		}
		#endregion
	}
}

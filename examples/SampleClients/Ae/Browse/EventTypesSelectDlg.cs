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
			cancelBtn_ = new System.Windows.Forms.Button();
			filtersCtrl_ = new Technosoftware.DaAeHdaClient.SampleClient.BitMaskCtrl();
			buttonsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 110);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(242, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(84, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Close";
			// 
			// FiltersCTRL
			// 
			filtersCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			filtersCtrl_.Location = new System.Drawing.Point(0, 0);
			filtersCtrl_.Name = "filtersCtrl_";
			filtersCtrl_.ReadOnly = false;
			filtersCtrl_.Size = new System.Drawing.Size(242, 110);
			filtersCtrl_.TabIndex = 1;
			filtersCtrl_.Type = null;
			filtersCtrl_.Value = 0;
			// 
			// EventTypesSelectDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = cancelBtn_;
			ClientSize = new System.Drawing.Size(242, 146);
			Controls.Add(filtersCtrl_);
			Controls.Add(buttonsPn_);
			MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(600, 216);
			MinimumSize = new System.Drawing.Size(250, 180);
			Name = "EventTypesSelectDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Select Event Types";
			buttonsPn_.ResumeLayout(false);
			ResumeLayout(false);

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

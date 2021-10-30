#region Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
// Web: https://www.technosoftware.com 
// 
// The source code in this file is covered under a dual-license scenario:
//   - Owner of a purchased license: SCLA 1.0
//   - GPL V3: everybody else
//
// SCLA license terms accompanied with this source code.
// See SCLA 1.0://technosoftware.com/license/Source_Code_License_Agreement.pdf
//
// GNU General Public License as published by the Free Software Foundation;
// version 3 of the License are accompanied with this source code.
// See https://technosoftware.com/license/GPLv3License.txt
//
// This source code is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
// or FITNESS FOR A PARTICULAR PURPOSE.
// 
// The Software is based on the OPC .NET API Sample Code.
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved

#region Using Directives

using System;
using System.Windows.Forms;

using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Trend
{
    /// <summary>
    /// A dialog used to modify the parameters of an item.
    /// </summary>
    public class SubscriptionEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Panel mainPn_;
		private TrendEditCtrl trendCtrl_;
		private System.ComponentModel.IContainer components = null;

		public SubscriptionEditDlg()
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
			this.mainPn_ = new System.Windows.Forms.Panel();
			this.trendCtrl_ = new TrendEditCtrl();
			this.buttonsPn_.SuspendLayout();
			this.mainPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
			this.okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
			this.cancelBtn_.Location = new System.Drawing.Point(248, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 146);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(328, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// MainPN
			// 
			this.mainPn_.Controls.Add(this.trendCtrl_);
			this.mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPn_.DockPadding.Left = 4;
			this.mainPn_.DockPadding.Right = 4;
			this.mainPn_.DockPadding.Top = 4;
			this.mainPn_.Location = new System.Drawing.Point(0, 0);
			this.mainPn_.Name = "mainPn_";
			this.mainPn_.Size = new System.Drawing.Size(328, 146);
			this.mainPn_.TabIndex = 32;
			// 
			// TrendCTRL
			// 
			this.trendCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trendCtrl_.Location = new System.Drawing.Point(4, 4);
			this.trendCtrl_.Name = "trendCtrl_";
			this.trendCtrl_.RequestType = RequestType.PlaybackProcessed;
			this.trendCtrl_.Size = new System.Drawing.Size(320, 142);
			this.trendCtrl_.TabIndex = 0;
			// 
			// SubscriptionEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 182);
			this.Controls.Add(this.mainPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "SubscriptionEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Subscription";
			this.buttonsPn_.ResumeLayout(false);
			this.mainPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the user to edit the properties of a trend.
		/// </summary>
		public bool ShowDialog(TsCHdaTrend trend, RequestType type)
		{
			if (trend == null) throw new ArgumentNullException("trend");
			
			// initialize the controls.
			trendCtrl_.Initialize(trend, type);

			// adjust dialog height.
			Height -= (buttonsPn_.Top - mainPn_.Height);

			// show the dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return false;
			}

			// update the trend.
			trendCtrl_.Update(trend);

			return true;
		}
	}
}

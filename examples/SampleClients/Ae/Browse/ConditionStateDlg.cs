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
    public class ConditionStateDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Panel leftPn_;
		private System.Windows.Forms.Button refreshBtn_;
		private Technosoftware.AeSampleClient.ConditionStateCtrl conditionCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ConditionStateDlg()
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
			this.refreshBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.leftPn_ = new System.Windows.Forms.Panel();
			this.conditionCtrl_ = new Technosoftware.AeSampleClient.ConditionStateCtrl();
			this.buttonsPn_.SuspendLayout();
			this.leftPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.refreshBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 474);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(552, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// RefreshBTN
			// 
			this.refreshBtn_.Location = new System.Drawing.Point(4, 8);
			this.refreshBtn_.Name = "refreshBtn_";
			this.refreshBtn_.TabIndex = 1;
			this.refreshBtn_.Text = "Refresh";
			this.refreshBtn_.Click += new System.EventHandler(this.RefreshBTN_Click);
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(472, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Close";
			this.cancelBtn_.Click += new System.EventHandler(this.CancelBTN_Click);
			// 
			// LeftPN
			// 
			this.leftPn_.Controls.Add(this.conditionCtrl_);
			this.leftPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPn_.DockPadding.Left = 4;
			this.leftPn_.DockPadding.Right = 4;
			this.leftPn_.DockPadding.Top = 4;
			this.leftPn_.Location = new System.Drawing.Point(0, 0);
			this.leftPn_.Name = "leftPn_";
			this.leftPn_.Size = new System.Drawing.Size(552, 474);
			this.leftPn_.TabIndex = 2;
			// 
			// ConditionCTRL
			// 
			this.conditionCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.conditionCtrl_.Location = new System.Drawing.Point(4, 4);
			this.conditionCtrl_.Name = "conditionCtrl_";
			this.conditionCtrl_.Size = new System.Drawing.Size(544, 470);
			this.conditionCtrl_.TabIndex = 0;
			// 
			// ConditionStateDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(552, 510);
			this.Controls.Add(this.leftPn_);
			this.Controls.Add(this.buttonsPn_);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(0, 180);
			this.Name = "ConditionStateDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "View Condition State";
			this.buttonsPn_.ResumeLayout(false);
			this.leftPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private TsCAeServer mServer_ = null;
		private string mSource_ = null;
		private string mCondition_ = null;
		private Technosoftware.DaAeHdaClient.Ae.TsCAeAttribute[] mAttributes_ = null;
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the condition state for specified source and condition.
		/// </summary>
		public void ShowDialog(TsCAeServer server, string source, string condition)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_    = server;
			mSource_    = source;
			mCondition_ = condition;
			
			// find attributes for condition.
			FindAttributes();
			
			// get the current enabled state.
			ShowCondition();

			// show the dialog.
			Show();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Fetches the condition state
		/// </summary>
		private void ShowCondition()
		{
			try
			{
				// build attribute list.
				int[] attributeIDs = new int[mAttributes_.Length];

				for (int ii = 0; ii < mAttributes_.Length; ii++)
				{
					attributeIDs[ii] = mAttributes_[ii].ID;
				}

				// fetch condition state.
				TsCAeCondition condition = mServer_.GetConditionState(mSource_, mCondition_, attributeIDs);
					
				// show condition.
				conditionCtrl_.ShowCondition(mAttributes_, condition);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "GetConditionState");
			}
		}

		/// <summary>
		/// Find attributes for condition by searching all categories.
		/// </summary>
		private void FindAttributes()
		{
			try
			{
				Technosoftware.DaAeHdaClient.Ae.TsCAeCategory[] categories = mServer_.QueryEventCategories((int)TsCAeEventType.Condition);

				for (int ii = 0; ii < categories.Length; ii++)
				{
					// fetch conditions for category.
					string[] conditions = mServer_.QueryConditionNames(categories[ii].ID);

					// check if this is the category containing the current condition.
					bool found = false;

					for (int jj = 0; jj < conditions.Length; jj++)
					{
						if (conditions[jj] == mCondition_)
						{
							found = true;
							break;
						}
					}

					// fetch the attributes when found.
					if (found)
					{
						mAttributes_ = mServer_.QueryEventAttributes(categories[ii].ID);
						break;
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return;
			}
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Closes the window.
		/// </summary>
		private void CancelBTN_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Re-reads the enabled states for the areas and sources.
		/// </summary>
		private void RefreshBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				ShowCondition();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion

	}
}

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
			refreshBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			leftPn_ = new System.Windows.Forms.Panel();
			conditionCtrl_ = new Technosoftware.AeSampleClient.ConditionStateCtrl();
			buttonsPn_.SuspendLayout();
			leftPn_.SuspendLayout();
			SuspendLayout();
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(refreshBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 474);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(552, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// RefreshBTN
			// 
			refreshBtn_.Location = new System.Drawing.Point(4, 8);
			refreshBtn_.Name = "refreshBtn_";
			refreshBtn_.TabIndex = 1;
			refreshBtn_.Text = "Refresh";
			refreshBtn_.Click += new System.EventHandler(RefreshBTN_Click);
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(472, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Close";
			cancelBtn_.Click += new System.EventHandler(CancelBTN_Click);
			// 
			// LeftPN
			// 
			leftPn_.Controls.Add(conditionCtrl_);
			leftPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			leftPn_.DockPadding.Left = 4;
			leftPn_.DockPadding.Right = 4;
			leftPn_.DockPadding.Top = 4;
			leftPn_.Location = new System.Drawing.Point(0, 0);
			leftPn_.Name = "leftPn_";
			leftPn_.Size = new System.Drawing.Size(552, 474);
			leftPn_.TabIndex = 2;
			// 
			// ConditionCTRL
			// 
			conditionCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			conditionCtrl_.Location = new System.Drawing.Point(4, 4);
			conditionCtrl_.Name = "conditionCtrl_";
			conditionCtrl_.Size = new System.Drawing.Size(544, 470);
			conditionCtrl_.TabIndex = 0;
			// 
			// ConditionStateDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = cancelBtn_;
			ClientSize = new System.Drawing.Size(552, 510);
			Controls.Add(leftPn_);
			Controls.Add(buttonsPn_);
			MaximizeBox = false;
			MinimumSize = new System.Drawing.Size(0, 180);
			Name = "ConditionStateDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "View Condition State";
			buttonsPn_.ResumeLayout(false);
			leftPn_.ResumeLayout(false);
			ResumeLayout(false);

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

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

using System.Collections;

using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da.Subscription
{
    /// <summary>
    /// A dialog used to edit the state of a list of subscriptions.
    /// </summary>
    public class SubscriptionListEditDlg : EditObjectListDlg
	{
		private SubscriptionEditCtrl objectCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public SubscriptionListEditDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            

			m_control = objectCtrl_;
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
			objectCtrl_ = new SubscriptionEditCtrl();
			SuspendLayout();
			// 
			// ObjectCTRL
			// 
			objectCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			objectCtrl_.Location = new System.Drawing.Point(4, 4);
			objectCtrl_.Name = "objectCtrl_";
			objectCtrl_.Size = new System.Drawing.Size(228, 148);
			objectCtrl_.TabIndex = 2;
			// 
			// SubscriptionListEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(320, 166);
			Controls.Add(objectCtrl_);
			Name = "SubscriptionListEditDlg";
			Text = "Edit Subscription";
			Controls.SetChildIndex(objectCtrl_, 0);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the user to modify the subscription state parameters.
		/// </summary>
		public TsCDaSubscriptionState ShowDialog(TsCDaServer server, TsCDaSubscriptionState state)
		{
			objectCtrl_.Server = server;

			if (state == null) state = (TsCDaSubscriptionState)objectCtrl_.Create();

			ArrayList results = ShowDialog(new object[] { state });

			if (results != null && results.Count == 1)
			{
				return (TsCDaSubscriptionState)results[0];
			}

			return null;
		}
	}
}

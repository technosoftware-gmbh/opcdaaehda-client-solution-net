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

namespace SampleClients.Da.ItemValue
{
    /// <summary>
    /// A dialog used to display and edit a list of ItemValue objects.
    /// </summary>
    public class ItemValueListEditDlg : EditObjectListDlg
	{
		private ItemValueEditCtrl objectCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ItemValueListEditDlg()
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
			objectCtrl_ = new ItemValueEditCtrl();
			SuspendLayout();
			// 
			// ObjectCTRL
			// 
			objectCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			objectCtrl_.Location = new System.Drawing.Point(4, 4);
			objectCtrl_.Name = "objectCtrl_";
			objectCtrl_.Size = new System.Drawing.Size(356, 168);
			objectCtrl_.TabIndex = 2;
			// 
			// ItemValueListEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(448, 190);
			Controls.AddRange(new System.Windows.Forms.Control[] {
																		  objectCtrl_});
			Name = "ItemValueListEditDlg";
			Text = "Edit Item Values";
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the user to edit the item list parameters.
		/// </summary>
		public TsCDaItemValue[] ShowDialog(TsCDaItemValue[] items, bool allowEditItemId)
		{
			objectCtrl_.AllowEditItemId = allowEditItemId;

			if (items == null) items = new TsCDaItemValue[] { (TsCDaItemValue)objectCtrl_.Create() };

			ArrayList results = base.ShowDialog((object[])items, !allowEditItemId);

			if (results != null && results.Count > 0)
			{
				return (TsCDaItemValue[])results.ToArray(typeof(TsCDaItemValue));
			}

			return null;
		}
	}
}

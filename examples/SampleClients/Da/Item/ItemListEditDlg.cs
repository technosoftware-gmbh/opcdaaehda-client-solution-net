#region Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
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
#endregion Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved

#region Using Directives

using System.Collections;

using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da.Item
{
    /// <summary>
    /// A dialog used to display and edit a list of Item objects.
    /// </summary>
    public class ItemListEditDlg : EditObjectListDlg
	{
		private ItemEditCtrl objectCtrl_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ItemListEditDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

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
			this.objectCtrl_ = new ItemEditCtrl();
			this.SuspendLayout();
			// 
			// ObjectCTRL
			// 
			this.objectCtrl_.AllowEditItemId = false;
			this.objectCtrl_.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.objectCtrl_.DockPadding.Left = 4;
			this.objectCtrl_.DockPadding.Right = 4;
			this.objectCtrl_.DockPadding.Top = 4;
			this.objectCtrl_.IsReadItem = false;
			this.objectCtrl_.Name = "objectCtrl_";
			this.objectCtrl_.Size = new System.Drawing.Size(296, 174);
			this.objectCtrl_.TabIndex = 2;
			// 
			// ItemListEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 190);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.objectCtrl_});
			this.Name = "ItemListEditDlg";
			this.Text = "Edit Items";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the user to edit the item list parameters.
		/// </summary>
		public TsCDaItem[] ShowDialog(TsCDaItem[] items, bool isReadItems, bool allowEditItemId)
		{
			objectCtrl_.IsReadItem      = isReadItems;
			objectCtrl_.AllowEditItemId = allowEditItemId;

			if (items == null) items = new TsCDaItem[] { (TsCDaItem)objectCtrl_.Create() };

			ArrayList results = base.ShowDialog((object[])items, !allowEditItemId);

			if (results != null && results.Count > 0)
			{
				return (TsCDaItem[])results.ToArray(typeof(TsCDaItem));
			}

			return null;
		}
	}
}

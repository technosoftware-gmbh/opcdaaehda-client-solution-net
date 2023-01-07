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

using System;
using System.ComponentModel;

#endregion

namespace SampleClients.Common
{
	/// <summary>
	/// Used to receive data type changed notifications.
	/// </summary>
	public delegate void DataTypeChangedCallback(System.Type type);

	/// <summary>
	/// A control used to select a well known data type.
	/// </summary>
	public class DataTypeCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ComboBox DataTypeCB;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataTypeCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			m_types = Technosoftware.DaAeHdaClient.OpcType.Enumerate();

			foreach (System.Type type in m_types)
			{
				DataTypeCB.Items.Add(type.Name);
			}

			DataTypeCB.SelectedIndex = -1;
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DataTypeCB = new System.Windows.Forms.ComboBox();
			SuspendLayout();
			// 
			// DataTypeCB
			// 
			DataTypeCB.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			DataTypeCB.Name = "DataTypeCB";
			DataTypeCB.Size = new System.Drawing.Size(112, 21);
			DataTypeCB.TabIndex = 0;
			DataTypeCB.SelectedValueChanged += new System.EventHandler(DataTypeCB_SelectedValueChanged);
			// 
			// DataTypeCtrl
			// 
			Controls.AddRange(new System.Windows.Forms.Control[] {
																		  DataTypeCB});
			Name = "DataTypeCtrl";
			Size = new System.Drawing.Size(112, 24);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// A list of known data types.
		/// </summary>
		public System.Type[] m_types = null;

		/// <summary>
		/// Raised when the data type changes.
		/// </summary>
		public event DataTypeChangedCallback DataTypeChanged = null;

		/// <summary>
		/// Whether the control is read only.
		/// </summary>
		public bool ReadOnly {set{ DataTypeCB.Enabled = !value; }}

		/// <summary>
		/// Gets or sets the selected data type.
		/// </summary>
		[Browsable(false)]
		public System.Type SelectedType
		{
			get
			{
				if (DataTypeCB.SelectedIndex >= 0) 
				{
					return m_types[DataTypeCB.SelectedIndex];
				}

				return null;
			}

			set
			{
				for (int ii = 0; ii < m_types.Length; ii++)
				{
					if (value == m_types[ii])
					{
						DataTypeCB.SelectedIndex = ii;
						return;
					}
				}

				DataTypeCB.SelectedIndex = -1;
			}
		}
	
		/// <summary>
		/// Called when the selected data type changes.
		/// </summary>
		private void DataTypeCB_SelectedValueChanged(object sender, EventArgs e)
		{
			if (DataTypeChanged != null)
			{
				DataTypeChanged(SelectedType);
			}
		}
	}
}

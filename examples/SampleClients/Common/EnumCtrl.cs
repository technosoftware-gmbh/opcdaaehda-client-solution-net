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
using System.Windows.Forms;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// A control used to select a valid value for any enumeration.
    /// </summary>
    public class EnumCtrl : System.Windows.Forms.UserControl
	{ 
		private System.Windows.Forms.ComboBox EnumCB;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolTip ToolTips;

		// the type of the OpcEnumCtrl displayed
		object m_value = null;

		public EnumCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		// provides access to the underlying combo box.
		public ComboBox Control {get{return EnumCB;}}

		/// <summary>
		/// Called when the value in the control changes.
		/// </summary>
		public event ValueChangedCallback ValueChanged = null;

		// sets the OpcEnumCtrl type used by the combo box
		[Browsable(false)]
		public object Value
		{
			get 
			{
				if (m_value == null)
				{
					return null;
				}

				return EnumCB.SelectedItem;
			}

			set {m_value = value; UpdateView();}
		}

		// update the combo box
		private void UpdateView()
		{
			EnumCB.Items.Clear();

			// check if an enum type was specified 
			if (m_value == null)
			{
				return;
			}

			// add the OpcEnumCtrl value to the drop dowwnlist
			Array values = Enum.GetValues(m_value.GetType());

			foreach (object enumValue in values)
			{
				EnumCB.Items.Add(enumValue);
			}

			// set to the current value
			EnumCB.SelectedItem = m_value;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
		
			base.Dispose(disposing);
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			EnumCB = new System.Windows.Forms.ComboBox();
			ToolTips = new System.Windows.Forms.ToolTip(components);
			SuspendLayout();
			// 
			// EnumCB
			// 
			EnumCB.Dock = System.Windows.Forms.DockStyle.Fill;
			EnumCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			EnumCB.Location = new System.Drawing.Point(0, 0);
			EnumCB.Name = "EnumCB";
			EnumCB.Size = new System.Drawing.Size(152, 21);
			EnumCB.TabIndex = 0;
			EnumCB.SelectedIndexChanged += new System.EventHandler(EnumCB_SelectedIndexChanged);
			// 
			// EnumCtrl
			// 
			Controls.Add(EnumCB);
			Name = "EnumCtrl";
			Size = new System.Drawing.Size(152, 24);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Handles a change to the value.
		/// </summary>
		private void EnumCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			if (EnumCB.SelectedItem != null)
			{
				if (ValueChanged != null)
				{
					ValueChanged(this, EnumCB.SelectedItem);
				}
			}
		}
	}
}
  
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
using System.Collections;
using System.Windows.Forms;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// An interface which contained controls must implement.
    /// </summary>
    public interface IEditObjectCtrl
	{
		/// <summary>
		/// Set all fields to default values.
		/// </summary>
		void SetDefaults();

		/// <summary>
		/// Copy values from control into object - throw exceptions on error.
		/// </summary>
		object Get();
		
		/// <summary>
		/// Copy object values into controls.
		/// </summary>
		void Set(object element);

		/// <summary>
		/// Creates a new object.
		/// </summary>
		object Create();
	}

	/// <summary>
	/// A dialog that edits a list of objects.
	/// </summary>
	public class EditObjectListDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.HScrollBar SelectorSB;
		private System.Windows.Forms.Button AddBTN;
		private System.Windows.Forms.Button RemoveBTN;
		private System.Windows.Forms.Panel SelectorPN;
		private System.Windows.Forms.Label CounterLB;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Button CancelBTN;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditObjectListDlg()
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
			ButtonsPN = new System.Windows.Forms.Panel();
			CancelBTN = new System.Windows.Forms.Button();
			CounterLB = new System.Windows.Forms.Label();
			RemoveBTN = new System.Windows.Forms.Button();
			AddBTN = new System.Windows.Forms.Button();
			OkBTN = new System.Windows.Forms.Button();
			SelectorSB = new System.Windows.Forms.HScrollBar();
			SelectorPN = new System.Windows.Forms.Panel();
			ButtonsPN.SuspendLayout();
			SelectorPN.SuspendLayout();
			SuspendLayout();
			// 
			// ButtonsPN
			// 
			ButtonsPN.Controls.AddRange(new System.Windows.Forms.Control[] {
																					CancelBTN,
																					CounterLB,
																					RemoveBTN,
																					AddBTN,
																					OkBTN});
			ButtonsPN.Dock = System.Windows.Forms.DockStyle.Right;
			ButtonsPN.Location = new System.Drawing.Point(296, 0);
			ButtonsPN.Name = "ButtonsPN";
			ButtonsPN.Size = new System.Drawing.Size(88, 277);
			ButtonsPN.TabIndex = 0;
			// 
			// CancelBTN
			// 
			CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			CancelBTN.Location = new System.Drawing.Point(8, 40);
			CancelBTN.Name = "CancelBTN";
			CancelBTN.TabIndex = 0;
			CancelBTN.Text = "Cancel";
			// 
			// CounterLB
			// 
			CounterLB.Dock = System.Windows.Forms.DockStyle.Bottom;
			CounterLB.Location = new System.Drawing.Point(0, 261);
			CounterLB.Name = "CounterLB";
			CounterLB.Size = new System.Drawing.Size(88, 16);
			CounterLB.TabIndex = 2;
			CounterLB.Text = "0 of 0";
			CounterLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RemoveBTN
			// 
			RemoveBTN.Location = new System.Drawing.Point(8, 104);
			RemoveBTN.Name = "RemoveBTN";
			RemoveBTN.TabIndex = 3;
			RemoveBTN.Text = "Remove";
			RemoveBTN.Click += new System.EventHandler(RemoveBTN_Click);
			// 
			// AddBTN
			// 
			AddBTN.Location = new System.Drawing.Point(8, 72);
			AddBTN.Name = "AddBTN";
			AddBTN.TabIndex = 4;
			AddBTN.Text = "Add";
			AddBTN.Click += new System.EventHandler(AddBTN_Click);
			// 
			// OkBTN
			// 
			OkBTN.Location = new System.Drawing.Point(8, 8);
			OkBTN.Name = "OkBTN";
			OkBTN.TabIndex = 1;
			OkBTN.Text = "OK";
			OkBTN.Click += new System.EventHandler(OkBTN_Click);
			// 
			// SelectorSB
			// 
			SelectorSB.Dock = System.Windows.Forms.DockStyle.Bottom;
			SelectorSB.LargeChange = 1;
			SelectorSB.Maximum = 1;
			SelectorSB.Name = "SelectorSB";
			SelectorSB.Size = new System.Drawing.Size(296, 16);
			SelectorSB.TabIndex = 0;
			SelectorSB.ValueChanged += new System.EventHandler(SelectorSB_ValueChanged);
			// 
			// SelectorPN
			// 
			SelectorPN.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 SelectorSB});
			SelectorPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			SelectorPN.Location = new System.Drawing.Point(0, 261);
			SelectorPN.Name = "SelectorPN";
			SelectorPN.Size = new System.Drawing.Size(296, 16);
			SelectorPN.TabIndex = 1;
			// 
			// EditObjectListDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(384, 277);
			Controls.AddRange(new System.Windows.Forms.Control[] {
																		  SelectorPN,
																		  ButtonsPN});
			Name = "EditObjectListDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Edit Object";
			ButtonsPN.ResumeLayout(false);
			SelectorPN.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The contained control that displays the objects.
		/// </summary>
		protected IEditObjectCtrl m_control = null;
		
		/// <summary>
		/// The list of objects being edited.
		/// </summary>
		private ArrayList m_objects = new ArrayList();

		/// <summary>
		/// The index of the current item.
		/// </summary>
		private int m_index = -1;

		/// <summary>
		/// Whether elements can be added or removed from the list.
		/// </summary>
		private bool m_fixedLength = false;

		/// <summary>
		/// Displays the dialog with a fixed length list of objects.
		/// </summary>
		public ArrayList ShowDialog(object[] objects)
		{
			return ShowDialog(objects, true);
		}

		/// <summary>
		/// Displays the dialog with the list of objects.
		/// </summary>
		public ArrayList ShowDialog(object[] objects, bool fixedLength)
		{
			m_objects     = new ArrayList();
			m_index       = -1;
			m_fixedLength = fixedLength;

			if (objects != null) m_objects.AddRange(objects);

			m_control.SetDefaults();

			AddBTN.Visible    = !m_fixedLength;
			RemoveBTN.Visible = !m_fixedLength;

			if (m_objects.Count == 0)
			{
				m_objects.Add(m_control.Create());
			}

			SelectorSB.Minimum     = 0;
			SelectorSB.Maximum     = m_objects.Count-1;
			SelectorSB.LargeChange = 1;
			SelectorSB.SmallChange = 1;

			SelectorSB.Value = m_index = 0;
			m_control.Set(m_objects[m_index]);
			CounterLB.Text = String.Format("{0} of {1}", m_index+1, m_objects.Count);

			if (ShowDialog() == DialogResult.OK)
			{
				return m_objects;
			}

			return null;
		}
		
		/// <summary>
		/// Validates and saves changes to the current object. 
		/// </summary>
		private bool Save()
		{
			if (m_index != -1)
			{
				try
				{
					m_objects[m_index] = m_control.Get();
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message);
					SelectorSB.Value = m_index;
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Changes the currently displayed object.
		/// </summary>
		private void SelectorSB_ValueChanged(object sender, System.EventArgs e)
		{
			if (SelectorSB.Value != m_index)
			{
				if (Save())
				{
					m_index = SelectorSB.Value;
					m_control.Set(m_objects[m_index]);
					CounterLB.Text = String.Format("{0} of {1}", m_index+1, m_objects.Count);
				}
			}
		}

		/// <summary>
		/// Creates a new object instance and adds it to the end of the list.
		/// </summary>
		private void AddBTN_Click(object sender, System.EventArgs e)
		{
			if (Save())
			{
				m_objects.Add(m_control.Create());
				
				SelectorSB.Minimum = 0;
				SelectorSB.Maximum = m_objects.Count-1;
				SelectorSB.LargeChange = 1;
				SelectorSB.SmallChange = 1;

				SelectorSB.Value = m_index = m_objects.Count-1;
				
				m_control.Set(m_objects[m_index]);
				CounterLB.Text = String.Format("{0} of {1}", m_index+1, m_objects.Count);

				RemoveBTN.Enabled = !m_fixedLength;
			}
		}

		/// <summary>
		/// Removes an object from the list.
		/// </summary>
		private void RemoveBTN_Click(object sender, System.EventArgs e)
		{
			if (m_index != -1)
			{
				m_objects.RemoveAt(m_index);

				if (m_index >= m_objects.Count)
				{
					m_index = m_objects.Count-1;
				}
				
				if (m_index == -1)
				{
					SelectorSB.Minimum = SelectorSB.Maximum = 0;
					SelectorSB.LargeChange = 1;
					SelectorSB.SmallChange = 1;

					m_control.SetDefaults();
					CounterLB.Text = "0 of 0";

					RemoveBTN.Enabled = false;
					return;
				}

				SelectorSB.Minimum = 0;
				SelectorSB.Maximum = m_objects.Count-1;
				SelectorSB.Value   = m_index;

				m_control.Set(m_objects[m_index]);
				CounterLB.Text = String.Format("{0} of {1}", m_index+1, m_objects.Count);
			}
		}

		/// <summary>
		/// Validates and saves changes to the current object.
		/// </summary>
		private void ApplyBTN_Click(object sender, System.EventArgs e)
		{
			Save();
		}

		/// <summary>
		/// Validates and saves changes to the current object and closes the dialog.
		/// </summary>
		private void OkBTN_Click(object sender, System.EventArgs e)
		{
			if (Save())	DialogResult = DialogResult.OK;
		}
	}
}

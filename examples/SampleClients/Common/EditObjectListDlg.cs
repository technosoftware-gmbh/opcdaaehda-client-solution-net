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
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.CounterLB = new System.Windows.Forms.Label();
			this.RemoveBTN = new System.Windows.Forms.Button();
			this.AddBTN = new System.Windows.Forms.Button();
			this.OkBTN = new System.Windows.Forms.Button();
			this.SelectorSB = new System.Windows.Forms.HScrollBar();
			this.SelectorPN = new System.Windows.Forms.Panel();
			this.ButtonsPN.SuspendLayout();
			this.SelectorPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.CancelBTN,
																					this.CounterLB,
																					this.RemoveBTN,
																					this.AddBTN,
																					this.OkBTN});
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Right;
			this.ButtonsPN.Location = new System.Drawing.Point(296, 0);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(88, 277);
			this.ButtonsPN.TabIndex = 0;
			// 
			// CancelBTN
			// 
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(8, 40);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// CounterLB
			// 
			this.CounterLB.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.CounterLB.Location = new System.Drawing.Point(0, 261);
			this.CounterLB.Name = "CounterLB";
			this.CounterLB.Size = new System.Drawing.Size(88, 16);
			this.CounterLB.TabIndex = 2;
			this.CounterLB.Text = "0 of 0";
			this.CounterLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RemoveBTN
			// 
			this.RemoveBTN.Location = new System.Drawing.Point(8, 104);
			this.RemoveBTN.Name = "RemoveBTN";
			this.RemoveBTN.TabIndex = 3;
			this.RemoveBTN.Text = "Remove";
			this.RemoveBTN.Click += new System.EventHandler(this.RemoveBTN_Click);
			// 
			// AddBTN
			// 
			this.AddBTN.Location = new System.Drawing.Point(8, 72);
			this.AddBTN.Name = "AddBTN";
			this.AddBTN.TabIndex = 4;
			this.AddBTN.Text = "Add";
			this.AddBTN.Click += new System.EventHandler(this.AddBTN_Click);
			// 
			// OkBTN
			// 
			this.OkBTN.Location = new System.Drawing.Point(8, 8);
			this.OkBTN.Name = "OkBTN";
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			this.OkBTN.Click += new System.EventHandler(this.OkBTN_Click);
			// 
			// SelectorSB
			// 
			this.SelectorSB.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.SelectorSB.LargeChange = 1;
			this.SelectorSB.Maximum = 1;
			this.SelectorSB.Name = "SelectorSB";
			this.SelectorSB.Size = new System.Drawing.Size(296, 16);
			this.SelectorSB.TabIndex = 0;
			this.SelectorSB.ValueChanged += new System.EventHandler(this.SelectorSB_ValueChanged);
			// 
			// SelectorPN
			// 
			this.SelectorPN.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.SelectorSB});
			this.SelectorPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.SelectorPN.Location = new System.Drawing.Point(0, 261);
			this.SelectorPN.Name = "SelectorPN";
			this.SelectorPN.Size = new System.Drawing.Size(296, 16);
			this.SelectorPN.TabIndex = 1;
			// 
			// EditObjectListDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 277);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.SelectorPN,
																		  this.ButtonsPN});
			this.Name = "EditObjectListDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Object";
			this.ButtonsPN.ResumeLayout(false);
			this.SelectorPN.ResumeLayout(false);
			this.ResumeLayout(false);

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

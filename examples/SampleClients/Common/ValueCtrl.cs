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

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Cpx;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// Called when the value is changed.
    /// </summary>
    public delegate void ValueChangedCallback(Control control, object value);

	/// <summary>
	/// A control used to display and edit a value with an arbitrary type.
	/// </summary>
	public class ValueCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TextBox ValueTB;
		private System.Windows.Forms.DateTimePicker DateTimeCTRL;
		private System.Windows.Forms.Button EditBTN;
		private System.Windows.Forms.Panel LeftPN;
		private System.Windows.Forms.Panel MainPN;
		private DataTypeCtrl DataTypeCTRL;
		private System.Windows.Forms.Panel EditPN;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ValueCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			DataTypeCTRL.DataTypeChanged += new DataTypeChangedCallback(OnDataTypeChanged);
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
			ValueTB = new System.Windows.Forms.TextBox();
			DateTimeCTRL = new System.Windows.Forms.DateTimePicker();
			EditBTN = new System.Windows.Forms.Button();
			LeftPN = new System.Windows.Forms.Panel();
			EditPN = new System.Windows.Forms.Panel();
			MainPN = new System.Windows.Forms.Panel();
			DataTypeCTRL = new DataTypeCtrl();
			LeftPN.SuspendLayout();
			EditPN.SuspendLayout();
			MainPN.SuspendLayout();
			SuspendLayout();
			// 
			// ValueTB
			// 
			ValueTB.Dock = System.Windows.Forms.DockStyle.Fill;
			ValueTB.Location = new System.Drawing.Point(0, 0);
			ValueTB.Name = "ValueTB";
			ValueTB.Size = new System.Drawing.Size(120, 20);
			ValueTB.TabIndex = 0;
			ValueTB.Text = "";
			// 
			// DateTimeCTRL
			// 
			DateTimeCTRL.CustomFormat = "yyyy/MM/dd HH:mm:ss";
			DateTimeCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			DateTimeCTRL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			DateTimeCTRL.Location = new System.Drawing.Point(0, 0);
			DateTimeCTRL.Name = "DateTimeCTRL";
			DateTimeCTRL.ShowUpDown = true;
			DateTimeCTRL.Size = new System.Drawing.Size(120, 20);
			DateTimeCTRL.TabIndex = 1;
			DateTimeCTRL.Visible = false;
			// 
			// EditBTN
			// 
			EditBTN.Dock = System.Windows.Forms.DockStyle.Fill;
			EditBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			EditBTN.Location = new System.Drawing.Point(4, 0);
			EditBTN.Name = "EditBTN";
			EditBTN.Size = new System.Drawing.Size(24, 20);
			EditBTN.TabIndex = 0;
			EditBTN.Text = "...";
			EditBTN.Click += new System.EventHandler(EditBTN_Click);
			// 
			// LeftPN
			// 
			LeftPN.Controls.Add(DateTimeCTRL);
			LeftPN.Controls.Add(ValueTB);
			LeftPN.Controls.Add(EditPN);
			LeftPN.Dock = System.Windows.Forms.DockStyle.Fill;
			LeftPN.Location = new System.Drawing.Point(0, 0);
			LeftPN.Name = "LeftPN";
			LeftPN.Size = new System.Drawing.Size(152, 20);
			LeftPN.TabIndex = 0;
			// 
			// EditPN
			// 
			EditPN.Controls.Add(EditBTN);
			EditPN.Dock = System.Windows.Forms.DockStyle.Right;
			EditPN.DockPadding.Left = 4;
			EditPN.DockPadding.Right = 4;
			EditPN.Location = new System.Drawing.Point(120, 0);
			EditPN.Name = "EditPN";
			EditPN.Size = new System.Drawing.Size(32, 20);
			EditPN.TabIndex = 2;
			EditPN.Visible = false;
			// 
			// MainPN
			// 
			MainPN.Controls.Add(LeftPN);
			MainPN.Controls.Add(DataTypeCTRL);
			MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			MainPN.Location = new System.Drawing.Point(0, 0);
			MainPN.Name = "MainPN";
			MainPN.Size = new System.Drawing.Size(240, 20);
			MainPN.TabIndex = 27;
			// 
			// DataTypeCTRL
			// 
			DataTypeCTRL.Dock = System.Windows.Forms.DockStyle.Right;
			DataTypeCTRL.Location = new System.Drawing.Point(152, 0);
			DataTypeCTRL.Name = "DataTypeCTRL";
			DataTypeCTRL.SelectedType = null;
			DataTypeCTRL.Size = new System.Drawing.Size(88, 20);
			DataTypeCTRL.TabIndex = 1;
			// 
			// ValueCtrl
			// 
			Controls.Add(MainPN);
			Name = "ValueCtrl";
			Size = new System.Drawing.Size(240, 20);
			LeftPN.ResumeLayout(false);
			EditPN.ResumeLayout(false);
			MainPN.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The current value of the object.
		/// </summary>
		private object m_value = null;

		/// <summary>
		/// The type of the value.
		/// </summary>
		private System.Type m_type  = null;
		
		/// <summary>
		/// Whether the value may be modified.
		/// </summary>
		private bool m_readOnly = false;

		/// <summary>
		/// The item id associated with the value.
		/// </summary>
		public OpcItem ItemID {get { return m_itemID; } set { m_itemID = value; }}
		/// <remarks/>
		private OpcItem m_itemID = null;

		/// <summary>
		/// The value stored in the control.
		/// </summary>
		[Browsable(false)]
		public object Value { get{return Get();} set {Set(value, false);} }

		/// <summary>
		/// Whether the data type of the value can be changed. 
		/// </summary>
		public bool AllowChangeType = true;

		/// <summary>
		/// Called when the value in the control changes.
		/// </summary>
		public event ValueChangedCallback ValueChanged = null;

		/// <summary>
		/// Gets the value displayed in the control.
		/// </summary>
		public object Get()
		{
			if (m_type == null) 
			{
				if (ValueTB.Text == "") return null;
				return ValueTB.Text;
			}
			
			if (m_type == typeof(DateTime)) 
			{
				DateTime datetime = DateTimeCTRL.Value;
				if (datetime == DateTimeCTRL.MinDate) return DateTime.MinValue;
				return datetime;
			}

			if (m_type != null && m_type.IsArray) return Technosoftware.DaAeHdaClient.OpcConvert.ChangeType(m_value, m_type);
			
			// convert empty string to null for all types other than strings.
			string value = ValueTB.Text;
			if (m_type != typeof(string) && value != null && value == "") value = null;

			// convert string to type (null creates a default value for the type).
			return Technosoftware.DaAeHdaClient.OpcConvert.ChangeType(value, m_type);
		}

        /// <summary>
        /// Performs a deep copy of an object if possible.
        /// </summary>
        public object Clone(object source)
        {
            if (source == null) return null;
            if (source.GetType().IsValueType) return source;

            if (source.GetType().IsArray || source.GetType() == typeof(Array))
            {
                Array array = (Array)((Array)source).Clone();

                for (int ii = 0; ii < array.Length; ii++)
                {
                    array.SetValue(Clone(array.GetValue(ii)), ii);
                }

                return array;
            }

            try { return ((ICloneable)source).Clone(); }
            catch { throw new NotSupportedException("Object cannot be cloned."); }
        }

		/// <summary>
		/// Sets the value displayed in the control.
		/// </summary>
		public void Set(object value, bool readOnly)
		{
			m_value    = Technosoftware.DaAeHdaClient.OpcConvert.Clone(value);
			m_type     = null;
			m_readOnly = readOnly;

			ValueTB.ReadOnly      = m_readOnly;
			DataTypeCTRL.ReadOnly = !AllowChangeType || m_readOnly;

			if (m_value == null)
			{
				ValueTB.Text         = "";
				ValueTB.Visible      = true;
				EditPN.Visible       = false;
				DateTimeCTRL.Visible = false;
				return;
			}

			DataTypeCTRL.SelectedType = m_type = m_value.GetType();

			if (!m_readOnly && m_type == typeof(DateTime))
			{
				DateTime datetime    = (DateTime)m_value;
				DateTimeCTRL.Value   = (datetime > DateTimeCTRL.MinDate)?datetime:DateTimeCTRL.MinDate;
				ValueTB.Visible      = false;
				EditPN.Visible       = false;
				DateTimeCTRL.Visible = true;
				return;
			}

			if (m_type.IsArray)
			{
				ValueTB.Text         = (string)Technosoftware.DaAeHdaClient.OpcConvert.ChangeType(m_value, typeof(string));
				ValueTB.Visible      = true;
				EditPN.Visible       = true;
				DateTimeCTRL.Visible = false;
				return;
			}

			ValueTB.Text         = Technosoftware.DaAeHdaClient.OpcConvert.ToString(m_value);
			ValueTB.Visible      = true;
			EditPN.Visible       = false;
			DateTimeCTRL.Visible = false;
		}

		/// <summary>
		/// Called when the data type changes.
		/// </summary>
		private void OnDataTypeChanged(System.Type type)
		{
			try
			{
				if (m_type != type)
				{
					m_type = type;
					Set(Get(), m_readOnly);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				Set(Technosoftware.DaAeHdaClient.OpcConvert.ChangeType(null, type), m_readOnly);
			}
		}

		/// <summary>
		/// Called when the edit array button is clicked.
		/// </summary>
		private void EditBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				object value = null;
				TsCCpxComplexItem complexItem = TsCCpxComplexTypeCache.GetComplexItem(m_itemID);

				if (complexItem != null)
				{
					value = new EditComplexValueDlg().ShowDialog(complexItem, m_value, m_readOnly, true);
				}

				else 
                if (m_value.GetType().IsArray)
				{
					value = new EditArrayDlg().ShowDialog(m_value, m_readOnly);
				}

				if (m_readOnly || value == null)
				{
					return;
				}

				// update the array.
				Set(value, m_readOnly);

				// send change notification.
				if (ValueChanged != null)
				{
					ValueChanged(this, m_value);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}

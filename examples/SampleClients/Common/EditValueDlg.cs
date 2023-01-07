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
using System.Windows.Forms;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// A dialog used to display and edit the contents of an array.
    /// </summary>
    public class EditValueDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private ValueCtrl ValueCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditValueDlg()
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
			OkBTN = new System.Windows.Forms.Button();
            ValueCTRL = new ValueCtrl();
			ButtonsPN.SuspendLayout();
			SuspendLayout();
			// 
			// ButtonsPN
			// 
			ButtonsPN.Controls.Add(CancelBTN);
			ButtonsPN.Controls.Add(OkBTN);
			ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			ButtonsPN.Location = new System.Drawing.Point(0, 26);
			ButtonsPN.Name = "ButtonsPN";
			ButtonsPN.Size = new System.Drawing.Size(296, 36);
			ButtonsPN.TabIndex = 0;
			// 
			// CancelBTN
			// 
			CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			CancelBTN.Location = new System.Drawing.Point(216, 8);
			CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new System.Drawing.Size(75, 23);
			CancelBTN.TabIndex = 0;
			CancelBTN.Text = "Cancel";
			// 
			// OkBTN
			// 
			OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            OkBTN.Location = new System.Drawing.Point(135, 8);
			OkBTN.Name = "OkBTN";
            OkBTN.Size = new System.Drawing.Size(75, 23);
			OkBTN.TabIndex = 1;
			OkBTN.Text = "OK";
			// 
			// ValueCTRL
			// 
			ValueCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			ValueCTRL.ItemID = null;
			ValueCTRL.Location = new System.Drawing.Point(0, 0);
			ValueCTRL.Name = "ValueCTRL";
            ValueCTRL.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			ValueCTRL.Size = new System.Drawing.Size(296, 26);
			ValueCTRL.TabIndex = 1;
            ValueCTRL.Value = null;
			// 
			// EditValueDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(296, 62);
			Controls.Add(ValueCTRL);
			Controls.Add(ButtonsPN);
			Name = "EditValueDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Edit Value";
			ButtonsPN.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The current array object.
		/// </summary>
		private object m_value = null;

		/// <summary>
		/// The data type of the elements of the current array object.
		/// </summary>
		private System.Type m_type = null;

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
		/// Displays the dialog with the specified array.
		/// </summary>
		public object ShowDialog(object value, bool fixedType)
		{
			if (value == null) throw new ArgumentNullException("value");
			if (value.GetType().IsArray) throw new ArgumentException("Is an array", "value");

			m_value = Technosoftware.DaAeHdaClient.OpcConvert.Clone(value);
			m_type  = m_value.GetType();

			ValueCTRL.AllowChangeType = !fixedType;
			ValueCTRL.Set(value, false);

			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			return ValueCTRL.Get();
		}
	}
}

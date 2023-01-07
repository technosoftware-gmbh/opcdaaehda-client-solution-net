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
using System.Text;
using System.Windows.Forms;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// A dialog used to display and edit the contents of an array.
    /// </summary>
    public class EditBinaryDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel MainPN;
		private System.Windows.Forms.RichTextBox DataTB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditBinaryDlg()
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
			MainPN = new System.Windows.Forms.Panel();
			DataTB = new System.Windows.Forms.RichTextBox();
			ButtonsPN.SuspendLayout();
			MainPN.SuspendLayout();
			SuspendLayout();
			// 
			// ButtonsPN
			// 
			ButtonsPN.Controls.Add(CancelBTN);
			ButtonsPN.Controls.Add(OkBTN);
			ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			ButtonsPN.Location = new System.Drawing.Point(0, 258);
			ButtonsPN.Name = "ButtonsPN";
			ButtonsPN.Size = new System.Drawing.Size(416, 36);
			ButtonsPN.TabIndex = 0;
			// 
			// CancelBTN
			// 
			CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			CancelBTN.Location = new System.Drawing.Point(336, 8);
			CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new System.Drawing.Size(75, 23);
			CancelBTN.TabIndex = 0;
			CancelBTN.Text = "Cancel";
			// 
			// OkBTN
			// 
			OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            OkBTN.Location = new System.Drawing.Point(255, 8);
			OkBTN.Name = "OkBTN";
            OkBTN.Size = new System.Drawing.Size(75, 23);
			OkBTN.TabIndex = 1;
			OkBTN.Text = "OK";
			// 
			// MainPN
			// 
			MainPN.Controls.Add(DataTB);
			MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			MainPN.Location = new System.Drawing.Point(0, 0);
			MainPN.Name = "MainPN";
            MainPN.Padding = new System.Windows.Forms.Padding(4);
			MainPN.Size = new System.Drawing.Size(416, 258);
			MainPN.TabIndex = 3;
			// 
			// DataTB
			// 
			DataTB.Dock = System.Windows.Forms.DockStyle.Fill;
			DataTB.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			DataTB.Location = new System.Drawing.Point(4, 4);
			DataTB.Name = "DataTB";
			DataTB.Size = new System.Drawing.Size(408, 250);
			DataTB.TabIndex = 0;
			DataTB.Text = "01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10";
			// 
			// EditBinaryDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(416, 294);
			Controls.Add(MainPN);
			Controls.Add(ButtonsPN);
			Name = "EditBinaryDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Edit Binary Value";
			ButtonsPN.ResumeLayout(false);
			MainPN.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Displays the dialog with the specified array.
		/// </summary>
		public object ShowDialog(byte[] value)
		{
			if (value == null) throw new ArgumentNullException("value");

			StringBuilder buffer = new StringBuilder(value.Length*3);

			for (int ii = 0; ii < value.Length; ii++)
			{
				buffer.Append(value[ii].ToString("X2"));
				buffer.Append(((ii+1)%16 == 0)?Environment.NewLine:" ");
			}

			DataTB.Text = buffer.ToString();

			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			ArrayList bytes = new ArrayList();

			do
			{
				bytes.Clear();

				int ii = 0;
				bool valid = true;

				string text = DataTB.Text;

				while (ii < text.Length)
				{
					while (ii < text.Length && Char.IsWhiteSpace(text[ii])) ii++;

					if (ii >= text.Length)
					{
						break;
					}

					byte byteValue = 0;

					for (int jj = 0; ii < text.Length && jj < 2; jj++)
					{
						char bits = text[ii++];

						if (Char.IsLower(bits)) bits = Char.ToUpper(bits);

						int index = "0123456789ABCDEF".IndexOf(bits);

						if (index == -1)
						{
							MessageBox.Show("Please enter a valid hexidecimal string.");
							valid = false;
							break;
						}

						byteValue <<= 4;
						byteValue += (byte)index;
					}

					if (!valid)
					{
						break;
					}

					bytes.Add(byteValue);
				}

				if (valid)
				{
					break;
				}
			}
			while (ShowDialog() != DialogResult.OK);

			return (byte[])bytes.ToArray(typeof(byte));
		}
	}
}

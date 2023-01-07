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

using System.Globalization;
using System.Windows.Forms;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// A dialog used select a locale from a list of supported locales.
    /// </summary>
    public class LocaleSelectDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Panel TopPN;
		private System.Windows.Forms.ListBox SupportedLocalesLB;
		private System.ComponentModel.IContainer components = null;

		public LocaleSelectDlg()
		{
			// Required for Windows Form Designer support
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
			OkBTN = new System.Windows.Forms.Button();
			CancelBTN = new System.Windows.Forms.Button();
			ButtonsPN = new System.Windows.Forms.Panel();
			TopPN = new System.Windows.Forms.Panel();
			SupportedLocalesLB = new System.Windows.Forms.ListBox();
			ButtonsPN.SuspendLayout();
			TopPN.SuspendLayout();
			SuspendLayout();
			// 
			// OkBTN
			// 
			OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            OkBTN.Location = new System.Drawing.Point(71, 3);
			OkBTN.Name = "OkBTN";
            OkBTN.Size = new System.Drawing.Size(75, 23);
			OkBTN.TabIndex = 1;
			OkBTN.Text = "OK";
			// 
			// CancelBTN
			// 
			CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			CancelBTN.Location = new System.Drawing.Point(152, 4);
			CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new System.Drawing.Size(75, 23);
			CancelBTN.TabIndex = 0;
			CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			ButtonsPN.Controls.Add(CancelBTN);
			ButtonsPN.Controls.Add(OkBTN);
			ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			ButtonsPN.Location = new System.Drawing.Point(0, 118);
			ButtonsPN.Name = "ButtonsPN";
			ButtonsPN.Size = new System.Drawing.Size(232, 32);
			ButtonsPN.TabIndex = 0;
			// 
			// TopPN
			// 
			TopPN.Controls.Add(SupportedLocalesLB);
			TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
			TopPN.Location = new System.Drawing.Point(0, 0);
			TopPN.Name = "TopPN";
            TopPN.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			TopPN.Size = new System.Drawing.Size(232, 118);
			TopPN.TabIndex = 1;
			// 
			// SupportedLocalesLB
			// 
			SupportedLocalesLB.Dock = System.Windows.Forms.DockStyle.Fill;
			SupportedLocalesLB.Location = new System.Drawing.Point(4, 4);
			SupportedLocalesLB.Name = "SupportedLocalesLB";
            SupportedLocalesLB.Size = new System.Drawing.Size(224, 114);
			SupportedLocalesLB.TabIndex = 6;
            SupportedLocalesLB.SelectedIndexChanged += new System.EventHandler(SupportedLocalesLB_SelectedIndexChanged);
			SupportedLocalesLB.DoubleClick += new System.EventHandler(SupportedLocalesLB_DoubleClick);
			// 
			// LocaleSelectDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(232, 150);
			Controls.Add(TopPN);
			Controls.Add(ButtonsPN);
			Name = "LocaleSelectDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Select Locale";
			ButtonsPN.ResumeLayout(false);
			TopPN.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion
		
		/// <summary>
		/// Prompts user to select a locale in a modal dialog.
		/// </summary>
		public int ShowDialog(CultureInfo[] locales)
		{
			SupportedLocalesLB.Items.Clear();

			if (locales != null)
			{
				foreach (CultureInfo locale in locales)
				{
					SupportedLocalesLB.Items.Add(locale.DisplayName);
				}
			}

			OkBTN.Enabled = false;

			// show dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return -1;
			}

			return SupportedLocalesLB.SelectedIndex;
		}

		/// <summary>
		/// Toggles enabled state of the OK button based on the selected item.
		/// </summary>
		private void SupportedLocalesLB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OkBTN.Enabled = (SupportedLocalesLB.SelectedIndex != -1);
		}

		/// <summary>
		/// Toggles enabled state of the OK button based on the selected item.
		/// </summary>
		private void SupportedLocalesLB_DoubleClick(object sender, System.EventArgs e)
		{
			if (OkBTN.Enabled)
			{
				DialogResult = DialogResult.OK;
			}
		}
	}
}

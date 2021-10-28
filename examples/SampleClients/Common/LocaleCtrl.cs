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
using System.Globalization;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// A control used to specify a locale or select one from a list.
    /// </summary>
    public class LocaleCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Button SelectBTN;
		private System.Windows.Forms.TextBox LocaleTB;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LocaleCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// initialize the list of locales.
			SetSupportedLocales(null);
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
			this.SelectBTN = new System.Windows.Forms.Button();
			this.LocaleTB = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// SelectBTN
			// 
			this.SelectBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SelectBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SelectBTN.Location = new System.Drawing.Point(160, 0);
			this.SelectBTN.Name = "SelectBTN";
			this.SelectBTN.Size = new System.Drawing.Size(28, 21);
			this.SelectBTN.TabIndex = 1;
			this.SelectBTN.Text = "...";
			this.SelectBTN.Click += new System.EventHandler(this.SelectBTN_Click);
			// 
			// LocaleTB
			// 
			this.LocaleTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.LocaleTB.Location = new System.Drawing.Point(0, 0);
			this.LocaleTB.Name = "LocaleTB";
			this.LocaleTB.Size = new System.Drawing.Size(156, 20);
			this.LocaleTB.TabIndex = 2;
			this.LocaleTB.Text = "";
			// 
			// LocaleCtrl
			// 
			this.Controls.Add(this.LocaleTB);
			this.Controls.Add(this.SelectBTN);
			this.Name = "LocaleCtrl";
			this.Size = new System.Drawing.Size(188, 24);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// A list of supported locales.
		/// </summary>
		public CultureInfo[] m_locales = null;

		/// <summary>
		/// Gets or sets the locale.
		/// </summary>
		public string Locale
		{
			get { return new CultureInfo(LocaleTB.Text).Name; }
			set { LocaleTB.Text = value; }
		}

		/// <summary>
		/// Sets the list of supported locales.
		/// </summary>
		public void SetSupportedLocales(string[] supportedLocales)
		{
			// convert strings to culture info objects.
			ArrayList locales = new ArrayList();
			
			if (supportedLocales != null)
			{
				foreach (string locale in supportedLocales)
				{
					CultureInfo culture = null;

					// filter out duplicates.
					for (int ii = 0; ii < locales.Count; ii++)
					{
						if (((CultureInfo)locales[ii]).Name == locale)
						{
							culture = (CultureInfo)locales[ii];
							break;
						}
					}

					// add new locale - if valid.
					if (culture == null)
					{
						try   { locales.Add(new CultureInfo(locale)); }
						catch {}
					}
				}
			}

			// add at least the invariant culture.
			if (locales.Count == 0)
			{
				locales.AddRange(CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures));
			}

			// cache the new list.
			m_locales = (CultureInfo[])locales.ToArray(typeof(CultureInfo));
		}

		/// <summary>
		/// Prompts the user to select one of the supported locales.
		/// </summary>
		private void SelectBTN_Click(object sender, System.EventArgs e)
		{
			int index = new LocaleSelectDlg().ShowDialog(m_locales);

			if (index != -1)
			{
				LocaleTB.Text = m_locales[index].Name;
			}
		}
	}
}

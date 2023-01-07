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

using SampleClients.Common;
using System;
using System.Windows.Forms;

#endregion

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A dialog that displays the current status of an OPC server.
    /// </summary>
    public class BrowseFiltersDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Label maxElementsLb_;
		private System.Windows.Forms.Label nameFilterLb_;
		private System.Windows.Forms.TextBox nameFilterTb_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.NumericUpDown maxElementsCtrl_;
		private System.Windows.Forms.Button applyBtn_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public BrowseFiltersDlg()
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
			maxElementsLb_ = new System.Windows.Forms.Label();
			nameFilterLb_ = new System.Windows.Forms.Label();
			nameFilterTb_ = new System.Windows.Forms.TextBox();
			buttonsPn_ = new System.Windows.Forms.Panel();
			applyBtn_ = new System.Windows.Forms.Button();
			okBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			maxElementsCtrl_ = new System.Windows.Forms.NumericUpDown();
			buttonsPn_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(maxElementsCtrl_)).BeginInit();
			SuspendLayout();
			// 
			// MaxElementsLB
			// 
			maxElementsLb_.Location = new System.Drawing.Point(4, 32);
			maxElementsLb_.Name = "maxElementsLb_";
			maxElementsLb_.Size = new System.Drawing.Size(76, 20);
			maxElementsLb_.TabIndex = 3;
			maxElementsLb_.Text = "Max Elements";
			maxElementsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameFilterLB
			// 
			nameFilterLb_.Location = new System.Drawing.Point(4, 4);
			nameFilterLb_.Name = "nameFilterLb_";
			nameFilterLb_.Size = new System.Drawing.Size(76, 20);
			nameFilterLb_.TabIndex = 1;
			nameFilterLb_.Text = "Name Filter";
			nameFilterLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameFilterTB
			// 
			nameFilterTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			nameFilterTb_.Location = new System.Drawing.Point(80, 4);
			nameFilterTb_.Name = "nameFilterTb_";
			nameFilterTb_.Size = new System.Drawing.Size(216, 20);
			nameFilterTb_.TabIndex = 2;
			nameFilterTb_.Text = "";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(applyBtn_);
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 58);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(304, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// ApplyBTN
			// 
			applyBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			applyBtn_.Location = new System.Drawing.Point(115, 8);
			applyBtn_.Name = "applyBtn_";
			applyBtn_.TabIndex = 2;
			applyBtn_.Text = "Apply";
			applyBtn_.Click += new System.EventHandler(ApplyBTN_Click);
			// 
			// OkBTN
			// 
			okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			okBtn_.Location = new System.Drawing.Point(4, 8);
			okBtn_.Name = "okBtn_";
			okBtn_.TabIndex = 1;
			okBtn_.Text = "OK";
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(224, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// MaxElementsCTRL
			// 
			maxElementsCtrl_.Location = new System.Drawing.Point(80, 32);
			maxElementsCtrl_.Name = "maxElementsCtrl_";
			maxElementsCtrl_.TabIndex = 4;
			// 
			// BrowseFiltersDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = cancelBtn_;
			ClientSize = new System.Drawing.Size(304, 94);
			Controls.Add(maxElementsCtrl_);
			Controls.Add(nameFilterTb_);
			Controls.Add(buttonsPn_);
			Controls.Add(maxElementsLb_);
			Controls.Add(nameFilterLb_);
			MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(312, 128);
			MinimumSize = new System.Drawing.Size(312, 128);
			Name = "BrowseFiltersDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Browse Filters";
			buttonsPn_.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(maxElementsCtrl_)).EndInit();
			ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private event EventHandler MFiltersChanged = null;
		#endregion

		#region Public Interface
		/// <summary>
		/// Raised when the apply button is clicked.
		/// </summary>
		public event EventHandler FiltersChanged
		{
			add    { MFiltersChanged += value; }
			remove { MFiltersChanged -= value; }
		}

		/// <summary>
		/// The current filter string.
		/// </summary>
		public string Filter
		{
			get { return nameFilterTb_.Text;  }
			set { nameFilterTb_.Text = value; }
		}

		/// <summary>
		/// The current max elements value.
		/// </summary>
		public int MaxElements
		{
			get { return (int)maxElementsCtrl_.Value;  }
			set { maxElementsCtrl_.Value = value;     }
		}

		/// <summary>
		/// Prompts the user to change the browse filter settings.
		/// </summary>
		public bool ShowDialog(ref string filter, ref int maxElements, EventHandler callback)
		{
			Filter      = filter;
			MaxElements = maxElements;

			if (callback != null)
			{
				FiltersChanged += callback;
			}

			if (ShowDialog() == DialogResult.OK)
			{
				filter      = Filter;
				maxElements = MaxElements;
				return true;
			}

			return false;
		}
		#endregion

		/// <summary>
		/// Invokes a callback if provided.
		/// </summary>
		private void ApplyBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MFiltersChanged != null)
				{
					MFiltersChanged(this, e);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Apply Browse Filters");
			}
		}
	}
}

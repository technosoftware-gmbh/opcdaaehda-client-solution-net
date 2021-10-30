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
            Icon = ClientUtils.GetAppIcon();
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
			this.maxElementsLb_ = new System.Windows.Forms.Label();
			this.nameFilterLb_ = new System.Windows.Forms.Label();
			this.nameFilterTb_ = new System.Windows.Forms.TextBox();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.applyBtn_ = new System.Windows.Forms.Button();
			this.okBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.maxElementsCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.buttonsPn_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxElementsCtrl_)).BeginInit();
			this.SuspendLayout();
			// 
			// MaxElementsLB
			// 
			this.maxElementsLb_.Location = new System.Drawing.Point(4, 32);
			this.maxElementsLb_.Name = "maxElementsLb_";
			this.maxElementsLb_.Size = new System.Drawing.Size(76, 20);
			this.maxElementsLb_.TabIndex = 3;
			this.maxElementsLb_.Text = "Max Elements";
			this.maxElementsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameFilterLB
			// 
			this.nameFilterLb_.Location = new System.Drawing.Point(4, 4);
			this.nameFilterLb_.Name = "nameFilterLb_";
			this.nameFilterLb_.Size = new System.Drawing.Size(76, 20);
			this.nameFilterLb_.TabIndex = 1;
			this.nameFilterLb_.Text = "Name Filter";
			this.nameFilterLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameFilterTB
			// 
			this.nameFilterTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nameFilterTb_.Location = new System.Drawing.Point(80, 4);
			this.nameFilterTb_.Name = "nameFilterTb_";
			this.nameFilterTb_.Size = new System.Drawing.Size(216, 20);
			this.nameFilterTb_.TabIndex = 2;
			this.nameFilterTb_.Text = "";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.applyBtn_);
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 58);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(304, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// ApplyBTN
			// 
			this.applyBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.applyBtn_.Location = new System.Drawing.Point(115, 8);
			this.applyBtn_.Name = "applyBtn_";
			this.applyBtn_.TabIndex = 2;
			this.applyBtn_.Text = "Apply";
			this.applyBtn_.Click += new System.EventHandler(this.ApplyBTN_Click);
			// 
			// OkBTN
			// 
			this.okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn_.Location = new System.Drawing.Point(4, 8);
			this.okBtn_.Name = "okBtn_";
			this.okBtn_.TabIndex = 1;
			this.okBtn_.Text = "OK";
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(224, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// MaxElementsCTRL
			// 
			this.maxElementsCtrl_.Location = new System.Drawing.Point(80, 32);
			this.maxElementsCtrl_.Name = "maxElementsCtrl_";
			this.maxElementsCtrl_.TabIndex = 4;
			// 
			// BrowseFiltersDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(304, 94);
			this.Controls.Add(this.maxElementsCtrl_);
			this.Controls.Add(this.nameFilterTb_);
			this.Controls.Add(this.buttonsPn_);
			this.Controls.Add(this.maxElementsLb_);
			this.Controls.Add(this.nameFilterLb_);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(312, 128);
			this.MinimumSize = new System.Drawing.Size(312, 128);
			this.Name = "BrowseFiltersDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Browse Filters";
			this.buttonsPn_.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.maxElementsCtrl_)).EndInit();
			this.ResumeLayout(false);

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

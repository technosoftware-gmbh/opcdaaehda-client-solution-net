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
using System.Windows.Forms;

using SampleClients.Common;
using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da.Browse
{
    /// <summary>
    /// Called when the browse filters have changed.
    /// </summary>
    public delegate void BrowseFiltersChangedCallback(TsCDaBrowseFilters filters);

	/// <summary>
	/// A dialog used to specify element and property filters used when browsing.
	/// </summary>
	public class BrowseFiltersDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private PropertyFiltersCtrl propertyFiltersCtrl_;
		private System.Windows.Forms.NumericUpDown maxElementsReturnedCtrl_;
		private System.Windows.Forms.TextBox elementNameFilterTb_;
		private System.Windows.Forms.Label returnPropertiesLb_;
		private System.Windows.Forms.Label elementNameFilterLb_;
		private System.Windows.Forms.CheckBox returnPropertiesCb_;
		private System.Windows.Forms.Label vendorFilterLb_;
		private System.Windows.Forms.TextBox vendorFilterTb_;
		private System.Windows.Forms.Label browseFilterLb_;
		private EnumCtrl browseFilterCtrl_;
		private System.Windows.Forms.Label maxElementsReturnedLb_;
		private System.Windows.Forms.Button applyBtn_;
		private System.Windows.Forms.Panel topPn_;
		private System.ComponentModel.IContainer components = null;

		public BrowseFiltersDlg()
		{
			// Required for Windows Form Designer support
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
			this.okBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.applyBtn_ = new System.Windows.Forms.Button();
			this.propertyFiltersCtrl_ = new PropertyFiltersCtrl();
			this.maxElementsReturnedCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.elementNameFilterTb_ = new System.Windows.Forms.TextBox();
			this.returnPropertiesLb_ = new System.Windows.Forms.Label();
			this.elementNameFilterLb_ = new System.Windows.Forms.Label();
			this.returnPropertiesCb_ = new System.Windows.Forms.CheckBox();
			this.vendorFilterLb_ = new System.Windows.Forms.Label();
			this.vendorFilterTb_ = new System.Windows.Forms.TextBox();
			this.browseFilterLb_ = new System.Windows.Forms.Label();
			this.browseFilterCtrl_ = new EnumCtrl();
			this.maxElementsReturnedLb_ = new System.Windows.Forms.Label();
			this.topPn_ = new System.Windows.Forms.Panel();
			this.buttonsPn_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxElementsReturnedCtrl_)).BeginInit();
			this.topPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
            this.okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.okBtn_.Location = new System.Drawing.Point(118, 6);
			this.okBtn_.Name = "okBtn_";
            this.okBtn_.Size = new System.Drawing.Size(75, 23);
			this.okBtn_.TabIndex = 1;
			this.okBtn_.Text = "OK";
			this.okBtn_.Click += new System.EventHandler(this.OkBTN_Click);
			// 
			// CancelBTN
			// 
            this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn_.Location = new System.Drawing.Point(280, 6);
			this.cancelBtn_.Name = "cancelBtn_";
            this.cancelBtn_.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			this.cancelBtn_.Click += new System.EventHandler(this.CancelBTN_Click);
			// 
			// ButtonsPN
			// 
            this.buttonsPn_.Controls.Add(this.applyBtn_);
            this.buttonsPn_.Controls.Add(this.cancelBtn_);
            this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(4, 274);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(360, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// ApplyBTN
			// 
            this.applyBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.applyBtn_.Location = new System.Drawing.Point(199, 6);
			this.applyBtn_.Name = "applyBtn_";
            this.applyBtn_.Size = new System.Drawing.Size(75, 23);
			this.applyBtn_.TabIndex = 2;
			this.applyBtn_.Text = "Apply";
			this.applyBtn_.Click += new System.EventHandler(this.ApplyBTN_Click);
			// 
			// PropertyFiltersCTRL
			// 
			this.propertyFiltersCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyFiltersCtrl_.Location = new System.Drawing.Point(4, 124);
			this.propertyFiltersCtrl_.Name = "propertyFiltersCtrl_";
			this.propertyFiltersCtrl_.PropertyIDs = new TsDaPropertyID[0];
			this.propertyFiltersCtrl_.ReturnAllProperties = true;
			this.propertyFiltersCtrl_.ReturnPropertyValues = true;
			this.propertyFiltersCtrl_.Size = new System.Drawing.Size(360, 150);
			this.propertyFiltersCtrl_.TabIndex = 0;
			// 
			// MaxElementsReturnedCTRL
			// 
			this.maxElementsReturnedCtrl_.Location = new System.Drawing.Point(112, 24);
			this.maxElementsReturnedCtrl_.Maximum = new System.Decimal(new int[] {
																					10000,
																					0,
																					0,
																					0});
			this.maxElementsReturnedCtrl_.Name = "maxElementsReturnedCtrl_";
			this.maxElementsReturnedCtrl_.Size = new System.Drawing.Size(72, 20);
			this.maxElementsReturnedCtrl_.TabIndex = 3;
			// 
			// ElementNameFilterTB
			// 
            this.elementNameFilterTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.elementNameFilterTb_.Location = new System.Drawing.Point(112, 48);
			this.elementNameFilterTb_.Name = "elementNameFilterTb_";
			this.elementNameFilterTb_.Size = new System.Drawing.Size(240, 20);
			this.elementNameFilterTb_.TabIndex = 5;
			// 
			// ReturnPropertiesLB
			// 
			this.returnPropertiesLb_.Location = new System.Drawing.Point(0, 96);
			this.returnPropertiesLb_.Name = "returnPropertiesLb_";
			this.returnPropertiesLb_.Size = new System.Drawing.Size(112, 23);
			this.returnPropertiesLb_.TabIndex = 8;
			this.returnPropertiesLb_.Text = "Return Properties";
			this.returnPropertiesLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ElementNameFilterLB
			// 
			this.elementNameFilterLb_.Location = new System.Drawing.Point(0, 48);
			this.elementNameFilterLb_.Name = "elementNameFilterLb_";
			this.elementNameFilterLb_.Size = new System.Drawing.Size(112, 23);
			this.elementNameFilterLb_.TabIndex = 4;
			this.elementNameFilterLb_.Text = "Element Name Filter";
			this.elementNameFilterLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReturnPropertiesCB
			// 
			this.returnPropertiesCb_.Checked = true;
			this.returnPropertiesCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.returnPropertiesCb_.Location = new System.Drawing.Point(112, 96);
			this.returnPropertiesCb_.Name = "returnPropertiesCb_";
			this.returnPropertiesCb_.Size = new System.Drawing.Size(16, 24);
			this.returnPropertiesCb_.TabIndex = 9;
			this.returnPropertiesCb_.CheckedChanged += new System.EventHandler(this.ReturnPropertiesCB_CheckedChanged);
			// 
			// VendorFilterLB
			// 
			this.vendorFilterLb_.Location = new System.Drawing.Point(0, 72);
			this.vendorFilterLb_.Name = "vendorFilterLb_";
			this.vendorFilterLb_.Size = new System.Drawing.Size(112, 23);
			this.vendorFilterLb_.TabIndex = 6;
			this.vendorFilterLb_.Text = "Vendor Filter";
			this.vendorFilterLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VendorFilterTB
			// 
            this.vendorFilterTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.vendorFilterTb_.Location = new System.Drawing.Point(112, 72);
			this.vendorFilterTb_.Name = "vendorFilterTb_";
			this.vendorFilterTb_.Size = new System.Drawing.Size(240, 20);
			this.vendorFilterTb_.TabIndex = 7;
			// 
			// BrowseFilterLB
			// 
            this.browseFilterLb_.Location = new System.Drawing.Point(0, 0);
			this.browseFilterLb_.Name = "browseFilterLb_";
			this.browseFilterLb_.Size = new System.Drawing.Size(112, 23);
			this.browseFilterLb_.TabIndex = 0;
			this.browseFilterLb_.Text = "Browse Filter";
			this.browseFilterLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BrowseFilterCTRL
			// 
			this.browseFilterCtrl_.Location = new System.Drawing.Point(112, 0);
			this.browseFilterCtrl_.Name = "browseFilterCtrl_";
			this.browseFilterCtrl_.Size = new System.Drawing.Size(152, 24);
			this.browseFilterCtrl_.TabIndex = 1;
            this.browseFilterCtrl_.Value = null;
			// 
			// MaxElementsReturnedLB
			// 
			this.maxElementsReturnedLb_.Location = new System.Drawing.Point(0, 24);
			this.maxElementsReturnedLb_.Name = "maxElementsReturnedLb_";
			this.maxElementsReturnedLb_.Size = new System.Drawing.Size(112, 23);
			this.maxElementsReturnedLb_.TabIndex = 2;
			this.maxElementsReturnedLb_.Text = "Maximum Returned";
			this.maxElementsReturnedLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
            this.topPn_.Controls.Add(this.elementNameFilterTb_);
            this.topPn_.Controls.Add(this.maxElementsReturnedCtrl_);
            this.topPn_.Controls.Add(this.browseFilterCtrl_);
            this.topPn_.Controls.Add(this.browseFilterLb_);
            this.topPn_.Controls.Add(this.returnPropertiesLb_);
            this.topPn_.Controls.Add(this.vendorFilterLb_);
            this.topPn_.Controls.Add(this.maxElementsReturnedLb_);
            this.topPn_.Controls.Add(this.returnPropertiesCb_);
            this.topPn_.Controls.Add(this.elementNameFilterLb_);
            this.topPn_.Controls.Add(this.vendorFilterTb_);
			this.topPn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.topPn_.Location = new System.Drawing.Point(4, 4);
			this.topPn_.Name = "topPn_";
			this.topPn_.Size = new System.Drawing.Size(360, 120);
			this.topPn_.TabIndex = 32;
			// 
			// BrowseFiltersDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 310);
            this.Controls.Add(this.propertyFiltersCtrl_);
            this.Controls.Add(this.buttonsPn_);
            this.Controls.Add(this.topPn_);
			this.Name = "BrowseFiltersDlg";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Browse Filters";
			this.buttonsPn_.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.maxElementsReturnedCtrl_)).EndInit();
			this.topPn_.ResumeLayout(false);
            this.topPn_.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Called when the OK or Apply button is clicked.
		/// </summary>
		private BrowseFiltersChangedCallback mCallback_ = null;

		/// <summary>
		/// Displays the browse filters in a non-model dialog.
		/// </summary>
		public void Show(
			Form                         owner,
			TsCDaBrowseFilters                filters,
			BrowseFiltersChangedCallback callback)
		{
			if (callback == null) throw new ArgumentNullException("callback");

			Owner      = owner;
			mCallback_ = callback;

			browseFilterCtrl_.Value        = filters.BrowseFilter;
			maxElementsReturnedCtrl_.Value = (decimal)filters.MaxElementsReturned;
			elementNameFilterTb_.Text      = filters.ElementNameFilter;
			vendorFilterTb_.Text           = filters.VendorFilter;
			returnPropertiesCb_.Checked    = (filters.PropertyIDs != null || filters.ReturnAllProperties);

			propertyFiltersCtrl_.ReturnAllProperties  = filters.ReturnAllProperties;
			propertyFiltersCtrl_.ReturnPropertyValues = filters.ReturnPropertyValues;
			propertyFiltersCtrl_.PropertyIDs          = filters.PropertyIDs;

			Show();
		}

		/// <summary>
		/// Invokes the callback an passes the new browse filters.
		/// </summary>
		private void ApplyChanges()
		{
			TsCDaBrowseFilters filters = new TsCDaBrowseFilters();

			filters.BrowseFilter         = (TsCDaBrowseFilter)browseFilterCtrl_.Value;
			filters.MaxElementsReturned  = (int)maxElementsReturnedCtrl_.Value;
			filters.ElementNameFilter    = elementNameFilterTb_.Text;
			filters.VendorFilter         = vendorFilterTb_.Text;

			if (!returnPropertiesCb_.Checked)
			{
				filters.ReturnAllProperties  = false;
				filters.ReturnPropertyValues = false;
				filters.PropertyIDs          = null;
			}
			else
			{
				filters.ReturnAllProperties  = propertyFiltersCtrl_.ReturnAllProperties;
				filters.ReturnPropertyValues = propertyFiltersCtrl_.ReturnPropertyValues;

				if (!filters.ReturnAllProperties)
				{
					filters.PropertyIDs = propertyFiltersCtrl_.PropertyIDs;
				}
				else
				{
					filters.PropertyIDs = null;
				}
			}

			if (mCallback_ != null)
			{
				mCallback_(filters);
			}
		}

		/// <summary>
		/// Sends the updated filters notification and closes the form. 
		/// </summary>
		private void OkBTN_Click(object sender, System.EventArgs e)
		{
			ApplyChanges();
			Close();
		}

		/// <summary>
		/// Sends the updated filters notification. 
		/// </summary>
		private void ApplyBTN_Click(object sender, System.EventArgs e)
		{
			ApplyChanges();
		}
		/// <summary>
		/// Closes the form. 
		/// </summary>
		private void CancelBTN_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Toggles the state of the property filters control.
		/// </summary>
		private void ReturnPropertiesCB_CheckedChanged(object sender, System.EventArgs e)
		{
			propertyFiltersCtrl_.Enabled = returnPropertiesCb_.Checked;

			if (propertyFiltersCtrl_.Enabled)
			{
				if (propertyFiltersCtrl_.PropertyIDs.Length == 0)
				{
					propertyFiltersCtrl_.ReturnAllProperties = true;
				}
			}
		}
	}
}

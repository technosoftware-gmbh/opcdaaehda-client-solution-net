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
			okBtn_ = new System.Windows.Forms.Button();
			cancelBtn_ = new System.Windows.Forms.Button();
			buttonsPn_ = new System.Windows.Forms.Panel();
			applyBtn_ = new System.Windows.Forms.Button();
			propertyFiltersCtrl_ = new PropertyFiltersCtrl();
			maxElementsReturnedCtrl_ = new System.Windows.Forms.NumericUpDown();
			elementNameFilterTb_ = new System.Windows.Forms.TextBox();
			returnPropertiesLb_ = new System.Windows.Forms.Label();
			elementNameFilterLb_ = new System.Windows.Forms.Label();
			returnPropertiesCb_ = new System.Windows.Forms.CheckBox();
			vendorFilterLb_ = new System.Windows.Forms.Label();
			vendorFilterTb_ = new System.Windows.Forms.TextBox();
			browseFilterLb_ = new System.Windows.Forms.Label();
			browseFilterCtrl_ = new EnumCtrl();
			maxElementsReturnedLb_ = new System.Windows.Forms.Label();
			topPn_ = new System.Windows.Forms.Panel();
			buttonsPn_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(maxElementsReturnedCtrl_)).BeginInit();
			topPn_.SuspendLayout();
			SuspendLayout();
			// 
			// OkBTN
			// 
            okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            okBtn_.Location = new System.Drawing.Point(118, 6);
			okBtn_.Name = "okBtn_";
            okBtn_.Size = new System.Drawing.Size(75, 23);
			okBtn_.TabIndex = 1;
			okBtn_.Text = "OK";
			okBtn_.Click += new System.EventHandler(OkBTN_Click);
			// 
			// CancelBTN
			// 
            cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelBtn_.Location = new System.Drawing.Point(280, 6);
			cancelBtn_.Name = "cancelBtn_";
            cancelBtn_.Size = new System.Drawing.Size(75, 23);
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			cancelBtn_.Click += new System.EventHandler(CancelBTN_Click);
			// 
			// ButtonsPN
			// 
            buttonsPn_.Controls.Add(applyBtn_);
            buttonsPn_.Controls.Add(cancelBtn_);
            buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(4, 274);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(360, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// ApplyBTN
			// 
            applyBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            applyBtn_.Location = new System.Drawing.Point(199, 6);
			applyBtn_.Name = "applyBtn_";
            applyBtn_.Size = new System.Drawing.Size(75, 23);
			applyBtn_.TabIndex = 2;
			applyBtn_.Text = "Apply";
			applyBtn_.Click += new System.EventHandler(ApplyBTN_Click);
			// 
			// PropertyFiltersCTRL
			// 
			propertyFiltersCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			propertyFiltersCtrl_.Location = new System.Drawing.Point(4, 124);
			propertyFiltersCtrl_.Name = "propertyFiltersCtrl_";
			propertyFiltersCtrl_.PropertyIDs = new TsDaPropertyID[0];
			propertyFiltersCtrl_.ReturnAllProperties = true;
			propertyFiltersCtrl_.ReturnPropertyValues = true;
			propertyFiltersCtrl_.Size = new System.Drawing.Size(360, 150);
			propertyFiltersCtrl_.TabIndex = 0;
			// 
			// MaxElementsReturnedCTRL
			// 
			maxElementsReturnedCtrl_.Location = new System.Drawing.Point(112, 24);
			maxElementsReturnedCtrl_.Maximum = new System.Decimal(new int[] {
																					10000,
																					0,
																					0,
																					0});
			maxElementsReturnedCtrl_.Name = "maxElementsReturnedCtrl_";
			maxElementsReturnedCtrl_.Size = new System.Drawing.Size(72, 20);
			maxElementsReturnedCtrl_.TabIndex = 3;
			// 
			// ElementNameFilterTB
			// 
            elementNameFilterTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			elementNameFilterTb_.Location = new System.Drawing.Point(112, 48);
			elementNameFilterTb_.Name = "elementNameFilterTb_";
			elementNameFilterTb_.Size = new System.Drawing.Size(240, 20);
			elementNameFilterTb_.TabIndex = 5;
			// 
			// ReturnPropertiesLB
			// 
			returnPropertiesLb_.Location = new System.Drawing.Point(0, 96);
			returnPropertiesLb_.Name = "returnPropertiesLb_";
			returnPropertiesLb_.Size = new System.Drawing.Size(112, 23);
			returnPropertiesLb_.TabIndex = 8;
			returnPropertiesLb_.Text = "Return Properties";
			returnPropertiesLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ElementNameFilterLB
			// 
			elementNameFilterLb_.Location = new System.Drawing.Point(0, 48);
			elementNameFilterLb_.Name = "elementNameFilterLb_";
			elementNameFilterLb_.Size = new System.Drawing.Size(112, 23);
			elementNameFilterLb_.TabIndex = 4;
			elementNameFilterLb_.Text = "Element Name Filter";
			elementNameFilterLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReturnPropertiesCB
			// 
			returnPropertiesCb_.Checked = true;
			returnPropertiesCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			returnPropertiesCb_.Location = new System.Drawing.Point(112, 96);
			returnPropertiesCb_.Name = "returnPropertiesCb_";
			returnPropertiesCb_.Size = new System.Drawing.Size(16, 24);
			returnPropertiesCb_.TabIndex = 9;
			returnPropertiesCb_.CheckedChanged += new System.EventHandler(ReturnPropertiesCB_CheckedChanged);
			// 
			// VendorFilterLB
			// 
			vendorFilterLb_.Location = new System.Drawing.Point(0, 72);
			vendorFilterLb_.Name = "vendorFilterLb_";
			vendorFilterLb_.Size = new System.Drawing.Size(112, 23);
			vendorFilterLb_.TabIndex = 6;
			vendorFilterLb_.Text = "Vendor Filter";
			vendorFilterLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VendorFilterTB
			// 
            vendorFilterTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			vendorFilterTb_.Location = new System.Drawing.Point(112, 72);
			vendorFilterTb_.Name = "vendorFilterTb_";
			vendorFilterTb_.Size = new System.Drawing.Size(240, 20);
			vendorFilterTb_.TabIndex = 7;
			// 
			// BrowseFilterLB
			// 
            browseFilterLb_.Location = new System.Drawing.Point(0, 0);
			browseFilterLb_.Name = "browseFilterLb_";
			browseFilterLb_.Size = new System.Drawing.Size(112, 23);
			browseFilterLb_.TabIndex = 0;
			browseFilterLb_.Text = "Browse Filter";
			browseFilterLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BrowseFilterCTRL
			// 
			browseFilterCtrl_.Location = new System.Drawing.Point(112, 0);
			browseFilterCtrl_.Name = "browseFilterCtrl_";
			browseFilterCtrl_.Size = new System.Drawing.Size(152, 24);
			browseFilterCtrl_.TabIndex = 1;
            browseFilterCtrl_.Value = null;
			// 
			// MaxElementsReturnedLB
			// 
			maxElementsReturnedLb_.Location = new System.Drawing.Point(0, 24);
			maxElementsReturnedLb_.Name = "maxElementsReturnedLb_";
			maxElementsReturnedLb_.Size = new System.Drawing.Size(112, 23);
			maxElementsReturnedLb_.TabIndex = 2;
			maxElementsReturnedLb_.Text = "Maximum Returned";
			maxElementsReturnedLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
            topPn_.Controls.Add(elementNameFilterTb_);
            topPn_.Controls.Add(maxElementsReturnedCtrl_);
            topPn_.Controls.Add(browseFilterCtrl_);
            topPn_.Controls.Add(browseFilterLb_);
            topPn_.Controls.Add(returnPropertiesLb_);
            topPn_.Controls.Add(vendorFilterLb_);
            topPn_.Controls.Add(maxElementsReturnedLb_);
            topPn_.Controls.Add(returnPropertiesCb_);
            topPn_.Controls.Add(elementNameFilterLb_);
            topPn_.Controls.Add(vendorFilterTb_);
			topPn_.Dock = System.Windows.Forms.DockStyle.Top;
			topPn_.Location = new System.Drawing.Point(4, 4);
			topPn_.Name = "topPn_";
			topPn_.Size = new System.Drawing.Size(360, 120);
			topPn_.TabIndex = 32;
			// 
			// BrowseFiltersDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(368, 310);
            Controls.Add(propertyFiltersCtrl_);
            Controls.Add(buttonsPn_);
            Controls.Add(topPn_);
			Name = "BrowseFiltersDlg";
            Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Browse Filters";
			buttonsPn_.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(maxElementsReturnedCtrl_)).EndInit();
			topPn_.ResumeLayout(false);
            topPn_.PerformLayout();
			ResumeLayout(false);

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

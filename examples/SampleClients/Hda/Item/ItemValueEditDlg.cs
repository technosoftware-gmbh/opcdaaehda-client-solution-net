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
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Item
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class ItemValueEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel mainPn_;
		private System.Windows.Forms.Label valueLb_;
		private System.Windows.Forms.Label qualityLb_;
		private System.Windows.Forms.Label limitBitsLb_;
		private System.Windows.Forms.Label vendorBitsLb_;
		private System.Windows.Forms.NumericUpDown valueCtrl_;
		private System.Windows.Forms.NumericUpDown vendorBitsCtrl_;
		private System.Windows.Forms.ComboBox limitBitsCb_;
		private System.Windows.Forms.ComboBox qualityCb_;
		private System.Windows.Forms.Label timestampLb_;
		private System.Windows.Forms.DateTimePicker timestampCtrl_;
		private System.Windows.Forms.CheckBox valueSpecifiedCb_;
		private System.ComponentModel.IContainer components = null;

		public ItemValueEditDlg()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
            

			// populate quality drop down.
			qualityCb_.Items.Clear();

			foreach (TsDaQualityBits quality in Enum.GetValues(typeof(TsDaQualityBits)))
			{
				qualityCb_.Items.Add(quality);
			}

			// populate limit bits drop down.
			limitBitsCb_.Items.Clear();

			foreach (TsDaLimitBits limitBits in Enum.GetValues(typeof(TsDaLimitBits)))
			{
				limitBitsCb_.Items.Add(limitBits);
			}
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
			cancelBtn_ = new System.Windows.Forms.Button();
			buttonsPn_ = new System.Windows.Forms.Panel();
			okBtn_ = new System.Windows.Forms.Button();
			mainPn_ = new System.Windows.Forms.Panel();
			valueSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			timestampCtrl_ = new System.Windows.Forms.DateTimePicker();
			timestampLb_ = new System.Windows.Forms.Label();
			qualityCb_ = new System.Windows.Forms.ComboBox();
			limitBitsCb_ = new System.Windows.Forms.ComboBox();
			vendorBitsCtrl_ = new System.Windows.Forms.NumericUpDown();
			vendorBitsLb_ = new System.Windows.Forms.Label();
			limitBitsLb_ = new System.Windows.Forms.Label();
			qualityLb_ = new System.Windows.Forms.Label();
			valueLb_ = new System.Windows.Forms.Label();
			valueCtrl_ = new System.Windows.Forms.NumericUpDown();
			buttonsPn_.SuspendLayout();
			mainPn_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(vendorBitsCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(valueCtrl_)).BeginInit();
			SuspendLayout();
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(192, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 122);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(272, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// OkBTN
			// 
			okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			okBtn_.Location = new System.Drawing.Point(4, 8);
			okBtn_.Name = "okBtn_";
			okBtn_.TabIndex = 1;
			okBtn_.Text = "OK";
			// 
			// MainPN
			// 
			mainPn_.Controls.Add(valueSpecifiedCb_);
			mainPn_.Controls.Add(timestampCtrl_);
			mainPn_.Controls.Add(timestampLb_);
			mainPn_.Controls.Add(qualityCb_);
			mainPn_.Controls.Add(limitBitsCb_);
			mainPn_.Controls.Add(vendorBitsCtrl_);
			mainPn_.Controls.Add(vendorBitsLb_);
			mainPn_.Controls.Add(limitBitsLb_);
			mainPn_.Controls.Add(qualityLb_);
			mainPn_.Controls.Add(valueLb_);
			mainPn_.Controls.Add(valueCtrl_);
			mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			mainPn_.DockPadding.Left = 4;
			mainPn_.DockPadding.Right = 4;
			mainPn_.DockPadding.Top = 4;
			mainPn_.Location = new System.Drawing.Point(0, 0);
			mainPn_.Name = "mainPn_";
			mainPn_.Size = new System.Drawing.Size(272, 122);
			mainPn_.TabIndex = 1;
			// 
			// ValueSpecifiedCB
			// 
			valueSpecifiedCb_.Location = new System.Drawing.Point(252, 3);
			valueSpecifiedCb_.Name = "valueSpecifiedCb_";
			valueSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			valueSpecifiedCb_.TabIndex = 2;
			valueSpecifiedCb_.CheckedChanged += new System.EventHandler(ValueSpecifiedCB_CheckedChanged);
			// 
			// TimestampCTRL
			// 
			timestampCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			timestampCtrl_.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			timestampCtrl_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			timestampCtrl_.Location = new System.Drawing.Point(96, 28);
			timestampCtrl_.Name = "timestampCtrl_";
			timestampCtrl_.Size = new System.Drawing.Size(148, 20);
			timestampCtrl_.TabIndex = 4;
			// 
			// TimestampLB
			// 
			timestampLb_.Location = new System.Drawing.Point(4, 28);
			timestampLb_.Name = "timestampLb_";
			timestampLb_.Size = new System.Drawing.Size(92, 23);
			timestampLb_.TabIndex = 3;
			timestampLb_.Text = "Timestamp";
			timestampLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualityCB
			// 
			qualityCb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			qualityCb_.Location = new System.Drawing.Point(96, 52);
			qualityCb_.Name = "qualityCb_";
			qualityCb_.Size = new System.Drawing.Size(172, 21);
			qualityCb_.TabIndex = 6;
			// 
			// LimitBitsCB
			// 
			limitBitsCb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			limitBitsCb_.Location = new System.Drawing.Point(96, 76);
			limitBitsCb_.Name = "limitBitsCb_";
			limitBitsCb_.Size = new System.Drawing.Size(172, 21);
			limitBitsCb_.TabIndex = 8;
			// 
			// VendorBitsCTRL
			// 
			vendorBitsCtrl_.Location = new System.Drawing.Point(96, 100);
			vendorBitsCtrl_.Maximum = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			vendorBitsCtrl_.Name = "vendorBitsCtrl_";
			vendorBitsCtrl_.Size = new System.Drawing.Size(60, 20);
			vendorBitsCtrl_.TabIndex = 10;
			// 
			// VendorBitsLB
			// 
			vendorBitsLb_.Location = new System.Drawing.Point(4, 100);
			vendorBitsLb_.Name = "vendorBitsLb_";
			vendorBitsLb_.Size = new System.Drawing.Size(92, 23);
			vendorBitsLb_.TabIndex = 9;
			vendorBitsLb_.Text = "Vendor Bits";
			vendorBitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LimitBitsLB
			// 
			limitBitsLb_.Location = new System.Drawing.Point(4, 76);
			limitBitsLb_.Name = "limitBitsLb_";
			limitBitsLb_.Size = new System.Drawing.Size(92, 23);
			limitBitsLb_.TabIndex = 7;
			limitBitsLb_.Text = "Limit Bits";
			limitBitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualityLB
			// 
			qualityLb_.Location = new System.Drawing.Point(4, 52);
			qualityLb_.Name = "qualityLb_";
			qualityLb_.Size = new System.Drawing.Size(92, 23);
			qualityLb_.TabIndex = 5;
			qualityLb_.Text = "Quality";
			qualityLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueLB
			// 
			valueLb_.Location = new System.Drawing.Point(4, 4);
			valueLb_.Name = "valueLb_";
			valueLb_.Size = new System.Drawing.Size(92, 23);
			valueLb_.TabIndex = 0;
			valueLb_.Text = "Value";
			valueLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueCTRL
			// 
			valueCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			valueCtrl_.DecimalPlaces = 15;
			valueCtrl_.Enabled = false;
			valueCtrl_.Location = new System.Drawing.Point(96, 4);
			valueCtrl_.Name = "valueCtrl_";
			valueCtrl_.Size = new System.Drawing.Size(152, 20);
			valueCtrl_.TabIndex = 1;
			// 
			// ItemValueEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(272, 158);
			Controls.Add(mainPn_);
			Controls.Add(buttonsPn_);
			Name = "ItemValueEditDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Edit Item Value";
			buttonsPn_.ResumeLayout(false);
			mainPn_.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(vendorBitsCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(valueCtrl_)).EndInit();
			ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to edit an item value.
		/// </summary>
		public TsCHdaItemValue ShowDialog(TsCHdaItemValue item)
		{
			// create a new item if none provided.
			if (item == null) 
			{				
				item = new TsCHdaItemValue();
			}

			// initialize controls.
			valueCtrl_.Value          = System.Convert.ToDecimal(item.Value);
			valueSpecifiedCb_.Checked = item.Value != null;
			qualityCb_.SelectedItem   = item.Quality.QualityBits;
			limitBitsCb_.SelectedItem = item.Quality.LimitBits;
			vendorBitsCtrl_.Value     = item.Quality.VendorBits;

			if (timestampCtrl_.MinDate > item.Timestamp)
			{
				timestampCtrl_.Value = timestampCtrl_.MinDate;
			}
			else
			{
				timestampCtrl_.Value = item.Timestamp;
			}

			// display dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// update object.
			item = new TsCHdaItemValue();

			if (valueSpecifiedCb_.Checked)
			{
				item.Value = (double)valueCtrl_.Value;
			}

			TsCDaQuality quality = new TsCDaQuality();

			quality.QualityBits = (TsDaQualityBits)qualityCb_.SelectedItem;
			quality.LimitBits   = (TsDaLimitBits)limitBitsCb_.SelectedItem;
			quality.VendorBits  = (byte)vendorBitsCtrl_.Value;

			item.Quality = quality;
			
			if (timestampCtrl_.Value == timestampCtrl_.MinDate)
			{
				item.Timestamp = DateTime.MinValue;
			}
			else
			{
				item.Timestamp = timestampCtrl_.Value;
			}

			// return new value.
			return item;
		}
		#endregion

		/// <summary>
		/// Toggles the enabled state of the value control.
		/// </summary>
		private void ValueSpecifiedCB_CheckedChanged(object sender, System.EventArgs e)
		{
			 valueCtrl_.Enabled = valueSpecifiedCb_.Checked;
		}
	}
}

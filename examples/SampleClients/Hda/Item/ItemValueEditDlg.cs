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
            Icon = ClientUtils.GetAppIcon();

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
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.okBtn_ = new System.Windows.Forms.Button();
			this.mainPn_ = new System.Windows.Forms.Panel();
			this.valueSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.timestampCtrl_ = new System.Windows.Forms.DateTimePicker();
			this.timestampLb_ = new System.Windows.Forms.Label();
			this.qualityCb_ = new System.Windows.Forms.ComboBox();
			this.limitBitsCb_ = new System.Windows.Forms.ComboBox();
			this.vendorBitsCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.vendorBitsLb_ = new System.Windows.Forms.Label();
			this.limitBitsLb_ = new System.Windows.Forms.Label();
			this.qualityLb_ = new System.Windows.Forms.Label();
			this.valueLb_ = new System.Windows.Forms.Label();
			this.valueCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.buttonsPn_.SuspendLayout();
			this.mainPn_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vendorBitsCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.valueCtrl_)).BeginInit();
			this.SuspendLayout();
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(192, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 122);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(272, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// OkBTN
			// 
			this.okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn_.Location = new System.Drawing.Point(4, 8);
			this.okBtn_.Name = "okBtn_";
			this.okBtn_.TabIndex = 1;
			this.okBtn_.Text = "OK";
			// 
			// MainPN
			// 
			this.mainPn_.Controls.Add(this.valueSpecifiedCb_);
			this.mainPn_.Controls.Add(this.timestampCtrl_);
			this.mainPn_.Controls.Add(this.timestampLb_);
			this.mainPn_.Controls.Add(this.qualityCb_);
			this.mainPn_.Controls.Add(this.limitBitsCb_);
			this.mainPn_.Controls.Add(this.vendorBitsCtrl_);
			this.mainPn_.Controls.Add(this.vendorBitsLb_);
			this.mainPn_.Controls.Add(this.limitBitsLb_);
			this.mainPn_.Controls.Add(this.qualityLb_);
			this.mainPn_.Controls.Add(this.valueLb_);
			this.mainPn_.Controls.Add(this.valueCtrl_);
			this.mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPn_.DockPadding.Left = 4;
			this.mainPn_.DockPadding.Right = 4;
			this.mainPn_.DockPadding.Top = 4;
			this.mainPn_.Location = new System.Drawing.Point(0, 0);
			this.mainPn_.Name = "mainPn_";
			this.mainPn_.Size = new System.Drawing.Size(272, 122);
			this.mainPn_.TabIndex = 1;
			// 
			// ValueSpecifiedCB
			// 
			this.valueSpecifiedCb_.Location = new System.Drawing.Point(252, 3);
			this.valueSpecifiedCb_.Name = "valueSpecifiedCb_";
			this.valueSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.valueSpecifiedCb_.TabIndex = 2;
			this.valueSpecifiedCb_.CheckedChanged += new System.EventHandler(this.ValueSpecifiedCB_CheckedChanged);
			// 
			// TimestampCTRL
			// 
			this.timestampCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.timestampCtrl_.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.timestampCtrl_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.timestampCtrl_.Location = new System.Drawing.Point(96, 28);
			this.timestampCtrl_.Name = "timestampCtrl_";
			this.timestampCtrl_.Size = new System.Drawing.Size(148, 20);
			this.timestampCtrl_.TabIndex = 4;
			// 
			// TimestampLB
			// 
			this.timestampLb_.Location = new System.Drawing.Point(4, 28);
			this.timestampLb_.Name = "timestampLb_";
			this.timestampLb_.Size = new System.Drawing.Size(92, 23);
			this.timestampLb_.TabIndex = 3;
			this.timestampLb_.Text = "Timestamp";
			this.timestampLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualityCB
			// 
			this.qualityCb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.qualityCb_.Location = new System.Drawing.Point(96, 52);
			this.qualityCb_.Name = "qualityCb_";
			this.qualityCb_.Size = new System.Drawing.Size(172, 21);
			this.qualityCb_.TabIndex = 6;
			// 
			// LimitBitsCB
			// 
			this.limitBitsCb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.limitBitsCb_.Location = new System.Drawing.Point(96, 76);
			this.limitBitsCb_.Name = "limitBitsCb_";
			this.limitBitsCb_.Size = new System.Drawing.Size(172, 21);
			this.limitBitsCb_.TabIndex = 8;
			// 
			// VendorBitsCTRL
			// 
			this.vendorBitsCtrl_.Location = new System.Drawing.Point(96, 100);
			this.vendorBitsCtrl_.Maximum = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			this.vendorBitsCtrl_.Name = "vendorBitsCtrl_";
			this.vendorBitsCtrl_.Size = new System.Drawing.Size(60, 20);
			this.vendorBitsCtrl_.TabIndex = 10;
			// 
			// VendorBitsLB
			// 
			this.vendorBitsLb_.Location = new System.Drawing.Point(4, 100);
			this.vendorBitsLb_.Name = "vendorBitsLb_";
			this.vendorBitsLb_.Size = new System.Drawing.Size(92, 23);
			this.vendorBitsLb_.TabIndex = 9;
			this.vendorBitsLb_.Text = "Vendor Bits";
			this.vendorBitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LimitBitsLB
			// 
			this.limitBitsLb_.Location = new System.Drawing.Point(4, 76);
			this.limitBitsLb_.Name = "limitBitsLb_";
			this.limitBitsLb_.Size = new System.Drawing.Size(92, 23);
			this.limitBitsLb_.TabIndex = 7;
			this.limitBitsLb_.Text = "Limit Bits";
			this.limitBitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualityLB
			// 
			this.qualityLb_.Location = new System.Drawing.Point(4, 52);
			this.qualityLb_.Name = "qualityLb_";
			this.qualityLb_.Size = new System.Drawing.Size(92, 23);
			this.qualityLb_.TabIndex = 5;
			this.qualityLb_.Text = "Quality";
			this.qualityLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueLB
			// 
			this.valueLb_.Location = new System.Drawing.Point(4, 4);
			this.valueLb_.Name = "valueLb_";
			this.valueLb_.Size = new System.Drawing.Size(92, 23);
			this.valueLb_.TabIndex = 0;
			this.valueLb_.Text = "Value";
			this.valueLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueCTRL
			// 
			this.valueCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.valueCtrl_.DecimalPlaces = 15;
			this.valueCtrl_.Enabled = false;
			this.valueCtrl_.Location = new System.Drawing.Point(96, 4);
			this.valueCtrl_.Name = "valueCtrl_";
			this.valueCtrl_.Size = new System.Drawing.Size(152, 20);
			this.valueCtrl_.TabIndex = 1;
			// 
			// ItemValueEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 158);
			this.Controls.Add(this.mainPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "ItemValueEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Item Value";
			this.buttonsPn_.ResumeLayout(false);
			this.mainPn_.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.vendorBitsCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.valueCtrl_)).EndInit();
			this.ResumeLayout(false);

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

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

using Technosoftware.DaAeHdaClient;
using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da.ItemValue
{
    /// <summary>
    /// A control used to display and edit the contents of an ItemValue object.
    /// </summary>
    public class ItemValueEditCtrl : System.Windows.Forms.UserControl, IEditObjectCtrl
	{
		private System.Windows.Forms.Label itemNameLb_;
		private System.Windows.Forms.TextBox itemNameTb_;
		private System.Windows.Forms.TextBox itemPathTb_;
		private System.Windows.Forms.Label itemPathLb_;
		private System.Windows.Forms.Label timestampLb_;
		private System.Windows.Forms.Label valueLb_;
		private System.Windows.Forms.CheckBox timestampSpecifiedCb_;
		private System.Windows.Forms.CheckBox qualitySpecifiedCb_;
		private System.Windows.Forms.NumericUpDown vendorBitsCtrl_;
		private System.Windows.Forms.Label qualityBitsLb_;
		private System.Windows.Forms.CheckBox valueSpecifiedCb_;
		private EnumCtrl qualityBitsCtrl_;
		private EnumCtrl limitBitsCtrl_;
		private System.Windows.Forms.Label limitBitsLb_;
		private System.Windows.Forms.Label vendorBitsLb_;
		private ValueCtrl valueCtrl_;
		private System.Windows.Forms.DateTimePicker timestampCtrl_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ItemValueEditCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.itemNameLb_ = new System.Windows.Forms.Label();
			this.timestampLb_ = new System.Windows.Forms.Label();
			this.valueLb_ = new System.Windows.Forms.Label();
			this.itemNameTb_ = new System.Windows.Forms.TextBox();
			this.timestampSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.itemPathTb_ = new System.Windows.Forms.TextBox();
			this.itemPathLb_ = new System.Windows.Forms.Label();
			this.qualitySpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.vendorBitsCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.qualityBitsLb_ = new System.Windows.Forms.Label();
			this.valueSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.qualityBitsCtrl_ = new EnumCtrl();
			this.limitBitsCtrl_ = new EnumCtrl();
			this.limitBitsLb_ = new System.Windows.Forms.Label();
			this.vendorBitsLb_ = new System.Windows.Forms.Label();
			this.valueCtrl_ = new ValueCtrl();
			this.timestampCtrl_ = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.vendorBitsCtrl_)).BeginInit();
			this.SuspendLayout();
			// 
			// ItemNameLB
			// 
			this.itemNameLb_.Name = "itemNameLb_";
			this.itemNameLb_.TabIndex = 0;
			this.itemNameLb_.Text = "Item Name";
			this.itemNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TimestampLB
			// 
			this.timestampLb_.Location = new System.Drawing.Point(0, 144);
			this.timestampLb_.Name = "timestampLb_";
			this.timestampLb_.TabIndex = 1;
			this.timestampLb_.Text = "Timestamp";
			this.timestampLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueLB
			// 
			this.valueLb_.Location = new System.Drawing.Point(0, 48);
			this.valueLb_.Name = "valueLb_";
			this.valueLb_.TabIndex = 3;
			this.valueLb_.Text = "Value";
			this.valueLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameTB
			// 
			this.itemNameTb_.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.itemNameTb_.Location = new System.Drawing.Point(104, 0);
			this.itemNameTb_.Name = "itemNameTb_";
			this.itemNameTb_.ReadOnly = true;
			this.itemNameTb_.Size = new System.Drawing.Size(248, 20);
			this.itemNameTb_.TabIndex = 8;
			this.itemNameTb_.Text = "";
			// 
			// TimestampSpecifiedCB
			// 
			this.timestampSpecifiedCb_.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.timestampSpecifiedCb_.Checked = true;
			this.timestampSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.timestampSpecifiedCb_.Location = new System.Drawing.Point(336, 143);
			this.timestampSpecifiedCb_.Name = "timestampSpecifiedCb_";
			this.timestampSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.timestampSpecifiedCb_.TabIndex = 20;
			this.timestampSpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// ItemPathTB
			// 
			this.itemPathTb_.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.itemPathTb_.Location = new System.Drawing.Point(104, 24);
			this.itemPathTb_.Name = "itemPathTb_";
			this.itemPathTb_.ReadOnly = true;
			this.itemPathTb_.Size = new System.Drawing.Size(248, 20);
			this.itemPathTb_.TabIndex = 27;
			this.itemPathTb_.Text = "";
			// 
			// ItemPathLB
			// 
			this.itemPathLb_.Location = new System.Drawing.Point(0, 24);
			this.itemPathLb_.Name = "itemPathLb_";
			this.itemPathLb_.TabIndex = 26;
			this.itemPathLb_.Text = "Item Path";
			this.itemPathLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualitySpecifiedCB
			// 
			this.qualitySpecifiedCb_.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.qualitySpecifiedCb_.Checked = true;
			this.qualitySpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.qualitySpecifiedCb_.Location = new System.Drawing.Point(336, 71);
			this.qualitySpecifiedCb_.Name = "qualitySpecifiedCb_";
			this.qualitySpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.qualitySpecifiedCb_.TabIndex = 30;
			this.qualitySpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// VendorBitsCTRL
			// 
			this.vendorBitsCtrl_.Location = new System.Drawing.Point(104, 121);
			this.vendorBitsCtrl_.Maximum = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			this.vendorBitsCtrl_.Name = "vendorBitsCtrl_";
			this.vendorBitsCtrl_.Size = new System.Drawing.Size(80, 20);
			this.vendorBitsCtrl_.TabIndex = 29;
			// 
			// QualityBitsLB
			// 
			this.qualityBitsLb_.Location = new System.Drawing.Point(0, 72);
			this.qualityBitsLb_.Name = "qualityBitsLb_";
			this.qualityBitsLb_.TabIndex = 28;
			this.qualityBitsLb_.Text = "Quality Bits";
			this.qualityBitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueSpecifiedCB
			// 
			this.valueSpecifiedCb_.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.valueSpecifiedCb_.Checked = true;
			this.valueSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.valueSpecifiedCb_.Location = new System.Drawing.Point(336, 48);
			this.valueSpecifiedCb_.Name = "valueSpecifiedCb_";
			this.valueSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.valueSpecifiedCb_.TabIndex = 31;
			this.valueSpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// QualityBitsCTRL
			// 
			this.qualityBitsCtrl_.Location = new System.Drawing.Point(104, 71);
			this.qualityBitsCtrl_.Name = "qualityBitsCtrl_";
			this.qualityBitsCtrl_.Size = new System.Drawing.Size(152, 24);
			this.qualityBitsCtrl_.TabIndex = 32;
			// 
			// LimitBitsCTRL
			// 
			this.limitBitsCtrl_.Location = new System.Drawing.Point(104, 95);
			this.limitBitsCtrl_.Name = "limitBitsCtrl_";
			this.limitBitsCtrl_.Size = new System.Drawing.Size(80, 24);
			this.limitBitsCtrl_.TabIndex = 34;
			// 
			// LimitBitsLB
			// 
			this.limitBitsLb_.Location = new System.Drawing.Point(0, 96);
			this.limitBitsLb_.Name = "limitBitsLb_";
			this.limitBitsLb_.TabIndex = 33;
			this.limitBitsLb_.Text = "Limit Bits";
			this.limitBitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VendorBitsLB
			// 
			this.vendorBitsLb_.Location = new System.Drawing.Point(0, 120);
			this.vendorBitsLb_.Name = "vendorBitsLb_";
			this.vendorBitsLb_.TabIndex = 35;
			this.vendorBitsLb_.Text = "Vendor Bits";
			this.vendorBitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueCTRL
			// 
			this.valueCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.valueCtrl_.Location = new System.Drawing.Point(104, 49);
			this.valueCtrl_.Name = "valueCtrl_";
			this.valueCtrl_.Size = new System.Drawing.Size(224, 20);
			this.valueCtrl_.TabIndex = 36;
			// 
			// TimestampCTRL
			// 
			this.timestampCtrl_.CustomFormat = "yyyy/MM/dd HH:mm:ss";
			this.timestampCtrl_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.timestampCtrl_.Location = new System.Drawing.Point(104, 145);
			this.timestampCtrl_.Name = "timestampCtrl_";
			this.timestampCtrl_.ShowUpDown = true;
			this.timestampCtrl_.Size = new System.Drawing.Size(136, 20);
			this.timestampCtrl_.TabIndex = 37;
			// 
			// ItemValueEditCtrl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.timestampCtrl_,
																		  this.valueCtrl_,
																		  this.vendorBitsLb_,
																		  this.limitBitsCtrl_,
																		  this.limitBitsLb_,
																		  this.qualityBitsCtrl_,
																		  this.valueSpecifiedCb_,
																		  this.qualitySpecifiedCb_,
																		  this.vendorBitsCtrl_,
																		  this.qualityBitsLb_,
																		  this.itemPathTb_,
																		  this.itemPathLb_,
																		  this.timestampSpecifiedCb_,
																		  this.itemNameTb_,
																		  this.valueLb_,
																		  this.timestampLb_,
																		  this.itemNameLb_});
			this.Name = "ItemValueEditCtrl";
			this.Size = new System.Drawing.Size(360, 168);
			((System.ComponentModel.ISupportInitialize)(this.vendorBitsCtrl_)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The item identifier passed to the control.
		/// </summary>
		private OpcItem mIdentifier_ = null;
		
		/// <summary>
		/// Whether changes to the item name and item path are allowed.
		/// </summary>
		public bool AllowEditItemId 
		{
			get	{return !itemNameTb_.ReadOnly;}
 
			set
			{
				itemNameTb_.ReadOnly = !value;
				itemPathTb_.ReadOnly = !value;
			}
		}
		
		//======================================================================
		// IEditObjectCtrl

		/// <summary>
		/// Set all fields to default values.
		/// </summary>
		public void SetDefaults()
		{
			itemNameTb_.Text              = null;
			itemPathTb_.Text              = null;
			valueCtrl_.ItemID             = null;
			valueCtrl_.Value              = null;
			valueSpecifiedCb_.Checked     = false;
			qualitySpecifiedCb_.Checked   = false;
			qualityBitsCtrl_.Value        = TsDaQualityBits.Bad;
			limitBitsCtrl_.Value          = TsDaLimitBits.None;
			vendorBitsCtrl_.Value         = 0;
			timestampCtrl_.Value          = timestampCtrl_.MinDate;
			timestampSpecifiedCb_.Checked = false;
		}

		/// <summary>
		/// Copy values from control into object - throw exceptions on error.
		/// </summary>
		public object Get()
		{
			TsCDaItemValue item = new TsCDaItemValue(mIdentifier_);

			item.ItemName = itemNameTb_.Text;
			item.ItemPath = itemPathTb_.Text;

			item.Value = (valueSpecifiedCb_.Checked)?valueCtrl_.Value:null;

			// set quality fields.
			item.Quality = TsCDaQuality.Bad;

			if (qualitySpecifiedCb_.Checked)
			{
				TsCDaQuality quality = new TsCDaQuality();

				quality.QualityBits = (TsDaQualityBits)qualityBitsCtrl_.Value;
				quality.LimitBits   = (TsDaLimitBits)limitBitsCtrl_.Value;
				quality.VendorBits  = (byte)vendorBitsCtrl_.Value;

				item.Quality = quality;
			}

			item.QualitySpecified = qualitySpecifiedCb_.Checked;

			// set timestamp - jump through some hoops to handle invalid values.
			item.Timestamp = DateTime.MinValue;

			if (timestampSpecifiedCb_.Checked)
			{
				item.Timestamp = (timestampCtrl_.Value > timestampCtrl_.MinDate)?timestampCtrl_.Value:DateTime.MinValue;
			}

			item.TimestampSpecified = timestampSpecifiedCb_.Checked;
		
			return item;
		}
		
		/// <summary>
		/// Copy object values into controls.
		/// </summary>
		public void Set(object value)
		{
			// check for null value.
			if (value == null) { SetDefaults(); return; }

			// cast value to item object.
			TsCDaItemValue item = (TsCDaItemValue)value;

			// save item identifier (including client and server handles).
			mIdentifier_ = new OpcItem(item);

			itemNameTb_.Text              = item.ItemName;
			itemPathTb_.Text              = item.ItemPath;
			valueCtrl_.ItemID             = new OpcItem(item);
			valueCtrl_.Value              = item.Value;
			valueSpecifiedCb_.Checked     = item.Value != null;
			qualitySpecifiedCb_.Checked   = item.QualitySpecified;
			qualityBitsCtrl_.Value        = item.Quality.QualityBits;
			limitBitsCtrl_.Value          = item.Quality.LimitBits;
			vendorBitsCtrl_.Value         = item.Quality.VendorBits;
			timestampCtrl_.Value          = timestampCtrl_.MinDate;
			timestampSpecifiedCb_.Checked = item.TimestampSpecified;

			// set timestamp - jump through some hoops to handle invalid values.
			if (item.TimestampSpecified)
			{
				timestampCtrl_.Value = (item.Timestamp > timestampCtrl_.MinDate)?item.Timestamp:timestampCtrl_.MinDate;
			}
		}

		/// <summary>
		/// Creates a new object.
		/// </summary>
		public object Create()
		{
			TsCDaItemValue item = new TsCDaItemValue(mIdentifier_);

			item.Value              = null;
			item.Quality            = TsCDaQuality.Bad;
			item.QualitySpecified   = false;
			item.Timestamp          = DateTime.MinValue;
			item.TimestampSpecified = false;

			return item;
		}

		/// <summary>
		/// Toggles the enabled state of controls based on the specified check boxes.
		/// </summary>
		private void Specified_CheckedChanged(object sender, System.EventArgs e)
		{			
			valueCtrl_.Enabled       = valueSpecifiedCb_.Checked;
			qualityBitsCtrl_.Enabled = qualitySpecifiedCb_.Checked;
			limitBitsCtrl_.Enabled   = qualitySpecifiedCb_.Checked;
			vendorBitsCtrl_.Enabled  = qualitySpecifiedCb_.Checked;

			// set timestamp to now when enabling timestamp.
			if (!timestampCtrl_.Enabled && timestampSpecifiedCb_.Checked)
			{
				timestampCtrl_.Enabled = true;
				timestampCtrl_.Value   = DateTime.Now;
			}

			// set timestamp to inavalid date when disabling timestamp.
			if (timestampCtrl_.Enabled && !timestampSpecifiedCb_.Checked)
			{
				timestampCtrl_.Enabled = false;
				timestampCtrl_.Value   = timestampCtrl_.MinDate;
			}
		}
	}
}

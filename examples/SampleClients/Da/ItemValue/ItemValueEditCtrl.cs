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
			itemNameLb_ = new System.Windows.Forms.Label();
			timestampLb_ = new System.Windows.Forms.Label();
			valueLb_ = new System.Windows.Forms.Label();
			itemNameTb_ = new System.Windows.Forms.TextBox();
			timestampSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			itemPathTb_ = new System.Windows.Forms.TextBox();
			itemPathLb_ = new System.Windows.Forms.Label();
			qualitySpecifiedCb_ = new System.Windows.Forms.CheckBox();
			vendorBitsCtrl_ = new System.Windows.Forms.NumericUpDown();
			qualityBitsLb_ = new System.Windows.Forms.Label();
			valueSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			qualityBitsCtrl_ = new EnumCtrl();
			limitBitsCtrl_ = new EnumCtrl();
			limitBitsLb_ = new System.Windows.Forms.Label();
			vendorBitsLb_ = new System.Windows.Forms.Label();
			valueCtrl_ = new ValueCtrl();
			timestampCtrl_ = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(vendorBitsCtrl_)).BeginInit();
			SuspendLayout();
			// 
			// ItemNameLB
			// 
			itemNameLb_.Name = "itemNameLb_";
			itemNameLb_.TabIndex = 0;
			itemNameLb_.Text = "Item Name";
			itemNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TimestampLB
			// 
			timestampLb_.Location = new System.Drawing.Point(0, 144);
			timestampLb_.Name = "timestampLb_";
			timestampLb_.TabIndex = 1;
			timestampLb_.Text = "Timestamp";
			timestampLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueLB
			// 
			valueLb_.Location = new System.Drawing.Point(0, 48);
			valueLb_.Name = "valueLb_";
			valueLb_.TabIndex = 3;
			valueLb_.Text = "Value";
			valueLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameTB
			// 
			itemNameTb_.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			itemNameTb_.Location = new System.Drawing.Point(104, 0);
			itemNameTb_.Name = "itemNameTb_";
			itemNameTb_.ReadOnly = true;
			itemNameTb_.Size = new System.Drawing.Size(248, 20);
			itemNameTb_.TabIndex = 8;
			itemNameTb_.Text = "";
			// 
			// TimestampSpecifiedCB
			// 
			timestampSpecifiedCb_.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			timestampSpecifiedCb_.Checked = true;
			timestampSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			timestampSpecifiedCb_.Location = new System.Drawing.Point(336, 143);
			timestampSpecifiedCb_.Name = "timestampSpecifiedCb_";
			timestampSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			timestampSpecifiedCb_.TabIndex = 20;
			timestampSpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// ItemPathTB
			// 
			itemPathTb_.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			itemPathTb_.Location = new System.Drawing.Point(104, 24);
			itemPathTb_.Name = "itemPathTb_";
			itemPathTb_.ReadOnly = true;
			itemPathTb_.Size = new System.Drawing.Size(248, 20);
			itemPathTb_.TabIndex = 27;
			itemPathTb_.Text = "";
			// 
			// ItemPathLB
			// 
			itemPathLb_.Location = new System.Drawing.Point(0, 24);
			itemPathLb_.Name = "itemPathLb_";
			itemPathLb_.TabIndex = 26;
			itemPathLb_.Text = "Item Path";
			itemPathLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualitySpecifiedCB
			// 
			qualitySpecifiedCb_.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			qualitySpecifiedCb_.Checked = true;
			qualitySpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			qualitySpecifiedCb_.Location = new System.Drawing.Point(336, 71);
			qualitySpecifiedCb_.Name = "qualitySpecifiedCb_";
			qualitySpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			qualitySpecifiedCb_.TabIndex = 30;
			qualitySpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// VendorBitsCTRL
			// 
			vendorBitsCtrl_.Location = new System.Drawing.Point(104, 121);
			vendorBitsCtrl_.Maximum = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			vendorBitsCtrl_.Name = "vendorBitsCtrl_";
			vendorBitsCtrl_.Size = new System.Drawing.Size(80, 20);
			vendorBitsCtrl_.TabIndex = 29;
			// 
			// QualityBitsLB
			// 
			qualityBitsLb_.Location = new System.Drawing.Point(0, 72);
			qualityBitsLb_.Name = "qualityBitsLb_";
			qualityBitsLb_.TabIndex = 28;
			qualityBitsLb_.Text = "Quality Bits";
			qualityBitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueSpecifiedCB
			// 
			valueSpecifiedCb_.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			valueSpecifiedCb_.Checked = true;
			valueSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			valueSpecifiedCb_.Location = new System.Drawing.Point(336, 48);
			valueSpecifiedCb_.Name = "valueSpecifiedCb_";
			valueSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			valueSpecifiedCb_.TabIndex = 31;
			valueSpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// QualityBitsCTRL
			// 
			qualityBitsCtrl_.Location = new System.Drawing.Point(104, 71);
			qualityBitsCtrl_.Name = "qualityBitsCtrl_";
			qualityBitsCtrl_.Size = new System.Drawing.Size(152, 24);
			qualityBitsCtrl_.TabIndex = 32;
			// 
			// LimitBitsCTRL
			// 
			limitBitsCtrl_.Location = new System.Drawing.Point(104, 95);
			limitBitsCtrl_.Name = "limitBitsCtrl_";
			limitBitsCtrl_.Size = new System.Drawing.Size(80, 24);
			limitBitsCtrl_.TabIndex = 34;
			// 
			// LimitBitsLB
			// 
			limitBitsLb_.Location = new System.Drawing.Point(0, 96);
			limitBitsLb_.Name = "limitBitsLb_";
			limitBitsLb_.TabIndex = 33;
			limitBitsLb_.Text = "Limit Bits";
			limitBitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VendorBitsLB
			// 
			vendorBitsLb_.Location = new System.Drawing.Point(0, 120);
			vendorBitsLb_.Name = "vendorBitsLb_";
			vendorBitsLb_.TabIndex = 35;
			vendorBitsLb_.Text = "Vendor Bits";
			vendorBitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueCTRL
			// 
			valueCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			valueCtrl_.Location = new System.Drawing.Point(104, 49);
			valueCtrl_.Name = "valueCtrl_";
			valueCtrl_.Size = new System.Drawing.Size(224, 20);
			valueCtrl_.TabIndex = 36;
			// 
			// TimestampCTRL
			// 
			timestampCtrl_.CustomFormat = "yyyy/MM/dd HH:mm:ss";
			timestampCtrl_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			timestampCtrl_.Location = new System.Drawing.Point(104, 145);
			timestampCtrl_.Name = "timestampCtrl_";
			timestampCtrl_.ShowUpDown = true;
			timestampCtrl_.Size = new System.Drawing.Size(136, 20);
			timestampCtrl_.TabIndex = 37;
			// 
			// ItemValueEditCtrl
			// 
			Controls.AddRange(new System.Windows.Forms.Control[] {
																		  timestampCtrl_,
																		  valueCtrl_,
																		  vendorBitsLb_,
																		  limitBitsCtrl_,
																		  limitBitsLb_,
																		  qualityBitsCtrl_,
																		  valueSpecifiedCb_,
																		  qualitySpecifiedCb_,
																		  vendorBitsCtrl_,
																		  qualityBitsLb_,
																		  itemPathTb_,
																		  itemPathLb_,
																		  timestampSpecifiedCb_,
																		  itemNameTb_,
																		  valueLb_,
																		  timestampLb_,
																		  itemNameLb_});
			Name = "ItemValueEditCtrl";
			Size = new System.Drawing.Size(360, 168);
			((System.ComponentModel.ISupportInitialize)(vendorBitsCtrl_)).EndInit();
			ResumeLayout(false);

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

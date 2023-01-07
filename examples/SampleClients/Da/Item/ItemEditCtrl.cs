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

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Cpx;
using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da.Item
{
    /// <summary>
    /// A control used to display and edit the contents of an Item object.
    /// </summary>
    public class ItemEditCtrl : System.Windows.Forms.UserControl, IEditObjectCtrl
	{
		private System.Windows.Forms.Label activeLb_;
		private System.Windows.Forms.Label reqTypeLb_;
		private System.Windows.Forms.Label deadbandLb_;
		private System.Windows.Forms.Label enableBufferingLb_;
		private System.Windows.Forms.CheckBox activeCb_;
		private System.Windows.Forms.NumericUpDown deadbandCtrl_;
		private System.Windows.Forms.CheckBox enableBufferingCb_;
		private System.Windows.Forms.CheckBox enableBufferSpecifiedCb_;
		private DataTypeCtrl reqTypeCtrl_;
		private System.Windows.Forms.Label itemNameLb_;
		private System.Windows.Forms.TextBox itemNameTb_;
		private System.Windows.Forms.TextBox itemPathTb_;
		private System.Windows.Forms.Label itemPathLb_;
		private System.Windows.Forms.Label samplingRateLb_;
		private System.Windows.Forms.NumericUpDown samplingRateCtrl_;
		private System.Windows.Forms.NumericUpDown maxAgeCtrl_;
		private System.Windows.Forms.Label maxAgeLb_;
		private System.Windows.Forms.CheckBox deadbandSpecifiedCb_;
		private System.Windows.Forms.CheckBox activeSpecifiedCb_;
		private System.Windows.Forms.CheckBox samplingRateSpecifiedCb_;
		private System.Windows.Forms.CheckBox maxAgeSpecifiedCb_;
		private System.Windows.Forms.CheckBox reqTypeSpecifiedCb_;
		private System.Windows.Forms.Panel readPn_;
		private System.Windows.Forms.Panel topPn_;
		private System.Windows.Forms.Panel subscribePn_;
		private System.Windows.Forms.Label typeConversionLb_;
		private System.Windows.Forms.ComboBox typeConversionCb_;
		private System.Windows.Forms.Label dataFilterLn_;
		private System.Windows.Forms.TextBox dataFilterTb_;
		private System.Windows.Forms.Panel complexItemPn_;
		private System.Windows.Forms.CheckBox dataFilterSpecifiedCb_;
		private System.Windows.Forms.CheckBox typeConversionSpecifiedCb_;
		private System.Windows.Forms.Panel reqTypePn_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ItemEditCtrl()
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
			activeLb_ = new System.Windows.Forms.Label();
			reqTypeLb_ = new System.Windows.Forms.Label();
			samplingRateLb_ = new System.Windows.Forms.Label();
			deadbandLb_ = new System.Windows.Forms.Label();
			enableBufferingLb_ = new System.Windows.Forms.Label();
			itemNameTb_ = new System.Windows.Forms.TextBox();
			activeCb_ = new System.Windows.Forms.CheckBox();
			samplingRateCtrl_ = new System.Windows.Forms.NumericUpDown();
			deadbandCtrl_ = new System.Windows.Forms.NumericUpDown();
			enableBufferingCb_ = new System.Windows.Forms.CheckBox();
			deadbandSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			activeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			samplingRateSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			enableBufferSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			reqTypeCtrl_ = new DataTypeCtrl();
			itemPathTb_ = new System.Windows.Forms.TextBox();
			itemPathLb_ = new System.Windows.Forms.Label();
			maxAgeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			maxAgeCtrl_ = new System.Windows.Forms.NumericUpDown();
			maxAgeLb_ = new System.Windows.Forms.Label();
			reqTypeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			subscribePn_ = new System.Windows.Forms.Panel();
			readPn_ = new System.Windows.Forms.Panel();
			topPn_ = new System.Windows.Forms.Panel();
			typeConversionLb_ = new System.Windows.Forms.Label();
			typeConversionCb_ = new System.Windows.Forms.ComboBox();
			dataFilterLn_ = new System.Windows.Forms.Label();
			dataFilterTb_ = new System.Windows.Forms.TextBox();
			complexItemPn_ = new System.Windows.Forms.Panel();
			dataFilterSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			typeConversionSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			reqTypePn_ = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(samplingRateCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(deadbandCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(maxAgeCtrl_)).BeginInit();
			subscribePn_.SuspendLayout();
			readPn_.SuspendLayout();
			topPn_.SuspendLayout();
			complexItemPn_.SuspendLayout();
			reqTypePn_.SuspendLayout();
			SuspendLayout();
			// 
			// ItemNameLB
			// 
			itemNameLb_.Location = new System.Drawing.Point(0, 0);
			itemNameLb_.Name = "itemNameLb_";
			itemNameLb_.TabIndex = 0;
			itemNameLb_.Text = "Item Name";
			itemNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ActiveLB
			// 
			activeLb_.Location = new System.Drawing.Point(0, 0);
			activeLb_.Name = "activeLb_";
			activeLb_.TabIndex = 1;
			activeLb_.Text = "Active";
			activeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReqTypeLB
			// 
			reqTypeLb_.Location = new System.Drawing.Point(0, 0);
			reqTypeLb_.Name = "reqTypeLb_";
			reqTypeLb_.TabIndex = 3;
			reqTypeLb_.Text = "Requested Type";
			reqTypeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SamplingRateLB
			// 
			samplingRateLb_.Location = new System.Drawing.Point(0, 48);
			samplingRateLb_.Name = "samplingRateLb_";
			samplingRateLb_.TabIndex = 5;
			samplingRateLb_.Text = "Sampling Rate";
			samplingRateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DeadbandLB
			// 
			deadbandLb_.Location = new System.Drawing.Point(0, 24);
			deadbandLb_.Name = "deadbandLb_";
			deadbandLb_.TabIndex = 6;
			deadbandLb_.Text = "Deadband";
			deadbandLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EnableBufferingLB
			// 
			enableBufferingLb_.Location = new System.Drawing.Point(0, 72);
			enableBufferingLb_.Name = "enableBufferingLb_";
			enableBufferingLb_.TabIndex = 7;
			enableBufferingLb_.Text = "Enable Buffering";
			enableBufferingLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameTB
			// 
			itemNameTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			itemNameTb_.Location = new System.Drawing.Point(104, 0);
			itemNameTb_.Name = "itemNameTb_";
			itemNameTb_.ReadOnly = true;
			itemNameTb_.Size = new System.Drawing.Size(280, 20);
			itemNameTb_.TabIndex = 8;
			itemNameTb_.Text = "";
			// 
			// ActiveCB
			// 
			activeCb_.Location = new System.Drawing.Point(104, 0);
			activeCb_.Name = "activeCb_";
			activeCb_.Size = new System.Drawing.Size(16, 24);
			activeCb_.TabIndex = 9;
			// 
			// SamplingRateCTRL
			// 
			samplingRateCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			samplingRateCtrl_.Increment = new System.Decimal(new int[] {
																			   100,
																			   0,
																			   0,
																			   0});
			samplingRateCtrl_.Location = new System.Drawing.Point(104, 50);
			samplingRateCtrl_.Maximum = new System.Decimal(new int[] {
																			 1000000000,
																			 0,
																			 0,
																			 0});
			samplingRateCtrl_.Name = "samplingRateCtrl_";
			samplingRateCtrl_.Size = new System.Drawing.Size(168, 20);
			samplingRateCtrl_.TabIndex = 12;
			// 
			// DeadbandCTRL
			// 
			deadbandCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			deadbandCtrl_.DecimalPlaces = 1;
			deadbandCtrl_.Location = new System.Drawing.Point(104, 26);
			deadbandCtrl_.Name = "deadbandCtrl_";
			deadbandCtrl_.Size = new System.Drawing.Size(168, 20);
			deadbandCtrl_.TabIndex = 14;
			// 
			// EnableBufferingCB
			// 
			enableBufferingCb_.Location = new System.Drawing.Point(104, 72);
			enableBufferingCb_.Name = "enableBufferingCb_";
			enableBufferingCb_.Size = new System.Drawing.Size(16, 24);
			enableBufferingCb_.TabIndex = 15;
			// 
			// DeadbandSpecifiedCB
			// 
			deadbandSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			deadbandSpecifiedCb_.Checked = true;
			deadbandSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			deadbandSpecifiedCb_.Location = new System.Drawing.Point(368, 24);
			deadbandSpecifiedCb_.Name = "deadbandSpecifiedCb_";
			deadbandSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			deadbandSpecifiedCb_.TabIndex = 18;
			deadbandSpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// ActiveSpecifiedCB
			// 
			activeSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			activeSpecifiedCb_.Checked = true;
			activeSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			activeSpecifiedCb_.Location = new System.Drawing.Point(368, 0);
			activeSpecifiedCb_.Name = "activeSpecifiedCb_";
			activeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			activeSpecifiedCb_.TabIndex = 20;
			activeSpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// SamplingRateSpecifiedCB
			// 
			samplingRateSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			samplingRateSpecifiedCb_.Checked = true;
			samplingRateSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			samplingRateSpecifiedCb_.Location = new System.Drawing.Point(368, 48);
			samplingRateSpecifiedCb_.Name = "samplingRateSpecifiedCb_";
			samplingRateSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			samplingRateSpecifiedCb_.TabIndex = 21;
			samplingRateSpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// EnableBufferSpecifiedCB
			// 
			enableBufferSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			enableBufferSpecifiedCb_.Checked = true;
			enableBufferSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			enableBufferSpecifiedCb_.Location = new System.Drawing.Point(368, 72);
			enableBufferSpecifiedCb_.Name = "enableBufferSpecifiedCb_";
			enableBufferSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			enableBufferSpecifiedCb_.TabIndex = 22;
			enableBufferSpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// ReqTypeCTRL
			// 
			reqTypeCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			reqTypeCtrl_.Location = new System.Drawing.Point(104, 0);
			reqTypeCtrl_.Name = "reqTypeCtrl_";
			reqTypeCtrl_.SelectedType = null;
			reqTypeCtrl_.Size = new System.Drawing.Size(208, 24);
			reqTypeCtrl_.TabIndex = 23;
			// 
			// ItemPathTB
			// 
			itemPathTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			itemPathTb_.Location = new System.Drawing.Point(104, 24);
			itemPathTb_.Name = "itemPathTb_";
			itemPathTb_.ReadOnly = true;
			itemPathTb_.Size = new System.Drawing.Size(280, 20);
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
			// MaxAgeSpecifiedCB
			// 
			maxAgeSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			maxAgeSpecifiedCb_.Checked = true;
			maxAgeSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			maxAgeSpecifiedCb_.Location = new System.Drawing.Point(368, 0);
			maxAgeSpecifiedCb_.Name = "maxAgeSpecifiedCb_";
			maxAgeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			maxAgeSpecifiedCb_.TabIndex = 30;
			maxAgeSpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// MaxAgeCTRL
			// 
			maxAgeCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			maxAgeCtrl_.DecimalPlaces = 3;
			maxAgeCtrl_.Location = new System.Drawing.Point(104, 2);
			maxAgeCtrl_.Maximum = new System.Decimal(new int[] {
																	   1000000000,
																	   0,
																	   0,
																	   0});
			maxAgeCtrl_.Name = "maxAgeCtrl_";
			maxAgeCtrl_.Size = new System.Drawing.Size(168, 20);
			maxAgeCtrl_.TabIndex = 29;
			// 
			// MaxAgeLB
			// 
			maxAgeLb_.Location = new System.Drawing.Point(0, 0);
			maxAgeLb_.Name = "maxAgeLb_";
			maxAgeLb_.TabIndex = 28;
			maxAgeLb_.Text = "Maximum Age";
			maxAgeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReqTypeSpecifiedCB
			// 
			reqTypeSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			reqTypeSpecifiedCb_.Checked = true;
			reqTypeSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			reqTypeSpecifiedCb_.Location = new System.Drawing.Point(368, 0);
			reqTypeSpecifiedCb_.Name = "reqTypeSpecifiedCb_";
			reqTypeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			reqTypeSpecifiedCb_.TabIndex = 31;
			reqTypeSpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// SubscribePN
			// 
			subscribePn_.Controls.Add(activeLb_);
			subscribePn_.Controls.Add(deadbandCtrl_);
			subscribePn_.Controls.Add(activeCb_);
			subscribePn_.Controls.Add(samplingRateLb_);
			subscribePn_.Controls.Add(enableBufferSpecifiedCb_);
			subscribePn_.Controls.Add(deadbandSpecifiedCb_);
			subscribePn_.Controls.Add(samplingRateCtrl_);
			subscribePn_.Controls.Add(activeSpecifiedCb_);
			subscribePn_.Controls.Add(enableBufferingLb_);
			subscribePn_.Controls.Add(samplingRateSpecifiedCb_);
			subscribePn_.Controls.Add(deadbandLb_);
			subscribePn_.Controls.Add(enableBufferingCb_);
			subscribePn_.Dock = System.Windows.Forms.DockStyle.Top;
			subscribePn_.Location = new System.Drawing.Point(0, 144);
			subscribePn_.Name = "subscribePn_";
			subscribePn_.Size = new System.Drawing.Size(384, 96);
			subscribePn_.TabIndex = 32;
			subscribePn_.Visible = false;
			// 
			// ReadPN
			// 
			readPn_.Controls.Add(maxAgeSpecifiedCb_);
			readPn_.Controls.Add(maxAgeLb_);
			readPn_.Controls.Add(maxAgeCtrl_);
			readPn_.Dock = System.Windows.Forms.DockStyle.Top;
			readPn_.Location = new System.Drawing.Point(0, 120);
			readPn_.Name = "readPn_";
			readPn_.Size = new System.Drawing.Size(384, 24);
			readPn_.TabIndex = 33;
			// 
			// TopPN
			// 
			topPn_.Controls.Add(itemNameLb_);
			topPn_.Controls.Add(itemPathLb_);
			topPn_.Controls.Add(itemPathTb_);
			topPn_.Controls.Add(itemNameTb_);
			topPn_.Dock = System.Windows.Forms.DockStyle.Top;
			topPn_.Location = new System.Drawing.Point(0, 0);
			topPn_.Name = "topPn_";
			topPn_.Size = new System.Drawing.Size(384, 48);
			topPn_.TabIndex = 34;
			// 
			// TypeConversionLB
			// 
			typeConversionLb_.Location = new System.Drawing.Point(0, 0);
			typeConversionLb_.Name = "typeConversionLb_";
			typeConversionLb_.TabIndex = 4;
			typeConversionLb_.Text = "Type Conversion";
			typeConversionLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TypeConversionCB
			// 
			typeConversionCb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			typeConversionCb_.Location = new System.Drawing.Point(104, 0);
			typeConversionCb_.Name = "typeConversionCb_";
			typeConversionCb_.Size = new System.Drawing.Size(208, 21);
			typeConversionCb_.TabIndex = 5;
			typeConversionCb_.SelectedIndexChanged += new System.EventHandler(TypeConversionCB_SelectedIndexChanged);
			// 
			// DataFilterLN
			// 
			dataFilterLn_.Location = new System.Drawing.Point(0, 24);
			dataFilterLn_.Name = "dataFilterLn_";
			dataFilterLn_.TabIndex = 6;
			dataFilterLn_.Text = "Data Filter";
			dataFilterLn_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DataFilterTB
			// 
			dataFilterTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			dataFilterTb_.Location = new System.Drawing.Point(104, 24);
			dataFilterTb_.Name = "dataFilterTb_";
			dataFilterTb_.Size = new System.Drawing.Size(256, 20);
			dataFilterTb_.TabIndex = 36;
			dataFilterTb_.Text = "";
			// 
			// ComplexItemPN
			// 
			complexItemPn_.Controls.Add(dataFilterLn_);
			complexItemPn_.Controls.Add(typeConversionLb_);
			complexItemPn_.Controls.Add(dataFilterTb_);
			complexItemPn_.Controls.Add(typeConversionCb_);
			complexItemPn_.Controls.Add(dataFilterSpecifiedCb_);
			complexItemPn_.Controls.Add(typeConversionSpecifiedCb_);
			complexItemPn_.Dock = System.Windows.Forms.DockStyle.Top;
			complexItemPn_.Location = new System.Drawing.Point(0, 72);
			complexItemPn_.Name = "complexItemPn_";
			complexItemPn_.Size = new System.Drawing.Size(384, 48);
			complexItemPn_.TabIndex = 37;
			// 
			// DataFilterSpecifiedCB
			// 
			dataFilterSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			dataFilterSpecifiedCb_.Checked = true;
			dataFilterSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			dataFilterSpecifiedCb_.Location = new System.Drawing.Point(368, 24);
			dataFilterSpecifiedCb_.Name = "dataFilterSpecifiedCb_";
			dataFilterSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			dataFilterSpecifiedCb_.TabIndex = 37;
			dataFilterSpecifiedCb_.CheckedChanged += new System.EventHandler(Specified_CheckedChanged);
			// 
			// TypeConversionSpecifiedCB
			// 
			typeConversionSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			typeConversionSpecifiedCb_.Checked = true;
			typeConversionSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			typeConversionSpecifiedCb_.Location = new System.Drawing.Point(368, 0);
			typeConversionSpecifiedCb_.Name = "typeConversionSpecifiedCb_";
			typeConversionSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			typeConversionSpecifiedCb_.TabIndex = 38;
			typeConversionSpecifiedCb_.CheckedChanged += new System.EventHandler(TypeConversionCB_SelectedIndexChanged);
			// 
			// ReqTypePN
			// 
			reqTypePn_.Controls.Add(reqTypeLb_);
			reqTypePn_.Controls.Add(reqTypeSpecifiedCb_);
			reqTypePn_.Controls.Add(reqTypeCtrl_);
			reqTypePn_.Dock = System.Windows.Forms.DockStyle.Top;
			reqTypePn_.Location = new System.Drawing.Point(0, 48);
			reqTypePn_.Name = "reqTypePn_";
			reqTypePn_.Size = new System.Drawing.Size(384, 24);
			reqTypePn_.TabIndex = 38;
			// 
			// ItemEditCtrl
			// 
			Controls.Add(subscribePn_);
			Controls.Add(readPn_);
			Controls.Add(complexItemPn_);
			Controls.Add(reqTypePn_);
			Controls.Add(topPn_);
			Name = "ItemEditCtrl";
			Size = new System.Drawing.Size(384, 240);
			((System.ComponentModel.ISupportInitialize)(samplingRateCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(deadbandCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(maxAgeCtrl_)).EndInit();
			subscribePn_.ResumeLayout(false);
			readPn_.ResumeLayout(false);
			topPn_.ResumeLayout(false);
			complexItemPn_.ResumeLayout(false);
			reqTypePn_.ResumeLayout(false);
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

		/// <summary>
		/// Whether the control is editing a 'read' item or a 'subscribe' item.
		/// </summary>
		public bool IsReadItem
		{
			get	{return readPn_.Visible;}
 
			set
			{
				readPn_.Visible      = value;
				subscribePn_.Visible = !value;
			}
		}

		//======================================================================
		// IEditObjectCtrl

		/// <summary>
		/// Set all fields to default values.
		/// </summary>
		public void SetDefaults()
		{
			itemNameTb_.Text                   = null;
			itemPathTb_.Text                   = null;
			reqTypeCtrl_.SelectedType          = null;
			reqTypeSpecifiedCb_.Checked        = false;
			maxAgeCtrl_.Value                  = 0;
			maxAgeSpecifiedCb_.Checked         = false;
			activeCb_.Checked                  = false;
			activeSpecifiedCb_.Checked         = false;
			deadbandCtrl_.Value                = 0;
			deadbandSpecifiedCb_.Checked       = false;
			samplingRateCtrl_.Value            = 0;
			samplingRateSpecifiedCb_.Checked   = false;
			enableBufferingCb_.Checked         = false;
			enableBufferSpecifiedCb_.Checked   = false;
			typeConversionCb_.Text             = null;
			typeConversionSpecifiedCb_.Checked = false;
			dataFilterTb_.Text                 = null;
			dataFilterSpecifiedCb_.Checked     = false;
		}

		/// <summary>
		/// Copy values from control into object - throw exceptions on error.
		/// </summary>
		public object Get()
		{
			TsCDaItem item = new TsCDaItem(mIdentifier_);

			item.ItemName                 = itemNameTb_.Text;
			item.ItemPath                 = itemPathTb_.Text;
			item.ReqType                  = (reqTypeSpecifiedCb_.Checked)?reqTypeCtrl_.SelectedType:null;
			item.MaxAge                   = (maxAgeSpecifiedCb_.Checked)?(int)maxAgeCtrl_.Value*1000:0;
			item.MaxAgeSpecified          = maxAgeSpecifiedCb_.Checked;
			item.Active                   = (activeSpecifiedCb_.Checked)?activeCb_.Checked:false;
			item.ActiveSpecified          = activeSpecifiedCb_.Checked;
			item.Deadband                 = (deadbandSpecifiedCb_.Checked)?(float)deadbandCtrl_.Value:0;
			item.DeadbandSpecified        = deadbandSpecifiedCb_.Checked;
			item.SamplingRate             = (samplingRateSpecifiedCb_.Checked)?(int)samplingRateCtrl_.Value:0;
			item.SamplingRateSpecified    = samplingRateSpecifiedCb_.Checked;
			item.EnableBuffering          = (enableBufferSpecifiedCb_.Checked)?enableBufferingCb_.Checked:false;
			item.EnableBufferingSpecified = enableBufferSpecifiedCb_.Checked;

			// update the item id to reflect selections for complex data.
			try
			{
				GetComplexItem(item);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				item.ItemName = itemNameTb_.Text;
				item.ItemPath = itemPathTb_.Text;
			}

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
			TsCDaItem item = (TsCDaItem)value;

			// save item identifier (including client and server handles).
			mIdentifier_ = new OpcItem(item);

			// update controls.
			itemNameTb_.Text                 = item.ItemName;
			itemPathTb_.Text                 = item.ItemPath;
			reqTypeCtrl_.SelectedType        = item.ReqType;
			reqTypeSpecifiedCb_.Checked      = item.ReqType != null;
			maxAgeCtrl_.Value                = (item.MaxAgeSpecified)?((decimal)item.MaxAge)/1000:0;
			maxAgeSpecifiedCb_.Checked       = item.MaxAgeSpecified;
			activeCb_.Checked                = (item.ActiveSpecified)?item.Active:false;
			activeSpecifiedCb_.Checked       = item.ActiveSpecified;
			deadbandCtrl_.Value              = (item.DeadbandSpecified)?(decimal)item.Deadband:0;
			deadbandSpecifiedCb_.Checked     = item.DeadbandSpecified;
			samplingRateCtrl_.Value          = (item.SamplingRateSpecified)?(decimal)item.SamplingRate:0;
			samplingRateSpecifiedCb_.Checked = item.SamplingRateSpecified;
			enableBufferingCb_.Checked       = (item.EnableBufferingSpecified)?item.EnableBuffering:false;
			enableBufferSpecifiedCb_.Checked = item.EnableBufferingSpecified;

			reqTypePn_.Visible     = true;
			complexItemPn_.Visible = false;

			// initialize complex data controls.
			try
			{
				SetComplexItem(mIdentifier_);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				reqTypePn_.Visible     = true;
				complexItemPn_.Visible = false;
			}
		}

		/// <summary>
		/// The active complex data item.
		/// </summary>
		private Technosoftware.DaAeHdaClient.Cpx.TsCCpxComplexItem mItem_ = null;

		/// <summary>
		/// Initializes the control with information specified to a complex item. 
		/// </summary>
		private void SetComplexItem(OpcItem itemId)
		{
			mItem_ = TsCCpxComplexTypeCache.GetComplexItem(itemId);

			// do nothing for items that are not complex.
			if (mItem_ == null)
			{
				reqTypePn_.Visible     = true;
				complexItemPn_.Visible = false;
				return;
			}

			// display complex item controls.
			reqTypePn_.Visible     = false;
			complexItemPn_.Visible = true;

			// initialize controls.
			typeConversionCb_.Items.Clear();
			typeConversionCb_.Text = null;
			typeConversionSpecifiedCb_.Checked = false;

			dataFilterTb_.Text = null;
			dataFilterSpecifiedCb_.Checked = false;

			// fetch the available type conversions.
			Technosoftware.DaAeHdaClient.Cpx.TsCCpxComplexItem[] conversions = mItem_.GetRootItem().GetTypeConversions(TsCCpxComplexTypeCache.Server);

			// no conversions available.
			if (conversions == null || conversions.Length == 0)
			{
				typeConversionSpecifiedCb_.Enabled = false;
			}

			// populate conversions drop down menu.
			else
			{
				Technosoftware.DaAeHdaClient.Cpx.TsCCpxComplexItem item = mItem_;

				if (item.UnfilteredItemID != null)
				{
					item = TsCCpxComplexTypeCache.GetComplexItem(item.UnfilteredItemID);
				}

				foreach (TsCCpxComplexItem conversion in conversions)
				{
					typeConversionCb_.Items.Add(conversion);

					if (conversion.Key == item.Key)
					{
						typeConversionCb_.SelectedItem = conversion;
						typeConversionSpecifiedCb_.Checked = true;
					}
				}

				if (typeConversionCb_.SelectedItem == null)
				{
					typeConversionCb_.SelectedIndex = 0;
				}
			}

			// display the active data filter.
			if (mItem_.UnfilteredItemID != null)
			{
				dataFilterTb_.Text = mItem_.DataFilterValue;
				dataFilterSpecifiedCb_.Checked = true;
			}
		}
		
		/// <summary>
		/// Updates the complex data properties affected by the item.
		/// </summary>
		private void GetComplexItem(OpcItem itemId)
		{
			if (mItem_ == null) { return; }

			TsCCpxComplexItem item = mItem_;

			// clear any existing data filter.
			if (!dataFilterSpecifiedCb_.Checked || !dataFilterSpecifiedCb_.Enabled || dataFilterTb_.Text == "")
			{
				if (mItem_.UnfilteredItemID != null)
				{
					mItem_.UpdateDataFilter(TsCCpxComplexTypeCache.Server, "");
					
					if (mItem_.UnconvertedItemID != null)
					{
						item = TsCCpxComplexTypeCache.GetComplexItem(mItem_.UnconvertedItemID);
					}
					else
					{
						item = TsCCpxComplexTypeCache.GetComplexItem(mItem_.UnfilteredItemID);
					}
				}
			}

			// clear any existing type conversion.
			if (!typeConversionSpecifiedCb_.Checked || typeConversionCb_.SelectedItem == null)
			{
				// check if type conversion removed.
				if (mItem_.UnconvertedItemID != null)
				{
					item = TsCCpxComplexTypeCache.GetComplexItem(mItem_.UnconvertedItemID);
				}
			}
			else
			{
				// check if the type conversion changed.
				TsCCpxComplexItem conversion = (TsCCpxComplexItem)typeConversionCb_.SelectedItem;

				if (conversion.Key != item.Key)
				{				
					if (item.UnfilteredItemID == null || conversion.Key != item.UnfilteredItemID.Key)
					{
						item = conversion;
					}
				}
			}

			// apply the new filter value.
			if (dataFilterSpecifiedCb_.Checked && dataFilterSpecifiedCb_.Enabled && dataFilterTb_.Text != "")
			{
				// update an existing data filter.
				if (item.UnfilteredItemID != null)
				{
					item.UpdateDataFilter(TsCCpxComplexTypeCache.Server, dataFilterTb_.Text);
				}
				else
				{
					// get the existing data filters.
					TsCCpxComplexItem[] filters = item.GetDataFilters(TsCCpxComplexTypeCache.Server);

					// assign a unique filter name.
					int ii = 0;
					string filterName = null;
					
					do
					{
						filterName = String.Format("Filter{0:00}", ii++);

						foreach (TsCCpxComplexItem filter in filters)
						{
							if (filter.Name == filterName)
							{
								filterName = null;
								break;
							}
						}
					}
					while (filterName == null);

					// create the filter.
					item = item.CreateDataFilter(TsCCpxComplexTypeCache.Server, filterName, dataFilterTb_.Text);
				}
			}

			// update the item id.
			if (item != null)
			{
				itemId.ItemPath = item.ItemPath;
				itemId.ItemName = item.ItemName;
			}
		}

		/// <summary>
		/// Creates a new object.
		/// </summary>
		public object Create()
		{
			return new TsCDaItem();
		}

		/// <summary>
		/// Toggles the enabled state of controls based on the specified check boxes.
		/// </summary>
		private void Specified_CheckedChanged(object sender, System.EventArgs e)
		{			
			reqTypeCtrl_.Enabled       = reqTypeSpecifiedCb_.Checked;
			maxAgeCtrl_.Enabled        = maxAgeSpecifiedCb_.Checked;
			activeCb_.Enabled          = activeSpecifiedCb_.Checked;
			deadbandCtrl_.Enabled      = deadbandSpecifiedCb_.Checked;
			samplingRateCtrl_.Enabled  = samplingRateSpecifiedCb_.Checked;
			enableBufferingCb_.Enabled = enableBufferSpecifiedCb_.Checked;
			dataFilterTb_.Enabled      = dataFilterSpecifiedCb_.Checked;
		}

		/// <summary>
		/// Updates the data filter whenever the selected index changed.
		/// </summary>
		private void TypeConversionCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			typeConversionCb_.Enabled = typeConversionSpecifiedCb_.Checked;

			TsCCpxComplexItem item = null;

			if (typeConversionSpecifiedCb_.Checked)
			{
				item = (TsCCpxComplexItem)typeConversionCb_.SelectedItem;
			}
			else
			{
				if (mItem_ != null)
				{
					item = mItem_.GetRootItem();
				}
			}

			if (item != null)
			{
				dataFilterSpecifiedCb_.Enabled = (item.DataFilterItem != null);
				dataFilterTb_.Enabled          = dataFilterSpecifiedCb_.Enabled && dataFilterSpecifiedCb_.Checked;
			}
        }
	}
}

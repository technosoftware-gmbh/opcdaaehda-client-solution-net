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
			this.itemNameLb_ = new System.Windows.Forms.Label();
			this.activeLb_ = new System.Windows.Forms.Label();
			this.reqTypeLb_ = new System.Windows.Forms.Label();
			this.samplingRateLb_ = new System.Windows.Forms.Label();
			this.deadbandLb_ = new System.Windows.Forms.Label();
			this.enableBufferingLb_ = new System.Windows.Forms.Label();
			this.itemNameTb_ = new System.Windows.Forms.TextBox();
			this.activeCb_ = new System.Windows.Forms.CheckBox();
			this.samplingRateCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.deadbandCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.enableBufferingCb_ = new System.Windows.Forms.CheckBox();
			this.deadbandSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.activeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.samplingRateSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.enableBufferSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.reqTypeCtrl_ = new DataTypeCtrl();
			this.itemPathTb_ = new System.Windows.Forms.TextBox();
			this.itemPathLb_ = new System.Windows.Forms.Label();
			this.maxAgeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.maxAgeCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.maxAgeLb_ = new System.Windows.Forms.Label();
			this.reqTypeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.subscribePn_ = new System.Windows.Forms.Panel();
			this.readPn_ = new System.Windows.Forms.Panel();
			this.topPn_ = new System.Windows.Forms.Panel();
			this.typeConversionLb_ = new System.Windows.Forms.Label();
			this.typeConversionCb_ = new System.Windows.Forms.ComboBox();
			this.dataFilterLn_ = new System.Windows.Forms.Label();
			this.dataFilterTb_ = new System.Windows.Forms.TextBox();
			this.complexItemPn_ = new System.Windows.Forms.Panel();
			this.dataFilterSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.typeConversionSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.reqTypePn_ = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.samplingRateCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deadbandCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maxAgeCtrl_)).BeginInit();
			this.subscribePn_.SuspendLayout();
			this.readPn_.SuspendLayout();
			this.topPn_.SuspendLayout();
			this.complexItemPn_.SuspendLayout();
			this.reqTypePn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// ItemNameLB
			// 
			this.itemNameLb_.Location = new System.Drawing.Point(0, 0);
			this.itemNameLb_.Name = "itemNameLb_";
			this.itemNameLb_.TabIndex = 0;
			this.itemNameLb_.Text = "Item Name";
			this.itemNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ActiveLB
			// 
			this.activeLb_.Location = new System.Drawing.Point(0, 0);
			this.activeLb_.Name = "activeLb_";
			this.activeLb_.TabIndex = 1;
			this.activeLb_.Text = "Active";
			this.activeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReqTypeLB
			// 
			this.reqTypeLb_.Location = new System.Drawing.Point(0, 0);
			this.reqTypeLb_.Name = "reqTypeLb_";
			this.reqTypeLb_.TabIndex = 3;
			this.reqTypeLb_.Text = "Requested Type";
			this.reqTypeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SamplingRateLB
			// 
			this.samplingRateLb_.Location = new System.Drawing.Point(0, 48);
			this.samplingRateLb_.Name = "samplingRateLb_";
			this.samplingRateLb_.TabIndex = 5;
			this.samplingRateLb_.Text = "Sampling Rate";
			this.samplingRateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DeadbandLB
			// 
			this.deadbandLb_.Location = new System.Drawing.Point(0, 24);
			this.deadbandLb_.Name = "deadbandLb_";
			this.deadbandLb_.TabIndex = 6;
			this.deadbandLb_.Text = "Deadband";
			this.deadbandLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EnableBufferingLB
			// 
			this.enableBufferingLb_.Location = new System.Drawing.Point(0, 72);
			this.enableBufferingLb_.Name = "enableBufferingLb_";
			this.enableBufferingLb_.TabIndex = 7;
			this.enableBufferingLb_.Text = "Enable Buffering";
			this.enableBufferingLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameTB
			// 
			this.itemNameTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.itemNameTb_.Location = new System.Drawing.Point(104, 0);
			this.itemNameTb_.Name = "itemNameTb_";
			this.itemNameTb_.ReadOnly = true;
			this.itemNameTb_.Size = new System.Drawing.Size(280, 20);
			this.itemNameTb_.TabIndex = 8;
			this.itemNameTb_.Text = "";
			// 
			// ActiveCB
			// 
			this.activeCb_.Location = new System.Drawing.Point(104, 0);
			this.activeCb_.Name = "activeCb_";
			this.activeCb_.Size = new System.Drawing.Size(16, 24);
			this.activeCb_.TabIndex = 9;
			// 
			// SamplingRateCTRL
			// 
			this.samplingRateCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.samplingRateCtrl_.Increment = new System.Decimal(new int[] {
																			   100,
																			   0,
																			   0,
																			   0});
			this.samplingRateCtrl_.Location = new System.Drawing.Point(104, 50);
			this.samplingRateCtrl_.Maximum = new System.Decimal(new int[] {
																			 1000000000,
																			 0,
																			 0,
																			 0});
			this.samplingRateCtrl_.Name = "samplingRateCtrl_";
			this.samplingRateCtrl_.Size = new System.Drawing.Size(168, 20);
			this.samplingRateCtrl_.TabIndex = 12;
			// 
			// DeadbandCTRL
			// 
			this.deadbandCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.deadbandCtrl_.DecimalPlaces = 1;
			this.deadbandCtrl_.Location = new System.Drawing.Point(104, 26);
			this.deadbandCtrl_.Name = "deadbandCtrl_";
			this.deadbandCtrl_.Size = new System.Drawing.Size(168, 20);
			this.deadbandCtrl_.TabIndex = 14;
			// 
			// EnableBufferingCB
			// 
			this.enableBufferingCb_.Location = new System.Drawing.Point(104, 72);
			this.enableBufferingCb_.Name = "enableBufferingCb_";
			this.enableBufferingCb_.Size = new System.Drawing.Size(16, 24);
			this.enableBufferingCb_.TabIndex = 15;
			// 
			// DeadbandSpecifiedCB
			// 
			this.deadbandSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.deadbandSpecifiedCb_.Checked = true;
			this.deadbandSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.deadbandSpecifiedCb_.Location = new System.Drawing.Point(368, 24);
			this.deadbandSpecifiedCb_.Name = "deadbandSpecifiedCb_";
			this.deadbandSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.deadbandSpecifiedCb_.TabIndex = 18;
			this.deadbandSpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// ActiveSpecifiedCB
			// 
			this.activeSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.activeSpecifiedCb_.Checked = true;
			this.activeSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.activeSpecifiedCb_.Location = new System.Drawing.Point(368, 0);
			this.activeSpecifiedCb_.Name = "activeSpecifiedCb_";
			this.activeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.activeSpecifiedCb_.TabIndex = 20;
			this.activeSpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// SamplingRateSpecifiedCB
			// 
			this.samplingRateSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.samplingRateSpecifiedCb_.Checked = true;
			this.samplingRateSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.samplingRateSpecifiedCb_.Location = new System.Drawing.Point(368, 48);
			this.samplingRateSpecifiedCb_.Name = "samplingRateSpecifiedCb_";
			this.samplingRateSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.samplingRateSpecifiedCb_.TabIndex = 21;
			this.samplingRateSpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// EnableBufferSpecifiedCB
			// 
			this.enableBufferSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.enableBufferSpecifiedCb_.Checked = true;
			this.enableBufferSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.enableBufferSpecifiedCb_.Location = new System.Drawing.Point(368, 72);
			this.enableBufferSpecifiedCb_.Name = "enableBufferSpecifiedCb_";
			this.enableBufferSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.enableBufferSpecifiedCb_.TabIndex = 22;
			this.enableBufferSpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// ReqTypeCTRL
			// 
			this.reqTypeCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.reqTypeCtrl_.Location = new System.Drawing.Point(104, 0);
			this.reqTypeCtrl_.Name = "reqTypeCtrl_";
			this.reqTypeCtrl_.SelectedType = null;
			this.reqTypeCtrl_.Size = new System.Drawing.Size(208, 24);
			this.reqTypeCtrl_.TabIndex = 23;
			// 
			// ItemPathTB
			// 
			this.itemPathTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.itemPathTb_.Location = new System.Drawing.Point(104, 24);
			this.itemPathTb_.Name = "itemPathTb_";
			this.itemPathTb_.ReadOnly = true;
			this.itemPathTb_.Size = new System.Drawing.Size(280, 20);
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
			// MaxAgeSpecifiedCB
			// 
			this.maxAgeSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.maxAgeSpecifiedCb_.Checked = true;
			this.maxAgeSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.maxAgeSpecifiedCb_.Location = new System.Drawing.Point(368, 0);
			this.maxAgeSpecifiedCb_.Name = "maxAgeSpecifiedCb_";
			this.maxAgeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.maxAgeSpecifiedCb_.TabIndex = 30;
			this.maxAgeSpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// MaxAgeCTRL
			// 
			this.maxAgeCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.maxAgeCtrl_.DecimalPlaces = 3;
			this.maxAgeCtrl_.Location = new System.Drawing.Point(104, 2);
			this.maxAgeCtrl_.Maximum = new System.Decimal(new int[] {
																	   1000000000,
																	   0,
																	   0,
																	   0});
			this.maxAgeCtrl_.Name = "maxAgeCtrl_";
			this.maxAgeCtrl_.Size = new System.Drawing.Size(168, 20);
			this.maxAgeCtrl_.TabIndex = 29;
			// 
			// MaxAgeLB
			// 
			this.maxAgeLb_.Location = new System.Drawing.Point(0, 0);
			this.maxAgeLb_.Name = "maxAgeLb_";
			this.maxAgeLb_.TabIndex = 28;
			this.maxAgeLb_.Text = "Maximum Age";
			this.maxAgeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReqTypeSpecifiedCB
			// 
			this.reqTypeSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.reqTypeSpecifiedCb_.Checked = true;
			this.reqTypeSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.reqTypeSpecifiedCb_.Location = new System.Drawing.Point(368, 0);
			this.reqTypeSpecifiedCb_.Name = "reqTypeSpecifiedCb_";
			this.reqTypeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.reqTypeSpecifiedCb_.TabIndex = 31;
			this.reqTypeSpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// SubscribePN
			// 
			this.subscribePn_.Controls.Add(this.activeLb_);
			this.subscribePn_.Controls.Add(this.deadbandCtrl_);
			this.subscribePn_.Controls.Add(this.activeCb_);
			this.subscribePn_.Controls.Add(this.samplingRateLb_);
			this.subscribePn_.Controls.Add(this.enableBufferSpecifiedCb_);
			this.subscribePn_.Controls.Add(this.deadbandSpecifiedCb_);
			this.subscribePn_.Controls.Add(this.samplingRateCtrl_);
			this.subscribePn_.Controls.Add(this.activeSpecifiedCb_);
			this.subscribePn_.Controls.Add(this.enableBufferingLb_);
			this.subscribePn_.Controls.Add(this.samplingRateSpecifiedCb_);
			this.subscribePn_.Controls.Add(this.deadbandLb_);
			this.subscribePn_.Controls.Add(this.enableBufferingCb_);
			this.subscribePn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.subscribePn_.Location = new System.Drawing.Point(0, 144);
			this.subscribePn_.Name = "subscribePn_";
			this.subscribePn_.Size = new System.Drawing.Size(384, 96);
			this.subscribePn_.TabIndex = 32;
			this.subscribePn_.Visible = false;
			// 
			// ReadPN
			// 
			this.readPn_.Controls.Add(this.maxAgeSpecifiedCb_);
			this.readPn_.Controls.Add(this.maxAgeLb_);
			this.readPn_.Controls.Add(this.maxAgeCtrl_);
			this.readPn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.readPn_.Location = new System.Drawing.Point(0, 120);
			this.readPn_.Name = "readPn_";
			this.readPn_.Size = new System.Drawing.Size(384, 24);
			this.readPn_.TabIndex = 33;
			// 
			// TopPN
			// 
			this.topPn_.Controls.Add(this.itemNameLb_);
			this.topPn_.Controls.Add(this.itemPathLb_);
			this.topPn_.Controls.Add(this.itemPathTb_);
			this.topPn_.Controls.Add(this.itemNameTb_);
			this.topPn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.topPn_.Location = new System.Drawing.Point(0, 0);
			this.topPn_.Name = "topPn_";
			this.topPn_.Size = new System.Drawing.Size(384, 48);
			this.topPn_.TabIndex = 34;
			// 
			// TypeConversionLB
			// 
			this.typeConversionLb_.Location = new System.Drawing.Point(0, 0);
			this.typeConversionLb_.Name = "typeConversionLb_";
			this.typeConversionLb_.TabIndex = 4;
			this.typeConversionLb_.Text = "Type Conversion";
			this.typeConversionLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TypeConversionCB
			// 
			this.typeConversionCb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.typeConversionCb_.Location = new System.Drawing.Point(104, 0);
			this.typeConversionCb_.Name = "typeConversionCb_";
			this.typeConversionCb_.Size = new System.Drawing.Size(208, 21);
			this.typeConversionCb_.TabIndex = 5;
			this.typeConversionCb_.SelectedIndexChanged += new System.EventHandler(this.TypeConversionCB_SelectedIndexChanged);
			// 
			// DataFilterLN
			// 
			this.dataFilterLn_.Location = new System.Drawing.Point(0, 24);
			this.dataFilterLn_.Name = "dataFilterLn_";
			this.dataFilterLn_.TabIndex = 6;
			this.dataFilterLn_.Text = "Data Filter";
			this.dataFilterLn_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DataFilterTB
			// 
			this.dataFilterTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataFilterTb_.Location = new System.Drawing.Point(104, 24);
			this.dataFilterTb_.Name = "dataFilterTb_";
			this.dataFilterTb_.Size = new System.Drawing.Size(256, 20);
			this.dataFilterTb_.TabIndex = 36;
			this.dataFilterTb_.Text = "";
			// 
			// ComplexItemPN
			// 
			this.complexItemPn_.Controls.Add(this.dataFilterLn_);
			this.complexItemPn_.Controls.Add(this.typeConversionLb_);
			this.complexItemPn_.Controls.Add(this.dataFilterTb_);
			this.complexItemPn_.Controls.Add(this.typeConversionCb_);
			this.complexItemPn_.Controls.Add(this.dataFilterSpecifiedCb_);
			this.complexItemPn_.Controls.Add(this.typeConversionSpecifiedCb_);
			this.complexItemPn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.complexItemPn_.Location = new System.Drawing.Point(0, 72);
			this.complexItemPn_.Name = "complexItemPn_";
			this.complexItemPn_.Size = new System.Drawing.Size(384, 48);
			this.complexItemPn_.TabIndex = 37;
			// 
			// DataFilterSpecifiedCB
			// 
			this.dataFilterSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dataFilterSpecifiedCb_.Checked = true;
			this.dataFilterSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.dataFilterSpecifiedCb_.Location = new System.Drawing.Point(368, 24);
			this.dataFilterSpecifiedCb_.Name = "dataFilterSpecifiedCb_";
			this.dataFilterSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.dataFilterSpecifiedCb_.TabIndex = 37;
			this.dataFilterSpecifiedCb_.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// TypeConversionSpecifiedCB
			// 
			this.typeConversionSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.typeConversionSpecifiedCb_.Checked = true;
			this.typeConversionSpecifiedCb_.CheckState = System.Windows.Forms.CheckState.Checked;
			this.typeConversionSpecifiedCb_.Location = new System.Drawing.Point(368, 0);
			this.typeConversionSpecifiedCb_.Name = "typeConversionSpecifiedCb_";
			this.typeConversionSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.typeConversionSpecifiedCb_.TabIndex = 38;
			this.typeConversionSpecifiedCb_.CheckedChanged += new System.EventHandler(this.TypeConversionCB_SelectedIndexChanged);
			// 
			// ReqTypePN
			// 
			this.reqTypePn_.Controls.Add(this.reqTypeLb_);
			this.reqTypePn_.Controls.Add(this.reqTypeSpecifiedCb_);
			this.reqTypePn_.Controls.Add(this.reqTypeCtrl_);
			this.reqTypePn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.reqTypePn_.Location = new System.Drawing.Point(0, 48);
			this.reqTypePn_.Name = "reqTypePn_";
			this.reqTypePn_.Size = new System.Drawing.Size(384, 24);
			this.reqTypePn_.TabIndex = 38;
			// 
			// ItemEditCtrl
			// 
			this.Controls.Add(this.subscribePn_);
			this.Controls.Add(this.readPn_);
			this.Controls.Add(this.complexItemPn_);
			this.Controls.Add(this.reqTypePn_);
			this.Controls.Add(this.topPn_);
			this.Name = "ItemEditCtrl";
			this.Size = new System.Drawing.Size(384, 240);
			((System.ComponentModel.ISupportInitialize)(this.samplingRateCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deadbandCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maxAgeCtrl_)).EndInit();
			this.subscribePn_.ResumeLayout(false);
			this.readPn_.ResumeLayout(false);
			this.topPn_.ResumeLayout(false);
			this.complexItemPn_.ResumeLayout(false);
			this.reqTypePn_.ResumeLayout(false);
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

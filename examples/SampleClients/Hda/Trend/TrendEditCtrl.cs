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

using SampleClients.Hda.Common;
using SampleClients.Hda.Item;

using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Trend
{
	/// <summary>
	/// Summary description for ReadParametersCtrl.
	/// </summary>
	public class TrendEditCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label startTimeLb_;
		private System.Windows.Forms.Label endTimeLb_;
		private System.Windows.Forms.Label maxValuesLb_;
		private System.Windows.Forms.Label includeBoundsLb_;
		private System.Windows.Forms.NumericUpDown maxValuesCtrl_;
		private System.Windows.Forms.CheckBox includeBoundsCb_;
		private System.Windows.Forms.CheckBox startTimeSpecifiedCb_;
		private System.Windows.Forms.CheckBox endTimeSpecifiedCb_;
		private TimeCtrl startTimeCtrl_;
		private TimeCtrl endTimeCtrl_;
		private System.Windows.Forms.Label aggregateLb_;
		private System.Windows.Forms.ComboBox aggregateCb_;
		private System.Windows.Forms.Label nameLb_;
		private System.Windows.Forms.TextBox nameTb_;
		private System.Windows.Forms.NumericUpDown resampleIntervalCtrl_;
		private System.Windows.Forms.Label resampleIntervalLb_;
		private System.Windows.Forms.CheckBox aggregateSpecifiedCb_;
		private System.Windows.Forms.NumericUpDown playbackDurationCtrl_;
		private System.Windows.Forms.Label playbackDurationLb_;
		private System.Windows.Forms.NumericUpDown updateIntervalCtrl_;
		private System.Windows.Forms.Label updateIntervalLb_;
		private System.Windows.Forms.Label updateIntervalUnitsLb_;
		private System.Windows.Forms.Label playbackDurationUnitsLb_;
		private System.Windows.Forms.Label resampleIntervalUnitsLb_;
		private System.Windows.Forms.Label playbackIntervalUnitsLb_;
		private System.Windows.Forms.NumericUpDown playbackIntervalCtrl_;
		private System.Windows.Forms.Label playbackIntervalLb_;
		private System.Windows.Forms.Panel playbackPn_;
		private System.Windows.Forms.Panel subscribePn_;
		private System.Windows.Forms.Panel processedPn_;
		private System.Windows.Forms.Panel rawPn_;
		private System.Windows.Forms.Panel maxValuesPn_;
		private System.Windows.Forms.Panel endTimePn_;
		private System.Windows.Forms.Panel namePn_;
		private System.Windows.Forms.Panel aggregatePn_;
		private System.Windows.Forms.Panel startTimePn_;
		private System.Windows.Forms.Panel timestampsPn_;
		private ItemTimesCtrl timestampsCtrl_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public TrendEditCtrl()
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
			this.startTimeLb_ = new System.Windows.Forms.Label();
			this.endTimeLb_ = new System.Windows.Forms.Label();
			this.maxValuesLb_ = new System.Windows.Forms.Label();
			this.includeBoundsLb_ = new System.Windows.Forms.Label();
			this.maxValuesCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.includeBoundsCb_ = new System.Windows.Forms.CheckBox();
			this.startTimeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.endTimeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.startTimeCtrl_ = new TimeCtrl();
			this.endTimeCtrl_ = new TimeCtrl();
			this.aggregateLb_ = new System.Windows.Forms.Label();
			this.aggregateCb_ = new System.Windows.Forms.ComboBox();
			this.nameLb_ = new System.Windows.Forms.Label();
			this.nameTb_ = new System.Windows.Forms.TextBox();
			this.resampleIntervalCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.resampleIntervalLb_ = new System.Windows.Forms.Label();
			this.aggregateSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			this.updateIntervalCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.updateIntervalLb_ = new System.Windows.Forms.Label();
			this.playbackDurationCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.playbackDurationLb_ = new System.Windows.Forms.Label();
			this.updateIntervalUnitsLb_ = new System.Windows.Forms.Label();
			this.playbackDurationUnitsLb_ = new System.Windows.Forms.Label();
			this.resampleIntervalUnitsLb_ = new System.Windows.Forms.Label();
			this.playbackIntervalUnitsLb_ = new System.Windows.Forms.Label();
			this.playbackIntervalCtrl_ = new System.Windows.Forms.NumericUpDown();
			this.playbackIntervalLb_ = new System.Windows.Forms.Label();
			this.playbackPn_ = new System.Windows.Forms.Panel();
			this.subscribePn_ = new System.Windows.Forms.Panel();
			this.processedPn_ = new System.Windows.Forms.Panel();
			this.rawPn_ = new System.Windows.Forms.Panel();
			this.maxValuesPn_ = new System.Windows.Forms.Panel();
			this.endTimePn_ = new System.Windows.Forms.Panel();
			this.namePn_ = new System.Windows.Forms.Panel();
			this.aggregatePn_ = new System.Windows.Forms.Panel();
			this.startTimePn_ = new System.Windows.Forms.Panel();
			this.timestampsPn_ = new System.Windows.Forms.Panel();
			this.timestampsCtrl_ = new ItemTimesCtrl();
			((System.ComponentModel.ISupportInitialize)(this.maxValuesCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.resampleIntervalCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.updateIntervalCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.playbackDurationCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.playbackIntervalCtrl_)).BeginInit();
			this.playbackPn_.SuspendLayout();
			this.subscribePn_.SuspendLayout();
			this.processedPn_.SuspendLayout();
			this.rawPn_.SuspendLayout();
			this.maxValuesPn_.SuspendLayout();
			this.endTimePn_.SuspendLayout();
			this.namePn_.SuspendLayout();
			this.aggregatePn_.SuspendLayout();
			this.startTimePn_.SuspendLayout();
			this.timestampsPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// StartTimeLB
			// 
			this.startTimeLb_.Location = new System.Drawing.Point(0, 0);
			this.startTimeLb_.Name = "startTimeLb_";
			this.startTimeLb_.Size = new System.Drawing.Size(96, 23);
			this.startTimeLb_.TabIndex = 0;
			this.startTimeLb_.Text = "Start Time";
			this.startTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EndTimeLB
			// 
			this.endTimeLb_.Location = new System.Drawing.Point(0, 0);
			this.endTimeLb_.Name = "endTimeLb_";
			this.endTimeLb_.Size = new System.Drawing.Size(96, 23);
			this.endTimeLb_.TabIndex = 1;
			this.endTimeLb_.Text = "End Time";
			this.endTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxValuesLB
			// 
			this.maxValuesLb_.Location = new System.Drawing.Point(0, 0);
			this.maxValuesLb_.Name = "maxValuesLb_";
			this.maxValuesLb_.Size = new System.Drawing.Size(96, 23);
			this.maxValuesLb_.TabIndex = 2;
			this.maxValuesLb_.Text = "Max Values";
			this.maxValuesLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// IncludeBoundsLB
			// 
			this.includeBoundsLb_.Location = new System.Drawing.Point(0, 0);
			this.includeBoundsLb_.Name = "includeBoundsLb_";
			this.includeBoundsLb_.Size = new System.Drawing.Size(96, 23);
			this.includeBoundsLb_.TabIndex = 3;
			this.includeBoundsLb_.Text = "Include Bounds";
			this.includeBoundsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxValuesCTRL
			// 
			this.maxValuesCtrl_.Location = new System.Drawing.Point(96, 1);
			this.maxValuesCtrl_.Maximum = new System.Decimal(new int[] {
																		  2147483647,
																		  0,
																		  0,
																		  0});
			this.maxValuesCtrl_.Name = "maxValuesCtrl_";
			this.maxValuesCtrl_.Size = new System.Drawing.Size(72, 20);
			this.maxValuesCtrl_.TabIndex = 6;
			// 
			// IncludeBoundsCB
			// 
			this.includeBoundsCb_.Location = new System.Drawing.Point(96, -1);
			this.includeBoundsCb_.Name = "includeBoundsCb_";
			this.includeBoundsCb_.Size = new System.Drawing.Size(16, 24);
			this.includeBoundsCb_.TabIndex = 7;
			// 
			// StartTimeSpecifiedCB
			// 
			this.startTimeSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.startTimeSpecifiedCb_.Location = new System.Drawing.Point(300, -1);
			this.startTimeSpecifiedCb_.Name = "startTimeSpecifiedCb_";
			this.startTimeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.startTimeSpecifiedCb_.TabIndex = 8;
			this.startTimeSpecifiedCb_.CheckedChanged += new System.EventHandler(this.TimeSpecifiedCB_CheckedChanged);
			// 
			// EndTimeSpecifiedCB
			// 
			this.endTimeSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.endTimeSpecifiedCb_.Location = new System.Drawing.Point(300, -1);
			this.endTimeSpecifiedCb_.Name = "endTimeSpecifiedCb_";
			this.endTimeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.endTimeSpecifiedCb_.TabIndex = 9;
			this.endTimeSpecifiedCb_.CheckedChanged += new System.EventHandler(this.TimeSpecifiedCB_CheckedChanged);
			// 
			// StartTimeCTRL
			// 
			this.startTimeCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.startTimeCtrl_.Enabled = false;
			this.startTimeCtrl_.Location = new System.Drawing.Point(96, 0);
			this.startTimeCtrl_.Name = "startTimeCtrl_";
			this.startTimeCtrl_.Size = new System.Drawing.Size(200, 24);
			this.startTimeCtrl_.TabIndex = 10;
			// 
			// EndTimeCTRL
			// 
			this.endTimeCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.endTimeCtrl_.Enabled = false;
			this.endTimeCtrl_.Location = new System.Drawing.Point(96, 0);
			this.endTimeCtrl_.Name = "endTimeCtrl_";
			this.endTimeCtrl_.Size = new System.Drawing.Size(200, 24);
			this.endTimeCtrl_.TabIndex = 11;
			// 
			// AggregateLB
			// 
			this.aggregateLb_.Location = new System.Drawing.Point(0, 0);
			this.aggregateLb_.Name = "aggregateLb_";
			this.aggregateLb_.Size = new System.Drawing.Size(96, 23);
			this.aggregateLb_.TabIndex = 12;
			this.aggregateLb_.Text = "Aggregate";
			this.aggregateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AggregateCB
			// 
			this.aggregateCb_.Enabled = false;
			this.aggregateCb_.Location = new System.Drawing.Point(96, 0);
			this.aggregateCb_.Name = "aggregateCb_";
			this.aggregateCb_.Size = new System.Drawing.Size(204, 21);
			this.aggregateCb_.TabIndex = 13;
			// 
			// NameLB
			// 
			this.nameLb_.Location = new System.Drawing.Point(0, 0);
			this.nameLb_.Name = "nameLb_";
			this.nameLb_.Size = new System.Drawing.Size(96, 23);
			this.nameLb_.TabIndex = 14;
			this.nameLb_.Text = "Name";
			this.nameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameTB
			// 
			this.nameTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.nameTb_.Location = new System.Drawing.Point(96, 0);
			this.nameTb_.Name = "nameTb_";
			this.nameTb_.Size = new System.Drawing.Size(216, 20);
			this.nameTb_.TabIndex = 15;
			this.nameTb_.Text = "";
			// 
			// ResampleIntervalCTRL
			// 
			this.resampleIntervalCtrl_.DecimalPlaces = 6;
			this.resampleIntervalCtrl_.Enabled = false;
			this.resampleIntervalCtrl_.Location = new System.Drawing.Point(96, 1);
			this.resampleIntervalCtrl_.Maximum = new System.Decimal(new int[] {
																				 -1,
																				 2147483647,
																				 0,
																				 0});
			this.resampleIntervalCtrl_.Name = "resampleIntervalCtrl_";
			this.resampleIntervalCtrl_.TabIndex = 17;
			// 
			// ResampleIntervalLB
			// 
			this.resampleIntervalLb_.Location = new System.Drawing.Point(0, 0);
			this.resampleIntervalLb_.Name = "resampleIntervalLb_";
			this.resampleIntervalLb_.Size = new System.Drawing.Size(96, 23);
			this.resampleIntervalLb_.TabIndex = 16;
			this.resampleIntervalLb_.Text = "Resample Interval";
			this.resampleIntervalLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AggregateSpecifiedCB
			// 
			this.aggregateSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.aggregateSpecifiedCb_.Location = new System.Drawing.Point(300, -1);
			this.aggregateSpecifiedCb_.Name = "aggregateSpecifiedCb_";
			this.aggregateSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			this.aggregateSpecifiedCb_.TabIndex = 18;
			this.aggregateSpecifiedCb_.CheckedChanged += new System.EventHandler(this.AggregateSpecifiedCB_CheckedChanged);
			// 
			// UpdateIntervalCTRL
			// 
			this.updateIntervalCtrl_.DecimalPlaces = 6;
			this.updateIntervalCtrl_.Location = new System.Drawing.Point(96, 1);
			this.updateIntervalCtrl_.Maximum = new System.Decimal(new int[] {
																			   -1,
																			   2147483647,
																			   0,
																			   0});
			this.updateIntervalCtrl_.Name = "updateIntervalCtrl_";
			this.updateIntervalCtrl_.TabIndex = 20;
			// 
			// UpdateIntervalLB
			// 
			this.updateIntervalLb_.Location = new System.Drawing.Point(0, 0);
			this.updateIntervalLb_.Name = "updateIntervalLb_";
			this.updateIntervalLb_.Size = new System.Drawing.Size(96, 23);
			this.updateIntervalLb_.TabIndex = 19;
			this.updateIntervalLb_.Text = "Update Interval";
			this.updateIntervalLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackDurationCTRL
			// 
			this.playbackDurationCtrl_.DecimalPlaces = 6;
			this.playbackDurationCtrl_.Location = new System.Drawing.Point(96, 25);
			this.playbackDurationCtrl_.Maximum = new System.Decimal(new int[] {
																				 -1,
																				 2147483647,
																				 0,
																				 0});
			this.playbackDurationCtrl_.Name = "playbackDurationCtrl_";
			this.playbackDurationCtrl_.TabIndex = 22;
			// 
			// PlaybackDurationLB
			// 
			this.playbackDurationLb_.Location = new System.Drawing.Point(0, 24);
			this.playbackDurationLb_.Name = "playbackDurationLb_";
			this.playbackDurationLb_.Size = new System.Drawing.Size(96, 23);
			this.playbackDurationLb_.TabIndex = 21;
			this.playbackDurationLb_.Text = "Playback Duration";
			this.playbackDurationLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UpdateIntervalUnitsLB
			// 
			this.updateIntervalUnitsLb_.Location = new System.Drawing.Point(220, 0);
			this.updateIntervalUnitsLb_.Name = "updateIntervalUnitsLb_";
			this.updateIntervalUnitsLb_.Size = new System.Drawing.Size(52, 23);
			this.updateIntervalUnitsLb_.TabIndex = 23;
			this.updateIntervalUnitsLb_.Text = "Seconds";
			this.updateIntervalUnitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackDurationUnitsLB
			// 
			this.playbackDurationUnitsLb_.Location = new System.Drawing.Point(220, 24);
			this.playbackDurationUnitsLb_.Name = "playbackDurationUnitsLb_";
			this.playbackDurationUnitsLb_.Size = new System.Drawing.Size(52, 23);
			this.playbackDurationUnitsLb_.TabIndex = 24;
			this.playbackDurationUnitsLb_.Text = "Seconds";
			this.playbackDurationUnitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ResampleIntervalUnitsLB
			// 
			this.resampleIntervalUnitsLb_.Location = new System.Drawing.Point(220, 0);
			this.resampleIntervalUnitsLb_.Name = "resampleIntervalUnitsLb_";
			this.resampleIntervalUnitsLb_.Size = new System.Drawing.Size(52, 23);
			this.resampleIntervalUnitsLb_.TabIndex = 25;
			this.resampleIntervalUnitsLb_.Text = "Seconds";
			this.resampleIntervalUnitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackIntervalUnitsLB
			// 
			this.playbackIntervalUnitsLb_.Location = new System.Drawing.Point(220, 0);
			this.playbackIntervalUnitsLb_.Name = "playbackIntervalUnitsLb_";
			this.playbackIntervalUnitsLb_.Size = new System.Drawing.Size(52, 23);
			this.playbackIntervalUnitsLb_.TabIndex = 28;
			this.playbackIntervalUnitsLb_.Text = "Seconds";
			this.playbackIntervalUnitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackIntervalCTRL
			// 
			this.playbackIntervalCtrl_.DecimalPlaces = 6;
			this.playbackIntervalCtrl_.Location = new System.Drawing.Point(96, 1);
			this.playbackIntervalCtrl_.Maximum = new System.Decimal(new int[] {
																				 -1,
																				 2147483647,
																				 0,
																				 0});
			this.playbackIntervalCtrl_.Name = "playbackIntervalCtrl_";
			this.playbackIntervalCtrl_.TabIndex = 27;
			// 
			// PlaybackIntervalLB
			// 
			this.playbackIntervalLb_.Location = new System.Drawing.Point(0, 0);
			this.playbackIntervalLb_.Name = "playbackIntervalLb_";
			this.playbackIntervalLb_.Size = new System.Drawing.Size(96, 23);
			this.playbackIntervalLb_.TabIndex = 26;
			this.playbackIntervalLb_.Text = "Playback Interval";
			this.playbackIntervalLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackPN
			// 
			this.playbackPn_.Controls.Add(this.playbackDurationLb_);
			this.playbackPn_.Controls.Add(this.playbackDurationCtrl_);
			this.playbackPn_.Controls.Add(this.playbackDurationUnitsLb_);
			this.playbackPn_.Controls.Add(this.playbackIntervalUnitsLb_);
			this.playbackPn_.Controls.Add(this.playbackIntervalCtrl_);
			this.playbackPn_.Controls.Add(this.playbackIntervalLb_);
			this.playbackPn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.playbackPn_.Location = new System.Drawing.Point(0, 192);
			this.playbackPn_.Name = "playbackPn_";
			this.playbackPn_.Size = new System.Drawing.Size(316, 48);
			this.playbackPn_.TabIndex = 29;
			// 
			// SubscribePN
			// 
			this.subscribePn_.Controls.Add(this.updateIntervalLb_);
			this.subscribePn_.Controls.Add(this.updateIntervalUnitsLb_);
			this.subscribePn_.Controls.Add(this.updateIntervalCtrl_);
			this.subscribePn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.subscribePn_.Location = new System.Drawing.Point(0, 168);
			this.subscribePn_.Name = "subscribePn_";
			this.subscribePn_.Size = new System.Drawing.Size(316, 24);
			this.subscribePn_.TabIndex = 30;
			// 
			// ProcessedPN
			// 
			this.processedPn_.Controls.Add(this.resampleIntervalLb_);
			this.processedPn_.Controls.Add(this.resampleIntervalCtrl_);
			this.processedPn_.Controls.Add(this.resampleIntervalUnitsLb_);
			this.processedPn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.processedPn_.Location = new System.Drawing.Point(0, 144);
			this.processedPn_.Name = "processedPn_";
			this.processedPn_.Size = new System.Drawing.Size(316, 24);
			this.processedPn_.TabIndex = 31;
			// 
			// RawPN
			// 
			this.rawPn_.Controls.Add(this.includeBoundsCb_);
			this.rawPn_.Controls.Add(this.includeBoundsLb_);
			this.rawPn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.rawPn_.Location = new System.Drawing.Point(0, 120);
			this.rawPn_.Name = "rawPn_";
			this.rawPn_.Size = new System.Drawing.Size(316, 24);
			this.rawPn_.TabIndex = 32;
			// 
			// MaxValuesPN
			// 
			this.maxValuesPn_.Controls.Add(this.maxValuesCtrl_);
			this.maxValuesPn_.Controls.Add(this.maxValuesLb_);
			this.maxValuesPn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.maxValuesPn_.Location = new System.Drawing.Point(0, 96);
			this.maxValuesPn_.Name = "maxValuesPn_";
			this.maxValuesPn_.Size = new System.Drawing.Size(316, 24);
			this.maxValuesPn_.TabIndex = 33;
			// 
			// EndTimePN
			// 
			this.endTimePn_.Controls.Add(this.endTimeSpecifiedCb_);
			this.endTimePn_.Controls.Add(this.endTimeLb_);
			this.endTimePn_.Controls.Add(this.endTimeCtrl_);
			this.endTimePn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.endTimePn_.Location = new System.Drawing.Point(0, 72);
			this.endTimePn_.Name = "endTimePn_";
			this.endTimePn_.Size = new System.Drawing.Size(316, 24);
			this.endTimePn_.TabIndex = 34;
			// 
			// NamePN
			// 
			this.namePn_.Controls.Add(this.nameLb_);
			this.namePn_.Controls.Add(this.nameTb_);
			this.namePn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.namePn_.Location = new System.Drawing.Point(0, 0);
			this.namePn_.Name = "namePn_";
			this.namePn_.Size = new System.Drawing.Size(316, 24);
			this.namePn_.TabIndex = 36;
			// 
			// AggregatePN
			// 
			this.aggregatePn_.Controls.Add(this.aggregateLb_);
			this.aggregatePn_.Controls.Add(this.aggregateCb_);
			this.aggregatePn_.Controls.Add(this.aggregateSpecifiedCb_);
			this.aggregatePn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.aggregatePn_.Location = new System.Drawing.Point(0, 24);
			this.aggregatePn_.Name = "aggregatePn_";
			this.aggregatePn_.Size = new System.Drawing.Size(316, 24);
			this.aggregatePn_.TabIndex = 37;
			// 
			// StartTimePN
			// 
			this.startTimePn_.Controls.Add(this.startTimeSpecifiedCb_);
			this.startTimePn_.Controls.Add(this.startTimeCtrl_);
			this.startTimePn_.Controls.Add(this.startTimeLb_);
			this.startTimePn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.startTimePn_.Location = new System.Drawing.Point(0, 48);
			this.startTimePn_.Name = "startTimePn_";
			this.startTimePn_.Size = new System.Drawing.Size(316, 24);
			this.startTimePn_.TabIndex = 38;
			// 
			// TimestampsPN
			// 
			this.timestampsPn_.Controls.Add(this.timestampsCtrl_);
			this.timestampsPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.timestampsPn_.Location = new System.Drawing.Point(0, 240);
			this.timestampsPn_.Name = "timestampsPn_";
			this.timestampsPn_.Size = new System.Drawing.Size(316, 256);
			this.timestampsPn_.TabIndex = 39;
			// 
			// TimestampsCTRL
			// 
			this.timestampsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.timestampsCtrl_.Location = new System.Drawing.Point(0, 0);
			this.timestampsCtrl_.Name = "timestampsCtrl_";
			this.timestampsCtrl_.Size = new System.Drawing.Size(316, 256);
			this.timestampsCtrl_.TabIndex = 0;
			// 
			// TrendEditCtrl
			// 
			this.Controls.Add(this.timestampsPn_);
			this.Controls.Add(this.playbackPn_);
			this.Controls.Add(this.subscribePn_);
			this.Controls.Add(this.processedPn_);
			this.Controls.Add(this.rawPn_);
			this.Controls.Add(this.maxValuesPn_);
			this.Controls.Add(this.endTimePn_);
			this.Controls.Add(this.startTimePn_);
			this.Controls.Add(this.aggregatePn_);
			this.Controls.Add(this.namePn_);
			this.Name = "TrendEditCtrl";
			this.Size = new System.Drawing.Size(316, 496);
			((System.ComponentModel.ISupportInitialize)(this.maxValuesCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.resampleIntervalCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.updateIntervalCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.playbackDurationCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.playbackIntervalCtrl_)).EndInit();
			this.playbackPn_.ResumeLayout(false);
			this.subscribePn_.ResumeLayout(false);
			this.processedPn_.ResumeLayout(false);
			this.rawPn_.ResumeLayout(false);
			this.maxValuesPn_.ResumeLayout(false);
			this.endTimePn_.ResumeLayout(false);
			this.namePn_.ResumeLayout(false);
			this.aggregatePn_.ResumeLayout(false);
			this.startTimePn_.ResumeLayout(false);
			this.timestampsPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Updates control visibility according the request type.
		/// </summary>
		public RequestType RequestType
		{
			get { return mType_; }
			set { mType_ = value; SetState(mType_); }
		}

		/// <summary>
		/// Initializes the control with the specified trend.
		/// </summary>
		public void Initialize(TsCHdaTrend trend, RequestType type)
		{
			// set controls to default values.
			nameTb_.Text                  = "";
			aggregateSpecifiedCb_.Checked = false;
			startTimeCtrl_.Set(new TsCHdaTime("YEAR"));
			startTimeSpecifiedCb_.Checked = true;
			endTimeCtrl_.Set(new TsCHdaTime("YEAR+1H"));
			endTimeSpecifiedCb_.Checked   = true;
			maxValuesCtrl_.Value          = 0;
			includeBoundsCb_.Checked      = false;
			resampleIntervalCtrl_.Value   = 0;
			updateIntervalCtrl_.Value     = 0;
			playbackIntervalCtrl_.Value   = 0;
			playbackDurationCtrl_.Value   = 0;

			aggregateCb_.Items.Clear();

			// update controls with trend properties.
			if (trend != null)
			{
				foreach (TsCHdaAggregate aggregate in trend.Server.Aggregates)
				{
					aggregateCb_.Items.Add(aggregate);

					if (aggregate.Id == trend.Aggregate)
					{
						aggregateCb_.SelectedItem = aggregate;
					}
				}

				nameTb_.Text                  = trend.Name;
				aggregateSpecifiedCb_.Checked = trend.Aggregate != TsCHdaAggregateID.NoAggregate;
				startTimeCtrl_.Set(trend.StartTime);
				startTimeSpecifiedCb_.Checked = trend.StartTime != null;
				endTimeCtrl_.Set(trend.EndTime);
				endTimeSpecifiedCb_.Checked   = trend.EndTime != null;
				maxValuesCtrl_.Value          = trend.MaxValues;
				includeBoundsCb_.Checked      = trend.IncludeBounds;
				resampleIntervalCtrl_.Value   = trend.ResampleInterval;
				updateIntervalCtrl_.Value     = trend.UpdateInterval;
				playbackIntervalCtrl_.Value   = trend.PlaybackInterval;
				playbackDurationCtrl_.Value   = trend.PlaybackDuration;

				timestampsCtrl_.Initialize(trend.Server, trend.Timestamps);
			}

			// update control visibility.
			RequestType = type;
		}
		
		/// <summary>
		/// Updates specified trend with values in the controls.
		/// </summary>
		public void Update(TsCHdaTrend trend)
		{
			trend.Name             = nameTb_.Text;
			trend.Aggregate = TsCHdaAggregateID.NoAggregate;
			trend.StartTime        = startTimeCtrl_.Get();
			trend.EndTime          = endTimeCtrl_.Get();
			trend.MaxValues        = (int)maxValuesCtrl_.Value;
			trend.IncludeBounds    = includeBoundsCb_.Checked;
			trend.ResampleInterval = resampleIntervalCtrl_.Value;
			trend.UpdateInterval   = updateIntervalCtrl_.Value;
			trend.PlaybackInterval = playbackIntervalCtrl_.Value;
			trend.PlaybackDuration = playbackDurationCtrl_.Value;
			trend.Timestamps       = timestampsCtrl_.GetTimes();

			if (!startTimeSpecifiedCb_.Checked)
			{
				trend.StartTime = null;
			}

			if (!endTimeSpecifiedCb_.Checked)
			{
				trend.EndTime = null;
			}

			if (aggregateSpecifiedCb_.Checked)
			{
				TsCHdaAggregate aggregate = (TsCHdaAggregate)aggregateCb_.SelectedItem;

				if (aggregate != null)
				{
					trend.Aggregate = aggregate.Id;
				}
			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Constants for unit labels.
		/// </summary>
		private const string Seconds   = "Seconds";
		private const string Intervals = "Intervals";

		private RequestType mType_ = RequestType.ReadRaw;

		private void SetState(RequestType type)
		{
			namePn_.Visible       = false;
			aggregatePn_.Visible  = false;
			startTimePn_.Visible  = false;
			endTimePn_.Visible    = false;
			maxValuesPn_.Visible  = false;
			rawPn_.Visible        = false;
			processedPn_.Visible  = false;
			subscribePn_.Visible  = false;
			playbackPn_.Visible   = false;
			timestampsPn_.Visible = false;

			switch (type)
			{				
				case RequestType.None:
				{					
					namePn_.Visible      = true;
					aggregatePn_.Visible = true;
					startTimePn_.Visible = true;
					endTimePn_.Visible   = true;
					maxValuesPn_.Visible = true;
					rawPn_.Visible       = true;
					processedPn_.Visible = true;
					subscribePn_.Visible = true;
					playbackPn_.Visible  = true;
					break;
				}

				case RequestType.ReadRaw:
				{					
					startTimePn_.Visible = true;
					endTimePn_.Visible   = true;
					maxValuesPn_.Visible = true;
					rawPn_.Visible       = true;
					
					aggregateSpecifiedCb_.Checked = false;
					break;
				}

				case RequestType.AdviseRaw:
				{					
					startTimePn_.Visible = true;
					subscribePn_.Visible = true;

					aggregateSpecifiedCb_.Checked = false;
					startTimeSpecifiedCb_.Checked = true;
					startTimeSpecifiedCb_.Enabled = false;
					break;
				}

				case RequestType.PlaybackRaw:
				{					
					startTimePn_.Visible  = true;
					endTimePn_.Visible    = true;
					maxValuesPn_.Visible  = true;
					playbackPn_.Visible   = true;

					aggregateSpecifiedCb_.Checked = false;
					startTimeSpecifiedCb_.Checked = true;
					startTimeSpecifiedCb_.Enabled = false;
					break;
				}

				case RequestType.ReadProcessed:
				{					
					aggregatePn_.Visible = true;
					startTimePn_.Visible = true;
					endTimePn_.Visible   = true;
					processedPn_.Visible = true;

					aggregateSpecifiedCb_.Checked = true;
					break;
				}

				case RequestType.AdviseProcessed:
				{					
					aggregatePn_.Visible = true;
					startTimePn_.Visible = true;
					processedPn_.Visible = true;
					subscribePn_.Visible = true;

					aggregateSpecifiedCb_.Checked = true;
					break;
				}

				case RequestType.PlaybackProcessed:
				{					
					aggregatePn_.Visible = true;
					startTimePn_.Visible = true;
					endTimePn_.Visible   = true;
					processedPn_.Visible = true;
					playbackPn_.Visible  = true;

					aggregateSpecifiedCb_.Checked = true;
					break;
				}

				case RequestType.ReadModified:
				{					
					startTimePn_.Visible = true;
					endTimePn_.Visible   = true;
					maxValuesPn_.Visible = true;

					aggregateSpecifiedCb_.Checked = false;
					break;
				}

				case RequestType.ReadAtTime:
				case RequestType.DeleteAtTime:
				{
					timestampsPn_.Visible = true;
					break;
				}

				case RequestType.ReadAttributes:
				case RequestType.ReadAnnotations:
				case RequestType.DeleteRaw:
				{					
					startTimePn_.Visible = true;
					endTimePn_.Visible   = true;

					aggregateSpecifiedCb_.Checked = false;
					startTimeSpecifiedCb_.Enabled = true;
					endTimeSpecifiedCb_.Enabled   = true;
					
					break;
				}
			}
		}
		#endregion

		/// <summary>
		/// Toggles the enabled state of various controls.
		/// </summary>
		private void TimeSpecifiedCB_CheckedChanged(object sender, System.EventArgs e)
		{
			startTimeCtrl_.Enabled = startTimeSpecifiedCb_.Checked;
			endTimeCtrl_.Enabled   = endTimeSpecifiedCb_.Checked;
		}

		/// <summary>
		/// Toggles between raw data and processed data modes.
		/// </summary>
		private void AggregateSpecifiedCB_CheckedChanged(object sender, System.EventArgs e)
		{
			if (aggregateSpecifiedCb_.Checked)
			{
				maxValuesCtrl_.Enabled              = false;
				includeBoundsCb_.Enabled            = false;
				aggregateCb_.Enabled                = true;
				resampleIntervalCtrl_.Enabled       = true;
				startTimeSpecifiedCb_.Checked       = true;
				startTimeSpecifiedCb_.Enabled       = false;
				endTimeSpecifiedCb_.Checked         = true;
				endTimeSpecifiedCb_.Enabled         = false;
				updateIntervalCtrl_.DecimalPlaces   = 0;
				updateIntervalUnitsLb_.Text         = Intervals;
				playbackDurationCtrl_.DecimalPlaces = 0;
				playbackDurationUnitsLb_.Text       = Intervals;

				if (aggregateCb_.SelectedIndex < 0 && aggregateCb_.Items.Count > 0)
				{
					aggregateCb_.SelectedIndex = 0;
				}
			}
			else
			{
				maxValuesCtrl_.Enabled              = true;
				includeBoundsCb_.Enabled            = true;
				aggregateCb_.Enabled                = false;
				resampleIntervalCtrl_.Enabled       = false;
				startTimeSpecifiedCb_.Enabled       = true;
				endTimeSpecifiedCb_.Enabled         = true;
				updateIntervalCtrl_.DecimalPlaces   = 6;
				updateIntervalUnitsLb_.Text         = Seconds;
				playbackDurationCtrl_.DecimalPlaces = 6;
				playbackDurationUnitsLb_.Text       = Seconds;
			}
		}
	}

	/// <summary>
	/// The set of possible operations for a trend.
	/// </summary>
	public enum RequestType
	{
		/// <summary>
		/// No specific request. All properties are used.
		/// </summary>
		None,

		/// <summary>
		/// A read raw or a read processed request.
		/// </summary>
		Read,

		/// <summary>
		/// A read raw data request.
		/// </summary>
		ReadRaw,

		/// <summary>
		/// A subscription for raw data.
		/// </summary>
		AdviseRaw,

		/// <summary>
		/// A request to playback raw data.
		/// </summary>
		PlaybackRaw,

		/// <summary>
		/// A read processed data request.
		/// </summary>
		ReadProcessed,

		/// <summary>
		/// A subscription for processed data.
		/// </summary>
		AdviseProcessed,

		/// <summary>
		/// A request to playback processed data.
		/// </summary>
		PlaybackProcessed,
		
		/// <summary>
		/// A read modified data request.
		/// </summary>
		ReadModified,
		
		/// <summary>
		/// A request to read data at specific times.
		/// </summary>
		ReadAtTime,

		/// <summary>
		/// A read attributes request.
		/// </summary>
		ReadAttributes,

		/// <summary>
		/// A read annotations request.
		/// </summary>
		ReadAnnotations,

		/// <summary>
		/// A insert annotations request.
		/// </summary>
		InsertAnnotations,
		
		/// <summary>
		/// An insert new data request.
		/// </summary>
		Insert,

		/// <summary>
		/// An insert new or replace existing data request.
		/// </summary>
		InsertReplace,

		/// <summary>
		/// A replace existing data request.
		/// </summary>
		Replace,

		/// <summary>
		/// A delete raw data request.
		/// </summary>
		DeleteRaw,

		/// <summary>
		/// A request to delete data at specific times.
		/// </summary>
		DeleteAtTime
	}
}

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
			startTimeLb_ = new System.Windows.Forms.Label();
			endTimeLb_ = new System.Windows.Forms.Label();
			maxValuesLb_ = new System.Windows.Forms.Label();
			includeBoundsLb_ = new System.Windows.Forms.Label();
			maxValuesCtrl_ = new System.Windows.Forms.NumericUpDown();
			includeBoundsCb_ = new System.Windows.Forms.CheckBox();
			startTimeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			endTimeSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			startTimeCtrl_ = new TimeCtrl();
			endTimeCtrl_ = new TimeCtrl();
			aggregateLb_ = new System.Windows.Forms.Label();
			aggregateCb_ = new System.Windows.Forms.ComboBox();
			nameLb_ = new System.Windows.Forms.Label();
			nameTb_ = new System.Windows.Forms.TextBox();
			resampleIntervalCtrl_ = new System.Windows.Forms.NumericUpDown();
			resampleIntervalLb_ = new System.Windows.Forms.Label();
			aggregateSpecifiedCb_ = new System.Windows.Forms.CheckBox();
			updateIntervalCtrl_ = new System.Windows.Forms.NumericUpDown();
			updateIntervalLb_ = new System.Windows.Forms.Label();
			playbackDurationCtrl_ = new System.Windows.Forms.NumericUpDown();
			playbackDurationLb_ = new System.Windows.Forms.Label();
			updateIntervalUnitsLb_ = new System.Windows.Forms.Label();
			playbackDurationUnitsLb_ = new System.Windows.Forms.Label();
			resampleIntervalUnitsLb_ = new System.Windows.Forms.Label();
			playbackIntervalUnitsLb_ = new System.Windows.Forms.Label();
			playbackIntervalCtrl_ = new System.Windows.Forms.NumericUpDown();
			playbackIntervalLb_ = new System.Windows.Forms.Label();
			playbackPn_ = new System.Windows.Forms.Panel();
			subscribePn_ = new System.Windows.Forms.Panel();
			processedPn_ = new System.Windows.Forms.Panel();
			rawPn_ = new System.Windows.Forms.Panel();
			maxValuesPn_ = new System.Windows.Forms.Panel();
			endTimePn_ = new System.Windows.Forms.Panel();
			namePn_ = new System.Windows.Forms.Panel();
			aggregatePn_ = new System.Windows.Forms.Panel();
			startTimePn_ = new System.Windows.Forms.Panel();
			timestampsPn_ = new System.Windows.Forms.Panel();
			timestampsCtrl_ = new ItemTimesCtrl();
			((System.ComponentModel.ISupportInitialize)(maxValuesCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(resampleIntervalCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(updateIntervalCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(playbackDurationCtrl_)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(playbackIntervalCtrl_)).BeginInit();
			playbackPn_.SuspendLayout();
			subscribePn_.SuspendLayout();
			processedPn_.SuspendLayout();
			rawPn_.SuspendLayout();
			maxValuesPn_.SuspendLayout();
			endTimePn_.SuspendLayout();
			namePn_.SuspendLayout();
			aggregatePn_.SuspendLayout();
			startTimePn_.SuspendLayout();
			timestampsPn_.SuspendLayout();
			SuspendLayout();
			// 
			// StartTimeLB
			// 
			startTimeLb_.Location = new System.Drawing.Point(0, 0);
			startTimeLb_.Name = "startTimeLb_";
			startTimeLb_.Size = new System.Drawing.Size(96, 23);
			startTimeLb_.TabIndex = 0;
			startTimeLb_.Text = "Start Time";
			startTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EndTimeLB
			// 
			endTimeLb_.Location = new System.Drawing.Point(0, 0);
			endTimeLb_.Name = "endTimeLb_";
			endTimeLb_.Size = new System.Drawing.Size(96, 23);
			endTimeLb_.TabIndex = 1;
			endTimeLb_.Text = "End Time";
			endTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxValuesLB
			// 
			maxValuesLb_.Location = new System.Drawing.Point(0, 0);
			maxValuesLb_.Name = "maxValuesLb_";
			maxValuesLb_.Size = new System.Drawing.Size(96, 23);
			maxValuesLb_.TabIndex = 2;
			maxValuesLb_.Text = "Max Values";
			maxValuesLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// IncludeBoundsLB
			// 
			includeBoundsLb_.Location = new System.Drawing.Point(0, 0);
			includeBoundsLb_.Name = "includeBoundsLb_";
			includeBoundsLb_.Size = new System.Drawing.Size(96, 23);
			includeBoundsLb_.TabIndex = 3;
			includeBoundsLb_.Text = "Include Bounds";
			includeBoundsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxValuesCTRL
			// 
			maxValuesCtrl_.Location = new System.Drawing.Point(96, 1);
			maxValuesCtrl_.Maximum = new System.Decimal(new int[] {
																		  2147483647,
																		  0,
																		  0,
																		  0});
			maxValuesCtrl_.Name = "maxValuesCtrl_";
			maxValuesCtrl_.Size = new System.Drawing.Size(72, 20);
			maxValuesCtrl_.TabIndex = 6;
			// 
			// IncludeBoundsCB
			// 
			includeBoundsCb_.Location = new System.Drawing.Point(96, -1);
			includeBoundsCb_.Name = "includeBoundsCb_";
			includeBoundsCb_.Size = new System.Drawing.Size(16, 24);
			includeBoundsCb_.TabIndex = 7;
			// 
			// StartTimeSpecifiedCB
			// 
			startTimeSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			startTimeSpecifiedCb_.Location = new System.Drawing.Point(300, -1);
			startTimeSpecifiedCb_.Name = "startTimeSpecifiedCb_";
			startTimeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			startTimeSpecifiedCb_.TabIndex = 8;
			startTimeSpecifiedCb_.CheckedChanged += new System.EventHandler(TimeSpecifiedCB_CheckedChanged);
			// 
			// EndTimeSpecifiedCB
			// 
			endTimeSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			endTimeSpecifiedCb_.Location = new System.Drawing.Point(300, -1);
			endTimeSpecifiedCb_.Name = "endTimeSpecifiedCb_";
			endTimeSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			endTimeSpecifiedCb_.TabIndex = 9;
			endTimeSpecifiedCb_.CheckedChanged += new System.EventHandler(TimeSpecifiedCB_CheckedChanged);
			// 
			// StartTimeCTRL
			// 
			startTimeCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			startTimeCtrl_.Enabled = false;
			startTimeCtrl_.Location = new System.Drawing.Point(96, 0);
			startTimeCtrl_.Name = "startTimeCtrl_";
			startTimeCtrl_.Size = new System.Drawing.Size(200, 24);
			startTimeCtrl_.TabIndex = 10;
			// 
			// EndTimeCTRL
			// 
			endTimeCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			endTimeCtrl_.Enabled = false;
			endTimeCtrl_.Location = new System.Drawing.Point(96, 0);
			endTimeCtrl_.Name = "endTimeCtrl_";
			endTimeCtrl_.Size = new System.Drawing.Size(200, 24);
			endTimeCtrl_.TabIndex = 11;
			// 
			// AggregateLB
			// 
			aggregateLb_.Location = new System.Drawing.Point(0, 0);
			aggregateLb_.Name = "aggregateLb_";
			aggregateLb_.Size = new System.Drawing.Size(96, 23);
			aggregateLb_.TabIndex = 12;
			aggregateLb_.Text = "Aggregate";
			aggregateLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AggregateCB
			// 
			aggregateCb_.Enabled = false;
			aggregateCb_.Location = new System.Drawing.Point(96, 0);
			aggregateCb_.Name = "aggregateCb_";
			aggregateCb_.Size = new System.Drawing.Size(204, 21);
			aggregateCb_.TabIndex = 13;
			// 
			// NameLB
			// 
			nameLb_.Location = new System.Drawing.Point(0, 0);
			nameLb_.Name = "nameLb_";
			nameLb_.Size = new System.Drawing.Size(96, 23);
			nameLb_.TabIndex = 14;
			nameLb_.Text = "Name";
			nameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameTB
			// 
			nameTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			nameTb_.Location = new System.Drawing.Point(96, 0);
			nameTb_.Name = "nameTb_";
			nameTb_.Size = new System.Drawing.Size(216, 20);
			nameTb_.TabIndex = 15;
			nameTb_.Text = "";
			// 
			// ResampleIntervalCTRL
			// 
			resampleIntervalCtrl_.DecimalPlaces = 6;
			resampleIntervalCtrl_.Enabled = false;
			resampleIntervalCtrl_.Location = new System.Drawing.Point(96, 1);
			resampleIntervalCtrl_.Maximum = new System.Decimal(new int[] {
																				 -1,
																				 2147483647,
																				 0,
																				 0});
			resampleIntervalCtrl_.Name = "resampleIntervalCtrl_";
			resampleIntervalCtrl_.TabIndex = 17;
			// 
			// ResampleIntervalLB
			// 
			resampleIntervalLb_.Location = new System.Drawing.Point(0, 0);
			resampleIntervalLb_.Name = "resampleIntervalLb_";
			resampleIntervalLb_.Size = new System.Drawing.Size(96, 23);
			resampleIntervalLb_.TabIndex = 16;
			resampleIntervalLb_.Text = "Resample Interval";
			resampleIntervalLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AggregateSpecifiedCB
			// 
			aggregateSpecifiedCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			aggregateSpecifiedCb_.Location = new System.Drawing.Point(300, -1);
			aggregateSpecifiedCb_.Name = "aggregateSpecifiedCb_";
			aggregateSpecifiedCb_.Size = new System.Drawing.Size(16, 24);
			aggregateSpecifiedCb_.TabIndex = 18;
			aggregateSpecifiedCb_.CheckedChanged += new System.EventHandler(AggregateSpecifiedCB_CheckedChanged);
			// 
			// UpdateIntervalCTRL
			// 
			updateIntervalCtrl_.DecimalPlaces = 6;
			updateIntervalCtrl_.Location = new System.Drawing.Point(96, 1);
			updateIntervalCtrl_.Maximum = new System.Decimal(new int[] {
																			   -1,
																			   2147483647,
																			   0,
																			   0});
			updateIntervalCtrl_.Name = "updateIntervalCtrl_";
			updateIntervalCtrl_.TabIndex = 20;
			// 
			// UpdateIntervalLB
			// 
			updateIntervalLb_.Location = new System.Drawing.Point(0, 0);
			updateIntervalLb_.Name = "updateIntervalLb_";
			updateIntervalLb_.Size = new System.Drawing.Size(96, 23);
			updateIntervalLb_.TabIndex = 19;
			updateIntervalLb_.Text = "Update Interval";
			updateIntervalLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackDurationCTRL
			// 
			playbackDurationCtrl_.DecimalPlaces = 6;
			playbackDurationCtrl_.Location = new System.Drawing.Point(96, 25);
			playbackDurationCtrl_.Maximum = new System.Decimal(new int[] {
																				 -1,
																				 2147483647,
																				 0,
																				 0});
			playbackDurationCtrl_.Name = "playbackDurationCtrl_";
			playbackDurationCtrl_.TabIndex = 22;
			// 
			// PlaybackDurationLB
			// 
			playbackDurationLb_.Location = new System.Drawing.Point(0, 24);
			playbackDurationLb_.Name = "playbackDurationLb_";
			playbackDurationLb_.Size = new System.Drawing.Size(96, 23);
			playbackDurationLb_.TabIndex = 21;
			playbackDurationLb_.Text = "Playback Duration";
			playbackDurationLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UpdateIntervalUnitsLB
			// 
			updateIntervalUnitsLb_.Location = new System.Drawing.Point(220, 0);
			updateIntervalUnitsLb_.Name = "updateIntervalUnitsLb_";
			updateIntervalUnitsLb_.Size = new System.Drawing.Size(52, 23);
			updateIntervalUnitsLb_.TabIndex = 23;
			updateIntervalUnitsLb_.Text = "Seconds";
			updateIntervalUnitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackDurationUnitsLB
			// 
			playbackDurationUnitsLb_.Location = new System.Drawing.Point(220, 24);
			playbackDurationUnitsLb_.Name = "playbackDurationUnitsLb_";
			playbackDurationUnitsLb_.Size = new System.Drawing.Size(52, 23);
			playbackDurationUnitsLb_.TabIndex = 24;
			playbackDurationUnitsLb_.Text = "Seconds";
			playbackDurationUnitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ResampleIntervalUnitsLB
			// 
			resampleIntervalUnitsLb_.Location = new System.Drawing.Point(220, 0);
			resampleIntervalUnitsLb_.Name = "resampleIntervalUnitsLb_";
			resampleIntervalUnitsLb_.Size = new System.Drawing.Size(52, 23);
			resampleIntervalUnitsLb_.TabIndex = 25;
			resampleIntervalUnitsLb_.Text = "Seconds";
			resampleIntervalUnitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackIntervalUnitsLB
			// 
			playbackIntervalUnitsLb_.Location = new System.Drawing.Point(220, 0);
			playbackIntervalUnitsLb_.Name = "playbackIntervalUnitsLb_";
			playbackIntervalUnitsLb_.Size = new System.Drawing.Size(52, 23);
			playbackIntervalUnitsLb_.TabIndex = 28;
			playbackIntervalUnitsLb_.Text = "Seconds";
			playbackIntervalUnitsLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackIntervalCTRL
			// 
			playbackIntervalCtrl_.DecimalPlaces = 6;
			playbackIntervalCtrl_.Location = new System.Drawing.Point(96, 1);
			playbackIntervalCtrl_.Maximum = new System.Decimal(new int[] {
																				 -1,
																				 2147483647,
																				 0,
																				 0});
			playbackIntervalCtrl_.Name = "playbackIntervalCtrl_";
			playbackIntervalCtrl_.TabIndex = 27;
			// 
			// PlaybackIntervalLB
			// 
			playbackIntervalLb_.Location = new System.Drawing.Point(0, 0);
			playbackIntervalLb_.Name = "playbackIntervalLb_";
			playbackIntervalLb_.Size = new System.Drawing.Size(96, 23);
			playbackIntervalLb_.TabIndex = 26;
			playbackIntervalLb_.Text = "Playback Interval";
			playbackIntervalLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackPN
			// 
			playbackPn_.Controls.Add(playbackDurationLb_);
			playbackPn_.Controls.Add(playbackDurationCtrl_);
			playbackPn_.Controls.Add(playbackDurationUnitsLb_);
			playbackPn_.Controls.Add(playbackIntervalUnitsLb_);
			playbackPn_.Controls.Add(playbackIntervalCtrl_);
			playbackPn_.Controls.Add(playbackIntervalLb_);
			playbackPn_.Dock = System.Windows.Forms.DockStyle.Top;
			playbackPn_.Location = new System.Drawing.Point(0, 192);
			playbackPn_.Name = "playbackPn_";
			playbackPn_.Size = new System.Drawing.Size(316, 48);
			playbackPn_.TabIndex = 29;
			// 
			// SubscribePN
			// 
			subscribePn_.Controls.Add(updateIntervalLb_);
			subscribePn_.Controls.Add(updateIntervalUnitsLb_);
			subscribePn_.Controls.Add(updateIntervalCtrl_);
			subscribePn_.Dock = System.Windows.Forms.DockStyle.Top;
			subscribePn_.Location = new System.Drawing.Point(0, 168);
			subscribePn_.Name = "subscribePn_";
			subscribePn_.Size = new System.Drawing.Size(316, 24);
			subscribePn_.TabIndex = 30;
			// 
			// ProcessedPN
			// 
			processedPn_.Controls.Add(resampleIntervalLb_);
			processedPn_.Controls.Add(resampleIntervalCtrl_);
			processedPn_.Controls.Add(resampleIntervalUnitsLb_);
			processedPn_.Dock = System.Windows.Forms.DockStyle.Top;
			processedPn_.Location = new System.Drawing.Point(0, 144);
			processedPn_.Name = "processedPn_";
			processedPn_.Size = new System.Drawing.Size(316, 24);
			processedPn_.TabIndex = 31;
			// 
			// RawPN
			// 
			rawPn_.Controls.Add(includeBoundsCb_);
			rawPn_.Controls.Add(includeBoundsLb_);
			rawPn_.Dock = System.Windows.Forms.DockStyle.Top;
			rawPn_.Location = new System.Drawing.Point(0, 120);
			rawPn_.Name = "rawPn_";
			rawPn_.Size = new System.Drawing.Size(316, 24);
			rawPn_.TabIndex = 32;
			// 
			// MaxValuesPN
			// 
			maxValuesPn_.Controls.Add(maxValuesCtrl_);
			maxValuesPn_.Controls.Add(maxValuesLb_);
			maxValuesPn_.Dock = System.Windows.Forms.DockStyle.Top;
			maxValuesPn_.Location = new System.Drawing.Point(0, 96);
			maxValuesPn_.Name = "maxValuesPn_";
			maxValuesPn_.Size = new System.Drawing.Size(316, 24);
			maxValuesPn_.TabIndex = 33;
			// 
			// EndTimePN
			// 
			endTimePn_.Controls.Add(endTimeSpecifiedCb_);
			endTimePn_.Controls.Add(endTimeLb_);
			endTimePn_.Controls.Add(endTimeCtrl_);
			endTimePn_.Dock = System.Windows.Forms.DockStyle.Top;
			endTimePn_.Location = new System.Drawing.Point(0, 72);
			endTimePn_.Name = "endTimePn_";
			endTimePn_.Size = new System.Drawing.Size(316, 24);
			endTimePn_.TabIndex = 34;
			// 
			// NamePN
			// 
			namePn_.Controls.Add(nameLb_);
			namePn_.Controls.Add(nameTb_);
			namePn_.Dock = System.Windows.Forms.DockStyle.Top;
			namePn_.Location = new System.Drawing.Point(0, 0);
			namePn_.Name = "namePn_";
			namePn_.Size = new System.Drawing.Size(316, 24);
			namePn_.TabIndex = 36;
			// 
			// AggregatePN
			// 
			aggregatePn_.Controls.Add(aggregateLb_);
			aggregatePn_.Controls.Add(aggregateCb_);
			aggregatePn_.Controls.Add(aggregateSpecifiedCb_);
			aggregatePn_.Dock = System.Windows.Forms.DockStyle.Top;
			aggregatePn_.Location = new System.Drawing.Point(0, 24);
			aggregatePn_.Name = "aggregatePn_";
			aggregatePn_.Size = new System.Drawing.Size(316, 24);
			aggregatePn_.TabIndex = 37;
			// 
			// StartTimePN
			// 
			startTimePn_.Controls.Add(startTimeSpecifiedCb_);
			startTimePn_.Controls.Add(startTimeCtrl_);
			startTimePn_.Controls.Add(startTimeLb_);
			startTimePn_.Dock = System.Windows.Forms.DockStyle.Top;
			startTimePn_.Location = new System.Drawing.Point(0, 48);
			startTimePn_.Name = "startTimePn_";
			startTimePn_.Size = new System.Drawing.Size(316, 24);
			startTimePn_.TabIndex = 38;
			// 
			// TimestampsPN
			// 
			timestampsPn_.Controls.Add(timestampsCtrl_);
			timestampsPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			timestampsPn_.Location = new System.Drawing.Point(0, 240);
			timestampsPn_.Name = "timestampsPn_";
			timestampsPn_.Size = new System.Drawing.Size(316, 256);
			timestampsPn_.TabIndex = 39;
			// 
			// TimestampsCTRL
			// 
			timestampsCtrl_.Dock = System.Windows.Forms.DockStyle.Fill;
			timestampsCtrl_.Location = new System.Drawing.Point(0, 0);
			timestampsCtrl_.Name = "timestampsCtrl_";
			timestampsCtrl_.Size = new System.Drawing.Size(316, 256);
			timestampsCtrl_.TabIndex = 0;
			// 
			// TrendEditCtrl
			// 
			Controls.Add(timestampsPn_);
			Controls.Add(playbackPn_);
			Controls.Add(subscribePn_);
			Controls.Add(processedPn_);
			Controls.Add(rawPn_);
			Controls.Add(maxValuesPn_);
			Controls.Add(endTimePn_);
			Controls.Add(startTimePn_);
			Controls.Add(aggregatePn_);
			Controls.Add(namePn_);
			Name = "TrendEditCtrl";
			Size = new System.Drawing.Size(316, 496);
			((System.ComponentModel.ISupportInitialize)(maxValuesCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(resampleIntervalCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(updateIntervalCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(playbackDurationCtrl_)).EndInit();
			((System.ComponentModel.ISupportInitialize)(playbackIntervalCtrl_)).EndInit();
			playbackPn_.ResumeLayout(false);
			subscribePn_.ResumeLayout(false);
			processedPn_.ResumeLayout(false);
			rawPn_.ResumeLayout(false);
			maxValuesPn_.ResumeLayout(false);
			endTimePn_.ResumeLayout(false);
			namePn_.ResumeLayout(false);
			aggregatePn_.ResumeLayout(false);
			startTimePn_.ResumeLayout(false);
			timestampsPn_.ResumeLayout(false);
			ResumeLayout(false);

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

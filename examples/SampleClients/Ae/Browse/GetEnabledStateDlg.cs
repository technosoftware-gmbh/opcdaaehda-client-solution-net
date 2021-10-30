#region Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
// Web: http://www.technosoftware.com 
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved

using SampleClients.Common;
using System;
using System.Collections;
using System.Windows.Forms;
using Technosoftware.DaAeHdaClient.Ae;

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A dialog that displays the current status of an OPC server.
    /// </summary>
    public class GetEnabledStateDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Panel leftPn_;
		private System.Windows.Forms.ListView resultsLv_;
		private System.Windows.Forms.Button refreshBtn_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public GetEnabledStateDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			AddHeader(resultsLv_, "Name", false);
			AddHeader(resultsLv_, "Enabled", true);
			AddHeader(resultsLv_, "Effectively Enabled", true);
			AddHeader(resultsLv_, "Result", false);
			
			AdjustColumns(resultsLv_);

			resultsLv_.SmallImageList = Resources.Instance.ImageList;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.refreshBtn_ = new System.Windows.Forms.Button();
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.leftPn_ = new System.Windows.Forms.Panel();
			this.resultsLv_ = new System.Windows.Forms.ListView();
			this.buttonsPn_.SuspendLayout();
			this.leftPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.refreshBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 234);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(392, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// RefreshBTN
			// 
			this.refreshBtn_.Location = new System.Drawing.Point(4, 8);
			this.refreshBtn_.Name = "refreshBtn_";
			this.refreshBtn_.TabIndex = 1;
			this.refreshBtn_.Text = "Refresh";
			this.refreshBtn_.Click += new System.EventHandler(this.RefreshBTN_Click);
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(312, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Close";
			this.cancelBtn_.Click += new System.EventHandler(this.CancelBTN_Click);
			// 
			// LeftPN
			// 
			this.leftPn_.Controls.Add(this.resultsLv_);
			this.leftPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftPn_.DockPadding.Left = 4;
			this.leftPn_.DockPadding.Right = 4;
			this.leftPn_.DockPadding.Top = 4;
			this.leftPn_.Location = new System.Drawing.Point(0, 0);
			this.leftPn_.Name = "leftPn_";
			this.leftPn_.Size = new System.Drawing.Size(392, 234);
			this.leftPn_.TabIndex = 2;
			// 
			// ResultsLV
			// 
			this.resultsLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultsLv_.FullRowSelect = true;
			this.resultsLv_.Location = new System.Drawing.Point(4, 4);
			this.resultsLv_.Name = "resultsLv_";
			this.resultsLv_.Size = new System.Drawing.Size(384, 230);
			this.resultsLv_.TabIndex = 0;
			this.resultsLv_.View = System.Windows.Forms.View.Details;
			// 
			// GetEnabledStateDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(392, 270);
			this.Controls.Add(this.leftPn_);
			this.Controls.Add(this.buttonsPn_);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(0, 180);
			this.Name = "GetEnabledStateDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Enable States";
			this.buttonsPn_.ResumeLayout(false);
			this.leftPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		TsCAeServer mServer_ = null;
		ArrayList mAreas_ = new ArrayList();
		ArrayList mSources_ = new ArrayList();
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the enabled states for the specified browse elements.
		/// </summary>
		public void ShowDialog(TsCAeServer server, Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement[] elements)
		{
			if (server == null) throw new ArgumentNullException("server");

			mServer_ = server;

			// sort elements in areas and sources.
			mAreas_.Clear();
			mSources_.Clear();

			for (int ii = 0; ii < elements.Length; ii++)
			{
				if (elements[ii].NodeType == Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area)
				{
					if (!mAreas_.Contains(elements[ii].QualifiedName))
					{
						mAreas_.Add(elements[ii].QualifiedName);
					}
				}
				else
				{
					if (!mSources_.Contains(elements[ii].QualifiedName))
					{
						mSources_.Add(elements[ii].QualifiedName);
					}
				}
			}
			
			// get the current enabled state.
			GetEnabledState();

			// show the dialog.
			Show();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Fetches the enabled state for the areas and sources.
		/// </summary>
		private void GetEnabledState()
		{
			resultsLv_.Items.Clear();

			// get state for areas
			try
			{
				TsCAeEnabledStateResult[] results = mServer_.GetEnableStateByArea((string[])mAreas_.ToArray(typeof(string)));

				for (int ii = 0; ii < results.Length; ii++)
				{
					ListViewItem item = new ListViewItem((string)mAreas_[ii], Resources.IMAGE_CLOSED_BLUE_FOLDER);

					item.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(results[ii].Enabled));
					item.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(results[ii].EffectivelyEnabled));
					item.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(results[ii].Result));

					item.Tag = results[ii];

					resultsLv_.Items.Add(item);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "GetEnableStateByArea");
			}

			// get state for sources
			try
			{
				TsCAeEnabledStateResult[] results = mServer_.GetEnableStateBySource((string[])mSources_.ToArray(typeof(string)));

				for (int ii = 0; ii < results.Length; ii++)
				{
					ListViewItem item = new ListViewItem((string)mSources_[ii], Resources.IMAGE_GREEN_SCROLL);

					item.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(results[ii].Enabled));
					item.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(results[ii].EffectivelyEnabled));
					item.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(results[ii].Result));

					item.Tag = results[ii];

					resultsLv_.Items.Add(item);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "GetEnableStateBySource");
			}			

			// adjust columns.
			AdjustColumns(resultsLv_);
		}

		/// <summary>
		/// Populates the list box with the categories.
		/// </summary>
		private void AddHeader(ListView listview, string name, bool center)
		{
			ColumnHeader header = new ColumnHeader();
			header.Text = name;

			if (center)
			{
				header.TextAlign = HorizontalAlignment.Center;
			}

			listview.Columns.Add(header);
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns(ListView listview)
		{
			// adjust column widths.
			for (int ii = 0; ii < listview.Columns.Count; ii++)
			{
				listview.Columns[ii].Width = -2;
			}
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Closes the window.
		/// </summary>
		private void CancelBTN_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Re-reads the enabled states for the areas and sources.
		/// </summary>
		private void RefreshBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				GetEnabledState();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion

	}
}

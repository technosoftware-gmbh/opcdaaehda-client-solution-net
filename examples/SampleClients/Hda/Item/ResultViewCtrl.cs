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

using System.Collections;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Item
{
	/// <summary>
	/// Summary description for ReadParametersCtrl.
	/// </summary>
	public class ResultViewCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label endTimeLb_;
		private System.Windows.Forms.Label resultLb_;
		private System.Windows.Forms.Label startTimeLb_;
		private System.Windows.Forms.Label itemNameLb_;
		private System.Windows.Forms.ComboBox itemNameCb_;
		private System.Windows.Forms.TextBox startTimeTb_;
		private System.Windows.Forms.TextBox endTimeTb_;
		private System.Windows.Forms.TextBox resultTb_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public ResultViewCtrl()
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
			this.endTimeLb_ = new System.Windows.Forms.Label();
			this.resultLb_ = new System.Windows.Forms.Label();
			this.startTimeLb_ = new System.Windows.Forms.Label();
			this.itemNameLb_ = new System.Windows.Forms.Label();
			this.itemNameCb_ = new System.Windows.Forms.ComboBox();
			this.startTimeTb_ = new System.Windows.Forms.TextBox();
			this.endTimeTb_ = new System.Windows.Forms.TextBox();
			this.resultTb_ = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// EndTimeLB
			// 
			this.endTimeLb_.Location = new System.Drawing.Point(0, 48);
			this.endTimeLb_.Name = "endTimeLb_";
			this.endTimeLb_.Size = new System.Drawing.Size(64, 23);
			this.endTimeLb_.TabIndex = 0;
			this.endTimeLb_.Text = "End Time";
			this.endTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ResultLB
			// 
			this.resultLb_.Location = new System.Drawing.Point(0, 72);
			this.resultLb_.Name = "resultLb_";
			this.resultLb_.Size = new System.Drawing.Size(64, 23);
			this.resultLb_.TabIndex = 1;
			this.resultLb_.Text = "Result";
			this.resultLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StartTimeLB
			// 
			this.startTimeLb_.Location = new System.Drawing.Point(0, 24);
			this.startTimeLb_.Name = "startTimeLb_";
			this.startTimeLb_.Size = new System.Drawing.Size(64, 23);
			this.startTimeLb_.TabIndex = 11;
			this.startTimeLb_.Text = "Start Time";
			this.startTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameLB
			// 
			this.itemNameLb_.Location = new System.Drawing.Point(0, 0);
			this.itemNameLb_.Name = "itemNameLb_";
			this.itemNameLb_.Size = new System.Drawing.Size(64, 23);
			this.itemNameLb_.TabIndex = 10;
			this.itemNameLb_.Text = "Item Name";
			this.itemNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameCB
			// 
			this.itemNameCb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.itemNameCb_.Location = new System.Drawing.Point(64, 0);
			this.itemNameCb_.Name = "itemNameCb_";
			this.itemNameCb_.Size = new System.Drawing.Size(208, 21);
			this.itemNameCb_.TabIndex = 12;
			this.itemNameCb_.SelectedIndexChanged += new System.EventHandler(this.ItemNameCB_SelectedIndexChanged);
			// 
			// StartTimeTB
			// 
			this.startTimeTb_.Location = new System.Drawing.Point(64, 28);
			this.startTimeTb_.Name = "startTimeTb_";
			this.startTimeTb_.ReadOnly = true;
			this.startTimeTb_.Size = new System.Drawing.Size(112, 20);
			this.startTimeTb_.TabIndex = 13;
			this.startTimeTb_.Text = "2005-01-01 00:00:00";
			// 
			// EndTimeTB
			// 
			this.endTimeTb_.Location = new System.Drawing.Point(64, 52);
			this.endTimeTb_.Name = "endTimeTb_";
			this.endTimeTb_.ReadOnly = true;
			this.endTimeTb_.Size = new System.Drawing.Size(112, 20);
			this.endTimeTb_.TabIndex = 14;
			this.endTimeTb_.Text = "2005-01-01 00:00:00";
			// 
			// ResultTB
			// 
			this.resultTb_.Location = new System.Drawing.Point(64, 76);
			this.resultTb_.Name = "resultTb_";
			this.resultTb_.ReadOnly = true;
			this.resultTb_.Size = new System.Drawing.Size(156, 20);
			this.resultTb_.TabIndex = 15;
			this.resultTb_.Text = "S_OK";
			// 
			// ResultViewCtrl
			// 
			this.Controls.Add(this.resultTb_);
			this.Controls.Add(this.endTimeTb_);
			this.Controls.Add(this.startTimeTb_);
			this.Controls.Add(this.itemNameCb_);
			this.Controls.Add(this.startTimeLb_);
			this.Controls.Add(this.itemNameLb_);
			this.Controls.Add(this.resultLb_);
			this.Controls.Add(this.endTimeLb_);
			this.Name = "ResultViewCtrl";
			this.Size = new System.Drawing.Size(272, 96);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Used to receive events when a new result is selected in the control.
		/// </summary>
		public delegate void ResultSelectedEventHandler(OpcItem result);

		/// <summary>
		/// Fired when a new result is selected in the control.
		/// </summary>
		public event ResultSelectedEventHandler ResultSelected = null;

		/// <summary>
		/// Initializes the control with a set of results.
		/// </summary>
		public void Initialize(OpcItem[] results)
		{
			// initialize controls.
			itemNameCb_.Items.Clear();
			startTimeTb_.Text = null;
			endTimeTb_.Text   = null;
			resultTb_.Text    = null;

			if (results != null)
			{
				foreach (OpcItem result in results)
				{
					if (result.ItemName != null)
					{
						itemNameCb_.Items.Add(result.ItemName);
					}
					else
					{
						itemNameCb_.Items.Add("<unknown>");
					}
				}

				itemNameCb_.Tag = results;

				if (itemNameCb_.Items.Count > 0)
				{
					itemNameCb_.SelectedIndex = 0;
				}
			}
		}

		/// <summary>
		/// Appends additional values to the existing collections for the item.
		/// </summary>
		public TsCHdaItemValueCollection[] AppendValues(TsCHdaItemValueCollection[] results)
		{
			bool reinitialize = false;

			ArrayList updatedResults = new ArrayList();

			if (itemNameCb_.Tag == null)
			{
				updatedResults.AddRange(results);
				reinitialize = true;
			}
			else
			{
				foreach (TsCHdaItemValueCollection result in results)
				{
					bool exists = false;

					foreach (TsCHdaItemValueCollection existingResult in (ICollection)itemNameCb_.Tag)
					{
						if (existingResult.ClientHandle != null && existingResult.ClientHandle.Equals(result.ClientHandle))
						{
							existingResult.StartTime = result.StartTime;
							existingResult.EndTime   = result.EndTime;
							existingResult.Result  = result.Result;
							
							existingResult.AddRange(result);
							
							updatedResults.Add(existingResult);
							exists = true;
							break;
						}
					}

					if (!exists)
					{
						updatedResults.Add(result);
						reinitialize = true;
					}
				}
			}

			// must reinitialize the control if new items are in the new result list.
			if (reinitialize)
			{
				Initialize((OpcItem[])updatedResults.ToArray(typeof(TsCHdaItemValueCollection)));
			}

			// just update the existing results and force a selection changed event.
			else
			{
				itemNameCb_.Tag = (OpcItem[])updatedResults.ToArray(typeof(TsCHdaItemValueCollection));

				// update controls directly.
				if (itemNameCb_.SelectedIndex != -1)
				{
					OnResultSelected(itemNameCb_.SelectedIndex);
				}

				// update selected index which causes the controls to be updated.
				else if (itemNameCb_.Items.Count > 0)
				{
					itemNameCb_.SelectedIndex = 0;
				}
			}

			// return the merged results.
			return (TsCHdaItemValueCollection[])itemNameCb_.Tag;
		}
		#endregion

		#region Private Members
		/// <summary>
		/// Updates controls after a new item is selected.
		/// </summary>
		private void OnResultSelected(int index)
		{
			// verify selection.
			OpcItem[] results = (OpcItem[])itemNameCb_.Tag;

			if (index < 0 || index > results.Length)
			{
				return;
			}

			// initialize controls.
			OpcItem result = results[index];
			
			startTimeTb_.Text = null;
			endTimeTb_.Text   = null;
			resultTb_.Text    = null;

			// update times.
			if (typeof(ITsCHdaActualTime).IsInstanceOfType(result))
			{
				startTimeTb_.Text = ((ITsCHdaActualTime)result).StartTime.ToString("yyyy-MM-dd HH:mm:ss");
				endTimeTb_.Text   = ((ITsCHdaActualTime)result).EndTime.ToString("yyyy-MM-dd HH:mm:ss");
			}

			// update result.
			if (typeof(IOpcResult).IsInstanceOfType(result))
			{
				resultTb_.Text = ((IOpcResult)result).Result.Name.Name;
			}

			// fire event.
			if (ResultSelected != null)
			{
				ResultSelected(result);
			}
		}
		#endregion

		/// <summary>
		/// Updates the control when a new item is selected.
		/// </summary>
		private void ItemNameCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// verify selection.
			OpcItem[] results = (OpcItem[])itemNameCb_.Tag;

			if (itemNameCb_.SelectedIndex < 0 || itemNameCb_.SelectedIndex > results.Length)
			{
				return;
			}

			// initialize controls.
			OpcItem result = results[itemNameCb_.SelectedIndex];
			
			startTimeTb_.Text = null;
			endTimeTb_.Text   = null;
			resultTb_.Text    = null;

			// update times.
			if (typeof(ITsCHdaActualTime).IsInstanceOfType(result))
			{
				startTimeTb_.Text = ((ITsCHdaActualTime)result).StartTime.ToString("yyyy-MM-dd HH:mm:ss");
				endTimeTb_.Text   = ((ITsCHdaActualTime)result).EndTime.ToString("yyyy-MM-dd HH:mm:ss");
			}

			// update result.
			if (typeof(IOpcResult).IsInstanceOfType(result))
			{
				resultTb_.Text = ((IOpcResult)result).Result.Name.Name;
			}

			// fire event.
			if (ResultSelected != null)
			{
				ResultSelected(result);
			}
		}
	}
}

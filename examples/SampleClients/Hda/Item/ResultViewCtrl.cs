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
			endTimeLb_ = new System.Windows.Forms.Label();
			resultLb_ = new System.Windows.Forms.Label();
			startTimeLb_ = new System.Windows.Forms.Label();
			itemNameLb_ = new System.Windows.Forms.Label();
			itemNameCb_ = new System.Windows.Forms.ComboBox();
			startTimeTb_ = new System.Windows.Forms.TextBox();
			endTimeTb_ = new System.Windows.Forms.TextBox();
			resultTb_ = new System.Windows.Forms.TextBox();
			SuspendLayout();
			// 
			// EndTimeLB
			// 
			endTimeLb_.Location = new System.Drawing.Point(0, 48);
			endTimeLb_.Name = "endTimeLb_";
			endTimeLb_.Size = new System.Drawing.Size(64, 23);
			endTimeLb_.TabIndex = 0;
			endTimeLb_.Text = "End Time";
			endTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ResultLB
			// 
			resultLb_.Location = new System.Drawing.Point(0, 72);
			resultLb_.Name = "resultLb_";
			resultLb_.Size = new System.Drawing.Size(64, 23);
			resultLb_.TabIndex = 1;
			resultLb_.Text = "Result";
			resultLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StartTimeLB
			// 
			startTimeLb_.Location = new System.Drawing.Point(0, 24);
			startTimeLb_.Name = "startTimeLb_";
			startTimeLb_.Size = new System.Drawing.Size(64, 23);
			startTimeLb_.TabIndex = 11;
			startTimeLb_.Text = "Start Time";
			startTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameLB
			// 
			itemNameLb_.Location = new System.Drawing.Point(0, 0);
			itemNameLb_.Name = "itemNameLb_";
			itemNameLb_.Size = new System.Drawing.Size(64, 23);
			itemNameLb_.TabIndex = 10;
			itemNameLb_.Text = "Item Name";
			itemNameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameCB
			// 
			itemNameCb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			itemNameCb_.Location = new System.Drawing.Point(64, 0);
			itemNameCb_.Name = "itemNameCb_";
			itemNameCb_.Size = new System.Drawing.Size(208, 21);
			itemNameCb_.TabIndex = 12;
			itemNameCb_.SelectedIndexChanged += new System.EventHandler(ItemNameCB_SelectedIndexChanged);
			// 
			// StartTimeTB
			// 
			startTimeTb_.Location = new System.Drawing.Point(64, 28);
			startTimeTb_.Name = "startTimeTb_";
			startTimeTb_.ReadOnly = true;
			startTimeTb_.Size = new System.Drawing.Size(112, 20);
			startTimeTb_.TabIndex = 13;
			startTimeTb_.Text = "2005-01-01 00:00:00";
			// 
			// EndTimeTB
			// 
			endTimeTb_.Location = new System.Drawing.Point(64, 52);
			endTimeTb_.Name = "endTimeTb_";
			endTimeTb_.ReadOnly = true;
			endTimeTb_.Size = new System.Drawing.Size(112, 20);
			endTimeTb_.TabIndex = 14;
			endTimeTb_.Text = "2005-01-01 00:00:00";
			// 
			// ResultTB
			// 
			resultTb_.Location = new System.Drawing.Point(64, 76);
			resultTb_.Name = "resultTb_";
			resultTb_.ReadOnly = true;
			resultTb_.Size = new System.Drawing.Size(156, 20);
			resultTb_.TabIndex = 15;
			resultTb_.Text = "S_OK";
			// 
			// ResultViewCtrl
			// 
			Controls.Add(resultTb_);
			Controls.Add(endTimeTb_);
			Controls.Add(startTimeTb_);
			Controls.Add(itemNameCb_);
			Controls.Add(startTimeLb_);
			Controls.Add(itemNameLb_);
			Controls.Add(resultLb_);
			Controls.Add(endTimeLb_);
			Name = "ResultViewCtrl";
			Size = new System.Drawing.Size(272, 96);
			ResumeLayout(false);

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

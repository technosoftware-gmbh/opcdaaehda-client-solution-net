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
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using Technosoftware.DaAeHdaClient;
using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Cpx;
using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da
{
    /// <summary>
    /// Used to receive trace/debug output during data update processing.
    /// </summary>
    public delegate void UpdateEventEventHandler(object subscriptionHandle, object args);

	/// <summary>
	/// A control used to display a set of data updates from a server.
	/// </summary>
	public class UpdatesListViewCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView itemListLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem removeMi_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.ToolStripMenuItem copyMi_;
		private System.Windows.Forms.ToolStripMenuItem showErrorTextMi_;
		private System.Windows.Forms.ToolStripMenuItem viewMi_;
		private System.Windows.Forms.ToolStripMenuItem keepValuesMi_;
		private System.Windows.Forms.ToolStripMenuItem clearMi_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int Itemid    = 0;
		private const int ItemPath = 1;
		private const int Value     = 2;
		private const int Datatype  = 3;
		private const int Quality   = 4;
		private const int Timestamp = 5;
		private const int Error     = 6;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] columnNames_ = new string[]
		{
			"Item ID",
			"Item Path",
			"Value",
			"Data Type",
			"Quality",
			"Timestamp",
			"Result"
		};

		public UpdatesListViewCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			itemListLv_.SmallImageList = Resources.Instance.ImageList;
			
			SetColumns(columnNames_);
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
			itemListLv_ = new System.Windows.Forms.ListView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			viewMi_ = new System.Windows.Forms.ToolStripMenuItem();
			showErrorTextMi_ = new System.Windows.Forms.ToolStripMenuItem();
			copyMi_ = new System.Windows.Forms.ToolStripMenuItem();
			editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			removeMi_ = new System.Windows.Forms.ToolStripMenuItem();
			keepValuesMi_ = new System.Windows.Forms.ToolStripMenuItem();
			clearMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			SuspendLayout();
			// 
			// ItemListLV
			// 
			itemListLv_.ContextMenuStrip = popupMenu_;
			itemListLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			itemListLv_.FullRowSelect = true;
			itemListLv_.MultiSelect = false;
			itemListLv_.Name = "itemListLv_";
			itemListLv_.Size = new System.Drawing.Size(432, 272);
			itemListLv_.TabIndex = 0;
			itemListLv_.View = System.Windows.Forms.View.Details;
			itemListLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(ItemListLV_MouseDown);
			itemListLv_.DoubleClick += new System.EventHandler(ViewMI_Click);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  viewMi_,
																					  showErrorTextMi_,
																					  separator01_,
																					  keepValuesMi_,
																					  clearMi_});
			// 
			// ViewMI
			// 
			viewMi_.ImageIndex = 0;
			viewMi_.Text = "&View...";
			viewMi_.Click += new System.EventHandler(ViewMI_Click);
			// 
			// ShowErrorTextMI
			// 
			showErrorTextMi_.ImageIndex = 1;
			showErrorTextMi_.Text = "&Show Error Text";
			showErrorTextMi_.Click += new System.EventHandler(ShowErrorTextMI_Click);
			// 
			// CopyMI
			// 
			copyMi_.ImageIndex = -1;
			copyMi_.Text = "";
			// 
			// EditMI
			// 
			editMi_.ImageIndex = -1;
			editMi_.Text = "";
			// 
			// RemoveMI
			// 
			removeMi_.ImageIndex = -1;
			removeMi_.Text = "";
			// 
			// KeepValuesMI
			// 
			keepValuesMi_.ImageIndex = 3;
			keepValuesMi_.Text = "&Keep Old Values";
			keepValuesMi_.Click += new System.EventHandler(KeepValuesMI_Click);
			// 
			// ClearMI
			// 
			clearMi_.ImageIndex = 4;
			clearMi_.Text = "&Clear";
			clearMi_.Click += new System.EventHandler(ClearMI_Click);
			// 
			// Separator01
			// 
			separator01_.ImageIndex = 2;
			separator01_.Text = "-";
			// 
			// UpdatesListViewCtrl
			// 
			AllowDrop = true;
			Controls.AddRange(new System.Windows.Forms.Control[] {
																		  itemListLv_});
			Name = "UpdatesListViewCtrl";
			Size = new System.Drawing.Size(432, 272);
			ResumeLayout(false);

		}
		#endregion
	
		/// <summary>
		/// Used to receive trace/debug events generated by the control.
		/// </summary>
		public event UpdateEventEventHandler UpdateEvent = null;

		/// <summary>
		/// The currently active server object
		/// </summary>
		private TsCDaServer mServer_ = null;

		/// <summary>
		/// A table subscriptions indexed by handle.
		/// </summary>
		private Hashtable mSubscriptions_ = new Hashtable();

		/// <summary>
		/// A table of list items indexed by subscription.
		/// </summary>
		private Hashtable mItems_ = new Hashtable();

		/// <summary>
		/// A table of dialog displaying detailed views of an item.
		/// </summary>
		private Hashtable mViewers_ = new Hashtable();

		/// <summary>
		/// Sets/clears the currently active server. 
		/// </summary>
		public void Initialize(TsCDaServer server)
		{
			mServer_ = server;
			mItems_.Clear();
			mSubscriptions_.Clear();

			itemListLv_.Items.Clear();
		}
 
		/// <summary>
		/// Called when a subscription is added or removed from the control.
		/// </summary>
		public void OnSubscriptionModified(TsCDaSubscription subscription, bool deleted)
		{
			if (subscription == null) return;

			if (!deleted)
			{
				// check if the subscription is already added to the control.
				if (mItems_.Contains(subscription.ClientHandle)) return;

				// register for data updates.
				subscription.DataChangedEvent += new TsCDaDataChangedEventHandler(OnDataChangeEvent);

				// add to subscription list.
				mSubscriptions_.Add(subscription.ClientHandle, subscription);
				mItems_.Add(subscription.ClientHandle, new ArrayList());
			}
			else
			{
				// check if the subscription is already removed from the control.
				if (!mItems_.Contains(subscription.ClientHandle)) return;
				
				// unregister for data updates.
				subscription.DataChangedEvent -= new TsCDaDataChangedEventHandler(OnDataChangeEvent);
				
				// remove all items for the subscription.
				ArrayList existingItemList = (ArrayList)mItems_[subscription.ClientHandle];

				foreach (ListViewItem listItem in existingItemList)
				{
					EditComplexValueDlg dialog = (EditComplexValueDlg)mViewers_[listItem];

					if (dialog != null)
					{
						dialog.Close();
						mViewers_.Remove(listItem);
					}

					listItem.Remove();
				}

				// remove from subscription list.
				mSubscriptions_.Remove(subscription.ClientHandle);
				mItems_.Remove(subscription.ClientHandle);
			}
		}

		/// <summary>
		/// Called when a data update event is raised by a subscription.
		/// </summary>
		private void OnDataChangeEvent(object subscriptionHandle, object requestHandle, TsCDaItemValueResult[] values)
		{
			// ensure processing is done on the control's main thread.
			if (InvokeRequired)
			{
				BeginInvoke(new TsCDaDataChangedEventHandler(OnDataChangeEvent), new object[] { subscriptionHandle, requestHandle, values });
				return;
			}

			try
			{
				// find subscription.
				ArrayList existingItemList = (ArrayList)mItems_[subscriptionHandle];

				// check if subscription is still valid.
				if (existingItemList == null) return;

				// change all existing item values for the subscription to 'grey'.
				// this indicates an update arrived but the value did not change.
				foreach (ListViewItem listItem in existingItemList)
				{
					if (listItem.ForeColor != Color.Gray) {	listItem.ForeColor = Color.Gray; }
				}

				// do nothing more if only a keep alive callback.
				if (values == null || values.Length == 0) 
				{
					OnKeepAlive(subscriptionHandle);
					return;
				}
				else
				{
					if (UpdateEvent != null)
					{
						UpdateEvent(subscriptionHandle, values);
					}
				}

				// update list view.
				ArrayList newListItems = new ArrayList();

				foreach (TsCDaItemValueResult value in values)
				{
					// item value should never have a null client handle.
					if (value.ClientHandle == null)
					{
						continue;
					}

					// this item can be updated with new values instead of inserting/removing items.
					ListViewItem replacableItem = null;

					// remove existing items.
					if (!keepValuesMi_.Checked)
					{
						// search list of existing items for previous values for this item.
						ArrayList updatedItemList = new ArrayList(existingItemList.Count);

						foreach (ListViewItem listItem in existingItemList)
						{
							TsCDaItemValueResult previous = (TsCDaItemValueResult)listItem.Tag;

							if (!value.ClientHandle.Equals(previous.ClientHandle))
							{
								updatedItemList.Add(listItem);
								continue;
							}

							if (replacableItem != null) 
							{
								EditComplexValueDlg dialog = (EditComplexValueDlg)mViewers_[replacableItem];

								if (dialog != null)
								{
									dialog.Close();
									mViewers_.Remove(replacableItem);
								}

								replacableItem.Remove();
							}

							replacableItem = listItem;				
						}

						// the updated list has all values for the current item removed.
						existingItemList = updatedItemList;
					}

					// add value to list.
					AddValue(subscriptionHandle, value, ref replacableItem);

					// save new list item.
					if (replacableItem != null)	{ newListItems.Add(replacableItem); }
				}

				// add new items to existing item list.
				existingItemList.AddRange(newListItems);
				mItems_[subscriptionHandle] = existingItemList;

				// adjust column widths.
				for (int ii = 0; ii < itemListLv_.Columns.Count; ii++)
				{
					if (ii != Value && ii != Quality) itemListLv_.Columns[ii].Width = -2;
				}
			}
			catch (Exception e)
			{
				OnException(subscriptionHandle, e);
			}
		}	

		/// <summary>
		/// Posts a message when an exception occurs.
		/// </summary>
		private void OnException(object subscription, Exception e)
		{
			if (UpdateEvent != null)
			{
				UpdateEvent(subscription, e.Message);
			}
		}

		/// <summary>
		/// Posts a message when a keep alive callback arrives.
		/// </summary>
		private void OnKeepAlive(object subscription)
		{
			if (UpdateEvent != null)
			{
				string message = "";
				
				message += Technosoftware.DaAeHdaClient.OpcConvert.ToString(DateTime.Now);
				message += "\t";
				message += "Keep alive callback received.";

				UpdateEvent(subscription, message);
			}
		}

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			itemListLv_.Clear();

			for (int ii = 0; ii < columns.Length; ii++)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = columns[ii];
				header.Width = (ii != Value && ii != Quality)?-2:120;
				itemListLv_.Columns.Add(header);
			}
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddValue(object subscriptionHandle, TsCDaItemValueResult item, ref ListViewItem replaceableItem)
		{
			string quality = "";

			// format quality.
			if (item.QualitySpecified)
			{
				quality += item.Quality.QualityBits.ToString();

				if (item.Quality.LimitBits != TsDaLimitBits.None)
				{
					quality += ", ";
					quality += item.Quality.LimitBits.ToString();
				}

				if (item.Quality.VendorBits != 0)
				{
					quality += String.Format(", {0:X}", item.Quality.VendorBits);
				}
			}

			// format columns.
			string[] columns = new string[]
			{
				item.ItemName,
				item.ItemPath,
				Technosoftware.DaAeHdaClient.OpcConvert.ToString(item.Value),
				(item.Value != null)?Technosoftware.DaAeHdaClient.OpcConvert.ToString(item.Value.GetType()):"",
				quality,
				(item.TimestampSpecified)?Technosoftware.DaAeHdaClient.OpcConvert.ToString(item.Timestamp):"",
				GetErrorText(subscriptionHandle, item.Result)
			};

			// update an existing item.
			if (replaceableItem != null)
			{
				for (int ii = 0; ii < replaceableItem.SubItems.Count; ii++)
				{
					replaceableItem.SubItems[ii].Text = columns[ii];
				}

				replaceableItem.Tag = item;
				replaceableItem.ForeColor = Color.Empty;

				// update detail view dialog.
				EditComplexValueDlg dialog = (EditComplexValueDlg)mViewers_[replaceableItem];

				if (dialog != null)
				{					
					dialog.UpdateValue(item.Value);
				}

				return;
			}

			// create a new list view item.
			replaceableItem = new ListViewItem(columns, Resources.IMAGE_YELLOW_SCROLL);
			replaceableItem.Tag = item;

			// insert after any existing item value with the same client handle.
			for (int ii = itemListLv_.Items.Count-1; ii >= 0; ii--)
			{
				TsCDaItemValueResult previous = (TsCDaItemValueResult)itemListLv_.Items[ii].Tag;

				if (previous.ClientHandle != null && previous.ClientHandle.Equals(item.ClientHandle))
				{
					itemListLv_.Items.Insert(ii+1, replaceableItem);
					return;
				}
			}

			itemListLv_.Items.Add(replaceableItem);
		}

		/// <summary>
		/// Lookups the error text for the specified error id.
		/// </summary>
		private string GetErrorText(object subscriptionHandle, OpcResult resultId)
		{
			if (showErrorTextMi_.Checked)
			{
				// display nothing for ok results.
				if (resultId == OpcResult.S_OK) return "";
	
				// fetch the error text from the server.	
				string errorText = null;

				try 
				{
					TsCDaSubscription subscription = (TsCDaSubscription)mSubscriptions_[subscriptionHandle];
					string locale = (subscription != null)?subscription.Locale:CultureInfo.CurrentCulture.Name;
					errorText = mServer_.GetErrorText(locale, resultId);
				}
				catch
				{
					errorText = null;
				}

				// return the result;
				return (errorText != null)?errorText:"";
			}

			// return the result id as a string.
			return resultId.ToString();
		}

		/// <summary>
		/// Shows a detailed view for array values.
		/// </summary>
		private void ViewMI_Click(object sender, System.EventArgs e)
		{
			if (itemListLv_.SelectedItems.Count > 0)
			{
				ListViewItem listItem = itemListLv_.SelectedItems[0];

				object tag = listItem.Tag;

				if (tag != null && tag.GetType() == typeof(TsCDaItemValueResult))
				{
					TsCDaItemValueResult item = (TsCDaItemValueResult)tag;

					if (item.Value != null)
					{
						TsCCpxComplexItem complexItem = TsCCpxComplexTypeCache.GetComplexItem(item);

						if (complexItem != null)
						{
							EditComplexValueDlg dialog = (EditComplexValueDlg)mViewers_[listItem];

							if (dialog == null)
							{
								mViewers_[listItem] = dialog = new EditComplexValueDlg();
								dialog.Disposed += new EventHandler(OnViewerClosed);
							}

							dialog.ShowDialog(complexItem, item.Value, true, false);
						}

						else if (item.Value.GetType().IsArray)
						{
							new EditArrayDlg().ShowDialog(item.Value, true);
						}
					}
				}
			}
		}

		/// <summary>
		/// Removes a reference to the detail viewer dialog when it is closed.
		/// </summary>
		private void OnViewerClosed(object sender, System.EventArgs e)
		{
			IDictionaryEnumerator enumerator = mViewers_.GetEnumerator();

			while (enumerator.MoveNext())
			{
				if (enumerator.Value == sender)
				{
					mViewers_.Remove(enumerator.Key);
					break;
				}
			}
		}

		/// <summary>
		/// Enables/disables items in the popup menu before it is displayed.
		/// </summary>
		private void ItemListLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// disable everything.
			viewMi_.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = itemListLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked node.
			clickedItem.Selected = true;

			if (itemListLv_.SelectedItems.Count == 1)
			{
				if (clickedItem.Tag != null && clickedItem.Tag.GetType() == typeof(TsCDaItemValueResult))
				{
					TsCDaItemValueResult item = (TsCDaItemValueResult)clickedItem.Tag;

					if (item.Value != null)
					{
						viewMi_.Enabled = ((TsCCpxComplexTypeCache.GetComplexItem(item) != null) || (item.Value.GetType().IsArray));
					}
				}
			}
		}

		/// <summary>
		/// Toggles the state of the show error text flag.
		/// </summary>
		private void ShowErrorTextMI_Click(object sender, System.EventArgs e)
		{
			showErrorTextMi_.Checked = !showErrorTextMi_.Checked;
		}

		/// <summary>
		/// Indicates that old values should not be remove when new values are added.
		/// </summary>
		private void KeepValuesMI_Click(object sender, System.EventArgs e)
		{
			keepValuesMi_.Checked = !keepValuesMi_.Checked;
		}

		/// <summary>
		/// Clears the contents of the view.
		/// </summary>
		private void ClearMI_Click(object sender, System.EventArgs e)
		{
			// clear items.
			itemListLv_.Items.Clear();

			// clear subscription item list.
			foreach (ArrayList items in mItems_.Values)
			{
				items.Clear();
			}
		}	
	}
}

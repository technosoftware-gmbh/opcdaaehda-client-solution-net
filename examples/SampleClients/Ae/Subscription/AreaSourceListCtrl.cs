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

namespace Technosoftware.AeSampleClient
{
    /// <summary>
    /// A control used to edit the state of a subscription.
    /// </summary>
    public class AreaSourceListCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView areaSourceLv_;
		private System.Windows.Forms.ContextMenuStrip popupMenu_;
		private System.Windows.Forms.ToolStripMenuItem addAreaMi_;
		private System.Windows.Forms.ToolStripMenuItem addSourceMi_;
		private System.Windows.Forms.ToolStripMenuItem deleteMi_;
		private System.Windows.Forms.ToolStripMenuItem editMi_;
		private System.Windows.Forms.ToolStripMenuItem separator01_;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public AreaSourceListCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			areaSourceLv_.SmallImageList = Resources.Instance.ImageList;

			AddHeader(areaSourceLv_, "Qualified Name");
			AddHeader(areaSourceLv_, "Node Type");

			AdjustColumns(areaSourceLv_);
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
			areaSourceLv_ = new System.Windows.Forms.ListView();
			popupMenu_ = new System.Windows.Forms.ContextMenuStrip();
			addAreaMi_ = new System.Windows.Forms.ToolStripMenuItem();
			addSourceMi_ = new System.Windows.Forms.ToolStripMenuItem();
			separator01_ = new System.Windows.Forms.ToolStripMenuItem();
			editMi_ = new System.Windows.Forms.ToolStripMenuItem();
			deleteMi_ = new System.Windows.Forms.ToolStripMenuItem();
			SuspendLayout();
			// 
			// AreaSourceLV
			// 
			areaSourceLv_.Dock = System.Windows.Forms.DockStyle.Fill;
			areaSourceLv_.FullRowSelect = true;
			areaSourceLv_.Location = new System.Drawing.Point(0, 0);
			areaSourceLv_.MultiSelect = false;
			areaSourceLv_.Name = "areaSourceLv_";
			areaSourceLv_.Size = new System.Drawing.Size(376, 200);
			areaSourceLv_.TabIndex = 16;
			areaSourceLv_.View = System.Windows.Forms.View.Details;
			areaSourceLv_.MouseDown += new System.Windows.Forms.MouseEventHandler(AreaSourceLV_MouseDown);
			// 
			// PopupMenu
			// 
			popupMenu_.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  addAreaMi_,
																					  addSourceMi_,
																					  separator01_,
																					  editMi_,
																					  deleteMi_});
			// 
			// AddAreaMI
			// 
			addAreaMi_.ImageIndex = 0;
			addAreaMi_.Text = "Add Area,,,";
			addAreaMi_.Click += new System.EventHandler(AddAreaMI_Click);
			// 
			// AddSourceMI
			// 
			addSourceMi_.ImageIndex = 1;
			addSourceMi_.Text = "Add Source...";
			addSourceMi_.Click += new System.EventHandler(AddSourceMI_Click);
			// 
			// Separator01
			// 
			separator01_.ImageIndex = 2;
			separator01_.Text = "-";
			// 
			// EditMI
			// 
			editMi_.ImageIndex = 3;
			editMi_.Text = "Edit..";
			editMi_.Click += new System.EventHandler(EditMI_Click);
			// 
			// DeleteMI
			// 
			deleteMi_.ImageIndex = 4;
			deleteMi_.Text = "Delete";
			deleteMi_.Click += new System.EventHandler(DeleteMI_Click);
			// 
			// AreaSourceListCtrl
			// 
			ContextMenuStrip = popupMenu_;
			Controls.Add(areaSourceLv_);
			Name = "AreaSourceListCtrl";
			Size = new System.Drawing.Size(376, 200);
			ResumeLayout(false);

		}
		#endregion

		#region Private Members
		#endregion

		#region Public Interface
		/// <summary>
		/// Returns the qualified names for the areas in the control.
		/// </summary>
		public string[] GetAreas()
		{
			ArrayList areas = new ArrayList();

			foreach (ListViewItem item in areaSourceLv_.Items)
			{
				Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element = (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)item.Tag;

				if (element.NodeType == Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area)
				{
					areas.Add(element.QualifiedName);
				}
			}

			return (string[])areas.ToArray(typeof(string));
		}

		/// <summary>
		/// Returns the qualified names for the sources in the control.
		/// </summary>
		public string[] GetSources()
		{
			ArrayList sources = new ArrayList();

			foreach (ListViewItem item in areaSourceLv_.Items)
			{
				Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element = (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)item.Tag;

				if (element.NodeType == Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Source)
				{
					sources.Add(element.QualifiedName);
				}
			}

			return (string[])sources.ToArray(typeof(string));
		}
		
		/// <summary>
		/// Adds multiple areas to the list.
		/// </summary>
		public void AddAreas(string[] areas)
		{
			if (areas != null)
			{
				for (int ii = 0; ii < areas.Length; ii++)
				{
                    Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element = new Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement
                    {
                        QualifiedName = areas[ii],
                        NodeType = Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area
                    };

                    Add(element);
				}
				
				AdjustColumns(areaSourceLv_);
			}
		}		

		/// <summary>
		/// Adds multiple sources to the list.
		/// </summary>
		public void AddSources(string[] sources)
		{
			if (sources != null)
			{
				for (int ii = 0; ii < sources.Length; ii++)
				{
                    Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element = new Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement
                    {
                        QualifiedName = sources[ii],
                        NodeType = Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Source
                    };

                    Add(element);
				}

				AdjustColumns(areaSourceLv_);
			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Adds the area or source to the list.
		/// </summary>
		public void Add(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element)
		{
			ListViewItem item = new ListViewItem(element.QualifiedName);
			
			item.SubItems.Add(element.NodeType.ToString());

			item.ImageIndex = (element.NodeType == Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area)?Resources.IMAGE_CLOSED_BLUE_FOLDER:Resources.IMAGE_GREEN_SCROLL;
			item.Tag        = element;

			areaSourceLv_.Items.Add(item);
		}

		/// <summary>
		/// Populates the list box with the categories.
		/// </summary>
		private void AddHeader(ListView listview, string name)
		{
            ColumnHeader header = new ColumnHeader
            {
                Text = name
            };
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
		/// Enables items in popup menu based on current selection.
		/// </summary>
		private void AreaSourceLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// disable everything.
			addSourceMi_.Enabled = false;
			addAreaMi_.Enabled   = false;
			editMi_.Enabled      = false;
			deleteMi_.Enabled    = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = areaSourceLv_.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked node.
			clickedItem.Selected = true;

			// enable everything.
			addSourceMi_.Enabled = true;
			addAreaMi_.Enabled   = true;

			if (areaSourceLv_.SelectedItems.Count == 1)
			{
				editMi_.Enabled = true;
			}

			if (areaSourceLv_.SelectedItems.Count > 0)
			{
				deleteMi_.Enabled = true;
			}
		}

		/// <summary>
		/// Invokes the default action for the current selection.
		/// </summary>
		private void AreaSourceLV_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if (areaSourceLv_.SelectedItems.Count != 1)
				{
					return;
				}

				if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(areaSourceLv_.SelectedItems[0].Tag))
				{
					EditMI_Click(sender, e);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		
		/// <summary>
		/// Prompts the user to enter the qualified name for an area.
		/// </summary>
		private void AddAreaMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				string qualifiedName = new QualifiedNameEditDlg().ShowDialog(null);

				if (qualifiedName == null)
				{
					return;
				}

                Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element = new Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement
                {
                    QualifiedName = qualifiedName,
                    NodeType = Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Area
                };

                Add(element);
				AdjustColumns(areaSourceLv_);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Prompts the user to enter the qualified name for a source.
		/// </summary>
		private void AddSourceMI_Click(object sender, System.EventArgs e)
		{	
			try
			{
				string qualifiedName = new QualifiedNameEditDlg().ShowDialog(null);

				if (qualifiedName == null)
				{
					return;
				}

                Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element = new Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement
                {
                    QualifiedName = qualifiedName,
                    NodeType = Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseType.Source
                };

                Add(element);
				AdjustColumns(areaSourceLv_);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Edits the currently selected element in the list.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (areaSourceLv_.SelectedItems.Count != 1)
				{
					return;
				}

				if (typeof(Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement).IsInstanceOfType(areaSourceLv_.SelectedItems[0].Tag))
				{
					Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement element = (Technosoftware.DaAeHdaClient.Ae.TsCAeBrowseElement)areaSourceLv_.SelectedItems[0].Tag;

					string qualifiedName = new QualifiedNameEditDlg().ShowDialog(element.QualifiedName);

					if (qualifiedName == null)
					{
						return;
					}

					element.QualifiedName = qualifiedName;
					AdjustColumns(areaSourceLv_);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}		
		}

		/// <summary>
		/// Deletes the currently selected items from the list.
		/// </summary>
		private void DeleteMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				if (areaSourceLv_.SelectedItems.Count == 0)
				{
					return;
				}
				
				// collect the items.
				ListViewItem[] items = new ListViewItem[areaSourceLv_.SelectedItems.Count];

				for (int ii = 0; ii < areaSourceLv_.SelectedItems.Count; ii++)
				{
					items[ii] = areaSourceLv_.SelectedItems[ii];
				}

				// remove the items.
				for (int ii = 0; ii < items.Length; ii++)
				{
					items[ii].Remove();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion
	}
}

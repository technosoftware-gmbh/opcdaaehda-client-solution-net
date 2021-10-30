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
using System.Collections;
using System.Windows.Forms;

using SampleClients.Common;

using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Common
{
	/// <summary>
	/// A control used browse and select a single OPC server. 
	/// </summary>
	public class AttributeFilterEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel topPn_;
		private System.Windows.Forms.Panel mainPn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Label nameLb_;
		private System.Windows.Forms.ComboBox attributeCb_;
		private System.Windows.Forms.Label descriptionLb_;
		private SampleClients.Common.EnumCtrl operatorCtrl_;
		private SampleClients.Common.ValueCtrl filterValueCtrl_;
		private System.Windows.Forms.Label operatorLb_;
		private System.Windows.Forms.Label filterValueLb_;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components_ = null;

		public AttributeFilterEditDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();
			
			filterValueCtrl_.AllowChangeType = false;
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
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.okBtn_ = new System.Windows.Forms.Button();
			this.mainPn_ = new System.Windows.Forms.Panel();
			this.descriptionLb_ = new System.Windows.Forms.Label();
			this.nameLb_ = new System.Windows.Forms.Label();
			this.attributeCb_ = new System.Windows.Forms.ComboBox();
			this.topPn_ = new System.Windows.Forms.Panel();
			this.operatorCtrl_ = new SampleClients.Common.EnumCtrl();
			this.filterValueCtrl_ = new SampleClients.Common.ValueCtrl();
			this.operatorLb_ = new System.Windows.Forms.Label();
			this.filterValueLb_ = new System.Windows.Forms.Label();
			this.buttonsPn_.SuspendLayout();
			this.mainPn_.SuspendLayout();
			this.topPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 138);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(304, 36);
			this.buttonsPn_.TabIndex = 1;
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(224, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// OkBTN
			// 
			this.okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn_.Location = new System.Drawing.Point(4, 8);
			this.okBtn_.Name = "okBtn_";
			this.okBtn_.TabIndex = 1;
			this.okBtn_.Text = "OK";
			// 
			// MainPN
			// 
			this.mainPn_.Controls.Add(this.descriptionLb_);
			this.mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPn_.DockPadding.Left = 4;
			this.mainPn_.DockPadding.Right = 4;
			this.mainPn_.DockPadding.Top = 4;
			this.mainPn_.Location = new System.Drawing.Point(0, 76);
			this.mainPn_.Name = "mainPn_";
			this.mainPn_.Size = new System.Drawing.Size(304, 62);
			this.mainPn_.TabIndex = 5;
			// 
			// DescriptionLB
			// 
			this.descriptionLb_.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.descriptionLb_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.descriptionLb_.Location = new System.Drawing.Point(4, 4);
			this.descriptionLb_.Name = "descriptionLb_";
			this.descriptionLb_.Size = new System.Drawing.Size(296, 58);
			this.descriptionLb_.TabIndex = 2;
			this.descriptionLb_.Text = "Description";
			// 
			// NameLB
			// 
			this.nameLb_.Location = new System.Drawing.Point(4, 4);
			this.nameLb_.Name = "nameLb_";
			this.nameLb_.Size = new System.Drawing.Size(68, 23);
			this.nameLb_.TabIndex = 0;
			this.nameLb_.Text = "Attribute";
			this.nameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AttributeCB
			// 
			this.attributeCb_.Location = new System.Drawing.Point(72, 4);
			this.attributeCb_.Name = "attributeCb_";
			this.attributeCb_.Size = new System.Drawing.Size(228, 21);
			this.attributeCb_.TabIndex = 3;
			this.attributeCb_.SelectedIndexChanged += new System.EventHandler(this.AttributeCB_SelectedIndexChanged);
			// 
			// TopPN
			// 
			this.topPn_.Controls.Add(this.operatorCtrl_);
			this.topPn_.Controls.Add(this.filterValueCtrl_);
			this.topPn_.Controls.Add(this.operatorLb_);
			this.topPn_.Controls.Add(this.filterValueLb_);
			this.topPn_.Controls.Add(this.attributeCb_);
			this.topPn_.Controls.Add(this.nameLb_);
			this.topPn_.Dock = System.Windows.Forms.DockStyle.Top;
			this.topPn_.Location = new System.Drawing.Point(0, 0);
			this.topPn_.Name = "topPn_";
			this.topPn_.Size = new System.Drawing.Size(304, 76);
			this.topPn_.TabIndex = 6;
			// 
			// OperatorCTRL
			// 
			this.operatorCtrl_.Location = new System.Drawing.Point(72, 28);
			this.operatorCtrl_.Name = "operatorCtrl_";
			this.operatorCtrl_.Size = new System.Drawing.Size(144, 24);
			this.operatorCtrl_.TabIndex = 13;
			// 
			// FilterValueCTRL
			// 
			this.filterValueCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.filterValueCtrl_.ItemID = null;
			this.filterValueCtrl_.Location = new System.Drawing.Point(72, 52);
			this.filterValueCtrl_.Name = "filterValueCtrl_";
			this.filterValueCtrl_.Size = new System.Drawing.Size(228, 20);
			this.filterValueCtrl_.TabIndex = 12;
			// 
			// OperatorLB
			// 
			this.operatorLb_.Location = new System.Drawing.Point(4, 28);
			this.operatorLb_.Name = "operatorLb_";
			this.operatorLb_.Size = new System.Drawing.Size(68, 23);
			this.operatorLb_.TabIndex = 10;
			this.operatorLb_.Text = "Operator";
			this.operatorLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FilterValueLB
			// 
			this.filterValueLb_.Location = new System.Drawing.Point(4, 52);
			this.filterValueLb_.Name = "filterValueLb_";
			this.filterValueLb_.Size = new System.Drawing.Size(68, 23);
			this.filterValueLb_.TabIndex = 11;
			this.filterValueLb_.Text = "Filter Value";
			this.filterValueLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AttributeFilterEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn_;
			this.ClientSize = new System.Drawing.Size(304, 174);
			this.Controls.Add(this.mainPn_);
			this.Controls.Add(this.topPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "AttributeFilterEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Attribute Filter";
			this.buttonsPn_.ResumeLayout(false);
			this.mainPn_.ResumeLayout(false);
			this.topPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the user to edit an existing browse filter.
		/// </summary>
		public TsCHdaBrowseFilter ShowDialog(TsCHdaServer server, TsCHdaBrowseFilter filter)
		{
			// add valid attribute ids to the combo box.
			attributeCb_.Items.Clear();

			foreach (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute attribute in server.Attributes)
			{
				if (filter.AttributeID == attribute.ID)
				{				
					attributeCb_.Items.Add(attribute);
					attributeCb_.SelectedItem = attribute;
					break;
				}
			}

			operatorCtrl_.Value    = filter.Operator;
			filterValueCtrl_.Value = filter.FilterValue;

			// prompt user to edit filter.
			return PromptUser();
		}

		/// <summary>
		/// Prompts the user to create a new browse filter.
		/// </summary>
		public TsCHdaBrowseFilter ShowDialog(TsCHdaServer server, ArrayList excludeIDs)
		{
			// add valid attribute ids to the combo box.
			attributeCb_.Items.Clear();

			foreach (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute attribute in server.Attributes)
			{
				if (excludeIDs == null || !excludeIDs.Contains(attribute.ID))
				{				
					attributeCb_.Items.Add(attribute);
				}
			}

			// set default values.
			attributeCb_.SelectedItem = null;
			operatorCtrl_.Value       = TsCHdaOperator.Equal;
			filterValueCtrl_.Value    = "";

			// prompt user to create filter.
			return PromptUser();
		}

		/// <summary>
		/// Displays the dialog until the user enters valid data or clicks cancel.
		/// </summary>
		private TsCHdaBrowseFilter PromptUser()
		{
			while (ShowDialog() == DialogResult.OK)
			{
				try
				{
					Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute attribute = (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute)attributeCb_.SelectedItem;

					if (attribute == null)
					{
						continue;
					}

					TsCHdaBrowseFilter filter = new TsCHdaBrowseFilter();

					filter.AttributeID = attribute.ID;
					filter.Operator    = (TsCHdaOperator)operatorCtrl_.Value;
					filter.FilterValue = filterValueCtrl_.Value;

					return filter;
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message);
				}
			}

			return null;
		}

		/// <summary>
		/// Handles a change to the selected attribute.
		/// </summary>
		private void AttributeCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				// get current selection.
				Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute attribute = (Technosoftware.DaAeHdaClient.Hda.TsCHdaAttribute)attributeCb_.SelectedItem;

				if (attribute == null)
				{
					descriptionLb_.Text = "";
					return;
				}

				// convert filter value to correct data type.
				object value = filterValueCtrl_.Value;

				if (value == null || value.GetType() != attribute.DataType)
				{
					try
					{
						filterValueCtrl_.Value = Technosoftware.DaAeHdaClient.OpcConvert.ChangeType(value, attribute.DataType);
					}
					catch
					{
						filterValueCtrl_.Value = Technosoftware.DaAeHdaClient.OpcConvert.ChangeType(null, attribute.DataType);
					}
				}
			
				// update description.
				descriptionLb_.Text = attribute.Description;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}

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
			buttonsPn_ = new System.Windows.Forms.Panel();
			cancelBtn_ = new System.Windows.Forms.Button();
			okBtn_ = new System.Windows.Forms.Button();
			mainPn_ = new System.Windows.Forms.Panel();
			descriptionLb_ = new System.Windows.Forms.Label();
			nameLb_ = new System.Windows.Forms.Label();
			attributeCb_ = new System.Windows.Forms.ComboBox();
			topPn_ = new System.Windows.Forms.Panel();
			operatorCtrl_ = new SampleClients.Common.EnumCtrl();
			filterValueCtrl_ = new SampleClients.Common.ValueCtrl();
			operatorLb_ = new System.Windows.Forms.Label();
			filterValueLb_ = new System.Windows.Forms.Label();
			buttonsPn_.SuspendLayout();
			mainPn_.SuspendLayout();
			topPn_.SuspendLayout();
			SuspendLayout();
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 138);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(304, 36);
			buttonsPn_.TabIndex = 1;
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(224, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// OkBTN
			// 
			okBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			okBtn_.Location = new System.Drawing.Point(4, 8);
			okBtn_.Name = "okBtn_";
			okBtn_.TabIndex = 1;
			okBtn_.Text = "OK";
			// 
			// MainPN
			// 
			mainPn_.Controls.Add(descriptionLb_);
			mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			mainPn_.DockPadding.Left = 4;
			mainPn_.DockPadding.Right = 4;
			mainPn_.DockPadding.Top = 4;
			mainPn_.Location = new System.Drawing.Point(0, 76);
			mainPn_.Name = "mainPn_";
			mainPn_.Size = new System.Drawing.Size(304, 62);
			mainPn_.TabIndex = 5;
			// 
			// DescriptionLB
			// 
			descriptionLb_.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			descriptionLb_.Dock = System.Windows.Forms.DockStyle.Fill;
			descriptionLb_.Location = new System.Drawing.Point(4, 4);
			descriptionLb_.Name = "descriptionLb_";
			descriptionLb_.Size = new System.Drawing.Size(296, 58);
			descriptionLb_.TabIndex = 2;
			descriptionLb_.Text = "Description";
			// 
			// NameLB
			// 
			nameLb_.Location = new System.Drawing.Point(4, 4);
			nameLb_.Name = "nameLb_";
			nameLb_.Size = new System.Drawing.Size(68, 23);
			nameLb_.TabIndex = 0;
			nameLb_.Text = "Attribute";
			nameLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AttributeCB
			// 
			attributeCb_.Location = new System.Drawing.Point(72, 4);
			attributeCb_.Name = "attributeCb_";
			attributeCb_.Size = new System.Drawing.Size(228, 21);
			attributeCb_.TabIndex = 3;
			attributeCb_.SelectedIndexChanged += new System.EventHandler(AttributeCB_SelectedIndexChanged);
			// 
			// TopPN
			// 
			topPn_.Controls.Add(operatorCtrl_);
			topPn_.Controls.Add(filterValueCtrl_);
			topPn_.Controls.Add(operatorLb_);
			topPn_.Controls.Add(filterValueLb_);
			topPn_.Controls.Add(attributeCb_);
			topPn_.Controls.Add(nameLb_);
			topPn_.Dock = System.Windows.Forms.DockStyle.Top;
			topPn_.Location = new System.Drawing.Point(0, 0);
			topPn_.Name = "topPn_";
			topPn_.Size = new System.Drawing.Size(304, 76);
			topPn_.TabIndex = 6;
			// 
			// OperatorCTRL
			// 
			operatorCtrl_.Location = new System.Drawing.Point(72, 28);
			operatorCtrl_.Name = "operatorCtrl_";
			operatorCtrl_.Size = new System.Drawing.Size(144, 24);
			operatorCtrl_.TabIndex = 13;
			// 
			// FilterValueCTRL
			// 
			filterValueCtrl_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			filterValueCtrl_.ItemID = null;
			filterValueCtrl_.Location = new System.Drawing.Point(72, 52);
			filterValueCtrl_.Name = "filterValueCtrl_";
			filterValueCtrl_.Size = new System.Drawing.Size(228, 20);
			filterValueCtrl_.TabIndex = 12;
			// 
			// OperatorLB
			// 
			operatorLb_.Location = new System.Drawing.Point(4, 28);
			operatorLb_.Name = "operatorLb_";
			operatorLb_.Size = new System.Drawing.Size(68, 23);
			operatorLb_.TabIndex = 10;
			operatorLb_.Text = "Operator";
			operatorLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FilterValueLB
			// 
			filterValueLb_.Location = new System.Drawing.Point(4, 52);
			filterValueLb_.Name = "filterValueLb_";
			filterValueLb_.Size = new System.Drawing.Size(68, 23);
			filterValueLb_.TabIndex = 11;
			filterValueLb_.Text = "Filter Value";
			filterValueLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AttributeFilterEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = cancelBtn_;
			ClientSize = new System.Drawing.Size(304, 174);
			Controls.Add(mainPn_);
			Controls.Add(topPn_);
			Controls.Add(buttonsPn_);
			Name = "AttributeFilterEditDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Set Attribute Filter";
			buttonsPn_.ResumeLayout(false);
			mainPn_.ResumeLayout(false);
			topPn_.ResumeLayout(false);
			ResumeLayout(false);

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

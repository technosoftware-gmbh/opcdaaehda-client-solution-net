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

using Technosoftware.DaAeHdaClient.Hda;

#endregion

namespace SampleClients.Hda.Common
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class AnnotationValueEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cancelBtn_;
		private System.Windows.Forms.Panel buttonsPn_;
		private System.Windows.Forms.Button okBtn_;
		private System.Windows.Forms.Panel mainPn_;
		private System.Windows.Forms.Label valueLb_;
		private System.Windows.Forms.Label timestampLb_;
		private System.Windows.Forms.DateTimePicker timestampCtrl_;
		private System.Windows.Forms.Label userLb_;
		private System.Windows.Forms.Label creationTimeLb_;
		private System.Windows.Forms.DateTimePicker creationTimeCtrl_;
		private System.Windows.Forms.TextBox userTb_;
		private System.Windows.Forms.TextBox annotationTb_;
		private System.ComponentModel.IContainer components = null;

		public AnnotationValueEditDlg()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();
        }
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
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
			this.cancelBtn_ = new System.Windows.Forms.Button();
			this.buttonsPn_ = new System.Windows.Forms.Panel();
			this.okBtn_ = new System.Windows.Forms.Button();
			this.mainPn_ = new System.Windows.Forms.Panel();
			this.timestampCtrl_ = new System.Windows.Forms.DateTimePicker();
			this.timestampLb_ = new System.Windows.Forms.Label();
			this.userLb_ = new System.Windows.Forms.Label();
			this.creationTimeLb_ = new System.Windows.Forms.Label();
			this.valueLb_ = new System.Windows.Forms.Label();
			this.creationTimeCtrl_ = new System.Windows.Forms.DateTimePicker();
			this.userTb_ = new System.Windows.Forms.TextBox();
			this.annotationTb_ = new System.Windows.Forms.TextBox();
			this.buttonsPn_.SuspendLayout();
			this.mainPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBTN
			// 
			this.cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn_.Location = new System.Drawing.Point(288, 8);
			this.cancelBtn_.Name = "cancelBtn_";
			this.cancelBtn_.TabIndex = 0;
			this.cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.buttonsPn_.Controls.Add(this.okBtn_);
			this.buttonsPn_.Controls.Add(this.cancelBtn_);
			this.buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonsPn_.Location = new System.Drawing.Point(0, 98);
			this.buttonsPn_.Name = "buttonsPn_";
			this.buttonsPn_.Size = new System.Drawing.Size(368, 36);
			this.buttonsPn_.TabIndex = 0;
			// 
			// OkBTN
			// 
			this.okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn_.Location = new System.Drawing.Point(4, 8);
			this.okBtn_.Name = "okBtn_";
			this.okBtn_.TabIndex = 1;
			this.okBtn_.Text = "OK";
			// 
			// MainPN
			// 
			this.mainPn_.Controls.Add(this.annotationTb_);
			this.mainPn_.Controls.Add(this.userTb_);
			this.mainPn_.Controls.Add(this.creationTimeCtrl_);
			this.mainPn_.Controls.Add(this.timestampCtrl_);
			this.mainPn_.Controls.Add(this.timestampLb_);
			this.mainPn_.Controls.Add(this.userLb_);
			this.mainPn_.Controls.Add(this.creationTimeLb_);
			this.mainPn_.Controls.Add(this.valueLb_);
			this.mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPn_.DockPadding.Left = 4;
			this.mainPn_.DockPadding.Right = 4;
			this.mainPn_.DockPadding.Top = 4;
			this.mainPn_.Location = new System.Drawing.Point(0, 0);
			this.mainPn_.Name = "mainPn_";
			this.mainPn_.Size = new System.Drawing.Size(368, 98);
			this.mainPn_.TabIndex = 1;
			// 
			// TimestampCTRL
			// 
			this.timestampCtrl_.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.timestampCtrl_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.timestampCtrl_.Location = new System.Drawing.Point(80, 28);
			this.timestampCtrl_.Name = "timestampCtrl_";
			this.timestampCtrl_.Size = new System.Drawing.Size(132, 20);
			this.timestampCtrl_.TabIndex = 4;
			// 
			// TimestampLB
			// 
			this.timestampLb_.Location = new System.Drawing.Point(4, 28);
			this.timestampLb_.Name = "timestampLb_";
			this.timestampLb_.Size = new System.Drawing.Size(76, 23);
			this.timestampLb_.TabIndex = 3;
			this.timestampLb_.Text = "Timestamp";
			this.timestampLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UserLB
			// 
			this.userLb_.Location = new System.Drawing.Point(4, 76);
			this.userLb_.Name = "userLb_";
			this.userLb_.Size = new System.Drawing.Size(76, 23);
			this.userLb_.TabIndex = 7;
			this.userLb_.Text = "User";
			this.userLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CreationTimeLB
			// 
			this.creationTimeLb_.Location = new System.Drawing.Point(4, 52);
			this.creationTimeLb_.Name = "creationTimeLb_";
			this.creationTimeLb_.Size = new System.Drawing.Size(76, 23);
			this.creationTimeLb_.TabIndex = 5;
			this.creationTimeLb_.Text = "Creation Time";
			this.creationTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueLB
			// 
			this.valueLb_.Location = new System.Drawing.Point(4, 4);
			this.valueLb_.Name = "valueLb_";
			this.valueLb_.Size = new System.Drawing.Size(76, 23);
			this.valueLb_.TabIndex = 0;
			this.valueLb_.Text = "Annotation";
			this.valueLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CreationTimeCTRL
			// 
			this.creationTimeCtrl_.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.creationTimeCtrl_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.creationTimeCtrl_.Location = new System.Drawing.Point(80, 52);
			this.creationTimeCtrl_.Name = "creationTimeCtrl_";
			this.creationTimeCtrl_.Size = new System.Drawing.Size(132, 20);
			this.creationTimeCtrl_.TabIndex = 9;
			// 
			// UserTB
			// 
			this.userTb_.Location = new System.Drawing.Point(80, 76);
			this.userTb_.Name = "userTb_";
			this.userTb_.Size = new System.Drawing.Size(132, 20);
			this.userTb_.TabIndex = 10;
			this.userTb_.Text = "";
			// 
			// AnnotationTB
			// 
			this.annotationTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.annotationTb_.Location = new System.Drawing.Point(80, 4);
			this.annotationTb_.Name = "annotationTb_";
			this.annotationTb_.Size = new System.Drawing.Size(284, 20);
			this.annotationTb_.TabIndex = 11;
			this.annotationTb_.Text = "";
			// 
			// AnnotationValueEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 134);
			this.Controls.Add(this.mainPn_);
			this.Controls.Add(this.buttonsPn_);
			this.Name = "AnnotationValueEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Annotation";
			this.buttonsPn_.ResumeLayout(false);
			this.mainPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to edit an item value.
		/// </summary>
		public TsCHdaAnnotationValue ShowDialog(TsCHdaAnnotationValue item)
		{
			// create a new item if none provided.
			if (item == null) 
			{				
				item = new TsCHdaAnnotationValue();
			}

			// initialize controls.
			annotationTb_.Text      = item.Annotation;
			timestampCtrl_.Value    = DateTime.Now;
			creationTimeCtrl_.Value = DateTime.Now;
			userTb_.Text            = item.User;
			
			if (timestampCtrl_.MinDate < item.Timestamp)
			{
				timestampCtrl_.Value = item.Timestamp;
			}

			if (creationTimeCtrl_.MinDate < item.CreationTime)
			{
				creationTimeCtrl_.Value = item.CreationTime;
			}

			// display dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// update object.
			item.Annotation   = annotationTb_.Text;
			item.Timestamp    = timestampCtrl_.Value;
			item.CreationTime = creationTimeCtrl_.Value;
			item.User         = userTb_.Text;

			// return new value.
			return item;
		}
		#endregion
	}
}

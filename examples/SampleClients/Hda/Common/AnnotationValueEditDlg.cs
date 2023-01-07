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
			cancelBtn_ = new System.Windows.Forms.Button();
			buttonsPn_ = new System.Windows.Forms.Panel();
			okBtn_ = new System.Windows.Forms.Button();
			mainPn_ = new System.Windows.Forms.Panel();
			timestampCtrl_ = new System.Windows.Forms.DateTimePicker();
			timestampLb_ = new System.Windows.Forms.Label();
			userLb_ = new System.Windows.Forms.Label();
			creationTimeLb_ = new System.Windows.Forms.Label();
			valueLb_ = new System.Windows.Forms.Label();
			creationTimeCtrl_ = new System.Windows.Forms.DateTimePicker();
			userTb_ = new System.Windows.Forms.TextBox();
			annotationTb_ = new System.Windows.Forms.TextBox();
			buttonsPn_.SuspendLayout();
			mainPn_.SuspendLayout();
			SuspendLayout();
			// 
			// CancelBTN
			// 
			cancelBtn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			cancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelBtn_.Location = new System.Drawing.Point(288, 8);
			cancelBtn_.Name = "cancelBtn_";
			cancelBtn_.TabIndex = 0;
			cancelBtn_.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			buttonsPn_.Controls.Add(okBtn_);
			buttonsPn_.Controls.Add(cancelBtn_);
			buttonsPn_.Dock = System.Windows.Forms.DockStyle.Bottom;
			buttonsPn_.Location = new System.Drawing.Point(0, 98);
			buttonsPn_.Name = "buttonsPn_";
			buttonsPn_.Size = new System.Drawing.Size(368, 36);
			buttonsPn_.TabIndex = 0;
			// 
			// OkBTN
			// 
			okBtn_.DialogResult = System.Windows.Forms.DialogResult.OK;
			okBtn_.Location = new System.Drawing.Point(4, 8);
			okBtn_.Name = "okBtn_";
			okBtn_.TabIndex = 1;
			okBtn_.Text = "OK";
			// 
			// MainPN
			// 
			mainPn_.Controls.Add(annotationTb_);
			mainPn_.Controls.Add(userTb_);
			mainPn_.Controls.Add(creationTimeCtrl_);
			mainPn_.Controls.Add(timestampCtrl_);
			mainPn_.Controls.Add(timestampLb_);
			mainPn_.Controls.Add(userLb_);
			mainPn_.Controls.Add(creationTimeLb_);
			mainPn_.Controls.Add(valueLb_);
			mainPn_.Dock = System.Windows.Forms.DockStyle.Fill;
			mainPn_.DockPadding.Left = 4;
			mainPn_.DockPadding.Right = 4;
			mainPn_.DockPadding.Top = 4;
			mainPn_.Location = new System.Drawing.Point(0, 0);
			mainPn_.Name = "mainPn_";
			mainPn_.Size = new System.Drawing.Size(368, 98);
			mainPn_.TabIndex = 1;
			// 
			// TimestampCTRL
			// 
			timestampCtrl_.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			timestampCtrl_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			timestampCtrl_.Location = new System.Drawing.Point(80, 28);
			timestampCtrl_.Name = "timestampCtrl_";
			timestampCtrl_.Size = new System.Drawing.Size(132, 20);
			timestampCtrl_.TabIndex = 4;
			// 
			// TimestampLB
			// 
			timestampLb_.Location = new System.Drawing.Point(4, 28);
			timestampLb_.Name = "timestampLb_";
			timestampLb_.Size = new System.Drawing.Size(76, 23);
			timestampLb_.TabIndex = 3;
			timestampLb_.Text = "Timestamp";
			timestampLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UserLB
			// 
			userLb_.Location = new System.Drawing.Point(4, 76);
			userLb_.Name = "userLb_";
			userLb_.Size = new System.Drawing.Size(76, 23);
			userLb_.TabIndex = 7;
			userLb_.Text = "User";
			userLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CreationTimeLB
			// 
			creationTimeLb_.Location = new System.Drawing.Point(4, 52);
			creationTimeLb_.Name = "creationTimeLb_";
			creationTimeLb_.Size = new System.Drawing.Size(76, 23);
			creationTimeLb_.TabIndex = 5;
			creationTimeLb_.Text = "Creation Time";
			creationTimeLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueLB
			// 
			valueLb_.Location = new System.Drawing.Point(4, 4);
			valueLb_.Name = "valueLb_";
			valueLb_.Size = new System.Drawing.Size(76, 23);
			valueLb_.TabIndex = 0;
			valueLb_.Text = "Annotation";
			valueLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CreationTimeCTRL
			// 
			creationTimeCtrl_.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			creationTimeCtrl_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			creationTimeCtrl_.Location = new System.Drawing.Point(80, 52);
			creationTimeCtrl_.Name = "creationTimeCtrl_";
			creationTimeCtrl_.Size = new System.Drawing.Size(132, 20);
			creationTimeCtrl_.TabIndex = 9;
			// 
			// UserTB
			// 
			userTb_.Location = new System.Drawing.Point(80, 76);
			userTb_.Name = "userTb_";
			userTb_.Size = new System.Drawing.Size(132, 20);
			userTb_.TabIndex = 10;
			userTb_.Text = "";
			// 
			// AnnotationTB
			// 
			annotationTb_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			annotationTb_.Location = new System.Drawing.Point(80, 4);
			annotationTb_.Name = "annotationTb_";
			annotationTb_.Size = new System.Drawing.Size(284, 20);
			annotationTb_.TabIndex = 11;
			annotationTb_.Text = "";
			// 
			// AnnotationValueEditDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(368, 134);
			Controls.Add(mainPn_);
			Controls.Add(buttonsPn_);
			Name = "AnnotationValueEditDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Edit Annotation";
			buttonsPn_.ResumeLayout(false);
			mainPn_.ResumeLayout(false);
			ResumeLayout(false);

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

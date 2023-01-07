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
#endregion

namespace SampleClients.Common
{
    partial class ClientUtils
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientUtils));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);

            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.White;
            this.ImageList.Images.SetKeyName(0, "Attribute");
            this.ImageList.Images.SetKeyName(1, "Property");
            this.ImageList.Images.SetKeyName(2, "Variable");
            this.ImageList.Images.SetKeyName(3, "Method");
            this.ImageList.Images.SetKeyName(4, "Object");
            this.ImageList.Images.SetKeyName(5, "OpenFolder");
            this.ImageList.Images.SetKeyName(6, "ClosedFolder");
            this.ImageList.Images.SetKeyName(7, "ObjectType");
            this.ImageList.Images.SetKeyName(8, "View");
            this.ImageList.Images.SetKeyName(9, "Reference");
            this.ImageList.Images.SetKeyName(10, "Number");
            this.ImageList.Images.SetKeyName(11, "String");
            this.ImageList.Images.SetKeyName(12, "ByteString");
            this.ImageList.Images.SetKeyName(13, "Structure");
            this.ImageList.Images.SetKeyName(14, "Array");
            this.ImageList.Images.SetKeyName(15, "InputArgument");
            this.ImageList.Images.SetKeyName(16, "OutputArgument");
            this.ImageList.Images.SetKeyName(17, "TBD");
            // 
            // ClientUtils
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ClientUtils";
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// A list of shared images for controls.
        /// </summary>
        public System.Windows.Forms.ImageList ImageList;
    }
}

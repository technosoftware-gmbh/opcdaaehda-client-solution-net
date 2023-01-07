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
    /// <summary>
    /// A class that defines resource constants such as image indexes.
    /// </summary>
    public class Resources : System.Windows.Forms.Form
	{
		public System.Windows.Forms.ImageList ToolBarImageList;
		public System.Windows.Forms.ImageList ImageList;

		private System.ComponentModel.IContainer components_;

		public Resources()
		{
			//
			// Required for Windows Form Designer support
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components_ = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Resources));
			ImageList = new System.Windows.Forms.ImageList(components_);
			ToolBarImageList = new System.Windows.Forms.ImageList(components_);
			// 
			// ImageList
			// 
			ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			ImageList.ImageSize = new System.Drawing.Size(16, 16);
			ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
			ImageList.TransparentColor = System.Drawing.Color.Teal;
			// 
			// ToolBarImageList
			// 
			ToolBarImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			ToolBarImageList.ImageSize = new System.Drawing.Size(16, 18);
			ToolBarImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ToolBarImageList.ImageStream")));
			ToolBarImageList.TransparentColor = System.Drawing.Color.Teal;
			// 
			// Resources
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(292, 273);
			Name = "Resources";
			Text = "Resources";

		}
		#endregion

		// global constants
		public static readonly int IMAGE_CLOSED_YELLOW_FOLDER  = 0;
		public static readonly int IMAGE_OPEN_YELLOW_FOLDER    = 1;
		public static readonly int IMAGE_GREEN_SCROLL          = 2;
		public static readonly int IMAGE_EXPLODING_BOX         = 3;
		public static readonly int IMAGE_CLOSED_BLUE_FOLDER    = 4;
		public static readonly int IMAGE_OPEN_BLUE_FOLDER      = 5;
		public static readonly int IMAGE_ENVELOPE              = 6;
		public static readonly int IMAGE_HIGHLIGHTED_ENVELOPE  = 7;
		public static readonly int IMAGE_LIST_BOX              = 8;
		public static readonly int IMAGE_YELLOW_SCROLL         = 9;
		public static readonly int IMAGE_LOCAL_COMPUTER        = 10;
		public static readonly int IMAGE_LOCAL_NETWORK         = 11;
		public static readonly int IMAGE_LOCAL_SERVER          = 12;

		public static Resources Instance = new Resources();
	}
}

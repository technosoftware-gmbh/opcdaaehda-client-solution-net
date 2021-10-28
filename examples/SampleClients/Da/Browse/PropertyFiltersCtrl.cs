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

using Technosoftware.DaAeHdaClient.Da;

#endregion

namespace SampleClients.Da.Browse
{
    /// <summary>
    /// A control used to specify property filters used when browsing.
    /// </summary>
    public class PropertyFiltersCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.CheckedListBox propertyNamesLb_;
		private System.Windows.Forms.CheckBox returnAllPropertiesCb_;
		private System.Windows.Forms.CheckBox returnPropertyValuesCb_;
		private System.Windows.Forms.Label returnAllPropertiesLb_;
		private System.Windows.Forms.Label returnPropertyValuesLb_;
		private System.Windows.Forms.Panel topPn_;
		private System.ComponentModel.IContainer components = null;
		
		public PropertyFiltersCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// popuplated the property names list
			TsDaPropertyDescription[] properties = TsDaPropertyDescription.Enumerate();

			foreach (TsDaPropertyDescription property in properties)
			{
				propertyNamesLb_.Items.Add(property);
			}
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.returnAllPropertiesCb_ = new System.Windows.Forms.CheckBox();
			this.returnPropertyValuesCb_ = new System.Windows.Forms.CheckBox();
			this.propertyNamesLb_ = new System.Windows.Forms.CheckedListBox();
			this.returnAllPropertiesLb_ = new System.Windows.Forms.Label();
			this.returnPropertyValuesLb_ = new System.Windows.Forms.Label();
			this.topPn_ = new System.Windows.Forms.Panel();
			this.topPn_.SuspendLayout();
			this.SuspendLayout();
			// 
			// ReturnAllPropertiesCB
			// 
			this.returnAllPropertiesCb_.Location = new System.Drawing.Point(112, 0);
			this.returnAllPropertiesCb_.Name = "returnAllPropertiesCb_";
			this.returnAllPropertiesCb_.Size = new System.Drawing.Size(16, 24);
			this.returnAllPropertiesCb_.TabIndex = 1;
			this.returnAllPropertiesCb_.CheckedChanged += new System.EventHandler(this.ReturnAllPropertiesCB_CheckedChanged);
			// 
			// ReturnPropertyValuesCB
			// 
            this.returnPropertyValuesCb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.returnPropertyValuesCb_.Location = new System.Drawing.Point(352, 0);
			this.returnPropertyValuesCb_.Name = "returnPropertyValuesCb_";
			this.returnPropertyValuesCb_.Size = new System.Drawing.Size(16, 24);
			this.returnPropertyValuesCb_.TabIndex = 3;
			// 
			// PropertyNamesLB
			// 
			this.propertyNamesLb_.CheckOnClick = true;
			this.propertyNamesLb_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyNamesLb_.Location = new System.Drawing.Point(0, 24);
			this.propertyNamesLb_.Name = "propertyNamesLb_";
            this.propertyNamesLb_.Size = new System.Drawing.Size(368, 160);
			this.propertyNamesLb_.TabIndex = 0;
			// 
			// ReturnAllPropertiesLB
			// 
            this.returnAllPropertiesLb_.Location = new System.Drawing.Point(0, 0);
			this.returnAllPropertiesLb_.Name = "returnAllPropertiesLb_";
			this.returnAllPropertiesLb_.Size = new System.Drawing.Size(112, 23);
			this.returnAllPropertiesLb_.TabIndex = 0;
			this.returnAllPropertiesLb_.Text = "Return All Properties";
			this.returnAllPropertiesLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReturnPropertyValuesLB
			// 
            this.returnPropertyValuesLb_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.returnPropertyValuesLb_.Location = new System.Drawing.Point(224, 0);
			this.returnPropertyValuesLb_.Name = "returnPropertyValuesLb_";
			this.returnPropertyValuesLb_.Size = new System.Drawing.Size(128, 23);
			this.returnPropertyValuesLb_.TabIndex = 2;
			this.returnPropertyValuesLb_.Text = "Return Property Values";
			this.returnPropertyValuesLb_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
            this.topPn_.Controls.Add(this.returnAllPropertiesLb_);
            this.topPn_.Controls.Add(this.returnAllPropertiesCb_);
            this.topPn_.Controls.Add(this.returnPropertyValuesLb_);
            this.topPn_.Controls.Add(this.returnPropertyValuesCb_);
			this.topPn_.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPn_.Location = new System.Drawing.Point(0, 0);
			this.topPn_.Name = "topPn_";
			this.topPn_.Size = new System.Drawing.Size(368, 24);
			this.topPn_.TabIndex = 29;
			// 
			// PropertyFiltersCtrl
			// 
            this.Controls.Add(this.propertyNamesLb_);
            this.Controls.Add(this.topPn_);
			this.Name = "PropertyFiltersCtrl";
			this.Size = new System.Drawing.Size(368, 184);
			this.topPn_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// Whether all properties for an item should be returned.
		/// </summary>
		public bool ReturnAllProperties
		{
			get { return returnAllPropertiesCb_.Checked; }
			set { returnAllPropertiesCb_.Checked = value; }
		}

		/// <summary>
		/// Whether property values should be returned with the descriptions.
		/// </summary>
		public bool ReturnPropertyValues
		{
			get { return returnPropertyValuesCb_.Checked; }
			set { returnPropertyValuesCb_.Checked = value; }
		}
		
		/// <summary>
		/// The set of selected property ids.
		/// </summary>
		public TsDaPropertyID[] PropertyIDs
		{
			get 
			{ 
				ArrayList propertyIDs = new ArrayList();

				foreach (TsDaPropertyDescription property in propertyNamesLb_.CheckedItems)
				{
					propertyIDs.Add(property.ID);
				}

				return (TsDaPropertyID[])propertyIDs.ToArray(typeof(TsDaPropertyID)); 
			}

			set 
			{ 
				for (int ii = 0; ii < propertyNamesLb_.Items.Count; ii++)
				{
					propertyNamesLb_.SetItemChecked(ii, false);

					if (value != null)
					{
						TsDaPropertyDescription property = (TsDaPropertyDescription)propertyNamesLb_.Items[ii];

						foreach (TsDaPropertyID propertyId in value)
						{
							if (property.ID == propertyId) 
							{
								propertyNamesLb_.SetItemChecked(ii, true);
								break;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Toggles the enabled state for the list of property names.
		/// </summary>
		private void ReturnAllPropertiesCB_CheckedChanged(object sender, System.EventArgs e)
		{
			propertyNamesLb_.Enabled = !returnAllPropertiesCb_.Checked;
		}
	}
}

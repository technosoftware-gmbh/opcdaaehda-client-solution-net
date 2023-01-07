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
#pragma warning disable 0618

using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Cpx;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// Summary description for EditComplexValueDlg.
    /// </summary>
    public class EditComplexValueDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.TreeView TypeTV;
		private System.Windows.Forms.ListView FieldsLV;
		private System.Windows.Forms.Splitter Splitter01;
		private System.Windows.Forms.ContextMenuStrip PopupMenu;
		private System.Windows.Forms.ToolStripMenuItem EditMI;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem FormattedMI;
		private System.Windows.Forms.ToolStripMenuItem RawMI;
		private System.Windows.Forms.Panel FormattedPN;
		private System.Windows.Forms.Panel RawPN;
		private System.Windows.Forms.Panel SchemaPN;
		private System.Windows.Forms.TextBox TypeDictionaryTB;
		private System.Windows.Forms.TextBox TypeDescriptionTB;
		private System.Windows.Forms.ToolStripMenuItem TypeDictionaryMI;
		private System.Windows.Forms.ToolStripMenuItem TypeDescriptionMI;
		private System.Windows.Forms.ToolStripMenuItem ViewMI;
		private System.Windows.Forms.RichTextBox RawTB;
        private IContainer components;

		public EditComplexValueDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            

			TypeTV.ImageList        = Resources.Instance.ImageList;
			FieldsLV.SmallImageList = Resources.Instance.ImageList;

			SetColumns(new string[] { "Name", "Data Type", "Value" });
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
            components = new System.ComponentModel.Container();
			ButtonsPN = new System.Windows.Forms.Panel();
			CancelBTN = new System.Windows.Forms.Button();
			OkBTN = new System.Windows.Forms.Button();
			TypeTV = new System.Windows.Forms.TreeView();
			PopupMenu = new System.Windows.Forms.ContextMenuStrip();
			EditMI = new System.Windows.Forms.ToolStripMenuItem();
			FormattedPN = new System.Windows.Forms.Panel();
			FieldsLV = new System.Windows.Forms.ListView();
			Splitter01 = new System.Windows.Forms.Splitter();
			RawPN = new System.Windows.Forms.Panel();
            RawTB = new System.Windows.Forms.RichTextBox();
            MainMenu = new System.Windows.Forms.MenuStrip();
			ViewMI = new System.Windows.Forms.ToolStripMenuItem();
			FormattedMI = new System.Windows.Forms.ToolStripMenuItem();
			RawMI = new System.Windows.Forms.ToolStripMenuItem();
			TypeDictionaryMI = new System.Windows.Forms.ToolStripMenuItem();
			TypeDescriptionMI = new System.Windows.Forms.ToolStripMenuItem();
			SchemaPN = new System.Windows.Forms.Panel();
			TypeDictionaryTB = new System.Windows.Forms.TextBox();
			TypeDescriptionTB = new System.Windows.Forms.TextBox();
			ButtonsPN.SuspendLayout();
			FormattedPN.SuspendLayout();
			RawPN.SuspendLayout();
			SchemaPN.SuspendLayout();
			SuspendLayout();
			// 
			// ButtonsPN
			// 
			ButtonsPN.Controls.Add(CancelBTN);
			ButtonsPN.Controls.Add(OkBTN);
			ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			ButtonsPN.Location = new System.Drawing.Point(0, 418);
			ButtonsPN.Name = "ButtonsPN";
			ButtonsPN.Size = new System.Drawing.Size(592, 36);
			ButtonsPN.TabIndex = 1;
			// 
			// CancelBTN
			// 
			CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			CancelBTN.Location = new System.Drawing.Point(512, 8);
			CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new System.Drawing.Size(75, 23);
			CancelBTN.TabIndex = 0;
			CancelBTN.Text = "Close";
			CancelBTN.Click += new System.EventHandler(CancelBTN_Click);
			// 
			// OkBTN
			// 
			OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            OkBTN.Location = new System.Drawing.Point(431, 8);
			OkBTN.Name = "OkBTN";
            OkBTN.Size = new System.Drawing.Size(75, 23);
			OkBTN.TabIndex = 1;
			OkBTN.Text = "OK";
			// 
			// TypeTV
			// 
			TypeTV.ContextMenuStrip = PopupMenu;
			TypeTV.Dock = System.Windows.Forms.DockStyle.Left;
			TypeTV.Location = new System.Drawing.Point(4, 4);
			TypeTV.Name = "TypeTV";
			TypeTV.Size = new System.Drawing.Size(228, 410);
			TypeTV.TabIndex = 2;
            TypeTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(TypeTV_AfterSelect);
			TypeTV.MouseDown += new System.Windows.Forms.MouseEventHandler(TypeTV_MouseDown);
			// 
			// PopupMenu
			// 
			PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					  EditMI});
			// 
			// EditMI
			// 
			EditMI.ImageIndex = 0;
			EditMI.Text = "Edit...";
			EditMI.Click += new System.EventHandler(EditMI_Click);
			// 
			// FormattedPN
			// 
			FormattedPN.Controls.Add(FieldsLV);
			FormattedPN.Controls.Add(Splitter01);
			FormattedPN.Controls.Add(TypeTV);
			FormattedPN.Dock = System.Windows.Forms.DockStyle.Fill;
			FormattedPN.Location = new System.Drawing.Point(0, 0);
			FormattedPN.Name = "FormattedPN";
            FormattedPN.Padding = new System.Windows.Forms.Padding(4);
			FormattedPN.Size = new System.Drawing.Size(592, 418);
			FormattedPN.TabIndex = 3;
			// 
			// FieldsLV
			// 
			FieldsLV.Dock = System.Windows.Forms.DockStyle.Fill;
			FieldsLV.FullRowSelect = true;
			FieldsLV.Location = new System.Drawing.Point(236, 4);
			FieldsLV.MultiSelect = false;
			FieldsLV.Name = "FieldsLV";
			FieldsLV.Size = new System.Drawing.Size(352, 410);
			FieldsLV.TabIndex = 6;
            FieldsLV.UseCompatibleStateImageBehavior = false;
			FieldsLV.View = System.Windows.Forms.View.Details;
			// 
			// Splitter01
			// 
			Splitter01.Location = new System.Drawing.Point(232, 4);
			Splitter01.Name = "Splitter01";
			Splitter01.Size = new System.Drawing.Size(4, 410);
			Splitter01.TabIndex = 7;
			Splitter01.TabStop = false;
			// 
			// RawPN
			// 
			RawPN.Controls.Add(RawTB);
			RawPN.Dock = System.Windows.Forms.DockStyle.Fill;
			RawPN.Location = new System.Drawing.Point(0, 0);
			RawPN.Name = "RawPN";
            RawPN.Padding = new System.Windows.Forms.Padding(4);
			RawPN.Size = new System.Drawing.Size(592, 418);
			RawPN.TabIndex = 5;
			RawPN.Visible = false;
			// 
            // RawTB
            // 
            RawTB.Dock = System.Windows.Forms.DockStyle.Fill;
            RawTB.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RawTB.Location = new System.Drawing.Point(4, 4);
            RawTB.Name = "RawTB";
            RawTB.Size = new System.Drawing.Size(584, 410);
            RawTB.TabIndex = 1;
            RawTB.Text = "0000 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 123456789ABCDEF0";
            // 
			// MainMenu
			// 
			MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																					 ViewMI});
			// 
			// ViewMI
			// 
			ViewMI.ImageIndex = 0;
			ViewMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																				   FormattedMI,
																				   RawMI,
																				   TypeDictionaryMI,
																				   TypeDescriptionMI});
			ViewMI.Text = "&View";
			// 
			// FormattedMI
			// 
			FormattedMI.ImageIndex = 0;
			FormattedMI.Text = "&Formatted Value";
			FormattedMI.Click += new System.EventHandler(ViewMI_Click);
			// 
			// RawMI
			// 
			RawMI.ImageIndex = 1;
			RawMI.Text = "&Raw Value";
			RawMI.Click += new System.EventHandler(ViewMI_Click);
			// 
			// TypeDictionaryMI
			// 
			TypeDictionaryMI.ImageIndex = 2;
            TypeDictionaryMI.Text = "BuiltInTypes Type";
			TypeDictionaryMI.Click += new System.EventHandler(ViewMI_Click);
			// 
			// TypeDescriptionMI
			// 
			TypeDescriptionMI.ImageIndex = 3;
			TypeDescriptionMI.Text = "Type Description";
			TypeDescriptionMI.Click += new System.EventHandler(ViewMI_Click);
			// 
			// SchemaPN
			// 
			SchemaPN.Controls.Add(TypeDictionaryTB);
			SchemaPN.Controls.Add(TypeDescriptionTB);
			SchemaPN.Dock = System.Windows.Forms.DockStyle.Fill;
			SchemaPN.Location = new System.Drawing.Point(0, 0);
			SchemaPN.Name = "SchemaPN";
            SchemaPN.Padding = new System.Windows.Forms.Padding(4);
			SchemaPN.Size = new System.Drawing.Size(592, 418);
			SchemaPN.TabIndex = 1;
			SchemaPN.Visible = false;
			// 
			// TypeDictionaryTB
			// 
			TypeDictionaryTB.Dock = System.Windows.Forms.DockStyle.Fill;
            TypeDictionaryTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			TypeDictionaryTB.Location = new System.Drawing.Point(4, 4);
			TypeDictionaryTB.Multiline = true;
			TypeDictionaryTB.Name = "TypeDictionaryTB";
			TypeDictionaryTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			TypeDictionaryTB.Size = new System.Drawing.Size(584, 410);
			TypeDictionaryTB.TabIndex = 1;
			TypeDictionaryTB.WordWrap = false;
			// 
			// TypeDescriptionTB
			// 
			TypeDescriptionTB.Dock = System.Windows.Forms.DockStyle.Fill;
            TypeDescriptionTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			TypeDescriptionTB.Location = new System.Drawing.Point(4, 4);
			TypeDescriptionTB.Multiline = true;
			TypeDescriptionTB.Name = "TypeDescriptionTB";
			TypeDescriptionTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			TypeDescriptionTB.Size = new System.Drawing.Size(584, 410);
			TypeDescriptionTB.TabIndex = 2;
			TypeDescriptionTB.WordWrap = false;
			// 
			// EditComplexValueDlg
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(592, 454);
			Controls.Add(RawPN);
			Controls.Add(FormattedPN);
			Controls.Add(SchemaPN);
			Controls.Add(ButtonsPN);
            Name = "EditComplexValueDlg";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "View Complex Data";
			ButtonsPN.ResumeLayout(false);
			FormattedPN.ResumeLayout(false);
			RawPN.ResumeLayout(false);
			SchemaPN.ResumeLayout(false);
            SchemaPN.PerformLayout();
			ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Whether the user is allowed to edit the complex value.
		/// </summary>
		private bool m_readOnly = false;

		/// <summary>
		/// The item id for the complex item being viewed.
		/// </summary>
		private TsCCpxComplexItem m_item = null;

		/// <summary>
		/// The unformatted value of the complex item.
		/// </summary>
		private object m_rawValue = null;

		/// <summary>
		/// The formatted value of the complex item.
		/// </summary>
		private TsCCpxComplexValue m_complexValue = null;

		/// <summary>
		/// A class that encapulates parsing of values described by the OPCBinary schema.
		/// </summary>
		private class BinaryValue
		{
			private TypeDictionary m_dictionary = null;
			private string         m_typeID     = null;
			
			// initializes the object are returns the parsed values.
			public TsCCpxComplexValue Init(object rawValue, string dictionary, string typeID)
			{
				XmlTextReader reader     = new XmlTextReader(dictionary, XmlNodeType.Document, null);
				XmlSerializer serializer = new XmlSerializer(typeof(TypeDictionary), OpcNamespace.OPC_BINARY);
						
				m_dictionary = (TypeDictionary)serializer.Deserialize(reader);
				m_typeID     = typeID;

				return Parse((byte[])rawValue);
			}

			// parses the buffer according to the schema.
			public TsCCpxComplexValue Parse(byte[] data)
			{
				return new Technosoftware.DaAeHdaClient.Cpx.TsCCpxBinaryReader().Read(data, m_dictionary, m_typeID);
			}

			// serializes the buffer according to the schema.
			public byte[] Parse(TsCCpxComplexValue complexValue)
			{
				return new Technosoftware.DaAeHdaClient.Cpx.TsCCpxBinaryWriter().Write(complexValue, m_dictionary, m_typeID);
			}
		}

		/// <summary>
		/// A object used to parse value described by the OPCBinary schema.
		/// </summary>
		private BinaryValue m_binaryValue = null;

		/// <summary>
		/// Displays the dialog with the specified complex item.
		/// </summary>
		public object ShowDialog(TsCCpxComplexItem item, object rawValue, bool readOnly, bool modal)
		{
			if (item == null)   throw new ArgumentNullException("item");

			try
			{
				m_readOnly = readOnly;
				m_item     = item;
				m_rawValue = rawValue;

				// fetch complex type information for the item.
				string dictionary = TsCCpxComplexTypeCache.GetTypeDictionary(item);

				if (dictionary == null)
				{
					return null;
				}

				// initialize dialog controls.
				TypeTV.Nodes.Clear();
				FieldsLV.Items.Clear();
				RawTB.Text = null;

				// display the dictionary and type description.
				TypeDictionaryTB.Text  = FormatXml(dictionary);
				TypeDescriptionTB.Text = FormatXml(TsCCpxComplexTypeCache.GetTypeDescription(item));

				if (rawValue == null)
				{
					ViewMI_Click(TypeDictionaryMI, null);
				}
				else
				{
					// parse binary value.
					if (rawValue.GetType() == typeof(byte[]))
					{
						m_binaryValue  = new BinaryValue();

						try
						{
							m_complexValue = m_binaryValue.Init(rawValue, dictionary, item.TypeID);
						}
						catch (Exception e)
						{
							MessageBox.Show(e.Message);
							m_complexValue = null;
						}
					}
					else
					{
						m_binaryValue  = null;
						m_complexValue = null;
					}

					UpdateView();
					
					if (TypeTV.SelectedNode != null)
					{
						TypeTV.SelectedNode = TypeTV.Nodes[0];
						TypeTV.SelectedNode.Expand();

						ViewMI_Click(FormattedMI, null);
					}
					else
					{
						ViewMI_Click(RawMI, null);
					}
				}

				if (modal)
				{
					// show dialog.
					if (ShowDialog() != DialogResult.OK)
					{
						return null;
					}

					return m_rawValue;
				}

				// display non-model window.
				Show();

				return null;
			}

			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return null;
			}
		}

		/// <summary>
		/// Updates the controls with a new value.
		/// </summary>
		public void UpdateValue(object rawValue)
		{
			m_rawValue = rawValue;

			if (m_binaryValue != null && rawValue.GetType() == typeof(byte[]))
			{
				m_complexValue = m_binaryValue.Parse((byte[])rawValue);
			}

			UpdateView();
		}

		/// <summary>
		/// Updates the controls with the current values.
		/// </summary>
		private void UpdateView()
		{
			ShowRawValue(m_rawValue);
			ShowFormattedValue(TypeTV.Nodes, m_complexValue, 0);

			if (TypeTV.Nodes.Count > 0)
			{
				if (TypeTV.SelectedNode == null)
				{
					TypeTV.SelectedNode = TypeTV.Nodes[0];
					TypeTV.SelectedNode.Expand();
				}

				ShowComplexValue((TsCCpxComplexValue)TypeTV.SelectedNode.Tag);
			}
		}

		/// <summary>
		/// Adds a complex value to the a branch in the tree view.
		/// </summary>
		private void ShowFormattedValue(TreeNodeCollection nodes, TsCCpxComplexValue complexValue, int index)
		{
			if (complexValue == null) 
			{
				nodes.Clear();
				return;
			}

			TreeNode node = null;
			
			// check if the node already exists.
			if (nodes.Count > index)
			{
				node = nodes[index];
			}

			// adds a new node.
			if (node == null)
			{
				node = new TreeNode();

				node.Text               = complexValue.Name;
				node.ImageIndex         = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
				node.SelectedImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER;			

				nodes.Add(node);
			}

			node.Tag = complexValue;

			// check for nested structure.
			if (complexValue.Value.GetType() == typeof(TsCCpxComplexValue[]))
			{
				int ii = 0;

				foreach (TsCCpxComplexValue element in (Array)complexValue.Value)
				{
					ShowFormattedValue(node.Nodes, element, ii++);
				}
			}
		}

		/// <summary>
		/// Displays the value(s) of a complex value in the list view.
		/// </summary>
		void ShowComplexValue(TsCCpxComplexValue complexValue)
		{
			// check if the value is already displayed.
			if (complexValue == null || complexValue.Equals(FieldsLV.Tag))
			{
				return;
			}
				
			FieldsLV.Items.Clear();

			// display a simple value.
			if (!complexValue.Value.GetType().IsArray || complexValue.Value.GetType() == typeof(byte[]))
			{
				ListViewItem listItem = new ListViewItem(complexValue.Name, Resources.IMAGE_EXPLODING_BOX);

				listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(complexValue.Value.GetType()));
				listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(complexValue.Value));
				
				listItem.Tag = complexValue;

				FieldsLV.Items.Add(listItem);		

				AdjustColumns();
				return;
			}

			// display an array value.
			ArrayList fields = new ArrayList((Array)complexValue.Value);

			for (int ii = 0; ii < fields.Count; ii++)
			{
				ListViewItem listItem = null;

				// display the fields in a complex value.
				if (fields[ii].GetType() == typeof(TsCCpxComplexValue))
				{					
					TsCCpxComplexValue elementValue = (TsCCpxComplexValue)fields[ii];

					listItem = new ListViewItem(elementValue.Name, Resources.IMAGE_EXPLODING_BOX);
				
					// display a complex value field.
					if (elementValue.Value.GetType() == typeof(TsCCpxComplexValue[]))
					{
						listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(elementValue.Type));
						listItem.SubItems.Add(String.Format("ComplexValue[{0}]", ((Array)elementValue.Value).Length));
					}

					// display a simple type field.
					else
					{
						listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(elementValue.Type));
						listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(elementValue.Value));
					}

					listItem.Tag = elementValue;
				}

				// display simple value.
				else
				{
					listItem = new ListViewItem(String.Format("[{0}]", ii), Resources.IMAGE_EXPLODING_BOX);
				
					listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(fields[ii].GetType()));
					listItem.SubItems.Add(Technosoftware.DaAeHdaClient.OpcConvert.ToString(fields[ii]));

					listItem.Tag = fields[ii];
				}
		
				// add item to list.
				FieldsLV.Items.Add(listItem);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Updates the display with the raw value for the item.
		/// </summary>
		private void ShowRawValue(object rawValue)
		{
			if (rawValue.GetType() == typeof(byte[]))
			{
				StringBuilder buffer = new StringBuilder(1024);

				byte[] data  = (byte[])rawValue;
				char[] chars = new char[16];

				int pos = 0;

				for (int ii = 0; ii < data.Length; ii++)
				{
					pos = ii%chars.Length;

					if (pos == 0)
					{
						if (ii > 0) 
						{
							buffer.Append(chars);
							buffer.Append(Environment.NewLine);
						}

						buffer.Append(String.Format("{0:X4} ", ii));
					}

					buffer.Append(String.Format("{0:X2} ", data[ii]));
					chars[pos] = System.Convert.ToChar(data[ii]);

					if (Char.IsControl(chars[pos]))
					{
						chars[pos] = '.';
					}
				}

				int trailer = chars.Length - data.Length%chars.Length;
				
				for (int ii = pos+1; ii < chars.Length; ii++)
				{					
					buffer.Append("   ");
					chars[ii] = ' ';
				}

				buffer.Append(chars);

				RawTB.Text = buffer.ToString();
			}
			else if (rawValue.GetType() == typeof(string))
			{		
				RawTB.Text = FormatXml((string)rawValue);
			}
			else
			{				
				RawTB.Text = null;
			}
		}

		/// <summary>
		/// Displays a dialog to edit a complex value.
		/// </summary>
		private void EditComplexValue(TsCCpxComplexValue complexValue)
		{
			object value = null;

			if (!complexValue.Value.GetType().IsArray) 
			{
				value = new EditValueDlg().ShowDialog(complexValue.Value, true);
			}
			else if (complexValue.Value.GetType() == typeof(byte[]))
            {
				value = new EditBinaryDlg().ShowDialog((byte[])complexValue.Value);
		    }
			else
			{
				if (complexValue.Value.GetType() != typeof(TsCCpxComplexValue[]))
				{
					value = new EditArrayDlg().ShowDialog(complexValue.Value, m_readOnly);
				}
			}

			if (value != null)
			{				
				// update the complex value.
				complexValue.Value = value;

				// serialize the entire complex value starting with the root object.
				m_rawValue = m_binaryValue.Parse(m_complexValue);

				// update the diplay.
				UpdateView();
			}
		}

		/// <summary>
		/// Formats an XML document for display.
		/// </summary>
		private string FormatXml(string xml)
		{
			try
			{
				XmlTextReader  reader    = new XmlTextReader(xml, XmlNodeType.Document, null);
				XPathDocument  document  = new XPathDocument(reader);
				XPathNavigator navigator = document.CreateNavigator();
			
				StringWriter  ostrm  = new StringWriter();
				XmlTextWriter writer = new XmlTextWriter(ostrm);
				writer.Formatting    = Formatting.Indented;
				writer.Indentation   = 4;
				writer.IndentChar    = ' ';

				string xsl = "";
				xsl += "<xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">";
				xsl += "<xsl:template match=\"*\">";
				xsl += "<xsl:copy-of select=\".\"/>";
				xsl += "</xsl:template>";
				xsl += "</xsl:stylesheet>";

				XslTransform transform = new XslTransform();
				transform.Load(new XmlTextReader(xsl, XmlNodeType.Element, null));
				transform.Transform(navigator, null, writer, null);

				return ostrm.ToString();
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			FieldsLV.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				FieldsLV.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < FieldsLV.Columns.Count; ii++)
			{
				FieldsLV.Columns[ii].Width = -2;
			}
		}

		/// <summary>
		/// Updates the detail view after selecting a node in the tree view.
		/// </summary>
		private void TypeTV_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TreeNode node = e.Node;

			if (node.Tag != null && node.Tag.GetType() == typeof(TsCCpxComplexValue))
			{
				ShowComplexValue((TsCCpxComplexValue)node.Tag);
			}
		}

		/// <summary>
		/// Updates the state of context menus based on the current selection.
		/// </summary>
		private void TypeTV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// selects the item that was right clicked on.
			TreeNode clickedNode = TypeTV.GetNodeAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedNode == null) return;

			// force selection to clicked node.
			TypeTV.SelectedNode = clickedNode;

			// disable everything.
			EditMI.Enabled = false;

			if (clickedNode.Tag == null || clickedNode.Tag.GetType() != typeof(TsCCpxComplexValue))
			{
				return;
			}

			TsCCpxComplexValue value = (TsCCpxComplexValue)clickedNode.Tag;

			if (value.Value.GetType() == typeof(TsCCpxComplexValue[]))
			{
				return;
			}

			EditMI.Enabled = !m_readOnly;		
		}	

		/// <summary>
		/// Closes the window when the cancel button is clicked.
		/// </summary>
		private void CancelBTN_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Toggles the state of the view formatted data menu item.
		/// </summary>
		private void ViewMI_Click(object sender, System.EventArgs e)
		{
			FormattedMI.Checked       = false;
			RawMI.Checked             = false;
			TypeDictionaryMI.Checked  = false;
			TypeDescriptionMI.Checked = false;

			((ToolStripMenuItem)sender).Checked = true;

			if (FormattedMI.Checked)
			{
				FormattedPN.Visible = true;
				RawPN.Visible       = false;
				SchemaPN.Visible    = false;
			}

			else if (RawMI.Checked)
			{
				FormattedPN.Visible = false;
				RawPN.Visible       = true;
				SchemaPN.Visible    = false;
			}

			else if (TypeDictionaryMI.Checked)
			{
				FormattedPN.Visible = false;
				RawPN.Visible       = false;
				SchemaPN.Visible    = true;

				TypeDictionaryTB.Visible  = true;
				TypeDescriptionTB.Visible = false;
			}

			else if (TypeDescriptionMI.Checked)
			{
				FormattedPN.Visible = false;
				RawPN.Visible       = false;
				SchemaPN.Visible    = true;

				TypeDictionaryTB.Visible  = false;
				TypeDescriptionTB.Visible = true;
			}
		}

		/// <summary>
		/// Called to edit a complex data value.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{			
			TreeNode node = TypeTV.SelectedNode;

			if (node != null && node.Tag != null && node.Tag.GetType() == typeof(TsCCpxComplexValue))
			{
				EditComplexValue((TsCCpxComplexValue)node.Tag);
			}
		}
	}
}
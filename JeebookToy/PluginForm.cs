/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/1
 * Time: 12:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Windows.Forms;

namespace JeebookToy
{
	/// <summary>
	/// Description of PluginForm.
	/// </summary>
	public partial class PluginForm : Form
	{
		public PluginForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void PluginFormLoad(object sender, EventArgs e)
		{
			string strPath = System.Windows.Forms.Application.StartupPath + "\\plugins\\";
			string[] dirs = System.IO.Directory.GetDirectories(strPath);
			for ( int i = 0; i < dirs.Length; i ++ )
			{
				PluginsComboBox.Items.Add( dirs[i].Substring( strPath.Length ) );
			}
			PluginsComboBox.SelectedIndex = 0;
		}
		
		void PluginsComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			if ( PluginsComboBox.SelectedText == "" )
				return;
			
			string strPath = System.Windows.Forms.Application.StartupPath + "\\plugins\\" + PluginsComboBox.SelectedText + "\\";
			string[] files = System.IO.Directory.GetFiles(strPath, "*.xsl");
			for ( int i = 0; i < files.Length; i ++ )
			{
				XslComboBox.Items.Add( files[i].Substring( strPath.Length ) );
			}
			XslComboBox.SelectedIndex = 0;
		}
		
		void CreateButtonClick(object sender, EventArgs e)
		{
			XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(System.Windows.Forms.Application.StartupPath + "\\plugins\\" + PluginsComboBox.SelectedText + "\\" + XslComboBox.SelectedText );

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(HtmlTidy.Tidy(SourceTextBox.Text));
            
            System.IO.StringWriter sw = new System.IO.StringWriter();
            xslt.Transform( xml, XmlWriter.Create(sw));
            
            TargetTextBox.Text = sw.ToString();
		}
	}
}

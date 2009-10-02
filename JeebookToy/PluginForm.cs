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
using EfTidyNet;

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
			if ( PluginsComboBox.Items.Count > 0 )
				PluginsComboBox.SelectedIndex = 0;
		}
		
		void PluginsComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			if ( PluginsComboBox.Text == "" )
				return;
			
			string strPath = System.Windows.Forms.Application.StartupPath + "\\plugins\\" + PluginsComboBox.Text + "\\";
			string[] files = System.IO.Directory.GetFiles(strPath, "*.xslt");
			for ( int i = 0; i < files.Length; i ++ )
			{
				XslComboBox.Items.Add( files[i].Substring( strPath.Length ) );
			}
			if ( XslComboBox.Items.Count > 0 )
				XslComboBox.SelectedIndex = 0;
		}
		
		void CreateButtonClick(object sender, EventArgs e)
		{
			//
			string 	xhtml = "";
			TidyNet tn = new TidyNet();
			tn.Option.OutputType(EfTidyNet.EfTidyOpt.EOutputType.XhtmlOut);
			tn.TidyMemToMem( SourceTextBox.Text, ref xhtml );

			//
			XmlDocument xml = new XmlDocument();
            xml.LoadXml(xhtml);

            //
            try {
	            StringBuilder sb = new StringBuilder();
	            SaxonWrapper.Xsl2Processor processor = new SaxonWrapper.Xsl2Processor();
	            processor.Load( System.Windows.Forms.Application.StartupPath + "\\plugins\\" + PluginsComboBox.Text + "\\" + XslComboBox.Text );
	            processor.Transform( xml, XmlWriter.Create( sb ) );
//	            Saxon.Api.Processor processor = new Saxon.Api.Processor();
//	            Saxon.Api.XsltCompiler compiler = processor.NewXsltCompiler();
//	            System.Xml.XmlReader xr = XmlReader.Create(System.Windows.Forms.Application.StartupPath + "\\plugins\\" + PluginsComboBox.Text + "\\" + XslComboBox.Text );
//	            Saxon.Api.XsltTransformer transformer = compiler.Compile(xr).Load();
//	            
//	            Saxon.Api.XdmNode inputNode = processor.NewDocumentBuilder().Build(xml);
//	            Saxon.Api.TextWriterDestination dest = new Saxon.Api.TextWriterDestination(XmlWriter.Create(sb));
//	                        
//	            transformer.InitialContextNode = inputNode;
//	            transformer.Run(dest);
	            
	            TargetTextBox.Text = sb.ToString();
            } 
            catch ( Exception ex )
            {
            	MessageBox.Show( ex.ToString() + ":" + ex.Message );
            }
		}
		
		void SourceTextBoxDoubleClick(object sender, EventArgs e)
		{
			SourceTextBox.SelectAll();
		}
		
		void TargetTextBoxDoubleClick(object sender, EventArgs e)
		{
			TargetTextBox.SelectAll();
		}
	}
}

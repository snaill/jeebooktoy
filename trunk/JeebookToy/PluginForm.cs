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
			XHtmlTextBox.Text = "";
			TargetTextBox.Text = "";
            TimeStatusLabel.Text = "0 ms";
            CharacterStatusLabel.Text = "0 character";

            //
            DateTime dtStart = System.DateTime.Now;


            //
            TidyNet.Tidy tidy = new TidyNet.Tidy();

            /* Set the options you want */
            tidy.Options.Xhtml = true;
            tidy.Options.XmlOut = true;
            tidy.Options.MakeClean = true;
            tidy.Options.CharEncoding = TidyNet.CharEncoding.UTF8;

            /* Declare the parameters that is needed */
            System.IO.MemoryStream input = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(SourceTextBox.Text));
            System.IO.MemoryStream output = new System.IO.MemoryStream();
            tidy.Parse(input, output, new TidyNet.TidyMessageCollection());

            XHtmlTextBox.Text = Encoding.UTF8.GetString(output.ToArray());
			
			//
			XmlDocument xml = new XmlDocument();
            xml.LoadXml(XHtmlTextBox.Text);

            //
            try {
	            StringBuilder sb = new StringBuilder();
	            SaxonWrapper.Xsl2Processor processor = new SaxonWrapper.Xsl2Processor();
	            processor.Load( System.Windows.Forms.Application.StartupPath + "\\plugins\\" + PluginsComboBox.Text + "\\" + XslComboBox.Text );
	            processor.Transform( xml, XmlWriter.Create( sb ) );
	            TargetTextBox.Text = sb.ToString();
            } 
            catch ( Exception ex )
            {
            	MessageBox.Show( ex.ToString() + ":" + ex.Message );
                return;
            }

            TimeStatusLabel.Text = ((int)(System.DateTime.Now - dtStart).TotalMilliseconds).ToString() + " ms";
            CharacterStatusLabel.Text = TargetTextBox.Text.Length.ToString() + " characters";
		}
		
		void SourceTextBoxDoubleClick(object sender, EventArgs e)
		{
			SourceTextBox.SelectAll();
		}
		
		void TargetTextBoxDoubleClick(object sender, EventArgs e)
		{
			TargetTextBox.SelectAll();
		}
		
        private void XHtmlTextBoxDoubleClick(object sender, EventArgs e)
        {
            XHtmlTextBox.SelectAll();
        }
	}
}

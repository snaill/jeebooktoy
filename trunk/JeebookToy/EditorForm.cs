/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-10-9
 * Time: 13:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using JeebookToy.JB;

namespace JeebookToy
{
	/// <summary>
	/// Description of EditorForm.
	/// </summary>
	public partial class EditorForm : Form
	{
		Book CurrentBook = null;
		
		public EditorForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//

		}
		
		void OpenButtonClick(object sender, EventArgs e)
		{
			CurrentBook = Book.Create(UriTextBox.Text);
			
			TreeNode tn = ContentTreeView.Nodes.Add(CurrentBook.Info.Title);
			for ( int i = 0; i < CurrentBook.Chapters.Count; i ++ )
			{
				TreeNode tnSub = tn.Nodes.Add( CurrentBook.Chapters[i].Title);
				tnSub.Tag = CurrentBook.Chapters[i];
			}
			tn.Expand();
		}
	
		void ContentTreeViewAfterSelect(object sender, TreeViewEventArgs e)
		{
			if ( ContentTreeView.SelectedNode != ContentTreeView.TopNode )
			{
				Chapter chap = (Chapter)ContentTreeView.SelectedNode.Tag;
				if ( chap.Elements == null )
					chap = Chapter.Create( chap.Uri );
				
				foreach ( Element ex in chap.Elements )
				{
					Para para = (Para)ex;
					ContextTextBox.Text += para.Text + "\r\n";
				}
			}			
		}
	}
}

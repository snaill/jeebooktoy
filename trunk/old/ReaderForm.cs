using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BookStarToy
{
	/// <summary>
	/// ReaderForm 的摘要说明。
	/// </summary>
	public class ReaderForm : System.Windows.Forms.Form
	{
		/// <summary>文件名</summary>
		public string Filename = null;

		/// <summary>SBP文件的阅读类</summary>
		private BookStarToy.SBP.SBP_Reader reader = new BookStarToy.SBP.SBP_Reader();

		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TreeView ArticleTreeView;
		private System.Windows.Forms.TextBox ArticleTextBox;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public ReaderForm()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.ArticleTreeView = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.ArticleTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ArticleTreeView
			// 
			this.ArticleTreeView.Dock = System.Windows.Forms.DockStyle.Left;
			this.ArticleTreeView.ImageIndex = -1;
			this.ArticleTreeView.Location = new System.Drawing.Point(0, 0);
			this.ArticleTreeView.Name = "ArticleTreeView";
			this.ArticleTreeView.SelectedImageIndex = -1;
			this.ArticleTreeView.Size = new System.Drawing.Size(212, 318);
			this.ArticleTreeView.TabIndex = 0;
			this.ArticleTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ArticleTreeView_AfterSelect);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(212, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(5, 318);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// ArticleTextBox
			// 
			this.ArticleTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ArticleTextBox.Location = new System.Drawing.Point(217, 0);
			this.ArticleTextBox.Multiline = true;
			this.ArticleTextBox.Name = "ArticleTextBox";
			this.ArticleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ArticleTextBox.Size = new System.Drawing.Size(319, 318);
			this.ArticleTextBox.TabIndex = 3;
			this.ArticleTextBox.Text = "";
			// 
			// ReaderForm
			// 
			this.ClientSize = new System.Drawing.Size(536, 318);
			this.Controls.Add(this.ArticleTextBox);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.ArticleTreeView);
			this.Name = "ReaderForm";
			this.Text = "ReaderForm";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ReaderForm_Closing);
			this.Load += new System.EventHandler(this.ReaderForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ReaderForm_Load(object sender, System.EventArgs e)
		{
			System.Diagnostics.Debug.Assert( null != Filename );
			try {
				reader.Load( Filename );
			}catch ( BookStarToy.SBP.SBP_Exception ex) {
				MessageBox.Show( ex.Message );
				Close();
				return;
			}

			//初始化文章数
			TreeNode tn = new TreeNode( );
			tn.Text = reader.GetInfoSection().BOOK_NAME; 
			tn.Tag = reader.GetInfoSection();
			for ( int i = 0; i < reader.Count; i++ )
			{
				if ( BookStarToy.SBP.SectionType.File != reader[i].HEAD_TYPE )
					continue;

				BookStarToy.SBP.FileSection fileSect = ( BookStarToy.SBP.FileSection )reader[i];
				TreeNode tnSub = new TreeNode( fileSect.FILE_NAME );
				tnSub.Tag = fileSect;
				tn.Nodes.Add( tnSub );
			}
			ArticleTreeView.Nodes.Add( tn );
			ArticleTreeView.ExpandAll(); 
			ArticleTreeView.SelectedNode = tn;
		}

		private void ReaderForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.Owner.Show(); 
		}

		private void ArticleTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			BookStarToy.SBP.Section sect = ( BookStarToy.SBP.Section )e.Node.Tag;
			if ( null == sect )
				return;

			switch ( sect.HEAD_TYPE )
			{
				case BookStarToy.SBP.SectionType.Info: 
					BookStarToy.SBP.InfoSection infoSect = (BookStarToy.SBP.InfoSection)sect;	
					ArticleTextBox.Text = infoSect.ToString();
					break;
				case BookStarToy.SBP.SectionType.File: 
					BookStarToy.SBP.FileSection fileSect = (BookStarToy.SBP.FileSection)sect;	
					string strTemp = reader.GetText( fileSect );
					
					// 不改变格式填入
					string[] strArray = strTemp.Split( '\n' );
					System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
					for ( int i = 0; i < strArray.Length; i++ )
						sb.Append( strArray[i] + "\r\n" );

					ArticleTextBox.Text = sb.ToString();
					break;
			}
		}

	}
}

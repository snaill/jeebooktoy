/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2005-3-18
 * Time: 0:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Threading;

namespace BookStarToy
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.TreeView tvWebsite;
		private System.Windows.Forms.ToolBar toolBar;
		private System.Windows.Forms.ListView lvDownload;
		private System.Windows.Forms.ColumnHeader chBookName;
		private System.Windows.Forms.ColumnHeader chStatus;
		private System.Windows.Forms.ColumnHeader chArticleCount;
		private System.Windows.Forms.ColumnHeader chBookURL;
		private System.Windows.Forms.ToolBarButton tbbBookCreator;
		private System.Windows.Forms.ToolBarButton tbbRegexTester;
		private System.Windows.Forms.ToolBarButton tbbOptions;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ToolBarButton tbbReader;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.OpenFileDialog openFileDialog;

		private System.Windows.Forms.ToolBarButton tbbDelete;
		private System.Windows.Forms.ToolBarButton tbbReset;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton tbbWebParser;
		private BookStarToy.Model.WebsiteManager websiteManager = new BookStarToy.Model.WebsiteManager();
		private DownloadService m_aDownloadService = null;

		/// <summary>
		/// 构造信息
		/// </summary>
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/// <summary>
		/// 启动函数
		/// </summary>
		/// <param name="args">参数</param>
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Run(new MainForm());
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.toolBar = new System.Windows.Forms.ToolBar();
			this.tbbBookCreator = new System.Windows.Forms.ToolBarButton();
			this.tbbReader = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbbReset = new System.Windows.Forms.ToolBarButton();
			this.tbbDelete = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.tbbOptions = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.tbbRegexTester = new System.Windows.Forms.ToolBarButton();
			this.tbbWebParser = new System.Windows.Forms.ToolBarButton();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tvWebsite = new System.Windows.Forms.TreeView();
			this.lvDownload = new System.Windows.Forms.ListView();
			this.chBookName = new System.Windows.Forms.ColumnHeader();
			this.chStatus = new System.Windows.Forms.ColumnHeader();
			this.chArticleCount = new System.Windows.Forms.ColumnHeader();
			this.chBookURL = new System.Windows.Forms.ColumnHeader();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(168, 44);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 274);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// toolBar
			// 
			this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
												       this.tbbBookCreator,
												       this.tbbReader,
												       this.toolBarButton1,
												       this.tbbReset,
												       this.tbbDelete,
												       this.toolBarButton2,
												       this.tbbOptions,
												       this.toolBarButton3,
												       this.tbbRegexTester,
												       this.tbbWebParser});
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.imageList;
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new System.Drawing.Size(536, 44);
			this.toolBar.TabIndex = 3;
			this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBarButtonClick);
			// 
			// tbbBookCreator
			// 
			this.tbbBookCreator.ImageIndex = 0;
			this.tbbBookCreator.ToolTipText = "Create eBook";
			// 
			// tbbReader
			// 
			this.tbbReader.ImageIndex = 3;
			this.tbbReader.ToolTipText = "Open SBP";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbReset
			// 
			this.tbbReset.ImageIndex = 5;
			// 
			// tbbDelete
			// 
			this.tbbDelete.ImageIndex = 4;
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbOptions
			// 
			this.tbbOptions.ImageIndex = 1;
			this.tbbOptions.ToolTipText = "Options";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbRegexTester
			// 
			this.tbbRegexTester.ImageIndex = 2;
			this.tbbRegexTester.ToolTipText = "Regex Tester";
			// 
			// tbbWebParser
			// 
			this.tbbWebParser.ImageIndex = 6;
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tvWebsite
			// 
			this.tvWebsite.Dock = System.Windows.Forms.DockStyle.Left;
			this.tvWebsite.ImageIndex = -1;
			this.tvWebsite.Location = new System.Drawing.Point(0, 44);
			this.tvWebsite.Name = "tvWebsite";
			this.tvWebsite.SelectedImageIndex = -1;
			this.tvWebsite.Size = new System.Drawing.Size(168, 274);
			this.tvWebsite.TabIndex = 0;
			this.tvWebsite.DoubleClick += new System.EventHandler(this.tvWebsite_DoubleClick);
			// 
			// lvDownload
			// 
			this.lvDownload.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
													 this.chBookName,
													 this.chStatus,
													 this.chArticleCount,
													 this.chBookURL});
			this.lvDownload.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvDownload.FullRowSelect = true;
			this.lvDownload.Location = new System.Drawing.Point(171, 44);
			this.lvDownload.Name = "lvDownload";
			this.lvDownload.Size = new System.Drawing.Size(365, 274);
			this.lvDownload.TabIndex = 1;
			this.lvDownload.View = System.Windows.Forms.View.Details;
			// 
			// chBookName
			// 
			this.chBookName.Text = "书名";
			// 
			// chStatus
			// 
			this.chStatus.Text = "状态";
			this.chStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// chArticleCount
			// 
			this.chArticleCount.Text = "完成/总数";
			this.chArticleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.chArticleCount.Width = 69;
			// 
			// chBookURL
			// 
			this.chBookURL.Text = "网址";
			this.chBookURL.Width = 169;
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 318);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(536, 24);
			this.statusBar.TabIndex = 2;
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "简书文档|*.sbp";
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(536, 342);
			this.Controls.Add(this.lvDownload);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.tvWebsite);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.toolBar);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			// Init Website TreeView
			System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("BookStarToy.Websites.xml");

			websiteManager.Load(stream);
			TreeNode tn = new TreeNode();
			for (int i = 0; ; i++)
			{
				// 到头判断
				if (null == websiteManager[i])
					break;

				// 设置组节点<group>
				if (null == tn.Text || tn.Text != websiteManager[i].SiteGroup)
				{
					if (null == tn.Text || "" == tn.Text)
						tn.Text = websiteManager[i].SiteGroup;
					else
					{
						tvWebsite.Nodes.Add(tn);
						tn = new TreeNode(websiteManager[i].SiteGroup);
					}
				}

				TreeNode tnSub = new TreeNode(websiteManager[i].SiteName);
				tnSub.Tag = websiteManager[i].SiteURL;
				tn.Nodes.Add(tnSub);
			}
			tvWebsite.Nodes.Add(tn);
			tvWebsite.ExpandAll();

			// 初始化下载服务
			m_aDownloadService = new DownloadService(new ParameterizedThreadStart(CreatorThread));
			m_aDownloadService.Initialize();
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			m_aDownloadService.Save();
		}

		private void tvWebsite_DoubleClick(object sender, System.EventArgs e)
		{
			if (null == tvWebsite.SelectedNode.Tag)
				return;

			try
			{
				System.Diagnostics.Process proc = new System.Diagnostics.Process();
				proc.StartInfo.FileName = tvWebsite.SelectedNode.Tag.ToString();
				proc.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		enum ToolButtonIndex { New = 0, Open = 1, Reset = 3, Delete = 4, Option = 6, Regex = 8, WebParser = 9 };
		void ToolBarButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch ( toolBar.Buttons.IndexOf( e.Button ) )
			{
				case (Int32)ToolButtonIndex.New:
					CreateBookForm nbf = new CreateBookForm();
					if ( nbf.ShowDialog() != System.Windows.Forms.DialogResult.OK )
						return;
					
					AddBook( nbf.book );
					break;
				case (Int32)ToolButtonIndex.Open:
					if ( openFileDialog.ShowDialog() != DialogResult.OK )
						return;
					ReaderForm rf = new ReaderForm();
					rf.Filename = openFileDialog.FileName; 
					this.Hide();
					rf.ShowDialog(this);
					break;

				case (Int32)ToolButtonIndex.Option:
					OptionsForm	of = new OptionsForm();
					of.ShowDialog();
					break;
				case (Int32)ToolButtonIndex.Regex:
					RegexTestForm rtf = new RegexTestForm();
					rtf.ShowDialog();
					break;
				case (Int32)ToolButtonIndex.WebParser:
					WebParserForm wpf = new WebParserForm( websiteManager );
					wpf.ShowDialog();
					break;
				case (Int32)ToolButtonIndex.Reset:
					if ( lvDownload.SelectedItems.Count != 0 )
					{
						ListViewItem lvi = lvDownload.SelectedItems[0];
						BookStarToy.Model.Book book = ( BookStarToy.Model.Book )lvi.Tag;
						if ( book.Status == BookStarToy.Model.BookStatus.Error || book.Status == BookStarToy.Model.BookStatus.Finished )
						{
							lvDownload.Items.Remove( lvi );
							book.Clear(); 
							AddBook( book );
						}
					}
					break;
				case (Int32)ToolButtonIndex.Delete:
					if ( lvDownload.SelectedItems.Count != 0 )
					{
						ListViewItem lvi = lvDownload.SelectedItems[0];
						BookStarToy.Model.Book book = ( BookStarToy.Model.Book )lvi.Tag;
						if ( book.Status == BookStarToy.Model.BookStatus.Error || book.Status == BookStarToy.Model.BookStatus.Finished )
							lvDownload.Items.Remove( lvi );
					}
					break;
			}
		}

		/// <summary>
		/// 添加图书，更新下载列表并启动创建线程
		/// </summary>
		/// <param name="book"></param>
		public void AddBook( BookStarToy.Model.Book book )
		{
			// 查找是否有相同项
			for ( int i = 0; i < lvDownload.Items.Count; i++ )
			{
				ListViewItem	lvItem = lvDownload.Items[i];
				if ( lvItem.SubItems[3].Text == book.URL )
				{
					MessageBox.Show( "该网址已在队列中");
					return;
				}
			}

			//
			ListViewItem	lvi = new ListViewItem();
			lvi.Text = "未命名";
			lvi.SubItems.Add( "" );
			lvi.SubItems.Add( "" );
			lvi.SubItems.Add( book.URL );
			lvi.Tag = book;
			lvDownload.Items.Add( lvi );

			m_aDownloadService.Add( book );
		}

		private void CreatorThread( Object o )
		{
			BookStarToy.Model.Book book = ( BookStarToy.Model.Book )o;
			book.StatusNotify = new BookStarToy.Model.StatusNotify(StatusNotify);

			BookStarToy.Model.BookCreator bc = new BookStarToy.Model.BookCreator();
			BookStarToy.Model.Website ws = websiteManager[book.URL];
			bc.Create( book, ws ); 
		}

		/// <summary>
		/// 通知下载状态
		/// </summary>
		/// <param name="oSender">通知发送者</param>
		/// <param name="oStatus">状态对象</param>
		void StatusNotify( Object oSender, Object oStatus )
		{
			lvDownload.Invoke(new BookStarToy.Model.StatusNotify(StatusNotifyLocal), new Object[2] { oSender, oStatus });
		}

		/// <summary>
		/// 通知下载状态，由于工作线程不能调用UI线程的界面元素，使用异步模式
		/// </summary>
		/// <param name="oSender">通知发送者</param>
		/// <param name="oStatus">状态对象</param>
		void StatusNotifyLocal( Object oSender, Object oStatus )
		{
			ListViewItem lvi = null;
			BookStarToy.Model.Book book = null;
			for (int i = 0; i < lvDownload.Items.Count; i++)
			{
				lvi = lvDownload.Items[i];
				book = (BookStarToy.Model.Book)lvi.Tag;
				if (book == oSender)
					break;
			}

			//
			System.Diagnostics.Debug.Assert( lvi != null && book != null );
			BookStarToy.Model.BookStatusNotify bsn = (BookStarToy.Model.BookStatusNotify)oStatus;
			if (null != bsn.BookName)
				lvi.Text = bsn.BookName;

			//
			switch (book.Status)
			{
				case BookStarToy.Model.BookStatus.Init:
					lvi.SubItems[1].Text = "初始化";
					break;
				case BookStarToy.Model.BookStatus.Building:
					lvi.SubItems[1].Text = "创建中";
					break;
				case BookStarToy.Model.BookStatus.Pausing:
					lvi.SubItems[1].Text = "暂停";
					break;
				case BookStarToy.Model.BookStatus.Finished:
					lvi.SubItems[1].Text = "完成";
					break;
				case BookStarToy.Model.BookStatus.Error:
					lvi.SubItems[1].Text = "错误：" + book.Message;
					break;
			}

			//
			if ( bsn.TotalCount >= 0 || bsn.FinishedCount >= 0 )
				lvi.SubItems[2].Text = bsn.FinishedCount + "/" + bsn.TotalCount;

		}
	}
}

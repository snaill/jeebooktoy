/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2005-6-17
 * Time: 14:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace BookStarToy
{
	/// <summary>
	/// Description of NewBookForm.
	/// </summary>
	public class CreateBookForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cmbBookType;
		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.ListView lvAddin;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox txtBookName;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtWriter;
		private System.Windows.Forms.Button btnFinish;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCreator;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.ColumnHeader chValue;
		private System.Windows.Forms.TextBox txtBI;
		private System.Windows.Forms.ComboBox CompressTypeComboBox;

		/// <summary>图书信息类</summary>
		public BookStarToy.Model.Book		book;

		/// <summary>
		/// 构造函数
		/// </summary>
		public CreateBookForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			this.txtBI = new System.Windows.Forms.TextBox();
			this.chValue = new System.Windows.Forms.ColumnHeader();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label9 = new System.Windows.Forms.Label();
			this.CompressTypeComboBox = new System.Windows.Forms.ComboBox();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.label7 = new System.Windows.Forms.Label();
			this.lvAddin = new System.Windows.Forms.ListView();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.cmbBookType = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtCreator = new System.Windows.Forms.TextBox();
			this.txtSource = new System.Windows.Forms.TextBox();
			this.txtWriter = new System.Windows.Forms.TextBox();
			this.txtBookName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnFinish = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtBI
			// 
			this.txtBI.Location = new System.Drawing.Point(72, 128);
			this.txtBI.Multiline = true;
			this.txtBI.Name = "txtBI";
			this.txtBI.Size = new System.Drawing.Size(296, 64);
			this.txtBI.TabIndex = 23;
			// 
			// chValue
			// 
			this.chValue.Text = "值";
			this.chValue.Width = 213;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage3);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(5, 5);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(392, 334);
			this.tabControl.TabIndex = 0;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControlSelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.CompressTypeComboBox);
			this.tabPage1.Controls.Add(this.txtURL);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(384, 309);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "通用";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(8, 56);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 12);
			this.label9.TabIndex = 6;
			this.label9.Text = "压缩类型";
			// 
			// CompressTypeComboBox
			// 
			this.CompressTypeComboBox.DisplayMember = "0";
			this.CompressTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CompressTypeComboBox.FormattingEnabled = true;
			this.CompressTypeComboBox.Items.AddRange(new object[] {
            "无压缩",
            "压缩"});
			this.CompressTypeComboBox.Location = new System.Drawing.Point(8, 80);
			this.CompressTypeComboBox.Name = "CompressTypeComboBox";
			this.CompressTypeComboBox.Size = new System.Drawing.Size(136, 20);
			this.CompressTypeComboBox.TabIndex = 5;
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(8, 24);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(344, 21);
			this.txtURL.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "网址";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.label7);
			this.tabPage3.Controls.Add(this.lvAddin);
			this.tabPage3.Controls.Add(this.cmbBookType);
			this.tabPage3.Controls.Add(this.label6);
			this.tabPage3.Controls.Add(this.txtBI);
			this.tabPage3.Controls.Add(this.txtCreator);
			this.tabPage3.Controls.Add(this.txtSource);
			this.tabPage3.Controls.Add(this.txtWriter);
			this.tabPage3.Controls.Add(this.txtBookName);
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Controls.Add(this.label4);
			this.tabPage3.Controls.Add(this.label8);
			this.tabPage3.Location = new System.Drawing.Point(4, 21);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(384, 309);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "摘要";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 200);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 27;
			this.label7.Text = "附加信息";
			// 
			// lvAddin
			// 
			this.lvAddin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chValue});
			this.lvAddin.FullRowSelect = true;
			this.lvAddin.GridLines = true;
			this.lvAddin.Location = new System.Drawing.Point(72, 200);
			this.lvAddin.Name = "lvAddin";
			this.lvAddin.Size = new System.Drawing.Size(296, 104);
			this.lvAddin.TabIndex = 26;
			this.lvAddin.View = System.Windows.Forms.View.Details;
			// 
			// chName
			// 
			this.chName.Text = "名称";
			this.chName.Width = 77;
			// 
			// cmbBookType
			// 
			this.cmbBookType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBookType.FormattingEnabled = true;
			this.cmbBookType.Location = new System.Drawing.Point(72, 8);
			this.cmbBookType.Name = "cmbBookType";
			this.cmbBookType.Size = new System.Drawing.Size(296, 20);
			this.cmbBookType.TabIndex = 25;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 24;
			this.label6.Text = "图书类型";
			// 
			// txtCreator
			// 
			this.txtCreator.Location = new System.Drawing.Point(72, 104);
			this.txtCreator.Name = "txtCreator";
			this.txtCreator.Size = new System.Drawing.Size(296, 21);
			this.txtCreator.TabIndex = 21;
			// 
			// txtSource
			// 
			this.txtSource.Location = new System.Drawing.Point(72, 80);
			this.txtSource.Name = "txtSource";
			this.txtSource.Size = new System.Drawing.Size(296, 21);
			this.txtSource.TabIndex = 19;
			// 
			// txtWriter
			// 
			this.txtWriter.Location = new System.Drawing.Point(72, 56);
			this.txtWriter.Name = "txtWriter";
			this.txtWriter.Size = new System.Drawing.Size(296, 21);
			this.txtWriter.TabIndex = 17;
			// 
			// txtBookName
			// 
			this.txtBookName.Location = new System.Drawing.Point(72, 32);
			this.txtBookName.Name = "txtBookName";
			this.txtBookName.Size = new System.Drawing.Size(296, 21);
			this.txtBookName.TabIndex = 15;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 22;
			this.label5.Text = "简介";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 18;
			this.label3.Text = "来源";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 14;
			this.label2.Text = "书名";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 20;
			this.label4.Text = "创建者";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 56);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 16);
			this.label8.TabIndex = 16;
			this.label8.Text = "作者";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnFinish);
			this.panel1.Controls.Add(this.btnNext);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(5, 339);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(392, 32);
			this.panel1.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(304, 8);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnFinish
			// 
			this.btnFinish.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnFinish.Location = new System.Drawing.Point(224, 8);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.Size = new System.Drawing.Size(80, 23);
			this.btnFinish.TabIndex = 1;
			this.btnFinish.Text = "Finish";
			this.btnFinish.Click += new System.EventHandler(this.BtnFinishClick);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(144, 8);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(80, 23);
			this.btnNext.TabIndex = 3;
			this.btnNext.Text = "Next >>";
			this.btnNext.Click += new System.EventHandler(this.BtnNextClick);
			// 
			// CreateBookForm
			// 
			this.ClientSize = new System.Drawing.Size(402, 376);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreateBookForm";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "创建新图书";
			this.Load += new System.EventHandler(this.CreateBookFormLoad);
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		void BtnNextClick(object sender, System.EventArgs e)
		{
			tabControl.SelectedIndex += 1;
		}
		
		void TabControlSelectedIndexChanged(object sender, System.EventArgs e)
		{
			btnNext.Enabled = tabControl.SelectedIndex != tabControl.TabCount - 1;
		}
		
		void BtnCancelClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		void BtnFinishClick(object sender, System.EventArgs e)
		{
			// 
			BookStarToy.Model.BookParam param = new BookStarToy.Model.BookParam();
			BookStarToy.SBP.FileCompressType[] fct = ( BookStarToy.SBP.FileCompressType[] )CompressTypeComboBox.Tag;
			param.CompressType = fct[CompressTypeComboBox.SelectedIndex];
			
			//  摘要信息段
			BookStarToy.SBP.InfoSection infoSection = new BookStarToy.SBP.InfoSection();
			infoSection.BOOK_NAME = txtBookName.Text;
			infoSection.BOOK_WRITER = txtWriter.Text;
			infoSection.BOOK_SOURCE = txtSource.Text;
			infoSection.BOOK_CREATOR = txtCreator.Text;
			infoSection.BOOK_BI = txtBI.Text;
			infoSection.BOOK_ADDIN = "";
			infoSection.BOOK_TYPE = ( ( Guid[] )cmbBookType.Tag )[cmbBookType.SelectedIndex];

			//
			book = new BookStarToy.Model.Book( txtURL.Text, param, infoSection);
		}
		
		void CreateBookFormLoad(object sender, System.EventArgs e)
		{
			// 初始化压缩类型
			BookStarToy.SBP.FileCompressType[] fct = new BookStarToy.SBP.FileCompressType[]{ 
				BookStarToy.SBP.FileCompressType.Stored,
				BookStarToy.SBP.FileCompressType.Deflated
			};
			CompressTypeComboBox.Tag = fct;
			CompressTypeComboBox.SelectedIndex = 1;

			// 添加types.xml的类别信息
			System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("BookStarToy.Types.xml");  
			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
			doc.Load( stream );
			System.Xml.XmlNodeList nodeList = doc.DocumentElement.SelectNodes("type"); 
			Guid[] array = new Guid[nodeList.Count + 1];
			for ( int i = 1; i < nodeList.Count; i++ )
			{
				cmbBookType.Items.Add( nodeList[i].Attributes["name"].Value );  
				array[i] = new Guid( nodeList[i].Attributes["uid"].Value );  
			}

			// 添加默认的类别
			cmbBookType.Items.Insert(0, "未分类"); 
			array[0] = new Guid( 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 );
			cmbBookType.Tag = array;
			cmbBookType.SelectedIndex = 0;
		}
		
	}
}

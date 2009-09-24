using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BookStarToy
{
	/// <summary>
	/// WebParserForm 的摘要说明。
	/// </summary>
	public class WebParserForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox WebsiteComboBox;
		private System.Windows.Forms.ComboBox ValueComboBox;
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.Button ResetButton;
		private System.Windows.Forms.TextBox OperationTextBox;
		private System.Windows.Forms.TextBox RegexTextBox;
		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.TextBox SourceTextBox;
		private System.Windows.Forms.TextBox ResultTextBox;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private BookStarToy.Model.WebsiteManager WebsiteMgr = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public WebParserForm( BookStarToy.Model.WebsiteManager wm)
		{
			//
			WebsiteMgr = wm;

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
			this.SourceTextBox = new System.Windows.Forms.TextBox();
			this.ResultTextBox = new System.Windows.Forms.TextBox();
			this.WebsiteComboBox = new System.Windows.Forms.ComboBox();
			this.ValueComboBox = new System.Windows.Forms.ComboBox();
			this.StartButton = new System.Windows.Forms.Button();
			this.ResetButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.NextButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.RegexTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.OperationTextBox = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// SourceTextBox
			// 
			this.SourceTextBox.Location = new System.Drawing.Point(8, 144);
			this.SourceTextBox.MaxLength = 65534;
			this.SourceTextBox.Multiline = true;
			this.SourceTextBox.Name = "SourceTextBox";
			this.SourceTextBox.Size = new System.Drawing.Size(224, 200);
			this.SourceTextBox.TabIndex = 0;
			this.SourceTextBox.Text = "";
			// 
			// ResultTextBox
			// 
			this.ResultTextBox.Location = new System.Drawing.Point(240, 144);
			this.ResultTextBox.MaxLength = 65534;
			this.ResultTextBox.Multiline = true;
			this.ResultTextBox.Name = "ResultTextBox";
			this.ResultTextBox.Size = new System.Drawing.Size(224, 200);
			this.ResultTextBox.TabIndex = 1;
			this.ResultTextBox.Text = "";
			// 
			// WebsiteComboBox
			// 
			this.WebsiteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.WebsiteComboBox.Location = new System.Drawing.Point(0, 24);
			this.WebsiteComboBox.Name = "WebsiteComboBox";
			this.WebsiteComboBox.Size = new System.Drawing.Size(136, 20);
			this.WebsiteComboBox.TabIndex = 2;
			this.WebsiteComboBox.SelectedIndexChanged += new System.EventHandler(this.WebsiteComboBox_SelectedIndexChanged);
			// 
			// ValueComboBox
			// 
			this.ValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ValueComboBox.Location = new System.Drawing.Point(144, 24);
			this.ValueComboBox.Name = "ValueComboBox";
			this.ValueComboBox.Size = new System.Drawing.Size(136, 20);
			this.ValueComboBox.TabIndex = 3;
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(103, 96);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 24);
			this.StartButton.TabIndex = 4;
			this.StartButton.Text = "开始";
			// 
			// ResetButton
			// 
			this.ResetButton.Location = new System.Drawing.Point(279, 96);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(75, 24);
			this.ResetButton.TabIndex = 5;
			this.ResetButton.Text = "重设";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "网站";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(144, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "获取值";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.NextButton);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.RegexTextBox);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.OperationTextBox);
			this.panel1.Controls.Add(this.ValueComboBox);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.WebsiteComboBox);
			this.panel1.Controls.Add(this.ResetButton);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.StartButton);
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(456, 128);
			this.panel1.TabIndex = 8;
			// 
			// NextButton
			// 
			this.NextButton.Location = new System.Drawing.Point(191, 96);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size(75, 24);
			this.NextButton.TabIndex = 12;
			this.NextButton.Text = "下一步";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 11;
			this.label4.Text = "正则表达式";
			// 
			// RegexTextBox
			// 
			this.RegexTextBox.Location = new System.Drawing.Point(0, 64);
			this.RegexTextBox.Name = "RegexTextBox";
			this.RegexTextBox.Size = new System.Drawing.Size(456, 21);
			this.RegexTextBox.TabIndex = 10;
			this.RegexTextBox.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(296, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "操作";
			// 
			// OperationTextBox
			// 
			this.OperationTextBox.Location = new System.Drawing.Point(288, 24);
			this.OperationTextBox.Name = "OperationTextBox";
			this.OperationTextBox.Size = new System.Drawing.Size(168, 21);
			this.OperationTextBox.TabIndex = 8;
			this.OperationTextBox.Text = "";
			// 
			// WebParserForm
			// 
			this.ClientSize = new System.Drawing.Size(472, 350);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ResultTextBox);
			this.Controls.Add(this.SourceTextBox);
			this.DockPadding.All = 5;
			this.Name = "WebParserForm";
			this.Text = "WebParserForm";
			this.Load += new System.EventHandler(this.WebParserForm_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void WebParserForm_Load(object sender, System.EventArgs e)
		{
			BookStarToy.Model.Website ws = WebsiteMgr[0];
			for ( int i = 1; ws != null; i++ )
			{
				WebsiteComboBox.Items.Add( ws.SiteName );
	//			Website ws = WebsiteMgr[i];
			}
			WebsiteComboBox.SelectedIndex = 0;
		}

		private void WebsiteComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BookStarToy.Model.Website ws = WebsiteMgr[ WebsiteComboBox.SelectedIndex ];
		//	ws.
		//	ValueComboBox.Items.Add( 
		}
	}
}

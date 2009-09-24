using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BookStarToy
{
	/// <summary>
	/// OptionsForm 的摘要说明。
	/// </summary>
	public class OptionsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public OptionsForm()
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(432, 264);
			this.tabControl1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(272, 280);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(352, 280);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "button2";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(424, 239);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "通用";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "简书保存路径";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(320, 21);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "textBox1";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(336, 32);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(40, 24);
			this.button3.TabIndex = 2;
			this.button3.Text = "button3";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 72);
			this.label2.Name = "label2";
			this.label2.TabIndex = 3;
			this.label2.Text = "默认创建者";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 96);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(376, 21);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = "textBox2";
			// 
			// OptionsForm
			// 
			this.ClientSize = new System.Drawing.Size(432, 310);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tabControl1);
			this.Name = "OptionsForm";
			this.Text = "OptionsForm";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BookStarToy
{
	/// <summary>
	/// AttributeForm ��ժҪ˵����
	/// </summary>
	public class AttributeForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListView lvAddin;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.ColumnHeader chValue;
		private System.Windows.Forms.TextBox txtBookName;
		private System.Windows.Forms.TextBox txtWriter;
		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.TextBox txtCreator;
		private System.Windows.Forms.TextBox txtBI;
		private System.Windows.Forms.ComboBox cmbBookType;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// ���캯��
		/// </summary>
		public AttributeForm()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtBookName = new System.Windows.Forms.TextBox();
			this.txtWriter = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSource = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCreator = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtBI = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbBookType = new System.Windows.Forms.ComboBox();
			this.lvAddin = new System.Windows.Forms.ListView();
			this.label7 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.chValue = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "����";
			// 
			// txtBookName
			// 
			this.txtBookName.Location = new System.Drawing.Point(64, 32);
			this.txtBookName.Name = "txtBookName";
			this.txtBookName.Size = new System.Drawing.Size(296, 21);
			this.txtBookName.TabIndex = 1;
			this.txtBookName.Text = "textBox1";
			// 
			// txtWriter
			// 
			this.txtWriter.Location = new System.Drawing.Point(64, 56);
			this.txtWriter.Name = "txtWriter";
			this.txtWriter.Size = new System.Drawing.Size(296, 21);
			this.txtWriter.TabIndex = 3;
			this.txtWriter.Text = "textBox2";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "����";
			// 
			// txtSource
			// 
			this.txtSource.Location = new System.Drawing.Point(64, 80);
			this.txtSource.Name = "txtSource";
			this.txtSource.Size = new System.Drawing.Size(296, 21);
			this.txtSource.TabIndex = 5;
			this.txtSource.Text = "textBox3";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "��Դ";
			// 
			// txtCreator
			// 
			this.txtCreator.Location = new System.Drawing.Point(64, 104);
			this.txtCreator.Name = "txtCreator";
			this.txtCreator.Size = new System.Drawing.Size(296, 21);
			this.txtCreator.TabIndex = 7;
			this.txtCreator.Text = "textBox4";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "������";
			// 
			// txtBI
			// 
			this.txtBI.Location = new System.Drawing.Point(64, 128);
			this.txtBI.Multiline = true;
			this.txtBI.Name = "txtBI";
			this.txtBI.Size = new System.Drawing.Size(296, 64);
			this.txtBI.TabIndex = 9;
			this.txtBI.Text = "textBox5";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "���";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "ͼ������";
			// 
			// cmbBookType
			// 
			this.cmbBookType.Location = new System.Drawing.Point(64, 8);
			this.cmbBookType.Name = "cmbBookType";
			this.cmbBookType.Size = new System.Drawing.Size(296, 20);
			this.cmbBookType.TabIndex = 11;
			this.cmbBookType.Text = "comboBox1";
			// 
			// lvAddin
			// 
			this.lvAddin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
												      this.chName,
												      this.chValue});
			this.lvAddin.FullRowSelect = true;
			this.lvAddin.GridLines = true;
			this.lvAddin.Location = new System.Drawing.Point(64, 200);
			this.lvAddin.Name = "lvAddin";
			this.lvAddin.Size = new System.Drawing.Size(296, 88);
			this.lvAddin.TabIndex = 12;
			this.lvAddin.View = System.Windows.Forms.View.Details;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 200);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 13;
			this.label7.Text = "������Ϣ";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(144, 296);
			this.button1.Name = "button1";
			this.button1.TabIndex = 14;
			this.button1.Text = "button1";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(256, 296);
			this.button2.Name = "button2";
			this.button2.TabIndex = 15;
			this.button2.Text = "button2";
			// 
			// chName
			// 
			this.chName.Text = "����";
			this.chName.Width = 77;
			// 
			// chValue
			// 
			this.chValue.Text = "ֵ";
			this.chValue.Width = 211;
			// 
			// AttributeForm
			// 
			this.ClientSize = new System.Drawing.Size(368, 326);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.lvAddin);
			this.Controls.Add(this.cmbBookType);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtBI);
			this.Controls.Add(this.txtCreator);
			this.Controls.Add(this.txtSource);
			this.Controls.Add(this.txtWriter);
			this.Controls.Add(this.txtBookName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "AttributeForm";
			this.Text = "AttributeForm";
			this.ResumeLayout(false);

		}
		#endregion
	}
}

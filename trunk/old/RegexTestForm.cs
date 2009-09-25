using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace BookStarToy
{
	/// <summary>
	/// RegexTestForm 的摘要说明。
	/// </summary>
	public class RegexTestForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button MatchesButton;
		private System.Windows.Forms.Button TestRegexButton;
		private System.Windows.Forms.Button ReplaceButton;
		private System.Windows.Forms.Button SplitButton;
		private System.Windows.Forms.GroupBox OptionsGroup;
		private System.Windows.Forms.CheckBox ECMAScriptChkBox;
		private System.Windows.Forms.CheckBox ExplicitCaptureChkBox;
		private System.Windows.Forms.CheckBox IgnoreCaseChkBox;
		private System.Windows.Forms.CheckBox MultiLineChkBox;
		private System.Windows.Forms.CheckBox RightToLeftChkBox;
		private System.Windows.Forms.CheckBox SingleLineChkBox;
		private System.Windows.Forms.CheckBox IgnorePatternWhitespaceChkBox;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.TextBox RegexTextBox;
		private System.Windows.Forms.TextBox InputTextBox;
		private System.Windows.Forms.TextBox ReplacementTextBox;
		private System.Windows.Forms.TextBox ResultsTextBox;
		private System.Windows.Forms.Button GroupsButton;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem OpenRegexMenuItem;
		private System.Windows.Forms.MenuItem TestRegexMenuItem;
		private System.Windows.Forms.MenuItem ReplaceMenuItem;
		private System.Windows.Forms.MenuItem MatchesMenuItem;
		private System.Windows.Forms.MenuItem SplitMenuItem;
		private System.Windows.Forms.MenuItem GroupsMenuItem;
		private System.Windows.Forms.MenuItem SaveRegexMenuItem;
		private System.Windows.Forms.MenuItem ClearMenuItem;
		private System.Windows.Forms.MenuItem EmptyInputMenuItem;
		private System.Windows.Forms.MenuItem EmptyResultMenuItem;
		private System.Windows.Forms.MenuItem Result2InputMenuItem;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		public RegexTestForm()
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
			this.RegexTextBox = new System.Windows.Forms.TextBox();
			this.InputTextBox = new System.Windows.Forms.TextBox();
			this.ReplacementTextBox = new System.Windows.Forms.TextBox();
			this.ResultsTextBox = new System.Windows.Forms.TextBox();
			this.MatchesButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.TestRegexButton = new System.Windows.Forms.Button();
			this.ReplaceButton = new System.Windows.Forms.Button();
			this.SplitButton = new System.Windows.Forms.Button();
			this.OptionsGroup = new System.Windows.Forms.GroupBox();
			this.IgnorePatternWhitespaceChkBox = new System.Windows.Forms.CheckBox();
			this.SingleLineChkBox = new System.Windows.Forms.CheckBox();
			this.RightToLeftChkBox = new System.Windows.Forms.CheckBox();
			this.MultiLineChkBox = new System.Windows.Forms.CheckBox();
			this.IgnoreCaseChkBox = new System.Windows.Forms.CheckBox();
			this.ExplicitCaptureChkBox = new System.Windows.Forms.CheckBox();
			this.ECMAScriptChkBox = new System.Windows.Forms.CheckBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.GroupsButton = new System.Windows.Forms.Button();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.OpenRegexMenuItem = new System.Windows.Forms.MenuItem();
			this.SaveRegexMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.TestRegexMenuItem = new System.Windows.Forms.MenuItem();
			this.ReplaceMenuItem = new System.Windows.Forms.MenuItem();
			this.SplitMenuItem = new System.Windows.Forms.MenuItem();
			this.MatchesMenuItem = new System.Windows.Forms.MenuItem();
			this.GroupsMenuItem = new System.Windows.Forms.MenuItem();
			this.ClearMenuItem = new System.Windows.Forms.MenuItem();
			this.EmptyInputMenuItem = new System.Windows.Forms.MenuItem();
			this.EmptyResultMenuItem = new System.Windows.Forms.MenuItem();
			this.Result2InputMenuItem = new System.Windows.Forms.MenuItem();
			this.OptionsGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// RegexTextBox
			// 
			this.RegexTextBox.Location = new System.Drawing.Point(8, 24);
			this.RegexTextBox.Multiline = true;
			this.RegexTextBox.Name = "RegexTextBox";
			this.RegexTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.RegexTextBox.Size = new System.Drawing.Size(320, 56);
			this.RegexTextBox.TabIndex = 0;
			this.RegexTextBox.Text = "";
			// 
			// InputTextBox
			// 
			this.InputTextBox.Location = new System.Drawing.Point(336, 24);
			this.InputTextBox.MaxLength = 65534;
			this.InputTextBox.Multiline = true;
			this.InputTextBox.Name = "InputTextBox";
			this.InputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.InputTextBox.Size = new System.Drawing.Size(240, 304);
			this.InputTextBox.TabIndex = 1;
			this.InputTextBox.Text = "";
			// 
			// ReplacementTextBox
			// 
			this.ReplacementTextBox.Location = new System.Drawing.Point(8, 208);
			this.ReplacementTextBox.Multiline = true;
			this.ReplacementTextBox.Name = "ReplacementTextBox";
			this.ReplacementTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ReplacementTextBox.Size = new System.Drawing.Size(320, 40);
			this.ReplacementTextBox.TabIndex = 2;
			this.ReplacementTextBox.Text = "";
			// 
			// ResultsTextBox
			// 
			this.ResultsTextBox.Location = new System.Drawing.Point(8, 272);
			this.ResultsTextBox.Multiline = true;
			this.ResultsTextBox.Name = "ResultsTextBox";
			this.ResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ResultsTextBox.Size = new System.Drawing.Size(320, 56);
			this.ResultsTextBox.TabIndex = 3;
			this.ResultsTextBox.Text = "";
			// 
			// MatchesButton
			// 
			this.MatchesButton.Location = new System.Drawing.Point(359, 336);
			this.MatchesButton.Name = "MatchesButton";
			this.MatchesButton.TabIndex = 4;
			this.MatchesButton.Text = "Matches()";
			this.MatchesButton.Click += new System.EventHandler(this.MatchesButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Regular Expression";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(336, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Text to Match On";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 192);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Replacement Text";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 256);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Result of Match";
			// 
			// TestRegexButton
			// 
			this.TestRegexButton.Location = new System.Drawing.Point(95, 336);
			this.TestRegexButton.Name = "TestRegexButton";
			this.TestRegexButton.TabIndex = 9;
			this.TestRegexButton.Text = "IsMatch()";
			this.TestRegexButton.Click += new System.EventHandler(this.TestRegexButton_Click);
			// 
			// ReplaceButton
			// 
			this.ReplaceButton.Location = new System.Drawing.Point(183, 336);
			this.ReplaceButton.Name = "ReplaceButton";
			this.ReplaceButton.TabIndex = 10;
			this.ReplaceButton.Text = "Replace()";
			this.ReplaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
			// 
			// SplitButton
			// 
			this.SplitButton.Location = new System.Drawing.Point(271, 336);
			this.SplitButton.Name = "SplitButton";
			this.SplitButton.TabIndex = 11;
			this.SplitButton.Text = "Split()";
			this.SplitButton.Click += new System.EventHandler(this.SplitButton_Click);
			// 
			// OptionsGroup
			// 
			this.OptionsGroup.Controls.Add(this.IgnorePatternWhitespaceChkBox);
			this.OptionsGroup.Controls.Add(this.SingleLineChkBox);
			this.OptionsGroup.Controls.Add(this.RightToLeftChkBox);
			this.OptionsGroup.Controls.Add(this.MultiLineChkBox);
			this.OptionsGroup.Controls.Add(this.IgnoreCaseChkBox);
			this.OptionsGroup.Controls.Add(this.ExplicitCaptureChkBox);
			this.OptionsGroup.Controls.Add(this.ECMAScriptChkBox);
			this.OptionsGroup.Location = new System.Drawing.Point(8, 88);
			this.OptionsGroup.Name = "OptionsGroup";
			this.OptionsGroup.Size = new System.Drawing.Size(320, 96);
			this.OptionsGroup.TabIndex = 12;
			this.OptionsGroup.TabStop = false;
			this.OptionsGroup.Text = "Regex Options";
			// 
			// IgnorePatternWhitespaceChkBox
			// 
			this.IgnorePatternWhitespaceChkBox.Location = new System.Drawing.Point(16, 64);
			this.IgnorePatternWhitespaceChkBox.Name = "IgnorePatternWhitespaceChkBox";
			this.IgnorePatternWhitespaceChkBox.Size = new System.Drawing.Size(184, 24);
			this.IgnorePatternWhitespaceChkBox.TabIndex = 6;
			this.IgnorePatternWhitespaceChkBox.Text = "IgnorePatternWhitespace";
			// 
			// SingleLineChkBox
			// 
			this.SingleLineChkBox.Location = new System.Drawing.Point(224, 40);
			this.SingleLineChkBox.Name = "SingleLineChkBox";
			this.SingleLineChkBox.Size = new System.Drawing.Size(88, 24);
			this.SingleLineChkBox.TabIndex = 5;
			this.SingleLineChkBox.Text = "SingleLine";
			// 
			// RightToLeftChkBox
			// 
			this.RightToLeftChkBox.Location = new System.Drawing.Point(104, 40);
			this.RightToLeftChkBox.Name = "RightToLeftChkBox";
			this.RightToLeftChkBox.TabIndex = 4;
			this.RightToLeftChkBox.Text = "RightToLeft";
			// 
			// MultiLineChkBox
			// 
			this.MultiLineChkBox.Location = new System.Drawing.Point(16, 40);
			this.MultiLineChkBox.Name = "MultiLineChkBox";
			this.MultiLineChkBox.Size = new System.Drawing.Size(88, 24);
			this.MultiLineChkBox.TabIndex = 3;
			this.MultiLineChkBox.Text = "MultiLine";
			// 
			// IgnoreCaseChkBox
			// 
			this.IgnoreCaseChkBox.Location = new System.Drawing.Point(224, 16);
			this.IgnoreCaseChkBox.Name = "IgnoreCaseChkBox";
			this.IgnoreCaseChkBox.Size = new System.Drawing.Size(88, 24);
			this.IgnoreCaseChkBox.TabIndex = 2;
			this.IgnoreCaseChkBox.Text = "IgnoreCase";
			// 
			// ExplicitCaptureChkBox
			// 
			this.ExplicitCaptureChkBox.Location = new System.Drawing.Point(104, 16);
			this.ExplicitCaptureChkBox.Name = "ExplicitCaptureChkBox";
			this.ExplicitCaptureChkBox.Size = new System.Drawing.Size(128, 24);
			this.ExplicitCaptureChkBox.TabIndex = 1;
			this.ExplicitCaptureChkBox.Text = "Explicit Capture";
			// 
			// ECMAScriptChkBox
			// 
			this.ECMAScriptChkBox.Location = new System.Drawing.Point(16, 16);
			this.ECMAScriptChkBox.Name = "ECMAScriptChkBox";
			this.ECMAScriptChkBox.Size = new System.Drawing.Size(88, 24);
			this.ECMAScriptChkBox.TabIndex = 0;
			this.ECMAScriptChkBox.Text = "ECMAScript";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
			// 
			// GroupsButton
			// 
			this.GroupsButton.Location = new System.Drawing.Point(447, 336);
			this.GroupsButton.Name = "GroupsButton";
			this.GroupsButton.TabIndex = 15;
			this.GroupsButton.Text = "Groups()";
			this.GroupsButton.Click += new System.EventHandler(this.GroupsButton_Click);
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
												     this.menuItem1,
												     this.menuItem2,
												     this.ClearMenuItem});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
												      this.OpenRegexMenuItem,
												      this.SaveRegexMenuItem});
			this.menuItem1.Text = "File";
			// 
			// OpenRegexMenuItem
			// 
			this.OpenRegexMenuItem.Index = 0;
			this.OpenRegexMenuItem.Text = "Open Regex";
			this.OpenRegexMenuItem.Click += new System.EventHandler(this.OpenRegexButton_Click);
			// 
			// SaveRegexMenuItem
			// 
			this.SaveRegexMenuItem.Index = 1;
			this.SaveRegexMenuItem.Text = "Save Regex";
			this.SaveRegexMenuItem.Click += new System.EventHandler(this.SaveRegexButton_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
												      this.TestRegexMenuItem,
												      this.ReplaceMenuItem,
												      this.SplitMenuItem,
												      this.MatchesMenuItem,
												      this.GroupsMenuItem});
			this.menuItem2.Text = "Operation";
			// 
			// TestRegexMenuItem
			// 
			this.TestRegexMenuItem.Index = 0;
			this.TestRegexMenuItem.Text = "IsMatch()";
			this.TestRegexMenuItem.Click += new System.EventHandler(this.TestRegexButton_Click);
			// 
			// ReplaceMenuItem
			// 
			this.ReplaceMenuItem.Index = 1;
			this.ReplaceMenuItem.Text = "Replace()";
			this.ReplaceMenuItem.Click += new System.EventHandler(this.ReplaceButton_Click);
			// 
			// SplitMenuItem
			// 
			this.SplitMenuItem.Index = 2;
			this.SplitMenuItem.Text = "Split()";
			this.SplitMenuItem.Click += new System.EventHandler(this.SplitButton_Click);
			// 
			// MatchesMenuItem
			// 
			this.MatchesMenuItem.Index = 3;
			this.MatchesMenuItem.Text = "Matches()";
			this.MatchesMenuItem.Click += new System.EventHandler(this.MatchesButton_Click);
			// 
			// GroupsMenuItem
			// 
			this.GroupsMenuItem.Index = 4;
			this.GroupsMenuItem.Text = "Groups()";
			this.GroupsMenuItem.Click += new System.EventHandler(this.GroupsButton_Click);
			// 
			// ClearMenuItem
			// 
			this.ClearMenuItem.Index = 2;
			this.ClearMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
													  this.EmptyInputMenuItem,
													  this.EmptyResultMenuItem,
													  this.Result2InputMenuItem});
			this.ClearMenuItem.Text = "Clear";
			// 
			// EmptyInputMenuItem
			// 
			this.EmptyInputMenuItem.Index = 0;
			this.EmptyInputMenuItem.Text = "Input => NULL";
			this.EmptyInputMenuItem.Click += new System.EventHandler(this.EmptyInputMenuItem_Click);
			// 
			// EmptyResultMenuItem
			// 
			this.EmptyResultMenuItem.Index = 1;
			this.EmptyResultMenuItem.Text = "Result => NULL";
			this.EmptyResultMenuItem.Click += new System.EventHandler(this.EmptyResultMenuItem_Click);
			// 
			// Result2InputMenuItem
			// 
			this.Result2InputMenuItem.Index = 2;
			this.Result2InputMenuItem.Text = "Result => Input";
			this.Result2InputMenuItem.Click += new System.EventHandler(this.Result2InputMenuItem_Click);
			// 
			// RegexTestForm
			// 
			this.ClientSize = new System.Drawing.Size(584, 366);
			this.Controls.Add(this.GroupsButton);
			this.Controls.Add(this.OptionsGroup);
			this.Controls.Add(this.SplitButton);
			this.Controls.Add(this.ReplaceButton);
			this.Controls.Add(this.TestRegexButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.MatchesButton);
			this.Controls.Add(this.ResultsTextBox);
			this.Controls.Add(this.ReplacementTextBox);
			this.Controls.Add(this.InputTextBox);
			this.Controls.Add(this.RegexTextBox);
			this.Menu = this.mainMenu;
			this.Name = "RegexTestForm";
			this.Text = "RegexTestForm";
			this.OptionsGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void SaveRegexButton_Click(object sender, System.EventArgs e)
		{
			saveFileDialog.ShowDialog();
		}

		private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			StreamWriter sw = File.CreateText( saveFileDialog.FileName );
			sw.Write( RegexTextBox.Text );
			sw.Close();
		}

		private void OpenRegexButton_Click(object sender, System.EventArgs e)
		{
			openFileDialog.ShowDialog();
		}

		private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			StreamReader	sr = File.OpenText( openFileDialog.FileName );
			RegexTextBox.Text = sr.ReadToEnd();
			sr.Close();
		}

		private RegexOptions GetSelectedRegexOptions()
		{
			RegexOptions sro = RegexOptions.None;

			if ( this.IgnoreCaseChkBox.Checked )
				sro |= RegexOptions.IgnoreCase;

			if ( this.ExplicitCaptureChkBox.Checked )
				sro |= RegexOptions.ExplicitCapture;

			if ( this.ECMAScriptChkBox.Checked )
				sro |= RegexOptions.ECMAScript;

			if ( this.IgnorePatternWhitespaceChkBox.Checked )
				sro |= RegexOptions.IgnorePatternWhitespace;

			if ( this.MultiLineChkBox.Checked )
				sro |= RegexOptions.Multiline;

			if ( this.SingleLineChkBox.Checked )
				sro |= RegexOptions.Singleline;

			if ( this.RightToLeftChkBox.Checked )
				sro |= RegexOptions.RightToLeft;

			return sro;
		}

		private void TestRegexButton_Click(object sender, System.EventArgs e)
		{
			try 
			{
				RegexOptions sro = this.GetSelectedRegexOptions();

				Regex reg = new Regex( this.RegexTextBox.Text, sro );
				if ( reg.IsMatch( this.InputTextBox.Text ) )
				{
					this.ResultsTextBox.ForeColor = Color.Black;
					this.ResultsTextBox.Text = "Match Found";
				}
				else
				{
					this.ResultsTextBox.ForeColor = Color.Red;
					this.ResultsTextBox.Text = "No Match Found";
				}
			}
			catch ( ArgumentException ex )
			{
				this.ResultsTextBox.ForeColor = Color.Red;
				this.ResultsTextBox.Text = "There was an error in your regular expression\r\n" + ex.Message;
			}
		}

		private void ReplaceButton_Click(object sender, System.EventArgs e)
		{
			try 
			{
				RegexOptions sro = this.GetSelectedRegexOptions();

				Regex reg = new Regex( this.RegexTextBox.Text, sro );
				this.ResultsTextBox.ForeColor = Color.Black;
				this.ResultsTextBox.Text = reg.Replace( this.InputTextBox.Text, this.ReplacementTextBox.Text );
			}
			catch ( ArgumentException ex )
			{
				this.ResultsTextBox.ForeColor = Color.Red;
				this.ResultsTextBox.Text = "There was an error in your regular expression\r\n" + ex.Message;
			}
		
		}

		private void SplitButton_Click(object sender, System.EventArgs e)
		{
			try 
			{
				RegexOptions sro = this.GetSelectedRegexOptions();

				Regex reg = new Regex( this.RegexTextBox.Text, sro );
				string[] splitResults = reg.Split( this.InputTextBox.Text );
				StringBuilder sb = new StringBuilder( this.InputTextBox.Text.Length );
				foreach( String str in splitResults )
					sb.Append( str + Environment.NewLine );

				this.ResultsTextBox.ForeColor = Color.Black;
				this.ResultsTextBox.Text = sb.ToString(); 
			}
			catch ( ArgumentException ex )
			{
				this.ResultsTextBox.ForeColor = Color.Red;
				this.ResultsTextBox.Text = "There was an error in your regular expression\r\n" + ex.Message;
			}		
		}

		private void MatchesButton_Click(object sender, System.EventArgs e)
		{
			try 
			{
				RegexOptions sro = this.GetSelectedRegexOptions();

				Regex reg = new Regex( this.RegexTextBox.Text, sro );

				MatchCollection mc = reg.Matches( this.InputTextBox.Text );

				String nextMatch = "---------- Next Match ----------\r\n";
				StringBuilder sb = new StringBuilder( 64 );
				foreach( Match m in mc )
					sb.Append( m.Value + ( Environment.NewLine + nextMatch ) );

				this.ResultsTextBox.ForeColor = Color.Black;
				this.ResultsTextBox.Text = sb.ToString(); 
			}
			catch ( ArgumentException ex )
			{
				this.ResultsTextBox.ForeColor = Color.Red;
				this.ResultsTextBox.Text = "There was an error in your regular expression\r\n" + ex.Message;
			}		
		}

		private void GroupsButton_Click(object sender, System.EventArgs e)
		{
			try 
			{
				RegexOptions sro = this.GetSelectedRegexOptions();

				Regex reg = new Regex( this.RegexTextBox.Text, sro );

				MatchCollection mc = reg.Matches( this.InputTextBox.Text );
				StringBuilder sb = new StringBuilder( 64 );

				foreach( Match m in mc )
				{
					GroupCollection gc = m.Groups;
					for( int i = 1; i < gc.Count; i++ )
						sb.Append( "Group" + gc[i].Index + ":" + gc[i].Value + "\r\n" );
					sb.Append( "---------- Next Match ----------\r\n" );
				}

				this.ResultsTextBox.ForeColor = Color.Black;
				this.ResultsTextBox.Text = sb.ToString(); 
			}
			catch ( ArgumentException ex )
			{
				this.ResultsTextBox.ForeColor = Color.Red;
				this.ResultsTextBox.Text = "There was an error in your regular expression\r\n" + ex.Message;
			}				
		}

		private void EmptyInputMenuItem_Click(object sender, System.EventArgs e)
		{
			this.InputTextBox.Text = "";
		}

		private void EmptyResultMenuItem_Click(object sender, System.EventArgs e)
		{
			this.ResultsTextBox.Text = "";
		}

		private void Result2InputMenuItem_Click(object sender, System.EventArgs e)
		{
			this.InputTextBox.Text = this.ResultsTextBox.Text;
		}
	}
}

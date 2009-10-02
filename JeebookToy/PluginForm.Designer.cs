/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/1
 * Time: 12:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace JeebookToy
{
	partial class PluginForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.PluginsComboBox = new System.Windows.Forms.ComboBox();
			this.XslComboBox = new System.Windows.Forms.ComboBox();
			this.SourceTextBox = new System.Windows.Forms.TextBox();
			this.TargetTextBox = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.CreateButton = new System.Windows.Forms.Button();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// PluginsComboBox
			// 
			this.PluginsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PluginsComboBox.FormattingEnabled = true;
			this.PluginsComboBox.Location = new System.Drawing.Point(3, 3);
			this.PluginsComboBox.Name = "PluginsComboBox";
			this.PluginsComboBox.Size = new System.Drawing.Size(234, 21);
			this.PluginsComboBox.TabIndex = 0;
			this.PluginsComboBox.SelectedIndexChanged += new System.EventHandler(this.PluginsComboBoxSelectedIndexChanged);
			// 
			// XslComboBox
			// 
			this.XslComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.XslComboBox.FormattingEnabled = true;
			this.XslComboBox.Location = new System.Drawing.Point(243, 3);
			this.XslComboBox.Name = "XslComboBox";
			this.XslComboBox.Size = new System.Drawing.Size(121, 21);
			this.XslComboBox.TabIndex = 1;
			// 
			// SourceTextBox
			// 
			this.SourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SourceTextBox.Location = new System.Drawing.Point(0, 0);
			this.SourceTextBox.Multiline = true;
			this.SourceTextBox.Name = "SourceTextBox";
			this.SourceTextBox.Size = new System.Drawing.Size(225, 266);
			this.SourceTextBox.TabIndex = 2;
			this.SourceTextBox.DoubleClick += new System.EventHandler(this.SourceTextBoxDoubleClick);
			// 
			// TargetTextBox
			// 
			this.TargetTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TargetTextBox.Location = new System.Drawing.Point(0, 0);
			this.TargetTextBox.Multiline = true;
			this.TargetTextBox.Name = "TargetTextBox";
			this.TargetTextBox.ReadOnly = true;
			this.TargetTextBox.Size = new System.Drawing.Size(230, 266);
			this.TargetTextBox.TabIndex = 3;
			this.TargetTextBox.DoubleClick += new System.EventHandler(this.TargetTextBoxDoubleClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 32);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.SourceTextBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.TargetTextBox);
			this.splitContainer1.Size = new System.Drawing.Size(459, 266);
			this.splitContainer1.SplitterDistance = 225;
			this.splitContainer1.TabIndex = 4;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.PluginsComboBox);
			this.flowLayoutPanel1.Controls.Add(this.XslComboBox);
			this.flowLayoutPanel1.Controls.Add(this.CreateButton);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(459, 32);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// CreateButton
			// 
			this.CreateButton.Location = new System.Drawing.Point(370, 3);
			this.CreateButton.Name = "CreateButton";
			this.CreateButton.Size = new System.Drawing.Size(75, 23);
			this.CreateButton.TabIndex = 0;
			this.CreateButton.Text = "Create";
			this.CreateButton.UseVisualStyleBackColor = true;
			this.CreateButton.Click += new System.EventHandler(this.CreateButtonClick);
			// 
			// PluginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 298);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "PluginForm";
			this.ShowInTaskbar = false;
			this.Text = "PluginForm";
			this.Load += new System.EventHandler(this.PluginFormLoad);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox SourceTextBox;
		private System.Windows.Forms.TextBox TargetTextBox;
		private System.Windows.Forms.Button CreateButton;
		private System.Windows.Forms.ComboBox PluginsComboBox;
		private System.Windows.Forms.ComboBox XslComboBox;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}

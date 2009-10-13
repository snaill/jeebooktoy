/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-10-9
 * Time: 13:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace JeebookToy
{
	partial class EditorForm
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.UriTextBox = new System.Windows.Forms.TextBox();
			this.OpenButton = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.ContextTextBox = new System.Windows.Forms.TextBox();
			this.ContentTreeView = new System.Windows.Forms.TreeView();
			this.flowLayoutPanel1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.UriTextBox);
			this.flowLayoutPanel1.Controls.Add(this.OpenButton);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(292, 32);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// UriTextBox
			// 
			this.UriTextBox.Location = new System.Drawing.Point(3, 3);
			this.UriTextBox.Name = "UriTextBox";
			this.UriTextBox.Size = new System.Drawing.Size(201, 21);
			this.UriTextBox.TabIndex = 0;
			// 
			// OpenButton
			// 
			this.OpenButton.Location = new System.Drawing.Point(210, 3);
			this.OpenButton.Name = "OpenButton";
			this.OpenButton.Size = new System.Drawing.Size(75, 23);
			this.OpenButton.TabIndex = 1;
			this.OpenButton.Text = "Open";
			this.OpenButton.UseVisualStyleBackColor = true;
			this.OpenButton.Click += new System.EventHandler(this.OpenButtonClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 32);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.ContentTreeView);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.ContextTextBox);
			this.splitContainer1.Size = new System.Drawing.Size(292, 234);
			this.splitContainer1.SplitterDistance = 97;
			this.splitContainer1.TabIndex = 1;
			// 
			// ContextTextBox
			// 
			this.ContextTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ContextTextBox.Location = new System.Drawing.Point(0, 0);
			this.ContextTextBox.Multiline = true;
			this.ContextTextBox.Name = "ContextTextBox";
			this.ContextTextBox.Size = new System.Drawing.Size(191, 234);
			this.ContextTextBox.TabIndex = 0;
			// 
			// ContentTreeView
			// 
			this.ContentTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ContentTreeView.Location = new System.Drawing.Point(0, 0);
			this.ContentTreeView.Name = "ContentTreeView";
			this.ContentTreeView.Size = new System.Drawing.Size(97, 234);
			this.ContentTreeView.TabIndex = 0;
			this.ContentTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ContentTreeViewAfterSelect);
			// 
			// EditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "EditorForm";
			this.Text = "EditorForm";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox ContextTextBox;
		private System.Windows.Forms.TreeView ContentTreeView;
		private System.Windows.Forms.Button OpenButton;
		private System.Windows.Forms.TextBox UriTextBox;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}

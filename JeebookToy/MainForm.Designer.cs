/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-25
 * Time: 16:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace JeebookToy
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.UrlTextBox = new System.Windows.Forms.TextBox();
			this.TaskListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.TaskStateImageList = new System.Windows.Forms.ImageList(this.components);
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.AddButton = new JeebookToy.Controls.SplitButton();
			this.SplitButtonMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.PluginTestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flowLayoutPanel1.SuspendLayout();
			this.SplitButtonMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// UrlTextBox
			// 
			this.UrlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.UrlTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UrlTextBox.Location = new System.Drawing.Point(3, 3);
			this.UrlTextBox.Name = "UrlTextBox";
			this.UrlTextBox.Size = new System.Drawing.Size(328, 26);
			this.UrlTextBox.TabIndex = 0;
			// 
			// TaskListView
			// 
			this.TaskListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.TaskListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TaskListView.FullRowSelect = true;
			this.TaskListView.Location = new System.Drawing.Point(0, 31);
			this.TaskListView.Name = "TaskListView";
			this.TaskListView.Size = new System.Drawing.Size(419, 218);
			this.TaskListView.SmallImageList = this.TaskStateImageList;
			this.TaskListView.TabIndex = 0;
			this.TaskListView.UseCompatibleStateImageBehavior = false;
			this.TaskListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 80;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Status";
			this.columnHeader2.Width = 250;
			// 
			// TaskStateImageList
			// 
			this.TaskStateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TaskStateImageList.ImageStream")));
			this.TaskStateImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.TaskStateImageList.Images.SetKeyName(0, "Finished");
			this.TaskStateImageList.Images.SetKeyName(1, "Failed");
			this.TaskStateImageList.Images.SetKeyName(2, "Packaging");
			this.TaskStateImageList.Images.SetKeyName(3, "Downloading");
			this.TaskStateImageList.Images.SetKeyName(4, "ToXHtml");
			this.TaskStateImageList.Images.SetKeyName(5, "ToJeebook");
			this.TaskStateImageList.Images.SetKeyName(6, "Ready");
			// 
			// StatusStrip
			// 
			this.StatusStrip.Location = new System.Drawing.Point(0, 249);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(419, 22);
			this.StatusStrip.TabIndex = 3;
			this.StatusStrip.Text = "StatusStrip";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.UrlTextBox);
			this.flowLayoutPanel1.Controls.Add(this.AddButton);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(419, 31);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// AddButton
			// 
			this.AddButton.ClickedImage = "Clicked";
			this.AddButton.ContextMenuStrip = this.SplitButtonMenuStrip;
			this.AddButton.DisabledImage = "Disabled";
			this.AddButton.FocusedImage = "Focused";
			this.AddButton.HoverImage = "Hover";
			this.AddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.AddButton.ImageKey = "Normal";
			this.AddButton.Location = new System.Drawing.Point(337, 3);
			this.AddButton.Name = "AddButton";
			this.AddButton.NormalImage = "Normal";
			this.AddButton.Size = new System.Drawing.Size(75, 21);
			this.AddButton.TabIndex = 1;
			this.AddButton.Text = "Add";
			this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.ButtonClick += new System.EventHandler(this.AddButtonClick);
			// 
			// SplitButtonMenuStrip
			// 
			this.SplitButtonMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.PluginTestMenuItem,
									this.EditorMenuItem});
			this.SplitButtonMenuStrip.Name = "contextMenuStrip1";
			this.SplitButtonMenuStrip.Size = new System.Drawing.Size(155, 70);
			// 
			// PluginTestMenuItem
			// 
			this.PluginTestMenuItem.Name = "PluginTestMenuItem";
			this.PluginTestMenuItem.Size = new System.Drawing.Size(154, 22);
			this.PluginTestMenuItem.Text = "Xslt Tester";
			this.PluginTestMenuItem.Click += new System.EventHandler(this.PluginTestMenuItemClick);
			// 
			// EditorMenuItem
			// 
			this.EditorMenuItem.Name = "EditorMenuItem";
			this.EditorMenuItem.Size = new System.Drawing.Size(154, 22);
			this.EditorMenuItem.Text = "Jeebook Editor";
			this.EditorMenuItem.Click += new System.EventHandler(this.EditorMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(419, 271);
			this.Controls.Add(this.TaskListView);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.StatusStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "MainForm";
			this.Text = "JeebookToy";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.SplitButtonMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem EditorMenuItem;
		private System.Windows.Forms.ImageList TaskStateImageList;
		private System.Windows.Forms.ListView TaskListView;
		private System.Windows.Forms.ToolStripMenuItem PluginTestMenuItem;
		private System.Windows.Forms.ContextMenuStrip SplitButtonMenuStrip;
		private JeebookToy.Controls.SplitButton AddButton;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.TextBox UrlTextBox;
	}
}

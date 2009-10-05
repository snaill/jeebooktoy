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
			this.UrlTextBox = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.DownloadTabPage = new System.Windows.Forms.TabPage();
			this.DownloadListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.FinishTabPage = new System.Windows.Forms.TabPage();
			this.FinsihListView = new System.Windows.Forms.ListView();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.AddButton = new JeebookToy.Controls.SplitButton();
			this.SplitButtonMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.PluginTestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1.SuspendLayout();
			this.DownloadTabPage.SuspendLayout();
			this.FinishTabPage.SuspendLayout();
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
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.DownloadTabPage);
			this.tabControl1.Controls.Add(this.FinishTabPage);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 34);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(419, 238);
			this.tabControl1.TabIndex = 2;
			// 
			// DownloadTabPage
			// 
			this.DownloadTabPage.Controls.Add(this.DownloadListView);
			this.DownloadTabPage.Location = new System.Drawing.Point(4, 22);
			this.DownloadTabPage.Name = "DownloadTabPage";
			this.DownloadTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.DownloadTabPage.Size = new System.Drawing.Size(411, 212);
			this.DownloadTabPage.TabIndex = 0;
			this.DownloadTabPage.Text = "Download";
			this.DownloadTabPage.UseVisualStyleBackColor = true;
			// 
			// DownloadListView
			// 
			this.DownloadListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.DownloadListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DownloadListView.Location = new System.Drawing.Point(3, 3);
			this.DownloadListView.Name = "DownloadListView";
			this.DownloadListView.Size = new System.Drawing.Size(405, 206);
			this.DownloadListView.TabIndex = 0;
			this.DownloadListView.UseCompatibleStateImageBehavior = false;
			this.DownloadListView.View = System.Windows.Forms.View.Details;
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
			// FinishTabPage
			// 
			this.FinishTabPage.Controls.Add(this.FinsihListView);
			this.FinishTabPage.Location = new System.Drawing.Point(4, 22);
			this.FinishTabPage.Name = "FinishTabPage";
			this.FinishTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.FinishTabPage.Size = new System.Drawing.Size(411, 212);
			this.FinishTabPage.TabIndex = 1;
			this.FinishTabPage.Text = "Finish";
			this.FinishTabPage.UseVisualStyleBackColor = true;
			// 
			// FinsihListView
			// 
			this.FinsihListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader3,
									this.columnHeader4});
			this.FinsihListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FinsihListView.Location = new System.Drawing.Point(3, 3);
			this.FinsihListView.Name = "FinsihListView";
			this.FinsihListView.Size = new System.Drawing.Size(405, 206);
			this.FinsihListView.TabIndex = 0;
			this.FinsihListView.UseCompatibleStateImageBehavior = false;
			this.FinsihListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Name";
			this.columnHeader3.Width = 80;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Folder";
			this.columnHeader4.Width = 250;
			// 
			// StatusStrip
			// 
			this.StatusStrip.Location = new System.Drawing.Point(0, 272);
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
			this.flowLayoutPanel1.Size = new System.Drawing.Size(419, 34);
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
			this.AddButton.Size = new System.Drawing.Size(75, 23);
			this.AddButton.TabIndex = 1;
			this.AddButton.Text = "Add";
			this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.ButtonClick += new System.EventHandler(this.AddButtonClick);
			// 
			// SplitButtonMenuStrip
			// 
			this.SplitButtonMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.PluginTestMenuItem});
			this.SplitButtonMenuStrip.Name = "contextMenuStrip1";
			this.SplitButtonMenuStrip.Size = new System.Drawing.Size(149, 26);
			// 
			// PluginTestMenuItem
			// 
			this.PluginTestMenuItem.Name = "PluginTestMenuItem";
			this.PluginTestMenuItem.Size = new System.Drawing.Size(148, 22);
			this.PluginTestMenuItem.Text = "Plugins Tester";
			this.PluginTestMenuItem.Click += new System.EventHandler(this.PluginTestMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(419, 294);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.StatusStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "MainForm";
			this.Text = "JeebookToy";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.tabControl1.ResumeLayout(false);
			this.DownloadTabPage.ResumeLayout(false);
			this.FinishTabPage.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.SplitButtonMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem PluginTestMenuItem;
		private System.Windows.Forms.ContextMenuStrip SplitButtonMenuStrip;
		private JeebookToy.Controls.SplitButton AddButton;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.ListView FinsihListView;
		private System.Windows.Forms.TabPage FinishTabPage;
		private System.Windows.Forms.ListView DownloadListView;
		private System.Windows.Forms.TabPage DownloadTabPage;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TextBox UrlTextBox;
	}
}

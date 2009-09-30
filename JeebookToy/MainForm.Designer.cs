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
			this.UrlTextBox = new System.Windows.Forms.TextBox();
			this.AddButton = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.DownloadTabPage = new System.Windows.Forms.TabPage();
			this.DownloadListView = new System.Windows.Forms.ListView();
			this.FinishTabPage = new System.Windows.Forms.TabPage();
			this.FinsihListView = new System.Windows.Forms.ListView();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.tabControl1.SuspendLayout();
			this.DownloadTabPage.SuspendLayout();
			this.FinishTabPage.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// UrlTextBox
			// 
			this.UrlTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UrlTextBox.Location = new System.Drawing.Point(49, 3);
			this.UrlTextBox.Name = "UrlTextBox";
			this.UrlTextBox.Size = new System.Drawing.Size(328, 26);
			this.UrlTextBox.TabIndex = 0;
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(3, 3);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(40, 23);
			this.AddButton.TabIndex = 1;
			this.AddButton.Text = "Add";
			this.AddButton.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.DownloadTabPage);
			this.tabControl1.Controls.Add(this.FinishTabPage);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 31);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tabControl1.RightToLeftLayout = true;
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(381, 213);
			this.tabControl1.TabIndex = 2;
			// 
			// DownloadTabPage
			// 
			this.DownloadTabPage.Controls.Add(this.DownloadListView);
			this.DownloadTabPage.Location = new System.Drawing.Point(4, 21);
			this.DownloadTabPage.Name = "DownloadTabPage";
			this.DownloadTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.DownloadTabPage.Size = new System.Drawing.Size(373, 188);
			this.DownloadTabPage.TabIndex = 0;
			this.DownloadTabPage.Text = "Download";
			this.DownloadTabPage.UseVisualStyleBackColor = true;
			// 
			// DownloadListView
			// 
			this.DownloadListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DownloadListView.Location = new System.Drawing.Point(3, 3);
			this.DownloadListView.Name = "DownloadListView";
			this.DownloadListView.Size = new System.Drawing.Size(367, 182);
			this.DownloadListView.TabIndex = 0;
			this.DownloadListView.UseCompatibleStateImageBehavior = false;
			this.DownloadListView.View = System.Windows.Forms.View.Details;
			// 
			// FinishTabPage
			// 
			this.FinishTabPage.Controls.Add(this.FinsihListView);
			this.FinishTabPage.Location = new System.Drawing.Point(4, 21);
			this.FinishTabPage.Name = "FinishTabPage";
			this.FinishTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.FinishTabPage.Size = new System.Drawing.Size(373, 188);
			this.FinishTabPage.TabIndex = 1;
			this.FinishTabPage.Text = "Finish";
			this.FinishTabPage.UseVisualStyleBackColor = true;
			// 
			// FinsihListView
			// 
			this.FinsihListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FinsihListView.Location = new System.Drawing.Point(3, 3);
			this.FinsihListView.Name = "FinsihListView";
			this.FinsihListView.Size = new System.Drawing.Size(367, 182);
			this.FinsihListView.TabIndex = 0;
			this.FinsihListView.UseCompatibleStateImageBehavior = false;
			this.FinsihListView.View = System.Windows.Forms.View.Details;
			// 
			// StatusStrip
			// 
			this.StatusStrip.Location = new System.Drawing.Point(0, 244);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(381, 22);
			this.StatusStrip.TabIndex = 3;
			this.StatusStrip.Text = "StatusStrip";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.AddButton);
			this.flowLayoutPanel1.Controls.Add(this.UrlTextBox);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(381, 31);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(381, 266);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.StatusStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainForm";
			this.Text = "JeebookToy";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tabControl1.ResumeLayout(false);
			this.DownloadTabPage.ResumeLayout(false);
			this.FinishTabPage.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.ListView FinsihListView;
		private System.Windows.Forms.TabPage FinishTabPage;
		private System.Windows.Forms.ListView DownloadListView;
		private System.Windows.Forms.TabPage DownloadTabPage;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.TextBox UrlTextBox;
	}
}

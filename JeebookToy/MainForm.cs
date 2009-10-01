/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-25
 * Time: 16:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace JeebookToy
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		TaskManager Manager = new TaskManager(System.Windows.Forms.Application.StartupPath + "\\temp\\");
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			Manager.AddTaskEvent += AddTaskHandler;
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
		}
		
		void AddButtonClick(object sender, EventArgs e)
		{
			Manager.Add(UrlTextBox.Text);
		}
		
		void AddTaskHandler( Task task )
		{
			if ( task.IsFinished )
			{
				ListViewItem lvi = FinsihListView.Items.Add( task.Name );
			}
			else
			{
				ListViewItem lvi = DownloadListView.Items.Add( task.Name );					
			}
		}
		
		void PluginTestMenuItemClick(object sender, EventArgs e)
		{
			PluginForm form = new PluginForm();
			form.ShowDialog();
		}
	}
}

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
using System.Collections.Specialized;

namespace JeebookToy
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		TaskManager 	TManager = new TaskManager(System.Windows.Forms.Application.StartupPath + "\\temp\\");
		PluginManager	PManager = new PluginManager(System.Windows.Forms.Application.StartupPath + "\\plugins\\");
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			Xsl2Engine.CurrentEngine = Xsl2Engine.CheckEngine();
			
			TManager.TaskStateChanged += TaskStateChangedHandler;
			TManager.CollectionChanged += CollectionChangedHandler;
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
		}
		
		void AddButtonClick(object sender, EventArgs e)
		{
			string strPlugin = PManager.Find( UrlTextBox.Text );
			if ( strPlugin == "" )
			{
				MessageBox.Show( "Unknown website" );
				return;
			}
			
			Task task = new BookTask();
			task.Create( UrlTextBox.Text, strPlugin, TManager.CreateTaskPath( UrlTextBox.Text ),System.Windows.Forms.Application.StartupPath + "\\JBs\\"  );
			TManager.Add(task);
		}
		
		void CollectionChangedHandler( object sender, NotifyCollectionChangedEventArgs args )
		{
			if ( args.Action == NotifyCollectionChangedAction.Add )
			{
				Task task = (Task)args.NewItems[0];
				if ( task.State == TaskState.Finished )
				{
					ListViewItem lvi = FinsihListView.Items.Add( task.Name );
				}
				else
				{
					ListViewItem lvi = DownloadListView.Items.Add( task.Name );					
				}
			}
		}
		
		void TaskStateChangedHandler( TaskStateChangedEventArgs args )
		{
			
		}
		
		void PluginTestMenuItemClick(object sender, EventArgs e)
		{
			PluginForm form = new PluginForm();
			form.ShowDialog();
		}
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			TManager.Clear();
		}
	}
}

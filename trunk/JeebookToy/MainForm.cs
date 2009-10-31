﻿/*
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
using JeebookToy.Controls;

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

		}
		
		void CollectionChangedHandler( object sender, NotifyCollectionChangedEventArgs args )
		{
			if ( args.Action == NotifyCollectionChangedAction.Add )
			{
				Task task = (Task)args.NewItems[0];
				ListViewItem lvi = TaskListView.Items.Add( task.Name );
				lvi.SubItems.Add("Ready");
				lvi.Tag = task;
			}
		}
		
		
		void TaskStateChangedHandler( TaskStateChangedEventArgs args )
		{
			TaskListView.Invoke( new TaskStateChangedHandler(TaskStateChanged), new object[1]{args} );
		}
		
		void TaskStateChanged( TaskStateChangedEventArgs args )
		{
			//
			ListViewItem item = null;
			for ( int i = 0; i < TaskListView.Items.Count; i ++ )
			{
				if ( TaskListView.Items[i].Tag == args.Current )
				{
					item = TaskListView.Items[i];
					break;
				}
			}
			System.Diagnostics.Debug.Assert( item != null );

			//
			switch ( args.Current.State )
			{
				case TaskState.Downloading: item.ImageKey = "Downloading"; break;
				case TaskState.Finished: item.ImageKey = "Finished"; break;
				case TaskState.Failed: item.ImageKey = "Failed"; break;
				case TaskState.Packaging: item.ImageKey = "Packaging";break;
				case TaskState.Ready: item.ImageKey = "Ready";break;
				case TaskState.ToJeebook: item.ImageKey = "ToJeebook";break;
				case TaskState.ToXHtml: item.ImageKey = "ToXHtml";break;
			}
			item.Text = args.Current.Name;
			item.SubItems[1].Text = args.ToString();
		}
		
		void PluginTestMenuItemClick(object sender, EventArgs e)
		{
			TesterForm form = new TesterForm();
			form.Show();
		}
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			TManager.Clear();
		}
		
		void EditorMenuItemClick(object sender, EventArgs e)
		{
			EditorForm form = new EditorForm();
			form.Show();
		}

        private void AddFromBookUrlMenuItem_Click(object sender, EventArgs e)
        {
            string strPlugin = PManager.Find(UrlTextBox.Text);
            if (strPlugin == "")
            {
                MessageBox.Show("Unknown website");
                return;
            }

            Task task = new BookTask();
            task.Create(UrlTextBox.Text, strPlugin, TManager.CreateTaskPath(UrlTextBox.Text), System.Windows.Forms.Application.StartupPath + "\\JBs\\");
            TManager.Add(task);
        }

        private void AddFromComicFolderMenuItem_Click(object sender, EventArgs e)
        {
            string[] files = System.IO.Directory.GetFiles(UrlTextBox.Text);
        }
	}
}

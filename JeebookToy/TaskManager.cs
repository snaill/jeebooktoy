/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/1
 * Time: 0:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using JeebookToy.JB;

namespace JeebookToy
{
	public delegate void AddTaskHandler( Task task );
	
	/// <summary>
	/// Description of TaskManager.
	/// </summary>
	public class TaskManager
	{
		System.Collections.Generic.List<Task>	Tasks = new System.Collections.Generic.List<Task>();
		Thread Loop = null;
		bool bLoop = false;
		
		public event AddTaskHandler AddTaskEvent;
			
		public TaskManager(string strPath)
		{
			string[] dirs = System.IO.Directory.GetDirectories(strPath);
			for ( int i = 0; i < dirs.Length; i ++ )
			{
				string strTask = dirs[i] + "index.task";
				if ( System.IO.File.Exists( strTask ) )
				{
					Task task = new Task(strTask);
					Add( task );
				}
				else
				{
					Book	book = new Book(dirs[i]);
				
					Task task = new Task();
				//	task.Name = book.Info.Title;
					task.Uri = dirs[i];
					Add( task );
				}
			}
			
			Loop = new Thread( new ThreadStart(LoopThread));
			Loop.Priority = ThreadPriority.BelowNormal;
			Loop.Start();
		}
			
		~TaskManager()
		{
				
		}
		
		public void Add( string url )
		{
			Task task = new Task();
			task.Uri  = url;
			Add( task );
		}
		
		public void Add( Task task )
		{
			Tasks.Add( task );
			if ( AddTaskEvent != null )
				AddTaskEvent( task );
		}
		
		
		void LoopThread()
		{
			bLoop = true;
			while ( bLoop )
			{
				for ( int i = 0; i < Tasks.Count; i ++ )
				{
					if ( Tasks[i].IsFinished )
						continue;
					
					Tasks[i].Run();
				}
				
				System.Threading.Thread.Sleep(1000);
			}
		}
	}
}

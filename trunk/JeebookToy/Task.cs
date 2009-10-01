/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/1
 * Time: 0:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace JeebookToy
{
	/// <summary>
	/// Description of Task.
	/// </summary>
	public class Task
	{
		public string Name = "New Task";
		public string Uri = "";
		public bool IsFinished = false;
				
		public Task()
		{
		}
		
		public Task(string strPath)
		{
		}
		
		public void Save(string strPath)
		{
			
		}
		
		public void Run()
		{
			// 下载目录页
			// 格式化处理HtmlTidy
			// 解析章节列表Xsl
			// 循环
				// 下载章节页
				// 格式化处理HtmlTidy
				// 解析章节内容Xsl
		}
	}
}

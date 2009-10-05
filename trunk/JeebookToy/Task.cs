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
	public delegate void TaskStateChangedHandler( Task task, TaskStateChangedEventArgs args );
		
	public enum TaskState 
	{
		Ready,
		Downloading,
		ToXHtml,
		ToJeebook,
		Packaging,
		Finished,
		Failed
	}
	
	/// <summary>
	/// Description of Task.
	/// </summary>
	public class Task
	{
		/// <summary>
		/// 任务名，也是图书名称，对应Book/Info/Title
		/// </summary>
		public string Name = "New Task";
		
		/// <summary>
		/// 下载的起始路径，对应Book/Info/bibliosource
		/// </summary>
		public string Uri = "";
		
		/// <summary>
		/// 任务状态
		/// </summary>
		public TaskState State = TaskState.Ready;
		
		/// <summary>
		/// 执行该任务所需要的插件路径
		/// </summary>
		public string XsltPath = "";
		
		/// <summary>
		/// 暂存临时文件（等待打包文件）的路径
		/// </summary>
		public string XmlPath = "";
		
		/// <summary>
		/// 目标文件（打包后文件）路径
		/// </summary>
		public string JBPath = "";
		
		/// <summary>
		/// 任务状态变化事件
		/// </summary>
		public event TaskStateChangedHandler TaskStateChanged;
		
		public Task()
		{
		}
		
		public virtual void Create(string url, string strXsltPath, string strXmlPath, string strJBPath)
		{
			Name = "New Task";
			Uri = url;
			State = TaskState.Ready;
			XsltPath = strXsltPath;
			XmlPath = strXmlPath;
			JBPath = strJBPath;	
		}
		
		public bool Load(string strPath)
		{
			return false;
		}
		
		public void Save(string strPath)
		{
			
		}
		
		public virtual void Run()
		{
			// 下载目录页
			// 格式化处理HtmlTidy
			// 解析章节列表Xsl
			// 循环
				// 下载章节页
				// 格式化处理HtmlTidy
				// 解析章节内容Xsl
		}
		
		public static string Download( string strURL )
		{
			try 
			{
				System.Net.WebRequest request = System.Net.WebRequest.Create( strURL );
				System.Net.WebResponse response = request.GetResponse();
				System.IO.StreamReader stream = new System.IO.StreamReader( response.GetResponseStream(), System.Text.Encoding.Default );
				string strInput = stream.ReadToEnd();

				response.Close();
				stream.Close(); 
				return strInput;
			} 
			catch ( Exception ) 
			{
				return "";
			}
		}
		
		public static string Html2XHtml( string strHtml )
		{
			TidyNet.Tidy tidy = new TidyNet.Tidy();

            /* Set the options you want */
            tidy.Options.Xhtml = true;
            tidy.Options.XmlOut = true;
            tidy.Options.MakeClean = true;
            tidy.Options.CharEncoding = TidyNet.CharEncoding.UTF8;

            /* Declare the parameters that is needed */
            System.IO.MemoryStream input = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(strHtml));
            System.IO.MemoryStream output = new System.IO.MemoryStream();
            tidy.Parse(input, output, new TidyNet.TidyMessageCollection());

            return System.Text.Encoding.UTF8.GetString(output.ToArray());
		}
		
		public static void Transform(string strXml, System.Xml.XmlWriter writer, string strXslFile )
		{
			//
			System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
            xml.LoadXml(strXml);

            //
            try {
	            
	            SaxonWrapper.Xsl2Processor processor = new SaxonWrapper.Xsl2Processor();
	            processor.Load( strXslFile );
	            processor.Transform( xml, writer );
            } 
            catch ( Exception )
            {
            }
		}
		
		public static string Transform(string strXml, string strXslFile )
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			Transform( strXml, System.Xml.XmlWriter.Create( sb ), strXslFile );
			return sb.ToString();
		}
		
		public static void Transform(string strXml, string strOutput, string strXslFile )
		{
			Transform( strXml, System.Xml.XmlWriter.Create( strOutput ), strXslFile );
		}	
		
		public static string GetPath( string url, string strPath )
		{
			if ( strPath.Contains("://") )
				return strPath;
			          
			Uri uri = new Uri(new Uri(url), strPath );
			return uri.AbsoluteUri;
		}
	}
}

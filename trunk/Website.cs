using System;
using System.Text.RegularExpressions;
using BookStarToy.SBP;
using System.Collections;
using System.Collections.Specialized;

namespace BookStarToy.Model
{
	/// <summary>
	/// 网站值类型
	/// </summary>
	public class SiteValueType
	{
		/// <summary>图书名</summary>
		public const string BookName = "BookName";
		/// <summary>文章信息，包括文章名和文章网页URL</summary>
		public const string ArticleInfo = "ArticleInfo";
		/// <summary>图书名</summary>
		public const string ArticleName = "ArticleName";
		/// <summary>图书网页URL</summary>
		public const string ArticleURL = "ArticleURL";
		/// <summary>图书内容</summary>
		public const string ArticleText = "ArticleText";
	}

	/// <summary>
	/// 保存目标分析网站所有包含的参数，用于显示网站树，打开网站URL，自动分析网站内容等等
	/// </summary>
	public class Website
	{
		/// <summary>
		/// 获取网站URL的BaseURL，由于某些网站会指向某个文件，比如http://www.chinaos.com/index.htm
		/// 为了方便目录URL作比较而使用该函数过滤掉URL不需要的部分
		/// </summary>
		/// <param name="strURL">网站的URL</param>
		/// <returns>网站URL的BaseURL</returns>
		public static string GetBaseURL( string strURL )
		{
			int nIndex = strURL.IndexOf( "://" ) + 3;
			int nIndex2 = strURL.IndexOf( "/", ( nIndex < 0 ) ? 0 : nIndex );
			return ( nIndex2 < 0 ) ? strURL : strURL.Substring( 0, nIndex2 );
		}

		/// <summary>
		/// 通过HTML的原URL和HTML中获取的相对URL，获得该相对URL对应的绝对URL
		/// </summary>
		/// <param name="strSourceURL">HTML的原URL</param>
		/// <param name="strInURL">相对URL</param>
		/// <returns>绝对URL</returns>
		public static string GetRealURL( string strSourceURL, string strInURL )
		{
			// 当strInURL为全路径，则返回
			if ( strInURL.IndexOf( "://" ) >= 0 )
				return strInURL;

			// 当以"/"开头，添加strSourceURL的BaseURL
			if ( strInURL.StartsWith("/") )
				return GetBaseURL( strSourceURL ) + strInURL;

			// 当以"."开头，对相对路径进行计算
			if ( strInURL.StartsWith(".") )
			{
				string[] array = strSourceURL.Substring( strSourceURL.IndexOf("://") + 3 ).Split( '/');
				Stack stack = new Stack();
				for ( int i = 0; i < array.Length - 1; i++ )
					stack.Push( array[i] );
				
				array = strInURL.Split( '/');
				for ( int i = 0; i < array.Length; i++ )
				{
					if ( array[i] == ".")
						continue;
					if ( array[i] == "..")
						stack.Pop();
					else
						stack.Push( array[i]);
				}

				string strRealURL = (string)stack.Pop();
				while ( stack.Count > 0 )
					strRealURL = (string)stack.Pop() + "/" + strRealURL;	
				strRealURL = strSourceURL.Substring( 0, strSourceURL.IndexOf("://") ) + "://" + strRealURL;
				return strRealURL;
			}
			
			//
			return strSourceURL.Substring( 0, strSourceURL.LastIndexOf("/") + 1 ) + strInURL;
		}

		/// <summary>
		/// 网站的名字，被存储在xml中，显示在主界面的左边网站树中
		/// </summary>
		public string SiteName;
		/// <summary>
		/// 网站的URL，用户可以点击网站树中的节点触发IE打开这个URL
		/// </summary>
		public string SiteURL;
		/// <summary>
		/// 网站所在的组（也称类别），它是网站的归类信息
		/// </summary>
		public string SiteGroup;
		/// <summary>
		/// 保存值节点的列表，值节点中保存了获取该值所需的正则表达式操作序列
		/// </summary>
		protected System.Xml.XmlNodeList ValueNodes;

		/// <summary>
		/// 网站类的构造函数
		/// </summary>
		/// <param name="name">网站名</param>
		/// <param name="url">网站URL</param>
		/// <param name="sitegroup">网站所在组</param>
		/// <param name="valueNodes">网站的<see cref="Website.ValueNodes">值节点列表</see></param>
		public Website( string name, string url, string sitegroup, System.Xml.XmlNodeList valueNodes)
		{
			SiteName = name;
			SiteURL = url;
			SiteGroup = sitegroup;
			ValueNodes = valueNodes;
		}

		/// <summary>
		/// 通过名字和网页内容，获取相应值的名值对列表中该名字的值
		/// </summary>
		/// <param name="strInput">网页内容</param>
		/// <param name="strName">与获取值的名字</param>
		/// <returns>对应名字的值，没有找到值则返回空</returns>
		public string GetValue( string strInput, string strName )
		{
			NameValueCollection nv = GetValueList( strInput, strName );
			return ( nv == null ) ? null : nv[strName];
		}

		/// <summary>
		/// 通过名字和网页内容，获取相应值的名值对列表
		/// </summary>
		/// <param name="strInput">网页内容</param>
		/// <param name="strName">与获取值的名字</param>
		/// <returns>该值的名值对列表，没有找到值则返回空</returns>
		public NameValueCollection GetValueList( string strInput, string strName )
		{
			NameValueCollection[] nvs = GetValueAllList( strInput, strName );
			return ( nvs.Length == 0 ) ? null : nvs[0];
		}

		/// <summary>
		/// 通过名字和网页内容，获取相应值的所有名值对列表
		/// </summary>
		/// <param name="strInput">网页内容</param>
		/// <param name="strName">与获取值的名字</param>
		/// <returns>该值的列表，列表中最少为1，没有找到值则返回空</returns>
		public NameValueCollection[] GetValueAllList( string strInput, string strName )
		{
			// 查找值节点
			System.Xml.XmlNode node = FindValueNode( strName );
			if ( null == node )
				return null;

			// 获取操作列表
			ArrayList	array = new ArrayList();
			System.Xml.XmlNodeList nodeList = node.ChildNodes; 
			System.Diagnostics.Debug.Assert( nodeList.Count > 0 );
			for ( int i = 0; i < nodeList.Count; i++ )
			{
				// 对每个操作选择正确的调用
				if ( nodeList[i].LocalName == "match" )
					strInput = Regex_Match( nodeList[i], strInput, array );
				else if ( nodeList[i].LocalName == "matches" )
					Regex_Matches( nodeList[i], strInput, array );
				else if ( nodeList[i].LocalName == "replace" )
					Regex_Replace( nodeList[i], strInput, array );
				else
					System.Diagnostics.Debug.Assert( false );
			}

			// 返回名值对数组
			NameValueCollection[] nvs = new NameValueCollection[array.Count];
			for ( int i = 0; i < array.Count; i++ )
				nvs[i] = (NameValueCollection)array[i];

			return nvs;
		}

		/// <summary>
		/// 正则表达式的匹配操作
		/// </summary>
		/// <param name="node">包含匹配信息的节点</param>
		/// <param name="strInput">网页信息</param>
		/// <param name="array">名值数组</param>
		/// <returns>返回匹配的值，如果没有匹配则原样返回网页信息</returns>
		protected string Regex_Match( System.Xml.XmlNode node, string strInput, ArrayList array )
		{
			// 通过匹配节点获取创建正则表达式的参数
			System.Text.RegularExpressions.RegexOptions options = Regex_Options( node.Attributes["options"].Value ); 
			string strPattern =  node.SelectSingleNode("pattern").InnerText;

			// 进行匹配，如果失败，返回网页信息
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strPattern, options);
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			if ( !match.Success )
				return strInput;

			// 匹配成功，获取需要保存的值，并加入列表
			System.Xml.XmlNodeList nodeList = node.SelectNodes("group");
			System.Text.RegularExpressions.GroupCollection gc = match.Groups;
			NameValueCollection nv = new NameValueCollection();
			for ( int i = 0; i < nodeList.Count; i++  )
			{
				string strName = nodeList[i].Attributes["name"].Value;
				nv.Add( strName, gc[strName].Value );
			}
			if ( nv.Count > 0 )
				array.Add( nv );


			// 返回匹配范围字符串
			return match.Value;
		}

		/// <summary>
		/// 正则表达式的一次全匹配操作，注意为了节省资源，这里并没有时候<see cref="System.Text.RegularExpressions.Regex.Matches(string,string)">Matches</see>函数
		/// </summary>
		/// <param name="node">包含匹配信息的节点</param>
		/// <param name="strInput">网页信息</param>
		/// <param name="array">名值数组</param>
		protected void Regex_Matches( System.Xml.XmlNode node, string strInput, ArrayList array )
		{
			// 通过匹配节点获取创建正则表达式的参数
			System.Text.RegularExpressions.RegexOptions options = Regex_Options( node.Attributes["options"].Value ); 
			string strPattern =  node.SelectSingleNode("pattern").InnerText;

			// 进行匹配，如果成功则依次取出个名值对数据
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strPattern, options);
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			while ( match.Success )
			{
				// 获取每次匹配中的名值对
				System.Xml.XmlNodeList nodeList = node.SelectNodes("group");
				System.Text.RegularExpressions.GroupCollection gc = match.Groups;
				NameValueCollection nv = new NameValueCollection();
				for ( int i = 0; i < nodeList.Count; i++  )
				{
					string strName = nodeList[i].Attributes["name"].Value;
					nv.Add( strName, gc[strName].Value );
				}	
				if ( nv.Count > 0 )
					array.Add( nv );

				// 继续获取下一个匹配	
				match = match.NextMatch(); 
			}
		}

		/// <summary>
		/// 正则表达式的更新操作
		/// </summary>
		/// <param name="node">包含匹配信息的节点</param>
		/// <param name="strInput">网页信息</param>
		/// <param name="array">名值数组</param>
		/// <returns>返回匹配的值，如果没有匹配则原样返回网页信息</returns>
		protected string Regex_Replace( System.Xml.XmlNode node, string strInput, ArrayList array )
		{
			// 通过匹配节点获取创建正则表达式的参数
			System.Text.RegularExpressions.RegexOptions options = Regex_Options( node.Attributes["options"].Value ); 
			string strPattern =  node.SelectSingleNode("pattern").InnerText;

			// 进行匹配，如果失败，返回网页信息
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strPattern, options);
			System.Xml.XmlNode nodeReplacement = node.SelectSingleNode("replacement");
			return regex.Replace( strInput, ( nodeReplacement.Value == null ) ? "" : nodeReplacement.Value );
		}		
		
		/// <summary>
		/// 转换字符串为正则表达式的创建参数<see cref="System.Text.RegularExpressions.RegexOptions">RegexOptions</see>格式
		/// </summary>
		/// <param name="strOptions"></param>
		/// <returns></returns>
		protected System.Text.RegularExpressions.RegexOptions Regex_Options( string strOptions )
		{
			// 字符串如果为空，则返回空类型
			if ( null == strOptions || "" == strOptions )
				return System.Text.RegularExpressions.RegexOptions.None;

			// 使用|分割字符串
			string[] strArray = strOptions.Split( '|' );
			System.Text.RegularExpressions.RegexOptions ros = System.Text.RegularExpressions.RegexOptions.None;
 
			// !!!!! 需要补全所有Options
			for ( int i = 0; i < strArray.Length; i++ )
			{
				if ( strArray[i] == "Singleline" )
					ros |= System.Text.RegularExpressions.RegexOptions.Singleline;
				else if ( strArray[i] == "IgnoreCase" )
					ros |= System.Text.RegularExpressions.RegexOptions.IgnoreCase; 
			}

			// 返回
			return ros;
		}

		/// <summary>
		/// 通过名字查找当前网站所能够获取值的值节点
		/// </summary>
		/// <param name="strName">需要获取值的名字</param>
		/// <returns>相应的值节点，没有找到返回空</returns>
		protected System.Xml.XmlNode FindValueNode( string strName )
		{
			for ( int i = 0; i < ValueNodes.Count; i++ )
			{
				if ( ValueNodes[i].Attributes["name"].Value == strName )
					return ValueNodes[i];
			}
			return null;
		}
	}

	/// <summary>
	/// 网站信息处理类的基类，用来包括缺省的内容处理
	/// </summary>
	public class WebsiteBase
	{
		#region 功能函数
		/// <summary>
		/// 下载网页
		/// </summary>
		/// <param name="strURL">网页URL</param>
		/// <param name="encoding">下载编码</param>
		/// <returns>网页内容</returns>
		public virtual string Download( string strURL, System.Text.Encoding encoding )
		{
			System.Net.WebRequest request = System.Net.WebRequest.Create( strURL );
			System.Net.WebResponse response = request.GetResponse();
			System.IO.StreamReader stream = new System.IO.StreamReader( response.GetResponseStream(), encoding );
			string strInput = stream.ReadToEnd();

			response.Close();
			stream.Close(); 
			return strInput;
		}
		#endregion

		#region 获取图书的相关信息
		/// <summary>
		/// 解析目录网页获取图书名称
		/// </summary>
		/// <param name="strInput">网页内容</param>
		/// <returns>图书名称</returns>
		public virtual string GetBookName( string strInput )
		{
			// 通过匹配节点获取创建正则表达式的参数
			string strMatch = @"<title>(?<BookName>.*)</title>";
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strMatch, RegexOptions.Singleline | RegexOptions.IgnoreCase );
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			if ( !match.Success )
				return null;

			return  match.Groups["BookName"].Value;
		}

		/// <summary>
		/// 解析目录网页返回目录列表，并以名称:URL的形式返回
		/// </summary>
		/// <param name="strInput">网页内容</param>
		/// <returns>目录列表，列表中最少为1，没有找到值则返回空</returns>
		public virtual NameValueCollection GetContent( string strInput )
		{
			// 通过匹配节点获取创建正则表达式的参数
			string strMatch = @"<a href=[(?<ArticleURL>\S*)|.(?<ArticleURL>\S*).].*?>(?<ArticleName>[^<]*?)</a>";
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strMatch, RegexOptions.Singleline | RegexOptions.IgnoreCase );
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			NameValueCollection nv = new NameValueCollection();
			while ( match.Success )
			{
				// 匹配成功，获取需要保存的值，并加入列表
				System.Text.RegularExpressions.GroupCollection gc = match.Groups;
				nv.Add( gc["ArticleName"].Value, gc["ArticleURL"].Value );
				match = match.NextMatch();
			}

			// 返回匹配范围字符串
			return nv;
		}

		/// <summary>
		/// 解析文章网页获取文章内容
		/// </summary>
		/// <param name="strInput">网页内容</param>
		/// <returns>文章内容</returns>
		public virtual string GetText( string strInput )
		{
			string[] strMatches = new string[]{ @"</p>|<br>", @"<font color=[.#[F]+|#[F]+].*?>.*?</font>|<script.*?>.*?</script>", @"&npbs;", "<.*?>"};
			string[] strReplacements = new string[]{ "\r\n", "", " ", "" };

			for ( int i = 0; i < strMatches.Length; i++ )
			{
				// 通过匹配节点获取创建正则表达式的参数
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strMatches[i], RegexOptions.Singleline | RegexOptions.IgnoreCase );
				strInput = regex.Replace( strInput, strReplacements[i] );
			}
			return strInput;
		}

		/// <summary>
		/// 解析目录网页判断当前图书是否完整(如新浪有连载未完的情况)
		/// </summary>
		/// <param name="strInput">网页内容</param>
		/// <returns>图书名称</returns>
		public virtual bool IsIntact( string strInput )
		{
			return true;
		}
		#endregion
	}

	/// <summary>
	/// 针对新浪图书网的优化处理类
	/// </summary>
	public class WebsiteSina
	{
		#region 获取图书的相关信息
		/// <summary>
		/// 解析目录网页获取图书名称
		/// </summary>
		/// <param name="strInput">网页内容</param>
		/// <returns>图书名称</returns>
		public virtual string GetBookName( string strInput )
		{
			// 通过匹配节点获取创建正则表达式的参数
			string strMatch = @"<TITLE>(?<BookName>.*)_.*_.*</TITLE>";
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strMatch, RegexOptions.Singleline | RegexOptions.IgnoreCase );
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			if ( !match.Success )
				return null;

			return  match.Groups["BookName"].Value;
		}

		/// <summary>
		/// 解析目录网页返回目录列表，并以名称:URL的形式返回
		/// </summary>
		/// <param name="strInput">网页内容</param>
		/// <returns>目录列表，列表中最少为1，没有找到值则返回空</returns>
		public virtual NameValueCollection GetContent( string strInput )
		{
			// 通过匹配节点获取创建正则表达式的参数
			string strMatch = @"<li><a href=(?<ArticleURL>\S*) target=_blank class=a03>(?<ArticleName>.*)</a>";
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strMatch, RegexOptions.Singleline | RegexOptions.IgnoreCase );
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			NameValueCollection nv = new NameValueCollection();
			while ( match.Success )
			{
				// 匹配成功，获取需要保存的值，并加入列表
				System.Text.RegularExpressions.GroupCollection gc = match.Groups;
				nv.Add( gc["ArticleName"].Value, gc["ArticleURL"].Value );
				match = match.NextMatch();
			}

			// 返回匹配范围字符串
			return nv;
		}

		/// <summary>
		/// 解析文章网页获取文章内容
		/// </summary>
		/// <param name="strInput">网页内容</param>
		/// <returns>文章内容</returns>
		public virtual string GetText( string strInput )
		{
			//找到文本所在HTML标识
			string strMatch = @"<td class=l17 vAlign=top>.*?[<td[^>]*>.*?</td>]*.*?</td>";
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strMatch, RegexOptions.Singleline | RegexOptions.IgnoreCase );
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			if ( !match.Success )
				return "";
			strInput = match.Value;

			// 获取每个自然段的文本
			System.Text.StringBuilder sb = new System.Text.StringBuilder( strInput.Length );
			strMatch = @"<p>(?<ArticleText>.*?)</p>";
			regex = new System.Text.RegularExpressions.Regex(strMatch, RegexOptions.Singleline | RegexOptions.IgnoreCase );
			match = regex.Match(strInput);
			while ( match.Success )
			{
				sb.Append( match.Groups["ArticleText"].Value + "\r\n" );
				match = match.NextMatch();
			}
			strInput = sb.ToString();

			// 过滤并格式化非文本信息
			string[] strMatches = new string[]{ @"<.*?>", "&nbsp|&nbsp;"};
			string[] strReplacements = new string[]{ "", " " };

			for ( int i = 0; i < strMatches.Length; i++ )
			{
				// 通过匹配节点获取创建正则表达式的参数
				regex = new System.Text.RegularExpressions.Regex(strMatches[i], RegexOptions.Singleline | RegexOptions.IgnoreCase );
				strInput = regex.Replace( strInput, strReplacements[i] );
			}
			return strInput;
		}

		/// <summary>
		/// 解析目录网页判断当前图书是否完整(如新浪有连载未完的情况)
		/// </summary>
		/// <param name="strInput">网页内容</param>
		/// <returns>图书名称</returns>
		public virtual bool IsIntact( string strInput )
		{
			return true;
		}
		#endregion
	}

	/// <summary>
	/// 网站信息管理器，用来装载或存储所有支持的网站信息
	/// </summary>
	public class WebsiteManager
	{
		/// <summary>
		/// 网站信息列表，保存所有从website.xml载入的网站信息
		/// </summary>
		private System.Collections.ArrayList	Websites = new System.Collections.ArrayList();
		
		/// <summary>
		/// 缺省网站信息，再无法找到相应信息或使用某个网站信息获取数据失败时，使用的默认操作
		/// 缺省网站信息只允许一个，如果website.xml中包含多个则只保留最后一个
		/// </summary>
		private Website				DefaultWebsite = null;

		/// <summary>
		/// 通过下标获取网站信息
		/// </summary>
		/// <value name="index">网站的下标，从0开始</value>
		public Website this[int index]
		{
			get 
			{
				if ( index < 0 || index >= Websites.Count )
					return null;
				return ( Website )Websites[index];
			}
		}

		/// <summary>
		/// 通过目录URL标获取网站信息，通过比较URL的BaseURL确定是否使用那个网站信息
		/// </summary>
		/// <value name="index">网站的下标，从0开始</value>
		public Website this[string strURL ]
		{
			get 
			{
				for ( int i = 0; i < Websites.Count; i++ )
				{
					Website ws = ( Website )Websites[i];
					string BaseURL = Website.GetBaseURL( ws.SiteURL );
					if ( strURL.StartsWith( BaseURL ) )
						return ws;
				}

				return null;
			}
		}

		/// <summary>
		/// 通过文件流载入website.xml文件，其中包含了所有网站信息
		/// </summary>
		/// <param name="stream">文件流</param>
		public void Load( System.IO.Stream stream )
		{
			try 
			{
				System.Xml.XmlDocument	doc = new System.Xml.XmlDocument();
				doc.Load( stream );
				System.Xml.XmlNodeList xnlGroups = doc.DocumentElement.SelectNodes("sitegroup");
				for ( int i = 0;i < xnlGroups.Count; i++ )
				{
					string sitegroup = xnlGroups[i].Attributes["name"].Value;
					System.Xml.XmlNodeList xnlSites = xnlGroups[i].SelectNodes("site");
					for ( int j = 0; j < xnlSites.Count; j++ )
					{
						string name = xnlSites[j].Attributes["name"].Value;
						string url = xnlSites[j].Attributes["url"].Value;
						System.Xml.XmlNodeList xnlValues = xnlSites[j].SelectNodes("value");
						if ( url == "")
							DefaultWebsite = new Website( name, url, sitegroup, xnlValues );
						else
						{
							Website	ws = new Website( name, url, sitegroup, xnlValues );
							Websites.Add( ws );
						}
					}

				}
			} 
			catch ( System.Xml.XmlException ex )
			{
				throw ex;
			}
		}

		/// <summary>
		/// 载入website.xml文件，其中包含了所有网站信息
		/// </summary>
		/// <param name="strFilename">文件名</param>
		public void Load( string strFilename )
		{
			System.IO.Stream stream = new System.IO.FileStream( strFilename, System.IO.FileMode.Open );
			Load( stream );
			stream.Close();
		}
	}

	/// <summary>
	/// 网站信息获取异常类
	/// </summary>
	public class WebsiteException : System.ApplicationException 
	{
		/// <summary>
		/// 错误代码枚举
		/// </summary>
		public enum ErrorCode 
		{ 
			/// <summary>未知错误</summary>
			Unknown, 
			/// <summary>下载错误</summary>
			DownloadFail, 
			/// <summary>获取网页信息错误</summary>
			GetTextFail 
		}

		/// <summary>当前错误代码</summary>
		ErrorCode Error = ErrorCode.Unknown;
		
		/// <summary>错误信息</summary>
		string strMessage = null;
		
		/// <summary>获取描述当前异常的消息</summary>
		public override string Message 
		{
			get 
			{
				switch ( Error )
				{
					case ErrorCode.DownloadFail:return "下载失败，原因：" + strMessage;
					case ErrorCode.GetTextFail:return "获取文章文本失败";
					default:
						return  "未知错误";
				}
			}
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="errcode">错误代码</param>
		/// <param name="msg">错误信息</param>
		public WebsiteException ( ErrorCode errcode, string msg )
		{
			Error = errcode;
			strMessage = msg;
		}
	}
}
using System;
using System.Text.RegularExpressions;
using BookStarToy.SBP;
using System.Collections;
using System.Collections.Specialized;

namespace BookStarToy.Model
{
	/// <summary>
	/// ��վֵ����
	/// </summary>
	public class SiteValueType
	{
		/// <summary>ͼ����</summary>
		public const string BookName = "BookName";
		/// <summary>������Ϣ��������������������ҳURL</summary>
		public const string ArticleInfo = "ArticleInfo";
		/// <summary>ͼ����</summary>
		public const string ArticleName = "ArticleName";
		/// <summary>ͼ����ҳURL</summary>
		public const string ArticleURL = "ArticleURL";
		/// <summary>ͼ������</summary>
		public const string ArticleText = "ArticleText";
	}

	/// <summary>
	/// ����Ŀ�������վ���а����Ĳ�����������ʾ��վ��������վURL���Զ�������վ���ݵȵ�
	/// </summary>
	public class Website
	{
		/// <summary>
		/// ��ȡ��վURL��BaseURL������ĳЩ��վ��ָ��ĳ���ļ�������http://www.chinaos.com/index.htm
		/// Ϊ�˷���Ŀ¼URL���Ƚ϶�ʹ�øú������˵�URL����Ҫ�Ĳ���
		/// </summary>
		/// <param name="strURL">��վ��URL</param>
		/// <returns>��վURL��BaseURL</returns>
		public static string GetBaseURL( string strURL )
		{
			int nIndex = strURL.IndexOf( "://" ) + 3;
			int nIndex2 = strURL.IndexOf( "/", ( nIndex < 0 ) ? 0 : nIndex );
			return ( nIndex2 < 0 ) ? strURL : strURL.Substring( 0, nIndex2 );
		}

		/// <summary>
		/// ͨ��HTML��ԭURL��HTML�л�ȡ�����URL����ø����URL��Ӧ�ľ���URL
		/// </summary>
		/// <param name="strSourceURL">HTML��ԭURL</param>
		/// <param name="strInURL">���URL</param>
		/// <returns>����URL</returns>
		public static string GetRealURL( string strSourceURL, string strInURL )
		{
			// ��strInURLΪȫ·�����򷵻�
			if ( strInURL.IndexOf( "://" ) >= 0 )
				return strInURL;

			// ����"/"��ͷ�����strSourceURL��BaseURL
			if ( strInURL.StartsWith("/") )
				return GetBaseURL( strSourceURL ) + strInURL;

			// ����"."��ͷ�������·�����м���
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
		/// ��վ�����֣����洢��xml�У���ʾ��������������վ����
		/// </summary>
		public string SiteName;
		/// <summary>
		/// ��վ��URL���û����Ե����վ���еĽڵ㴥��IE�����URL
		/// </summary>
		public string SiteURL;
		/// <summary>
		/// ��վ���ڵ��飨Ҳ����𣩣�������վ�Ĺ�����Ϣ
		/// </summary>
		public string SiteGroup;
		/// <summary>
		/// ����ֵ�ڵ���б�ֵ�ڵ��б����˻�ȡ��ֵ�����������ʽ��������
		/// </summary>
		protected System.Xml.XmlNodeList ValueNodes;

		/// <summary>
		/// ��վ��Ĺ��캯��
		/// </summary>
		/// <param name="name">��վ��</param>
		/// <param name="url">��վURL</param>
		/// <param name="sitegroup">��վ������</param>
		/// <param name="valueNodes">��վ��<see cref="Website.ValueNodes">ֵ�ڵ��б�</see></param>
		public Website( string name, string url, string sitegroup, System.Xml.XmlNodeList valueNodes)
		{
			SiteName = name;
			SiteURL = url;
			SiteGroup = sitegroup;
			ValueNodes = valueNodes;
		}

		/// <summary>
		/// ͨ�����ֺ���ҳ���ݣ���ȡ��Ӧֵ����ֵ���б��и����ֵ�ֵ
		/// </summary>
		/// <param name="strInput">��ҳ����</param>
		/// <param name="strName">���ȡֵ������</param>
		/// <returns>��Ӧ���ֵ�ֵ��û���ҵ�ֵ�򷵻ؿ�</returns>
		public string GetValue( string strInput, string strName )
		{
			NameValueCollection nv = GetValueList( strInput, strName );
			return ( nv == null ) ? null : nv[strName];
		}

		/// <summary>
		/// ͨ�����ֺ���ҳ���ݣ���ȡ��Ӧֵ����ֵ���б�
		/// </summary>
		/// <param name="strInput">��ҳ����</param>
		/// <param name="strName">���ȡֵ������</param>
		/// <returns>��ֵ����ֵ���б�û���ҵ�ֵ�򷵻ؿ�</returns>
		public NameValueCollection GetValueList( string strInput, string strName )
		{
			NameValueCollection[] nvs = GetValueAllList( strInput, strName );
			return ( nvs.Length == 0 ) ? null : nvs[0];
		}

		/// <summary>
		/// ͨ�����ֺ���ҳ���ݣ���ȡ��Ӧֵ��������ֵ���б�
		/// </summary>
		/// <param name="strInput">��ҳ����</param>
		/// <param name="strName">���ȡֵ������</param>
		/// <returns>��ֵ���б��б�������Ϊ1��û���ҵ�ֵ�򷵻ؿ�</returns>
		public NameValueCollection[] GetValueAllList( string strInput, string strName )
		{
			// ����ֵ�ڵ�
			System.Xml.XmlNode node = FindValueNode( strName );
			if ( null == node )
				return null;

			// ��ȡ�����б�
			ArrayList	array = new ArrayList();
			System.Xml.XmlNodeList nodeList = node.ChildNodes; 
			System.Diagnostics.Debug.Assert( nodeList.Count > 0 );
			for ( int i = 0; i < nodeList.Count; i++ )
			{
				// ��ÿ������ѡ����ȷ�ĵ���
				if ( nodeList[i].LocalName == "match" )
					strInput = Regex_Match( nodeList[i], strInput, array );
				else if ( nodeList[i].LocalName == "matches" )
					Regex_Matches( nodeList[i], strInput, array );
				else if ( nodeList[i].LocalName == "replace" )
					Regex_Replace( nodeList[i], strInput, array );
				else
					System.Diagnostics.Debug.Assert( false );
			}

			// ������ֵ������
			NameValueCollection[] nvs = new NameValueCollection[array.Count];
			for ( int i = 0; i < array.Count; i++ )
				nvs[i] = (NameValueCollection)array[i];

			return nvs;
		}

		/// <summary>
		/// ������ʽ��ƥ�����
		/// </summary>
		/// <param name="node">����ƥ����Ϣ�Ľڵ�</param>
		/// <param name="strInput">��ҳ��Ϣ</param>
		/// <param name="array">��ֵ����</param>
		/// <returns>����ƥ���ֵ�����û��ƥ����ԭ��������ҳ��Ϣ</returns>
		protected string Regex_Match( System.Xml.XmlNode node, string strInput, ArrayList array )
		{
			// ͨ��ƥ��ڵ��ȡ����������ʽ�Ĳ���
			System.Text.RegularExpressions.RegexOptions options = Regex_Options( node.Attributes["options"].Value ); 
			string strPattern =  node.SelectSingleNode("pattern").InnerText;

			// ����ƥ�䣬���ʧ�ܣ�������ҳ��Ϣ
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strPattern, options);
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			if ( !match.Success )
				return strInput;

			// ƥ��ɹ�����ȡ��Ҫ�����ֵ���������б�
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


			// ����ƥ�䷶Χ�ַ���
			return match.Value;
		}

		/// <summary>
		/// ������ʽ��һ��ȫƥ�������ע��Ϊ�˽�ʡ��Դ�����ﲢû��ʱ��<see cref="System.Text.RegularExpressions.Regex.Matches(string,string)">Matches</see>����
		/// </summary>
		/// <param name="node">����ƥ����Ϣ�Ľڵ�</param>
		/// <param name="strInput">��ҳ��Ϣ</param>
		/// <param name="array">��ֵ����</param>
		protected void Regex_Matches( System.Xml.XmlNode node, string strInput, ArrayList array )
		{
			// ͨ��ƥ��ڵ��ȡ����������ʽ�Ĳ���
			System.Text.RegularExpressions.RegexOptions options = Regex_Options( node.Attributes["options"].Value ); 
			string strPattern =  node.SelectSingleNode("pattern").InnerText;

			// ����ƥ�䣬����ɹ�������ȡ������ֵ������
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strPattern, options);
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			while ( match.Success )
			{
				// ��ȡÿ��ƥ���е���ֵ��
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

				// ������ȡ��һ��ƥ��	
				match = match.NextMatch(); 
			}
		}

		/// <summary>
		/// ������ʽ�ĸ��²���
		/// </summary>
		/// <param name="node">����ƥ����Ϣ�Ľڵ�</param>
		/// <param name="strInput">��ҳ��Ϣ</param>
		/// <param name="array">��ֵ����</param>
		/// <returns>����ƥ���ֵ�����û��ƥ����ԭ��������ҳ��Ϣ</returns>
		protected string Regex_Replace( System.Xml.XmlNode node, string strInput, ArrayList array )
		{
			// ͨ��ƥ��ڵ��ȡ����������ʽ�Ĳ���
			System.Text.RegularExpressions.RegexOptions options = Regex_Options( node.Attributes["options"].Value ); 
			string strPattern =  node.SelectSingleNode("pattern").InnerText;

			// ����ƥ�䣬���ʧ�ܣ�������ҳ��Ϣ
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strPattern, options);
			System.Xml.XmlNode nodeReplacement = node.SelectSingleNode("replacement");
			return regex.Replace( strInput, ( nodeReplacement.Value == null ) ? "" : nodeReplacement.Value );
		}		
		
		/// <summary>
		/// ת���ַ���Ϊ������ʽ�Ĵ�������<see cref="System.Text.RegularExpressions.RegexOptions">RegexOptions</see>��ʽ
		/// </summary>
		/// <param name="strOptions"></param>
		/// <returns></returns>
		protected System.Text.RegularExpressions.RegexOptions Regex_Options( string strOptions )
		{
			// �ַ������Ϊ�գ��򷵻ؿ�����
			if ( null == strOptions || "" == strOptions )
				return System.Text.RegularExpressions.RegexOptions.None;

			// ʹ��|�ָ��ַ���
			string[] strArray = strOptions.Split( '|' );
			System.Text.RegularExpressions.RegexOptions ros = System.Text.RegularExpressions.RegexOptions.None;
 
			// !!!!! ��Ҫ��ȫ����Options
			for ( int i = 0; i < strArray.Length; i++ )
			{
				if ( strArray[i] == "Singleline" )
					ros |= System.Text.RegularExpressions.RegexOptions.Singleline;
				else if ( strArray[i] == "IgnoreCase" )
					ros |= System.Text.RegularExpressions.RegexOptions.IgnoreCase; 
			}

			// ����
			return ros;
		}

		/// <summary>
		/// ͨ�����ֲ��ҵ�ǰ��վ���ܹ���ȡֵ��ֵ�ڵ�
		/// </summary>
		/// <param name="strName">��Ҫ��ȡֵ������</param>
		/// <returns>��Ӧ��ֵ�ڵ㣬û���ҵ����ؿ�</returns>
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
	/// ��վ��Ϣ������Ļ��࣬��������ȱʡ�����ݴ���
	/// </summary>
	public class WebsiteBase
	{
		#region ���ܺ���
		/// <summary>
		/// ������ҳ
		/// </summary>
		/// <param name="strURL">��ҳURL</param>
		/// <param name="encoding">���ر���</param>
		/// <returns>��ҳ����</returns>
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

		#region ��ȡͼ��������Ϣ
		/// <summary>
		/// ����Ŀ¼��ҳ��ȡͼ������
		/// </summary>
		/// <param name="strInput">��ҳ����</param>
		/// <returns>ͼ������</returns>
		public virtual string GetBookName( string strInput )
		{
			// ͨ��ƥ��ڵ��ȡ����������ʽ�Ĳ���
			string strMatch = @"<title>(?<BookName>.*)</title>";
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strMatch, RegexOptions.Singleline | RegexOptions.IgnoreCase );
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			if ( !match.Success )
				return null;

			return  match.Groups["BookName"].Value;
		}

		/// <summary>
		/// ����Ŀ¼��ҳ����Ŀ¼�б���������:URL����ʽ����
		/// </summary>
		/// <param name="strInput">��ҳ����</param>
		/// <returns>Ŀ¼�б��б�������Ϊ1��û���ҵ�ֵ�򷵻ؿ�</returns>
		public virtual NameValueCollection GetContent( string strInput )
		{
			// ͨ��ƥ��ڵ��ȡ����������ʽ�Ĳ���
			string strMatch = @"<a href=[(?<ArticleURL>\S*)|.(?<ArticleURL>\S*).].*?>(?<ArticleName>[^<]*?)</a>";
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strMatch, RegexOptions.Singleline | RegexOptions.IgnoreCase );
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			NameValueCollection nv = new NameValueCollection();
			while ( match.Success )
			{
				// ƥ��ɹ�����ȡ��Ҫ�����ֵ���������б�
				System.Text.RegularExpressions.GroupCollection gc = match.Groups;
				nv.Add( gc["ArticleName"].Value, gc["ArticleURL"].Value );
				match = match.NextMatch();
			}

			// ����ƥ�䷶Χ�ַ���
			return nv;
		}

		/// <summary>
		/// ����������ҳ��ȡ��������
		/// </summary>
		/// <param name="strInput">��ҳ����</param>
		/// <returns>��������</returns>
		public virtual string GetText( string strInput )
		{
			string[] strMatches = new string[]{ @"</p>|<br>", @"<font color=[.#[F]+|#[F]+].*?>.*?</font>|<script.*?>.*?</script>", @"&npbs;", "<.*?>"};
			string[] strReplacements = new string[]{ "\r\n", "", " ", "" };

			for ( int i = 0; i < strMatches.Length; i++ )
			{
				// ͨ��ƥ��ڵ��ȡ����������ʽ�Ĳ���
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strMatches[i], RegexOptions.Singleline | RegexOptions.IgnoreCase );
				strInput = regex.Replace( strInput, strReplacements[i] );
			}
			return strInput;
		}

		/// <summary>
		/// ����Ŀ¼��ҳ�жϵ�ǰͼ���Ƿ�����(������������δ������)
		/// </summary>
		/// <param name="strInput">��ҳ����</param>
		/// <returns>ͼ������</returns>
		public virtual bool IsIntact( string strInput )
		{
			return true;
		}
		#endregion
	}

	/// <summary>
	/// �������ͼ�������Ż�������
	/// </summary>
	public class WebsiteSina
	{
		#region ��ȡͼ��������Ϣ
		/// <summary>
		/// ����Ŀ¼��ҳ��ȡͼ������
		/// </summary>
		/// <param name="strInput">��ҳ����</param>
		/// <returns>ͼ������</returns>
		public virtual string GetBookName( string strInput )
		{
			// ͨ��ƥ��ڵ��ȡ����������ʽ�Ĳ���
			string strMatch = @"<TITLE>(?<BookName>.*)_.*_.*</TITLE>";
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strMatch, RegexOptions.Singleline | RegexOptions.IgnoreCase );
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			if ( !match.Success )
				return null;

			return  match.Groups["BookName"].Value;
		}

		/// <summary>
		/// ����Ŀ¼��ҳ����Ŀ¼�б���������:URL����ʽ����
		/// </summary>
		/// <param name="strInput">��ҳ����</param>
		/// <returns>Ŀ¼�б��б�������Ϊ1��û���ҵ�ֵ�򷵻ؿ�</returns>
		public virtual NameValueCollection GetContent( string strInput )
		{
			// ͨ��ƥ��ڵ��ȡ����������ʽ�Ĳ���
			string strMatch = @"<li><a href=(?<ArticleURL>\S*) target=_blank class=a03>(?<ArticleName>.*)</a>";
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strMatch, RegexOptions.Singleline | RegexOptions.IgnoreCase );
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			NameValueCollection nv = new NameValueCollection();
			while ( match.Success )
			{
				// ƥ��ɹ�����ȡ��Ҫ�����ֵ���������б�
				System.Text.RegularExpressions.GroupCollection gc = match.Groups;
				nv.Add( gc["ArticleName"].Value, gc["ArticleURL"].Value );
				match = match.NextMatch();
			}

			// ����ƥ�䷶Χ�ַ���
			return nv;
		}

		/// <summary>
		/// ����������ҳ��ȡ��������
		/// </summary>
		/// <param name="strInput">��ҳ����</param>
		/// <returns>��������</returns>
		public virtual string GetText( string strInput )
		{
			//�ҵ��ı�����HTML��ʶ
			string strMatch = @"<td class=l17 vAlign=top>.*?[<td[^>]*>.*?</td>]*.*?</td>";
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(strMatch, RegexOptions.Singleline | RegexOptions.IgnoreCase );
			System.Text.RegularExpressions.Match match = regex.Match(strInput);
			if ( !match.Success )
				return "";
			strInput = match.Value;

			// ��ȡÿ����Ȼ�ε��ı�
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

			// ���˲���ʽ�����ı���Ϣ
			string[] strMatches = new string[]{ @"<.*?>", "&nbsp|&nbsp;"};
			string[] strReplacements = new string[]{ "", " " };

			for ( int i = 0; i < strMatches.Length; i++ )
			{
				// ͨ��ƥ��ڵ��ȡ����������ʽ�Ĳ���
				regex = new System.Text.RegularExpressions.Regex(strMatches[i], RegexOptions.Singleline | RegexOptions.IgnoreCase );
				strInput = regex.Replace( strInput, strReplacements[i] );
			}
			return strInput;
		}

		/// <summary>
		/// ����Ŀ¼��ҳ�жϵ�ǰͼ���Ƿ�����(������������δ������)
		/// </summary>
		/// <param name="strInput">��ҳ����</param>
		/// <returns>ͼ������</returns>
		public virtual bool IsIntact( string strInput )
		{
			return true;
		}
		#endregion
	}

	/// <summary>
	/// ��վ��Ϣ������������װ�ػ�洢����֧�ֵ���վ��Ϣ
	/// </summary>
	public class WebsiteManager
	{
		/// <summary>
		/// ��վ��Ϣ�б��������д�website.xml�������վ��Ϣ
		/// </summary>
		private System.Collections.ArrayList	Websites = new System.Collections.ArrayList();
		
		/// <summary>
		/// ȱʡ��վ��Ϣ�����޷��ҵ���Ӧ��Ϣ��ʹ��ĳ����վ��Ϣ��ȡ����ʧ��ʱ��ʹ�õ�Ĭ�ϲ���
		/// ȱʡ��վ��Ϣֻ����һ�������website.xml�а��������ֻ�������һ��
		/// </summary>
		private Website				DefaultWebsite = null;

		/// <summary>
		/// ͨ���±��ȡ��վ��Ϣ
		/// </summary>
		/// <value name="index">��վ���±꣬��0��ʼ</value>
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
		/// ͨ��Ŀ¼URL���ȡ��վ��Ϣ��ͨ���Ƚ�URL��BaseURLȷ���Ƿ�ʹ���Ǹ���վ��Ϣ
		/// </summary>
		/// <value name="index">��վ���±꣬��0��ʼ</value>
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
		/// ͨ���ļ�������website.xml�ļ������а�����������վ��Ϣ
		/// </summary>
		/// <param name="stream">�ļ���</param>
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
		/// ����website.xml�ļ������а�����������վ��Ϣ
		/// </summary>
		/// <param name="strFilename">�ļ���</param>
		public void Load( string strFilename )
		{
			System.IO.Stream stream = new System.IO.FileStream( strFilename, System.IO.FileMode.Open );
			Load( stream );
			stream.Close();
		}
	}

	/// <summary>
	/// ��վ��Ϣ��ȡ�쳣��
	/// </summary>
	public class WebsiteException : System.ApplicationException 
	{
		/// <summary>
		/// �������ö��
		/// </summary>
		public enum ErrorCode 
		{ 
			/// <summary>δ֪����</summary>
			Unknown, 
			/// <summary>���ش���</summary>
			DownloadFail, 
			/// <summary>��ȡ��ҳ��Ϣ����</summary>
			GetTextFail 
		}

		/// <summary>��ǰ�������</summary>
		ErrorCode Error = ErrorCode.Unknown;
		
		/// <summary>������Ϣ</summary>
		string strMessage = null;
		
		/// <summary>��ȡ������ǰ�쳣����Ϣ</summary>
		public override string Message 
		{
			get 
			{
				switch ( Error )
				{
					case ErrorCode.DownloadFail:return "����ʧ�ܣ�ԭ��" + strMessage;
					case ErrorCode.GetTextFail:return "��ȡ�����ı�ʧ��";
					default:
						return  "δ֪����";
				}
			}
		}

		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="errcode">�������</param>
		/// <param name="msg">������Ϣ</param>
		public WebsiteException ( ErrorCode errcode, string msg )
		{
			Error = errcode;
			strMessage = msg;
		}
	}
}
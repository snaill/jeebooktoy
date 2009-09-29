/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace JeebookToy.JB
{
	/// <summary>
	/// Description of Book.
	/// </summary>
	public class Book
	{
		public Book()
		{
		}
		
		public Info Info{ get; set;	}
		public System.Collections.Generic.List<Chapter>	Chapters;
		
		public void Save( string strPath )
		{
			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();

			System.Xml.XmlNamespaceManager xnm = new System.Xml.XmlNamespaceManager(doc.NameTable);
			xnm.AddNamespace("", "http://docbook.org/ns/docbook");
			xnm.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
			xnm.AddNamespace("xi", "http://www.w3.org/2001/XInclude");
			
			if ( Info != null )
			{
				System.Xml.XmlElement elem = Info.ToXmlElement(doc);
				if ( elem != null )
					doc.AppendChild( elem );
			}
			
			for ( int i = 0; i < Chapters.Count; i ++ )
			{
				//Chapters[i]
			}
		}
	}
}

﻿/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace JeebookToy.JB
{
	/// <summary>
	/// Description of Info.
	/// </summary>
	public class Info : Element
	{
		public Info()
		{
		}
		
		public string Title { get; set; }
		public Author Author{ get; set; }

		public System.Xml.XmlElement ToXmlElement(System.Xml.XmlDocument doc)
		{
			if ( ( Title == null || Title == "" ) && Author == null )
				return null;
			
			System.Xml.XmlElement elem = doc.CreateElement("info");
			if ( Title != null && Title != "" )
			{
				System.Xml.XmlElement elem2 = doc.CreateElement("title");
				elem2.Value = Title;
				elem.AppendChild( elem2 );
			}
			if ( Author != null )
			{
				System.Xml.XmlElement elem2 = Author.ToXmlElement( doc );
				if ( elem2 != null )
					elem.AppendChild(elem2);
			}
			
			return elem;
		}
	}
}
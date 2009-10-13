﻿/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace JeebookToy.JB
{
	/// <summary>
	/// Description of Link.
	/// </summary>
	public class Link
	{
		public Link()
		{
		}
		
		public string Href { get; set; }
		public string Text { get; set; }
		
		public System.Xml.XmlElement ToXmlElement(System.Xml.XmlDocument doc)
		{
			if ( ( Href == null || Href == "" ) && ( Text == null || Text == "" ))
				return null;
			
			System.Xml.XmlElement elem = doc.CreateElement("para");
			System.Xml.XmlElement elem2 = doc.CreateElement("link");
			System.Xml.XmlAttribute attr = doc.CreateAttribute("href", "xlink");
			attr.Value = Href;

			elem2.Attributes.Append( attr );
			elem2.Value = Text;
			
			elem.AppendChild( elem2 );
			return elem;
		}

	}
}

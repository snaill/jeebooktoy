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
	/// Description of Author.
	/// </summary>
	public class Author : Element
	{
		public Author()
		{
		}
		
		public string OtherName { get; set; }
				
		public System.Xml.XmlElement ToXmlElement(System.Xml.XmlDocument doc)
		{
			if ( OtherName == null || OtherName == "" )
				return null;
			
			System.Xml.XmlElement elem = doc.CreateElement("author");
			System.Xml.XmlElement elem2 = doc.CreateElement("personname");
			System.Xml.XmlElement elem3 = doc.CreateElement("othername");
			elem3.Value = OtherName;
			
			elem.AppendChild( elem2 );
			elem2.AppendChild( elem3 );
			
			return elem;
		}

	}
}

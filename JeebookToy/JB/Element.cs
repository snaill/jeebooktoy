﻿/*
 * Created by SharpDevelop.
 * User: liming
 * Date: 2009-9-27
 * Time: 12:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace JeebookToy.JB
{
	/// <summary>
	/// Description of Element.
	/// </summary>
	public interface Element
	{
		System.Xml.XmlElement ToXmlElement(System.Xml.XmlDocument doc);
	}
}
/*
 * Created by SharpDevelop.
 * User: Snaill
 * Date: 2009/10/5
 * Time: 22:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace JeebookToy
{
	public enum Xsl2EngineType
	{
		Unknown,
		AltovaXML,
		Saxon
	}
	
	/// <summary>
	/// Description of Xsl2Engine.
	/// </summary>
	public static class Xsl2Engine
	{
		public static Xsl2EngineType CurrentEngine = Xsl2EngineType.Unknown;

		public static Xsl2EngineType CheckEngine()
		{
			try {
				Altova.AltovaXML.ApplicationClass ac = new Altova.AltovaXML.ApplicationClass();
				return Xsl2EngineType.AltovaXML;
			} catch (Exception)
			{
			}
			
			try {
				Saxon.Api.Processor	processor = new Saxon.Api.Processor();
				return Xsl2EngineType.Saxon;
			}catch (Exception)
			{			
			}

			return Xsl2EngineType.Unknown;
		}
		
		public static string TransformByAltovaXML( string strXml, string strXsl )
		{
			Altova.AltovaXML.ApplicationClass ac = new Altova.AltovaXML.ApplicationClass();
            ac.XSLT2.InputXMLFromText = strXml;
            ac.XSLT2.XSLFromText = strXsl;
            return ac.XSLT2.ExecuteAndGetResultAsString();			
		}
		
		public static string TransformBySaxon( string strXml, string strXsl )
		{
			//
			System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
            xml.LoadXml(strXml);
            
            //
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			Saxon.Api.Processor	processor = new Saxon.Api.Processor();
            Saxon.Api.XsltCompiler compiler = processor.NewXsltCompiler();
            
            System.Xml.XmlReader xr = System.Xml.XmlReader.Create( new System.IO.StringReader( strXsl ) );
			Saxon.Api.XsltTransformer transformer = compiler.Compile(xr).Load();
			
			Saxon.Api.XdmNode inputNode = processor.NewDocumentBuilder().Build(xml);
            transformer.InitialContextNode = inputNode;
            
            Saxon.Api.TextWriterDestination dest = new Saxon.Api.TextWriterDestination( System.Xml.XmlWriter.Create( sb ) );
            transformer.Run(dest);
            
			return sb.ToString();		
		}
		
		public static string Transform( string strXml, string strXsl )
		{
			switch ( CurrentEngine )
			{
				case Xsl2EngineType.AltovaXML:
					return TransformByAltovaXML(strXml, strXsl);
				case Xsl2EngineType.Saxon:
					return TransformBySaxon(strXml, strXsl);
			}
			
			return "";
		}
	}
}

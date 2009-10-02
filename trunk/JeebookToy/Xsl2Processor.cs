using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Xsl;
using Saxon.Api;

namespace SaxonWrapper
{
    public class Xsl2Processor
    {
        Processor processor;
        XsltCompiler compiler;
        XsltTransformer transformer;

        public Xsl2Processor()
        {
            // Create a Processor instance.
            processor = new Processor();
            compiler = processor.NewXsltCompiler();
            
        }

        public void Load(string XslPath)
        {
            TextReader input = new StreamReader(XslPath);
            transformer = compiler.Compile(input).Load();
            input.Close();
        }

        public void Load(XmlReader xmlReader)
        {
            transformer = compiler.Compile(xmlReader).Load();
        }

        public void Load(XmlNode xslDoc)
        {
            XmlNodeReader xmlNodeReader = new XmlNodeReader(xslDoc);
            Load(xmlNodeReader);
        }

        public void Transform(XmlNode input, XmlWriter output)
        {
            XdmNode inputNode = processor.NewDocumentBuilder().Build(input);
            transformer.InitialContextNode = inputNode;
            TextWriterDestination dest = new TextWriterDestination(output);
            transformer.Run(dest);
        }
    }
}

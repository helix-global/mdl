using System;
using System.IO;
using BinaryStudio.Modeling.MetadataInterchange;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure;

namespace xmi
    {
    internal class Program
        {
        private const String RootPath = @"C:\TFS";
        private static void Main(String[] args)
            {
            var o = MetadataReader.LoadFrom(new ObjectFactory(),new Uri($"file://{Path.Combine(RootPath,@"mdl\docs\ptc-18-01-01.xmi")}"));
            }

        private class ObjectFactory : IObjectFactory
            {
            public Object CreateObject(String NamespaceURI, String TypeName)
                {
                return (new ModelFactory()).CreateObject(NamespaceURI,TypeName);
                }
            }
        }
    }

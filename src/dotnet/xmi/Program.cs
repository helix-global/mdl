using System;
using System.IO;
using BinaryStudio.Modeling.MetadataInterchange;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure;

namespace xmi
    {
    internal class Program
        {
        private const String RootPath = @"C:\TFS";
        private static readonly IObjectFactory ObjectFactory = new EObjectFactory();
        private static readonly IExternalPackageResolver ExternalPackageResolver = new EExternalPackageResolver();

        private static void Main(String[] args)
            {
            var o = MetadataReader.LoadFrom(ObjectFactory,ExternalPackageResolver,
                new Uri($"file://{Path.Combine(RootPath,@"mdl\docs\ptc-18-01-01.xmi")}"));
            if (o != null)
                {
                Console.WriteLine("OK");
                }
            }

        private class EObjectFactory : IObjectFactory
            {
            public Boolean IsSupportedNamespace(String NamespaceURI)
                {
                if (NamespaceURI == "http://www.omg.org/spec/XMI/20131001") { return true;  }
                if (NamespaceURI == "http://www.omg.org/spec/UML/20131001") { return true;  }
                if (NamespaceURI == "http://www.omg.org/spec/UML/20161101") { return true;  }
                if (NamespaceURI == "http://www.omg.org/spec/MOF/20131001") { return false; }
                return (new ModelFactory()).IsSupportedNamespace(NamespaceURI);
                }

            public Object CreateObject(String NamespaceURI, String TypeName)
                {
                return (new ModelFactory()).CreateObject(NamespaceURI,TypeName);
                }
            }

        private class EExternalPackageResolver : IExternalPackageResolver {
            public Object Resolve(Uri uri) {
                switch (uri.AbsoluteUri) {
                    #region http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi
                    case "http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi":
                        {
                        return MetadataReader.LoadFrom(ObjectFactory,ExternalPackageResolver,new Uri($"file://{Path.Combine(RootPath,@"mdl\docs\ptc-18-01-02.xmi")}"));
                        }
                    #endregion
                    }
                throw new NotSupportedException();
                }
            }
        }
    }

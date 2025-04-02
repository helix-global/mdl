using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace BinaryStudio.Modeling.MetadataInterchange
    {
    public abstract class MetadataReader
        {
        #region M:LoadFrom(IObjectFactory,IExternalPackageResolver,XmlReader):Object
        public static Object LoadFrom(IObjectFactory factory,IExternalPackageResolver ExternalPackageResolver,XmlReader reader) {
            if (factory == null) { throw new ArgumentNullException(nameof(factory)); }
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:
                        {
                        if (reader.LocalName == "XMI") {
                            using (var r = reader.ReadSubtree()) {
                                var o = new XMIMetadataReader();
                                return o.LoadFrom(factory,ExternalPackageResolver,reader);
                                }
                            }
                        throw new NotSupportedException();
                        }
                    }
                }
            return null;
            }
        #endregion
        #region M:LoadFrom(IObjectFactory,IExternalPackageResolver,Uri):Object
        public static Object LoadFrom(IObjectFactory factory,IExternalPackageResolver ExternalPackageResolver,Uri uri) {
            if (factory == null) { throw new ArgumentNullException(nameof(factory)); }
            if (uri == null) { throw new ArgumentNullException(nameof(uri)); }
            switch (uri.Scheme) {
                case "file":
                    {
                    switch (Path.GetExtension(uri.AbsolutePath)) {
                        case ".xmi":
                        case ".xml":
                            {
                            var o = XDocument.Load(uri.AbsolutePath);
                            using (var reader = o.CreateReader()) {
                                return LoadFrom(factory,ExternalPackageResolver,reader);
                                }
                            }
                        default: throw new NotSupportedException();
                        }
                    }
                default: throw new NotSupportedException();
                }
            //switch (Path.GetExtension(filename)) {
            //    
            //    case ".xml":
            //        {
            //        var r = XElement.Load(filename);
            //        }
            //        break;
            //    }
            return null;
            }
        #endregion
        }
    }

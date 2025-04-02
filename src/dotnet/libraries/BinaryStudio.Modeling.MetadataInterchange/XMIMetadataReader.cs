using System;
using System.Xml;
using System.Xml.Serialization;

namespace BinaryStudio.Modeling.MetadataInterchange
    {
    internal class XMIMetadataReader
        {
        public XMIMetadataReader()
            {
            }

        #region M:LoadFrom(IObjectFactory,IExternalPackageResolver,XmlReader):Object
        public Object LoadFrom(IObjectFactory factory,IExternalPackageResolver ExternalPackageResolver,XmlReader reader) {
            if (factory == null) { throw new ArgumentNullException(nameof(factory)); }
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            var r = (IXmlSerializable)new XMIPackage(factory,ExternalPackageResolver);
            r.ReadXml(reader);
            return r;
            }
        #endregion
        }
    }
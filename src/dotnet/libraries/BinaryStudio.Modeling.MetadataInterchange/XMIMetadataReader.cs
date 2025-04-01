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

        #region M:LoadFrom(IObjectFactory,XmlReader):Object
        public Object LoadFrom(IObjectFactory factory,XmlReader reader) {
            if (factory == null) { throw new ArgumentNullException(nameof(factory)); }
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            var r = (IXmlSerializable)new XMIPackage(factory);
            r.ReadXml(reader);
            return r;
            }
        #endregion
        }
    }
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BinaryStudio.Modeling.MetadataInterchange
    {
    [DefaultProperty("Content")]
    internal class XMIPackage : IXmlSerializable
        {
        public IObjectFactory Factory { get; }
        public String NamespaceURI { get;private set; }
        public XMIDocumentation Documentation { get;set; }
        public Object Content { get;set; }

        public XMIPackage(IObjectFactory factory)
            {
            if (factory == null) { throw new ArgumentNullException(nameof(factory)); }
            Factory = factory;
            }

        #region M:IXmlSerializable.GetSchema:XmlSchema
        /// <summary>This method is reserved and should not be used. When implementing the <see langword="IXmlSerializable"/> interface, you should return <see langword="null" /> (<see langword="Nothing" /> in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.</summary>
        /// <returns>An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.</returns>
        XmlSchema IXmlSerializable.GetSchema()
            {
            throw new NotImplementedException();
            }
        #endregion
        #region M:IXmlSerializable.ReadXml(XmlReader)
        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized.</param>
        void IXmlSerializable.ReadXml(XmlReader reader) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            NamespaceURI = reader.NamespaceURI;
            Apply(Factory,NamespaceURI,this,reader);
            }
        #endregion
        #region M:IXmlSerializable.WriteXml(XmlWriter)
        /// <summary>Converts an object into its XML representation.</summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized.</param>
        void IXmlSerializable.WriteXml(XmlWriter writer)
            {
            throw new NotImplementedException();
            }
        #endregion
        #region M:Apply(IObjectFactory,String,Object,XmlReader)
        private static void Apply(IObjectFactory factory,String xmi,Object target,XmlReader source) {
            if (target == null) { throw new ArgumentNullException(nameof(target)); }
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            source.MoveToContent();
            var properties = new Dictionary<String,PropertyDescriptor>(StringComparer.OrdinalIgnoreCase);
            foreach (PropertyDescriptor pi in TypeDescriptor.GetProperties(target)) {
                properties[pi.Name]=pi;
                }
            if (source.HasAttributes) {
                while (source.MoveToNextAttribute()) {
                    if (String.IsNullOrWhiteSpace(source.NamespaceURI)) {
                        if (!properties.TryGetValue(source.LocalName,out var pi)) { throw new MissingMemberException($@"Attempted to access a missing property ""{source.LocalName}""."); }
                        SetValue(target,pi,source.Value);
                        }
                    }
                source.MoveToElement();
                }
            while (source.Read()) {
                switch (source.NodeType) {
                    case XmlNodeType.Element:
                        {
                        var type  = source.GetAttribute("type",xmi);
                        var id    = source.GetAttribute("id",xmi);
                        var idref = source.GetAttribute("idref",xmi);
                        if (String.IsNullOrWhiteSpace(source.NamespaceURI)) {
                            if (properties.TryGetValue(source.LocalName,out var pi)) {
                                if (!String.IsNullOrWhiteSpace(type)) {
                                    var o = factory.CreateObject(source.NamespaceURI,source.LocalName);
                                    using (var reader = source.ReadSubtree())
                                        {
                                        Apply(factory,xmi,o,reader);
                                        }
                                    var value = pi.GetValue(target);
                                    if (value is IList L) {
                                        L.Add(o);
                                        }
                                    else
                                        {
                                        pi.SetValue(target,o);
                                        }
                                    }
                                else
                                    {
                                    if ((pi.PropertyType == typeof(String)) ||
                                        (pi.PropertyType == typeof(Int32))  ||
                                        (pi.PropertyType == typeof(Int64))  ||
                                        (pi.PropertyType == typeof(Int16))  ||
                                        (pi.PropertyType == typeof(UInt32)) ||
                                        (pi.PropertyType == typeof(UInt64)) ||
                                        (pi.PropertyType == typeof(UInt16)))
                                        {
                                        SetValue(target,pi,source.ReadElementContentAsString());
                                        }
                                    else
                                        {
                                        var o = Activator.CreateInstance(pi.PropertyType);
                                        using (var reader = source.ReadSubtree()) {
                                            Apply(factory,xmi,o,reader);
                                            }
                                        pi.SetValue(target,o);
                                        }
                                    }
                                continue;
                                }
                            throw new MissingMemberException($@"Attempted to access a missing property ""{source.LocalName}"".");
                            }
                        else
                            {
                            var pi = TypeDescriptor.GetDefaultProperty(target);
                            if (pi == null) { throw new MissingMemberException($@"Could not find a default property."); }
                            var o = factory.CreateObject(source.NamespaceURI,source.LocalName);
                            using (var reader = source.ReadSubtree())
                                {
                                Apply(factory,xmi,o,reader);
                                }
                            pi.SetValue(target,o);
                            }
                        }
                        break;
                    }
                }
            }
        #endregion
        #region M:SetValue(Object,PropertyDescriptor,Object)
        private static void SetValue(Object component,PropertyDescriptor descriptor,Object value) {
            var converter = descriptor.Converter;
            if (converter.CanConvertFrom(value.GetType())) {
                descriptor.SetValue(component,converter.ConvertFrom(value));
                }
            else
                {
                descriptor.SetValue(component,value);
                }
            }
        #endregion

        private static readonly IDictionary<String,Type> types = new Dictionary<String,Type>();
        }
    }
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BinaryStudio.Modeling.MetadataInterchange
    {
    [DefaultProperty("Content")]
    internal class XMIPackage : IXmlSerializable
        {
        private class PendingChange
            {
            public Object TargetObject { get;set; }
            public PropertyDescriptor TargetPropertyDescriptor { get;set; }
            public String SourceObjectIdentity { get;set; }
            public Boolean IsAssignment { get;set; }
            public Boolean IsAddToList { get;set; }
            }

        public IObjectFactory Factory { get; }
        public String NamespaceURI { get;private set; }
        public XMIDocumentation Documentation { get;set; }
        [XMIIsTargetList] public IList<Object> Content { get; }
        public IDictionary<String,String> NamespaceURIForPrefix { get; }
        public IDictionary<String,String> PrefixForNamespaceURI { get; }
        public IDictionary<String,Object> ObjectForID { get; }
        public IDictionary<String,Object> ObjectForHREF { get; }
        public String NamespacePrefix { get;private set; }
        private IList<PendingChange> PendingChanges { get; }
        public IExternalPackageResolver ExternalPackageResolver { get; }

        public XMIPackage(IObjectFactory factory,IExternalPackageResolver ExternalPackageResolver)
            {
            if (factory == null) { throw new ArgumentNullException(nameof(factory)); }
            Factory = factory;
            NamespaceURIForPrefix = new Dictionary<String,String>();
            PrefixForNamespaceURI = new Dictionary<String,String>();
            ObjectForID = new SortedDictionary<String,Object>();
            ObjectForHREF = new Dictionary<String,Object>();
            PendingChanges = new List<PendingChange>();
            this.ExternalPackageResolver = ExternalPackageResolver;
            Content = new List<Object>();
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
            if (reader.HasAttributes) {
                while (reader.MoveToNextAttribute()) {
                    if (String.Equals(reader.NamespaceURI,"http://www.w3.org/2000/xmlns/")) {
                        NamespaceURIForPrefix[reader.LocalName]=reader.Value;
                        PrefixForNamespaceURI[reader.Value]=reader.LocalName;
                        }
                    }
                reader.MoveToElement();
                }
            NamespacePrefix = PrefixForNamespaceURI[NamespaceURI];
            Apply(NamespaceURI,this,reader);
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
        #region M:Apply(String,Object,XmlReader)
        private void Apply(String xmi,Object target,XmlReader source) {
            if (target == null) { throw new ArgumentNullException(nameof(target)); }
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            source.MoveToContent();
            var properties = new Dictionary<String,PropertyDescriptor>(StringComparer.OrdinalIgnoreCase);
            foreach (PropertyDescriptor pi in TypeDescriptor.GetProperties(target)) {
                properties[pi.Name]=pi;
                }
            var ControlAttributes = new Dictionary<String,String>();
            var AssgnmtAttributes = new Dictionary<String,String>();
            if (source.HasAttributes) {
                while (source.MoveToNextAttribute()) {
                    if (String.IsNullOrWhiteSpace(source.NamespaceURI)) {
                        AssgnmtAttributes[source.LocalName]=source.Value;
                        }
                    else
                        {
                        ControlAttributes[source.Name]=source.Value;
                        }
                    }
                source.MoveToElement();
                }
            //var id = GetValueOrDefault(ControlAttributes,$"{NamespacePrefix}:id");
            foreach (var attribute in AssgnmtAttributes) {
                if (!properties.TryGetValue(attribute.Key, out var pi)) { throw new MissingMemberException($@"Attempted to access a missing property ""{attribute.Key}""."); }
                SetValue(target,pi,attribute.Value);
                }
            while (source.Read()) {
                switch (source.NodeType) {
                    case XmlNodeType.Element:
                        {
                        var type  = source.GetAttribute("type",xmi);
                        var idref = source.GetAttribute("idref",xmi);
                        var id    = source.GetAttribute("id",xmi);
                        var href  = source.GetAttribute("href");

                        if (String.IsNullOrWhiteSpace(source.NamespaceURI)) {
                            if (properties.TryGetValue(source.LocalName,out var pi)) {
                                if (!String.IsNullOrWhiteSpace(type)) {
                                    DecodeQualifiedName(type,out var TypeNamespaceURI,out var TypeLocalName);
                                    var o = Factory.CreateObject(TypeNamespaceURI,TypeLocalName);
                                    if (!String.IsNullOrWhiteSpace(id)) { ObjectForID.Add(id,o); }
                                    using (var reader = source.ReadSubtree())
                                        {
                                        Apply(xmi,o,reader);
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
                                    if (!String.IsNullOrWhiteSpace(href)) {
                                        ResolveExternalObject(href,out var o);
                                        SetValue(target,pi,o);
                                        continue;
                                        }

                                    if (CanReadFromContentString(pi.PropertyType))
                                        {
                                        SetValue(target,pi,source.ReadElementContentAsString());
                                        }
                                    else
                                        {
                                        var TargetList = pi.GetValue(target) as IList;
                                        if (!String.IsNullOrWhiteSpace(idref)) {
                                            if (pi.IsReadOnly) {
                                                if (TargetList != null) {
                                                    if (ObjectForID.TryGetValue(idref,out var r)) {
                                                        TargetList.Add(r);
                                                        continue;
                                                        }
                                                    else
                                                        {
                                                        PendingChanges.Add(new PendingChange{
                                                            TargetObject = TargetList,
                                                            SourceObjectIdentity = idref,
                                                            IsAddToList = true
                                                            });
                                                        continue;
                                                        }
                                                    }
                                                }
                                            if (pi.PropertyType.IsConstructedGenericType) {
                                                var GenericType = pi.PropertyType.GetGenericTypeDefinition();
                                                if (GenericType == typeof(IList<>)) {
                                                    throw new NullReferenceException($@"Unable connect to the target list property ""{pi.Name}"".");
                                                    }
                                                }
                                            throw new InvalidDataException();
                                            }

                                        if (pi.IsReadOnly && (TargetList != null)) {
                                            var TargetListType = TargetList.GetType();
                                            if (TargetListType.IsConstructedGenericType) {
                                                var TargetListArgumentType = TargetListType.GenericTypeArguments[0];
                                                if (CanReadFromContentString(TargetListArgumentType)) {
                                                    TargetList.Add(source.ReadElementContentAsString());
                                                    continue;
                                                    }
                                                }
                                            }

                                        //if (pi.GetValue(target) is 
                                        var o = Activator.CreateInstance(pi.PropertyType);
                                        using (var reader = source.ReadSubtree()) {
                                            Apply(xmi,o,reader);
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
                            if (Factory.IsSupportedNamespace(source.NamespaceURI)) {
                                var pi = TypeDescriptor.GetDefaultProperty(target);
                                if (pi == null) { throw new MissingMemberException($@"Could not find a default property."); }
                                var o = Factory.CreateObject(source.NamespaceURI,source.LocalName);
                                if (!String.IsNullOrWhiteSpace(id)) { ObjectForID.Add(id,o); }
                                using (var reader = source.ReadSubtree())
                                    {
                                    Apply(xmi,o,reader);
                                    }
                                //if (target is XMIPackage pkg)
                                //        {
                                //        SetValue(target,pi,o);
                                //        }
                                pi.SetValue(target,o);
                                }
                            }
                        }
                        break;
                    }
                }
            }
        #endregion
        #region M:SetValue(Object,PropertyDescriptor,Object)
        private void SetValue(Object TargetObject,PropertyDescriptor TargetDescriptor,Object value) {
            if (TargetDescriptor == null) { throw new ArgumentNullException(nameof(TargetDescriptor)); }
            if (TargetDescriptor.IsReadOnly) {
                if (TargetDescriptor.Attributes.Contains(XMIIsTargetListAttribute.Yes)) {
                    if (TargetDescriptor.GetValue(TargetObject) is IList TargetList) {
                        TargetList.Add(value);
                        return;
                        }
                    if (TargetDescriptor.PropertyType.IsConstructedGenericType) {
                        var GenericType = TargetDescriptor.PropertyType.GetGenericTypeDefinition();
                        if (GenericType == typeof(IList<>)) {
                            throw new NullReferenceException($@"Unable connect to the target list property ""{TargetDescriptor.Name}"".");
                            }
                        }
                    }
                }

            var SourceType = value.GetType();
            var TargetType = TargetDescriptor.PropertyType;
            var converter = TargetDescriptor.Converter;
            if (converter.CanConvertFrom(SourceType)) {
                TargetDescriptor.SetValue(TargetObject,converter.ConvertFrom(value));
                }
            else
                {
                if (SourceType == typeof(String)) {
                    if (TargetType.IsClass || TargetType.IsInterface) {
                        var id = (String)value;
                        if (ObjectForID.TryGetValue(id,out var o)) {
                            SetValue(TargetObject,TargetDescriptor,o);
                            return;
                            }
                        PendingChanges.Add(new PendingChange{
                            TargetObject = TargetObject,
                            TargetPropertyDescriptor = TargetDescriptor,
                            SourceObjectIdentity = id,
                            IsAssignment = true
                            });
                        return;
                        }
                    }
                TargetDescriptor.SetValue(TargetObject,value);
                }
            }
        #endregion
        #region M:DecodeQualifiedName(String,{out}String,{out}String)
        [SuppressMessage("ReSharper","ParameterHidesMember")]
        private void DecodeQualifiedName(String Source,out String NamespaceURI,out String LocalName) {
            if (String.IsNullOrWhiteSpace(Source)) { throw new ArgumentOutOfRangeException(nameof(Source)); }
            var i = Source.IndexOf(':');
            if (i != -1)
                {
                NamespaceURI = NamespaceURIForPrefix[Source.Substring(0,i)];
                LocalName = Source.Substring(i+1);
                }
            else
                {
                NamespaceURI = null;
                LocalName = Source;
                }
            }
        #endregion
        #region M:GetValueOrDefault(IDictionary<String,String>,String):String
        private static String GetValueOrDefault(IDictionary<String,String> source,String key) {
            return source.TryGetValue(key,out var r)
                ? r
                : null;
            }
        #endregion
        #region M:CanReadFromContentString(Type):Boolean
        private static Boolean CanReadFromContentString(Type Type) {
            return (Type == typeof(String)) ||
                   (Type == typeof(Int32))  ||
                   (Type == typeof(Int64))  ||
                   (Type == typeof(Int16))  ||
                   (Type == typeof(UInt32)) ||
                   (Type == typeof(UInt64)) ||
                   (Type == typeof(UInt16));
            }
        #endregion
        #region M:ResolveExternalObject(String,{out}Object)
        private void ResolveExternalObject(String href,out Object o) {
            o = null;
            if (!ObjectForHREF.TryGetValue(href,out o)) {
                if (ExternalPackageResolver != null) {
                    var values = href.Split('#');
                    var uri = href;
                    String idref = null;
                    if (values.Length > 1) {
                        uri   = values[0];
                        idref = values[1];
                        }
                    o = ExternalPackageResolver.Resolve(new Uri(uri));
                    if (o is XMIPackage xmipkg) {
                        if (!String.IsNullOrWhiteSpace(idref)) {
                            o = xmipkg.ObjectForID[idref];
                            ObjectForHREF[href]=o;
                            }
                        }
                    }
                }
            }
        #endregion

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return $"XMIPackage";
            }
        #endregion

        private static readonly IDictionary<String,Type> types = new Dictionary<String,Type>();
        }
    }
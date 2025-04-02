using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
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
            public Object TargetObject;
            public PropertyDescriptor TargetPropertyDescriptor;
            public String SourceObjectIdentity;
            public Boolean IsAssignment;
            public Boolean IsAddToList;
            public Boolean Completed;
            public IList TargetList;
            public Object SourceValue;

            public override String ToString() {
                return Completed
                    ? "Completed"
                    : "Pending";
                }
            }

        private struct Value
            {
            public Object SourceValue;
            public Boolean ForceIDREF;
            }

        public IObjectFactory Factory { get; }
        public String NamespaceURI { get;private set; }
        public XMIDocumentation Documentation { get;set; }
        [IsTargetList] public IList<Object> Content { get; }
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
            foreach (var change in PendingChanges) {
                if (change.IsAddToList) {
                    if (change.TargetList != null) {
                        if (!String.IsNullOrWhiteSpace(change.SourceObjectIdentity)) {
                            change.TargetList.Add(ObjectForID[change.SourceObjectIdentity]);
                            change.Completed = true;
                            continue;
                            }
                        change.TargetList.Add(change.SourceValue);
                        change.Completed = true;
                        }
                    }
                else
                    {
                    if (!String.IsNullOrWhiteSpace(change.SourceObjectIdentity)) {
                        change.TargetPropertyDescriptor.SetValue(change.TargetObject,ObjectForID[change.SourceObjectIdentity]);
                        change.Completed = true;
                        continue;
                        }
                    change.TargetPropertyDescriptor.SetValue(change.TargetObject,change.SourceValue);
                    change.Completed = true;
                    }
                }
            return;
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
                                #region {Construction from "prefix:type"}
                                if (!String.IsNullOrWhiteSpace(type)) {
                                    DecodeQualifiedName(type,out var TypeNamespaceURI,out var TypeLocalName);
                                    var o = Factory.CreateObject(TypeNamespaceURI,TypeLocalName);
                                    if (!String.IsNullOrWhiteSpace(id)) { ObjectForID.Add(id,o); }
                                    using (var reader = source.ReadSubtree()) {
                                        Apply(xmi,o,reader);
                                        }
                                    SetValue(target,pi,o);
                                    continue;
                                    }
                                #endregion
                                #region {Loading external object from "href"}
                                    if (!String.IsNullOrWhiteSpace(href)) {
                                    ResolveExternalObject(href,out var o);
                                    SetValue(target,pi,o);
                                    continue;
                                    }
                                #endregion
                                #region {Loading element content for "primitive" type}
                                if (CanReadFromContentString(pi.PropertyType))
                                    {
                                    SetValue(target,pi,source.ReadElementContentAsString());
                                    continue;
                                    }
                                #endregion
                                #region {Perform for "xmi:idref"}
                                if (!String.IsNullOrWhiteSpace(idref)) {
                                    SetValue(target,pi,(TargetList,ElementType)=>
                                        new Value{
                                            SourceValue = idref,
                                            ForceIDREF = true
                                            });
                                    continue;
                                    }
                                #endregion
                                #region {Perform ordinary property processing}
                                SetValue(target,pi,(TargetList,ElementType)=>{
                                    if (TargetList != null) {
                                        if (CanReadFromContentString(ElementType)) {
                                            return new Value{
                                                ForceIDREF = false,
                                                SourceValue=source.ReadElementContentAsString()
                                                };
                                            }
                                        }
                                    var o = Activator.CreateInstance(pi.PropertyType);
                                    using (var reader = source.ReadSubtree()) {
                                        Apply(xmi,o,reader);
                                        }
                                    return new Value{
                                        SourceValue = o,
                                        ForceIDREF = false
                                        };
                                    });
                                #endregion
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
                                SetValue(target,pi,o);
                                }
                            }
                        }
                        break;
                    }
                }
            }
        #endregion
        #region M:SetValue(Object,PropertyDescriptor,Object)
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private void SetValue(Object TargetObject,PropertyDescriptor TargetDescriptor,Object SourceValue) {
            SetValue(TargetObject,TargetDescriptor,(TargetList,ElementType)=>
                new Value {
                    SourceValue=SourceValue,
                    ForceIDREF = false
                    });
            //if (TargetDescriptor == null) { throw new ArgumentNullException(nameof(TargetDescriptor)); }
            //var SourceType = SourceValue.GetType();
            //if (TargetDescriptor.IsReadOnly) {
            //    if (TargetDescriptor.GetValue(TargetObject) is IList TargetList) {
            //        var ElementType = GetListTypeElementType(TargetList.GetType());
            //        if (ElementType.IsAssignableFrom(SourceType)) {
            //            PendingChanges.Add(new PendingChange{
            //                TargetList = TargetList,
            //                SourceValue = SourceValue,
            //                IsAddToList = true
            //                });
            //            return;
            //            }
            //        if (SourceValue is String S) {
            //            if (TargetDescriptor.Attributes.Contains(IsIDREFAttribute.Yes)) {
            //                PendingChanges.Add(new PendingChange{
            //                    TargetList = TargetList,
            //                    SourceObjectIdentity = S,
            //                    IsAddToList = true
            //                    });
            //                return;
            //                }
            //            }
            //        PendingChanges.Add(new PendingChange{
            //            TargetList = TargetList,
            //            SourceValue = SourceValue,
            //            IsAddToList = true
            //            });
            //        return;
            //        }
            //    if (IsListType(TargetDescriptor.PropertyType)) { throw new NullReferenceException($@"Unable connect to the target list property ""{TargetDescriptor.Name}""."); }
            //    }

            //var TargetType = TargetDescriptor.PropertyType;
            //var Converter = TargetDescriptor.Converter;
            //if (!Converter.CanConvertFrom(SourceType)) {
            //    if (SourceValue is String S) {
            //        if (TargetDescriptor.Attributes.Contains(IsIDREFAttribute.Yes)) {
            //            PendingChanges.Add(new PendingChange {
            //                TargetObject = TargetObject,
            //                TargetPropertyDescriptor = TargetDescriptor,
            //                SourceObjectIdentity = S,
            //                IsAssignment = true
            //                });
            //            return;
            //            }
            //        }
            //    TargetDescriptor.SetValue(TargetObject,SourceValue);
            //    }
            //else
            //    {
            //    TargetDescriptor.SetValue(TargetObject,Converter.ConvertFrom(SourceValue));
            //    }
            }
        #endregion
        #region M:SetValue(Object,PropertyDescriptor,Object)
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private void SetValue(Object TargetObject,PropertyDescriptor TargetDescriptor,Func<IList,Type,Value> SourceValueProvider) {
            if (TargetDescriptor == null) { throw new ArgumentNullException(nameof(TargetDescriptor)); }
            Type SourceType = null;
            Value SourceValue;
            if (TargetDescriptor.IsReadOnly) {
                if (TargetDescriptor.GetValue(TargetObject) is IList TargetList) {
                    var ElementType = GetListTypeElementType(TargetList.GetType());
                    SourceValue = SourceValueProvider(TargetList,ElementType);
                    SourceType = SourceValue.SourceValue.GetType();
                    if (ElementType.IsAssignableFrom(SourceType)) {
                        PendingChanges.Add(new PendingChange{
                            TargetObject = TargetObject,
                            TargetList = TargetList,
                            SourceValue = SourceValue.SourceValue,
                            IsAddToList = true
                            });
                        return;
                        }
                    if (SourceValue.SourceValue is String S) {
                        if (TargetDescriptor.Attributes.Contains(IsIDREFAttribute.Yes) || SourceValue.ForceIDREF) {
                            PendingChanges.Add(new PendingChange{
                                TargetObject = TargetObject,
                                TargetList = TargetList,
                                SourceObjectIdentity = S,
                                IsAddToList = true
                                });
                            return;
                            }
                        }
                    PendingChanges.Add(new PendingChange{
                        TargetObject = TargetObject,
                        TargetList = TargetList,
                        SourceValue = SourceValue.SourceValue,
                        IsAddToList = true
                        });
                    return;
                    }
                if (IsListType(TargetDescriptor.PropertyType)) { throw new NullReferenceException($@"Unable connect to the target list property ""{TargetDescriptor.Name}""."); }
                }

            SourceValue = SourceValueProvider(null,null);
            SourceType = SourceValue.SourceValue.GetType();
            var Converter = TargetDescriptor.Converter;
            if (!Converter.CanConvertFrom(SourceType)) {
                if (SourceValue.SourceValue is String S) {
                    if (TargetDescriptor.Attributes.Contains(IsIDREFAttribute.Yes) || (SourceValue.ForceIDREF)) {
                        PendingChanges.Add(new PendingChange {
                            TargetObject = TargetObject,
                            TargetPropertyDescriptor = TargetDescriptor,
                            SourceObjectIdentity = S,
                            IsAssignment = true
                            });
                        return;
                        }
                    }
                TargetDescriptor.SetValue(TargetObject,SourceValue.SourceValue);
                }
            else
                {
                TargetDescriptor.SetValue(TargetObject,Converter.ConvertFrom(SourceValue.SourceValue));
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
        #region M:GetListTypeElementType(Type):Type
        private static Type GetListTypeElementType(Type ListType) {
            if (ListType == null) { throw new ArgumentNullException(nameof(ListType)); }
            if (ListType.IsGenericTypeDefinition) { throw new ArgumentOutOfRangeException(nameof(ListType)); }
            if (ListType.IsConstructedGenericType) {
                var IListType = typeof(IList<>);
                var Interfaces = ListType.GetInterfaces();
                foreach (var Interface in Interfaces) {
                    var GenericType = Interface.GetGenericTypeDefinition();
                    if (GenericType == IListType)
                        {
                        return ListType.GenericTypeArguments[0];
                        }
                    }
                }
            return typeof(Object);
            }
        #endregion
        #region M:IsListType(Type):Boolean
        private static Boolean IsListType(Type Type) {
            if (Type == null) { throw new ArgumentNullException(nameof(Type)); }
            var Interfaces = Type.GetInterfaces();
            foreach (var Interface in Interfaces) {
                if (Interface == typeof(IList))
                    {
                    return true;
                    }
                }
            if (Type.IsConstructedGenericType) {
                var GenericType = Type.GetGenericTypeDefinition();
                if (GenericType == typeof(IList<>))
                    {
                    return true;
                    }
                }
            return false;
            }
        #endregion

        private static readonly IDictionary<String,Type> types = new Dictionary<String,Type>();
        }
    }
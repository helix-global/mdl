using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace pre
    {
    internal class Package : ModelElement,IPackage,IPackageableElement
        {
        public String Name { get;private set; }
        public String Identifier { get;private set; }
        public IDictionary<String,Package> OwnedPackage { get; }
        public IDictionary<String,Class> OwnedClass { get; }
        public IDictionary<String,Enumeration> OwnedEnumeration { get; }
        public IDictionary<String,Association> OwnedAssociation { get; }
        public Package PackageOwner { get; }
        public override Model BaseModel { get{ return Owner?.BaseModel; }}
        IPackage IPackageableElement.Package { get { return PackageOwner; }}

        public IDictionary<String,IPackageableElement> PackagedElement { get {
            var r = new SortedDictionary<String,IPackageableElement>();
            foreach (var i in OwnedPackage)     { r.Add(i.Key,i.Value); }
            foreach (var i in OwnedClass)       { r.Add(i.Key,i.Value); }
            foreach (var i in OwnedEnumeration) { r.Add(i.Key,i.Value); }
            foreach (var i in OwnedAssociation) { r.Add(i.Key,i.Value); }
            return r;
            }}

        #region ctor
        public Package(Package owner)
            :base(owner)
            {
            PackageOwner = owner;
            OwnedPackage = new SortedDictionary<String,Package>();
            OwnedClass = new SortedDictionary<String,Class>();
            OwnedEnumeration = new SortedDictionary<String,Enumeration>();
            OwnedAssociation = new Dictionary<String,Association>();
            }
        #endregion

        #region M:ReadXml(XmlReader)
        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader)
            {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            Name = reader.GetAttribute("name");
            Identifier = reader.GetAttribute("id",xmi);
            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:
                        {
                        var type = reader.GetAttribute("type",xmi);
                        switch (reader.LocalName) {
                            #region packagedElement{uml:Package}
                            case "packagedElement" when type == "uml:Package":
                                {
                                var o = new Package(this);
                                using (var r = reader.ReadSubtree()) {
                                    o.ReadXml(r);
                                    }
                                OwnedPackage.Add(o.Identifier,o);
                                }
                                break;
                            #endregion
                            #region packagedElement{uml:Class}
                            case "packagedElement" when type == "uml:Class":
                                {
                                var o = new Class(this);
                                using (var r = reader.ReadSubtree()) {
                                    o.ReadXml(r);
                                    }
                                OwnedClass.Add(o.Identifier,o);
                                }
                                break;
                                #endregion
                            #region packagedElement{uml:Enumeration}
                            case "packagedElement" when type == "uml:Enumeration":
                                {
                                var o = new Enumeration(this);
                                using (var r = reader.ReadSubtree()) {
                                    o.ReadXml(r);
                                    }
                                OwnedEnumeration.Add(o.Identifier,o);
                                }
                                break;
                                #endregion
                            #region packagedElement{uml:Association}
                            case "packagedElement" when type == "uml:Association":
                                {
                                var o = new Association(this);
                                using (var r = reader.ReadSubtree()) {
                                    o.ReadXml(r);
                                    }
                                OwnedAssociation.Add(o.Identifier,o);
                                }
                                break;
                            #endregion
                            case "packageImport":
                                break;
                            default: throw new NotSupportedException();
                            }
                        }
                        break;
                    }
                }
            }
        #endregion
        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return $"{Name}";
            }
        #endregion
        #region M:OnAfterLoadModel
        public override void OnAfterLoadModel()
            {
            foreach (var i in OwnedEnumeration) { i.Value.OnAfterLoadModel(); }
            foreach (var i in OwnedClass)       { i.Value.OnAfterLoadModel(); }
            foreach (var i in OwnedAssociation) { i.Value.OnAfterLoadModel(); }
            foreach (var i in OwnedPackage)     { i.Value.OnAfterLoadModel(); }
            }
        #endregion
        #region M:FindModelElement(String):ModelElement
        public override ModelElement FindModelElement(String idref) {
            if (String.IsNullOrWhiteSpace(idref)) { throw new ArgumentOutOfRangeException(nameof(idref)); }
            var values = PackagedElement;
            if (values.TryGetValue(idref,out var e)) { return (ModelElement)e; }
            foreach (var value in values) {
                var r = value.Value.FindModelElement(idref);
                if (r != null)
                    {
                    return r;
                    }
                }
            return null;
            }
        #endregion
        }
    }
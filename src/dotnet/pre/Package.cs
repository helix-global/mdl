using System;
using System.Collections.Generic;
using System.Xml;

namespace pre
    {
    public class Package : ModelElement
        {
        public String Name { get;private set; }
        public ObjectIdentifier Identifier { get;private set; }
        public IList<Package> OwnedPackage { get; }
        public IList<Class> OwnedClass { get; }
        public IList<Enumeration> OwnedEnumeration { get; }
        public IDictionary<String,Association> OwnedAssociation { get; }
        public Package PackageOwner { get; }
        public override Model BaseModel { get{ return Owner?.BaseModel; }}

        #region ctor
        public Package(Package owner)
            :base(owner)
            {
            PackageOwner = owner;
            OwnedPackage = new List<Package>();
            OwnedClass = new List<Class>();
            OwnedEnumeration = new List<Enumeration>();
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
            Identifier = new ObjectIdentifier(reader.GetAttribute("id",xmi));
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
                                OwnedPackage.Add(o);
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
                                OwnedClass.Add(o);
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
                                OwnedEnumeration.Add(o);
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
        }
    }
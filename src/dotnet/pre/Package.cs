using System;
using System.Collections.Generic;
using System.Xml;

namespace pre
    {
    public class Package : PackageableElement
        {
        public String Name { get;private set; }
        public ObjectIdentifier Identifier { get;private set; }
        public IList<Package> NestedPackages { get; }
        public IList<Class> NestedClasses { get; }
        public IList<Enumeration> NestedEnumeration { get; }
        public IList<Association> Associations { get; }
        public Package Owner { get; }
        public override Model BaseModel { get{ return Owner?.BaseModel; }}

        #region ctor
        public Package(Package owner)
            :base(owner)
            {
            Owner = owner;
            NestedPackages = new List<Package>();
            NestedClasses = new List<Class>();
            NestedEnumeration = new List<Enumeration>();
            Associations = new List<Association>();
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
                                NestedPackages.Add(o);
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
                                NestedClasses.Add(o);
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
                                NestedEnumeration.Add(o);
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
                                Associations.Add(o);
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
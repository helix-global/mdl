using System;
using System.Collections.Generic;
using System.Xml;

namespace pre
    {
    public class Association : ModelElement
        {
        public String Name { get;private set; }
        public String Identifier { get;private set; }
        public IList<MemberEnd> MemberEnd { get; }
        public IList<Property> OwnedEnd{ get; }
        public IList<Generalization> Generalization { get; }
        public IList<Comment> OwnedComment { get; }
        public Package PackageOwner { get; }

        public Association(Package owner)
            : base(owner)
            {
            PackageOwner = owner;
            MemberEnd = new List<MemberEnd>();
            OwnedEnd = new List<Property>();
            Generalization = new List<Generalization>();
            OwnedComment = new List<Comment>();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return Name;
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
                            #region memberEnd
                            case "memberEnd":
                                {
                                var o = new MemberEnd(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                MemberEnd.Add(o);
                                }
                                break;
                            #endregion
                            #region ownedEnd
                            case "ownedEnd" when type == "uml:Property":
                                {
                                var o = new Property(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                OwnedEnd.Add(o);
                                }
                                break;
                            #endregion
                            #region generalization
                            case "generalization" when type == "uml:Generalization":
                                {
                                var o = new Generalization(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                Generalization.Add(o);
                                }
                                break;
                            #endregion
                            #region ownedComment
                            case "ownedComment" when type == "uml:Comment":
                                {
                                var o = new Comment(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                OwnedComment.Add(o);
                                }
                                break;
                            #endregion
                            default: throw new NotSupportedException();
                            }
                        }
                        break;
                    }
                }
            }
        #endregion
        }
    }
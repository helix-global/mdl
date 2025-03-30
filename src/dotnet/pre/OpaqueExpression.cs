using System;
using System.Collections.Generic;
using System.Xml;

namespace pre
    {
    public class OpaqueExpression : ModelElement
        {
        public String Name { get;private set; }
        public String Body { get;private set; }
        public String Language { get;private set; }
        public ObjectIdentifier Identifier { get;private set; }
        public IList<Comment> OwnedComment { get; }

        public OpaqueExpression(ModelElement owner)
            : base(owner)
            {
            OwnedComment = new List<Comment>();
            }

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
                            #region body
                            case "body":
                                {
                                Body = reader.ReadElementContentAsString();
                                }
                                break;
                            #endregion
                            #region language
                            case "language":
                                {
                                Language = reader.ReadElementContentAsString();
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
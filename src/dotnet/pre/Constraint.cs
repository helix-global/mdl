using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace pre
    {
    public class Constraint : ModelElement
        {
        public String Name { get;private set; }
        public ObjectIdentifier Identifier { get;private set; }
        public OpaqueExpression Specification { get;private set; }
        public IList<Comment> OwnedComment { get; }
        public Precondition Precondition { get;set; }

        public Constraint(ModelElement owner) : base(owner)
            {
            OwnedComment = new List<Comment>();
            }

        #region M:ReadXml(XmlReader)
        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader)
            {
            reader.MoveToContent();
            Name = reader.GetAttribute("name");
            Identifier = new ObjectIdentifier(reader.GetAttribute("id",xmi));
            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:
                        {
                        var type = reader.GetAttribute("type",xmi);
                        switch (reader.LocalName) {
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
                            #region specification{uml:OpaqueExpression}
                            case "specification" when type == "uml:OpaqueExpression":
                                {
                                var o = new OpaqueExpression(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                Specification = o;
                                }
                                break;
                            #endregion
                            case "constrainedElement":
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
            return Name;
            }
        #endregion
        #region M:WriteCSharp(TextWriter,String)
        public override void WriteCSharp(TextWriter writer, String prefix)
            {
            writer.Write($"{prefix}<rule language=\"{Specification.Language}\">\n");
            foreach (var comment in OwnedComment) {
                comment.WriteCSharp(writer,$"{prefix}  ");
                }
            if (Specification.Body != null) {
                writer.Write($"{prefix}  <![CDATA[\n");
                var values = Specification.Body.Split('\n');
                foreach (var value in values) {
                    writer.Write($"{prefix}    {value.TrimEnd('\r','\n')}\n");
                    }
                writer.Write($"{prefix}  ]]>\n");
                }
            writer.Write($"{prefix}  xmi:id=\"{Identifier}\"\n");
            if (Precondition != null)
                {
                writer.Write($"{prefix}  xmi:is-postcondition=\"true\"\n");
                }
            writer.Write($"{prefix}</rule>\n");
            }
        #endregion
        }
    }
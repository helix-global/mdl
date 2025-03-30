using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace pre
    {
    public class Enumeration : ModelElement
        {
        public String Name { get;private set; }
        public ObjectIdentifier Identifier { get;private set; }
        public IList<Comment> OwnedComment { get; }
        public IList<EnumerationLiteral> OwnedLiteral { get; }

        public Enumeration(ModelElement owner)
            : base(owner)
            {
            OwnedComment = new List<Comment>();
            OwnedLiteral = new List<EnumerationLiteral>();
            }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return Name;
            }

        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader)
            {
            reader.MoveToContent();
            Name = reader.GetAttribute("name");
            Identifier = new ObjectIdentifier(reader.GetAttribute("id",xmi));
            BaseModel.ClassNames.Add(Name??String.Empty);
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
                            #region ownedLiteral
                            case "ownedLiteral" when type == "uml:EnumerationLiteral":
                                {
                                var o = new EnumerationLiteral(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                OwnedLiteral.Add(o);
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

        #region M:WriteCSharp(TextWriter,String)
        public override void WriteCSharp(TextWriter writer,String prefix) {
            writer.Write($"{prefix}using System;\n");
            writer.Write($"{prefix}\n");
            writer.Write($"{prefix}namespace {DefaultNamespace}\n");
            writer.Write($"{prefix}    {{\n");

            if (OwnedComment.Count > 0) {
                writer.Write($"{prefix}    /// <summary>\n");
                foreach (var comment in OwnedComment) {
                    comment.WriteCSharp(writer,$"{prefix}    /// ");
                    }
                writer.Write($"{prefix}    /// </summary>\n");
                }
            writer.Write($"{prefix}    /// xmi:id=\"{Identifier}\"\n");
            writer.Write($"{prefix}    public enum {Name}\n");
            writer.Write($"{prefix}        {{\n");

            var i = 0;
            foreach (var attribute in OwnedLiteral) {
                if (i > 0)
                    {
                    writer.Write(",\n");
                    }
                attribute.WriteCSharp(writer,$"{prefix}        ");
                i++;
                }
            writer.Write("\n");
            writer.Write($"{prefix}        }}\n");
            writer.Write($"{prefix}    }}\n");
            }
        #endregion
        }
    }
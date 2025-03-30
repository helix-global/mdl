using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace pre
    {
    public class EnumerationLiteral : ModelElement
        {
        public String Name { get;private set; }
        public ObjectIdentifier Identifier { get;private set; }
        public IList<Comment> OwnedComment { get; }

        public EnumerationLiteral(ModelElement owner)
            : base(owner)
            {
            OwnedComment = new List<Comment>();
            }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return Name;
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
        public override void WriteCSharp(TextWriter writer, String prefix)
            {
            if (OwnedComment.Count > 0) {
                writer.Write($"{prefix}/// <summary>\n");
                foreach (var comment in OwnedComment) {
                    comment.WriteCSharp(writer,$"{prefix}/// ");
                    }
                writer.Write($"{prefix}/// </summary>\n");
                }
            writer.Write($"{prefix}/// xmi:id=\"{Identifier}\"\n");
            writer.Write($"{prefix}{UpperFirstLetter(Name)}");
            }
        }
    }
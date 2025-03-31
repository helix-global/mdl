using System;
using System.Xml;

namespace pre
    {
    public class RedefinedProperty : ModelElement
        {
        public String ReferencedIdentifier { get;private set; }
        public RedefinedProperty(ModelElement owner)
            : base(owner)
            {
            }

        public override void ReadXml(XmlReader reader)
            {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            ReferencedIdentifier = reader.GetAttribute("idref",xmi);
            }
        }
    }
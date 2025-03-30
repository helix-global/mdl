using System;
using System.Xml;

namespace pre
    {
    public class SubsettedProperty : ModelElement
        {
        public ObjectIdentifier ReferencedIdentifier { get;private set; }

        public SubsettedProperty(ModelElement owner)
            : base(owner)
            {
            }

        public override void ReadXml(XmlReader reader)
            {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            ReferencedIdentifier = new ObjectIdentifier(reader.GetAttribute("idref",xmi));
            }
        }
    }
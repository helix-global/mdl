using System;
using System.Xml;

namespace pre
    {
    public class Precondition : ModelElement
        {
        public ObjectIdentifier ReferencedIdentifier { get;private set; }
        public Precondition(ModelElement owner)
            : base(owner)
            {
            }

        public override void ReadXml(XmlReader reader)
            {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            ReferencedIdentifier = new ObjectIdentifier(reader.GetAttribute("idref",xmi));
            }

        public override String ToString()
            {
            return ReferencedIdentifier.ToString();
            }
        }
    }
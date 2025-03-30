using System.Xml;

namespace pre
    {
    public class ValueSpecification : ModelElement
        {
        public ObjectIdentifier Identifier { get;private set; }

        public ValueSpecification(ModelElement owner)
            : base(owner)
            {
            }

        public override void ReadXml(XmlReader reader)
            {
            reader.MoveToContent();
            Identifier = new ObjectIdentifier(reader.GetAttribute("id",xmi));
            }
        }
    }
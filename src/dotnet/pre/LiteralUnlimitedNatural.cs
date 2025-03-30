using System;
using System.Xml;

namespace pre
    {
    public class LiteralUnlimitedNatural : LiteralSpecification
        {
        public UnlimitedNatural? Value { get;private set; }
        public LiteralUnlimitedNatural(ModelElement owner)
            : base(owner)
            {
            }

        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader) {
            base.ReadXml(reader);
            var value = reader.GetAttribute("value");
            if (!String.IsNullOrWhiteSpace(value)) {
                if (String.Equals(value,"*"))
                    {
                    Value = UnlimitedNatural.Unlimited;
                    }
                if (UInt64.TryParse(value,out var r)) {
                    Value = new UnlimitedNatural(r);
                    }
                }
            }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return Value.HasValue
                ? Value.ToString()
                : String.Empty;
            }
        }
    }
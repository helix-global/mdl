using System;
using System.Xml;

namespace pre
    {
    public class LiteralInteger : LiteralSpecification
        {
        public Int32? Value { get;private set; }
        public LiteralInteger(ModelElement owner)
            : base(owner)
            {
            }

        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader) {
            base.ReadXml(reader);
            var value = reader.GetAttribute("value");
            if (!String.IsNullOrWhiteSpace(value)) {
                if (Int32.TryParse(value,out var r)) {
                    Value = r;
                    }
                }
            }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return Value.HasValue
                ? Value.ToString()
                : String.Empty;
            }
        }
    }
using System;
using System.Xml;

namespace pre
    {
    internal class MemberEnd : ModelElement
        {
        public ObjectIdentifier ReferencedIdentifier { get;private set; }

        public MemberEnd(ModelElement owner)
            : base(owner)
            {
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return ReferencedIdentifier.ToString();
            }
        #endregion
        #region M:ReadXml(XmlReader)
        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader)
            {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            ReferencedIdentifier = new ObjectIdentifier(reader.GetAttribute("idref",xmi));
            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:
                        {
                        var type = reader.GetAttribute("type",xmi);
                        switch (reader.LocalName) {
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
using System;
using System.Xml;

namespace pre
    {
    internal class SubsettedProperty : ModelElement
        {
        public String ReferencedIdentifier { get;private set; }

        public SubsettedProperty(ModelElement owner)
            : base(owner)
            {
            }

        #region M:ReadXml(XmlReader)
        public override void ReadXml(XmlReader reader)
            {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            ReferencedIdentifier = reader.GetAttribute("idref",xmi);
            }
        #endregion
        #region M:ToString:String
        public override String ToString()
            {
            return ReferencedIdentifier.ToString();
            }
        #endregion
        }
    }
using System;
using System.Collections.Generic;
using System.Xml;

namespace pre
    {
    public class Model : Package
        {
        public override Model BaseModel { get{ return this; }}
        public ISet<String> ClassNames { get; }
        public IDictionary<ObjectIdentifier,Class> Classes { get; }

        #region ctor
        public Model()
            :base(null)
            {
            ClassNames = new SortedSet<String>();
            Classes = new Dictionary<ObjectIdentifier,Class>();
            }
        #endregion

        #region M:ReadXml(XmlReader)
        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:
                        {
                        switch (reader.LocalName) {
                            case "Package" when reader.NamespaceURI == uml:
                                {
                                var o = new Package(this);
                                using (var r = reader.ReadSubtree()) {
                                    o.ReadXml(r);
                                    }
                                NestedPackages.Add(o);
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        #endregion
        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return "{Model}";
            }
        #endregion
        }
    }
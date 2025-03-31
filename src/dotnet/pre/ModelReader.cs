using System;
using System.Xml;
using System.Xml.Linq;

namespace pre
    {
    internal class ModelReader
        {
        public Model Model { get;private set; }

        #region ctor{String}
        public ModelReader(String filename)
            {
            LoadFrom(filename);
            }
        #endregion

        #region M:LoadFrom(String)
        private void LoadFrom(String filename)
            {
            if (filename == null) { throw new ArgumentNullException(nameof(filename)); }
            if (String.IsNullOrWhiteSpace(filename)) { throw new ArgumentOutOfRangeException(nameof(filename)); }
            var source = XDocument.Load(filename,LoadOptions.PreserveWhitespace);
            using (var reader = source.CreateReader())
                {
                LoadFrom(reader);
                }
            }
        #endregion
        #region M:LoadFrom(XmlReader)
        private void LoadFrom(XmlReader reader) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:
                        {
                        switch (reader.LocalName) {
                            case "XMI" when reader.NamespaceURI == ModelElement.xmi:
                                {
                                var o = new Model();
                                using (var r = reader.ReadSubtree()) {
                                    o.ReadXml(r);
                                    }
                                Model = o;
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            Model?.OnAfterLoadModel();
            }
        #endregion
        }
    }
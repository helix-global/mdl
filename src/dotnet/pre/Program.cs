using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace pre
    {
    internal class Program
        {
        private const String xmischema = "http://www.omg.org/spec/XMI/20131001";

        #region M:Main(String[])
        private static void Main(String[] args)
            {
            var reader = new ModelReader(@"C:\TFS\mdl\docs\ptc-18-01-01.xmi");
            var writer = new ModelWriter();
            writer.WriteTo(reader.Model,@"C:\TFS\mdl\src\dotnet\libraries\BinaryStudio.Modeling.UnifiedModelingLanguage");
            return;
            }
        #endregion
        #region M:Elements(XmlElement):IEnumerable<XmlElement>
        private static IEnumerable<XmlElement> Elements(XmlElement source) {
            yield return source;
            foreach (var node in source.ChildNodes.OfType<XmlElement>()) {
                foreach (var e in Elements(node)) {
                    yield return e;
                    }
                }
            }
        #endregion
        #region M:Elements(XmlDocument):IEnumerable<XmlElement>
        private static IEnumerable<XmlElement> Elements(XmlDocument source) {
            if (source.DocumentElement == null) {  yield break; }
            foreach (var node in source.DocumentElement.ChildNodes.OfType<XmlElement>()) {
                foreach (var e in Elements(node)) {
                    yield return e;
                    }
                }
            }
        #endregion
        #region M:PrepareIndexes(XmlDocument,IDictionary<ObjectIdentifier,XmlElement>)
        private static void PrepareIndexes(XmlDocument source,IDictionary<ObjectIdentifier,XmlElement> target) {
            if (source.DocumentElement != null) {
                foreach (var e in source.DocumentElement.ChildNodes.OfType<XmlElement>()) {
                    PrepareIndexes(e,ObjectIdentifier.Empty,target);
                    }
                }
            }
        #endregion
        #region M:PrepareIndexes(XmlElement,ObjectIdentifier,IDictionary<ObjectIdentifier,XmlElement>)
        private static void PrepareIndexes(XmlElement source,ObjectIdentifier α,IDictionary<ObjectIdentifier,XmlElement> target) {
            var id = source.GetAttribute("id",xmischema);
            if (!String.IsNullOrWhiteSpace(id)) {
                var β = new ObjectIdentifier(id);
                var γ = α.Append(β);
                target.Add(γ,source);
                foreach (var e in source.ChildNodes.OfType<XmlElement>()) {
                    PrepareIndexes(e,γ,target);
                    }
                }
            }
        #endregion
        }
    }

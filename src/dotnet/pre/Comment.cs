using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace pre
    {
    internal class Comment : ModelElement
        {
        public ObjectIdentifier Identifier { get;private set; }
        public String Body { get;private set; }

        public Comment(ModelElement owner)
            : base(owner)
            {
            }

        #region M:ReadXml(XmlReader)
        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader)
            {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            Identifier = new ObjectIdentifier(reader.GetAttribute("id",xmi));
            Body = reader.GetAttribute("body");
            }
        #endregion
        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return $"{Body}";
            }
        #endregion
        #region M:WriteCSharp(TextWriter,String)
        public override void WriteCSharp(TextWriter writer, String prefix) {
            if (!String.IsNullOrWhiteSpace(Body)) {
                var body = Body;
                foreach (var className in BaseModel.ClassNames) {
                    body = Regex.Replace(body,$@"\b{className}\b",$@"<see cref=""{className}""/>");
                    }
                if (Owner is Class cls) {
                    foreach (var propertyName in cls.PropertyNames) {
                        body = Regex.Replace(body,$@"\b{propertyName}\b",$@"<see cref=""{UpperFirstLetter(propertyName)}""/>");
                        }
                    foreach (var operationName in cls.OperationNames) {
                        body = Regex.Replace(body,$@"\b{operationName}[(][)]",$@"<see cref=""{operationName}""/>");
                        }
                    }
                if (Owner is Property prop) {
                    cls = (Class)prop.Owner;
                    foreach (var propertyName in cls.PropertyNames) {
                        body = Regex.Replace(body,$@"\b{propertyName}\b",$@"<see cref=""{UpperFirstLetter(propertyName)}""/>");
                        }
                    foreach (var operationName in cls.OperationNames) {
                        body = Regex.Replace(body,$@"\b{operationName}[(][)]",$@"<see cref=""{operationName}""/>");
                        }
                    }
                if (Owner is Operation opr) {
                    cls = (Class)opr.Owner;
                    foreach (var propertyName in cls.PropertyNames) {
                        body = Regex.Replace(body,$@"\b{propertyName}\b",$@"<see cref=""{UpperFirstLetter(propertyName)}""/>");
                        }
                    foreach (var operationName in cls.OperationNames) {
                        body = Regex.Replace(body,$@"\b{operationName}[(][)]",$@"<see cref=""{operationName}""/>");
                        }
                    }
                var values = body.Split('\n');
                foreach (var value in values) {
                    writer.Write($"{prefix}{value.TrimEnd('\r','\n')}\n");
                    }
                }
            }
        #endregion
        }
    }
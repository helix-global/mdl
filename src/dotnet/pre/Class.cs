using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

namespace pre
    {
    public class Class : PackageableElement
        {
        public String Name { get;private set; }
        public ObjectIdentifier Identifier { get;private set; }
        public IList<Comment> OwnedComment { get; }
        public IList<Property> OwnedAttribute { get; }
        public IList<Constraint> OwnedRule { get; }
        public IList<Generalization> Generalization { get; }
        public IList<Operation> OwnedOperation { get; }
        public Boolean UseInteger { get;set; }
        public Boolean UseReal { get;set; }

        #region P:DeclaredProperties:IDictionary<ObjectIdentifier,Property>
        public IDictionary<ObjectIdentifier,Property> DeclaredProperties { get {
            var r = new Dictionary<ObjectIdentifier,Property>();
            foreach (var attr in OwnedAttribute) {
                r[attr.Identifier] = attr;
                }
            foreach (var generalization in Generalization) {
                if (generalization.GetService(typeof(Class)) is Class cls) {
                    foreach (var attr in cls.DeclaredProperties) {
                        r[attr.Key] = attr.Value;
                        }
                    }
                }
            return r;
            }}
        #endregion
        #region P:DeclaredOperations:IDictionary<ObjectIdentifier,Operation>
        public IDictionary<ObjectIdentifier,Operation> DeclaredOperations { get {
            var r = new Dictionary<ObjectIdentifier,Operation>();
            foreach (var attr in OwnedOperation) {
                r[attr.Identifier] = attr;
                }
            foreach (var generalization in Generalization) {
                if (generalization.GetService(typeof(Class)) is Class cls) {
                    foreach (var attr in cls.DeclaredOperations) {
                        r[attr.Key] = attr.Value;
                        }
                    }
                }
            return r;
            }}
        #endregion
        #region P:PropertyNames:HashSet<String>
        public HashSet<String> PropertyNames { get{
            var r = new HashSet<String>();
            foreach (var attr in OwnedAttribute) {
                r.Add(attr.Name);
                }

            foreach (var generalization in Generalization) {
                if (generalization.GetService(typeof(Class)) is Class cls) {
                    r.UnionWith(cls.PropertyNames);
                    }
                }
            return r;
            }}
        #endregion
        #region P:OperationNames:HashSet<String>
        public HashSet<String> OperationNames { get{
            var r = new HashSet<String>();
            foreach (var opr in OwnedOperation) {
                r.Add(opr.Name);
                }

            foreach (var generalization in Generalization) {
                if (generalization.GetService(typeof(Class)) is Class cls) {
                    r.UnionWith(cls.OperationNames);
                    }
                }
            return r;
            }}
        #endregion

        public Class(ModelElement owner)
            :base(owner)
            {
            OwnedComment = new List<Comment>();
            OwnedAttribute = new List<Property>();
            OwnedRule = new List<Constraint>();
            Generalization = new List<Generalization>();
            OwnedOperation = new List<Operation>();
            }

        #region M:ReadXml(XmlReader)
        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader)
            {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            Name = reader.GetAttribute("name");
            Identifier = new ObjectIdentifier(reader.GetAttribute("id",xmi));
            BaseModel.ClassNames.Add(Name??String.Empty);
            BaseModel.Classes.Add(Identifier,this);
            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:
                        {
                        var type = reader.GetAttribute("type",xmi);
                        switch (reader.LocalName) {
                            #region ownedComment
                            case "ownedComment" when type == "uml:Comment":
                                {
                                var o = new Comment(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                OwnedComment.Add(o);
                                }
                                break;
                            #endregion
                            #region ownedAttribute
                            case "ownedAttribute" when type == "uml:Property":
                                {
                                var o = new Property(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                OwnedAttribute.Add(o);
                                }
                                break;
                            #endregion
                            #region ownedRule
                            case "ownedRule" when type == "uml:Constraint":
                                {
                                var o = new Constraint(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                OwnedRule.Add(o);
                                }
                                break;
                            #endregion
                            #region generalization
                            case "generalization" when type == "uml:Generalization":
                                {
                                var o = new Generalization(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                Generalization.Add(o);
                                }
                                break;
                            #endregion
                            #region ownedOperation
                            case "ownedOperation" when type == "uml:Operation":
                                {
                                var o = new Operation(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                OwnedOperation.Add(o);
                                }
                                break;
                            #endregion
                            default: throw new NotSupportedException();
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
            return $"{Name}";
            }
        #endregion
        #region M:WriteCSharp(TextWriter,String)
        public override void WriteCSharp(TextWriter writer,String prefix) {
            writer.Write($"{prefix}using System;\n");
            writer.Write($"{prefix}\n");
            writer.Write($"{prefix}namespace {DefaultNamespace}\n");
            writer.Write($"{prefix}    {{\n");
            if (UseInteger) { writer.Write($"{prefix}    using Integer=Int32;\n"); }
            if (UseReal)    { writer.Write($"{prefix}    using Real=Double;\n"); }
            if (UseReal || UseInteger)
                {
                writer.Write("\n");
                }

            if (OwnedComment.Count > 0) {
                writer.Write($"{prefix}    /// <summary>\n");
                foreach (var comment in OwnedComment) {
                    comment.WriteCSharp(writer,$"{prefix}    /// ");
                    }
                writer.Write($"{prefix}    /// </summary>\n");
                }
            foreach (var rule in OwnedRule) {
                rule.WriteCSharp(writer,$"{prefix}    /// ");
                }
            writer.Write($"{prefix}    /// xmi:id=\"{Identifier}\"\n");

            writer.Write($"{prefix}    public interface {Name}");
            if (Generalization.Count > 0) {
                writer.Write(" : ");
                writer.Write(String.Join(",",Generalization));
                }
            writer.Write("\n");
            writer.Write($"{prefix}        {{\n");

            foreach (var o in OwnedAttribute) {
                o.WriteCSharp(writer,$"{prefix}        ");
                }

            if (OwnedOperation.Count > 0) {
                writer.Write("\n");
                foreach (var o in OwnedOperation) {
                    o.WriteCSharp(writer,$"{prefix}        ");
                    }
                }

            writer.Write($"{prefix}        }}\n");
            writer.Write($"{prefix}    }}\n");
            }
        #endregion
        }
    }
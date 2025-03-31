using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;

namespace pre
    {
    public class Class : ModelElement
        {
        public String Name { get;private set; }
        public String Identifier { get;private set; }
        public IList<Comment> OwnedComment { get; }
        public IDictionary<String,Property> OwnedAttribute { get; }
        public IDictionary<String,Generalization> Generalization { get; }
        public IDictionary<String,Operation> OwnedOperation { get; }
        public IList<Constraint> OwnedRule { get; }
        public Boolean UseInteger { get;set; }
        public Boolean UseReal { get;set; }
        public Package PackageOwner { get; }

        #region P:DeclaredProperties:IDictionary<String,Property>
        public IDictionary<String,Property> DeclaredProperties { get {
            var r = new SortedDictionary<String,Property>();
            foreach ((var id,var o) in OwnedAttribute) {
                r[id] = o;
                }
            foreach (var g in Generalization) {
                if (g.Value.GetService(typeof(Class)) is Class cls) {
                    foreach ((var id, var o) in cls.DeclaredProperties) {
                        r[id] = o;
                        }
                    }
                }
            return r;
            }}
        #endregion
        #region P:DeclaredOperations:IDictionary<String,Operation>
        public IDictionary<String,Operation> DeclaredOperations { get {
            var r = new Dictionary<String,Operation>();
            foreach ((var id,var o) in OwnedOperation) {
                r[id] = o;
                }
            foreach (var g in Generalization) {
                if (g.Value.GetService(typeof(Class)) is Class cls) {
                    foreach ((var id,var o) in cls.DeclaredOperations) {
                        r[id] = o;
                        }
                    }
                }
            return r;
            }}
        #endregion
        #region P:PropertyNames:HashSet<String>
        public HashSet<String> PropertyNames { get{
            var r = new HashSet<String>();
            foreach (var i in OwnedAttribute) {
                r.Add(i.Value.Name);
                }

            foreach (var o in Generalization) {
                if (o.Value.GetService(typeof(Class)) is Class cls) {
                    r.UnionWith(cls.PropertyNames);
                    }
                }
            return r;
            }}
        #endregion
        #region P:OperationNames:HashSet<String>
        public HashSet<String> OperationNames { get{
            var r = new HashSet<String>();
            foreach (var i in OwnedOperation) {
                r.Add(i.Value.Name);
                }

            foreach (var g in Generalization) {
                if (g.Value.GetService(typeof(Class)) is Class cls) {
                    r.UnionWith(cls.OperationNames);
                    }
                }
            return r;
            }}
        #endregion

        public Class(Package owner)
            :base(owner)
            {
            PackageOwner = owner;
            OwnedComment = new List<Comment>();
            OwnedAttribute = new SortedDictionary<String,Property>();
            Generalization = new SortedDictionary<String,Generalization>();
            OwnedOperation = new SortedDictionary<String,Operation>();
            OwnedRule = new List<Constraint>();
            }

        #region M:ReadXml(XmlReader)
        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader)
            {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            Name = reader.GetAttribute("name");
            Identifier = reader.GetAttribute("id",xmi);
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
                                OwnedAttribute.Add(o.Identifier,o);
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
                                Generalization.Add(o.Identifier,o);
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
                                OwnedOperation.Add(o.Identifier,o);
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
            writer.Write($"{prefix}using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;\n");
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
                writer.Write(String.Join(",",Generalization.Values.Select(i=>i.General)));
                }
            writer.Write("\n");
            writer.Write($"{prefix}        {{\n");

            foreach (var o in OwnedAttribute) {
                o.Value.WriteCSharp(writer,$"{prefix}        ");
                }

            if (OwnedOperation.Count > 0) {
                writer.Write("\n");
                foreach (var o in OwnedOperation) {
                    o.Value.WriteCSharp(writer,$"{prefix}        ");
                    }
                }

            writer.Write($"{prefix}        }}\n");
            writer.Write($"{prefix}    }}\n");
            }
        #endregion
        #region M:FindModelElement(String):ModelElement
        public override ModelElement FindModelElement(String idref) {
            if (String.IsNullOrWhiteSpace(idref)) { throw new ArgumentOutOfRangeException(nameof(idref)); }
            if (idref == Identifier) { return this; }
            if (OwnedAttribute.TryGetValue(idref,out var p)) { return p; }
            if (OwnedOperation.TryGetValue(idref,out var o)) { return o; }

            foreach (var g in Generalization) {
                var r = g.Value.FindModelElement(idref);
                if (r != null) {
                    return r;
                    }
                }
            return null;
            }
        #endregion
        #region M:OnAfterLoadModel
        public override void OnAfterLoadModel()
            {
            foreach (var i in Generalization) { i.Value.OnAfterLoadModel(); }
            foreach (var i in OwnedAttribute) { i.Value.OnAfterLoadModel(); }
            foreach (var i in OwnedOperation) { i.Value.OnAfterLoadModel(); }
            }
        #endregion
        }
    }
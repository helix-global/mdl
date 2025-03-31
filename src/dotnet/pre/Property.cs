using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace pre
    {
    internal class Property : ModelElement
        {
        public String Name { get;private set; }
        public String Identifier { get;private set; }
        public IList<Comment> OwnedComment { get; }
        public IList<SubsettedProperty> SubsettedProperties { get; }
        public ValueSpecification LowerValue { get;private set; }
        public ValueSpecification UpperValue { get;private set; }
        public String Type { get;private set; }
        public String Aggregation { get;private set; }
        public IList<RedefinedProperty> RedefinedProperties { get; }
        public Class ClassOwner { get; }
        public Association AssociationOwner { get; }
        public String IsDerived { get;private set; }
        public Boolean? IsDerivedUnion { get;private set; }
        public String Association { get;private set; }
        public String IsReadOnly { get;private set; }
        public Boolean? IsOrdered { get;private set; }
        public String Multiplicity { get;private set; }
        public String TypeMultiplicitySuffix { get;private set; }
        public String MultiplicityAttribute { get;private set; }
        public String TypeWithMultiplicity { get {
            var r = new StringBuilder();
            r.Append($"{Type}");
            r.Append($"{TypeMultiplicitySuffix}");
            return r.ToString();
            }}

        private IPackage Package{get{
            return ((IPackageableElement)Owner).Package;
            }}

        private Property(ModelElement owner)
            : base(owner)
            {
            SubsettedProperties = new List<SubsettedProperty>();
            RedefinedProperties = new List<RedefinedProperty>();
            OwnedComment = new List<Comment>();
            }

        public Property(Class owner)
            : this((ModelElement)owner)
            {
            ClassOwner = owner;
            }

        public Property(Association owner)
            : this((ModelElement)owner)
            {
            AssociationOwner = owner;
            }

        #region M:ReadXml(XmlReader)
        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            Name = reader.GetAttribute("name");
            Identifier = reader.GetAttribute("id",xmi);
            Type = reader.GetAttribute("type");
            Aggregation = reader.GetAttribute("aggregation");
            Association = reader.GetAttribute("association");
            IsReadOnly = reader.GetAttribute("isReadOnly");
            IsDerived = reader.GetAttribute("isDerived");
            IsDerivedUnion = GetValueAsBoolean(reader.GetAttribute("isDerivedUnion"));
            IsOrdered = GetValueAsBoolean(reader.GetAttribute("isOrdered"));
            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:
                        {
                        var type = reader.GetAttribute("type",xmi);
                        switch (reader.LocalName) {
                            #region subsettedProperty
                            case "subsettedProperty":
                                {
                                var o = new SubsettedProperty(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                SubsettedProperties.Add(o);
                                }
                                break;
                            #endregion
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
                            #region lowerValue
                            case "lowerValue" when type == "uml:LiteralInteger":
                                {
                                var o = new LiteralInteger(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                LowerValue = o;
                                }
                                break;
                            case "lowerValue" when type == "uml:LiteralUnlimitedNatural":
                                {
                                var o = new LiteralUnlimitedNatural(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                LowerValue = o;
                                }
                                break;
                            #endregion
                            #region upperValue
                            case "upperValue" when type == "uml:LiteralInteger":
                                {
                                var o = new LiteralInteger(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                UpperValue = o;
                                }
                                break;
                            case "upperValue" when type == "uml:LiteralUnlimitedNatural":
                                {
                                var o = new LiteralUnlimitedNatural(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                UpperValue = o;
                                }
                                break;
                            #endregion
                            #region type
                            case "type":
                                {
                                var content = reader.GetAttribute("href");
                                switch (content) {
                                    case "http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#Boolean": { Type = "Boolean"; } break;
                                    case "http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#String" : { Type = "String";  } break;
                                    case "http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#Integer": { Type = "Integer"; } break;
                                    case "http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#Real"   : { Type = "Real";    } break;
                                    case "http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#UnlimitedNatural": { Type = "UnlimitedNatural"; } break;
                                    default: throw new NotSupportedException();
                                    }
                                if (Owner is Class clsdef) {
                                    if (Type == "Integer") { clsdef.UseInteger = true; }
                                    if (Type == "Real")    { clsdef.UseReal    = true; }
                                    }
                                }
                                break;
                            #endregion
                            #region redefinedProperty
                            case "redefinedProperty":
                                {
                                var o = new RedefinedProperty(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                RedefinedProperties.Add(o);
                                }
                                break;
                            #endregion
                            case "defaultValue":
                                break;
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
        public override void WriteCSharp(TextWriter writer, String prefix)
            {
            var attributes = new StringBuilder();

            writer.Write($"{prefix}#region P:{UpperFirstLetter(Name)}:{TypeWithMultiplicity}\n");
            writer.Write($"{prefix}/// <summary>\n");
            foreach (var comment in OwnedComment) {
                comment.WriteCSharp(writer,$"{prefix}/// ");
                }
            if (RedefinedProperties.Count > 0) {
                writer.Write($"{prefix}/// Redefines:\n");
                if (ClassOwner != null) {
                    foreach (var p in RedefinedProperties) {
                        var r = ClassOwner.DeclaredProperties[p.ReferencedIdentifier];
                        writer.Write($"{prefix}///   <see cref=\"P:{DefaultNamespace}.{r.ClassOwner.Name}.{UpperFirstLetter(r.Name)}\"/>\"\n");
                        }
                    }
                }
            if (SubsettedProperties.Count>0) {
                writer.Write($"{prefix}/// Subsets:\n");
                foreach (var p in SubsettedProperties) {
                    if (ClassOwner != null) {
                        if (ClassOwner.DeclaredProperties.TryGetValue(p.ReferencedIdentifier,out var r)) {
                            writer.Write($"{prefix}///   <see cref=\"P:{DefaultNamespace}.{r.ClassOwner.Name}.{UpperFirstLetter(r.Name)}\"/>\"\n");
                            continue;
                            }
                        }
                    var e = BaseModel.FindModelElement(p.ReferencedIdentifier);
                    if (e != null)
                        {
                        continue;
                        }
                    }
                }
            writer.Write($"{prefix}/// </summary>\n");
            writer.Write($"{prefix}/// xmi:id=\"{Identifier}\"\n");
            if (!String.IsNullOrWhiteSpace(Aggregation))    { writer.Write($"{prefix}/// xmi:aggregation=\"{Aggregation}\"\n"); }
            if (!String.IsNullOrWhiteSpace(Association))    { writer.Write($"{prefix}/// xmi:association=\"{Association}\"\n"); }
            if (!String.IsNullOrWhiteSpace(IsDerived))      { writer.Write($"{prefix}/// xmi:is-derived=\"true\"\n"); }
            if (!String.IsNullOrWhiteSpace(IsReadOnly))     { writer.Write($"{prefix}/// xmi:is-readonly=\"true\"\n"); }

            if (!String.IsNullOrWhiteSpace(MultiplicityAttribute)) { attributes.Append($"[{MultiplicityAttribute}]"); }
            if (IsOrdered == true)      { attributes.Append("[Ordered]"); }
            if (IsDerivedUnion == true) { attributes.Append("[Union]");   }

            foreach (var p in SubsettedProperties) {
                if (ClassOwner != null) {
                    if (ClassOwner.DeclaredProperties.TryGetValue(p.ReferencedIdentifier,out var r)) {
                        continue;
                        }
                    }
                writer.Write($"{prefix}/// xmi:subsets=\"{p.ReferencedIdentifier}\"\n");
                }

            if (attributes.Length > 0) { writer.Write($"{prefix}{attributes}\n"); }
            writer.Write($"{prefix}{TypeWithMultiplicity}");
            writer.Write($" {UpperFirstLetter(Name)} {{ get; }}\n");
            writer.Write($"{prefix}#endregion\n");
            }
        #endregion
        #region M:OnAfterLoadModel
        public override void OnAfterLoadModel()
            {
            Multiplicity = MultiplicityToString(LowerValue,UpperValue);
            switch (Multiplicity) {
                case "1..1" :
                    {
                    TypeMultiplicitySuffix=String.Empty;
                    MultiplicityAttribute=String.Empty;
                    }
                    break;
                case "0..1" :
                    {
                    TypeMultiplicitySuffix=String.Empty;
                    switch (Type) {
                        case "Integer":
                        case "Real":
                        case "Boolean":
                        case "UnlimitedNatural":
                            {
                            MultiplicityAttribute=String.Empty;
                            TypeMultiplicitySuffix="?";
                            }
                            break;
                        default:
                            {
                            if (BaseModel.Enumerations.ContainsKey(Type))
                                {
                                MultiplicityAttribute=String.Empty;
                                TypeMultiplicitySuffix="?";
                                }
                            else
                                {
                                MultiplicityAttribute=$"Multiplicity(\"{Multiplicity}\")";
                                }
                            }
                            break;
                        }
                    }
                    break;
                case "0..*" :
                    {
                    TypeMultiplicitySuffix="[]";
                    MultiplicityAttribute=String.Empty;
                    }
                    break;
                case "1..*" :
                case "0..2" :
                case "1..2" :
                case "2..*" :
                    {
                    TypeMultiplicitySuffix="[]";
                    MultiplicityAttribute=$"Multiplicity(\"{Multiplicity}\")";
                    }
                    break;
                default: throw new NotSupportedException();
                }
            }
        #endregion
        }
    }
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace pre
    {
    public class Parameter : ModelElement
        {
        public String Type { get;private set; }
        public String Name { get;private set; }
        public ValueSpecification LowerValue { get;private set; }
        public ValueSpecification UpperValue { get;private set; }
        public ObjectIdentifier Identifier { get;private set; }
        public IList<Comment> OwnedComment { get; }
        public String Direction { get;private set; }
        public String Multiplicity { get;private set; }
        public String TypeMultiplicitySuffix { get;private set; }
        public String MultiplicityAttribute { get;private set; }

        public String TypeWithMultiplicity { get {
            var r = new StringBuilder();
            r.Append($"{Type}");
            r.Append($"{TypeMultiplicitySuffix}");
            return r.ToString();
            }}

        public Parameter(ModelElement owner)
            : base(owner)
            {
            OwnedComment = new List<Comment>();
            }

        #region M:ReadXml(XmlReader)
        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            Name = reader.GetAttribute("name");
            Identifier = new ObjectIdentifier(reader.GetAttribute("id",xmi));
            Type = reader.GetAttribute("type");
            Direction = reader.GetAttribute("direction");
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
                                if (Owner is Operation oprdef) {
                                    if (Type == "Integer") { oprdef.UseInteger = true; }
                                    if (Type == "Real")    { oprdef.UseReal    = true; }
                                    }
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
        #region M:WriteCSharp(TextWriter,String)
        public override void WriteCSharp(TextWriter writer, String prefix) {
            if (String.IsNullOrWhiteSpace(MultiplicityAttribute))
                {
                writer.Write($"{prefix}{TypeWithMultiplicity}");
                }
            else
                {
                writer.Write($"{prefix}[{MultiplicityAttribute}]{TypeWithMultiplicity}");
                }
            writer.Write($" {Name}");
            }
        #endregion
        #region M:ToString:String
        public override String ToString()
            {
            return $"{TypeWithMultiplicity} {Name}";
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
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace pre
    {
    internal class Operation : ModelElement
        {
        public String Name { get;private set; }
        public String Identifier { get;private set; }
        public IList<Comment> OwnedComment { get; }
        public IList<Constraint> OwnedRule { get; }
        public IList<Parameter> OwnedParameter { get; }
        public IList<RedefinedOperation> RedefinedOperations { get; }
        public IList<Precondition> Preconditions { get; }
        public String IsQuery { get;private set; }
        public Boolean UseInteger { get;set; }
        public Boolean UseReal { get;set; }
        public Class Class { get; }

        public Operation(Class owner)
            : base(owner)
            {
            Class = owner;
            OwnedComment = new List<Comment>();
            OwnedRule = new List<Constraint>();
            OwnedParameter = new List<Parameter>();
            RedefinedOperations = new List<RedefinedOperation>();
            Preconditions = new List<Precondition>();
            }

        #region M:ReadXml(XmlReader)
        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            reader.MoveToContent();
            Name = reader.GetAttribute("name");
            Identifier = reader.GetAttribute("id",xmi);
            IsQuery = reader.GetAttribute("isQuery");
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
                            #region redefinedOperation
                            case "redefinedOperation":
                                {
                                var o = new RedefinedOperation(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                RedefinedOperations.Add(o);
                                }
                                break;
                            #endregion
                            #region precondition
                            case "precondition":
                                {
                                var o = new Precondition(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                Preconditions.Add(o);
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
                            #region ownedParameter
                            case "ownedParameter" when type == "uml:Parameter":
                                {
                                var o = new Parameter(this);
                                using (var r = reader.ReadSubtree())
                                    {
                                    o.ReadXml(r);
                                    }
                                OwnedParameter.Add(o);
                                }
                                break;
                            #endregion
                            default: throw new NotSupportedException();
                            }
                        }
                        break;
                    }
                }
            if (Owner is Class clsdef) {
                if (UseInteger) { clsdef.UseInteger = true; }
                if (UseReal)    { clsdef.UseReal    = true; }
                }

            if (Preconditions.Count > 0) {
                foreach (var constraint in OwnedRule) {
                    var precond = Preconditions.FirstOrDefault(i=>i.ReferencedIdentifier.Equals(constraint.Identifier));
                    if (precond != null) {
                        constraint.Precondition = precond;
                        }
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
        #region M:ParamType(Parameter):String
        private static String ParamType(Parameter value) {
            return (value != null)
                ? value.TypeWithMultiplicity
                : null;
            }
        #endregion
        #region M:ParamType(Parameter,{out}String):String
        private static String ParamType(Parameter value, out String ParameterMultiplicityAttribute) {
            ParameterMultiplicityAttribute = String.Empty;
            if (value != null) {
                ParameterMultiplicityAttribute = value.MultiplicityAttribute;
                return value.TypeWithMultiplicity;
                }
            return null;
            }
        #endregion
        #region M:WriteCSharp(TextWriter,String)
        public override void WriteCSharp(TextWriter writer, String prefix) {
            String ParameterMultiplicityAttribute = null;
            var retparam = OwnedParameter.FirstOrDefault(i => i.Direction == "return");
            var ordparam = OwnedParameter.Where(i=>i.Direction != "return").ToArray();
            var retprfix = (retparam != null)
                ? $":{ParamType(retparam,out ParameterMultiplicityAttribute)}"
                : String.Empty;
            writer.Write($"{prefix}#region M:{Name}");
            if (ordparam.Length > 0)
                {
                writer.Write("(");
                writer.Write(String.Join(",",ordparam.Select(i=>i.TypeWithMultiplicity)));
                writer.Write(")");
                }
            writer.Write($"{retprfix}\n");
            writer.Write($"{prefix}/// <summary>\n");
            foreach (var comment in OwnedComment) {
                comment.WriteCSharp(writer,$"{prefix}/// ");
                }
            if (RedefinedOperations.Count > 0) {
                writer.Write($"{prefix}/// Redefines:\n");
                var cls = Class;
                foreach (var o in RedefinedOperations) {
                    var refopr = cls.DeclaredOperations[o.ReferencedIdentifier];
                    writer.Write($"{prefix}///   <see cref=\"M:{DefaultNamespace}.{refopr.Class.Name}.{refopr.Name}\"/>\"\n");
                    }
                }
            writer.Write($"{prefix}/// </summary>\n");
            foreach (var rule in OwnedRule) {
                rule.WriteCSharp(writer,$"{prefix}/// ");
                }
            writer.Write($"{prefix}/// xmi:id=\"{Identifier}\"\n");
            writer.Write($"{prefix}/// xmi:is-query=\"{IsQuery}\"\n");


            if (!String.IsNullOrWhiteSpace(ParameterMultiplicityAttribute)) {
                writer.Write($"{prefix}[return: {ParameterMultiplicityAttribute}]\n");
                }
            writer.Write((retparam != null) ? $"{prefix}{ParamType(retparam)}":"void");
            writer.Write($" {UpdateCSharpKeyword(Name)}");
            writer.Write($"(");
            writer.Write(String.Join(",",ordparam.Select(i=>i)));
            writer.Write($");\n");
            writer.Write($"{prefix}#endregion\n");
            }
        #endregion
        #region M:OnAfterLoadModel
        public override void OnAfterLoadModel()
            {
            foreach (var i in OwnedParameter) { i.OnAfterLoadModel(); }
            }
        #endregion
        }
    }
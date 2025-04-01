using System;
using BinaryStudio.Modeling.MetadataInterchange;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public class ModelFactory : IObjectFactory
        {
        #region M:CreateObject(String,String)
        public Object CreateObject(String NamespaceURI, String TypeName) {
            if (NamespaceURI == "http://www.omg.org/spec/UML/20131001") {
                switch (TypeName) {
                    case "Package"         : return new EPackage();
                    case "PackageImport"   : return new EPackageImport();
                    case "Class"           : return new EClass();
                    case "Comment"         : return new EComment();
                    case "Constraint"      : return new EConstraint();
                    case "OpaqueExpression": return new EOpaqueExpression(); 
                    case "Generalization"  : return new EGeneralization();
                    case "Property"        : return new EProperty();
                    case "LiteralInteger"  : return new ELiteralInteger();
                    case "LiteralUnlimitedNatural" : return new ELiteralUnlimitedNatural();
                    case "LiteralReal" : return new ELiteralReal();
                    case "LiteralString" : return new ELiteralString();
                    default: throw new NotSupportedException();
                    }
                }
            return null;
            }
        #endregion
        }
    }
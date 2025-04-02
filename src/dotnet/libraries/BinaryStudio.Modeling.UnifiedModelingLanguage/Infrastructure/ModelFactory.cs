using System;
using BinaryStudio.Modeling.MetadataInterchange;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public class ModelFactory : IObjectFactory
        {
        #region M:IsSupportedNamespace(String):Boolean
        public Boolean IsSupportedNamespace(String NamespaceURI) {
            switch (NamespaceURI) {
                case "http://www.omg.org/spec/UML/20131001":
                case "http://www.omg.org/spec/UML/20161101":
                    return true;
                }
            return false;
            }
        #endregion
        #region M:CreateObject(String,String)
        public Object CreateObject(String NamespaceURI, String TypeName) {
            switch (NamespaceURI) {
                case "http://www.omg.org/spec/UML/20131001":
                case "http://www.omg.org/spec/UML/20161101":
                    {
                    switch (TypeName) {
                        case "Package"                 : return new EPackage();
                        case "PackageImport"           : return new EPackageImport();
                        case "Class"                   : return new EClass();
                        case "Comment"                 : return new EComment();
                        case "Constraint"              : return new EConstraint();
                        case "OpaqueExpression"        : return new EOpaqueExpression(); 
                        case "Generalization"          : return new EGeneralization();
                        case "Property"                : return new EProperty();
                        case "LiteralInteger"          : return new ELiteralInteger();
                        case "LiteralUnlimitedNatural" : return new ELiteralUnlimitedNatural();
                        case "LiteralReal"             : return new ELiteralReal();
                        case "LiteralString"           : return new ELiteralString();
                        case "LiteralBoolean"          : return new ELiteralBoolean();
                        case "PrimitiveType"           : return new EPrimitiveType();
                        case "Operation"               : return new EOperation();
                        case "Parameter"               : return new EParameter();
                        case "InstanceValue"           : return new EInstanceValue();
                        case "Enumeration"             : return new EEnumeration();
                        case "EnumerationLiteral"      : return new EEnumerationLiteral();
                        case "Association"             : return new EAssociation();
                        default: throw new NotSupportedException();
                        }
                    }
                }
            throw new NotSupportedException();
            }
        #endregion
        }
    }
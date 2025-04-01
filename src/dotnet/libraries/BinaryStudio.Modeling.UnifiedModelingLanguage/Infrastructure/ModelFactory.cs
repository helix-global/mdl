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
                switch (TypeName)
                    {
                    case "Package":
                        return new EPackage();
                    }
                }
            return null;
            }
        #endregion
        }
    }
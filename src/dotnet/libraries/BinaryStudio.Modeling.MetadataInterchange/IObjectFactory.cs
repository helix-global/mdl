using System;

namespace BinaryStudio.Modeling.MetadataInterchange
    {
    public interface IObjectFactory
        {
        Boolean IsSupportedNamespace(String NamespaceURI);
        Object CreateObject(String NamespaceURI,String TypeName);
        }
    }
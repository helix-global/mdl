using System;

namespace BinaryStudio.Modeling.MetadataInterchange
    {
    public interface IObjectFactory
        {
        Object CreateObject(String NamespaceURI,String TypeName);
        }
    }
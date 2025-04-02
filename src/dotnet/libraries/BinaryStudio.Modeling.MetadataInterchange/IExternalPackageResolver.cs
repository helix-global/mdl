using System;

namespace BinaryStudio.Modeling.MetadataInterchange
    {
    public interface IExternalPackageResolver
        {
        Object Resolve(Uri uri);
        }
    }
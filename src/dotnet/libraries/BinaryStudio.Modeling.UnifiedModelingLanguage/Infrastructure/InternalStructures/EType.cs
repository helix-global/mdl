using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EType : EPackageableElement,Type
        {
        public Package Package { get;set; }
        public Boolean conformsTo(Type other)
            {
            throw new NotImplementedException();
            }
        }
    }
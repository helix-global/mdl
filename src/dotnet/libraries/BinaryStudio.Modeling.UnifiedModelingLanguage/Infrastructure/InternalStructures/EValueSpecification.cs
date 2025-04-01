using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EValueSpecification : EPackageableElement,ValueSpecification
        {
        public Type Type { get;set; }
        public Boolean? booleanValue()
            {
            throw new NotImplementedException();
            }

        public Int32? integerValue()
            {
            throw new NotImplementedException();
            }

        public Boolean isComputable()
            {
            throw new NotImplementedException();
            }

        public Boolean isNull()
            {
            throw new NotImplementedException();
            }

        public Double? realValue()
            {
            throw new NotImplementedException();
            }

        public String stringValue()
            {
            throw new NotImplementedException();
            }

        public UnlimitedNatural? unlimitedValue()
            {
            throw new NotImplementedException();
            }
        }
    }
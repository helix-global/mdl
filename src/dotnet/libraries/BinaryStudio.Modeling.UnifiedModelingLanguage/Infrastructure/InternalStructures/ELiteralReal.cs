using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    using Real=Double;
    internal class ELiteralReal : ELiteralSpecification<Real>,LiteralReal
        {
        public Double realValue()
            {
            throw new NotImplementedException();
            }
        }
    }
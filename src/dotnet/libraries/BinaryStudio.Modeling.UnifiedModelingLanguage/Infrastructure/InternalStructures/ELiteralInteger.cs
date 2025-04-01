using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    using Integer=Int32;
    internal class ELiteralInteger : ELiteralSpecification<Integer>,LiteralInteger
        {
        public Int32 integerValue()
            {
            throw new NotImplementedException();
            }
        }
    }
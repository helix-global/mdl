using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class ELiteralSpecification : EValueSpecification,LiteralSpecification
        {
        }

    internal class ELiteralSpecification<T> : ELiteralSpecification
        {
        public T Value { get;set; }
        public Boolean IsComputable{ get; }
        }
    }
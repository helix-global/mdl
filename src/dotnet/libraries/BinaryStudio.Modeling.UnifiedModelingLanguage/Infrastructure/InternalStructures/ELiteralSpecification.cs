using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class ELiteralSpecification : EValueSpecification,LiteralSpecification
        {
        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"LiteralSpecification"
                : $"LiteralSpecification{{{Name}}}";
            }
        #endregion
        }

    internal class ELiteralSpecification<T> : ELiteralSpecification
        {
        public T Value { get;set; }
        public Boolean IsComputable{ get; }
        }
    }
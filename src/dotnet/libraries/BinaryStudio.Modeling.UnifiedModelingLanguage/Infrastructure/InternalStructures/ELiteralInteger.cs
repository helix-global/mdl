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

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"LiteralInteger"
                : $"LiteralInteger{{{Name}}}";
            }
        #endregion
        }
    }
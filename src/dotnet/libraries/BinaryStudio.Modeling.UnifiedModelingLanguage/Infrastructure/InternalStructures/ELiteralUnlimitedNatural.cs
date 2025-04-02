using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class ELiteralUnlimitedNatural : ELiteralSpecification<UnlimitedNatural>,LiteralUnlimitedNatural
        {
        public UnlimitedNatural unlimitedValue()
            {
            throw new System.NotImplementedException();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"LiteralUnlimitedNatural"
                : $"LiteralUnlimitedNatural{{{Name}}}";
            }
        #endregion
        }
    }
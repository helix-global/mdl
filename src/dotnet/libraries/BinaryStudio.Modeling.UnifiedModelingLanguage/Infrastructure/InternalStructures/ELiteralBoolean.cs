using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class ELiteralBoolean : ELiteralSpecification<Boolean>,LiteralBoolean
        {
        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"LiteralBoolean"
                : $"LiteralBoolean{{{Name}}}";
            }
        #endregion

        public Boolean booleanValue()
            {
            throw new NotImplementedException();
            }
        }
    }
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

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"LiteralReal"
                : $"LiteralReal{{{Name}}}";
            }
        #endregion
        }
    }
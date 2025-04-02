using System;
using BinaryStudio.Modeling.MetadataInterchange;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EValueSpecification : EPackageableElement,ValueSpecification
        {
        [IsIDREF] public Type Type { get;set; }
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

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"ValueSpecification"
                : $"ValueSpecification{{{Name}}}";
            }
        #endregion
        }
    }
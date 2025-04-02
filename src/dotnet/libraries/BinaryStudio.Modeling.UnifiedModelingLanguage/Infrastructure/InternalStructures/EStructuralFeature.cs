using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EStructuralFeature : EFeature,StructuralFeature
        {
        public Boolean IsOrdered { get;set; }
        public Boolean IsUnique { get;set; }
        public Int32 Lower { get;set; }
        public ValueSpecification LowerValue { get;set; }
        public UnlimitedNatural Upper { get;set; }
        public ValueSpecification UpperValue { get;set; }

        public Boolean compatibleWith(MultiplicityElement other)
            {
            throw new NotImplementedException();
            }

        public Boolean includesMultiplicity(MultiplicityElement M)
            {
            throw new NotImplementedException();
            }

        public Boolean @is(Int32 lowerbound, UnlimitedNatural upperbound)
            {
            throw new NotImplementedException();
            }

        public Boolean isMultivalued()
            {
            throw new NotImplementedException();
            }

        public Int32? lower()
            {
            throw new NotImplementedException();
            }

        public Int32 lowerBound()
            {
            throw new NotImplementedException();
            }

        public UnlimitedNatural? upper()
            {
            throw new NotImplementedException();
            }

        public UnlimitedNatural upperBound()
            {
            throw new NotImplementedException();
            }

        public Type Type { get; set; }
        public Boolean IsReadOnly { get; set; }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"StructuralFeature"
                : $"StructuralFeature{{{Name}}}";
            }
        #endregion
        }
    }
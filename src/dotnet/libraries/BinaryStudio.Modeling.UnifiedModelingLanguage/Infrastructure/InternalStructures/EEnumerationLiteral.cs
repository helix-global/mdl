using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EEnumerationLiteral : EInstanceSpecification, EnumerationLiteral
        {
        public Enumeration Classifier { get; }
        public Enumeration Enumeration { get;set; }
        public Enumeration classifier()
            {
            throw new System.NotImplementedException();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"EnumerationLiteral"
                : $"EnumerationLiteral{{{Name}}}";
            }
        #endregion
        }
    }
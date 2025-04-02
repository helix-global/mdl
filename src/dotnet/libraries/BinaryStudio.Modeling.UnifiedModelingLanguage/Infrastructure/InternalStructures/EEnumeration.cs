using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EEnumeration : EDataType,Enumeration
        {
        public IList<EnumerationLiteral> OwnedLiteral { get; }

        public EEnumeration()
            {
            OwnedLiteral = new List<EnumerationLiteral>();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"Enumeration"
                : $"Enumeration{{{Name}}}";
            }
        #endregion
        }
    }
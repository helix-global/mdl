using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EDataType : EClassifier,DataType
        {
        public IList<Property> OwnedAttribute { get; }
        public IList<Operation> OwnedOperation { get; }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"DataType"
                : $"DataType{{{Name}}}";
            }
        #endregion
        }
    }
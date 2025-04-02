using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal abstract class EEncapsulatedClassifier : EStructuredClassifier,EncapsulatedClassifier
        {
        public IList<Port> OwnedPort { get; }
        public Port[] ownedPort()
            {
            throw new System.NotImplementedException();
            }

        protected EEncapsulatedClassifier()
            {
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"EncapsulatedClassifier"
                : $"EncapsulatedClassifier{{{Name}}}";
            }
        #endregion
        }
    }
using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EDirectedRelationship : ERelationship,DirectedRelationship
        {
        public IList<Element> Source { get; }
        public IList<Element> Target { get; }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return $"ValueSpecification";
            }
        #endregion
        }
    }
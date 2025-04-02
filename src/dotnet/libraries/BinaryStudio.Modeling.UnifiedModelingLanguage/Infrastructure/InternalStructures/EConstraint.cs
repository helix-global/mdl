using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EConstraint : EPackageableElement,Constraint
        {
        public IList<Element> ConstrainedElement { get; }
        public Namespace Context { get; set; }
        public ValueSpecification Specification { get; set; }

        public EConstraint()
            {
            ConstrainedElement = new List<Element>();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"Constraint"
                : $"Constraint{{{Name}}}";
            }
        #endregion
        }
    }
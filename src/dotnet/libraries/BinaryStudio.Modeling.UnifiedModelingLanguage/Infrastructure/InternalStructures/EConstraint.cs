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
        }
    }
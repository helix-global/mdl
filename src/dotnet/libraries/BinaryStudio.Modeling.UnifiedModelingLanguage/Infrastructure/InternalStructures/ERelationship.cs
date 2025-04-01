using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class ERelationship : EElement,Relationship
        {
        public IList<Element> RelatedElement { get; }
        }
    }
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EDirectedRelationship : ERelationship,DirectedRelationship
        {
        public IList<Element> Source { get; }
        public IList<Element> Target { get; }
        }
    }
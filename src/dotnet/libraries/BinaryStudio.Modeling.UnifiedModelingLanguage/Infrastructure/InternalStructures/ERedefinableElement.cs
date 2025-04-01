using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class ERedefinableElement : ENamedElement,RedefinableElement
        {
        public Boolean IsLeaf { get;set; }
        public IList<RedefinableElement> RedefinedElement { get; }
        public IList<Classifier> RedefinitionContext { get; }
        public Boolean isConsistentWith(RedefinableElement redefiningElement)
            {
            throw new NotImplementedException();
            }

        public Boolean isRedefinitionContextValid(RedefinableElement redefinedElement)
            {
            throw new NotImplementedException();
            }
        }
    }
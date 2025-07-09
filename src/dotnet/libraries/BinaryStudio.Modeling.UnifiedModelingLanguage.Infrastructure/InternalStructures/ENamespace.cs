using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class ENamespace : EModelElement,Namespace
        {
        public List<ElementOwnership> ownedElement { get; }
        }
    }
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Namespace : ModelElement
        {
        List<ElementOwnership> ownedElement { get; }
        }
    }

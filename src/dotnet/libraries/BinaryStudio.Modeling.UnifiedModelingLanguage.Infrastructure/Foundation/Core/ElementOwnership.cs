using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ElementOwnership
        {
        VisibilityKind visibility { get; }
        Boolean isSpecification { get; }
        }
    }

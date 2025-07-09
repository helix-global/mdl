using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ElementImport
        {
        String alias { get; }
        ModelElement importedElement { get; }
        Boolean isSpecification { get; }
        Package package { get; }
        VisibilityKind visibility { get; }
        }
    }

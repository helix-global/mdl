using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Comment : ModelElement
        {
        ModelElement[] annotatedElement { get; }
        String body { get; }
        }
    }

using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface TaggedValue : ModelElement
        {
        String dataValue { get; }
        ModelElement modelElement { get; }
        ModelElement referenceValue { get; }
        TagDefinition type { get; }
        }
    }
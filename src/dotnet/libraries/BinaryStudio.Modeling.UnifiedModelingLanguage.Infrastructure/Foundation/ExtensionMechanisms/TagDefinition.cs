using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface TagDefinition : ModelElement
        {
        Multiplicity multiplicity { get; }
        Stereotype owner { get; }
        String tagType { get; }
        TaggedValue[] typedValue { get; }
        }
    }

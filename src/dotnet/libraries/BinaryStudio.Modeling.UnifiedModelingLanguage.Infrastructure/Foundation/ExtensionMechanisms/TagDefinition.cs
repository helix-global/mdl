namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface TagDefinition : ModelElement
        {
        Multiplicity multiplicity { get; }
        Stereotype owner { get; }
        Name tagType { get; }
        TaggedValue[] typedValue { get; }
        }
    }

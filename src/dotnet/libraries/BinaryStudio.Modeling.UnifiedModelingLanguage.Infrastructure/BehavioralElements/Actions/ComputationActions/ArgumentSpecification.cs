namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ArgumentSpecification : ModelElement
        {
        Multiplicity multiplicity { get; }
        OrderingKind ordering { get; }
        DataType type { get; }
        }
    }

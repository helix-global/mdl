namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class ArgumentSpecification : ModelElement
        {
        Multiplicity multiplicity { get; }
        OrderingKind ordering { get; }
        DataType type { get; }
        }
    }

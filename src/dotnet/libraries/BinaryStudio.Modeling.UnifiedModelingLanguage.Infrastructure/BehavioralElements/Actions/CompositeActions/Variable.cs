namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Variable : ModelElement
        {
        Multiplicity multiplicity { get; }
        OrderingKind ordering { get; }
        GroupAction scope { get; }
        Classifier type { get; }
        }
    }


namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class Variable : ModelElement
        {
        Multiplicity multiplicity { get; }
        OrderingKind ordering { get; }
        GroupAction scope { get; }
        Classifier type { get; }
        }
    }


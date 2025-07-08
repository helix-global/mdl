namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class Pin : ModelElement
        {
        Multiplicity multiplicity { get; }
        OrderingKind ordering { get; }
        Classifier type { get; }
        }
    }
    
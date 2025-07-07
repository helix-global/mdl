namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Pin : ModelElement
        {
        Multiplicity multiplicity { get; }
        OrderingKind ordering { get; }
        Classifier type { get; }
        }
    }
    
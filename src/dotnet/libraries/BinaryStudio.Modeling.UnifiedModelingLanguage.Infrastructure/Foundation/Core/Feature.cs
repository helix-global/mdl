namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Feature : ModelElement
        {
        ClassifierRole[] classifierRole { get; }
        Classifier owner { get; }
        ScopeKind ownerScope { get; }
        }
    }

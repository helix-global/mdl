namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface StructuralFeature : Feature
        {
        ChangeableKind changeability { get; }
        Multiplicity multiplicity { get; }
        OrderingKind ordering { get; }
        ScopeKind targetScope { get; }
        Classifier type { get; }
        }
    }

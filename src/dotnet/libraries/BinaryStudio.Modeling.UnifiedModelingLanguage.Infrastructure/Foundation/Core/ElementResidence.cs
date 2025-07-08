namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ElementResidence
        {
        ModelElement resident { get; }
        VisibilityKind visibility { get; }
        }
    }

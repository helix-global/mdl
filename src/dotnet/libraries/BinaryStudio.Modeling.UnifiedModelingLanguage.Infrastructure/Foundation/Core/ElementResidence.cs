namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ElementResidence
        {
        Component container { get; }
        ModelElement resident { get; }
        VisibilityKind visibility { get; }
        }
    }

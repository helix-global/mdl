namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Flow : Relationship
        {
        ModelElement[] target { get; }
        ModelElement[] source { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Namespace : ModelElement
        {
        ModelElement[] ownedElement { get; }
        }
    }

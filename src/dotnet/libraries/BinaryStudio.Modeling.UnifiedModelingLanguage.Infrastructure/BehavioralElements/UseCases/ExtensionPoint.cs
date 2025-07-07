namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ExtensionPoint : ModelElement
        {
        LocationReference location { get; }
        UseCase useCase { get; }
        Extend[] extend { get; }
        }
    }

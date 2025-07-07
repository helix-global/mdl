namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface UseCase : Classifier
        {
        Extend[] extend { get; }
        Extend[] extender { get; }
        ExtensionPoint[] extensionPoint { get; }
        Include[] include { get; }
        Include[] includer { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Artifact : Classifier
        {
        Component[] implementationLocation { get; }
        }
    }

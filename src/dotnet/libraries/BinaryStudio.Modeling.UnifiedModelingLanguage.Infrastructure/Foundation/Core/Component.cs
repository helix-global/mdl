namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Component : Classifier
        {
        Node[] deploymentLocation { get; }
        Artifact[] implementation { get; }
        ElementResidence[] residentElement { get; }
        }
    }

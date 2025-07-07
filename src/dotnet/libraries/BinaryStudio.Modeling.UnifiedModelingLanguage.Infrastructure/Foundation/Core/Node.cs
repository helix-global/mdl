namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Node : Classifier
        {
        Component[] deployedComponent { get; }
        }
    }

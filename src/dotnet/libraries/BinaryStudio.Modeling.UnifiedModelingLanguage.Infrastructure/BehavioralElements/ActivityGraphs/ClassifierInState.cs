namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ClassifierInState : Classifier
        {
        State[] inState { get; }
        Classifier type { get; }
        }
    }

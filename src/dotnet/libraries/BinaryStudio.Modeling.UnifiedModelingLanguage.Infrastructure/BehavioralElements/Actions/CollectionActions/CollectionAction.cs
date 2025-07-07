namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface CollectionAction : Action
        {
        Action subaction { get; }
        }
    }

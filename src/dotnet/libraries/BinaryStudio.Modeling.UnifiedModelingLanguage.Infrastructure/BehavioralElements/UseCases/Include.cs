namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Include : Relationship
        {
        UseCase addition { get; }
        UseCase @base { get; }
        }
    }

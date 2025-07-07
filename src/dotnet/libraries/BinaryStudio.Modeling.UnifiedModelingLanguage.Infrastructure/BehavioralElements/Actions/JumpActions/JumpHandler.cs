namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface JumpHandler
        {
        Action[] protectedAction { get; }
        Classifier jumpType { get; }
        HandlerAction body { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface HandlerAction : Action
        {
        OutputPin[] handlerOutput { get; }
        Action body { get; }
        OutputPin occurrence { get; }
        }
    }

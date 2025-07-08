namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class HandlerAction : Action
        {
        OutputPin[] handlerOutput { get; }
        Action body { get; }
        OutputPin occurrence { get; }
        }
    }

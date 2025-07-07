namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface BroadcastSignalAction : ExplicitInvocationAction
        {
        Signal signal { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class SendSignalAction : ExplicitInvocationAction
        {
        Signal signal { get; }
        InputPin target { get; }
        }
    }

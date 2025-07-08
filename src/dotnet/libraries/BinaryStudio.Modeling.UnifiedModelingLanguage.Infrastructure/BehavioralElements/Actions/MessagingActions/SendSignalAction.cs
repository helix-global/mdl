namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface SendSignalAction : ExplicitInvocationAction
        {
        Signal signal { get; }
        InputPin target { get; }
        }
    }

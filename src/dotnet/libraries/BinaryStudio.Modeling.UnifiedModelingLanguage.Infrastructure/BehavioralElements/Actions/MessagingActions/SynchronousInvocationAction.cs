namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface SynchronousInvocationAction : InvocationAction
        {
        OutputPin reply { get; }
        }
    }

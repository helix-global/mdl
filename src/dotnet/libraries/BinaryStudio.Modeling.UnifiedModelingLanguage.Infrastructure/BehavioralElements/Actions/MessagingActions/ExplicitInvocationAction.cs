namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ExplicitInvocationAction : PrimitiveAction
        {
        InputPin[] argument { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class InvocationAction : PrimitiveAction
        {
        InputPin target { get; }
        InputPin request { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface InvocationAction : PrimitiveAction
        {
        InputPin target { get; }
        InputPin request { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ReadSelfAction : PrimitiveAction
        {
        OutputPin result { get; }
        }
    }

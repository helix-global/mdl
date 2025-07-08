namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface LinkAction : PrimitiveAction
        {
        LinkEndData[] endData { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface LiteralValueAction : PrimitiveAction
        {
        DataValue value { get; }
        OutputPin result { get; }
        }
    }

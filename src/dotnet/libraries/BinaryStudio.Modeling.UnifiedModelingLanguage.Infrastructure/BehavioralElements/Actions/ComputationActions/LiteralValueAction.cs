namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class LiteralValueAction : PrimitiveAction
        {
        DataValue value { get; }
        OutputPin result { get; }
        }
    }

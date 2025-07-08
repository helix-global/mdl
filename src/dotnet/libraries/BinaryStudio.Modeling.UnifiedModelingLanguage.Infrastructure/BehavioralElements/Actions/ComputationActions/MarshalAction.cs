namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class MarshalAction : PrimitiveAction
        {
        InputPin[] argument { get; }
        OutputPin result { get; }
        Class marshalType { get; }
        }
    }

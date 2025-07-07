namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface MarshalAction : PrimitiveAction
        {
        InputPin[] argument { get; }
        OutputPin result { get; }
        Class marshalType { get; }
        }
    }

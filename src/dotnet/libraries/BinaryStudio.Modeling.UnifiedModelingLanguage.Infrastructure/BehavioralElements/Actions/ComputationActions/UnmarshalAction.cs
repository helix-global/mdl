namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface UnmarshalAction : PrimitiveAction
        {
        InputPin argument { get; }
        OutputPin[] result { get; }
        Class unmarshalType { get; }
        }
    }

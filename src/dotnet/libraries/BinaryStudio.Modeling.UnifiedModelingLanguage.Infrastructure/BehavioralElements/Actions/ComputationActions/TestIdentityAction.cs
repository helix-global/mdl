namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface TestIdentityAction : PrimitiveAction
        {
        InputPin first { get; }
        InputPin second { get; }
        OutputPin result { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class TestIdentityAction : PrimitiveAction
        {
        InputPin first { get; }
        InputPin second { get; }
        OutputPin result { get; }
        }
    }

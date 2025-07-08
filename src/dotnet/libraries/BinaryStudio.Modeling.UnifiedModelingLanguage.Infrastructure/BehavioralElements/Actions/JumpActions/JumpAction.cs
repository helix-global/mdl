namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class JumpAction : PrimitiveAction
        {
        Exception exception { get; }
        InputPin jumpOccurence { get; }
        }
    }

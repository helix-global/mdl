namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface JumpAction : PrimitiveAction
        {
        Exception exception { get; }
        InputPin jumpOccurence { get; }
        }
    }

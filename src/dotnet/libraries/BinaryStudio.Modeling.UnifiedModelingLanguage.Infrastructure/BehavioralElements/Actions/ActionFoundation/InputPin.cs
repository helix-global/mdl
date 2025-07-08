namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class InputPin : Pin
        {
        Action action { get; }
        DataFlow flow { get; }
        Procedure procedure { get; }
        }
    }

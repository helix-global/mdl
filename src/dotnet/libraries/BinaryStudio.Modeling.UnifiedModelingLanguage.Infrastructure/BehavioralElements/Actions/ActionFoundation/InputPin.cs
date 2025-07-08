namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface InputPin : Pin
        {
        Action action { get; }
        DataFlow flow { get; }
        Procedure procedure { get; }
        }
    }

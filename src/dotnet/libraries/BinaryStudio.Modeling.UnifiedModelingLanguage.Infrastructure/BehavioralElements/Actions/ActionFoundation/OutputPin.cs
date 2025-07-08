namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface OutputPin : Pin
        {
        Action action { get; }
        DataFlow[] flow { get; }
        LoopAction loop { get; }
        Procedure procedure { get; }
        }
    } 

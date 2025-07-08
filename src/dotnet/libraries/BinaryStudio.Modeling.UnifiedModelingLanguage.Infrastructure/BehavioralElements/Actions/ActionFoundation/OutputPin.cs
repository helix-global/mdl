namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class OutputPin : Pin
        {
        Action action { get; }
        DataFlow[] flow { get; }
        LoopAction loop { get; }
        Procedure procedure { get; }
        }
    } 

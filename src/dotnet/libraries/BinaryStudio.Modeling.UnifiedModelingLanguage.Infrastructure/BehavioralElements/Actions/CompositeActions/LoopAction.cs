namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class LoopAction : Action
        {
        Clause clause { get; }

        /**
        ordered
         */
        OutputPin[] loopVariable { get; }
        }
    }

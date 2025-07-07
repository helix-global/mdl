namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface LoopAction : Action
        {
        Clause clause { get; }

        /**
        ordered
         */
        OutputPin[] loopVariable { get; }
        }
    }

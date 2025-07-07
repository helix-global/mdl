namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface SubmachineState : CompositeState
        {
        StateMachine submachine { get; }
        }
    }

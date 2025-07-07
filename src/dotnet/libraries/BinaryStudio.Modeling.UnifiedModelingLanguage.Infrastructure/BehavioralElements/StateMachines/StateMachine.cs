namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface StateMachine : ModelElement
        {
        ModelElement context { get; }
        SubmachineState[] submachineState { get; }
        State top { get; }
        Transition[] transitions { get; }
        }
    }

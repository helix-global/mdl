namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface State : StateVertex
        {
        ClassifierInState[] classifierInState { get; }
        Event[] deferrableEvent { get; }
        Procedure doActivity { get; }
        Procedure entry { get; }
        Procedure exit { get; }
        Transition[] internalTransition { get; }
        StateMachine stateMachine { get; }
        }
    }

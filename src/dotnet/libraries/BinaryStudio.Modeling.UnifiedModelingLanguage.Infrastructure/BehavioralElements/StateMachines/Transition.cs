namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Transition : ModelElement
        {
        Procedure effect { get; }
        Guard guard { get; }
        StateVertex source { get; }
        StateVertex target { get; }
        State state { get; }
        Event trigger { get; }
        StateMachine stateMachine { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface StateVertex : ModelElement
        {
        CompositeState container { get; }
        Transition[] outgoing { get; }
        Transition[] incoming { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Event : ModelElement
        {
        Parameter[] parameter { get; }
        State[] state { get; }
        Transition[] transition { get; }
        }
    }

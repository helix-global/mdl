namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ActivityGraph : StateMachine
        {
        Partition[] partition { get; }
        }
    }

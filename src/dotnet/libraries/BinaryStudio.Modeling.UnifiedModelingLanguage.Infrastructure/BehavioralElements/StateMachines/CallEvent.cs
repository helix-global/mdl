namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface CallEvent : Event
        {
        Operation operation { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ChangeEvent : Event
        {
        BooleanExpression changeExpression { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface TimeEvent : Event
        {
        TimeExpression when { get; }
        }
    }

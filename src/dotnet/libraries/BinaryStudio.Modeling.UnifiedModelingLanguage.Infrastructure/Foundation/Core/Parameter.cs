namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Parameter : ModelElement
        {
        BehavioralFeature behavioralFeature { get; }
        Expression defaultValue { get; }
        Event @event { get; }
        ParameterDirectionKind kind { get; }
        ObjectFlowState[] state { get; }
        Classifier type { get; }
        }
    }

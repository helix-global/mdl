namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Signal : Classifier
        {
        SignalEvent[] occurrence { get; }
        Reception[] reception { get; }
        BehavioralFeature[] context { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Partition : ModelElement
        {
        ActivityGraph activityGraph { get; }
        ModelElement[] contents { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class Partition : ModelElement
        {
        ActivityGraph activityGraph { get; }
        ModelElement[] contents { get; }
        }
    }

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class DataFlow : ModelElement
        {
        InputPin destination { get; }
        OutputPin source { get; }
        }
    }

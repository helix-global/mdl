namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface DataFlow : ModelElement
        {
        InputPin destination { get; }
        OutputPin source { get; }
        }
    }

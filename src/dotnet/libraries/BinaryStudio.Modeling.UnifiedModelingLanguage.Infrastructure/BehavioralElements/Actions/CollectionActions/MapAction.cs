namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface MapAction : CollectionAction
        {
        OutputPin[] result { get; }
        InputPin[] argument { get; }
        OutputPin[] subinput { get; }
        OutputPin[] suboutput { get; }
        }
    }

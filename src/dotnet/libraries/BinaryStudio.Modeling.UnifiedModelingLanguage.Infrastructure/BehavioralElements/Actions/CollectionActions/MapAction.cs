namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class MapAction : CollectionAction
        {
        OutputPin[] result { get; }
        InputPin[] argument { get; }
        OutputPin[] subinput { get; }
        OutputPin[] suboutput { get; }
        }
    }

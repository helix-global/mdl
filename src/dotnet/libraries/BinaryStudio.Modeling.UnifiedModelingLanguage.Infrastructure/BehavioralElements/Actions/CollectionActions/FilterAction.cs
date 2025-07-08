namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class FilterAction : CollectionAction
        {
        InputPin[] argument { get; }
        OutputPin[] subinput { get; }
        OutputPin subtest { get; }
        }
    }

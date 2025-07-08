namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface FilterAction : CollectionAction
        {
        InputPin[] argument { get; }
        OutputPin[] subinput { get; }
        OutputPin subtest { get; }
        }
    }

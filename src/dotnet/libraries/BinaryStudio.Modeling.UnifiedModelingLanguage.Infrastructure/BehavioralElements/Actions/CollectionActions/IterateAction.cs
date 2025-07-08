using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class IterateAction : CollectionAction
        {
        Boolean isUnordered { get; }
        OutputPin[] loopVariable { get; }
        InputPin[] collectionInput { get; }
        OutputPin[] suboutput { get; }
        OutputPin[] result { get; }
        InputPin[] loopVariableInput { get; }
        OutputPin[] subinput { get; }
        }
    }

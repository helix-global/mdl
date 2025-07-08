using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class AddVariableValueAction : WriteVariableAction
        {
        Boolean isReplaceAll { get; }
        InputPin insertAt { get; }
        }
    }

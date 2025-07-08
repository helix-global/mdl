using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface AddVariableValueAction : WriteVariableAction
        {
        Boolean isReplaceAll { get; }
        InputPin insertAt { get; }
        }
    }

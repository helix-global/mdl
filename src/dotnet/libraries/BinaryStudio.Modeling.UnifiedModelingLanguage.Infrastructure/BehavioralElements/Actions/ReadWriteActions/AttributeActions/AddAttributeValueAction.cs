using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface AddAttributeValueAction : WriteAttributeAction
        {
        Boolean isReplaceAll { get; }
        InputPin insertAt { get; }
        }
    }

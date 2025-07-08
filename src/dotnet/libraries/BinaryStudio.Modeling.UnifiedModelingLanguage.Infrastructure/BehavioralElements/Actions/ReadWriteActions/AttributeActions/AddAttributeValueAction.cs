using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class AddAttributeValueAction : WriteAttributeAction
        {
        Boolean isReplaceAll { get; }
        InputPin insertAt { get; }
        }
    }

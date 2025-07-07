using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface LinkEndCreationData : LinkEndData
        {
        Boolean isReplaceAll { get; }
        InputPin insertAt { get; }
        }
    }

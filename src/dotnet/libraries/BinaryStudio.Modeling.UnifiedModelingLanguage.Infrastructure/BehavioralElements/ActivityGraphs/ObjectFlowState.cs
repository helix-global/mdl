using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ObjectFlowState : SimpleState
        {
        Boolean isSynch { get; }
        Parameter available { get; }
        Classifier type { get; }
        Parameter[] parameter { get; }
        }
    }

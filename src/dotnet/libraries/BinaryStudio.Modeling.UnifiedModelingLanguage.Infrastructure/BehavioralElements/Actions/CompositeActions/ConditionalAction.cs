using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ConditionalAction : Action
        {
        Boolean isDeterminate { get; }
        Clause[] clause { get; }
        }
    }

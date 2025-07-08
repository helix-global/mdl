using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class ConditionalAction : Action
        {
        Boolean isDeterminate { get; }
        Clause[] clause { get; }
        }
    }

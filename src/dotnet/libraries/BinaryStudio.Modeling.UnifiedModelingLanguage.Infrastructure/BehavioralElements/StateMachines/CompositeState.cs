using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface CompositeState : State
        {
        Boolean isConcurrent { get; }
        StateVertex[] subvertex { get; }
        }
    }

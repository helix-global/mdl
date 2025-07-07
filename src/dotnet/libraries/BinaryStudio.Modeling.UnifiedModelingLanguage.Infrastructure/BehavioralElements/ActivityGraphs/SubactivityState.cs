using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface SubactivityState : SubmachineState
        {
        Boolean isDynamic { get; }
        ArgListsExpression dynamicArguments { get; }
        Multiplicity dynamicMultiplicity { get; }
        }
    }

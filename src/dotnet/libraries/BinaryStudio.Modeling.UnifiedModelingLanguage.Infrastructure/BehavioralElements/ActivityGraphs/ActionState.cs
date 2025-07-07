using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ActionState : SimpleState
        {
        Boolean isDynamic { get; }
        ArgListsExpression dynamicArguments { get; }
        Multiplicity dynamicMultiplicity { get; }
        }
    }

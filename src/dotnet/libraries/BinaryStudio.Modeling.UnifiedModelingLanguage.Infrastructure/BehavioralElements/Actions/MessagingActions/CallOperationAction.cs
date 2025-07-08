using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class CallOperationAction : ExplicitInvocationAction
        {
        Boolean isAsynchronous { get; }
        OutputPin[] result { get; }
        InputPin target { get; }
        Operation operation { get; }
        }
    }

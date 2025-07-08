using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface CallOperationAction : ExplicitInvocationAction
        {
        Boolean isAsynchronous { get; }
        OutputPin[] result { get; }
        InputPin target { get; }
        Operation operation { get; }
        }
    }

using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface AsynchronousInvocationAction : InvocationAction
        {
        Boolean isRepliable { get; }
        }
    }

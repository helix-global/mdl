using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface GroupAction : Action
        {
        Boolean mustIsolate { get; }
        Action[] subaction { get; }
        Variable[] variable { get; }
        }
    }

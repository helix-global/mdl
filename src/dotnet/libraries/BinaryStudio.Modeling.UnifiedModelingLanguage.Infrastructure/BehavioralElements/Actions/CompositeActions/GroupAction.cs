using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class GroupAction : Action
        {
        Boolean mustIsolate { get; }
        Action[] subaction { get; }
        Variable[] variable { get; }
        }
    }

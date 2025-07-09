using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface StubState : StateVertex
        { 
        String referenceState { get; }
        }
    }

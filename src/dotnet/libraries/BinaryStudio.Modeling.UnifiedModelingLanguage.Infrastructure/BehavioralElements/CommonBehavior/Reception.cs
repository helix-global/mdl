using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Reception : BehavioralFeature
        {
        String specification { get; }
        Boolean isRoot { get; }
        Boolean isLeaf { get; }
        Boolean isAbstract { get; }
        Signal signal { get; }
        }
    }

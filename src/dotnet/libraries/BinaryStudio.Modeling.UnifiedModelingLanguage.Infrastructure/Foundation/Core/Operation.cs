using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Operation : BehavioralFeature
        {
        Collaboration[] collaboration { get; }
        CallConcurrencyKind concurrency { get; }
        Boolean isAbstract { get; }
        Boolean isLeaf { get; }
        Boolean isRoot { get; }
        Method[] method { get; }
        CallEvent[] occurrence { get; }
        String specification { get; }
        }
    }

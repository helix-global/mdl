using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface BehavioralFeature : Feature
        {
        Boolean isQuery { get; }
        Parameter[] parameter { get; }
        Signal[] raisedSignal { get; }
        }
    }

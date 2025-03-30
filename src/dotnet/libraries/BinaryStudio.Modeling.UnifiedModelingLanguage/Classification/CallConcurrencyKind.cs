using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="CallConcurrencyKind"/> is an <see cref="Enumeration"/> used to specify the semantics of concurrent calls to a <see cref="BehavioralFeature"/>.
    /// </summary>
    /// xmi:id="CallConcurrencyKind"
    public enum CallConcurrencyKind
        {
        /// <summary>
        /// No concurrency management mechanism is associated with the <see cref="BehavioralFeature"/> and, therefore, concurrency conflicts may occur. Instances that invoke a <see cref="BehavioralFeature"/> need to coordinate so that only one invocation to a target on any <see cref="BehavioralFeature"/> occurs at once.
        /// </summary>
        /// xmi:id="CallConcurrencyKind-sequential"
        Sequential,
        /// <summary>
        /// Multiple invocations of a <see cref="BehavioralFeature"/> that overlap in time may occur to one instance, but only one is allowed to commence. The others are blocked until the performance of the currently executing <see cref="BehavioralFeature"/> is complete. It is the responsibility of the system designer to ensure that deadlocks do not occur due to simultaneous blocking.
        /// </summary>
        /// xmi:id="CallConcurrencyKind-guarded"
        Guarded,
        /// <summary>
        /// Multiple invocations of a <see cref="BehavioralFeature"/> that overlap in time may occur to one instance and all of them may proceed concurrently.
        /// </summary>
        /// xmi:id="CallConcurrencyKind-concurrent"
        Concurrent
        }
    }

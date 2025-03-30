using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="DurationObservation"/> is a reference to a duration during an execution. It points out the <see cref="NamedElement"/>(s) in the model to observe and whether the observations are when this <see cref="NamedElement"/> is entered or when it is exited.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of firstEvent must be 2 if the multiplicity of event is 2. Otherwise the multiplicity of firstEvent is 0.
    ///   <![CDATA[
    ///     if (event->size() = 2)
    ///       then (firstEvent->size() = 2) else (firstEvent->size() = 0)
    ///     endif
    ///   ]]>
    ///   xmi:id="DurationObservation-first_event_multiplicity"
    /// </rule>
    /// xmi:id="DurationObservation"
    public interface DurationObservation : Observation
        {
        #region P:Event:NamedElement /*[,2]*/
        /// <summary>
        /// The <see cref="DurationObservation"/> is determined as the duration between the entering or exiting of a single <see cref="Event"/> <see cref="Element"/> during execution, or the entering/exiting of one <see cref="Event"/> <see cref="Element"/> and the entering/exiting of a second.
        /// </summary>
        /// xmi:id="DurationObservation-event"
        NamedElement /*[,2]*/ Event { get; }
        #endregion
        #region P:FirstEvent:Boolean /*[,2]*/
        /// <summary>
        /// The value of <see cref="FirstEvent"/>[i] is related to <see cref="Event"/>[i] (where i is 1 or 2). If <see cref="FirstEvent"/>[i] is true, then the corresponding observation <see cref="Event"/> is the first time instant the execution enters <see cref="Event"/>[i]. If <see cref="FirstEvent"/>[i] is false, then the corresponding observation <see cref="Event"/> is the time instant the execution exits <see cref="Event"/>[i].
        /// </summary>
        /// xmi:id="DurationObservation-firstEvent"
        Boolean /*[,2]*/ FirstEvent { get; }
        #endregion
        }
    }

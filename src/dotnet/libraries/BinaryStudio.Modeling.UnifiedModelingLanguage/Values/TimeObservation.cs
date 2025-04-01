using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="TimeObservation"/> is a reference to a time instant during an execution. It points out the <see cref="NamedElement"/> in the model to observe and whether the observation is when this <see cref="NamedElement"/> is entered or when it is exited.
    /// </summary>
    /// xmi:id="TimeObservation"
    public interface TimeObservation : Observation
        {
        #region P:Event:NamedElement
        /// <summary>
        /// The <see cref="TimeObservation"/> is determined by the entering or exiting of the <see cref="Event"/> <see cref="Element"/> during execution.
        /// </summary>
        /// xmi:id="TimeObservation-event"
        /// xmi:association="A_event_timeObservation"
        NamedElement Event { get;set; }
        #endregion
        #region P:FirstEvent:Boolean
        /// <summary>
        /// The value of <see cref="FirstEvent"/> is related to the <see cref="Event"/>. If <see cref="FirstEvent"/> is true, then the corresponding observation <see cref="Event"/> is the first time instant the execution enters the <see cref="Event"/> <see cref="Element"/>. If <see cref="FirstEvent"/> is false, then the corresponding observation <see cref="Event"/> is the time instant the execution exits the <see cref="Event"/> <see cref="Element"/>.
        /// </summary>
        /// xmi:id="TimeObservation-firstEvent"
        Boolean FirstEvent { get;set; }
        #endregion
        }
    }

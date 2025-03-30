using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="TransitionKind"/> is an <see cref="Enumeration"/> type used to differentiate the various kinds of Transitions.
    /// </summary>
    /// xmi:id="TransitionKind"
    public enum TransitionKind
        {
        /// <summary>
        /// Implies that the <see cref="Transition"/>, if triggered, occurs without exiting or entering the source <see cref="State"/> (i.e., it does not cause a state change). This means that the entry or exit condition of the source <see cref="State"/> will not be invoked. An internal <see cref="Transition"/> can be taken even if the SateMachine is in one or more Regions nested within the associated <see cref="State"/>.
        /// </summary>
        /// xmi:id="TransitionKind-internal"
        Internal,
        /// <summary>
        /// Implies that the <see cref="Transition"/>, if triggered, will not exit the composite (source) <see cref="State"/>, but it will exit and re-enter any state within the composite <see cref="State"/> that is in the current state configuration.
        /// </summary>
        /// xmi:id="TransitionKind-local"
        Local,
        /// <summary>
        /// Implies that the <see cref="Transition"/>, if triggered, will exit the composite (source) <see cref="State"/>.
        /// </summary>
        /// xmi:id="TransitionKind-external"
        External
        }
    }

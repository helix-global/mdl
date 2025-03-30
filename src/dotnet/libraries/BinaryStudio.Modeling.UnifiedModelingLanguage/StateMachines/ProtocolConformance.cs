using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ProtocolStateMachine"/> can be redefined into a more specific <see cref="ProtocolStateMachine"/> or into behavioral <see cref="StateMachine"/>. <see cref="ProtocolConformance"/> declares that the specific <see cref="ProtocolStateMachine"/> specifies a protocol that conforms to the general <see cref="ProtocolStateMachine"/> or that the specific behavioral <see cref="StateMachine"/> abides by the protocol of the general <see cref="ProtocolStateMachine"/>.
    /// </summary>
    /// xmi:id="ProtocolConformance"
    public interface ProtocolConformance : DirectedRelationship
        {
        #region P:GeneralMachine:ProtocolStateMachine
        /// <summary>
        /// Specifies the <see cref="ProtocolStateMachine"/> to which the specific <see cref="ProtocolStateMachine"/> conforms.
        /// </summary>
        /// xmi:id="ProtocolConformance-generalMachine"
        ProtocolStateMachine GeneralMachine { get; }
        #endregion
        #region P:SpecificMachine:ProtocolStateMachine
        /// <summary>
        /// Specifies the <see cref="ProtocolStateMachine"/> which conforms to the general <see cref="ProtocolStateMachine"/>.
        /// </summary>
        /// xmi:id="ProtocolConformance-specificMachine"
        ProtocolStateMachine SpecificMachine { get; }
        #endregion
        }
    }

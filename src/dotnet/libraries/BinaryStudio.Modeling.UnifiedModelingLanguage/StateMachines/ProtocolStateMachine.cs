using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ProtocolStateMachine"/> is always defined in the <see cref="Context"/> of a <see cref="Classifier"/>. It specifies which BehavioralFeatures of the <see cref="Classifier"/> can be called in which <see cref="State"/> and under which conditions, thus specifying the allowed invocation sequences on the <see cref="Classifier"/>'s BehavioralFeatures. A <see cref="ProtocolStateMachine"/> specifies the possible and permitted Transitions on the instances of its <see cref="Context"/> <see cref="Classifier"/>, together with the BehavioralFeatures that carry the Transitions. In this manner, an instance lifecycle can be specified for a <see cref="Classifier"/>, by defining the order in which the BehavioralFeatures can be activated and the States through which an instance progresses during its existence.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="ProtocolStateMachine"/> must only have a <see cref="Classifier"/> context, not a <see cref="BehavioralFeature"/> context.
    ///   <![CDATA[
    ///     _'context' <> null and specification = null
    ///   ]]>
    ///   xmi:id="ProtocolStateMachine-classifier_context"
    /// </rule>
    /// <rule language="OCL">
    ///   ProtocolStateMachines cannot have deep or shallow history Pseudostates.
    ///   <![CDATA[
    ///     region->forAll (r | r.subvertex->forAll (v | v.oclIsKindOf(Pseudostate) implies
    ///     ((v.oclAsType(Pseudostate).kind <>  PseudostateKind::deepHistory) and (v.oclAsType(Pseudostate).kind <> PseudostateKind::shallowHistory))))
    ///     
    ///   ]]>
    ///   xmi:id="ProtocolStateMachine-deep_or_shallow_history"
    /// </rule>
    /// <rule language="OCL">
    ///   The states of a <see cref="ProtocolStateMachine"/> cannot have entry, exit, or do activity Behaviors.
    ///   <![CDATA[
    ///     region->forAll(r | r.subvertex->forAll(v | v.oclIsKindOf(State) implies
    ///     (v.oclAsType(State).entry->isEmpty() and v.oclAsType(State).exit->isEmpty() and v.oclAsType(State).doActivity->isEmpty())))
    ///     
    ///   ]]>
    ///   xmi:id="ProtocolStateMachine-entry_exit_do"
    /// </rule>
    /// <rule language="OCL">
    ///   All Transitions of a <see cref="ProtocolStateMachine"/> must be ProtocolTransitions.
    ///   <![CDATA[
    ///     region->forAll(r | r.transition->forAll(t | t.oclIsTypeOf(ProtocolTransition)))
    ///   ]]>
    ///   xmi:id="ProtocolStateMachine-protocol_transitions"
    /// </rule>
    /// xmi:id="ProtocolStateMachine"
    public interface ProtocolStateMachine : StateMachine
        {
        #region P:Conformance:ProtocolConformance[]
        /// <summary>
        /// Conformance between <see cref="ProtocolStateMachine"/> 
        /// </summary>
        /// xmi:id="ProtocolStateMachine-conformance"
        /// xmi:aggregation="composite"
        ProtocolConformance[] Conformance { get; }
        #endregion
        }
    }

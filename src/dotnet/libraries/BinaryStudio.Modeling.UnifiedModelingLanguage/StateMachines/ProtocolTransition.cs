using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ProtocolTransition"/> specifies a legal <see cref="Transition"/> for an <see cref="Operation"/>. Transitions of ProtocolStateMachines have the following information: a pre-condition (<see cref="Guard"/>), a <see cref="Trigger"/>, and a post-condition. Every <see cref="ProtocolTransition"/> is associated with at most one <see cref="BehavioralFeature"/> belonging to the context <see cref="Classifier"/> of the <see cref="ProtocolStateMachine"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   If a <see cref="ProtocolTransition"/> refers to an <see cref="Operation"/> (i.e., has a <see cref="CallEvent"/> trigger corresponding to an <see cref="Operation"/>), then that <see cref="Operation"/> should apply to the context <see cref="Classifier"/> of the <see cref="StateMachine"/> of the <see cref="ProtocolTransition"/>.
    ///   <![CDATA[
    ///     if (referred()->notEmpty() and containingStateMachine()._'context'->notEmpty()) then 
    ///         containingStateMachine()._'context'.oclAsType(BehavioredClassifier).allFeatures()->includesAll(referred())
    ///     else true endif
    ///   ]]>
    ///   xmi:id="ProtocolTransition-refers_to_operation"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="ProtocolTransition"/> never has associated Behaviors.
    ///   <![CDATA[
    ///     effect = null
    ///   ]]>
    ///   xmi:id="ProtocolTransition-associated_actions"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="ProtocolTransition"/> always belongs to a <see cref="ProtocolStateMachine"/>.
    ///   <![CDATA[
    ///     container.belongsToPSM()
    ///   ]]>
    ///   xmi:id="ProtocolTransition-belongs_to_psm"
    /// </rule>
    /// xmi:id="ProtocolTransition"
    public interface ProtocolTransition : Transition
        {
        #region P:PostCondition:Constraint
        /// <summary>
        /// Specifies the post condition of the <see cref="Transition"/> which is the Condition that should be obtained once the <see cref="Transition"/> is triggered. This post condition is part of the post condition of the <see cref="Operation"/> connected to the <see cref="Transition"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedRule"/>"
        /// </summary>
        /// xmi:id="ProtocolTransition-postCondition"
        /// xmi:aggregation="composite"
        /// xmi:association="A_postCondition_owningTransition"
        [Multiplicity("0..1")]
        Constraint PostCondition { get; }
        #endregion
        #region P:PreCondition:Constraint
        /// <summary>
        /// Specifies the precondition of the <see cref="Transition"/>. It specifies the Condition that should be verified before triggering the <see cref="Transition"/>. This <see cref="Guard"/> condition added to the <see cref="Source"/> <see cref="State"/> will be evaluated as part of the precondition of the <see cref="Operation"/> <see cref="Referred"/> by the <see cref="Transition"/> if any.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Transition.Guard"/>"
        /// </summary>
        /// xmi:id="ProtocolTransition-preCondition"
        /// xmi:aggregation="composite"
        /// xmi:association="A_preCondition_protocolTransition"
        [Multiplicity("0..1")]
        Constraint PreCondition { get; }
        #endregion
        #region P:Referred:Operation[]
        /// <summary>
        /// This association refers to the associated <see cref="Operation"/>. It is derived from the <see cref="Operation"/> of the <see cref="CallEvent"/> <see cref="Trigger"/> when applicable.
        /// </summary>
        /// xmi:id="ProtocolTransition-referred"
        /// xmi:association="A_referred_protocolTransition"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Operation[] Referred { get; }
        #endregion

        #region M:referred:Operation[]
        /// <summary>
        /// Derivation for <see cref="ProtocolTransition"/>::/<see cref="Referred"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (trigger->collect(event)->select(oclIsKindOf(CallEvent))->collect(oclAsType(CallEvent).operation)->asSet())
        ///   ]]>
        ///   xmi:id="ProtocolTransition-referred.1-spec"
        /// </rule>
        /// xmi:id="ProtocolTransition-referred.1"
        /// xmi:is-query="true"
        Operation[] referred();
        #endregion
        }
    }

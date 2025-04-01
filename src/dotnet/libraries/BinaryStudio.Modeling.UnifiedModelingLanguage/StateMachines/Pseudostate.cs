using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Pseudostate"/> is an abstraction that encompasses different types of transient Vertices in the <see cref="StateMachine"/> graph. A <see cref="StateMachine"/> instance never comes to rest in a <see cref="Pseudostate"/>, instead, it will exit and enter the <see cref="Pseudostate"/> within a single run-to-completion step.
    /// </summary>
    /// <rule language="OCL">
    ///   All transitions outgoing a fork vertex must target states in different regions of an orthogonal state.
    ///   <![CDATA[
    ///     (kind = PseudostateKind::fork) implies
    ///     
    ///     -- for any pair of outgoing transitions there exists an orthogonal state which contains the targets of these transitions 
    ///     -- such that these targets belong to different regions of that orthogonal state 
    ///     
    ///     outgoing->forAll(t1:Transition, t2:Transition | let contState:State = containingStateMachine().LCAState(t1.target, t2.target) in
    ///     	((contState <> null) and (contState.region
    ///     		->exists(r1:Region, r2: Region | (r1 <> r2) and t1.target.isContainedInRegion(r1) and t2.target.isContainedInRegion(r2)))))
    ///     	
    ///   ]]>
    ///   xmi:id="Pseudostate-transitions_outgoing"
    /// </rule>
    /// <rule language="OCL">
    ///   In a complete statemachine, a choice <see cref="Vertex"/> must have at least one incoming and one outgoing <see cref="Transition"/>.
    ///   <![CDATA[
    ///     (kind = PseudostateKind::choice) implies (incoming->size() >= 1 and outgoing->size() >= 1)
    ///     
    ///   ]]>
    ///   xmi:id="Pseudostate-choice_vertex"
    /// </rule>
    /// <rule language="OCL">
    ///   The outgoing <see cref="Transition"/> from an initial vertex may have a behavior, but not a trigger or a guard.
    ///   <![CDATA[
    ///     (kind = PseudostateKind::initial) implies (outgoing.guard = null and outgoing.trigger->isEmpty())
    ///   ]]>
    ///   xmi:id="Pseudostate-outgoing_from_initial"
    /// </rule>
    /// <rule language="OCL">
    ///   In a complete <see cref="StateMachine"/>, a join <see cref="Vertex"/> must have at least two incoming Transitions and exactly one outgoing <see cref="Transition"/>.
    ///   <![CDATA[
    ///     (kind = PseudostateKind::join) implies (outgoing->size() = 1 and incoming->size() >= 2)
    ///     
    ///   ]]>
    ///   xmi:id="Pseudostate-join_vertex"
    /// </rule>
    /// <rule language="OCL">
    ///   In a complete <see cref="StateMachine"/>, a junction <see cref="Vertex"/> must have at least one incoming and one outgoing <see cref="Transition"/>.
    ///   <![CDATA[
    ///     (kind = PseudostateKind::junction) implies (incoming->size() >= 1 and outgoing->size() >= 1)
    ///     
    ///   ]]>
    ///   xmi:id="Pseudostate-junction_vertex"
    /// </rule>
    /// <rule language="OCL">
    ///   History Vertices can have at most one outgoing <see cref="Transition"/>.
    ///   <![CDATA[
    ///     ((kind = PseudostateKind::deepHistory) or (kind = PseudostateKind::shallowHistory)) implies (outgoing->size() <= 1)
    ///     
    ///   ]]>
    ///   xmi:id="Pseudostate-history_vertices"
    /// </rule>
    /// <rule language="OCL">
    ///   An initial <see cref="Vertex"/> can have at most one outgoing <see cref="Transition"/>.
    ///   <![CDATA[
    ///     (kind = PseudostateKind::initial) implies (outgoing->size() <= 1)
    ///   ]]>
    ///   xmi:id="Pseudostate-initial_vertex"
    /// </rule>
    /// <rule language="OCL">
    ///   In a complete <see cref="StateMachine"/>, a fork <see cref="Vertex"/> must have at least two outgoing Transitions and exactly one incoming <see cref="Transition"/>.
    ///   <![CDATA[
    ///     (kind = PseudostateKind::fork) implies (incoming->size() = 1 and outgoing->size() >= 2)
    ///     
    ///   ]]>
    ///   xmi:id="Pseudostate-fork_vertex"
    /// </rule>
    /// <rule language="OCL">
    ///   All Transitions incoming a join <see cref="Vertex"/> must originate in different Regions of an orthogonal <see cref="State"/>.
    ///   <![CDATA[
    ///     (kind = PseudostateKind::join) implies
    ///     
    ///     -- for any pair of incoming transitions there exists an orthogonal state which contains the source vetices of these transitions 
    ///     -- such that these source vertices belong to different regions of that orthogonal state 
    ///     
    ///     incoming->forAll(t1:Transition, t2:Transition | let contState:State = containingStateMachine().LCAState(t1.source, t2.source) in
    ///     	((contState <> null) and (contState.region
    ///     		->exists(r1:Region, r2: Region | (r1 <> r2) and t1.source.isContainedInRegion(r1) and t2.source.isContainedInRegion(r2)))))
    ///   ]]>
    ///   xmi:id="Pseudostate-transitions_incoming"
    /// </rule>
    /// xmi:id="Pseudostate"
    public interface Pseudostate : Vertex
        {
        #region P:Kind:PseudostateKind
        /// <summary>
        /// Determines the precise type of the <see cref="Pseudostate"/> and can be one of: entryPoint, exitPoint, initial, deepHistory, shallowHistory, join, fork, junction, terminate or choice.
        /// </summary>
        /// xmi:id="Pseudostate-kind"
        PseudostateKind Kind { get;set; }
        #endregion
        #region P:State:State
        /// <summary>
        /// The <see cref="State"/> that owns this <see cref="Pseudostate"/> and in which it appears.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Pseudostate-state"
        /// xmi:association="A_connectionPoint_state"
        [Multiplicity("0..1")]
        State State { get;set; }
        #endregion
        #region P:StateMachine:StateMachine
        /// <summary>
        /// The <see cref="StateMachine"/> in which this <see cref="Pseudostate"/> is defined. This only applies to Pseudostates of the <see cref="Kind"/> entryPoint or exitPoint.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Pseudostate-stateMachine"
        /// xmi:association="A_connectionPoint_stateMachine"
        [Multiplicity("0..1")]
        StateMachine StateMachine { get;set; }
        #endregion

        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <summary>
        /// The query <see cref="isConsistentWith"/> specifies a <see cref="Pseudostate"/> can only be redefined by a <see cref="Pseudostate"/> of the same <see cref="Kind"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     redefiningElement.isRedefinitionContextValid(self)
        ///   ]]>
        ///   xmi:id="Pseudostate-isConsistentWith-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (redefiningElement.oclIsKindOf(Pseudostate) and
        ///     redefiningElement.oclAsType(Pseudostate).kind = kind)
        ///   ]]>
        ///   xmi:id="Pseudostate-isConsistentWith-spec"
        /// </rule>
        /// xmi:id="Pseudostate-isConsistentWith"
        /// xmi:is-query=""
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        }
    }

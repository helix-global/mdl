﻿using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="State"/> models a situation during which some (usually implicit) invariant condition holds.
    /// </summary>
    /// <rule language="OCL">
    ///   Only entry or exit Pseudostates can serve as connection points.
    ///   <![CDATA[
    ///     connectionPoint->forAll(kind = PseudostateKind::entryPoint or kind = PseudostateKind::exitPoint)
    ///   ]]>
    ///   xmi:id="State-entry_or_exit"
    /// </rule>
    /// <rule language="OCL">
    ///   Only submachine States can have connection point references.
    ///   <![CDATA[
    ///     isSubmachineState implies connection->notEmpty( )
    ///   ]]>
    ///   xmi:id="State-submachine_states"
    /// </rule>
    /// <rule language="OCL">
    ///   Only composite States can have entry or exit Pseudostates defined.
    ///   <![CDATA[
    ///     connectionPoint->notEmpty() implies isComposite
    ///   ]]>
    ///   xmi:id="State-composite_states"
    /// </rule>
    /// <rule language="OCL">
    ///   The connection point references used as destinations/sources of Transitions associated with a submachine <see cref="State"/> must be defined as entry/exit points in the submachine <see cref="StateMachine"/>.
    ///   <![CDATA[
    ///     self.isSubmachineState implies (self.connection->forAll (cp |
    ///       cp.entry->forAll (ps | ps.stateMachine = self.submachine) and
    ///       cp.exit->forAll (ps | ps.stateMachine = self.submachine)))
    ///   ]]>
    ///   xmi:id="State-destinations_or_sources_of_transitions"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="State"/> is not allowed to have both a submachine and Regions.
    ///   <![CDATA[
    ///     isComposite implies not isSubmachineState
    ///   ]]>
    ///   xmi:id="State-submachine_or_regions"
    /// </rule>
    /// xmi:id="State"
    public interface State : Namespace,Vertex
        {
        #region P:Connection:IList<ConnectionPointReference>
        /// <summary>
        /// The <see cref="Entry"/> and <see cref="Exit"/> <see cref="Connection"/> points used in conjunction with this (<see cref="Submachine"/>) <see cref="State"/>, i.e., as targets and sources, respectively, in the <see cref="Region"/> with the <see cref="Submachine"/> <see cref="State"/>. A <see cref="Connection"/> point reference references the corresponding definition of a <see cref="Connection"/> point <see cref="Pseudostate"/> in the <see cref="StateMachine"/> referenced by the <see cref="Submachine"/> <see cref="State"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="State-connection"
        /// xmi:aggregation="composite"
        /// xmi:association="A_connection_state"
        IList<ConnectionPointReference> Connection { get; }
        #endregion
        #region P:ConnectionPoint:IList<Pseudostate>
        /// <summary>
        /// The <see cref="Entry"/> and <see cref="Exit"/> Pseudostates of a composite <see cref="State"/>. These can only be <see cref="Entry"/> or <see cref="Exit"/> Pseudostates, and they must have different names. They can only be defined for composite States.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="State-connectionPoint"
        /// xmi:aggregation="composite"
        /// xmi:association="A_connectionPoint_state"
        IList<Pseudostate> ConnectionPoint { get; }
        #endregion
        #region P:DeferrableTrigger:IList<Trigger>
        /// <summary>
        /// A list of Triggers that are candidates to be retained by the <see cref="StateMachine"/> if they trigger no Transitions out of the <see cref="State"/> (not consumed). A deferred <see cref="Trigger"/> is retained until the <see cref="StateMachine"/> reaches a <see cref="State"/> configuration where it is no longer deferred.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="State-deferrableTrigger"
        /// xmi:aggregation="composite"
        /// xmi:association="A_deferrableTrigger_state"
        IList<Trigger> DeferrableTrigger { get; }
        #endregion
        #region P:DoActivity:Behavior
        /// <summary>
        /// An optional <see cref="Behavior"/> that is executed while being in the <see cref="State"/>. The execution starts when this <see cref="State"/> is entered, and ceases either by itself when done, or when the <see cref="State"/> is exited, whichever comes first.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="State-doActivity"
        /// xmi:aggregation="composite"
        /// xmi:association="A_doActivity_state"
        [Multiplicity("0..1")]
        Behavior DoActivity { get;set; }
        #endregion
        #region P:Entry:Behavior
        /// <summary>
        /// An optional <see cref="Behavior"/> that is executed whenever this <see cref="State"/> is entered regardless of the <see cref="Transition"/> taken to reach the <see cref="State"/>. If defined, <see cref="Entry"/> Behaviors are always executed to completion prior to any internal <see cref="Behavior"/> or Transitions performed within the <see cref="State"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="State-entry"
        /// xmi:aggregation="composite"
        /// xmi:association="A_entry_state"
        [Multiplicity("0..1")]
        Behavior Entry { get;set; }
        #endregion
        #region P:Exit:Behavior
        /// <summary>
        /// An optional <see cref="Behavior"/> that is executed whenever this <see cref="State"/> is exited regardless of which <see cref="Transition"/> was taken out of the <see cref="State"/>. If defined, <see cref="Exit"/> Behaviors are always executed to completion only after all internal and transition Behaviors have completed execution.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="State-exit"
        /// xmi:aggregation="composite"
        /// xmi:association="A_exit_state"
        [Multiplicity("0..1")]
        Behavior Exit { get;set; }
        #endregion
        #region P:IsComposite:Boolean
        /// <summary>
        /// A state with <see cref="IsComposite"/>=true is said to be a composite <see cref="State"/>. A composite <see cref="State"/> is a <see cref="State"/> that contains at least one <see cref="Region"/>.
        /// </summary>
        /// xmi:id="State-isComposite"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Boolean IsComposite { get; }
        #endregion
        #region P:IsOrthogonal:Boolean
        /// <summary>
        /// A <see cref="State"/> with <see cref="IsOrthogonal"/>=true is said to be an orthogonal composite <see cref="State"/> An orthogonal composite <see cref="State"/> contains two or more Regions.
        /// </summary>
        /// xmi:id="State-isOrthogonal"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Boolean IsOrthogonal { get; }
        #endregion
        #region P:IsSimple:Boolean
        /// <summary>
        /// A <see cref="State"/> with <see cref="IsSimple"/>=true is said to be a simple <see cref="State"/> A simple <see cref="State"/> does not have any Regions and it does not refer to any <see cref="Submachine"/> <see cref="StateMachine"/>.
        /// </summary>
        /// xmi:id="State-isSimple"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Boolean IsSimple { get; }
        #endregion
        #region P:IsSubmachineState:Boolean
        /// <summary>
        /// A <see cref="State"/> with <see cref="IsSubmachineState"/>=true is said to be a <see cref="Submachine"/> <see cref="State"/> Such a <see cref="State"/> refers to another <see cref="StateMachine"/>(<see cref="Submachine"/>).
        /// </summary>
        /// xmi:id="State-isSubmachineState"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Boolean IsSubmachineState { get; }
        #endregion
        #region P:Region:IList<Region>
        /// <summary>
        /// The Regions owned directly by the <see cref="State"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="State-region"
        /// xmi:aggregation="composite"
        /// xmi:association="A_region_state"
        IList<Region> Region { get; }
        #endregion
        #region P:StateInvariant:Constraint
        /// <summary>
        /// Specifies conditions that are always true when this <see cref="State"/> is the current <see cref="State"/>. In ProtocolStateMachines state invariants are additional conditions to the preconditions of the <see cref="Outgoing"/> Transitions, and to the postcondition of the <see cref="Incoming"/> Transitions.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedRule"/>"
        /// </summary>
        /// xmi:id="State-stateInvariant"
        /// xmi:aggregation="composite"
        /// xmi:association="A_stateInvariant_owningState"
        [Multiplicity("0..1")]
        Constraint StateInvariant { get;set; }
        #endregion
        #region P:Submachine:StateMachine
        /// <summary>
        /// The <see cref="StateMachine"/> that is to be inserted in place of the (<see cref="Submachine"/>) <see cref="State"/>.
        /// </summary>
        /// xmi:id="State-submachine"
        /// xmi:association="A_submachineState_submachine"
        [Multiplicity("0..1")]
        StateMachine Submachine { get;set; }
        #endregion

        #region M:containingStateMachine:StateMachine
        /// <summary>
        /// The query <see cref="containingStateMachine"/> returns the <see cref="StateMachine"/> that contains the <see cref="State"/> either directly or transitively.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.Vertex.containingStateMachine"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (container.containingStateMachine())
        ///   ]]>
        ///   xmi:id="State-containingStateMachine-spec"
        /// </rule>
        /// xmi:id="State-containingStateMachine"
        /// xmi:is-query="true"
        StateMachine containingStateMachine();
        #endregion
        #region M:isComposite:Boolean
        /// <summary>
        /// A composite <see cref="State"/> is a <see cref="State"/> with at least one <see cref="Region"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (region->notEmpty())
        ///   ]]>
        ///   xmi:id="State-isComposite.1-spec"
        /// </rule>
        /// xmi:id="State-isComposite.1"
        /// xmi:is-query="true"
        Boolean isComposite();
        #endregion
        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <summary>
        /// The query isConsistentWith specifies that a non-final <see cref="State"/> can only be redefined by a non-final <see cref="State"/> (this is overridden by <see cref="FinalState"/> to allow a <see cref="FinalState"/> to be redefined by a <see cref="FinalState"/>) and, if the redefined <see cref="State"/> is a <see cref="Submachine"/> <see cref="State"/>, then the redefining <see cref="State"/> must be a <see cref="Submachine"/> state whose <see cref="Submachine"/> is a redefinition of the <see cref="Submachine"/> of the redefined <see cref="State"/>. Note that consistency requirements for the redefinition of Regions and <see cref="ConnectionPoint"/> Pseudostates within a composite <see cref="State"/> and <see cref="Connection"/> ConnectionPoints of a <see cref="Submachine"/> <see cref="State"/> are specified by the isConsistentWith and isRedefinitionContextValid operations for <see cref="Region"/> and <see cref="Vertex"/> (and its subclasses, <see cref="Pseudostate"/> and <see cref="ConnectionPointReference"/>).
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (redefiningElement.oclIsTypeOf(State) and 
        ///       let redefiningState : State = redefiningElement.oclAsType(State) in
        ///         submachine <> null implies (redefiningState.submachine <> null and
        ///           redefiningState.submachine.extendedStateMachine->includes(submachine)))
        ///   ]]>
        ///   xmi:id="State-isConsistentWith-spec"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     redefiningElement.isRedefinitionContextValid(self)
        ///   ]]>
        ///   xmi:id="State-isConsistentWith-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// xmi:id="State-isConsistentWith"
        /// xmi:is-query="true"
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        #region M:isOrthogonal:Boolean
        /// <summary>
        /// An orthogonal <see cref="State"/> is a composite state with at least 2 regions.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (region->size () > 1)
        ///   ]]>
        ///   xmi:id="State-isOrthogonal.1-spec"
        /// </rule>
        /// xmi:id="State-isOrthogonal.1"
        /// xmi:is-query="true"
        Boolean isOrthogonal();
        #endregion
        #region M:isSimple:Boolean
        /// <summary>
        /// A simple <see cref="State"/> is a <see cref="State"/> without any regions.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = ((region->isEmpty()) and not isSubmachineState())
        ///   ]]>
        ///   xmi:id="State-isSimple.1-spec"
        /// </rule>
        /// xmi:id="State-isSimple.1"
        /// xmi:is-query="true"
        Boolean isSimple();
        #endregion
        #region M:isSubmachineState:Boolean
        /// <summary>
        /// Only <see cref="Submachine"/> <see cref="State"/> references another <see cref="StateMachine"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (submachine <> null)
        ///   ]]>
        ///   xmi:id="State-isSubmachineState.1-spec"
        /// </rule>
        /// xmi:id="State-isSubmachineState.1"
        /// xmi:is-query="true"
        Boolean isSubmachineState();
        #endregion
        }
    }

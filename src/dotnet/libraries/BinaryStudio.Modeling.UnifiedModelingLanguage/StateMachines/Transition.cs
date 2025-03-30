using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Transition"/> represents an arc between exactly one <see cref="Source"/> <see cref="Vertex"/> and exactly one Target vertex (the <see cref="Source"/> and targets may be the same <see cref="Vertex"/>). It may form part of a compound transition, which takes the <see cref="StateMachine"/> from one steady <see cref="State"/> configuration to another, representing the full response of the <see cref="StateMachine"/> to an occurrence of an <see cref="Event"/> that triggered it.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="Transition"/> with kind external can source any <see cref="Vertex"/> except entry points.
    ///   <![CDATA[
    ///     (kind = TransitionKind::external) implies
    ///     	not (source.oclIsKindOf(Pseudostate) and source.oclAsType(Pseudostate).kind = PseudostateKind::entryPoint)
    ///   ]]>
    ///   xmi:id="Transition-state_is_external"
    /// </rule>
    /// <rule language="OCL">
    ///   A join segment must not have Guards or Triggers.
    ///   <![CDATA[
    ///     (target.oclIsKindOf(Pseudostate) and target.oclAsType(Pseudostate).kind = PseudostateKind::join) implies (guard = null and trigger->isEmpty())
    ///   ]]>
    ///   xmi:id="Transition-join_segment_guards"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Transition"/> with kind internal must have a <see cref="State"/> as its source, and its source and target must be equal.
    ///   <![CDATA[
    ///     (kind = TransitionKind::internal) implies
    ///     		(source.oclIsKindOf (State) and source = target)
    ///   ]]>
    ///   xmi:id="Transition-state_is_internal"
    /// </rule>
    /// <rule language="OCL">
    ///   Transitions outgoing Pseudostates may not have a <see cref="Trigger"/>.
    ///   <![CDATA[
    ///     source.oclIsKindOf(Pseudostate) and (source.oclAsType(Pseudostate).kind <> PseudostateKind::initial) implies trigger->isEmpty()
    ///   ]]>
    ///   xmi:id="Transition-outgoing_pseudostates"
    /// </rule>
    /// <rule language="OCL">
    ///   A join segment must always originate from a <see cref="State"/>.
    ///   <![CDATA[
    ///     (target.oclIsKindOf(Pseudostate) and target.oclAsType(Pseudostate).kind = PseudostateKind::join) implies (source.oclIsKindOf(State))
    ///   ]]>
    ///   xmi:id="Transition-join_segment_state"
    /// </rule>
    /// <rule language="OCL">
    ///   A fork segment must always target a <see cref="State"/>.
    ///   <![CDATA[
    ///     (source.oclIsKindOf(Pseudostate) and  source.oclAsType(Pseudostate).kind = PseudostateKind::fork) implies (target.oclIsKindOf(State))
    ///   ]]>
    ///   xmi:id="Transition-fork_segment_state"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Transition"/> with kind local must have a composite <see cref="State"/> or an entry point as its source.
    ///   <![CDATA[
    ///     (kind = TransitionKind::local) implies
    ///     		((source.oclIsKindOf (State) and source.oclAsType(State).isComposite) or
    ///     		(source.oclIsKindOf (Pseudostate) and source.oclAsType(Pseudostate).kind = PseudostateKind::entryPoint))
    ///   ]]>
    ///   xmi:id="Transition-state_is_local"
    /// </rule>
    /// <rule language="OCL">
    ///   An initial <see cref="Transition"/> at the topmost level <see cref="Region"/> of a <see cref="StateMachine"/> that has no <see cref="Trigger"/>.
    ///   <![CDATA[
    ///     (source.oclIsKindOf(Pseudostate) and container.stateMachine->notEmpty()) implies
    ///     	trigger->isEmpty()
    ///     
    ///   ]]>
    ///   xmi:id="Transition-initial_transition"
    /// </rule>
    /// <rule language="OCL">
    ///   A fork segment must not have Guards or Triggers.
    ///   <![CDATA[
    ///     (source.oclIsKindOf(Pseudostate) and source.oclAsType(Pseudostate).kind = PseudostateKind::fork) implies (guard = null and trigger->isEmpty())
    ///   ]]>
    ///   xmi:id="Transition-fork_segment_guards"
    /// </rule>
    /// <rule language="OCL">
    ///   The source and target Vertices of a <see cref="Transition"/> must be contained in the same <see cref="StateMachine"/> as the <see cref="Transition"/>.
    ///   <![CDATA[
    ///     let stateMachine = self.containingStateMachine() in 
    ///     source.containingStateMachine() = stateMachine and 
    ///     target.containingStateMachine() = stateMachine
    ///   ]]>
    ///   xmi:id="Transition-transition_vertices"
    /// </rule>
    /// xmi:id="Transition"
    public interface Transition : Namespace,RedefinableElement
        {
        #region P:Container:Region
        /// <summary>
        /// Designates the <see cref="Region"/> that owns this <see cref="Transition"/>.
        /// </summary>
        /// xmi:id="Transition-container"
        Region Container { get; }
        #endregion
        #region P:Effect:Behavior
        /// <summary>
        /// Specifies an optional behavior to be performed when the <see cref="Transition"/> fires.
        /// </summary>
        /// xmi:id="Transition-effect"
        /// xmi:aggregation="composite"
        Behavior Effect { get; }
        #endregion
        #region P:Guard:Constraint
        /// <summary>
        /// A <see cref="Guard"/> is a <see cref="Constraint"/> that provides a fine-grained control over the firing of the <see cref="Transition"/>. The <see cref="Guard"/> is evaluated when an <see cref="Event"/> occurrence is dispatched by the <see cref="StateMachine"/>. If the <see cref="Guard"/> is true at that time, the <see cref="Transition"/> may be enabled, otherwise, it is disabled. Guards should be pure expressions without side effects. Guard expressions with side effects are ill formed.
        /// </summary>
        /// xmi:id="Transition-guard"
        /// xmi:aggregation="composite"
        Constraint Guard { get; }
        #endregion
        #region P:Kind:TransitionKind
        /// <summary>
        /// Indicates the precise type of the <see cref="Transition"/>.
        /// </summary>
        /// xmi:id="Transition-kind"
        TransitionKind Kind { get; }
        #endregion
        #region P:RedefinedTransition:Transition
        /// <summary>
        /// The <see cref="Transition"/> that is redefined by this <see cref="Transition"/>.
        /// </summary>
        /// xmi:id="Transition-redefinedTransition"
        Transition RedefinedTransition { get; }
        #endregion
        #region P:RedefinitionContext:Classifier
        /// <summary>
        /// References the <see cref="Classifier"/> in which context this element may be redefined.
        /// </summary>
        /// xmi:id="Transition-redefinitionContext"
        /// xmi:redefines="RedefinableElement-redefinitionContext{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.RedefinitionContext"/>}"
        Classifier RedefinitionContext { get; }
        #endregion
        #region P:Source:Vertex
        /// <summary>
        /// Designates the originating <see cref="Vertex"/> (<see cref="State"/> or <see cref="Pseudostate"/>) of the <see cref="Transition"/>.
        /// </summary>
        /// xmi:id="Transition-source"
        Vertex Source { get; }
        #endregion
        #region P:Target:Vertex
        /// <summary>
        /// Designates the <see cref="Target"/> <see cref="Vertex"/> that is reached when the <see cref="Transition"/> is taken.
        /// </summary>
        /// xmi:id="Transition-target"
        Vertex Target { get; }
        #endregion
        #region P:Trigger:Trigger[]
        /// <summary>
        /// Specifies the Triggers that may fire the transition.
        /// </summary>
        /// xmi:id="Transition-trigger"
        /// xmi:aggregation="composite"
        Trigger[] Trigger { get; }
        #endregion

        #region M:containingStateMachine:StateMachine
        /// <summary>
        /// The query <see cref="containingStateMachine"/> returns the <see cref="StateMachine"/> that contains the <see cref="Transition"/> either directly or transitively.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (container.containingStateMachine())
        ///   ]]>
        ///   xmi:id="Transition-containingStateMachine-spec"
        /// </rule>
        /// xmi:id="Transition-containingStateMachine"
        /// xmi:is-query="true"
        StateMachine containingStateMachine();
        #endregion
        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <summary>
        /// The query isConsistentWith specifies that a redefining <see cref="Transition"/> is consistent with a redefined <see cref="Transition"/> provided that the <see cref="Source"/> <see cref="Vertex"/> of the redefining <see cref="Transition"/> redefines the <see cref="Source"/> <see cref="Vertex"/> of the redefined <see cref="Transition"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (redefiningElement.oclIsKindOf(Transition) and
        ///       redefiningElement.oclAsType(Transition).source.redefinedTransition = source)
        ///   ]]>
        ///   xmi:id="Transition-isConsistentWith-spec"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     redefiningElement.isRedefinitionContextValid(self)
        ///   ]]>
        ///   xmi:id="Transition-isConsistentWith-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// xmi:id="Transition-isConsistentWith"
        /// xmi:is-query="true"
        /// xmi:redefines="RedefinableElement-isConsistentWith{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>}"
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        #region M:redefinitionContext:Classifier
        /// <summary>
        /// The redefinition context of a <see cref="Transition"/> is the nearest containing <see cref="StateMachine"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = containingStateMachine()
        ///   ]]>
        ///   xmi:id="Transition-redefinitionContext.1-spec"
        /// </rule>
        /// xmi:id="Transition-redefinitionContext.1"
        /// xmi:is-query="true"
        Classifier redefinitionContext();
        #endregion
        }
    }

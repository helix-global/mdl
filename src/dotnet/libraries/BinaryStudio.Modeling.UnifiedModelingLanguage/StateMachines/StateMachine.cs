using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// StateMachines can be used to express event-driven behaviors of parts of a system. <see cref="Behavior"/> is modeled as a traversal of a graph of Vertices interconnected by one or more joined <see cref="Transition"/> arcs that are triggered by the dispatching of successive <see cref="Event"/> occurrences. During this traversal, the <see cref="StateMachine"/> may execute a sequence of Behaviors associated with various elements of the <see cref="StateMachine"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The connection points of a <see cref="StateMachine"/> are Pseudostates of kind entry point or exit point.
    ///   <![CDATA[
    ///     connectionPoint->forAll (kind = PseudostateKind::entryPoint or kind = PseudostateKind::exitPoint)
    ///   ]]>
    ///   xmi:id="StateMachine-connection_points"
    /// </rule>
    /// <rule language="OCL">
    ///   The <see cref="Classifier"/> context of a <see cref="StateMachine"/> cannot be an <see cref="Interface"/>.
    ///   <![CDATA[
    ///     _'context' <> null implies not _'context'.oclIsKindOf(Interface)
    ///   ]]>
    ///   xmi:id="StateMachine-classifier_context"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="StateMachine"/> as the method for a <see cref="BehavioralFeature"/> cannot have entry/exit connection points.
    ///   <![CDATA[
    ///     specification <> null implies connectionPoint->isEmpty()
    ///   ]]>
    ///   xmi:id="StateMachine-method"
    /// </rule>
    /// <rule language="OCL">
    ///   The context <see cref="Classifier"/> of the method <see cref="StateMachine"/> of a <see cref="BehavioralFeature"/> must be the <see cref="Classifier"/> that owns the <see cref="BehavioralFeature"/>.
    ///   <![CDATA[
    ///     specification <> null implies ( _'context' <> null and specification.featuringClassifier->exists(c | c = _'context'))
    ///   ]]>
    ///   xmi:id="StateMachine-context_classifier"
    /// </rule>
    /// xmi:id="StateMachine"
    public interface StateMachine : Behavior
        {
        #region P:ConnectionPoint:Pseudostate[]
        /// <summary>
        /// The connection points defined for this <see cref="StateMachine"/>. They represent the interface of the <see cref="StateMachine"/> when used as <see cref="Part"/> of submachine <see cref="State"/>
        /// </summary>
        /// xmi:id="StateMachine-connectionPoint"
        /// xmi:aggregation="composite"
        /// xmi:association="A_connectionPoint_stateMachine"
        /// xmi:subsets="Namespace-ownedMember"
        Pseudostate[] ConnectionPoint { get; }
        #endregion
        #region P:ExtendedStateMachine:StateMachine[]
        /// <summary>
        /// The StateMachines of which this is an <see cref="Extension"/>.
        /// </summary>
        /// xmi:id="StateMachine-extendedStateMachine"
        /// xmi:association="A_extendedStateMachine_stateMachine"
        /// xmi:redefines="Behavior-redefinedBehavior{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Behavior.RedefinedBehavior"/>}"
        StateMachine[] ExtendedStateMachine { get; }
        #endregion
        #region P:Region:Region[]
        /// <summary>
        /// The Regions owned directly by the <see cref="StateMachine"/>.
        /// </summary>
        /// xmi:id="StateMachine-region"
        /// xmi:aggregation="composite"
        /// xmi:association="A_region_stateMachine"
        /// xmi:subsets="Namespace-ownedMember"
        [Multiplicity("1..*")]
        Region[] Region { get; }
        #endregion
        #region P:SubmachineState:State[]
        /// <summary>
        /// References the submachine(s) in case of a submachine <see cref="State"/>. Multiple machines are referenced in case of a concurrent <see cref="State"/>.
        /// </summary>
        /// xmi:id="StateMachine-submachineState"
        /// xmi:association="A_submachineState_submachine"
        State[] SubmachineState { get; }
        #endregion

        #region M:ancestor(Vertex,Vertex):Boolean
        /// <summary>
        /// The query ancestor(s1, s2) checks whether <see cref="Vertex"/> s2 is an ancestor of <see cref="Vertex"/> s1.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if (s2 = s1) then 
        ///     	true 
        ///     else 
        ///     	if s1.container.stateMachine->notEmpty() then 
        ///     	    true
        ///     	else 
        ///     	    if s2.container.stateMachine->notEmpty() then 
        ///     	        false
        ///     	    else
        ///     	        ancestor(s1, s2.container.state)
        ///     	     endif
        ///     	 endif
        ///     endif  )
        ///   ]]>
        ///   xmi:id="StateMachine-ancestor-spec"
        /// </rule>
        /// xmi:id="StateMachine-ancestor"
        /// xmi:is-query="true"
        Boolean ancestor(Vertex s1,Vertex s2);
        #endregion
        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <summary>
        /// The query isConsistentWith specifies that a <see cref="StateMachine"/> can be redefined by any other <see cref="StateMachine"/> for which the redefinition <see cref="Context"/> is valid (see the isRedefinitionContextValid operation). Note that consistency requirements for the redefinition of Regions and <see cref="ConnectionPoint"/> Pseudostates owned by a <see cref="StateMachine"/> are specified by the isConsistentWith and isRedefinitionContextValid operations for <see cref="Region"/> and <see cref="Vertex"/> (and its subclass <see cref="Pseudostate"/>).
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = true
        ///   ]]>
        ///   xmi:id="StateMachine-isConsistentWith-spec"
        /// </rule>
        /// xmi:id="StateMachine-isConsistentWith"
        /// xmi:is-query="true"
        /// xmi:redefines="RedefinableElement-isConsistentWith{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>}"
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        #region M:isRedefinitionContextValid(RedefinableElement):Boolean
        /// <summary>
        /// The query isRedefinitionContextValid specifies whether the redefinition <see cref="Context"/> of a <see cref="StateMachine"/> is properly related to the redefinition contexts of a <see cref="StateMachine"/> it redefines. The requirement is that the <see cref="Context"/> <see cref="BehavioredClassifier"/> of a redefining <see cref="StateMachine"/> must specialize the <see cref="Context"/> <see cref="Classifier"/> of the redefined <see cref="StateMachine"/>. If the redefining <see cref="StateMachine"/> does not have a <see cref="Context"/> <see cref="BehavioredClassifier"/>, then then the redefining <see cref="StateMachine"/> also must not have a <see cref="Context"/> <see cref="BehavioredClassifier"/> but must, instead, specialize the redefining <see cref="StateMachine"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (redefinedElement.oclIsKindOf(StateMachine) and
        ///       let parentContext : BehavioredClassifier =
        ///         redefinedElement.oclAsType(StateMachine).context in
        ///       if context = null then
        ///         parentContext = null and self.allParents()→includes(redefinedElement)
        ///       else
        ///         parentContext <> null and context.allParents()->includes(parentContext)
        ///       endif)
        ///   ]]>
        ///   xmi:id="StateMachine-isRedefinitionContextValid-spec"
        /// </rule>
        /// xmi:id="StateMachine-isRedefinitionContextValid"
        /// xmi:is-query="true"
        /// xmi:redefines="RedefinableElement-isRedefinitionContextValid{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isRedefinitionContextValid"/>}"
        Boolean isRedefinitionContextValid(RedefinableElement redefinedElement);
        #endregion
        #region M:LCA(Vertex,Vertex):Region
        /// <summary>
        /// The operation LCA(s1,s2) returns the <see cref="Region"/> that is the least common ancestor of Vertices s1 and s2, based on the <see cref="StateMachine"/> containment hierarchy.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if ancestor(s1, s2) then 
        ///         s2.container
        ///     else
        ///     	if ancestor(s2, s1) then
        ///     	    s1.container 
        ///     	else 
        ///     	    LCA(s1.container.state, s2.container.state)
        ///     	endif
        ///     endif)
        ///   ]]>
        ///   xmi:id="StateMachine-LCA-spec"
        /// </rule>
        /// xmi:id="StateMachine-LCA"
        /// xmi:is-query="true"
        Region LCA(Vertex s1,Vertex s2);
        #endregion
        #region M:LCAState(Vertex,Vertex):State
        /// <summary>
        /// This utility funciton is like the LCA, except that it returns the nearest composite <see cref="State"/> that contains both input Vertices.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if v2.oclIsTypeOf(State) and ancestor(v1, v2) then
        ///     	v2.oclAsType(State)
        ///     else if v1.oclIsTypeOf(State) and ancestor(v2, v1) then
        ///     	v1.oclAsType(State)
        ///     else if (v1.container.state->isEmpty() or v2.container.state->isEmpty()) then 
        ///     	null.oclAsType(State)
        ///     else LCAState(v1.container.state, v2.container.state)
        ///     endif endif endif)
        ///   ]]>
        ///   xmi:id="StateMachine-LCAState-spec"
        /// </rule>
        /// xmi:id="StateMachine-LCAState"
        /// xmi:is-query="true"
        State LCAState(Vertex v1,Vertex v2);
        #endregion
        }
    }

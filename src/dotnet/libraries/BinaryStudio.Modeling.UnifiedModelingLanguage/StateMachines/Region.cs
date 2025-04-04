﻿using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Region"/> is a top-level part of a <see cref="StateMachine"/> or a composite <see cref="State"/>, that serves as a container for the Vertices and Transitions of the <see cref="StateMachine"/>. A <see cref="StateMachine"/> or composite <see cref="State"/> may contain multiple Regions representing behaviors that may occur in parallel.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="Region"/> can have at most one deep history <see cref="Vertex"/>.
    ///   <![CDATA[
    ///     self.subvertex->select (oclIsKindOf(Pseudostate))->collect(oclAsType(Pseudostate))->
    ///        select(kind = PseudostateKind::deepHistory)->size() <= 1
    ///     
    ///   ]]>
    ///   xmi:id="Region-deep_history_vertex"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Region"/> can have at most one shallow history <see cref="Vertex"/>.
    ///   <![CDATA[
    ///     subvertex->select(oclIsKindOf(Pseudostate))->collect(oclAsType(Pseudostate))->
    ///       select(kind = PseudostateKind::shallowHistory)->size() <= 1
    ///     
    ///   ]]>
    ///   xmi:id="Region-shallow_history_vertex"
    /// </rule>
    /// <rule language="OCL">
    ///   If a <see cref="Region"/> is owned by a <see cref="StateMachine"/>, then it cannot also be owned by a <see cref="State"/> and vice versa.
    ///   <![CDATA[
    ///     (stateMachine <> null implies state = null) and (state <> null implies stateMachine = null)
    ///   ]]>
    ///   xmi:id="Region-owned"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Region"/> can have at most one initial <see cref="Vertex"/>.
    ///   <![CDATA[
    ///     self.subvertex->select (oclIsKindOf(Pseudostate))->collect(oclAsType(Pseudostate))->
    ///       select(kind = PseudostateKind::initial)->size() <= 1
    ///     
    ///   ]]>
    ///   xmi:id="Region-initial_vertex"
    /// </rule>
    /// xmi:id="Region"
    public interface Region : Namespace,RedefinableElement
        {
        #region P:ExtendedRegion:Region
        /// <summary>
        /// The region of which this region is an extension.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.RedefinedElement"/>"
        /// </summary>
        /// xmi:id="Region-extendedRegion"
        /// xmi:association="A_extendedRegion_region"
        [Multiplicity("0..1")]
        Region ExtendedRegion { get;set; }
        #endregion
        #region P:RedefinitionContext:Classifier
        /// <summary>
        /// References the <see cref="Classifier"/> in which context this element may be redefined.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.RedefinitionContext"/>"
        /// </summary>
        /// xmi:id="Region-redefinitionContext"
        /// xmi:association="A_redefinitionContext_region"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Classifier RedefinitionContext { get; }
        #endregion
        #region P:State:State
        /// <summary>
        /// The <see cref="State"/> that owns the <see cref="Region"/>. If a <see cref="Region"/> is owned by a <see cref="State"/>, then it cannot also be owned by a <see cref="StateMachine"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Region-state"
        /// xmi:association="A_region_state"
        [Multiplicity("0..1")]
        State State { get;set; }
        #endregion
        #region P:StateMachine:StateMachine
        /// <summary>
        /// The <see cref="StateMachine"/> that owns the <see cref="Region"/>. If a <see cref="Region"/> is owned by a <see cref="StateMachine"/>, then it cannot also be owned by a <see cref="State"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Region-stateMachine"
        /// xmi:association="A_region_stateMachine"
        [Multiplicity("0..1")]
        StateMachine StateMachine { get;set; }
        #endregion
        #region P:Subvertex:IList<Vertex>
        /// <summary>
        /// The set of Vertices that are owned by this <see cref="Region"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Region-subvertex"
        /// xmi:aggregation="composite"
        /// xmi:association="A_subvertex_container"
        IList<Vertex> Subvertex { get; }
        #endregion
        #region P:Transition:IList<Transition>
        /// <summary>
        /// The set of Transitions owned by the <see cref="Region"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Region-transition"
        /// xmi:aggregation="composite"
        /// xmi:association="A_transition_container"
        IList<Transition> Transition { get; }
        #endregion

        #region M:belongsToPSM:Boolean
        /// <summary>
        /// The operation belongsToPSM () checks if the <see cref="Region"/> belongs to a <see cref="ProtocolStateMachine"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if  stateMachine <> null 
        ///     then
        ///       stateMachine.oclIsKindOf(ProtocolStateMachine)
        ///     else 
        ///       state <> null  implies  state.container.belongsToPSM()
        ///     endif )
        ///   ]]>
        ///   xmi:id="Region-belongsToPSM-spec"
        /// </rule>
        /// xmi:id="Region-belongsToPSM"
        /// xmi:is-query="true"
        Boolean belongsToPSM();
        #endregion
        #region M:containingStateMachine:StateMachine
        /// <summary>
        /// The operation <see cref="containingStateMachine"/> returns the <see cref="StateMachine"/> in which this <see cref="Region"/> is defined.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if stateMachine = null 
        ///     then
        ///       state.containingStateMachine()
        ///     else
        ///       stateMachine
        ///     endif)
        ///   ]]>
        ///   xmi:id="Region-containingStateMachine-spec"
        /// </rule>
        /// xmi:id="Region-containingStateMachine"
        /// xmi:is-query="true"
        StateMachine containingStateMachine();
        #endregion
        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <summary>
        /// The query isConsistentWith specifies that a <see cref="Region"/> can be redefined by any <see cref="Region"/> for which the redefinition context is valid (see the isRedefinitionContextValid operation). Note that consistency requirements for the redefinition of Vertices and Transitions within a redefining <see cref="Region"/> are specified by the isConsistentWith and isRedefinitionContextValid operations for <see cref="Vertex"/> (and its subclasses) and <see cref="Transition"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = true
        ///   ]]>
        ///   xmi:id="Region-isConsistentWith-spec"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     redefiningElement.isRedefinitionContextValid(self)
        ///   ]]>
        ///   xmi:id="Region-isConsistentWith-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// xmi:id="Region-isConsistentWith"
        /// xmi:is-query="true"
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        #region M:isRedefinitionContextValid(RedefinableElement):Boolean
        /// <summary>
        /// The query <see cref="isRedefinitionContextValid"/> specifies whether the redefinition contexts of a <see cref="Region"/> are properly related to the redefinition contexts of the specified <see cref="Region"/> to allow this element to redefine the other. The containing <see cref="StateMachine"/> or <see cref="State"/> of a redefining <see cref="Region"/> must Redefine the containing <see cref="StateMachine"/> or <see cref="State"/> of the redefined <see cref="Region"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isRedefinitionContextValid"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if redefinedElement.oclIsKindOf(Region) then
        ///       let redefinedRegion : Region = redefinedElement.oclAsType(Region) in
        ///         if stateMachine->isEmpty() then
        ///         -- the Region is owned by a State
        ///           (state.redefinedState->notEmpty() and state.redefinedState.region->includes(redefinedRegion))
        ///         else -- the region is owned by a StateMachine
        ///           (stateMachine.extendedStateMachine->notEmpty() and
        ///             stateMachine.extendedStateMachine->exists(sm : StateMachine |
        ///               sm.region->includes(redefinedRegion)))
        ///         endif
        ///     else
        ///       false
        ///     endif)
        ///   ]]>
        ///   xmi:id="Region-isRedefinitionContextValid-spec"
        /// </rule>
        /// xmi:id="Region-isRedefinitionContextValid"
        /// xmi:is-query="true"
        Boolean isRedefinitionContextValid(RedefinableElement redefinedElement);
        #endregion
        #region M:redefinitionContext:Classifier
        /// <summary>
        /// The redefinition context of a <see cref="Region"/> is the nearest containing <see cref="StateMachine"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = containingStateMachine()
        ///   ]]>
        ///   xmi:id="Region-redefinitionContext.1-spec"
        /// </rule>
        /// xmi:id="Region-redefinitionContext.1"
        /// xmi:is-query="true"
        Classifier redefinitionContext();
        #endregion
        }
    }

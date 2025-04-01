using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Vertex"/> is an abstraction of a node in a <see cref="StateMachine"/> graph. It can be the source or destination of any number of Transitions.
    /// </summary>
    /// xmi:id="Vertex"
    public interface Vertex : NamedElement,RedefinableElement
        {
        #region P:RedefinedVertex:Vertex
        /// <summary>
        /// The <see cref="Vertex"/> of which this <see cref="Vertex"/> is a redefinition.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.RedefinedElement"/>"
        /// </summary>
        /// xmi:id="State-redefinedState"
        /// xmi:association="A_redefinedState_state"
        [Multiplicity("0..1")]
        Vertex RedefinedVertex { get;set; }
        #endregion
        #region P:RedefinitionContext:Classifier
        /// <summary>
        /// References the <see cref="Classifier"/> in which context this element may be redefined.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.RedefinitionContext"/>"
        /// </summary>
        /// xmi:id="State-redefinitionContext"
        /// xmi:association="A_redefinitionContext_state"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Classifier RedefinitionContext { get; }
        #endregion
        #region P:Container:Region
        /// <summary>
        /// The <see cref="Region"/> that contains this <see cref="Vertex"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Vertex-container"
        /// xmi:association="A_subvertex_container"
        [Multiplicity("0..1")]
        Region Container { get;set; }
        #endregion
        #region P:Incoming:IList<Transition>
        /// <summary>
        /// Specifies the Transitions entering this <see cref="Vertex"/>.
        /// </summary>
        /// xmi:id="Vertex-incoming"
        /// xmi:association="A_incoming_target_vertex"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        IList<Transition> Incoming { get; }
        #endregion
        #region P:Outgoing:IList<Transition>
        /// <summary>
        /// Specifies the Transitions departing from this <see cref="Vertex"/>.
        /// </summary>
        /// xmi:id="Vertex-outgoing"
        /// xmi:association="A_outgoing_source_vertex"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        IList<Transition> Outgoing { get; }
        #endregion

        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <summary>
        /// The query isRedefinitionContextValid specifies that the redefinition context of a redefining <see cref="Vertex"/> is properly related to the redefinition context of the redefined <see cref="Vertex"/> if the <see cref="Owner"/> of the redefining <see cref="Vertex"/> is a redefinition of the <see cref="Owner"/> of the redefined <see cref="Vertex"/>. Note that the <see cref="Owner"/> of a <see cref="Vertex"/> may be a <see cref="Region"/>, a <see cref="StateMachine"/> (for a connectionPoint <see cref="Pseudostate"/>), or a <see cref="State"/> (for a connectionPoint <see cref="Pseudostate"/> or a connection <see cref="ConnectionPointReference"/>), all of which are RedefinableElements.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     redefiningElement.isRedefinitionContextValid(self)
        ///   ]]>
        ///   xmi:id="State-isConsistentWith-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (redefinedElement.oclIsKindOf(Vertex) and
        ///       owner.oclAsType(RedefinableElement).redefinedElement->includes(redefinedElement.owner))
        ///   ]]>
        ///   xmi:id="State-isConsistentWith-spec"
        /// </rule>
        /// xmi:id="State-isConsistentWith"
        /// xmi:is-query="true"
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        #region M:redefinitionContext:Classifier
        /// <summary>
        /// The redefinition context of a <see cref="Vertex"/> is the nearest containing <see cref="StateMachine"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = containingStateMachine()
        ///   ]]>
        ///   xmi:id="State-redefinitionContext.1-spec"
        /// </rule>
        /// xmi:id="State-redefinitionContext.1"
        /// xmi:is-query="true"
        Classifier redefinitionContext();
        #endregion
        #region M:containingStateMachine:StateMachine
        /// <summary>
        /// The operation <see cref="containingStateMachine"/> returns the <see cref="StateMachine"/> in which this <see cref="Vertex"/> is defined.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if container <> null
        ///     then
        ///     -- the container is a region
        ///        container.containingStateMachine()
        ///     else 
        ///        if (self.oclIsKindOf(Pseudostate)) and ((self.oclAsType(Pseudostate).kind = PseudostateKind::entryPoint) or (self.oclAsType(Pseudostate).kind = PseudostateKind::exitPoint)) then
        ///           self.oclAsType(Pseudostate).stateMachine
        ///        else 
        ///           if (self.oclIsKindOf(ConnectionPointReference)) then
        ///               self.oclAsType(ConnectionPointReference).state.containingStateMachine() -- no other valid cases possible
        ///           else 
        ///               null
        ///           endif
        ///        endif
        ///     endif
        ///     
        ///     )
        ///   ]]>
        ///   xmi:id="Vertex-containingStateMachine-spec"
        /// </rule>
        /// xmi:id="Vertex-containingStateMachine"
        /// xmi:is-query="true"
        StateMachine containingStateMachine();
        #endregion
        #region M:incoming:Transition[]
        /// <summary>
        /// Derivation for <see cref="Vertex"/>::/<see cref="Incoming"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (Transition.allInstances()->select(target=self))
        ///   ]]>
        ///   xmi:id="Vertex-incoming.1-spec"
        /// </rule>
        /// xmi:id="Vertex-incoming.1"
        /// xmi:is-query="true"
        Transition[] incoming();
        #endregion
        #region M:isContainedInRegion(Region):Boolean
        /// <summary>
        /// This utility query returns true if the <see cref="Vertex"/> is contained in the <see cref="Region"/> r (input argument).
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if (container = r) then
        ///     	true
        ///     else
        ///     	if (r.state->isEmpty()) then
        ///     		false
        ///     	else
        ///     		container.state.isContainedInRegion(r)
        ///     	endif
        ///     endif)
        ///   ]]>
        ///   xmi:id="Vertex-isContainedInRegion-spec"
        /// </rule>
        /// xmi:id="Vertex-isContainedInRegion"
        /// xmi:is-query="true"
        Boolean isContainedInRegion(Region r);
        #endregion
        #region M:isContainedInState(State):Boolean
        /// <summary>
        /// This utility operation returns true if the <see cref="Vertex"/> is contained in the <see cref="State"/> s (input argument).
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if not s.isComposite() or container->isEmpty() then
        ///     	false
        ///     else
        ///     	if container.state = s then 
        ///     		true
        ///     	else
        ///     		container.state.isContainedInState(s)
        ///     	endif
        ///     endif)
        ///   ]]>
        ///   xmi:id="Vertex-isContainedInState-spec"
        /// </rule>
        /// xmi:id="Vertex-isContainedInState"
        /// xmi:is-query="true"
        Boolean isContainedInState(State s);
        #endregion
        #region M:outgoing:Transition[]
        /// <summary>
        /// Derivation for <see cref="Vertex"/>::/<see cref="Outgoing"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (Transition.allInstances()->select(source=self))
        ///   ]]>
        ///   xmi:id="Vertex-outgoing.1-spec"
        /// </rule>
        /// xmi:id="Vertex-outgoing.1"
        /// xmi:is-query="true"
        Transition[] outgoing();
        #endregion
        }
    }

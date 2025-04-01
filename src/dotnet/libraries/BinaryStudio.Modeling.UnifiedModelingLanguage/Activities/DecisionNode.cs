using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="DecisionNode"/> is a <see cref="ControlNode"/> that chooses between <see cref="Outgoing"/> ActivityEdges for the routing of tokens.
    /// </summary>
    /// <rule language="OCL">
    ///   If the <see cref="DecisionNode"/> has no decisionInputFlow and an incoming <see cref="ControlFlow"/>, then any decisionInput <see cref="Behavior"/> has no in parameters.
    ///   <![CDATA[
    ///     (decisionInput<>null and decisionInputFlow=null and incoming->exists(oclIsKindOf(ControlFlow))) implies
    ///        decisionInput.inputParameters()->isEmpty()
    ///   ]]>
    ///   xmi:id="DecisionNode-zero_input_parameters"
    /// </rule>
    /// <rule language="OCL">
    ///   The ActivityEdges incoming to and outgoing from a <see cref="DecisionNode"/>, other than the decisionInputFlow (if any), must be either all ObjectFlows or all ControlFlows.
    ///   <![CDATA[
    ///     let allEdges: Set(ActivityEdge) = incoming->union(outgoing) in
    ///     let allRelevantEdges: Set(ActivityEdge) = if decisionInputFlow->notEmpty() then allEdges->excluding(decisionInputFlow) else allEdges endif in
    ///     allRelevantEdges->forAll(oclIsKindOf(ControlFlow)) or allRelevantEdges->forAll(oclIsKindOf(ObjectFlow))
    ///     
    ///   ]]>
    ///   xmi:id="DecisionNode-edges"
    /// </rule>
    /// <rule language="OCL">
    ///   The decisionInputFlow of a <see cref="DecisionNode"/> must be an incoming <see cref="ActivityEdge"/> of the <see cref="DecisionNode"/>.
    ///   <![CDATA[
    ///     incoming->includes(decisionInputFlow)
    ///   ]]>
    ///   xmi:id="DecisionNode-decision_input_flow_incoming"
    /// </rule>
    /// <rule language="OCL">
    ///   If the <see cref="DecisionNode"/> has a decisionInputFlow and an second incoming <see cref="ObjectFlow"/>, then any decisionInput has two in Parameters, the first of which has a type that is the same as or a supertype of the type of object tokens offered on the non-decisionInputFlow and the second of which has a type that is the same as or a supertype of the type of object tokens offered on the decisionInputFlow.
    ///   <![CDATA[
    ///     (decisionInput<>null and decisionInputFlow<>null and incoming->forAll(oclIsKindOf(ObjectFlow))) implies
    ///     	decisionInput.inputParameters()->size()=2
    ///   ]]>
    ///   xmi:id="DecisionNode-two_input_parameters"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="DecisionNode"/> has one or two incoming ActivityEdges and at least one outgoing <see cref="ActivityEdge"/>.
    ///   <![CDATA[
    ///     (incoming->size() = 1 or incoming->size() = 2) and outgoing->size() > 0
    ///   ]]>
    ///   xmi:id="DecisionNode-incoming_outgoing_edges"
    /// </rule>
    /// <rule language="OCL">
    ///   If the <see cref="DecisionNode"/> has a decisionInputFlow and an incoming <see cref="ControlFlow"/>, then any decisionInput <see cref="Behavior"/> has one in <see cref="Parameter"/> whose type is the same as or a supertype of the type of object tokens offered on the decisionInputFlow.
    ///   <![CDATA[
    ///     (decisionInput<>null and decisionInputFlow<>null and incoming->exists(oclIsKindOf(ControlFlow))) implies
    ///     	decisionInput.inputParameters()->size()=1
    ///   ]]>
    ///   xmi:id="DecisionNode-incoming_control_one_input_parameter"
    /// </rule>
    /// <rule language="OCL">
    ///   A decisionInput <see cref="Behavior"/> has no out parameters, no inout parameters, and one return parameter.
    ///   <![CDATA[
    ///     decisionInput<>null implies 
    ///       (decisionInput.ownedParameter->forAll(par | 
    ///          par.direction <> ParameterDirectionKind::out and 
    ///          par.direction <> ParameterDirectionKind::inout ) and
    ///        decisionInput.ownedParameter->one(par | 
    ///          par.direction <> ParameterDirectionKind::return))
    ///          
    ///   ]]>
    ///   xmi:id="DecisionNode-parameters"
    /// </rule>
    /// <rule language="OCL">
    ///   If the <see cref="DecisionNode"/> has no decisionInputFlow and an incoming <see cref="ObjectFlow"/>, then any decisionInput <see cref="Behavior"/> has one in <see cref="Parameter"/> whose type is the same as or a supertype of the type of object tokens offered on the incoming <see cref="ObjectFlow"/>.
    ///   <![CDATA[
    ///     (decisionInput<>null and decisionInputFlow=null and incoming->forAll(oclIsKindOf(ObjectFlow))) implies
    ///     	decisionInput.inputParameters()->size()=1
    ///   ]]>
    ///   xmi:id="DecisionNode-incoming_object_one_input_parameter"
    /// </rule>
    /// xmi:id="DecisionNode"
    public interface DecisionNode : ControlNode
        {
        #region P:DecisionInput:Behavior
        /// <summary>
        /// A <see cref="Behavior"/> that is executed to provide an input to guard ValueSpecifications on ActivityEdges <see cref="Outgoing"/> from the <see cref="DecisionNode"/>.
        /// </summary>
        /// xmi:id="DecisionNode-decisionInput"
        /// xmi:association="A_decisionInput_decisionNode"
        [Multiplicity("0..1")]
        Behavior DecisionInput { get;set; }
        #endregion
        #region P:DecisionInputFlow:ObjectFlow
        /// <summary>
        /// An additional <see cref="ActivityEdge"/> <see cref="Incoming"/> to the <see cref="DecisionNode"/> that provides a decision input value for the guards ValueSpecifications on ActivityEdges <see cref="Outgoing"/> from the <see cref="DecisionNode"/>.
        /// </summary>
        /// xmi:id="DecisionNode-decisionInputFlow"
        /// xmi:association="A_decisionInputFlow_decisionNode"
        [Multiplicity("0..1")]
        ObjectFlow DecisionInputFlow { get;set; }
        #endregion
        }
    }

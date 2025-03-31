using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ExceptionHandler"/> is an <see cref="Element"/> that specifies a <see cref="HandlerBody"/> <see cref="ExecutableNode"/> to execute in case the specified exception occurs during the execution of the protected <see cref="ExecutableNode"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The handlerBody has no incoming or outgoing ActivityEdges and the exceptionInput has no incoming ActivityEdges.
    ///   <![CDATA[
    ///     handlerBody.incoming->isEmpty() and handlerBody.outgoing->isEmpty() and exceptionInput.incoming->isEmpty()
    ///   ]]>
    ///   xmi:id="ExceptionHandler-handler_body_edges"
    /// </rule>
    /// <rule language="OCL">
    ///   If the protectedNode is an <see cref="Action"/> with OutputPins, then the handlerBody must also be an <see cref="Action"/> with the same number of OutputPins, which are compatible in type, ordering, and multiplicity to those of the protectedNode.
    ///   <![CDATA[
    ///     (protectedNode.oclIsKindOf(Action) and protectedNode.oclAsType(Action).output->notEmpty()) implies
    ///     (
    ///       handlerBody.oclIsKindOf(Action) and 
    ///       let protectedNodeOutput : OrderedSet(OutputPin) = protectedNode.oclAsType(Action).output,
    ///             handlerBodyOutput : OrderedSet(OutputPin) =  handlerBody.oclAsType(Action).output in
    ///         protectedNodeOutput->size() = handlerBodyOutput->size() and
    ///         Sequence{1..protectedNodeOutput->size()}->forAll(i |
    ///         	handlerBodyOutput->at(i).type.conformsTo(protectedNodeOutput->at(i).type) and
    ///         	handlerBodyOutput->at(i).isOrdered=protectedNodeOutput->at(i).isOrdered and
    ///         	handlerBodyOutput->at(i).compatibleWith(protectedNodeOutput->at(i)))
    ///     )
    ///   ]]>
    ///   xmi:id="ExceptionHandler-output_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   The handlerBody is an <see cref="Action"/> with one <see cref="InputPin"/>, and that <see cref="InputPin"/> is the same as the exceptionInput.
    ///   <![CDATA[
    ///     handlerBody.oclIsKindOf(Action) and
    ///     let inputs: OrderedSet(InputPin) = handlerBody.oclAsType(Action).input in
    ///     inputs->size()=1 and inputs->first()=exceptionInput
    ///   ]]>
    ///   xmi:id="ExceptionHandler-one_input"
    /// </rule>
    /// <rule language="OCL">
    ///   An <see cref="ActivityEdge"/> that has a source within the handlerBody of an <see cref="ExceptionHandler"/> must have its target in the handlerBody also, and vice versa.
    ///   <![CDATA[
    ///     let nodes:Set(ActivityNode) = handlerBody.oclAsType(Action).allOwnedNodes() in
    ///     nodes.outgoing->forAll(nodes->includes(target)) and
    ///     nodes.incoming->forAll(nodes->includes(source))
    ///   ]]>
    ///   xmi:id="ExceptionHandler-edge_source_target"
    /// </rule>
    /// <rule language="OCL">
    ///   The handlerBody must have the same owner as the protectedNode.
    ///   <![CDATA[
    ///     handlerBody.owner=protectedNode.owner
    ///   ]]>
    ///   xmi:id="ExceptionHandler-handler_body_owner"
    /// </rule>
    /// <rule language="OCL">
    ///   The exceptionInput must either have no type or every exceptionType must conform to the exceptionInput type.
    ///   <![CDATA[
    ///     exceptionInput.type=null or 
    ///     exceptionType->forAll(conformsTo(exceptionInput.type.oclAsType(Classifier)))
    ///   ]]>
    ///   xmi:id="ExceptionHandler-exception_input_type"
    /// </rule>
    /// xmi:id="ExceptionHandler"
    public interface ExceptionHandler : Element
        {
        #region P:ExceptionInput:ObjectNode
        /// <summary>
        /// An <see cref="ObjectNode"/> within the <see cref="HandlerBody"/>. When the <see cref="ExceptionHandler"/> catches an exception, the exception token is placed on this <see cref="ObjectNode"/>, causing the <see cref="HandlerBody"/> to execute.
        /// </summary>
        /// xmi:id="ExceptionHandler-exceptionInput"
        /// xmi:association="A_exceptionInput_exceptionHandler"
        ObjectNode ExceptionInput { get; }
        #endregion
        #region P:ExceptionType:Classifier[]
        /// <summary>
        /// The Classifiers whose instances the <see cref="ExceptionHandler"/> catches as exceptions. If an exception occurs whose type is any <see cref="ExceptionType"/>, the <see cref="ExceptionHandler"/> catches the exception and executes the <see cref="HandlerBody"/>.
        /// </summary>
        /// xmi:id="ExceptionHandler-exceptionType"
        /// xmi:association="A_exceptionType_exceptionHandler"
        [Multiplicity("1..*")]
        Classifier[] ExceptionType { get; }
        #endregion
        #region P:HandlerBody:ExecutableNode
        /// <summary>
        /// An <see cref="ExecutableNode"/> that is executed if the <see cref="ExceptionHandler"/> catches an exception.
        /// </summary>
        /// xmi:id="ExceptionHandler-handlerBody"
        /// xmi:association="A_handlerBody_exceptionHandler"
        ExecutableNode HandlerBody { get; }
        #endregion
        #region P:ProtectedNode:ExecutableNode
        /// <summary>
        /// The <see cref="ExecutableNode"/> protected by the <see cref="ExceptionHandler"/>. If an exception propagates out of the <see cref="ProtectedNode"/> and has a type matching one of the exceptionTypes, then it is caught by this <see cref="ExceptionHandler"/>.
        /// </summary>
        /// xmi:id="ExceptionHandler-protectedNode"
        /// xmi:association="A_handler_protectedNode"
        /// xmi:subsets="Element-owner"
        ExecutableNode ProtectedNode { get; }
        #endregion
        }
    }

using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="CallAction"/> is an abstract class for Actions that invoke a <see cref="Behavior"/> with given <see cref="Argument"/> values and (if the invocation is synchronous) receive reply values.
    /// </summary>
    /// <rule language="OCL">
    ///   The number of argument InputPins must be the same as the number of input (in and inout) ownedParameters of the called <see cref="Behavior"/> or <see cref="Operation"/>. The type, ordering and multiplicity of each argument <see cref="InputPin"/> must be consistent with the corresponding input <see cref="Parameter"/>.
    ///   <![CDATA[
    ///     let parameter: OrderedSet(Parameter) = self.inputParameters() in
    ///     argument->size() = parameter->size() and
    ///     Sequence{1..argument->size()}->forAll(i | 
    ///     	argument->at(i).type.conformsTo(parameter->at(i).type) and 
    ///     	argument->at(i).isOrdered = parameter->at(i).isOrdered and
    ///     	argument->at(i).compatibleWith(parameter->at(i)))
    ///   ]]>
    ///   xmi:id="CallAction-argument_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   The number of result OutputPins must be the same as the number of output (inout, out and return) ownedParameters of the called <see cref="Behavior"/> or <see cref="Operation"/>. The type, ordering and multiplicity of each result <see cref="OutputPin"/> must be consistent with the corresponding input <see cref="Parameter"/>.
    ///   <![CDATA[
    ///     let parameter: OrderedSet(Parameter) = self.outputParameters() in
    ///     result->size() = parameter->size() and
    ///     Sequence{1..result->size()}->forAll(i | 
    ///     	parameter->at(i).type.conformsTo(result->at(i).type) and 
    ///     	parameter->at(i).isOrdered = result->at(i).isOrdered and
    ///     	parameter->at(i).compatibleWith(result->at(i)))
    ///   ]]>
    ///   xmi:id="CallAction-result_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   Only synchronous CallActions can have result OutputPins.
    ///   <![CDATA[
    ///     result->notEmpty() implies isSynchronous
    ///   ]]>
    ///   xmi:id="CallAction-synchronous_call"
    /// </rule>
    /// xmi:id="CallAction"
    public interface CallAction : InvocationAction
        {
        #region P:IsSynchronous:Boolean
        /// <summary>
        /// If true, the call is synchronous and the caller waits for completion of the invoked <see cref="Behavior"/>. If false, the call is asynchronous and the caller proceeds immediately and cannot receive return values.
        /// </summary>
        /// xmi:id="CallAction-isSynchronous"
        Boolean IsSynchronous { get; }
        #endregion
        #region P:Result:OutputPin[]
        /// <summary>
        /// The OutputPins on which the reply values from the invocation are placed (if the call is synchronous).
        /// </summary>
        /// xmi:id="CallAction-result"
        /// xmi:aggregation="composite"
        /// xmi:association="A_result_callAction"
        /// xmi:subsets="Action-output"
        [Ordered]
        OutputPin[] Result { get; }
        #endregion

        #region M:inputParameters:Parameter[]
        /// <summary>
        /// Return the in and inout ownedParameters of the <see cref="Behavior"/> or <see cref="Operation"/> being called. (This operation is abstract and should be overridden by subclasses of <see cref="CallAction"/>.)
        /// </summary>
        /// xmi:id="CallAction-inputParameters"
        /// xmi:is-query="true"
        Parameter[] inputParameters();
        #endregion
        #region M:outputParameters:Parameter[]
        /// <summary>
        /// Return the inout, out and return ownedParameters of the <see cref="Behavior"/> or <see cref="Operation"/> being called. (This operation is abstract and should be overridden by subclasses of <see cref="CallAction"/>.)
        /// </summary>
        /// xmi:id="CallAction-outputParameters"
        /// xmi:is-query="true"
        Parameter[] outputParameters();
        #endregion
        }
    }

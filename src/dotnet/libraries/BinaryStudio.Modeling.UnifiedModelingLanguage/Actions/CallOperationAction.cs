using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="CallOperationAction"/> is a <see cref="CallAction"/> that transmits an <see cref="Operation"/> call request to the <see cref="Target"/> object, where it may cause the invocation of associated <see cref="Behavior"/>. The <see cref="Argument"/> values of the <see cref="CallOperationAction"/> are passed on the <see cref="Input"/> Parameters of the <see cref="Operation"/>. If call is synchronous, the execution of the <see cref="CallOperationAction"/> waits until the execution of the invoked <see cref="Operation"/> completes and the values of <see cref="Output"/> Parameters of the <see cref="Operation"/> are placed on the <see cref="Result"/> OutputPins. If the call is asynchronous, the <see cref="CallOperationAction"/> completes immediately and no results values can be provided.
    /// </summary>
    /// <rule language="OCL">
    ///   If onPort has no value, the operation must be an owned or inherited feature of the type of the target <see cref="InputPin"/>, otherwise the <see cref="Port"/> given by onPort must be an owned or inherited feature of the type of the target <see cref="InputPin"/>, and the <see cref="Port"/> must have a required or provided <see cref="Interface"/> with the operation as an owned or inherited feature.
    ///   <![CDATA[
    ///     if onPort=null then  target.type.oclAsType(Classifier).allFeatures()->includes(operation)
    ///     else target.type.oclAsType(Classifier).allFeatures()->includes(onPort) and onPort.provided->union(onPort.required).allFeatures()->includes(operation)
    ///     endif
    ///   ]]>
    ///   xmi:id="CallOperationAction-type_target_pin"
    /// </rule>
    /// xmi:id="CallOperationAction"
    public interface CallOperationAction : CallAction
        {
        #region P:Operation:Operation
        /// <summary>
        /// The <see cref="Operation"/> being invoked.
        /// </summary>
        /// xmi:id="CallOperationAction-operation"
        Operation Operation { get; }
        #endregion
        #region P:Target:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that provides the <see cref="Target"/> object to which the <see cref="Operation"/> call request is sent.
        /// </summary>
        /// xmi:id="CallOperationAction-target"
        /// xmi:aggregation="composite"
        InputPin Target { get; }
        #endregion

        #region M:outputParameters:Parameter[]
        /// <summary>
        /// Return the inout, out and return ownedParameters of the <see cref="Operation"/> being called.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (operation.outputParameters())
        ///   ]]>
        ///   xmi:id="CallOperationAction-outputParameters-spec"
        /// </rule>
        /// xmi:id="CallOperationAction-outputParameters"
        /// xmi:is-query="true"
        /// xmi:redefines="CallAction-outputParameters{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.CallAction.outputParameters"/>}"
        Parameter[] outputParameters();
        #endregion
        #region M:inputParameters:Parameter[]
        /// <summary>
        /// Return the in and inout ownedParameters of the <see cref="Operation"/> being called.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (operation.inputParameters())
        ///   ]]>
        ///   xmi:id="CallOperationAction-inputParameters-spec"
        /// </rule>
        /// xmi:id="CallOperationAction-inputParameters"
        /// xmi:is-query="true"
        /// xmi:redefines="CallAction-inputParameters{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.CallAction.inputParameters"/>}"
        Parameter[] inputParameters();
        #endregion
        }
    }

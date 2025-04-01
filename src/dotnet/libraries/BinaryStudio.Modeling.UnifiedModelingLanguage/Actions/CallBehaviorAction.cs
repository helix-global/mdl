using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="CallBehaviorAction"/> is a <see cref="CallAction"/> that invokes a <see cref="Behavior"/> directly. The <see cref="Argument"/> values of the <see cref="CallBehaviorAction"/> are passed on the <see cref="Input"/> Parameters of the invoked <see cref="Behavior"/>. If the call is synchronous, the execution of the <see cref="CallBehaviorAction"/> waits until the execution of the invoked <see cref="Behavior"/> completes and the values of <see cref="Output"/> Parameters of the <see cref="Behavior"/> are placed on the <see cref="Result"/> OutputPins. If the call is asynchronous, the <see cref="CallBehaviorAction"/> completes immediately and no results values can be provided.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="CallBehaviorAction"/> may not specify onPort.
    ///   <![CDATA[
    ///     onPort=null
    ///   ]]>
    ///   xmi:id="CallBehaviorAction-no_onport"
    /// </rule>
    /// xmi:id="CallBehaviorAction"
    public interface CallBehaviorAction : CallAction
        {
        #region P:Behavior:Behavior
        /// <summary>
        /// The <see cref="Behavior"/> being invoked.
        /// </summary>
        /// xmi:id="CallBehaviorAction-behavior"
        /// xmi:association="A_behavior_callBehaviorAction"
        Behavior Behavior { get;set; }
        #endregion

        #region M:inputParameters:Parameter[]
        /// <summary>
        /// Return the in and inout ownedParameters of the <see cref="Behavior"/> being called.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.CallAction.inputParameters"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (behavior.inputParameters())
        ///   ]]>
        ///   xmi:id="CallBehaviorAction-inputParameters-spec"
        /// </rule>
        /// xmi:id="CallBehaviorAction-inputParameters"
        /// xmi:is-query="true"
        Parameter[] inputParameters();
        #endregion
        #region M:outputParameters:Parameter[]
        /// <summary>
        /// Return the inout, out and return ownedParameters of the <see cref="Behavior"/> being called.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.CallAction.outputParameters"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (behavior.outputParameters())
        ///   ]]>
        ///   xmi:id="CallBehaviorAction-outputParameters-spec"
        /// </rule>
        /// xmi:id="CallBehaviorAction-outputParameters"
        /// xmi:is-query="true"
        Parameter[] outputParameters();
        #endregion
        }
    }

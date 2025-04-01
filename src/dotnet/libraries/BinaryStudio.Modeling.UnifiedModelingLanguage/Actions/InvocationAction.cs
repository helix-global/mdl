using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="InvocationAction"/> is an abstract class for the various actions that request <see cref="Behavior"/> invocation.
    /// 
    /// </summary>
    /// xmi:id="InvocationAction"
    public interface InvocationAction : Action
        {
        #region P:Argument:IList<InputPin>
        /// <summary>
        /// The InputPins that provide the <see cref="Argument"/> values passed in the invocation request.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="InvocationAction-argument"
        /// xmi:aggregation="composite"
        /// xmi:association="A_argument_invocationAction"
        [Ordered]
        IList<InputPin> Argument { get; }
        #endregion
        #region P:OnPort:Port
        /// <summary>
        /// For CallOperationActions, SendSignalActions, and SendObjectActions, an optional <see cref="Port"/> of the target object through which the invocation request is sent.
        /// </summary>
        /// xmi:id="InvocationAction-onPort"
        /// xmi:association="A_onPort_invocationAction"
        [Multiplicity("0..1")]
        Port OnPort { get;set; }
        #endregion
        }
    }

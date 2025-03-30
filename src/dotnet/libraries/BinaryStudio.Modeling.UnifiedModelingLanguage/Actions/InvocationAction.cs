using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="InvocationAction"/> is an abstract class for the various actions that request <see cref="Behavior"/> invocation.
    /// 
    /// </summary>
    /// xmi:id="InvocationAction"
    public interface InvocationAction : Action
        {
        #region P:Argument:InputPin[]
        /// <summary>
        /// The InputPins that provide the <see cref="Argument"/> values passed in the invocation request.
        /// </summary>
        /// xmi:id="InvocationAction-argument"
        /// xmi:aggregation="composite"
        InputPin[] Argument { get; }
        #endregion
        #region P:OnPort:Port
        /// <summary>
        /// For CallOperationActions, SendSignalActions, and SendObjectActions, an optional <see cref="Port"/> of the target object through which the invocation request is sent.
        /// </summary>
        /// xmi:id="InvocationAction-onPort"
        Port OnPort { get; }
        #endregion
        }
    }

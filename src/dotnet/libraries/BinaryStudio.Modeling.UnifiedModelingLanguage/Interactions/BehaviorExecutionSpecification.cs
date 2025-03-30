using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="BehaviorExecutionSpecification"/> is a kind of <see cref="ExecutionSpecification"/> representing the execution of a <see cref="Behavior"/>.
    /// </summary>
    /// xmi:id="BehaviorExecutionSpecification"
    public interface BehaviorExecutionSpecification : ExecutionSpecification
        {
        #region P:Behavior:Behavior
        /// <summary>
        /// <see cref="Behavior"/> whose execution is occurring.
        /// </summary>
        /// xmi:id="BehaviorExecutionSpecification-behavior"
        Behavior Behavior { get; }
        #endregion
        }
    }

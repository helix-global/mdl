using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

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
        /// xmi:association="A_behavior_behaviorExecutionSpecification"
        [Multiplicity("0..1")]
        Behavior Behavior { get; }
        #endregion
        }
    }

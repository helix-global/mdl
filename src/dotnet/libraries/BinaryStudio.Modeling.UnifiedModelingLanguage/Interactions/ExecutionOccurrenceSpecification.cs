using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ExecutionOccurrenceSpecification"/> represents moments in time at which Actions or Behaviors start or finish.
    /// </summary>
    /// xmi:id="ExecutionOccurrenceSpecification"
    public interface ExecutionOccurrenceSpecification : OccurrenceSpecification
        {
        #region P:Execution:ExecutionSpecification
        /// <summary>
        /// References the <see cref="Execution"/> specification describing the <see cref="Execution"/> that is started or finished at this <see cref="Execution"/> event.
        /// </summary>
        /// xmi:id="ExecutionOccurrenceSpecification-execution"
        ExecutionSpecification Execution { get; }
        #endregion
        }
    }

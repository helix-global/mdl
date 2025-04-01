using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

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
        /// xmi:association="A_execution_executionOccurrenceSpecification"
        ExecutionSpecification Execution { get;set; }
        #endregion
        }
    }

using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ExecutionSpecification"/> is a specification of the execution of a unit of <see cref="Behavior"/> or <see cref="Action"/> within the <see cref="Lifeline"/>. The duration of an <see cref="ExecutionSpecification"/> is represented by two OccurrenceSpecifications, the <see cref="Start"/> <see cref="OccurrenceSpecification"/> and the <see cref="Finish"/> <see cref="OccurrenceSpecification"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The startEvent and the finishEvent must be on the same <see cref="Lifeline"/>.
    ///   <![CDATA[
    ///     start.covered = finish.covered
    ///   ]]>
    ///   xmi:id="ExecutionSpecification-same_lifeline"
    /// </rule>
    /// xmi:id="ExecutionSpecification"
    public interface ExecutionSpecification : InteractionFragment
        {
        #region P:Finish:OccurrenceSpecification
        /// <summary>
        /// References the <see cref="OccurrenceSpecification"/> that designates the <see cref="Finish"/> of the <see cref="Action"/> or <see cref="Behavior"/>.
        /// </summary>
        /// xmi:id="ExecutionSpecification-finish"
        /// xmi:association="A_finish_executionSpecification"
        OccurrenceSpecification Finish { get; }
        #endregion
        #region P:Start:OccurrenceSpecification
        /// <summary>
        /// References the <see cref="OccurrenceSpecification"/> that designates the <see cref="Start"/> of the <see cref="Action"/> or <see cref="Behavior"/>.
        /// </summary>
        /// xmi:id="ExecutionSpecification-start"
        /// xmi:association="A_start_executionSpecification"
        OccurrenceSpecification Start { get; }
        #endregion
        }
    }

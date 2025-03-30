using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="InteractionOperand"/> is contained in a <see cref="CombinedFragment"/>. An <see cref="InteractionOperand"/> represents one operand of the expression given by the enclosing <see cref="CombinedFragment"/>.
    /// </summary>
    /// <rule language="">
    ///   The guard must contain only references to values local to the <see cref="Lifeline"/> on which it resides, or values global to the whole <see cref="Interaction"/>.
    ///   xmi:id="InteractionOperand-guard_contain_references"
    /// </rule>
    /// <rule language="">
    ///   The guard must be placed directly prior to (above) the <see cref="OccurrenceSpecification"/> that will become the first <see cref="OccurrenceSpecification"/> within this <see cref="InteractionOperand"/>.
    ///   xmi:id="InteractionOperand-guard_directly_prior"
    /// </rule>
    /// xmi:id="InteractionOperand"
    public interface InteractionOperand : InteractionFragment,Namespace
        {
        #region P:Fragment:InteractionFragment[]
        /// <summary>
        /// The fragments of the operand.
        /// </summary>
        /// xmi:id="InteractionOperand-fragment"
        /// xmi:aggregation="composite"
        InteractionFragment[] Fragment { get; }
        #endregion
        #region P:Guard:InteractionConstraint
        /// <summary>
        /// <see cref="Constraint"/> of the operand.
        /// </summary>
        /// xmi:id="InteractionOperand-guard"
        /// xmi:aggregation="composite"
        InteractionConstraint Guard { get; }
        #endregion
        }
    }

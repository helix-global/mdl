using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

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
        #region P:Fragment:IList<InteractionFragment>
        /// <summary>
        /// The fragments of the operand.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="InteractionOperand-fragment"
        /// xmi:aggregation="composite"
        /// xmi:association="A_fragment_enclosingOperand"
        [Ordered]
        IList<InteractionFragment> Fragment { get; }
        #endregion
        #region P:Guard:InteractionConstraint
        /// <summary>
        /// <see cref="Constraint"/> of the operand.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="InteractionOperand-guard"
        /// xmi:aggregation="composite"
        /// xmi:association="A_guard_interactionOperand"
        [Multiplicity("0..1")]
        InteractionConstraint Guard { get;set; }
        #endregion
        }
    }

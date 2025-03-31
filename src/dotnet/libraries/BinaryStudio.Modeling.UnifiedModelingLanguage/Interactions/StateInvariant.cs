using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="StateInvariant"/> is a runtime constraint on the participants of the <see cref="Interaction"/>. It may be used to specify a variety of different kinds of Constraints, such as values of Attributes or Variables, internal or external States, and so on. A <see cref="StateInvariant"/> is an <see cref="InteractionFragment"/> and it is placed on a <see cref="Lifeline"/>.
    /// </summary>
    /// xmi:id="StateInvariant"
    public interface StateInvariant : InteractionFragment
        {
        #region P:Covered:Lifeline
        /// <summary>
        /// References the <see cref="Lifeline"/> on which the <see cref="StateInvariant"/> appears.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.InteractionFragment.Covered"/>"
        /// </summary>
        /// xmi:id="StateInvariant-covered"
        /// xmi:association="A_covered_stateInvariant"
        Lifeline Covered { get; }
        #endregion
        #region P:Invariant:Constraint
        /// <summary>
        /// A <see cref="Constraint"/> that should hold at runtime for this <see cref="StateInvariant"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="StateInvariant-invariant"
        /// xmi:aggregation="composite"
        /// xmi:association="A_invariant_stateInvariant"
        Constraint Invariant { get; }
        #endregion
        }
    }

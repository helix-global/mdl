using System;

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
        /// </summary>
        /// xmi:id="StateInvariant-covered"
        /// xmi:redefines="InteractionFragment-covered{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.InteractionFragment.Covered"/>}"
        Lifeline Covered { get; }
        #endregion
        #region P:Invariant:Constraint
        /// <summary>
        /// A <see cref="Constraint"/> that should hold at runtime for this <see cref="StateInvariant"/>.
        /// </summary>
        /// xmi:id="StateInvariant-invariant"
        /// xmi:aggregation="composite"
        Constraint Invariant { get; }
        #endregion
        }
    }

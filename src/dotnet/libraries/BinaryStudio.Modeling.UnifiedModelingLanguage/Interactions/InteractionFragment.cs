using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="InteractionFragment"/> is an abstract notion of the most general interaction unit. An <see cref="InteractionFragment"/> is a piece of an <see cref="Interaction"/>. Each <see cref="InteractionFragment"/> is conceptually like an <see cref="Interaction"/> by itself.
    /// </summary>
    /// xmi:id="InteractionFragment"
    public interface InteractionFragment : NamedElement
        {
        #region P:Covered:Lifeline[]
        /// <summary>
        /// References the Lifelines that the <see cref="InteractionFragment"/> involves.
        /// </summary>
        /// xmi:id="InteractionFragment-covered"
        Lifeline[] Covered { get; }
        #endregion
        #region P:EnclosingInteraction:Interaction
        /// <summary>
        /// The <see cref="Interaction"/> enclosing this <see cref="InteractionFragment"/>.
        /// </summary>
        /// xmi:id="InteractionFragment-enclosingInteraction"
        Interaction EnclosingInteraction { get; }
        #endregion
        #region P:EnclosingOperand:InteractionOperand
        /// <summary>
        /// The operand enclosing this <see cref="InteractionFragment"/> (they may nest recursively).
        /// </summary>
        /// xmi:id="InteractionFragment-enclosingOperand"
        InteractionOperand EnclosingOperand { get; }
        #endregion
        #region P:GeneralOrdering:GeneralOrdering[]
        /// <summary>
        /// The general ordering relationships contained in this fragment.
        /// </summary>
        /// xmi:id="InteractionFragment-generalOrdering"
        /// xmi:aggregation="composite"
        GeneralOrdering[] GeneralOrdering { get; }
        #endregion
        }
    }

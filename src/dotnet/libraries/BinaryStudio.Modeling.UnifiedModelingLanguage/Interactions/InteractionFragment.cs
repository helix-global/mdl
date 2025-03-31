using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

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
        /// xmi:association="A_covered_coveredBy"
        Lifeline[] Covered { get; }
        #endregion
        #region P:EnclosingInteraction:Interaction
        /// <summary>
        /// The <see cref="Interaction"/> enclosing this <see cref="InteractionFragment"/>.
        /// </summary>
        /// xmi:id="InteractionFragment-enclosingInteraction"
        /// xmi:association="A_fragment_enclosingInteraction"
        /// xmi:subsets="NamedElement-namespace"
        [Multiplicity("0..1")]
        Interaction EnclosingInteraction { get; }
        #endregion
        #region P:EnclosingOperand:InteractionOperand
        /// <summary>
        /// The operand enclosing this <see cref="InteractionFragment"/> (they may nest recursively).
        /// </summary>
        /// xmi:id="InteractionFragment-enclosingOperand"
        /// xmi:association="A_fragment_enclosingOperand"
        /// xmi:subsets="NamedElement-namespace"
        [Multiplicity("0..1")]
        InteractionOperand EnclosingOperand { get; }
        #endregion
        #region P:GeneralOrdering:GeneralOrdering[]
        /// <summary>
        /// The general ordering relationships contained in this fragment.
        /// </summary>
        /// xmi:id="InteractionFragment-generalOrdering"
        /// xmi:aggregation="composite"
        /// xmi:association="A_generalOrdering_interactionFragment"
        /// xmi:subsets="Element-ownedElement"
        GeneralOrdering[] GeneralOrdering { get; }
        #endregion
        }
    }

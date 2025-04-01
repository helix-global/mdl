using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="InteractionFragment"/> is an abstract notion of the most general interaction unit. An <see cref="InteractionFragment"/> is a piece of an <see cref="Interaction"/>. Each <see cref="InteractionFragment"/> is conceptually like an <see cref="Interaction"/> by itself.
    /// </summary>
    /// xmi:id="InteractionFragment"
    public interface InteractionFragment : NamedElement
        {
        #region P:Covered:IList<Lifeline>
        /// <summary>
        /// References the Lifelines that the <see cref="InteractionFragment"/> involves.
        /// </summary>
        /// xmi:id="InteractionFragment-covered"
        /// xmi:association="A_covered_coveredBy"
        IList<Lifeline> Covered { get; }
        #endregion
        #region P:EnclosingInteraction:Interaction
        /// <summary>
        /// The <see cref="Interaction"/> enclosing this <see cref="InteractionFragment"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="InteractionFragment-enclosingInteraction"
        /// xmi:association="A_fragment_enclosingInteraction"
        [Multiplicity("0..1")]
        Interaction EnclosingInteraction { get;set; }
        #endregion
        #region P:EnclosingOperand:InteractionOperand
        /// <summary>
        /// The operand enclosing this <see cref="InteractionFragment"/> (they may nest recursively).
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="InteractionFragment-enclosingOperand"
        /// xmi:association="A_fragment_enclosingOperand"
        [Multiplicity("0..1")]
        InteractionOperand EnclosingOperand { get;set; }
        #endregion
        #region P:GeneralOrdering:IList<GeneralOrdering>
        /// <summary>
        /// The general ordering relationships contained in this fragment.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="InteractionFragment-generalOrdering"
        /// xmi:aggregation="composite"
        /// xmi:association="A_generalOrdering_interactionFragment"
        IList<GeneralOrdering> GeneralOrdering { get; }
        #endregion
        }
    }

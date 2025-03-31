using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="DirectedRelationship"/> represents a relationship between a collection of <see cref="Source"/> model Elements and a collection of <see cref="Target"/> model Elements.
    /// </summary>
    /// xmi:id="DirectedRelationship"
    public interface DirectedRelationship : Relationship
        {
        #region P:Source:Element[]
        /// <summary>
        /// Specifies the <see cref="Source"/> <see cref="Element"/>(s) of the <see cref="DirectedRelationship"/>.
        /// </summary>
        /// xmi:id="DirectedRelationship-source"
        /// xmi:association="A_source_directedRelationship"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        /// xmi:subsets="Relationship-relatedElement"
        [Multiplicity("1..*")][Union]
        Element[] Source { get; }
        #endregion
        #region P:Target:Element[]
        /// <summary>
        /// Specifies the <see cref="Target"/> <see cref="Element"/>(s) of the <see cref="DirectedRelationship"/>.
        /// </summary>
        /// xmi:id="DirectedRelationship-target"
        /// xmi:association="A_target_directedRelationship"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        /// xmi:subsets="Relationship-relatedElement"
        [Multiplicity("1..*")][Union]
        Element[] Target { get; }
        #endregion
        }
    }

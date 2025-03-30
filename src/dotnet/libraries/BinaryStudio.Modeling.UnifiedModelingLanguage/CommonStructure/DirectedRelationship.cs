using System;

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
        Element[] Source { get; }
        #endregion
        #region P:Target:Element[]
        /// <summary>
        /// Specifies the <see cref="Target"/> <see cref="Element"/>(s) of the <see cref="DirectedRelationship"/>.
        /// </summary>
        /// xmi:id="DirectedRelationship-target"
        Element[] Target { get; }
        #endregion
        }
    }

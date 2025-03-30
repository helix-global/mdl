using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="Relationship"/> is an abstract concept that specifies some kind of relationship between Elements.
    /// </summary>
    /// xmi:id="Relationship"
    public interface Relationship : Element
        {
        #region P:RelatedElement:Element[]
        /// <summary>
        /// Specifies the elements related by the <see cref="Relationship"/>.
        /// </summary>
        /// xmi:id="Relationship-relatedElement"
        Element[] RelatedElement { get; }
        #endregion
        }
    }

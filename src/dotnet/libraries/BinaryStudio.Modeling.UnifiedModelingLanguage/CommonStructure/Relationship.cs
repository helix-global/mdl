using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="Relationship"/> is an abstract concept that specifies some kind of relationship between Elements.
    /// </summary>
    /// xmi:id="Relationship"
    public interface Relationship : Element
        {
        #region P:RelatedElement:IList<Element>
        /// <summary>
        /// Specifies the elements related by the <see cref="Relationship"/>.
        /// </summary>
        /// xmi:id="Relationship-relatedElement"
        /// xmi:association="A_relatedElement_relationship"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Multiplicity("1..*")][Union]
        IList<Element> RelatedElement { get; }
        #endregion
        }
    }

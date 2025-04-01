using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="TypedElement"/> is a <see cref="NamedElement"/> that may have a <see cref="Type"/> specified for it.
    /// </summary>
    /// xmi:id="TypedElement"
    public interface TypedElement : NamedElement
        {
        #region P:Type:Type
        /// <summary>
        /// The <see cref="Type"/> of the <see cref="TypedElement"/>.
        /// </summary>
        /// xmi:id="TypedElement-type"
        /// xmi:association="A_type_typedElement"
        [Multiplicity("0..1")]
        Type Type { get;set; }
        #endregion
        }
    }

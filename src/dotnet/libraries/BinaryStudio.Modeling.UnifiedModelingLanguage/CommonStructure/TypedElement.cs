using System;

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
        Type Type { get; }
        #endregion
        }
    }

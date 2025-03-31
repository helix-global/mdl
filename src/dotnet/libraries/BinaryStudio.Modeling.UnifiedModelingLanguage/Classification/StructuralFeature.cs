using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="StructuralFeature"/> is a typed feature of a <see cref="Classifier"/> that specifies the structure of instances of the <see cref="Classifier"/>.
    /// </summary>
    /// xmi:id="StructuralFeature"
    public interface StructuralFeature : MultiplicityElement,TypedElement,Feature
        {
        #region P:IsReadOnly:Boolean
        /// <summary>
        /// If <see cref="IsReadOnly"/> is true, the <see cref="StructuralFeature"/> may not be written to after initialization.
        /// </summary>
        /// xmi:id="StructuralFeature-isReadOnly"
        Boolean IsReadOnly { get; }
        #endregion
        }
    }

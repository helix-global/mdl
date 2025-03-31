using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="PackageableElement"/> is a <see cref="NamedElement"/> that may be owned directly by a <see cref="Package"/>. A <see cref="PackageableElement"/> is also able to serve as the parameteredElement of a <see cref="TemplateParameter"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="PackageableElement"/> owned by a <see cref="Namespace"/> must have a visibility.
    ///   <![CDATA[
    ///     visibility = null implies namespace = null
    ///   ]]>
    ///   xmi:id="PackageableElement-namespace_needs_visibility"
    /// </rule>
    /// xmi:id="PackageableElement"
    public interface PackageableElement : ParameterableElement,NamedElement
        {
        #region P:Visibility:VisibilityKind
        /// <summary>
        /// A <see cref="PackageableElement"/> must have a <see cref="Visibility"/> specified if it is owned by a <see cref="Namespace"/>. The default <see cref="Visibility"/> is public.
        /// </summary>
        /// xmi:id="PackageableElement-visibility"
        /// xmi:redefines="NamedElement-visibility{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Visibility"/>}"
        [Multiplicity("0..1")]
        VisibilityKind Visibility { get; }
        #endregion
        }
    }

using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ElementImport"/> identifies a <see cref="NamedElement"/> in a <see cref="Namespace"/> other than the one that owns that <see cref="NamedElement"/> and allows the <see cref="NamedElement"/> to be referenced using an unqualified name in the <see cref="Namespace"/> owning the <see cref="ElementImport"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   An importedElement has either public visibility or no visibility at all.
    ///   <![CDATA[
    ///     importedElement.visibility <> null implies importedElement.visibility = VisibilityKind::public
    ///   ]]>
    ///   xmi:id="ElementImport-imported_element_is_public"
    /// </rule>
    /// <rule language="OCL">
    ///   The visibility of an <see cref="ElementImport"/> is either public or private.
    ///   <![CDATA[
    ///     visibility = VisibilityKind::public or visibility = VisibilityKind::private
    ///   ]]>
    ///   xmi:id="ElementImport-visibility_public_or_private"
    /// </rule>
    /// xmi:id="ElementImport"
    public interface ElementImport : DirectedRelationship
        {
        #region P:Alias:String
        /// <summary>
        /// Specifies the name that should be added to the importing <see cref="Namespace"/> in lieu of the name of the imported PackagableElement. The <see cref="Alias"/> must not clash with any other member in the importing <see cref="Namespace"/>. By default, no <see cref="Alias"/> is used.
        /// </summary>
        /// xmi:id="ElementImport-alias"
        String Alias { get; }
        #endregion
        #region P:ImportedElement:PackageableElement
        /// <summary>
        /// Specifies the <see cref="PackageableElement"/> whose name is to be added to a <see cref="Namespace"/>.
        /// </summary>
        /// xmi:id="ElementImport-importedElement"
        PackageableElement ImportedElement { get; }
        #endregion
        #region P:ImportingNamespace:Namespace
        /// <summary>
        /// Specifies the <see cref="Namespace"/> that imports a <see cref="PackageableElement"/> from another <see cref="Namespace"/>.
        /// </summary>
        /// xmi:id="ElementImport-importingNamespace"
        Namespace ImportingNamespace { get; }
        #endregion
        #region P:Visibility:VisibilityKind
        /// <summary>
        /// Specifies the <see cref="Visibility"/> of the imported <see cref="PackageableElement"/> within the <see cref="ImportingNamespace"/>, i.e., whether the  <see cref="ImportedElement"/> will in turn be visible to other Namespaces. If the <see cref="ElementImport"/> is public, the <see cref="ImportedElement"/> will be visible outside the <see cref="ImportingNamespace"/> while, if the <see cref="ElementImport"/> is private, it will not.
        /// </summary>
        /// xmi:id="ElementImport-visibility"
        VisibilityKind Visibility { get; }
        #endregion

        #region M:getName:String
        /// <summary>
        /// The query <see cref="getName"/> returns the name under which the imported <see cref="PackageableElement"/> will be known in the importing namespace.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if alias->notEmpty() then
        ///       alias
        ///     else
        ///       importedElement.name
        ///     endif)
        ///   ]]>
        ///   xmi:id="ElementImport-getName-spec"
        /// </rule>
        /// xmi:id="ElementImport-getName"
        /// xmi:is-query="true"
        String getName();
        #endregion
        }
    }

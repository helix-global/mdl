using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="PackageImport"/> is a <see cref="Relationship"/> that imports all the non-private members of a <see cref="Package"/> into the <see cref="Namespace"/> owning the <see cref="PackageImport"/>, so that those Elements may be referred to by their unqualified names in the <see cref="ImportingNamespace"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The visibility of a <see cref="PackageImport"/> is either public or private.
    ///   <![CDATA[
    ///     visibility = VisibilityKind::public or visibility = VisibilityKind::private
    ///   ]]>
    ///   xmi:id="PackageImport-public_or_private"
    /// </rule>
    /// xmi:id="PackageImport"
    public interface PackageImport : DirectedRelationship
        {
        #region P:ImportedPackage:Package
        /// <summary>
        /// Specifies the <see cref="Package"/> whose members are imported into a <see cref="Namespace"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.DirectedRelationship.Target"/>"
        /// </summary>
        /// xmi:id="PackageImport-importedPackage"
        /// xmi:association="A_importedPackage_packageImport"
        Package ImportedPackage { get;set; }
        #endregion
        #region P:ImportingNamespace:Namespace
        /// <summary>
        /// Specifies the <see cref="Namespace"/> that imports the members from a <see cref="Package"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.DirectedRelationship.Source"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.Owner"/>"
        /// </summary>
        /// xmi:id="PackageImport-importingNamespace"
        /// xmi:association="A_packageImport_importingNamespace"
        Namespace ImportingNamespace { get;set; }
        #endregion
        #region P:Visibility:VisibilityKind
        /// <summary>
        /// Specifies the <see cref="Visibility"/> of the imported PackageableElements within the <see cref="ImportingNamespace"/>, i.e., whether imported Elements will in turn be visible to other Namespaces. If the <see cref="PackageImport"/> is public, the imported Elements will be visible outside the <see cref="ImportingNamespace"/>, while, if the <see cref="PackageImport"/> is private, they will not.
        /// </summary>
        /// xmi:id="PackageImport-visibility"
        VisibilityKind Visibility { get;set; }
        #endregion
        }
    }

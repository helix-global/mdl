using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A package can have one or more profile applications to indicate which profiles have been applied. Because a profile is a package, it is possible to apply a profile not only to packages, but also to profiles.
    /// <see cref="Package"/> specializes <see cref="TemplateableElement"/> and <see cref="PackageableElement"/> specializes <see cref="ParameterableElement"/> to specify that a package can be used as a template and a <see cref="PackageableElement"/> as a template parameter.
    /// A package is used to group elements, and provides a <see cref="Namespace"/> for the grouped elements.
    /// </summary>
    /// <rule language="OCL">
    ///   If an element that is owned by a package has visibility, it is public or private.
    ///   <![CDATA[
    ///     packagedElement->forAll(e | e.visibility<> null implies e.visibility = VisibilityKind::public or e.visibility = VisibilityKind::private)
    ///   ]]>
    ///   xmi:id="Package-elements_public_or_private"
    /// </rule>
    /// xmi:id="Package"
    public interface Package : TemplateableElement,Namespace,PackageableElement
        {
        #region P:NestedPackage:IList<Package>
        /// <summary>
        /// References the packaged elements that are Packages.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Package.PackagedElement"/>"
        /// </summary>
        /// xmi:id="Package-nestedPackage"
        /// xmi:aggregation="composite"
        /// xmi:association="A_nestedPackage_nestingPackage"
        /// xmi:is-derived="true"
        IList<Package> NestedPackage { get; }
        #endregion
        #region P:NestingPackage:Package
        /// <summary>
        /// References the <see cref="Package"/> that owns this <see cref="Package"/>.
        /// Subsets:
        /// </summary>
        /// xmi:id="Package-nestingPackage"
        /// xmi:association="A_nestedPackage_nestingPackage"
        /// xmi:subsets="A_packagedElement_owningPackage-owningPackage"
        [Multiplicity("0..1")]
        Package NestingPackage { get;set; }
        #endregion
        #region P:OwnedStereotype:IList<Stereotype>
        /// <summary>
        /// References the Stereotypes that are owned by the <see cref="Package"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Package.PackagedElement"/>"
        /// </summary>
        /// xmi:id="Package-ownedStereotype"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedStereotype_owningPackage"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        IList<Stereotype> OwnedStereotype { get; }
        #endregion
        #region P:OwnedType:IList<Type>
        /// <summary>
        /// References the packaged elements that are Types.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Package.PackagedElement"/>"
        /// </summary>
        /// xmi:id="Package-ownedType"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedType_package"
        /// xmi:is-derived="true"
        IList<Type> OwnedType { get; }
        #endregion
        #region P:PackagedElement:IList<PackageableElement>
        /// <summary>
        /// Specifies the packageable elements that are owned by this <see cref="Package"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Package-packagedElement"
        /// xmi:aggregation="composite"
        /// xmi:association="A_packagedElement_owningPackage"
        IList<PackageableElement> PackagedElement { get; }
        #endregion
        #region P:PackageMerge:IList<PackageMerge>
        /// <summary>
        /// References the PackageMerges that are owned by this <see cref="Package"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Package-packageMerge"
        /// xmi:aggregation="composite"
        /// xmi:association="A_packageMerge_receivingPackage"
        /// xmi:subsets="A_source_directedRelationship-directedRelationship"
        IList<PackageMerge> PackageMerge { get; }
        #endregion
        #region P:ProfileApplication:IList<ProfileApplication>
        /// <summary>
        /// References the ProfileApplications that indicate which profiles have been applied to the <see cref="Package"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Package-profileApplication"
        /// xmi:aggregation="composite"
        /// xmi:association="A_profileApplication_applyingPackage"
        /// xmi:subsets="A_source_directedRelationship-directedRelationship"
        IList<ProfileApplication> ProfileApplication { get; }
        #endregion
        #region P:URI:String
        /// <summary>
        /// Provides an identifier for the package that can be used for many purposes. A <see cref="URI"/> is the universally unique identification of the package following the IETF <see cref="URI"/> specification, RFC 2396 http://www.ietf.org/rfc/rfc2396.txt and it must comply with those syntax rules.
        /// </summary>
        /// xmi:id="Package-URI"
        [Multiplicity("0..1")]
        String URI { get;set; }
        #endregion

        #region M:allApplicableStereotypes:Stereotype[]
        /// <summary>
        /// The query <see cref="allApplicableStereotypes"/> returns all the directly or indirectly owned stereotypes, including stereotypes contained in sub-profiles.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (let ownedPackages : Bag(Package) = ownedMember->select(oclIsKindOf(Package))->collect(oclAsType(Package)) in
        ///      ownedStereotype->union(ownedPackages.allApplicableStereotypes())->flatten()->asSet()
        ///     )
        ///   ]]>
        ///   xmi:id="Package-allApplicableStereotypes-spec"
        /// </rule>
        /// xmi:id="Package-allApplicableStereotypes"
        /// xmi:is-query="true"
        Stereotype[] allApplicableStereotypes();
        #endregion
        #region M:containingProfile:Profile
        /// <summary>
        /// The query <see cref="containingProfile"/> returns the closest profile directly or indirectly containing this package (or this package itself, if it is a profile).
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if self.oclIsKindOf(Profile) then 
        ///     	self.oclAsType(Profile)
        ///     else
        ///     	self.namespace.oclAsType(Package).containingProfile()
        ///     endif)
        ///   ]]>
        ///   xmi:id="Package-containingProfile-spec"
        /// </rule>
        /// xmi:id="Package-containingProfile"
        /// xmi:is-query="true"
        [return: Multiplicity("0..1")]
        Profile containingProfile();
        #endregion
        #region M:makesVisible(NamedElement):Boolean
        /// <summary>
        /// The query <see cref="makesVisible"/> defines whether a <see cref="Package"/> makes an element visible outside itself. Elements with no <see cref="Visibility"/> and elements with public <see cref="Visibility"/> are made visible.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     member->includes(el)
        ///   ]]>
        ///   xmi:id="Package-makesVisible-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ownedMember->includes(el) or
        ///     (elementImport->select(ei|ei.importedElement = VisibilityKind::public)->collect(importedElement.oclAsType(NamedElement))->includes(el)) or
        ///     (packageImport->select(visibility = VisibilityKind::public)->collect(importedPackage.member->includes(el))->notEmpty()))
        ///   ]]>
        ///   xmi:id="Package-makesVisible-spec"
        /// </rule>
        /// xmi:id="Package-makesVisible"
        /// xmi:is-query="true"
        Boolean makesVisible(NamedElement el);
        #endregion
        #region M:mustBeOwned:Boolean
        /// <summary>
        /// The query <see cref="mustBeOwned"/> indicates whether elements of this type must have an <see cref="Owner"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.mustBeOwned"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (false)
        ///   ]]>
        ///   xmi:id="Package-mustBeOwned-spec"
        /// </rule>
        /// xmi:id="Package-mustBeOwned"
        /// xmi:is-query="true"
        Boolean mustBeOwned();
        #endregion
        #region M:nestedPackage:Package[]
        /// <summary>
        /// Derivation for <see cref="Package"/>::/<see cref="NestedPackage"/> 
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (packagedElement->select(oclIsKindOf(Package))->collect(oclAsType(Package))->asSet())
        ///   ]]>
        ///   xmi:id="Package-nestedPackage.1-spec"
        /// </rule>
        /// xmi:id="Package-nestedPackage.1"
        /// xmi:is-query="true"
        Package[] nestedPackage();
        #endregion
        #region M:ownedStereotype:Stereotype[]
        /// <summary>
        /// Derivation for <see cref="Package"/>::/<see cref="OwnedStereotype"/> 
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (packagedElement->select(oclIsKindOf(Stereotype))->collect(oclAsType(Stereotype))->asSet())
        ///   ]]>
        ///   xmi:id="Package-ownedStereotype.1-spec"
        /// </rule>
        /// xmi:id="Package-ownedStereotype.1"
        /// xmi:is-query="true"
        Stereotype[] ownedStereotype();
        #endregion
        #region M:ownedType:Type[]
        /// <summary>
        /// Derivation for <see cref="Package"/>::/<see cref="OwnedType"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (packagedElement->select(oclIsKindOf(Type))->collect(oclAsType(Type))->asSet())
        ///   ]]>
        ///   xmi:id="Package-ownedType.1-spec"
        /// </rule>
        /// xmi:id="Package-ownedType.1"
        /// xmi:is-query="true"
        Type[] ownedType();
        #endregion
        #region M:visibleMembers:PackageableElement[]
        /// <summary>
        /// The query <see cref="visibleMembers"/> defines which members of a <see cref="Package"/> can be accessed outside it.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (member->select( m | m.oclIsKindOf(PackageableElement) and self.makesVisible(m))->collect(oclAsType(PackageableElement))->asSet())
        ///   ]]>
        ///   xmi:id="Package-visibleMembers-spec"
        /// </rule>
        /// xmi:id="Package-visibleMembers"
        /// xmi:is-query="true"
        PackageableElement[] visibleMembers();
        #endregion
        }
    }

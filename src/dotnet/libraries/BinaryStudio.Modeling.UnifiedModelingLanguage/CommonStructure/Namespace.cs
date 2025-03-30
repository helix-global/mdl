using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Namespace"/> is an <see cref="Element"/> in a model that owns and/or imports a set of NamedElements that can be identified by <see cref="Name"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   All the members of a <see cref="Namespace"/> are distinguishable within it.
    ///   <![CDATA[
    ///     membersAreDistinguishable()
    ///   ]]>
    ///   xmi:id="Namespace-members_distinguishable"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Namespace"/> cannot have a <see cref="PackageImport"/> to itself.
    ///   <![CDATA[
    ///     packageImport.importedPackage.oclAsType(Namespace)->excludes(self)
    ///   ]]>
    ///   xmi:id="Namespace-cannot_import_self"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Namespace"/> cannot have an <see cref="ElementImport"/> to one of its ownedMembers.
    ///   <![CDATA[
    ///     elementImport.importedElement.oclAsType(Element)->excludesAll(ownedMember)
    ///   ]]>
    ///   xmi:id="Namespace-cannot_import_ownedMembers"
    /// </rule>
    /// xmi:id="Namespace"
    public interface Namespace : NamedElement
        {
        #region P:ElementImport:ElementImport[]
        /// <summary>
        /// References the ElementImports owned by the <see cref="Namespace"/>.
        /// </summary>
        /// xmi:id="Namespace-elementImport"
        /// xmi:aggregation="composite"
        ElementImport[] ElementImport { get; }
        #endregion
        #region P:ImportedMember:PackageableElement[]
        /// <summary>
        /// References the PackageableElements that are members of this <see cref="Namespace"/> as a result of either PackageImports or ElementImports.
        /// </summary>
        /// xmi:id="Namespace-importedMember"
        PackageableElement[] ImportedMember { get; }
        #endregion
        #region P:Member:NamedElement[]
        /// <summary>
        /// A collection of NamedElements identifiable within the <see cref="Namespace"/>, either by being owned or by being introduced by importing or inheritance.
        /// </summary>
        /// xmi:id="Namespace-member"
        NamedElement[] Member { get; }
        #endregion
        #region P:OwnedMember:NamedElement[]
        /// <summary>
        /// A collection of NamedElements owned by the <see cref="Namespace"/>.
        /// </summary>
        /// xmi:id="Namespace-ownedMember"
        /// xmi:aggregation="composite"
        NamedElement[] OwnedMember { get; }
        #endregion
        #region P:OwnedRule:Constraint[]
        /// <summary>
        /// Specifies a set of Constraints owned by this <see cref="Namespace"/>.
        /// </summary>
        /// xmi:id="Namespace-ownedRule"
        /// xmi:aggregation="composite"
        Constraint[] OwnedRule { get; }
        #endregion
        #region P:PackageImport:PackageImport[]
        /// <summary>
        /// References the PackageImports owned by the <see cref="Namespace"/>.
        /// </summary>
        /// xmi:id="Namespace-packageImport"
        /// xmi:aggregation="composite"
        PackageImport[] PackageImport { get; }
        #endregion

        #region M:excludeCollisions(PackageableElement[]):PackageableElement[]
        /// <summary>
        /// The query <see cref="excludeCollisions"/> excludes from a set of PackageableElements any that would not be distinguishable from each other in this <see cref="Namespace"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (imps->reject(imp1  | imps->exists(imp2 | not imp1.isDistinguishableFrom(imp2, self))))
        ///   ]]>
        ///   xmi:id="Namespace-excludeCollisions-spec"
        /// </rule>
        /// xmi:id="Namespace-excludeCollisions"
        /// xmi:is-query="true"
        PackageableElement[] excludeCollisions(PackageableElement[] imps);
        #endregion
        #region M:getNamesOfMember(NamedElement):String[]
        /// <summary>
        /// The query <see cref="getNamesOfMember"/> gives a set of all of the names that a <see cref="Member"/> would have in a <see cref="Namespace"/>, taking importing into account. In general a <see cref="Member"/> can have multiple names in a <see cref="Namespace"/> if it is imported more than once with different aliases.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if self.ownedMember ->includes(element)
        ///     then Set{element.name}
        ///     else let elementImports : Set(ElementImport) = self.elementImport->select(ei | ei.importedElement = element) in
        ///       if elementImports->notEmpty()
        ///       then
        ///          elementImports->collect(el | el.getName())->asSet()
        ///       else 
        ///          self.packageImport->select(pi | pi.importedPackage.visibleMembers().oclAsType(NamedElement)->includes(element))-> collect(pi | pi.importedPackage.getNamesOfMember(element))->asSet()
        ///       endif
        ///     endif)
        ///   ]]>
        ///   xmi:id="Namespace-getNamesOfMember-spec"
        /// </rule>
        /// xmi:id="Namespace-getNamesOfMember"
        /// xmi:is-query="true"
        String[] getNamesOfMember(NamedElement element);
        #endregion
        #region M:importMembers(PackageableElement[]):PackageableElement[]
        /// <summary>
        /// The query <see cref="importMembers"/> defines which of a set of PackageableElements are actually imported into the <see cref="Namespace"/>. This excludes hidden ones, i.e., those which have names that conflict with names of ownedMembers, and it also excludes PackageableElements that would have the indistinguishable names when imported.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.excludeCollisions(imps)->select(imp | self.ownedMember->forAll(mem | imp.isDistinguishableFrom(mem, self))))
        ///   ]]>
        ///   xmi:id="Namespace-importMembers-spec"
        /// </rule>
        /// xmi:id="Namespace-importMembers"
        /// xmi:is-query="true"
        PackageableElement[] importMembers(PackageableElement[] imps);
        #endregion
        #region M:importedMember:PackageableElement[]
        /// <summary>
        /// The <see cref="ImportedMember"/> property is derived as the PackageableElements that are members of this <see cref="Namespace"/> as a result of either PackageImports or ElementImports.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.importMembers(elementImport.importedElement->asSet()->union(packageImport.importedPackage->collect(p | p.visibleMembers()))->asSet()))
        ///   ]]>
        ///   xmi:id="Namespace-importedMember.1-spec"
        /// </rule>
        /// xmi:id="Namespace-importedMember.1"
        /// xmi:is-query="true"
        PackageableElement[] importedMember();
        #endregion
        #region M:membersAreDistinguishable:Boolean
        /// <summary>
        /// The Boolean query <see cref="membersAreDistinguishable"/> determines whether all of the <see cref="Namespace"/>'s members are distinguishable within it.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (member->forAll( memb |
        ///        member->excluding(memb)->forAll(other |
        ///            memb.isDistinguishableFrom(other, self))))
        ///   ]]>
        ///   xmi:id="Namespace-membersAreDistinguishable-spec"
        /// </rule>
        /// xmi:id="Namespace-membersAreDistinguishable"
        /// xmi:is-query="true"
        Boolean membersAreDistinguishable();
        #endregion
        }
    }

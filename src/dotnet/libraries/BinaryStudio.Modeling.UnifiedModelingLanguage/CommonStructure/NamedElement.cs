using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="NamedElement"/> is an <see cref="Element"/> in a model that may have a <see cref="Name"/>. The <see cref="Name"/> may be given directly and/or via the use of a <see cref="StringExpression"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   If a <see cref="NamedElement"/> is owned by something other than a <see cref="Namespace"/>, it does not have a visibility. One that is not owned by anything (and hence must be a <see cref="Package"/>, as this is the only kind of <see cref="NamedElement"/> that overrides mustBeOwned()) may have a visibility.
    ///   <![CDATA[
    ///     (namespace = null and owner <> null) implies visibility = null
    ///   ]]>
    ///   xmi:id="NamedElement-visibility_needs_ownership"
    /// </rule>
    /// <rule language="OCL">
    ///   When there is a name, and all of the containing Namespaces have a name, the qualifiedName is constructed from the name of the <see cref="NamedElement"/> and the names of the containing Namespaces.
    ///   <![CDATA[
    ///     (name <> null and allNamespaces()->select(ns | ns.name = null)->isEmpty()) implies
    ///       qualifiedName = allNamespaces()->iterate( ns : Namespace; agg: String = name | ns.name.concat(self.separator()).concat(agg))
    ///   ]]>
    ///   xmi:id="NamedElement-has_qualified_name"
    /// </rule>
    /// <rule language="OCL">
    ///   If there is no name, or one of the containing Namespaces has no name, there is no qualifiedName.
    ///   <![CDATA[
    ///     name=null or allNamespaces()->select( ns | ns.name=null )->notEmpty() implies qualifiedName = null
    ///   ]]>
    ///   xmi:id="NamedElement-has_no_qualified_name"
    /// </rule>
    /// xmi:id="NamedElement"
    public interface NamedElement : Element
        {
        #region P:ClientDependency:Dependency[]
        /// <summary>
        /// Indicates the Dependencies that reference this <see cref="NamedElement"/> as a client.
        /// </summary>
        /// xmi:id="NamedElement-clientDependency"
        /// xmi:association="A_clientDependency_client"
        /// xmi:is-derived="true"
        /// xmi:subsets="A_source_directedRelationship-directedRelationship"
        Dependency[] ClientDependency { get; }
        #endregion
        #region P:Name:String
        /// <summary>
        /// The <see cref="Name"/> of the <see cref="NamedElement"/>.
        /// </summary>
        /// xmi:id="NamedElement-name"
        [Multiplicity("0..1")]
        String Name { get; }
        #endregion
        #region P:NameExpression:StringExpression
        /// <summary>
        /// The <see cref="StringExpression"/> used to define the <see cref="Name"/> of this <see cref="NamedElement"/>.
        /// </summary>
        /// xmi:id="NamedElement-nameExpression"
        /// xmi:aggregation="composite"
        /// xmi:association="A_nameExpression_namedElement"
        /// xmi:subsets="Element-ownedElement"
        [Multiplicity("0..1")]
        StringExpression NameExpression { get; }
        #endregion
        #region P:Namespace:Namespace
        /// <summary>
        /// Specifies the <see cref="Namespace"/> that owns the <see cref="NamedElement"/>.
        /// </summary>
        /// xmi:id="NamedElement-namespace"
        /// xmi:association="A_ownedMember_namespace"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        /// xmi:subsets="A_member_memberNamespace-memberNamespace"
        /// xmi:subsets="Element-owner"
        [Multiplicity("0..1")][Union]
        Namespace Namespace { get; }
        #endregion
        #region P:QualifiedName:String
        /// <summary>
        /// A <see cref="Name"/> that allows the <see cref="NamedElement"/> to be identified within a hierarchy of nested Namespaces. It is constructed from the names of the containing Namespaces starting at the root of the hierarchy and ending with the <see cref="Name"/> of the <see cref="NamedElement"/> itself.
        /// </summary>
        /// xmi:id="NamedElement-qualifiedName"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Multiplicity("0..1")]
        String QualifiedName { get; }
        #endregion
        #region P:Visibility:VisibilityKind
        /// <summary>
        /// Determines whether and how the <see cref="NamedElement"/> is visible outside its owning <see cref="Namespace"/>.
        /// </summary>
        /// xmi:id="NamedElement-visibility"
        [Multiplicity("0..1")]
        VisibilityKind Visibility { get; }
        #endregion

        #region M:allNamespaces:Namespace[]
        /// <summary>
        /// The query <see cref="allNamespaces"/> gives the sequence of Namespaces in which the <see cref="NamedElement"/> is nested, working outwards.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if owner.oclIsKindOf(TemplateParameter) and
        ///       owner.oclAsType(TemplateParameter).signature.template.oclIsKindOf(Namespace) then
        ///         let enclosingNamespace : Namespace =
        ///           owner.oclAsType(TemplateParameter).signature.template.oclAsType(Namespace) in
        ///             enclosingNamespace.allNamespaces()->prepend(enclosingNamespace)
        ///     else
        ///       if namespace->isEmpty()
        ///         then OrderedSet{}
        ///       else
        ///         namespace.allNamespaces()->prepend(namespace)
        ///       endif
        ///     endif)
        ///   ]]>
        ///   xmi:id="NamedElement-allNamespaces-spec"
        /// </rule>
        /// xmi:id="NamedElement-allNamespaces"
        /// xmi:is-query="true"
        Namespace[] allNamespaces();
        #endregion
        #region M:allOwningPackages:Package[]
        /// <summary>
        /// The query <see cref="allOwningPackages"/> returns the set of all the enclosing Namespaces of this <see cref="NamedElement"/>, working outwards, that are Packages, up to but not including the first such <see cref="Namespace"/> that is not a <see cref="Package"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if namespace.oclIsKindOf(Package)
        ///     then
        ///       let owningPackage : Package = namespace.oclAsType(Package) in
        ///         owningPackage->union(owningPackage.allOwningPackages())
        ///     else
        ///       null
        ///     endif)
        ///   ]]>
        ///   xmi:id="NamedElement-allOwningPackages-spec"
        /// </rule>
        /// xmi:id="NamedElement-allOwningPackages"
        /// xmi:is-query="true"
        Package[] allOwningPackages();
        #endregion
        #region M:clientDependency:Dependency[]
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (Dependency.allInstances()->select(d | d.client->includes(self)))
        ///   ]]>
        ///   xmi:id="NamedElement-clientDependency.1-spec"
        /// </rule>
        /// xmi:id="NamedElement-clientDependency.1"
        /// xmi:is-query="true"
        Dependency[] clientDependency();
        #endregion
        #region M:isDistinguishableFrom(NamedElement,Namespace):Boolean
        /// <summary>
        /// The query <see cref="isDistinguishableFrom"/> determines whether two NamedElements may logically co-exist within a <see cref="Namespace"/>. By default, two named elements are distinguishable if (a) they have types neither of which is a kind of the other or (b) they have different names.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = ((self.oclIsKindOf(n.oclType()) or n.oclIsKindOf(self.oclType())) implies
        ///         ns.getNamesOfMember(self)->intersection(ns.getNamesOfMember(n))->isEmpty()
        ///     )
        ///   ]]>
        ///   xmi:id="NamedElement-isDistinguishableFrom-spec"
        /// </rule>
        /// xmi:id="NamedElement-isDistinguishableFrom"
        /// xmi:is-query="true"
        Boolean isDistinguishableFrom(NamedElement n,Namespace ns);
        #endregion
        #region M:qualifiedName:String
        /// <summary>
        /// When a <see cref="NamedElement"/> has a <see cref="Name"/>, and all of its containing Namespaces have a <see cref="Name"/>, the <see cref="QualifiedName"/> is constructed from the <see cref="Name"/> of the <see cref="NamedElement"/> and the names of the containing Namespaces.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if self.name <> null and self.allNamespaces()->select( ns | ns.name=null )->isEmpty()
        ///     then 
        ///         self.allNamespaces()->iterate( ns : Namespace; agg: String = self.name | ns.name.concat(self.separator()).concat(agg))
        ///     else
        ///        null
        ///     endif)
        ///   ]]>
        ///   xmi:id="NamedElement-qualifiedName.1-spec"
        /// </rule>
        /// xmi:id="NamedElement-qualifiedName.1"
        /// xmi:is-query="true"
        String qualifiedName();
        #endregion
        #region M:separator:String
        /// <summary>
        /// The query <see cref="separator"/> gives the string that is used to separate names when constructing a <see cref="QualifiedName"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = ('::')
        ///   ]]>
        ///   xmi:id="NamedElement-separator-spec"
        /// </rule>
        /// xmi:id="NamedElement-separator"
        /// xmi:is-query="true"
        String separator();
        #endregion
        }
    }

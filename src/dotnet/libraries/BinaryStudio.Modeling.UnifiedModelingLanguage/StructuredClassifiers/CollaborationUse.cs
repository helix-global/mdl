using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="CollaborationUse"/> is used to specify the application of a pattern specified by a <see cref="Collaboration"/> to a specific situation.
    /// </summary>
    /// <rule language="OCL">
    ///   All the client elements of a roleBinding are in one <see cref="Classifier"/> and all supplier elements of a roleBinding are in one <see cref="Collaboration"/>.
    ///   <![CDATA[
    ///     roleBinding->collect(client)->forAll(ne1, ne2 |
    ///       ne1.oclIsKindOf(ConnectableElement) and ne2.oclIsKindOf(ConnectableElement) and
    ///         let ce1 : ConnectableElement = ne1.oclAsType(ConnectableElement), ce2 : ConnectableElement = ne2.oclAsType(ConnectableElement) in
    ///           ce1.structuredClassifier = ce2.structuredClassifier)
    ///     and
    ///       roleBinding->collect(supplier)->forAll(ne1, ne2 |
    ///       ne1.oclIsKindOf(ConnectableElement) and ne2.oclIsKindOf(ConnectableElement) and
    ///         let ce1 : ConnectableElement = ne1.oclAsType(ConnectableElement), ce2 : ConnectableElement = ne2.oclAsType(ConnectableElement) in
    ///           ce1.collaboration = ce2.collaboration)
    ///   ]]>
    ///   xmi:id="CollaborationUse-client_elements"
    /// </rule>
    /// <rule language="OCL">
    ///   Every collaborationRole in the <see cref="Collaboration"/> is bound within the <see cref="CollaborationUse"/>.
    ///   <![CDATA[
    ///     type.collaborationRole->forAll(role | roleBinding->exists(rb | rb.supplier->includes(role)))
    ///   ]]>
    ///   xmi:id="CollaborationUse-every_role"
    /// </rule>
    /// <rule language="OCL">
    ///   Connectors in a <see cref="Collaboration"/> typing a <see cref="CollaborationUse"/> must have corresponding Connectors between elements bound in the context <see cref="Classifier"/>, and these corresponding Connectors must have the same or more general type than the <see cref="Collaboration"/> Connectors.
    ///   <![CDATA[
    ///     type.ownedConnector->forAll(connector |
    ///       let rolesConnectedInCollab : Set(ConnectableElement) = connector.end.role->asSet(),
    ///             relevantBindings : Set(Dependency) = roleBinding->select(rb | rb.supplier->intersection(rolesConnectedInCollab)->notEmpty()),
    ///             boundRoles : Set(ConnectableElement) = relevantBindings->collect(client.oclAsType(ConnectableElement))->asSet(),
    ///             contextClassifier : StructuredClassifier = boundRoles->any(true).structuredClassifier->any(true) in
    ///               contextClassifier.ownedConnector->exists( correspondingConnector | 
    ///                   correspondingConnector.end.role->forAll( role | boundRoles->includes(role) )
    ///                   and (connector.type->notEmpty() and correspondingConnector.type->notEmpty()) implies connector.type->forAll(conformsTo(correspondingConnector.type)) )
    ///     )
    ///   ]]>
    ///   xmi:id="CollaborationUse-connectors"
    /// </rule>
    /// xmi:id="CollaborationUse"
    public interface CollaborationUse : NamedElement
        {
        #region P:RoleBinding:Dependency[]
        /// <summary>
        /// A mapping between features of the <see cref="Collaboration"/> and features of the owning <see cref="Classifier"/>. This mapping indicates which <see cref="ConnectableElement"/> of the <see cref="Classifier"/> plays which role(s) in the <see cref="Collaboration"/>. A <see cref="ConnectableElement"/> may be bound to multiple roles in the same <see cref="CollaborationUse"/> (that is, it may play multiple roles).
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="CollaborationUse-roleBinding"
        /// xmi:aggregation="composite"
        /// xmi:association="A_roleBinding_collaborationUse"
        Dependency[] RoleBinding { get; }
        #endregion
        #region P:Type:Collaboration
        /// <summary>
        /// The <see cref="Collaboration"/> which is used in this <see cref="CollaborationUse"/>. The <see cref="Collaboration"/> defines the cooperation between its roles which are mapped to ConnectableElements relating to the <see cref="Classifier"/> owning the <see cref="CollaborationUse"/>.
        /// </summary>
        /// xmi:id="CollaborationUse-type"
        /// xmi:association="A_type_collaborationUse"
        Collaboration Type { get; }
        #endregion
        }
    }

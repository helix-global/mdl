using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// StructuredClassifiers may contain an internal structure of connected elements each of which plays a <see cref="Role"/> in the overall <see cref="Behavior"/> modeled by the <see cref="StructuredClassifier"/>.
    /// </summary>
    /// xmi:id="StructuredClassifier"
    public interface StructuredClassifier : Classifier
        {
        #region P:OwnedAttribute:IList<Property>
        /// <summary>
        /// The Properties owned by the <see cref="StructuredClassifier"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Attribute"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.StructuredClassifier.Role"/>"
        /// </summary>
        /// xmi:id="StructuredClassifier-ownedAttribute"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedAttribute_structuredClassifier"
        [Ordered]
        IList<Property> OwnedAttribute { get; }
        #endregion
        #region P:OwnedConnector:IList<Connector>
        /// <summary>
        /// The connectors owned by the <see cref="StructuredClassifier"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Feature"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="StructuredClassifier-ownedConnector"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedConnector_structuredClassifier"
        /// xmi:subsets="A_redefinitionContext_redefinableElement-redefinableElement"
        IList<Connector> OwnedConnector { get; }
        #endregion
        #region P:Part:IList<Property>
        /// <summary>
        /// The Properties specifying instances that the <see cref="StructuredClassifier"/> owns by composition. This collection is derived, selecting those owned Properties where isComposite is true.
        /// </summary>
        /// xmi:id="StructuredClassifier-part"
        /// xmi:association="A_part_structuredClassifier"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        IList<Property> Part { get; }
        #endregion
        #region P:Role:IList<ConnectableElement>
        /// <summary>
        /// The roles that instances may play in this <see cref="StructuredClassifier"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.Member"/>"
        /// </summary>
        /// xmi:id="StructuredClassifier-role"
        /// xmi:association="A_role_structuredClassifier"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Union]
        IList<ConnectableElement> Role { get; }
        #endregion

        #region M:allRoles:ConnectableElement[]
        /// <summary>
        /// All features of type <see cref="ConnectableElement"/>, equivalent to all direct and inherited roles.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (allFeatures()->select(oclIsKindOf(ConnectableElement))->collect(oclAsType(ConnectableElement))->asSet())
        ///   ]]>
        ///   xmi:id="StructuredClassifier-allRoles-spec"
        /// </rule>
        /// xmi:id="StructuredClassifier-allRoles"
        /// xmi:is-query="true"
        ConnectableElement[] allRoles();
        #endregion
        #region M:part:Property[]
        /// <summary>
        /// Derivation for <see cref="StructuredClassifier"/>::/<see cref="Part"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ownedAttribute->select(isComposite))
        ///   ]]>
        ///   xmi:id="StructuredClassifier-part.1-spec"
        /// </rule>
        /// xmi:id="StructuredClassifier-part.1"
        /// xmi:is-query="true"
        Property[] part();
        #endregion
        }
    }

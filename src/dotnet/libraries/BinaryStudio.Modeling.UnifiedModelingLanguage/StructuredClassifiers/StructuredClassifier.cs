using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// StructuredClassifiers may contain an internal structure of connected elements each of which plays a <see cref="Role"/> in the overall <see cref="Behavior"/> modeled by the <see cref="StructuredClassifier"/>.
    /// </summary>
    /// xmi:id="StructuredClassifier"
    public interface StructuredClassifier : Classifier
        {
        #region P:OwnedAttribute:Property[]
        /// <summary>
        /// The Properties owned by the <see cref="StructuredClassifier"/>.
        /// </summary>
        /// xmi:id="StructuredClassifier-ownedAttribute"
        /// xmi:aggregation="composite"
        Property[] OwnedAttribute { get; }
        #endregion
        #region P:OwnedConnector:Connector[]
        /// <summary>
        /// The connectors owned by the <see cref="StructuredClassifier"/>.
        /// </summary>
        /// xmi:id="StructuredClassifier-ownedConnector"
        /// xmi:aggregation="composite"
        Connector[] OwnedConnector { get; }
        #endregion
        #region P:Part:Property[]
        /// <summary>
        /// The Properties specifying instances that the <see cref="StructuredClassifier"/> owns by composition. This collection is derived, selecting those owned Properties where isComposite is true.
        /// </summary>
        /// xmi:id="StructuredClassifier-part"
        Property[] Part { get; }
        #endregion
        #region P:Role:ConnectableElement[]
        /// <summary>
        /// The roles that instances may play in this <see cref="StructuredClassifier"/>.
        /// </summary>
        /// xmi:id="StructuredClassifier-role"
        ConnectableElement[] Role { get; }
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
        }
    }

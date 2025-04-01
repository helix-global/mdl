using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// Interfaces declare coherent services that are implemented by BehavioredClassifiers that implement the Interfaces via InterfaceRealizations.
    /// </summary>
    /// <rule language="OCL">
    ///   The visibility of all Features owned by an <see cref="Interface"/> must be public.
    ///   <![CDATA[
    ///     feature->forAll(visibility = VisibilityKind::public)
    ///   ]]>
    ///   xmi:id="Interface-visibility"
    /// </rule>
    /// xmi:id="Interface"
    public interface Interface : Classifier
        {
        #region P:NestedClassifier:IList<Classifier>
        /// <summary>
        /// References all the Classifiers that are defined (nested) within the <see cref="Interface"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Interface-nestedClassifier"
        /// xmi:aggregation="composite"
        /// xmi:association="A_nestedClassifier_interface"
        /// xmi:subsets="A_redefinitionContext_redefinableElement-redefinableElement"
        [Ordered]
        IList<Classifier> NestedClassifier { get; }
        #endregion
        #region P:OwnedAttribute:IList<Property>
        /// <summary>
        /// The attributes (i.e., the Properties) owned by the <see cref="Interface"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Attribute"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Interface-ownedAttribute"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedAttribute_interface"
        [Ordered]
        IList<Property> OwnedAttribute { get; }
        #endregion
        #region P:OwnedOperation:IList<Operation>
        /// <summary>
        /// The Operations owned by the <see cref="Interface"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Feature"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Interface-ownedOperation"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedOperation_interface"
        /// xmi:subsets="A_redefinitionContext_redefinableElement-redefinableElement"
        [Ordered]
        IList<Operation> OwnedOperation { get; }
        #endregion
        #region P:OwnedReception:IList<Reception>
        /// <summary>
        /// Receptions that objects providing this <see cref="Interface"/> are willing to accept.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Feature"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Interface-ownedReception"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedReception_interface"
        IList<Reception> OwnedReception { get; }
        #endregion
        #region P:Protocol:ProtocolStateMachine
        /// <summary>
        /// References a <see cref="ProtocolStateMachine"/> specifying the legal sequences of the invocation of the BehavioralFeatures described in the <see cref="Interface"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Interface-protocol"
        /// xmi:aggregation="composite"
        /// xmi:association="A_protocol_interface"
        [Multiplicity("0..1")]
        ProtocolStateMachine Protocol { get;set; }
        #endregion
        #region P:RedefinedInterface:IList<Interface>
        /// <summary>
        /// References all the Interfaces redefined by this <see cref="Interface"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.RedefinedClassifier"/>"
        /// </summary>
        /// xmi:id="Interface-redefinedInterface"
        /// xmi:association="A_redefinedInterface_interface"
        IList<Interface> RedefinedInterface { get; }
        #endregion
        }
    }

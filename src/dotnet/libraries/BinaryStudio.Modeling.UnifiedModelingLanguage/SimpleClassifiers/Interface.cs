using System;
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
        #region P:NestedClassifier:Classifier[]
        /// <summary>
        /// References all the Classifiers that are defined (nested) within the <see cref="Interface"/>.
        /// </summary>
        /// xmi:id="Interface-nestedClassifier"
        /// xmi:aggregation="composite"
        /// xmi:association="A_nestedClassifier_interface"
        /// xmi:subsets="A_redefinitionContext_redefinableElement-redefinableElement"
        /// xmi:subsets="Namespace-ownedMember"
        [Ordered]
        Classifier[] NestedClassifier { get; }
        #endregion
        #region P:OwnedAttribute:Property[]
        /// <summary>
        /// The attributes (i.e., the Properties) owned by the <see cref="Interface"/>.
        /// </summary>
        /// xmi:id="Interface-ownedAttribute"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedAttribute_interface"
        /// xmi:subsets="Classifier-attribute"
        /// xmi:subsets="Namespace-ownedMember"
        [Ordered]
        Property[] OwnedAttribute { get; }
        #endregion
        #region P:OwnedOperation:Operation[]
        /// <summary>
        /// The Operations owned by the <see cref="Interface"/>.
        /// </summary>
        /// xmi:id="Interface-ownedOperation"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedOperation_interface"
        /// xmi:subsets="A_redefinitionContext_redefinableElement-redefinableElement"
        /// xmi:subsets="Classifier-feature"
        /// xmi:subsets="Namespace-ownedMember"
        [Ordered]
        Operation[] OwnedOperation { get; }
        #endregion
        #region P:OwnedReception:Reception[]
        /// <summary>
        /// Receptions that objects providing this <see cref="Interface"/> are willing to accept.
        /// </summary>
        /// xmi:id="Interface-ownedReception"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedReception_interface"
        /// xmi:subsets="Classifier-feature"
        /// xmi:subsets="Namespace-ownedMember"
        Reception[] OwnedReception { get; }
        #endregion
        #region P:Protocol:ProtocolStateMachine
        /// <summary>
        /// References a <see cref="ProtocolStateMachine"/> specifying the legal sequences of the invocation of the BehavioralFeatures described in the <see cref="Interface"/>.
        /// </summary>
        /// xmi:id="Interface-protocol"
        /// xmi:aggregation="composite"
        /// xmi:association="A_protocol_interface"
        /// xmi:subsets="Namespace-ownedMember"
        [Multiplicity("0..1")]
        ProtocolStateMachine Protocol { get; }
        #endregion
        #region P:RedefinedInterface:Interface[]
        /// <summary>
        /// References all the Interfaces redefined by this <see cref="Interface"/>.
        /// </summary>
        /// xmi:id="Interface-redefinedInterface"
        /// xmi:association="A_redefinedInterface_interface"
        /// xmi:subsets="Classifier-redefinedClassifier"
        Interface[] RedefinedInterface { get; }
        #endregion
        }
    }

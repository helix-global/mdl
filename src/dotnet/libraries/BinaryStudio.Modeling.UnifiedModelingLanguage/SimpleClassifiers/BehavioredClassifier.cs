using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="BehavioredClassifier"/> may have InterfaceRealizations, and owns a set of Behaviors one of which may specify the behavior of the <see cref="BehavioredClassifier"/> itself.
    /// </summary>
    /// <rule language="OCL">
    ///   If a behavior is classifier behavior, it does not have a specification.
    ///   <![CDATA[
    ///     classifierBehavior->notEmpty() implies classifierBehavior.specification->isEmpty()
    ///   ]]>
    ///   xmi:id="BehavioredClassifier-class_behavior"
    /// </rule>
    /// xmi:id="BehavioredClassifier"
    public interface BehavioredClassifier : Classifier
        {
        #region P:ClassifierBehavior:Behavior
        /// <summary>
        /// A <see cref="Behavior"/> that specifies the behavior of the <see cref="BehavioredClassifier"/> itself.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.BehavioredClassifier.OwnedBehavior"/>"
        /// </summary>
        /// xmi:id="BehavioredClassifier-classifierBehavior"
        /// xmi:association="A_classifierBehavior_behavioredClassifier"
        [Multiplicity("0..1")]
        Behavior ClassifierBehavior { get;set; }
        #endregion
        #region P:InterfaceRealization:IList<InterfaceRealization>
        /// <summary>
        /// The set of InterfaceRealizations owned by the <see cref="BehavioredClassifier"/>. <see cref="Interface"/> realizations reference the Interfaces of which the <see cref="BehavioredClassifier"/> is an implementation.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.ClientDependency"/>"
        /// </summary>
        /// xmi:id="BehavioredClassifier-interfaceRealization"
        /// xmi:aggregation="composite"
        /// xmi:association="A_interfaceRealization_implementingClassifier"
        IList<InterfaceRealization> InterfaceRealization { get; }
        #endregion
        #region P:OwnedBehavior:IList<Behavior>
        /// <summary>
        /// Behaviors owned by a <see cref="BehavioredClassifier"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="BehavioredClassifier-ownedBehavior"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedBehavior_behavioredClassifier"
        IList<Behavior> OwnedBehavior { get; }
        #endregion
        }
    }

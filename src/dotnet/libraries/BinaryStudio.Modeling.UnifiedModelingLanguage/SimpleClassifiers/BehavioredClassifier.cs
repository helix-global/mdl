using System;

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
        /// </summary>
        /// xmi:id="BehavioredClassifier-classifierBehavior"
        Behavior ClassifierBehavior { get; }
        #endregion
        #region P:InterfaceRealization:InterfaceRealization[]
        /// <summary>
        /// The set of InterfaceRealizations owned by the <see cref="BehavioredClassifier"/>. <see cref="Interface"/> realizations reference the Interfaces of which the <see cref="BehavioredClassifier"/> is an implementation.
        /// </summary>
        /// xmi:id="BehavioredClassifier-interfaceRealization"
        /// xmi:aggregation="composite"
        InterfaceRealization[] InterfaceRealization { get; }
        #endregion
        #region P:OwnedBehavior:Behavior[]
        /// <summary>
        /// Behaviors owned by a <see cref="BehavioredClassifier"/>.
        /// </summary>
        /// xmi:id="BehavioredClassifier-ownedBehavior"
        /// xmi:aggregation="composite"
        Behavior[] OwnedBehavior { get; }
        #endregion
        }
    }

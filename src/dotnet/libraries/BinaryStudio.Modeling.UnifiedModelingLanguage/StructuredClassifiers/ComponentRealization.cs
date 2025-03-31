using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="Realization"/> is specialized to (optionally) define the Classifiers that realize the contract offered by a <see cref="Component"/> in terms of its provided and required Interfaces. The <see cref="Component"/> forms an <see cref="Abstraction"/> from these various Classifiers.
    /// </summary>
    /// xmi:id="ComponentRealization"
    public interface ComponentRealization : Realization
        {
        #region P:Abstraction:Component
        /// <summary>
        /// The <see cref="Component"/> that owns this <see cref="ComponentRealization"/> and which is implemented by its realizing Classifiers.
        /// </summary>
        /// xmi:id="ComponentRealization-abstraction"
        /// xmi:association="A_realization_abstraction_component"
        /// xmi:subsets="Dependency-supplier"
        /// xmi:subsets="Element-owner"
        [Multiplicity("0..1")]
        Component Abstraction { get; }
        #endregion
        #region P:RealizingClassifier:Classifier[]
        /// <summary>
        /// The Classifiers that are involved in the implementation of the <see cref="Component"/> that owns this <see cref="Realization"/>.
        /// </summary>
        /// xmi:id="ComponentRealization-realizingClassifier"
        /// xmi:association="A_realizingClassifier_componentRealization"
        /// xmi:subsets="Dependency-client"
        [Multiplicity("1..*")]
        Classifier[] RealizingClassifier { get; }
        #endregion
        }
    }

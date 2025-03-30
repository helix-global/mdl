using System;

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
        Component Abstraction { get; }
        #endregion
        #region P:RealizingClassifier:Classifier[]
        /// <summary>
        /// The Classifiers that are involved in the implementation of the <see cref="Component"/> that owns this <see cref="Realization"/>.
        /// </summary>
        /// xmi:id="ComponentRealization-realizingClassifier"
        Classifier[] RealizingClassifier { get; }
        #endregion
        }
    }

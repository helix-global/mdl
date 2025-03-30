using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Feature"/> declares a behavioral or structural characteristic of Classifiers.
    /// </summary>
    /// xmi:id="Feature"
    public interface Feature : RedefinableElement
        {
        #region P:FeaturingClassifier:Classifier
        /// <summary>
        /// The Classifiers that have this <see cref="Feature"/> as a feature.
        /// </summary>
        /// xmi:id="Feature-featuringClassifier"
        Classifier FeaturingClassifier { get; }
        #endregion
        #region P:IsStatic:Boolean
        /// <summary>
        /// Specifies whether this <see cref="Feature"/> characterizes individual instances classified by the <see cref="Classifier"/> (false) or the <see cref="Classifier"/> itself (true).
        /// </summary>
        /// xmi:id="Feature-isStatic"
        Boolean IsStatic { get; }
        #endregion
        }
    }

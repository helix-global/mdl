using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

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
        /// Subsets:
        /// </summary>
        /// xmi:id="Feature-featuringClassifier"
        /// xmi:association="A_feature_featuringClassifier"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        /// xmi:subsets="A_member_memberNamespace-memberNamespace"
        [Multiplicity("0..1")][Union]
        Classifier FeaturingClassifier { get; }
        #endregion
        #region P:IsStatic:Boolean
        /// <summary>
        /// Specifies whether this <see cref="Feature"/> characterizes individual instances classified by the <see cref="Classifier"/> (false) or the <see cref="Classifier"/> itself (true).
        /// </summary>
        /// xmi:id="Feature-isStatic"
        Boolean IsStatic { get;set; }
        #endregion
        }
    }

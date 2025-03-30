using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A substitution is a relationship between two classifiers signifying that the substituting classifier complies with the <see cref="Contract"/> specified by the <see cref="Contract"/> classifier. This implies that instances of the substituting classifier are runtime substitutable where instances of the <see cref="Contract"/> classifier are expected.
    /// </summary>
    /// xmi:id="Substitution"
    public interface Substitution : Realization
        {
        #region P:Contract:Classifier
        /// <summary>
        /// The <see cref="Contract"/> with which the substituting classifier complies.
        /// </summary>
        /// xmi:id="Substitution-contract"
        Classifier Contract { get; }
        #endregion
        #region P:SubstitutingClassifier:Classifier
        /// <summary>
        /// Instances of the substituting classifier are runtime substitutable where instances of the <see cref="Contract"/> classifier are expected.
        /// </summary>
        /// xmi:id="Substitution-substitutingClassifier"
        Classifier SubstitutingClassifier { get; }
        #endregion
        }
    }

using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

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
        /// xmi:association="A_contract_substitution"
        /// xmi:subsets="Dependency-supplier"
        Classifier Contract { get; }
        #endregion
        #region P:SubstitutingClassifier:Classifier
        /// <summary>
        /// Instances of the substituting classifier are runtime substitutable where instances of the <see cref="Contract"/> classifier are expected.
        /// </summary>
        /// xmi:id="Substitution-substitutingClassifier"
        /// xmi:association="A_substitution_substitutingClassifier"
        /// xmi:subsets="Dependency-client"
        /// xmi:subsets="Element-owner"
        Classifier SubstitutingClassifier { get; }
        #endregion
        }
    }

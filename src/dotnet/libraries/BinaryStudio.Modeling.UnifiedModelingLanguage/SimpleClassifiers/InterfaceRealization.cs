using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="InterfaceRealization"/> is a specialized realization relationship between a <see cref="BehavioredClassifier"/> and an <see cref="Interface"/>. This relationship signifies that the realizing <see cref="BehavioredClassifier"/> conforms to the <see cref="Contract"/> specified by the <see cref="Interface"/>.
    /// </summary>
    /// xmi:id="InterfaceRealization"
    public interface InterfaceRealization : Realization
        {
        #region P:Contract:Interface
        /// <summary>
        /// References the <see cref="Interface"/> specifying the conformance <see cref="Contract"/>.
        /// </summary>
        /// xmi:id="InterfaceRealization-contract"
        /// xmi:association="A_contract_interfaceRealization"
        /// xmi:subsets="Dependency-supplier"
        Interface Contract { get; }
        #endregion
        #region P:ImplementingClassifier:BehavioredClassifier
        /// <summary>
        /// References the <see cref="BehavioredClassifier"/> that owns this <see cref="InterfaceRealization"/>, i.e., the <see cref="BehavioredClassifier"/> that realizes the <see cref="Interface"/> to which it refers.
        /// </summary>
        /// xmi:id="InterfaceRealization-implementingClassifier"
        /// xmi:association="A_interfaceRealization_implementingClassifier"
        /// xmi:subsets="Dependency-client"
        /// xmi:subsets="Element-owner"
        BehavioredClassifier ImplementingClassifier { get; }
        #endregion
        }
    }

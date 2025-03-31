using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A package merge defines how the contents of one package are extended by the contents of another package.
    /// </summary>
    /// xmi:id="PackageMerge"
    public interface PackageMerge : DirectedRelationship
        {
        #region P:MergedPackage:Package
        /// <summary>
        /// References the <see cref="Package"/> that is to be merged with the receiving package of the <see cref="PackageMerge"/>.
        /// </summary>
        /// xmi:id="PackageMerge-mergedPackage"
        /// xmi:association="A_mergedPackage_packageMerge"
        /// xmi:subsets="DirectedRelationship-target"
        Package MergedPackage { get; }
        #endregion
        #region P:ReceivingPackage:Package
        /// <summary>
        /// References the <see cref="Package"/> that is being extended with the contents of the merged package of the <see cref="PackageMerge"/>.
        /// </summary>
        /// xmi:id="PackageMerge-receivingPackage"
        /// xmi:association="A_packageMerge_receivingPackage"
        /// xmi:subsets="DirectedRelationship-source"
        /// xmi:subsets="Element-owner"
        Package ReceivingPackage { get; }
        #endregion
        }
    }

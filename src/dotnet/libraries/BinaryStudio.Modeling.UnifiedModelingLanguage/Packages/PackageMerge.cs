using System;

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
        Package MergedPackage { get; }
        #endregion
        #region P:ReceivingPackage:Package
        /// <summary>
        /// References the <see cref="Package"/> that is being extended with the contents of the merged package of the <see cref="PackageMerge"/>.
        /// </summary>
        /// xmi:id="PackageMerge-receivingPackage"
        Package ReceivingPackage { get; }
        #endregion
        }
    }

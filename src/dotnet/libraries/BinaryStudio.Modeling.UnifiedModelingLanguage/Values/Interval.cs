using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="Interval"/> defines the range between two ValueSpecifications.
    /// </summary>
    /// xmi:id="Interval"
    public interface Interval : ValueSpecification
        {
        #region P:Max:ValueSpecification
        /// <summary>
        /// Refers to the <see cref="ValueSpecification"/> denoting the maximum value of the range.
        /// </summary>
        /// xmi:id="Interval-max"
        ValueSpecification Max { get; }
        #endregion
        #region P:Min:ValueSpecification
        /// <summary>
        /// Refers to the <see cref="ValueSpecification"/> denoting the minimum value of the range.
        /// </summary>
        /// xmi:id="Interval-min"
        ValueSpecification Min { get; }
        #endregion
        }
    }

using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

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
        /// xmi:association="A_max_interval"
        ValueSpecification Max { get;set; }
        #endregion
        #region P:Min:ValueSpecification
        /// <summary>
        /// Refers to the <see cref="ValueSpecification"/> denoting the minimum value of the range.
        /// </summary>
        /// xmi:id="Interval-min"
        /// xmi:association="A_min_interval"
        ValueSpecification Min { get;set; }
        #endregion
        }
    }

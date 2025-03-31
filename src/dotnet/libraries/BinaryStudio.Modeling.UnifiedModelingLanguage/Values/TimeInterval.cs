using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="TimeInterval"/> defines the range between two TimeExpressions.
    /// </summary>
    /// xmi:id="TimeInterval"
    public interface TimeInterval : Interval
        {
        #region P:Max:TimeExpression
        /// <summary>
        /// Refers to the <see cref="TimeExpression"/> denoting the maximum value of the range.
        /// </summary>
        /// xmi:id="TimeInterval-max"
        /// xmi:association="A_max_timeInterval"
        /// xmi:redefines="Interval-max{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Interval.Max"/>}"
        TimeExpression Max { get; }
        #endregion
        #region P:Min:TimeExpression
        /// <summary>
        /// Refers to the <see cref="TimeExpression"/> denoting the minimum value of the range.
        /// </summary>
        /// xmi:id="TimeInterval-min"
        /// xmi:association="A_min_timeInterval"
        /// xmi:redefines="Interval-min{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Interval.Min"/>}"
        TimeExpression Min { get; }
        #endregion
        }
    }

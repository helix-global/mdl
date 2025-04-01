using System;
using System.Collections.Generic;
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
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Interval.Max"/>"
        /// </summary>
        /// xmi:id="TimeInterval-max"
        /// xmi:association="A_max_timeInterval"
        TimeExpression Max { get;set; }
        #endregion
        #region P:Min:TimeExpression
        /// <summary>
        /// Refers to the <see cref="TimeExpression"/> denoting the minimum value of the range.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Interval.Min"/>"
        /// </summary>
        /// xmi:id="TimeInterval-min"
        /// xmi:association="A_min_timeInterval"
        TimeExpression Min { get;set; }
        #endregion
        }
    }

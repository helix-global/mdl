using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="DurationInterval"/> defines the range between two Durations.
    /// </summary>
    /// xmi:id="DurationInterval"
    public interface DurationInterval : Interval
        {
        #region P:Max:Duration
        /// <summary>
        /// Refers to the <see cref="Duration"/> denoting the maximum value of the range.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Interval.Max"/>"
        /// </summary>
        /// xmi:id="DurationInterval-max"
        /// xmi:association="A_max_durationInterval"
        Duration Max { get; }
        #endregion
        #region P:Min:Duration
        /// <summary>
        /// Refers to the <see cref="Duration"/> denoting the minimum value of the range.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Interval.Min"/>"
        /// </summary>
        /// xmi:id="DurationInterval-min"
        /// xmi:association="A_min_durationInterval"
        Duration Min { get; }
        #endregion
        }
    }

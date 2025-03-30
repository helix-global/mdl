using System;

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
        /// </summary>
        /// xmi:id="DurationInterval-max"
        /// xmi:redefines="Interval-max{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Interval.Max"/>}"
        Duration Max { get; }
        #endregion
        #region P:Min:Duration
        /// <summary>
        /// Refers to the <see cref="Duration"/> denoting the minimum value of the range.
        /// </summary>
        /// xmi:id="DurationInterval-min"
        /// xmi:redefines="Interval-min{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Interval.Min"/>}"
        Duration Min { get; }
        #endregion
        }
    }

using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="IntervalConstraint"/> is a <see cref="Constraint"/> that is specified by an <see cref="Interval"/>.
    /// </summary>
    /// xmi:id="IntervalConstraint"
    public interface IntervalConstraint : Constraint
        {
        #region P:Specification:Interval
        /// <summary>
        /// The <see cref="Interval"/> that specifies the condition of the <see cref="IntervalConstraint"/>.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Constraint.Specification"/>"
        /// </summary>
        /// xmi:id="IntervalConstraint-specification"
        /// xmi:aggregation="composite"
        /// xmi:association="A_specification_intervalConstraint"
        Interval Specification { get; }
        #endregion
        }
    }

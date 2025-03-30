using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="TimeExpression"/> is a <see cref="ValueSpecification"/> that represents a time value.
    /// </summary>
    /// <rule language="OCL">
    ///   If a <see cref="TimeExpression"/> has no expr, then it must have a single observation that is a <see cref="TimeObservation"/>.
    ///   <![CDATA[
    ///     expr = null implies (observation->size() = 1 and observation->forAll(oclIsKindOf(TimeObservation)))
    ///   ]]>
    ///   xmi:id="TimeExpression-no_expr_requires_observation"
    /// </rule>
    /// xmi:id="TimeExpression"
    public interface TimeExpression : ValueSpecification
        {
        #region P:Expr:ValueSpecification
        /// <summary>
        /// A <see cref="ValueSpecification"/> that evaluates to the value of the <see cref="TimeExpression"/>.
        /// </summary>
        /// xmi:id="TimeExpression-expr"
        /// xmi:aggregation="composite"
        ValueSpecification Expr { get; }
        #endregion
        #region P:Observation:Observation[]
        /// <summary>
        /// Refers to the Observations that are involved in the computation of the <see cref="TimeExpression"/> value.
        /// </summary>
        /// xmi:id="TimeExpression-observation"
        Observation[] Observation { get; }
        #endregion
        }
    }

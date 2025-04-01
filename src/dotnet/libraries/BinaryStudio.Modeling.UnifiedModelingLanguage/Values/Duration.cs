using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Duration"/> is a <see cref="ValueSpecification"/> that specifies the temporal distance between two time instants.
    /// </summary>
    /// <rule language="OCL">
    ///   If a <see cref="Duration"/> has no expr, then it must have a single observation that is a <see cref="DurationObservation"/>.
    ///   <![CDATA[
    ///     expr = null implies (observation->size() = 1 and observation->forAll(oclIsKindOf(DurationObservation)))
    ///   ]]>
    ///   xmi:id="Duration-no_expr_requires_observation"
    /// </rule>
    /// xmi:id="Duration"
    public interface Duration : ValueSpecification
        {
        #region P:Expr:ValueSpecification
        /// <summary>
        /// A <see cref="ValueSpecification"/> that evaluates to the value of the <see cref="Duration"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Duration-expr"
        /// xmi:aggregation="composite"
        /// xmi:association="A_expr_duration"
        [Multiplicity("0..1")]
        ValueSpecification Expr { get;set; }
        #endregion
        #region P:Observation:IList<Observation>
        /// <summary>
        /// Refers to the Observations that are involved in the computation of the <see cref="Duration"/> value
        /// </summary>
        /// xmi:id="Duration-observation"
        /// xmi:association="A_observation_duration"
        IList<Observation> Observation { get; }
        #endregion
        }
    }

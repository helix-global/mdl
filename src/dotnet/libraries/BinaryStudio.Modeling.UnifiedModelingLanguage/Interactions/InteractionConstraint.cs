using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="InteractionConstraint"/> is a Boolean expression that guards an operand in a <see cref="CombinedFragment"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   Minint/maxint can only be present if the <see cref="InteractionConstraint"/> is associated with the operand of a loop <see cref="CombinedFragment"/>.
    ///   <![CDATA[
    ///     maxint->notEmpty() or minint->notEmpty() implies
    ///     interactionOperand.combinedFragment.interactionOperator =
    ///     InteractionOperatorKind::loop
    ///   ]]>
    ///   xmi:id="InteractionConstraint-minint_maxint"
    /// </rule>
    /// <rule language="OCL">
    ///   If minint is specified, then the expression must evaluate to a non-negative integer.
    ///   <![CDATA[
    ///     minint->notEmpty() implies 
    ///     minint->asSequence()->first().integerValue() >= 0
    ///   ]]>
    ///   xmi:id="InteractionConstraint-minint_non_negative"
    /// </rule>
    /// <rule language="OCL">
    ///   If maxint is specified, then the expression must evaluate to a positive integer.
    ///   <![CDATA[
    ///     maxint->notEmpty() implies 
    ///     maxint->asSequence()->first().integerValue() > 0
    ///   ]]>
    ///   xmi:id="InteractionConstraint-maxint_positive"
    /// </rule>
    /// <rule language="">
    ///   The dynamic variables that take part in the constraint must be owned by the <see cref="ConnectableElement"/> corresponding to the covered <see cref="Lifeline"/>.
    ///   xmi:id="InteractionConstraint-dynamic_variables"
    /// </rule>
    /// <rule language="">
    ///   The constraint may contain references to global data or write-once data.
    ///   xmi:id="InteractionConstraint-global_data"
    /// </rule>
    /// <rule language="OCL">
    ///   If maxint is specified, then minint must be specified and the evaluation of maxint must be >= the evaluation of minint.
    ///   <![CDATA[
    ///     maxint->notEmpty() implies (minint->notEmpty() and 
    ///     maxint->asSequence()->first().integerValue() >=
    ///     minint->asSequence()->first().integerValue() )
    ///   ]]>
    ///   xmi:id="InteractionConstraint-maxint_greater_equal_minint"
    /// </rule>
    /// xmi:id="InteractionConstraint"
    public interface InteractionConstraint : Constraint
        {
        #region P:Maxint:ValueSpecification
        /// <summary>
        /// The maximum number of iterations of a loop
        /// </summary>
        /// xmi:id="InteractionConstraint-maxint"
        /// xmi:aggregation="composite"
        /// xmi:association="A_maxint_interactionConstraint"
        /// xmi:subsets="Element-ownedElement"
        [Multiplicity("0..1")]
        ValueSpecification Maxint { get; }
        #endregion
        #region P:Minint:ValueSpecification
        /// <summary>
        /// The minimum number of iterations of a loop
        /// </summary>
        /// xmi:id="InteractionConstraint-minint"
        /// xmi:aggregation="composite"
        /// xmi:association="A_minint_interactionConstraint"
        /// xmi:subsets="Element-ownedElement"
        [Multiplicity("0..1")]
        ValueSpecification Minint { get; }
        #endregion
        }
    }

using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="DurationConstraint"/> is a <see cref="Constraint"/> that refers to a <see cref="DurationInterval"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of firstEvent must be 2 if the multiplicity of constrainedElement is 2. Otherwise the multiplicity of firstEvent is 0.
    ///   <![CDATA[
    ///     if (constrainedElement->size() = 2)
    ///       then (firstEvent->size() = 2) else (firstEvent->size() = 0) 
    ///     endif
    ///   ]]>
    ///   xmi:id="DurationConstraint-first_event_multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="DurationConstraint"/> has either one or two constrainedElements.
    ///   <![CDATA[
    ///     constrainedElement->size() = 1 or constrainedElement->size()=2
    ///   ]]>
    ///   xmi:id="DurationConstraint-has_one_or_two_constrainedElements"
    /// </rule>
    /// xmi:id="DurationConstraint"
    public interface DurationConstraint : IntervalConstraint
        {
        #region P:FirstEvent:Boolean[]
        /// <summary>
        /// The value of <see cref="FirstEvent"/>[i] is related to <see cref="ConstrainedElement"/>[i] (where i is 1 or 2). If <see cref="FirstEvent"/>[i] is true, then the corresponding observation event is the first time instant the execution enters <see cref="ConstrainedElement"/>[i]. If <see cref="FirstEvent"/>[i] is false, then the corresponding observation event is the last time instant the execution is within <see cref="ConstrainedElement"/>[i].
        /// </summary>
        /// xmi:id="DurationConstraint-firstEvent"
        [Multiplicity("0..2")]
        Boolean[] FirstEvent { get; }
        #endregion
        #region P:Specification:DurationInterval
        /// <summary>
        /// The <see cref="DurationInterval"/> constraining the duration.
        /// </summary>
        /// xmi:id="DurationConstraint-specification"
        /// xmi:aggregation="composite"
        /// xmi:association="A_specification_durationConstraint"
        /// xmi:redefines="IntervalConstraint-specification{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.IntervalConstraint.Specification"/>}"
        DurationInterval Specification { get; }
        #endregion
        }
    }

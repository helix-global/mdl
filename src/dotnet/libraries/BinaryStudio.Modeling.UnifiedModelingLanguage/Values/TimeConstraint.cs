﻿using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="TimeConstraint"/> is a <see cref="Constraint"/> that refers to a <see cref="TimeInterval"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="TimeConstraint"/> has one constrainedElement.
    ///   <![CDATA[
    ///     constrainedElement->size() = 1
    ///   ]]>
    ///   xmi:id="TimeConstraint-has_one_constrainedElement"
    /// </rule>
    /// xmi:id="TimeConstraint"
    public interface TimeConstraint : IntervalConstraint
        {
        #region P:FirstEvent:Boolean?
        /// <summary>
        /// The value of <see cref="FirstEvent"/> is related to the <see cref="ConstrainedElement"/>. If <see cref="FirstEvent"/> is true, then the corresponding observation event is the first time instant the execution enters the <see cref="ConstrainedElement"/>. If <see cref="FirstEvent"/> is false, then the corresponding observation event is the last time instant the execution is within the <see cref="ConstrainedElement"/>.
        /// </summary>
        /// xmi:id="TimeConstraint-firstEvent"
        Boolean? FirstEvent { get;set; }
        #endregion
        #region P:Specification:TimeInterval
        /// <summary>
        /// TheTimeInterval constraining the duration.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.IntervalConstraint.Specification"/>"
        /// </summary>
        /// xmi:id="TimeConstraint-specification"
        /// xmi:aggregation="composite"
        /// xmi:association="A_specification_timeConstraint"
        TimeInterval Specification { get;set; }
        #endregion
        }
    }

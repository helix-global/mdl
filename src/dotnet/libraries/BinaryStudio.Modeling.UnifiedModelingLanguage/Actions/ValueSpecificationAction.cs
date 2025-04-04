﻿using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ValueSpecificationAction"/> is an <see cref="Action"/> that evaluates a <see cref="ValueSpecification"/> and provides a <see cref="Result"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of the result <see cref="OutputPin"/> is 1..1
    ///   <![CDATA[
    ///     result.is(1,1)
    ///   ]]>
    ///   xmi:id="ValueSpecificationAction-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the value <see cref="ValueSpecification"/> must conform to the type of the result <see cref="OutputPin"/>.
    ///   <![CDATA[
    ///     value.type.conformsTo(result.type)
    ///   ]]>
    ///   xmi:id="ValueSpecificationAction-compatible_type"
    /// </rule>
    /// xmi:id="ValueSpecificationAction"
    public interface ValueSpecificationAction : Action
        {
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> on which the <see cref="Result"/> <see cref="Value"/> is placed.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Output"/>"
        /// </summary>
        /// xmi:id="ValueSpecificationAction-result"
        /// xmi:aggregation="composite"
        /// xmi:association="A_result_valueSpecificationAction"
        OutputPin Result { get;set; }
        #endregion
        #region P:Value:ValueSpecification
        /// <summary>
        /// The <see cref="ValueSpecification"/> to be evaluated.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="ValueSpecificationAction-value"
        /// xmi:aggregation="composite"
        /// xmi:association="A_value_valueSpecificationAction"
        ValueSpecification Value { get;set; }
        #endregion
        }
    }

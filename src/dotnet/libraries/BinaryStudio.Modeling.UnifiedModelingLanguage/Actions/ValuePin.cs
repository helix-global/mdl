using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ValuePin"/> is an <see cref="InputPin"/> that provides a <see cref="Value"/> by evaluating a <see cref="ValueSpecification"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="ValuePin"/> may have no incoming ActivityEdges.
    ///   <![CDATA[
    ///     incoming->isEmpty()
    ///   ]]>
    ///   xmi:id="ValuePin-no_incoming_edges"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the value <see cref="ValueSpecification"/> must conform to the type of the <see cref="ValuePin"/>.
    ///   <![CDATA[
    ///     value.type.conformsTo(type)
    ///   ]]>
    ///   xmi:id="ValuePin-compatible_type"
    /// </rule>
    /// xmi:id="ValuePin"
    public interface ValuePin : InputPin
        {
        #region P:Value:ValueSpecification
        /// <summary>
        /// The <see cref="ValueSpecification"/> that is evaluated to obtain the <see cref="Value"/> that the <see cref="ValuePin"/> will provide.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="ValuePin-value"
        /// xmi:aggregation="composite"
        /// xmi:association="A_value_valuePin"
        ValueSpecification Value { get;set; }
        #endregion
        }
    }

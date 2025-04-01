using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="QualifierValue"/> is an <see cref="Element"/> that is used as part of <see cref="LinkEndData"/> to provide the <see cref="Value"/> for a single <see cref="Qualifier"/> of the end given by the <see cref="LinkEndData"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of the value <see cref="InputPin"/> is 1..1.
    ///   <![CDATA[
    ///     value.is(1,1)
    ///   ]]>
    ///   xmi:id="QualifierValue-multiplicity_of_qualifier"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the value <see cref="InputPin"/> conforms to the type of the qualifier <see cref="Property"/>.
    ///   <![CDATA[
    ///     value.type.conformsTo(qualifier.type)
    ///   ]]>
    ///   xmi:id="QualifierValue-type_of_qualifier"
    /// </rule>
    /// <rule language="OCL">
    ///   The qualifier must be a qualifier of the <see cref="Association"/> end of the linkEndData that owns this <see cref="QualifierValue"/>.
    ///   <![CDATA[
    ///     linkEndData.end.qualifier->includes(qualifier)
    ///   ]]>
    ///   xmi:id="QualifierValue-qualifier_attribute"
    /// </rule>
    /// xmi:id="QualifierValue"
    public interface QualifierValue : Element
        {
        #region P:Qualifier:Property
        /// <summary>
        /// The <see cref="Qualifier"/> <see cref="Property"/> for which the <see cref="Value"/> is to be specified.
        /// </summary>
        /// xmi:id="QualifierValue-qualifier"
        /// xmi:association="A_qualifier_qualifierValue"
        Property Qualifier { get;set; }
        #endregion
        #region P:Value:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> from which the specified <see cref="Value"/> for the <see cref="Qualifier"/> is taken.
        /// </summary>
        /// xmi:id="QualifierValue-value"
        /// xmi:association="A_value_qualifierValue"
        InputPin Value { get;set; }
        #endregion
        }
    }

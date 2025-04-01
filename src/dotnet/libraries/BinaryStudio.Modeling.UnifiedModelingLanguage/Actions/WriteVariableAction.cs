using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="WriteVariableAction"/> is an abstract class for VariableActions that change <see cref="Variable"/> values.
    /// </summary>
    /// <rule language="OCL">
    ///   The type of the value <see cref="InputPin"/> must conform to the type of the variable.
    ///   <![CDATA[
    ///     value <> null implies value.type.conformsTo(variable.type)
    ///   ]]>
    ///   xmi:id="WriteVariableAction-value_type"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the value <see cref="InputPin"/> is 1..1.
    ///   <![CDATA[
    ///     value<>null implies value.is(1,1)
    ///   ]]>
    ///   xmi:id="WriteVariableAction-multiplicity"
    /// </rule>
    /// xmi:id="WriteVariableAction"
    public interface WriteVariableAction : VariableAction
        {
        #region P:Value:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that gives the <see cref="Value"/> to be added or removed from the <see cref="Variable"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="WriteVariableAction-value"
        /// xmi:aggregation="composite"
        /// xmi:association="A_value_writeVariableAction"
        [Multiplicity("0..1")]
        InputPin Value { get;set; }
        #endregion
        }
    }

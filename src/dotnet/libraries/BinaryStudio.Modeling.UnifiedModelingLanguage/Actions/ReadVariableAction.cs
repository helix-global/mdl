using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ReadVariableAction"/> is a <see cref="VariableAction"/> that retrieves the values of a <see cref="Variable"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The type and ordering of the result <see cref="OutputPin"/> are the same as the type and ordering of the variable.
    ///   <![CDATA[
    ///     result.type =variable.type and 
    ///     result.isOrdered = variable.isOrdered
    ///     
    ///   ]]>
    ///   xmi:id="ReadVariableAction-type_and_ordering"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the variable must be compatible with the multiplicity of the output pin.
    ///   <![CDATA[
    ///     variable.compatibleWith(result)
    ///   ]]>
    ///   xmi:id="ReadVariableAction-compatible_multiplicity"
    /// </rule>
    /// xmi:id="ReadVariableAction"
    public interface ReadVariableAction : VariableAction
        {
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> on which the <see cref="Result"/> values are placed.
        /// </summary>
        /// xmi:id="ReadVariableAction-result"
        /// xmi:aggregation="composite"
        OutputPin Result { get; }
        #endregion
        }
    }

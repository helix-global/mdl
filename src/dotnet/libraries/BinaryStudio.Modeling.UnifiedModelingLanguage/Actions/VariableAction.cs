using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="VariableAction"/> is an abstract class for Actions that operate on a specified <see cref="Variable"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The <see cref="VariableAction"/> must be in the scope of the variable.
    ///   <![CDATA[
    ///     variable.isAccessibleBy(self)
    ///   ]]>
    ///   xmi:id="VariableAction-scope_of_variable"
    /// </rule>
    /// xmi:id="VariableAction"
    public interface VariableAction : Action
        {
        #region P:Variable:Variable
        /// <summary>
        /// The <see cref="Variable"/> to be read or written.
        /// </summary>
        /// xmi:id="VariableAction-variable"
        /// xmi:association="A_variable_variableAction"
        Variable Variable { get; }
        #endregion
        }
    }

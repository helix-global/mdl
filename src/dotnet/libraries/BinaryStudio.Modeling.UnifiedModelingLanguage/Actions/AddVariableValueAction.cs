using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="AddVariableValueAction"/> is a <see cref="WriteVariableAction"/> for adding values to a <see cref="Variable"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   A value <see cref="InputPin"/> is required.
    ///   <![CDATA[
    ///     value <> null
    ///   ]]>
    ///   xmi:id="AddVariableValueAction-required_value"
    /// </rule>
    /// <rule language="OCL">
    ///   AddVariableValueActions for ordered Variables must have a single <see cref="InputPin"/> for the insertion point with type UnlimtedNatural and multiplicity of 1..1 if isReplaceAll=false, otherwise the <see cref="Action"/> has no <see cref="InputPin"/> for the insertion point.
    ///   <![CDATA[
    ///     if not variable.isOrdered then insertAt = null
    ///     else 
    ///       not isReplaceAll implies
    ///       	insertAt<>null and 
    ///       	insertAt->forAll(type=UnlimitedNatural and is(1,1.oclAsType(UnlimitedNatural)))
    ///     endif
    ///     
    ///   ]]>
    ///   xmi:id="AddVariableValueAction-insertAt_pin"
    /// </rule>
    /// xmi:id="AddVariableValueAction"
    public interface AddVariableValueAction : WriteVariableAction
        {
        #region P:InsertAt:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that gives the position at which to insert a new <see cref="Value"/> or move an existing <see cref="Value"/> in ordered Variables. The type of the <see cref="InsertAt"/> <see cref="InputPin"/> is UnlimitedNatural, but the <see cref="Value"/> cannot be zero. It is omitted for unordered Variables.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="AddVariableValueAction-insertAt"
        /// xmi:aggregation="composite"
        /// xmi:association="A_insertAt_addVariableValueAction"
        [Multiplicity("0..1")]
        InputPin InsertAt { get; }
        #endregion
        #region P:IsReplaceAll:Boolean
        /// <summary>
        /// Specifies whether existing values of the <see cref="Variable"/> should be removed before adding the new <see cref="Value"/>.
        /// </summary>
        /// xmi:id="AddVariableValueAction-isReplaceAll"
        Boolean IsReplaceAll { get; }
        #endregion
        }
    }

using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="RemoveVariableValueAction"/> is a <see cref="WriteVariableAction"/> that removes values from a Variables.
    /// </summary>
    /// <rule language="OCL">
    ///   ReadVariableActions removing a value from ordered, non-unique Variables must have a single removeAt <see cref="InputPin"/> and no value <see cref="InputPin"/>, if isRemoveDuplicates is false. The removeAt <see cref="InputPin"/> must be of type Unlimited Natural with multiplicity 1..1. Otherwise, the <see cref="Action"/> has a value <see cref="InputPin"/> and no removeAt <see cref="InputPin"/>.
    ///   <![CDATA[
    ///     if  variable.isOrdered and not variable.isUnique and not isRemoveDuplicates then 
    ///       value = null and
    ///       removeAt <> null and
    ///       removeAt.type = UnlimitedNatural and
    ///       removeAt.is(1,1)
    ///     else
    ///       removeAt = null and value <> null
    ///     endif
    ///   ]]>
    ///   xmi:id="RemoveVariableValueAction-removeAt_and_value"
    /// </rule>
    /// xmi:id="RemoveVariableValueAction"
    public interface RemoveVariableValueAction : WriteVariableAction
        {
        #region P:IsRemoveDuplicates:Boolean
        /// <summary>
        /// Specifies whether to remove duplicates of the <see cref="Value"/> in nonunique Variables.
        /// </summary>
        /// xmi:id="RemoveVariableValueAction-isRemoveDuplicates"
        Boolean IsRemoveDuplicates { get; }
        #endregion
        #region P:RemoveAt:InputPin
        /// <summary>
        /// An <see cref="InputPin"/> that provides the position of an existing <see cref="Value"/> to remove in ordered, nonunique Variables. The type of the <see cref="RemoveAt"/> <see cref="InputPin"/> is UnlimitedNatural, but the <see cref="Value"/> cannot be zero or unlimited.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="RemoveVariableValueAction-removeAt"
        /// xmi:aggregation="composite"
        /// xmi:association="A_removeAt_removeVariableValueAction"
        [Multiplicity("0..1")]
        InputPin RemoveAt { get; }
        #endregion
        }
    }

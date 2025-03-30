using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="RemoveStructuralFeatureValueAction"/> is a <see cref="WriteStructuralFeatureAction"/> that removes values from a <see cref="StructuralFeature"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   RemoveStructuralFeatureValueActions removing a value from ordered, non-unique StructuralFeatures must have a single removeAt <see cref="InputPin"/> and no value <see cref="InputPin"/>, if isRemoveDuplicates is false. The removeAt <see cref="InputPin"/> must be of type Unlimited Natural with multiplicity 1..1. Otherwise, the <see cref="Action"/> has a value <see cref="InputPin"/> and no removeAt <see cref="InputPin"/>.
    ///   <![CDATA[
    ///     if structuralFeature.isOrdered and not structuralFeature.isUnique and  not isRemoveDuplicates then
    ///       value = null and
    ///       removeAt <> null and
    ///       removeAt.type = UnlimitedNatural and
    ///       removeAt.is(1,1)
    ///     else
    ///       removeAt = null and value <> null
    ///     endif
    ///   ]]>
    ///   xmi:id="RemoveStructuralFeatureValueAction-removeAt_and_value"
    /// </rule>
    /// xmi:id="RemoveStructuralFeatureValueAction"
    public interface RemoveStructuralFeatureValueAction : WriteStructuralFeatureAction
        {
        #region P:IsRemoveDuplicates:Boolean
        /// <summary>
        /// Specifies whether to remove duplicates of the <see cref="Value"/> in nonunique StructuralFeatures.
        /// </summary>
        /// xmi:id="RemoveStructuralFeatureValueAction-isRemoveDuplicates"
        Boolean IsRemoveDuplicates { get; }
        #endregion
        #region P:RemoveAt:InputPin
        /// <summary>
        /// An <see cref="InputPin"/> that provides the position of an existing <see cref="Value"/> to remove in ordered, nonunique structural features. The type of the <see cref="RemoveAt"/> <see cref="InputPin"/> is UnlimitedNatural, but the <see cref="Value"/> cannot be zero or unlimited.
        /// </summary>
        /// xmi:id="RemoveStructuralFeatureValueAction-removeAt"
        /// xmi:aggregation="composite"
        InputPin RemoveAt { get; }
        #endregion
        }
    }

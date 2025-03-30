using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="AddStructuralFeatureValueAction"/> is a <see cref="WriteStructuralFeatureAction"/> for adding values to a <see cref="StructuralFeature"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   A value <see cref="InputPin"/> is required.
    ///   <![CDATA[
    ///     value<>null
    ///   ]]>
    ///   xmi:id="AddStructuralFeatureValueAction-required_value"
    /// </rule>
    /// <rule language="OCL">
    ///   AddStructuralFeatureActions adding a value to ordered StructuralFeatures must have a single <see cref="InputPin"/> for the insertion point with type UnlimitedNatural and multiplicity of 1..1 if isReplaceAll=false, and must have no Input <see cref="Pin"/> for the insertion point when the <see cref="StructuralFeature"/> is unordered.
    ///   <![CDATA[
    ///     if not structuralFeature.isOrdered then insertAt = null
    ///     else 
    ///       not isReplaceAll implies
    ///       	insertAt<>null and 
    ///       	insertAt->forAll(type=UnlimitedNatural and is(1,1.oclAsType(UnlimitedNatural)))
    ///     endif
    ///     
    ///   ]]>
    ///   xmi:id="AddStructuralFeatureValueAction-insertAt_pin"
    /// </rule>
    /// xmi:id="AddStructuralFeatureValueAction"
    public interface AddStructuralFeatureValueAction : WriteStructuralFeatureAction
        {
        #region P:InsertAt:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that gives the position at which to insert the <see cref="Value"/> in an ordered <see cref="StructuralFeature"/>. The type of the <see cref="InsertAt"/> <see cref="InputPin"/> is UnlimitedNatural, but the <see cref="Value"/> cannot be zero. It is omitted for unordered StructuralFeatures.
        /// </summary>
        /// xmi:id="AddStructuralFeatureValueAction-insertAt"
        /// xmi:aggregation="composite"
        InputPin InsertAt { get; }
        #endregion
        #region P:IsReplaceAll:Boolean
        /// <summary>
        /// Specifies whether existing values of the <see cref="StructuralFeature"/> should be removed before adding the new <see cref="Value"/>.
        /// </summary>
        /// xmi:id="AddStructuralFeatureValueAction-isReplaceAll"
        Boolean IsReplaceAll { get; }
        #endregion
        }
    }

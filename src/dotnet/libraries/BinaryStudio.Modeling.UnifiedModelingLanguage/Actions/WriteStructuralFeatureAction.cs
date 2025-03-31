using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="WriteStructuralFeatureAction"/> is an abstract class for StructuralFeatureActions that change <see cref="StructuralFeature"/> values.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of the result <see cref="OutputPin"/> must be 1..1.
    ///   <![CDATA[
    ///     result <> null implies result.is(1,1)
    ///   ]]>
    ///   xmi:id="WriteStructuralFeatureAction-multiplicity_of_result"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the value <see cref="InputPin"/> must conform to the type of the structuralFeature.
    ///   <![CDATA[
    ///     value <> null implies value.type.conformsTo(structuralFeature.type)
    ///   ]]>
    ///   xmi:id="WriteStructuralFeatureAction-type_of_value"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the value <see cref="InputPin"/> is 1..1.
    ///   <![CDATA[
    ///     value<>null implies value.is(1,1)
    ///   ]]>
    ///   xmi:id="WriteStructuralFeatureAction-multiplicity_of_value"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the result <see cref="OutputPin"/> is the same as the type of the inherited object <see cref="InputPin"/>.
    ///   <![CDATA[
    ///     result <> null implies result.type = object.type
    ///   ]]>
    ///   xmi:id="WriteStructuralFeatureAction-type_of_result"
    /// </rule>
    /// xmi:id="WriteStructuralFeatureAction"
    public interface WriteStructuralFeatureAction : StructuralFeatureAction
        {
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> on which is put the <see cref="Input"/> <see cref="Object"/> as modified by the <see cref="WriteStructuralFeatureAction"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Output"/>"
        /// </summary>
        /// xmi:id="WriteStructuralFeatureAction-result"
        /// xmi:aggregation="composite"
        /// xmi:association="A_result_writeStructuralFeatureAction"
        [Multiplicity("0..1")]
        OutputPin Result { get; }
        #endregion
        #region P:Value:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that provides the <see cref="Value"/> to be added or removed from the <see cref="StructuralFeature"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="WriteStructuralFeatureAction-value"
        /// xmi:aggregation="composite"
        /// xmi:association="A_value_writeStructuralFeatureAction"
        [Multiplicity("0..1")]
        InputPin Value { get; }
        #endregion
        }
    }

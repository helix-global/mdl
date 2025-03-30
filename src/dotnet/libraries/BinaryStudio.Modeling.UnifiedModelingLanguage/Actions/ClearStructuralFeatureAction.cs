using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ClearStructuralFeatureAction"/> is a <see cref="StructuralFeatureAction"/> that removes all values of a <see cref="StructuralFeature"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The type of the result <see cref="OutputPin"/> is the same as the type of the inherited object <see cref="InputPin"/>.
    ///   <![CDATA[
    ///     result<>null implies result.type = object.type
    ///   ]]>
    ///   xmi:id="ClearStructuralFeatureAction-type_of_result"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the result <see cref="OutputPin"/> must be 1..1.
    ///   <![CDATA[
    ///     result<>null implies result.is(1,1)
    ///   ]]>
    ///   xmi:id="ClearStructuralFeatureAction-multiplicity_of_result"
    /// </rule>
    /// xmi:id="ClearStructuralFeatureAction"
    public interface ClearStructuralFeatureAction : StructuralFeatureAction
        {
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> on which is put the <see cref="Input"/> <see cref="Object"/> as modified by the <see cref="ClearStructuralFeatureAction"/>.
        /// </summary>
        /// xmi:id="ClearStructuralFeatureAction-result"
        /// xmi:aggregation="composite"
        OutputPin Result { get; }
        #endregion
        }
    }

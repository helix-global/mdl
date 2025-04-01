using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ReadStructuralFeatureAction"/> is a <see cref="StructuralFeatureAction"/> that retrieves the values of a <see cref="StructuralFeature"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of the <see cref="StructuralFeature"/> must be compatible with the multiplicity of the result <see cref="OutputPin"/>.
    ///   <![CDATA[
    ///     structuralFeature.compatibleWith(result)
    ///   ]]>
    ///   xmi:id="ReadStructuralFeatureAction-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The type and ordering of the result <see cref="OutputPin"/> are the same as the type and ordering of the <see cref="StructuralFeature"/>.
    ///   <![CDATA[
    ///     result.type =structuralFeature.type and 
    ///     result.isOrdered = structuralFeature.isOrdered
    ///     
    ///   ]]>
    ///   xmi:id="ReadStructuralFeatureAction-type_and_ordering"
    /// </rule>
    /// xmi:id="ReadStructuralFeatureAction"
    public interface ReadStructuralFeatureAction : StructuralFeatureAction
        {
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> on which the <see cref="Result"/> values are placed.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Output"/>"
        /// </summary>
        /// xmi:id="ReadStructuralFeatureAction-result"
        /// xmi:aggregation="composite"
        /// xmi:association="A_result_readStructuralFeatureAction"
        OutputPin Result { get;set; }
        #endregion
        }
    }

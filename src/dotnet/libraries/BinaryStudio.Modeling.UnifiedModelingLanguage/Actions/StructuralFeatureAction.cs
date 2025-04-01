using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="StructuralFeatureAction"/> is an abstract class for all Actions that operate on StructuralFeatures.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of the object <see cref="InputPin"/> must be 1..1.
    ///   <![CDATA[
    ///     object.is(1,1)
    ///   ]]>
    ///   xmi:id="StructuralFeatureAction-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The structuralFeature must either be an owned or inherited feature of the type of the object <see cref="InputPin"/>, or it must be an owned end of a binary <see cref="Association"/> whose opposite end had as a type to which the type of the object <see cref="InputPin"/> conforms.
    ///   <![CDATA[
    ///     object.type.oclAsType(Classifier).allFeatures()->includes(structuralFeature) or
    ///     	object.type.conformsTo(structuralFeature.oclAsType(Property).opposite.type)
    ///   ]]>
    ///   xmi:id="StructuralFeatureAction-object_type"
    /// </rule>
    /// <rule language="OCL">
    ///   The visibility of the structuralFeature must allow access from the object performing the <see cref="ReadStructuralFeatureAction"/>.
    ///   <![CDATA[
    ///     structuralFeature.visibility = VisibilityKind::public or
    ///     _'context'.allFeatures()->includes(structuralFeature) or
    ///     structuralFeature.visibility=VisibilityKind::protected and
    ///     _'context'.conformsTo(structuralFeature.oclAsType(Property).opposite.type.oclAsType(Classifier))
    ///     
    ///   ]]>
    ///   xmi:id="StructuralFeatureAction-visibility"
    /// </rule>
    /// <rule language="OCL">
    ///   The structuralFeature must not be static.
    ///   <![CDATA[
    ///     not structuralFeature.isStatic
    ///   ]]>
    ///   xmi:id="StructuralFeatureAction-not_static"
    /// </rule>
    /// <rule language="OCL">
    ///   The structuralFeature must have exactly one featuringClassifier.
    ///   <![CDATA[
    ///     structuralFeature.featuringClassifier->size() = 1
    ///   ]]>
    ///   xmi:id="StructuralFeatureAction-one_featuring_classifier"
    /// </rule>
    /// xmi:id="StructuralFeatureAction"
    public interface StructuralFeatureAction : Action
        {
        #region P:Object:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> from which the <see cref="Object"/> whose <see cref="StructuralFeature"/> is to be read or written is obtained.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="StructuralFeatureAction-object"
        /// xmi:aggregation="composite"
        /// xmi:association="A_object_structuralFeatureAction"
        InputPin Object { get;set; }
        #endregion
        #region P:StructuralFeature:StructuralFeature
        /// <summary>
        /// The <see cref="StructuralFeature"/> to be read or written.
        /// </summary>
        /// xmi:id="StructuralFeatureAction-structuralFeature"
        /// xmi:association="A_structuralFeature_structuralFeatureAction"
        StructuralFeature StructuralFeature { get;set; }
        #endregion
        }
    }

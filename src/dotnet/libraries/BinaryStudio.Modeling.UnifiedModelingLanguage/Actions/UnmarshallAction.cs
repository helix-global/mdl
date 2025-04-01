using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="UnmarshallAction"/> is an <see cref="Action"/> that retrieves the values of the StructuralFeatures of an <see cref="Object"/> and places them on OutputPins. 
    /// </summary>
    /// <rule language="OCL">
    ///   The unmarshallType must have at least one <see cref="StructuralFeature"/>.
    ///   <![CDATA[
    ///     unmarshallType.allAttributes()->size() >= 1
    ///   ]]>
    ///   xmi:id="UnmarshallAction-structural_feature"
    /// </rule>
    /// <rule language="OCL">
    ///   The number of result outputPins must be the same as the number of attributes of the unmarshallType.
    ///   <![CDATA[
    ///     unmarshallType.allAttributes()->size() = result->size()
    ///   ]]>
    ///   xmi:id="UnmarshallAction-number_of_result"
    /// </rule>
    /// <rule language="OCL">
    ///   The type, ordering and multiplicity of each attribute of the unmarshallType must be compatible with the type, ordering and multiplicity of the corresponding result <see cref="OutputPin"/>.
    ///   <![CDATA[
    ///     let attribute:OrderedSet(Property) = unmarshallType.allAttributes() in
    ///     Sequence{1..result->size()}->forAll(i | 
    ///     	attribute->at(i).type.conformsTo(result->at(i).type) and
    ///     	attribute->at(i).isOrdered=result->at(i).isOrdered and
    ///     	attribute->at(i).compatibleWith(result->at(i)))
    ///   ]]>
    ///   xmi:id="UnmarshallAction-type_ordering_and_multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the object <see cref="InputPin"/> is 1..1
    ///   <![CDATA[
    ///     object.is(1,1)
    ///   ]]>
    ///   xmi:id="UnmarshallAction-multiplicity_of_object"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the object <see cref="InputPin"/> conform to the unmarshallType.
    ///   <![CDATA[
    ///     object.type.conformsTo(unmarshallType)
    ///   ]]>
    ///   xmi:id="UnmarshallAction-object_type"
    /// </rule>
    /// xmi:id="UnmarshallAction"
    public interface UnmarshallAction : Action
        {
        #region P:Object:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that gives the <see cref="Object"/> to be unmarshalled.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="UnmarshallAction-object"
        /// xmi:aggregation="composite"
        /// xmi:association="A_object_unmarshallAction"
        InputPin Object { get;set; }
        #endregion
        #region P:Result:IList<OutputPin>
        /// <summary>
        /// The OutputPins on which are placed the values of the StructuralFeatures of the <see cref="Input"/> <see cref="Object"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Output"/>"
        /// </summary>
        /// xmi:id="UnmarshallAction-result"
        /// xmi:aggregation="composite"
        /// xmi:association="A_result_unmarshallAction"
        [Multiplicity("1..*")][Ordered]
        IList<OutputPin> Result { get; }
        #endregion
        #region P:UnmarshallType:Classifier
        /// <summary>
        /// The type of the <see cref="Object"/> to be unmarshalled.
        /// </summary>
        /// xmi:id="UnmarshallAction-unmarshallType"
        /// xmi:association="A_unmarshallType_unmarshallAction"
        Classifier UnmarshallType { get;set; }
        #endregion
        }
    }

using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ReadLinkObjectEndAction"/> is an <see cref="Action"/> that retrieves an <see cref="End"/> <see cref="Object"/> from a link <see cref="Object"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The end <see cref="Property"/> must be an <see cref="Association"/> memberEnd.
    ///   <![CDATA[
    ///     end.association <> null
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndAction-property"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the object <see cref="InputPin"/> is 1..1.
    ///   <![CDATA[
    ///     object.is(1,1)
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndAction-multiplicity_of_object"
    /// </rule>
    /// <rule language="OCL">
    ///   The ends of the association must not be static.
    ///   <![CDATA[
    ///     end.association.memberEnd->forAll(e | not e.isStatic)
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndAction-ends_of_association"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the result <see cref="OutputPin"/> is the same as the type of the end <see cref="Property"/>.
    ///   <![CDATA[
    ///     result.type = end.type
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndAction-type_of_result"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the result <see cref="OutputPin"/> is 1..1.
    ///   <![CDATA[
    ///     result.is(1,1)
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndAction-multiplicity_of_result"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the object <see cref="InputPin"/> is the <see cref="AssociationClass"/> that owns the end <see cref="Property"/>.
    ///   <![CDATA[
    ///     object.type = end.association
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndAction-type_of_object"
    /// </rule>
    /// <rule language="OCL">
    ///   The association of the end must be an <see cref="AssociationClass"/>.
    ///   <![CDATA[
    ///     end.association.oclIsKindOf(AssociationClass)
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndAction-association_of_association"
    /// </rule>
    /// xmi:id="ReadLinkObjectEndAction"
    public interface ReadLinkObjectEndAction : Action
        {
        #region P:End:Property
        /// <summary>
        /// The <see cref="Association"/> <see cref="End"/> to be read.
        /// </summary>
        /// xmi:id="ReadLinkObjectEndAction-end"
        /// xmi:association="A_end_readLinkObjectEndAction"
        Property End { get; }
        #endregion
        #region P:Object:InputPin
        /// <summary>
        /// The <see cref="Input"/> pin from which the link <see cref="Object"/> is obtained.
        /// </summary>
        /// xmi:id="ReadLinkObjectEndAction-object"
        /// xmi:aggregation="composite"
        /// xmi:association="A_object_readLinkObjectEndAction"
        /// xmi:subsets="Action-input"
        InputPin Object { get; }
        #endregion
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> where the <see cref="Result"/> value is placed.
        /// </summary>
        /// xmi:id="ReadLinkObjectEndAction-result"
        /// xmi:aggregation="composite"
        /// xmi:association="A_result_readLinkObjectEndAction"
        /// xmi:subsets="Action-output"
        OutputPin Result { get; }
        #endregion
        }
    }

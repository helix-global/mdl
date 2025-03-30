using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ReadLinkObjectEndQualifierAction"/> is an <see cref="Action"/> that retrieves a <see cref="Qualifier"/> end value from a link <see cref="Object"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of the object <see cref="InputPin"/> is 1..1.
    ///   <![CDATA[
    ///     object.is(1,1)
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndQualifierAction-multiplicity_of_object"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the object <see cref="InputPin"/> is the <see cref="AssociationClass"/> that owns the <see cref="Association"/> end that has the given qualifier <see cref="Property"/>.
    ///   <![CDATA[
    ///     object.type = qualifier.associationEnd.association
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndQualifierAction-type_of_object"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the qualifier <see cref="Property"/> is 1..1.
    ///   <![CDATA[
    ///     qualifier.is(1,1)
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndQualifierAction-multiplicity_of_qualifier"
    /// </rule>
    /// <rule language="OCL">
    ///   The ends of the <see cref="Association"/> must not be static.
    ///   <![CDATA[
    ///     qualifier.associationEnd.association.memberEnd->forAll(e | not e.isStatic)
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndQualifierAction-ends_of_association"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the result <see cref="OutputPin"/> is 1..1.
    ///   <![CDATA[
    ///     result.is(1,1)
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndQualifierAction-multiplicity_of_result"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the result <see cref="OutputPin"/> is the same as the type of the qualifier <see cref="Property"/>.
    ///   <![CDATA[
    ///     result.type = qualifier.type
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndQualifierAction-same_type"
    /// </rule>
    /// <rule language="OCL">
    ///   The association of the <see cref="Association"/> end of the qualifier <see cref="Property"/> must be an <see cref="AssociationClass"/>.
    ///   <![CDATA[
    ///     qualifier.associationEnd.association.oclIsKindOf(AssociationClass)
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndQualifierAction-association_of_association"
    /// </rule>
    /// <rule language="OCL">
    ///   The qualifier <see cref="Property"/> must be a qualifier of an <see cref="Association"/> end.
    ///   <![CDATA[
    ///     qualifier.associationEnd <> null
    ///   ]]>
    ///   xmi:id="ReadLinkObjectEndQualifierAction-qualifier_attribute"
    /// </rule>
    /// xmi:id="ReadLinkObjectEndQualifierAction"
    public interface ReadLinkObjectEndQualifierAction : Action
        {
        #region P:Object:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> from which the link <see cref="Object"/> is obtained.
        /// </summary>
        /// xmi:id="ReadLinkObjectEndQualifierAction-object"
        /// xmi:aggregation="composite"
        InputPin Object { get; }
        #endregion
        #region P:Qualifier:Property
        /// <summary>
        /// The <see cref="Qualifier"/> <see cref="Property"/> to be read.
        /// </summary>
        /// xmi:id="ReadLinkObjectEndQualifierAction-qualifier"
        Property Qualifier { get; }
        #endregion
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> where the <see cref="Result"/> value is placed.
        /// </summary>
        /// xmi:id="ReadLinkObjectEndQualifierAction-result"
        /// xmi:aggregation="composite"
        OutputPin Result { get; }
        #endregion
        }
    }

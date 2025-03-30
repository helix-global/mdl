using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="LinkEndData"/> is an <see cref="Element"/> that identifies on <see cref="End"/> of a link to be read or written by a <see cref="LinkAction"/>. As a link (that is not a link object) cannot be passed as a runtime <see cref="Value"/> to or from an <see cref="Action"/>, it is instead identified by its <see cref="End"/> objects and <see cref="Qualifier"/> values, if any. A <see cref="LinkEndData"/> instance provides these values for a single <see cref="Association"/> <see cref="End"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The type of the value <see cref="InputPin"/> conforms to the type of the <see cref="Association"/> end.
    ///   <![CDATA[
    ///     value<>null implies value.type.conformsTo(end.type)
    ///   ]]>
    ///   xmi:id="LinkEndData-same_type"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the value <see cref="InputPin"/> must be 1..1.
    ///   <![CDATA[
    ///     value<>null implies value.is(1,1)
    ///   ]]>
    ///   xmi:id="LinkEndData-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The value <see cref="InputPin"/> is not also the qualifier value <see cref="InputPin"/>.
    ///   <![CDATA[
    ///     value->excludesAll(qualifier.value)
    ///   ]]>
    ///   xmi:id="LinkEndData-end_object_input_pin"
    /// </rule>
    /// <rule language="OCL">
    ///   The <see cref="Property"/> must be an <see cref="Association"/> memberEnd.
    ///   <![CDATA[
    ///     end.association <> null
    ///   ]]>
    ///   xmi:id="LinkEndData-property_is_association_end"
    /// </rule>
    /// <rule language="OCL">
    ///   The qualifiers must be qualifiers of the <see cref="Association"/> end.
    ///   <![CDATA[
    ///     end.qualifier->includesAll(qualifier.qualifier)
    ///   ]]>
    ///   xmi:id="LinkEndData-qualifiers"
    /// </rule>
    /// xmi:id="LinkEndData"
    public interface LinkEndData : Element
        {
        #region P:End:Property
        /// <summary>
        /// The <see cref="Association"/> <see cref="End"/> for which this <see cref="LinkEndData"/> specifies values.
        /// </summary>
        /// xmi:id="LinkEndData-end"
        Property End { get; }
        #endregion
        #region P:Qualifier:QualifierValue[]
        /// <summary>
        /// A set of QualifierValues used to provide values for the qualifiers of the <see cref="End"/>.
        /// </summary>
        /// xmi:id="LinkEndData-qualifier"
        /// xmi:aggregation="composite"
        QualifierValue[] Qualifier { get; }
        #endregion
        #region P:Value:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that provides the specified <see cref="Value"/> for the given <see cref="End"/>. This <see cref="InputPin"/> is omitted if the <see cref="LinkEndData"/> specifies the "open" <see cref="End"/> for a <see cref="ReadLinkAction"/>.
        /// </summary>
        /// xmi:id="LinkEndData-value"
        InputPin Value { get; }
        #endregion

        #region M:allPins:InputPin[]
        /// <summary>
        /// Returns all the InputPins referenced by this <see cref="LinkEndData"/>. By default this includes the <see cref="Value"/> and <see cref="Qualifier"/> InputPins, but subclasses may override the operation to add other InputPins.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (value->asBag()->union(qualifier.value))
        ///   ]]>
        ///   xmi:id="LinkEndData-allPins-spec"
        /// </rule>
        /// xmi:id="LinkEndData-allPins"
        /// xmi:is-query="true"
        InputPin[] allPins();
        #endregion
        }
    }

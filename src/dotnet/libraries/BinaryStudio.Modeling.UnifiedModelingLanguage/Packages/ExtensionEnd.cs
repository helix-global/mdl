using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    using Integer=Int32;

    /// <summary>
    /// An extension <see cref="End"/> is used to tie an extension to a stereotype when extending a metaclass.
    /// The default multiplicity of an extension <see cref="End"/> is 0..1.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of <see cref="ExtensionEnd"/> is 0..1 or 1.
    ///   <![CDATA[
    ///     (lowerBound() = 0 or lowerBound() = 1) and upperBound() = 1
    ///   ]]>
    ///   xmi:id="ExtensionEnd-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The aggregation of an <see cref="ExtensionEnd"/> is composite.
    ///   <![CDATA[
    ///     self.aggregation = AggregationKind::composite
    ///   ]]>
    ///   xmi:id="ExtensionEnd-aggregation"
    /// </rule>
    /// xmi:id="ExtensionEnd"
    public interface ExtensionEnd : Property
        {
        #region P:Lower:Integer?
        /// <summary>
        /// This redefinition changes the default multiplicity of <see cref="Association"/> ends, since model elements are usually extended by 0 or 1 instance of the extension stereotype.
        /// </summary>
        /// xmi:id="ExtensionEnd-lower"
        /// xmi:is-derived="true"
        /// xmi:redefines="MultiplicityElement-lower{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.MultiplicityElement.Lower"/>}"
        Integer? Lower { get; }
        #endregion
        #region P:Type:Stereotype
        /// <summary>
        /// References the <see cref="Type"/> of the <see cref="ExtensionEnd"/>. Note that this <see cref="Association"/> restricts the possible types of an <see cref="ExtensionEnd"/> to only be Stereotypes.
        /// </summary>
        /// xmi:id="ExtensionEnd-type"
        /// xmi:association="A_type_extensionEnd"
        /// xmi:redefines="TypedElement-type{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.TypedElement.Type"/>}"
        Stereotype Type { get; }
        #endregion

        #region M:lowerBound:Integer?
        /// <summary>
        /// The query <see cref="lowerBound"/> returns the <see cref="Lower"/> bound of the multiplicity as an Integer. This is a redefinition of the default <see cref="Lower"/> bound, which normally, for MultiplicityElements, evaluates to 1 if empty.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if lowerValue=null then 0 else lowerValue.integerValue() endif)
        ///   ]]>
        ///   xmi:id="ExtensionEnd-lowerBound-spec"
        /// </rule>
        /// xmi:id="ExtensionEnd-lowerBound"
        /// xmi:is-query="true"
        /// xmi:redefines="MultiplicityElement-lowerBound{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.MultiplicityElement.lowerBound"/>}"
        Integer? lowerBound();
        #endregion
        }
    }

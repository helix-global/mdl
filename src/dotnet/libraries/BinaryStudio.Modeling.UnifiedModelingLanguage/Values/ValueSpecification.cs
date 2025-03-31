using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    using Integer=Int32;
    using Real=Double;

    /// <summary>
    /// A <see cref="ValueSpecification"/> is the specification of a (possibly empty) set of values. A <see cref="ValueSpecification"/> is a <see cref="ParameterableElement"/> that may be exposed as a formal <see cref="TemplateParameter"/> and provided as the actual parameter in the binding of a template.
    /// </summary>
    /// xmi:id="ValueSpecification"
    public interface ValueSpecification : TypedElement,PackageableElement
        {

        #region M:booleanValue:Boolean
        /// <summary>
        /// The query <see cref="booleanValue"/> gives a single Boolean value when one can be computed.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (null)
        ///   ]]>
        ///   xmi:id="ValueSpecification-booleanValue-spec"
        /// </rule>
        /// xmi:id="ValueSpecification-booleanValue"
        /// xmi:is-query="true"
        Boolean booleanValue();
        #endregion
        #region M:integerValue:Integer
        /// <summary>
        /// The query <see cref="integerValue"/> gives a single Integer value when one can be computed.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (null)
        ///   ]]>
        ///   xmi:id="ValueSpecification-integerValue-spec"
        /// </rule>
        /// xmi:id="ValueSpecification-integerValue"
        /// xmi:is-query="true"
        Integer integerValue();
        #endregion
        #region M:isCompatibleWith(ParameterableElement):Boolean
        /// <summary>
        /// The query <see cref="isCompatibleWith"/> determines if this <see cref="ValueSpecification"/> is compatible with the specified <see cref="ParameterableElement"/>. This <see cref="ValueSpecification"/> is compatible with <see cref="ParameterableElement"/> p if the kind of this <see cref="ValueSpecification"/> is the same as or a subtype of the kind of p. Further, if p is a <see cref="TypedElement"/>, then the <see cref="Type"/> of this <see cref="ValueSpecification"/> must be conformant with the <see cref="Type"/> of p.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.oclIsKindOf(p.oclType()) and (p.oclIsKindOf(TypedElement) implies 
        ///     self.type.conformsTo(p.oclAsType(TypedElement).type)))
        ///   ]]>
        ///   xmi:id="ValueSpecification-isCompatibleWith-spec"
        /// </rule>
        /// xmi:id="ValueSpecification-isCompatibleWith"
        /// xmi:is-query="true"
        /// xmi:redefines="ParameterableElement-isCompatibleWith{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ParameterableElement.isCompatibleWith"/>}"
        Boolean isCompatibleWith(ParameterableElement p);
        #endregion
        #region M:isComputable:Boolean
        /// <summary>
        /// The query <see cref="isComputable"/> determines whether a value specification can be computed in a model. This operation cannot be fully defined in OCL. A conforming implementation is expected to deliver true for this operation for all ValueSpecifications that it can compute, and to compute all of those for which the operation is true. A conforming implementation is expected to be able to compute at least the value of all LiteralSpecifications.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (false)
        ///   ]]>
        ///   xmi:id="ValueSpecification-isComputable-spec"
        /// </rule>
        /// xmi:id="ValueSpecification-isComputable"
        /// xmi:is-query="true"
        Boolean isComputable();
        #endregion
        #region M:isNull:Boolean
        /// <summary>
        /// The query <see cref="isNull"/> returns true when it can be computed that the value is null.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (false)
        ///   ]]>
        ///   xmi:id="ValueSpecification-isNull-spec"
        /// </rule>
        /// xmi:id="ValueSpecification-isNull"
        /// xmi:is-query="true"
        Boolean isNull();
        #endregion
        #region M:realValue:Real
        /// <summary>
        /// The query <see cref="realValue"/> gives a single Real value when one can be computed.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (null)
        ///   ]]>
        ///   xmi:id="ValueSpecification-realValue-spec"
        /// </rule>
        /// xmi:id="ValueSpecification-realValue"
        /// xmi:is-query="true"
        Real realValue();
        #endregion
        #region M:stringValue:String
        /// <summary>
        /// The query <see cref="stringValue"/> gives a single String value when one can be computed.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (null)
        ///   ]]>
        ///   xmi:id="ValueSpecification-stringValue-spec"
        /// </rule>
        /// xmi:id="ValueSpecification-stringValue"
        /// xmi:is-query="true"
        String stringValue();
        #endregion
        #region M:unlimitedValue:UnlimitedNatural
        /// <summary>
        /// The query <see cref="unlimitedValue"/> gives a single UnlimitedNatural value when one can be computed.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (null)
        ///   ]]>
        ///   xmi:id="ValueSpecification-unlimitedValue-spec"
        /// </rule>
        /// xmi:id="ValueSpecification-unlimitedValue"
        /// xmi:is-query="true"
        UnlimitedNatural unlimitedValue();
        #endregion
        }
    }

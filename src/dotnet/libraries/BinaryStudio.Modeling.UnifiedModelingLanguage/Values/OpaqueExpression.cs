using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    using Integer=Int32;

    /// <summary>
    /// An <see cref="OpaqueExpression"/> is a <see cref="ValueSpecification"/> that specifies the computation of a collection of values either in terms of a UML <see cref="Behavior"/> or based on a textual statement in a <see cref="Language"/> other than UML
    /// </summary>
    /// <rule language="OCL">
    ///   If the language attribute is not empty, then the size of the body and language arrays must be the same.
    ///   <![CDATA[
    ///     language->notEmpty() implies (_'body'->size() = language->size())
    ///   ]]>
    ///   xmi:id="OpaqueExpression-language_body_size"
    /// </rule>
    /// <rule language="OCL">
    ///   The behavior must have exactly one return result parameter.
    ///   <![CDATA[
    ///     behavior <> null implies
    ///        behavior.ownedParameter->select(direction=ParameterDirectionKind::return)->size() = 1
    ///   ]]>
    ///   xmi:id="OpaqueExpression-one_return_result_parameter"
    /// </rule>
    /// <rule language="OCL">
    ///   The behavior may only have non-stream in or return parameters.
    ///   <![CDATA[
    ///     behavior <> null implies behavior.ownedParameter->forAll(not isStream and
    ///     (direction=ParameterDirectionKind::in or direction=ParameterDirectionKind::return))
    ///   ]]>
    ///   xmi:id="OpaqueExpression-only_in_or_return_parameters"
    /// </rule>
    /// xmi:id="OpaqueExpression"
    public interface OpaqueExpression : ValueSpecification
        {
        #region P:Behavior:Behavior
        /// <summary>
        /// Specifies the <see cref="Behavior"/> of the <see cref="OpaqueExpression"/> as a UML <see cref="Behavior"/>.
        /// </summary>
        /// xmi:id="OpaqueExpression-behavior"
        /// xmi:association="A_behavior_opaqueExpression"
        [Multiplicity("0..1")]
        Behavior Behavior { get; }
        #endregion
        #region P:Body:String[]
        /// <summary>
        /// A textual definition of the <see cref="Behavior"/> of the <see cref="OpaqueExpression"/>, possibly in multiple languages.
        /// </summary>
        /// xmi:id="OpaqueExpression-body"
        [Ordered]
        String[] Body { get; }
        #endregion
        #region P:Language:String[]
        /// <summary>
        /// Specifies the languages used to express the textual bodies of the <see cref="OpaqueExpression"/>.  Languages are matched to <see cref="Body"/> Strings by order. The interpretation of the <see cref="Body"/> depends on the languages. If the languages are unspecified, they may be implicit from the expression <see cref="Body"/> or the context.
        /// </summary>
        /// xmi:id="OpaqueExpression-language"
        [Ordered]
        String[] Language { get; }
        #endregion
        #region P:Result:Parameter
        /// <summary>
        /// If an <see cref="OpaqueExpression"/> is specified using a UML <see cref="Behavior"/>, then this refers to the single required return <see cref="Parameter"/> of that <see cref="Behavior"/>. When the <see cref="Behavior"/> completes execution, the values on this <see cref="Parameter"/> give the <see cref="Result"/> of evaluating the <see cref="OpaqueExpression"/>.
        /// </summary>
        /// xmi:id="OpaqueExpression-result"
        /// xmi:association="A_result_opaqueExpression"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Multiplicity("0..1")]
        Parameter Result { get; }
        #endregion

        #region M:isIntegral:Boolean
        /// <summary>
        /// The query <see cref="isIntegral"/> tells whether an expression is intended to produce an Integer.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (false)
        ///   ]]>
        ///   xmi:id="OpaqueExpression-isIntegral-spec"
        /// </rule>
        /// xmi:id="OpaqueExpression-isIntegral"
        /// xmi:is-query="true"
        Boolean isIntegral();
        #endregion
        #region M:isNonNegative:Boolean
        /// <summary>
        /// The query <see cref="isNonNegative"/> tells whether an integer expression has a non-negative value.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     self.isIntegral()
        ///   ]]>
        ///   xmi:id="OpaqueExpression-isNonNegative-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (false)
        ///   ]]>
        ///   xmi:id="OpaqueExpression-isNonNegative-spec"
        /// </rule>
        /// xmi:id="OpaqueExpression-isNonNegative"
        /// xmi:is-query="true"
        Boolean isNonNegative();
        #endregion
        #region M:isPositive:Boolean
        /// <summary>
        /// The query <see cref="isPositive"/> tells whether an integer expression has a positive value.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (false)
        ///   ]]>
        ///   xmi:id="OpaqueExpression-isPositive-spec"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     self.isIntegral()
        ///   ]]>
        ///   xmi:id="OpaqueExpression-isPositive-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// xmi:id="OpaqueExpression-isPositive"
        /// xmi:is-query="true"
        Boolean isPositive();
        #endregion
        #region M:result:Parameter
        /// <summary>
        /// Derivation for <see cref="OpaqueExpression"/>::/<see cref="Result"/> 
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if behavior = null then
        ///     	null
        ///     else
        ///     	behavior.ownedParameter->first()
        ///     endif)
        ///   ]]>
        ///   xmi:id="OpaqueExpression-result.1-spec"
        /// </rule>
        /// xmi:id="OpaqueExpression-result.1"
        /// xmi:is-query="true"
        Parameter result();
        #endregion
        #region M:value:Integer
        /// <summary>
        /// The query <see cref="value"/> gives an integer value for an expression intended to produce one.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     self.isIntegral()
        ///   ]]>
        ///   xmi:id="OpaqueExpression-value-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (0)
        ///   ]]>
        ///   xmi:id="OpaqueExpression-value-spec"
        /// </rule>
        /// xmi:id="OpaqueExpression-value"
        /// xmi:is-query="true"
        Integer value();
        #endregion
        }
    }

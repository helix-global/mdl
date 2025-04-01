using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    using Integer=Int32;

    /// <summary>
    /// A multiplicity is a definition of an inclusive interval of non-negative integers beginning with a <see cref="Lower"/> bound and ending with a (possibly infinite) <see cref="Upper"/> bound. A <see cref="MultiplicityElement"/> embeds this information to specify the allowable cardinalities for an instantiation of the <see cref="Element"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The upper bound must be greater than or equal to the lower bound.
    ///   <![CDATA[
    ///     upperBound() >= lowerBound()
    ///   ]]>
    ///   xmi:id="MultiplicityElement-upper_ge_lower"
    /// </rule>
    /// <rule language="OCL">
    ///   The lower bound must be a non-negative integer literal.
    ///   <![CDATA[
    ///     lowerBound() >= 0
    ///   ]]>
    ///   xmi:id="MultiplicityElement-lower_ge_0"
    /// </rule>
    /// <rule language="">
    ///   If a non-literal <see cref="ValueSpecification"/> is used for lowerValue or upperValue, then evaluating that specification must not have side effects.
    ///   xmi:id="MultiplicityElement-value_specification_no_side_effects"
    /// </rule>
    /// <rule language="">
    ///   If a non-literal <see cref="ValueSpecification"/> is used for lowerValue or upperValue, then that specification must be a constant expression.
    ///   xmi:id="MultiplicityElement-value_specification_constant"
    /// </rule>
    /// <rule language="OCL">
    ///   If it is not empty, then lowerValue must have an Integer value.
    ///   <![CDATA[
    ///     lowerValue <> null implies lowerValue.integerValue() <> null
    ///   ]]>
    ///   xmi:id="MultiplicityElement-lower_is_integer"
    /// </rule>
    /// <rule language="OCL">
    ///   If it is not empty, then upperValue must have an UnlimitedNatural value.
    ///   <![CDATA[
    ///     upperValue <> null implies upperValue.unlimitedValue() <> null
    ///   ]]>
    ///   xmi:id="MultiplicityElement-upper_is_unlimitedNatural"
    /// </rule>
    /// xmi:id="MultiplicityElement"
    public interface MultiplicityElement : Element
        {
        #region P:IsOrdered:Boolean
        /// <summary>
        /// For a multivalued multiplicity, this attribute specifies whether the values in an instantiation of this <see cref="MultiplicityElement"/> are sequentially ordered.
        /// </summary>
        /// xmi:id="MultiplicityElement-isOrdered"
        Boolean IsOrdered { get;set; }
        #endregion
        #region P:IsUnique:Boolean
        /// <summary>
        /// For a multivalued multiplicity, this attributes specifies whether the values in an instantiation of this <see cref="MultiplicityElement"/> are unique.
        /// </summary>
        /// xmi:id="MultiplicityElement-isUnique"
        Boolean IsUnique { get;set; }
        #endregion
        #region P:Lower:Integer
        /// <summary>
        /// The <see cref="Lower"/> bound of the multiplicity interval.
        /// </summary>
        /// xmi:id="MultiplicityElement-lower"
        /// xmi:is-derived="true"
        Integer Lower { get;set; }
        #endregion
        #region P:LowerValue:ValueSpecification
        /// <summary>
        /// The specification of the <see cref="Lower"/> bound for this multiplicity.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="MultiplicityElement-lowerValue"
        /// xmi:aggregation="composite"
        /// xmi:association="A_lowerValue_owningLower"
        [Multiplicity("0..1")]
        ValueSpecification LowerValue { get;set; }
        #endregion
        #region P:Upper:UnlimitedNatural
        /// <summary>
        /// The <see cref="Upper"/> bound of the multiplicity interval.
        /// </summary>
        /// xmi:id="MultiplicityElement-upper"
        /// xmi:is-derived="true"
        UnlimitedNatural Upper { get;set; }
        #endregion
        #region P:UpperValue:ValueSpecification
        /// <summary>
        /// The specification of the <see cref="Upper"/> bound for this multiplicity.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="MultiplicityElement-upperValue"
        /// xmi:aggregation="composite"
        /// xmi:association="A_upperValue_owningUpper"
        [Multiplicity("0..1")]
        ValueSpecification UpperValue { get;set; }
        #endregion

        #region M:compatibleWith(MultiplicityElement):Boolean
        /// <summary>
        /// The operation compatibleWith takes another multiplicity as input. It returns true if the other multiplicity is wider than, or the same as, self.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = ((other.lowerBound() <= self.lowerBound()) and ((other.upperBound() = *) or (self.upperBound() <= other.upperBound())))
        ///   ]]>
        ///   xmi:id="MultiplicityElement-compatibleWith-spec"
        /// </rule>
        /// xmi:id="MultiplicityElement-compatibleWith"
        /// xmi:is-query="true"
        Boolean compatibleWith(MultiplicityElement other);
        #endregion
        #region M:includesMultiplicity(MultiplicityElement):Boolean
        /// <summary>
        /// The query <see cref="includesMultiplicity"/> checks whether this multiplicity includes all the cardinalities allowed by the specified multiplicity.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     self.upperBound()->notEmpty() and self.lowerBound()->notEmpty() and M.upperBound()->notEmpty() and M.lowerBound()->notEmpty()
        ///   ]]>
        ///   xmi:id="MultiplicityElement-includesMultiplicity-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = ((self.lowerBound() <= M.lowerBound()) and (self.upperBound() >= M.upperBound()))
        ///   ]]>
        ///   xmi:id="MultiplicityElement-includesMultiplicity-spec"
        /// </rule>
        /// xmi:id="MultiplicityElement-includesMultiplicity"
        /// xmi:is-query="true"
        Boolean includesMultiplicity(MultiplicityElement M);
        #endregion
        #region M:is(Integer,UnlimitedNatural):Boolean
        /// <summary>
        /// The operation is determines if the <see cref="Upper"/> and <see cref="Lower"/> bound of the ranges are the ones given.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (lowerbound = self.lowerBound() and upperbound = self.upperBound())
        ///   ]]>
        ///   xmi:id="MultiplicityElement-is-spec"
        /// </rule>
        /// xmi:id="MultiplicityElement-is"
        /// xmi:is-query="true"
        Boolean @is(Integer lowerbound,UnlimitedNatural upperbound);
        #endregion
        #region M:isMultivalued:Boolean
        /// <summary>
        /// The query <see cref="isMultivalued"/> checks whether this multiplicity has an <see cref="Upper"/> bound greater than one.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     upperBound()->notEmpty()
        ///   ]]>
        ///   xmi:id="MultiplicityElement-isMultivalued-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (upperBound() > 1)
        ///   ]]>
        ///   xmi:id="MultiplicityElement-isMultivalued-spec"
        /// </rule>
        /// xmi:id="MultiplicityElement-isMultivalued"
        /// xmi:is-query="true"
        Boolean isMultivalued();
        #endregion
        #region M:lower:Integer?
        /// <summary>
        /// The derived <see cref="Lower"/> attribute must equal the lowerBound.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (lowerBound())
        ///   ]]>
        ///   xmi:id="MultiplicityElement-lower.1-spec"
        /// </rule>
        /// xmi:id="MultiplicityElement-lower.1"
        /// xmi:is-query="true"
        Integer? lower();
        #endregion
        #region M:lowerBound:Integer
        /// <summary>
        /// The query <see cref="lowerBound"/> returns the <see cref="Lower"/> bound of the multiplicity as an integer, which is the integerValue of <see cref="LowerValue"/>, if this is given, and 1 otherwise.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if (lowerValue=null or lowerValue.integerValue()=null) then 1 else lowerValue.integerValue() endif)
        ///   ]]>
        ///   xmi:id="MultiplicityElement-lowerBound-spec"
        /// </rule>
        /// xmi:id="MultiplicityElement-lowerBound"
        /// xmi:is-query="true"
        Integer lowerBound();
        #endregion
        #region M:upper:UnlimitedNatural?
        /// <summary>
        /// The derived <see cref="Upper"/> attribute must equal the upperBound.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (upperBound())
        ///   ]]>
        ///   xmi:id="MultiplicityElement-upper.1-spec"
        /// </rule>
        /// xmi:id="MultiplicityElement-upper.1"
        /// xmi:is-query="true"
        UnlimitedNatural? upper();
        #endregion
        #region M:upperBound:UnlimitedNatural
        /// <summary>
        /// The query <see cref="upperBound"/> returns the <see cref="Upper"/> bound of the multiplicity for a bounded multiplicity as an unlimited natural, which is the unlimitedNaturalValue of <see cref="UpperValue"/>, if given, and 1, otherwise.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if (upperValue=null or upperValue.unlimitedValue()=null) then 1 else upperValue.unlimitedValue() endif)
        ///   ]]>
        ///   xmi:id="MultiplicityElement-upperBound-spec"
        /// </rule>
        /// xmi:id="MultiplicityElement-upperBound"
        /// xmi:is-query="true"
        UnlimitedNatural upperBound();
        #endregion
        }
    }

using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="StringExpression"/> is an <see cref="Expression"/> that specifies a String value that is derived by concatenating a sequence of operands with String values or a sequence of subExpressions, some of which might be template parameters.
    /// </summary>
    /// <rule language="OCL">
    ///   All the operands of a <see cref="StringExpression"/> must be LiteralStrings
    ///   <![CDATA[
    ///     operand->forAll (oclIsKindOf (LiteralString))
    ///   ]]>
    ///   xmi:id="StringExpression-operands"
    /// </rule>
    /// <rule language="OCL">
    ///   If a <see cref="StringExpression"/> has sub-expressions, it cannot have operands and vice versa (this avoids the problem of having to define a collating sequence between operands and subexpressions).
    ///   <![CDATA[
    ///     if subExpression->notEmpty() then operand->isEmpty() else operand->notEmpty() endif
    ///   ]]>
    ///   xmi:id="StringExpression-subexpressions"
    /// </rule>
    /// xmi:id="StringExpression"
    public interface StringExpression : Expression,TemplateableElement
        {
        #region P:OwningExpression:StringExpression
        /// <summary>
        /// The <see cref="StringExpression"/> of which this <see cref="StringExpression"/> is a <see cref="SubExpression"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.Owner"/>"
        /// </summary>
        /// xmi:id="StringExpression-owningExpression"
        /// xmi:association="A_subExpression_owningExpression"
        [Multiplicity("0..1")]
        StringExpression OwningExpression { get; }
        #endregion
        #region P:SubExpression:StringExpression[]
        /// <summary>
        /// The StringExpressions that constitute this <see cref="StringExpression"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="StringExpression-subExpression"
        /// xmi:aggregation="composite"
        /// xmi:association="A_subExpression_owningExpression"
        [Ordered]
        StringExpression[] SubExpression { get; }
        #endregion

        #region M:stringValue:String
        /// <summary>
        /// The query <see cref="stringValue"/> returns the String resulting from concatenating, in order, all the component String values of all the operands or subExpressions that are part of the <see cref="StringExpression"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ValueSpecification.stringValue"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if subExpression->notEmpty()
        ///     then subExpression->iterate(se; stringValue: String = '' | stringValue.concat(se.stringValue()))
        ///     else operand->iterate(op; stringValue: String = '' | stringValue.concat(op.stringValue()))
        ///     endif)
        ///   ]]>
        ///   xmi:id="StringExpression-stringValue-spec"
        /// </rule>
        /// xmi:id="StringExpression-stringValue"
        /// xmi:is-query="true"
        String stringValue();
        #endregion
        }
    }

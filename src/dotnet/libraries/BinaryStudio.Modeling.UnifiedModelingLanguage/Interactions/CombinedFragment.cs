using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="CombinedFragment"/> defines an expression of InteractionFragments. A <see cref="CombinedFragment"/> is defined by an interaction operator and corresponding InteractionOperands. Through the use of CombinedFragments the user will be able to describe a number of traces in a compact and concise manner.
    /// </summary>
    /// <rule language="OCL">
    ///   If the interactionOperator is break, the corresponding <see cref="InteractionOperand"/> must cover all Lifelines covered by the enclosing <see cref="InteractionFragment"/>.
    ///   <![CDATA[
    ///     interactionOperator=InteractionOperatorKind::break  implies   
    ///     enclosingInteraction.oclAsType(InteractionFragment)->asSet()->union(
    ///        enclosingOperand.oclAsType(InteractionFragment)->asSet()).covered->asSet() = self.covered->asSet()
    ///   ]]>
    ///   xmi:id="CombinedFragment-break"
    /// </rule>
    /// <rule language="OCL">
    ///   The interaction operators 'consider' and 'ignore' can only be used for the <see cref="ConsiderIgnoreFragment"/> subtype of <see cref="CombinedFragment"/>
    ///   <![CDATA[
    ///     ((interactionOperator = InteractionOperatorKind::consider) or (interactionOperator =  InteractionOperatorKind::ignore)) implies oclIsKindOf(ConsiderIgnoreFragment)
    ///   ]]>
    ///   xmi:id="CombinedFragment-consider_and_ignore"
    /// </rule>
    /// <rule language="OCL">
    ///   If the interactionOperator is opt, loop, break, assert or neg, there must be exactly one operand.
    ///   <![CDATA[
    ///     (interactionOperator =  InteractionOperatorKind::opt or interactionOperator = InteractionOperatorKind::loop or
    ///     interactionOperator = InteractionOperatorKind::break or interactionOperator = InteractionOperatorKind::assert or
    ///     interactionOperator = InteractionOperatorKind::neg)
    ///     implies operand->size()=1
    ///   ]]>
    ///   xmi:id="CombinedFragment-opt_loop_break_neg"
    /// </rule>
    /// xmi:id="CombinedFragment"
    public interface CombinedFragment : InteractionFragment
        {
        #region P:CfragmentGate:Gate[]
        /// <summary>
        /// Specifies the gates that form the interface between this <see cref="CombinedFragment"/> and its surroundings
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="CombinedFragment-cfragmentGate"
        /// xmi:aggregation="composite"
        /// xmi:association="A_cfragmentGate_combinedFragment"
        Gate[] CfragmentGate { get; }
        #endregion
        #region P:InteractionOperator:InteractionOperatorKind
        /// <summary>
        /// Specifies the operation which defines the semantics of this combination of InteractionFragments.
        /// </summary>
        /// xmi:id="CombinedFragment-interactionOperator"
        InteractionOperatorKind InteractionOperator { get; }
        #endregion
        #region P:Operand:InteractionOperand[]
        /// <summary>
        /// The set of operands of the combined fragment.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="CombinedFragment-operand"
        /// xmi:aggregation="composite"
        /// xmi:association="A_operand_combinedFragment"
        [Multiplicity("1..*")][Ordered]
        InteractionOperand[] Operand { get; }
        #endregion
        }
    }

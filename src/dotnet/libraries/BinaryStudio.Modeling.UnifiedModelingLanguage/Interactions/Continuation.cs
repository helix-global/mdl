using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Continuation"/> is a syntactic way to define continuations of different branches of an alternative <see cref="CombinedFragment"/>. Continuations are intuitively similar to labels representing intermediate points in a flow of control.
    /// </summary>
    /// <rule language="OCL">
    ///   Continuations always occur as the very first <see cref="InteractionFragment"/> or the very last <see cref="InteractionFragment"/> of the enclosing <see cref="InteractionOperand"/>.
    ///   <![CDATA[
    ///      enclosingOperand->notEmpty() and 
    ///      let peerFragments : OrderedSet(InteractionFragment) =  enclosingOperand.fragment in 
    ///        ( peerFragments->notEmpty() and 
    ///        ((peerFragments->first() = self) or  (peerFragments->last() = self)))
    ///   ]]>
    ///   xmi:id="Continuation-first_or_last_interaction_fragment"
    /// </rule>
    /// <rule language="OCL">
    ///   Across all <see cref="Interaction"/> instances having the same context value, every <see cref="Lifeline"/> instance covered by a <see cref="Continuation"/> (self) must be common with one covered <see cref="Lifeline"/> instance of all other <see cref="Continuation"/> instances with the same name as self, and every <see cref="Lifeline"/> instance covered by a <see cref="Continuation"/> instance with the same name as self must be common with one covered <see cref="Lifeline"/> instance of self. <see cref="Lifeline"/> instances are common if they have the same selector and represents associationEnd values.
    ///   <![CDATA[
    ///     enclosingOperand.combinedFragment->notEmpty() and
    ///     let parentInteraction : Set(Interaction) = 
    ///     enclosingOperand.combinedFragment->closure(enclosingOperand.combinedFragment)->
    ///     collect(enclosingInteraction).oclAsType(Interaction)->asSet()
    ///     in 
    ///     (parentInteraction->size() = 1) 
    ///     and let peerInteractions : Set(Interaction) =
    ///      (parentInteraction->union(parentInteraction->collect(_'context')->collect(behavior)->
    ///      select(oclIsKindOf(Interaction)).oclAsType(Interaction)->asSet())->asSet()) in
    ///      (peerInteractions->notEmpty()) and 
    ///       let combinedFragments1 : Set(CombinedFragment) = peerInteractions.fragment->
    ///      select(oclIsKindOf(CombinedFragment)).oclAsType(CombinedFragment)->asSet() in
    ///        combinedFragments1->notEmpty() and  combinedFragments1->closure(operand.fragment->
    ///        select(oclIsKindOf(CombinedFragment)).oclAsType(CombinedFragment))->asSet().operand.fragment->
    ///        select(oclIsKindOf(Continuation)).oclAsType(Continuation)->asSet()->
    ///        forAll(c : Continuation |  (c.name = self.name) implies 
    ///       (c.covered->asSet()->forAll(cl : Lifeline | --  cl must be common to one lifeline covered by self
    ///       self.covered->asSet()->
    ///       select(represents = cl.represents and selector = cl.selector)->asSet()->size()=1))
    ///        and
    ///      (self.covered->asSet()->forAll(cl : Lifeline | --  cl must be common to one lifeline covered by c
    ///      c.covered->asSet()->
    ///       select(represents = cl.represents and selector = cl.selector)->asSet()->size()=1))
    ///       )
    ///   ]]>
    ///   xmi:id="Continuation-same_name"
    /// </rule>
    /// <rule language="OCL">
    ///   Continuations are always global in the enclosing <see cref="InteractionFragment"/> e.g., it always covers all Lifelines covered by the enclosing InteractionOperator.
    ///   <![CDATA[
    ///     enclosingOperand->notEmpty() and
    ///       let operandLifelines : Set(Lifeline) =  enclosingOperand.covered in 
    ///         (operandLifelines->notEmpty() and 
    ///         operandLifelines->forAll(ol :Lifeline |self.covered->includes(ol)))
    ///   ]]>
    ///   xmi:id="Continuation-global"
    /// </rule>
    /// xmi:id="Continuation"
    public interface Continuation : InteractionFragment
        {
        #region P:Setting:Boolean
        /// <summary>
        /// True: when the <see cref="Continuation"/> is at the end of the enclosing <see cref="InteractionFragment"/> and False when it is in the beginning.
        /// </summary>
        /// xmi:id="Continuation-setting"
        Boolean Setting { get;set; }
        #endregion
        }
    }

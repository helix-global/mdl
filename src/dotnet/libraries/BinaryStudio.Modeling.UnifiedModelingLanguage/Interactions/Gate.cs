using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Gate"/> is a <see cref="MessageEnd"/> which serves as a connection point for relating a <see cref="Message"/> which has a <see cref="MessageEnd"/> (sendEvent / receiveEvent) outside an <see cref="InteractionFragment"/> with another <see cref="Message"/> which has a <see cref="MessageEnd"/> (receiveEvent / sendEvent)  inside that <see cref="InteractionFragment"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   If this <see cref="Gate"/> is an actualGate, it must have exactly one matching formalGate within the referred <see cref="Interaction"/>.
    ///   <![CDATA[
    ///     interactionUse->notEmpty() implies interactionUse.refersTo.formalGate->select(matches(self))->size()=1
    ///   ]]>
    ///   xmi:id="Gate-actual_gate_matched"
    /// </rule>
    /// <rule language="OCL">
    ///   If this <see cref="Gate"/> is inside a <see cref="CombinedFragment"/>, it must have exactly one matching <see cref="Gate"/> which is outside of that <see cref="CombinedFragment"/>.
    ///   <![CDATA[
    ///     isInsideCF() implies combinedFragment.cfragmentGate->select(isOutsideCF() and matches(self))->size()=1
    ///   ]]>
    ///   xmi:id="Gate-inside_cf_matched"
    /// </rule>
    /// <rule language="OCL">
    ///   If this <see cref="Gate"/> is outside an 'alt' <see cref="CombinedFragment"/>,  for every InteractionOperator inside that <see cref="CombinedFragment"/> there must be exactly one matching <see cref="Gate"/> inside the CombindedFragment with its opposing end enclosed by that InteractionOperator. If this <see cref="Gate"/> is outside <see cref="CombinedFragment"/> with operator other than 'alt',   there must be exactly one matching <see cref="Gate"/> inside that <see cref="CombinedFragment"/>.
    ///   <![CDATA[
    ///     isOutsideCF() implies
    ///      if self.combinedFragment.interactionOperator->asOrderedSet()->first() = InteractionOperatorKind::alt
    ///      then self.combinedFragment.operand->forAll(op : InteractionOperand |
    ///      self.combinedFragment.cfragmentGate->select(isInsideCF() and 
    ///      oppositeEnd().enclosingFragment()->includes(self.combinedFragment) and matches(self))->size()=1)
    ///      else  self.combinedFragment.cfragmentGate->select(isInsideCF() and matches(self))->size()=1
    ///      endif
    ///   ]]>
    ///   xmi:id="Gate-outside_cf_matched"
    /// </rule>
    /// <rule language="OCL">
    ///   isFormal() implies that no other formalGate of the parent <see cref="Interaction"/> returns the same getName() as returned for self
    ///   <![CDATA[
    ///     isFormal() implies interaction.formalGate->select(getName() = self.getName())->size()=1
    ///   ]]>
    ///   xmi:id="Gate-formal_gate_distinguishable"
    /// </rule>
    /// <rule language="OCL">
    ///   isActual() implies that no other actualGate of the parent <see cref="InteractionUse"/> returns the same getName() as returned for self
    ///   <![CDATA[
    ///     isActual() implies interactionUse.actualGate->select(getName() = self.getName())->size()=1
    ///   ]]>
    ///   xmi:id="Gate-actual_gate_distinguishable"
    /// </rule>
    /// <rule language="OCL">
    ///   isOutsideCF() implies that no other outside cfragmentGate of the parent <see cref="CombinedFragment"/> returns the same getName() as returned for self
    ///   <![CDATA[
    ///     isOutsideCF() implies combinedFragment.cfragmentGate->select(getName() = self.getName())->size()=1
    ///   ]]>
    ///   xmi:id="Gate-outside_cf_gate_distinguishable"
    /// </rule>
    /// <rule language="OCL">
    ///   isInsideCF() implies that no other inside cfragmentGate attached to a message with its other end in the same InteractionOperator as self, returns the same getName() as returned for self
    ///   <![CDATA[
    ///     isInsideCF() implies
    ///     let selfOperand : InteractionOperand = self.getOperand() in
    ///       combinedFragment.cfragmentGate->select(isInsideCF() and getName() = self.getName())->select(getOperand() = selfOperand)->size()=1
    ///   ]]>
    ///   xmi:id="Gate-inside_cf_gate_distinguishable"
    /// </rule>
    /// xmi:id="Gate"
    public interface Gate : MessageEnd
        {

        #region M:getName:String
        /// <summary>
        /// This query returns the <see cref="Name"/> of the gate, either the explicit <see cref="Name"/> (.<see cref="Name"/>) or the constructed <see cref="Name"/> ('out_" or 'in_' concatenated in front of .<see cref="Message"/>.<see cref="Name"/>) if the explicit <see cref="Name"/> is not present.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if name->notEmpty() then name->asOrderedSet()->first()
        ///     else  if isActual() or isOutsideCF() 
        ///       then if isSend() 
        ///         then 'out_'.concat(self.message.name->asOrderedSet()->first())
        ///         else 'in_'.concat(self.message.name->asOrderedSet()->first())
        ///         endif
        ///       else if isSend()
        ///         then 'in_'.concat(self.message.name->asOrderedSet()->first())
        ///         else 'out_'.concat(self.message.name->asOrderedSet()->first())
        ///         endif
        ///       endif
        ///     endif)
        ///   ]]>
        ///   xmi:id="Gate-getName-spec"
        /// </rule>
        /// xmi:id="Gate-getName"
        /// xmi:is-query="true"
        String getName();
        #endregion
        #region M:getOperand:InteractionOperand
        /// <summary>
        /// If the <see cref="Gate"/> is an inside Combined Fragment <see cref="Gate"/>, this operation returns the <see cref="InteractionOperand"/> that the opposite end of this <see cref="Gate"/> is included within.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if isInsideCF() then
        ///       let oppEnd : MessageEnd = self.oppositeEnd()->asOrderedSet()->first() in
        ///         if oppEnd.oclIsKindOf(MessageOccurrenceSpecification)
        ///         then let oppMOS : MessageOccurrenceSpecification = oppEnd.oclAsType(MessageOccurrenceSpecification)
        ///             in oppMOS.enclosingOperand->asOrderedSet()->first()
        ///         else let oppGate : Gate = oppEnd.oclAsType(Gate)
        ///             in oppGate.combinedFragment.enclosingOperand->asOrderedSet()->first()
        ///         endif
        ///       else null
        ///     endif)
        ///   ]]>
        ///   xmi:id="Gate-getOperand-spec"
        /// </rule>
        /// xmi:id="Gate-getOperand"
        /// xmi:is-query="true"
        InteractionOperand getOperand();
        #endregion
        #region M:isActual:Boolean
        /// <summary>
        /// This query returns true value if this <see cref="Gate"/> is an actualGate of an <see cref="InteractionUse"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (interactionUse->notEmpty())
        ///   ]]>
        ///   xmi:id="Gate-isActual-spec"
        /// </rule>
        /// xmi:id="Gate-isActual"
        /// xmi:is-query="true"
        Boolean isActual();
        #endregion
        #region M:isDistinguishableFrom(NamedElement,Namespace):Boolean
        /// <summary>
        /// The query <see cref="isDistinguishableFrom"/> specifies that two Gates may coexist in the same <see cref="Namespace"/>, without an explicit <see cref="Name"/> property. The association end formalGate subsets <see cref="OwnedElement"/>, and since the <see cref="Gate"/> <see cref="Name"/> attribute
        /// is optional, it is allowed to have two formal gates without an explicit <see cref="Name"/>, but having derived names which are distinct.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.isDistinguishableFrom"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (true)
        ///   ]]>
        ///   xmi:id="Gate-isDistinguishableFrom-spec"
        /// </rule>
        /// xmi:id="Gate-isDistinguishableFrom"
        /// xmi:is-query="true"
        Boolean isDistinguishableFrom(NamedElement n,Namespace ns);
        #endregion
        #region M:isFormal:Boolean
        /// <summary>
        /// This query returns true if this <see cref="Gate"/> is a formalGate of an <see cref="Interaction"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <p>interaction-&gt;notEmpty()</p>
        ///   <![CDATA[
        ///     result = (interaction->notEmpty())
        ///   ]]>
        ///   xmi:id="Gate-isFormal-spec"
        /// </rule>
        /// xmi:id="Gate-isFormal"
        /// xmi:is-query="true"
        Boolean isFormal();
        #endregion
        #region M:isInsideCF:Boolean
        /// <summary>
        /// This query returns true if this <see cref="Gate"/> is attached to the boundary of a <see cref="CombinedFragment"/>, and its other end (if present) is inside of an InteractionOperator of the same <see cref="CombinedFragment"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.oppositeEnd()-> notEmpty() and combinedFragment->notEmpty() implies
        ///     let oppEnd : MessageEnd = self.oppositeEnd()->asOrderedSet()->first() in
        ///     if oppEnd.oclIsKindOf(MessageOccurrenceSpecification)
        ///     then let oppMOS : MessageOccurrenceSpecification
        ///     = oppEnd.oclAsType(MessageOccurrenceSpecification)
        ///     in combinedFragment = oppMOS.enclosingOperand.combinedFragment
        ///     else let oppGate : Gate = oppEnd.oclAsType(Gate)
        ///     in combinedFragment = oppGate.combinedFragment.enclosingOperand.combinedFragment
        ///     endif)
        ///   ]]>
        ///   xmi:id="Gate-isInsideCF-spec"
        /// </rule>
        /// xmi:id="Gate-isInsideCF"
        /// xmi:is-query="true"
        Boolean isInsideCF();
        #endregion
        #region M:isOutsideCF:Boolean
        /// <summary>
        /// This query returns true if this <see cref="Gate"/> is attached to the boundary of a <see cref="CombinedFragment"/>, and its other end (if present)  is outside of the same <see cref="CombinedFragment"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.oppositeEnd()-> notEmpty() and combinedFragment->notEmpty() implies
        ///     let oppEnd : MessageEnd = self.oppositeEnd()->asOrderedSet()->first() in
        ///     if oppEnd.oclIsKindOf(MessageOccurrenceSpecification) 
        ///     then let oppMOS : MessageOccurrenceSpecification = oppEnd.oclAsType(MessageOccurrenceSpecification)
        ///     in  self.combinedFragment.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
        ///          union(self.combinedFragment.enclosingOperand.oclAsType(InteractionFragment)->asSet()) =
        ///          oppMOS.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
        ///          union(oppMOS.enclosingOperand.oclAsType(InteractionFragment)->asSet())
        ///     else let oppGate : Gate = oppEnd.oclAsType(Gate) 
        ///     in self.combinedFragment.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
        ///          union(self.combinedFragment.enclosingOperand.oclAsType(InteractionFragment)->asSet()) =
        ///          oppGate.combinedFragment.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
        ///          union(oppGate.combinedFragment.enclosingOperand.oclAsType(InteractionFragment)->asSet())
        ///     endif)
        ///   ]]>
        ///   xmi:id="Gate-isOutsideCF-spec"
        /// </rule>
        /// xmi:id="Gate-isOutsideCF"
        /// xmi:is-query="true"
        Boolean isOutsideCF();
        #endregion
        #region M:matches(Gate):Boolean
        /// <summary>
        /// This query returns true if the <see cref="Name"/> of this <see cref="Gate"/> matches the <see cref="Name"/> of the in parameter <see cref="Gate"/>, and the messages for the two Gates correspond. The <see cref="Message"/> for one <see cref="Gate"/> (say A) corresponds to the <see cref="Message"/> for another <see cref="Gate"/> (say B) if (A and B have the same <see cref="Name"/> value) and (if A is a sendEvent then B is a receiveEvent) and (if A is a receiveEvent then B is a sendEvent) and (A and B have the same messageSort value) and (A and B have the same signature value).
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.getName() = gateToMatch.getName() and 
        ///     self.message.messageSort = gateToMatch.message.messageSort and
        ///     self.message.name = gateToMatch.message.name and
        ///     self.message.sendEvent->includes(self) implies gateToMatch.message.receiveEvent->includes(gateToMatch)  and
        ///     self.message.receiveEvent->includes(self) implies gateToMatch.message.sendEvent->includes(gateToMatch) and
        ///     self.message.signature = gateToMatch.message.signature)
        ///   ]]>
        ///   xmi:id="Gate-matches-spec"
        /// </rule>
        /// xmi:id="Gate-matches"
        /// xmi:is-query="true"
        Boolean matches(Gate gateToMatch);
        #endregion
        }
    }

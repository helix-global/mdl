using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="MessageEnd"/> is an abstract specialization of <see cref="NamedElement"/> that represents what can occur at the end of a <see cref="Message"/>.
    /// </summary>
    /// xmi:id="MessageEnd"
    public interface MessageEnd : NamedElement
        {
        #region P:Message:Message
        /// <summary>
        /// References a <see cref="Message"/>.
        /// </summary>
        /// xmi:id="MessageEnd-message"
        /// xmi:association="A_message_messageEnd"
        [Multiplicity("0..1")]
        Message Message { get; }
        #endregion

        #region M:enclosingFragment:InteractionFragment[]
        /// <summary>
        /// This query returns a set including the enclosing <see cref="InteractionFragment"/> this <see cref="MessageEnd"/> is enclosed within.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if self->select(oclIsKindOf(Gate))->notEmpty() 
        ///     then -- it is a Gate
        ///     let endGate : Gate = 
        ///       self->select(oclIsKindOf(Gate)).oclAsType(Gate)->asOrderedSet()->first()
        ///       in
        ///       if endGate.isOutsideCF() 
        ///       then endGate.combinedFragment.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
        ///          union(endGate.combinedFragment.enclosingOperand.oclAsType(InteractionFragment)->asSet())
        ///       else if endGate.isInsideCF() 
        ///         then endGate.combinedFragment.oclAsType(InteractionFragment)->asSet()
        ///         else if endGate.isFormal() 
        ///           then endGate.interaction.oclAsType(InteractionFragment)->asSet()
        ///           else if endGate.isActual() 
        ///             then endGate.interactionUse.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
        ///          union(endGate.interactionUse.enclosingOperand.oclAsType(InteractionFragment)->asSet())
        ///             else null
        ///             endif
        ///           endif
        ///         endif
        ///       endif
        ///     else -- it is a MessageOccurrenceSpecification
        ///     let endMOS : MessageOccurrenceSpecification  = 
        ///       self->select(oclIsKindOf(MessageOccurrenceSpecification)).oclAsType(MessageOccurrenceSpecification)->asOrderedSet()->first() 
        ///       in
        ///       if endMOS.enclosingInteraction->notEmpty() 
        ///       then endMOS.enclosingInteraction.oclAsType(InteractionFragment)->asSet()
        ///       else endMOS.enclosingOperand.oclAsType(InteractionFragment)->asSet()
        ///       endif
        ///     endif)
        ///   ]]>
        ///   xmi:id="MessageEnd-enclosingFragment-spec"
        /// </rule>
        /// xmi:id="MessageEnd-enclosingFragment"
        /// xmi:is-query="true"
        InteractionFragment[] enclosingFragment();
        #endregion
        #region M:isReceive:Boolean
        /// <summary>
        /// This query returns value true if this <see cref="MessageEnd"/> is a receiveEvent.
        /// </summary>
        /// <rule language="OCL">
        ///   <p>message-&gt;notEmpty()</p>
        ///   <![CDATA[
        ///     message->notEmpty()
        ///     
        ///   ]]>
        ///   xmi:id="MessageEnd-isReceive-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (message.receiveEvent->asSet()->includes(self))
        ///   ]]>
        ///   xmi:id="MessageEnd-isReceive-spec"
        /// </rule>
        /// xmi:id="MessageEnd-isReceive"
        /// xmi:is-query="true"
        Boolean isReceive();
        #endregion
        #region M:isSend:Boolean
        /// <summary>
        /// This query returns value true if this <see cref="MessageEnd"/> is a sendEvent.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     message->notEmpty()
        ///     
        ///   ]]>
        ///   xmi:id="MessageEnd-isSend-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (message.sendEvent->asSet()->includes(self))
        ///   ]]>
        ///   xmi:id="MessageEnd-isSend-spec"
        /// </rule>
        /// xmi:id="MessageEnd-isSend"
        /// xmi:is-query="true"
        Boolean isSend();
        #endregion
        #region M:oppositeEnd:MessageEnd[]
        /// <summary>
        /// This query returns a set including the <see cref="MessageEnd"/> (if exists) at the opposite end of the <see cref="Message"/> for this <see cref="MessageEnd"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (message->asSet().messageEnd->asSet()->excluding(self))
        ///   ]]>
        ///   xmi:id="MessageEnd-oppositeEnd-spec"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     message->notEmpty()
        ///     
        ///   ]]>
        ///   xmi:id="MessageEnd-oppositeEnd-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// xmi:id="MessageEnd-oppositeEnd"
        /// xmi:is-query="true"
        MessageEnd[] oppositeEnd();
        #endregion
        }
    }

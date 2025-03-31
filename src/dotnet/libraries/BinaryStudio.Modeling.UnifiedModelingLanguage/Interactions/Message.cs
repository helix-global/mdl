using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Message"/> defines a particular communication between Lifelines of an <see cref="Interaction"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   If the sendEvent and the receiveEvent of the same <see cref="Message"/> are on the same <see cref="Lifeline"/>, the sendEvent must be ordered before the receiveEvent.
    ///   <![CDATA[
    ///     receiveEvent.oclIsKindOf(MessageOccurrenceSpecification)
    ///     implies
    ///     let f :  Lifeline = sendEvent->select(oclIsKindOf(MessageOccurrenceSpecification)).oclAsType(MessageOccurrenceSpecification)->asOrderedSet()->first().covered in
    ///     f = receiveEvent->select(oclIsKindOf(MessageOccurrenceSpecification)).oclAsType(MessageOccurrenceSpecification)->asOrderedSet()->first().covered  implies
    ///     f.events->indexOf(sendEvent.oclAsType(MessageOccurrenceSpecification)->asOrderedSet()->first() ) < 
    ///     f.events->indexOf(receiveEvent.oclAsType(MessageOccurrenceSpecification)->asOrderedSet()->first() )
    ///   ]]>
    ///   xmi:id="Message-sending_receiving_message_event"
    /// </rule>
    /// <rule language="">
    ///   Arguments of a <see cref="Message"/> must only be: i) attributes of the sending lifeline, ii) constants, iii) symbolic values (which are wildcard values representing any legal value), iv) explicit parameters of the enclosing <see cref="Interaction"/>, v) attributes of the class owning the <see cref="Interaction"/>.
    ///   xmi:id="Message-arguments"
    /// </rule>
    /// <rule language="OCL">
    ///   Messages cannot cross boundaries of CombinedFragments or their operands.  This is true if and only if both MessageEnds are enclosed within the same <see cref="InteractionFragment"/> (i.e., an <see cref="InteractionOperand"/> or an <see cref="Interaction"/>).
    ///   <![CDATA[
    ///     sendEvent->notEmpty() and receiveEvent->notEmpty() implies
    ///     let sendEnclosingFrag : Set(InteractionFragment) = 
    ///     sendEvent->asOrderedSet()->first().enclosingFragment()
    ///     in 
    ///     let receiveEnclosingFrag : Set(InteractionFragment) = 
    ///     receiveEvent->asOrderedSet()->first().enclosingFragment()
    ///     in  sendEnclosingFrag = receiveEnclosingFrag
    ///   ]]>
    ///   xmi:id="Message-cannot_cross_boundaries"
    /// </rule>
    /// <rule language="OCL">
    ///   In the case when the <see cref="Message"/> signature is a <see cref="Signal"/>, the arguments of the <see cref="Message"/> must correspond to the attributes of the <see cref="Signal"/>. A <see cref="Message"/> Argument corresponds to a <see cref="Signal"/> Attribute if the Argument is of the same <see cref="Class"/> or a specialization of that of the Attribute.
    ///   <![CDATA[
    ///     (messageSort = MessageSort::asynchSignal ) and signature.oclIsKindOf(Signal) implies
    ///        let signalAttributes : OrderedSet(Property) = signature.oclAsType(Signal).inheritedMember()->
    ///                  select(n:NamedElement | n.oclIsTypeOf(Property))->collect(oclAsType(Property))->asOrderedSet()
    ///        in signalAttributes->size() = self.argument->size()
    ///        and self.argument->forAll( o: ValueSpecification |
    ///               not (o.oclIsKindOf(Expression)
    ///               and o.oclAsType(Expression).symbol->size()=0
    ///               and o.oclAsType(Expression).operand->isEmpty() ) implies
    ///                   let p : Property = signalAttributes->at(self.argument->indexOf(o))
    ///                   in o.type.oclAsType(Classifier).conformsTo(p.type.oclAsType(Classifier)))
    ///     
    ///   ]]>
    ///   xmi:id="Message-signature_is_signal"
    /// </rule>
    /// <rule language="">
    ///   If the MessageEnds are both OccurrenceSpecifications, then the connector must go between the Parts represented by the Lifelines of the two MessageEnds.
    ///   xmi:id="Message-occurrence_specifications"
    /// </rule>
    /// <rule language="OCL">
    ///   The signature must either refer an <see cref="Operation"/> (in which case messageSort is either synchCall or asynchCall or reply) or a <see cref="Signal"/> (in which case messageSort is asynchSignal). The name of the <see cref="NamedElement"/> referenced by signature must be the same as that of the <see cref="Message"/>.
    ///   <![CDATA[
    ///     signature->notEmpty() implies 
    ///     ((signature.oclIsKindOf(Operation) and 
    ///     (messageSort = MessageSort::asynchCall or messageSort = MessageSort::synchCall or messageSort = MessageSort::reply) 
    ///     ) or (signature.oclIsKindOf(Signal)  and messageSort = MessageSort::asynchSignal )
    ///      ) and name = signature.name
    ///   ]]>
    ///   xmi:id="Message-signature_refer_to"
    /// </rule>
    /// <rule language="OCL">
    ///   In the case when a <see cref="Message"/> with messageSort synchCall or asynchCall has a non empty <see cref="Operation"/> signature, the arguments of the <see cref="Message"/> must correspond to the in and inout parameters of the <see cref="Operation"/>. A <see cref="Parameter"/> corresponds to an Argument if the Argument is of the same <see cref="Class"/> or a specialization of that of the <see cref="Parameter"/>.
    ///   <![CDATA[
    ///     (messageSort = MessageSort::asynchCall or messageSort = MessageSort::synchCall) and signature.oclIsKindOf(Operation)  implies 
    ///      let requestParms : OrderedSet(Parameter) = signature.oclAsType(Operation).ownedParameter->
    ///      select(direction = ParameterDirectionKind::inout or direction = ParameterDirectionKind::_'in'  )
    ///     in requestParms->size() = self.argument->size() and
    ///     self.argument->forAll( o: ValueSpecification | 
    ///     not (o.oclIsKindOf(Expression) and o.oclAsType(Expression).symbol->size()=0 and o.oclAsType(Expression).operand->isEmpty() ) implies 
    ///     let p : Parameter = requestParms->at(self.argument->indexOf(o)) in
    ///     o.type.oclAsType(Classifier).conformsTo(p.type.oclAsType(Classifier))
    ///     )
    ///   ]]>
    ///   xmi:id="Message-signature_is_operation_request"
    /// </rule>
    /// <rule language="OCL">
    ///   In the case when a <see cref="Message"/> with messageSort reply has a non empty <see cref="Operation"/> signature, the arguments of the <see cref="Message"/> must correspond to the out, inout, and return parameters of the <see cref="Operation"/>. A <see cref="Parameter"/> corresponds to an Argument if the Argument is of the same <see cref="Class"/> or a specialization of that of the <see cref="Parameter"/>.
    ///   <![CDATA[
    ///     (messageSort = MessageSort::reply) and signature.oclIsKindOf(Operation) implies 
    ///      let replyParms : OrderedSet(Parameter) = signature.oclAsType(Operation).ownedParameter->
    ///     select(direction = ParameterDirectionKind::inout or direction = ParameterDirectionKind::out or direction = ParameterDirectionKind::return)
    ///     in replyParms->size() = self.argument->size() and
    ///     self.argument->forAll( o: ValueSpecification | o.oclIsKindOf(Expression) and let e : Expression = o.oclAsType(Expression) in
    ///     e.operand->notEmpty()  implies 
    ///     let p : Parameter = replyParms->at(self.argument->indexOf(o)) in
    ///     e.operand->asSequence()->first().type.oclAsType(Classifier).conformsTo(p.type.oclAsType(Classifier))
    ///     )
    ///   ]]>
    ///   xmi:id="Message-signature_is_operation_reply"
    /// </rule>
    /// xmi:id="Message"
    public interface Message : NamedElement
        {
        #region P:Argument:ValueSpecification[]
        /// <summary>
        /// The arguments of the <see cref="Message"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Message-argument"
        /// xmi:aggregation="composite"
        /// xmi:association="A_argument_message"
        [Ordered]
        ValueSpecification[] Argument { get; }
        #endregion
        #region P:Connector:Connector
        /// <summary>
        /// The <see cref="Connector"/> on which this <see cref="Message"/> is sent.
        /// </summary>
        /// xmi:id="Message-connector"
        /// xmi:association="A_connector_message"
        [Multiplicity("0..1")]
        Connector Connector { get; }
        #endregion
        #region P:Interaction:Interaction
        /// <summary>
        /// The enclosing <see cref="Interaction"/> owning the <see cref="Message"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Message-interaction"
        /// xmi:association="A_message_interaction"
        Interaction Interaction { get; }
        #endregion
        #region P:MessageKind:MessageKind
        /// <summary>
        /// The derived kind of the <see cref="Message"/> (complete, lost, found, or unknown).
        /// </summary>
        /// xmi:id="Message-messageKind"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        MessageKind MessageKind { get; }
        #endregion
        #region P:MessageSort:MessageSort
        /// <summary>
        /// The sort of communication reflected by the <see cref="Message"/>.
        /// </summary>
        /// xmi:id="Message-messageSort"
        MessageSort MessageSort { get; }
        #endregion
        #region P:ReceiveEvent:MessageEnd
        /// <summary>
        /// References the Receiving of the <see cref="Message"/>.
        /// Subsets:
        /// </summary>
        /// xmi:id="Message-receiveEvent"
        /// xmi:association="A_receiveEvent_endMessage"
        /// xmi:subsets="A_message_messageEnd-messageEnd"
        [Multiplicity("0..1")]
        MessageEnd ReceiveEvent { get; }
        #endregion
        #region P:SendEvent:MessageEnd
        /// <summary>
        /// References the Sending of the <see cref="Message"/>.
        /// Subsets:
        /// </summary>
        /// xmi:id="Message-sendEvent"
        /// xmi:association="A_sendEvent_endMessage"
        /// xmi:subsets="A_message_messageEnd-messageEnd"
        [Multiplicity("0..1")]
        MessageEnd SendEvent { get; }
        #endregion
        #region P:Signature:NamedElement
        /// <summary>
        /// The <see cref="Signature"/> of the <see cref="Message"/> is the specification of its content. It refers either an <see cref="Operation"/> or a <see cref="Signal"/>.
        /// </summary>
        /// xmi:id="Message-signature"
        /// xmi:association="A_signature_message"
        [Multiplicity("0..1")]
        NamedElement Signature { get; }
        #endregion

        #region M:isDistinguishableFrom(NamedElement,Namespace):Boolean
        /// <summary>
        /// The query <see cref="isDistinguishableFrom"/> specifies that any two Messages may coexist in the same <see cref="Namespace"/>, regardless of their names.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.isDistinguishableFrom"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (true)
        ///   ]]>
        ///   xmi:id="Message-isDistinguishableFrom-spec"
        /// </rule>
        /// xmi:id="Message-isDistinguishableFrom"
        /// xmi:is-query="true"
        Boolean isDistinguishableFrom(NamedElement n,Namespace ns);
        #endregion
        #region M:messageKind:MessageKind
        /// <summary>
        /// This query returns the <see cref="MessageKind"/> value for this <see cref="Message"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (messageKind)
        ///   ]]>
        ///   xmi:id="Message-messageKind.1-spec"
        /// </rule>
        /// xmi:id="Message-messageKind.1"
        /// xmi:is-query="true"
        MessageKind messageKind();
        #endregion
        }
    }

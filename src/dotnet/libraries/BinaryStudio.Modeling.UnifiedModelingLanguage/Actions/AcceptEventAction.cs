using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="AcceptEventAction"/> is an <see cref="Action"/> that waits for the occurrence of one or more specific Events.
    /// </summary>
    /// <rule language="OCL">
    ///   If isUnmarshall=false and any of the triggers are for SignalEvents or TimeEvents, there must be exactly one result <see cref="OutputPin"/> with multiplicity 1..1.
    ///   <![CDATA[
    ///     not isUnmarshall and trigger->exists(event.oclIsKindOf(SignalEvent) or event.oclIsKindOf(TimeEvent)) implies 
    ///     	output->size() = 1 and output->first().is(1,1)
    ///   ]]>
    ///   xmi:id="AcceptEventAction-one_output_pin"
    /// </rule>
    /// <rule language="OCL">
    ///   AcceptEventActions may have no input pins.
    ///   <![CDATA[
    ///     input->size() = 0
    ///   ]]>
    ///   xmi:id="AcceptEventAction-no_input_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   There are no OutputPins if the trigger events are only ChangeEvents and/or CallEvents when this action is an instance of <see cref="AcceptEventAction"/> and not an instance of a descendant of <see cref="AcceptEventAction"/> (such as <see cref="AcceptCallAction"/>).
    ///   <![CDATA[
    ///     (self.oclIsTypeOf(AcceptEventAction) and
    ///        (trigger->forAll(event.oclIsKindOf(ChangeEvent) or  
    ///                                  event.oclIsKindOf(CallEvent))))
    ///     implies output->size() = 0
    ///   ]]>
    ///   xmi:id="AcceptEventAction-no_output_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   If isUnmarshall is true (and this is not an <see cref="AcceptCallAction"/>), there must be exactly one trigger, which is for a <see cref="SignalEvent"/>. The number of result output pins must be the same as the number of attributes of the signal. The type and ordering of each result output pin must be the same as the corresponding attribute of the signal. The multiplicity of each result output pin must be compatible with the multiplicity of the corresponding attribute.
    ///   <![CDATA[
    ///     isUnmarshall and self.oclIsTypeOf(AcceptEventAction) implies
    ///     	trigger->size()=1 and
    ///     	trigger->asSequence()->first().event.oclIsKindOf(SignalEvent) and
    ///     	let attribute: OrderedSet(Property) = trigger->asSequence()->first().event.oclAsType(SignalEvent).signal.allAttributes() in
    ///     	attribute->size()>0 and result->size() = attribute->size() and
    ///     	Sequence{1..result->size()}->forAll(i | 
    ///     		result->at(i).type = attribute->at(i).type and 
    ///     		result->at(i).isOrdered = attribute->at(i).isOrdered and
    ///     		result->at(i).includesMultiplicity(attribute->at(i)))
    ///   ]]>
    ///   xmi:id="AcceptEventAction-unmarshall_signal_events"
    /// </rule>
    /// <rule language="OCL">
    ///   If isUnmarshall=false and all the triggers are for SignalEvents, then the type of the single result <see cref="OutputPin"/> must either be null or all the signals must conform to it.
    ///   <![CDATA[
    ///     not isUnmarshall implies 
    ///     	result->isEmpty() or
    ///     	let type: Type = result->first().type in type=null or 
    ///     		(trigger->forAll(event.oclIsKindOf(SignalEvent)) and 
    ///     		 trigger.event.oclAsType(SignalEvent).signal->forAll(s | s.conformsTo(type)))
    ///   ]]>
    ///   xmi:id="AcceptEventAction-conforming_type"
    /// </rule>
    /// xmi:id="AcceptEventAction"
    public interface AcceptEventAction : Action
        {
        #region P:IsUnmarshall:Boolean
        /// <summary>
        /// Indicates whether there is a single <see cref="OutputPin"/> for a <see cref="SignalEvent"/> occurrence, or multiple OutputPins for attribute values of the instance of the <see cref="Signal"/> associated with a <see cref="SignalEvent"/> occurrence.
        /// </summary>
        /// xmi:id="AcceptEventAction-isUnmarshall"
        Boolean IsUnmarshall { get; }
        #endregion
        #region P:Result:OutputPin[]
        /// <summary>
        /// OutputPins holding the values received from an <see cref="Event"/> occurrence.
        /// </summary>
        /// xmi:id="AcceptEventAction-result"
        /// xmi:aggregation="composite"
        OutputPin[] Result { get; }
        #endregion
        #region P:Trigger:Trigger[]
        /// <summary>
        /// The Triggers specifying the Events of which the <see cref="AcceptEventAction"/> waits for occurrences.
        /// </summary>
        /// xmi:id="AcceptEventAction-trigger"
        /// xmi:aggregation="composite"
        Trigger[] Trigger { get; }
        #endregion
        }
    }

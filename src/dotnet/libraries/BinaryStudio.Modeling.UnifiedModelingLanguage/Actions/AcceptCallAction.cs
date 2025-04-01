using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="AcceptCallAction"/> is an <see cref="AcceptEventAction"/> that handles the receipt of a synchronous call request. In addition to the values from the <see cref="Operation"/> <see cref="Input"/> parameters, the <see cref="Action"/> produces an <see cref="Output"/> that is needed later to supply the information to the <see cref="ReplyAction"/> necessary to return control to the caller. An <see cref="AcceptCallAction"/> is for synchronous calls. If it is used to handle an asynchronous call, execution of the subsequent <see cref="ReplyAction"/> will complete immediately with no effect.
    /// </summary>
    /// <rule language="OCL">
    ///   The number of result OutputPins must be the same as the number of input (in and inout) ownedParameters of the <see cref="Operation"/> specified by the trigger <see cref="Event"/>. The type, ordering and multiplicity of each result <see cref="OutputPin"/> must be consistent with the corresponding input <see cref="Parameter"/>.
    ///   <![CDATA[
    ///     let parameter: OrderedSet(Parameter) = trigger.event->asSequence()->first().oclAsType(CallEvent).operation.inputParameters() in
    ///     result->size() = parameter->size() and
    ///     Sequence{1..result->size()}->forAll(i | 
    ///     	parameter->at(i).type.conformsTo(result->at(i).type) and 
    ///     	parameter->at(i).isOrdered = result->at(i).isOrdered and
    ///     	parameter->at(i).compatibleWith(result->at(i)))
    ///   ]]>
    ///   xmi:id="AcceptCallAction-result_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   The action must have exactly one trigger, which must be for a <see cref="CallEvent"/>.
    ///   <![CDATA[
    ///     trigger->size()=1 and
    ///     trigger->asSequence()->first().event.oclIsKindOf(CallEvent)
    ///     
    ///   ]]>
    ///   xmi:id="AcceptCallAction-trigger_call_event"
    /// </rule>
    /// <rule language="OCL">
    ///   isUnmrashall must be true for an <see cref="AcceptCallAction"/>.
    ///   <![CDATA[
    ///     isUnmarshall = true
    ///   ]]>
    ///   xmi:id="AcceptCallAction-unmarshall"
    /// </rule>
    /// xmi:id="AcceptCallAction"
    public interface AcceptCallAction : AcceptEventAction
        {
        #region P:ReturnInformation:OutputPin
        /// <summary>
        /// An <see cref="OutputPin"/> where a value is placed containing sufficient information to perform a subsequent <see cref="ReplyAction"/> and return control to the caller. The contents of this value are opaque. It can be passed and copied but it cannot be manipulated by the model.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Output"/>"
        /// </summary>
        /// xmi:id="AcceptCallAction-returnInformation"
        /// xmi:aggregation="composite"
        /// xmi:association="A_returnInformation_acceptCallAction"
        OutputPin ReturnInformation { get;set; }
        #endregion
        }
    }

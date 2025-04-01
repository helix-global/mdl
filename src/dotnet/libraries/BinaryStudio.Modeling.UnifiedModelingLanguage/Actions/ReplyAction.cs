using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ReplyAction"/> is an <see cref="Action"/> that accepts a set of reply values and a value containing return information produced by a previous <see cref="AcceptCallAction"/>. The <see cref="ReplyAction"/> returns the values to the caller of the previous call, completing execution of the call.
    /// </summary>
    /// <rule language="OCL">
    ///   The replyValue InputPins must match the output (return, out, and inout) parameters of the operation of the event of the replyToCall <see cref="Trigger"/> in number, type, ordering, and multiplicity.
    ///   <![CDATA[
    ///     let parameter:OrderedSet(Parameter) = replyToCall.event.oclAsType(CallEvent).operation.outputParameters() in
    ///     replyValue->size()=parameter->size() and
    ///     Sequence{1..replyValue->size()}->forAll(i |
    ///     	replyValue->at(i).type.conformsTo(parameter->at(i).type) and
    ///     	replyValue->at(i).isOrdered=parameter->at(i).isOrdered and
    ///     	replyValue->at(i).compatibleWith(parameter->at(i)))
    ///   ]]>
    ///   xmi:id="ReplyAction-pins_match_parameter"
    /// </rule>
    /// <rule language="OCL">
    ///   The event of the replyToCall <see cref="Trigger"/> must be a <see cref="CallEvent"/>.
    ///   <![CDATA[
    ///     replyToCall.event.oclIsKindOf(CallEvent)
    ///   ]]>
    ///   xmi:id="ReplyAction-event_on_reply_to_call_trigger"
    /// </rule>
    /// xmi:id="ReplyAction"
    public interface ReplyAction : Action
        {
        #region P:ReplyToCall:Trigger
        /// <summary>
        /// The <see cref="Trigger"/> specifying the <see cref="Operation"/> whose call is being replied to.
        /// </summary>
        /// xmi:id="ReplyAction-replyToCall"
        /// xmi:association="A_replyToCall_replyAction"
        Trigger ReplyToCall { get;set; }
        #endregion
        #region P:ReplyValue:IList<InputPin>
        /// <summary>
        /// A list of InputPins providing the values for the <see cref="Output"/> (inout, out, and return) Parameters of the <see cref="Operation"/>. These values are returned to the caller.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="ReplyAction-replyValue"
        /// xmi:aggregation="composite"
        /// xmi:association="A_replyValue_replyAction"
        [Ordered]
        IList<InputPin> ReplyValue { get; }
        #endregion
        #region P:ReturnInformation:InputPin
        /// <summary>
        /// An <see cref="InputPin"/> that holds the return information value produced by an earlier <see cref="AcceptCallAction"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="ReplyAction-returnInformation"
        /// xmi:aggregation="composite"
        /// xmi:association="A_returnInformation_replyAction"
        InputPin ReturnInformation { get;set; }
        #endregion
        }
    }

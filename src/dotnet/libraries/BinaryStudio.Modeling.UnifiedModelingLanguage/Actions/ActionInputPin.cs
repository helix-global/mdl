using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ActionInputPin"/> is a kind of <see cref="InputPin"/> that executes an <see cref="Action"/> to determine the values to input to another <see cref="Action"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The fromAction of an <see cref="ActionInputPin"/> must only have ActionInputPins as InputPins.
    ///   <![CDATA[
    ///     fromAction.input->forAll(oclIsKindOf(ActionInputPin))
    ///   ]]>
    ///   xmi:id="ActionInputPin-input_pin"
    /// </rule>
    /// <rule language="OCL">
    ///   The fromAction of an <see cref="ActionInputPin"/> must have exactly one <see cref="OutputPin"/>.
    ///   <![CDATA[
    ///     fromAction.output->size() = 1
    ///   ]]>
    ///   xmi:id="ActionInputPin-one_output_pin"
    /// </rule>
    /// <rule language="OCL">
    ///   The fromAction of an <see cref="ActionInputPin"/> cannot have ActivityEdges coming into or out of it or its Pins.
    ///   <![CDATA[
    ///     fromAction.incoming->union(outgoing)->isEmpty() and
    ///     fromAction.input.incoming->isEmpty() and
    ///     fromAction.output.outgoing->isEmpty()
    ///   ]]>
    ///   xmi:id="ActionInputPin-no_control_or_object_flow"
    /// </rule>
    /// xmi:id="ActionInputPin"
    public interface ActionInputPin : InputPin
        {
        #region P:FromAction:Action
        /// <summary>
        /// The <see cref="Action"/> used to provide the values of the <see cref="ActionInputPin"/>.
        /// </summary>
        /// xmi:id="ActionInputPin-fromAction"
        /// xmi:aggregation="composite"
        Action FromAction { get; }
        #endregion
        }
    }

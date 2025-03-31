using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="SendSignalAction"/> is an <see cref="InvocationAction"/> that creates a <see cref="Signal"/> instance and transmits it to the <see cref="Target"/> object. Values from the <see cref="Argument"/> InputPins are used to provide values for the attributes of the <see cref="Signal"/>. The requestor continues execution immediately after the <see cref="Signal"/> instance is sent out and cannot receive reply values.
    /// </summary>
    /// <rule language="OCL">
    ///   The type, ordering, and multiplicity of an argument <see cref="InputPin"/> must be the same as the corresponding attribute of the signal.
    ///   <![CDATA[
    ///     let attribute: OrderedSet(Property) = signal.allAttributes() in
    ///     Sequence{1..argument->size()}->forAll(i | 
    ///     	argument->at(i).type.conformsTo(attribute->at(i).type) and 
    ///     	argument->at(i).isOrdered = attribute->at(i).isOrdered and
    ///     	argument->at(i).compatibleWith(attribute->at(i)))
    ///   ]]>
    ///   xmi:id="SendSignalAction-type_ordering_multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The number and order of argument InputPins must be the same as the number and order of attributes of the signal.
    ///   <![CDATA[
    ///     argument->size()=signal.allAttributes()->size()
    ///   ]]>
    ///   xmi:id="SendSignalAction-number_order"
    /// </rule>
    /// <rule language="OCL">
    ///   If onPort is not empty, the <see cref="Port"/> given by onPort must be an owned or inherited feature of the type of the target <see cref="InputPin"/>.
    ///   <![CDATA[
    ///     not onPort->isEmpty() implies target.type.oclAsType(Classifier).allFeatures()->includes(onPort)
    ///     
    ///   ]]>
    ///   xmi:id="SendSignalAction-type_target_pin"
    /// </rule>
    /// xmi:id="SendSignalAction"
    public interface SendSignalAction : InvocationAction
        {
        #region P:Signal:Signal
        /// <summary>
        /// The <see cref="Signal"/> whose instance is transmitted to the <see cref="Target"/>.
        /// </summary>
        /// xmi:id="SendSignalAction-signal"
        /// xmi:association="A_signal_sendSignalAction"
        Signal Signal { get; }
        #endregion
        #region P:Target:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that provides the <see cref="Target"/> object to which the <see cref="Signal"/> instance is sent.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="SendSignalAction-target"
        /// xmi:aggregation="composite"
        /// xmi:association="A_target_sendSignalAction"
        InputPin Target { get; }
        #endregion
        }
    }

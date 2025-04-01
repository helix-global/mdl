using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="BroadcastSignalAction"/> is an <see cref="InvocationAction"/> that transmits a <see cref="Signal"/> instance to all the potential target objects in the system. Values from the <see cref="Argument"/> InputPins are used to provide values for the attributes of the <see cref="Signal"/>. The requestor continues execution immediately after the <see cref="Signal"/> instances are sent out and cannot receive reply values.
    /// </summary>
    /// <rule language="OCL">
    ///   The number of argument InputPins must be the same as the number of attributes in the signal.
    ///   <![CDATA[
    ///     argument->size() = signal.allAttributes()->size()
    ///   ]]>
    ///   xmi:id="BroadcastSignalAction-number_of_arguments"
    /// </rule>
    /// <rule language="OCL">
    ///   The type, ordering, and multiplicity of an argument <see cref="InputPin"/> must be the same as the corresponding attribute of the signal.
    ///   <![CDATA[
    ///     let attribute: OrderedSet(Property) = signal.allAttributes() in
    ///     Sequence{1..argument->size()}->forAll(i | 
    ///     	argument->at(i).type.conformsTo(attribute->at(i).type) and 
    ///     	argument->at(i).isOrdered = attribute->at(i).isOrdered and
    ///     	argument->at(i).compatibleWith(attribute->at(i)))
    ///   ]]>
    ///   xmi:id="BroadcastSignalAction-type_ordering_multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   A BroadcaseSignalAction may not specify onPort.
    ///   <![CDATA[
    ///     onPort=null
    ///   ]]>
    ///   xmi:id="BroadcastSignalAction-no_onport"
    /// </rule>
    /// xmi:id="BroadcastSignalAction"
    public interface BroadcastSignalAction : InvocationAction
        {
        #region P:Signal:Signal
        /// <summary>
        /// The <see cref="Signal"/> whose instances are to be sent.
        /// </summary>
        /// xmi:id="BroadcastSignalAction-signal"
        /// xmi:association="A_signal_broadcastSignalAction"
        Signal Signal { get;set; }
        #endregion
        }
    }

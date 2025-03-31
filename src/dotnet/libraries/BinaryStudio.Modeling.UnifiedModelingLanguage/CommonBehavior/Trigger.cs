using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Trigger"/> specifies a specific point  at which an <see cref="Event"/> occurrence may trigger an effect in a <see cref="Behavior"/>. A <see cref="Trigger"/> may be qualified by the <see cref="Port"/> on which the <see cref="Event"/> occurred.
    /// </summary>
    /// <rule language="OCL">
    ///   If a <see cref="Trigger"/> specifies one or more ports, the event of the <see cref="Trigger"/> must be a <see cref="MessageEvent"/>.
    ///   <![CDATA[
    ///     port->notEmpty() implies event.oclIsKindOf(MessageEvent)
    ///   ]]>
    ///   xmi:id="Trigger-trigger_with_ports"
    /// </rule>
    /// xmi:id="Trigger"
    public interface Trigger : NamedElement
        {
        #region P:Event:Event
        /// <summary>
        /// The <see cref="Event"/> that detected by the <see cref="Trigger"/>.
        /// </summary>
        /// xmi:id="Trigger-event"
        /// xmi:association="A_event_trigger"
        Event Event { get; }
        #endregion
        #region P:Port:Port[]
        /// <summary>
        /// A optional <see cref="Port"/> of through which the given effect is detected.
        /// </summary>
        /// xmi:id="Trigger-port"
        /// xmi:association="A_port_trigger"
        Port[] Port { get; }
        #endregion
        }
    }

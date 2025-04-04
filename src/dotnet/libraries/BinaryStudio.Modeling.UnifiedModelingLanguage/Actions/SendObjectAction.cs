﻿using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="SendObjectAction"/> is an <see cref="InvocationAction"/> that transmits an <see cref="Input"/> object to the <see cref="Target"/> object, which is handled as a <see cref="Request"/> message by the <see cref="Target"/> object. The requestor continues execution immediately after the object is sent out and cannot receive reply values.
    /// </summary>
    /// <rule language="OCL">
    ///   If onPort is not empty, the <see cref="Port"/> given by onPort must be an owned or inherited feature of the type of the target <see cref="InputPin"/>.
    ///   <![CDATA[
    ///     onPort<>null implies target.type.oclAsType(Classifier).allFeatures()->includes(onPort)
    ///   ]]>
    ///   xmi:id="SendObjectAction-type_target_pin"
    /// </rule>
    /// xmi:id="SendObjectAction"
    public interface SendObjectAction : InvocationAction
        {
        #region P:Request:InputPin
        /// <summary>
        /// The <see cref="Request"/> object, which is transmitted to the <see cref="Target"/> object. The object may be copied in transmission, so identity might not be preserved.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.InvocationAction.Argument"/>"
        /// </summary>
        /// xmi:id="SendObjectAction-request"
        /// xmi:aggregation="composite"
        /// xmi:association="A_request_sendObjectAction"
        InputPin Request { get;set; }
        #endregion
        #region P:Target:InputPin
        /// <summary>
        /// The <see cref="Target"/> object to which the object is sent.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="SendObjectAction-target"
        /// xmi:aggregation="composite"
        /// xmi:association="A_target_sendObjectAction"
        InputPin Target { get;set; }
        #endregion
        }
    }

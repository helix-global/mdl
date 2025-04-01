using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="OpaqueAction"/> is an <see cref="Action"/> whose functionality is not specified within UML.
    /// </summary>
    /// <rule language="OCL">
    ///   If the language attribute is not empty, then the size of the body and language lists must be the same.
    ///   <![CDATA[
    ///     language->notEmpty() implies (_'body'->size() = language->size())
    ///   ]]>
    ///   xmi:id="OpaqueAction-language_body_size"
    /// </rule>
    /// xmi:id="OpaqueAction"
    public interface OpaqueAction : Action
        {
        #region P:Body:IList<String>
        /// <summary>
        /// Provides a textual specification of the functionality of the <see cref="Action"/>, in one or more languages other than UML.
        /// </summary>
        /// xmi:id="OpaqueAction-body"
        [Ordered]
        IList<String> Body { get; }
        #endregion
        #region P:InputValue:IList<InputPin>
        /// <summary>
        /// The InputPins providing inputs to the <see cref="OpaqueAction"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="OpaqueAction-inputValue"
        /// xmi:aggregation="composite"
        /// xmi:association="A_inputValue_opaqueAction"
        IList<InputPin> InputValue { get; }
        #endregion
        #region P:Language:IList<String>
        /// <summary>
        /// If provided, a specification of the <see cref="Language"/> used for each of the <see cref="Body"/> Strings.
        /// </summary>
        /// xmi:id="OpaqueAction-language"
        [Ordered]
        IList<String> Language { get; }
        #endregion
        #region P:OutputValue:IList<OutputPin>
        /// <summary>
        /// The OutputPins on which the <see cref="OpaqueAction"/> provides outputs.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Output"/>"
        /// </summary>
        /// xmi:id="OpaqueAction-outputValue"
        /// xmi:aggregation="composite"
        /// xmi:association="A_outputValue_opaqueAction"
        IList<OutputPin> OutputValue { get; }
        #endregion
        }
    }

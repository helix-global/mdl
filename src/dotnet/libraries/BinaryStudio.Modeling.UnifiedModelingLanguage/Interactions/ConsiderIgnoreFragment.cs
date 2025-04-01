using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ConsiderIgnoreFragment"/> is a kind of <see cref="CombinedFragment"/> that is used for the consider and ignore cases, which require lists of pertinent Messages to be specified.
    /// </summary>
    /// <rule language="OCL">
    ///   The interaction operator of a <see cref="ConsiderIgnoreFragment"/> must be either 'consider' or 'ignore'.
    ///   <![CDATA[
    ///     (interactionOperator =  InteractionOperatorKind::consider) or (interactionOperator =  InteractionOperatorKind::ignore)
    ///   ]]>
    ///   xmi:id="ConsiderIgnoreFragment-consider_or_ignore"
    /// </rule>
    /// <rule language="OCL">
    ///   The NamedElements must be of a type of element that can be a signature for a message (i.e.., an <see cref="Operation"/>, or a <see cref="Signal"/>).
    ///   <![CDATA[
    ///     message->forAll(m | m.oclIsKindOf(Operation) or m.oclIsKindOf(Signal))
    ///   ]]>
    ///   xmi:id="ConsiderIgnoreFragment-type"
    /// </rule>
    /// xmi:id="ConsiderIgnoreFragment"
    public interface ConsiderIgnoreFragment : CombinedFragment
        {
        #region P:Message:IList<NamedElement>
        /// <summary>
        /// The set of messages that apply to this fragment.
        /// </summary>
        /// xmi:id="ConsiderIgnoreFragment-message"
        /// xmi:association="A_message_considerIgnoreFragment"
        IList<NamedElement> Message { get; }
        #endregion
        }
    }

using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="Interaction"/> is a unit of <see cref="Behavior"/> that focuses on the observable exchange of information between connectable elements.
    /// </summary>
    /// <rule language="OCL">
    ///   An <see cref="Interaction"/> instance must not be contained within another <see cref="Interaction"/> instance.
    ///   <![CDATA[
    ///     enclosingInteraction->isEmpty()
    ///   ]]>
    ///   xmi:id="Interaction-not_contained"
    /// </rule>
    /// xmi:id="Interaction"
    public interface Interaction : InteractionFragment,Behavior
        {
        #region P:Action:Action[]
        /// <summary>
        /// Actions owned by the <see cref="Interaction"/>.
        /// </summary>
        /// xmi:id="Interaction-action"
        /// xmi:aggregation="composite"
        /// xmi:association="A_action_interaction"
        /// xmi:subsets="Element-ownedElement"
        Action[] Action { get; }
        #endregion
        #region P:FormalGate:Gate[]
        /// <summary>
        /// Specifies the gates that form the <see cref="Message"/> interface between this <see cref="Interaction"/> and any InteractionUses which reference it.
        /// </summary>
        /// xmi:id="Interaction-formalGate"
        /// xmi:aggregation="composite"
        /// xmi:association="A_formalGate_interaction"
        /// xmi:subsets="Namespace-ownedMember"
        Gate[] FormalGate { get; }
        #endregion
        #region P:Fragment:InteractionFragment[]
        /// <summary>
        /// The ordered set of fragments in the <see cref="Interaction"/>.
        /// </summary>
        /// xmi:id="Interaction-fragment"
        /// xmi:aggregation="composite"
        /// xmi:association="A_fragment_enclosingInteraction"
        /// xmi:subsets="Namespace-ownedMember"
        [Ordered]
        InteractionFragment[] Fragment { get; }
        #endregion
        #region P:Lifeline:Lifeline[]
        /// <summary>
        /// Specifies the participants in this <see cref="Interaction"/>.
        /// </summary>
        /// xmi:id="Interaction-lifeline"
        /// xmi:aggregation="composite"
        /// xmi:association="A_lifeline_interaction"
        /// xmi:subsets="Namespace-ownedMember"
        Lifeline[] Lifeline { get; }
        #endregion
        #region P:Message:Message[]
        /// <summary>
        /// The Messages contained in this <see cref="Interaction"/>.
        /// </summary>
        /// xmi:id="Interaction-message"
        /// xmi:aggregation="composite"
        /// xmi:association="A_message_interaction"
        /// xmi:subsets="Namespace-ownedMember"
        Message[] Message { get; }
        #endregion
        }
    }

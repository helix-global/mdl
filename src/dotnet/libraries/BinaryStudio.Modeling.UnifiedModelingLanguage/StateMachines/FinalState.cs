using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A special kind of <see cref="State"/>, which, when entered, signifies that the enclosing <see cref="Region"/> has completed. If the enclosing <see cref="Region"/> is directly contained in a <see cref="StateMachine"/> and all other Regions in that <see cref="StateMachine"/> also are completed, then it means that the entire <see cref="StateMachine"/> behavior is completed.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="FinalState"/> has no exit <see cref="Behavior"/>.
    ///   <![CDATA[
    ///     exit->isEmpty()
    ///   ]]>
    ///   xmi:id="FinalState-no_exit_behavior"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="FinalState"/> cannot have any outgoing Transitions.
    ///   <![CDATA[
    ///     outgoing->size() = 0
    ///   ]]>
    ///   xmi:id="FinalState-no_outgoing_transitions"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="FinalState"/> cannot have Regions.
    ///   <![CDATA[
    ///     region->size() = 0
    ///   ]]>
    ///   xmi:id="FinalState-no_regions"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="FinalState"/> cannot reference a submachine.
    ///   <![CDATA[
    ///     submachine->isEmpty()
    ///   ]]>
    ///   xmi:id="FinalState-cannot_reference_submachine"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="FinalState"/> has no entry <see cref="Behavior"/>.
    ///   <![CDATA[
    ///     entry->isEmpty()
    ///   ]]>
    ///   xmi:id="FinalState-no_entry_behavior"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="FinalState"/> has no state (doActivity) <see cref="Behavior"/>.
    ///   <![CDATA[
    ///     doActivity->isEmpty()
    ///   ]]>
    ///   xmi:id="FinalState-no_state_behavior"
    /// </rule>
    /// xmi:id="FinalState"
    public interface FinalState : State
        {

        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <summary>
        /// The query <see cref="isConsistentWith"/> specifies a <see cref="FinalState"/> can only be redefined by a <see cref="FinalState"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     redefiningElement.isRedefinitionContextValid(self)
        ///   ]]>
        ///   xmi:id="FinalState-isConsistentWith-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = redefiningElement.oclIsKindOf(FinalState)
        ///   ]]>
        ///   xmi:id="FinalState-isConsistentWith-spec"
        /// </rule>
        /// xmi:id="FinalState-isConsistentWith"
        /// xmi:is-query=""
        /// xmi:redefines="RedefinableElement-isConsistentWith{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>}"
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        }
    }

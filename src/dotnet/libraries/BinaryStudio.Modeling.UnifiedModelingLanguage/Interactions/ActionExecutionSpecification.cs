using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ActionExecutionSpecification"/> is a kind of <see cref="ExecutionSpecification"/> representing the execution of an <see cref="Action"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The <see cref="Action"/> referenced by the <see cref="ActionExecutionSpecification"/> must be owned by the <see cref="Interaction"/> owning that <see cref="ActionExecutionSpecification"/>.
    ///   <![CDATA[
    ///     (enclosingInteraction->notEmpty() or enclosingOperand.combinedFragment->notEmpty()) and
    ///     let parentInteraction : Set(Interaction) = enclosingInteraction.oclAsType(Interaction)->asSet()->union(
    ///     enclosingOperand.combinedFragment->closure(enclosingOperand.combinedFragment)->
    ///     collect(enclosingInteraction).oclAsType(Interaction)->asSet()) in
    ///     (parentInteraction->size() = 1) and self.action.interaction->asSet() = parentInteraction
    ///   ]]>
    ///   xmi:id="ActionExecutionSpecification-action_referenced"
    /// </rule>
    /// xmi:id="ActionExecutionSpecification"
    public interface ActionExecutionSpecification : ExecutionSpecification
        {
        #region P:Action:Action
        /// <summary>
        /// <see cref="Action"/> whose execution is occurring.
        /// </summary>
        /// xmi:id="ActionExecutionSpecification-action"
        /// xmi:association="A_action_actionExecutionSpecification"
        Action Action { get;set; }
        #endregion
        }
    }

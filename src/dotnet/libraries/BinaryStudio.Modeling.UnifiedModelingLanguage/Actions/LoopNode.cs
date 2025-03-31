using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="LoopNode"/> is a <see cref="StructuredActivityNode"/> that represents an iterative loop with setup, <see cref="Test"/>, and body sections.
    /// </summary>
    /// <rule language="OCL">
    ///   The result OutputPins have no incoming edges.
    ///   <![CDATA[
    ///     result.incoming->isEmpty()
    ///   ]]>
    ///   xmi:id="LoopNode-result_no_incoming"
    /// </rule>
    /// <rule language="OCL">
    ///   The loopVariableInputs must not have outgoing edges.
    ///   <![CDATA[
    ///     loopVariableInput.outgoing->isEmpty()
    ///   ]]>
    ///   xmi:id="LoopNode-input_edges"
    /// </rule>
    /// <rule language="OCL">
    ///   The union of the ExecutableNodes in the setupPart, test and bodyPart of a <see cref="LoopNode"/> must be the same as the subset of nodes contained in the <see cref="LoopNode"/> (considered as a <see cref="StructuredActivityNode"/>) that are ExecutableNodes.
    ///   <![CDATA[
    ///     setupPart->union(test)->union(bodyPart)=node->select(oclIsKindOf(ExecutableNode)).oclAsType(ExecutableNode)->asSet()
    ///   ]]>
    ///   xmi:id="LoopNode-executable_nodes"
    /// </rule>
    /// <rule language="OCL">
    ///   The bodyOutput pins are OutputPins on Actions in the body of the <see cref="LoopNode"/>.
    ///   <![CDATA[
    ///     bodyPart.oclAsType(Action).allActions().output->includesAll(bodyOutput)
    ///   ]]>
    ///   xmi:id="LoopNode-body_output_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   The test and body parts of a <see cref="ConditionalNode"/> must be disjoint with each other.
    ///   <![CDATA[
    ///     setupPart->intersection(test)->isEmpty() and
    ///     setupPart->intersection(bodyPart)->isEmpty() and
    ///     test->intersection(bodyPart)->isEmpty()
    ///   ]]>
    ///   xmi:id="LoopNode-setup_test_and_body"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="LoopNode"/> must have the same number of bodyOutput Pins as loopVariables, and each bodyOutput <see cref="Pin"/> must be compatible with the corresponding loopVariable (by positional order) in type, multiplicity, ordering and uniqueness.
    ///   <![CDATA[
    ///     bodyOutput->size()=loopVariable->size() and
    ///     Sequence{1..loopVariable->size()}->forAll(i |
    ///     	bodyOutput->at(i).type.conformsTo(loopVariable->at(i).type) and
    ///     	bodyOutput->at(i).isOrdered = loopVariable->at(i).isOrdered and
    ///     	bodyOutput->at(i).isUnique = loopVariable->at(i).isUnique and
    ///     	loopVariable->at(i).includesMultiplicity(bodyOutput->at(i)))
    ///   ]]>
    ///   xmi:id="LoopNode-matching_output_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="LoopNode"/> must have the same number of loopVariableInputs and loopVariables, and they must match in type, uniqueness and multiplicity.
    ///   <![CDATA[
    ///     loopVariableInput->size()=loopVariable->size() and
    ///     loopVariableInput.type=loopVariable.type and
    ///     loopVariableInput.isUnique=loopVariable.isUnique and
    ///     loopVariableInput.lower=loopVariable.lower and
    ///     loopVariableInput.upper=loopVariable.upper
    ///   ]]>
    ///   xmi:id="LoopNode-matching_loop_variables"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="LoopNode"/> must have the same number of result OutputPins and loopVariables, and they must match in type, uniqueness and multiplicity.
    ///   <![CDATA[
    ///     result->size()=loopVariable->size() and
    ///     result.type=loopVariable.type and
    ///     result.isUnique=loopVariable.isUnique and
    ///     result.lower=loopVariable.lower and
    ///     result.upper=loopVariable.upper
    ///   ]]>
    ///   xmi:id="LoopNode-matching_result_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   All ActivityEdges outgoing from loopVariable OutputPins must have targets within the <see cref="LoopNode"/>.
    ///   <![CDATA[
    ///     allOwnedNodes()->includesAll(loopVariable.outgoing.target)
    ///   ]]>
    ///   xmi:id="LoopNode-loop_variable_outgoing"
    /// </rule>
    /// xmi:id="LoopNode"
    public interface LoopNode : StructuredActivityNode
        {
        #region P:BodyOutput:OutputPin[]
        /// <summary>
        /// The OutputPins on Actions within the <see cref="BodyPart"/>, the values of which are moved to the <see cref="LoopVariable"/> OutputPins after the completion of each execution of the <see cref="BodyPart"/>, before the next iteration of the loop begins or before the loop exits.
        /// </summary>
        /// xmi:id="LoopNode-bodyOutput"
        /// xmi:association="A_bodyOutput_loopNode"
        [Ordered]
        OutputPin[] BodyOutput { get; }
        #endregion
        #region P:BodyPart:ExecutableNode[]
        /// <summary>
        /// The set of ExecutableNodes that perform the repetitive computations of the loop. The <see cref="BodyPart"/> is executed as long as the <see cref="Test"/> section produces a true value.
        /// </summary>
        /// xmi:id="LoopNode-bodyPart"
        /// xmi:association="A_bodyPart_loopNode"
        ExecutableNode[] BodyPart { get; }
        #endregion
        #region P:Decider:OutputPin
        /// <summary>
        /// An <see cref="OutputPin"/> on an <see cref="Action"/> in the <see cref="Test"/> section whose Boolean value determines whether to continue executing the loop <see cref="BodyPart"/>.
        /// </summary>
        /// xmi:id="LoopNode-decider"
        /// xmi:association="A_decider_loopNode"
        OutputPin Decider { get; }
        #endregion
        #region P:IsTestedFirst:Boolean
        /// <summary>
        /// If true, the <see cref="Test"/> is performed before the first execution of the <see cref="BodyPart"/>. If false, the <see cref="BodyPart"/> is executed once before the <see cref="Test"/> is performed.
        /// </summary>
        /// xmi:id="LoopNode-isTestedFirst"
        Boolean IsTestedFirst { get; }
        #endregion
        #region P:LoopVariable:OutputPin[]
        /// <summary>
        /// A list of OutputPins that hold the values of the loop variables during an execution of the loop. When the <see cref="Test"/> fails, the values are moved to the <see cref="Result"/> OutputPins of the loop.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="LoopNode-loopVariable"
        /// xmi:aggregation="composite"
        /// xmi:association="A_loopVariable_loopNode"
        [Ordered]
        OutputPin[] LoopVariable { get; }
        #endregion
        #region P:LoopVariableInput:InputPin[]
        /// <summary>
        /// A list of InputPins whose values are moved into the <see cref="LoopVariable"/> Pins before the first iteration of the loop.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.StructuredActivityNode.StructuredNodeInput"/>"
        /// </summary>
        /// xmi:id="LoopNode-loopVariableInput"
        /// xmi:aggregation="composite"
        /// xmi:association="A_loopVariableInput_loopNode"
        [Ordered]
        InputPin[] LoopVariableInput { get; }
        #endregion
        #region P:Result:OutputPin[]
        /// <summary>
        /// A list of OutputPins that receive the <see cref="LoopVariable"/> values after the last iteration of the loop and constitute the <see cref="Output"/> of the <see cref="LoopNode"/>.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.StructuredActivityNode.StructuredNodeOutput"/>"
        /// </summary>
        /// xmi:id="LoopNode-result"
        /// xmi:aggregation="composite"
        /// xmi:association="A_result_loopNode"
        [Ordered]
        OutputPin[] Result { get; }
        #endregion
        #region P:SetupPart:ExecutableNode[]
        /// <summary>
        /// The set of ExecutableNodes executed before the first iteration of the loop, in order to initialize values or perform other setup computations.
        /// </summary>
        /// xmi:id="LoopNode-setupPart"
        /// xmi:association="A_setupPart_loopNode"
        ExecutableNode[] SetupPart { get; }
        #endregion
        #region P:Test:ExecutableNode[]
        /// <summary>
        /// The set of ExecutableNodes executed in order to provide the <see cref="Test"/> <see cref="Result"/> for the loop.
        /// </summary>
        /// xmi:id="LoopNode-test"
        /// xmi:association="A_test_loopNode"
        [Multiplicity("1..*")]
        ExecutableNode[] Test { get; }
        #endregion

        #region M:allActions:Action[]
        /// <summary>
        /// Return only this <see cref="LoopNode"/>. This prevents Actions within the <see cref="LoopNode"/> from having their OutputPins used as bodyOutputs or <see cref="Decider"/> Pins in containing LoopNodes or ConditionalNodes.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.allActions"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self->asSet())
        ///   ]]>
        ///   xmi:id="LoopNode-allActions-spec"
        /// </rule>
        /// xmi:id="LoopNode-allActions"
        /// xmi:is-query="true"
        Action[] allActions();
        #endregion
        #region M:sourceNodes:ActivityNode[]
        /// <summary>
        /// Return the <see cref="LoopVariable"/> OutputPins in addition to other source nodes for the <see cref="LoopNode"/> as a <see cref="StructuredActivityNode"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.StructuredActivityNode.sourceNodes"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.StructuredActivityNode::sourceNodes()->union(loopVariable))
        ///   ]]>
        ///   xmi:id="LoopNode-sourceNodes-spec"
        /// </rule>
        /// xmi:id="LoopNode-sourceNodes"
        /// xmi:is-query="true"
        ActivityNode[] sourceNodes();
        #endregion
        }
    }

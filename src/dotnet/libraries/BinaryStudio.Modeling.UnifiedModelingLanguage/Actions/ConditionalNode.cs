using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ConditionalNode"/> is a <see cref="StructuredActivityNode"/> that chooses one among some number of alternative collections of ExecutableNodes to execute.
    /// </summary>
    /// <rule language="OCL">
    ///   The result OutputPins have no incoming edges.
    ///   <![CDATA[
    ///     result.incoming->isEmpty()
    ///   ]]>
    ///   xmi:id="ConditionalNode-result_no_incoming"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="ConditionalNode"/> has no InputPins.
    ///   <![CDATA[
    ///     input->isEmpty()
    ///   ]]>
    ///   xmi:id="ConditionalNode-no_input_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   No <see cref="ExecutableNode"/> in the ConditionNode may appear in the test or body part of more than one clause of a <see cref="ConditionalNode"/>.
    ///   <![CDATA[
    ///     node->select(oclIsKindOf(ExecutableNode)).oclAsType(ExecutableNode)->forAll(n | 
    ///     	self.clause->select(test->union(_'body')->includes(n))->size()=1)
    ///   ]]>
    ///   xmi:id="ConditionalNode-one_clause_with_executable_node"
    /// </rule>
    /// <rule language="OCL">
    ///   Each clause of a <see cref="ConditionalNode"/> must have the same number of bodyOutput pins as the <see cref="ConditionalNode"/> has result OutputPins, and each clause bodyOutput <see cref="Pin"/> must be compatible with the corresponding result <see cref="OutputPin"/> (by positional order) in type, multiplicity, ordering, and uniqueness.
    ///   <![CDATA[
    ///     clause->forAll(
    ///     	bodyOutput->size()=self.result->size() and
    ///     	Sequence{1..self.result->size()}->forAll(i |
    ///     		bodyOutput->at(i).type.conformsTo(result->at(i).type) and
    ///     		bodyOutput->at(i).isOrdered = result->at(i).isOrdered and
    ///     		bodyOutput->at(i).isUnique = result->at(i).isUnique and
    ///     		bodyOutput->at(i).compatibleWith(result->at(i))))
    ///   ]]>
    ///   xmi:id="ConditionalNode-matching_output_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   The union of the ExecutableNodes in the test and body parts of all clauses must be the same as the subset of nodes contained in the <see cref="ConditionalNode"/> (considered as a <see cref="StructuredActivityNode"/>) that are ExecutableNodes.
    ///   <![CDATA[
    ///     clause.test->union(clause._'body') = node->select(oclIsKindOf(ExecutableNode)).oclAsType(ExecutableNode)
    ///   ]]>
    ///   xmi:id="ConditionalNode-executable_nodes"
    /// </rule>
    /// <rule language="OCL">
    ///   No two clauses within a <see cref="ConditionalNode"/> may be predecessorClauses of each other, either directly or indirectly.
    ///   <![CDATA[
    ///     clause->closure(predecessorClause)->intersection(clause)->isEmpty()
    ///   ]]>
    ///   xmi:id="ConditionalNode-clause_no_predecessor"
    /// </rule>
    /// xmi:id="ConditionalNode"
    public interface ConditionalNode : StructuredActivityNode
        {
        #region P:Clause:Clause[]
        /// <summary>
        /// The set of Clauses composing the <see cref="ConditionalNode"/>.
        /// </summary>
        /// xmi:id="ConditionalNode-clause"
        /// xmi:aggregation="composite"
        Clause[] Clause { get; }
        #endregion
        #region P:IsAssured:Boolean
        /// <summary>
        /// If true, the modeler asserts that the test for at least one <see cref="Clause"/> of the <see cref="ConditionalNode"/> will succeed.
        /// </summary>
        /// xmi:id="ConditionalNode-isAssured"
        Boolean IsAssured { get; }
        #endregion
        #region P:IsDeterminate:Boolean
        /// <summary>
        /// If true, the modeler asserts that the test for at most one <see cref="Clause"/> of the <see cref="ConditionalNode"/> will succeed.
        /// </summary>
        /// xmi:id="ConditionalNode-isDeterminate"
        Boolean IsDeterminate { get; }
        #endregion
        #region P:Result:OutputPin[]
        /// <summary>
        /// The OutputPins that onto which are moved values from the bodyOutputs of the <see cref="Clause"/> selected for execution.
        /// </summary>
        /// xmi:id="ConditionalNode-result"
        /// xmi:aggregation="composite"
        /// xmi:redefines="StructuredActivityNode-structuredNodeOutput{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.StructuredActivityNode.StructuredNodeOutput"/>}"
        OutputPin[] Result { get; }
        #endregion

        #region M:allActions:Action[]
        /// <summary>
        /// Return only this <see cref="ConditionalNode"/>. This prevents Actions within the <see cref="ConditionalNode"/> from having their OutputPins used as bodyOutputs or decider Pins in containing LoopNodes or ConditionalNodes.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self->asSet())
        ///   ]]>
        ///   xmi:id="ConditionalNode-allActions-spec"
        /// </rule>
        /// xmi:id="ConditionalNode-allActions"
        /// xmi:is-query="true"
        /// xmi:redefines="Action-allActions{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.allActions"/>}"
        Action[] allActions();
        #endregion
        }
    }

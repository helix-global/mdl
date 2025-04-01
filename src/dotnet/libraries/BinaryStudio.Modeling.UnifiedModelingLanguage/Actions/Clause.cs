using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Clause"/> is an <see cref="Element"/> that represents a single branch of a <see cref="ConditionalNode"/>, including a <see cref="Test"/> and a <see cref="Body"/> section. The <see cref="Body"/> section is executed only if (but not necessarily if) the <see cref="Test"/> section evaluates to true.
    /// </summary>
    /// <rule language="OCL">
    ///   The bodyOutput Pins are OutputPins on Actions in the body of the <see cref="Clause"/>.
    ///   <![CDATA[
    ///     _'body'.oclAsType(Action).allActions().output->includesAll(bodyOutput)
    ///   ]]>
    ///   xmi:id="Clause-body_output_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   The decider <see cref="Pin"/> must be on an <see cref="Action"/> in the test section of the <see cref="Clause"/> and must be of type Boolean with multiplicity 1..1.
    ///   <![CDATA[
    ///     test.oclAsType(Action).allActions().output->includes(decider) and
    ///     decider.type = Boolean and
    ///     decider.is(1,1)
    ///   ]]>
    ///   xmi:id="Clause-decider_output"
    /// </rule>
    /// <rule language="OCL">
    ///   The test and body parts of a <see cref="ConditionalNode"/> must be disjoint with each other.
    ///   <![CDATA[
    ///     test->intersection(_'body')->isEmpty()
    ///   ]]>
    ///   xmi:id="Clause-test_and_body"
    /// </rule>
    /// xmi:id="Clause"
    public interface Clause : Element
        {
        #region P:Body:IList<ExecutableNode>
        /// <summary>
        /// The set of ExecutableNodes that are executed if the <see cref="Test"/> evaluates to true and the <see cref="Clause"/> is chosen over other Clauses within the <see cref="ConditionalNode"/> that also have tests that evaluate to true.
        /// </summary>
        /// xmi:id="Clause-body"
        /// xmi:association="A_body_clause"
        IList<ExecutableNode> Body { get; }
        #endregion
        #region P:BodyOutput:IList<OutputPin>
        /// <summary>
        /// The OutputPins on Actions within the <see cref="Body"/> section whose values are moved to the result OutputPins of the containing <see cref="ConditionalNode"/> after execution of the <see cref="Body"/>.
        /// </summary>
        /// xmi:id="Clause-bodyOutput"
        /// xmi:association="A_bodyOutput_clause"
        [Ordered]
        IList<OutputPin> BodyOutput { get; }
        #endregion
        #region P:Decider:OutputPin
        /// <summary>
        /// An <see cref="OutputPin"/> on an <see cref="Action"/> in the <see cref="Test"/> section whose Boolean value determines the result of the <see cref="Test"/>.
        /// </summary>
        /// xmi:id="Clause-decider"
        /// xmi:association="A_decider_clause"
        OutputPin Decider { get;set; }
        #endregion
        #region P:PredecessorClause:IList<Clause>
        /// <summary>
        /// A set of Clauses whose tests must all evaluate to false before this <see cref="Clause"/> can evaluate its <see cref="Test"/>.
        /// </summary>
        /// xmi:id="Clause-predecessorClause"
        /// xmi:association="A_predecessorClause_successorClause"
        IList<Clause> PredecessorClause { get; }
        #endregion
        #region P:SuccessorClause:IList<Clause>
        /// <summary>
        /// A set of Clauses that may not evaluate their tests unless the <see cref="Test"/> for this <see cref="Clause"/> evaluates to false.
        /// </summary>
        /// xmi:id="Clause-successorClause"
        /// xmi:association="A_predecessorClause_successorClause"
        IList<Clause> SuccessorClause { get; }
        #endregion
        #region P:Test:IList<ExecutableNode>
        /// <summary>
        /// The set of ExecutableNodes that are executed in order to provide a <see cref="Test"/> result for the <see cref="Clause"/>.
        /// </summary>
        /// xmi:id="Clause-test"
        /// xmi:association="A_test_clause"
        [Multiplicity("1..*")]
        IList<ExecutableNode> Test { get; }
        #endregion
        }
    }

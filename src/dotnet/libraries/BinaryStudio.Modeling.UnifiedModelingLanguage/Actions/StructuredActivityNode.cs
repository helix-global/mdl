using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="StructuredActivityNode"/> is an <see cref="Action"/> that is also an <see cref="ActivityGroup"/> and whose behavior is specified by the ActivityNodes and ActivityEdges it so contains. Unlike other kinds of <see cref="ActivityGroup"/>, a <see cref="StructuredActivityNode"/> owns the ActivityNodes and ActivityEdges it contains, and so a <see cref="Node"/> or <see cref="Edge"/> can only be directly contained in one <see cref="StructuredActivityNode"/>, though StructuredActivityNodes may be nested.
    /// </summary>
    /// <rule language="OCL">
    ///   The outgoing ActivityEdges of the OutputPins of a <see cref="StructuredActivityNode"/> must have targets that are not within the <see cref="StructuredActivityNode"/>.
    ///   <![CDATA[
    ///     output.outgoing.target->excludesAll(allOwnedNodes()-input)
    ///   ]]>
    ///   xmi:id="StructuredActivityNode-output_pin_edges"
    /// </rule>
    /// <rule language="OCL">
    ///   The edges of a <see cref="StructuredActivityNode"/> are all the ActivityEdges with source and target ActivityNodes contained directly or indirectly within the <see cref="StructuredActivityNode"/> and at least one of the source or target not contained in any more deeply nested <see cref="StructuredActivityNode"/>.
    ///   <![CDATA[
    ///     edge=self.sourceNodes().outgoing->intersection(self.allOwnedNodes().incoming)->
    ///     	union(self.targetNodes().incoming->intersection(self.allOwnedNodes().outgoing))->asSet()
    ///   ]]>
    ///   xmi:id="StructuredActivityNode-edges"
    /// </rule>
    /// <rule language="OCL">
    ///   The incoming ActivityEdges of an <see cref="InputPin"/> of a <see cref="StructuredActivityNode"/> must have sources that are not within the <see cref="StructuredActivityNode"/>.
    ///   <![CDATA[
    ///     input.incoming.source->excludesAll(allOwnedNodes()-output)
    ///   ]]>
    ///   xmi:id="StructuredActivityNode-input_pin_edges"
    /// </rule>
    /// xmi:id="StructuredActivityNode"
    public interface StructuredActivityNode : Namespace,Action,ActivityGroup
        {
        #region P:Activity:Activity
        /// <summary>
        /// The <see cref="Activity"/> immediately containing the <see cref="StructuredActivityNode"/>, if it is not contained in another <see cref="StructuredActivityNode"/>.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.ActivityGroup.InActivity"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.ActivityNode.Activity"/>"
        /// </summary>
        /// xmi:id="StructuredActivityNode-activity"
        /// xmi:association="A_structuredNode_activity"
        [Multiplicity("0..1")]
        Activity Activity { get;set; }
        #endregion
        #region P:Edge:IList<ActivityEdge>
        /// <summary>
        /// The ActivityEdges immediately contained in the <see cref="StructuredActivityNode"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.ActivityGroup.ContainedEdge"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="StructuredActivityNode-edge"
        /// xmi:aggregation="composite"
        /// xmi:association="A_edge_inStructuredNode"
        IList<ActivityEdge> Edge { get; }
        #endregion
        #region P:MustIsolate:Boolean
        /// <summary>
        /// If true, then any object used by an <see cref="Action"/> within the <see cref="StructuredActivityNode"/> cannot be accessed by any <see cref="Action"/> outside the <see cref="Node"/> until the <see cref="StructuredActivityNode"/> as a whole completes. Any concurrent Actions that would result in accessing such objects are required to have their execution deferred until the completion of the <see cref="StructuredActivityNode"/>.
        /// 
        /// </summary>
        /// xmi:id="StructuredActivityNode-mustIsolate"
        Boolean MustIsolate { get;set; }
        #endregion
        #region P:Node:IList<ActivityNode>
        /// <summary>
        /// The ActivityNodes immediately contained in the <see cref="StructuredActivityNode"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.ActivityGroup.ContainedNode"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="StructuredActivityNode-node"
        /// xmi:aggregation="composite"
        /// xmi:association="A_node_inStructuredNode"
        IList<ActivityNode> Node { get; }
        #endregion
        #region P:StructuredNodeInput:IList<InputPin>
        /// <summary>
        /// The InputPins owned by the <see cref="StructuredActivityNode"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="StructuredActivityNode-structuredNodeInput"
        /// xmi:aggregation="composite"
        /// xmi:association="A_structuredNodeInput_structuredActivityNode"
        IList<InputPin> StructuredNodeInput { get; }
        #endregion
        #region P:StructuredNodeOutput:IList<OutputPin>
        /// <summary>
        /// The OutputPins owned by the <see cref="StructuredActivityNode"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Output"/>"
        /// </summary>
        /// xmi:id="StructuredActivityNode-structuredNodeOutput"
        /// xmi:aggregation="composite"
        /// xmi:association="A_structuredNodeOutput_structuredActivityNode"
        IList<OutputPin> StructuredNodeOutput { get; }
        #endregion
        #region P:Variable:IList<Variable>
        /// <summary>
        /// The Variables defined in the scope of the <see cref="StructuredActivityNode"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="StructuredActivityNode-variable"
        /// xmi:aggregation="composite"
        /// xmi:association="A_variable_scope"
        IList<Variable> Variable { get; }
        #endregion

        #region M:allActions:Action[]
        /// <summary>
        /// Returns this <see cref="StructuredActivityNode"/> and all Actions contained in it.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.allActions"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (node->select(oclIsKindOf(Action)).oclAsType(Action).allActions()->including(self)->asSet())
        ///   ]]>
        ///   xmi:id="StructuredActivityNode-allActions-spec"
        /// </rule>
        /// xmi:id="StructuredActivityNode-allActions"
        /// xmi:is-query="true"
        Action[] allActions();
        #endregion
        #region M:allOwnedNodes:ActivityNode[]
        /// <summary>
        /// Returns all the ActivityNodes contained directly or indirectly within this <see cref="StructuredActivityNode"/>, in addition to the Pins of the <see cref="StructuredActivityNode"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.allOwnedNodes"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.Action::allOwnedNodes()->union(node)->union(node->select(oclIsKindOf(Action)).oclAsType(Action).allOwnedNodes())->asSet())
        ///   ]]>
        ///   xmi:id="StructuredActivityNode-allOwnedNodes-spec"
        /// </rule>
        /// xmi:id="StructuredActivityNode-allOwnedNodes"
        /// xmi:is-query="true"
        ActivityNode[] allOwnedNodes();
        #endregion
        #region M:containingActivity:Activity
        /// <summary>
        /// The <see cref="Activity"/> that directly or indirectly contains this <see cref="StructuredActivityNode"/> (considered as an <see cref="Action"/>).
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ActivityGroup.containingActivity"/>"
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ActivityNode.containingActivity"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.Action::containingActivity())
        ///   ]]>
        ///   xmi:id="StructuredActivityNode-containingActivity-spec"
        /// </rule>
        /// xmi:id="StructuredActivityNode-containingActivity"
        /// xmi:is-query="true"
        [return: Multiplicity("0..1")]
        Activity containingActivity();
        #endregion
        #region M:sourceNodes:ActivityNode[]
        /// <summary>
        /// Return those ActivityNodes contained immediately within the <see cref="StructuredActivityNode"/> that may act as sources of edges owned by the <see cref="StructuredActivityNode"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (node->union(input.oclAsType(ActivityNode)->asSet())->
        ///       union(node->select(oclIsKindOf(Action)).oclAsType(Action).output)->asSet())
        ///   ]]>
        ///   xmi:id="StructuredActivityNode-sourceNodes-spec"
        /// </rule>
        /// xmi:id="StructuredActivityNode-sourceNodes"
        /// xmi:is-query="true"
        ActivityNode[] sourceNodes();
        #endregion
        #region M:targetNodes:ActivityNode[]
        /// <summary>
        /// Return those ActivityNodes contained immediately within the <see cref="StructuredActivityNode"/> that may act as targets of edges owned by the <see cref="StructuredActivityNode"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (node->union(output.oclAsType(ActivityNode)->asSet())->
        ///       union(node->select(oclIsKindOf(Action)).oclAsType(Action).input)->asSet())
        ///   ]]>
        ///   xmi:id="StructuredActivityNode-targetNodes-spec"
        /// </rule>
        /// xmi:id="StructuredActivityNode-targetNodes"
        /// xmi:is-query="true"
        ActivityNode[] targetNodes();
        #endregion
        }
    }

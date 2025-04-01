using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="Activity"/> is the <see cref="Specification"/> of parameterized <see cref="Behavior"/> as the coordinated sequencing of subordinate units.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="Parameter"/> with direction other than inout must have exactly one <see cref="ActivityParameterNode"/> in an <see cref="Activity"/>.
    ///   <![CDATA[
    ///     ownedParameter->forAll(p | 
    ///        p.direction <> ParameterDirectionKind::inout implies node->select(
    ///            oclIsKindOf(ActivityParameterNode) and oclAsType(ActivityParameterNode).parameter = p)->size()= 1)
    ///   ]]>
    ///   xmi:id="Activity-maximum_one_parameter_node"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Parameter"/> with direction inout must have exactly two ActivityParameterNodes in an <see cref="Activity"/>, at most one with incoming ActivityEdges and at most one with outgoing ActivityEdges.
    ///   <![CDATA[
    ///     ownedParameter->forAll(p | 
    ///     p.direction = ParameterDirectionKind::inout implies
    ///     let associatedNodes : Set(ActivityNode) = node->select(
    ///            oclIsKindOf(ActivityParameterNode) and oclAsType(ActivityParameterNode).parameter = p) in 
    ///       associatedNodes->size()=2 and
    ///       associatedNodes->select(incoming->notEmpty())->size()<=1 and
    ///       associatedNodes->select(outgoing->notEmpty())->size()<=1
    ///     )
    ///     
    ///   ]]>
    ///   xmi:id="Activity-maximum_two_parameter_nodes"
    /// </rule>
    /// xmi:id="Activity"
    public interface Activity : Behavior
        {
        #region P:Edge:IList<ActivityEdge>
        /// <summary>
        /// ActivityEdges expressing flow between the nodes of the <see cref="Activity"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Activity-edge"
        /// xmi:aggregation="composite"
        /// xmi:association="A_edge_activity"
        IList<ActivityEdge> Edge { get; }
        #endregion
        #region P:Group:IList<ActivityGroup>
        /// <summary>
        /// Top-level ActivityGroups in the <see cref="Activity"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Activity-group"
        /// xmi:aggregation="composite"
        /// xmi:association="A_group_inActivity"
        IList<ActivityGroup> Group { get; }
        #endregion
        #region P:IsReadOnly:Boolean
        /// <summary>
        /// If true, this <see cref="Activity"/> must not make any changes to objects. The default is false (an <see cref="Activity"/> may make nonlocal changes). (This is an assertion, not an executable property. It may be used by an execution engine to optimize model execution. If the assertion is violated by the <see cref="Activity"/>, then the model is ill-formed.) 
        /// </summary>
        /// xmi:id="Activity-isReadOnly"
        Boolean IsReadOnly { get;set; }
        #endregion
        #region P:IsSingleExecution:Boolean
        /// <summary>
        /// If true, all invocations of the <see cref="Activity"/> are handled by the same execution.
        /// </summary>
        /// xmi:id="Activity-isSingleExecution"
        Boolean IsSingleExecution { get;set; }
        #endregion
        #region P:Node:IList<ActivityNode>
        /// <summary>
        /// ActivityNodes coordinated by the <see cref="Activity"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Activity-node"
        /// xmi:aggregation="composite"
        /// xmi:association="A_node_activity"
        IList<ActivityNode> Node { get; }
        #endregion
        #region P:Partition:IList<ActivityPartition>
        /// <summary>
        /// Top-level ActivityPartitions in the <see cref="Activity"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Activity.Group"/>"
        /// </summary>
        /// xmi:id="Activity-partition"
        /// xmi:association="A_partition_activity"
        IList<ActivityPartition> Partition { get; }
        #endregion
        #region P:StructuredNode:IList<StructuredActivityNode>
        /// <summary>
        /// Top-level StructuredActivityNodes in the <see cref="Activity"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Activity.Group"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Activity.Node"/>"
        /// </summary>
        /// xmi:id="Activity-structuredNode"
        /// xmi:aggregation="composite"
        /// xmi:association="A_structuredNode_activity"
        IList<StructuredActivityNode> StructuredNode { get; }
        #endregion
        #region P:Variable:IList<Variable>
        /// <summary>
        /// Top-level Variables defined by the <see cref="Activity"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Activity-variable"
        /// xmi:aggregation="composite"
        /// xmi:association="A_variable_activityScope"
        IList<Variable> Variable { get; }
        #endregion
        }
    }

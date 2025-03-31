using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ActivityEdge"/> is an abstract class for directed connections between two ActivityNodes.
    /// </summary>
    /// <rule language="OCL">
    ///   If an <see cref="ActivityEdge"/> is directly owned by an <see cref="Activity"/>, then its source and target must be directly or indirectly contained in the same <see cref="Activity"/>.
    ///   <![CDATA[
    ///     activity<>null implies source.containingActivity() = activity and target.containingActivity() = activity
    ///   ]]>
    ///   xmi:id="ActivityEdge-source_and_target"
    /// </rule>
    /// xmi:id="ActivityEdge"
    public interface ActivityEdge : RedefinableElement
        {
        #region P:Activity:Activity
        /// <summary>
        /// The <see cref="Activity"/> containing the <see cref="ActivityEdge"/>, if it is directly owned by an <see cref="Activity"/>.
        /// </summary>
        /// xmi:id="ActivityEdge-activity"
        /// xmi:association="A_edge_activity"
        /// xmi:subsets="Element-owner"
        [Multiplicity("0..1")]
        Activity Activity { get; }
        #endregion
        #region P:Guard:ValueSpecification
        /// <summary>
        /// A <see cref="ValueSpecification"/> that is evaluated to determine if a token can traverse the <see cref="ActivityEdge"/>. If an <see cref="ActivityEdge"/> has no <see cref="Guard"/>, then there is no restriction on tokens traversing the edge.
        /// </summary>
        /// xmi:id="ActivityEdge-guard"
        /// xmi:aggregation="composite"
        /// xmi:association="A_guard_activityEdge"
        /// xmi:subsets="Element-ownedElement"
        [Multiplicity("0..1")]
        ValueSpecification Guard { get; }
        #endregion
        #region P:InGroup:ActivityGroup[]
        /// <summary>
        /// ActivityGroups containing the <see cref="ActivityEdge"/>.
        /// </summary>
        /// xmi:id="ActivityEdge-inGroup"
        /// xmi:association="A_containedEdge_inGroup"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Union]
        ActivityGroup[] InGroup { get; }
        #endregion
        #region P:InPartition:ActivityPartition[]
        /// <summary>
        /// ActivityPartitions containing the <see cref="ActivityEdge"/>.
        /// </summary>
        /// xmi:id="ActivityEdge-inPartition"
        /// xmi:association="A_edge_inPartition"
        /// xmi:subsets="ActivityEdge-inGroup"
        ActivityPartition[] InPartition { get; }
        #endregion
        #region P:InStructuredNode:StructuredActivityNode
        /// <summary>
        /// The <see cref="StructuredActivityNode"/> containing the <see cref="ActivityEdge"/>, if it is owned by a <see cref="StructuredActivityNode"/>.
        /// </summary>
        /// xmi:id="ActivityEdge-inStructuredNode"
        /// xmi:association="A_edge_inStructuredNode"
        /// xmi:subsets="ActivityEdge-inGroup"
        /// xmi:subsets="Element-owner"
        [Multiplicity("0..1")]
        StructuredActivityNode InStructuredNode { get; }
        #endregion
        #region P:Interrupts:InterruptibleActivityRegion
        /// <summary>
        /// The <see cref="InterruptibleActivityRegion"/> for which this <see cref="ActivityEdge"/> is an interruptingEdge.
        /// </summary>
        /// xmi:id="ActivityEdge-interrupts"
        /// xmi:association="A_interruptingEdge_interrupts"
        [Multiplicity("0..1")]
        InterruptibleActivityRegion Interrupts { get; }
        #endregion
        #region P:RedefinedEdge:ActivityEdge[]
        /// <summary>
        /// ActivityEdges from a generalization of the <see cref="Activity"/> containing this <see cref="ActivityEdge"/> that are redefined by this <see cref="ActivityEdge"/>.
        /// </summary>
        /// xmi:id="ActivityEdge-redefinedEdge"
        /// xmi:association="A_redefinedEdge_activityEdge"
        /// xmi:subsets="RedefinableElement-redefinedElement"
        ActivityEdge[] RedefinedEdge { get; }
        #endregion
        #region P:Source:ActivityNode
        /// <summary>
        /// The <see cref="ActivityNode"/> from which tokens are taken when they traverse the <see cref="ActivityEdge"/>.
        /// </summary>
        /// xmi:id="ActivityEdge-source"
        /// xmi:association="A_outgoing_source_node"
        ActivityNode Source { get; }
        #endregion
        #region P:Target:ActivityNode
        /// <summary>
        /// The <see cref="ActivityNode"/> to which tokens are put when they traverse the <see cref="ActivityEdge"/>.
        /// </summary>
        /// xmi:id="ActivityEdge-target"
        /// xmi:association="A_incoming_target_node"
        ActivityNode Target { get; }
        #endregion
        #region P:Weight:ValueSpecification
        /// <summary>
        /// The minimum number of tokens that must traverse the <see cref="ActivityEdge"/> at the same time. If no <see cref="Weight"/> is specified, this is equivalent to specifying a constant value of 1.
        /// </summary>
        /// xmi:id="ActivityEdge-weight"
        /// xmi:aggregation="composite"
        /// xmi:association="A_weight_activityEdge"
        /// xmi:subsets="Element-ownedElement"
        [Multiplicity("0..1")]
        ValueSpecification Weight { get; }
        #endregion

        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (redefiningElement.oclIsKindOf(ActivityEdge))
        ///   ]]>
        ///   xmi:id="ActivityEdge-isConsistentWith-spec"
        /// </rule>
        /// xmi:id="ActivityEdge-isConsistentWith"
        /// xmi:is-query="true"
        /// xmi:redefines="RedefinableElement-isConsistentWith{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>}"
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        }
    }

using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="ActivityNode"/> is an abstract class for points in the flow of an <see cref="Activity"/> connected by ActivityEdges.
    /// </summary>
    /// xmi:id="ActivityNode"
    public interface ActivityNode : RedefinableElement
        {
        #region P:Activity:Activity
        /// <summary>
        /// The <see cref="Activity"/> containing the <see cref="ActivityNode"/>, if it is directly owned by an <see cref="Activity"/>.
        /// </summary>
        /// xmi:id="ActivityNode-activity"
        /// xmi:association="A_node_activity"
        /// xmi:subsets="Element-owner"
        [Multiplicity("0..1")]
        Activity Activity { get; }
        #endregion
        #region P:Incoming:ActivityEdge[]
        /// <summary>
        /// ActivityEdges that have the <see cref="ActivityNode"/> as their target.
        /// </summary>
        /// xmi:id="ActivityNode-incoming"
        /// xmi:association="A_incoming_target_node"
        ActivityEdge[] Incoming { get; }
        #endregion
        #region P:InGroup:ActivityGroup[]
        /// <summary>
        /// ActivityGroups containing the <see cref="ActivityNode"/>.
        /// </summary>
        /// xmi:id="ActivityNode-inGroup"
        /// xmi:association="A_containedNode_inGroup"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Union]
        ActivityGroup[] InGroup { get; }
        #endregion
        #region P:InInterruptibleRegion:InterruptibleActivityRegion[]
        /// <summary>
        /// InterruptibleActivityRegions containing the <see cref="ActivityNode"/>.
        /// </summary>
        /// xmi:id="ActivityNode-inInterruptibleRegion"
        /// xmi:association="A_inInterruptibleRegion_node"
        /// xmi:subsets="ActivityNode-inGroup"
        InterruptibleActivityRegion[] InInterruptibleRegion { get; }
        #endregion
        #region P:InPartition:ActivityPartition[]
        /// <summary>
        /// ActivityPartitions containing the <see cref="ActivityNode"/>.
        /// </summary>
        /// xmi:id="ActivityNode-inPartition"
        /// xmi:association="A_inPartition_node"
        /// xmi:subsets="ActivityNode-inGroup"
        ActivityPartition[] InPartition { get; }
        #endregion
        #region P:InStructuredNode:StructuredActivityNode
        /// <summary>
        /// The <see cref="StructuredActivityNode"/> containing the ActvityNode, if it is directly owned by a <see cref="StructuredActivityNode"/>.
        /// </summary>
        /// xmi:id="ActivityNode-inStructuredNode"
        /// xmi:association="A_node_inStructuredNode"
        /// xmi:subsets="ActivityNode-inGroup"
        /// xmi:subsets="Element-owner"
        [Multiplicity("0..1")]
        StructuredActivityNode InStructuredNode { get; }
        #endregion
        #region P:Outgoing:ActivityEdge[]
        /// <summary>
        /// ActivityEdges that have the <see cref="ActivityNode"/> as their source.
        /// </summary>
        /// xmi:id="ActivityNode-outgoing"
        /// xmi:association="A_outgoing_source_node"
        ActivityEdge[] Outgoing { get; }
        #endregion
        #region P:RedefinedNode:ActivityNode[]
        /// <summary>
        /// ActivityNodes from a generalization of the <see cref="Activity"/> containining this <see cref="ActivityNode"/> that are redefined by this <see cref="ActivityNode"/>.
        /// </summary>
        /// xmi:id="ActivityNode-redefinedNode"
        /// xmi:association="A_redefinedNode_activityNode"
        /// xmi:subsets="RedefinableElement-redefinedElement"
        ActivityNode[] RedefinedNode { get; }
        #endregion

        #region M:containingActivity:Activity
        /// <summary>
        /// The <see cref="Activity"/> that directly or indirectly contains this <see cref="ActivityNode"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if inStructuredNode<>null then inStructuredNode.containingActivity()
        ///     else activity
        ///     endif)
        ///   ]]>
        ///   xmi:id="ActivityNode-containingActivity-spec"
        /// </rule>
        /// xmi:id="ActivityNode-containingActivity"
        /// xmi:is-query="true"
        Activity containingActivity();
        #endregion
        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (redefiningElement.oclIsKindOf(ActivityNode))
        ///   ]]>
        ///   xmi:id="ActivityNode-isConsistentWith-spec"
        /// </rule>
        /// xmi:id="ActivityNode-isConsistentWith"
        /// xmi:is-query="true"
        /// xmi:redefines="RedefinableElement-isConsistentWith{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>}"
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        }
    }

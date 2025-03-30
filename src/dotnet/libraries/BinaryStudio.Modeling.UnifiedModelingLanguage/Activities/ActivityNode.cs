using System;

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
        Activity Activity { get; }
        #endregion
        #region P:InGroup:ActivityGroup[]
        /// <summary>
        /// ActivityGroups containing the <see cref="ActivityNode"/>.
        /// </summary>
        /// xmi:id="ActivityNode-inGroup"
        ActivityGroup[] InGroup { get; }
        #endregion
        #region P:InInterruptibleRegion:InterruptibleActivityRegion[]
        /// <summary>
        /// InterruptibleActivityRegions containing the <see cref="ActivityNode"/>.
        /// </summary>
        /// xmi:id="ActivityNode-inInterruptibleRegion"
        InterruptibleActivityRegion[] InInterruptibleRegion { get; }
        #endregion
        #region P:InPartition:ActivityPartition[]
        /// <summary>
        /// ActivityPartitions containing the <see cref="ActivityNode"/>.
        /// </summary>
        /// xmi:id="ActivityNode-inPartition"
        ActivityPartition[] InPartition { get; }
        #endregion
        #region P:InStructuredNode:StructuredActivityNode
        /// <summary>
        /// The <see cref="StructuredActivityNode"/> containing the ActvityNode, if it is directly owned by a <see cref="StructuredActivityNode"/>.
        /// </summary>
        /// xmi:id="ActivityNode-inStructuredNode"
        StructuredActivityNode InStructuredNode { get; }
        #endregion
        #region P:Incoming:ActivityEdge[]
        /// <summary>
        /// ActivityEdges that have the <see cref="ActivityNode"/> as their target.
        /// </summary>
        /// xmi:id="ActivityNode-incoming"
        ActivityEdge[] Incoming { get; }
        #endregion
        #region P:Outgoing:ActivityEdge[]
        /// <summary>
        /// ActivityEdges that have the <see cref="ActivityNode"/> as their source.
        /// </summary>
        /// xmi:id="ActivityNode-outgoing"
        ActivityEdge[] Outgoing { get; }
        #endregion
        #region P:RedefinedNode:ActivityNode[]
        /// <summary>
        /// ActivityNodes from a generalization of the <see cref="Activity"/> containining this <see cref="ActivityNode"/> that are redefined by this <see cref="ActivityNode"/>.
        /// </summary>
        /// xmi:id="ActivityNode-redefinedNode"
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

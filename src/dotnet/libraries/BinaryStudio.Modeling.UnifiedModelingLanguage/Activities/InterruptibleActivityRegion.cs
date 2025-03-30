using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="InterruptibleActivityRegion"/> is an <see cref="ActivityGroup"/> that supports the termination of tokens flowing in the portions of an activity within it.
    /// </summary>
    /// <rule language="OCL">
    ///   The interruptingEdges of an <see cref="InterruptibleActivityRegion"/> must have their source in the region and their target outside the region, but within the same <see cref="Activity"/> containing the region.
    ///   <![CDATA[
    ///     interruptingEdge->forAll(edge | 
    ///       node->includes(edge.source) and node->excludes(edge.target) and edge.target.containingActivity() = inActivity)
    ///   ]]>
    ///   xmi:id="InterruptibleActivityRegion-interrupting_edges"
    /// </rule>
    /// xmi:id="InterruptibleActivityRegion"
    public interface InterruptibleActivityRegion : ActivityGroup
        {
        #region P:InterruptingEdge:ActivityEdge[]
        /// <summary>
        /// The ActivityEdges leaving the <see cref="InterruptibleActivityRegion"/> on which a traversing token will result in the termination of other tokens flowing in the <see cref="InterruptibleActivityRegion"/>.
        /// </summary>
        /// xmi:id="InterruptibleActivityRegion-interruptingEdge"
        ActivityEdge[] InterruptingEdge { get; }
        #endregion
        #region P:Node:ActivityNode[]
        /// <summary>
        /// ActivityNodes immediately contained in the <see cref="InterruptibleActivityRegion"/>.
        /// </summary>
        /// xmi:id="InterruptibleActivityRegion-node"
        ActivityNode[] Node { get; }
        #endregion
        }
    }

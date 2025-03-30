using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="ActivityGroup"/> is an abstract class for defining sets of ActivityNodes and ActivityEdges in an <see cref="Activity"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   All containedNodes and containeEdges of an <see cref="ActivityGroup"/> must be in the same <see cref="Activity"/> as the group.
    ///   <![CDATA[
    ///     containedNode->forAll(activity = self.containingActivity()) and 
    ///     containedEdge->forAll(activity = self.containingActivity())
    ///   ]]>
    ///   xmi:id="ActivityGroup-nodes_and_edges"
    /// </rule>
    /// <rule language="OCL">
    ///   No containedNode or containedEdge of an <see cref="ActivityGroup"/> may be contained by its subgroups or its superGroups, transitively.
    ///   <![CDATA[
    ///     subgroup->closure(subgroup).containedNode->excludesAll(containedNode) and
    ///     superGroup->closure(superGroup).containedNode->excludesAll(containedNode) and 
    ///     subgroup->closure(subgroup).containedEdge->excludesAll(containedEdge) and 
    ///     superGroup->closure(superGroup).containedEdge->excludesAll(containedEdge)
    ///   ]]>
    ///   xmi:id="ActivityGroup-not_contained"
    /// </rule>
    /// xmi:id="ActivityGroup"
    public interface ActivityGroup : NamedElement
        {
        #region P:ContainedEdge:ActivityEdge[]
        /// <summary>
        /// ActivityEdges immediately contained in the <see cref="ActivityGroup"/>.
        /// </summary>
        /// xmi:id="ActivityGroup-containedEdge"
        ActivityEdge[] ContainedEdge { get; }
        #endregion
        #region P:ContainedNode:ActivityNode[]
        /// <summary>
        /// ActivityNodes immediately contained in the <see cref="ActivityGroup"/>.
        /// </summary>
        /// xmi:id="ActivityGroup-containedNode"
        ActivityNode[] ContainedNode { get; }
        #endregion
        #region P:InActivity:Activity
        /// <summary>
        /// The <see cref="Activity"/> containing the <see cref="ActivityGroup"/>, if it is directly owned by an <see cref="Activity"/>.
        /// </summary>
        /// xmi:id="ActivityGroup-inActivity"
        Activity InActivity { get; }
        #endregion
        #region P:Subgroup:ActivityGroup[]
        /// <summary>
        /// Other ActivityGroups immediately contained in this <see cref="ActivityGroup"/>.
        /// </summary>
        /// xmi:id="ActivityGroup-subgroup"
        /// xmi:aggregation="composite"
        ActivityGroup[] Subgroup { get; }
        #endregion
        #region P:SuperGroup:ActivityGroup
        /// <summary>
        /// The <see cref="ActivityGroup"/> immediately containing this <see cref="ActivityGroup"/>, if it is directly owned by another <see cref="ActivityGroup"/>.
        /// </summary>
        /// xmi:id="ActivityGroup-superGroup"
        ActivityGroup SuperGroup { get; }
        #endregion

        #region M:containingActivity:Activity
        /// <summary>
        /// The <see cref="Activity"/> that directly or indirectly contains this <see cref="ActivityGroup"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if superGroup<>null then superGroup.containingActivity()
        ///     else inActivity
        ///     endif)
        ///   ]]>
        ///   xmi:id="ActivityGroup-containingActivity-spec"
        /// </rule>
        /// xmi:id="ActivityGroup-containingActivity"
        /// xmi:is-query="true"
        Activity containingActivity();
        #endregion
        }
    }

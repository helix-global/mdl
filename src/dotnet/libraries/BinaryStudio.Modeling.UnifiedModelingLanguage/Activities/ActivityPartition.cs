using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ActivityPartition"/> is a kind of <see cref="ActivityGroup"/> for identifying ActivityNodes that have some characteristic in common.
    /// </summary>
    /// <rule language="OCL">
    ///   If a non-external <see cref="ActivityPartition"/> represents a <see cref="Classifier"/> and has a superPartition, then the superPartition must represent a <see cref="Classifier"/>, and the <see cref="Classifier"/> of the subpartition must be nested (nestedClassifier or ownedBehavior) in the <see cref="Classifier"/> represented by the superPartition, or be at the contained end of a composition <see cref="Association"/> with the <see cref="Classifier"/> represented by the superPartition.
    ///   <![CDATA[
    ///     (not isExternal and represents.oclIsKindOf(Classifier) and superPartition->notEmpty()) implies
    ///     (
    ///        let representedClassifier : Classifier = represents.oclAsType(Classifier) in
    ///          superPartition.represents.oclIsKindOf(Classifier) and
    ///           let representedSuperClassifier : Classifier = superPartition.represents.oclAsType(Classifier) in
    ///            (representedSuperClassifier.oclIsKindOf(BehavioredClassifier) and representedClassifier.oclIsKindOf(Behavior) and 
    ///             representedSuperClassifier.oclAsType(BehavioredClassifier).ownedBehavior->includes(representedClassifier.oclAsType(Behavior))) 
    ///            or
    ///            (representedSuperClassifier.oclIsKindOf(Class) and  representedSuperClassifier.oclAsType(Class).nestedClassifier->includes(representedClassifier))
    ///            or
    ///            (Association.allInstances()->exists(a | a.memberEnd->exists(end1 | end1.isComposite and end1.type = representedClassifier and 
    ///                                                                           a.memberEnd->exists(end2 | end1<>end2 and end2.type = representedSuperClassifier))))
    ///     )
    ///   ]]>
    ///   xmi:id="ActivityPartition-represents_classifier"
    /// </rule>
    /// <rule language="OCL">
    ///   If an <see cref="ActivityPartition"/> represents a <see cref="Property"/> and has a superPartition, then the <see cref="Property"/> must be of a <see cref="Classifier"/> represented by the superPartition, or of a <see cref="Classifier"/> that is the type of a <see cref="Property"/> represented by the superPartition.
    ///   <![CDATA[
    ///     (represents.oclIsKindOf(Property) and superPartition->notEmpty()) implies
    ///     (
    ///       (superPartition.represents.oclIsKindOf(Classifier) and represents.owner = superPartition.represents) or 
    ///       (superPartition.represents.oclIsKindOf(Property) and represents.owner = superPartition.represents.oclAsType(Property).type)
    ///     )
    ///   ]]>
    ///   xmi:id="ActivityPartition-represents_property_and_is_contained"
    /// </rule>
    /// <rule language="OCL">
    ///   If an <see cref="ActivityPartition"/> represents a <see cref="Property"/> and has a superPartition representing a <see cref="Classifier"/>, then all the other non-external subpartitions of the superPartition must represent Properties directly owned by the same <see cref="Classifier"/>.
    ///   <![CDATA[
    ///     (represents.oclIsKindOf(Property) and superPartition->notEmpty() and superPartition.represents.oclIsKindOf(Classifier)) implies
    ///     (
    ///       let representedClassifier : Classifier = superPartition.represents.oclAsType(Classifier)
    ///       in
    ///         superPartition.subpartition->reject(isExternal)->forAll(p | 
    ///            p.represents.oclIsKindOf(Property) and p.owner=representedClassifier)
    ///     )
    ///   ]]>
    ///   xmi:id="ActivityPartition-represents_property"
    /// </rule>
    /// <rule language="OCL">
    ///   An ActvivityPartition with isDimension = true may not be contained by another <see cref="ActivityPartition"/>.
    ///   <![CDATA[
    ///     isDimension implies superPartition->isEmpty()
    ///   ]]>
    ///   xmi:id="ActivityPartition-dimension_not_contained"
    /// </rule>
    /// xmi:id="ActivityPartition"
    public interface ActivityPartition : ActivityGroup
        {
        #region P:Edge:IList<ActivityEdge>
        /// <summary>
        /// ActivityEdges immediately contained in the <see cref="ActivityPartition"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.ActivityGroup.ContainedEdge"/>"
        /// </summary>
        /// xmi:id="ActivityPartition-edge"
        /// xmi:association="A_edge_inPartition"
        IList<ActivityEdge> Edge { get; }
        #endregion
        #region P:IsDimension:Boolean
        /// <summary>
        /// Indicates whether the <see cref="ActivityPartition"/> groups other ActivityPartitions along a dimension.
        /// </summary>
        /// xmi:id="ActivityPartition-isDimension"
        Boolean IsDimension { get;set; }
        #endregion
        #region P:IsExternal:Boolean
        /// <summary>
        /// Indicates whether the <see cref="ActivityPartition"/> <see cref="Represents"/> an entity to which the partitioning structure does not apply.
        /// </summary>
        /// xmi:id="ActivityPartition-isExternal"
        Boolean IsExternal { get;set; }
        #endregion
        #region P:Node:IList<ActivityNode>
        /// <summary>
        /// ActivityNodes immediately contained in the <see cref="ActivityPartition"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.ActivityGroup.ContainedNode"/>"
        /// </summary>
        /// xmi:id="ActivityPartition-node"
        /// xmi:association="A_inPartition_node"
        IList<ActivityNode> Node { get; }
        #endregion
        #region P:Represents:Element
        /// <summary>
        /// An <see cref="Element"/> represented by the functionality modeled within the <see cref="ActivityPartition"/>.
        /// </summary>
        /// xmi:id="ActivityPartition-represents"
        /// xmi:association="A_represents_activityPartition"
        [Multiplicity("0..1")]
        Element Represents { get;set; }
        #endregion
        #region P:Subpartition:IList<ActivityPartition>
        /// <summary>
        /// Other ActivityPartitions immediately contained in this <see cref="ActivityPartition"/> (as its subgroups).
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.ActivityGroup.Subgroup"/>"
        /// </summary>
        /// xmi:id="ActivityPartition-subpartition"
        /// xmi:aggregation="composite"
        /// xmi:association="A_subpartition_superPartition"
        IList<ActivityPartition> Subpartition { get; }
        #endregion
        #region P:SuperPartition:ActivityPartition
        /// <summary>
        /// Other ActivityPartitions immediately containing this <see cref="ActivityPartition"/> (as its superGroups).
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.ActivityGroup.SuperGroup"/>"
        /// </summary>
        /// xmi:id="ActivityPartition-superPartition"
        /// xmi:association="A_subpartition_superPartition"
        [Multiplicity("0..1")]
        ActivityPartition SuperPartition { get;set; }
        #endregion
        }
    }

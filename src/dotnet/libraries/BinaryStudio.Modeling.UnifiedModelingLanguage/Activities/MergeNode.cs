using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A merge node is a control node that brings together multiple alternate flows. It is not used to synchronize concurrent flows but to accept one among several alternate flows.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="MergeNode"/> has one outgoing <see cref="ActivityEdge"/>.
    ///   <![CDATA[
    ///     outgoing->size()=1
    ///   ]]>
    ///   xmi:id="MergeNode-one_outgoing_edge"
    /// </rule>
    /// <rule language="OCL">
    ///   The ActivityEdges incoming to and outgoing from a <see cref="MergeNode"/> must be either all ObjectFlows or all ControlFlows.
    ///   <![CDATA[
    ///     let allEdges : Set(ActivityEdge) = incoming->union(outgoing) in
    ///     allEdges->forAll(oclIsKindOf(ControlFlow)) or allEdges->forAll(oclIsKindOf(ObjectFlow))
    ///     
    ///   ]]>
    ///   xmi:id="MergeNode-edges"
    /// </rule>
    /// xmi:id="MergeNode"
    public interface MergeNode : ControlNode
        {
        }
    }

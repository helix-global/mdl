using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ForkNode"/> is a <see cref="ControlNode"/> that splits a flow into multiple concurrent flows.
    /// </summary>
    /// <rule language="OCL">
    ///   The ActivityEdges incoming to and outgoing from a <see cref="ForkNode"/> must be either all ObjectFlows or all ControlFlows.
    ///   <![CDATA[
    ///     let allEdges : Set(ActivityEdge) = incoming->union(outgoing) in
    ///     allEdges->forAll(oclIsKindOf(ControlFlow)) or allEdges->forAll(oclIsKindOf(ObjectFlow))
    ///     
    ///   ]]>
    ///   xmi:id="ForkNode-edges"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="ForkNode"/> has one incoming <see cref="ActivityEdge"/>.
    ///   <![CDATA[
    ///     incoming->size()=1
    ///   ]]>
    ///   xmi:id="ForkNode-one_incoming_edge"
    /// </rule>
    /// xmi:id="ForkNode"
    public interface ForkNode : ControlNode
        {
        }
    }

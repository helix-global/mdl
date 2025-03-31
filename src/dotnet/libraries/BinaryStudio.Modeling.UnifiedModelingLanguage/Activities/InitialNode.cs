using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="InitialNode"/> is a <see cref="ControlNode"/> that offers a single control token when initially enabled.
    /// </summary>
    /// <rule language="OCL">
    ///   An <see cref="InitialNode"/> has no incoming ActivityEdges.
    ///   <![CDATA[
    ///     incoming->isEmpty()
    ///   ]]>
    ///   xmi:id="InitialNode-no_incoming_edges"
    /// </rule>
    /// <rule language="OCL">
    ///   All the outgoing ActivityEdges from an <see cref="InitialNode"/> must be ControlFlows.
    ///   <![CDATA[
    ///     outgoing->forAll(oclIsKindOf(ControlFlow))
    ///   ]]>
    ///   xmi:id="InitialNode-control_edges"
    /// </rule>
    /// xmi:id="InitialNode"
    public interface InitialNode : ControlNode
        {
        }
    }

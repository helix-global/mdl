using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="OutputPin"/> is a <see cref="Pin"/> that holds output values produced by an <see cref="Action"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   An <see cref="OutputPin"/> may have incoming ActivityEdges only when it is owned by a <see cref="StructuredActivityNode"/>, and these edges must have sources contained (directly or indirectly) in the owning <see cref="StructuredActivityNode"/>.
    ///   <![CDATA[
    ///     incoming->notEmpty() implies
    ///     	action<>null and
    ///     	action.oclIsKindOf(StructuredActivityNode) and
    ///     	action.oclAsType(StructuredActivityNode).allOwnedNodes()->includesAll(incoming.source)
    ///   ]]>
    ///   xmi:id="OutputPin-incoming_edges_structured_only"
    /// </rule>
    /// xmi:id="OutputPin"
    public interface OutputPin : Pin
        {
        }
    }

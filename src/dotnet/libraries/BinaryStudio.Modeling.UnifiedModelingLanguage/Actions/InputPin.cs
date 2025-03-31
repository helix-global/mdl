using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="InputPin"/> is a <see cref="Pin"/> that holds input values to be consumed by an <see cref="Action"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   An <see cref="InputPin"/> may have outgoing ActivityEdges only when it is owned by a <see cref="StructuredActivityNode"/>, and these edges must target a node contained (directly or indirectly) in the owning <see cref="StructuredActivityNode"/>.
    ///   <![CDATA[
    ///     outgoing->notEmpty() implies
    ///     	action<>null and
    ///     	action.oclIsKindOf(StructuredActivityNode) and
    ///     	action.oclAsType(StructuredActivityNode).allOwnedNodes()->includesAll(outgoing.target)
    ///   ]]>
    ///   xmi:id="InputPin-outgoing_edges_structured_only"
    /// </rule>
    /// xmi:id="InputPin"
    public interface InputPin : Pin
        {
        }
    }

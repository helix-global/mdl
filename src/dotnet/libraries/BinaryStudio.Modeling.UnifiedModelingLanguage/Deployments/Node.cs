using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Node"/> is computational resource upon which artifacts may be deployed for execution. Nodes can be interconnected through communication paths to define network structures.
    /// </summary>
    /// <rule language="OCL">
    ///   The internal structure of a <see cref="Node"/> (if defined) consists solely of parts of type <see cref="Node"/>.
    ///   <![CDATA[
    ///     part->forAll(oclIsKindOf(Node))
    ///   ]]>
    ///   xmi:id="Node-internal_structure"
    /// </rule>
    /// xmi:id="Node"
    public interface Node : DeploymentTarget,Class
        {
        #region P:NestedNode:Node[]
        /// <summary>
        /// The Nodes that are defined (nested) within the <see cref="Node"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Node-nestedNode"
        /// xmi:aggregation="composite"
        /// xmi:association="A_nestedNode_node"
        Node[] NestedNode { get; }
        #endregion
        }
    }

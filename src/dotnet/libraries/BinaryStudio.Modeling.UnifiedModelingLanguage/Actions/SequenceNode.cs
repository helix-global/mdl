using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="SequenceNode"/> is a <see cref="StructuredActivityNode"/> that executes a sequence of ExecutableNodes in order.
    /// </summary>
    /// xmi:id="SequenceNode"
    public interface SequenceNode : StructuredActivityNode
        {
        #region P:ExecutableNode:ExecutableNode[]
        /// <summary>
        /// The ordered set of ExecutableNodes to be sequenced.
        /// </summary>
        /// xmi:id="SequenceNode-executableNode"
        /// xmi:aggregation="composite"
        /// xmi:association="A_executableNode_sequenceNode"
        /// xmi:redefines="StructuredActivityNode-node{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.StructuredActivityNode.Node"/>}"
        [Ordered]
        ExecutableNode[] ExecutableNode { get; }
        #endregion
        }
    }

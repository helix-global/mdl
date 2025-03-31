using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ExecutableNode"/> is an abstract class for ActivityNodes whose execution may be controlled using ControlFlows and to which ExceptionHandlers may be attached.
    /// </summary>
    /// xmi:id="ExecutableNode"
    public interface ExecutableNode : ActivityNode
        {
        #region P:Handler:ExceptionHandler[]
        /// <summary>
        /// A set of ExceptionHandlers that are examined if an exception propagates out of the ExceptionNode.
        /// </summary>
        /// xmi:id="ExecutableNode-handler"
        /// xmi:aggregation="composite"
        /// xmi:association="A_handler_protectedNode"
        /// xmi:subsets="Element-ownedElement"
        ExceptionHandler[] Handler { get; }
        #endregion
        }
    }

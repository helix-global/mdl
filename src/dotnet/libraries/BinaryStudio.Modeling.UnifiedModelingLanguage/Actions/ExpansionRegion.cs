using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ExpansionRegion"/> is a <see cref="StructuredActivityNode"/> that executes its content multiple times corresponding to elements of <see cref="Input"/> collection(s).
    /// </summary>
    /// xmi:id="ExpansionRegion"
    public interface ExpansionRegion : StructuredActivityNode
        {
        #region P:InputElement:ExpansionNode[]
        /// <summary>
        /// The ExpansionNodes that hold the <see cref="Input"/> collections for the <see cref="ExpansionRegion"/>.
        /// </summary>
        /// xmi:id="ExpansionRegion-inputElement"
        ExpansionNode[] InputElement { get; }
        #endregion
        #region P:Mode:ExpansionKind
        /// <summary>
        /// The <see cref="Mode"/> in which the <see cref="ExpansionRegion"/> executes its contents. If parallel, executions are concurrent. If iterative, executions are sequential. If stream, a stream of values flows into a single execution.
        /// </summary>
        /// xmi:id="ExpansionRegion-mode"
        ExpansionKind Mode { get; }
        #endregion
        #region P:OutputElement:ExpansionNode[]
        /// <summary>
        /// The ExpansionNodes that form the <see cref="Output"/> collections of the <see cref="ExpansionRegion"/>.
        /// </summary>
        /// xmi:id="ExpansionRegion-outputElement"
        ExpansionNode[] OutputElement { get; }
        #endregion
        }
    }

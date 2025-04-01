using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ExpansionRegion"/> is a <see cref="StructuredActivityNode"/> that executes its content multiple times corresponding to elements of <see cref="Input"/> collection(s).
    /// </summary>
    /// xmi:id="ExpansionRegion"
    public interface ExpansionRegion : StructuredActivityNode
        {
        #region P:InputElement:IList<ExpansionNode>
        /// <summary>
        /// The ExpansionNodes that hold the <see cref="Input"/> collections for the <see cref="ExpansionRegion"/>.
        /// </summary>
        /// xmi:id="ExpansionRegion-inputElement"
        /// xmi:association="A_inputElement_regionAsInput"
        [Multiplicity("1..*")]
        IList<ExpansionNode> InputElement { get; }
        #endregion
        #region P:Mode:ExpansionKind
        /// <summary>
        /// The <see cref="Mode"/> in which the <see cref="ExpansionRegion"/> executes its contents. If parallel, executions are concurrent. If iterative, executions are sequential. If stream, a stream of values flows into a single execution.
        /// </summary>
        /// xmi:id="ExpansionRegion-mode"
        ExpansionKind Mode { get;set; }
        #endregion
        #region P:OutputElement:IList<ExpansionNode>
        /// <summary>
        /// The ExpansionNodes that form the <see cref="Output"/> collections of the <see cref="ExpansionRegion"/>.
        /// </summary>
        /// xmi:id="ExpansionRegion-outputElement"
        /// xmi:association="A_outputElement_regionAsOutput"
        IList<ExpansionNode> OutputElement { get; }
        #endregion
        }
    }

using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="Expression"/> represents a node in an expression tree, which may be non-terminal or terminal. It defines a <see cref="Symbol"/>, and has a possibly empty sequence of operands that are ValueSpecifications. It denotes a (possibly empty) set of values when evaluated in a context.
    /// </summary>
    /// xmi:id="Expression"
    public interface Expression : ValueSpecification
        {
        #region P:Operand:ValueSpecification[]
        /// <summary>
        /// Specifies a sequence of <see cref="Operand"/> ValueSpecifications.
        /// </summary>
        /// xmi:id="Expression-operand"
        /// xmi:aggregation="composite"
        /// xmi:association="A_operand_expression"
        /// xmi:subsets="Element-ownedElement"
        [Ordered]
        ValueSpecification[] Operand { get; }
        #endregion
        #region P:Symbol:String
        /// <summary>
        /// The <see cref="Symbol"/> associated with this node in the expression tree.
        /// </summary>
        /// xmi:id="Expression-symbol"
        [Multiplicity("0..1")]
        String Symbol { get; }
        #endregion
        }
    }

using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="Abstraction"/> is a <see cref="Relationship"/> that relates two Elements or sets of Elements that represent the same concept at different levels of abstraction or from different viewpoints.
    /// </summary>
    /// xmi:id="Abstraction"
    public interface Abstraction : Dependency
        {
        #region P:Mapping:OpaqueExpression
        /// <summary>
        /// An <see cref="OpaqueExpression"/> that states the abstraction relationship between the <see cref="Supplier"/>(s) and the <see cref="Client"/>(s). In some cases, such as derivation, it is usually formal and unidirectional; in other cases, such as trace, it is usually informal and bidirectional. The <see cref="Mapping"/> expression is optional and may be omitted if the precise relationship between the Elements is not specified.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Abstraction-mapping"
        /// xmi:aggregation="composite"
        /// xmi:association="A_mapping_abstraction"
        [Multiplicity("0..1")]
        OpaqueExpression Mapping { get;set; }
        #endregion
        }
    }

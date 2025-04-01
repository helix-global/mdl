using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Slot"/> designates that an entity modeled by an <see cref="InstanceSpecification"/> has a <see cref="Value"/> or values for a specific <see cref="StructuralFeature"/>.
    /// </summary>
    /// xmi:id="Slot"
    public interface Slot : Element
        {
        #region P:DefiningFeature:StructuralFeature
        /// <summary>
        /// The <see cref="StructuralFeature"/> that specifies the values that may be held by the <see cref="Slot"/>.
        /// </summary>
        /// xmi:id="Slot-definingFeature"
        /// xmi:association="A_definingFeature_slot"
        StructuralFeature DefiningFeature { get;set; }
        #endregion
        #region P:OwningInstance:InstanceSpecification
        /// <summary>
        /// The <see cref="InstanceSpecification"/> that owns this <see cref="Slot"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.Owner"/>"
        /// </summary>
        /// xmi:id="Slot-owningInstance"
        /// xmi:association="A_slot_owningInstance"
        InstanceSpecification OwningInstance { get;set; }
        #endregion
        #region P:Value:IList<ValueSpecification>
        /// <summary>
        /// The <see cref="Value"/> or values held by the <see cref="Slot"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Slot-value"
        /// xmi:aggregation="composite"
        /// xmi:association="A_value_owningSlot"
        [Ordered]
        IList<ValueSpecification> Value { get; }
        #endregion
        }
    }

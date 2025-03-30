using System;

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
        StructuralFeature DefiningFeature { get; }
        #endregion
        #region P:OwningInstance:InstanceSpecification
        /// <summary>
        /// The <see cref="InstanceSpecification"/> that owns this <see cref="Slot"/>.
        /// </summary>
        /// xmi:id="Slot-owningInstance"
        InstanceSpecification OwningInstance { get; }
        #endregion
        #region P:Value:ValueSpecification[]
        /// <summary>
        /// The <see cref="Value"/> or values held by the <see cref="Slot"/>.
        /// </summary>
        /// xmi:id="Slot-value"
        /// xmi:aggregation="composite"
        ValueSpecification[] Value { get; }
        #endregion
        }
    }

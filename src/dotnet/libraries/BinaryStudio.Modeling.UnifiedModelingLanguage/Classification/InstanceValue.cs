using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="InstanceValue"/> is a <see cref="ValueSpecification"/> that identifies an <see cref="Instance"/>.
    /// </summary>
    /// xmi:id="InstanceValue"
    public interface InstanceValue : ValueSpecification
        {
        #region P:Instance:InstanceSpecification
        /// <summary>
        /// The <see cref="InstanceSpecification"/> that represents the specified value.
        /// </summary>
        /// xmi:id="InstanceValue-instance"
        InstanceSpecification Instance { get; }
        #endregion
        }
    }

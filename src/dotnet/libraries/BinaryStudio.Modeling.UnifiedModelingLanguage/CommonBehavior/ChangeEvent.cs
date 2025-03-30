using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ChangeEvent"/> models a change in the system configuration that makes a condition true.
    /// </summary>
    /// xmi:id="ChangeEvent"
    public interface ChangeEvent : Event
        {
        #region P:ChangeExpression:ValueSpecification
        /// <summary>
        /// A Boolean-valued <see cref="ValueSpecification"/> that will result in a <see cref="ChangeEvent"/> whenever its value changes from false to true.
        /// </summary>
        /// xmi:id="ChangeEvent-changeExpression"
        /// xmi:aggregation="composite"
        ValueSpecification ChangeExpression { get; }
        #endregion
        }
    }

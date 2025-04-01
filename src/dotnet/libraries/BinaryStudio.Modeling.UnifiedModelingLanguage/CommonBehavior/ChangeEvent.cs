using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

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
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="ChangeEvent-changeExpression"
        /// xmi:aggregation="composite"
        /// xmi:association="A_changeExpression_changeEvent"
        ValueSpecification ChangeExpression { get;set; }
        #endregion
        }
    }

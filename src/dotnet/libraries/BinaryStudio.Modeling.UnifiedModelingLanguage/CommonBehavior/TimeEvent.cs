using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="TimeEvent"/> is an <see cref="Event"/> that occurs at a specific point in time.
    /// </summary>
    /// <rule language="OCL">
    ///   The <see cref="ValueSpecification"/> when must return a non-negative Integer.
    ///   <![CDATA[
    ///     when.integerValue() >= 0
    ///   ]]>
    ///   xmi:id="TimeEvent-when_non_negative"
    /// </rule>
    /// xmi:id="TimeEvent"
    public interface TimeEvent : Event
        {
        #region P:IsRelative:Boolean
        /// <summary>
        /// Specifies whether the <see cref="TimeEvent"/> is specified as an absolute or relative time.
        /// </summary>
        /// xmi:id="TimeEvent-isRelative"
        Boolean IsRelative { get;set; }
        #endregion
        #region P:When:TimeExpression
        /// <summary>
        /// Specifies the time of the <see cref="TimeEvent"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="TimeEvent-when"
        /// xmi:aggregation="composite"
        /// xmi:association="A_when_timeEvent"
        TimeExpression When { get;set; }
        #endregion
        }
    }

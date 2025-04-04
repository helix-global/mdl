﻿using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="OccurrenceSpecification"/> is the basic semantic unit of Interactions. The sequences of occurrences specified by them are the meanings of Interactions.
    /// </summary>
    /// xmi:id="OccurrenceSpecification"
    public interface OccurrenceSpecification : InteractionFragment
        {
        #region P:Covered:Lifeline
        /// <summary>
        /// References the <see cref="Lifeline"/> on which the <see cref="OccurrenceSpecification"/> appears.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.InteractionFragment.Covered"/>"
        /// </summary>
        /// xmi:id="OccurrenceSpecification-covered"
        /// xmi:association="A_covered_events"
        Lifeline Covered { get;set; }
        #endregion
        #region P:ToAfter:IList<GeneralOrdering>
        /// <summary>
        /// References the GeneralOrderings that specify EventOcurrences that must occur after this <see cref="OccurrenceSpecification"/>.
        /// </summary>
        /// xmi:id="OccurrenceSpecification-toAfter"
        /// xmi:association="A_before_toAfter"
        IList<GeneralOrdering> ToAfter { get; }
        #endregion
        #region P:ToBefore:IList<GeneralOrdering>
        /// <summary>
        /// References the GeneralOrderings that specify EventOcurrences that must occur before this <see cref="OccurrenceSpecification"/>.
        /// </summary>
        /// xmi:id="OccurrenceSpecification-toBefore"
        /// xmi:association="A_toBefore_after"
        IList<GeneralOrdering> ToBefore { get; }
        #endregion
        }
    }
